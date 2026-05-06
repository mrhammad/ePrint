<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="manage_email.aspx.cs" Inherits="ePrint.StoreSettings.manage_email" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register TagPrefix="UC" TagName="CopyEmail" Src="~/usercontrol/StoreSettings/account_list.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--  <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadListBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_Email" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
        .RadGrid_Default .rgCommandRow {
            background: none;
        }

            .RadGrid_Default .rgCommandRow a {
                color: #10357F;
                text-decoration: none;
            }

        .RadGrid_Default .rgCommandCell {
            border: none;
        }

        .RadGrid_Default .rgHeader {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }

        .RadGrid_Default {
            outline: none;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" SkinID="Windows7" runat="server" />
    <div style="float: left;" id="pnldetails" class="estore_settingBox">
        <div align="left" style="padding-bottom: 5px;">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Manage_Emails")%>&nbsp;</asp:Label>
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp;
                                        <%--<a href="#?"
                                            rel="popup1" class="poplight" style="color: White; text-decoration: underline">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                            </a> </span>--%>
                                        <a id="A1" href="#" style="color: White; text-decoration: underline" runat="server"
                                            onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change")%></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div style="min-height: 350px">
                <div id="div_GridAdmin" class="manageedit" style="display: block; margin-top: -6px;">
                    <div align="left" style="width: 100%; padding: 0px 0px 0px 0px; border: 0px solid red">
                        <div style="width: 60%">
                            <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div>
                        <div id="div_popupActionAdmin" style="display: none; z-index: 999999; position: absolute; margin: 60px 0px 0px 8px"
                            onmouseover="show();" onmouseout="hide();">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%">
                                            <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel3">
                                                <telerik:RadListBox runat="server" ID="RadListBox3" SelectionMode="Single" Width="80px"
                                                    OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged" AutoPostBack="true">
                                                    <Items>
                                                        <telerik:RadListBoxItem Text='Enable' onclick="CheckOne_new('enable');" />
                                                        <telerik:RadListBoxItem Text='Disable' onclick="CheckOne_new('disable');" />
                                                        <telerik:RadListBoxItem Text='Copy Email' onclick="CheckOne_new('copyemail')" />
                                                        <%--onclick="CheckOne_new('copyemail');"--%>
                                                        <%--onmouseover="popupAccountsShow();"--%>
                                                    </Items>
                                                </telerik:RadListBox>
                                            </telerik:RadAjaxPanel>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="div5" style="display: block;">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <telerik:RadGrid ID="RadGrid_EmailAdmin" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                    BorderWidth="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false"
                                    PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="50" Width="750px"
                                    ShowGroupPanel="false" ShowStatusBar="true" HeaderStyle-Font-Bold="true" OnItemDataBound="RadGrid_Email_RowDataBound">
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" />
                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="EmailToCustomerID" HorizontalAlign="NotSet"
                                        CommandItemDisplay="Top" OverrideDataSourceControlSorting="true" Width="100%">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%; float: left; margin-left: -8px; border-bottom-width: 0px">
                                                <tr>
                                                    <td align="left">
                                                        <b>
                                                            <asp:Label ID="lbl_admin" runat="server" Text="Email to admin (Not specific to any account)"><%=objLanguage.GetLanguageConversion("Email_To_Admin_Not_Specific_To_Any_Account")%></asp:Label>
                                                        </b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <Columns>
                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="10%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                ItemStyle-Width="1%">
                                                <HeaderTemplate>
                                                    <div style="float: left; display: none;">
                                                        <div style="float: left; display: none;">
                                                            <input id="checkAll_Email" runat="server" name="checkAll" type="checkbox" />
                                                        </div>
                                                        <div id="div_chkAdmin" style="float: left; padding: 2px 4px 2px 4px; border: outset 1px; width: 36px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <div style="float: left">
                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                type="checkbox" />
                                                                            <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Panel ID="pnl_chkImage" runat="server">
                                                                            <div style="float: left; padding: 5px 3px 0px 3px; display: block">
                                                                                <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                    onclick="show();" alt='' />
                                                                                <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                    onclick="hide();" alt='' />
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
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="Event" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="35%" HeaderText="Event" ItemStyle-Width="35%" SortExpression="Event"
                                                UniqueName="system" Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label2" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Event")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                            <asp:Label ID="lbl_Event" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Event", "{0}") %>'
                                                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.Event", "{0}") %>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="Subject" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="45%" HeaderText="Subject" ItemStyle-Width="45%" SortExpression="Subject"
                                                UniqueName="system" Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label3" runat="server"><%=objLanguage.GetLanguageConversion("Subject")%></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                            <asp:Label ID="lbl_Subject" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Subject", "{0}") %>'
                                                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.Subject", "{0}") %>'></asp:Label>
                                                        </div>
                                                        </div> </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="Enable" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="10%" HeaderText="Enabled" ItemStyle-Width="10%" SortExpression="Enabled"
                                                UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label4" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Enabled")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                            <asp:ImageButton ID="Img_Enabled1" CommandName="Enable" Text="Delete" UniqueName="ActionColumn"
                                                                runat="server"></asp:ImageButton>
                                                            <asp:HiddenField ID="hdn_Enable" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsActive", "{0}") %>' />
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <NoRecordsTemplate>
                                            <div style="padding: 0px 0px 0px 82px">
                                                <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                            </div>
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                    <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                        AllowDragToGroup="false">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <div style="clear: both; height: 10px;">
                </div>
                <div style="margin-left: 10px">
                    <asp:UpdatePanel ID="UpdatePanel_ApproverEmail" runat="server" UpdateMode="Conditional"
                        ChildrenAsTriggers="false">
                        <ContentTemplate>
                            <telerik:RadGrid ID="RadGrid_ApproverEmail" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                BorderWidth="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false"
                                PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="50" Width="750px"
                                ShowGroupPanel="false" ShowStatusBar="true" HeaderStyle-Font-Bold="true" OnItemDataBound="RadGrid_ApproverEmail_RowDataBound">
                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView AutoGenerateColumns="False" DataKeyNames="EmailToCustomerID" HorizontalAlign="NotSet"
                                    OverrideDataSourceControlSorting="true" CommandItemDisplay="Top" Width="100%">
                                    <CommandItemTemplate>
                                        <table class="rgCommandTable" border="0" style="width: 100%; float: left; margin-left: -8px; border-bottom-width: 0px">
                                            <tr>
                                                <td align="left">
                                                    <b>
                                                        <asp:Label ID="lbl_admin" runat="server" Text="Email to Approver"></asp:Label>
                                                    </b>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="10%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                            ItemStyle-Width="10%">
                                            <HeaderTemplate>
                                                <div style="float: left; display: none">
                                                    <div style="float: left; display: none;">
                                                        <%--<input id="checkAll_Email" runat="server" name="checkAll" type="checkbox" />--%>
                                                    </div>
                                                    <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                            <tr>
                                                                <td>
                                                                    <div style="float: left">
                                                                        <input id="checkAllAE" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                            type="checkbox" />
                                                                        <input id="hdnUPDOWNAE" runat="server" type="hidden" /></ItemTemplate>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div style="float: left; padding: 0px 0px 0px 1px">
                                                                        <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                            onclick="showpharse('manemails');"
                                                                            alt='' />
                                                                        <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                            onclick="hidephrase('manemails');" alt='' />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div style="clear: both;">
                                                    </div>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="padding-left: 2px; display: none">
                                                    <input id="checkBox_Email" runat="server" name="Id" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>' />
                                                    <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Event" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="35%" HeaderText="Event" ItemStyle-Width="35%" SortExpression="Event"
                                            UniqueName="system" Visible="true">
                                            <ItemTemplate>
                                                <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                    <%--<div style="float: left; width: 99%; overflow: hidden; height: 15px">--%>
                                                    <asp:Label ID="lbl_Event" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Event", "{0}") %>'></asp:Label>
                                                    <%-- </div>--%>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Subject" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="45%" HeaderText="Subject" ItemStyle-Width="45%" SortExpression="Subject"
                                            UniqueName="system" Visible="true">
                                            <ItemTemplate>
                                                <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                    <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                        <asp:Label ID="lbl_Subject" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Subject", "{0}") %>'></asp:Label>
                                                    </div>
                                                    </div> </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="Enable" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="5%" HeaderText="Enabled" ItemStyle-Width="5%" SortExpression="Enabled"
                                            UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                    <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                        <asp:ImageButton ID="Img_Enabled1" CommandName="Enable" UniqueName="ActionColumn"
                                                            runat="server"></asp:ImageButton>
                                                        <asp:HiddenField ID="hdn_Enable" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsActive", "{0}") %>' />
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <NoRecordsTemplate>
                                        <div style="padding: 0px 0px 0px 10px">
                                            No records found
                                        </div>
                                    </NoRecordsTemplate>
                                </MasterTableView>
                                <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                    AllowDragToGroup="false">
                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div style="clear: both; height: 10px;">
                </div>
                <div id="div_Grid" style="display: block; padding-left: 10px" runat="server">
                    <div>
                        <div id="div_popupAction" style="display: none; z-index: 999999; position: absolute; margin: 55px 0px 0px 8px"
                            onmouseover="show();" onmouseout="hide();">
                            <%--<telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1">--%>
                            <telerik:RadListBox runat="server" ID="RadListBox1" SelectionMode="Single" Width="80px"
                                OnSelectedIndexChanged="RadListBox1_SelectedIndexChanged" AutoPostBack="true">
                                <Items>
                                    <telerik:RadListBoxItem Text="Enable" Style="cursor: pointer;" onclick="CheckOne_new('enable');" />
                                    <telerik:RadListBoxItem Text="Disable" Style="cursor: pointer;" onclick="CheckOne_new('disable');" />
                                    <telerik:RadListBoxItem Text="Copy Email" Style="cursor: pointer;" onclick="CheckOne_new('copyemail')" />
                                    <%--onclick="CheckOne_new('copyemail');"--%>
                                    <%--onmouseover="popupAccountsShow();"--%>
                                </Items>
                            </telerik:RadListBox>
                            <%--</telerik:RadAjaxPanel>--%>
                            <asp:HiddenField ID="lblCOpy" runat="server" Value="" />
                        </div>
                    </div>
                    <div id="div2" style="display: block; margin-bottom: 5px;">
                        <asp:UpdatePanel ID="UpdatePanel_Email" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <telerik:RadGrid ID="RadGrid_Email" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                    BorderWidth="0" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false"
                                    PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="50" Width="750px"
                                    ShowGroupPanel="false" ShowStatusBar="true" HeaderStyle-Font-Bold="true" OnItemDataBound="RadGrid_Email_RowDataBound">
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" />
                                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="EmailToCustomerID" HorizontalAlign="NotSet"
                                        OverrideDataSourceControlSorting="true" CommandItemDisplay="Top" Width="100%">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%; margin-left: -8px; border-bottom-width: 0px">
                                                <tr>
                                                    <td align="left">
                                                        <b>
                                                            <asp:Label ID="lbl_admin" runat="server" Text="Email to customer"><%=objLanguage.GetLanguageConversion("Email_To_Customer")%></asp:Label>
                                                        </b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <Columns>
                                            <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="10%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                ItemStyle-Width="10%">
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div style="float: left; display: none;">
                                                            <input id="checkAll_Email" runat="server" name="checkAll" type="checkbox" />
                                                        </div>
                                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <div style="float: left">
                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                type="checkbox" />
                                                                            <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div style="float: left; padding: 5px 3px 0px 3px; margin-top: -3px;">
                                                                            <div id="div_img_actionShow" style="display: block; border: solid 0px Transparent; cursor: pointer;" onclick="show();">
                                                                                <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow" alt='' />
                                                                            </div>
                                                                            <div id="div_img_actionHide" style="display: none; border: solid 0px Transparent; cursor: pointer;" onclick="hide();">
                                                                                <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide" alt='' />
                                                                            </div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div style="clear: both;">
                                                        </div>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <input id="checkBox_Email" runat="server" style="margin-left: 8px;" name="Id" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>' />
                                                    <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="Event" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="35%" HeaderText="Event" ItemStyle-Width="35%" SortExpression="Event"
                                                UniqueName="system" Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label5" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Event") %>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                            <asp:Label ID="lbl_Event" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Event", "{0}") %>'
                                                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.Event", "{0}") %>'></asp:Label>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="Subject" HeaderStyle-HorizontalAlign="Left"
                                                HeaderStyle-Width="45%" HeaderText="Subject" ItemStyle-Width="45%" SortExpression="Subject"
                                                UniqueName="system" Visible="true">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label6" runat="server"><%=objLanguage.GetLanguageConversion("Subject") %></asp:Label>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                            <asp:Label ID="lbl_Subject" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Subject", "{0}") %>'
                                                                ToolTip='<%# DataBinder.Eval(Container, "DataItem.Subject", "{0}") %>'></asp:Label>
                                                        </div>
                                                        </div> </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn DataField="Enable" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="5%" HeaderText="Enabled" ItemStyle-Width="5%" SortExpression="Enabled"
                                                UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <div>
                                                        <asp:Label ID="Label7" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Enabled")%>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <a href="manage_email_edit.aspx?ID=<%# DataBinder.Eval(Container, "DataItem.EmailToCustomerID", "{0}") %>&amp;mode=edit">
                                                        <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                            <asp:ImageButton ID="Img_Enabled1" CommandName="Enable" UniqueName="ActionColumn"
                                                                runat="server"></asp:ImageButton>
                                                            <asp:HiddenField ID="hdn_Enable" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsActive", "{0}") %>' />
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <NoRecordsTemplate>
                                            <div style="padding: 0px 0px 0px 10px">
                                                <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                            </div>
                                        </NoRecordsTemplate>
                                    </MasterTableView>
                                    <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                        AllowDragToGroup="false">
                                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlEmail" runat="server">
        <script type="text/javascript" language="javascript">
            showDivPopupCenter('div_EmailaccountsList', '220');
        </script>
    </asp:Panel>
    <div id="div_pnlEmail" style="display: none;">
        <asp:Panel ID="CopyEmail" runat="server">
            <script type="text/javascript" language="javascript">
                showDivPopupCenter('div_EmailaccountsList', '220');
            </script>
        </asp:Panel>
    </div>
    <script type="text/javascript" language="javascript">

        var img_actionsShow = document.getElementById("div_img_actionShow");
        var img_actionsHide = document.getElementById("div_img_actionHide");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        var div_pnlEmail = document.getElementById("div_pnlEmail");
        //        function Show_accountListDiv() {
        //            showDivPopupCenter('div_accountsList', '200');
        //        }

        function Show_EmailaccountListDiv() {
            hidephrase();
            div_pnlEmail.style.display = 'block';
            showDivPopupCenter('div_EmailaccountsList', '220');
            ShowPopUpEmail();
            RadWinClose();
        }
        function show() {
            img_actionsShow.style.display = "none";
            img_actionsHide.style.display = "block";

            div_chk.style.border = "inset 1px";
            div_chk.style.background = "gray";

            div_popupAction.style.display = "block";
        }

        function hide() {
            img_actionsHide.style.display = "none";
            img_actionsShow.style.display = "block";

            div_chk.style.border = "outset 1px";
            div_chk.style.background = "";

            div_popupAction.style.display = "none";
        }

        function checkAll_new(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Email') != -1) {
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

        function CheckOne_new(val) {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Email') != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            hide();
            if (Number(Counter) == 0) {
                if (val == "enable")
                    alert("Please check at least one row to enable");
                if (val == "disable")
                    alert("Please check at least one row to disable");
                if (val == "copyemail")
                    alert("Please check at least one row to copy email");
                return false;
            }
            else {
                if (val == "enable")
                    return true;
                if (val == "disable")
                    return true;
                if (val == "copyemail") {
                    if (true) {
                        Show_EmailaccountListDiv();
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }

        function imgbtnIsEnable_ClientClick(val) {
            if (val == "enable")
                return true;
            if (val == "disable")
                return true;
            if (val == "copyemail")
                return true;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
