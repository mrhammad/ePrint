<%@ Page Title="My Orders" Language="C#" MasterPageFile="~/Templates/masterPageDefault.master" AutoEventWireup="true" CodeBehind="myorder.aspx.cs" Inherits="ePrint.WebStore.account.myorder" EnableEventValidation="false" ViewStateEncryptionMode="Never" %>




<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_left_banner2.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
       
    </script>
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
            font-size: 13px;
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
        
        #ctl00_ContentPlaceHolder1_radPendingOrder_ctl00 thead tr
        {
            white-space: nowrap;
        }
        #ctl00_ContentPlaceHolder1_RadGridOrder_ctl00 thead tr
        {
            white-space: nowrap;
        }
        
        #ctl00_ContentPlaceHolder1_radAwaiting_ctl00 thead tr
        {
            white-space: nowrap;
        }
        #ctl00_ContentPlaceHolder1_RadGridJob_ctl00 thead tr
        {
            white-space: nowrap;
        }
        #ctl00_ContentPlaceHolder1_RadGridInvoice_ctl00 thead tr
        {
            white-space: nowrap;
        }
    </style>
    <script src="../js/Account.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
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
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radAwaiting">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radAwaiting" LoadingPanelID="RadAjaxLoadingPanel2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnlAwatingClearFil">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radAwaiting" LoadingPanelID="RadAjaxLoadingPanel2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="radPendingOrder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radPendingOrder" LoadingPanelID="RadAjaxLoadingPanel3" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkPendingApproval">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="radPendingOrder" LoadingPanelID="RadAjaxLoadingPanel3" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" SkinID="Windows7" runat="server" />
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel3" SkinID="Windows7" runat="server" />
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel4" SkinID="Windows7" runat="server" />
    <div id="myorder">
        <div id="order_radtab">
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Default" MultiPageID="RadMultiPage2"
                SelectedIndex="0" CssClass="tabStrip" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="Order">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Job">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Invoice">
                    </telerik:RadTab>
                    <%--   <telerik:RadTab Text="All Orders">
                    </telerik:RadTab>--%>
                    <telerik:RadTab Text="Pending Approval">
                    </telerik:RadTab>
                    <telerik:RadTab Text="Awaiting Approval">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
        </div>
        <div id="accountInfoMain_div">
            <div id="accountInfo_background">
                <div id="accountInfoContent_divPadding">
                    <div id="accountInfoContent_div">
                        <div id="accountInfoContent_right">
                            <table class="width100p">
                                <tr>
                                    <td>
                                        <div id="accountInfoContent_left" runat="server" class="widthAuto">
                                            <acc:account_panel ID="account_left_banner2" runat="server" />
                                        </div>
                                    </td>
                                    <td class="width100p">
                                        <div id="order_div" class="width100p">
                                            <div id="order_header">
                                                <div class="DisplayNone">
                                                    <strong>&nbsp;&nbsp;&nbsp;Orders </strong>
                                                </div>
                                                <div id="divClrFilter">
                                                    <div id="DivOrder1" runat="server" class="floatLeft clearBottom DisplayBlock">
                                                        <div style="float: left;">
                                                            <asp:LinkButton ID="lnkOrder" runat="server" CssClass="ClearFilter" Text="" OnClick="lnkOrderFilters_Click" />
                                                        </div>
                                                        <div style="float: left; padding-left: 10px;">
                                                            <asp:LinkButton ID="lnkExport_Excel" runat="server" CssClass="ClearFilter" Text=""
                                                                OnClick="btnExportOrder_OnClick" />
                                                            <!-- <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                                ID="btnExport_Order" runat="server" Text="Export" CssClass="button" OnClick="btnExportOrder_OnClick"
                                                                BackColor="Transparent" />-->
                                                        </div>
                                                    </div>
                                                    <div id="DivJob" runat="server" class="floatLeft clearBottom DisplayNone">
                                                        <div style="float: left;">
                                                            <asp:LinkButton ID="lnkJob" runat="server" CssClass="ClearFilter" Text="" OnClick="lnkJobFilters_Click" />
                                                        </div>
                                                        <div style="float: left; padding-left: 10px;">
                                                            <asp:LinkButton ID="lnkExport_Excel_Job" runat="server" CssClass="ClearFilter" Text=""
                                                                OnClick="btnExportJob_OnClick" />
                                                            <!--<asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                                ID="btnExport_Job" runat="server" Text="Export" CssClass="button" OnClick="btnExportJob_OnClick"
                                                                BackColor="Transparent" />-->
                                                        </div>
                                                    </div>
                                                    <div id="DivInvoice" runat="server" class="floatLeft clearBottom DisplayNone">
                                                        <div style="float: left;">
                                                            <asp:LinkButton ID="lnkInvoice" runat="server" CssClass="ClearFilter" Text="" OnClick="lnkInvoiceFilters_Click" />
                                                        </div>
                                                        <div style="float: left; padding-left: 10px;">
                                                            <asp:LinkButton ID="lnkExport_Excel_Invoice" runat="server" CssClass="ClearFilter"
                                                                Text="" OnClick="btnExportInvoice_OnClick" />
                                                            <!--  <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                                ID="btnExport_Invoice" runat="server" Text="Export" CssClass="button" OnClick="btnExportInvoice_OnClick"
                                                                BackColor="Transparent" />-->
                                                        </div>
                                                    </div>
                                                    <div id="DivOrder" runat="server" class="floatLeft clearBottom DisplayNone">
                                                        <div style="float: left;">
                                                            <asp:LinkButton ID="btnOrderclrFilters" runat="server" CssClass="ClearFilter" Text="Clear All Filters"
                                                                OnClick="OrderclrFilters_Click" />
                                                        </div>
                                                        <div style="float: left; padding-left: 10px;">
                                                            <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                                ID="btnExport_All" runat="server" Text="Export" CssClass="button" OnClick="btnExportAll_OnClick"
                                                                BackColor="Transparent" />
                                                        </div>
                                                    </div>
                                                    <div id="DivAwating" runat="server" class="floatLeft clearBottom DisplayNone">
                                                        <div style="float: left;">
                                                            <asp:LinkButton ID="lnlAwatingClearFil" runat="server" CssClass="ClearFilter" Text="Clear All Filters"
                                                                OnClick="lnlAwatingClearFil_Click" />
                                                        </div>
                                                        <div style="float: left; padding-left: 10px;">
                                                            <asp:LinkButton ID="lnk_Export_Awaiting" runat="server" CssClass="ClearFilter" Text=""
                                                                OnClick="btnExportawaiting_OnClick" />
                                                            <!-- <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                                ID="btnExport_awaiting" runat="server" Text="Export" CssClass="button" OnClick="btnExportawaiting_OnClick"
                                                                BackColor="Transparent" />-->
                                                        </div>
                                                    </div>
                                                    <div id="DivPending" runat="server" class="floatLeft clearBottom DisplayNone">
                                                        <div style="float: left;">
                                                            <asp:LinkButton ID="lnkPendingApproval" runat="server" CssClass="ClearFilter" Text="Clear All Filters"
                                                                OnClick="lnkPendingApproval_Click" />
                                                        </div>
                                                        <div style="float: left; padding-left: 10px;">
                                                            <asp:LinkButton ID="lnk_Export_pending" runat="server" CssClass="ClearFilter" Text=""
                                                                OnClick="btnExportpending_OnClick" />
                                                            <!-- <asp:ImageButton ToolTip="Export" ImageUrl="~/images/StoreImages/export-icon1.jpg"
                                                                ID="btnExport_pending" runat="server" Text="Export" CssClass="button" OnClick="btnExportpending_OnClick"
                                                                BackColor="Transparent" />-->
                                                        </div>
                                                    </div>
                                                    <div id="divMsg" class="productAdded" runat="server">
                                                        <div id="productAdded_image" class="floatLeft">
                                                            <img id="imgSucess" runat="server" alt="" src="~/images/StoreImages/Ok-icon.png" />
                                                        </div>
                                                        <div id="productAdded_sucessMsg">
                                                            <asp:Label ID="lblSucess" runat="server" Text="No items in cart"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="order_content">
                                                <asp:Label ID="lbl_noOrders" runat="server" Text="You have placed no orders."></asp:Label>
                                            </div>
                                            <div id="order_content_table" runat="server" class="widthAuto">
                                                <div id="order_content_Grids" style="margin-right: 25px;">
                                                    <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="0" CssClass="multiPage">
                                                        <telerik:RadPageView ID="RadPageView2" runat="server">
                                                            <telerik:RadGrid ID="RadGridOrder" GridLines="none" runat="server" AllowSorting="true"
                                                                ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                                                AllowFilteringByColumn="true" AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                                                HeaderStyle-Font-Bold="true" AllowPaging="true" HeaderStyle-BorderWidth="0" FilterItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-BorderWidth="0" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                                                                AlternatingItemStyle-BackColor="White" HeaderStyle-ForeColor="#525252" ShowFooter="true"
                                                                Skin="Default" HeaderStyle-BorderColor="#000000" HeaderStyle-Font-Size="13px"
                                                                HeaderStyle-Height="20px" HeaderStyle-BorderStyle="Double" CssClass="AddBorders"
                                                                OnItemDataBound="RadGridOrder_OnItemDataBound" OnNeedDataSource="RadGridOrder_OnNeedDataSource"
                                                                OnItemCommand="RadGridOrder_ItemCommand">
                                                                <AlternatingItemStyle BackColor="White" />
                                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                                                <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0"
                                                                    ShowFooter="false" CssClass="MasterTableView">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="1%"
                                                                            HeaderStyle-Width="1%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Action_Main">
                                                                                    <div class="MyOrdergrid_Action_Icon" style="width: 75px;">
                                                                                        <div style="float: left;">
                                                                                            <asp:LinkButton ID="Lnk_Reorder" runat="server" CssClass="ReorderIcon" ToolTip="Re-Order"
                                                                                                CausesValidation="false" OnCommand="LnkReorder_Click" CommandArgument='<%#String.Concat(Eval("OrderID"),"_",Eval("CartItemID").ToString()) %>'
                                                                                                Visible="false" OnClientClick="javascript:return ReorderCheck(this.id,'order');"></asp:LinkButton>
                                                                                            <asp:HiddenField ID="hdnReorder_Ord" runat="server" Value='<%# Eval("ReOrderCheck") %>' />
                                                                                        </div>
                                                                                        <div style="float: left; padding-left: 5px;">
                                                                                            <asp:PlaceHolder ID="plhAttachments" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                        <div>
                                                                                            <asp:PlaceHolder ID="plheditImage" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="MyOrdergrid_Action_Icon">
                                                                                        <asp:ImageButton ID="img_OrderReject" runat="server" CausesValidation="false" Visible="false"
                                                                                            ToolTip='<%# Eval("RejectReason") %>' ImageUrl="~/images/StoreImages/Reject.png">
                                                                                        </asp:ImageButton>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText=""
                                                                            SortExpression="OrderNo" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="90px" HeaderStyle-Width="6%" ItemStyle-Width="6%" ItemStyle-Height="22px"
                                                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderNo_Main">
                                                                                    <a title=' <%#Eval("OrderNo")%>' href="javascript:void(0);" id='OrderNo' style="white-space: nowrap;"
                                                                                        onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');" class="anchorTagColor">
                                                                                        <%#Eval("OrderNo")%>
                                                                                    </a>
                                                                                    <asp:HiddenField ID="hdn_OrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                                                    <asp:HiddenField ID="hdn_OrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                                                    <asp:HiddenField ID="hdn_CreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                         <%-- added by Safdar for PO--%>
                                                                        
                                                                     <telerik:GridTemplateColumn UniqueName="CustomerPO" DataField="CustomerPO" HeaderText="CustomerPO"
                                                                            SortExpression="CustomerPO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_CustomerPO" Text='<%#Bind("CustomerPO")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- added by chethan for department to column--%>
                                                                        <telerik:GridTemplateColumn UniqueName="Department" DataField="Department" HeaderText=""
                                                                            SortExpression="Department" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_DepartmentTo" Text='<%#Bind("Department")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- end --%>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText=""
                                                                            SortExpression="OrderDate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            DataType="System.DateTime" CurrentFilterFunction="EqualTo">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: center;">
                                                                                    <asp:Label ID="lbl_OrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="RequiredBy" DataField="RequiredBy" HeaderText=""
                                                                            SortExpression="RequiredBy" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" AutoPostBackOnFilter="true" ItemStyle-Height="22px" FilterControlWidth="75px"
                                                                            DataType="System.DateTime" CurrentFilterFunction="EqualTo">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="text-align: center;">
                                                                                    <asp:Label ID="lbl_OrderEstimatedCompletionDate" Text='<%#Bind("RequiredBy")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="OrderedFor" DataField="OrderedFor"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_OrderedFor" Text='<%#Bind("OrderedFor")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                          <telerik:GridTemplateColumn UniqueName="JobName" DataField="JobName" HeaderText=""
                                                                            SortExpression="JobName" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lb_JobName" Text='<%#Bind("JobName")%>' runat="server"></asp:Label>
                                                                                   
                                                                                </div>
                                                                            </ItemTemplate>
                                                                              </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText=""
                                                                            SortExpression="OrderTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblOrderTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%--<telerik:GridBoundColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText=""
                                                                            SortExpression="OrderTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                        </telerik:GridBoundColumn>--%>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderItemTitle" DataField="OrderItemTitle"
                                                                            HeaderText="" SortExpression="OrderItemTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderItemTitle" Text='<%#Bind("OrderItemTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblOrderItemTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderItemTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Quantity" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="padding-left: 1%;">
                                                                                    <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Sign Number" UniqueName="SignNumber" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Center" DataField="SignNumber" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="8%" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_SignNumber" Text='<%#Bind("SignNumber")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Campaign Name" UniqueName="CampaignName"
                                                                            AllowFiltering="true" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="CampaignName"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_campaign" Text='<%#Bind("CampaignName")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="OrderStatus" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="left" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Left" DataField="OrderStatus" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_OrderStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Approved" UniqueName="Approved" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" DataField="Approved" DataType="System.String" AutoPostBackOnFilter="true"
                                                                            HeaderStyle-Width="2%" ItemStyle-Width="2%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_Approved" Style="white-space: nowrap;" Text='<%#Bind("Approved")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <%--<FooterTemplate>
                                                                                <div>
                                                                                    <span style="color: Black; float: right; font-weight: bold;">
                                                                                        <%=objLanguage.GetLanguageConversion("Total")%>:</span>
                                                                                </div>
                                                                            </FooterTemplate>--%>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="TotalPrice" DataField="TotalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <FooterStyle HorizontalAlign="right" Width="90px" Font-Bold="true" />
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_OrderTotalPrice" Style="white-space: nowrap;" Text='<%#Bind("TotalPrice")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <div>
                                                                                    <asp:Label Font-Bold="true" ID="TextBox2" runat="server" CssClass="GV_Row"></asp:Label>
                                                                                </div>
                                                                            </FooterTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="FinalPrice" DataField="FinalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <FooterStyle HorizontalAlign="right" Width="90px" Font-Bold="true" />
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_OrderFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <div>
                                                                                    <asp:Label Font-Bold="true" ID="TextBox1" runat="server" CssClass="GV_Row"></asp:Label>
                                                                                </div>
                                                                            </FooterTemplate>
                                                                        </telerik:GridTemplateColumn>

                                                                          <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate1" DataField="CustomDate1"
                                                                              HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                              ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                              AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                              <ItemTemplate>
                                                                                  <div class="MyOrdergrid_Padding3px">
                                                                                      <asp:Label ID="lbl_OrderCustomDate1" Text='<%#Bind("CustomDate1")%>' runat="server"></asp:Label>
                                                                                  </div>
                                                                               <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                      <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                      <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                          runat="server"></asp:Label>
                                                                                  </div>--%>
                                                                              </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                          <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate2" DataField="CustomDate2"
                                                                              HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                              ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                              AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                              <ItemTemplate>
                                                                                  <div class="MyOrdergrid_Padding3px">
                                                                                      <asp:Label ID="lbl_OrderCustomDate2" Text='<%#Bind("CustomDate2")%>' runat="server"></asp:Label>
                                                                                  </div>
                                                                               <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                      <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                      <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                          runat="server"></asp:Label>
                                                                                  </div>--%>
                                                                              </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate3" DataField="CustomDate3"
                                                                              HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                              ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                              AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                              <ItemTemplate>
                                                                                  <div class="MyOrdergrid_Padding3px">
                                                                                      <asp:Label ID="lbl_OrderCustomDate3" Text='<%#Bind("CustomDate3")%>' runat="server"></asp:Label>
                                                                                  </div>
                                                                               <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                      <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                      <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                          runat="server"></asp:Label>
                                                                                  </div>--%>
                                                                              </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                             <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate4" DataField="CustomDate4"
                                                                              HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                              ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                              AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                              <ItemTemplate>
                                                                                  <div class="MyOrdergrid_Padding3px">
                                                                                      <asp:Label ID="lbl_OrderCustomDate4" Text='<%#Bind("CustomDate4")%>' runat="server"></asp:Label>
                                                                                  </div>
                                                                               <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                      <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                      <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                          runat="server"></asp:Label>
                                                                                  </div>--%>
                                                                              </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                              <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate5" DataField="CustomDate5"
                                                                              HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                              ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                              AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                              <ItemTemplate>
                                                                                  <div class="MyOrdergrid_Padding3px">
                                                                                      <asp:Label ID="lbl_OrderCustomDate5" Text='<%#Bind("CustomDate5")%>' runat="server"></asp:Label>
                                                                                  </div>
                                                                               <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                      <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                      <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                          runat="server"></asp:Label>
                                                                                  </div>--%>
                                                                              </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>

                                                                           <telerik:GridTemplateColumn HeaderText="" UniqueName="JobStatus" DataField="JobStatus"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobStatus" Text='<%#Bind("JobStatus")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                      
                                                                            </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="ProofStatus" DataField="ProofStatus"
                                                                         HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                         ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                         AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                         <ItemTemplate>
                                                                             <div class="MyOrdergrid_Padding3px">
                                                                                 <asp:Label ID="lbl_ProofStatus" Text='<%#Bind("ProofStatus")%>' runat="server"></asp:Label>
                                                                             </div>
                                                                      
                                                                         </ItemTemplate>
                                                                         </telerik:GridTemplateColumn>

                                                                        <%-- <telerik:GridTemplateColumn UniqueName="ActualDeliveryDate" DataField="ActualDeliveryDate"
                                                                            HeaderText="Actual DeliveryDate" SortExpression="ActualDeliveryDate" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main">
                                                                                    <asp:Label ID="lbl_ActualDeliveryDate" Text='<%#Bind("ActualDeliveryDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                        <%-- <telerik:GridTemplateColumn HeaderText="Item Material" UniqueName="ItemMaterial"
                                                                            AllowFiltering="true" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="ItemMaterial"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_ItemMaterial" Text='<%#Bind("ItemMaterial")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                    </Columns>
                                                                    <NoRecordsTemplate>
                                                                        <div class="NoRecordsFound">
                                                                            <%=objLanguage.GetLanguageConversion("No_Records_Found")%>
                                                                        </div>
                                                                    </NoRecordsTemplate>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="RadPageView5" runat="server">
                                                            <telerik:RadGrid ID="RadGridJob" GridLines="none" runat="server" AllowSorting="true"
                                                                ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                                                AllowFilteringByColumn="true" AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                                                HeaderStyle-Font-Bold="true" AllowPaging="true" HeaderStyle-BorderWidth="0" FilterItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-BorderWidth="0" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                                                                EnableHeaderContextMenu="true" ShowFooter="false" AlternatingItemStyle-BackColor="White"
                                                                HeaderStyle-ForeColor="#525252" Skin="Default" HeaderStyle-BorderColor="#000000"
                                                                HeaderStyle-Font-Size="13px" HeaderStyle-Height="20px" HeaderStyle-BorderStyle="Double"
                                                                CssClass="AddBorders" OnItemDataBound="RadGridJob_OnItemDataBound" OnNeedDataSource="RadGridJob_OnNeedDataSource"
                                                                OnItemCommand="RadGridJob_ItemCommand">
                                                                <AlternatingItemStyle BackColor="White" />
                                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                                                <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0"
                                                                    ShowFooter="false" CssClass="MasterTableView">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-Width="1%" HeaderStyle-Width="1%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Action_Icon" style="width: 75px;">
                                                                                    <div style="float: left;">
                                                                                        <asp:LinkButton ID="Lnk_JobReorder" runat="server" CssClass="ReorderIcon" ToolTip="Re-Order"
                                                                                            CausesValidation="false" OnCommand="LnkReorder_Click" CommandArgument='<%# Eval("OrderID") %>'
                                                                                            Visible="false" OnClientClick="javascript:return ReorderCheck(this.id,'job');"></asp:LinkButton>
                                                                                        <asp:HiddenField ID="hdnReorder_Job" runat="server" Value='<%# Eval("ReOrderCheck") %>' />
                                                                                    </div>
                                                                                    <div style="float: left; padding-left: 5px;">
                                                                                        <asp:PlaceHolder ID="plhAttachments" runat="server"></asp:PlaceHolder>
                                                                                    </div>
                                                                                    <div class="MyOrdergrid_Action_Icon">
                                                                                        <asp:ImageButton ID="img_JobReject" runat="server" CausesValidation="false" Visible="false"
                                                                                            ToolTip='<%# Eval("RejectReason") %>' ImageUrl="~/images/StoreImages/Reject.png">
                                                                                        </asp:ImageButton>
                                                                                    </div>
                                                                                </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText=""
                                                                            SortExpression="OrderNo" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="90px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px"
                                                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderNo_Main">
                                                                                    <a title=' <%#Eval("OrderNo")%>' href="javascript:void(0);" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                                                        class="anchorTagColor">
                                                                                        <%#Eval("OrderNo")%>
                                                                                    </a>
                                                                                    <asp:HiddenField ID="hdn_JobKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                                                    <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                                                    <asp:HiddenField ID="hdn_JobCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                          <%-- added by Safdar for PO--%>
                                                                        
                                                                     <telerik:GridTemplateColumn UniqueName="CustomerPO" DataField="CustomerPO" HeaderText="CustomerPO"
                                                                            SortExpression="CustomerPO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_CustomerPO" Text='<%#Bind("CustomerPO")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>

                                                                        <%-- added by chethan for department to column--%>
                                                                        <telerik:GridTemplateColumn UniqueName="Department" DataField="Department" HeaderText=""
                                                                            SortExpression="Department" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_JobDepartmentTo" Text='<%#Bind("Department")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- end --%>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText=""
                                                                            SortExpression="OrderDate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" DataType="System.DateTime"
                                                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main">
                                                                                    <asp:Label ID="lbl_jobDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="RequiredBy" DataField="RequiredBy" HeaderText=""
                                                                            SortExpression="RequiredBy" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="true" HeaderStyle-Width="7%"
                                                                            ItemStyle-Width="7%" AutoPostBackOnFilter="true" DataType="System.DateTime" CurrentFilterFunction="EqualTo"
                                                                            ItemStyle-Height="22px" FilterControlWidth="75px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobEstimatedCompletionDate" Text='<%#Bind("RequiredBy")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                         <telerik:GridTemplateColumn UniqueName="JobName" DataField="JobName" HeaderText=""
                                                                            SortExpression="JobName" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lb_JobName" Text='<%#Bind("JobName")%>' runat="server"></asp:Label>
                                                                                   
                                                                                </div>
                                                                            </ItemTemplate>
                                                                              </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText=""
                                                                            SortExpression="OrderTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderItemTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblOrderItemTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderItemTitle" DataField="OrderItemTitle" HeaderText=""
                                                                            SortExpression="OrderItemTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblJobItemTitle" Text='<%#Bind("OrderItemTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblJobItemTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderItemTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="OrderStatus" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Left" DataField="OrderStatus" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="Quantity" HeaderStyle-HorizontalAlign="right"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price(ex Tax)" UniqueName="TotalPrice" DataField="TotalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_jobTotalPrice" Text='<%#Bind("TotalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price in Tax" UniqueName="FinalPrice" DataField="FinalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>

                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate1" DataField="CustomDate1"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobCustomDate1" Text='<%#Bind("CustomDate1")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate2" DataField="CustomDate2"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobCustomDate2" Text='<%#Bind("CustomDate2")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate3" DataField="CustomDate3"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobCustomDate3" Text='<%#Bind("CustomDate3")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate4" DataField="CustomDate4"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobCustomDate4" Text='<%#Bind("CustomDate4")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate5" DataField="CustomDate5"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_JobCustomDate5" Text='<%#Bind("CustomDate5")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                            </telerik:GridTemplateColumn>
                                                                             <telerik:GridTemplateColumn HeaderText="" UniqueName="ProofStatus" DataField="ProofStatus"
                                                                                 HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                                 ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                                 AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                                 <ItemTemplate>
                                                                                     <div class="MyOrdergrid_Padding3px">
                                                                                         <asp:Label ID="lbl_ProofStatus" Text='<%#Bind("ProofStatus")%>' runat="server"></asp:Label>
                                                                                     </div>
                                                                                     <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                         <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                         <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                             runat="server"></asp:Label>
                                                                                     </div>--%>
                                                                                 </ItemTemplate>
                                                                                 </telerik:GridTemplateColumn>
                                                                    </Columns>
                                                                    <NoRecordsTemplate>
                                                                        <div class="NoRecordsFound">
                                                                            <%=objLanguage.GetLanguageConversion("No_Records_Found")%>
                                                                        </div>
                                                                    </NoRecordsTemplate>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="RadPageView6" runat="server">
                                                            <telerik:RadGrid ID="RadGridInvoice" GridLines="none" runat="server" AllowSorting="true"
                                                                ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                                                AllowFilteringByColumn="true" AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                                                HeaderStyle-Font-Bold="true" AllowPaging="true" HeaderStyle-BorderWidth="0" FilterItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-BorderWidth="0" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                                                                ShowFooter="false" AlternatingItemStyle-BackColor="White" HeaderStyle-ForeColor="#525252"
                                                                Skin="Default" HeaderStyle-BorderColor="#000000" HeaderStyle-Font-Size="13px"
                                                                HeaderStyle-Height="20px" HeaderStyle-BorderStyle="Double" CssClass="AddBorders"
                                                                OnItemDataBound="RadGridInvoice_OnItemDataBound" OnNeedDataSource="RadGridInvoice_OnNeedDataSource"
                                                                OnItemCommand="RadGridInvoice_ItemCommand" EnableHeaderContextMenu="true">
                                                                <AlternatingItemStyle BackColor="White" />
                                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                                                <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0"
                                                                    ShowFooter="false" CssClass="MasterTableView">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="1%"
                                                                            HeaderStyle-Width="1%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Action_Main">
                                                                                    <div class="MyOrdergrid_Action_Icon">
                                                                                        <asp:LinkButton ID="Lnk_InvoiceReorder" runat="server" CssClass="ReorderIcon" ToolTip="Re-Order"
                                                                                            CausesValidation="false" OnCommand="LnkReorder_Click" CommandArgument='<%# Eval("OrderID") %>'
                                                                                            Visible="false" OnClientClick="javascript:return ReorderCheck(this.id,'inv');"></asp:LinkButton>
                                                                                        <asp:HiddenField ID="hdnReorder_Inv" runat="server" Value='<%# Eval("ReOrderCheck") %>' />
                                                                                    </div>
                                                                                    <div style="float: left; padding-left: 5px;">
                                                                                        <asp:PlaceHolder ID="plhAttachments" runat="server"></asp:PlaceHolder>
                                                                                    </div>
                                                                                    <div class="MyOrdergrid_Action_Icon">
                                                                                        <asp:ImageButton ID="img_invocieReject" runat="server" CausesValidation="false" Visible="false"
                                                                                            ToolTip='<%# Eval("RejectReason") %>' ImageUrl="~/images/StoreImages/Reject.png">
                                                                                        </asp:ImageButton>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText=""
                                                                            SortExpression="OrderNo" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="90px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px"
                                                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderNo_Main">
                                                                                    <a title=' <%#Eval("OrderNo")%>' href="javascript:void(0);" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                                                        class="anchorTagColor">
                                                                                        <%#Eval("OrderNo")%>
                                                                                    </a>
                                                                                    <asp:HiddenField ID="hdn_InvoiceKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                                                    <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                                                    <asp:HiddenField ID="hdn_InvoiceCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                          <%-- added by Safdar for PO--%>
                                                                        
                                                                     <telerik:GridTemplateColumn UniqueName="CustomerPO" DataField="CustomerPO" HeaderText="CustomerPO"
                                                                            SortExpression="CustomerPO" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_CustomerPO" Text='<%#Bind("CustomerPO")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>

                                                                        <%-- added by chethan for department to column--%>
                                                                        <telerik:GridTemplateColumn UniqueName="Department" DataField="Department" HeaderText=""
                                                                            SortExpression="Department" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_DepartmentTo" Text='<%#Bind("Department")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- end --%>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText=""
                                                                            SortExpression="OrderDate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="true" HeaderStyle-Width="7%"
                                                                            ItemStyle-Width="7%" ItemStyle-Height="22px" FilterControlWidth="75px" CurrentFilterFunction="EqualTo"
                                                                            DataType="System.DateTime" AutoPostBackOnFilter="true">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main">
                                                                                    <asp:Label ID="lbl_InvoiceDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="RequiredBy" DataField="RequiredBy" HeaderText=""
                                                                            SortExpression="RequiredBy" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="true" HeaderStyle-Width="7%"
                                                                            ItemStyle-Width="7%" AutoPostBackOnFilter="true" ItemStyle-Height="22px" FilterControlWidth="75px"
                                                                            CurrentFilterFunction="EqualTo" DataType="System.DateTime">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvoiceEstimatedCompletionDate" Text='<%#Bind("RequiredBy")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                          <telerik:GridTemplateColumn UniqueName="JobName" DataField="JobName" HeaderText=""
                                                                            SortExpression="JobName" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lb_JobName" Text='<%#Bind("JobName")%>' runat="server"></asp:Label>
                                                                                   
                                                                                </div>
                                                                            </ItemTemplate>
                                                                              </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText=""
                                                                            SortExpression="OrderTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblOrderTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderItemTitle" DataField="OrderItemTitle"
                                                                            HeaderText="" SortExpression="OrderItemTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblInvTitle" Text='<%#Bind("OrderItemTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblInvTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderItemTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="OrderStatus" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Left" DataField="OrderStatus" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvoiceStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price(ex Tax)" UniqueName="TotalPrice" DataField="TotalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvoiceTotalPrice" Text='<%#Bind("TotalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price in Tax" UniqueName="FinalPrice" DataField="FinalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvoiceFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>

                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate1" DataField="CustomDate1"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvCustomDate1" Text='<%#Bind("CustomDate1")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                             <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                          </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate2" DataField="CustomDate2"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvCustomDate2" Text='<%#Bind("CustomDate2")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                             <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                          </telerik:GridTemplateColumn>
                                                                          <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate3" DataField="CustomDate3"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvCustomDate3" Text='<%#Bind("CustomDate3")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                             <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                          </telerik:GridTemplateColumn>
                                                                           <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate4" DataField="CustomDate4"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvCustomDate4" Text='<%#Bind("CustomDate4")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                             <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                          </telerik:GridTemplateColumn>
                                                                            <telerik:GridTemplateColumn HeaderText="" UniqueName="CustomDate5" DataField="CustomDate5"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            AutoPostBackOnFilter="true" ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_InvCustomDate5" Text='<%#Bind("CustomDate5")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                             <%--   <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>--%>
                                                                            </ItemTemplate>
                                                                          </telerik:GridTemplateColumn>
                                                                    </Columns>
                                                                    <NoRecordsTemplate>
                                                                        <div class="NoRecordsFound">
                                                                            <%=objLanguage.GetLanguageConversion("No_Records_Found")%>
                                                                        </div>
                                                                    </NoRecordsTemplate>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="RadPageView3" runat="server">
                                                            <telerik:RadGrid ID="MyOrdergrid" GridLines="none" runat="server" AllowSorting="true"
                                                                ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                                                AllowFilteringByColumn="true" AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                                                HeaderStyle-Font-Bold="true" AllowPaging="true" HeaderStyle-BorderWidth="0" FilterItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-BorderWidth="0" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                                                                ShowFooter="false" AlternatingItemStyle-BackColor="White" OnItemDataBound="MyOrdergrid_OnItemDataBound"
                                                                OnNeedDataSource="MyOrdergrid_OnNeedDataSource" HeaderStyle-ForeColor="#525252"
                                                                Skin="Default" HeaderStyle-BorderColor="#000000" HeaderStyle-Font-Size="13px"
                                                                HeaderStyle-Height="20px" HeaderStyle-BorderStyle="Double" CssClass="AddBorders"
                                                                OnItemCommand="MyOrdergrid_ItemCommand">
                                                                <AlternatingItemStyle BackColor="White" />
                                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                                                <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0"
                                                                    ShowFooter="false" CssClass="MasterTableView">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="1%"
                                                                            HeaderStyle-Width="1%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Action_Main">
                                                                                    <div class="MyOrdergrid_Action_Icon" style="width: 75px;">
                                                                                        <div style="float: left;">
                                                                                            <asp:LinkButton ID="LnkReorder" runat="server" CssClass="ReorderIcon" ToolTip="Re-Order"
                                                                                                CausesValidation="false" OnCommand="LnkReorder_Click" CommandArgument='<%#String.Concat(Eval("OrderID"),"_",Eval("CartItemID").ToString()) %>'
                                                                                                Visible="false" OnClientClick="javascript:return ReorderCheck(this.id,'all');"></asp:LinkButton>
                                                                                            <asp:HiddenField ID="hdnReorder_All" runat="server" Value='<%# Eval("ReOrderCheck") %>' />
                                                                                        </div>
                                                                                        <div style="float: left; padding-left: 5px;">
                                                                                            <asp:PlaceHolder ID="plhAttachments" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                        <div>
                                                                                            <asp:PlaceHolder ID="plheditImage" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="MyOrdergrid_Action_Icon">
                                                                                        <asp:ImageButton ID="imgReject" runat="server" CausesValidation="false" Visible="false"
                                                                                            ToolTip='<%# Eval("RejectReason") %>' ImageUrl="~/images/StoreImages/Reject.png">
                                                                                        </asp:ImageButton>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText=""
                                                                            SortExpression="OrderNo" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="90px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px"
                                                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderNo_Main">
                                                                                    <a title=' <%#Eval("OrderNo")%>' href="javascript:void(0);" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                                                        class="anchorTagColor">
                                                                                        <%#Eval("OrderNo")%>
                                                                                    </a>
                                                                                    <asp:HiddenField ID="hdnOrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                                                    <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                                                    <asp:HiddenField ID="hdnCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText=""
                                                                            SortExpression="OrderDate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="7%"
                                                                            ItemStyle-Width="7%" ItemStyle-Height="22px" FilterControlWidth="75px" CurrentFilterFunction="EqualTo"
                                                                            DataType="System.DateTime" AutoPostBackOnFilter="true">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main">
                                                                                    <asp:Label ID="lblOrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="RequiredBy" DataField="RequiredBy" HeaderText=""
                                                                            SortExpression="RequiredBy" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="false" HeaderStyle-Width="7%"
                                                                            ItemStyle-Width="7%" AutoPostBackOnFilter="true" ItemStyle-Height="22px" FilterControlWidth="75px"
                                                                            CurrentFilterFunction="EqualTo" DataType="System.DateTime">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblEstimatedCompletionDate" Text='<%#Bind("RequiredBy")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Ordered For" UniqueName="OrderedFor" DataField="OrderedFor"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="false" HeaderStyle-Width="8%"
                                                                            ItemStyle-Width="8%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_OrderedFor" Text='<%#Bind("OrderedFor")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText=""
                                                                            SortExpression="OrderTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="false"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="90px"
                                                                            HeaderStyle-Width="12%" ItemStyle-Width="12%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Sign Number" UniqueName="SignNumber" AllowFiltering="false"
                                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Center" DataField="SignNumber" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_SignNumber" Text='<%#Bind("SignNumber")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Campaign Name" UniqueName="CampaignName"
                                                                            AllowFiltering="false" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="CampaignName"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_campaign" Text='<%#Bind("CampaignName")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="OrderStatus" AllowFiltering="false"
                                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Left" DataField="OrderStatus" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Approved" UniqueName="Approved" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" DataField="Approved" DataType="System.String" AutoPostBackOnFilter="true"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_Approved" Text='<%#Bind("Approved")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price(ex Tax)" UniqueName="TotalPrice" DataField="TotalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblTotalPrice" Text='<%#Bind("TotalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price in Tax" UniqueName="FinalPrice" DataField="FinalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- <telerik:GridTemplateColumn UniqueName="ActualDeliveryDate" DataField="ActualDeliveryDate"
                                                                            HeaderText="Actual DeliveryDate" SortExpression="ActualDeliveryDate" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            HeaderStyle-Width="7%" ItemStyle-Width="7%" ItemStyle-Height="22px" FilterControlWidth="75px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main">
                                                                                    <asp:Label ID="lbl_ActualDeliveryDate" Text='<%#Bind("ActualDeliveryDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                        <%-- <telerik:GridTemplateColumn HeaderText="Item Material" UniqueName="ItemMaterial"
                                                                            AllowFiltering="true" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="ItemMaterial"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_ItemMaterial" Text='<%#Bind("ItemMaterial")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                    </Columns>
                                                                    <NoRecordsTemplate>
                                                                        <div class="NoRecordsFound">
                                                                            <%=objLanguage.GetLanguageConversion("No_Records_Found")%>
                                                                        </div>
                                                                    </NoRecordsTemplate>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="RadPageView4" runat="server">
                                                            <telerik:RadGrid ID="radPendingOrder" GridLines="none" runat="server" AllowSorting="true"
                                                                ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                                                AllowFilteringByColumn="true" AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                                                HeaderStyle-Font-Bold="true" AllowPaging="true" HeaderStyle-BorderWidth="0" FilterItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-BorderWidth="0" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                                                                ShowFooter="false" AlternatingItemStyle-BackColor="White" OnNeedDataSource="radPendingOrder_OnNeedDataSource"
                                                                HeaderStyle-ForeColor="#525252" Skin="Default" HeaderStyle-BorderColor="#000000"
                                                                HeaderStyle-BorderStyle="Double" CssClass="AddBorders" OnItemDataBound="radPendingOrder_ItemDataBound"
                                                                Width="100%" HeaderStyle-Height="20px" HeaderStyle-Font-Size="13px" OnItemCommand="radPendingOrder_ItemCommand">
                                                                <AlternatingItemStyle BackColor="White" />
                                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                                                <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0"
                                                                    Width="100%" CssClass="MasterTableView" ShowFooter="false">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="radPendingOrder_Action_Main">
                                                                                    <div class="MyOrdergrid_Action_Icon" style="width: 75px;">
                                                                                        <div style="float: left; padding-left: 5px;">
                                                                                            <asp:PlaceHolder ID="plhAttachments" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText=""
                                                                            SortExpression="OrderNo" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="90px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <a title=' <%#Eval("OrderNo")%>' href="javascript:void(0);" id='OrderNo' onclick="javascript:Onclick_ReferenceorderNo('<%#Eval("OrderID")%>','<%#Eval("StoreUserID")%>');"
                                                                                        class="anchorTagColor">
                                                                                        <%#Eval("OrderNo")%>
                                                                                    </a>
                                                                                    <asp:HiddenField ID="hdnOrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                                                    <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                                                    <asp:HiddenField ID="hdnCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- added by chethan for department to column--%>
                                                                        <telerik:GridTemplateColumn UniqueName="Department" DataField="Department" HeaderText=""
                                                                            SortExpression="Department" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_DepartmentTo" Text='<%#Bind("Department")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- end --%>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText=""
                                                                            SortExpression="OrderDate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px" CurrentFilterFunction="EqualTo"
                                                                            DataType="System.DateTime" AutoPostBackOnFilter="true">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="text-align: center;">
                                                                                    <asp:Label ID="lblOrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="RequiredBy" DataField="RequiredBy" HeaderText=""
                                                                            SortExpression="RequiredBy" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                                                            ItemStyle-Height="22px" DataType="System.DateTime">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="text-align: center;">
                                                                                    <asp:Label ID="lblEstimatedCompletionDate" Text='<%#Bind("RequiredBy")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Ordered For" UniqueName="OrderedFor" DataField="OrderedFor"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" AutoPostBackOnFilter="true" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_OrderedFor" Text='<%#Bind("OrderedFor")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText=""
                                                                            SortExpression="OrderTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblpendingTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblpendingTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderItemTitle" DataField="OrderItemTitle"
                                                                            HeaderText="" SortExpression="OrderItemTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderItemTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblOrderTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderItemTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="Quantity" HeaderStyle-HorizontalAlign="left"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                                            HeaderStyle-Width="2%" ItemStyle-Width="2%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="text-align: left; padding-left: 6px;">
                                                                                    <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Sign Number" UniqueName="SignNumber" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Center" DataField="SignNumber" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="7%" ItemStyle-Width="5%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_SignNumber" Text='<%#Bind("SignNumber")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Campaign Name" UniqueName="CampaignName"
                                                                            AllowFiltering="true" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="CampaignName"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_campaign" Text='<%#Bind("CampaignName")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="OrderStatus" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="left" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Left" DataField="OrderStatus" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderStatus" Text='<%#Bind("OrderStatus")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Approved" UniqueName="Approved" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" DataField="Approved" DataType="System.String" AutoPostBackOnFilter="true"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_Approved" Style="white-space: nowrap" Text='<%#Bind("Approved")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price(ex Tax)" UniqueName="TotalPrice" DataField="TotalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="25px"
                                                                            ItemStyle-Width="25%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="white-space: nowrap;">
                                                                                    <asp:Label ID="lblTotalPrice" Style="width: auto;" Text='<%#Bind("TotalPrice")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="FinalPrice" DataField="FinalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="10%"
                                                                            ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- <telerik:GridTemplateColumn UniqueName="ActualDeliveryDate" DataField="ActualDeliveryDate"
                                                                            HeaderText="Actual DeliveryDate" SortExpression="ActualDeliveryDate" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            HeaderStyle-Width="7%" ItemStyle-Width="7%" ItemStyle-Height="22px" FilterControlWidth="75px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main">
                                                                                    <asp:Label ID="lbl_ActualDeliveryDate" Text='<%#Bind("ActualDeliveryDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                        <%-- <telerik:GridTemplateColumn HeaderText="Item Material" UniqueName="ItemMaterial"
                                                                            AllowFiltering="true" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="ItemMaterial"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_ItemMaterial" Text='<%#Bind("ItemMaterial")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                    </Columns>
                                                                    <NoRecordsTemplate>
                                                                        <div class="NoRecordsFound">
                                                                            <%=objLanguage.GetLanguageConversion("No_Records_Found")%>
                                                                        </div>
                                                                    </NoRecordsTemplate>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </telerik:RadPageView>
                                                        <telerik:RadPageView ID="RadPageView1" runat="server">
                                                            <telerik:RadGrid ID="radAwaiting" GridLines="none" runat="server" AllowSorting="true"
                                                                ShowGroupPanel="True" EnableEmbeddedSkins="true" EnableTheming="false" GroupingEnabled="False"
                                                                AllowFilteringByColumn="true" AutoGenerateColumns="False" PageSize="50" GroupingSettings-CaseSensitive="false"
                                                                HeaderStyle-Font-Bold="true" AllowPaging="true" HeaderStyle-BorderWidth="0" FilterItemStyle-HorizontalAlign="Left"
                                                                ItemStyle-BorderWidth="0" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                                                                ShowFooter="false" AlternatingItemStyle-BackColor="White" OnNeedDataSource="radAwaiting_OnNeedDataSource"
                                                                HeaderStyle-ForeColor="#525252" Skin="Default" HeaderStyle-BorderColor="#000000"
                                                                HeaderStyle-BorderStyle="Double" CssClass="AddBorders" OnItemDataBound="radAwaitingOrder_ItemDataBound"
                                                                HeaderStyle-Height="20px" HeaderStyle-Font-Size="13px" OnItemCommand="radAwaiting_ItemCommand">
                                                                <AlternatingItemStyle BackColor="White" />
                                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                                                                <MasterTableView DataKeyNames="OrderID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" CellPadding="0" CellSpacing="0"
                                                                    CssClass="MasterTableView" ShowFooter="false">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" UniqueName="Action" ItemStyle-VerticalAlign="Top" ItemStyle-Width="1%"
                                                                            HeaderStyle-Width="1%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Action_Main">
                                                                                    <div class="MyOrdergrid_Action_Icon" style="width: 75px;">
                                                                                        <div style="float: left;">
                                                                                            <asp:LinkButton ID="Lnk_ReorderIcon" runat="server" CssClass="ReorderIcon" ToolTip="Re-Order"
                                                                                                CausesValidation="false" OnCommand="LnkReorder_Click" CommandArgument='<%#String.Concat(Eval("OrderID"),"_",Eval("CartItemID").ToString()) %>'
                                                                                                Visible="false" OnClientClick="javascript:return ReorderCheck(this.id,'awaiting');"></asp:LinkButton>
                                                                                            <asp:HiddenField ID="hdnReorder_Ord" runat="server" Value='<%# Eval("ReOrderCheck") %>' />
                                                                                        </div>
                                                                                        <div style="float: left; padding-left: 5px;">
                                                                                            <asp:PlaceHolder ID="plhAttachments" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                        <div>
                                                                                            <asp:PlaceHolder ID="plheditImage" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderNo" DataField="OrderNo" HeaderText=""
                                                                            SortExpression="OrderNo" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="90px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <a title=' <%#Eval("OrderNo")%>' href="javascript:void(0);" id='OrderNo' onclick="javascript:Onclick_orderNo('<%#Eval("OrderKey")%>');"
                                                                                        class="anchorTagColor">
                                                                                        <%#Eval("OrderNo")%>
                                                                                    </a>
                                                                                    <asp:HiddenField ID="hdnOrderKey" runat="server" Value='<%#Bind("OrderKey")%>' />
                                                                                    <asp:HiddenField ID="hdnOrderID" runat="server" Value='<%#Bind("OrderID")%>' />
                                                                                    <asp:HiddenField ID="hdnCreatedBy" runat="server" Value='<%#Bind("createdBy")%>' />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- added by chethan for department to column--%>
                                                                        <telerik:GridTemplateColumn UniqueName="Department" DataField="Department" HeaderText=""
                                                                            SortExpression="Department" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="5%"
                                                                            ItemStyle-Width="5%" ItemStyle-Height="22px" FilterControlWidth="75px" AutoPostBackOnFilter="true"
                                                                            CurrentFilterFunction="Contains">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main" style="text-align: left;">
                                                                                    <asp:Label ID="lbl_DepartmentTo" Text='<%#Bind("Department")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%-- end --%>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderDate" DataField="OrderDate" HeaderText=""
                                                                            SortExpression="OrderDate" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="true" HeaderStyle-Width="7%"
                                                                            ItemStyle-Width="7%" ItemStyle-Height="22px" CurrentFilterFunction="EqualTo"
                                                                            DataType="System.DateTime" AutoPostBackOnFilter="true">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px" style="text-align: center;">
                                                                                    <asp:Label ID="lblOrderDate" Text='<%#Bind("OrderDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="RequiredBy" DataField="RequiredBy" HeaderText=""
                                                                            SortExpression="RequiredBy" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="true" HeaderStyle-Width="7%"
                                                                            ItemStyle-Width="7%" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                                                            ItemStyle-Height="22px" DataType="System.DateTime">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblEstimatedCompletionDate" CssClass="radAwaiting_lblEstimatedCompletionDate"
                                                                                        Text='<%#Bind("RequiredBy")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Ordered For" UniqueName="OrderedFor" DataField="OrderedFor"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Left" AllowFiltering="true" HeaderStyle-Width="8%"
                                                                            ItemStyle-Width="8%" ItemStyle-Height="22px" AutoPostBackOnFilter="true">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_OrderedFor" Text='<%#Bind("OrderedFor")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                                <div id="div_atnfor" runat="server" class="smallfont DisplayNone">
                                                                                    <%=objLanguage.GetLanguageConversion("For_the_attention_of")%>
                                                                                    <asp:Label ID="lbl_forattn" CssClass="smallfontgrey" Text='<%#Bind("AttentionFor")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderTitle" DataField="OrderTitle" HeaderText=""
                                                                            SortExpression="OrderTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblawaitingTitle" Text='<%#Bind("OrderTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblawaitingTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn UniqueName="OrderItemTitle" DataField="OrderItemTitle"
                                                                            HeaderText="" SortExpression="OrderItemTitle" DataType="System.String" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderTitle" Text='<%#Bind("OrderItemTitle")%>' runat="server"></asp:Label>
                                                                                    <%--<asp:Label ID="lblOrderTitle" runat="server"><%# objBc.SpecialDecode(DataBinder.Eval(Container, "DataItem.OrderItemTitle", "{0}"))%></asp:Label></div>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="Quantity" HeaderStyle-HorizontalAlign="Right"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Right" AllowFiltering="false"
                                                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblQty" Text='<%#Bind("Quantity")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Sign Number" UniqueName="SignNumber" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Center" DataField="SignNumber" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_SignNumber" Text='<%#Bind("SignNumber")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Campaign Name" UniqueName="CampaignName"
                                                                            AllowFiltering="true" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="CampaignName"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_campaign" Text='<%#Bind("CampaignName")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="" UniqueName="OrderStatus" AllowFiltering="true"
                                                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top"
                                                                            ItemStyle-HorizontalAlign="Left" DataField="OrderStatus" DataType="System.String"
                                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="75px"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblOrderStatus" Style="text-align: center;" Text='<%#Bind("OrderStatus")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Approved" UniqueName="Approved" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderStyle-Font-Bold="true" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left"
                                                                            AllowFiltering="false" DataField="Approved" DataType="System.String" AutoPostBackOnFilter="true"
                                                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_Approved" Style="white-space: nowrap;" Text='<%#Bind("Approved")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Price(ex Tax)" UniqueName="TotalPrice" DataField="TotalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="20%"
                                                                            ItemStyle-Width="20%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblTotalPrice" Style="white-space: nowrap;" Text='<%#Bind("TotalPrice")%>'
                                                                                        runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Final Price" UniqueName="FinalPrice" DataField="FinalPrice"
                                                                            HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                                                            ItemStyle-HorizontalAlign="Right" AllowFiltering="false" HeaderStyle-Width="20%"
                                                                            ItemStyle-Width="20%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lblFinalPrice" Text='<%#Bind("FinalPrice")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <%--  <telerik:GridTemplateColumn UniqueName="ActualDeliveryDate" DataField="ActualDeliveryDate"
                                                                            HeaderText="Actual DeliveryDate" SortExpression="ActualDeliveryDate" HeaderStyle-Font-Bold="true"
                                                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                                                            HeaderStyle-Width="7%" ItemStyle-Width="7%" ItemStyle-Height="22px" FilterControlWidth="75px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_OrderDate_Main">
                                                                                    <asp:Label ID="lbl_ActualDeliveryDate" Text='<%#Bind("ActualDeliveryDate")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                        <%-- <telerik:GridTemplateColumn HeaderText="Item Material" UniqueName="ItemMaterial"
                                                                            AllowFiltering="true" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Font-Bold="true"
                                                                            ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" DataField="ItemMaterial"
                                                                            DataType="System.String" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                                            FilterControlWidth="75px" HeaderStyle-Width="10%" ItemStyle-Width="10%" ItemStyle-Height="22px">
                                                                            <ItemTemplate>
                                                                                <div class="MyOrdergrid_Padding3px">
                                                                                    <asp:Label ID="lbl_ItemMaterial" Text='<%#Bind("ItemMaterial")%>' runat="server"></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>--%>
                                                                    </Columns>
                                                                    <NoRecordsTemplate>
                                                                        <div class="NoRecordsFound">
                                                                            <%=objLanguage.GetLanguageConversion("No_Records_Found")%>
                                                                        </div>
                                                                    </NoRecordsTemplate>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </telerik:RadPageView>
                                                    </telerik:RadMultiPage>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="createAccount_content_bottom">
                                            <div id="createAccount_content_bottom_left" class="clearLeft">
                                                <br />
                                                <a href="javascript:void(0);" class="anchorColor" onclick="javascript:RedirectToProduct();return false;">
                                                    <small>«</small>Back</a>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" language="javascript">
            var strSitepath = '<%=strSitepath %>';
            var AllProductsDeletedMSG = '<%=AllProductsDeletedMSG %>';
            var ReorderDltdMsg1 = '<%=ReorderDltdMsg1 %>';
            var ReorderDltdMsg2 = '<%=ReorderDltdMsg2 %>';
        </script>
        <script type="text/javascript" src="../js/general.js?VN='<%=VersionNumber%>'"></script>
    </div>
    <telerik:RadWindowManager ID="RadWindowManager3" runat="server">
        <Windows>
            <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" Title="Artwork View"
                KeepInScreenBounds="true" VisibleTitlebar="true" VisibleStatusbar="true" Modal="true"
                ShowContentDuringLoad="false" Behaviors="Close,Move,Reload,Resize,Maximize">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <script type="text/javascript">
        function openArtworkPopup(CartItemID, OrderItemID, OrderID, page) {

            var oWnd = $find("<%= RadWindow1.ClientID %>");
            oWnd.setUrl('<%=strSitepath %>' + "common/artwork_common.aspx?CartItemID=" + CartItemID + "&OrderItemId=" + OrderItemID + "&from=" + page + "&OrderID=" + OrderID);
            oWnd.setSize(600, 300);
            oWnd.center();
            oWnd.show();
        }      
    </script>
</asp:Content>
