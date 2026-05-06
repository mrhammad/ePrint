<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="account_status.aspx.cs" Inherits="ePrint.settings.account_status" title="Account Status" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        }
    </style>
    <div align="left" style="width: 100%">
        <div class="navigatorpanel" style="display: none;">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"></asp:Label>
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
                <div align="left" style="width: 100%; margin-top: -2px" class="mis_header_panel">
                    <div id="">
                        <div align="left" style="width: 100%; margin-top: -6px;">
                            <div style="width: 60%">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                            <script type="text/javascript">
                                function RowDblClick(sender, eventArgs) {
                                    sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                }
                            </script>
                        </telerik:RadCodeBlock>
                        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                            <AjaxSettings>
                                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                        <telerik:AjaxUpdatedControl ControlID="Label1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                            </AjaxSettings>
                        </telerik:RadAjaxManager>
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
                        <div id="div_TotalRec" style="float: right; padding-right: 55%; padding-bottom: 3px">
                        </div>
                        <div id="div_popupAction" style="margin: 56px 0px 0px 9px;" onmouseover="show();"
                            onmouseout="hide(); ">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div style="width: 100%;">
                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" OnClick="lnkDeleteStatus_OnClick"
                                                    CommandName="Delete" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px"
                                                    OnClientClick="javascript:return CallDelete();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel2" ChildrenAsTriggers="false" UpdateMode="Conditional"
                            runat="server">
                            <ContentTemplate>
                                <telerik:RadGrid Width="40%" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                    BorderWidth="0" ShowStatusBar="true" AllowAutomaticInserts="false" PageSize="50"
                                    AllowAutomaticUpdates="false" AllowPaging="True" AutoGenerateColumns="False"
                                    DataSourceID="SessionDataSource1" PagerStyle-AlwaysVisible="true" OnItemDataBound="RadGrid1_ItemDataBound"
                                    HeaderStyle-Font-Bold="true" OnUpdateCommand="RadGrid1_UpdateCommand" OnInsertCommand="RadGrid1_InsertCommand"
                                    OnItemCommand="RadGrid1_OnItemCommand">
                                    <MasterTableView Width="100%" CommandItemSettings-RefreshText="" CommandItemSettings-ShowRefreshButton="false"
                                        CommandItemDisplay="Top" DataKeyNames="StatusID" DataSourceID="SessionDataSource1"
                                        HorizontalAlign="NotSet" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnFirstPage">
                                        <%--Add  By Jagat On 31/July/2012--%>
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%">
                                                <tr>
                                                    <td align="left">
                                                        <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                            Font-Underline="True"><%=objlang.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                    </td>
                                                    <td align="right">
                                                    </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <%--End--%>
                                        <Columns>
                                            <telerik:GridTemplateColumn ItemStyle-Width="20px" HeaderStyle-Width="20px">
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div style="float: left; display: none;">
                                                            <input id="Checkbox1" type="checkbox" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                        </div>
                                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                            -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                            <table width="80%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <div style="float: left">
                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
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
                                                        <input type="checkbox" runat="server" id="Id" name="Id" onclick="CheckChanged();"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.StatusID", "{0}") %>' />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="StatusTitle" HeaderText="Status" SortExpression="StatusTitle"
                                                HeaderStyle-Width="350px" ItemStyle-Width="350px" UniqueName="TaxName" ColumnEditorID="GridTextBoxColumnEditor1">
                                                <HeaderStyle Font-Bold="true" />
                                            </telerik:GridBoundColumn>
                                            <%--By Jagat On 06-July-2012--%>
                                            <telerik:GridTemplateColumn DataField="IsDefault" HeaderStyle-HorizontalAlign="Center"
                                                HeaderStyle-Width="80px" ItemStyle-Width="80px" AllowFiltering="false" HeaderText="Default"
                                                UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.StatusID", "{0}") %>,'contact');">
                                                        <div style="float: none; width: 100%; overflow: hidden; height: 18px;">
                                                            <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                            <center>
                                                                <asp:ImageButton ID="img_Default" runat="server" CommandName="Set as default" CssClass="rollover"
                                                                    Text="Set as default" CommandArgument='<%#Eval("StatusID")%>' OnCommand="setDefault_OnClick">
                                                                </asp:ImageButton></center>
                                                        </div>
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                                HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                    <div>
                                                        <center>
                                                            <asp:Label ID="Label1" Text="" runat="server"><%=objlang.GetLanguageConversion("Action") %></asp:Label></center>
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <center>
                                                        <div>
                                                            <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("StatusID")%>'
                                                                ToolTip="delete" ImageUrl="~/Images/erase.png" OnCommand="imgbtnDelete_OnClick"
                                                                OnClientClick="javascript:return imgbtnDelete_ClientClick();" />
                                                    </center>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                        <EditFormSettings ColumnNumber="2" EditFormType="Template" CaptionDataField="TaxName">
                                            <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                            <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                            <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="0" BackColor="White"
                                                Width="100%" />
                                            <FormTableStyle CellSpacing="0" CellPadding="0" Height="10px" BackColor="White" />
                                            <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                            <EditColumn UniqueName="EditColumn">
                                            </EditColumn>
                                            <FormTemplate>
                                                <table border="0" cellpadding="0" width="100%" style="margin: 5px">
                                                    <tr>
                                                        <td>
                                                            <div class="bglabel" style="width: 100%; margin: 0px">
                                                                <%=objlang.GetLanguageConversion("Status")%>&nbsp;<span style="color: Red">*</span>
                                                            </div>
                                                        </td>
                                                        <td style="padding-left: 13px">
                                                            <asp:HiddenField ID="hdnCategoryName" Value='<%# Bind( "StatusTitle") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnStatusID" runat="server" Value='<%# Bind( "StatusID") %>' />
                                                            <asp:TextBox ID="txtStautsTitle" class='textboxnew' Width="250px" runat="server"
                                                                Text='<%# Bind("StatusTitle") %>' Style="float: left"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtStautsTitle"
                                                                ErrorMessage="Please Enter Status" CssClass="RFV_Message" ForeColor="" Style="width: auto;
                                                                padding-left: 4px; padding-right: 4px; margin-left: 4px"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="bglabel" style="width: 100%; margin: 0px">
                                                                <%=objlang.GetLanguageConversion("Default")%>
                                                            </div>
                                                        </td>
                                                        <td style="padding-left: 10px">
                                                            <asp:CheckBox ID="chkDefault" runat="server" />
                                                            <asp:HiddenField ID="hdnDefault" runat="server" Value='<%# Bind( "IsDefault") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td style="padding-left: 16px; padding-top: 5px;">
                                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton8"
                                                                runat="server" Text='<%#objlang.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                                CausesValidation="false">
                                                            </telerik:RadButton>
                                                            <span style="padding-left: 5px"></span>
                                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton1"
                                                                runat="server" Text='<%#objlang.GetLanguageConversion("Save")%>' CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                            </telerik:RadButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FormTemplate>
                                            <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                        </EditFormSettings>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true">
                                        <KeyboardNavigationSettings AllowSubmitOnEnter="true" />
                                        <ClientEvents OnRowClick="RowDblClick" />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="200px" />
                        <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor2" runat="server" TextBoxStyle-Width="150px" />
                        <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                        </telerik:RadWindowManager>
                        <br />
                        <asp:ObjectDataSource ID="SessionDataSource1" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                            SelectMethod="settings_accountstatus_select">
                            <SelectParameters>
                                <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                                    Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <div class="only5px"></div>
        <span class="smallgraytext"><%=objlang.GetLanguageConversion("Account_Status_Note")%></span>
                <div class="only5px"></div>
                </div>
            </div>
        </div>
    </div>
    <%--By Jagat On 11-July-2012--%>
    <script type="text/javascript">
        function EnterOnUpdate(e) {
            if (typeof e == 'undefined' || window.event) { e = window.event; }
            if (e.keyCode == 13) {

                document.getElementById('ctl00_ContentPlaceHolder1_RadGrid1_ctl00_ctl02_ctl03_RadButton1').click();
                return false;
            }

            else {
                validate();
                return false;
            }
        }
    
    
    </script>
    <%--End--%>
    <script type="text/javascript" language="javascript">
        function imgbtnDelete_ClientClick() {
            return confirm('<%=objlang.GetLanguageConversion("Record_Delete_Confirmation")%>');
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
                alert('<%=objlang.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>');
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');

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
</asp:Content>
