<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="settings_warehouselocation_add.aspx.cs" Inherits="ePrint.settings.settings_warehouselocation_add" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdWarehouseLocation">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdWarehouseLocation" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            margin-left: -8px;
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
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <div class="navigatorpanel" align="left" style="display: none">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel" Text="Stock Location"><%=objLanguage.GetLanguageConversion("Stock_Location") %></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div style="overflow: auto" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel" style="margin-top: -10px">
            <asp:UpdatePanel ID="pnlgridAccountingCodes" ChildrenAsTriggers="false" UpdateMode="Conditional"
                RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <div id="div_Grid">
                        <telerik:RadGrid ID="grdWarehouseLocation" runat="server" OnNeedDataSource="grdWarehouseLocation_NeedDataSource"
                            BorderWidth="0" onrowdatabound="GridView1_RowDataBound" OnItemDataBound="RadGrid1_ItemDataBound"
                            AutoGenerateColumns="false" AllowAutomaticUpdates="false" AllowFilteringByColumn="true"
                            Width="85%" HeaderStyle-Font-Bold="true" AllowPaging="true" OnUpdateCommand="grdWarehouseLocation_UpdateCommand"
                            OnInsertCommand="grdWarehouseLocation_InsertCommand" AllowAutomaticInserts="false"
                            OnItemCommand="grdWarehouseLocation_OnItemCommand" PageSize="20" AllowAutomaticDeletes="false"
                            PagerStyle-AlwaysVisible="true">
                            <GroupingSettings CaseSensitive="false" />
                            <MasterTableView DataKeyNames="Locationid" CommandItemDisplay="Top">
                                <CommandItemTemplate>
                                    <table class="rgCommandTable" border="0" style="width: 100%">
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
                                <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                <EditItemStyle />
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
                                            margin-bottom: 9px;" width="65%">
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="lblLocationName" runat="server">
                            <%=objLanguage.GetLanguageConversion("Location_Name") %><span style="color:red">*</span></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtlocationName" MaxLength="100" Width="300px" runat="server" Text='<%# Bind( "LocationName") %>'
                                                        CssClass="textboxnew" AutoCompleteType="disabled" Style="float: left"></asp:TextBox>
                                                    <asp:HiddenField ID="hdnlocationid" Value='<%# Bind( "Locationid") %>' runat="server" />
                                                    <span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldlocationname" ControlToValidate="txtlocationName"
                                                            ErrorMessage='Please enter Location Name' runat="server" CssClass="RFV_Message"
                                                            Display="Dynamic" Style="padding-left: 4px; padding-right: 4px; width: auto;
                                                            margin-left: 3px" ForeColor=""><%=objLanguage.GetLanguageConversion("Please_enter_Location_name") %>
                                                        </asp:RequiredFieldValidator>
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="lbl_Address1" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Address1") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox Font-Size="11px" ID="txtaddress" runat="server" Rows="2" Text='<%# Bind( "Address") %>'
                                                        Width="300px" CssClass="textboxnew"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="lbl_Address3" runat="server" Text="City" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("City") %> </asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_city" runat="server" Text='<%# Bind( "City") %>' MaxLength="100"
                                                        Width="300px" CssClass="textboxnew"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="lbl_Address4" runat="server" Text="Suburb" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Suburb") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_suburb" runat="server" Text='<%# Bind( "State") %>' MaxLength="100"
                                                        Width="300px" CssClass="textboxnew"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="lbl_Address5" runat="server" Text="Post Code" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Post_Code") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_postCode" runat="server" Text='<%# Bind( "Zipcode") %>' Width="300px"
                                                        MaxLength="50" CssClass="textboxnew"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="Label42" runat="server" Text="Country" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Country") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlcountry" runat="server" CssClass="textboxnew" Width="307px">
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="hdncountry" runat="server" Value='<%# Bind("Country") %>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="Label43" runat="server" Text="Telephone" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Telephone") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txttelephone" runat="server" Text='<%# Bind("Telephone") %>' Width="300px"
                                                        MaxLength="60" CssClass="textboxnew"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bglabel" style="width: 88%">
                                                    <asp:Label ID="Label1" runat="server" Text="Default Location" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Default_Location") %></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="chkdefault" runat="server" />
                                                    <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <div style="display: inline; float: left">
                                                        <asp:Button ID="btncancel_address" Style="display: block; margin: 0px 10px 0px 0px"
                                                            runat="server" Text='<%# objLanguage.GetLanguageConversion("Cancel") %>' CausesValidation="false"
                                                            CommandName="Cancel" CssClass="button" /></div>
                                                    <div style="display: inline; float: left">
                                                        <asp:Button ID="btnsave" runat="server" Text='<%#objLanguage.GetLanguageConversion("Save") %>'
                                                            CssClass="button" Style="margin: 0px 10px 0px 0px" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>' />
                                                    </div>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </FormTemplate>
                                    <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                </EditFormSettings>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Location Name" HeaderStyle-HorizontalAlign="Left"
                                        AutoPostBackOnFilter="true" ItemStyle-Wrap="false" DataField="LocationName" UniqueName="LocationName"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%" HeaderStyle-Width="20%"
                                        FilterControlWidth="100">
                                        <ItemTemplate>
                                            <a href="#">
                                                <asp:Label ID="lblFieldName" runat="server" Text='<%#Eval("LocationName")%>'></asp:Label></a>
                                            <asp:HiddenField ID="hdnFieldName" runat="server" Value='<%#Eval("LocationName")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Addresss" HeaderStyle-HorizontalAlign="Left"
                                        AutoPostBackOnFilter="true" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left"
                                        ItemStyle-Width="40%" HeaderStyle-Width="40%" DataField="Address" UniqueName="Address"
                                        FilterControlWidth="100">
                                        <ItemTemplate>
                                            <div id="div_address" style="float: left; width: 100%; overflow: hidden; height: 16px;
                                                cursor: pointer; cursor: hand;">
                                                <asp:Label ID="lbl_Address" runat="server"></asp:Label>
                                                <asp:HiddenField ID="hdn_Address" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Address", "{0}") %>' />
                                                <asp:HiddenField ID="hdn_City" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.City", "{0}") %>' />
                                                <asp:HiddenField ID="hdn_Suburb" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.State", "{0}") %>' />
                                                <asp:HiddenField ID="hdn_PostCode" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.ZipCode", "{0}") %>' />
                                                <asp:HiddenField ID="hdn_Country" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Country", "{0}") %>' />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Telephone" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Width="15%" HeaderStyle-Width="15%" AutoPostBackOnFilter="true" ItemStyle-Wrap="false"
                                        ItemStyle-HorizontalAlign="Left" DataField="Telephone" UniqueName="Telephone"
                                        FilterControlWidth="100">
                                        <ItemTemplate>
                                            <a href="#">
                                                <asp:Label ID="lbltelephone" runat="server" Text='<%#Eval("Telephone")%>'></asp:Label>
                                            </a>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="In Use" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <center>
                                                <asp:Image runat="server" ID="img_InUse" />
                                                <asp:HiddenField ID="hdn_InUse" runat="server" Value='<%#Eval("Inuse")%>' />
                                            </center>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Default" ItemStyle-Width="8%" HeaderStyle-Width="8%"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                        <ItemTemplate>
                                            <center>
                                                <asp:Image runat="server" ID="img_Default" />
                                                <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("IsDefault")%>' />
                                            </center>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-Width="6%" HeaderStyle-Width="6%"
                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>
                                            <div>
                                                <asp:Label ID="Label1" Text="Action" runat="server"><%=objLanguage.GetLanguageConversion("Action") %></asp:Label></div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("Locationid")%>'
                                                    ToolTip="delete" OnCommand="imgbtnDelete_OnClick" OnClientClick="javascript:return window.confirm('Are you sure you want to delete this location?');"
                                                    ImageUrl="~/Images/erase.png" /></center>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings EnableRowHoverStyle="true">
                            </ClientSettings>
                            <ClientSettings ClientEvents-OnRowClick="RowDblClick" />
                        </telerik:RadGrid>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                <script type="text/javascript">
                    function RowDblClick(sender, eventArgs) {
                        sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                    }
                </script>
            </telerik:RadCodeBlock>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

