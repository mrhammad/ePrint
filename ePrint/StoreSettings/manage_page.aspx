<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="manage_page.aspx.cs" Inherits="ePrint.StoreSettings.manage_page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
    <%--Comment by praveen (If this bolock is uncomment, then sortpage wont refresh/rebild )--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="lnk_accountsList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
            margin-left: -10px;
            margin-top: -10px;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
            margin-top: -8px;
        }
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }
        .RadGrid_Default
        {
            outline: none;
        }
    </style>
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">
        <script type="text/javascript">
            function onRowDropping(sender, args) {
                if (sender.get_id() == "<%=RadGrid1.ClientID %>") {

                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('<%=RadGrid1.ClientID %>', node) && !isChildOf('<%=RadGrid1.ClientID %>', node)) {
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
    <div class="estore_settingBox" id="pnldetails">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Manage_Page")%>&nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp;
                                        <%--<a href="#?"
                                            rel="popup1" class="poplight" style="color: White; text-decoration: underline">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                        </a></span>--%>
                                        <a id="A1" href="#" style="color: White; text-decoration: underline" runat="server"
                                            onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div style="padding: 0px 5px 10px 5px;">
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="padding-left: 5px; padding-top: 5px; display: block">
                    <div style="width: 100%; display: block" id="divtabs">
                        <div id="ynnav">
                            <ul>
                                <li id="li_managePage" style="cursor: pointer; float: left; clear: right;">
                                    <div id="divmanagePage" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                                        float: left; line-height: 20px; margin-right: 2px; display: block">
                                        <b>
                                            <asp:Label ID="lbl_managePage" Style="color: Red" runat="server" Text="Manage Pages"
                                                onclick="javascript:gettabs('m');"><%=objLanguage.GetLanguageConversion("Manage_Page")%></asp:Label>
                                        </b>
                                    </div>
                                </li>
                                <li id="li_sortPage" style="cursor: pointer; float: left; clear: right; display: block">
                                    <div id="divsortPage" nowrap="nowrap" style="color: Black; height: 20px; padding: 0px 10px 0px 10px;
                                        float: left; line-height: 20px; margin-right: 2px; filter: opaci">
                                        <b>
                                            <asp:Label ID="lbl_sortPage" runat="server" Text="Reorder Pages" onclick="javascript:gettabs('s');"><%=objLanguage.GetLanguageConversion("Reorder_Pages")%></asp:Label>
                                        </b>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <div id="div_managePage" style="border: solid 1px gainsboro; display: block; margin: 0px 0px 0px 5px;">
                    <div align="left" style="padding: 20px; padding-left: 10px; width: 50%; display: block;">
                        <div id="div_Main" runat="server">
                            <%--<asp:LinkButton ID="lnkDelete" runat="server" CssClass="button" Text="Delete" OnClick="Delete_OnClick"
                                Style="color: Black" OnClientClick="javascript:return CheckOne_new();"></asp:LinkButton>--%>
                            <div id="div_Grid">
                                <div id="div_popupAction" style="margin: 46px 0px 0px 9px;" onmouseover="show();"
                                    onmouseout="hide(); ">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div style="width: 100%">
                                                    <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete Selected" OnClientClick="javascript:return CheckOne_new();"
                                                            OnClick="Delete_OnClick" Width="150px" Style="text-decoration: none" ForeColor="#333333"
                                                            Font-Size="11px"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <%--Manage Page Grid--%>
                                <telerik:RadGrid ID="GridView1" runat="server" GridLines="None" AllowFilteringByColumn="true"
                                    BorderWidth="0" AllowPaging="true" AllowSorting="false" AutoGenerateColumns="false"
                                    OnNeedDataSource="GridView1_OnNeedDataSource" PagerStyle-AlwaysVisible="true"
                                    GroupingEnabled="false" PageSize="50" ShowGroupPanel="true" OnItemCommand="GridView1_ItemCommand"
                                    ShowStatusBar="true" OnItemDataBound="GridView1_RowDataBound" GroupingSettings-CaseSensitive="false">
                                    <HeaderStyle Width="100px" Font-Bold="true" />
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" />
                                    <MasterTableView HorizontalAlign="NotSet" DataKeyNames="pageID" OverrideDataSourceControlSorting="true"
                                        AllowFilteringByColumn="True" CommandItemDisplay="top" Width="100%">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%; margin-top: -16px">
                                                <tr>
                                                    <td align="left" style="text-decoration: underline; margin-top: -12px">
                                                        <a href="manage_page_edit.aspx?&amp;mode=add">
                                                            <%=objLanguage.GetLanguageConversion("Add_New_Record")%></a>
                                                    </td>
                                                    <td align="right" style="text-decoration: underline; margin-right: -10px;">
                                                        <asp:LinkButton ID="btnclrFilters" runat="server" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                            margin-right: -10px; cursor: pointer" Text='<%#objLanguage.GetLanguageConversion("Clear_All_Filters")%>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <EditItemStyle></EditItemStyle>
                                        <Columns>
                                            <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" HeaderStyle-Wrap="false"
                                                ItemStyle-HorizontalAlign="left" ItemStyle-Width="3%">
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div style="float: left; display: none;">
                                                            <input id="CheckBox1" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                type="checkbox" />
                                                        </div>
                                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                            -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <div style="float: left">
                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                type="checkbox" />
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Panel ID="pnl_chkImage" runat="server">
                                                                            <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                                <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block;
                                                                                    border: solid 0px Transparent; cursor: pointer;" onclick="show();" alt='' />
                                                                                <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none;
                                                                                    border: solid 0px Transparent; cursor: pointer;" onclick="hide();" alt='' />
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
                                                    <div style="padding-left: 2px">
                                                        <input id="Id" runat="server" name="Id" type="checkbox" onclick="CheckChanged();"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.pageID", "{0}") %>' />
                                                    </div>
                                                    <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                DataField="systemName" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%"
                                                HeaderText="System Name" ItemStyle-Width="40%" UniqueName="system" Visible="true"
                                                DataType="System.String">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("System_Name")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href='manage_page_edit.aspx?&amp;mode=edit&amp;pageID=<%#Eval("pageID")%>'>
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px; cursor: pointer;">
                                                            <asp:Label ID="lblsystemName_change" runat="server" ToolTip='<%#Eval("systemName")%>'><%#Eval("systemName")%></asp:Label>
                                                        </div>
                                                        <asp:LinkButton ID="lnk_systemName" runat="server" Style="display: none;" Text='<%#Eval("systemName")%>'><%# SpecialDecode(DataBinder.Eval(Container, "DataItem.systemName", "{0}"))%></asp:LinkButton>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn CurrentFilterFunction="Contains" AutoPostBackOnFilter="true"
                                                DataField="pageName" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%"
                                                HeaderText="Page Name" ItemStyle-Width="40%" UniqueName="page" Visible="true"
                                                DataType="System.String">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="label2" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Page_Name")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href='manage_page_edit.aspx?&amp;mode=edit&amp;pageID=<%#Eval("pageID")%>'>
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                            <asp:Label ID="lblsystemName" runat="server" ToolTip='<%#Eval("pageName")%>'>
                                                            <%# SpecialDecode(DataBinder.Eval(Container, "DataItem.pageName", "{0}"))%>
                                                            </asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="modifiedDate" AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="30%" HeaderText="Page Name" ItemStyle-Width="30%" UniqueName="Default"
                                                Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="lblDefault" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Default_Landing")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.pageID", "{0}") %>,'Page');">
                                                        <div style="width: 100%; padding-left: 16px; overflow: hidden; height: 18px;">
                                                            <asp:HiddenField ID="hdn_IsDefaultLand" runat="server" Value='<%#Eval("IsDefaultLand")%>' />
                                                            <asp:HiddenField ID="hdn_ShowPageIn" runat="server" Value='<%#Eval("ShowPagesIn")%>' />
                                                            <asp:ImageButton ID="img_DefaultLand" runat="server" CommandName="Set as default"
                                                                CssClass="rollover" Text="Set as default" CommandArgument='<%#Eval("pageID")%>'
                                                                OnCommand="setDefaultLand_OnClick"></asp:ImageButton>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                                                DataField="modifiedDate" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%"
                                                HeaderText="Last Modified On" ItemStyle-Width="30%" AllowFiltering="true" SortExpression="modifiedDate"
                                                UniqueName="modifiedDate" Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="label3" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Last_Modified_On")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href='manage_page_edit.aspx?&amp;mode=edit&amp;pageID=<%#Eval("pageID")%>'>
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px; text-align: left">
                                                            <asp:Label ID="lbl_dateGridView1" Text='<%# DataBinder.Eval(Container, "DataItem.modifiedDate", "{0}") %>'
                                                                runat="server"><%--Text='<%#Eval("modifiedDate")%>'--%>
                                                            </asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="11%" HeaderText="Action"
                                                ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" UniqueName="restoreDefault">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="label4" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="text-align: center;">
                                                        <asp:ImageButton ID="ImgButtonDelete" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                            CommandArgument='<%#Eval("pageID")%>' OnCommand="DeleteImg_OnClick" Text="Delete"
                                                            UniqueName="DeleteColumn" runat="server" OnClientClick="javascript:return imgbtnDelete_ClientClick()">
                                                        </asp:ImageButton>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <NoRecordsTemplate>
                                            No records found
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                    <ClientSettings ReorderColumnsOnClient="true" EnableRowHoverStyle="true" AllowDragToGroup="true">
                                        <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                                <%-- <asp:ObjectDataSource ID="odsManagePage" runat="server" TypeName="Printcenter.UI.Webstores.WebstoreBasePage"
                                    SelectMethod="pagesSelect">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="CompanyID" SessionField="CompanyID" Type="Int32" />
                                        <asp:Parameter Name="AccountID" DbType="Int32" DefaultValue="0" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <div id="div_sortPage" style="border: solid 1px gainsboro; display: none; margin: 0px 0px 0px 5px;">
                    <div align="left" style="padding: 20px; padding-left: 10px; width: 50%; display: block;">
                        <div id="div2" runat="server" style="padding: 0px 0px 10px 0px">
                            <asp:LinkButton ID="lnkSave" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:return validate_Account();"
                                OnClick="btn_save_Click" Style="color: Black"></asp:LinkButton>
                        </div>
                        <div id="div3" runat="server">
                            <%--SortPage Grid--%>
                            <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                BorderWidth="0" OnNeedDataSource="RadGrid1_NeedDataSource" AllowPaging="false"
                                AllowSorting="false" AutoGenerateColumns="false" ClientSettings-AllowRowsDragDrop="true"
                                PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="500" ShowGroupPanel="true"
                                ShowStatusBar="true" OnRowDrop="RadGrid1_RowDrop" OnItemDataBound="RadGrid1_RowDataBound">
                                <HeaderStyle Width="100px" Font-Bold="true" />
                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="pageID" HorizontalAlign="NotSet"
                                    OverrideDataSourceControlSorting="true" Width="100%">
                                    <Columns>
                                        <telerik:GridDragDropColumn Visible="false">
                                        </telerik:GridDragDropColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="10%" HeaderText="Reorder" ItemStyle-Width="10%" UniqueName="system"
                                            Visible="true">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="lbl1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("ReOrder")%>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                                    <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                        float: left; background-repeat: no-repeat; margin: 0px 0px 0px 12px;">
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="System Name"
                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="System Name"
                                            ItemStyle-Width="30%" SortExpression="Description" UniqueName="system" Visible="true">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="lbl2" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("System_Name")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; cursor: pointer; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:Label ID="lbl2" runat="server" ToolTip='<%#Eval("systemName")%>'><%#Eval("systemName")%></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="Page Name"
                                            HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Page Name"
                                            ItemStyle-Width="30%" SortExpression="Description" UniqueName="page" Visible="true">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="lbl3" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Page_Name")%>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; cursor: pointer; width: 99%; overflow: hidden; height: 15px">
                                                    <asp:Label ID="lblpageName3" runat="server" ToolTip='<%#Eval("pageName")%>'><%#Eval("pageName")%></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="Last Modified On"
                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="30%" HeaderText="Last Modified On"
                                            ItemStyle-Width="30%" SortExpression="Description" UniqueName="last" Visible="true">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="lbl4" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Last_Modified_On")%></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px; text-align: center">
                                                    <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("modifiedDate")%>'>
                                                    </asp:Label>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <NoRecordsTemplate>
                                        <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                                <ClientSettings ReorderColumnsOnClient="true" EnableRowHoverStyle="true" AllowRowsDragDrop="true"
                                    AllowDragToGroup="true">
                                    <ClientEvents OnRowDropping="onRowDropping" />
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        var div_managePage = document.getElementById("div_managePage");
        var div_sortPage = document.getElementById("div_sortPage");

        var lbl_managePage = document.getElementById("<%=lbl_managePage.ClientID %>");
        var lbl_sortPage = document.getElementById("<%=lbl_sortPage.ClientID %>");

        var stay = '<%=stay %>';

        function gettabs(value) {
            if (value == 'm') {
                div_managePage.style.display = "block";
                div_sortPage.style.display = "none";

                lbl_managePage.style.color = "Red"
                lbl_sortPage.style.color = "black"
            }
            else if (value == 's') {
                div_managePage.style.display = "none";
                div_sortPage.style.display = "block";

                lbl_managePage.style.color = "black"
                lbl_sortPage.style.color = "Red"
            }
        }

        gettabs(stay);

        function imgbtnDelete_ClientClick() {
            return confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation") %>');
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

        function CheckOne_new() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            if (Number(Counter) == 0) {
                alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete") %>');
                return false;
            }
            else {
                return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation") %>');
            }
        }
        function setAsDefault(ID, val) {

            return true;
        }

    </script>
    <script type="text/javascript" language="javascript">



        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
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

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
