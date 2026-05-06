<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="system_pharsebook.aspx.cs" Inherits="ePrint.settings.system_pharsebook" title="Settings: Phrase Book" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
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
            text-decoration: underline;
            margin-left: -9px;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
            margin-top: -8px;
        }
        .RadGrid_Default .rgAdd
        {
            display: none;
        }
        
        .RadGrid_Default .rgCommandTable
        {
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
                            <div align="left" style="float: left; width: 100%" nowrap="nowrap">
                                <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"></asp:Label>
                                <asp:Label ID="lblphrase" runat="server" Text="SASA" Visible="false" Style="display: block;"></asp:Label>
                                <asp:HiddenField runat="server" ID="hdn" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div>
                <div align="left" style="width: 100%;" class="mis_header_panel">
                    <div id="">
                        <div style="width: 100%; padding-bottom: 2px">
                            <div style="width: 100%;">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td valign="top" style="width: 60px;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                </td>
                                <td valign="top" style="padding-left: 10px; margin-top: -10px">
                                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                        <script type="text/javascript">
                                            function RowDblClick(sender, eventArgs) {
                                                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                            }
                                        </script>
                                    </telerik:RadCodeBlock>
                                    <asp:Panel ID="pnlLeftSelection" runat="server">
                                        Please choose the options from the left hand panel to proceed.
                                    </asp:Panel>
                                    <div style="padding-right: 40%; float: right">
                                    </div>
                                    <div id="div_popupAction" style="margin: 72px 0px 0px 9px;" onmouseover="show();"
                                        onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%; margin-top: -25px;">
                                                        <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete Selected" OnClick="lnkDelete_OnClick"
                                                                OnClientClick="javascript:return CallDelete();" ForeColor="#333333" Font-Size="11px"
                                                                CausesValidation="false" Style="text-decoration: none"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="Windows7" />
                                    <telerik:RadGrid Width="70%" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                        BorderWidth="0" ShowStatusBar="true" AllowAutomaticInserts="True" PageSize="50"
                                        AllowAutomaticUpdates="True" PagerStyle-AlwaysVisible="true" AllowSorting="true"
                                        AllowPaging="True" OnItemUpdated="RadGrid1_ItemUpdated" AutoGenerateColumns="False"
                                        DataSourceID="SessionDataSource1" OnItemDataBound="radGrid1_ItemDataBound" OnUpdateCommand="RadGrid1_UpdateCommand"
                                        OnInsertCommand="RadGrid1_InsertCommand" OnDeleteCommand="RadGrid1_DeleteCommand"
                                        OnItemCommand="RadGrid1_OnItemCommand" OnItemCreated="RadGrid1_ItemCreated" HeaderStyle-Font-Bold="true"
                                        OnPageIndexChanged="RadGrid1_PazeIndexChanged" OnPageSizeChanged="RadGrid1_PazeSizeChanged">
                                        <MasterTableView CommandItemSettings-ShowRefreshButton="false" CommandItemSettings-RefreshText=""
                                            CommandItemDisplay="Top" DataKeyNames="PhraseBookID" DataSourceID="SessionDataSource1"
                                            HorizontalAlign="NotSet" AutoGenerateColumns="False" InsertItemPageIndexAction="ShowItemOnFirstPage">
                                            <CommandItemSettings AddNewRecordText="Add New Record" />
                                            <EditItemStyle></EditItemStyle>
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                                <input type="checkbox" runat="server" name="checkAll" onclick="CheckAll(this);" />
                                                            </div>
                                                            <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
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
                                                            <input type="checkbox" runat="server" id="Id" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.PhraseBookID", "{0}") %>'
                                                                onclick="CheckChanged();" />
                                                            <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="PhraseText" HeaderText="Phrase Text" SortExpression="PhraseText"
                                                    HeaderStyle-Width="500px" UniqueName="PhraseText" HeaderStyle-HorizontalAlign="left"
                                                    ItemStyle-HorizontalAlign="left">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn SortExpression="IsDefaultPhrase" HeaderText="Default Phrase"
                                                    UniqueName="IsDefaultPhrase" DataType="System.Boolean" DefaultInsertValue="False"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                                    <ItemTemplate>
                                                        <div style="display: block">
                                                            <center>
                                                                <asp:Label ID="lblIsDefaultPhrase" runat="server" Text='<%# Eval("DefaultPhrase") %>'></asp:Label></center>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                                    HeaderText="Action" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div>
                                                            <center>
                                                                <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("PhraseBookID")%>'
                                                                    ToolTip="Delete" ImageUrl="~/Images/erase.png" OnCommand="imgbtnDelete_OnClick"
                                                                    OnClientClick="javascript:return imgbtnDelete_ClientClick();" /></center>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                                <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                                    Width="100%" />
                                                <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                <EditColumn ButtonType="PushButton" UpdateText="Update" UniqueName="EditCommandColumn1"
                                                    CancelText="Cancel">
                                                </EditColumn>
                                                <FormTemplate>
                                                    <table border="0" cellpadding="2" width="100%" style="margin-top: 2px; margin-bottom: 7px;">
                                                        <tr>
                                                            <td style="float: left; width: 200px; margin-top: 2px; vertical-align: top;" class="bglabel">
                                                                <asp:Label ID="Lbl1" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Phrase_Text") %></asp:Label>
                                                                <span style="color: Red">*</span>
                                                            </td>
                                                            <td align="left" valign="top" style="margin-left: -10px">
                                                                <asp:TextBox ID="txtPhraseText" TextMode="MultiLine" Height="95px" Width="500px"
                                                                    Text='<%# Bind("PhraseText") %>' runat="server" SkinID="textPad">
                                                                </asp:TextBox>
                                                                <br />
                                                                <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtPhraseText"
                                                                    ErrorMessage="Please Enter Phrase Text " CssClass="RFV_Message" Style="width: auto;
                                                                    padding-left: 4px; padding-right: 4px;" ForeColor=""></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top" style="vertical-align: top;">
                                                            <td style="float: left; width: 200px" class="bglabel" align="left">
                                                                <asp:Label ID="Lbl12" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Default_Phrase")%></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkedit" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"IsDefaultPhrase") is DBNull ?false:Eval("IsDefaultPhrase")) %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 100px">
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton8"
                                                                    runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">
                                                                </telerik:RadButton>
                                                                <span style="width: 10px">&nbsp;</span>
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton1"
                                                                    runat="server" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                                <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true">
                                            <ClientEvents OnRowClick="RowDblClick" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                    <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="200px" />
                                    <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor2" runat="server" TextBoxStyle-Width="150px" />
                                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                                    </telerik:RadWindowManager>
                                    <br />
                                    <asp:ObjectDataSource ID="SessionDataSource1" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                                        SelectMethod="settings_phrasebook_select" InsertMethod="settings_phrasebook_insert"
                                        UpdateMethod="settings_phrasebook_update" DeleteMethod="settings_phrasebook_delete"
                                        OnInserted="ObjDS_Inserted" OnUpdated="ObjDS_Updated">
                                        <UpdateParameters>
                                            <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                                                Type="Int32" />
                                            <asp:Parameter Name="PhraseBookID" Type="Int32" />
                                            <asp:Parameter Name="EmailTemplateType" Type="String" DefaultValue="estimate" />
                                        </UpdateParameters>
                                        <DeleteParameters>
                                            <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                                                Type="Int32" />
                                            <asp:Parameter Name="PhraseBookID" Type="Int32" />
                                        </DeleteParameters>
                                    </asp:ObjectDataSource>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function CallDelete() {
            var ret = CheckOne();
            if (ret) {
                CheckGrid();
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
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');
            }
        }</script>
    <asp:Panel ID="pnlest" runat="server" Visible="false">
        <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>" type="text/javascript"
            language="javascript"></script>
        <script type="text/javascript">


            estimate('block');
            function txtFocus(TextBoxID) {
                document.getElementById(TextBoxID).focus() = true;
            }

        </script>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <script type="text/javascript">
            job('block');
            function txtFocus(TextBoxID) {
                document.getElementById(TextBoxID).focus() = true;
            }

        </script>
    </asp:Panel>
    <script>

        var type = getQuerystring('type');
        var subtype = type.substring(0, 1);
        if (subtype == 'e') {
            estimate('none');

            job('none');
            invoice('none');
            purchase('none');
            printbroker('none');
            delivery('none');
            email('none');
            edit_temp('none');
        }
        else if (subtype == 'j') {
            job('block');
            estimate('block');

            invoice('none');
            purchase('none');
            printbroker('none');
            delivery('none');
            email('none');
            edit_temp('none');
        }
        else if (subtype == 'i') {
            invoice('block');
            estimate('block');
            job('none');

            purchase('none');
            printbroker('none');
            delivery('none');
            email('none');
            edit_temp('none');
        }
        else if (subtype == 'p') {
            purchase('block');
            estimate('block');
            job('none');
            invoice('none');

            printbroker('none');
            delivery('none');
            email('none');
            edit_temp('none');
        }
        else if (subtype == 'd') {
            delivery('block');
            estimate('block');
            job('none');
            invoice('none');
            purchase('none');
            printbroker('none');
            email('none');
            edit_temp('none');

        }
        else if (subtype == 'o') {
            printbroker('block');
            estimate('block');
            job('none');
            invoice('none');
            purchase('none');
            delivery('none');
            email('none');
            edit_temp('none');
        }
        else if (subtype == 'm') {
            email('block');
            estimate('block');
            job('none');
            invoice('none');
            purchase('none');
            printbroker('none');
            delivery('none');
            edit_temp('none');
        }
        else if (subtype == 't') {
            email('none');
            estimate('block');
            job('none');
            invoice('none');
            purchase('none');
            printbroker('none');
            delivery('none');
            edit_temp('block');
        }
        else {
            estimate('block');
            job('none');
            invoice('none');
            purchase('none');
            printbroker('none');
            delivery('none');
            email('none');
            edit_temp('none');
        }

        function imgbtnDelete_ClientClick() {

            return confirm("Are you sure you want delete this record?");
        }



        function getQuerystring(key, default_) {
            if (default_ == null) default_ = "";
            key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
            var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
            var qs = regex.exec(window.location.href);
            if (qs == null)
                return default_;
            else
                return qs[1];
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
