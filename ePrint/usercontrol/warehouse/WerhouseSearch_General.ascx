<%@ control language="C#" autoeventwireup="true" CodeBehind="WerhouseSearch_General.ascx.cs" Inherits="ePrint.usercontrol.warehouse.WerhouseSearch_General" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="<%=strSitepath %>js/Item/warehouse_view.js?VN='<%#VersionNumber%>'"></script>
<telerik:RadAjaxManagerProxy ID="RADMgrWareHouse" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridViewInv">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewInv" LoadingPanelID="RadAjaxLoadingPanelWarehouse" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewInv" LoadingPanelID="RadAjaxLoadingPanelWarehouse" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewInv" LoadingPanelID="RadAjaxLoadingPanelWarehouse" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelWarehouse" SkinID="Windows7"
    runat="server" />
<div id="ds00" style="display: none;">
</div>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<%--while loading page should mask done by smitha--%>
<script>
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    //document.getElementById("ds00").style.display = "block";
</script>
<div align="left" style="width: 100%">
    <div id="div_warehouse_border">
        <div align="left" style="width: 100%; margin-left: 0px; margin-top: -1px;">
            <div id="divpadding" style="width: 100%">
                <div align="left" id="divinventory" style="width: 100%; vertical-align: top" class="onlyEmpty">
                    <%--Clear All Div--%>
                    <div>
                        <div style="float: left; padding-left: 5px">
                            <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer;
                                display: none" runat="server" Text="Clear all Filters" />
                        </div>
                        <div style="border: 0px solid red; float: right">
                            <div style="float: left; display: none">
                                <span class="HeaderText" style="color: #787878">Current View:</span>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div id="div_lblView" style="float: left; display: none">
                                <asp:Label ID="lblView" runat="server"></asp:Label>
                            </div>
                            <%--<div id="div_ddlView" style="float: left; display: none">
                                <asp:DropDownList ID="ddl_View" SkinID="onlyDDL" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div style="float: left; display: none">
                                <a id="spn_change" style="text-decoration: underline; cursor: pointer; display: none">
                                    Change</a>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <%--<div style="float: left;display:none">
                                <span class="normalText" style="color: #787878">Or try</span> <a href="../warehouse/warehouse_inventory_search.aspx"
                                    id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                                    <%=objLanguage.convert("Advanced Search")%></a>
                            </div>--%>
                        </div>
                    </div>
                    <%--Grid--%>
                    <div id="div_MainInv" runat="server" style="width: 100.5%; padding-top: 5px; margin-left: -5px;">
                        <asp:HiddenField ID="hidGridRecord" runat="server" Value="" />
                        <div id="div_Grid">
                            <telerik:RadGrid ID="GridViewInv" AllowSorting="true" ShowGroupPanel="true" AllowFilteringByColumn="false"
                                ShowStatusBar="true" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                OnNeedDataSource="GridViewInv_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewInv_SortCommand"
                                OnItemCommand="GridViewInv_ItemCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true"
                                EnableEmbeddedSkins="false" CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                OnItemDataBound="OnRowDataBound_GridViewInv" OnItemCreated="GridViewInv_ItemCreated">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                <ClientSettings AllowExpandCollapse="false">
                                    <Selecting />
                                    <%--<ClientEvents OnFilterMenuShowing="filterMenuShowing" />--%>
                                </ClientSettings>
                                <MasterTableView OverrideDataSourceControlSorting="true">
                                    <Columns>
                                        <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" AllowFiltering="false"
                                            ItemStyle-Wrap="false">
                                            <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                            <HeaderTemplate>
                                                <%-- <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%-- <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                    value='<%# DataBinder.Eval(Container, "DataItem.InventoryID", "{0}") %>' />--%>
                                                <asp:HiddenField ID="hid_InventoryID" runat="server" Value='<%#Eval("InventoryID") %>' />
                                                <asp:HiddenField ID="hid_WeightSize" runat="server" Value='<%#Eval("BasisWeight")%>' />
                                                <asp:HiddenField ID="hid_Gsm" runat="server" Value='gsm' />
                                                <asp:HiddenField ID="hid_PaperName" runat="server" Value='<%#Eval("PaperName")%>' />
                                                <asp:HiddenField ID="hid_Height" runat="server" Value='<%#Eval("height") %>' />
                                                <asp:HiddenField ID="hid_Width" runat="server" Value='<%#Eval("Width") %>' />
                                                <asp:HiddenField ID="hid_Length" runat="server" Value='<%#Eval("Length") %>' />
                                                <asp:HiddenField ID="hid_WidthType" runat="server" Value='<%#Eval("WidthType") %>' />
                                                <asp:HiddenField ID="hid_LengthType" runat="server" Value='<%#Eval("LengthType") %>' />
                                                <asp:HiddenField ID="hid_PaperType" runat="server" Value='<%#Eval("PaperType") %>' />
                                                <asp:HiddenField ID="hid_PackedIn" runat="server" Value='<%#Eval("PackedIn") %>' />
                                                <asp:HiddenField ID="hid_StockType" runat="server" Value='<%#Eval("StockType")%>' />
                                                <asp:HiddenField ID="hid_PackedInType" runat="server" Value='<%#Eval("PackedInType")%>' />
                                                <asp:HiddenField ID="hid_ChargableSheets" runat="server" Value='<%#Eval("ChargableSheets") %>' />
                                                <asp:HiddenField ID="hid_InkType" runat="server" Value='<%#Eval("InkType") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                </ClientSettings>
                                <%--<FilterMenu OnClientShown="MenuShowing" />--%>
                                <HeaderStyle Width="200px" />
                                <ItemStyle Width="200px" />
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnTabType" runat="server" Value="inventory" />
                <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                <asp:HiddenField ID="hdnInvDelIds" runat="server" Value="0" />
                <asp:HiddenField ID="hdnInvStoreDelIds" runat="server" Value="0" />
                <asp:HiddenField ID="hdnInvCustDelIds" runat="server" Value="0" />
                <asp:HiddenField ID="hid_custID" runat="server" Value="0" />
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    var column = null;
    function OnRowClick(EditPage) {
        window.location = EditPage;
    }
    //    function MenuShowing(sender, args) {
    //        if (column == null) return;
    //        var menu = sender;
    //        var items = menu.get_items();
    //        if (column.get_dataType() == "System.String") {
    //            var i = 0;
    //            while (i < items.get_count() - 1) {
    //                if (items.getItem(i).get_value() in { 'GreaterThan': '', 'GreaterThanOrEqualTo': '', 'LessThan': '', 'LessThanOrEqualTo': '', 'NotEqualTo': '' }) {
    //                    var item = items.getItem(i);
    //                    if (item != null) item.set_visible(false);
    //                }
    //                else {
    //                    var item = items.getItem(i); if (item != null) item.set_visible(true);
    //                }
    //                i++;
    //            }
    //        } column = null;
    //    }
    //    function filterMenuShowing(sender, eventArgs) {
    //        column = eventArgs.get_column();
    //    } </script>
<%--<script type="text/javascript" language="javascript">
    var GridViewInv = document.getElementById("<%=GridViewInv.ClientID%>");
    var module = '<%=InvenotoryInk %>'; var Ware_itemtype = '<%=type %>';
    if ('<%=totalrec %>' != 0) {
        if (module == "warehouse") {
            //window.onload = CallScroll } else { //CallScroll();
        }
    } //** Func to make grid scroll when In the Update Panel **//
    var clsTimeID = '';
    var TakeTimaeCount = 0;
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID%>");
    var hdnInvDelIds = document.getElementById("<%=hdnInvDelIds.ClientID %>");
    var ctl00_tint_hdnIDs = document.getElementById("ctl00_tint_hdnIDs");
    var hdnInvStoreDelIds = document.getElementById("<%=hdnInvStoreDelIds.ClientID %>");
    var ctl00_tint_hdnIDs = document.getElementById("ctl00_tint_hdnIDs");
    var hdnInvCustDelIds = document.getElementById("<%=hdnInvCustDelIds.ClientID%>");
    var ctl00_tint_hdnIDs = document.getElementById("ctl00_tint_hdnIDs");
    //This Function is used in the ItemAdd.ascx page
    var InventoryFlag = false;
    var StoreFlag = false;
    var CustomerFlag = false;
    ////function changeCssWare(iss) 
    function openwindow(type) {
        window.open("item_finishedgoods_add.aspx?page=" + type + "", "", "width=900,height=400,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }
    function openwindow1() {
        window.open("inventory_add.aspx?type=add", "", "width=850,height=600,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }
    //Default Call var InvenotoryInk = "<%=InvenotoryInk %>"; 
    /////function checkInk()
    checkInk();
    ////showmessage();hidemessage();showpo(tblid,index) var WareID, WareName,WareType, UnitPrice, PackedInQty; 
    var IamFrom = "<%=IamFrom %>";
    function GetCustID(custid) {
        var hid_custID = document.getElementById("<%=hid_custID.ClientID %>");
        if (InvenotoryInk == "estimate") {
            hid_custID.value = custid;
        }
    }
    var div_lblView = document.getElementById("div_lblView");
    var div_ddlView = document.getElementById("div_ddlView");
    var div_lblViewStore = document.getElementById("div_lblViewStore");
    var div_ddlviewstore = document.getElementById("div_ddlviewstore");
    var div_lblviewCust = document.getElementById("div_lblviewCust");
    var div_ddlviewCust = document.getElementById("div_ddlviewCust");

    var checktrue = false;

    document.getElementById("ds00").style.display = "none";
</script>--%>
