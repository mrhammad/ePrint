<%@ page title="Settings: Company Type" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Settings_CompanyType.aspx.cs" Inherits="ePrint.settings.Settings_CompanyType" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RAM" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGridCompanyType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridCompanyType" LoadingPanelID="RALP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridCompanyType" LoadingPanelID="RALP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="dltbtn">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridCompanyType" LoadingPanelID="RALP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="drp_UsedIn">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridCompanyType" LoadingPanelID="RALP" />
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
    <div id="Div_navigator" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left;" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label ID="lblHeader" runat="server"><%=objlang.GetLanguageConversion("Settings_Company_Type")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="Div_Msg" style="margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 100%" class="mis_header_panel">
            <div id="">
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false"
                    runat="server">
                    <ContentTemplate>
                        <div id="div_Grid" style="width: 1000px;">
                            <div id="div_popupAction" style="margin: 58px 0px 0px 9px;" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="dltbtn" runat="server" Text="Delete Selected" OnClick="dltbtn_click"
                                                        OnClientClick="javascript:return CallDelete();" ForeColor="#333333" Font-Size="11px"
                                                        Style="text-decoration: none;"></asp:LinkButton></div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <telerik:RadGrid ID="RadGridCompanyType" AutoGenerateColumns="false" runat="server"
                                BorderWidth="0" itemstyle-heigh="2%" GridLines="None" AllowPaging="true" PageSize="50"
                                OnPageIndexChanged="RadGridCompanyType_PageIndexChanged" OnPageSizeChanged="RadGridCompanyType_PageSizeChanged"
                                Width="50%" PagerStyle-AlwaysVisible="true" OnUpdateCommand="Rad_CompanyType_OnUpdateCommand"
                                HeaderStyle-Font-Bold="true" OnItemCommand="RadGridCompanyType_OnItemCommand"
                                OnInsertCommand="Rad_CompanyType_OnInsertCommand" OnItemDataBound="RadGridCompanyType_ItemDataBound">
                                <MasterTableView Width="100%" HorizontalAlign="NotSet" CommandItemSettings-RefreshText=""
                                    CommandItemSettings-ShowRefreshButton="false" AutoGenerateColumns="False" DataKeyNames="id"
                                    CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnFirstPage">
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
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                            AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                            <HeaderTemplate>
                                                <div style="float: left">
                                                    <div style="float: left; display: none;">
                                                        <input type="checkbox" runat="server" name="checkAll" onclick="CheckAll(this);" />
                                                    </div>
                                                    <div id="div_chk" style="border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px;
                                                        -ms-border-radius: 5px; height: inherit; width: inherit">
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
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div style="padding-left: 2px">
                                                    <input type="checkbox" runat="server" id="chkCompanytypeId1" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.id", "{0}") %>'
                                                        onclick="CheckChanged();" />
                                                    <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ID" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                            ItemStyle-HorizontalAlign="Left" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Company Type" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <a href="#">
                                                    <asp:Label ID="lblcompanyType" runat="server" Text='<%#Eval("companytype")%>' Width="100%"></asp:Label>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Used In" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <a href="#">
                                                    <asp:Label ID="lblUsedIn" runat="server" Text='<%#Eval("UsedFor")%>' Width="100%"></asp:Label>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="Action">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:ImageButton ID="btndeletecolor" ImageUrl="~/Images/erase.png" CommandArgument='<%#Eval("id")%>'
                                                        ToolTip="Delete" runat="server" OnCommand="btnDelete_OnClick" OnClientClick="javascript:return ImgButtonErase_ClientClick()">
                                                    </asp:ImageButton></center>
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
                                        <EditColumn UniqueName="EditColumn">
                                        </EditColumn>
                                        <FormTemplate>
                                            <table border="0" cellpadding="2" cellspacing="2px" width="100%" id="a">
                                                <tr>
                                                    <td valign="top">
                                                        <div class="bglabel" style="width: 100%;">
                                                            <asp:Label ID="lbl_Name" runat="server" CssClass="normalText" Text="Company Type:"><%=objlang.GetLanguageConversion("Company_Type")%></asp:Label>
                                                            <span style="color: red">*</span>
                                                        </div>
                                                    </td>
                                                    <td style="float: left;">
                                                        <div style="padding-left: 10px;">
                                                            <asp:TextBox ID="txtcompanyType" class='textboxnew' runat="server" Width="200px"
                                                                Text='<%# Bind("companytype") %>' TextMode="MultiLine" MaxLength="200" Style="float: left"></asp:TextBox>
                                                            <span style="color: Red">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtcompanyType"
                                                                    ErrorMessage="Please enter company type" runat="server" CssClass="RFV_Message"
                                                                    Display="Dynamic" ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px;"> </asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <div class="bglabel" style="width: 100%;">
                                                            <asp:Label ID="lbl_UsedIn" runat="server" CssClass="normalText" Text="Company Type:"><%=objlang.GetLanguageConversion("Used_In")%></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td style="float: left;">
                                                        <div style="padding-left: 10px;">
                                                            <asp:DropDownList ID="ddl_UsedIn" runat="server">
                                                                <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                                                <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                                                                <asp:ListItem Text="Supplier" Value="Supplier"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="hdnCompanyTypeId" runat="server" Value='<%#Eval("id")%>' />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px;">
                                                        &nbsp;
                                                    </td>
                                                    <td style="padding-left: 10px;">
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnCancel"
                                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">
                                                        </telerik:RadButton>
                                                        <span style="padding-left: 5px"></span>
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btnSave"
                                                            runat="server" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                        </telerik:RadButton>
                                                        <asp:HiddenField ID="hdnColorid1" runat="server" Value='<%# Bind("id") %>' />
                                                    </td>
                                                </tr>
                                            </table>
                                        </FormTemplate>
                                        <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                    </EditFormSettings>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                </ClientSettings>
                                <ClientSettings ClientEvents-OnRowClick="RowDblClick" />
                            </telerik:RadGrid>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }
        </script>
    </telerik:RadCodeBlock>
    <script type="text/javascript">



        function CallCancel() {
            document.getElementById("divAddnewCompany").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_lnkDelete").style.display = "block";
        }

        function ImgButtonErase_ClientClick() {
            if (confirm('<%=objlang.GetLanguageConversion("Record_Delete_Confirmation")%>')) {

                return true;
            }
            else {
                return false;
            }
        }

        function CheckAll(checkAllBox) {
            var frm = document.forms[0]; var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                    e.checked = ChkState;
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1)
                    e.checked = ChkState;
            }
        }

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
                alert('<%=objlang.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>');
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');
            }
        }

        function validation() {
            var checkValid = false;
            if (document.getElementById("ctl00_ContentPlaceHolder1_txtcompanyType").value == "") {
                document.getElementById("txtcompanyType").style.display = "block";
                checkValid = true;
            }
            else {
                checkValid = false;
            }
            if (checkValid) {
                return false;
            }
            else {
                return true;
            }
        }

        function CheckChanged(Id) {
            var frm = document.forms[0];
            var boolAllChecked;
            boolAllChecked = true;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];

                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1)
                    if (e.checked == false) {
                        boolAllChecked = false;
                        break;
                    }
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
                    if (boolAllChecked == false)
                        e.checked = false;
                    else
                        e.checked = true;
                    break;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
