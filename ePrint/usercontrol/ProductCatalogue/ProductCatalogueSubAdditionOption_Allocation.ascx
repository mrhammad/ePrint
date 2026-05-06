<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCatalogueSubAdditionOption_Allocation.ascx.cs" Inherits="ePrint.usercontrol.ProductCatalogue.ProductCatalogueSubAdditionOption_Allocation" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--Specific--%>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridAvailableSubAdditionalOptions">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="GridAllocatedSubAdditionalOptions">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAllocatedSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="BtnMoveExclude">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAllocatedSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnReMoveExclude">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAllocatedSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAllocatedSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnReMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAllocatedSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAllocatedSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnReMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAllocatedSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableSubAdditionalOptions" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadScriptBlock runat="server" ID="scriptBlock">
    <script type="text/javascript">

        function onRowDropping(sender, args) {
            if (sender.get_id() == "<%=GridAvailableSubAdditionalOptions.ClientID %>") {

                var node = args.get_destinationHtmlElement();
                if (!isChildOf('<%=GridAllocatedSubAdditionalOptions.ClientID %>', node) && !isChildOf('<%=GridAvailableSubAdditionalOptions.ClientID %>', node)) {
                    args.set_cancel(true);
                }
            }

        }

        function isChildOf(parentId, element) {
            while (element) {
                if (element.id && element.id.indexOf(parentId) > -1) {
                    return true;
                }
                element = element.parentNode;
            }
            return false;
        }

    </script>
</telerik:RadScriptBlock>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
<asp:Panel ID="pnlstyle" runat="server" Visible="false">
    <style type="text/css">
        .rgExpandCol
        {
            visibility: hidden !important;
        }
    </style>
</asp:Panel>
<div id="div_Specific" style="display: block;">
    <table id="Table1" runat="server" width="100%">
        <tr>
            <td width="47%">
                <div id="div_AvailableCustomers" style="float: left; width: 100%">
                    <strong><span id="Spn_header" runat="server" style="float: left; padding-left: 0%;">
                    </span></strong>
                    <div class="only5px">
                    </div>
                    <telerik:RadGrid runat="server" ID="GridAvailableSubAdditionalOptions" OnNeedDataSource="GridAvailableSubAdditionalOptions_NeedDataSource"
                        AllowPaging="True" Width="99%" AllowMultiRowSelection="true" CssClass="RadGrid_Eprint_Skin"
                        GroupingEnabled="false" PageSize="200" ShowGroupPanel="false" AutoGenerateColumns="false"
                        AllowFilteringByColumn="true" Height="485px">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                        <HeaderStyle Width="10px" />
                        <MasterTableView DataKeyNames="webothercostid" Width="104%">
                            <Columns>
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="checkAll_1" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" runat="server" id="Id_1" onclick="CheckChanged('move');" name="Id"
                                            value='<%# DataBinder.Eval(Container, "DataItem.webothercostid", "{0}") %>' />
                                        <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.webothercostid", "{0}") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridDragDropColumn HeaderStyle-Width="5%" Visible="false" />
                                <telerik:GridBoundColumn Visible="false" HeaderText="webothercostid" DataField="webothercostid">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn SortExpression="webothercostName" HeaderText="webother costName"
                                    CurrentFilterFunction="Contains" HeaderStyle-Width="28%" DataField="webothercostName"
                                    ItemStyle-Width="28%" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                    AutoPostBackOnFilter="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderTemplate>
                                        <div style="float: left; width: 40%;">
                                            <asp:Label ID="lblCustomerName" runat="server"><%=objLanguage.GetLanguageConversion("Sub_Additional_Options")%></asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; width: 40%;">
                                            <a title='<%#Eval("webothercostName")%>'>
                                                <asp:Label ID="lblCustomerName" CssClass="normalText" runat="server" Text='<%#Eval("webothercostName")%>'></asp:Label></a>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true">
                            <Scrolling UseStaticHeaders="true" ScrollHeight="180" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
            </td>
            <td style="padding: 0px 15px 0px 15px;">
                <asp:Button ID="btnMove" runat="server" Text=">>" ToolTip="Move" CssClass="button"
                    OnClientClick="javascript:return CallSelect('move');" OnClick="BtnMove_Onclick"
                    Visible="false" />
                <div class="only10px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <asp:Button ID="btnReMove" runat="server" Text="<<" ToolTip="Remove" CssClass="button"
                    OnClientClick="javascript:return CallSelect('remove');" OnClick="BtnReMove_Onclick"
                    Visible="false" />
            </td>
            <td>
                <div id="div_AllocatedGrid" style="width: 100%; display: block;">
                    <strong><span id="grd_header" runat="server" style="float: left; padding-left: 0%;">
                    </span></strong>&nbsp;
                    <div class="only5px">
                    </div>
                    <telerik:RadGrid runat="server" Width="98%" ID="GridAllocatedSubAdditionalOptions"
                        GroupingEnabled="false" OnNeedDataSource="GridAllocatedSubAdditionalOptions_NeedDataSource"
                        ShowGroupPanel="false" AutoGenerateColumns="false" AllowFilteringByColumn="true"
                        OnRowDrop="GridAllocatedSubAdditionalOptions_RowDrop" AllowMultiRowSelection="true"
                        PageSize="200" Height="485px" CssClass="RadGrid_Eprint_Skin">
                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                        <HeaderStyle Width="10px" />
                        <MasterTableView DataKeyNames="webothercostid">
                            <Columns>
                                <telerik:GridDragDropColumn Visible="false" />
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="checkAll_2" onclick="CheckAll_New(this);" runat="server"
                                            name="checkAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; margin-left: 6px;">
                                            <input type="checkbox" runat="server" id="Id_2" onclick="CheckChanged('remove');"
                                                checked="checked" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.webothercostid", "{0}") %>' />
                                            <asp:Label ID="lblSelectedCouponCodeID" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.webothercostid", "{0}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="webothercostName" HeaderText="Sub Additional Options"
                                    AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" HeaderStyle-Width="20%"
                                    DataField="webothercostName" AllowFiltering="true" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderTemplate>
                                        <div style="float: left; width: 99%;">
                                            <asp:Label ID="lblShippedCategory" runat="server"><%=objLanguage.GetLanguageConversion("Sub_Additional_Options")%></asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; width: 99%;">
                                            <a title='<%#Eval("webothercostName")%>'>
                                                <asp:Label ID="lblShippedOtherCostCategoryName1" CssClass="normalText" runat="server"
                                                    Text='<%#Eval("webothercostName")%>'></asp:Label></a>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                <div style="height: 30px; cursor: pointer;">
                                    <%=objLanguage.GetLanguageConversion("No_records_to_display")%>
                                </div>
                            </NoRecordsTemplate>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="true" Scrolling-AllowScroll="true">
                            <Scrolling UseStaticHeaders="true" ScrollHeight="180" />
                        </ClientSettings>
                    </telerik:RadGrid>
                    <%--- product grid selected customer ---%>
                </div>
                <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="div_Copy" runat="server" style="float: left; width: 120%; margin-top: 2px;
                    display: none;">
                    <div id="div10" style="float: left; width: 4%;">
                        <asp:CheckBox ID="chk_Copy" runat="server" />
                    </div>
                    <div id="div9" style="float: left; width: 90%; margin: 3px 0px 0px 0px;">
                        <asp:Label ID="lbl_Copy" runat="server" Text='Copy all products of the select category to the above selected Customers <br /> and Public accounts'></asp:Label>
                    </div>
                </div>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <div style="display: inline">
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClientClick="javascript:getFinalVaules_SubAdditionOptions();"
                        OnClick="btnSave_OnClick" />
                </div>
                <div style="display: inline; width: 20%">
                    <asp:Button ID="btnselectallocate" CssClass="button" runat="server" Style="margin-left: 3px"
                        Text="Save and Allocate" OnClientClick="javascript:getFinalVaules_SubAdditionOptions();loadingimage(this.id,'div_btnselectallocateprocess');"
                        OnClick="btnselectallocate_OnClick" />
                    <div id="div_btnselectallocateprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hid_MoveCustomers" runat="server" Value="" />
    <asp:HiddenField ID="hid_RemoveCustomers" runat="server" Value="" />
    <asp:HiddenField ID="hdn_CustomerList" runat="server" Value="" />
    <asp:HiddenField ID="hdn_movecookievalue" runat="server" Value="" />
    <asp:HiddenField ID="hdn_removecookievalue" runat="server" Value="" />
    <asp:HiddenField ID="hdn_finalvalues" runat="server" Value="" />
    <asp:HiddenField ID="hdn_gridbuffer" runat="server" Value="" />
    <asp:HiddenField ID="hdn_iscopychecked" runat="server" Value="false" />
    <asp:HiddenField ID="hdn_deptallocationtype" runat="server" Value=""></asp:HiddenField>
    <asp:HiddenField ID="hdn_WebOtherCostIDs" runat="server" Value="" />
</div>
<asp:Panel ID="popUpClose" runat="server" Visible="false">
    <script type="text/javascript">
        function TakeOut() {
            var hdn_CustomerList = document.getElementById("<%=hdn_CustomerList.ClientID %>");
            var hdn_Customers = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdn_Customers");
            hdn_Customers.value = hdn_CustomerList.value;
            window.close();
        }
        setTimeout("TakeOut()", 2000);



    </script>
</asp:Panel>
<script>
    var pw = window.parent;
    function AllocateCategory() {
        debugger;
        var hdn_WebOtherCostIDs = document.getElementById("<%=hdn_WebOtherCostIDs.ClientID %>");
        var hdn_CustomerList = document.getElementById("<%=hdn_CustomerList.ClientID %>");
        var hdn_Customers = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdn_Customers");
        hdn_Customers.value = hdn_CustomerList.value;
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_fromflag").value = 'allocate';
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_validateflag").value = ("<%=Action %>");
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_WebOtherCostIDs").value = document.getElementById("<%=hdn_WebOtherCostIDs.ClientID %>").value;
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_iscopychecked").value = document.getElementById("<%=hdn_iscopychecked.ClientID %>").value;
        pw.document.getElementById("ctl00_ContentPlaceHolder1_btnSave").click();
        GetRadWindow().close();
        //        }
    }

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
</script>
<script type="text/javascript">
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");

    function CallSelect(value) {
        debugger;
        var hid_MoveCustomers = document.getElementById("<%=hid_MoveCustomers.ClientID %>");
        var hid_RemoveCustomers = document.getElementById("<%=hid_RemoveCustomers.ClientID %>");
        var ret = CheckOne(value);
        if (ret) {

            //CheckGrid();
            var custid = '';
            var DeptIDs = '';
            var IDs_DeptIDs = '';
            var IDs = '';
            var frm = '';
            var count = 0;

            if (value == 'move') {
                frm = document.getElementById("<%=GridAvailableSubAdditionalOptions.ClientID %>").getElementsByTagName("input");
            }
            else if (value == 'remove') {
                frm = document.getElementById("<%=GridAllocatedSubAdditionalOptions.ClientID %>").getElementsByTagName("input");
            }
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('Id') != -1) {
                    if (frm[l].type == "checkbox") {
                        if (frm[l].checked && ((frm[l].id).indexOf("Id_1") > -1 || (frm[l].id).indexOf("Id_2") > -1)) {
                            var rowinputs = frm;
                            custid = frm[l].value;
                            IDs = IDs + frm[l].value + ",";
                        }
                    }
                }

            }
            //storeselectedvalues();



            if (value == 'move') {
                hid_MoveCustomers.value = IDs;
                document.cookie = "MoveCustomers=" + IDs;
                __doPostBack('AllocationID$btnMove', '');
                return ret;
                //added by rakshith
                // document.getElementById("<%=hdn_movecookievalue.ClientID %>").value = document.getElementById("<%=hdn_movecookievalue.ClientID %>").value + IDs_DeptIDs;
            }
            else {
                hid_RemoveCustomers.value = IDs;
                document.cookie = "RemoveCustomers=" + IDs;
                // document.getElementById("<%=hdn_removecookievalue.ClientID %>").value = document.getElementById("<%=hdn_removecookievalue.ClientID %>").value + IDs_DeptIDs;
                //                var newhdnmove = (document.getElementById("<%=hdn_movecookievalue.ClientID %>").value);
                //                var str2 = newhdnmove.replace(IDs_DeptIDs, "");
                //                document.getElementById("<%=hdn_movecookievalue.ClientID %>").value = str2;
                __doPostBack('AllocationID$btnReMove', '');
                return ret;
            }
        }
        else {
            if (value == 'move') {
                document.cookie = "MoveCustomers=" + "";
                hid_MoveCustomers.value = '';

            }
            else {
                hid_RemoveCustomers.value = '';
                document.cookie = "RemoveCustomers=" + "";
            }
        }
    }


    var hdn_movecookievalue = document.getElementById("<%=hdn_movecookievalue.ClientID %>");
    //var frmselected = document.getElementById("<%=GridAllocatedSubAdditionalOptions.ClientID %>").getElementsByTagName("input");
    var hdn_finalvalues = document.getElementById("<%=hdn_finalvalues.ClientID %>");
    var hdn_gridbuffer = document.getElementById("<%=hdn_gridbuffer.ClientID %>");
    var hid_MoveCustomers = document.getElementById("<%=hid_MoveCustomers.ClientID %>");

    function assignOptionstval() {
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_WebOtherCostIDs").value = document.getElementById("<%=hdn_WebOtherCostIDs.ClientID %>").value;
        var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
        //for (var m = 0; m < rowinputs.length; m++) {
        //    if (rowinputs[m].type == "radio" && (rowinputs[m].id).indexOf("rdbselectall") > -1) {
        //        document.getElementById(rowinputs[m].id).checked = true;
        //    }
        //}
        //checkheaderradio();
        GetRadWindow().close();
    }

</script>
<script type="text/javascript" language="javascript">
    function assignmultiple() {
        var hdn_CustomerList = document.getElementById("<%=hdn_CustomerList.ClientID %>");
        var hdn_Customers = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdn_Customers");
        hdn_Customers.value = hdn_CustomerList.value;
        window.parent.document.getElementById("ctl00_ContentPlaceHolder1_btnsavemultiple").click();
        GetRadWindow().close();
    }


    function ExpandThisMasterTableViewItem(isspcfc, index) {
        var Grid = $find("<%= GridAllocatedSubAdditionalOptions.ClientID %>");
        var MasterTable = Grid.get_masterTableView();
        var firstMasterTableViewRow = MasterTable.get_dataItems()[index];
        if (isspcfc == true) {
            firstMasterTableViewRow.set_expanded(true);
        }
        else {
            firstMasterTableViewRow.set_expanded(false);
        }
    }

</script>
