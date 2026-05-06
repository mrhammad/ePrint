<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="taxrate.aspx.cs" Inherits="ePrint.settings.taxrate" title="Taxes Rates" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>




<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../App_Themes/justfortest.css" rel="stylesheet" type="text/css" />
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
        <style>
            .RadGrid_Default .rgCommandRow
            {
                background: none;
            }
            .RadGrid_Default .rgCommandRow a
            {
                color: #10357F;
                text-decoration: none;
                margin-left: -4px;
            }
            .RadGrid_Default .rgCommandCell
            {
                border: none;
            }
            .RadGrid_Default .rgHeader
            {
                border-top: 1px solid #828282;
                border-bottom: 1px solid #828282;
            }
            .RadGrid_Default
            {
                outline: none;
            }

            .status-color-box {
    width: 10px; /* Adjust the width as needed */
    height: 10px; /* Adjust the height as needed */
    border: 1px solid #ccc; /* Optional: Add a border if desired */
    display: inline-block; /* Make sure it displays as a box */
}


        </style>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div style="margin-top: -18px; margin-left: -8px">
                <div align="left" style="width: 100%; padding-bottom: 25px;" class="mis_header_panel">
                    <div id="">
                        <div style="width: 60%; padding-top: 20px;">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                        </telerik:RadCodeBlock>
                        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                            <AjaxSettings>
                                <telerik:AjaxSetting AjaxControlID="RadGrid1">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="GridStatus" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="GridStatus">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="GridStatus" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                                <telerik:AjaxSetting AjaxControlID="lnkDeleteTax">
                                    <UpdatedControls>
                                        <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                    </UpdatedControls>
                                </telerik:AjaxSetting>
                            </AjaxSettings>
                        </telerik:RadAjaxManager>
                        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Skin="Default" SkinID="Default"
                            runat="server" />
                        <div id="ds00" style="display: block;">
                        </div>
                        <div id="div_Load" align="left" style="display: none" class="loading_new">
                            <UC:Loading ID="ucLoading" runat="server" />
                        </div>
                        <asp:Panel ID="panel2" runat="server">
                            <div style="float: left">
                            </div>
                            <div style="float: left; width: 10px">
                                &nbsp;
                            </div>
                            <div id="div_TotalRec" style="float: right; padding-right: 60%;">
                            </div>
                            <div class="only5px">
                            </div>
                            <div>
                                <div id="div_popupAction" style="margin: 47px 0px 0px 19px;" onmouseover="show();"
                                    onmouseout="hide(); ">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div style="width: 100%;">
                                                    <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 100px;
                                                        border: 1px; border-style: solid; border-color: Gray;">
                                                        <asp:LinkButton ID="lnkDeleteTax" runat="server" Text="Delete Selected" OnClick="lnkDeleteTax_OnClick"
                                                            ForeColor="#333333" Font-Size="11px" Style="text-decoration: none;" OnClientClick="javascript:return CallDelete();">
                                                            <%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div align="left" style="width: 100%; padding-bottom: 25px;" class="mis_header_panel">
                                <telerik:RadGrid ID="RadGrid1" runat="server" AllowAutomaticDeletes="false" Width="55%"
                                    ShowStatusBar="true" AllowAutomaticInserts="True" PageSize="50" AllowAutomaticUpdates="True"
                                    BorderWidth="0" AllowPaging="True" OnPageIndexChanged="RadGrid1_PageIndexChanged"
                                    OnPageSizeChanged="RadGrid1_PageSizeChanged" ClientSettings-AllowRowsDragDrop="true"
                                    AutoGenerateColumns="False" DataSourceID="SessionDataSource1" OnItemUpdated="RadGrid1_ItemUpdated"
                                    OnItemDataBound="radGrid1_ItemDataBound" PagerStyle-AlwaysVisible="true" OnUpdateCommand="RadGrid1_UpdateCommand"
                                    OnInsertCommand="RadGrid1_InsertCommand" OnItemCreated="RadGrid1_ItemCreated"
                                    OnDataBound="RadGrid1_DataBound" Style="margin-top: -16px;" OnItemCommand="RadGrid1_OnItemCommand">
                                    <PagerStyle Mode="NextPrevAndNumeric" />
                                    <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="taxID" DataSourceID="SessionDataSource1"
                                        HorizontalAlign="NotSet" AutoGenerateColumns="False" CommandItemSettings-RefreshText=""
                                        CommandItemSettings-ShowRefreshButton="false" InsertItemPageIndexAction="ShowItemOnFirstPage">
                                        <%--Add  By Jagat On 31/July/2012--%>
                                        <CommandItemTemplate>
                                            <table>
                                                <tr>
                                                    <td align="left">
                                                        <asp:LinkButton ID="btnAdd" Text="Add New Record" CommandName="InitInsert" runat="server"
                                                            Font-Underline="True">
                                                    <%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                    </td>
                                                    <td align="right">
                                                    </td>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <%--End--%>
                                        <EditFormSettings ColumnNumber="2" EditFormType="Template" CaptionDataField="TaxName"
                                            CaptionFormatString="Edit Tax Rate of {0}">
                                            <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                            <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                            <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" BackColor="White"
                                                Width="60%" />
                                            <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                            <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                            <EditColumn UniqueName="EditColumn">
                                            </EditColumn>
                                            <FormTemplate>
                                                <table border="0" cellpadding="4px" cellspacing="4px" width="100%" id="a">
                                                    <tr>
                                                        <td>
                                                            <%--Tax Name:--%>
                                                            <div class="bglabel" style="width: 98%;">
                                                                <%=objlang.GetLanguageConversion("Tax_Name")%><span style="color: Red"> *</span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <telerik:RadTextBox ID="txtTaxName" Width="200px" runat="server" Text='<%# Bind("TaxName") %>'
                                                                    Style="border-top: silver 1px solid; border-right: #737373 2px solid; border-left: silver 1px solid;
                                                                    border-bottom: #737373 1px solid; padding-left: 4px; padding-top: 2px; padding-bottom: 2px;
                                                                    margin: 0px 0px 0px 0px; font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: #000000; width: 175px; vertical-align: middle; float: left">
                                                                </telerik:RadTextBox>
                                                                <span style="color: Red">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="" ControlToValidate="txtTaxName"
                                                                        ErrorMessage=" Enter Tax Name" runat="server" CssClass="RFV_Message" Style="width: auto;
                                                                        padding-left: 4px; padding-right: 4px; margin-left: 4px">
                                                                    </asp:RequiredFieldValidator></span>
                                                            </div>
                                                        </td>
                                                    </tr>

                                                    <%-- start --%>

                                                    <tr>
                                                        <td>
                                                            <%--Tax Name:--%>
                                                            <div class="bglabel" style="width: 98%;">
                                                                Alias
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div>
                                                                <telerik:RadTextBox ID="Alias" Width="200px" runat="server" Text='<%# Bind("Alias") %>'
                                                                    Style="border-top: silver 1px solid; border-right: #737373 2px solid; border-left: silver 1px solid;
                                                                    border-bottom: #737373 1px solid; padding-left: 4px; padding-top: 2px; padding-bottom: 2px;
                                                                    margin: 0px 0px 0px 0px; font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                    font-size: 11px; color: #000000; width: 175px; vertical-align: middle; float: left">
                                                                </telerik:RadTextBox>
                                                            </div>
                                                        </td>
                                                    </tr>

                                                    <%-- end --%>

                                                    <tr>
                                                        <td>
                                                            <div class="bglabel" style="width: 98%; margin-top: -10px;">
                                                                <%=objlang.GetLanguageConversion("Tax_Rate")%><span style="color: Red"> *</span>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: -10px;">
                                                                <span>
                                                                    <telerik:RadNumericTextBox runat="server" ID="tbTaxRate" Style="text-align: right;
                                                                        border-top: silver 1px solid; border-right: #737373 2px solid; border-left: silver 1px solid;
                                                                        border-bottom: #737373 1px solid; padding-left: 4px; padding-top: 2px; padding-bottom: 2px;
                                                                        margin: 0px 0px 0px 0px; font-family: Verdana, Arial, Helvetica, sans-serif;
                                                                        float: left; font-size: 11px; color: #000000; vertical-align: middle;" Width="60px"
                                                                        DbValue='<%# Bind("TaxRate") %>'>
                                                                        <NumberFormat AllowRounding="true" DecimalDigits="4" />
                                                                    </telerik:RadNumericTextBox><span style="color: Red"><asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator1" ControlToValidate="tbTaxRate" ErrorMessage=" Please enter tax rate"
                                                                        runat="server" ForeColor="" CssClass="RFV_Message" Style="width: auto; padding-left: 4px;
                                                                        padding-right: 4px; margin-left: 4px">
                                                                    </asp:RequiredFieldValidator></span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                        </td>
                                                        <td>
                                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                                runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">
                                                            </telerik:RadButton>
                                                            <span style="padding-left: 5px"></span>
                                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton1"
                                                                runat="server" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                            </telerik:RadButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </FormTemplate>
                                            <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                        </EditFormSettings>
                                        <Columns>
                                            <telerik:GridTemplateColumn ItemStyle-Width="20px" UniqueName="Select">
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderTemplate>
                                                    <div style="float: left">
                                                        <div style="float: left; display: none">
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
                                                        <input type="checkbox" runat="server" id="Id1" onclick="CheckChanged();" name="Id"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.TaxID", "{0}") %>' />
                                                        <%-- changebgColor(this);--is not defined--%>
                                                        <input type="hidden" id="hdnUPDOWN1" runat="server" />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <%--ItemTemPlate Change By Jagat On 14/July/2012--%>
                                            <telerik:GridTemplateColumn SortExpression="TaxName" HeaderText="Tax Name" UniqueName="TemplateColumn"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemTemplate>
                                                    <div style="float: left; overflow: hidden; cursor: pointer">
                                                        <asp:Label runat="server" ID="lblTaxName" Text='<%#Eval("TaxName") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <%-- start --%>

                                            <telerik:GridTemplateColumn SortExpression="Alias" HeaderText="Tax Name" UniqueName="TemplateColumn"
                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemTemplate>
                                                    <div style="float: left; overflow: hidden; cursor: pointer">
                                                        <asp:Label runat="server" ID="lblAlias" Text='<%#Eval("Alias") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>

                                            <%-- end --%>
                                            <telerik:GridTemplateColumn SortExpression="TaxRate" HeaderText="Tax Rate(%)" UniqueName="TemplateColumn"
                                                ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                                <HeaderStyle Font-Bold="true" />
                                                <ItemTemplate>
                                                    <div style="float: right; overflow: hidden; cursor: pointer">
                                                        <asp:Label runat="server" ID="lblTaxRate" Text='<%# Eval("TaxRate") %>'></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                                HeaderText="Action" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10px"
                                                ItemStyle-Width="10px">
                                                <HeaderStyle Font-Bold="true" />
                                                <HeaderTemplate>
                                                    <div style="float: none">
                                                        <asp:Label Text="Action" runat="server"><%=objlang.GetLanguageConversion("Action") %></asp:Label></div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <center>
                                                            <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("TaxID")%>'
                                                                ToolTip="delete" ImageUrl="~/Images/erase.png" OnCommand="imgbtnDelete_OnClick"
                                                                OnClientClick="javascript:return imgbtnDelete_ClientClick();" />
                                                            <asp:HiddenField ID="IsDefault" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                        </center>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true" >
                                        <%--AllowKeyboardNavigation="true"
                                        <KeyboardNavigationSettings AllowSubmitOnEnter="true" />--%>
                                        <ClientEvents OnRowClick="RowDblClick" />
                                    </ClientSettings>
                                    <%--End--%>
                                </telerik:RadGrid></div>
                            <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="200px" />
                            <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor2" runat="server" TextBoxStyle-Width="150px" />
                            <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                            </telerik:RadWindowManager>
                            <asp:ObjectDataSource ID="SessionDataSource1" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                                SelectMethod="settings_taxrate_select" UpdateMethod="settings_taxrate_update_new"
                                InsertMethod="settings_taxrate_insert_new" OnInserted="ObjDS_Inserted" OnUpdated="ObjDS_Updated"
                                DeleteMethod="settings_taxrate_delete_new">
                                <InsertParameters>
                                    <asp:Parameter Name="taxRate" Type="Decimal" />
                                </InsertParameters>
                                <UpdateParameters>
                                    <asp:Parameter Name="taxID" Type="Int32" />
                                    <asp:Parameter Name="taxRate" Type="Decimal" />
                                </UpdateParameters>
                            </asp:ObjectDataSource>
                        </asp:Panel>
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="Div2">
                                <div style="float: left; width: 800px; padding-top: 20px; margin-left: 10px">
                                    <div id="div_btnUpDown" style="float: left; display: block; padding-bottom: 3px;">
                                        <asp:Button ID="btnUpDown" runat="server" CssClass="button" Text="Save Order" CausesValidation="false"
                                            Visible="false" OnClick="btnUpDown_OnClick" />
                                    </div>
                                    <div id="div_btnUpDownprocess" style="display: none">
                                        <img src="../images/radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div class="only5px" style="margin-top: -25px">
                                </div>
                                <div align="left" style="width: 90%;">
                                    <div id="div_popupAction" style="margin: 49px 0px 0px 21px;" onmouseover="show();"
                                        onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                            <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" OnClick="lnkDeleteStatus_OnClick"
                                                                Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CallDelete();"
                                                                CausesValidation="false"><%=objlang.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div align="left" style="width: 90%; margin-top: -10px;" class="mis_header_panel">
                                    <telerik:RadGrid ID="GridStatus" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        BorderWidth="0" onrowupdating="GridStatus_OnRowUpdating" onrowdeleting="GridStatus_OnRowDeleting"
                                        PageSize="50" OnItemDataBound="GridStatus_OnRowDataBound" OnNeedDataSource="grdPendingOrders_NeedDataSource"
                                        OnUpdateCommand="GridStatus_UpdateCommand" OnRowDrop="grdPendingOrders_RowDrop"
                                        Width="100%" PagerStyle-AlwaysVisible="true" OnInsertCommand="GridStatus_InsertCommand"
                                        GroupingEnabled="false" AllowSorting="false" ShowStatusBar="true" OnSortCommand="GridStatusBindTableAlpha"
                                        ShowGroupPanel="true" OnItemCommand="GridStatus_OnItemCommand">
                                        <PagerStyle Mode="NextPrevAndNumeric" />
                                        <MasterTableView DataKeyNames="StatusID" ToolTip="Drag and drop the rows to reorder"
                                            InsertItemPageIndexAction="ShowItemOnCurrentPage" CommandItemDisplay="Top" CommandItemSettings-RefreshText=""
                                            CommandItemSettings-ShowRefreshButton="false">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 100%; margin-left: -5px; margin-top: -8px;
                                                    border-bottom-width: 0px">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="btnAdd" Text="" CommandName="InitInsert" runat="server" CausesValidation="false"
                                                                Font-Underline="True"><%=objlang.GetLanguageConversion("Add_New_Record") %></asp:LinkButton>
                                                        </td>
                                                        <td align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="4%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="left" Width="4%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                            </div>
                                                            <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                    <tr>
                                                                        <td>
                                                                            <div style="float: left">
                                                                                <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                    type="checkbox" />
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
                                                                value='<%# DataBinder.Eval(Container, "DataItem.StatusID", "{0}") %>' />
                                                            <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                            <asp:HiddenField ID="hdn_statusid" runat="server" Value='<%#Eval("StatusID")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                         <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="Label6" runat="server" Text="">Colour</asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                       
                                                         
                                                          

                                                            <asp:Panel ID="pnlStatusColor" runat="server" CssClass="status-color-box" 
                                                                       Style='<%# "background-color:" + Eval("StatusColorCode") %>'>
                                                            </asp:Panel>



                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>





                                                <%-- Itemplate of Each Column Change By Jagat On 06-July/2012 --%>
                                                <telerik:GridTemplateColumn ItemStyle-Wrap="false" ItemStyle-Height="20px" SortExpression="Status">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <div style='height: 15px; width: 100%'>
                                                            <asp:Label ID="Label1" runat="server" Text=""><%=objlang.GetLanguageConversion("Status") %></asp:Label></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="height: 15px; width: 100%; cursor: pointer;">
                                                            <asp:Label ID="lblStatusID" Text='<%#Eval("StatusID")%>' runat="server" Visible="false"></asp:Label>
                                                            <asp:LinkButton ID="lnkStatus" runat="server" Text='<%#Eval("StatusTitle")%>' CausesValidation="false"
                                                                ToolTip='<%#Eval("StatusTitle") %>' Visible="false"></asp:LinkButton><%--OnClientClick="javascript:CheckGrid();"--%>
                                                            <%#Eval("StatusTitle")%>
                                                        </div>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-Wrap="false" ItemStyle-Height="20px" SortExpression="UserFriendlyName">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <div style='height: 15px; width: 100%'>
                                                            <asp:Label ID="lbl_Userfriendly" runat="server" Text=""><%=objlang.GetLanguageConversion("Friendly_NAme_For_Estore")%></asp:Label></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Label ID="lbl_UserfriendlyName" Text='<%#Eval("UserFriendlyName")%>' runat="server"></asp:Label>
                                                        </div>
                                                        <%-- </a>--%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-Wrap="false" ItemStyle-Height="20px" SortExpression="Probability">
                                                    <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <div style='height: 15px; display:none; width: 100%'>
                                                            <asp:Label ID="lbl_Probability" runat="server" Text=""><%=objlang.GetLanguageConversion("Probability")%></asp:Label></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style='height: 15px; width: 100%;  display:none; cursor: pointer;'>
                                                            <asp:Label ID="lbl_Probability1" Text='<%#Eval("Probability")%>' runat="server" Style="float: right;
                                                                margin-right: 2px;"></asp:Label>
                                                        </div>
                                                        <%-- </a>--%>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_estimate" runat="server" Text=""><%=objlang.GetLanguageConversion("Estimate")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Image runat="server" ID="img_estimate" />
                                                            <asp:HiddenField ID="hdn_estimate" runat="server" Value='<%#Eval("Estimate")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_job" runat="server" Text=""><%=objlang.GetLanguageConversion("Job")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Image runat="server" ID="img_job" />
                                                            <asp:HiddenField ID="hdn_job" runat="server" Value='<%#Eval("Job")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_invoice" runat="server" Text=""><%=objlang.GetLanguageConversion("Invoice")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Image runat="server" ID="img_invoice" />
                                                            <asp:HiddenField ID="hdn_invoice" runat="server" Value='<%#Eval("Invoice")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_purchase" runat="server" Text=""><%=objlang.GetLanguageConversion("Purchase")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Image runat="server" ID="img_purchase" />
                                                            <asp:HiddenField ID="hdn_purchase" runat="server" Value='<%#Eval("Purchase")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_delivery" runat="server" Text=""><%=objlang.GetLanguageConversion("Delivery")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Image runat="server" ID="img_delivery" />
                                                            <asp:HiddenField ID="hdn_delivery" runat="server" Value='<%#Eval("Delivery")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_proof" runat="server" Text=""><%=objlang.GetLanguageConversion("Proof")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Image runat="server" ID="img_proof" />
                                                            <asp:HiddenField ID="hdn_proof" runat="server" Value='<%#Eval("Proof")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lbl_default_text" runat="server" Text=""><%=objlang.GetLanguageConversion("In_Use")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div align="center" style='height: 15px; width: 100%; cursor: pointer;'>
                                                            <asp:Image runat="server" ID="img_default_value" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--End--%>
                                                <telerik:GridDragDropColumn ItemStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                    ItemStyle-Width="10%" HeaderText="" DragImageUrl="~/images/drag_drop.gif" Visible="false">
                                                    <HeaderStyle Font-Bold="true" HorizontalAlign="Center" Wrap="false" />
                                                </telerik:GridDragDropColumn>
                                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <center>
                                                            <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                                float: none; background-repeat: no-repeat; position: static;" align="center">
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
                                                    <table border="0" cellpadding="0" style="margin-top: 8px; margin-bottom: 9px; width: 100%;">
                                                        <tr>
                                                            <td style="float: left; width: 165px;" valign="top">
                                                                <div class="bglabel" style="width: 99%; margin: 0px;">
                                                                    <asp:HiddenField ID="hdn_statusid" runat="server" Value='<%#Eval("StatusID")%>' />
                                                                    <asp:Label ID="lblStatus" runat="server" Text="" CssClass="normaltext"><%=objlang.GetLanguageConversion("Status_Title")%></asp:Label>
                                                                    <span style="color: Red">*</span></div>
                                                                </div>
                                                            </td>
                                                            <td style="float: left; padding-left: 12px; width: 400px;">
                                                                <asp:TextBox ID="txtStatus" runat="server" Width="150px" CssClass="textboxnew" MaxLength="100"
                                                                    Text='<%#Eval("StatusTitle")%>' onblur="copyText(this.id);" Style="float: left"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="txtStatus" ID="rfvTxtStatus" runat="server"
                                                                    ValidationGroup="save" ErrorMessage="Please enter Status Title" CssClass="RFV_Message"
                                                                    Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px"
                                                                    ForeColor=""><%=objlang.GetLanguageConversion("Please_Enter_Status_Title")%></asp:RequiredFieldValidator>
                                                                <span id="spn_txtStatus" class="spanerrorMsg" style="display: none; width: 178px;">
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="float: left; width: 165px;">
                                                                <div class="bglabel" style="width: 99%; margin: 0px;">
                                                                    <asp:Label ID="lbl_UserFriendlyName" runat="server" Text="" CssClass="normaltext"><%=objlang.GetLanguageConversion("Friendly_NAme_For_Estore")%></asp:Label>
                                                                    <span style="color: Red">*</span></div>
                                                            </td>
                                                            <td style="float: left; padding-left: 12px; width: 400px;">
                                                                <asp:TextBox ID="txt_UserFriendlyName" runat="server" Width="150px" CssClass="textboxnew"
                                                                    Text='<%#Eval("UserFriendlyName")%>' MaxLength="100" Style="float: left"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ControlToValidate="txt_UserFriendlyName" ID="rfvTxtUser"
                                                                    ValidationGroup="save" runat="server" ErrorMessage="Please enter User Friendly Name"
                                                                    CssClass="RFV_Message" Style="width: auto; padding-left: 4px; padding-right: 4px;
                                                                    margin-left: 4px" ForeColor=""><%=objlang.GetLanguageConversion("Please_Enter_User_Friendly_Name")%></asp:RequiredFieldValidator>
                                                                <span id="spn_UserFriendlyName" class="spanerrorMsg" style="display: none; width: 178px;">
                                                                </span>
                                                            </td>
                                                        </tr>

                                                         <tr>
                                                            <td style="float: left; width: 165px;">
                                                                <div class="bglabel" style="width: 99%; margin: 0px;">
                                                                    <asp:Label ID="lbl_StatusColor" runat="server" Text="" CssClass="normaltext">Highlight Colour</asp:Label>
                                                                   
                                                            </td>
                                                            <td style="float: left; padding-left: 12px; width: 400px;">
                                                               <%-- <asp:TextBox ID="TextBox1" runat="server" Width="150px" CssClass="textboxnew"
                                                                    Text='<%#Eval("UserFriendlyName")%>' MaxLength="100" Style="float: left"></asp:TextBox>--%>
                                                               <%-- <div class="ddl" style="border: 0px solid; width: 40%">--%>
                          
                                                                <asp:DropDownList ID="ddlStatusColor" runat="server" CssClass="normalText" Width="40%">
                                                                    <asp:ListItem Text="None" Value="" Style="color:black;" ></asp:ListItem>
                                                                    <asp:ListItem Text="Bright Green" Value="#01DA66" Style="color:black; background-color:#01DA66;"></asp:ListItem>
                                                                    <asp:ListItem Text="Light Red" Value="#E64557" Style="color:black; background-color:#E64557;"></asp:ListItem>
                                                                    <asp:ListItem Text="Vibrant Turquoise" Value="#40BDDB" Style="color:black; background-color:#40BDDB;"></asp:ListItem>
                                                                    <asp:ListItem Text="Soft Purple" Value="#C57BE2" Style="color:black; background-color:#C57BE2;"></asp:ListItem>
                                                                    <asp:ListItem Text="Coral Orange" Value="#F97B57" Style="color:black; background-color:#F97B57;"></asp:ListItem>
                                                                    <asp:ListItem Text="Cool Gray" Value="#888888" Style="color:black; background-color:#888888;"></asp:ListItem>
                                                                    <asp:ListItem Text="Bright Yellow" Value="#FFD700" Style="color:black; background-color:#FFD700;"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                 <%--</div>--%>
                                                            </td>
                                                        </tr>


                                                        <tr id="DivProbability" runat="server" style="display:none">
                                                            <td style="float: left; width: 165px;">
                                                                <div class="bglabel" style="width: 99%; margin: 0px;">
                                                                    <asp:Label ID="Label4" runat="server" Text="" CssClass="normaltext"><%=objlang.GetLanguageConversion("Probability")%></asp:Label>
                                                                </div>
                                                            </td>
                                                            <td style="float: left; padding-left: 12px; width: 400px;">
                                                                <asp:TextBox ID="txtProbability" runat="server" Width="50px" CssClass="textboxnew"
                                                                    Text='<%#Eval("Probability")%>' MaxLength="5" onkeypress="return validateNumberOnly(event);"
                                                                    Style="text-align: right;"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="float: left; width: 165px;">
                                                                <div class="bglabel" style="width: 99%; margin: 0px;">
                                                                    <asp:Label ID="Label1" runat="server" Text="" CssClass="normaltext"><%=objlang.GetLanguageConversion("Status_Display_In")%></asp:Label></div>
                                                            </td>
                                                            <td style="float: left; padding-left: 2px; width: 400px;">
                                                                <div style="float: left; width: 115px;" class="box">
                                                                    <div style="padding-top: 10px;">
                                                                        <asp:CheckBoxList ID="chk_modname" RepeatColumns="1" RepeatDirection="Horizontal"
                                                                            runat="server">
                                                                            <asp:ListItem Text="" Value="Estimate" Selected="True"> </asp:ListItem>
                                                                            <asp:ListItem Text="" Value="Job" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="" Value="Invoice" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="" Value="Purchase" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="" Value="Delivery" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="" Value="Proof" Selected="True"></asp:ListItem>
                                                                        </asp:CheckBoxList>
                                                                    </div>
                                                                </div>
                                                                <div style="float: left; padding-left: 5px">
                                                                    <asp:Label ID="lbl_default" runat="server" Text=""><%=objlang.GetLanguageConversion("Default") %></asp:Label>
                                                                    <asp:CheckBoxList ID="chk_default" RepeatColumns="1" RepeatDirection="Horizontal"
                                                                        runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem></asp:ListItem>

                                                                    </asp:CheckBoxList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="float: left; width: 165px; border: solid 1px transparent;">
                                                            </td>
                                                            <td style="float: left; padding-left: 9px; width: 300px;">
                                                                <asp:LinkButton ID="RadButton8" CssClass="button" runat="server" CommandName="Cancel"
                                                                    CausesValidation="false" Text='<%#objlang.GetLanguageConversion("Cancel")%>'></asp:LinkButton>
                                                                <span style="padding-left: 5px"></span>
                                                                <asp:LinkButton ID="RadButton1" CssClass="button" runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'
                                                                    CausesValidation="true" Text='<%#objlang.GetLanguageConversion("Save")%>' ValidationGroup="save"></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                                <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                            </EditFormSettings>
                                        </MasterTableView>
                                        <ClientSettings ReorderColumnsOnClient="true" AllowDragToGroup="true">
                                        </ClientSettings>
                                        <ClientSettings EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                            <ClientEvents OnRowClick="OnRowclick" />
                                        </ClientSettings>
                                    </telerik:RadGrid></div>
                                <asp:ObjectDataSource ID="odsStatus" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                                    SelectMethod="settings_estimatestatus_select_new" DeleteMethod="settings_estimatestatus_delete"
                                    UpdateMethod="settings_estimatestatus_update"></asp:ObjectDataSource>
                                <div align="left" class="divpaging" style="display: none">
                                </div>
                                <div align="left" style="padding-top: 5px">
                                    <asp:Label ID="lbl_message" runat="server">
                                                        <div style="float:left;padding-left:35px">
                                                        
                                                        1. You can not delete a status that is currently ticked as in use within the system.
                                                      
                                                        </div>
                                    </asp:Label>
                                </div>
                            </div>
                    </div>
                    </asp:Panel>
                </div>
                <script type="text/javascript">
                    function changebgColor1(chkobj) {
                        var gridid = document.getElementById("<%=GridStatus.ClientID%>");
                        changeGridColor(chkobj, gridid);
                    }                          
                </script>
                <div id="div_JobCardStatus" runat="server" style="float: left; width: 100%; display: none">
                    <div style="float: left; width: 100%;">
                        <div class="bglabel" style="width: 20%">
                            <asp:Label ID="Label2" runat="server" Text="Default Job Status:" CssClass="normaltext"></asp:Label></div>
                        <div class="ddl" style="border: 0px solid; width: 40%">
                            <div style="float: left; width: 50%; border: 0px solid;">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="normalText" Width="100%">
                                    <asp:ListItem>My Printing Co.</asp:ListItem>
                                    <asp:ListItem>Antalis Paper</asp:ListItem>
                                    <asp:ListItem>Inking Ltd.</asp:ListItem>
                                    <asp:ListItem>Robert Horne Paper Suppliers</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div style="float: left; width: 90%; padding: 5px 8px 0px 0px">
                        <asp:Button ID="Button2" runat="server" Text="Add" OnClientClick="javascript:return showJobcard('add')"
                            Width="65px" CssClass="button" Style="padding: 2px" />
                        <asp:Button ID="Button3" runat="server" Text="Edit" Width="65px" CssClass="button"
                            OnClientClick="javascript:return showJobcard('edit')" Style="padding: 2px" />
                        <asp:Button ID="Button4" runat="server" Text="Delete" Width="65px" CssClass="button"
                            OnClientClick="javascript:return window.confirm('Are you sure to delete this Job status ');"
                            Style="padding: 2px" />
                    </div>
                    <div id="div_jobcardAdd" style="float: left; width: 100%; padding: 10px 0px 0px 0px;
                        display: none">
                        <fieldset>
                            <legend class="HeaderText">
                                <label id="lbljobcard">
                                </label>
                            </legend>
                            <div id="Div3">
                                <div style="float: left; width: 100%;">
                                    <div class="bglabel" style="width: 20%">
                                        <asp:Label ID="Label3" runat="server" Text="Tax Name:" CssClass="normaltext"></asp:Label>
                                    </div>
                                    <div class="box">
                                        <asp:TextBox ID="TextBox2" runat="server" Width="200px" CssClass="textboxnew"></asp:TextBox></div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                                <div style="float: left; width: 90%; padding: 0px 8px 0px 0px">
                                    <asp:Button ID="Button5" runat="server" Text="Save" Width="65px" CssClass="button"
                                        Style="padding: 2px" />
                                    <asp:Button ID="Button6" runat="server" Text="Cancel" Width="65px" CssClass="button"
                                        Style="padding: 2px" />
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
                <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
                    display: none">
                    <div id="div_test_2" style="width: 100%; border: solid 1px red;">
                        Loading...</div>
                </div>
                <asp:HiddenField ID="hdnreturn" runat="server" Value="0" />
            </div>
            <script type="text/javascript">

                function CheckAll(checkAllBox) {
                    var frm = document.forms[0];
                    var ChkState = checkAllBox.checked;
                    for (i = 0; i < frm.length; i++) {
                        e = frm.elements[i];
                        if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                            e.checked = ChkState;
                        if (e.type == 'checkbox' && e.name.indexOf('All') != -1)
                            e.checked = ChkState;
                    }
                }
                function CallDelete() {
                    var ret = CheckOne_new();
                    if (ret) {

                        CheckGrid();

                        return true;
                    }
                    else {
                        return false;
                    }
                }
            </script>
            <script type="text/javascript">

                function checkAll_new(checkAllBox) {
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
            <asp:Panel ID="pnlCallScroll" runat="server" Visible="false">
            </asp:Panel>
            <script type="text/javascript" language="javascript">

                function Validate(valtype, obj) {
                    var type = '<%=type %>';
                    if (type == "JS") {
                        CheckFinal = true;
                        if (valtype == "m") {

                        }
                        else {


                            var txtStatus1Val = document.getElementById(txtStatus1).value;
                            if (txtStatus1Val == "") {
                                CheckFinal = false;
                            }
                            else {
                                CheckFinal = true;
                            }
                        }
                    }

                    if (CheckFinal) {
                        CheckGrid();
                        return true;
                    }
                    else {
                        return false;
                    }
                }
        
            </script>
            <script type="text/javascript" language="javascript">
                var imgedit = document.getElementById("imgEdit");
                var imgsave = document.getElementById("imgSave");
                var lnkedit = document.getElementById("lnkEdit");
                var lnksave = document.getElementById("lnkSave");

                function EditStatus() {

                    lnkedit.style.display = "none";
                    lnksave.style.display = "block";

                }
                function SaveStatus() {

                    lnkedit.style.display = "block";
                    lnksave.style.display = "none";
                }

                function showJobcard(type) {

                    document.getElementById("div_jobcardAdd").style.display = "block";
                    if (type == 'add') {
                        document.getElementById("lbljobcard").innerHTML = "Enter the New Status";

                    }
                    if (type == 'edit') {
                        document.getElementById("lbljobcard").innerHTML = "Enter the Status to Edit";
                    }
                    return false;

                }
            </script>
            <script type="text/javascript">
                function CallDelete() {

                    var ret = CheckOne_new();

                    if (ret) {
                        CheckGrid();
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
                        return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');


                    }
                }

                function imgbtnDelete_ClientClick() {
                    return confirm('<%=objLanguage.GetLanguageConversion("Delete_This_Record")%>');
                }
     
            </script>
            <script type="text/javascript" src="../js/drag.js?VN='<%=VersionNumber%>'" language="javascript"></script>
            <script type="text/javascript" language="javascript">
                document.getElementById("ds00").style.display = "none";
                document.getElementById("div_Load").style.display = "none";
                var tabledragdrop = document.getElementById('<%=GridStatus.ClientID %>');
                try {
                    var tableDnD2 = new TableDnD();
                    tableDnD2.init(tabledragdrop);
                }
                catch (err) {
                }

                function ValueChanged() {
                    var frm = tabledragdrop.getElementsByTagName("input");
                    var i = 1;
                    for (l = 0; l < frm.length; l++) {
                        if (frm[l].id.indexOf('hdnUPDOWN') != -1) {
                            frm[l].value = i;
                            i++;
                        }
                    }
                }
                function test() {
                    alert("This is to test the alert");
                }
            </script>
            <%-- By Jagat On 11-July-2012--%>
            <script type="text/javascript">
                function UpdateOnEnter(e) {

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
            <script type="text/javascript">

                function RowDblClick(sender, eventArgs) {
                    sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                }

                function OnRowclick(sender, eventArgs) {
                    sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                }

                function copyText(id) {
                    var txtStatus = document.getElementById(id);
                    var FrdNme = id.replace("txtStatus", "txt_UserFriendlyName");
                    var friendlystatus = document.getElementById(FrdNme);

                    if (friendlystatus.value == "") {
                        friendlystatus.focus();
                        friendlystatus.value = txtStatus.value;
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
            <script type="text/javascript" language="javascript">
                function validateNumberOnly(evt) {
                    var charCode = (evt.which) ? evt.which : window.event.keyCode;

                    if (charCode <= 13) {
                        return true;
                    }
                    else {
                        var keyChar = String.fromCharCode(charCode);
                        var re = /[0-9]/
                        return re.test(keyChar);
                    }
                }
            </script>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
