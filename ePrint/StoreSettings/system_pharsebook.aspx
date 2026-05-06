<%@ page language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="system_pharsebook.aspx.cs" Inherits="ePrint.StoreSettings.system_pharsebook" title="Settings: Phrase Book" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/StoreSettings/editabletemplate_menu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="divMain">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
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
            margin-left: -10px;
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
        .RadGrid_Default .rgAdd
        {
            display: none;
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
            <div class="mis_header_panel" style="padding-bottom: 0px; padding-top: 10px;">
                <div align="left" style="width: 50%;">
                    <div class="settings_align">
                        <div style="width: 100%; padding-bottom: 2px">
                            <div style="width: 100%; padding-top: 10px; margin-bottom: -10px;">
                                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <%--  <td valign="top" style="width: 60px;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                </td>--%>
                                <td valign="top">
                                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                        <script type="text/javascript">
                                            function RowDblClick(sender, eventArgs) {
                                                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                                //document.getElementById("helptext").style.display = 'block';
                                                //document.getElementById("helptext").style.display = 'block';
                                                document.getElementById("divContacts").style.display = 'none';
                                                document.getElementById("divDepartments").style.display = 'none';
                                                document.getElementById("divAddress").style.display = 'none';
                                            }
                                            function DisplyDiv(type) {
                                                debugger;
                                                if (type == "Contacts") {
                                                    document.getElementById("divContacts").style.display = 'block';
                                                    document.getElementById("divDepartments").style.display = 'none';
                                                    document.getElementById("divAddress").style.display = 'none';
                                                    //document.getElementById("helptext").style.display = 'none';
                                                }
                                                else if (type == "Departments") {
                                                    document.getElementById("divContacts").style.display = 'none';
                                                    document.getElementById("divDepartments").style.display = 'block';
                                                    document.getElementById("divAddress").style.display = 'none';
                                                    //document.getElementById("helptext").style.display = 'none';
                                                }
                                                else if (type == "Addresses") {
                                                    document.getElementById("divContacts").style.display = 'none';
                                                    document.getElementById("divDepartments").style.display = 'none';
                                                    document.getElementById("divAddress").style.display = 'block';
                                                    //document.getElementById("helptext").style.display = 'none';
                                                }
                                                else {
                                                    document.getElementById("divContacts").style.display = 'none';
                                                    document.getElementById("divDepartments").style.display = 'none';
                                                    document.getElementById("divAddress").style.display = 'none';
                                                    //document.getElementById("helptext").style.display = 'none';

                                                }
                                            }
                                        </script>
                                    </telerik:RadCodeBlock>
                                    <asp:Panel ID="pnlLeftSelection" runat="server">
                                        Please choose the options from the left hand panel to proceed.
                                    </asp:Panel>
                                    <div style="float: left">
                                    </div>
                                    <div style="padding-right: 40%; float: right">
                                    </div>
                                    <div id="div_popupAction" style="margin: 65px 0px 0px 9px;" onmouseover="show();"
                                        onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <div class="divDropdownlist" style="padding-bottom: 7px; margin-top: -12x; width: 130px;">
                                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete Selected" OnClick="lnkDelete_OnClick"
                                                                OnClientClick="javascript:return CallDelete();" ForeColor="#333333" Font-Size="11px"
                                                                CausesValidation="false" Style="text-decoration: none"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="Windows7" />
                                    <div style="padding-top: 7px">
                                        <telerik:RadGrid Width="100%" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                            BorderWidth="0" ShowStatusBar="true" AllowAutomaticInserts="True" PageSize="50"
                                            AllowAutomaticUpdates="True" PagerStyle-AlwaysVisible="true" AllowSorting="true"
                                            AllowPaging="True" OnItemUpdated="RadGrid1_ItemUpdated" AutoGenerateColumns="False"
                                            DataSourceID="SessionDataSource1" OnItemDataBound="radGrid1_ItemDataBound" OnUpdateCommand="RadGrid1_UpdateCommand"
                                            OnInsertCommand="RadGrid1_InsertCommand" OnDeleteCommand="RadGrid1_DeleteCommand"
                                            OnItemCreated="RadGrid1_ItemCreated" OnItemCommand="RadGrid1_OnItemCommand" HeaderStyle-Font-Bold="true"
                                            OnPageIndexChanged="RadGrid1_PazeIndexChanged" OnPageSizeChanged="RadGrid1_PazeSizeChanged">
                                            <MasterTableView CommandItemSettings-ShowRefreshButton="false" CommandItemSettings-RefreshText=""
                                                CommandItemDisplay="Top" DataKeyNames="PhraseBookID" DataSourceID="SessionDataSource1"
                                                HorizontalAlign="NotSet" AutoGenerateColumns="False">
                                                <EditItemStyle></EditItemStyle>
                                                <Columns>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                        AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                        <HeaderTemplate>
                                                            <div style="float: left">
                                                                <div style="float: left; display: none;">
                                                                    <input id="Checkbox1" type="checkbox" runat="server" name="checkAll" onclick="CheckAll(this);" />
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
                                                    <telerik:GridBoundColumn DataField="Title" HeaderText="Phrase Text" HeaderStyle-Width="57%"
                                                        ItemStyle-Width="77%" SortExpression="Title" UniqueName="Title" HeaderStyle-HorizontalAlign="left"
                                                        ItemStyle-HorizontalAlign="left">
                                                    </telerik:GridBoundColumn>
                                                    <telerik:GridTemplateColumn SortExpression="IsDefaultPhrase" HeaderText="Default Phrase"
                                                        HeaderStyle-Width="15%" ItemStyle-Width="10%" UniqueName="IsDefaultPhrase" DataType="System.Boolean"
                                                        DefaultInsertValue="False" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                                        Visible="false">
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%; display: block">
                                                                <asp:Label ID="lblIsDefaultPhrase" runat="server" Text='<%# Eval("DefaultPhrase") %>'></asp:Label></div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                                        HeaderText="Action" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="5%"
                                                        ItemStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <div style="margin-left: 0px;">
                                                                <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("PhraseBookID")%>'
                                                                    ToolTip="Delete" ImageUrl="~/Images/erase.png" OnCommand="imgbtnDelete_OnClick"
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
                                                        <table border="0" cellpadding="2" width="100%" style="margin-top: 4px; margin-bottom: 7px;">
                                                            <tr>
                                                                <td class="bglabel" style="width: 95%;">
                                                                    <asp:Label ID="Label1" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Option_Title")%></asp:Label>
                                                                    <span style="color: red;">*</span>
                                                                </td>
                                                                <td>
                                                                    <div>
                                                                        <%--  <telerik:RadTextBox ID="txtTitle" Width="350px" Style="margin-top: -2px;" runat="server"
                                                                            Text='<%# Bind("Title") %>'>
                                                                        </telerik:RadTextBox>--%>
                                                                        <asp:TextBox ID="txtTitle" Width="350px" Style="margin-top: -2px;" runat="server"
                                                                            Text='<%# Bind("Title") %>'></asp:TextBox>
                                                                    </div>
                                                                    <div>
                                                                        <asp:RequiredFieldValidator ID="requiredfieldvalidator2" runat="server" ControlToValidate="txtTitle"
                                                                            ErrorMessage="Please Enter Option Title" Display="Dynamic" SetFocusOnError="true"
                                                                            CssClass="RFV_Message" Style="width: auto; padding-left: 4px; padding-right: 4px"
                                                                            ForeColor=""></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="bglabel" style="width: 200px; margin-top: -2px;">
                                                                    <asp:Label ID="Label2" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Option_Type")%></asp:Label>
                                                                </td>
                                                                <td style="margin-top: -2px;">
                                                                    <asp:HiddenField ID="hdnType" runat="server" Value='<%# Bind("Type") %>' />
                                                                    <asp:DropDownList ID="ddlType" runat="server" CssClass="normalText" Width="208px"
                                                                        onchange="Javascript:SelectType(this.id);">
                                                                        <asp:ListItem Text="Fixed" Value="Fixed"></asp:ListItem>
                                                                        <asp:ListItem Text="Contacts" Value="Contacts"></asp:ListItem>
                                                                        <asp:ListItem Text="Departments" Value="Departments"></asp:ListItem>
                                                                        <asp:ListItem Text="Addresses" Value="Addresses"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                     
                                                             <tr id="trLabelSeparator">
                                                                <td class="bglabel" style="width: 200px; margin-top: -2px;">
                                                                    <asp:Label ID="lblLabelSeparator" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Label_Separator")%></asp:Label>
                                                                </td>
                                                                <td style="margin-top: -2px;">
                                                                    <asp:HiddenField ID="hdnLabelSeperator" runat="server" Value='<%# Bind("LabelSeparator") %>' />
                                                                    <asp:DropDownList ID="ddlLabelSeparator" runat="server" CssClass="normalText" Width="208px">
                                                                        <asp:ListItem Text="Colon Separator [ : ]" Value=":"></asp:ListItem>    
                                                                         <asp:ListItem Text="Hyphen Separator [ - ]" Value="-"></asp:ListItem>                                                                                                                                                                                                                            
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                               
                                                            <tr id="trTextSeparator">
                                                                <td class="bglabel" style="width: 200px; margin-top: -2px;">
                                                                    <asp:Label ID="Label3" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Text_Separator")%></asp:Label>
                                                                </td>
                                                                <td style="margin-top: -2px;">
                                                                    <asp:HiddenField ID="hdnSeperator" runat="server" Value='<%# Bind("LineSeparator") %>' />
                                                                    <asp:DropDownList ID="ddlSeperator" runat="server" CssClass="normalText" Width="208px">
                                                                        <asp:ListItem Text="Line Separator [ \ ]" Value="\"></asp:ListItem>
                                                                        <asp:ListItem Text="Comma Separator [ , ]" Value=","></asp:ListItem>
                                                                        <asp:ListItem Text="Pipe Separator [ | ] " Value="|"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="bglabel" style="width: 95%; margin-top: -2px;">
                                                                    <asp:Label ID="Lbl1" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Option_Text")%></asp:Label>
                                                                    <span style="color: red;">*</span>
                                                                </td>
                                                                <td style="margin-top: -2px; width: 80%;">
                                                                    <div>
                                                                        <%--   <telerik:RadTextBox ID="txtPhraseText" TextMode="MultiLine" Height="155px" Width="350px"
                                                                            Text='<%# Bind("PhraseText") %>' runat="server">
                                                                        </telerik:RadTextBox>--%>
                                                                        <asp:TextBox ID="txtPhraseText" TextMode="MultiLine" Height="155px" Width="350px"
                                                                            Text='<%# Bind("PhraseText") %>' runat="server"></asp:TextBox>
                                                                       
                                                                    </div>
                                                                      <div>
                                                                            <asp:Label ID="lblTagsHelpText" CssClass="smallgraytext" Style="vertical-align: top;"
                                                                                runat="server"><%=objLanguage.GetLanguageConversion("Please_refer_the_available_tags_below")%></asp:Label>
                                                                        </div>
                                                                    <div>
                                                                        <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtPhraseText"
                                                                            ErrorMessage="Please Enter Option Text" Display="Dynamic" SetFocusOnError="true"
                                                                            CssClass="RFV_Message" Style="width: auto; padding-left: 4px; padding-right: 4px"
                                                                            ForeColor=""></asp:RequiredFieldValidator>
                                                                    </div>
                                                                   
                                                                </td>
                                                            </tr>
                                                            <tr><td></td><td><b>Note: please do not insert a text separator after the final option.</b></td></tr>
                                                            <tr style="display: none;" valign="top">
                                                                <td>
                                                                    <asp:Label ID="Lbl12" Text="" Style="visibility: collapse;" runat="server"><%=objLanguage.GetLanguageConversion("Default_Phrase")%></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkedit" Visible="false" runat="server" Checked='<%# (DataBinder.Eval(Container.DataItem,"IsDefaultPhrase") is DBNull ?false:Eval("IsDefaultPhrase")) %>' />
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton8"
                                                                        OnClientClicking="CloseDiv" runat="server" Text="Cancel" CommandName="Cancel"
                                                                        CausesValidation="false">
                                                                    </telerik:RadButton>
                                                                    <span style="width: 10px">&nbsp;</span>
                                                                    <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton1"
                                                                        OnClientClicking="CloseDiv" runat="server" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
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
                                        </telerik:RadGrid></div>
                                    <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="200px" />
                                    <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor2" runat="server" TextBoxStyle-Width="150px" />
                                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                                    </telerik:RadWindowManager>
                                    <br />
                                    <asp:ObjectDataSource ID="SessionDataSource1" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                                        SelectMethod="settings_phrasebook_select" InsertMethod="settings_phrasebook_insert_drpdn"
                                        UpdateMethod="settings_phrasebook_update_drpdn" DeleteMethod="settings_phrasebook_delete"
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
                            <tr>
                                <td>
                                    <div id="divMain" runat="server" align="left" style="width: 85%; padding-left: 10px;">
                                        <%-- <div id="helptext" style="display: none">
                                            <span class="graytext">
                                                <%=objLanguage.GetLanguageConversion("Please_use_to_create_new_dropdown_option")%></span></div>--%>
                                        <div id="divContacts" style="display: none">
                                            <span class="HeaderText"></span>
                                            <div class="only5px">
                                            </div>
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("You_can_use_the_below_tags_to_dynamically_replace_the_values")%>
                                            </span>
                                            <div class="only5px">
                                            </div>
                                            <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr valign="top" height="23" id="trheader" runat="server">
                                                        <td class="bgcustomize" align="left" valign="top" width="1%">
                                                            <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                        </td>
                                                        <td class="bgcustomize navigatorpanel" width="30%">
                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Tag_Name")%>
                                                        </td>
                                                        <td class="bgcustomize navigatorpanel" width="60%">
                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Description")%>
                                                        </td>
                                                        <td class="bgcustomize" align="right" valign="top" width="1%">
                                                            <img src="../images/rt_tabnotch.gif" width="5" height="5/">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" width="100%">
                                                            <table class="borderWithoutTop" border="0" cellpadding="1" cellspacing="0" width="100%">
                                                                <tbody>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactTitle" size="30" value='[#Title#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_Title")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactFirstName" size="30" value='[#FirstName#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_FirstName")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Contact MiddleName" size="30" value='[#MiddleName#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_MiddleName")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactLastName" size="30" value='[#LastName#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_LastName")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactDepartment" size="30" value='[#Department#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_Department")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactJobTitle" size="30" value='[#JobTitle#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_JobTitle")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressLine1" size="30" value='[#AddressLine1#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_AddressLine1")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressLine2" size="30" value='[#AddressLine2#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_AddressLine2")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressCity" size="30" value='[#AddressCity#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_Address_City")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressState" size="30" value='[#AddressState#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_AddressState")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressCountry" size="30" value='[#AddressCountry#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_AddressCountry")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressPostCode" size="30" value='[#AddressPostCode#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_AddressPostCode")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressTelephone" size="30" value='[#AddressTelephone#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_AddressTelephone")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactAddressFax" size="30" value='[#AddressFax#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_AddressFax")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactPhone" size="30" value='[#Phone#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_Phone")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactMobile" size="30" value='[#Mobile#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_Mobile")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactEmail" size="30" value='[#Email#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_Email")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactFax" size="30" value='[#Fax#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Contact_Fax")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <%--Added By Naveen for 168--%>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField1" size="30" value='[#CustomField1#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName1" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField2" size="30" value='[#CustomField2#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName2" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField3" size="30" value='[#CustomField3#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName3" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField4" size="30" value='[#CustomField4#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName4" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField5" size="30" value='[#CustomField5#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName5" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField6" size="30" value='[#CustomField6#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName6" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField7" size="30" value='[#CustomField7#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName7" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField8" size="30" value='[#CustomField8#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName8" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField9" size="30" value='[#CustomField9#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName9" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField10" size="30" value='[#CustomField10#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName10" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField11" size="30" value='[#CustomField11#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName11" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField12" size="30" value='[#CustomField12#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName12" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField13" size="30" value='[#CustomField13#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName13" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField14" size="30" value='[#CustomField14#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName14" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="ContactCustomField15" size="30" value='[#CustomField15#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lblconScreenName15" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div id="divDepartments" style="display: none">
                                            <%-- <span class="HeaderText">
                                                <%=objLanguage.GetLanguageConversion("Custom_Tags_for_Supplier_RFQ")%></span>--%>
                                            <div class="only5px">
                                            </div>
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("You_can_use_the_below_tags_to_dynamically_replace_the_values")%></span>
                                            <div class="only5px">
                                            </div>
                                            <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr valign="top" height="23" id="trheaderSup" runat="server">
                                                        <td class="bgcustomize" align="left" valign="top" width="1%">
                                                            <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                        </td>
                                                        <td class="bgcustomize navigatorpanel" width="30%">
                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Tag_Name")%>
                                                        </td>
                                                        <td class="bgcustomize navigatorpanel" width="60%">
                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Description")%>
                                                        </td>
                                                        <td class="bgcustomize" align="right" valign="top" width="1%">
                                                            <img src="../images/rt_tabnotch.gif" width="5" height="5/">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" width="100%">
                                                            <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tbody>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentName" size="30" value='[#Name#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_Name")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentDeliveryAddress1" size="30" value='[#DeliveryAddress1#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryAddress1")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentDeliveryAddress2" size="30" value='[#DeliveryAddress2#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryAddress2")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department DeliveryCity" size="30" value='[#DeliveryCity#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryCity")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentDeliveryAddressState" size="30" value='[#DeliveryAddressState#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryAddressState")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department DeliveryAddressPostCode" size="30" value='[#DeliveryAddressPostCode#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryAddressPostCode")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentDeliveryAddressCountry" size="30" value='[#DeliveryAddressCountry#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryAddressCountry")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentDeliveryAddressTelephone" size="30" value='[#DeliveryAddressTelephone#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryAddressTelephone")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department DeliveryAddressFax" size="30" value='[#DeliveryAddressFax#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_DeliveryAddressFax")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department InvoiceAddressLine1" size="30" value='[#InvoiceAddressLine1#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoiceAddressLine1")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department InvoiceAddressLine2" size="30" value='[#InvoiceAddressLine2#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoiceAddressLine2")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department InvoiceCity" size="30" value='[#InvoiceCity#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoiceCity")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department InvoiceState" size="30" value='[#InvoiceState#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoiceState")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department InvoicePostCode" size="30" value='[#InvoicePostCode#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoicePostCode")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department InvoiceCountry" size="30" value='[#InvoiceCountry#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoiceCountry")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name=";Department InvoiceTelephone" size="30" value='[#InvoiceTelephone#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoiceTelephone")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Department InvoiceFax" size="30" value='[#InvoiceFax#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Department_InvoiceFax")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <%-- Added by Naveen for 168--%>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField1" size="30" value='[#CustomField1#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName1" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField2" size="30" value='[#CustomField2#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName2" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField3" size="30" value='[#CustomField3#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName3" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField4" size="30" value='[#CustomField4#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName4" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField5" size="30" value='[#CustomField5#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName5" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField6" size="30" value='[#CustomField6#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName6" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField7" size="30" value='[#CustomField7#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName7" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField8" size="30" value='[#CustomField8#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName8" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField9" size="30" value='[#CustomField9#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName9" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField10" size="30" value='[#CustomField10#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName10" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField11" size="30" value='[#CustomField11#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName11" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField12" size="30" value='[#CustomField12#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName12" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField13" size="30" value='[#CustomField13#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName13" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField14" size="30" value='[#CustomField14#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName14" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="DepartmentCustomField15" size="30" value='[#CustomField15#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" class="screenField" width="60%" valign="middle">
                                                                            <asp:Label ID="lbldeptScreenName15" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div id="divAddress" style="display: none">
                                            <%--<span class="HeaderText">
                                                <%=objLanguage.GetLanguageConversion("Custom_Tags_for_Invoice")%></span>--%>
                                            <div class="only5px">
                                            </div>
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("You_can_use_the_below_tags_to_dynamically_replace_the_values")%>
                                            </span>
                                            <div class="only5px">
                                            </div>
                                            <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr valign="top" height="23" id="trheaderInv" runat="server">
                                                        <td class="bgcustomize" align="left" valign="top" width="1%">
                                                            <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                        </td>
                                                        <td class="bgcustomize navigatorpanel" width="30%">
                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Tag_Name")%>
                                                        </td>
                                                        <td class="bgcustomize navigatorpanel" width="60%">
                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Description")%>
                                                        </td>
                                                        <td class="bgcustomize" align="right" valign="top" width="1%">
                                                            <img src="../images/rt_tabnotch.gif" width="5" height="5/">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" width="100%">
                                                            <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tbody>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adresslabel" size="30" value='[#label#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_label")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress AddressLine1" size="30" value='[#AddressLine1#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_AddressLine1")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress AddressLine2" size="30" value='[#AddressLine2#]'
                                                                                onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_AddressLine2")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress City" size="30" value='[#City#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_City")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress State" size="30" value='[#State#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_State")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress Zipcode" size="30" value='[#Zipcode#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_Zipcode")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress Country" size="30" value='[#Country#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_Country")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewTableRows" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress Telephone" size="30" value='[#Telephone#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_Telephone")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="NewAlternative" valign="top">
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="30%" nowrap="nowrap">
                                                                            <input type='text' name="Adress Fax" size="30" value='[#Fax#]' onclick="this.select();" />
                                                                        </td>
                                                                        <td style="overflow: hidden;" width="60%" valign="middle">
                                                                            &nbsp;<%=objLanguage.GetLanguageConversion("Address_Fax")%>
                                                                        </td>
                                                                        <td width="1%">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
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
    <script type="text/javascript">
        function DisplayTagsNone() {

            document.getElementById("divContacts").style.display = 'none';
            document.getElementById("divDepartments").style.display = 'none';
            document.getElementById("divAddress").style.display = 'none';
            document.getElementById("divInvoice").style.display = 'none';
        }
        function SelectType(id) {

            var ddlType = document.getElementById(id);
            var RPLC = id.replace('ddlType', 'ddlSeperator');
            var RPLC1 = id.replace('ddlType', 'lblTagsHelpText');

            if (ddlType.selectedIndex != 0) {
                if (ddlType.selectedIndex == 1) {
                    document.getElementById("divContacts").style.display = 'block';
                    document.getElementById("divDepartments").style.display = 'none';
                    document.getElementById("divAddress").style.display = 'none';
                    document.getElementById("trLabelSeparator").style.display = 'none';
                    document.getElementById("trTextSeparator").style.display = 'none';
                }
                else if (ddlType.selectedIndex == 2) {
                    document.getElementById("divContacts").style.display = 'none';
                    document.getElementById("divDepartments").style.display = 'block';
                    document.getElementById("divAddress").style.display = 'none';
                    document.getElementById("trLabelSeparator").style.display = 'none';
                    document.getElementById("trTextSeparator").style.display = 'none';
                }
                else if (ddlType.selectedIndex == 3) {
                    document.getElementById("divContacts").style.display = 'none';
                    document.getElementById("divDepartments").style.display = 'none';
                    document.getElementById("divAddress").style.display = 'block';
                    document.getElementById("trLabelSeparator").style.display = 'table-row';
                    document.getElementById("trTextSeparator").style.display = 'none';
                }
                document.getElementById(RPLC).disabled = true;
                document.getElementById(RPLC1).style.visibility = 'visible';
            }
            else {
                document.getElementById("divContacts").style.display = 'none';
                document.getElementById("divDepartments").style.display = 'none';
                document.getElementById("divAddress").style.display = 'none';
                document.getElementById("trLabelSeparator").style.display = 'table-row';
                document.getElementById("trTextSeparator").style.display = 'table-row';
                document.getElementById(RPLC).disabled = false;
                document.getElementById(RPLC1).style.visibility = 'hidden';
            }
        }
        function DisplySeparator(SeparatorValue) {

            if (SeparatorValue.trim().toLowerCase() == "fixed") {
                $('#trLabelSeparator').css('display', 'table-row');
                $('#trTextSeparator').css('display', 'table-row');
            }
            if (SeparatorValue.trim().toLowerCase() == "contacts" || SeparatorValue.trim().toLowerCase() == "departments") {
                $('#trLabelSeparator').css('display', 'none');
                $('#trTextSeparator').css('display', 'none');
            }
            if (SeparatorValue.trim().toLowerCase() == "addresses") {
                $('#trLabelSeparator').css('display', 'table-row');
                $('#trTextSeparator').css('display', 'none');
            }
        }
        function CloseDiv(sender, args) {

            document.getElementById("divContacts").style.display = 'none';
            document.getElementById("divDepartments").style.display = 'none';
            document.getElementById("divAddress").style.display = 'none';
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

