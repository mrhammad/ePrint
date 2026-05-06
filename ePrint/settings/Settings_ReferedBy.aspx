<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Settings_ReferedBy.aspx.cs" Inherits="ePrint.settings.Settings_ReferedBy" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/item/general.js" type="text/javascript"></script>
    <telerik:RadAjaxManager ID="RAM" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdCommissiontype">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdCommissiontype" LoadingPanelID="RALP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteReferedby">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdCommissiontype" LoadingPanelID="RALP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RALP" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
            margin-left: -3px;
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
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text="Settings: Referred By"><%=objLanguage.GetLanguageConversion("Settings_ReferredBy")%></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div align="left" style="width: 100%; margin-top: -6px" class="mis_header_panel">
                    <div id="">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div align="left" style="width: 100%; border: 0px solid red">
                            <div id="">
                                <asp:UpdatePanel ID="pnlgridAccountingCodes" ChildrenAsTriggers="false" UpdateMode="Conditional"
                                    RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <div id="div_Grid">
                                            <div id="div_popupAction" style="margin: 54px 0px 0px 9px;" onmouseover="show();"
                                                onmouseout="hide(); ">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <div style="width: 100%;">
                                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                                    <asp:LinkButton ID="btnDeleteReferedby" runat="server" Text="Delete Selected" OnClick="btnDeleteReferencedBy_OnClick"
                                                                        OnClientClick="javascript:return CallDelete();" Style="text-decoration: none;"
                                                                        ForeColor="#333333" Font-Size="11px" CausesValidation="false"></asp:LinkButton></div>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="div_Main" runat="server" align="left" style="width: 100%; border-top-color: White">
                                                <telerik:RadGrid ID="grdCommissiontype" runat="server" AutoGenerateColumns="false"
                                                    DataSourceID="AccountCodeDataSource" AllowAutomaticUpdates="false" Width="55%"
                                                    BorderWidth="0" GridLines="None" HeaderStyle-Font-Bold="true" PageSize="50" AllowAutomaticInserts="false"
                                                    AllowPaging="true" PagerStyle-AlwaysVisible="true" AllowAutomaticDeletes="false"
                                                    OnInsertCommand="grdCommissiontype_OnInsertCommand" OnUpdateCommand="grdCommissiontype_UpdateCommand"
                                                    OnItemDataBound="grdCommissiontype_ItemDataBound" OnItemCommand="grdCommissiontype_ItemCommand">
                                                    <MasterTableView CommandItemDisplay="Top" CommandItemStyle-BorderColor="White" DataKeyNames="ReferencedID"
                                                        InsertItemPageIndexAction="ShowItemOnFirstPage">
                                                        <%--Add  By Jagat On 31/July/2012--%>
                                                        <CommandItemTemplate>
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                                            Font-Underline="True"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                                    </td>
                                                                    <td align="right">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </CommandItemTemplate>
                                                        <%--End--%>
                                                        <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                                        <EditItemStyle></EditItemStyle>
                                                        <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                            <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                            <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                                            <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White" />
                                                            <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                            <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                            <EditColumn UniqueName="EditColumn">
                                                            </EditColumn>
                                                            <FormTemplate>
                                                                <table border="0" cellpadding="2" cellspacing="0" style="margin-left: 8px; margin-top: 4px;">
                                                                    <tr>
                                                                        <td style="width: 95%" class="bglabel">
                                                                            <div>
                                                                                <asp:Label ID="lbl_Name" runat="server" Text="Referred By:"><%=objLanguage.GetLanguageConversion("Referred_By")%></asp:Label><span
                                                                                    style="color: red"> *</span>
                                                                            </div>
                                                                        </td>
                                                                        <td align="left" style="padding-left: 7px" valign="top">
                                                                            <asp:TextBox ID="txt_ReferedByName" class='textboxnew' runat="server" Width="225px"
                                                                                MaxLength="200" Text='<%# Bind("Name") %>' SkinID="textPad" Style="float: left"></asp:TextBox>
                                                                            <asp:HiddenField ID="hdn_ReferencedID" Value='<%# Bind("ReferencedID") %>' runat="server" />
                                                                            <span>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_ReferedByName"
                                                                                    ErrorMessage="Please enter referred by" runat="server" SetFocusOnError="true"
                                                                                    ValidationGroup="grp" CssClass="RFV_Message" ForeColor="" Style="width: auto;
                                                                                    padding-left: 4px; padding-right: 4px; margin-left: 4px"><%=objLanguage.GetLanguageConversion("Please_Enter_Reffered_By")%>
                                                                                </asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 95%" class="bglabel">
                                                                            <div>
                                                                                <asp:Label ID="lbl_Commission" runat="server" Text="Commission:"><%=objLanguage.GetLanguageConversion("Commission")%></asp:Label>
                                                                                <span style="color: red">*</span>
                                                                            </div>
                                                                        </td>
                                                                        <td align="left" style="padding-left: 7px" valign="top">
                                                                            <asp:TextBox runat="server" ID="txt_CommValue" class='textboxnew' Width="40px" Text='<%# Bind("CommissionValue") %>'
                                                                                Style="text-align: right; float: left"></asp:TextBox>
                                                                            <span>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_CommValue"
                                                                                    ErrorMessage="Please enter commission" runat="server" SetFocusOnError="true"
                                                                                    ValidationGroup="grp" CssClass="RFV_Message" ForeColor="" Style="width: auto;
                                                                                    padding-left: 4px; padding-right: 4px; margin-left: 4px"><%=objLanguage.GetLanguageConversion("Please_Enter_Commission")%>
                                                                                </asp:RequiredFieldValidator>
                                                                            </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 95%" class="bglabel">
                                                                            <div>
                                                                                <asp:Label ID="lbl_Default" runat="server" Width="115px" Text="Referred By:"><%=objLanguage.GetLanguageConversion("Default")%></asp:Label>
                                                                            </div>
                                                                        </td>
                                                                        <td align="left" style="padding-left: 3px">
                                                                            <asp:CheckBox ID="chkDefault" runat="server" />
                                                                            <asp:HiddenField ID="hdnDefault" Value='<%# Bind( "IsDefault") %>' runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="padding: 5px 0px 10px 5px;">
                                                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                                                runat="server" Text='<%#objlang.GetValueOnLang("Cancel")%>' CommandName="Cancel"
                                                                                CausesValidation="false">
                                                                            </telerik:RadButton>
                                                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                                                                ValidationGroup="grp" runat="server" Text='<%#objlang.GetValueOnLang("Save")%>'
                                                                                CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                            </telerik:RadButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </FormTemplate>
                                                            <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                                        </EditFormSettings>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn ItemStyle-Width="5px">
                                                                <HeaderStyle Font-Bold="true" />
                                                                <HeaderTemplate>
                                                                    <div style="float: left">
                                                                        <div style="float: left; display: none;">
                                                                        </div>
                                                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                            -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                                            <table width="80%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                                <tr>
                                                                                    <td>
                                                                                        <div style="float: left">
                                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll(this);" type="checkbox" />
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
                                                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                                            value='<%# DataBinder.Eval(Container, "DataItem.ReferencedID", "{0}") %>' />
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                                                UniqueName="ReferencedID" SortExpression="ReferencedID">
                                                                <HeaderTemplate>
                                                                    <asp:Label ID="lblHeaderNameACode" runat="server"><%=objlang.GetLanguageConversion("Referred_By")%></asp:Label>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <a href="#">
                                                                        <div style="float: left; overflow: hidden; cursor: pointer;">
                                                                            <asp:Label ID="lblAccountCode" OnLoad="FuncCommissionType" runat="server" Text='<%#Eval("Name")%>'
                                                                                Style="cursor: pointer;"></asp:Label>
                                                                            <asp:HiddenField ID="hdnAccountingCodeID" runat="server" Value='<%#Eval("ReferencedID")%>' />
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Commission (%)" ItemStyle-Width="120px" HeaderStyle-Width="120px"
                                                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right">
                                                                <ItemTemplate>
                                                                    <a href="#">
                                                                        <div style="float: Right; overflow: hidden; cursor: pointer;">
                                                                            <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("CommissionValue")%>'
                                                                                Style="cursor: pointer;"></asp:Label>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn DataField="IsDefault" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-Width="10px" AllowFiltering="false" SortExpression="Enabled" UniqueName="system"
                                                                Visible="true" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.ReferencedID", "{0}") %>,'contact');">
                                                                        <div style="float: none; overflow: hidden; height: 18px;">
                                                                            <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                                            <center>
                                                                                <asp:ImageButton ID="img_Default" runat="server" CommandName="Set as default" CssClass="rollover"
                                                                                    Text="Set as default" CommandArgument='<%#Eval("ReferencedID")%>' OnCommand="setDefaultRefferedBy_OnClick">
                                                                                </asp:ImageButton></center>
                                                                        </div>
                                                                    </a>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="In Use" ItemStyle-Width="50px" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:Image runat="server" ID="img_InUse" />
                                                                        <asp:HiddenField ID="hdn_InUse" runat="server" Value='<%#Eval("InUsedCount")%>' />
                                                                    </center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Delete" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" Visible="true" CommandArgument='<%#Eval("ReferencedID")%>'
                                                                            OnClientClick="javascript:return imgbtnDelete_ClientClick();" OnCommand="imgbtnDelete_OnClick"
                                                                            ToolTip="delete" ImageUrl="~/Images/erase.png" /></center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <ClientSettings EnableRowHoverStyle="true">
                                                    </ClientSettings>
                                                    <ClientSettings ClientEvents-OnRowClick="RowDblClick" />
                                                </telerik:RadGrid>
                                            </div>
                                        </div>
                                        <div class="onlyEmpty">
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:ObjectDataSource ID="AccountCodeDataSource" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                                    SelectMethod="ClientReferencedByName_Select">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="Name" Type="string" SessionField="Name" DefaultValue="" />
                                    </SelectParameters>
                                    <SelectParameters>
                                        <asp:SessionParameter Name="CompanyID" Type="Int32" SessionField="CompanyID" DefaultValue="0" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdn_CommissionType" runat="server" Value="" />
    <script type="text/javascript">

        function imgbtnDelete_ClientClick() {
            return confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');
        }
        function CallDelete() {
            var ret = CheckOne_new();

            if (ret) {

                return true;

            }
            else {

                return false;
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
                alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>');
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');

            }
        }
        function checkAll(checkAllBox) {

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
        function ImgButtonErase_ClientClick() {
            if (confirm("Are you sure you want to delete this record?")) {

                return true;
            }
            else {
                return false;
            }
        }
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }
    </script>
    <script type="text/javascript">
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        function show() {
            img_actionsHide.style.display = "block";
            img_actionsShow.style.display = "none";

            div_chk.style.border = "inset 1px";
            div_chk.style.background = "#C5C5C5";

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
