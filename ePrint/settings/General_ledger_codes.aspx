<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="General_ledger_codes.aspx.cs" Inherits="ePrint.settings.General_ledger_codes"  title="Accounting Codes" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>




<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="gridAccountingCodes">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridAccountingCodes" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteAccountcode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="gridAccountingCodes" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            margin-left: -9px;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
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
            margin-top: -8px;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <%--<div id="divFinishedGoods" style="width: 100%;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label ID="lblHeader" runat="server"><%=objlang.GetLanguageConversion("Settings")%> : <%=objlang.GetLanguageConversion("Accounting_Code")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="a" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="clear: both">
        </div>
        <div id="">
            <asp:UpdatePanel ID="pnlgridAccountingCodes" ChildrenAsTriggers="false" UpdateMode="Conditional"
                RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <div id="div_Grid">
                        <div id="div_popupAction" style="margin: 64px 0px 0px 21px;" onmouseover="show();"
                            onmouseout="hide(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%;">
                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="btnDeleteAccountcode" runat="server" Text="Delete Selected" OnClick="btnDeleteAccountcode_OnClick"
                                                    ForeColor="#333333" Font-Size="11px" Style="text-decoration: none" OnClientClick="javascript:return CallDelete();"><%=objlang.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div_Main" runat="server" align="left" style="width: 100%; margin-left: 2px;"
                            class="mis_header_panel">
                            <telerik:RadGrid ID="gridAccountingCodes" runat="server" AutoGenerateColumns="false"
                                BorderWidth="0" DataSourceID="AccountCodeDataSource" OnItemDataBound="gridAccountingCodes_ItemDataBound"
                                AllowAutomaticUpdates="false" Width="70%" OnUpdateCommand="gridAccountingCodes_UpdateCommand"
                                OnInsertCommand="gridAccountingCodes_InsertCommand" OnItemDeleted="gridAccountingCodes_ItemDeleted"
                                OnItemCommand="gridAccountingCodes_OnItemCommand" HeaderStyle-Font-Bold="true"
                                PageSize="50" AllowAutomaticInserts="false" AllowPaging="true" PagerStyle-AlwaysVisible="true"
                                AllowAutomaticDeletes="false" AllowFilteringByColumn="true">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Top" DataKeyNames="AccountCodeID" InsertItemPageIndexAction="ShowItemOnFirstPage">
                                    <%--Add  By Jagat On 31/July/2012--%>
                                    <CommandItemTemplate>
                                        <table class="rgCommandTable" border="0" style="width: 100%">
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="btnAdd" Text="" CommandName="InitInsert" runat="server" Font-Underline="True"><%=objlang.GetLanguageConversion("Add_New_record") %></asp:LinkButton>
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                        margin-right: -9px; float: right; cursor: pointer" runat="server" Text="Clear All Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
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
                                        <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                            Width="100%" />
                                        <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                        <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                        <EditColumn UniqueName="EditColumn">
                                        </EditColumn>
                                        <FormTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 8px; margin-top: 4px;
                                                margin-bottom: 9px;" width="100%">
                                                <tr>
                                                    <td class="bglabel width145px">
                                                        <%=objlang.GetLanguageConversion("Accounting_Code")%>
                                                        <span style="color: Red">*</span>
                                                    </td>
                                                    <td>
                                                        <asp:HiddenField ID="hdnAccountCodeID" Value='<%# Bind( "AccountCodeID") %>' runat="server" />
                                                        <asp:TextBox ID="txtAccountingCode" runat="server" Text='<%# Bind("Code") %>' Style="float: left"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldAccountingCode" ControlToValidate="txtAccountingCode"
                                                                runat="server" ForeColor="" CssClass="RFV_Message" Style="width: auto; padding-left: 4px;
                                                                padding-right: 4px; margin-left: 4px">   <%=objlang.GetLanguageConversion("Please_enter_Accounting_Code")%>
                                                            </asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 160px">
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Lbl_Note" Text="Accounting Code format must be identical to the code in the accounting package."
                                                            runat="server" CssClass="smallgraytext"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="bglabel width145px">
                                                        <%=objlang.GetLanguageConversion("Description")%>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox TextMode="MultiLine" runat="server" ID="txtDescription" Text='<%# Bind("Description") %>'></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <table border="0" style="padding-bottom: 10px; margin-left: -5px">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <%=objlang.GetLanguageConversion("Default")%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkRevenuCode" runat="server" Checked="true" Text="Revenue Codes" />
                                                                    <asp:HiddenField ID="hdnRevenueCode" runat="server" Value='<%#Eval("IsRevenueCode")%>' />
                                                                </td>
                                                                <td style="padding-top: 5px; padding-left: 10px">
                                                                    <asp:HiddenField ID="hdnIsDefault" runat="server" Value='<%#Eval("ISDefault")%>' />
                                                                    <asp:CheckBox ID="chkDefault" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="chkPurchaseCode" runat="server" Checked="true" Text="Purchase Codes" />
                                                                    <asp:HiddenField ID="hdnPurchaseCode" runat="server" Value='<%#Eval("IsPurchaseCode")%>' />
                                                                </td>
                                                                <td style="padding-top: 5px; padding-left: 10px">
                                                                    <asp:HiddenField ID="hdnIsPurchaseDefault" runat="server" Value='<%#Eval("IsDefaultPurchase")%>' />
                                                                    <asp:CheckBox ID="chkPurchaseDefault" runat="server" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <%--   <tr>
                                                    <td class="bglabel width145px">
                                                        <%=objlang.GetLanguageConversion("Revenue_Codes")%>
                                                    </td>
                                                    <td>
                                                        <asp:HiddenField ID="hdnIsDefault" runat="server" Value='<%#Eval("ISDefault")%>' />
                                                        <asp:CheckBox ID="chkDefault" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="bglabel width145px">
                                                        <%=objlang.GetLanguageConversion("Purchase_Codes")%>
                                                    </td>
                                                    <td>
                                                        <asp:HiddenField ID="hdnIsPurchaseDefault" runat="server" Value='<%#Eval("IsDefaultPurchase")%>' />
                                                        <asp:CheckBox ID="chkPurchaseDefault" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="bglabel width145px">
                                                        <%=objlang.GetLanguageConversion("Revenu_Code")%>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkRevenuCode" runat="server" Checked="true" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="bglabel width145px">
                                                        <%=objlang.GetLanguageConversion("Purchase_Code")%>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chkPurchaseCode" runat="server" Checked="true" />
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                            runat="server" Text='<%#objlang.GetValueOnLang("Cancel")%>' CommandName="Cancel"
                                                            CausesValidation="false">
                                                        </telerik:RadButton>
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                                            runat="server" Text='<%#objlang.GetValueOnLang("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </FormTemplate>
                                        <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                    </EditFormSettings>
                                    <Columns>
                                        <telerik:GridTemplateColumn AllowFiltering="false">
                                            <HeaderStyle Font-Bold="true" />
                                            <HeaderTemplate>
                                                <div style="float: left">
                                                    <div style="float: none; display: none;">
                                                        <input type="checkbox" id="Checkbox1" runat="server" name="checkAll" />
                                                    </div>
                                                    <div id="div_chk" style="float: none; border: outset 1px; -moz-border-radius: 5px;
                                                        -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
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
                                                <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                    value='<%# DataBinder.Eval(Container, "DataItem.AccountCodeID", "{0}") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            UniqueName="AccountCodeID" SortExpression="AccountCodeID" AutoPostBackOnFilter="true"
                                            DataField="Code">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblHeaderNameACode" runat="server"><%=objlang.GetLanguageConversion("Accounting_Code") %></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <a href="#">
                                                    <asp:Label ID="lblAccountCode" runat="server" Text='<%#Eval("Code")%>' Style="cursor: pointer;"></asp:Label></a>
                                                <asp:HiddenField ID="hdnAccountingCodeID" runat="server" Value='<%#Eval("AccountCodeID")%>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" DataField="Description" AutoPostBackOnFilter="true"
                                            UniqueName="Description">
                                            <ItemTemplate>
                                                <a href="#">
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>' Style="cursor: pointer;"></asp:Label></a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="In Use" HeaderStyle-Width="8%" ItemStyle-Width="8%"
                                            HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdn_InUse" runat="server" Value='<%#Eval("inUSe")%>' />
                                                <asp:Image runat="server" ID="img_InUse" />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Revenue Codes" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:Image runat="server" ID="img_RevenueCodes" />
                                                    <asp:HiddenField ID="hdn_RevenueCode" runat="server" Value='<%#Eval("IsRevenueCode")%>' />
                                                </center>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Estimate Default" HeaderStyle-Width="15%"
                                            ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            AllowFiltering="false">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:Image runat="server" ID="img_Default" />
                                                    <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("ISDefault")%>' />
                                                </center>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Purchase Codes" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                            HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:Image runat="server" ID="img_PurchaseCode" />
                                                    <asp:HiddenField ID="hdn_PurchaseCode" runat="server" Value='<%#Eval("IsPurchaseCode")%>' />
                                                </center>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Purchase Default" HeaderStyle-Width="15%"
                                            ItemStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Center"
                                            AllowFiltering="false">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:Image runat="server" ID="img_PurchaseDefault" />
                                                    <asp:HiddenField ID="hdn_PurchaseDefault" runat="server" Value='<%#Eval("ISDefaultPurchase")%>' />
                                                </center>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn AllowFiltering="false">
                                            <HeaderTemplate>
                                                <div>
                                                    <asp:Label ID="Label1" Text="n" runat="server" Visible="false"></asp:Label></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="margin-left: -15px; float: left">
                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" Visible="false" CommandArgument='<%#Eval("AccountCodeID")%>'
                                                        ToolTip="delete" ImageUrl="~/Images/erase.png" OnCommand="imgbtnDelete_OnClick"
                                                        OnClientClick="javascript:return imgbtnDelete_ClientClick();" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView><ClientSettings EnableRowHoverStyle="true">
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
                SelectMethod="Setting_accountingCode_SelectAll" DeleteMethod="Setting_accountingCode_Delete">
                <SelectParameters>
                    <asp:SessionParameter Name="companyID" Type="Int32" SessionField="CompanyID" DefaultValue="0" />
                </SelectParameters>
                <DeleteParameters>
                    <asp:Parameter Name="AccountCodeID" Type="Int32" />
                    <asp:SessionParameter Name="companyID" Type="Int32" SessionField="CompanyID" DefaultValue="0" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        </div>
        <%--  </div>--%>
    </div>
    <script type="text/javascript">
        function imgbtnDelete_ClientClick() {
            return confirm("Are you sure you want delete this record?");
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
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');

            }
        }
    </script>
    <script type="text/javascript">

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
        
    </script>
    <script type="text/javascript">
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
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
