<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myorder.aspx.cs" Inherits="ePrint.MyPublicStore.account.myorder" masterpagefile="~/Templates/masterPageDefault.master"  %>

<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .RadGrid_Default
        {
            border: 1px solid #828282;
            background: #fff;
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        
        .RadGrid_Default, .RadGrid_Default .rgMasterTable, .RadGrid_Default .rgDetailTable, .RadGrid_Default .rgGroupPanel table, .RadGrid_Default .rgCommandRow table, .RadGrid_Default .rgEditForm table, .RadGrid_Default .rgPager table, .GridToolTip_Default
        {
            font-family: Helvetica,sans-serif;
        }
        
        .RadTabStrip_Default .rtsLI, .RadTabStrip_Default .rtsLink
        {
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }
        
        .RadTabStrip .rtsLevel1 .rtsTxt, .RadTabStripVertical .rtsLevel1 .rtsTxt
        {
            margin-left: -9px;
        }
        .qntylblalign
        {
            text-align :right ;
        }
        @media screen and (max-width: 600px) {
        .divtab{
            float:inherit;
        }
        }
    </style>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="MyOrdergrid">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MyOrdergrid" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnOrderclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="MyOrdergrid" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGridOrder" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGridJob" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGridInvoice" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div id="myorder">
        <div id="accountInfoMain_div" class="contentArea_Background">
            <div class="navigation_div">
                <a href="<%=strSitepath%>">
                    <asp:Label ID="lbl_home" runat="server"></asp:Label>
                </a>
                <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
                <a href="<%=strSitepath%>account/account<%=FileExtension %>">
                    <%=objLanguage.GetLanguageConversion("My_Account") %></a> >
                <%=objLanguage.GetLanguageConversion("My_Orders") %>
            </div>
            <div id="accountInfo_background">
                <div id="accountInfoContent_div">
                    <div id="accountInfoContent_left" class="col-lg-4">
                        <acc:account_panel ID="account_panel1" runat="server" />
                    </div>
                    <div class="col-lg-8">
                    <div class="divtab">
                        <%--  id="order_header"--%>
                        <%-- <strong>
                                    <%=objLanguage.GetLanguageConversion("My_Orders") %>
                                </strong>--%>
                        <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Default" MultiPageID="RadMultiPage2"
                            SelectedIndex="0" OnTabClick="RadTabStrip1_TabClick">
                            <Tabs>
                                <telerik:RadTab Text="Order">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Job">
                                </telerik:RadTab>
                                <telerik:RadTab Text="Invoice">
                                </telerik:RadTab>
                               <%-- <telerik:RadTab Text="All Orders">
                                </telerik:RadTab>--%>
                            </Tabs>
                        </telerik:RadTabStrip>
                    </div>
                    <div id="accountInfoContent_right" class="divtab_right">
                        <div id="order_div">
                            <div id="order_content" runat="server" class="placedNoOrder_div">
                                <asp:Label ID="lbl_noOrders" runat="server" Text="You have placed no orders."><%=objLanguage.GetLanguageConversion("You_have_placed_no_orders")%></asp:Label>
                            </div>
                            <div class="order_content_table" id="order_content_table" runat="server" style="margin-top: -5px;">
                                <div id="divClrFilter" style="float: left;">
                                    <asp:LinkButton ID="btnOrderclrFilters" CssClass="MyOrder_ClearFilter" runat="server"
                                        Text="Clear All Filters" OnClick="OrderclrFilters_Click" />
                                </div>
                                <div style="float: left;">
                                    <div id="DivOrder1" runat="server" class="floatLeft clearBottom DisplayBlock">
                                        <div style="float: left; padding-left: 10px;">
                                         <asp:LinkButton ID="lnkbtnExport_Order" CssClass="MyOrder_ClearFilter" runat="server"
                                        Text="" OnClick="btnExportOrder_OnClick"  style="margin-top: -5px;"/>
                                         <!--   <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                ID="btnExport_Order" runat="server" Text="Export" CssClass="button" OnClick="btnExportOrder_OnClick"
                                                BackColor="Transparent" />-->
                                        </div>
                                    </div>
                                    <div id="DivJob" runat="server" class="floatLeft clearBottom DisplayNone">
                                        <div style="float: left; padding-left: 10px;">
                                              <asp:LinkButton ID="lnkbtnExport_Job" CssClass="MyOrder_ClearFilter" runat="server"
                                        Text="" OnClick="btnExportJob_OnClick" style="margin-top: -5px;"/>
                                              <!--     <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                ID="btnExport_Job" runat="server" Text="Export" CssClass="button" OnClick="btnExportJob_OnClick"
                                                BackColor="Transparent" />-->
                                        </div>
                                    </div>
                                    <div id="DivInvoice" runat="server" class="floatLeft clearBottom DisplayNone">
                                        <div style="float: left; padding-left: 10px;">
                                           <asp:LinkButton ID="lnkbtnExport_Invoice" CssClass="MyOrder_ClearFilter" runat="server"
                                        Text="" OnClick="btnExportInvoice_OnClick" style="margin-top: -5px;"/>
                                          <!--  <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                ID="btnExport_Invoice" runat="server" Text="Export" CssClass="button" OnClick="btnExportInvoice_OnClick"
                                                BackColor="Transparent" />-->
                                        </div>
                                    </div>
                                    <div id="DivOrder" runat="server" class="floatLeft clearBottom DisplayNone">
                                        <div style="float: left; padding-left: 10px;">
                                            <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                ID="btnExport_All" runat="server" Text="Export" CssClass="button" OnClick="btnExportAll_OnClick"
                                                BackColor="Transparent" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="0" CssClass="multiPage"
                                Style="padding-top: 5px;">
                                <telerik:RadPageView ID="RadPageView2" runat="server">
                                    <telerik:RadGrid CssClass="width100p" ID="RadGridOrder" runat="server" AutoGenerateColumns="false"
                                        AllowSorting="true" PageSize="50" AllowPaging="true" CellSpacing="0" CellPadding="0"
                                        OnItemCommand="RadGridOrder_ItemCommand" Visible="true" HeaderStyle-Font-Bold="true"
                                        HeaderStyle-HorizontalAlign="Left" OnItemDataBound="RadGridOrder_OnItemDataBound"
                                        OnNeedDataSource="RadGridOrder_OnNeedDataSource" Width="100%">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                        <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                            HorizontalAlign="NotSet" AutoGenerateColumns="False" TableLayout="Fixed">
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="6%"
                                                    HeaderStyle-Width="7%" ItemStyle-Height="22px">
                                                    <ItemTemplate>
                                                        <div class="MyOrdergrid_Action_Main">
                                                            <div class="MyOrdergrid_Action_Icon">
                                                                <asp:ImageButton ID="LnkReorder" runat="server" CssClass="ReorderIcon" OnCommand="LnkReorder_Click"
                                                                    CommandArgument='<%# Eval("OrderID") %>' ToolTip="Re-Order" CausesValidation="false"
                                                                    ImageUrl="~/images/StoreImages/Order1.png" OnClientClick="javascript:return ReorderCheck(this.id,'order');">
                                                                </asp:ImageButton>
                                                                <asp:HiddenField ID="hdnReorder_Ord" runat="server" Value='<%# Eval("ReOrderCheck") %>' />
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText="Order Reference"
                                                    HeaderStyle-Width="16%" ItemStyle-Width="16%" SortExpression="OrderNo" DataType="System.String"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="70px">
                                                    <ItemTemplate>
                                                        <a title=' <%#Eval("OrderNo")%>' href="#" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                            class="anchorColor">
                                                            <%#Eval("OrderNo")%>
                                                        </a>
                                                        <asp:HiddenField ID="hdnOrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                        <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                        <asp:HiddenField ID="hdnCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText="Order Date"
                                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" SortExpression="OrderDate" DataType="System.DateTime"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="Requiredby" DataField="Requiredby" HeaderText="Delivery Date"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="Requiredby"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataType="System.DateTime"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" AutoPostBackOnFilter="true"
                                                    CurrentFilterFunction="EqualTo" FilterControlWidth="72%">
                                                    <ItemTemplate>
                                                        <asp:Label CssClass="paddingLeft10" ID="lblEstimatedCompletionDate" Text='<%#Bind("Requiredby")%>'
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Qty" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right"
                                                    AllowFiltering="false"  DataType ="System.Int64">
                                                    <ItemTemplate>
                                                    <div class ="qntylblalign">
                                                        <asp:Label ID="lblQty" CssClass="qntylblalign" Text ='<%#Bind("Quantity")%>' runat="server"></asp:Label></div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText="Order Title"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="OrderTitle"
                                                    DataType="System.String" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="73px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Order Status" UniqueName="OrderStatus" AllowFiltering="true"
                                                    HeaderStyle-Width="17%" ItemStyle-Width="17%" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                    DataField="OrderStatus" DataType="System.String" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="75px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price ex Tax" UniqueName="TotalPrice" DataField="TotalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrice" Text='<%#Bind("TotalPrice")%>' runat="server" Style="float: right;"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price in Tax" UniqueName="FinalPrice" DataField="FinalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server" CssClass="floatRight"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <NoRecordsTemplate>
                                                <div class="paddingLeft10">
                                                    <%=objLanguage.GetLanguageConversion("No_Records_Found") %>
                                                </div>
                                            </NoRecordsTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView5" runat="server">
                                    <telerik:RadGrid CssClass="width100p" ID="RadGridJob" runat="server" AutoGenerateColumns="false"
                                        AllowSorting="true" PageSize="50" AllowPaging="true" CellSpacing="0" CellPadding="0"
                                        Visible="true" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                        OnItemCommand="RadGridJob_ItemCommand" OnItemDataBound="RadGridJob_OnItemDataBound"
                                        OnNeedDataSource="RadGridJob_OnNeedDataSource" Width="100%">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                        <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                            HorizontalAlign="NotSet" AutoGenerateColumns="False" TableLayout="Fixed">
                                            <Columns>
                                                <%--   <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                        AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="6%"
                                                        HeaderStyle-Width="7%" ItemStyle-Height="22px">
                                                        <ItemTemplate>
                                                            <div class="MyOrdergrid_Action_Main">
                                                                <div class="MyOrdergrid_Action_Icon">
                                                                    <asp:ImageButton ID="LnkReorder" runat="server" CssClass="ReorderIcon" OnCommand="LnkReorder_Click"
                                                                        CommandArgument='<%# Eval("OrderID") %>' ToolTip="Re-Order" CausesValidation="false"
                                                                        ImageUrl="~/images/StoreImages/Order1.png"></asp:ImageButton>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText="Order Reference"
                                                    HeaderStyle-Width="16%" ItemStyle-Width="16%" SortExpression="OrderNo" DataType="System.String"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="70px">
                                                    <ItemTemplate>
                                                        <a title=' <%#Eval("OrderNo")%>' href="#" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                            class="anchorColor">
                                                            <%#Eval("OrderNo")%>
                                                        </a>
                                                        <asp:HiddenField ID="hdnOrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                        <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                        <asp:HiddenField ID="hdnCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText="Order Date"
                                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" SortExpression="OrderDate" DataType="System.DateTime"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="Requiredby" DataField="Requiredby" HeaderText="Delivery Date"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="Requiredby"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataType="System.DateTime"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" AutoPostBackOnFilter="true"
                                                    CurrentFilterFunction="EqualTo" FilterControlWidth="72%">
                                                    <ItemTemplate>
                                                        <asp:Label CssClass="paddingLeft10" ID="lblEstimatedCompletionDate" Text='<%#Bind("Requiredby")%>'
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Qty" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right"
                                                    AllowFiltering="false" DataType ="System.Int64" >
                                                    <ItemTemplate>
                                                     <div class ="qntylblalign">
                                                        <asp:Label ID="lblQty" Cssclass="qntylblalign" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label></div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText="Order Title"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="OrderTitle"
                                                    DataType="System.String" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="73px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Order Status" UniqueName="OrderStatus" AllowFiltering="true"
                                                    HeaderStyle-Width="17%" ItemStyle-Width="17%" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                    DataField="OrderStatus" DataType="System.String" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="75px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price ex Tax" UniqueName="TotalPrice" DataField="TotalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrice" Text='<%#Bind("TotalPrice")%>' runat="server" Style="float: right;"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price in Tax" UniqueName="FinalPrice" DataField="FinalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server" CssClass="floatRight"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <NoRecordsTemplate>
                                                <div class="paddingLeft10">
                                                    <%=objLanguage.GetLanguageConversion("No_Records_Found") %>
                                                </div>
                                            </NoRecordsTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView6" runat="server">
                                    <telerik:RadGrid CssClass="width100p" ID="RadGridInvoice" runat="server" AutoGenerateColumns="false"
                                        AllowSorting="true" PageSize="50" AllowPaging="true" CellSpacing="0" CellPadding="0"
                                        Visible="true" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                        OnItemCommand="RadGridInvoice_ItemCommand" OnItemDataBound="RadGridInvoice_OnItemDataBound"
                                        OnNeedDataSource="RadGridInvoice_OnNeedDataSource" Width="100%">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                        <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                            HorizontalAlign="NotSet" AutoGenerateColumns="False" TableLayout="Fixed">
                                            <Columns>
                                                <%-- <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                        AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="6%"
                                                        HeaderStyle-Width="7%" ItemStyle-Height="22px">
                                                        <ItemTemplate>
                                                            <div class="MyOrdergrid_Action_Main">
                                                                <div class="MyOrdergrid_Action_Icon">
                                                                    <asp:ImageButton ID="LnkReorder" runat="server" CssClass="ReorderIcon" OnCommand="LnkReorder_Click"
                                                                        CommandArgument='<%# Eval("OrderID") %>' ToolTip="Re-Order" CausesValidation="false"
                                                                        ImageUrl="~/images/StoreImages/Order1.png"></asp:ImageButton>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>--%>
                                                <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText="Order Reference"
                                                    HeaderStyle-Width="16%" ItemStyle-Width="16%" SortExpression="OrderNo" DataType="System.String"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="70px">
                                                    <ItemTemplate>
                                                        <a title=' <%#Eval("OrderNo")%>' href="#" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                            class="anchorColor">
                                                            <%#Eval("OrderNo")%>
                                                        </a>
                                                        <asp:HiddenField ID="hdnOrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                        <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                        <asp:HiddenField ID="hdnCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText="Order Date"
                                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" SortExpression="OrderDate" DataType="System.DateTime"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="Requiredby" DataField="Requiredby" HeaderText="Delivery Date"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="Requiredby"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataType="System.DateTime"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" AutoPostBackOnFilter="true"
                                                    CurrentFilterFunction="EqualTo" FilterControlWidth="72%">
                                                    <ItemTemplate>
                                                        <asp:Label CssClass="paddingLeft10" ID="lblEstimatedCompletionDate" Text='<%#Bind("Requiredby")%>'
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Qty" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right"
                                                    AllowFiltering="false"  DataType ="System.Int64">
                                                    <ItemTemplate>
                                                     <div class ="qntylblalign">
                                                        <asp:Label ID="lblQty" CssClass="qntylblalign" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label></div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText="Order Title"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="OrderTitle"
                                                    DataType="System.String" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="73px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Order Status" UniqueName="OrderStatus" AllowFiltering="true"
                                                    HeaderStyle-Width="17%" ItemStyle-Width="17%" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                    DataField="OrderStatus" DataType="System.String" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="75px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price ex Tax" UniqueName="TotalPrice" DataField="TotalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrice" Text='<%#Bind("TotalPrice")%>' runat="server" Style="float: right;"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price in Tax" UniqueName="FinalPrice" DataField="FinalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server" CssClass="floatRight"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <NoRecordsTemplate>
                                                <div class="paddingLeft10">
                                                    <%=objLanguage.GetLanguageConversion("No_Records_Found") %>
                                                </div>
                                            </NoRecordsTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="RadPageView4" runat="server" CssClass="pageViewEducation">
                                    <telerik:RadGrid CssClass="width100p" ID="MyOrdergrid" runat="server" AutoGenerateColumns="false"
                                        AllowSorting="true" PageSize="50" AllowPaging="true" OnItemDataBound="MyOrdergrid_OnItemDataBound"
                                        OnItemCommand="MyOrdergrid_ItemCommand" OnNeedDataSource="MyOrdergrid_OnNeedDataSource"
                                        CellSpacing="0" CellPadding="0" Visible="true" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                        Width="100%">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                        <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                            HorizontalAlign="NotSet" AutoGenerateColumns="False" TableLayout="Fixed">
                                            <Columns>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="6%"
                                                    HeaderStyle-Width="7%" ItemStyle-Height="22px">
                                                    <ItemTemplate>
                                                        <div class="MyOrdergrid_Action_Main">
                                                            <div class="MyOrdergrid_Action_Icon">
                                                                <asp:ImageButton ID="LnkReorder" runat="server" CssClass="ReorderIcon" OnCommand="LnkReorder_Click"
                                                                    CommandArgument='<%# Eval("OrderID") %>' ToolTip="Re-Order" CausesValidation="false"
                                                                    ImageUrl="~/images/StoreImages/Order1.png" OnClientClick="javascript:return ReorderCheck(this.id,'all');">
                                                                </asp:ImageButton>
                                                                <asp:HiddenField ID="hdnReorder_All" runat="server" Value='<%# Eval("ReOrderCheck") %>' />
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText="Order Reference"
                                                    HeaderStyle-Width="16%" ItemStyle-Width="16%" SortExpression="OrderNo" DataType="System.String"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="70px">
                                                    <ItemTemplate>
                                                        <a title=' <%#Eval("OrderNo")%>' href="#" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                            class="anchorColor">
                                                            <%#Eval("OrderNo")%>
                                                        </a>
                                                        <asp:HiddenField ID="hdnOrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                        <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                        <asp:HiddenField ID="hdnCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                        <asp:HiddenField ID="hdnOrderNo" runat="server" Value='<%#Bind("OrderNo")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText="Order Date"
                                                    HeaderStyle-Width="10%" ItemStyle-Width="10%" SortExpression="OrderDate" DataType="System.DateTime"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="Requiredby" DataField="Requiredby" HeaderText="Delivery Date"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="Requiredby"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" DataType="System.DateTime"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" AutoPostBackOnFilter="true"
                                                    CurrentFilterFunction="EqualTo" FilterControlWidth="72%">
                                                    <ItemTemplate>
                                                        <asp:Label CssClass="paddingLeft10" ID="lblEstimatedCompletionDate" Text='<%#Bind("Requiredby")%>'
                                                            runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Qty" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                    HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right"
                                                    AllowFiltering="false"  DataType ="System.Int64">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblQty" CssClass="qntylblalign" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText="Order Title"
                                                    HeaderStyle-Width="16.5%" ItemStyle-Width="16.5%" SortExpression="OrderTitle"
                                                    DataType="System.String" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left" AllowFiltering="true" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="73px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Order Status" UniqueName="OrderStatus" AllowFiltering="true"
                                                    HeaderStyle-Width="17%" ItemStyle-Width="17%" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                    DataField="OrderStatus" DataType="System.String" CurrentFilterFunction="Contains"
                                                    AutoPostBackOnFilter="true" FilterControlWidth="75px">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblOrderStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price ex Tax" UniqueName="TotalPrice" DataField="TotalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalPrice" Text='<%#Bind("TotalPrice")%>' runat="server" Style="float: right;"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Price in Tax" UniqueName="FinalPrice" DataField="FinalPrice"
                                                    HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                    ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="8%"
                                                    ItemStyle-Width="8%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server" CssClass="floatRight"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <NoRecordsTemplate>
                                                <div class="paddingLeft10">
                                                    <%=objLanguage.GetLanguageConversion("No_Records_Found") %>
                                                </div>
                                            </NoRecordsTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </div>
                    </div>
                    <div id="MyOrder_BackBtn_div">
                        <div id="createAccount_content_bottom_left" class="paddingLeft10">
                            <br />
                            <a href="#" class="anchorColor" onclick="javascript:RedirectToProduct();return false;">
                                <small>«</small><%=objLanguage.GetLanguageConversion("Back") %></a>
                        </div>
                    </div>
                   </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <script type="text/javascript" language="javascript">
        function Onclick_orderNo(OrdKey) {
            if (Rewritemodule.toLowerCase() == 'on') {

                window.location = "<%=strSitepath %>" + "order" + KeySeparator + OrdKey + "<%=FileExtension %>";
            }
            else {
                window.location = "<%=strSitepath %>" + "order.aspx?OrdKey=" + OrdKey;
            }
        }

        // Back to Product Category....
        function RedirectToProduct() {
            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = strSitepath + "products" + KeySeparator + 0 + FileExtension;
            }
            else {
                window.location = strSitepath + "products/product.aspx?ID=0";
            }
        }

        var AllProductsDeletedMSG = '<%=AllProductsDeletedMSG %>';
        var ReorderDltdMsg1 = '<%=ReorderDltdMsg1 %>';
        var ReorderDltdMsg2 = '<%=ReorderDltdMsg2 %>';

        function ReorderCheck(btnid, type) {

            var RPLC;
            if (type == 'order') {
                RPLC = btnid.replace('LnkReorder', 'hdnReorder_Ord');
            }
            else if (type == 'all') {
                RPLC = btnid.replace('LnkReorder', 'hdnReorder_All');
            }

            var result = document.getElementById(RPLC).value;

            if (result != '') {
                var STR1 = result.split('§');

                var Deleted = STR1[0].split('¶');
                var IsDeleted = Deleted[1];

                var AllDeleted = STR1[1].split('¶');
                var IsAllDeleted = AllDeleted[1];

                if (IsDeleted == 'True') {
                    if (IsAllDeleted == 'True') {
                        alert(AllProductsDeletedMSG);
                        return false;
                    }
                    else {
                        var Names = '';
                        if (STR1[2] != '') {
                            var Prods = STR1[2].split('»');
                            for (var c = 0; c < Prods.length; c++) {
                                if (Prods[c] != '') {
                                    var ProdName = Prods[c].split('~');
                                    Names = Names + ProdName[0] + ', ';
                                }
                            }
                        }
                        Names = Names.substring(0, Names.length - 2);
                        var MSG = ReorderDltdMsg1 + Names + ReorderDltdMsg2;
                        if (window.confirm(MSG)) {
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
                else {
                    return true;
                }
            }
        }
        
    </script>
</asp:Content>
