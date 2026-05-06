<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tasksubject.aspx.cs" Inherits="ePrint.settings.tasksubject"   masterpagefile="~/Templates/settingpage.master" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="../js/Item/settingsjs.js?VN='<%=VersionNumber%>'"></script>
    <style type="text/css">
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
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
            border: 0px solid rgb(130, 130, 130);
        }
    </style>
    <div align="left" class="act_width100">
        <div style="clear: both;">
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div class="div_tasksub_margintop">
                <div align="left" class="div_tasksub_padding">
                    <div id="div_message" align="left">
                        <div class="div_msg_margin">
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
                            <telerik:AjaxSetting AjaxControlID="radgrdtasksubject">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radgrdtasksubject" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="radgrdtasksubject" LoadingPanelID="RadAjaxLoadingPanel1" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
                    <div id="div_popupAction" style="margin: 58px 0px 0px 9px;" onmouseover="show();"
                        onmouseout="hide(); ">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div class="act_width100">
                                        <div class="divDropdownlist div_tasksub_ddl">
                                            <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" OnClick="lnkDeleteStatus_OnClick"
                                                CommandName="Delete" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px"
                                                CausesValidation="false" OnClientClick="javascript:return CallDelete();"></asp:LinkButton></div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" ChildrenAsTriggers="false" UpdateMode="Conditional"
                        runat="server">
                        <ContentTemplate>
                            <telerik:RadGrid ID="radgrdtasksubject" Width="40%" GridLines="None" runat="server"
                                AllowAutomaticDeletes="True" ShowStatusBar="true" AllowAutomaticInserts="false"
                                PageSize="50" AllowAutomaticUpdates="false" AllowPaging="True" AutoGenerateColumns="False"
                                DataSourceID="SessionDataSource1" PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true"
                                OnInsertCommand="radgrdtasksubject_InsertCommand" OnItemDataBound="radgrdtasksubject_ItemDataBound"
                                OnItemCommand="radgrdtasksubject_ItemCommand" OnUpdateCommand="radgrdtasksubject_UpdateCommand"
                                AllowFilteringByColumn="true">
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView Width="100%" CommandItemSettings-RefreshText="" CommandItemSettings-ShowRefreshButton="false"
                                    CommandItemDisplay="Top" DataKeyNames="sampleSubjectId" DataSourceID="SessionDataSource1"
                                    HorizontalAlign="NotSet" AutoGenerateColumns="False" EnableNoRecordsTemplate="true"
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                    <NoRecordsTemplate>
                                        <div>
                                            No records to display</div>
                                    </NoRecordsTemplate>
                                    <CommandItemTemplate>
                                        <table class="rgCommandTable act_width100" border="0">
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                        Font-Underline="True"><%=objlang.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" class="grd_clrfilter"
                                                        runat="server" Text="Clear All Filters"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn UniqueName="Checkbox" AllowFiltering="false">
                                            <HeaderStyle Font-Bold="true" />
                                            <HeaderTemplate>
                                                <div class="div_floatleft">
                                                    <div class="div_floatleft show_hide">
                                                        <input id="Checkbox1" type="checkbox" onclick="checkAll(this);" runat="server" name="checkAll" />
                                                    </div>
                                                    <div id="div_chk" class="tasksub_div_chk">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                            <tr>
                                                                <td>
                                                                    <div class="div_floatleft">
                                                                        <input id="checkAll" runat="server" onclick="checkAll(this);" name="checkAll" type="checkbox" />
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <asp:Panel ID="pnl_chkImage" runat="server">
                                                                        <div class="tasksub_div_imgdisplay">
                                                                            <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" class="tasksub_imgarrowdown"
                                                                                onclick="show();" alt='' />
                                                                            <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" class="tasksub_imgarrowup"
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
                                                <div class="tasksub_div_paddingleft">
                                                    <input type="checkbox" runat="server" id="Id" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.sampleSubjectId", "{0}") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="sampleSubject" HeaderText="Subject" SortExpression="Subject"
                                            UniqueName="Subject" ColumnEditorID="GridTextBoxColumnEditor1" ItemStyle-Width="85%"
                                            AutoPostBackOnFilter="true">
                                            <HeaderStyle Font-Bold="true" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn DataField="IsDefault" HeaderStyle-HorizontalAlign="Center"
                                            AllowFiltering="false" HeaderStyle-Width="5%" HeaderText="Default" ItemStyle-Width="5%"
                                            UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <a href="javascript:void(0);">
                                                    <div class="tasksub_defaultimg">
                                                        <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                        <asp:ImageButton ID="img_Default" runat="server" CommandName="Set as default" CssClass="rollover"
                                                            Text="Set as default" CommandArgument='<%#Eval("sampleSubjectId")%>' OnCommand="setDefault_OnClick">
                                                        </asp:ImageButton>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                            HeaderText="Action" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%"
                                            ItemStyle-Width="10%" AllowFiltering="false">
                                            <HeaderTemplate>
                                                <div class="tasksub_action">
                                                    <asp:Label ID="Label1" Text="" runat="server"><%=objlang.GetLanguageConversion("Action") %></asp:Label></div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="tasksub_deleteimg">
                                                    <asp:ImageButton ID="imgbtnDelete" runat="server" ToolTip="Delete" ImageUrl="~/Images/erase.png"
                                                        OnCommand="imgbtnDelete_OnClick" OnClientClick="javascript:return imgbtnDelete_ClientClick();"
                                                        CommandArgument='<%#Eval("sampleSubjectId")%>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings ColumnNumber="2" EditFormType="Template" CaptionDataField="TaxName">
                                        <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                        <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                        <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                            Width="100%" />
                                        <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                        <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                        <EditColumn UniqueName="EditColumn">
                                        </EditColumn>
                                        <FormTemplate>
                                            <table border="0" cellpadding="2" class="act_width100">
                                                <tr>
                                                    <td valign="top">
                                                        <div class="bglabel" style="width: 100%;">
                                                            <%=objlang.GetLanguageConversion("Subject")%>&nbsp;<span style="color: Red">*</span>
                                                        </div>
                                                    </td>
                                                    <td valign="top">
                                                        <div class="tasksub_td_margin8">
                                                            <asp:HiddenField ID="hdnCategoryName" Value='<%# Bind("sampleSubject") %>' runat="server" />
                                                            <asp:HiddenField ID="hdnSubjectID" runat="server" Value='<%# Bind("sampleSubjectId") %>' />
                                                            <asp:TextBox ID="txtSubject" CssClass="textboxnew" Width="200px" Height="16px" runat="server"
                                                                Text='<%# Bind("sampleSubject") %>' Style="float: left">
                                                            </asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="requiredfieldvalidator1" runat="server" ControlToValidate="txtSubject"
                                                                ErrorMessage="Please Enter Call Purpose" CssClass="RFV_Message" ForeColor=""
                                                                Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px">
                                                            </asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="bglabel" style="width: 100%;">
                                                            <%=objlang.GetLanguageConversion("Default")%>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="tasksub_td_margin4">
                                                            <asp:CheckBox ID="chkDefault" runat="server" />
                                                            <asp:HiddenField ID="hdnDefault" runat="server" Value='<%# Bind("IsDefault") %>' />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td class="tasksub_td_padding8">
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="radbtnCancel"
                                                            runat="server" Text='<%#objlang.GetLanguageConversion("Cancel")%>' CommandName="Cancel"
                                                            CausesValidation="false">
                                                        </telerik:RadButton>
                                                        <span class="tasksub_spn_padding"></span>
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="radbtnSave"
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
                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                    </telerik:RadWindowManager>
                    <br />
                    <asp:ObjectDataSource ID="SessionDataSource1" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                        SelectMethod="Settings_TaskSubject_Select">
                        <SelectParameters>
                            <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                                Type="Int64" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var div_message = document.getElementById("div_message");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        var deleteconfirmation = '<%=objlang.GetLanguageConversion("Record_Delete_Confirmation")%>';
        var selectrow = '<%=objlang.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>';
        var deletealert = '<%=objlang.GetLanguageConversion("Delete_Confirmation_Alert")%>';

       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>