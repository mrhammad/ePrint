<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reports.ascx.cs" Inherits="ePrint.usercontrol.Reports" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdateInitiatorPanelsOnly="true">
    <ClientEvents OnRequestStart="mngRequestStarted" />
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadGridReports">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridReports" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="GridProductReport">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridProductReport" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="GridClientReport">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridClientReport" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridProductReport_Customer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_Customer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGrid_CustomerJobReport">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_CustomerJobReport" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGrid_StockUsageReport">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_StockUsageReport" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGrid_Order_Report">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_Order_Report" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnOrderReportGo">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_Order_Report" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnAllEstimatesbyCustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridAllEstimatesbyCustomer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnAllOrdersbyCustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridAllOrdersbyCustomer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadStockUsage_Packs">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadStockUsage_Packs_MyProj">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs_MyProj" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridProductReport_CustomerNew">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_CustomerNew" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridCustomerYearlyComparison">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridCustomerYearlyComparison" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridItemswithReorderAlertsSet">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridItemswithReorderAlertsSet" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridItemsRequiringReorder">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridItemsRequiringReorder" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridAllEstimatesbyCustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridAllEstimatesbyCustomer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridAllOrdersbyCustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridAllOrdersbyCustomer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridAllJobsbyCustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridAllJobsbyCustomer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridAllInvoicesbyCustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridAllInvoicesbyCustomer" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGridAllInvoicesbyAccountingCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridAllInvoicesbyAccountingCode" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID="lnkBtnClearFilter">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridReports" />
                <telerik:AjaxUpdatedControl ControlID="GridProductReport" />
                <telerik:AjaxUpdatedControl ControlID="GridClientReport" />
                <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_Customer" />
                <telerik:AjaxUpdatedControl ControlID="RadGrid_CustomerJobReport" />
                <telerik:AjaxUpdatedControl ControlID="RadGrid_StockUsageReport" />
                <telerik:AjaxUpdatedControl ControlID="RadGrid_Order_Report" />
                <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs" />
                <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs_MyProj" />
                <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_CustomerNew" />
                <telerik:AjaxUpdatedControl ControlID="RadGridItemswithReorderAlertsSet" />
                <telerik:AjaxUpdatedControl ControlID="RadGridItemsRequiringReorder" />
                <telerik:AjaxUpdatedControl ControlID="RadGridCustomerYearlyComparison" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllEstimatesbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllOrdersbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllJobsbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllInvoicesbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllInvoicesbyAccountingCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="export">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGridReports" />
                <telerik:AjaxUpdatedControl ControlID="GridProductReport" />
                <telerik:AjaxUpdatedControl ControlID="GridClientReport" />
                <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_Customer" />
                <telerik:AjaxUpdatedControl ControlID="RadGrid_CustomerJobReport" />
                <telerik:AjaxUpdatedControl ControlID="RadGrid_StockUsageReport" />
                <telerik:AjaxUpdatedControl ControlID="RadGrid_Order_Report" />
                <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs" />
                <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs_MyProj" />
                <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_CustomerNew" />
                <telerik:AjaxUpdatedControl ControlID="RadGridItemswithReorderAlertsSet" />
                <telerik:AjaxUpdatedControl ControlID="RadGridItemsRequiringReorder" />
                <telerik:AjaxUpdatedControl ControlID="RadGridCustomerYearlyComparison" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllEstimatesbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllOrdersbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllJobsbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllInvoicesbyCustomer" />
                <telerik:AjaxUpdatedControl ControlID="RadGridAllInvoicesbyAccountingCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<script type="text/javascript">
    function mngRequestStarted(sender, eventArgs) {
        if (eventArgs.EventTarget.indexOf("export") != -1) {
            eventArgs.set_enableAjax(false);
        }
    }

</script>
<style type="text/css">
    .RadGrid_Default .rgRow a {
        color: #10357F;
    }

    .RadGrid_Default .rgAltRow a {
        color: #10357F;
    }

    .loadingPanel .raDiv {
        position: fixed;
        z-index: 2;
        background-color: transparent;
        background-position: top;
        background-repeat: no-repeat;
        top: 50%;
    }

    .rgGroupCol {
        width: 1%;
    }

    .RadGrid .rgGroupHeader td p {
        margin-left: -12px;
    }

    .RadGrid_Default .rgFooter td {
        font-weight: bold;
    }

    .rlbList li.rlbDisabled input[type="checkbox"] {
        display: none;
    }

    .RadListBox_Default .rlbList li.rlbDisabled span {
        color: #000000;
    }

    .RadListBox_Default .rlbText, .RadListBox_Default .rlbItem {
        line-height: 12px;
    }

    .RadGrid_Default .rgGroupPanel table {
        color: #555;
    }
</style>
<div id="DIV11" runat="server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" Skin="Default"
        CssClass="loadingPanel" />
</div>
<div class="reportborderWithoutTop">
    <div id="padding">
        <div align="left">
            <asp:Button ID="lnkdownload" runat="server" CssClass="show_hide" OnClick="lnkDownload_OnClick"></asp:Button>
            <asp:Button ID="btnbacksearch" runat="server" CssClass="show_hide" OnClick="Back_Onclick"></asp:Button>
            <div id="div_Grid" style="padding: 4px">
                <%--<asp:UpdatePanel ID="upnlse" runat="server">
               <ContentTemplate>--%>
                <div id="div_popupAction" style="margin: 40px 0px 0px 9px;" onmouseover="show();"
                    onmouseout="hide(); ">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="df" runat="server" style="width: 100%;">
                                    <telerik:RadMenu ID="RadMenu1" runat="server" Width="160px" EnableEmbeddedSkins="false"
                                        Skin="Eprint_Skin" Flow="Vertical">
                                        <Items>
                                            <telerik:RadMenuItem Text="Allocate To">
                                                <Items>
                                                    <telerik:RadMenuItem Width="165px" Value="customer" Text="Customer" Style="cursor: pointer;" onclick="javascript: return CheckOne_new('customer');" />
                                                </Items>
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadMenu>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <%--sales/order report job system report--%>
                    <telerik:RadGrid ID="RadGridReports" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" OnItemDataBound="RadGridReports_ItemDataBound"
                        AllowFilteringByColumn="true" OnNeedDataSource="RadGridJobReports_OnNeedDataSource"
                        Visible="false">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td style="width: 30px">
                                            <a id="a1" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label1" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td class="report_clrfilter">
                                            <asp:LinkButton ID="lnkBtnClearFilter" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Category" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Category"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lnkCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="CustomerCode"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemTitle"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" ItemStyle-Width="9%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ProductDescription"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdDesc" runat="server" Text='<%#Eval("ProductDescription")%>'> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="CustomerName"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustomerName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="State" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="State"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Text='<%#Eval("State")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Department" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="Department"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Contact Name" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ContactName"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactName" runat="server" Text='<%#Eval("ContactName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-Width="5%"
                                    ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="false"
                                    DataField="UnitSalesThisWeek">
                                    <HeaderTemplate>
                                        <table class="reporttablefont">
                                            <tr>
                                                <td colspan="6" align="center" class="reportjobtabletd">Unit Sales
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="reportunitsale">This Week
                                                </td>
                                                <td class="reportunitsale">Last Week
                                                </td>
                                                <td class="reportunitsale">This Month
                                                </td>
                                                <td class="reportunitsale">Last Month
                                                </td>
                                                <td class="reportunitsale">A/C Year
                                                </td>
                                                <td class="reportunittilldate">Till Date
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table class="reportsalevalue">
                                            <tr>
                                                <td class="reporttablevalue">
                                                    <asp:Label ID="lblSalesThisWeek" runat="server" Text='<%#Eval("UnitSalesThisWeek")%>'></asp:Label>
                                                </td>
                                                <td class="reporttablevalue">
                                                    <asp:Label ID="lblSalesLastWeek" runat="server" Text='<%#Eval("UnitSalesLastWeek")%>'></asp:Label>
                                                </td>
                                                <td class="reporttablevalue">
                                                    <asp:Label ID="lblSalesThisMonth" runat="server" Text='<%#Eval("UnitSalesThisMonth")%>'></asp:Label>
                                                </td>
                                                <td class="reporttablevalue">
                                                    <asp:Label ID="lblSalesLastMonth" runat="server" Text='<%#Eval("UnitSalesLastMonth")%>'></asp:Label>
                                                </td>
                                                <td class="reporttablevalue">
                                                    <asp:Label ID="lblSalesACYear" runat="server" Text='<%#Eval("UnitSalesACYear")%>'></asp:Label>
                                                </td>
                                                <td class="reporttablevalue">
                                                    <asp:Label ID="lblSalesTillDate" runat="server" Text='<%#Eval("UnitSalesTillDate")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>

                <div>
                    <%--Customer Yearly Comparison Report--%>
                    <%--<telerik:RadGrid ID="RadGridCustomerYearlyComparison" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" EnableViewState="true"
                        AllowFilteringByColumn="true" OnNeedDataSource="RadGridCustomerYearlyComparison_OnNeedDataSource"
                        Visible="false">--%>
                    <%--<telerik:RadGrid ID="RadGridCustomerYearlyComparison" Width="100%" runat="server" AutoGenerateColumns="false"
                        OnNeedDataSource="RadGridCustomerYearlyComparison_OnNeedDataSource" AllowPaging="true" PageSize="100"
                        AllowFilteringByColumn="true" Visible="false" AllowSorting="true" OnItemDataBound="RadGridCustomerYearlyComparison_ItemDataBound"
                        ShowFooter="True" FooterStyle-Font-Bold="true" EnableLinqExpressions="false">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td style="width: 30px">
                                            <a id="a1" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label1" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td class="report_clrfilter">
                                            <asp:LinkButton ID="lnkBtnClearFilter" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Client Name" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="ClientName"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lnkClientName" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Total Estimate SubTotal This Year" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="TotalEstimateSubTotalThisYear"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalEstimateSubTotalThisYear" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Total Estimate SubTotal Last Year" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="TotalEstimateSubTotalLastYear"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalEstimateSubTotalLastYear" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Total Estimate SubTotal Last Year To Date" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" ItemStyle-Width="9%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="TotalEstimateSubTotalLastYearToDate"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalEstimateSubTotalLastYearToDate" runat="server"> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>--%>

                    <telerik:RadGrid ID="RadGridCustomerYearlyComparison" FooterStyle-Font-Bold="true" HeaderStyle-Font-Bold="true"
                        runat="server" AllowPaging="true" PageSize="100" AllowSorting="true" AutoGenerateColumns="false"
                        AllowFilteringByColumn="false" OnItemCommand="GridCustomerYearlyComparison_ItemCommand"
                        OnNeedDataSource="RadGridCustomerYearlyComparison_OnNeedDataSource" Visible="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td style="width: 30px">
                                            <a id="a1" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label1" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td class="report_clrfilter">
                                            <asp:LinkButton ID="lnkBtnClearFilter" runat="server" ForeColor="#103593" Style="text-decoration: underline; display: none;"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridBoundColumn HeaderStyle-Font-Bold="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="ClientName" HeaderText="Client Name" UniqueName="ClientName"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderStyle-Font-Bold="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataType="System.Decimal" DataField="LastEstimateDate" HeaderText="Last Estimate Date" UniqueName="LastEstimateDate"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderStyle-Font-Bold="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataType="System.Decimal" DataField="LastInvoiceDate" HeaderText="Last Invoice Date" UniqueName="LastInvoiceDate"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderStyle-Font-Bold="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataType="System.Decimal" DataField="EstimateSubTotalExTaxThisYear" HeaderText="Estimate SubTotal ExTax This Year" UniqueName="EstimateSubTotalExTaxThisYear"></telerik:GridBoundColumn>

                                <telerik:GridBoundColumn HeaderStyle-Font-Bold="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataType="System.Decimal" DataField="EstimateSubTotalExTaxLastYear" HeaderText="Estimate SubTotal ExTax Last Year" UniqueName="EstimateSubTotalExTaxLastYear"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderStyle-Font-Bold="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataType="System.Decimal" DataField="InvoiceSubTotalExTaxThisYear" HeaderText="Invoice SubTotal ExTax This Year" UniqueName="InvoiceSubTotalExTaxThisYear"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderStyle-Font-Bold="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" DataType="System.Decimal" DataField="InvoiceSubTotalExTaxLastYear" HeaderText="Invoice SubTotal ExTax Last Year" UniqueName="InvoiceSubTotalExTaxLastYear"></telerik:GridBoundColumn>



                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>

                <%--Job Customer Canned Report--%>
                <div>
                    <%-- Product Sales Reports --%>
                    <telerik:RadGrid ID="RadGrid_CustomerJobReport" Width="100%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" OnItemDataBound="RadGridCustomerJobReport_ItemDataBound"
                        AllowFilteringByColumn="true" OnNeedDataSource="RadGridCustomerJobReport_OnNeedDataSource"
                        Visible="false" AllowSorting="true" ShowGroupPanel="true" EnableLinqExpressions="false" ShowFooter="True" FooterStyle-Font-Bold="true" OnPreRender="RadGrid_CustomerJobReport_PreRender">
                        <%--   <GroupPanel Text=""
                            ForeColor="Aqua">
                        </GroupPanel>--%>
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" ShowGroupFooter="true">
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="False">
                                <HeaderStyle Width="19px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblJobCustomerName" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlJobParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularJobSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Label ID="Label20" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("Date_Range")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtJobFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td class="tdwidth">
                                                    </td>--%>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("To")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtJobToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btJobGo" runat="server" CssClass="button" Text="Go" OnClick="btnJobGo_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Job Number" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="JobNumber"
                                    SortExpression="JobNumber" FilterControlWidth="70px" Groupable="true" GroupByExpression="JobNumber Group By JobNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcustJobNumber" runat="server" Text='<%#Eval("JobNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Job Title (Order Title)" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="JobTitle"
                                    FilterControlWidth="70px" SortExpression="JobTitle" Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJobTitle" runat="server" Text='<%#Eval("JobTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Department Name" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="DepartmentName"
                                    FilterControlWidth="70px" SortExpression="DepartmentName" GroupByExpression="DepartmentName Group By DepartmentName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeptName" runat="server" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Department State" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" ItemStyle-Width="9%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="DepartmentState"
                                    FilterControlWidth="70px" SortExpression="DepartmentState" GroupByExpression="DepartmentState Group By DepartmentState">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDeptState" runat="server" Text='<%#Eval("DepartmentState")%>'> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="ParentCategorySubCategory" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" ItemStyle-Width="9%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ParentCategorySubCategory"
                                    FilterControlWidth="70px" SortExpression="ParentCategorySubCategory" GroupByExpression="ParentCategorySubCategory Group By ParentCategorySubCategory">
                                    <ItemTemplate>
                                        <asp:Label ID="lblParentcat" runat="server" Text='<%#Eval("ParentCategorySubCategory")%>'> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Code" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemCode"
                                    FilterControlWidth="70px" SortExpression="ItemCode" Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="CustomerCode"
                                    FilterControlWidth="70px" SortExpression="CustomerCode" GroupByExpression="CustomerCode Group By CustomerCode">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemTitle"
                                    FilterControlWidth="70px" SortExpression="ItemTitle" Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemDescription"
                                    FilterControlWidth="70px" UniqueName="SubTotal" FooterStyle-HorizontalAlign="Left"
                                    SortExpression="ItemDescription" Groupable="false" Aggregate="Custom" FooterText="Sub Total:"
                                    FooterStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemDesc" runat="server" Text='<%#Eval("ItemDescription")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div>
                                            <asp:Label ID="lbltext" runat="server"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="10%"
                                    ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    DataField="ItemQty" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    UniqueName="ItemQTy" SortExpression="ItemQty" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                    DataType="System.Int32" Groupable="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true"
                                    FooterStyle-HorizontalAlign="Right" FooterStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemQTy" runat="server" Text='<%#Eval("ItemQty")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div>
                                            <asp:Label ID="lblSumTotalQty" runat="server" Text="0"></asp:Label>
                                        </div>
                                    </FooterTemplate>

                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Sales Value" HeaderStyle-Font-Bold="true"
                                    HeaderStyle-Width="12%" ItemStyle-Width="12%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    AllowFiltering="true" DataField="SalesValue" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-HorizontalAlign="Right" UniqueName="SalesValue" SortExpression="SalesValue"
                                    CurrentFilterFunction="EqualTo" DataType="System.Decimal" AutoPostBackOnFilter="true"
                                    Groupable="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true"
                                    FooterStyle-HorizontalAlign="Right" FooterStyle-Width="15%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesValue" runat="server" Text='<%#Eval("SalesValue")%>'></asp:Label>
                                        <asp:HiddenField ID="hdnSubItemSalesValue" runat="server" Value='<%#Eval("SubItemSalesValue")%>' />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div>
                                            <asp:Label ID="lblSumTotalSubTotal" runat="server" Text="0"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowDragToGroup="true">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                        <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                    </telerik:RadGrid>
                    <div id="divCustomerJob" runat="server" style="display: none;">
                        <table width="300px" style="float: right;">
                            <tr>
                                <td style="width: 65px; font-weight: bold">Sub Total
                                </td>
                                <td style="width: 60px">
                                    <asp:Label ID="lblTotalQty" runat="server"></asp:Label>
                                </td>
                                <td style="width: 50px">
                                    <asp:Label ID="lblTotalSalesValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%-- End--%>
                <div>
                    <telerik:RadGrid ID="GridProductReport" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="true" Visible="false"
                        OnNeedDataSource="GridProductReport_OnNeedDataSource" OnItemDataBound="GridProductReport_ItemDataBound">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a1" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label1" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCustomerName" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Filter_by_Customer")%>:
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        OnSelectedIndexChanged="ddlCustomerName_OnSelectedIndexChanged" AutoPostBack="true"
                                                        onchange="Javascript:GetSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="lnkBtnClearFilter" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Category" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Category"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lnkCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="CustomerCode"
                                    FilterControlWidth="70px">
                                    <%-- <HeaderTemplate>
                                        <table style="font-weight: bold; width: 50px">
                                            <tr>
                                                <td style="text-align: center">
                                                    Customer
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    Code
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>--%>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" DataField="ItemTitle" CurrentFilterFunction="Contains"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Product Description" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="ProductDescription"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProdDesc" runat="server" Text='<%#Eval("ProductDescription")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    DataField="OpeningStock" HeaderStyle-Font-Bold="true" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <div class="cannedreport_header">
                                            Stock
                                        </div>
                                        <div class="cannedreport_header">
                                            on Hand
                                        </div>
                                        <%--<table class="boldwidth">
                                            <tr>
                                                <td class="txtcentre">
                                                    Opening
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    Stock
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Text='<%#Eval("OpeningStock")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Supplier" HeaderStyle-HorizontalAlign="left"
                                    ItemStyle-HorizontalAlign="left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    AutoPostBackOnFilter="true" AllowFiltering="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true" DataField="Supplier" ItemStyle-Wrap="true"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesLastMonth" runat="server" Text='<%#Eval("Supplier")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="6%" ItemStyle-Width="6%" DataField="Sales_Incl_BackOrders"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <%--  <table class="boldwidth">
                                            <tr>
                                                <td class="txtcentre">
                                                    Sales
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    (incl.Back Orders)
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("Sales_Incl_BackOrders")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Receipts" HeaderStyle-HorizontalAlign="right"
                                    ItemStyle-HorizontalAlign="right" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" DataField="Receipts"
                                    AllowFiltering="false">
                                    <HeaderTemplate>
                                        <div class="cannedreport_header">
                                            Receipts&nbsp;<span class="productcannedreport_receipts">*</span>
                                        </div>
                                        <%-- <table class="reporttablefont">
                                            <tr>
                                                <td>
                                                    Receipts&nbsp;<span style="vertical-align: middle; color: Red">*</span>
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Receipts")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Adjustment" HeaderStyle-HorizontalAlign="right"
                                    ItemStyle-HorizontalAlign="right" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" DataField="Adj"
                                    AllowFiltering="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactName" Text='<%#Eval("Adj")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" DataField="AvailableStock" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <div class="cannedreport_header">
                                            Available
                                        </div>
                                        <div class="cannedreport_header">
                                            Stock
                                        </div>
                                        <%-- <table class="reporttablefont">
                                            <tr>
                                                <td class="txtcentre">
                                                    Available
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    Stock
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCentreName" Text='<%#Eval("AvailableStock")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="6%" ItemStyle-Width="6%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" DataField="Last_13_WeeksSales" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <div class="cannedreport_header">
                                            Last
                                        </div>
                                        <div class="cannedreport_header">
                                            13 Weeks Sales
                                        </div>
                                        <%-- <table class="reporttablefont">
                                            <tr>
                                                <td class="txtcentre">
                                                    Last
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    13 weeks Sales
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesThisWeek" runat="server" Text='<%#Eval("Last_13_WeeksSales")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="false" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" DataField="WeeksRemaining" ItemStyle-Wrap="true">
                                    <HeaderTemplate>
                                        <div class="cannedreport_header">
                                            Weeks
                                        </div>
                                        <div class="cannedreport_header">
                                            Remaining
                                        </div>
                                        <%-- <table class="reporttablefont">
                                            <tr>
                                                <td class="txtcentre">
                                                    Weeks
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    remaining
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesLastWeek" runat="server" Text='<%#Eval("WeeksRemaining")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Back Order Quantity" HeaderStyle-HorizontalAlign="Right"
                                    ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="6%" ItemStyle-Width="6%"
                                    AllowFiltering="false" HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSalesThisMonth" runat="server" Text='<%#Eval("Backorderunits")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                    <div id="divReceipts" runat="server" style="display: none">
                        <table style="width: 100%; padding-top: 5px; margin-left: -3px">
                            <tr>
                                <td style="width: 5px">
                                    <span style="vertical-align: middle; color: Red">*</span>
                                </td>
                                <td>
                                    <asp:Label ID="lblReceiptsText" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div>
                    <telerik:RadGrid ID="RadGridProductReport_Customer" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="true" Visible="false"
                        OnNeedDataSource="RadGridProductReportCustomer_OnNeedDataSource" OnItemDataBound="RadGridProductReportCustomer_ItemDataBound"
                        AllowSorting="true">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Label ID="Label20" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("Date_Range")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td class="tdwidth">
                                                    </td>--%>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("To")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnProductGo" runat="server" CssClass="button" Text="Go" OnClick="btnProductGo_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ParentCategory/SubCategory"
                                    SortExpression="ParentCategory/SubCategory">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("ParentCategory/SubCategory")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Itemcode"
                                    SortExpression="Itemcode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("Itemcode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="CustomerCode"
                                    SortExpression="CustomerCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ItemTitle"
                                    SortExpression="ItemTitle">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ItemDescription"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" SortExpression="ItemDescription">
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("ItemDescription")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="Openingstock" SortExpression="Openingstock"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="Openingstock">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("Openingstock")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" DataField="Releases"
                                    ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" SortExpression="Releases" DataType="System.Decimal"
                                    UniqueName="Releases">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("Releases")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Receipts" SortExpression="Receipts"
                                    DataType="System.Decimal" UniqueName="Receipts">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("Receipts")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Adjustments" SortExpression="Adjustments"
                                    DataType="System.Decimal" UniqueName="Adjustments">
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" Text='<%#Eval("Adjustments")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="EqualTo"
                                    AutoPostBackOnFilter="true" DataField="ClosingStock" SortExpression="ClosingStock"
                                    DataType="System.Decimal" UniqueName="ClosingStock">
                                    <HeaderTemplate>
                                        <div class="customercannedreport_header">
                                        </div>
                                        <div class="customercannedreport_header">
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" Text='<%#Eval("ClosingStock")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ReleasesOverLast13Weeks"
                                    SortExpression="ReleasesOverLast13Weeks" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                    DataType="System.Decimal" UniqueName="ReleasesOverLast13Weeks">
                                    <HeaderTemplate>
                                        <div class="customercannedreport_header">
                                        </div>
                                        <div class="customercannedreport_header">
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%#Eval("ReleasesOverLast13Weeks")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    ItemStyle-Wrap="true" DataField="WeeksRemaining" SortExpression="WeeksRemaining"
                                    DataType="System.Decimal" UniqueName="WeeksRemaining">
                                    <HeaderTemplate>
                                        <div class="customercannedreport_header">
                                        </div>
                                        <div class="customercannedreport_header">
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("WeeksRemaining")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--New report--%>

                <div>
                    <telerik:RadGrid ID="RadGridProductReport_CustomerNew" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="true" Visible="false"
                        OnNeedDataSource="RadGridProductReport_CustomerNew_OnNeedDataSource" OnItemDataBound="RadGridProductReport_CustomerNew_ItemDataBound"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Label ID="Label20" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("Date_Range")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <%-- <td class="tdwidth">
                                                    </td>--%>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("To")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnProductGoNew" runat="server" CssClass="button" Text="Go" OnClick="btnProductGoNew_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ParentCategory/SubCategory"
                                    SortExpression="ParentCategory/SubCategory">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Eval("ParentCategory/SubCategory")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Itemcode"
                                    SortExpression="Itemcode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("Itemcode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="CustomerCode"
                                    SortExpression="CustomerCode">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ItemTitle"
                                    SortExpression="ItemTitle">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ItemDescription"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" SortExpression="ItemDescription">
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("ItemDescription")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="Openingstock" SortExpression="Openingstock"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="Openingstock">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("Openingstock")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="AllocatedQty"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="AllocatedQty">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("AllocatedQty")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" DataField="Releases"
                                    ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" SortExpression="Releases" DataType="System.Decimal"
                                    UniqueName="Releases">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("Releases")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Receipts" SortExpression="Receipts"
                                    DataType="System.Decimal" UniqueName="Receipts">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("Receipts")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Adjustments" SortExpression="Adjustments"
                                    DataType="System.Decimal" UniqueName="Adjustments">
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" Text='<%#Eval("Adjustments")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="EqualTo"
                                    AutoPostBackOnFilter="true" DataField="ClosingStock" SortExpression="ClosingStock"
                                    DataType="System.Decimal" UniqueName="ClosingStock">
                                    <HeaderTemplate>
                                        <div class="customercannedreport_header">
                                        </div>
                                        <div class="customercannedreport_header">
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" Text='<%#Eval("ClosingStock")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ReleasesOverLast13Weeks"
                                    SortExpression="ReleasesOverLast13Weeks" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                    DataType="System.Decimal" UniqueName="ReleasesOverLast13Weeks">
                                    <HeaderTemplate>
                                        <div class="customercannedreport_header">
                                        </div>
                                        <div class="customercannedreport_header">
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" runat="server" Text='<%#Eval("ReleasesOverLast13Weeks")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    ItemStyle-Wrap="true" DataField="WeeksRemaining" SortExpression="WeeksRemaining"
                                    DataType="System.Decimal" UniqueName="WeeksRemaining">
                                    <HeaderTemplate>
                                        <div class="customercannedreport_header">
                                        </div>
                                        <div class="customercannedreport_header">
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label19" runat="server" Text='<%#Eval("WeeksRemaining")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>

                <%--end--%>

                <%--RadGridItemswithReorderAlertsSet--%>
                <div>
                    <telerik:RadGrid ID="RadGridItemswithReorderAlertsSet" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="true" Visible="false"
                        OnItemDataBound="RadGridItemsWithReorderAlertsSet_ItemDataBound"
                        OnNeedDataSource="RadGridItemswithReorderAlertsSet_OnNeedDataSource"
                        OnItemCommand="RadGridItemswithReorderAlertsSet_ItemCommand"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
            <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                              <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerNameAlertsSet" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnProductGoNew" runat="server" CssClass="button" Text="Go" OnClick="RadGridItemswithReorderAlertsSet_GO_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Itemcode" UniqueName="Itemcode"
                                    SortExpression="Itemcode" HeaderText="Item Code">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("Itemcode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="false" FilterControlWidth="0px"
                                    DataField="PriceCatalogueID" UniqueName="PriceCatalogueID"
                                    SortExpression="PriceCatalogueID" HeaderText="">
                                    <ItemTemplate>
                                        <a href="#" onclick='javascript:editstock("<%# Eval("PriceCatalogueID") %>"); return false;'>
                                            <img src="../images/Stocksimg.png" alt="Edit" style="cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ItemTitle" UniqueName="ItemTitle"
                                    SortExpression="ItemTitle" HeaderText="Item Title">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="TotalQuantity" SortExpression="TotalQuantity"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalQuantity" HeaderText="Quantity on Hand">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("TotalQuantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="true" HeaderStyle-Wrap="false"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="AllocatedQty"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="AllocatedQuantity" HeaderText="Allocated Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("AllocatedQuantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false" DataField="BackOrderQty"
                                    ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" SortExpression="BackOrderQty" DataType="System.Decimal"
                                    UniqueName="BackOrderQty" HeaderText="Backorder Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("BackOrderQty")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="AvailableQuantity" SortExpression="AvailableQuantity"
                                    DataType="System.Decimal" UniqueName="AvailableQuantity" HeaderText="Available Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("AvailableQuantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="ReorderAlertLevel" SortExpression="ReorderAlertLevel"
                                    DataType="System.Decimal" UniqueName="ReorderAlertLevel" HeaderText="Alert Level">
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" Text='<%#Eval("ReorderAlertLevel")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="ReorderQuantity" SortExpression="ReorderQuantity"
                                    DataType="System.Decimal" UniqueName="ReorderQuantity" HeaderText="Reorder Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" Text='<%#Eval("ReorderQuantity")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Customer" SortExpression="Customer"
                                    DataType="System.String" UniqueName="Customer" HeaderText="Customer">
                                    <ItemTemplate>
                                        <asp:Literal ID="litCustomer" runat="server" Text='<%# FormatCustomerBadges(Eval("Customer")) %>'
                                            EnableViewState="false" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--end--%>

                <%--RadGridItemsRequiringReorder--%>
                <div>
                    <telerik:RadGrid ID="RadGridItemsRequiringReorder" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="true" Visible="false"
                        OnItemDataBound="RadGridItemsRequiringReorder_ItemDataBound"
                        OnNeedDataSource="RadGridItemsRequiringReorder_OnNeedDataSource"
                        OnItemCommand="RadGridmsItemsRequiringReorder_ItemCommand"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
<input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                  <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnProductGoNew" runat="server" CssClass="button" Text="Go" OnClick="RadGridItemsRequiringReorder_GO_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Itemcode" UniqueName="Itemcode"
                                    SortExpression="Itemcode" HeaderText="Item Code">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("Itemcode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="false" FilterControlWidth="0px"
                                    DataField="PriceCatalogueID" UniqueName="PriceCatalogueID"
                                    SortExpression="PriceCatalogueID" HeaderText="">
                                    <ItemTemplate>
                                        <a href="#" onclick='javascript:editstock("<%# Eval("PriceCatalogueID") %>"); return false;'>
                                            <img src="../images/Stocksimg.png" alt="Edit" style="cursor: pointer;" />
                                        </a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ItemTitle" UniqueName="ItemTitle"
                                    SortExpression="ItemTitle" HeaderText="Item Title">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="TotalQuantity" SortExpression="TotalQuantity"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalQuantity" HeaderText="Quantity on Hand">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("TotalQuantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="AllocatedQuantity"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="AllocatedQuantity" HeaderText="Allocated Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("AllocatedQuantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="AvailableQuantity" SortExpression="AvailableQuantity"
                                    DataType="System.Decimal" UniqueName="AvailableQuantity" HeaderText="Available Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("AvailableQuantity")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" DataField="BackOrderQty"
                                    ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" SortExpression="BackOrderQty" DataType="System.Decimal"
                                    UniqueName="BackOrderQty" HeaderText="Backorder Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label14" runat="server" Text='<%#Eval("BackOrderQty")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="ReorderAlertLevel" SortExpression="ReorderAlertLevel"
                                    DataType="System.Decimal" UniqueName="ReorderAlertLevel" HeaderText="Alert Level">
                                    <ItemTemplate>
                                        <asp:Label ID="Label16" Text='<%#Eval("ReorderAlertLevel")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="ReorderQuantity" SortExpression="ReorderQuantity"
                                    DataType="System.Decimal" UniqueName="ReorderQuantity" HeaderText="Reorder Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="Label17" Text='<%#Eval("ReorderQuantity")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="ReorderAmount" SortExpression="ReorderAmount"
                                    DataType="System.Decimal" UniqueName="ReorderAmount" HeaderText="Reorder Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="Label18" Text='<%#Eval("ReorderAmount")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Customer" SortExpression="Customer"
                                    DataType="System.String" UniqueName="Customer" HeaderText="Customer">
                                    <ItemTemplate>
                                        <asp:Literal ID="litCustomer" runat="server" Text='<%# FormatCustomerBadges(Eval("Customer")) %>'
                                            EnableViewState="false" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--end--%>

                <%--GetAllEstimatesbyCustomer--%>
                <div>
                    <telerik:RadGrid ID="RadGridAllEstimatesbyCustomer" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="false" Visible="false"
                        OnItemDataBound="RadGridAllEstimatesbyCustomer_ItemDataBound"
                        OnNeedDataSource="RadGridAllEstimatesbyCustomer_OnNeedDataSource"
                        OnItemCommand="RadGridAllEstimatesbyCustomer_ItemCommand"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
<input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" CssClass="lable_bold">
                                          Customer Type
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlCustomerType" AutoPostBack="true" runat="server" CssClass="product_reportcannedddl"
                                                        OnSelectedIndexChanged="ddlCustomerType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                  <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" CssClass="lable_bold">
                                            Period
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlReportPeriod" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="onDurationFilterChange(this, 'AllEstimatesbyCustomer');">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <%--Date Range--%>
                                                        <table id="tbl_AllEstimatesbyCustomer_DateRanges" runat="server" clientidmode="Static" style="display: none;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server">Date From</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server">Date To</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--Date Range--%>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnAllEstimatesbyCustomer" runat="server" CssClass="button" Text="Go" OnClick="RadGridAllEstimatesbyCustomer_GO_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="CompanyName" UniqueName="CompanyName"
                                    SortExpression="CompanyName" HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="20px" DataField="CostExMarkup" UniqueName="CostExMarkup"
                                    SortExpression="CostExMarkup" HeaderText="Cost Ex Markup">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("CostExMarkup")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="TotalQuantity" SortExpression="TotalExTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalExTax" HeaderText="Total Ex Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("TotalExTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="TotalIncTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalIncTax" HeaderText="Total Inc Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("TotalIncTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="PercentageProgressedIntoJobs" SortExpression="% Progressed into Jobs"
                                    DataType="System.Decimal" UniqueName="% Progressed into Jobs" HeaderText="% Progressed into Jobs">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("PercentageProgressedIntoJobs")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--end--%>

                <%--RadGridAllOrdersbyCustomer--%>
                <div>
                    <telerik:RadGrid ID="RadGridAllOrdersbyCustomer" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="false" Visible="false"
                        OnItemDataBound="RadGridAllOrdersbyCustomer_ItemDataBound"
                        OnNeedDataSource="RadGridAllOrdersbyCustomer_OnNeedDataSource"
                        OnItemCommand="RadGridAllOrdersbyCustomer_ItemCommand"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
<input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label5" runat="server" CssClass="lable_bold">
                                          Customer Type
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlCustomerType" AutoPostBack="true" runat="server" CssClass="product_reportcannedddl"
                                                        OnSelectedIndexChanged="ddlCustomerType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                  <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" CssClass="lable_bold">
                                            Period
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlReportPeriod" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="onDurationFilterChange(this, 'AllOrdersbyCustomer');">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <%--Date Range--%>
                                                        <table id="tbl_AllOrdersbyCustomer_DateRanges" runat="server" clientidmode="Static" style="display: none;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server">Date From</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server">Date To</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--Date Range--%>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnAllOrdersbyCustomer" runat="server" CssClass="button" Text="Go" OnClick="RadGridAllOrdersbyCustomer_GO_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="CompanyName" UniqueName="CompanyName"
                                    SortExpression="CompanyName" HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="20px" DataField="CostExMarkup" UniqueName="CostExMarkup"
                                    SortExpression="CostExMarkup" HeaderText="Cost Ex Markup">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("CostExMarkup")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="TotalQuantity" SortExpression="TotalExTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalExTax" HeaderText="Total Ex Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("TotalExTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="TotalIncTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalIncTax" HeaderText="Total Inc Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("TotalIncTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="PercentageProgressedIntoJobs" SortExpression="% Progressed into Jobs"
                                    DataType="System.Decimal" UniqueName="% Progressed into Jobs" HeaderText="% Progressed into Jobs">
                                    <ItemTemplate>
                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("PercentageProgressedIntoJobs")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--end--%>

                <%--RadGridAllJobsbyCustomer--%>
                <div>
                    <telerik:RadGrid ID="RadGridAllJobsbyCustomer" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="false" Visible="false"
                        OnItemDataBound="RadGridAllJobsbyCustomer_ItemDataBound"
                        OnNeedDataSource="RadGridAllJobsbyCustomer_OnNeedDataSource"
                        OnItemCommand="RadGridAllJobsbyCustomer_ItemCommand"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
<input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label51" runat="server" CssClass="lable_bold">
                                          Customer Type
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlCustomerType" AutoPostBack="true" runat="server" CssClass="product_reportcannedddl"
                                                        OnSelectedIndexChanged="ddlCustomerType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                  <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" CssClass="lable_bold">
                                            Period
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlReportPeriod" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="onDurationFilterChange(this, 'AllJobsbyCustomer');">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <%--Date Range--%>
                                                        <table id="tbl_AllJobsbyCustomer_DateRanges" runat="server" clientidmode="Static" style="display: none;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server">Date From</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server">Date To</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--Date Range--%>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnAllJobsbyCustomer" runat="server" CssClass="button" Text="Go" OnClick="RadGridAllJobsbyCustomer_GO_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="CompanyName" UniqueName="CompanyName"
                                    SortExpression="CompanyName" HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="20px" DataField="CostExMarkup" UniqueName="CostExMarkup"
                                    SortExpression="CostExMarkup" HeaderText="Total Cost Ex. Markup">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("CostExMarkup")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="TotalQuantity" SortExpression="TotalExTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalExcTax" HeaderText="Total Ex. Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("TotalExcTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="TotalIncTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalIncTax" HeaderText="Total Inc. Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("TotalIncTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="GrossProfitPrice" SortExpression="GrossProfitPrice"
                                    DataType="System.Decimal" UniqueName="GrossProfitPrice" HeaderText="Gross Profit $">
                                    <ItemTemplate>
                                        <asp:Label ID="Label151" runat="server" Text='<%#Eval("GrossProfitPrice")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="GrossProfitPercentage" SortExpression="GrossProfitPercentage"
                                    DataType="System.Decimal" UniqueName="GrossProfitPercentage" HeaderText="Gross Profit %">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1555" runat="server" Text='<%#Eval("GrossProfitPercentage")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--end--%>

                <%--RadGridAllInvoicesbyCustomer--%>
                <div>
                    <telerik:RadGrid ID="RadGridAllInvoicesbyCustomer" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="false" Visible="false"
                        OnItemDataBound="RadGridAllInvoicesbyCustomer_ItemDataBound"
                        OnNeedDataSource="RadGridAllInvoicesbyCustomer_OnNeedDataSource"
                        OnItemCommand="RadGridAllInvoicesbyCustomer_ItemCommand"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
<input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label51" runat="server" CssClass="lable_bold">
                                          Customer Type
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlCustomerType" AutoPostBack="true" runat="server" CssClass="product_reportcannedddl"
                                                        OnSelectedIndexChanged="ddlCustomerType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                  <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" CssClass="lable_bold">
                                            Period
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlReportPeriod" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="onDurationFilterChange(this, 'AllInvoicesbyCustomer');">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <%--Date Range--%>
                                                        <table id="tbl_AllInvoicesbyCustomer_DateRanges" runat="server" clientidmode="Static" style="display: none;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server">Date From</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server">Date To</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--Date Range--%>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnAllJobsbyCustomer" runat="server" CssClass="button" Text="Go" OnClick="RadGridAllInvoicesbyCustomer_GO_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ClientName" UniqueName="ClientName"
                                    SortExpression="ClientName" HeaderText="Company Name">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("ClientName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="20px" DataField="CostExMarkup" UniqueName="CostExMarkup"
                                    SortExpression="CostExMarkup" HeaderText="Total Cost Ex. Markup">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("CostExMarkup")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="TotalQuantity" SortExpression="TotalExTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalExcTax" HeaderText="Total Ex. Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("TotalExcTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="TotalIncTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalIncTax" HeaderText="Total Inc. Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("TotalIncTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="GrossProfitPrice" SortExpression="GrossProfitPrice"
                                    DataType="System.Decimal" UniqueName="GrossProfitPrice" HeaderText="Gross Profit $">
                                    <ItemTemplate>
                                        <asp:Label ID="Label151" runat="server" Text='<%#Eval("GrossProfitPrice")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="GrossProfitPercentage" SortExpression="GrossProfitPercentage"
                                    DataType="System.Decimal" UniqueName="GrossProfitPercentage" HeaderText="Gross Profit %">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1555" runat="server" Text='<%#Eval("GrossProfitPercentage")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--end--%>

                <%--RadGridAllInvoicesbyAccountingCode--%>
                <div>
                    <telerik:RadGrid ID="RadGridAllInvoicesbyAccountingCode" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="false" Visible="false"
                        OnItemDataBound="RadGridAllInvoicesbyAccountingCode_ItemDataBound"
                        OnNeedDataSource="RadGridAllInvoicesbyAccountingCode_OnNeedDataSource"
                        OnItemCommand="RadGridAllInvoicesbyAccountingCode_ItemCommand"
                        AllowSorting="true" GroupingSettings-CaseSensitive="false">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
<input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label51" runat="server" CssClass="lable_bold">
                                          Customer Type
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlCustomerType" AutoPostBack="true" runat="server" CssClass="product_reportcannedddl"
                                                        OnSelectedIndexChanged="ddlCustomerType_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                  <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>

                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" CssClass="lable_bold">
                                            Period
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlReportPeriod" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="onDurationFilterChange(this, 'AllInvoicesbyAccountingCode');">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <%--Date Range--%>
                                                        <table id="tbl_AllInvoicesbyAccountingCode_DateRanges" runat="server" clientidmode="Static" style="display: none;">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label20" runat="server">Date From</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="Label6" runat="server">Date To</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="100px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%--Date Range--%>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnAllInvoicesbyAccountingCode" runat="server" CssClass="button" Text="Go" OnClick="RadGridAllInvoicesbyAccountingCode_GO_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>

                               
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="AccountingCode" UniqueName="AccountingCode"
                                    SortExpression="AccountingCode" HeaderText="Accounting Code">
                                    <ItemTemplate>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Eval("AccountingCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="20px" DataField="CostExMarkup" UniqueName="CostExMarkup"
                                    SortExpression="CostExMarkup" HeaderText="Total Cost Ex. Markup">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("CostExMarkup")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="TotalQuantity" SortExpression="TotalExTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalExcTax" HeaderText="Total Ex. Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("TotalExcTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="TotalIncTax"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="TotalIncTax" HeaderText="Total Inc. Tax">
                                    <ItemTemplate>
                                        <asp:Label ID="Label23" runat="server" Text='<%#Eval("TotalIncTax")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="GrossProfitPrice" SortExpression="GrossProfitPrice"
                                    DataType="System.Decimal" UniqueName="GrossProfitPrice" HeaderText="Gross Profit $">
                                    <ItemTemplate>
                                        <asp:Label ID="Label151" runat="server" Text='<%#Eval("GrossProfitPrice")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="GrossProfitPercentage" SortExpression="GrossProfitPercentage"
                                    DataType="System.Decimal" UniqueName="GrossProfitPercentage" HeaderText="Gross Profit %">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1555" runat="server" Text='<%#Eval("GrossProfitPercentage")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>


                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <%--end--%>

                <div>
                    <telerik:RadGrid ID="RadGrid_StockUsageReport" Width="98%" runat="server" AutoGenerateColumns="true"
                        GroupingEnabled="true" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true"
                        Visible="false" HeaderStyle-Font-Bold="true" HeaderStyle-Wrap="true" AllowSorting="true"
                        EnableLinqExpressions="false" OnItemDataBound="RadGrid_StockUsageReport_ItemDataBound"
                        OnNeedDataSource="RadGrid_StockUsageReport_OnNeedDataSource">
                        <MasterTableView CommandItemDisplay="Top" HeaderStyle-Font-Bold="true" GroupHeaderItemStyle-BackColor="#F2F2F2"
                            HeaderStyle-Height="25px" GroupHeaderItemStyle-Font-Bold="true" AllowFilteringByColumn="true">
                            <GroupByExpressions>
                                <telerik:GridGroupByExpression>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldAlias="Department" FieldName="DeptName" />
                                    </SelectFields>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="DeptName" SortOrder="Ascending" />
                                    </GroupByFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlUsageCustomerName_OnSelectedIndexChanged"
                                                            onchange="Javascript:GetParticularSelectedClientID(this.id);" Height="20px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddldepartment" runat="server" CssClass="product_reportcannedddl"
                                                            onchange="Javascript:GetParticularSelectedDepatmentID(this.id);" Height="20px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <%-- <td class="tdwidth">
                                                    </td>--%>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMonthCategory" runat="server" CssClass="product_reportcannedddl"
                                                            onchange="Javascript:GetselectedmonthCategory(this.id);" Height="20px" Width="210px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnUsageReportGo" runat="server" CssClass="button" Text="Go" OnClick="btnUsageReportGo_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="lable_bold">
                                            <div style="margin-right: 500px">
                                                <asp:Label ID="lblMonthHeading" runat="server">
                                                </asp:Label>
                                            </div>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <%--   <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Stock Code"
                                    UniqueName="Stock Code" SortExpression="Stock Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstockCode" runat="server" Text='<%#Eval("Stock Code")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="300px" ItemStyle-Width="300px" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    DataField="Product Name" UniqueName="Product Name" SortExpression="Product Name"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("Product Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="40px" DataField="Mth On List"
                                    UniqueName="Mth On List" SortExpression="Mth On List">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMthOnList" runat="server" Text='<%#Eval("Mth On List")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="40px" DataField="Stock On Hand"
                                    UniqueName="Stock On Hand" SortExpression="Stock On Hand">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockOnHand" runat="server" Text='<%#Eval("Stock On Hand")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="Stock Sales Value"
                                    FilterControlWidth="70px" UniqueName="Stock Sales Value" SortExpression="Stock Sales Value"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockSalesValue" runat="server" Text='<%#Eval("Stock Sales Value")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="UOI" UniqueName="UOI"
                                    FilterControlWidth="40px" SortExpression="UOI" CurrentFilterFunction="EqualTo"
                                    AutoPostBackOnFilter="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUOI" runat="server" Text='<%#Eval("UOI")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="60px" CurrentFilterFunction="EqualTo" DataField="Avg Mth Usage"
                                    UniqueName="Avg Mth Usage" SortExpression="Avg Mth Usage">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvgMthUsage" runat="server" Text='<%#Eval("Avg Mth Usage")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Mths Over" UniqueName="Mths Over"
                                    FilterControlWidth="60px" SortExpression="Mths Over">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMthsOver" runat="server" Text='<%#Eval("Mths Over")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="70px" CurrentFilterFunction="EqualTo" DataField="Total Sales"
                                    UniqueName="Total Sales" SortExpression="Total Sales">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSales" Text='<%#Eval("Total Sales")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Jan"
                                    UniqueName="Total Sales On Jan" SortExpression="Total Sales On Jan">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljan" Text='<%#Eval("Total Sales On Jan")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Feb"
                                    UniqueName="Total Sales On Feb" SortExpression="Total Sales On Feb">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeb" Text='<%#Eval("Total Sales On Feb")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Mar"
                                    UniqueName="Total Sales On Mar" SortExpression="Total Sales On Mar">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmar" Text='<%#Eval("Total Sales On Mar")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Apr"
                                    UniqueName="Total Sales On Apr" SortExpression="Total Sales On Apr">
                                    <ItemTemplate>
                                        <asp:Label ID="lblapr" Text='<%#Eval("Total Sales On Apr")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On May"
                                    UniqueName="Total Sales On May" SortExpression="Total Sales On May">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmay" runat="server" Text='<%#Eval("Total Sales On May")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Jun"
                                    UniqueName="Total Sales On Jun" SortExpression="Total Sales On Jun">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljun" Text='<%#Eval("Total Sales On Jun")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Jul"
                                    UniqueName="Total Sales On Jul" SortExpression="Total Sales On Jul">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljul" Text='<%#Eval("Total Sales On Jul")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Aug"
                                    UniqueName="Total Sales On Aug" SortExpression="Total Sales On Aug">
                                    <ItemTemplate>
                                        <asp:Label ID="lblaug" Text='<%#Eval("Total Sales On Aug")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Sep"
                                    UniqueName="Total Sales On Sep" SortExpression="Total Sales On Sep">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsep" Text='<%#Eval("Total Sales On Sep")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Oct"
                                    UniqueName="Total Sales On Oct" SortExpression="Total Sales On Oct">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloct" Text='<%#Eval("Total Sales On Oct")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Nov"
                                    UniqueName="Total Sales On Nov" SortExpression="Total Sales On Nov">
                                    <ItemTemplate>
                                        <asp:Label ID="lablnov" Text='<%#Eval("Total Sales On Nov")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Dec"
                                    UniqueName="Total Sales On Dec" SortExpression="Total Sales On Dec">
                                    <ItemTemplate>
                                        <asp:Label ID="labledec" Text='<%#Eval("Total Sales On Dec")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>--%>
                            <%--<Columns>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Item Code"
                                    UniqueName="Stock Code" SortExpression="Stock Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstockCode" runat="server" Text='<%#Eval("Item Code")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="300px" ItemStyle-Width="300px" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    DataField="Product Name" UniqueName="Product Name" SortExpression="Item Title"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("Item Title")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="40px" DataField="Month On List"
                                    UniqueName="Mth On List" SortExpression="Mth On List">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMthOnList" runat="server" Text='<%#Eval("Month On List")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="40px" DataField="Stock On Hand"
                                    UniqueName="Stock On Hand" SortExpression="Stock On Hand">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockOnHand" runat="server" Text='<%#Eval("Stock On Hand")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="Stock Sales Value"
                                    FilterControlWidth="70px" UniqueName="Stock Sales Value" SortExpression="Stock Sales Value"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockSalesValue" runat="server" Text='<%#Eval("Stock Sales Value")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="UOI" UniqueName="UOI"
                                    FilterControlWidth="40px" SortExpression="UOI" CurrentFilterFunction="EqualTo"
                                    AutoPostBackOnFilter="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUOI" runat="server" Text='<%#Eval("UOI")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="60px" CurrentFilterFunction="EqualTo" DataField="Avg Month Usage"
                                    UniqueName="Avg Mth Usage" SortExpression="Avg Mth Usage">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvgMthUsage" runat="server" Text='<%#Eval("Avg Month Usage")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="EqualTo" DataField="Mths Over" UniqueName="Month Over"
                                    FilterControlWidth="60px" SortExpression="Mths Over">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMthsOver" runat="server" Text='<%#Eval("Month Over")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="70px" CurrentFilterFunction="EqualTo" DataField="Total Sales"
                                    UniqueName="Total Sales" SortExpression="Total Sales">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSales" Text='<%#Eval("Total Sales")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="January"
                                    UniqueName="Total Sales On Jan" SortExpression="Total Sales On Jan">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljan" Text='<%#Eval("January")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="February"
                                    UniqueName="Total Sales On Feb" SortExpression="Total Sales On Feb">
                                    <ItemTemplate>
                                        <asp:Label ID="lblfeb" Text='<%#Eval("February")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="March"
                                    UniqueName="Total Sales On Mar" SortExpression="Total Sales On Mar">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmar" Text='<%#Eval("March")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="April"
                                    UniqueName="Total Sales On Apr" SortExpression="April">
                                    <ItemTemplate>
                                        <asp:Label ID="lblapr" Text='<%#Eval("April")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On May"
                                    UniqueName="Total Sales On May" SortExpression="Total Sales On May">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmay" runat="server" Text='<%#Eval("May")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="June"
                                    UniqueName="Total Sales On Jun" SortExpression="June">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljun" Text='<%#Eval("June")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="July"
                                    UniqueName="Total Sales On Jul" SortExpression="Total Sales On July">
                                    <ItemTemplate>
                                        <asp:Label ID="lbljul" Text='<%#Eval("July")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On Aug"
                                    UniqueName="Total Sales On Aug" SortExpression="Total Sales On August">
                                    <ItemTemplate>
                                        <asp:Label ID="lblaug" Text='<%#Eval("August")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="September"
                                    UniqueName="Total Sales On Sep" SortExpression="Total Sales On Sep">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsep" Text='<%#Eval("September")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="Total Sales On October"
                                    UniqueName="Total Sales On Oct" SortExpression="Total Sales On Oct">
                                    <ItemTemplate>
                                        <asp:Label ID="lbloct" Text='<%#Eval("October")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="November"
                                    UniqueName="Total Sales On Nov" SortExpression="Total Sales On Nov">
                                    <ItemTemplate>
                                        <asp:Label ID="lablnov" Text='<%#Eval("November")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    FilterControlWidth="40px" CurrentFilterFunction="EqualTo" DataField="December"
                                    UniqueName="Total Sales On Dec" SortExpression="Total Sales On Dec">
                                    <ItemTemplate>
                                        <asp:Label ID="labledec" Text='<%#Eval("December")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>--%>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>


                <div>
                    <telerik:RadGrid ID="RadGrid_StockUsageHistoryReport" Width="98%" runat="server" AutoGenerateColumns="true"
                        GroupingEnabled="true" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true"
                        Visible="false" HeaderStyle-Font-Bold="true" HeaderStyle-Wrap="true" AllowSorting="true"
                        EnableLinqExpressions="false" OnItemDataBound="RadGrid_StockUsageHistoryReport_ItemDataBound"
                        OnNeedDataSource="RadGrid_StockUsageHistoryReport_OnNeedDataSource">
                        <MasterTableView CommandItemDisplay="Top" HeaderStyle-Font-Bold="true" GroupHeaderItemStyle-BackColor="#F2F2F2"
                            HeaderStyle-Height="25px" GroupHeaderItemStyle-Font-Bold="true" AllowFilteringByColumn="true">
                            <GroupByExpressions>
                                <telerik:GridGroupByExpression>
                                    <SelectFields>
                                        <telerik:GridGroupByField FieldAlias="Department" FieldName="DeptName" />
                                    </SelectFields>
                                    <GroupByFields>
                                        <telerik:GridGroupByField FieldName="DeptName" SortOrder="Ascending" />
                                    </GroupByFields>
                                </telerik:GridGroupByExpression>
                            </GroupByExpressions>
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlUsageHistoryCustomerName_OnSelectedIndexChanged"
                                                            onchange="Javascript:GetParticularSelectedClientID(this.id);" Height="20px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddldepartment" runat="server" CssClass="product_reportcannedddl"
                                                            onchange="Javascript:GetParticularSelectedDepatmentID(this.id);" Height="20px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <%-- <td class="tdwidth">
                                                    </td>--%>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMonthCategory" runat="server" CssClass="product_reportcannedddl"
                                                            onchange="Javascript:GetselectedmonthCategory(this.id);" Height="20px" Width="210px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnUsageReportGo" runat="server" CssClass="button" Text="Go" OnClick="btnUsageHistoryReportGo_OnClick" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="lable_bold">
                                            <div style="margin-right: 500px">
                                                <asp:Label ID="lblMonthHeading" runat="server">
                                                </asp:Label>
                                            </div>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>

                <div>
                    <%--Order Details Report--%>
                    <telerik:RadGrid ID="RadGrid_Order_Report" Width="99.5%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="true" Visible="false"
                        AllowSorting="true" OnNeedDataSource="RadGrid_Order_Report_OnNeedDataSource"
                        OnItemCommand="RadGrid_Order_Report_ItemCommand" OnItemDataBound="RadGrid_Order_Report_ItemDataBound">
                        <GroupingSettings CaseSensitive="false" />
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table>
                                                <tr>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <telerik:RadComboBox ID="Customerlist" runat="server" Width="250px" Style="vertical-align: middle; margin-right: 10px"
                                                            EmptyMessage="-- Customer Name --" Height="100px">
                                                            <ItemTemplate>
                                                                <div style="margin-left: -10px; width: 150%">
                                                                    <asp:CheckBoxList ID="chkclientname" runat="server">
                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </ItemTemplate>
                                                            <Items>
                                                                <telerik:RadComboBoxItem Text="" />
                                                            </Items>
                                                        </telerik:RadComboBox>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Label ID="Label20" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Date_Range")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Label ID="Label22" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("From")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOrderFromDate" runat="server" CssClass="textboxnew" Width="100px"
                                                            Height="25px"></asp:TextBox>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server">
                                                          <%=objLanguage.GetLanguageConversion("To")%>
                                                        </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOrderToDate" runat="server" CssClass="textboxnew" Width="100px"
                                                            Height="25px"></asp:TextBox>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlStockItem" runat="server" CssClass="product_reportcannedddl"
                                                            Style="width: 140px" Height="23px" onchange="Javascript:GetStockItemValue(this.id);">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:CheckBox ID="chkreplishment" runat="server" onClick="Javascript:GetReplinshesValue(this.id);"
                                                            Height="15px" Text="Include Replenishment Order"></asp:CheckBox>
                                                    </td>
                                                    <td class="tdwidth"></td>
                                                    <td class="tdwidth"></td>
                                                    <td>
                                                        <asp:Button ID="btnOrderReportGo" runat="server" CssClass="button" Text="Go" OnClick="btnOrderReportGo_onClick" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Customer"
                                    UniqueName="Customer" SortExpression="Customer">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("Customer")%>' ToolTip='<%#Eval("Customer")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="15%" ItemStyle-Width="15%" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Department"
                                    UniqueName="Department" SortExpression="Department">
                                    <ItemTemplate>
                                        <asp:Label ID="lblbranchname" runat="server" Text='<%#Eval("Department")%>' ToolTip='<%#Eval("Department")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="50%" ItemStyle-Width="50%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    DataField="Contact" UniqueName="ContactNameofthePersonOrdering" SortExpression="Contact Name of the Person Ordering"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcontactperson" runat="server" Text='<%#Eval("Contact")%>' ToolTip='<%#Eval("Contact")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="End user Cost Centre"
                                    UniqueName="EnduserCostCentre" SortExpression="End user Cost Centre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostCentre" runat="server" Text='<%#Eval("End user Cost Centre")%>'
                                            ToolTip='<%#Eval("End user Cost Centre")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="15%" ItemStyle-Width="15%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Order No"
                                    UniqueName="OrderNo" SortExpression="Order No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderno" runat="server" Text='<%#Eval("Order No")%>' ToolTip='<%#Eval("Order No")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="Customer Order No"
                                    FilterControlWidth="70px" UniqueName="CustomerOrderNo" SortExpression="Customer Order No"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerOrderNo" runat="server" Text='<%#Eval("Customer Order No")%>'
                                            ToolTip='<%#Eval("Customer Order No")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="13%" ItemStyle-Width="13%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="false" AutoPostBackOnFilter="false"
                                    DataType="System.DateTime" DataField="OrderedDate" UniqueName="OrderedDate" SortExpression="OrderedDate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderedDate" Text='<%# DataBinder.Eval(Container, "DataItem.OrderedDate", "{0}") %>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="Item Code" UniqueName="ItemCode"
                                    SortExpression="Item Code" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblstockcode" runat="server" Text='<%#Eval("Item Code")%>' ToolTip='<%#Eval("Item Code")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" DataField="Item Title" UniqueName="ItemTitle"
                                    SortExpression="Item Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrductname" runat="server" Text='<%#Eval("Item Title")%>' ToolTip='<%#Eval("Item Title")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" DataField="Product Type" UniqueName="ProductType"
                                    SortExpression="Product Type">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOnDemand" runat="server" Text='<%#Eval("Product Type")%>' ToolTip='<%#Eval("Product Type")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="True" ItemStyle-Wrap="false"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="Contains" DataField="Customer Code" UniqueName="CustomerCode"
                                    SortExpression="Customer Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCustomerCode" Text='<%#Eval("Customer Code")%>' ToolTip='<%#Eval("Customer Code")%>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="13%" ItemStyle-Width="13%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="GreaterThan" DataField="Qty Ordered" UniqueName="QtyOrdered"
                                    SortExpression="Qty Ordered">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQtyOrdered" Text='<%#Eval("Qty Ordered")%>' ToolTip='<%#Eval("Qty Ordered")%>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="GreaterThan" DataField="Unit of Issue" UniqueName="UnitofIssue"
                                    SortExpression="Unit of Issue">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitOfIssues" Text='<%#Eval("Unit of Issue")%>' ToolTip='<%#Eval("Unit of Issue")%>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="GreaterThan" DataField="Unit Cost" UniqueName="UnitCost"
                                    SortExpression="Unit Cost">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUnitCost" Text='<%#Eval("Unit Cost")%>' ToolTip='<%#Eval("Unit Cost")%>'
                                            runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    CurrentFilterFunction="GreaterThan" DataField="Total" UniqueName="Total" SortExpression="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lbltotal" Text='<%#Eval("Total")%>' ToolTip='<%#Eval("Total")%>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <div>
                    <telerik:RadGrid ID="RadStockUsage_Packs" Width="100%" runat="server" AutoGenerateColumns="false"
                        OnNeedDataSource="RadStockUsage_Packs_OnNeedDataSource" AllowPaging="true" PageSize="100"
                        AllowFilteringByColumn="true" Visible="false" AllowSorting="true" OnItemDataBound="RadStockUsage_Packs_OnItemDataBound"
                        ShowFooter="True" FooterStyle-Font-Bold="true" EnableLinqExpressions="false">
                        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" ShowFooter="true">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 20px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" AlternateText="Xlsx" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td class="tdwidth"></td>
                                        <td class="tdwidth"></td>
                                        <td class="tdwidth"></td>
                                        <td class="tdwidth"></td>
                                        <td style="white-space: nowrap; width: 2px;">
                                            <telerik:RadComboBox ID="Customerlist" runat="server" Width="250px" Style="vertical-align: middle; margin-right: 10px"
                                                EmptyMessage="-- Customer Name --" Height="100px">
                                                <ItemTemplate>
                                                    <div style="margin-left: -10px; width: 150%">
                                                        <asp:CheckBoxList ID="chkclientname" runat="server">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </ItemTemplate>
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnOrderReportGo" runat="server" CssClass="button" Text="Go" OnClick="btnStockUsage_PacksReportGo_onClick" />
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Item Code" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="ItemCode"
                                    SortExpression="ItemCode" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemTitle"
                                    FilterControlWidth="150px" SortExpression="ItemTitle" Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="UOI" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="SoldInPacksOf" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="5%"
                                    ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="SoldInPacksOf" FilterControlWidth="40px" SortExpression="SoldInPacksOf">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUOI" runat="server" Text='<%#Eval("SoldInPacksOf")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Quantity on Hand" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="QuantityOnHand" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="3%"
                                    ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="QuantityOnHand" FilterControlWidth="40px" SortExpression="QuantityOnHand">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQauntityOnHand" runat="server" Text='<%#Eval("QuantityOnHand")%>'> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Allocated Stock" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="AllocatedStock" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="4%"
                                    ItemStyle-Width="4%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="AllocatedStock" FilterControlWidth="40px" SortExpression="AllocatedStock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAllocatedStock" runat="server" Text='<%#Eval("AllocatedStock")%>'> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Available Stock" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="AvailableStock" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="2%"
                                    ItemStyle-Width="2%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="AvailableStock" FilterControlWidth="40px" SortExpression="AvailableStock"
                                    Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvailableStock" runat="server" Text='<%#Eval("AvailableStock")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Stock on Backorder" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="StockOnBackOrder" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="2%"
                                    ItemStyle-Width="2%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="StockOnBackOrder" FilterControlWidth="40px" SortExpression="StockOnBackOrder">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockOnBackOrder" runat="server" Text='<%#Eval("StockOnBackOrder")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Cost Per Pack" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="CostPerPack" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="3%"
                                    ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="CostPerPack" FilterControlWidth="40px" SortExpression="CostPerPack"
                                    Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostPerPack" runat="server" Text='<%#Eval("CostPerPack")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Backorder Value" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="BackOrderValue" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="1%"
                                    ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="BackOrderValue" FilterControlWidth="40px" SortExpression="BackOrderValue"
                                    FooterStyle-HorizontalAlign="Right" FooterStyle-Wrap="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBackOrderValue" runat="server" Text='<%#Eval("BackOrderValue")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div>
                                            <asp:Label ID="lblTotaCostQuantity" runat="server" Text="Total Cost Value:"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Cost Value" HeaderStyle-Font-Bold="true"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    AllowFiltering="true" SortExpression="CostquantityOnBackOrder" DataField="CostquantityOnBackOrder"
                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" UniqueName="CostquantityOnBackOrder"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" FilterControlWidth="40px"
                                    FooterStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalcost" runat="server" Text='<%#Eval("CostquantityOnBackOrder")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div>
                                            <asp:Label ID="lblTotalCostQuantityvalue" runat="server" Text=""></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowDragToGroup="true">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <div>
                    <telerik:RadGrid ID="RadStockUsage_Packs_MyProj" Width="100%" runat="server" AutoGenerateColumns="false"
                        OnNeedDataSource="RadStockUsage_Packs_MyProj_OnNeedDataSource" AllowPaging="true"
                        PageSize="100" AllowFilteringByColumn="true" Visible="false" AllowSorting="true"
                        OnItemDataBound="RadStockUsage_Packs_MyProj_OnItemDataBound" ShowFooter="True"
                        FooterStyle-Font-Bold="true" EnableLinqExpressions="false">
                        <MasterTableView CommandItemDisplay="Top" AllowSorting="true" ShowFooter="true">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td class="product_reportwidth30">
                                            <a id="a2" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label2" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 20px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td class="tdwidth"></td>
                                        <td class="tdwidth"></td>
                                        <td class="tdwidth"></td>
                                        <td class="tdwidth"></td>
                                        <td style="white-space: nowrap; width: 2px;">
                                            <telerik:RadComboBox ID="Customerlist" runat="server" Width="250px" Style="vertical-align: middle; margin-right: 10px"
                                                EmptyMessage="-- Customer Name --" Height="100px">
                                                <ItemTemplate>
                                                    <div style="margin-left: -10px; width: 150%">
                                                        <asp:CheckBoxList ID="chkclientname" runat="server">
                                                        </asp:CheckBoxList>
                                                    </div>
                                                </ItemTemplate>
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnOrderReportGo" runat="server" CssClass="button" Text="Go" OnClick="btnStockUsage_PacksReportGo_MyProj_onClick" />
                                        </td>
                                        <td class="product_reportcannedtd">
                                            <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Product ID" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="ItemCode"
                                    SortExpression="ItemCode" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemTitle"
                                    FilterControlWidth="150px" SortExpression="ItemTitle" Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Product Type" HeaderStyle-HorizontalAlign="Left"
                                    UniqueName="ProductType" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%"
                                    ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="false"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="ProductType" FilterControlWidth="70px" SortExpression="ProductType">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductType" runat="server" Text='<%#Eval("ProductType")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Category" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                    HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ProductCategory"
                                    FilterControlWidth="150px" SortExpression="ProductCategory" Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductCategory" runat="server" Text='<%#Eval("ProductCategory")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="True Quantity" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="QuantityOnHand" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="3%"
                                    ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="QuantityOnHand" FilterControlWidth="40px" SortExpression="QuantityOnHand">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQauntityOnHand" runat="server" Text='<%#Eval("QuantityOnHand")%>'> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <%--<telerik:GridTemplateColumn HeaderText="Allocated Stock" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="AllocatedStock" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="4%"
                                    ItemStyle-Width="4%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="AllocatedStock" FilterControlWidth="40px" SortExpression="AllocatedStock">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAllocatedStock" runat="server" Text='<%#Eval("AllocatedStock")%>'> </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Available Stock" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="AvailableStock" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="2%"
                                    ItemStyle-Width="2%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="AvailableStock" FilterControlWidth="40px" SortExpression="AvailableStock"
                                    Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAvailableStock" runat="server" Text='<%#Eval("AvailableStock")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Stock on Backorder" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="StockOnBackOrder" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="2%"
                                    ItemStyle-Width="2%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="StockOnBackOrder" FilterControlWidth="40px" SortExpression="StockOnBackOrder">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStockOnBackOrder" runat="server" Text='<%#Eval("StockOnBackOrder")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Cost Per Pack" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="CostPerPack" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="3%"
                                    ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="CostPerPack" FilterControlWidth="40px" SortExpression="CostPerPack"
                                    Groupable="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCostPerPack" runat="server" Text='<%#Eval("CostPerPack")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Backorder Value" HeaderStyle-HorizontalAlign="Right"
                                    UniqueName="BackOrderValue" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="1%"
                                    ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                    DataField="BackOrderValue" FilterControlWidth="40px" SortExpression="BackOrderValue"
                                    FooterStyle-HorizontalAlign="Right" FooterStyle-Wrap="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBackOrderValue" runat="server" Text='<%#Eval("BackOrderValue")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div>
                                            <asp:Label ID="lblTotaCostQuantity" runat="server" Text="Total Cost Value:"></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Cost Value" HeaderStyle-Font-Bold="true"
                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                    AllowFiltering="true" SortExpression="CostquantityOnBackOrder" DataField="CostquantityOnBackOrder"
                                    HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" UniqueName="CostquantityOnBackOrder"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" FilterControlWidth="40px"
                                    FooterStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalcost" runat="server" Text='<%#Eval("CostquantityOnBackOrder")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <div>
                                            <asp:Label ID="lblTotalCostQuantityvalue" runat="server" Text=""></asp:Label>
                                        </div>
                                    </FooterTemplate>
                                </telerik:GridTemplateColumn>--%>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowDragToGroup="true">
                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                        </ClientSettings>
                        <FilterMenu OnClientShown="MenuShowing" />
                    </telerik:RadGrid>
                </div>
                <div>
                    <telerik:RadGrid ID="GridClientReport" Width="99.8%" runat="server" AutoGenerateColumns="false"
                        AllowPaging="true" PageSize="100" AllowFilteringByColumn="true" Visible="false"
                        OnNeedDataSource="GridClientReport_OnNeedDataSource">
                        <MasterTableView CommandItemDisplay="Top">
                            <CommandItemTemplate>
                                <table class="DivButtonsHeader">
                                    <tr>
                                        <td style="width: 30px">
                                            <a id="a1" href="#" onclick="backBtn();" style="margin-left: 8px;">
                                                <asp:Label ID="Label1" ToolTip="Back" runat="server">
                                        <input type="image" style="vertical-align:middle;margin-top:5px;"  src="../images/image_EM_b.png" onclick="javascript: return showWaitMessage();"  />
                                                </asp:Label></a>
                                        </td>
                                        <td class="product_reportwidth35">
                                            <div id="Div1" style="height: 23px; margin-left: 15px;">
                                                <asp:ImageButton ID="export" runat="server" src="../images/export-icon1.jpg" OnClick="lnkDownload_OnClick" />
                                            </div>
                                        </td>
                                        <td class="report_clrfilter">
                                            <asp:LinkButton ID="lnkBtnClearFilter" runat="server" ForeColor="#103593" Style="text-decoration: underline"
                                                OnClick="lnkBtnClearFilter_Click">Clear all filter</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </CommandItemTemplate>
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" DataField="Customer" CurrentFilterFunction="Contains"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lnkCustName" runat="server" Text='<%#Eval("Customer")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Contact Name" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" DataField="ContactName" CurrentFilterFunction="Contains"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactName" runat="server" Text='<%#Eval("ContactName")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Contact Number" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" DataField="ContactNumber" CurrentFilterFunction="Contains"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblContactNumber" runat="server" Text='<%#Eval("ContactNumber")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                    HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                    AutoPostBackOnFilter="true" DataField="Subject" CurrentFilterFunction="Contains"
                                    FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Call Type" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Wrap="true" DataField="CallType" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    AllowFiltering="true" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCallType" runat="server" Text='<%#Eval("CallType")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Call Purpose" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Wrap="true" DataField="CallPurpose" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    AllowFiltering="true" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCallPurpose" runat="server" Text='<%#Eval("CallPurpose")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Call Result" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Wrap="true" DataField="CallResult" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    AllowFiltering="true" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCallResult" runat="server" Text='<%#Eval("CallResult")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Wrap="true" DataField="Notes" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    AllowFiltering="true" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNotes" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Date and Time" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Wrap="true" DataField="DateAndTime" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    AllowFiltering="true" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateTime" runat="server" Text='<%#Eval("DateAndTime")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Status" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    HeaderStyle-Wrap="true" DataField="Status" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    AllowFiltering="true" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Duration" HeaderStyle-HorizontalAlign="Left"
                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                    AllowFiltering="true" DataField="Duration" HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                    ItemStyle-Wrap="true" FilterControlWidth="70px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDuration" runat="server" Text='<%#Eval("Duration")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
                <div style="height: 10px">
                </div>
                <telerik:RadGrid ID="GridReports" Width="99.8%" runat="server" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="20" onrowdatabound="GridReports_OnRowDataBound"
                    OnItemDataBound="GridReports_OnItemDataBound" OnPageIndexChanged="GridReports_PageIndexChanged"
                    OnPageSizeChanged="GridReports_PageSizeChanged">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                <HeaderTemplate>
                                    <div style="float: left">
                                        <div style="float: left; display: none;">
                                            <input id="Checkbox1" type="checkbox" runat="server" name="checkAll" />
                                        </div>
                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                            <table width="70%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                <tr>
                                                    <td>
                                                        <div style="float: left">
                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);" type="checkbox" />
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <asp:Panel ID="pnl_chkImage" runat="server">
                                                            <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                    onclick="show();" alt='' />
                                                                <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                    onclick="hide();" alt='' />
                                                            </div>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div style="clear: both;">
                                        </div>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="padding-left: 5px">
                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                            value='<%#String.Concat(Eval("ReportID"),"_",Eval("ReportName").ToString()) %>' />
                                    </div>
                                    <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.ReportID", "{0}") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Report Name" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hid_ReportID" runat="server" Value='<%#Eval("ReportID")%>' />
                                    <asp:LinkButton ID="lnkReportName" runat="server" Text='<%#Eval("ReportName")%>'
                                        CommandArgument='<%#Eval("ReportID")%>'></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="7%" ItemStyle-Width="7%"
                                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Allocated Customers" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="7%" ItemStyle-Width="7%" UniqueName="AllocatedCustomers"
                                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <div>
                                        <asp:PlaceHolder ID="plh_AllocatedCustomers" runat="server">
                                            <asp:Label ID="lblAllocatedCustomers" runat="server" Text='<%#Eval("AllocatedCustomers")%>'></asp:Label>
                                        </asp:PlaceHolder>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Created By" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Created On" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedOn" runat="server" Text='<%#Eval("CreatedDate")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:ImageButton ID="Imgedit" runat="server" ToolTip="Edit" ImageUrl="../images/ico-edit.gif"
                                        Style='cursor: pointer' OnClick="Imgedit_Click" CommandArgument='<%#Eval("ReportID")%>' />
                                    <asp:ImageButton ID="ImgDelete" runat="server" ToolTip="Delete" ImageUrl="~/images/delete.gif"
                                        Style='cursor: pointer' OnClick="ImgDelete_Click" CommandArgument='<%#Eval("ReportID")%>'
                                        OnClientClick="javascript:return window.confirm('Are you sure you want to delete this Report?');" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <asp:HiddenField ID="hdnFromDate" runat="server" />
                <asp:HiddenField ID="hdnToDate" runat="server" />
                <asp:HiddenField ID="hdnClientID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnParticluarClientID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnDurationFilter" runat="server" Value="0" />
                <asp:HiddenField ID="hdnCustomerTypeFilter" runat="server" Value="0" />
                <asp:HiddenField ID="hdnParticularCustomer" runat="server" Value="" />
                <asp:HiddenField ID="hdnJobSelectedClientID" runat="server" Value="0" />
                <asp:HiddenField ID="hdnParticularJobCustomer" runat="server" Value="0" />
                <asp:HiddenField ID="hdnClearFilters" runat="server" Value="0" />
                <asp:HiddenField ID="hdnTotalQty" runat="server" Value="0" />
                <asp:HiddenField ID="hdnTotalSalesValue" runat="server" Value="0" />
                <asp:HiddenField ID="hdnJobFormdate" runat="server" Value="0" />
                <asp:HiddenField ID="hdnJobToDate" runat="server" Value="0" />
                <asp:HiddenField ID="hdnProductFormDate" runat="server" Value="0" />
                <asp:HiddenField ID="hdnProductToDate" runat="server" Value="0" />
                <asp:HiddenField ID="hdnDepartmentID" runat="server" Value="" />
                <asp:HiddenField ID="hdnOrderClientID" runat="server" Value="" />
                <asp:HiddenField ID="hdnisstockItem" runat="server" Value="" />
                <asp:HiddenField ID="hdnisreplinsh" runat="server" Value="" />
                <asp:HiddenField ID="hdnOrderFromdate" runat="server" Value="0" />
                <asp:HiddenField ID="hdnOrderTodate" runat="server" Value="0" />
                <asp:HiddenField ID="hdnMonthCategory" runat="server" Value="" />
                <asp:HiddenField ID="hdnTotalcost" runat="server" Value="" />
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:HiddenField ID="hdnStockReleaseAdjRep2" runat="server" Value="0" />
                <asp:HiddenField ID="hdnStockProdSalRelRep2" runat="server" Value="0" />
                <asp:HiddenField ID="hdnStockProdAllocateReport" runat="server" Value="0" />
                <%--Added by Safdar --%>
                <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
                    align="center">
                    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager2" DestroyOnClose="true"
                        Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
                        Behaviors="Close,Move,Reload,Resize">
                    </telerik:RadWindowManager>
                </div>
                <!--POPUP END-->
                <div id="divBackGroundNew" style="display: none;">
                </div>
                <%--Added by safdar end--%>
            </div>
        </div>
        <asp:HiddenField ID="hdn_ReportIDs" runat="server" Value="" />
        <div id="Div_Customer" style="position: absolute; display: none; vertical-align: middle; z-index: 100;"
            align="center">
            <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
                Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose" Top="115" Left="174"
                Behaviors="Close,Move,Reload,Resize">
            </telerik:RadWindowManager>
        </div>
    </div>
</div>


<script type="text/javascript" language="javascript">

    function getrecord() {
        __doPostBack('ctl00$ContentPlaceHolder1$usrReportsave$lnkdownload', '');
    }

    function backBtn() {
        __doPostBack('ctl00$ContentPlaceHolder1$usrReportsave$btnbacksearch', '');
    }

    function btnClearFilter() {
        __doPostBack('ctl00$ContentPlaceHolder1$usrReportsave$lnkClearFilter', '');
    }

</script>
<script type="text/javascript" language="javascript">
    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender; var items = menu.get_items();
        if (column.get_dataType() == "System.Decimal" || column.get_dataType() == "System.Int32") {
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

        column = null;
        menu.repaint();
    }
    function filterMenuShowing(sender, eventArgs) {

        column = eventArgs.get_column();
    }

    function GetParticularSelectedDepatmentID(ID) {
        var ddlDepartmentID = document.getElementById(ID);
        var ddlvalue = ddlDepartmentID.options[ddlDepartmentID.selectedIndex].value;
        var hdnDepartmentID = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnDepartmentID");
        if (ddlvalue != "") {
            hdnDepartmentID.value = ddlvalue;
        }
        else {
            hdnDepartmentID.value = "";
        }
    }
    function GetStockItemValue(ID) {
        var hdnisstockItem = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnisstockItem");
        var ddlStockItem = document.getElementById(ID);
        var ddlvalue = ddlStockItem.options[ddlStockItem.selectedIndex].value;
        if (ddlvalue != "") {
            hdnisstockItem.value = ddlvalue;
        }

        else {
            hdnisstockItem.value = "";
        }
    }
    function GetReplinshesValue(ID) {

        var hdnisreplinsh = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnisreplinsh");
        var chkreplishment = document.getElementById(ID);
        if (chkreplishment.checked) {
            hdnisreplinsh.value = "1";
        }
        else {
            hdnisreplinsh.value = "";
        }

    }
    function removeValue(list, value) {
        var sourceArr = list.split(",");
        var toReturn = "";
        for (var i = 0; i < sourceArr.length; i++) {
            if (sourceArr[i] != value)
                toReturn += sourceArr[i] + ",";
        }
        return toReturn.substr(0, toReturn.length - 1);
    }
    function RemoveComma(Chk_values) {
        Chk_values = Chk_values.substring(0, Chk_values.length - 1)
        return Chk_values;
    }
    var t = false;
    var count = 0;
    var dropdownlist;
    var Chk_values = '';

    function getSelectedItem(id, position, clientid) {
        var hdnOrderClientID = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnOrderClientID");
        var change = "i0_chkclientname_" + position;
        var exactid = id.replace(change, "Input");
        dropdownlist = document.getElementById(exactid);
        var checkbox = document.getElementById(id);
        if (checkbox.checked) {
            t = true;
            count++;
            Chk_values += clientid + ",";

            dropdownlist.value = count.toString() + " Customer selected ";

        }
        else {
            count--;
            if (count > 0) {
                dropdownlist.value = count.toString() + " Customer selected ";
                Chk_values = removeValue(Chk_values, clientid)
            }
        }

        if (count <= 0) {
            Chk_values = "";
            dropdownlist.value = '-- Customer Name -- ';
        }

        hdnOrderClientID.value = Chk_values;


    }
    function GetselectedmonthCategory(id) {
        var hdnMonthCategory = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnMonthCategory");
        var ddlMonthCategory = document.getElementById(id);
        var ddlvalue = ddlMonthCategory.options[ddlMonthCategory.selectedIndex].value;
        if (ddlvalue != "") {
            hdnMonthCategory.value = ddlvalue;
        }

        else {
            hdnMonthCategory.value = "";
        }
    }
    var div_chk = document.getElementById("div_chk");
    var div_popupAction = document.getElementById("div_popupAction");

    function show() {
        img_actionsHide.style.display = "block";
        img_actionsShow.style.display = "none";

        div_chk.style.border = "inset 1px";
        div_chk.style.background = "#CBCBCB";

        div_popupAction.style.display = "block";
    }

    function hide() {
        img_actionsHide.style.display = "none";
        img_actionsShow.style.display = "block";

        div_chk.style.border = "outset 1px";
        div_chk.style.background = "";

        div_popupAction.style.display = "none";
    }
    function checkAll_new(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
            if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                if (!e.disabled) {
                    e.checked = ChkState;
                }
            }
        }
    }
    function CheckOne_new(val) {
        var Counter = 0;
        var hdn_ReportIDs = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdn_ReportIDs");
        hdn_ReportIDs.value = "";
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (!e.disabled) {
                    if (e.checked == true) {
                        Counter = Number(Counter) + 1;
                        hdn_ReportIDs.value += e.value + ",";
                    }
                }
            }
        }

        hide();

        if (Number(Counter) == 0) {
            if (val == "customer")
                alert("Please check at least one row to Allocate.");

            return false;
        }
        else {
            if (val == "customer") {
                if (true) {
                    openPopUp(hdn_ReportIDs.value);
                }
                else {
                    return false;
                }
            }
        }
    }
    function checkButtonChecked() {
        if (div_chk != null) {
            div_chk.style.display = "none";
            div_popupAction.style.display = "none";
        }
    }
</script>
<telerik:RadScriptBlock ID="radSript1" runat="server">
    <script type="text/javascript">
        function OpenCustomer_List(ID, type, name, ModuleType) {
            var RadCustomer = window.radopen("<%=nmsCommon.global.sitePath()%>Settings/EstoreReports_AllocatedCustomers.aspx?From=" + type + "&ReportID=" + ID + "&ReportName=" + name + "&ModuleType=" + ModuleType, '1000', '500');
            SetRadWindow_Ver2('Div_Customer', 'divBackGroundNew');
            RadCustomer.setSize(710, 369);
            RadCustomer.center();
        }
        function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
            var Div_Customer = document.getElementById(divMaskID);
            var divBackGroundNew = document.getElementById(divBackgroundID);

            if (document.getElementById(divMaskID).style.display == "none") {

                if (navigator.appName != "Microsoft Internet Explorer") {
                    setLoadingPositionOfDivCenter_Ver2(Div_Customer);
                }
                showDivPopupCenter_Ver2(divMaskID);
            }
            else {
                showDivPopupCenter_Ver2(divMaskID);
            }
        }
        function RadWinClose() {
            document.getElementById("Div_Customer").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }
        function openPopUp(ReportIDs) {
            window.radopen("<%=nmsCommon.global.sitePath()%>settings/productCatelogue_Allocation.aspx?from=reports&type=I&id=0&Name=Allocate Multiple&action=AllocateMultiple&ReportIds=" + ReportIDs);
            SetRadWindow_Ver2('Div_Customer', 'divBackGroundNew');
        }

        function onDurationFilterChange(ddlDuration, identifier) {
            if (ddlDuration.value === "daterange") {
                document.getElementById("tbl_" + identifier + "_DateRanges").style.display = "block";
            } else {
                document.getElementById("tbl_" + identifier + "_DateRanges").style.display = "none";
            }
        }


    </script>
</telerik:RadScriptBlock>
<style type="text/css">
    .RadComboBox_Default .rcbInputCell .rcbEmptyMessage {
        color: #000000;
        font-style: normal;
    }

    .RadComboBox_Default .rcbInputCell .rcbEmptyMessage {
        color: #000000;
        font-style: normal;
    }

    .RadGrid .rgGroupHeader td p {
        font-size: 12px;
    }

    .RadGrid_Default .rgMasterTable td.rgGroupCol {
        background-color: #F2F2F2;
        border-color: #F2F2F2;
    }

    .RadInput_Default, .RadInputMgr_Default {
        white-space: nowrap;
    }
</style>
