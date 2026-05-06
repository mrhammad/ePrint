<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Inventory_popup.ascx.cs" Inherits="ePrint.usercontrol.warehouse.Inventory_popup" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register Src="~/usercontrol/warehouse/inventory_add.ascx" TagName="InventoryAdd"
    TagPrefix="UC" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridInventory">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnShowAll_new">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSelect">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnShowAll">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridInventory" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
</telerik:RadAjaxLoadingPanel>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<div id="div_Content" align="left" style="width: 100%">
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div >  <%--class="borderWithoutTop"--%>
        <div align="left" style="width: 100%;">
            <div align="left">
                <asp:UpdatePanel ID="UpdatePanel2" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <table align="center" width="100%">
                            <tr>
                                <td align="left">
                                    <asp:PlaceHolder ID="plhErrorMessage" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div >  <%--id="padding"--%>
            <div align="left" id="div_InvItems" runat="server" style="width: 100%;">
                <%-- <asp:UpdateProgress ID="UpPro" runat="server">
                    <ProgressTemplate>
                        <div id="divLoading_paperSelector" align="left" style="position: absolute; height: 50px;
                            width: 200px; top: 45%; left: 40%;">
                            <UC:Loading ID="ucLoading1" runat="server" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
                <div style="float: left; width: 100%">
                    <div style="float: left; padding-left: 10px;">
                        <asp:Button ID="btnSelect" runat="server" CssClass="button" Text="Select" OnClientClick="javascript:CallSelect();" /></div>
                    <div style="float: left; padding-left: 10px">
                        <%--   <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>--%>
                        <asp:Button ID="btnShowAll" runat="server" CssClass="button" Text="Show All Inventory"
                            OnClick="btnShowAll_OnClick" />
                        <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
                <div style="float: right; margin-top:-15px; padding-bottom:4px;">
                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                        cursor: pointer" runat="server" Text="Clear All Filters" />
                </div>
                <div class="only5px">
                </div>
                <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>--%>
                <style type="text/css">
                    /*                   
                    .RadGrid_Eprint_Skin .rgHeaderDiv
                    {
                        background: none repeat scroll 0 0 transparent;
                        padding-right: 0;
                    }*/
                </style>
                <telerik:RadGrid ID="GridInventory" AllowSorting="True" ShowStatusBar="True" runat="server"
                    AutoGenerateColumns="False" AllowPaging="True" AllowMultiRowSelection="True"
                    Width="100%" PageSize="50" AllowAutomaticInserts="True" CssClass="RadGrid_Eprint_Skin"
                    GridLines="None" PagerStyle-CssClass="RadComboBox_Eprint_Skin" OnItemDataBound="OnRowDataBound_GridInvItem"
                    PagerStyle-AlwaysVisible="false" OnNeedDataSource="GridInvItem_NeedDataSource"
                    OnItemCommand="GridInvItem_ItemCommand" GroupingEnabled="False" OnSortCommand="GridInvItem_SortCommand"
                    PagerStyle-Visible="true" AllowFilteringByColumn="True">
                    <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                    <HeaderStyle Width="120px" />
                    <MasterTableView TableLayout="Fixed">
                        <Columns>
                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-Wrap="false">
                                <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="false" />
                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                <HeaderTemplate>
                                    <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                        value='<%# DataBinder.Eval(Container, "DataItem.InventoryID", "{0}") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="InventoryCode" SortExpression="InventoryCode"
                                HeaderText="Inventory Code" DataField="InventoryCode" AllowFiltering="true" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" FilterControlWidth="55">
                                <HeaderStyle Width="15%" HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle Width="15%" HorizontalAlign="Left" Height="5%" />
                                <ItemTemplate>
                                    <div style="overflow: hidden; height: 15px;">
                                        <asp:Label ID="lblInventoryCode" runat="server" Text='<%#Eval("InventoryCode")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="InventoryName" DataField="InventoryName"
                                HeaderText="Inventory Name" ItemStyle-Wrap="false" UniqueName="InventoryName"
                                AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                FilterControlWidth="65">
                                <HeaderStyle Width="15%" HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle Width="15%" HorizontalAlign="Left" Height="5%" />
                                <ItemTemplate>
                                    <div style="overflow: hidden; width: 100px; height: 15px;">
                                        <asp:Label ID="lblInvName" runat="server" Text='<%#Eval("InventoryName")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="BasisWeight" SortExpression="BasisWeight"
                                HeaderText="Weight '<%=WeightMeasure %>'" DataField="BasisWeight" AllowFiltering="true"
                                CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" FilterControlWidth="35">
                                <HeaderStyle Width="10%" HorizontalAlign="right"></HeaderStyle>
                                <ItemStyle Width="10%" HorizontalAlign="right" />
                                <ItemTemplate>
                                    <div style="overflow: hidden; height: 15px; text-align:right;">
                                        <asp:Label ID="lblBasisWeight" runat="server" Text='<%#Eval("BasisWeight")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="PackedIn" SortExpression="PackedIn" HeaderText="Pack Qty"
                                DataField="PackedIn" AllowFiltering="true" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                                FilterControlWidth="45">
                                <HeaderStyle Width="13%" HorizontalAlign="right"></HeaderStyle>
                                <ItemStyle Width="13%" HorizontalAlign="right" />
                                <ItemTemplate>
                                    <div style="overflow: hidden; height: 15px; text-align:right; width:90%;">
                                        <asp:Label ID="lblPackedIn" runat="server" Text='<%#Eval("PackedIn")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="PackedPrice" SortExpression="PackedPrice"
                                HeaderText="Pack Price($)" DataField="PackedPrice" AllowFiltering="true" CurrentFilterFunction="EqualTo"
                                AutoPostBackOnFilter="true" FilterControlWidth="45">
                                <HeaderStyle Width="14%" HorizontalAlign="right"></HeaderStyle>
                                <ItemStyle Width="14%" HorizontalAlign="right" />
                                <ItemTemplate>
                                    <div style="overflow: hidden; height: 15px; text-align:right; width:80%;">
                                        <asp:Label ID="lblPackedPrice" runat="server" Text='<%#Eval("PackedPrice")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="Cost" DataField="Cost" HeaderText="Cost Price"
                                ItemStyle-Wrap="false" UniqueName="Cost" ItemStyle-HorizontalAlign="left" ItemStyle-Width="10%"
                                AllowFiltering="true" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                                FilterControlWidth="78">
                                <HeaderStyle HorizontalAlign="left" Width="15%" Wrap="false" />
                                <ItemStyle Width="15%" HorizontalAlign="left" />
                                <ItemTemplate>
                                    <div style="overflow: hidden; width: 100px; height: 15px">
                                        <asp:Label ID="lblInvCost" runat="server" Text='<%#Eval("Cost")%>'></asp:Label>
                                        <asp:Label ID="lblMsgPer" runat="server" Text=" &nbsp;Per&nbsp;"></asp:Label>
                                        <asp:Label ID="lblInvPer" runat="server" Text='<%#Eval("PerQuantity")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="UnitPrice" SortExpression="UnitPrice" HeaderText="Unit Price($)"
                                DataField="UnitPrice" AllowFiltering="true" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                                FilterControlWidth="45">
                                <HeaderStyle Width="13%" HorizontalAlign="right"></HeaderStyle>
                                <ItemStyle Width="13%" HorizontalAlign="right" />
                                <ItemTemplate>
                                    <div style="overflow: hidden; height: 15px; text-align:right; width:90%;">
                                        <asp:Label ID="lblUnitPrice" runat="server" Text='<%#Eval("UnitPrice")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="SupplierName" UniqueName="SupplierName"
                                DataField="SupplierName" HeaderText="Supplier" ItemStyle-Wrap="false" ItemStyle-Width="15%"
                                AllowFiltering="true" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                FilterControlWidth="75">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" Wrap="false" />
                                <ItemStyle Wrap="False" Width="15%"></ItemStyle>
                                <ItemTemplate>
                                    <div style="overflow: hidden; width: 105px; height: 15px">
                                        <asp:Label ID="lblSupplier" runat="server" Text='<%#Eval("SupplierName")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description" SortExpression="Description"
                                AllowFiltering="true" AutoPostBackOnFilter="true" UniqueName="Description" DataField="Description"
                                ItemStyle-Wrap="true" ItemStyle-Width="15%" CurrentFilterFunction="Contains"
                                ItemStyle-Height="20px" FilterControlWidth="75">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" Wrap="false" />
                                <ItemTemplate>
                                    <div style="white-space: nowrap; display: block; overflow: hidden; width: 100px;">
                                        <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <ItemStyle Wrap="True" Height="20px" Width="15%"></ItemStyle>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings>
                        <Scrolling AllowScroll="false" SaveScrollPosition="false" EnableVirtualScrollPaging="false"
                            UseStaticHeaders="true"></Scrolling>
                    </ClientSettings>
                </telerik:RadGrid>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div class="only5px">
                </div>
             <!--   <div style="float: left; width: 100%">
                    <div style="float: left; padding-left: 10px;">
                        <asp:Button ID="btnSelect_new" runat="server" CssClass="button" Text="Select" OnClientClick="javascript:CallSelect();" /></div>
                    <div style="float: left; padding-left: 10px;">
                        <%--    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>--%>
                        <asp:Button ID="btnShowAll_new" runat="server" CssClass="button" Text="Show All Inventory"
                            OnClick="btnShowAll_OnClick" />
                        <%--   </ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div> -->
                <div class="only5px">
                </div>
            </div>
            <asp:LinkButton ID="lnkselect" runat="server" OnClick="btnSelect_OnClick"></asp:LinkButton>
        </div>
    </div>
</div>
<asp:HiddenField ID="hidGridCount" runat="server" Value="" />
<asp:HiddenField ID="hid_IventoryIDs" runat="server" Value="" />
<asp:HiddenField ID="hid_InvDetails" runat="server" Value="" />
<script>
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
    var hid_IventoryIDs = document.getElementById("<%=hid_IventoryIDs.ClientID %>");
    var hid_InvDetails = document.getElementById("<%=hid_InvDetails.ClientID %>");

    function CheckAll(checkAllBox) {
        var frm = document.forms[0];
        var ChkState = checkAllBox.checked;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) e.checked = ChkState;
            if (e.type == 'checkbox' && e.name.indexOf('All') != -1) e.checked = ChkState;
        }
    }
    function CheckChanged() {
        var frm = document.forms[0];
        var boolAllChecked; boolAllChecked = true;
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                if (e.checked == false) {
                    boolAllChecked = false; break;
                }
        }
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
                if (boolAllChecked == false) e.checked = false; else e.checked = true; break;
            }
        }
    }
    var TakeTimaeCount = 0;
    function CallSelect() {
        var ret = CheckOne();
        if (ret) {
            CheckGrid();
            var IDs = '';
            var frm = document.getElementById("<%=GridInventory.ClientID %>").getElementsByTagName("input");
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id') != -1) {
                    if (frm[l].checked) {
                        IDs = IDs + frm[l].value + ",";
                    }
                }
            }
            document.getElementById("<%=hid_IventoryIDs.ClientID %>").value = IDs;

            __doPostBack('ctl00$ContentPlaceHolder1$ctl00$lnkselect', '');
            return true;
        }
        else {
            return false;
        }


    }

    function CheckOne() {
        var Counter = 0;
        var frm = document.forms[0];
        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                if (e.checked)
                    Counter = Number(Counter) + 1;
            }
        }
        if (Number(Counter) == 0) {
            alert("Please check at least one row to Select");
            return false;
        }
        else {
            return true;
        }
    }

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow) oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
        else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow; //IE (and Moz az well)
        return oWindow;
    }


    function CloseOnReload() {
        GetRadWindow().Close();
    }

</script>
<script>
    document.getElementById("ds00").style.width = document.getElementById("outerTable").offsetWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";        
</script>
<script type="text/javascript">
    var div_Load = document.getElementById("div_Load");
    setLoadingPositionOfDivMove(div_Load);
    document.getElementById("div_Load").style.display = "block";
</script>
<script>
    var pw;

    pw = window.parent;
    function setpaperid(id, value, papertype) {

        pw.SendPaperIDandName(id, value, papertype);
    }
    function TimerToClose() {
        window.close();

    }

    function setplatesid(id, value) {
        pw.SendPlatesIDandName(id, value);
    }    
</script>
<script type="text/javascript">
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";
</script>
<asp:Panel ID="popUpClose" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        function InvDetails() {
            var hid_InvDetails = document.getElementById("<%=hid_InvDetails.ClientID %>");
            window.parent.InvUpdateForChoice(hid_InvDetails.value);
            CloseOnReload();
        }
        InvDetails();
    </script>
</asp:Panel>