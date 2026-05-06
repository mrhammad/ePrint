<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="department_selector.ascx.cs" Inherits="ePrint.usercontrol.Departments.department_selector" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div id="div_DepartmentMain" runat="server" style="border: solid 0px silver; display: block;">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid_Department">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_Department" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div id="div_Department" style="padding: 0px 10px 0px 10px; display: block;">
        <telerik:RadGrid ID="RadGrid_Department" runat="server" AllowPaging="true" AllowSorting="false"
            AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true" GroupingEnabled="false"
            PageSize="50" Width="100%" ShowGroupPanel="true" ShowStatusBar="true" HeaderStyle-Font-Bold="true"
            OnNeedDataSource="RadGrid_Department_OnNeedDataSource" AllowFilteringByColumn="true"
            OnItemDataBound="RadGridDepartment_OnRowDataBound">
            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
            <PagerStyle Mode="NextPrevAndNumeric" />
            <MasterTableView DataKeyNames="DeptID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                CommandItemDisplay="Top" Width="100%">
                <CommandItemTemplate>
                    <table class="rgCommandTable" border="0" style="width: 100%;">
                        <tr>
                            <td align="left" style="width: 49%;">
                                <div style="float: left; width: 200px;">
                                    <a href="javascript:void(0);" onclick="javascript:addNewDepartment('dept','add','<%=ClientID %>','0');"
                                        title="Add New Department">
                                        <button id="btnAddNewRecord" class="rgAdd" type="button">
                                        </button>
                                        <%=objLanguage.GetLanguageConversion("Department")%></a>
                                </div>
                                <div style="float: left;">
                                    <%--<b><a href="javascript:void(0);" onclick="javascript:addNewDepartment('dept','add','<%=ClientID %>','0');">
                                                <asp:Button runat="server" ID="btnAddNewRecord" class="rgAdd" />
                                                <%=("Add New Department")%>
                                            </a></b>--%>
                                </div>
                            </td>
                            <td align="right" style="width: 49%;">
                                <%-- <asp:LinkButton ID="btnclrFiltersShowDept" runat="server" OnClick="clrFiltersHideDept_Click"
                                    Style="text-decoration: underline; cursor: pointer;" Text="Show Filters" OnClientClick="javascript:SetFiterState_Onclick('dept','show');" />&nbsp;
                                <asp:LinkButton ID="btnclrFiltersHideDept" runat="server" OnClick="clrFiltersHideDept_Click"
                                    Style="text-decoration: underline; cursor: pointer;" Text="Hide Filters" Visible="false"
                                    OnClientClick="javascript:SetFiterState_Onclick('dept','hide');" />--%>
                                <asp:LinkButton ID="btnclrFilters_Dept" runat="server" Style="text-decoration: underline;
                                    cursor: pointer" Visible="false" Text="" OnClick="clrFiltersDept_Click"><%=objLanguage.GetLanguageConversion("Clear_Filters")%></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </CommandItemTemplate>
                <Columns>
                    <telerik:GridTemplateColumn DataField="DeptName" HeaderStyle-HorizontalAlign="Left"
                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="200"
                        HeaderStyle-Width="20%" HeaderText="" ItemStyle-Width="20%" SortExpression="DeptName"
                        UniqueName="DeptName" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="SendDeptDetails('<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeliveryAddressID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.InvoiceAddress", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeliveryAddress1", "{0}") %>');">
                                <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_DeptName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>'
                                        ToolTip='<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>'></asp:Label>
                                    <asp:HiddenField ID="hdn_DeptName" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>' />
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="DeliveryAddress" HeaderStyle-HorizontalAlign="Left"
                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="200"
                        HeaderStyle-Width="20%" HeaderText="" ItemStyle-Width="20%" SortExpression="DeliveryAddress"
                        UniqueName="DeliveryAddress" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="SendDeptDetails('<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeliveryAddressID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.InvoiceAddress", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeliveryAddress1", "{0}") %>');">
                                <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_DeliveryAddress" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DeliveryAddress1", "{0}") %>'
                                        ToolTip='<%# DataBinder.Eval(Container, "DataItem.DeliveryAddress1", "{0}") %>'></asp:Label>
                                    <%--<asp:HiddenField ID="hdn_DeptName" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>' />--%>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn DataField="InvoiceAddress" HeaderStyle-HorizontalAlign="Left"
                        CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="200"
                        HeaderStyle-Width="20%" HeaderText="" ItemStyle-Width="20%" SortExpression="InvoiceAddress"
                        UniqueName="InvoiceAddress" Visible="true">
                        <ItemTemplate>
                            <a href="javascript:void(0);" onclick="SendDeptDetails('<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeliveryAddressID", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.InvoiceAddress", "{0}") %>','<%# DataBinder.Eval(Container, "DataItem.DeliveryAddress1", "{0}") %>');">
                                <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                    <asp:Label ID="lbl_InvoiceAddress" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.InvoiceAddress", "{0}") %>'
                                        ToolTip='<%# DataBinder.Eval(Container, "DataItem.InvoiceAddress", "{0}") %>'></asp:Label>
                                    <%--<asp:HiddenField ID="hdn_DeptName" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>' />--%>
                                </div>
                            </a>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <NoRecordsTemplate>
                    <div style="padding: 0px 0px 0px 10px">
                        <%=objLanguage.GetLanguageConversion("No_Records_Found") %>
                    </div>
                </NoRecordsTemplate>
            </MasterTableView>
            <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                AllowDragToGroup="false" Scrolling-AllowScroll="true">
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                <Scrolling UseStaticHeaders="true" ScrollHeight="300" />
            </ClientSettings>
        </telerik:RadGrid>
    </div>
</div>
<div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
    width: 50%" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="620" OnClientClose="RadWinClose"
        Behaviors="Close,Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<script type="text/javascript" language="javascript">

    var strSitepath = '<%=strSitepath %>';
    var pg = '<%=pg %>';
    var CompanyType = '<%=CompanyType %>';

    function SetFiterState_Onclick(TabName, State) {

        var TabName = TabName.toLowerCase();
        var State = State.toLowerCase();

        if (TabName == "dept") {
            if (State == "show") {
                document.cookie = "DeptFiterState=Show";
            }
            else if (State == "hide") {
                document.cookie = "DeptFiterState=Hide";
            }
        }
    }

    function addNewDepartment(val, type, clientid, contactid) {
        if (type == 'add') {
            window.location = strSitepath + "common/common_popup.aspx?type=moreDept&clientid=" + clientid + "&mode=add&pg=" + pg + "&companytype=" + CompanyType + "&Pgtype=" + pg + "&from=" + pg;
        }
    }

    function SendDeptDetails(id, deptname, invAddressId, DelAddressID, InVAddress, DelAddress) {
        var pw = window.parent;
        pw.SendDeptIDName(id, deptname, invAddressId, DelAddressID, InVAddress, DelAddress);
        setTimeout("TakeOut()", 500);
        return false;
    }

    function TakeOut() {
        window.close();
    }

</script>


