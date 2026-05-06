<%@ page language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="rates_papersize.aspx.cs" Inherits="ePrint.settings.rates_papersize" title="Settings: Paper Sizes" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link rel="stylesheet" type="text/css" href="../../App_Themes/justfortest.css" />
    <div align="left" style="width: 100%">
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">
                                    <asp:Label ID="lblHeader" runat="server"></asp:Label>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
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
    </style>
    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div align="left" style="width: 100%; margin-top: -10px" class="mis_header_panel">
            <div>
                <div align="left" style="width: 100%;">
                    <div>
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                    <div id="div_TotalRec" style="float: right; padding-right: 53%; padding-bottom: 3px">
                    </div>
                </telerik:RadCodeBlock>
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="Label1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="lnkDelete">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
                <div>
                    <div id="div_popupAction" style="margin: 61px 0px 0px 9px;" onmouseover="show();"
                        onmouseout="hide(); ">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <div style="width: 100%;">
                                        <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                            <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete Selected" OnClick="lnkDelete_OnClick"
                                                OnClientClick="javascript:return CallDelete();" CausesValidation="false" Style="text-decoration: none;"
                                                ForeColor="#333333" Font-Size="11px"></asp:LinkButton></div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <telerik:RadGrid Width="55%" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="false"
                    BorderWidth="0" ShowStatusBar="true" AllowAutomaticInserts="true" PageSize="50"
                    AllowAutomaticUpdates="true" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SessionDataSource1"
                    PagerStyle-AlwaysVisible="true" OnItemUpdated="RadGrid1_ItemUpdated" OnItemDeleted="RadGrid1_ItemDeleted"
                    OnItemDataBound="radGrid1_ItemDataBound" OnDataBound="RadGrid1_DataBound" AllowSorting="true"
                    OnItemCommand="radGrid1_OnItemCommand" OnPageIndexChanged="RadGrid1_PazeIndexChanged"
                    OnRowDrop="RadGrid1_RowDrop" HeaderStyle-Font-Bold="true" OnPageSizeChanged="RadGrid1_PazeSizeChanged">
                    <PagerStyle Mode="NextPrevAndNumeric" />
                    <MasterTableView Width="100%" CommandItemDisplay="Top" DataKeyNames="PaperSizeID"
                        DataSourceID="SessionDataSource1" HorizontalAlign="NotSet" AutoGenerateColumns="False"
                        CommandItemSettings-RefreshText="" CommandItemSettings-ShowRefreshButton="false"
                        InsertItemPageIndexAction="ShowItemOnFirstPage">
                        <%--Add  By Jagat On 31/July/2012--%>
                        <CommandItemTemplate>
                            <table class="rgCommandTable" border="0" style="width: 100%">
                                <tr>
                                    <td align="left">
                                        <asp:LinkButton ID="btnAdd" CommandName="InitInsert" runat="server" Font-Underline="True"><%#objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                    </td>
                                    <td align="right">
                                    </td>
                                </tr>
                            </table>
                        </CommandItemTemplate>
                        <%--End--%>
                        <Columns>
                            <telerik:GridTemplateColumn>
                                <HeaderTemplate>
                                    <div style="float: left">
                                        <div style="float: left; display: none;">
                                            <input type="checkbox" runat="server" name="checkAll" />
                                        </div>
                                        <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                            -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                <tr>
                                                    <td>
                                                        <div style="float: left">
                                                            <input id="checkAll1" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
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
                                    <%-- changebgColor(this);--on 29.09.2011 --%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="padding-left: 5px">
                                        <input type="checkbox" runat="server" id="Id1" onclick="CheckChanged();" name="Id"
                                            value='<%# DataBinder.Eval(Container, "DataItem.PaperSizeID", "{0}") %>' />
                                    </div>
                                    <%--changebgColor(this);-- Not defined, on 29.09.2011--%>
                                    <input type="hidden" id="hdnUPDOWN1" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="papersizename" HeaderText="" HeaderStyle-Width="35%"
                                ItemStyle-Width="35%" SortExpression="papersizename" UniqueName="papersizename"
                                MaxLength="50">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle />
                            </telerik:GridBoundColumn>
                            <%--By Jagat On 07-July-2012--%>
                            <telerik:GridTemplateColumn SortExpression="Width" UniqueName="Width" Visible="true"
                                HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle HorizontalAlign="Right" />
                                <%--                               
                                --%>
                                <ItemTemplate>
                                    <div style="text-align: right; overflow: hidden; cursor: pointer">
                                        <asp:Label runat="server" ID="lblName" Text='<%# Eval("Width") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="Height" UniqueName="Height" Visible="true"
                                HeaderStyle-HorizontalAlign="Right ">
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <div style="text-align: right; overflow: hidden; cursor: pointer">
                                        <asp:Label runat="server" ID="lblHeight" Text='<%# Eval("Height") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                HeaderText="" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                <HeaderTemplate>
                                    <div style="text-align: center;">
                                        <asp:Label ID="Label1" Text="" runat="server"><%=objLanguage.GetLanguageConversion("Action") %></asp:Label></div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="imgbtnDelete" Style="margin: 0px 0px 0px 12px;" runat="server"
                                                        CommandArgument='<%#Eval("PaperSizeID")%>' ToolTip="Delete" ImageUrl="~/Images/erase.png"
                                                        OnCommand="imgbtnDelete_OnClick" OnClientClick="javascript:return imgbtnDelete_ClientClick();" />
                                                </td>
                                                <td>
                                                    <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                        background-repeat: no-repeat;">
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                           
                            <%--End--%>
                        </Columns>
                        <EditFormSettings ColumnNumber="2" EditFormType="Template">
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
                                        <td valign="top" style="width: 112px;">
                                            <div class="bglabel" style="width: 100px; margin: 0px">
                                                <asp:Label ID="lblName" runat="server" Text="" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Name") %></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                        </td>
                                        <td>
                                            <div style="float: left; width: 100%;">
                                                <telerik:RadTextBox ID="txtPaperSizeName" CssClass="textboxnew" Width="200px" Text='<%# Bind("papersizename") %>'
                                                    runat="server" MaxLength="50" Style="border-top: silver 1px solid; border-right: #737373 2px solid;
                                                    border-left: silver 1px solid; border-bottom: #737373 1px solid; padding-left: 4px;
                                                    padding-top: 2px; padding-bottom: 2px; margin: 0px 0px 0px 0px; font-family: Verdana, Arial, Helvetica, sans-serif;
                                                    font-size: 11px; color: #000000; width: 175px; vertical-align: middle; float: left">
                                                </telerik:RadTextBox>
                                                <%--<asp:TextBox ID="txtPaperSizeName" CssClass="textboxnew" Width="200px" Text='<%#Eval("papersizename")%>' runat="server"
                                                    MaxLength="50" Style="border-top: silver 1px solid; border-right: #737373 2px solid; 
                                                     border-left: silver 1px solid; border-bottom: #737373 1px solid; padding-left: 4px;
                                                     padding-top: 2px; padding-bottom: 2px; margin: 0px 0px 0px 0px; font-family: Verdana, Arial, Helvetica, sans-serif;
                                                    font-size: 11px; color: #000000; width: 175px; vertical-align: middle; float: left">
                                                    </asp:TextBox>--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPaperSizeName"
                                                    ErrorMessage="* Please enter Paper Name" runat="server" CssClass="RFV_Message"
                                                    ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px">
                                                </asp:RequiredFieldValidator></span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width: 112px;">
                                            <div class="bglabel" style="width: 100px; margin: 0px">
                                                <asp:Label ID="Label2" runat="server" Text="Width" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Width") %></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <div style="float: left; width: 100%;">
                                                <span>
                                                    <telerik:RadNumericTextBox runat="server" CssClass="textboxnew" Style="text-align: right;
                                                        border-top: silver 1px solid; border-right: #737373 2px solid; border-left: silver 1px solid;
                                                        border-bottom: #737373 1px solid; padding-left: 4px; padding-top: 2px; padding-bottom: 2px;
                                                        margin: 0px 0px 0px 0px; font-family: Verdana, Arial, Helvetica, sans-serif;
                                                        font-size: 11px; color: #000000; width: 175px; vertical-align: middle; float: left"
                                                        ID="tbTaxRate" Width="50px" IncrementSettings-InterceptArrowKeys="false" DbValue='<%# Bind("Width") %>'>
                                                    </telerik:RadNumericTextBox>
                                                    <span style="color: Red">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="tbTaxRate"
                                                            ErrorMessage=" * Please enter Paper Width" runat="server" CssClass="RFV_Message"
                                                            ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px">
                                                        </asp:RequiredFieldValidator></span> </span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="width: 112px;">
                                            <div class="bglabel" style="width: 100px; margin: 0px">
                                                <asp:Label ID="Label3" runat="server" Text="" CssClass="normalText"><%=objLanguage.GetLanguageConversion("Height") %></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <div style="float: left; width: 100%;">
                                                <span>
                                                    <telerik:RadNumericTextBox runat="server" Style="text-align: right; border-top: silver 1px solid;
                                                        border-right: #737373 2px solid; border-left: silver 1px solid; border-bottom: #737373 1px solid;
                                                        padding-left: 4px; padding-top: 2px; padding-bottom: 2px; margin: 0px 0px 0px 0px;
                                                        font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; color: #000000;
                                                        width: 175px; vertical-align: middle; float: left" ID="RadNumericTextBox1" Width="50px"
                                                        DbValue='<%# Bind("Height") %>'>
                                                    </telerik:RadNumericTextBox>
                                                    <span style="color: Red">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="RadNumericTextBox1"
                                                            ErrorMessage=" * Please enter Paper Height" runat="server" CssClass="RFV_Message"
                                                            ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px">
                                                        </asp:RequiredFieldValidator></span> </span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 112px;">
                                        </td>
                                        <td style="float: left; padding: 10px 0px">
                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton8"
                                                runat="server" Text="Cancel" CommandName="Cancel" OnClick="btnCancel_Clicked"
                                                CausesValidation="false">
                                            </telerik:RadButton>
                                            <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="RadButton1"
                                                runat="server" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                            </telerik:RadButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="float: left;">
                                            <div class="smallgraytext">
                                                <asp:Label ID="lblNote" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </FormTemplate>
                            <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                        </EditFormSettings>
                    </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                        <%--AllowKeyboardNavigation="true"--%>
                        <%--<KeyboardNavigationSettings AllowSubmitOnEnter="true" />--%>
                        <ClientEvents OnRowClick="RowDblClick" />
                    </ClientSettings>
                </telerik:RadGrid>
                <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor1" runat="server" TextBoxStyle-Width="300px" />
                <telerik:GridTextBoxColumnEditor ID="GridTextBoxColumnEditor2" runat="server" TextBoxStyle-Width="150px" />
                <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                </telerik:RadWindowManager>
                <asp:ObjectDataSource ID="SessionDataSource1" runat="server" TypeName="Printcenter.UI.Setting.SettingsBasePage"
                    SelectMethod="settings_papersize_selectall" UpdateMethod="settings_papersize_update"
                    DeleteMethod="settings_papersize_delete" InsertMethod="settings_papersize_insert"
                    OnInserted="ObjDS_Inserted" OnUpdated="ObjDS_Updated">
                    <InsertParameters>
                        <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                            Type="Int32" />
                        <asp:Parameter Name="PaperSizeName" Type="String" />
                        <asp:Parameter Name="Height" Type="String" />
                        <asp:Parameter Name="Width" Type="String" />
                    </InsertParameters>
                    <DeleteParameters>
                        <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                            Type="Int32" />
                        <asp:Parameter Name="PaperSizeID" Type="String" />
                    </DeleteParameters>
                    <UpdateParameters>
                        <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                            Type="Int32" />
                        <asp:Parameter Name="PaperSizeID" Type="Int32" />
                        <asp:Parameter Name="PaperSizeName" Type="String" />
                        <asp:Parameter Name="Height" Type="Decimal" />
                        <asp:Parameter Name="Width" Type="Decimal" />
                    </UpdateParameters>
                    <SelectParameters>
                        <asp:SessionParameter DefaultValue="0" Name="companyID" SessionField="companyID"
                            Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <div class="onlyEmpty">
                </div>
                <div style="clear: both;">
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function RowDblClick(sender, eventArgs) {
            sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
        }
    </script>
    <script>
        function imgbtnDelete_ClientClick() {
            return confirm("By deleting this all the size will changed to custom value in the corresponding Estimate/Job/Invoice records. Are you sure you want delete this record?");

        }</script>
    <script type="text/javascript">        // Added on 29.09.2011
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
                alert('Please check at least one row to Delete');

                return false;
            }
            else {
                return window.confirm('By deleting this all the size will changed to custom value in the corresponding Estimate/Job/Invoice records. Are you sure you want to delete this record(s)? ');
            }
        }
        
    </script>
    <%--By Jagat On 11/July/2012--%>
    <script type="text/javascript">
        function InsertOnEnter(e) {
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
