<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailsSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.EmailsSubSection" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'"></script>
<style type="text/css">
    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td
    {
        border-style: solid;
        border-color: #C9C9C9;
        border-width: 0 0 1px 0px; /*top right bottom left*/
    }
    .RowMouseOver td
    {
        background-color: #D8D8D8 !important;
        height: auto;
    }
    .RowMouseOut
    {
        background: #ffffff;
        height: auto;
    }
    
    .RadGrid .rgSelectedRow
    {
        background-color: #8F8F8F !important;
        background-image: none !important;
        height: auto;
    }
    
    .RadGrid_Default .rgCommandCell
    {
        border-right: 0px solid rgb(242, 242, 242);
        border-width: 0px 0px 0px;
        border-style: inherit;
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        border-color: rgb(153, 153, 153) rgb(242, 242, 242);
        padding: 0px;
        border: 0px solid red;
    }
    .RadGrid_Default .rgCommandTable
    {
        border-right: 0px none;
        border-left: 0px none;
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        border-width: 0px 0px;
        border-style: solid none;
        border-color: rgb(253, 253, 253) -moz-use-text-color rgb(231, 231, 231);
    }
    .RadGrid .rgClipCells .rgHeader, .RadGrid .rgClipCells .rgFilterRow > td, .RadGrid .rgClipCells .rgRow > td, .RadGrid .rgClipCells .rgAltRow > td, .RadGrid .rgClipCells .rgEditRow > td, .RadGrid .rgClipCells .rgFooter > td
    {
        overflow: visible;
    }
</style>
<%--<asp:LinkButton ID="lnk_ClearFilter_Email" runat="server" CausesValidation="false" OnClick="clrFiltersEmail_Click"></asp:LinkButton>--%>
<div id="div_EmailMain" runat="server" style="border: solid 0px silver; display: block;">
    <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
        <div style="width: 60%; margin: 5px 0px 0px 5px">
            <asp:UpdatePanel ID="UpdatePanel4" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhEmail" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div>
        <div id="div_popupActionEmail" style="display: none; z-index: 999999; position: absolute;
            margin: 63px 0px 0px 18px" onmouseover="show_Email();" onmouseout="hide_Email();">
            <telerik:RadListBox runat="server" ID="RadListBox_Email" SelectionMode="Single" Width="80px"
                AutoPostBack="false">
                <Items>
                    <telerik:RadListBoxItem Text="Delete" onclick="javascript:return CheckOne_new_Email('delete_email');"
                        Checked="false" />
                </Items>
            </telerik:RadListBox>
        </div>
    </div>
    <div id="div_Load" class="loading_new" style="display: none">
        <table cellpadding="0" cellspacing="10">
            <tr>
                <td>
                    <div style="float: left">
                        <img src="<%=ImgPath %>loading_new.gif" border="0" /></div>
                </td>
            </tr>
        </table>
    </div>
    <asp:LinkButton ID="lnk_EmailRadList" runat="server" OnClick="RadListBox_Email_SelectedIndexChanged"></asp:LinkButton>
    <div id="div_Email" style="padding: 7px 10px 25px 7px; display: block;">
        <asp:UpdatePanel ID="UpdatePanel_Email" runat="server">
            <ContentTemplate>
                <telerik:RadGrid ID="RadGrid_Email" runat="server" AllowPaging="true" AllowSorting="true"
                    AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true" GroupingEnabled="false"
                    PageSize="50" Width="100%" ShowGroupPanel="true" ShowStatusBar="true" HeaderStyle-Font-Bold="true"
                    OnNeedDataSource="RadGrid_Email_OnNeedDataSource" AllowFilteringByColumn="true"
                    OnItemDataBound="RadGridEmail_OnRowDataBound" OnItemCommand="RadGrid_Email_ItemCommand"
                    GridLines="none" CssClass="AddBorders" EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333"
                    HeaderStyle-BorderStyle="None" BorderColor="White" FilterItemStyle-HorizontalAlign="Justify"
                    Skin="Default" GroupingSettings-CaseSensitive="false">
                    <AlternatingItemStyle BackColor="White" />
                    <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" Position="Bottom" />
                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                    <MasterTableView DataKeyNames="sl" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                        CommandItemDisplay="Top" Width="100%">
                        <CommandItemTemplate>
                          <%--  <table class="rgCommandTable" border="0" style="width: 100%; margin-left: -8px; margin-top: -4px;">
                                <tr>
                                    <td align="left" style="width: 49%;">
                                        <div id="DivAddNewEmails" runat="server" style="float: left; width: 200px;">
                                            <a href="javascript:void(0);;" onclick="javascript:PopupCenter_Email('0','add','<%=ClientID %>','<%=isadd %>'); return false"
                                                title="Add New Email" style="color: #10357F; text-decoration: underline;">
                                                <%=objLangClass.GetLanguageConversion("Add_New_Email")%>
                                            </a>
                                        </div>
                                        <div style="float: left;">
                                        </div>
                                    </td>
                                    <td align="right" style="width: 49%;">
                                        <div style="margin-right: -15px;">
                                            <asp:LinkButton ID="btnclrFilters_Email" runat="server" Style="text-decoration: underline;
                                                color: #10357F; cursor: pointer" Text="" OnClick="clrFiltersEmail_Click"><%=objLangClass.GetLanguageConversion("Clear_All_Filters") %></asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>--%>
                            <asp:LinkButton ID="lnk_ClearFilter_Email" runat="server" CausesValidation="false" OnClick="clrFiltersEmail_Click"></asp:LinkButton>
                            <div style="border-bottom: 1px solid #C9C9C9; margin-top: 5px;">
                            </div>
                        </CommandItemTemplate>
                        <Columns>
                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                HeaderStyle-Width="5%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                ItemStyle-Width="5%" UniqueName="Delete_Emails">
                                <HeaderTemplate>
                                    <div id="div_checkBox_Email" style="float: left; height: auto; margin: 0px 0px 0px 0px;
                                        display: block;">
                                        <div id="div_chk_Email" style="float: left; margin: -1px 0px -1px 0px; padding: 0px 0px 0px 0px;
                                            border: outset 1px; width: 40px; -moz-border-radius: 5px; -webkit-border-radius: 5px;
                                            -ms-border-radius: 5px; border-radius: 2px 2px 2px 2px">
                                            <div style="float: left; padding: 2px 0px 2px 1px">
                                                <input id="checkAll_Email" runat="server" name="checkAll_Email" onclick="checkAll_new_Email(this);"
                                                    type="checkbox" />
                                                <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                            </div>
                                            <div style="float: left; padding: 7px 0px 0px 2px">
                                                <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow_Email" style="display: block;
                                                    border: solid 0px Transparent; cursor: pointer;" onclick="show_Email();" alt='' />
                                                <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide_Email" style="display: none;
                                                    border: solid 0px Transparent; cursor: pointer;" onclick="hide_Email();" alt='' />
                                            </div>
                                        </div>
                                        <div style="clear: both;">
                                        </div>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="checkBox_Email" runat="server" name="Id" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.sl", "{0}") %>' />
                                    <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="subject" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" FilterControlWidth="100" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" HeaderStyle-Width="25%" HeaderText="" ItemStyle-Width="25%"
                                SortExpression="subject" UniqueName="subject" Visible="true">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:PopupCenter_Email('<%# DataBinder.Eval(Container, "DataItem.sl", "{0}") %>','edit','<%=ClientID %>','<%=isView%>'); return false">
                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                            <asp:Label ID="lbl_Email" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.subject", "{0}")) %>'
                                                ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.subject", "{0}")) %>'></asp:Label>
                                            <asp:HiddenField ID="hdn_sl" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.sl", "{0}") %>' />
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="TO" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                AllowFiltering="true" FilterControlWidth="100" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" HeaderStyle-Width="25%" HeaderText="" ItemStyle-Width="25%"
                                SortExpression="TO" UniqueName="TO" Visible="true">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:PopupCenter_Email('<%# DataBinder.Eval(Container, "DataItem.sl", "{0}") %>','edit','<%=ClientID %>','<%=isView%>'); return false">
                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                            <asp:Label ID="lbl_Recipients" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TO", "{0}") %>'
                                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.TO", "{0}") %>'></asp:Label>
                                            <asp:HiddenField ID="hdn_Recipients" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TO", "{0}") %>' />
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                AllowFiltering="false" FilterControlWidth="100" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" HeaderStyle-Width="15%" HeaderText="" ItemStyle-Width="15%"
                                Visible="true">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:PopupCenter_Email('<%# DataBinder.Eval(Container, "DataItem.sl", "{0}") %>','edit','<%=ClientID %>','<%=isView%>'); return false">
                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                            <asp:Label ID="lbl_NoEmailSent" runat="server"></asp:Label>
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="dateSent" HeaderStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Left" AllowFiltering="true" FilterControlWidth="90"
                                HeaderStyle-Width="15%" HeaderText="" CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true"
                                ItemStyle-Width="15%" SortExpression="dateSent" UniqueName="dateSent" Visible="true">
                                <ItemTemplate>
                                    <a href="javascript:void(0);" onclick="javascript:PopupCenter_Email('<%# DataBinder.Eval(Container, "DataItem.sl", "{0}") %>','edit','<%=ClientID %>','<%=isView%>'); return false">
                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px;">
                                            <asp:Label ID="lbl_dateSent" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.dateSent", "{0}") %>'></asp:Label>
                                            <asp:HiddenField ID="hdn_dateSent" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.dateSent", "{0}") %>' />
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                AutoPostBackOnFilter="true" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%"
                                HeaderText="" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="5%" UniqueName="restoreDefault">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <asp:ImageButton ID="ImgButtonDeleteEmail" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                            CommandArgument='<%#Eval("sl")%>' Text="Delete" UniqueName="DeleteColumn" runat="server"
                                            OnClientClick="javascript:return imgbtnDelete_ClientClick('email',0)" OnCommand="DeleteImgEmail_OnClick">
                                        </asp:ImageButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <NoRecordsTemplate>
                            <div style="padding: 0px 0px 0px 10px">
                                <%=objLangClass.GetLanguageConversion("No_records_Found") %>
                            </div>
                        </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                        AllowDragToGroup="false" Scrolling-AllowScroll="true">
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                        <Scrolling UseStaticHeaders="true" ScrollHeight="340" SaveScrollPosition="true" />
                        <ClientEvents OnFilterMenuShowing="filterMenuShowing" OnRowMouseOver="RowMouseOver"
                            OnRowMouseOut="RowMouseOut" />
                    </ClientSettings>
                    <FilterMenu OnClientShown="MenuShowing" />
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="clear: both">
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
    var img_actionsShow_Email = document.getElementById("img_actionsShow_Email");
    var img_actionsHide_Email = document.getElementById("img_actionsHide_Email");
    var div_popupActionEmail = document.getElementById("div_popupActionEmail");
    var RadListBox_Email = document.getElementById("<%=RadListBox_Email.ClientID %>");
</script>
<script type="text/javascript" language="javascript">
    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender; var items = menu.get_items();
        if (column.get_dataType() == "System.DateTime") {
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

        if (column.get_dataType() == "System.String") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'Contains': '', 'DoesNotContain': '', 'StartsWith': '', 'EndsWith': '', 'EqualTo': '' })) {
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

        if (column.get_dataType() == "System.Decimal" || column.get_dataType() == "System.Int32") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '' })) {
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

</script>
