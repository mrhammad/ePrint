<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="warehouse_list.ascx.cs" Inherits="ePrint.usercontrol.purchase.warehouse_list" %>

<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
    .noSelect {
    -webkit-touch-callout: none;
    -webkit-user-select: none;
    -khtml-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
}  
</style>

<%--<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
<%--<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridInventory">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>--%>
<div align="left" style="width: 100%">
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text="Paper Selector"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div id="divBackGroundNew" style="display: none">
    </div>
    <asp:UpdateProgress ID="UpPro" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div id="divBackGround1">
                 <center>
                  <div id="divLoading" class="noSelect" style="position: fixed; float:left; height:100%; overflow:auto; width:100%; right:0; bottom:0; left:0;top:0;
                   display:block; background-color:#A8A8A8; padding-bottom:25%;">
                        <div class="Graphic" style="pointer-events:none"; z-index: 10200;>
                            <div>
                                <img src="<%=strImagepath %>loading_new.gif" border="0" style="display:block;margin-top:15%;opacity:5;"/>
                            </div>
                         </div>
                        <div style="clear: both">
                        </div>
                  </div>
               </center>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div>
        <%--class="borderWithoutTop"--%>
        <div>
            <%--id="padding"--%>
            <div id="div_Search" align="left" runat="server" style="width: 100%">
                <div class="bglabel" style="width: 20%">
                    <asp:Label ID="Label28" runat="server" Text="" CssClass="normaltext"></asp:Label>
                </div>
                <div class="ddlsetting" style="width: 25%;">
                    <asp:DropDownList ID="ddlInvCategory" runat="server" CssClass="normalText" AutoPostBack="true"
                        Width="130px" OnSelectedIndexChanged="ddlInvCategory_OnSelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="box" style="width: 20%">
                    <asp:Button ID="btnShowAll" runat="server" Text="" CssClass="button" Width="190px"
                        Visible="false" ToolTip="all" />
                    <%--OnClick="btnShowAll_OnClick"--%>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div align="left" id="div_InvItems" runat="server" style="width: 100%; padding-top: 10px;">
                <div style="float: left; width: 100%">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div style="float: left; width: 100%;">
                                <%--<div id="div_TotalRec" style="float: right; padding-right: 5px">
                                    <span class="normalText">Total Records:</span><b>
                                        <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b></div>--%>
                                <div id="link_invent" style="float: left; text-align: left; width: 99%; padding-bottom: 5px;
                                    padding-top: 5px;">
                                    <asp:LinkButton ID="link_clrfilt_Invntry" OnClick="clrFilters_Click_inventry" Style="text-decoration: underline;
                                        cursor: pointer" runat="server" Text="" />
                                </div>
                            </div>
                            <div class="onlyEmpty">
                            </div>
                            <div id="div_Main" runat="server" align="left" style="width: 100%; border: 0px solid red;">
                                <%-- <div id="a">
                                </div>--%>
                                <div id="div_Grid">
                                    <asp:HiddenField runat="server" ID="hdnGridInventoryRadGrid" Value="10" />
                                    <telerik:RadGrid ID="GridInventory" runat="server" AllowPaging="true" PageSize="10"
                                        ShowStatusBar="true" Visible="true" Width="99%" HeaderStyle-Font-Bold="true"
                                        AutoGenerateColumns="false" HeaderStyle-HorizontalAlign="Left" ShowHeader="true"
                                        PagerStyle-AlwaysVisible="true" OnItemDataBound="GridInventory_OnRowDataBound"
                                        OnNeedDataSource="GridView1_NeedDataSource" OnItemCommand="GridView1_ItemCommand"
                                        OnPageSizeChanged="GridInventory_PageSizeChanged" OnPageIndexChanged="GridInventory_PageIndexChanged"
                                        OnSortCommand="GridInventory_SortCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true"
                                        EnableEmbeddedSkins="false" HeaderStyle-Wrap="true" ItemStyle-Wrap="false" FilterItemStyle-Wrap="true"
                                        CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                        PagerStyle-Wrap="true" AllowSorting="true">
                                        <ClientSettings AllowExpandCollapse="True">
                                            <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                        </ClientSettings>
                                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                        <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true">
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="true" HeaderText="" HeaderStyle-Width="12%"
                                                    ItemStyle-Width="12%" DataField="InventoryCode" UniqueName="InventoryCode" SortExpression="InventoryCode"
                                                    AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; width: 99%; overflow: hidden">
                                                            <a href="#" title='<%#Eval("InventoryCode")%>' style="display: none" id='A1' onclick="ShowWarehouseQtyDiv('show');getvalues('<%#Eval("InventoryID")%>','<%#Eval("InventoryCode")%>','<%#Eval("InventoryName")%>','<%#Eval("PackedIn")%>','<%#Eval("PackedPrice")%>','I','<%#Eval("Cost")%>','<%#Eval("PerQuantity")%>','<%#Eval("PaperType") %>','<%#Eval("Description") %>','<%#Eval("StockType") %>','1')">
                                                                <%#Eval("LimitInventoryCode")%>
                                                            </a>
                                                            <asp:LinkButton ID="lnkInvCode" runat="server" ToolTip='<%#Eval("InventoryCode")%>'
                                                                Text='<%#Eval("InventoryCode")%>'></asp:LinkButton>
                                                            <asp:HiddenField ID="hid_InventoryCode" runat="server" Value='<%#Eval("InventoryCode") %>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="10%"
                                                    DataField="InventoryName" SortExpression="InventoryName" UniqueName="InventoryName"
                                                    AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; width: 99%; overflow: hidden">
                                                            <a href="#" title='<%#Eval("InventoryName")%>' style="display: none" onclick="ShowWarehouseQtyDiv('show');getvalues('<%#Eval("InventoryID")%>','<%#Eval("InventoryCode")%>','<%#Eval("InventoryName")%>','<%#Eval("PackedIn")%>','<%#Eval("PackedPrice")%>','I','<%#Eval("Cost")%>','<%#Eval("PerQuantity")%>','<%#Eval("PaperType") %>','<%#Eval("Description") %>','<%#Eval("StockType") %>','1')">
                                                                <%#Eval("LimitInventoryName")%>
                                                            </a>
                                                            <asp:LinkButton ID="lnkInvName1" runat="server" ToolTip='<%#Eval("InventoryName")%>'
                                                                Text='<%#Eval("InventoryName")%>'></asp:LinkButton>
                                                            <asp:HiddenField ID="hid_InventoryID" runat="server" Value='<%#Eval("InventoryID") %>' />
                                                            <asp:Label ID="lblInvName" runat="server" Text='<%#Eval("InventoryName")%>' Visible="false"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="10%" DataField="Description"
                                                    ItemStyle-Width="10%" UniqueName="Description" SortExpression="Description" FilterControlWidth="40%"
                                                    AllowFiltering="true" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; width: 99%; overflow: hidden">
                                                            <asp:Label ID="lblInvDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="10%" DataField="FriendlyName"
                                                    ItemStyle-Width="10%" UniqueName="FriendlyName" SortExpression="FriendlyName" FilterControlWidth="40%"
                                                    AllowFiltering="true" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; width: 99%; overflow: hidden">
                                                            <asp:Label ID="lblInvFriendlyName" runat="server" Text='<%#Eval("FriendlyName")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="10%" DataField="BasisWeight"
                                                    ItemStyle-Width="10%" UniqueName="BasisWeight" SortExpression="BasisWeight" FilterControlWidth="40%"
                                                    AllowFiltering="true" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; width: 99%; overflow: hidden">
                                                            <asp:Label ID="lblInvWeightSize" runat="server" Text='<%#Eval("BasisWeight")%>'></asp:Label>
                                                            <asp:Label ID="lblGsm" runat="server" Text="gsm"></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="12%" DataField="PaperName"
                                                    UniqueName="PaperName" SortExpression="PaperName" ItemStyle-Wrap="false" ItemStyle-Width="12%"
                                                    ItemStyle-Height="20px" AllowFiltering="true" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; padding-left: 5px; width: 99%; overflow: hidden">
                                                            <asp:Label ID="lblPaperSize" runat="server" Text='<%#Eval("PaperName")%>'></asp:Label>
                                                            <asp:HiddenField ID="hid_Height" runat="server" Value='<%#Eval("Height") %>' />
                                                            <asp:HiddenField ID="hid_Width" runat="server" Value='<%#Eval("Width") %>' />
                                                            <asp:HiddenField ID="hid_Length" runat="server" Value='<%#Eval("Length") %>' />
                                                            <asp:HiddenField ID="hid_WidthType" runat="server" Value='<%#Eval("WidthType") %>' />
                                                            <asp:HiddenField ID="hid_LengthType" runat="server" Value='<%#Eval("LengthType") %>' />
                                                            <asp:HiddenField ID="hid_PaperType" runat="server" Value='<%#Eval("PaperType") %>' />
                                                            <asp:HiddenField ID="hid_PackedIn" runat="server" Value='<%#Eval("PackedIn") %>' />
                                                            <asp:HiddenField ID="hid_StockType" runat="server" Value='<%#Eval("StockType")%>' />
                                                            <asp:HiddenField ID="hid_PackedInType" runat="server" Value='<%#Eval("PackedInType")%>' />
                                                            <asp:HiddenField ID="hid_Description" runat="server" Value='<%#Eval("Description")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="12%" DataField="PackedIn"
                                                    SortExpression="PackedIn" UniqueName="PackedIn" ItemStyle-Wrap="false" ItemStyle-Width="12%"
                                                    AllowFiltering="false" ItemStyle-Height="20px" ItemStyle-HorizontalAlign="left">
                                                    <ItemTemplate>
                                                        <div style="float: right; width: 60%; overflow: hidden">
                                                            <asp:Label ID="lblPackQty" runat="server" Text='<%#Eval("PackedIn")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Pack Price($)" HeaderStyle-Width="12%" DataField="PackedPrice"
                                                    UniqueName="PackedPrice" SortExpression="PackedPrice" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Left" ItemStyle-Height="20px"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <div style="float: right; width: 60%; overflow: hidden">
                                                            <asp:Label ID="lblPackPrice" runat="server" Text='<%#Eval("PackedPrice")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="12%" ItemStyle-Width="12%"
                                                    DataField="Cost" UniqueName="Cost" SortExpression="Cost" ItemStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <div style="float: left; padding-left: 5px; width: 99%; overflow: hidden">
                                                            &nbsp;<asp:Label ID="lblInvCost" runat="server" Text='<%#Eval("Cost")%>'></asp:Label>
                                                            <asp:Label ID="lblMsgPer" runat="server" Text=" &nbsp;Per&nbsp;"></asp:Label>
                                                            <asp:Label ID="lblInvPer" runat="server" Text='<%#Eval("PerQuantity")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Width="20%" ItemStyle-Width="20%"
                                                    DataField="SupplierName" SortExpression="SupplierName" UniqueName="SupplierName"
                                                    FilterControlWidth="65%" AutoPostBackOnFilter="true">
                                                    <ItemTemplate>
                                                        <div style="float: left; padding-left: 5px; width: 99%; overflow: hidden">
                                                            <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("SupplierName")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <%--<ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="true" AllowRowsDragDrop="true"
                                            AllowColumnsReorder="false">
                                            <Scrolling AllowScroll="true" ScrollHeight="250" UseStaticHeaders="True" EnableVirtualScrollPaging="false">
                                            </Scrolling>
                                        </ClientSettings>--%>
                                    </telerik:RadGrid>
                                    <%--<asp:ObjectDataSource ID="odsInventory" runat="server" TypeName="Printcenter.UI.Inventories.InventoryBasePage"
                                    SelectMethod="warehouse_inventory_selectall_onclientid"></asp:ObjectDataSource>--%>
                                    <%-- <div align="left" style="width: 99.5%">
                                        <UC:Paging ID="usrPaging" runat="server" />
                                    </div>--%>
                                </div>
                            </div>
                            <%-- <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                                <div id="padding" class="emptyrecords" align="center">
                                    <span class="HeaderText" style="text-align: center">No record(s) found</span>
                                </div>
                            </asp:Panel>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div align="left" id="div_ink" runat="server" style="width: 100%;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div align="left" style="width: 100%">
                            <div id="div_TotalRecInk" style="float: right; padding-right: 5px">
                                <%--<span class="normalText">Total Records:</span>--%>
                                <%--<asp:Label ID="lblTotalRecordsInk" Font-Bold="true" runat="server"></asp:Label>--%></div>
                            <div id="ink_link" style="float: left; text-align: left; width: 99%; padding-bottom: 5px;
                                padding-top: 5px;">
                                <asp:LinkButton ID="link_clrfilt_Ink" Style="text-decoration: underline; cursor: pointer"
                                    runat="server" Text="Clear all Filters" OnClick="clrFilters_Click_ink" />
                            </div>
                        </div>
                        <div class="onlyEmpty">
                        </div>
                        <div id="div_MainInk" runat="server" align="left" style="width: 100%">
                            <div id="aInk">
                            </div>
                            <div id="div_GridInk">
                                <asp:HiddenField runat="server" ID="hdnGridInk" Value="10" />
                                <telerik:RadGrid ID="GridInk" runat="server" AllowPaging="true" ShowStatusBar="true"
                                    Visible="true" Width="99%" HeaderStyle-Font-Bold="true" AutoGenerateColumns="false"
                                    AllowSorting="true" HeaderStyle-HorizontalAlign="Left" ShowHeader="true" PagerStyle-AlwaysVisible="true"
                                    OnItemDataBound="GridInk_OnRowDataBound" OnItemCommand="GridInk_OnItemCommand"
                                    OnNeedDataSource="GridInk_OnNeedDataSource" OnPageSizeChanged="GridInk_PageSizeChanged"
                                    OnPageIndexChanged="GridInk_PageIndexChanged" OnSortCommand="GridInk_SortCommand">
                                    <MasterTableView AllowFilteringByColumn="true">
                                        <Columns>
                                            <telerik:GridTemplateColumn HeaderText="Name" DataField="InventoryName" UniqueName="InventoryName"
                                                DataType="System.String" SortExpression="InventoryName" AllowFiltering="true"
                                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                                <ItemStyle Width="40%" />
                                                <ItemTemplate>
                                                    <div style="float: left; cursor: pointer; overflow: hidden; max-height: 18px; height: 18px;">
                                                        <a href="#" id='<%#Eval("InventoryID")%>' onclick="ShowWarehouseQtyDiv('show');getvalues(this.id,'<%#Eval("InventoryCode")%>','<%#Eval("InventoryName")%>','<%#Eval("PackedIn")%>','<%#Eval("PackedPrice")%>','I','<%#Eval("Cost")%>','<%#Eval("PerQuantity")%>','','<%#Eval("Description") %>','<%#Eval("StockType") %>','1')">
                                                            <%#Eval("InventoryName")%>
                                                        </a>
                                                    </div>
                                                    <asp:Label ID="lblInvCode" runat="server" Text='<%#Eval("InventoryCode")%>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="PackedIn" HeaderText="Pack Qty" UniqueName="PackedIn"
                                                SortExpression="PackedIn" AllowFiltering="true" AutoPostBackOnFilter="true">
                                                <ItemStyle Width="20%" />
                                                <ItemTemplate>
                                                    <div style="float: left; overflow: hidden; max-height: 18px; height: 18px;">
                                                        <asp:Label ID="lblInkPackQty" runat="server" Text='<%#Eval("PackedIn")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="PackedPrice" UniqueName="PackedPrice" SortExpression="PackedPrice"
                                                HeaderText="Pack Price($)" AllowFiltering="true" AutoPostBackOnFilter="true">
                                                <ItemStyle Width="20%" />
                                                <ItemTemplate>
                                                    <div style="float: left; max-height: 18px; height: 18px;">
                                                        <asp:Label ID="lblInkPackPrice" runat="server" Text='<%#Eval("PackedPrice")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="SupplierName" SortExpression="SupplierName"
                                                UniqueName="SupplierName" FilterControlWidth="60%" HeaderText="Supplier" HeaderStyle-Width="20%"
                                                ItemStyle-Width="20%" ItemStyle-Wrap="true" AutoPostBackOnFilter="true">
                                                <ItemTemplate>
                                                    <div style="float: left; max-height: 18px; height: 18px; overflow: hidden;">
                                                        <asp:Label ID="lblSupplier" runat="server" ToolTip='<%#Eval("SupplierName")%>' Text='<%#Eval("SupplierName")%>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                                <%--  <asp:GridView ID="GridInk" runat="server" AutoGenerateColumns="false" GridLines="Horizontal"
                                    AllowPaging="true" PageSize="100" SkinID="GridStyle" OnRowDataBound="GridInk_OnRowDataBound">
                                    
                                    <Columns>
                                        <asp:TemplateField HeaderText="Name" ItemStyle-Wrap="false" ItemStyle-Width="40%"
                                            ItemStyle-Height="20px">
                                            <HeaderStyle HorizontalAlign="Left" Width="40%" Wrap="false" />
                                            <ItemTemplate>
                                                <a href="#" id='<%#Eval("InventoryID")%>' onclick="ShowWarehouseQtyDiv('show');getvalues(this.id,'<%#Eval("InventoryCode")%>','<%#Eval("InventoryName")%>','<%#Eval("PackedIn")%>','<%#Eval("PackedPrice")%>','I','<%#Eval("Cost")%>','<%#Eval("PerQuantity")%>','','<%#Eval("StockType") %>','1')">
                                                    <%#Eval("InventoryName")%>
                                                </a>
                                                <asp:Label ID="lblInvCode" runat="server" Text='<%#Eval("InventoryCode")%>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pack Qty" ItemStyle-Wrap="false" ItemStyle-Width="30%"
                                            ItemStyle-HorizontalAlign="Right">
                                            <HeaderStyle HorizontalAlign="Right" Width="30%" Wrap="false" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblInkPackQty" runat="server" Text='<%#Eval("PackedIn")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pack Price($)" ItemStyle-Wrap="false" ItemStyle-Width="35%"
                                            ItemStyle-HorizontalAlign="Right">
                                            <HeaderStyle HorizontalAlign="Right" Width="35%" Wrap="false" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblInkPackPrice" runat="server" Text='<%#Eval("PackedPrice")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div id="padding" class="emptyrecords" align="center">
                                            <span class="HeaderText" style="text-align: center">No record(s) found</span>
                                        </div>
                                    </EmptyDataTemplate>
                                    <PagerTemplate>
                                    </PagerTemplate>
                                </asp:GridView>--%>
                                <%--<asp:ObjectDataSource ID="odsInk" runat="server" TypeName="Printcenter.UI.Inventories.InventoryBasePage"
                                    SelectMethod="warehouse_inventory_selectall_onclientid"></asp:ObjectDataSource>--%>
                                <%-- <div align="left" style="width: 99.5%">
                                    <UC:Paging ID="usrPagingInk" runat="server" />
                                </div>--%>
                            </div>
                        </div>
                        <%-- <asp:Panel ID="pnlEmptyRecordsInk" runat="server" Visible="false">
                            <div id="padding" class="emptyrecords" align="center">
                                <span class="HeaderText" style="text-align: center">No record(s) found</span>
                            </div>
                        </asp:Panel>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div align="left" id="div_Store" runat="server" style="width: 100%;">
                <div style="float: left; width: 100%">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="div_TotalRecStore" style="float: right; padding-right: 5px">
                                <span class="normalText">Total Records:</span><b>
                                    <asp:Label ID="lblTotalRecordsStore" runat="server"></asp:Label></b></div>
                            <div class="onlyEmpty">
                            </div>
                            <div id="div_MainStore" runat="server" align="left" style="width: 100%">
                                <div id="aStore">
                                </div>
                                <div id="div_GridStore">
                                    <asp:GridView ID="GridStoreSupply" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="100" Width="100%" GridLines="horizontal" SkinID="GridStyle"
                                        OnRowDataBound="GridStoreSupply_RowDatabound">
                                        <%--DataSourceID="SqlDataSource1"--%>
                                        <AlternatingRowStyle />
                                        <RowStyle CssClass="NewAlternative" />
                                        <HeaderStyle CssClass="bgcustomize navigatorpanel" Height="22px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%"
                                                ItemStyle-Width="20%" ItemStyle-Height="20px">
                                                <ItemTemplate>
                                                    <a id='<%#Eval("FinishedGoodsID") %>' style="cursor: pointer" href="#" onclick="ShowWarehouseQtyDiv('show');getvalues(this.id,'<%#Eval("ProductCode")%>','<%#Eval("ProductName")%>','<%#Eval("PackQuantity")%>','<%#Eval("PackCostPrice")%>','S','<%#Eval("PackCostPrice")%>','<%#Eval("PackQuantity")%>','','','<%#Eval("PackQuantity")%>')">
                                                        <%# DataBinder.Eval(Container.DataItem, "ProductCode")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%"
                                                ItemStyle-Width="20%">
                                                <ItemTemplate>
                                                    <%--<%=strSitepath %>warehouse/item_finishedgoods_add.aspx?page=store&type=edit&id=<%#DataBinder.Eval(Container.DataItem,"FinishedGoodsID") %>'>--%>
                                                    <a id='<%#Eval("FinishedGoodsID") %>' style="cursor: pointer" href="#" onclick="ShowWarehouseQtyDiv('show');getvalues(this.id,'<%#Eval("ProductCode")%>','<%#Eval("ProductName")%>','<%#Eval("PackQuantity")%>','<%#Eval("PackCostPrice")%>','S','<%#Eval("PackCostPrice")%>','<%#Eval("PackQuantity")%>','','','<%#Eval("PackQuantity")%>')">
                                                        <%# DataBinder.Eval(Container.DataItem, "ProductName")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="In Stock Quantity" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="20%" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInStockQty" runat="server" Text='<%#Eval("InStockQuantity")%>'></asp:Label>
                                                    <%--<%# DataBinder.Eval(Container.DataItem, "InStockQuantity")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pack Quantity" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStorePackQty" runat="server" Text='<%#Eval("PackQuantity")%>'></asp:Label>
                                                    <%--<%# DataBinder.Eval(Container.DataItem, "PackQuantity")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pack Cost Price ($)" HeaderStyle-HorizontalAlign="Right"
                                                HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStorePackCostPrice" runat="server" Text='<%#Eval("PackCostPrice")%>'></asp:Label>
                                                    <%--<%# DataBinder.Eval(Container.DataItem, "PackCostPrice")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div id="padding" class="emptyrecords" align="center">
                                                <span class="HeaderText" style="text-align: center">No record(s) found</span>
                                            </div>
                                        </EmptyDataTemplate>
                                        <PagerTemplate>
                                        </PagerTemplate>
                                    </asp:GridView>
                                    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CRMConnectionString %>"
                                        SelectCommand="PC_warehouse_storesupply_select" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                                Type="int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                    <div align="left" style="width: 99.5%">
                                        <UC:Paging ID="usrPagingstore" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlEmptyRecordsStore" runat="server" Visible="false">
                                <div id="padding" class="emptyrecords" align="center">
                                    <span class="HeaderText" style="text-align: center">No record(s) found</span>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div align="left" id="div_Customer" runat="server" style="width: 100%;">
                <div style="float: left; width: 100%">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="div_TotalRecCust" style="float: right; padding-right: 5px">
                                <span class="normalText">Total Records:</span><b>
                                    <asp:Label ID="lblTotalRecordsCustomerItem" runat="server"></asp:Label></b></div>
                            <div class="onlyEmpty">
                            </div>
                            <div id="div_MainCust" runat="server" align="left" style="width: 100%">
                                <div id="aCust">
                                </div>
                                <div id="div_GridCust">
                                    <asp:GridView ID="GridCustomerItem" runat="server" AllowSorting="true" AutoGenerateColumns="false"
                                        AllowPaging="true" PageSize="100" Width="100%" GridLines="horizontal" SkinID="GridStyle"
                                        OnRowDataBound="Gridcust_RowDatabound">
                                        <%--DataSourceID="SqlDataSource2"--%>
                                        <AlternatingRowStyle CssClass="NewTableRows" />
                                        <RowStyle CssClass="NewAlternative" />
                                        <HeaderStyle CssClass="bgcustomize navigatorpanel" Height="22px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Product Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-Height="20px"
                                                ItemStyle-Width="15%">
                                                <HeaderStyle Width="15%" />
                                                <ItemTemplate>
                                                    <%--href='<%=strSitepath %>warehouse/item_finishedgoods_add.aspx?page=item&type=edit&id=<%#DataBinder.Eval(Container.DataItem,"FinishedGoodsID") %>'--%>
                                                    <a id='<%#Eval("FinishedGoodsID") %>' style="cursor: pointer" href="#" onclick="ShowWarehouseQtyDiv('show');getvalues(this.id,'<%#Eval("ProductCode")%>','<%#Eval("ProductName")%>','<%#Eval("PackQuantity")%>','<%#Eval("PackCostPrice")%>','C','<%#Eval("PackCostPrice")%>','<%#Eval("PackQuantity")%>','','','<%#Eval("PackQuantity")%>')">
                                                        <%# DataBinder.Eval(Container.DataItem, "ProductCode")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="25%">
                                                <HeaderStyle Width="25%" />
                                                <ItemTemplate>
                                                    <%-- href='<%=strSitepath %>warehouse/item_finishedgoods_add.aspx?page=item&type=edit&id=<%#DataBinder.Eval(Container.DataItem,"FinishedGoodsID") %>'--%>
                                                    <a id='<%#Eval("FinishedGoodsID") %>' style="cursor: pointer" href="#" onclick="ShowWarehouseQtyDiv('show');getvalues(this.id,'<%#Eval("ProductCode")%>','<%#Eval("ProductName")%>','<%#Eval("PackQuantity")%>','<%#Eval("PackCostPrice")%>','C','<%#Eval("PackCostPrice")%>','<%#Eval("PackQuantity")%>','','','<%#Eval("PackQuantity")%>')">
                                                        <%# DataBinder.Eval(Container.DataItem, "ProductName")%>
                                                    </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock Qty" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustInStockQty" runat="server" Text='<%#Eval("InStockQuantity")%>'></asp:Label>
                                                    <%--<%# DataBinder.Eval(Container.DataItem, "InStockQuantity")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pack Qty" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
                                                <HeaderStyle Width="10%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustPaperQty" runat="server" Text='<%#Eval("PackQuantity")%>'></asp:Label>
                                                    <%--<%# DataBinder.Eval(Container.DataItem, "PackQuantity")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pack Cost Price ($)" HeaderStyle-HorizontalAlign="right"
                                                ItemStyle-Width="15%">
                                                <HeaderStyle Width="15%" />
                                                <ItemStyle HorizontalAlign="Right" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCustPackCostPrice" runat="server" Text='<%#Eval("PackCostPrice")%>'></asp:Label>
                                                    <%--<%# DataBinder.Eval(Container.DataItem, "PackCostPrice")%>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left"
                                                ItemStyle-Width="25%">
                                                <HeaderStyle Width="25%" />
                                                <ItemTemplate>
                                                    &nbsp;<%# DataBinder.Eval(Container.DataItem, "customername")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div id="padding" class="emptyrecords" align="center">
                                                <span class="HeaderText" style="text-align: center">No record(s) found</span>
                                            </div>
                                        </EmptyDataTemplate>
                                        <PagerTemplate>
                                        </PagerTemplate>
                                    </asp:GridView>
                                    <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CRMConnectionString %>"
                                        SelectCommand="PC_warehouse_customeritem_select" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:SessionParameter Name="companyID" DefaultValue="0" SessionField="companyId"
                                                Type="int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                    <div align="left" style="width: 99.5%">
                                        <UC:Paging ID="usrPagingCustItem" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlEmptyRecordsCust" runat="server" Visible="false">
                                <div id="Div1" class="emptyrecords" align="center">
                                    <span class="HeaderText" style="text-align: center">No record(s) found</span>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
        </div>
    </div>
</div>
<div id="div_Warehouse_Qty" style="display: none; position: absolute; z-index: 1000;
    width: 45%" align="center">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                    padding-left: 1px">
                    <b>Quantity</b>
                    <asp:Label ID="Label10" runat="server"></asp:Label></div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButton2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="ShowWarehouseQtyDiv('close');return false;" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>
            <td class="popup-middlebg" align="center">
                <div style="padding: 10px 5px 10px 0px; width: 98%">
                    <div class="" style="width: 100%">
                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                            <tr>
                                <td valign="top">
                                    <div align="left" style="width: 99%; padding-left: 3px">
                                        <div class="bglabel" style="width: auto">
                                            <asp:Label ID="Label135" runat="server" Text=""></asp:Label>
                                            <span style="color: Red; padding-left: 3px">*</span>
                                        </div>
                                        <div class="box">
                                            <div style="float: left">
                                                <asp:TextBox ID="txtWarehouseQty" SkinID="textPad" Width="80px" runat="server" MaxLength="8"
                                                    Style="direction: rtl" onblur="CallonBlur(this.value,'spn_txtWarehouseQty');CheckDecimalPlus(this.value,'spn_txtWarehouseQty_number','spn_txtWarehouseQty_number','yes')"></asp:TextBox><%-- IsIntegerParameter(this.value,'spn_txtWarehouseQty_number');--%>
                                            </div>
                                            <div style="float: left">
                                                <span id="spn_PaperTypeUnit" class="normalText" style="display: none; padding-left: 5px;
                                                    vertical-align: middle"></span>
                                            </div>
                                            <span id="spn_txtWarehouseQty" class="spanerrorMsg" style="display: none; width: auto;
                                                padding-left: 4px; padding-right: 4px">
                                                <%=objLangClass.GetLanguageConversion("Please_Enter_Stock_Qty")%></span><span id="spn_txtWarehouseQty_number"
                                                    class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px">
                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="float: left; margin-left: 160px;">
                                        <asp:Button ID="Button6" CssClass="button" Text="" Width="65px" runat="server" OnClientClick="javascript:AddThisWarehouseItem(); return false;" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td style="width: 10px; background-color: #ffffff">
                &nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">
                &nbsp;
            </td>
            <td class="popup-bottom-middlebg">
                &nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="div_test_1" style="overflow: scroll; border: solid 1px red; width: 100%;
    display: none;">
    <div id="div_test_2" style="border: solid 1px blue;">
        Loading...
    </div>
</div>
<div align="left" style="width: 800px">
</div>
<asp:HiddenField ID="hidGridCount" runat="server" Value="" />
<asp:HiddenField ID="hidInvBindType" runat="server" Value="cat" />
<script type="text/javascript">
    var spn_PaperTypeUnit = document.getElementById("spn_PaperTypeUnit");

    function CallScroll() {
        var type = '<%=type %>';
        var invtype = '<%=invtype %>';
        var GridID = "";
        var div_HeaderID = "";
        var div_BodyID = "";
        var OuterDivID = "";
        var InnerDivID = "";
        var DivTotalRecID = "";

        if (type == "inventory") {
            if (invtype == "inks" || invtype == "plates") {
                GridID = document.getElementById("<%=GridInk.ClientID%>");
                div_HeaderID = document.getElementById("aInk");
                div_BodyID = document.getElementById("div_GridInk");
                OuterDivID = document.getElementById("div_test_1");
                InnerDivID = document.getElementById("div_test_2");
                DivTotalRecID = document.getElementById("div_TotalRecInk");

            }
            else {
                GridID = document.getElementById("<%=GridInventory.ClientID%>");
                div_HeaderID = document.getElementById("a");
                div_BodyID = document.getElementById("div_Grid");
                OuterDivID = document.getElementById("div_test_1");
                InnerDivID = document.getElementById("div_test_2");
                DivTotalRecID = document.getElementById("div_TotalRec");
            }
        }
        else if (type == "store supply") {
            GridID = document.getElementById("<%=GridStoreSupply.ClientID%>");
            div_HeaderID = document.getElementById("aStore");
            div_BodyID = document.getElementById("div_GridStore");
            OuterDivID = document.getElementById("div_test_1");
            InnerDivID = document.getElementById("div_test_2");
            DivTotalRecID = document.getElementById("div_TotalRecStore");
        }
        else {
            GridID = document.getElementById("<%=GridCustomerItem.ClientID%>");
            div_HeaderID = document.getElementById("aCust");
            div_BodyID = document.getElementById("div_GridCust");
            OuterDivID = document.getElementById("div_test_1");
            InnerDivID = document.getElementById("div_test_2");
            DivTotalRecID = document.getElementById("div_TotalRecCust");
        }
    start(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);
}
if ('<%=totalrec %>' != 0) {
        window.onload = CallScroll
    }
    var clsTimeID = '';
    var TakeTimaeCount = 0;
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
</script>
<script type="text/javascript">
    var pw = window.parent;
    var ItemID = "";
    var ItemCode = "";
    var ItemName = "";
    var Qty = "";
    var PackedIn = "";
    var Price = "";
    var ItemType = "";
    var PerPrice = "";
    var PerQty = "";
    var PaperType = "";
    var Description = "";
    var Stocktype = "";
    var CompanyID = '<%=CompanyID %>';
    var UserID = '<%=UserID %>';
    var chkDesIncl = '<%=chkDesIncl %>';

    function setinvid(id, value) {
        ShowWarehouseQtyDiv('show');
    }
    function getvalues(grdItemID, grdItemCode, grdItemName, grdPackedIn, grdPrice, grdItemType, grdPerPrice, grdPerQty, grdPaperType,grdDescription, grdStockType, grdtxtQty) {
        debugger
        ItemID = grdItemID;
        ItemCode = grdItemCode;
        ItemName = grdItemName;
        PackedIn = grdPackedIn;
        Price = grdPrice;
        ItemType = grdItemType;
        PerPrice = grdPerPrice;
        PerQty = grdPerQty;
        PaperType = grdPaperType;
        Description = grdDescription;
        Stocktype = grdStockType;
        grdtxtQty = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, grdtxtQty, 0, '', true, false, true);

        document.getElementById("<%= txtWarehouseQty.ClientID%>").value = grdtxtQty; //PackedIn;

        if (grdStockType.toLowerCase() == "paper") {
            if (grdPaperType == "web printing") {
                spn_PaperTypeUnit.style.display = "block";
                spn_PaperTypeUnit.innerHTML = "roll";
            }
            else if (grdPaperType == "sheet") {
                spn_PaperTypeUnit.style.display = "block";
                spn_PaperTypeUnit.innerHTML = "sheet";
            }
        }
        else {
            spn_PaperTypeUnit.style.display = "none";
        }
    }


</script>
<script type="text/javascript">
    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender;
        var items = menu.get_items();

        if (column.get_dataType() == "System.String") {
            var i = 0;

            while (i < items.get_count() - 1) {
                if (items.getItem(i).get_value() in { 'GreaterThan': '', 'GreaterThanOrEqualTo': '', 'LessThan': '', 'LessThanOrEqualTo': '' }) {
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
    }

    function filterMenuShowing(sender, eventArgs) {
        column = eventArgs.get_column();
    }
</script>
<script type="text/javascript">

    function ShowWarehouseQtyDiv(AddType) {

        if (AddType == "show") {
            document.getElementById("div_Warehouse_Qty").style.display = "block";
            showDivPopupCenter('div_Warehouse_Qty', '250');

            document.getElementById("<%= txtWarehouseQty.ClientID%>").focus;
        }
        else {
            document.getElementById("div_Warehouse_Qty").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }
    }
    function AddThisWarehouseItem() {
        debugger
        var txtWarehouseQtyID = document.getElementById("<%=txtWarehouseQty.ClientID %>");
        document.getElementById("spn_txtWarehouseQty").style.display = "none";
        document.getElementById("spn_txtWarehouseQty_number").style.display = "none";
        var txtWarehouseQty = trim12(txtWarehouseQtyID.value);
        if (txtWarehouseQty == '') {
            document.getElementById("spn_txtWarehouseQty").style.display = "block";
            document.getElementById("spn_txtWarehouseQty_number").style.display = "none";
            return false;
        }
        else if (CheckDecimalPlus(txtWarehouseQty, 'spn_txtWarehouseQty_number', 'spn_txtWarehouseQty_number', 'yes') == false) {
            document.getElementById("spn_txtWarehouseQty").style.display = "none";
            return false;
        }
        else {
            Qty = txtWarehouseQty;
            var vaQty = 0;
            var TempPerprice = 0;
            var FinalPrice = 0;

            if (Stocktype.toLowerCase() == "ink" || Stocktype.toLowerCase() == "inks") {
                //FinalPrice = (Qty * Price);
                FinalPrice = (Qty * RemoveDollorAndComma(PerPrice));
            }
            else {

                if (PerQty > 0) {
                    vaQty = Qty / PerQty;
                    TempPerprice = RemoveDollorAndComma(PerPrice) * vaQty;
                    FinalPrice = TempPerprice.toFixed(2);
                }
            }
            if (ItemType = "I") {
                if (chkDesIncl == "r") {
                    ItemName = 'Item Title:' + ItemName;
                }
                else if (chkDesIncl == "a") {
                    ItemName = 'Item Title:' + ItemName + '\n' + Description;
                }
                else {
                    ItemName = 'Item Title:' + ItemName + '\n' + Description;
                }
            }
            pw.BindItemValues(ItemID, ItemCode, ItemName, Qty, PackedIn, FinalPrice, ItemType, PerQty, PerPrice, Price, Stocktype);
            //ShowWarehouseQtyDiv('hide');
            txtWarehouseQty.value = "";
            //pw.AddMoreItem();  
            window.close();
        }
    }
</script>
<%--<script type="text/javascript">
    var GridItemTitle = document.getElementById("<%=GridInventory.ClientID %>");
    function CallOverflow() {

        SetGridOverflow(GridItemTitle);
    }
    CallOverflow();

</script>--%>