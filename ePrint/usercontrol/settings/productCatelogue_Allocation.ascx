<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="productCatelogue_Allocation.ascx.cs" Inherits="ePrint.usercontrol.settings.productCatelogue_Allocation" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--Specific--%>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridAvailableCustomers">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="GridSelectedCustomer">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridSelectedCustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="BtnMoveExclude">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridSelectedCustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnReMoveExclude">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridSelectedCustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridSelectedCustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnReMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridSelectedCustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ProductGridSelectedCustomers">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ProductGridSelectedCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="BtnMoveExclude">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ProductGridSelectedCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnReMoveExclude">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ProductGridSelectedCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ProductGridSelectedCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnReMove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="ProductGridSelectedCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
                <telerik:AjaxUpdatedControl ControlID="GridAvailableCustomers" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
<asp:Panel ID="pnlstyle" runat="server" Visible="false">
    <style type="text/css">
        .rgExpandCol {
            visibility: hidden !important;
        }
    </style>
</asp:Panel>
<div id="div_Specific" style="display: block;">
    <table id="Table1" runat="server" width="100%">
        <tr>
            <td width="47%">
                <div id="div_AvailableCustomers" style="float: left; width: 100%">
                    <strong><span id="Spn_header" runat="server" style="float: left; padding-left: 0%;"></span></strong>
                    <div class="only5px">
                    </div>
                    <telerik:RadGrid runat="server" ID="GridAvailableCustomers" OnNeedDataSource="GridAvailableCustomers_NeedDataSource"
                        AllowPaging="True" Width="99%" AllowMultiRowSelection="true" CssClass="RadGrid_Eprint_Skin"
                        PageSize="200" EnableHeaderContextMenu="true" AutoGenerateColumns="false" AllowFilteringByColumn="true"
                        Height="485px">
                        <GroupingSettings CaseSensitive="false" />
                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                        <HeaderStyle Width="10px" />
                        <MasterTableView DataKeyNames="clientid" Width="104%">
                            <Columns>
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <input type="checkbox" id="checkAll_1" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" runat="server" id="Id_1" onclick="CheckChanged('move');" name="Id"
                                            value='<%# DataBinder.Eval(Container, "DataItem.clientid", "{0}") %>' />
                                        <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.clientid", "{0}") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridDragDropColumn HeaderStyle-Width="5%" Visible="false" />
                                <telerik:GridBoundColumn Visible="false" HeaderText="clientid" DataField="clientid">
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn SortExpression="CustomerName" HeaderText="Customer Name"
                                    CurrentFilterFunction="Contains" HeaderStyle-Width="28%" DataField="CustomerName"
                                    ItemStyle-Width="28%" HeaderStyle-HorizontalAlign="Left" AllowFiltering="true"
                                    AutoPostBackOnFilter="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderTemplate>
                                        <div style="float: left; width: 40%;">
                                            <asp:Label ID="lblCustomerName" runat="server"><%=objLanguage.GetLanguageConversion("Customer_Name")%></asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; width: 40%;">
                                            <a title='<%#Eval("CustomerName")%>'>
                                                <asp:Label ID="lblCustomerName" CssClass="normalText" runat="server" Text='<%#Eval("CustomerName")%>'></asp:Label></a>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="AdditionalGroupID" Visible="false" DataField="AdditionalGroupID"
                                    SortExpression="AdditionalGroupID" UniqueName="AdditionalGroupID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Group Name" Visible="false" DataField="GroupName"
                                    SortExpression="GroupName" UniqueName="GroupName">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <ClientSettings AllowRowsDragDrop="True">
                            <%--<Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />--%>
                            <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="400px" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
            </td>
            <td style="padding: 0px 15px 0px 15px;">
                <asp:Button ID="btnMove" runat="server" Text=">>" ToolTip="Move" CssClass="button"
                    OnClientClick="javascript:CallSelect('move');" OnClick="BtnMove_Onclick" Visible="false" />
                <div class="only10px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <asp:Button ID="btnReMove" runat="server" Text="<<" ToolTip="Remove" CssClass="button"
                    OnClientClick="javascript:CallSelect('remove');" OnClick="BtnReMove_Onclick"
                    Visible="false" />
                <asp:Button ID="BtnMoveExclude" runat="server" Text=">>" ToolTip="Move" CssClass="button"
                    OnClientClick="javascript:CallSelect('move');" OnClick="BtnMoveExclude_Onclick"
                    Visible="false" /><%-- reverted for bugid - 2318--%>
                <div class="only10px">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
                <asp:Button ID="btnReMoveExclude" runat="server" Text="<<" ToolTip="Remove" CssClass="button"
                    OnClientClick="javascript:CallSelect('remove');" OnClick="btnReMoveExclude_Onclick"
                    Visible="false" />
            </td>
            <td width="47%">
                <div id="div_AllocatedGrid" style="width: 100%; display: block;">
                    <strong><span id="grd_header" runat="server" style="float: left; padding-left: 0%;"></span></strong>&nbsp;
                    <div class="only5px">
                    </div>
                    <telerik:RadGrid runat="server" Width="99%" AllowPaging="false" Visible="false" ID="GridSelectedCustomer"
                        OnPreRender="GridSelectedCustomer_PreRender" OnDetailTableDataBind="GridAvailableCustomers_DetailTableDataBind"
                        OnNeedDataSource="GridSelectedCustomer_NeedDataSource" AllowMultiRowSelection="true"
                        PageSize="200" CssClass="RadGrid_Eprint_Skin" AutoGenerateColumns="false" Height="485px"
                        AllowFilteringByColumn="true" MasterTableView-GroupHeaderItemStyle-Width="99px"
                        OnItemDataBound="GridSelectedCustomer_ItemDataBound" OnItemCreated="GridSelectedCustomer_ItemCreated">
                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        <MasterTableView DataKeyNames="clientid" Width="100%" TableLayout="Fixed" HierarchyLoadMode="Client">
                            <DetailTables>
                                <telerik:GridTableView AllowFilteringByColumn="false" AllowPaging="false" Name="DepartmentGrid"
                                    DataKeyNames="DeptID" Width="100%">
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="ExpandColumn" AllowFiltering="false" HeaderStyle-Width="5%"
                                            ItemStyle-Width="5%">
                                            <HeaderTemplate>
                                                <a href="javascript:;">
                                                    <input type="checkbox" runat="server" style="margin-left: 30px; visibility: hidden;"
                                                        value='<%#Eval("clientid") %>' id="chkdeptall" />
                                                </a>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" id="chkdept_1" onclick="deptuncheckone(this.checked,'<%#Eval("CustomerID")%>    ');"
                                                    value='<%#Eval("CustomerID")%>*~<%#Eval("DeptID")%>' />
                                                <asp:HiddenField runat="server" ID="hdn_customerid" Value='<%#Eval("CustomerID")%>'></asp:HiddenField>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-Width="50%" ItemStyle-Width="50%">
                                            <HeaderTemplate>
                                                <asp:Label ID="lbldeptheader" runat="server"><%=objLanguage.GetLanguageConversion("Department_Name")%></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbldeptname" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.DeptName","{0}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </telerik:GridTableView>
                            </DetailTables>
                            <Columns>
                                <telerik:GridDragDropColumn Visible="false" />
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="8%" ItemStyle-Width="8%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <div style="float: left">
                                            <input type="checkbox" id="checkAll_2" onclick="CheckAll_New(this);" runat="server"
                                                name="checkAll" />
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; margin-top: -16px; padding-left: 2px">
                                            <a href="javascript:;" onclick="deptcheckall(<%#Eval("clientid") %>);">
                                                <input type="checkbox" runat="server" id="Id_2" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.clientid", "{0}") %>' />
                                            </a>
                                            <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.clientid", "{0}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="CustomerName" HeaderText="Customer Name"
                                    CurrentFilterFunction="Contains" HeaderStyle-Width="85%" DataField="CustomerName"
                                    ItemStyle-Width="85%" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderTemplate>
                                        <div style="float: left; width: 99%;">
                                            <asp:Label ID="lbl_CustomerName" runat="server"><%=objLanguage.GetLanguageConversion("Customer_Name")%></asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; width: 99%;">
                                            <a id="A1" runat="server" style="float: left;" title='<%#Eval("CustomerName")%>'>
                                                <asp:Label ID="lbl_CustomerName" CssClass="normalText" runat="server" Text='<%#Eval("CustomerName")%>'></asp:Label></a>
                                        </div>
                                        <asp:Panel ID="pnldeptallocation" Style="display: inline; float: left; margin-left: -5px"
                                            runat="server">
                                            <a href="javascript:;" style="cursor: pointer" onclick="deptcheckall(<%#Eval("clientid") %>);ExpandThisMasterTableViewItem(false,<%#Container.ItemIndex %>,'<%#Eval("clientid") %>');">
                                                <input id='rdbselectall' runat="server" style="cursor: pointer" type="radio" checked="true"
                                                    group="rdb<%#Container.ItemIndex %>" value='<%#Eval("clientid")%>' /></a><%=objLanguage.GetLanguageConversion("All")%>
                                            <a href="javascript:;" style="cursor: pointer" onclick="deptcheckallUncheck(<%#Eval("clientid") %>);ExpandThisMasterTableViewItem(true,<%#Container.ItemIndex %>,'<%#Eval("clientid") %>');">
                                                <input type="radio" runat="server" style="cursor: pointer" id="rdbselect" group="rdb<%#Container.ItemIndex %>"
                                                    value='<%#Eval("clientid")%>' /></input> </a>
                                            <%=objLanguage.GetLanguageConversion("Specific_Departments")%>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                <div style="height: 30px; cursor: pointer;">
                                    <%=objLanguage.GetLanguageConversion("No_Records_Available")%>.
                                </div>
                            </NoRecordsTemplate>
                        </MasterTableView>
                        <ClientSettings AllowRowsDragDrop="True">
                            <%--<Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />--%>
                            <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="425px" />
                            <ClientEvents OnGroupExpanding="HierarchyExpanding" />
                        </ClientSettings>
                    </telerik:RadGrid>
                    <%--- product grid selected customer ---%>
                    <telerik:RadGrid runat="server" Width="99%" AllowPaging="True" ID="ProductGridSelectedCustomers"
                        OnNeedDataSource="GridSelectedCustomer_NeedDataSource" AllowMultiRowSelection="true"
                        PageSize="200" CssClass="RadGrid_Eprint_Skin" AutoGenerateColumns="false" Height="485px"
                        AllowFilteringByColumn="true">
                        <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                        <MasterTableView DataKeyNames="clientid" Width="100%">
                            <Columns>
                                <telerik:GridDragDropColumn Visible="false" />
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="false" AllowFiltering="false">
                                    <HeaderTemplate>
                                        <div style="float: left">
                                            <input type="checkbox" id="checkAll_2" onclick="CheckAll_New(this);" runat="server"
                                                name="checkAll" />
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left;">
                                            <input type="checkbox" runat="server" id="Id_2" onclick="CheckChanged('remove');"
                                                checked="checked" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.clientid", "{0}") %>' />
                                            <asp:Label ID="lbl" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container, "DataItem.clientid", "{0}") %>'></asp:Label>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="CustomerName" HeaderText="Customer Name"
                                    CurrentFilterFunction="Contains" HeaderStyle-Width="28%" DataField="CustomerName"
                                    ItemStyle-Width="28%" HeaderStyle-HorizontalAlign="Left" AutoPostBackOnFilter="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderTemplate>
                                        <div style="float: left; width: 99%;">
                                            <asp:Label ID="lbl_CustomerName" runat="server"><%=objLanguage.GetLanguageConversion("Customer_Name")%></asp:Label>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div style="float: left; width: 99%;">
                                            <a title='<%#Eval("CustomerName")%>'>
                                                <asp:Label ID="lbl_CustomerName" CssClass="normalText" runat="server" Text='<%#Eval("CustomerName")%>'></asp:Label></a>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <NoRecordsTemplate>
                                <div style="height: 30px; cursor: pointer;">
                                    <%=objLanguage.GetLanguageConversion("No_Records_Available")%>.
                                </div>
                            </NoRecordsTemplate>
                        </MasterTableView>
                        <ClientSettings AllowRowsDragDrop="True">
                            <%--<Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />--%>
                            <Scrolling AllowScroll="true" UseStaticHeaders="true" ScrollHeight="425px" />
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
                <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td>
                <div id="div_Copy" runat="server" style="float: left; width: 120%; margin-top: 2px; display: none;">
                    <div id="div10" style="float: left; width: 4%;">
                        <asp:CheckBox ID="chk_Copy" runat="server" />
                    </div>
                    <div id="div9" style="float: left; width: 90%; margin: 3px 0px 0px 0px;">
                        <asp:Label ID="lbl_Copy" runat="server" Text='Copy all products of the select category to the above selected Customers <br /> and Public accounts'></asp:Label>
                    </div>
                </div>
                &nbsp;
            </td>
            <td>&nbsp;
            </td>
            <td>
                <div style="display: inline">
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClientClick="javascript:getFinalVaules('i')"
                        OnClick="btnSave_OnClick" />
                </div>
                <div style="display: inline; width: 20%">
                    <asp:Button ID="btnselectallocate" CssClass="button" runat="server" Style="margin-left: 3px"
                        Text="Select and Allocate" OnClientClick="javascript:getFinalVaules('i');loadingimage(this.id,'div_btnselectallocateprocess');"
                        OnClick="btnselectallocate_OnClick" />
                    <div id="div_btnselectallocateprocess" style="display: none">
                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                    </div>
                </div>
                <div style="display: inline">
                    <asp:Button ID="btnproductsaveallocate" CssClass="button" Visible="false" runat="server"
                        Text="Save & Allocate" OnClick="btnSave_OnClick" />
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
    <asp:HiddenField ID="hdn_checkallocationtype" runat="server" />
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
        //        if (pw.document.getElementById("ctl00_ContentPlaceHolder1_txtCategoryName").value == '') {

        //            window.close();
        //            alert("here");
        //        }
        //        else {
        var hdn_CustomerList = document.getElementById("<%=hdn_CustomerList.ClientID %>");
        var hdn_Customers = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdn_Customers");
        hdn_Customers.value = hdn_CustomerList.value;
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_fromflag").value = 'allocate';
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_validateflag").value = ("<%=Action %>");
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_finalvalues").value = document.getElementById("<%=hdn_finalvalues.ClientID %>").value;
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
    var From = '<%=From %>';
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");

    function CallSelect(value) {
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
            if (From.toLowerCase() == 'category') {
                if (value == 'move') {
                    frm = document.getElementById("<%=GridAvailableCustomers.ClientID %>").getElementsByTagName("input");
                }
                else if (value == 'remove') {
                    frm = document.getElementById("<%=GridSelectedCustomer.ClientID %>").getElementsByTagName("input");
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
            storeselectedvalues();
        }
        else {
            if (value == 'move') {
                frm = document.getElementById("<%=GridAvailableCustomers.ClientID %>").getElementsByTagName("input");
            }
            else if (value == 'remove') {
                frm = document.getElementById("<%=ProductGridSelectedCustomers.ClientID %>").getElementsByTagName("input");
            }
        var i = 1;
        for (l = 0; l < frm.length; l++) {
            if (frm[l].id.indexOf('Id') != -1) {
                if (frm[l].type == "checkbox") {
                    if (frm[l].checked && ((frm[l].id).indexOf("Id_1") > -1 || (frm[l].id).indexOf("Id_2") > -1)) {
                        IDs = IDs + frm[l].value + ",";
                    }
                }
            }
        }
    }

    if (value == 'move') {
        hid_MoveCustomers.value = IDs;
        document.cookie = "MoveCustomers=" + IDs;
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
    //var frmselected = document.getElementById("<%=GridSelectedCustomer.ClientID %>").getElementsByTagName("input");
    var hdn_finalvalues = document.getElementById("<%=hdn_finalvalues.ClientID %>");
    var hdn_gridbuffer = document.getElementById("<%=hdn_gridbuffer.ClientID %>");
    var hid_MoveCustomers = document.getElementById("<%=hid_MoveCustomers.ClientID %>");

    function assigndeptval() {
        pw.document.getElementById("ctl00_ContentPlaceHolder1_hdn_finalvalues").value = document.getElementById("<%=hdn_finalvalues.ClientID %>").value;
        var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
        for (var m = 0; m < rowinputs.length; m++) {
            if (rowinputs[m].type == "radio" && (rowinputs[m].id).indexOf("rdbselectall") > -1) {
                document.getElementById(rowinputs[m].id).checked = true;
            }
        }
        checkheaderradio();
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
    function assignReportCustomers()
    {
        var ReportIDs="<%=ReportIDs%>";
        var hdn_CustomerList = document.getElementById("<%=hdn_CustomerList.ClientID %>");
        var hdn_Customers = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdn_Customers");
        hdn_Customers.value = hdn_CustomerList.value;
        var hdn_ReportIDs = window.parent.document.getElementById("ctl00_ContentPlaceHolder1_hdn_ReportIDs");
        hdn_ReportIDs.value=ReportIDs;
        window.parent.document.getElementById("ctl00_ContentPlaceHolder1_btnsavemultiple").click();
        GetRadWindow().close();
    }
    function ExpandThisMasterTableViewItem(isspcfc, index, clientid) {
        //added by gopi for 13782 (to check radio button on anchor tag click)
        var rowinputs = document.getElementById("AllocationID_GridSelectedCustomer").getElementsByTagName("input");
        for (var d = 0; d < rowinputs.length; d++) {
            if ((rowinputs[d].type == "radio") && ((rowinputs[d].id).indexOf("rdbselectall") > -1) && !isspcfc) {
                if ((document.getElementById(rowinputs[d].id).value == clientid)) {
                    if (isspcfc) {
                        document.getElementById(rowinputs[d].id).checked = false;
                    } else {
                        document.getElementById(rowinputs[d].id).checked = true;
                        deptcheckall(clientid);
                    }
                }
            } else if ((rowinputs[d].type == "radio") && ((rowinputs[d].id).indexOf("rdbselect") > -1) && isspcfc) {
                if ((document.getElementById(rowinputs[d].id).value == clientid)) {
                    document.getElementById(rowinputs[d].id).checked = true;
                }
            }
        }


        var Grid = $find("<%= GridSelectedCustomer.ClientID %>");
        var MasterTable = Grid.get_masterTableView();
        var firstMasterTableViewRow = MasterTable.get_dataItems()[index];
        if (isspcfc == true) {
            firstMasterTableViewRow.set_expanded(true);
        }
        else {
            //Added By gopikrishna 13782(On page load dept allocation type is all it's expanded value is false so first expanded true then make it false )
            firstMasterTableViewRow.set_expanded(true);
            firstMasterTableViewRow.set_expanded(false);
        }
    }

</script>

