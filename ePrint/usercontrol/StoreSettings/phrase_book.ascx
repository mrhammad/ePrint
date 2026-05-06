<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="phrase_book.ascx.cs" Inherits="ePrint.usercontrol.StoreSettings.phrase_book" %>

<%@ Register Src="~/usercontrol/StoreSettings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadGrid_Email">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_Email" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGrid_ApproverEmail">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid_ApproverEmail" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadGrid1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<style>
    .reContentArea
    {
        font-family: Arial !important;
        font-size: 14px !important;
    }
    
    .reContentArea table td
    {
        font-size: 14px !important;
    }
    
    .Default.RadEditor .reContentCell
    {
        border: 1px solid #DADADA;
        height: 205px;
    }
    
    
    .RadGrid_Default .rgCommandRow
    {
        background: none;
    }
    .RadGrid_Default .rgAdd
    {
        display: none;
    }
    .RadGrid_Default .rgCommandRow a
    {
        color: #10357F;
        text-decoration: underline;
        margin-left: -10px;
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
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" SkinID="Windows7" runat="server" />
<div align="left" style="width: 100%">
    <div class="navigatorpanel" style="display: none;">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left; width: 100%" nowrap="nowrap" runat="server"
                            id="divOtherHeader">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel"></asp:Label>
                            <asp:Label ID="lblphrase" runat="server" Text="SASA" Visible="false" Style="display: block;"></asp:Label>
                            <asp:Label ID="lbl_selectAccount1" runat="server" Text=""></asp:Label>&nbsp; <a id="A2"
                                href="javascript:Show_accountListDiv();" style="color: White; text-decoration: underline"
                                runat="server">
                                <asp:Label ID="Label2" runat="server" Text="Change"></asp:Label>
                            </a>
                            <asp:HiddenField runat="server" ID="hdn" />
                        </div>
                        <div align="left" style="float: left;" nowrap="nowrap" runat="server" id="divEmailsHeader">
                            <span class="navigatorpanel">
                                <%=objLanguage.GetLanguageConversion("eStore_Settings_Panel") %>:&nbsp;<%=objLanguage.GetLanguageConversion("Manage_Emails") %>&nbsp;
                                <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                    href="javascript:Show_accountListDiv();" style="color: White; text-decoration: underline"
                                    runat="server">
                                    <asp:Label ID="lbl_change" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                </a></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div id="divnoaccount" class="divno_account" runat="server">
        <asp:Label ID="lblnoaccount" runat="server"><%=objLanguage.GetLanguageConversion("Customer_Select_Alert")%> </asp:Label>
    </div>
    <div id="content" runat="server">
        <div class="">
            <div align="left" style="width: 100%;">
                <div class="manageedit">
                    <div style="width: 100%;">
                        <div style="width: 100%;">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <table cellpadding="0" cellspacing="0" border="0" width="100% ;">
                        <tr>
                            <td valign="top" style="width: 60px;">
                                <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                            </td>
                            <td valign="top" style="padding-left: 10px; margin-top: -12px">
                                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                    <script type="text/javascript">
                                        function RowDblClick(sender, eventArgs) {
                                            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                        }
                                    </script>
                                </telerik:RadCodeBlock>
                                <div style="display: none">
                                    <asp:Button ID="lnkDelete" runat="server" Text="Delete" OnClientClick="javascript:return CallDelete();"
                                        CausesValidation="false" Visible="false" class="button"></asp:Button>
                                </div>
                                <div style="padding-right: 40%; float: right">
                                </div>
                                <div id="div_popupAction_Del" onmouseover="showpharse('login');" onmouseout="hidephrase('login');">
                                    <telerik:RadListBox runat="server" ID="RadListBox2" SelectionMode="Single" Width="80px"
                                        AutoPostBack="true" OnSelectedIndexChanged="RadListBox2_SelectedIndexChanged">
                                        <Items>
                                            <telerik:RadListBoxItem Text="Delete" onclick="CheckOne_new('del')" />
                                        </Items>
                                    </telerik:RadListBox>
                                </div>
                                <div runat="server" id="divPhraseBook" style="margin-top: -8px">
                                    <telerik:RadGrid Width="65%" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="False"
                                        BorderWidth="0" ShowStatusBar="true" AllowAutomaticInserts="False" PageSize="50"
                                        AllowAutomaticUpdates="False" PagerStyle-AlwaysVisible="true" AllowSorting="true"
                                        AllowPaging="True" AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" OnItemUpdated="RadGrid1_ItemUpdated"
                                        OnItemDataBound="radGrid1_ItemDataBound" OnUpdateCommand="RadGrid1_UpdateCommand"
                                        OnInsertCommand="RadGrid1_InsertCommand" OnPageIndexChanged="RadGrid1_PazeIndexChanged"
                                        OnPageSizeChanged="RadGrid1_PazeSizeChanged" OnItemCreated="RadGrid1_ItemCreated"
                                        OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="RadGrid1_OnItemCommand">
                                        <MasterTableView CommandItemSettings-ShowRefreshButton="false" CommandItemSettings-RefreshText=""
                                            CommandItemDisplay="Top" DataKeyNames="PhraseBookID" HorizontalAlign="NotSet"
                                            AutoGenerateColumns="False">
                                            <CommandItemSettings AddNewRecordText="Add New Record" />
                                            <EditItemStyle></EditItemStyle>
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                                <%-- <input id="checkAll_Email" runat="server" name="checkAll" type="checkbox" />--%>
                                                            </div>
                                                            <div id="div_chk_Del" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                -webkit-border-radius: 5px; -ms-border-radius: 5px;">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                    <tr>
                                                                        <td>
                                                                            <div style="float: left">
                                                                                <input type="checkbox" id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);" />
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                                <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow_Del" style="display: block;
                                                                                    border: solid 0px Transparent; cursor: pointer;" onclick="showpharse('login');"
                                                                                    alt='' />
                                                                                <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide_Del" style="display: none;
                                                                                    border: solid 0px Transparent; cursor: pointer;" onclick="hidephrase('login');"
                                                                                    alt='' />
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
                                                        <div style="padding-left: 2px">
                                                            <input type="checkbox" runat="server" id="checkBox_Email" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.PhraseBookID", "{0}") %>'
                                                                onclick="CheckChanged_New();" />
                                                        </div>
                                                        <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="PhraseText" HeaderText="Phrase Text" HeaderStyle-Width="57%"
                                                    ItemStyle-Width="77%" SortExpression="PhraseText" UniqueName="PhraseText" HeaderStyle-HorizontalAlign="left"
                                                    ItemStyle-HorizontalAlign="Left">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn SortExpression="IsDefaultPhrase" HeaderText="Default Phrase"
                                                    HeaderStyle-Width="30%" ItemStyle-Width="30%" UniqueName="IsDefaultPhrase" DataType="System.Boolean"
                                                    DefaultInsertValue="False" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <div style="float: left; width: 99%; display: block">
                                                            <asp:Label ID="lblIsDefaultPhrase" runat="server" Text='<%# Eval("DefaultPhrase") %>'></asp:Label></div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                                    HeaderText="Action" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="5%"
                                                    ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <div style="margin-left: -6px; float: right">
                                                            <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("PhraseBookID")%>'
                                                                ToolTip="delete" ImageUrl="~/Images/erase.png" OnCommand="RadGrid1_DeleteCommand"
                                                                OnClientClick="javascript:return imgbtnDelete_ClientClick();" /></div>
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
                                                    <table border="0" cellpadding="2" width="100%" style="margin-top: 4px; margin-bottom: 7px;
                                                        height: auto;">
                                                        <tr>
                                                            <td style="float: left; vertical-align: top; width: 100px" class="bglabel">
                                                                <asp:Label ID="Lbl1" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Phrase_Text") %> :</asp:Label>
                                                                <span style="padding-left: 2px; color: Red;">*</span>
                                                            </td>
                                                            <td style="vertical-align: top; height: 205px">
                                                                <%--   <telerik:RadTextBox ID="txtPhraseText" TextMode="MultiLine" Height="95px" Width="500px"
                                                                    Text='<%# Bind("PhraseText") %>' runat="server">
                                                                </telerik:RadTextBox>--%>
                                                                <asp:Label ID="lblcnt" runat="server" Text='<%# Bind("PhraseText") %>' Visible="false"></asp:Label>
                                                                <telerik:RadEditor ID="txtPhraseText" runat="server" Width="600px" Height="205px"
                                                                    EditModes="Design,Html" OnClientLoad="OnClientLoad" ContentAreaMode="Iframe"
                                                                    ContentFilters="MakeUrlsAbsolute">
                                                                    <Tools>
                                                                        <telerik:EditorToolGroup>
                                                                            <telerik:EditorTool Name="Bold"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="Italic"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="Underline"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="LinkManager"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="Unlink"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="FontName"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="RealFontSize"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="ForeColor"></telerik:EditorTool>
                                                                            <telerik:EditorTool Name="BackColor"></telerik:EditorTool>
                                                                        </telerik:EditorToolGroup>
                                                                    </Tools>
                                                                    <FontNames>
                                                                        <telerik:EditorFont Value="Arial" />
                                                                        <telerik:EditorFont Value="Arial Narrow" />
                                                                        <telerik:EditorFont Value="Arial Black" />
                                                                        <telerik:EditorFont Value="Calibri" />
                                                                        <telerik:EditorFont Value="Century Gothic" />
                                                                        <telerik:EditorFont Value="Comic Sans MS" />
                                                                        <telerik:EditorFont Value="Helvetica" />
                                                                        <telerik:EditorFont Value="sans-serif" />
                                                                        <telerik:EditorFont Value="Times New Roman" />
                                                                        <telerik:EditorFont Value="Trebuchet Ms" />
                                                                        <telerik:EditorFont Value="Verdana" />
                                                                    </FontNames>
                                                                </telerik:RadEditor>
                                                                <div>
                                                                    <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtPhraseText"
                                                                        CssClass="RFV_Message" Style="width: auto; padding-left: 4px; padding-right: 4px"
                                                                        ErrorMessage="* Please Enter Phrase Text " ForeColor=""><%=objLanguage.GetLanguageConversion("Please_Enter_Phrase_Text")%> </asp:RequiredFieldValidator>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td style="float: left; width: 100px" align="left" class="bglabel">
                                                                <asp:Label ID="Lbl12" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Default_Phrase") %> :</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="chkedit" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"IsDefaultPhrase") is DBNull ?false:Eval("IsDefaultPhrase")) %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton8"
                                                                    runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">
                                                                </telerik:RadButton>
                                                                <span style="width: 10px">&nbsp;</span>
                                                                <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton1"
                                                                    runat="server" Text="Save" CommandArgument='<%#Eval("PhraseBookID")%>' CommandName='<%#(Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                </telerik:RadButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblnote" runat="server" CssClass="smallerfontgrey" Text="Note: Please use [TickBox] to display tickbox in login page"></asp:Label>
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
                                </div>
                                <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="200px" />
                                <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor2" runat="server" TextBoxStyle-Width="150px" />
                                <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                                </telerik:RadWindowManager>
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    function CheckChanged_New() {
        var frm = document.forms[0];
        var boolAllChecked;
        boolAllChecked = true;

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkBox_Email') != -1) {
                if (e.checked == false) {
                    boolAllChecked = false;
                    break;
                }
            }
        }

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_Email') != -1) {
                if (boolAllChecked == false) {
                    e.checked = false;
                    //alert(e.name);
                }
                else
                    e.checked = true;
                break;
            }
        }
    }

    function OnClientLoad(editor, eventArgs) {
        editor.get_contentArea().style.fontFamily = 'Helvetica'
        editor.get_contentArea().style.fontSize = '13px'
        //var tool = editor.getToolByName("RealFontSize"); tool.set_value("13px");
        //var fonttool = editor.getToolByName("FontName"); fonttool.set_value("Helvetica, sans-serif");
    }
</script>

