<%@ page title="Customer Payment Terms" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="Cutomer_PaymentTerms.aspx.cs" Inherits="ePrint.settings.Cutomer_PaymentTerms" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RAM" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Rad_PaymentTerms">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rad_PaymentTerms" LoadingPanelID="RALP" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_Deleted">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Rad_PaymentTerms" LoadingPanelID="RALP" />
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
                                <asp:Label ID="lblHeader" runat="server"><%=objLanguage.GetLanguageConversion("Settings_Customer_Payment_Terms")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="estore_settingBox" style="min-height: 400px; width: 99%;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div id="Div_Msg" style="padding: 10px 0px 0px 10px; margin-bottom: -10px;">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div style="width: 100%; margin-top: -18px" class="mis_header_panel">
            <div id="">
                <asp:UpdatePanel ID="UpdatePnl" ChildrenAsTriggers="false" UpdateMode="Conditional"
                    RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <div id="Div_RadGrid">
                            <div id="div_popupAction" style="margin: 58px 0px 0px 9px;" onmouseover="show();"
                                onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="btn_Deleted" runat="server" Text="Delete Selected" Style="text-decoration: none;"
                                                        ForeColor="#333333" Font-Size="11px" OnClick="btn_Deleted_OnClick" OnClientClick="javascript:return CallDelete();"></asp:LinkButton></div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <telerik:RadGrid Width="55%" ID="Rad_PaymentTerms" GridLines="None" runat="server"
                                BorderWidth="0" AllowAutomaticDeletes="True" ShowStatusBar="true" AllowAutomaticInserts="false"
                                PageSize="50" AllowAutomaticUpdates="false" AllowPaging="True" ClientSettings-AllowRowsDragDrop="true"
                                AutoGenerateColumns="False" PagerStyle-AlwaysVisible="true" OnInsertCommand="Rad_PaymentTerms_OnInsertCommand"
                                OnUpdateCommand="Rad_PaymentTerms_OnUpdateCommand" OnItemDataBound="Rad_PaymentTerms_ItemDataBound"
                                OnItemCommand="Rad_PaymentTerms_OnItemCommand">
                                <PagerStyle Mode="NextPrevAndNumeric" />
                                <MasterTableView Width="100%" CommandItemDisplay="Top" HorizontalAlign="NotSet" AutoGenerateColumns="False"
                                    InsertItemPageIndexAction="ShowItemOnFirstPage">
                                    <CommandItemSettings ShowRefreshButton="false" />
                                    <%--Add  By Jagat On 31/July/2012--%>
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
                                    <%--End--%>
                                    <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                        <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                        <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                        <FormMainTableStyle GridLines="None" CellPadding="0" BackColor="White" Width="100%" />
                                        <FormTableStyle CellPadding="0" Height="10px" BackColor="White" />
                                        <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                        <EditColumn UniqueName="EditColumn">
                                        </EditColumn>
                                        <FormTemplate>
                                            <table border="0" cellpadding="0" width="90%" style="margin-top: 5px">
                                                <tr>
                                                    <td valign="top" style="width: 90px">
                                                        <div class="bglabel" runat="server" style="width: 120px; margin: 0px">
                                                            <asp:Label ID="lbl_Name" runat="server" CssClass="normalText" Text="Payment Name"><%=objLanguage.GetLanguageConversion("Payment_Name")%></asp:Label>
                                                            <span style="color: red;">*</span>
                                                        </div>
                                                    </td>
                                                    <td style="float: left; margin-left: 3px;">
                                                        <asp:TextBox ID="txt_PaymentName" class='textboxnew' runat="server" MaxLength="200"
                                                            Width="200px" Text='<%# Bind("Name") %>' TextMode="MultiLine" Height="20px" Style="float: left"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_PaymentName"
                                                                ErrorMessage="Please enter payment name" runat="server" CssClass="RFV_Message"
                                                                ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px"><%=objLanguage.GetLanguageConversion("Please_Enter_Payment_Name")%></asp:RequiredFieldValidator>
                                                        </span>
                                                        <asp:HiddenField ID="hdn_PaymentID" Value='<%# Bind( "PaymentTermID") %>' runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 90px">
                                                        <div id="Div1" class="bglabel" runat="server" style="width: 120px; margin: 0px">
                                                            <asp:Label ID="lbl_days" runat="server" CssClass="normalText" Text="Payment Days"><%=objLanguage.GetLanguageConversion("Payment_Days")%></asp:Label>
                                                            <span style="color: red;">*</span>
                                                        </div>
                                                    </td>
                                                    <td style="float: left; padding-top: 3px; margin-left: 3px;">
                                                        <asp:TextBox ID="txt_PaymentDays" class='textboxnew' onblur="javascript:AllowOlyDays(this,this.value);"
                                                            runat="server" Width="50px" Text='<%# Bind("Days") %>' Style="float: left"></asp:TextBox>
                                                        <span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" ControlToValidate="txt_PaymentDays"
                                                                ErrorMessage="This field must be a numerical entry" runat="server" CssClass="RFV_Message"
                                                                ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px"><%=objLanguage.GetLanguageConversion("This_Field_Must_Be_Numerical_Entry")%></asp:RequiredFieldValidator>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 90px">
                                                        <div id="div_Default" class="bglabel" runat="server" style="width: 120px; margin: 0px">
                                                            <asp:Label ID="lblDefault" runat="server" CssClass="normalText" Text="Payment Name:"><%=objLanguage.GetLanguageConversion("Default")%></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td style="float: left;">
                                                        <asp:CheckBox ID="chkDefault" runat="server" />
                                                        <asp:HiddenField ID="hdnDefault" Value='<%# Bind( "IsDefault") %>' runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="padding-left: 3px; padding-bottom: 5px;">
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btn_Cancel"
                                                            runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="false">
                                                        </telerik:RadButton>
                                                        <span style="padding-left: 5px"></span>
                                                        <telerik:RadButton Skin="EprintbtnSkin" EnableEmbeddedSkins="false" ID="btn_Save"
                                                            runat="server" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                        </telerik:RadButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </FormTemplate>
                                        <FormTableButtonRowStyle HorizontalAlign="Right" CssClass="EditFormButtonRow"></FormTableButtonRowStyle>
                                    </EditFormSettings>
                                    <Columns>
                                        <telerik:GridTemplateColumn ItemStyle-Width="20px" HeaderStyle-Width="20px">
                                            <HeaderStyle Font-Bold="true" />
                                            <HeaderTemplate>
                                                <div style="float: left">
                                                    <div style="float: left; display: none;">
                                                        <input type="checkbox" onclick="checkAll(this);" runat="server" name="checkAll" />
                                                    </div>
                                                    <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
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
                                                <div style="padding-left: 2px">
                                                    <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                        value='<%# DataBinder.Eval(Container, "DataItem.PaymentTermID", "{0}") %>' />
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <%--ItemTemplete Change By jagat On 14/July/2012--%>
                                        <telerik:GridTemplateColumn HeaderText="Name" UniqueName="Name" SortExpression="Name"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="350px"
                                            ItemStyle-Width="350px">
                                            <HeaderStyle Font-Bold="true" />
                                            <ItemTemplate>
                                                <div style="float: left; overflow: hidden; cursor: pointer">
                                                    <a href="#">
                                                        <asp:Label runat="server" ID="lbl_Name" Text='<%#Eval("Name")%>'></asp:Label>
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Days" UniqueName="Days" SortExpression="Days"
                                            ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right">
                                            <HeaderStyle Font-Bold="true" />
                                            <ItemTemplate>
                                                <div style="float: right; overflow: hidden; cursor: pointer">
                                                    <a href="#">
                                                        <asp:Label runat="server" ID="lbl_Days" Text='<%#Eval("Days")%>'></asp:Label>
                                                    </a>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn DataField="IsDefault" HeaderStyle-HorizontalAlign="Center"
                                            UniqueName="system" ItemStyle-HorizontalAlign="Center">
                                            <HeaderStyle Font-Bold="true" />
                                            <ItemTemplate>
                                                <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.PaymentTermID", "{0}") %>,'contact');">
                                                    <div style="float: none; width: 100%; overflow: hidden; height: 18px;">
                                                        <center>
                                                            <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                            <asp:ImageButton ID="img_Default" runat="server" CommandName="Set as default" CssClass="rollover"
                                                                Text="Set as default" CommandArgument='<%#Eval("PaymentTermID")%>' OnCommand="setDefaultPaymentTerm_OnClick">
                                                            </asp:ImageButton></center>
                                                    </div>
                                                </a>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                            HeaderText="ion" HeaderStyle-HorizontalAlign="Center">
                                            <HeaderStyle Font-Bold="true" />
                                            <HeaderTemplate>
                                                <div>
                                                    <center>
                                                        <asp:Label ID="Label1" Text="Action" runat="server"><%=objLanguage.GetLanguageConversion("Action") %></asp:Label></center>
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div>
                                                    <center>
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" ToolTip="delete" ImageUrl="~/Images/erase.png"
                                                            CommandArgument='<%#Eval("PaymentTermID") %>' OnCommand="imgbtnDelete_OnClick"
                                                            OnClientClick="javascript:return imgbtnDelete_ClientClick();" /></center>
                                                </div>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings EnableRowHoverStyle="true">
                                    <KeyboardNavigationSettings AllowSubmitOnEnter="true" />
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
    <script>

        function AllowOlyDays(obj, val) {
            if (val.substring(1, 0) != "-") {

                //By Jagat On 09-July-2012

                if (!isNaN(val)) {
                    var regex = new RegExp("[.]");

                    if (obj.value.match(regex)) {
                        obj.value = '';
                        obj.focus();
                        return false;
                    }

                    return true;
                }

                //End

                else {
                    obj.value = '';
                    obj.focus();
                    return false;
                }
            }
            else {
                obj.value = '';
                obj.focus();
                return false;
            }
        }

    </script>
    <script type="text/javascript">
        function imgbtnDelete_ClientClick() {
            return confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');
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
                alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete")%>');
                return false;
            }
            else {

                return window.confirm('Are you sure you want to delete this record(s)?');

            }
        }
    </script>
    <%-- By Jagat On 11-July-2012--%>
    <script type="text/javascript">
        function noNumbers(e) {

            if (typeof e == 'undefined' || window.event) { e = window.event; }
            if (e.keyCode == 13) {

                document.getElementById('ctl00_ContentPlaceHolder1_Rad_PaymentTerms_ctl00_ctl02_ctl03_btn_Save').click();


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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
