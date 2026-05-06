<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="editableTemplate_manageFonts.aspx.cs" Inherits="ePrint.StoreSettings.editableTemplate_manageFonts" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register Src="~/usercontrol/StoreSettings/editabletemplate_menu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript" src="<%#strSitepath %>js/Item/AutoFill.js?VN='<%#VersionNumber%>'"></script>
    <asp:ScriptManagerProxy ID="SMproxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <script src="../js/item/ProductCatalogue.js" language="javascript" type="text/javascript"></script>
    <script src="../js/item/editabletemplate.js?VN='<%#VersionNumber%>'" language="javascript"
        type="text/javascript"></script>
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
    <style>
        .RadColorPicker .rcpMillionColorsPageView .rcpInputsWrapper .rcpMillionColorsInputs
        {
            display: none;
        }
        #ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_emptycolor
        {
            display: none;
        }
        .NoColorButton .rcpApplyButton
        {
            display: none !important;
        }
    </style>
    <script type="text/javascript">
        function hidetype(tdid) {
            edit_temp('block');
            document.getElementById(tdid).style.background = '#F3F3F3';
        }

        function desableAfterLoad() {
            window.document.getElementById("div_Load").style.display = "none";
        }

    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdeditablefonts">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdeditablefonts" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdeditablecolors">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdeditablecolors" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadColorPicker1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadColorPicker1" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdeditablecolors">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="colorpicker" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdeditablefonts" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdeditablecolors" LoadingPanelID="Radajaxloadingpanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="Radajaxloadingpanel1" runat="server" SkinID="Windows7">
    </telerik:RadAjaxLoadingPanel>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <%--  <div align="left" id="pnleditabletemplatefontmanager">--%>
    <div align="left">
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label runat="server" ID="lblheader">Editable Template Manage Font</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
    </div>
    <div id="content" class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel" style="margin-top: -10px">
            <div align="left" style="width: 100%;">
                <div id="">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <table cellpadding="1" cellspacing="1" border="0" width="100%">
                        <tr>
                            <%-- <td valign="top" style="width: 18%;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                    <asp:Panel ID="pnlfont" runat="server" Visible="false">
                                        <script type="text/javascript">
                                            hidetype('Td64');
                                        </script>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlcolor" runat="server" Visible="false">
                                        <script type="text/javascript">

                                            hidetype('Td65');
                                        </script>
                                    </asp:Panel>
                                </td>
                                <td style="width: 10px">
                                    &nbsp;
                                </td>--%>
                            <td style="width: 85%;" valign="top">
                                <div class="only5px">
                                </div>
                                <div align="left" style="width: 80%; margin-top: -4px">
                                    <div id="div_popupAction" style="margin: 58px 0px 0px 9px;" onmouseover="show();"
                                        onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                            <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" CommandName="Delete"
                                                                Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClick="btn_Deleted_OnClick"
                                                                OnClientClick="javascript:return imgbtnDelete_ClientClickGeneral();" CausesValidation="false"></asp:LinkButton></div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <telerik:RadGrid ID="grdeditablefonts" runat="server" AllowSorting="true" AllowPaging="true"
                                        BorderWidth="0" Width="70%" OnItemDataBound="grdeditablefonts_ItemDataBound"
                                        AutoGenerateColumns="false" OnNeedDataSource="grdeditablefonts_NeedDataSource"
                                        OnInsertCommand="grdeditablefonts_InsertCommand" OnUpdateCommand="grdeditablefonts_UpdateCommand"
                                        HeaderStyle-Font-Bold="true" PageSize="20" AllowFilteringByColumn="true" GridLines="None"
                                        OnItemCommand="grdeditablefonts_OnItemCommand" PagerStyle-AlwaysVisible="true" GroupingSettings-CaseSensitive="false">
                                        <MasterTableView DataKeyNames="FontID" CommandItemDisplay="Top">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New Font Style" CommandName="InitInsert"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                            <EditItemStyle />
                                            <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                <FormCaptionStyle CssClass="EditFormHeader" />
                                                <FormMainTableStyle GridLines="None" CellPadding="3" CellSpacing="0" BackColor="White"
                                                    Width="100" />
                                                <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                <EditColumn UniqueName="EditColumn">
                                                </EditColumn>
                                                <FormTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 8px; margin-top: 4px;
                                                        margin-bottom: 9px;" width="100%">
                                                        <tr>
                                                            <td style="width: 90%; margin: 0px">
                                                                <asp:Label ID="lblfontstylelbl" runat="server" Text="Font Style" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Font_Style") %> <span style="color:red"> *</span></asp:Label>
                                                                <%-- <asp:TextBox ID="txtfontstyle" runat="server" Style="margin-left: 4px" CssClass="textboxnew"></asp:TextBox>--%>
                                                                <%-- <telerik:RadTextBox ID="txtfontstyle" runat="server" EnabledStyle-Width="176px" Text='<%# Bind( "FontStyle") %>'
                                                                    DisabledStyle-Width="176px" Style="margin-left: 4px;">
                                                                </telerik:RadTextBox>--%>
                                                                <asp:TextBox ID="txtfontstyle" runat="server" Text='<%# Bind( "FontStyle") %>' CssClass="manage_followtxt textboxnew"
                                                                    Style="float: left"></asp:TextBox>
                                                                <div id="spnreferror" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;
                                                                    float: right;">
                                                                    <div class="RFV_Message">
                                                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px">
                                                                            <%=objLanguage.GetLanguageConversion("Font_Style_already_exists")%></span>
                                                                    </div>
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="A"
                                                                    ErrorMessage="Please enter Font Style" ControlToValidate="txtfontstyle" CssClass="RFV_Message"
                                                                    ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px"><%=objLanguage.GetLanguageConversion("Please_Enter_Font_Style")%>
                                                                </asp:RequiredFieldValidator>
                                                                <div id="spnfontnull" style="display: none; width: auto; float: right">
                                                                    <div class="RFV_Message">
                                                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px; margin-left: 2px;
                                                                            display: inline-block;">
                                                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Font_Style") %></span>
                                                                    </div>
                                                                </div>
                                                                <asp:HiddenField ID="hdn_FontID" runat="server" Value='<%# Bind("FontID") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblfontfamilylbl" runat="server" Text="Font Family" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Font_Family") %></asp:Label>
                                                                <%--   <asp:DropDownList ID="ddlfontfamily" Style="margin-left: 4px; width:180px" CssClass="textboxnew"
                                                                        runat="server">
                                                                    </asp:DropDownList>--%>
                                                                <%--  <telerik:RadComboBox ID="ddlfontfamily" runat="server" Height="200" Style="margin-left: 4px;
                                                                    width: 180px">
                                                                </telerik:RadComboBox>--%>
                                                                <asp:DropDownList ID="ddlfontfamily" runat="server" CssClass="manage_followddl">
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hdn_FontFamily" runat="server" Value='<%# Bind("FontFamily") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblsize" runat="server" Text="Size" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Size") %> <span style="color:red"> *</span></asp:Label>
                                                                <%-- <asp:TextBox ID="txtsize" runat="server" Style="margin-left: 4px" CssClass="textboxnew"></asp:TextBox>--%>
                                                                <%--           <telerik:RadNumericTextBox ID="txtsize" runat="server" Text='<%# Bind( "FontSize") %>'
                                                                    EnabledStyle-Width="60px" DisabledStyle-Width="60px" Style="margin-left: 4px"
                                                                    CssClass="textboxnew">
                                                                </telerik:RadNumericTextBox>--%>
                                                                <asp:TextBox ID="txtsize" runat="server" Text='<%# Bind( "FontSize") %>' CssClass="textboxnew manage_indenttxt"
                                                                    Style="text-align: right; float: left"></asp:TextBox>
                                                                <span>pt</span> <span>
                                                                    <asp:RequiredFieldValidator ID="rqdfldvalidator" runat="server" ValidationGroup="A"
                                                                        ErrorMessage="Please enter Font Size" ControlToValidate="txtsize" Display="Dynamic"
                                                                        SetFocusOnError="true" CssClass="RFV_Message" ForeColor="" Style="width: auto;
                                                                        padding-left: 4px; padding-right: 4px; margin-right: 37%; float: right"><%=objLanguage.GetLanguageConversion("Please_Enter_Font_Size") %>
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="cmpvld1" ErrorMessage="" ControlToValidate="txtsize" Display="Dynamic"
                                                                        SetFocusOnError="true" ValidationGroup="A" runat="server" Operator="LessThanEqual"
                                                                        Type="Double" ValueToCompare="500" CssClass="RFV_Message" ForeColor="" Style="width: auto;
                                                                        padding-left: 4px; padding-right: 4px; margin-right: 30%; float: right;"><%=objLanguage.GetLanguageConversion("Max_Font_Size_is_500_pt")%></asp:CompareValidator>
                                                                </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblindent" runat="server" Text="Indent" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Indent")%>
                                                                </asp:Label>
                                                                <%--  <asp:TextBox ID="txtindent" runat="server" Style="margin-left: 4px" CssClass="textboxnew"></asp:TextBox>--%>
                                                                <%--   <telerik:RadNumericTextBox ID="txtindent" runat="server" Text='<%# Bind( "Indent") %>'
                                                                    EnabledStyle-Width="60px" DisabledStyle-Width="60px" Style="margin-left: 4px"
                                                                    CssClass="textboxnew">
                                                                </telerik:RadNumericTextBox>--%>
                                                                <asp:TextBox ID="txtindent" runat="server" Text='<%# Bind( "Indent") %>' CssClass="textboxnew manage_indenttxt"
                                                                    Style="text-align: right; float: left"></asp:TextBox>
                                                                <span>mm</span>
                                                                <asp:CompareValidator ID="cmpvld2" ErrorMessage="" ControlToValidate="txtindent"
                                                                    SetFocusOnError="true" ValidationGroup="A" runat="server" Operator="LessThanEqual"
                                                                    Display="Dynamic" Type="Double" ValueToCompare="100" CssClass="RFV_Message" ForeColor=""
                                                                    Style="width: auto; padding-left: 4px; padding-right: 4px; margin-right: 30%;
                                                                    float: right;"><%=objLanguage.GetLanguageConversion("Max_Indent_is_100_mm")%></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblmanualtracking" runat="server" Text="Manual Tracking" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Manual_Tracking")%></asp:Label>
                                                                <%-- <asp:DropDownList ID="ddlplusminus" runat="server" Style="margin-left: 4px">
                                                                        <asp:ListItem Text="+" Value="+" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="-" Value="-"></asp:ListItem>
                                                                    </asp:DropDownList>--%>
                                                                <%--      <telerik:RadComboBox ID="ddlplusminus" runat="server" Style="margin-left: 4px; width: 40px">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="+" Value="+" />
                                                                        <telerik:RadComboBoxItem Text="-" Value="-" />
                                                                    </Items>
                                                                </telerik:RadComboBox>--%>
                                                                <asp:DropDownList ID="ddlplusminus" runat="server" CssClass="manage_followddl11">
                                                                    <asp:ListItem Text="+" Value="+" />
                                                                    <asp:ListItem Text="-" Value="-" />
                                                                </asp:DropDownList>
                                                                <%-- <asp:TextBox ID="txtmanualtracking" runat="server" Width="75px" CssClass="textboxnew"></asp:TextBox>--%>
                                                                <%-- <telerik:RadNumericTextBox ID="txtmanualtracking" EnabledStyle-Width="88px" DisabledStyle-Width="88px"
                                                                    runat="server">
                                                                </telerik:RadNumericTextBox>--%>
                                                                <asp:TextBox ID="txtmanualtracking" runat="server" CssClass="textboxnew manage_manualtrkg"
                                                                    Style="text-align: right"></asp:TextBox>
                                                                <%-- <asp:DropDownList ID="ddltrackingin" runat="server">
                                                                    <asp:ListItem Text="pt" Value="pt" Selected="True"></asp:ListItem>
                                                                    <asp:ListItem Text="mm" Value="mm"></asp:ListItem>
                                                                    </asp:DropDownList>--%>
                                                                <%--  <telerik:RadComboBox ID="ddlunit" runat="server" Style="width: 40px">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="pt" Value="pt" />
                                                                        <telerik:RadComboBoxItem Text="mm" Value="mm" />
                                                                    </Items>
                                                                </telerik:RadComboBox>--%>
                                                                <asp:DropDownList ID="ddlunit" runat="server" CssClass="manage_width40px">
                                                                    <asp:ListItem Text="pt" Value="pt" />
                                                                    <asp:ListItem Text="mm" Value="mm" />
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hdn_ManualTracking" runat="server" Value='<%# Bind("ManualTracking") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbldatatype" runat="server" Text="Data Type" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Data_Type")%></asp:Label>
                                                                <%--  <asp:DropDownList ID="DropDownList1" runat="server" Style="margin-left: 4px">
                                                                        <asp:ListItem Text="Text" Value="text" Selected="True"></asp:ListItem>
                                                                        <asp:ListItem Text="Number" Value="number"></asp:ListItem>
                                                                    </asp:DropDownList>--%>
                                                                <%--      <telerik:RadComboBox ID="ddldatatype" runat="server" Style="margin-left: 4px;">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="Text" Value="Text" />
                                                                        <telerik:RadComboBoxItem Text="Number" Value="Number" />
                                                                    </Items>
                                                                </telerik:RadComboBox>--%>
                                                                <asp:DropDownList ID="ddldatatype" runat="server" CssClass="manage_margin4px">
                                                                    <asp:ListItem Text="Text" Value="Text" />
                                                                    <asp:ListItem Text="Number" Value="Number" />
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hdn_Datatype" runat="server" Value='<%# Bind("DataType") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbljustify" runat="server" CssClass="bglabel" Text="Justify"><%=objLanguage.GetLanguageConversion("Justify")%></asp:Label>
                                                                <div class="box">
                                                                    <div style="float: left">
                                                                        <asp:RadioButton ID="rbdright" GroupName="j" runat="server" Text="" /></div>
                                                                    <div style="float: left">
                                                                        <asp:Image ID="Image1" runat="server" Style="display: inline" ToolTip="Right" ImageUrl="../images/right_just.gif" /></div>
                                                                    <div style="float: left">
                                                                        <asp:RadioButton ID="rdbcenter" GroupName="j" runat="server" Text="" /></div>
                                                                    <div style="float: left">
                                                                        <img id="Img1" runat="server" title="Center" src="../images/justifyfull.gif" /></div>
                                                                    <div style="float: left">
                                                                        <asp:RadioButton ID="rdbleft" GroupName="j" runat="server" Text="" /></div>
                                                                    <div style="float: left">
                                                                        <img title="Left" src="../images/left_just.gif" /></div>
                                                                </div>
                                                                <asp:HiddenField ID="hdn_textalign" runat="server" Value='<%# Bind("TextAlign") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblcapitalization" runat="server" CssClass="bglabel" Text="Capitalization"><%=objLanguage.GetLanguageConversion("Capitalization")%></asp:Label>
                                                                <%--  <asp:RadioButtonList ID="rdblst" runat="server" >
                                                             <asp:ListItem Text="As per user input"></asp:ListItem>
                                                              <asp:ListItem Text="All Upper Case"></asp:ListItem>
                                                               <asp:ListItem Text="First word First letter Caps"></asp:ListItem>
                                                                <asp:ListItem Text="All WOrds First Letter Caps"></asp:ListItem>
                                                                 <asp:ListItem Text="All lower Case"></asp:ListItem>
                                                             </asp:RadioButtonList>--%>
                                                                <%-- <asp:DropDownList ID="ddlcapitalization" CssClass="textboxnew" style="margin-left:4px; width:185px" runat="server">
                                                             <asp:ListItem Text="As per user input"></asp:ListItem>
                                                              <asp:ListItem Text="All Upper Case"></asp:ListItem>
                                                               <asp:ListItem Text="First word First letter Caps"></asp:ListItem>
                                                                <asp:ListItem Text="All WOrds First Letter Caps"></asp:ListItem>
                                                                 <asp:ListItem Text="All lower Case"></asp:ListItem>
                                                             </asp:DropDownList>--%>
                                                                <%--   <telerik:RadComboBox ID="radcomcapitalization" runat="server" Style="margin-left: 4px;
                                                                    width: 185px">
                                                                    <Items>
                                                                        <telerik:RadComboBoxItem Text="As per user Input" Value="User Input" />
                                                                        <telerik:RadComboBoxItem Text="All UPPER CASE" Value="All Caps" />
                                                                        <telerik:RadComboBoxItem Text="First word first letter capital" Value="InitCap" />
                                                                        <telerik:RadComboBoxItem Text="All Word First Letter Caps" Value="First Cap" />
                                                                        <telerik:RadComboBoxItem Text="all lower case" Value="All Lower" />
                                                                    </Items>
                                                                </telerik:RadComboBox>--%>
                                                                <asp:DropDownList ID="radcomcapitalization" runat="server" Style="margin-left: 4px;
                                                                    width: 185px">
                                                                    <asp:ListItem Text="As per user Input" Value="User Input" />
                                                                    <asp:ListItem Text="All UPPER CASE" Value="All Caps" />
                                                                    <asp:ListItem Text="First word first letter capital" Value="InitCap" />
                                                                    <asp:ListItem Text="All Word First Letter Caps" Value="First Cap" />
                                                                    <asp:ListItem Text="all lower case" Value="All Lower" />
                                                                </asp:DropDownList>
                                                                <asp:HiddenField ID="hdn_Capitalization" runat="server" Value='<%# Bind("Capitalize") %>' />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" CssClass="bglabel" Width="28%" Style="visibility: hidden;
                                                                    margin-left: 4px"></asp:Label>
                                                                <asp:Button ID="btncancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="button" />
                                                                <asp:Button ID="btnsave" runat="server" CausesValidation="true" ValidationGroup="A"
                                                                    Style="margin-left: 3px" Text="Save" CssClass="button" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>' />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                                <input id="Checkbox1" type="checkbox" onclick="CheckAll(this);" runat="server" name="checkAll" />
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
                                                            <input type="checkbox" runat="server" id="Id" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.FontID", "{0}") %>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn DataField="FontStyle" AutoPostBackOnFilter="true" FilterControlWidth="40%"
                                                    CurrentFilterFunction="Contains">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblhdrfontstyle" runat="server"><%=objLanguage.GetLanguageConversion("Font_Style")%></asp:Label></HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfontstyle" Style="cursor: pointer" runat="server" Text='<%# DataBinder.Eval(Container,"Dataitem.FontStyle","{0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn DataField="FontFamily" AutoPostBackOnFilter="true" FilterControlWidth="40%"
                                                    CurrentFilterFunction="Contains">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblhdrfamily" runat="server"><%=objLanguage.GetLanguageConversion("Font_Family")%></asp:Label></HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfontfamily" Style="cursor: pointer" runat="server" Text='<%# DataBinder.Eval(Container,"Dataitem.FontFamily","{0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AutoPostBackOnFilter="true" DataField="FontSize" FilterControlWidth="40%"
                                                    CurrentFilterFunction="Contains">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblhdrsize" runat="server"><%=objLanguage.GetLanguageConversion("Font_Size_pt")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfontsize" Style="cursor: pointer; margin-left: 25%" runat="server"
                                                            Text='<%# DataBinder.Eval(Container,"Dataitem.FontSize","{0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%--Added  By Naveen--%>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <div style="float: none">
                                                            <asp:Label ID="lbl_text" runat="server" Text=""><%=objLanguage.GetLanguageConversion("In_Use")%></asp:Label></div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <center>
                                                            <asp:Image runat="server" ID="img_default_value" ImageUrl="" />
                                                            <asp:HiddenField ID="hdnIsUsed" runat="server" Value='<%#Eval("IsUsed") %>' />
                                                        </center>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <%----------------------------%>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="rgHeader"
                                                    HeaderText="ion" AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
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
                                                                <asp:ImageButton ID="imgbtnDelete" runat="server" ToolTip="delete" ImageUrl="" CommandArgument='<%#Eval("FontID") %>'
                                                                    OnCommand="imgbtnDelete_OnClick" OnClientClick="javascript:return imgbtnDelete_ClientClick('font');" /></center>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true" ClientEvents-OnRowClick="RowDblClick">
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                    <telerik:RadGrid ID="grdeditablecolors" runat="server" AllowSorting="true" AllowPaging="true"
                                        BorderWidth="0" Width="70%" AutoGenerateColumns="false" OnNeedDataSource="grdeditablecolors_NeedDataSource"
                                        PageSize="20" OnItemDataBound="grdeditablecolors_ItemDataBound" OnInsertCommand="grdeditablecolors_InsertCommand"
                                        OnUpdateCommand="grdeditablecolors_UpdateCommand" HeaderStyle-Font-Bold="true"
                                        AllowFilteringByColumn="true" GridLines="None" PagerStyle-AlwaysVisible="true"
                                        OnItemCommand="RadGrid1_ItemCommand" GroupingSettings-CaseSensitive="false">
                                        <MasterTableView CommandItemDisplay="Top" TableLayout="Fixed">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="lnkAddNew" runat="server" Text="Add New Font Style" OnClientClick="javascript:recordtype();"
                                                                CommandName="InitInsert"><%=objLanguage.GetLanguageConversion("Add_New_Record")%> </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <EditFormSettings ColumnNumber="2" EditFormType="Template">
                                                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                                <FormCaptionStyle CssClass="EditFormHeader" />
                                                <FormMainTableStyle GridLines="None" CellPadding="3" CellSpacing="0" BackColor="White"
                                                    Width="100" />
                                                <FormTableStyle CellSpacing="0" CellPadding="2" Height="10px" BackColor="White" />
                                                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                                <EditColumn UniqueName="EditColumn">
                                                </EditColumn>
                                                <FormTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 8px; margin-top: 4px;
                                                        margin-bottom: 9px;" width="100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblcolorstyle" runat="server" Text="Color Style" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Color_Style")%> &nbsp;<span style="color: red;">*</span></asp:Label>
                                                                <%--  <telerik:RadTextBox ID="txtcolorstyle" EnabledStyle-Width="176px" DisabledStyle-Width="176px"
                                                                    runat="server" Text='<%# DataBinder.Eval(Container,"Dataitem.ColorStyle","{0}") %>'
                                                                    Style="margin-left: 4px; float: left;">
                                                                </telerik:RadTextBox>--%>
                                                                <asp:TextBox ID="txtcolorstyle" runat="server" Text='<%# DataBinder.Eval(Container,"Dataitem.ColorStyle","{0}") %>'
                                                                    CssClass="manage_txtboxnew estore_managecolortxtbox" Width="175px"></asp:TextBox>
                                                                <%-- <asp:RequiredFieldValidator ID="reqstyle" runat="server" ControlToValidate="txtcolorstyle"
                                                                    Display="Dynamic" ValidationGroup="V" ErrorMessage="Please enter color style"
                                                                    SetFocusOnError="true" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                <asp:RangeValidator ID="txtcyValue" runat="server" ErrorMessage="" ControlToValidate="txtcyan"
                                                                    ValidationGroup="V" Display="Dynamic" MinimumValue="0" MaximumValue="100" Type="Double"></asp:RangeValidator>
                                                                <asp:RangeValidator ID="txtmaValue" runat="server" ErrorMessage="" ControlToValidate="txtmagenta"
                                                                    ValidationGroup="V" Display="Dynamic" MinimumValue="0" MaximumValue="100" Type="Double"></asp:RangeValidator>
                                                                <asp:RangeValidator ID="txtyeValue" runat="server" ErrorMessage="" ControlToValidate="txtyellow"
                                                                    ValidationGroup="V" Display="Dynamic" MinimumValue="0" MaximumValue="100" Type="Double"></asp:RangeValidator>
                                                                <asp:RangeValidator ID="txtbkValue" runat="server" ErrorMessage="" ControlToValidate="txtblack"
                                                                    ValidationGroup="V" Display="Dynamic" MinimumValue="0" MaximumValue="100" Type="Double"></asp:RangeValidator>
                                                                <div id="spnreferror" style="display: none; width: auto; margin-left: 3px; float: left">
                                                                    <div class="RFV_Message">
                                                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion("Color_Style_already_exists")%></span>
                                                                    </div>
                                                                </div>
                                                                <div id="spnRqdStyleName" style="display: none; width: auto; margin-left: 3px; float: left">
                                                                    <div class="RFV_Message">
                                                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px;">
                                                                            <%=objLanguage.GetLanguageConversion("Please_enter_style_name")%></span>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <span id="Span1" runat="server" style="float: left; width: 28%; padding: 5px; clear: left;
                                                                    vertical-align: middle; margin: 0px 0px 2px 0px;">&nbsp;</span> <span>
                                                                        <asp:TextBox ID="lblcyan" Enabled="false" Width="2%" Style="margin-left: 4px; margin-top: 5px;"
                                                                            CssClass="textboxnew" ForeColor="Black" Font-Bold="true" BackColor="Cyan" Text="C"
                                                                            runat="server" />
                                                                        <asp:TextBox ID="txtcyan" Width="4%" MaxLength="6" onchange="javascript:return Savecmyk(this.value);"
                                                                            Style="margin-top: 5px;" onkeyup="javascript:return DisplayError(this.value,this.id,'cy');"
                                                                            onblur="javascript:todecimal_function1(this,this.value)" onkeypress="javascript:return isNumberKey(event)"
                                                                            CssClass="textboxnew" runat="server" />
                                                                        <asp:TextBox ID="lblmagenta" Width="2%" Enabled="false" CssClass="textboxnew" ForeColor="White"
                                                                            Style="margin-top: 5px;" Font-Bold="true" BackColor="Magenta" Text="M" runat="server">
                                                                        </asp:TextBox>
                                                                        <asp:TextBox ID="txtmagenta" Width="4%" MaxLength="6" onchange="javascript:return Savecmyk(this.value);"
                                                                            Style="margin-top: 5px;" onkeyup="javascript:return DisplayError(this.value,this.id,'ma');"
                                                                            onblur="javascript:todecimal_function1(this,this.value)" onkeypress="javascript:return isNumberKey(event)"
                                                                            CssClass="textboxnew" runat="server" />
                                                                        <asp:TextBox ID="lblyellow" Width="2%" Text="Y" Font-Bold="true" Enabled="false"
                                                                            Style="margin-top: 5px;" ForeColor="Black" CssClass="textboxnew" BackColor="Yellow"
                                                                            runat="server"></asp:TextBox>
                                                                        <asp:TextBox ID="txtyellow" runat="server" CssClass="textboxnew" MaxLength="6" onchange="javascript:return Savecmyk(this.value);"
                                                                            Style="margin-top: 5px;" onkeyup="javascript:return DisplayError(this.value,this.id,'ye');"
                                                                            onblur="javascript:todecimal_function1(this,this.value)" onkeypress="javascript:return isNumberKey(event)"
                                                                            Width="4%"></asp:TextBox>
                                                                        <asp:TextBox ID="lblblack" runat="server" Font-Bold="true" Enabled="false" BackColor="Black"
                                                                            Text="K" ForeColor="White" Style="margin-top: 5px;" CssClass="textboxnew" Width="2%"></asp:TextBox>
                                                                        <asp:TextBox ID="txtblack" runat="server" Width="4%" MaxLength="6" onchange="javascript:return Savecmyk(this.value);"
                                                                            Style="margin-top: 5px;" onkeyup="javascript:return DisplayError(this.value,this.id,'bk');"
                                                                            onblur="javascript:todecimal_function1(this,this.value)" onkeypress="javascript:return isNumberKey(event)"
                                                                            CssClass="textboxnew"></asp:TextBox>
                                                                        <asp:TextBox ID="txtselectedcolor" Width="5%" Enabled="false" Visible="true" CssClass="textboxnew"
                                                                            Style="margin-top: 5px;" runat="server"></asp:TextBox>
                                                                    </span><span>
                                                                        <asp:LinkButton ID="lnkselectcolor" ForeColor="#224575" Style="vertical-align: bottom;"
                                                                            runat="server"><%=objLanguage.GetLanguageConversion("Select_Color") %><%=colorformat %></asp:LinkButton></span>
                                                                <span>
                                                                    <asp:HiddenField ID="hdn_colorid" runat="server" Value='<%# Bind("ColorID")%>' />
                                                                    <asp:HiddenField ID="hdn_r" runat="server" Value='<%# Bind("R")%>' />
                                                                    <asp:HiddenField ID="hdn_g" runat="server" Value='<%# Bind("G")%>' />
                                                                    <asp:HiddenField ID="hdn_b" runat="server" Value='<%# Bind("B")%>' />
                                                                    <asp:HiddenField ID="hdn_a" runat="server" Value='<%# Bind("A")%>' />
                                                                    <asp:HiddenField ID="hdn_cval" runat="server" Value='<%# Bind("C")%>' />
                                                                    <asp:HiddenField ID="hdn_mval" runat="server" Value='<%# Bind("M")%>' />
                                                                    <asp:HiddenField ID="hdn_yval" runat="server" Value='<%# Bind("Y")%>' />
                                                                    <asp:HiddenField ID="hdn_kval" runat="server" Value='<%# Bind("K")%>' />
                                                                    <asp:HiddenField ID="hdnR" runat="server" Value="" />
                                                                    <asp:HiddenField ID="hdnG" runat="server" Value="" />
                                                                    <asp:HiddenField ID="hdnB" runat="server" Value="" />
                                                                </span>
                                                                <asp:Label ID="lblError" runat="server" ForeColor="" CssClass="RFV_Message " Style="display: none;
                                                                    margin-left: 5px; margin-top: 2px; margin-bottom: 1px; float: left; width: auto;
                                                                    padding-left: 4px; padding-right: 4px;"><%=objLanguage.GetLanguageConversion("The_value_must_be_between_0_to_100")%></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <span id="Span2" runat="server" style="float: left; width: 28%; padding: 5px; clear: left;
                                                                    vertical-align: middle; margin: 0px 0px -5px 0px;">&nbsp;</span> <span>
                                                                        <telerik:RadButton ID="btnToggle" runat="server" AutoPostBack="false" ToggleType="CheckBox"
                                                                            ButtonType="ToggleButton">
                                                                            <ToggleStates>
                                                                                <telerik:RadButtonToggleState Text="" />
                                                                                <telerik:RadButtonToggleState Text="" />
                                                                            </ToggleStates>
                                                                        </telerik:RadButton>
                                                                        <asp:HiddenField ID="hdn_chkspotcolor" runat="server" Value='<%# Bind("SpotColor")%>' />
                                                                    </span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblspotcolor" runat="server" Text="Spot Color Reference" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Spot_Color_Reference")%><%=colorformat %><%=objLanguage.GetLanguageConversion("Reference")%></asp:Label>
                                                                <%--  <telerik:RadTextBox ID="txtspotcolor" EnabledStyle-Width="176px" DisabledStyle-Width="176px"
                                                                    Text='<%#DataBinder.Eval(Container,"Dataitem.SpotColorRef","{0}")%>' runat="server"
                                                                    Style="margin-left: 4px; float: left;">
                                                                </telerik:RadTextBox>--%>
                                                                <asp:TextBox ID="txtspotcolor" Text='<%#DataBinder.Eval(Container,"Dataitem.SpotColorRef","{0}")%>'
                                                                    runat="server" CssClass="manage_txtboxnew estore_managecolortxtbox"></asp:TextBox>
                                                                <%-- <asp:RequiredFieldValidator ID="reqSpotcolor" runat="server" ControlToValidate="txtspotcolor"
                                                                    Enabled="false" ValidationGroup="V" ForeColor="Red" Text=""><%=objLanguage.GetLanguageConversion("Please_enter_spot_color_reference")%></asp:RequiredFieldValidator>--%>
                                                                <div id="divspotcolorerror" style="display: none; margin-left: 3px; float: left">
                                                                    <div class="RFV_Message">
                                                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                                                            <%=objLanguage.GetLanguageConversion("Please_enter_spot_color_reference")%></span>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbltint" runat="server" Text="Tint" CssClass="bglabel"><%=objLanguage.GetLanguageConversion("Tint") %></asp:Label>
                                                                <%--  <telerik:RadNumericTextBox ID="txttint" runat="server" EnabledStyle-Width="66px"
                                                                    ClientEvents-OnLoad="DefaultValue" DisabledStyle-Width="66px" Text='<%#DataBinder.Eval(Container,"Dataitem.Tint","{0}")%>'
                                                                    Style="margin-left: 4px">
                                                                    <NumberFormat AllowRounding="false" />
                                                                </telerik:RadNumericTextBox>--%>
                                                                <asp:TextBox ID="txttint" runat="server" Text='<%#DataBinder.Eval(Container,"Dataitem.Tint","{0}")%>'
                                                                    value="100.00" CssClass="manage_tinttxtboxnew" onblur="javascript:todecimal_function1(this,this.value);"
                                                                    Style="float: left">
                                                                                                                                        
                                                                </asp:TextBox>
                                                                <span>%</span>
                                                                <asp:RangeValidator ID="rngValidtint" runat="server" ValidationGroup="V" ControlToValidate="txttint"
                                                                    Type="Double" MinimumValue="0" ForeColor="" SetFocusOnError="true" MaximumValue="100"
                                                                    CssClass="RFV_Message" Style="width: auto; padding-left: 4px; padding-right: 4px;
                                                                    margin-right: 23%; float: right" ErrorMessage=""><%=objLanguage.GetLanguageConversion("The_value_must_be_between_0_to_100")%></asp:RangeValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Label ID="Label2" runat="server" Width="30%" CssClass="bglabelempty"></asp:Label>
                                                                <%--<telerik:RadColorPicker ID="RadColorPicker1" Preset="Default" PaletteModes="RGBSliders"
                                                                        ShowIcon="false" SelectedColor="Red" runat="server">
                                                                    </telerik:RadColorPicker>--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div style="margin-left: 23.5%;">
                                                        <div align="right" style="width: 10%; margin-bottom: 40%; display: inline">
                                                            <%---test ---%>
                                                        </div>
                                                    </div>
                                                    <div style="margin-top: 5px">
                                                        <asp:Label ID="Label3" runat="server" CssClass="bglabelEmpty" Width="29.5%"></asp:Label>
                                                        <asp:Button Text="Cancel" ID="btncancel" CssClass="button" runat="server" CommandName="Cancel" />
                                                        <asp:Button Text="Save" ID="btnsavecolor" CssClass="button" runat="server" CausesValidation="true"
                                                            OnClientClick="if (!validateSpotColor(this)) {return false;}" ValidationGroup="V"
                                                            CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>' />
                                                        <div class="clearBoth" style="height: 8px">
                                                        </div>
                                                    </div>
                                                </FormTemplate>
                                            </EditFormSettings>
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-Width="7.5%" ItemStyle-Width="7.5%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <div style="float: left">
                                                            <div style="float: left; display: none;">
                                                                <input id="Checkbox1" type="checkbox" onclick="checkAll(this);" runat="server" name="checkAll" />
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
                                                        <div style="padding-left: 2px;">
                                                            <input type="checkbox" runat="server" id="Id" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.ColorID", "{0}") %>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                                    DataField="ColorStyle" HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Left"
                                                    ItemStyle-HorizontalAlign="Left">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblhdr1" runat="server"><%=objLanguage.GetLanguageConversion("Color_Style") %></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcolorstyle" runat="server" Style="cursor: pointer;" Width="100%"
                                                            Text='<%# DataBinder.Eval(Container,"Dataitem.ColorStyle","{0}") %>' ToolTip='<%# DataBinder.Eval(Container,"Dataitem.ColorStyle","{0}") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-Width="30%" ItemStyle-Width="30%">
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblcmykcolorheader" Width="100%" runat="server"><%=objLanguage.GetLanguageConversion("CMYK_Color") %><%=colorformat %> </asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcmykcode" Style="cursor: pointer;" Width="100%" runat="server"></asp:Label>
                                                        <asp:HiddenField ID="hdn_colorid" runat="server" Value='<%# Bind("ColorID")%>' />
                                                        <asp:HiddenField ID="hdn_pr" runat="server" Value='<%# Bind("R")%>' />
                                                        <asp:HiddenField ID="hdn_pg" runat="server" Value='<%# Bind("G")%>' />
                                                        <asp:HiddenField ID="hdn_pb" runat="server" Value='<%# Bind("B")%>' />
                                                        <asp:HiddenField ID="hdn_pa" runat="server" Value='<%# Bind("A")%>' />
                                                        <asp:HiddenField ID="hdn_pcval" runat="server" Value='<%# Bind("C")%>' />
                                                        <asp:HiddenField ID="hdn_pmval" runat="server" Value='<%# Bind("M")%>' />
                                                        <asp:HiddenField ID="hdn_pyval" runat="server" Value='<%# Bind("Y")%>' />
                                                        <asp:HiddenField ID="hdn_pkval" runat="server" Value='<%# Bind("K")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Spot Colour Name"
                                                    AllowFiltering="false" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%"
                                                    ItemStyle-Width="20%">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <asp:Label ID="lblspotcolorname" Text="Spot Color Reference" Width="100%" runat="server"><%=objLanguage.GetLanguageConversion("Spot_Color_Reference")%><%=colorformat %><%=objLanguage.GetLanguageConversion("_Name")%></asp:Label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="float: left">
                                                            <asp:Label ID="lblspotcolorname" runat="server" Style="cursor: pointe;" Width="100%"
                                                                Text='<%# DataBinder.Eval(Container,"Dataitem.SpotColorRef","{0}") %>'></asp:Label>
                                                            <asp:HiddenField ID="hdnspotColorRef" runat="server" Value='<%# Bind("SpotColorRef")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Action"
                                                    AllowFiltering="false" HeaderStyle-HorizontalAlign="Center">
                                                    <HeaderStyle Font-Bold="true" />
                                                    <HeaderTemplate>
                                                        <center>
                                                            <asp:Label ID="Label1" Text="Action" Width="100%" runat="server"><%=objLanguage.GetLanguageConversion("Action") %></asp:Label></center>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div style="margin-left: 13px; float: none">
                                                            <center>
                                                                <asp:ImageButton ID="imgbtncolorDelete" runat="server" ToolTip="delete" ImageUrl="~/Images/erase.png"
                                                                    CommandArgument='<%#Eval("ColorID") %>' OnCommand="imgbtncolorDelete_OnClick"
                                                                    OnClientClick="javascript:return imgbtnDelete_ClientClick('color');" /></center>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                        <ClientSettings EnableRowHoverStyle="true" ClientEvents-OnRowClick="RowDblClick">
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                    <asp:HiddenField ID="hdn_c" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdn_m" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdn_y" runat="server" Value="0" />
                                    <asp:HiddenField ID="hdn_k" runat="server" Value="0" />
                                    <asp:UpdatePanel ID="updpnl" runat="server">
                                        <ContentTemplate>
                                            <asp:HiddenField ID="cgridid" runat="server" Value="0" />
                                            <asp:HiddenField ID="mgridid" runat="server" Value="0" />
                                            <asp:HiddenField ID="ygridid" runat="server" Value="0" />
                                            <asp:HiddenField ID="kgridid" runat="server" Value="0" />
                                            <asp:HiddenField ID="cgrideditid" runat="server" Value="0" />
                                            <asp:HiddenField ID="mgrideditid" runat="server" Value="0" />
                                            <asp:HiddenField ID="ygrideditid" runat="server" Value="0" />
                                            <asp:HiddenField ID="kgrideditid" runat="server" Value="0" />
                                            <asp:HiddenField ID="hdncasetype" runat="server" Value="" />
                                            <asp:HiddenField ID="hdncolor" runat="server" Value="" />
                                            <asp:HiddenField ID="hdncoloredit" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnvalidateedit" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnvlidateadd" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnrecordtype" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnred" runat="server" Value="" />
                                            <asp:HiddenField ID="hdngreen" runat="server" Value="" />
                                            <asp:HiddenField ID="hdnblue" runat="server" Value="" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                                        <script type="text/javascript">
                                            function RowDblClick(sender, eventArgs) {
                                                document.getElementById("<%=hdnrecordtype.ClientID %>").value = 'editrow';
                                                document.getElementById("<%= hdnred.ClientID %>").value = "";
                                                document.getElementById("<%= hdngreen.ClientID %>").value = "";
                                                document.getElementById("<%= hdnblue.ClientID %>").value = "";
                                                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                            }
                                        </script>
                                    </telerik:RadCodeBlock>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="Select Color"
            Behaviors="Move,Close" OnClientClose="SaveColor" VisibleStatusbar="false" Modal="true">
            <Windows>
                <telerik:RadWindow ID="colorpicker" DestroyOnClose="true" Width="290" Height="270"
                    runat="server">
                    <ContentTemplate>
                        <div id="popup" style="width: 50%; margin-left: 10px;">
                            <table>
                                <tr>
                                    <td>
                                        <telerik:RadColorPicker ID="RadColorPicker1" CssClass="NoColorButton" AutoPostBack="true"
                                            OnClientColorPreview="rgb2cmyk" Preset="Default" PaletteModes="HSV" ShowIcon="false"
                                            runat="server">
                                        </telerik:RadColorPicker>
                                    </td>
                                </tr>
                                <%--<tr>
                                        <td colspan="2">
                                            <span>*</span>
                                            <asp:Label ID="lblmsg" CssClass="smallerfontgrey" Text="Please select the colour & Click on Apply to convert into CMYK"
                                                runat="server" />
                                        </td>
                                    </tr>--%>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
        <asp:HiddenField ID="hdn_fontnames" runat="server" Value="" />
        <asp:HiddenField ID="hdn_colornames" runat="server" Value="" />
        <asp:HiddenField ID="hdnR" runat="server" Value='<%# Bind("R")%>' />
        <asp:HiddenField ID="hdnG" runat="server" Value='<%# Bind("G")%>' />
        <asp:HiddenField ID="hdnB" runat="server" Value='<%# Bind("B")%>' />
    </div>
    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock1">
        <script type="text/javascript">

            var preview = false;
            var cy = 0;
            var me = 0;
            var ye = 0;
            var kb = 0;
            var IsApply = false;
            var IsOpen = false;


            function validateSpotColor(obj) {
                var valid = true;
                var colorid = document.getElementById(obj.id.replace('btnsavecolor', 'hdn_colorid'));
                var ckeckbox = document.getElementById(obj.id.replace('btnsavecolor', 'btnToggle'));
                var txtspot = document.getElementById(obj.id.replace('btnsavecolor', 'txtspotcolor'));
                var req = document.getElementById(obj.id.replace('btnsavecolor', 'reqSpotcolor'));
                var txttint = document.getElementById(obj.id.replace('btnsavecolor', 'txttint'));
                var txtStyleName = document.getElementById(obj.id.replace('btnsavecolor', 'txtcolorstyle'));
                var hdnfontnames = document.getElementById("<%=hdn_fontnames.ClientID %>");
                var action = document.getElementById("<%=hdnrecordtype.ClientID %>").value;
                var splitval = hdnfontnames.value.split(',');

                if (txtStyleName.value == "") {
                    document.getElementById("spnRqdStyleName").style.display = "block";
                    document.getElementById("spnreferror").style.display = "none";
                    txtStyleName.focus();
                    valid = false;
                }
                else {
                    document.getElementById("spnRqdStyleName").style.display = "none";
                    for (var i = 0; i < splitval.length; i++) {
                        if (splitval[i].trim() != "") {
                            var Name_ID = splitval[i].trim().split('~');
                            var Name = Name_ID[0].trim();
                            var ID = Name_ID[1].trim();
                            if (action == 'addnew') {
                                if (Name.toLowerCase() == txtStyleName.value.trim().toLowerCase()) {
                                    document.getElementById("spnreferror").style.display = "block";
                                    document.getElementById("spnRqdStyleName").style.display = "none";
                                    valid = false;
                                }
                            }
                            else {
                                if (ID != colorid.value) {
                                    if (Name.toLowerCase() == txtStyleName.value.trim().toLowerCase()) {
                                        document.getElementById("spnreferror").style.display = "block";
                                        document.getElementById("spnRqdStyleName").style.display = "none";
                                        valid = false;
                                    }
                                }
                            }
                        }
                    }
                }


                var status = ckeckbox.control._checked;
                if (status == true) {
                    if (txtspot.value == "") {
                        document.getElementById("divspotcolorerror").style.display = "block";
                        valid = false;
                    }
                    else {
                        document.getElementById("divspotcolorerror").style.display = "none";
                    }
                }
                else {
                    document.getElementById("divspotcolorerror").style.display = "none";
                }
                if (valid) {
                    return true;
                }
                else {
                    return false;
                }
            }


            function recordtype() {
                document.getElementById("<%=hdnrecordtype.ClientID %>").value = 'addnew';
                document.getElementById("<%=hdncasetype.ClientID %>").value = 'add';
            }

            function isNumberKey(evt) {
                var charCode = (evt.which) ? evt.which : event.keyCode
                if (charCode == 46) {
                    return true;
                }
                if (charCode > 31 && (charCode < 48 || charCode > 57))
                    return false;

                return true;
            }

            function DefaultValue(id) {
                if (sender.isEmpty()) {
                    sender.set_value(100.00);
                }
            }
            function Eprint_ReturnFinal_Formated_Amount1(Amount) {
                var settingScale = '2';
                return roundNumber_new(Amount, settingScale);
            }

            function todecimal_function1(txtobj) {
                var value = txtobj.value;
                if (!isNaN(txtobj.value) && Number(txtobj.value)) {
                    txtobj.value = Eprint_ReturnFinal_Formated_Amount1(txtobj.value);
                }
                else {
                    txtobj.value = Eprint_ReturnFinal_Formated_Amount1(0);
                }
            }

            function DisplayError(value, id, type) {
                var lblError;
                if (type == 'cy') {
                    var Rplc = id.replace('txtcyan', 'lblError');
                    lblError = Rplc;
                }
                else if (type == 'ma') {
                    var Rplc = id.replace('txtmagenta', 'lblError');
                    lblError = Rplc;
                }
                else if (type == 'ye') {
                    var Rplc = id.replace('txtyellow', 'lblError');
                    lblError = Rplc;
                }
                else if (type == 'bk') {
                    var Rplc = id.replace('txtblack', 'lblError');
                    lblError = Rplc;
                }
                if (value > 100) {
                    document.getElementById(lblError).style.display = "block";
                }
                else {
                    if (lblError != null) {
                        document.getElementById(lblError).style.display = "none";
                    }
                }
            }

            function Validate(Id) {
                var cyanid = Id.replace('btnsavecolor', 'txtcyan');
                var magid = Id.replace('btnsavecolor', 'txtmagenta');
                var yelid = Id.replace('btnsavecolor', 'txtyellow');
                var blkid = Id.replace('btnsavecolor', 'txtblack');

                var cy, mag, yel, blk;
                cy = document.getElementById(cyanid).value;
                mag = document.getElementById(magid).value;
                yel = document.getElementById(yelid).value;
                blk = document.getElementById(blkid).value;
                if (cy > 100 || mag > 100 || yel > 100) {
                    return false;
                }
                else {
                    return true;
                }
            }

            function validateduplicate(textbox, txtval, action) {
                var textvalue = txtval;
                var count = 0;
                var hdnfontnames = document.getElementById("<%=hdn_fontnames.ClientID %>");
                var splitval = hdnfontnames.value.split(',');
                if (textvalue != "") {
                    for (var i = 0; i < splitval.length; i++) {
                        if (splitval[i] == textvalue.trim()) {
                            count = Number(count) + 1;
                        }
                    }
                }
                if (action == "add" && Number(count) > 0) {
                    document.getElementById("spnreferror").style.display = "none";
                    document.getElementById("spnRqdStyleName").style.display = "none";
                    //textbox.value = "";
                }
                else if (action == "edit" && Number(count) >= 1) {
                    document.getElementById("spnreferror").style.display = "none";
                    document.getElementById("spnRqdStyleName").style.display = "none";
                    //textbox.value = "";
                }
                else {
                    document.getElementById("spnreferror").style.display = "none";
                    document.getElementById("spnRqdStyleName").style.display = "none";
                }
            }

            function showwindow(colorid) {
                IsOpen = true;
                IsApply = true;
                preview = true;
                if (colorid == '') {
                    document.getElementById("<%=hdncasetype.ClientID %>").value = 'add';
                }
                else {
                    document.getElementById("<%=hdncasetype.ClientID %>").value = 'edit';
                }
                var oWnd = $find("<%=colorpicker.ClientID%>");
                document.getElementById("divBackGroundNew").style.display = "block";
                oWnd.show();
                document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_emptycolor").style.display = "none";

            }

            function hidewindow() {
                var oWnd = $find("<%=colorpicker.ClientID%>");
                document.getElementById("divBackGroundNew").style.display = "none";
                oWnd.close();
            }

            function SaveColor(sender, eventArgs) {
                IsOpen = false;
                var selectedcolor = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_hexInput").value;
                var r = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").value;
                var g = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").value;
                var b = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").value;

                document.getElementById("<%= hdnred.ClientID %>").value = r;
                document.getElementById("<%= hdngreen.ClientID %>").value = g;
                document.getElementById("<%= hdnblue.ClientID %>").value = b;

                var colorpicker = $find("<%=colorpicker.ClientID%>");
            }

            function Savecmyk(val) {
                if (val > 100) {

                    return false;
                }
                if (document.getElementById("<%=hdnrecordtype.ClientID %>").value == 'addnew' && document.getElementById("<%=hdncasetype.ClientID %>").value == 'add') {
                    var cy = document.getElementById(document.getElementById("<%= cgridid.ClientID %>").value).value;
                    var me = document.getElementById(document.getElementById("<%= mgridid.ClientID %>").value).value;
                    var ye = document.getElementById(document.getElementById("<%= ygridid.ClientID %>").value).value;
                    var kb = document.getElementById(document.getElementById("<%= kgridid.ClientID %>").value).value;

                    var r, g, b;
                    if (cy <= 100 && me <= 100 && ye <= 100 && kb <= 100) {
                        var c = cy / 100;
                        var m = me / 100;
                        var y = ye / 100;
                        var k = kb / 100;

                        r = 1 - Math.min(1, c * (1 - k) + k);
                        g = 1 - Math.min(1, m * (1 - k) + k);
                        b = 1 - Math.min(1, y * (1 - k) + k);

                        var red = Math.round(r * 255);
                        var green = Math.round(g * 255);
                        var blue = Math.round(b * 255);

                        AutoFill.GetColor(red, green, blue, GetResult, onTimeout, onError);

                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_emptycolor").style.display = "none";

                        document.getElementById(document.getElementById("<%= cgridid.ClientID %>").value).value = cy;
                        document.getElementById(document.getElementById("<%= mgridid.ClientID %>").value).value = me;
                        document.getElementById(document.getElementById("<%= ygridid.ClientID %>").value).value = ye;
                        document.getElementById(document.getElementById("<%= kgridid.ClientID %>").value).value = kb;
                    }



                }
                else {
                    var cy = document.getElementById(document.getElementById("<%= cgrideditid.ClientID %>").value).value;
                    var me = document.getElementById(document.getElementById("<%= mgrideditid.ClientID %>").value).value;
                    var ye = document.getElementById(document.getElementById("<%= ygrideditid.ClientID %>").value).value;
                    var kb = document.getElementById(document.getElementById("<%= kgrideditid.ClientID %>").value).value;

                    var r, g, b;
                    if (cy <= 100 && me <= 100 && ye <= 100 && kb <= 100) {
                        var c = cy / 100;
                        var m = me / 100;
                        var y = ye / 100;
                        var k = kb / 100;

                        r = 1 - Math.min(1, c * (1 - k) + k);
                        g = 1 - Math.min(1, m * (1 - k) + k);
                        b = 1 - Math.min(1, y * (1 - k) + k);

                        var red = Math.round(r * 255);
                        var green = Math.round(g * 255);
                        var blue = Math.round(b * 255);

                        AutoFill.GetColor(red, green, blue, GetResult, onTimeout, onError);

                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").disabled = true;
                        document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_emptycolor").style.display = "none";

                        document.getElementById(document.getElementById("<%= cgrideditid.ClientID %>").value).value = cy;
                        document.getElementById(document.getElementById("<%= mgrideditid.ClientID %>").value).value = me;
                        document.getElementById(document.getElementById("<%= ygrideditid.ClientID %>").value).value = ye;
                        document.getElementById(document.getElementById("<%= kgrideditid.ClientID %>").value).value = kb;
                    }

                }
            }

            function GetResult(result) {
                var color = result;
                var colorPicker = $find('<%= RadColorPicker1.ClientID%>');
                if (document.getElementById("<%=hdnrecordtype.ClientID %>").value == 'addnew' && document.getElementById("<%=hdncasetype.ClientID %>").value == 'add') {
                    document.getElementById(document.getElementById("<%= hdncolor.ClientID %>").value).style.background = color;
                    colorPicker.set_selectedColor(color);
                    var r = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").value;
                    var g = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").value;
                    var b = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").value;

                    document.getElementById("<%= hdnred.ClientID %>").value = r;
                    document.getElementById("<%= hdngreen.ClientID %>").value = g;
                    document.getElementById("<%= hdnblue.ClientID %>").value = b;
                    return false;
                }
                else {
                    document.getElementById(document.getElementById("<%= hdncoloredit.ClientID %>").value).style.background = color;
                    colorPicker.set_selectedColor(color);
                    var r = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").value;
                    var g = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").value;
                    var b = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").value;

                    document.getElementById("<%= hdnred.ClientID %>").value = r;
                    document.getElementById("<%= hdngreen.ClientID %>").value = g;
                    document.getElementById("<%= hdnblue.ClientID %>").value = b;
                    return false;
                }
            }

            function onTimeout(request, context) { }

            function onError(objError) { }

            function rgb2cmyk(sender, eventArgs) {
                var colorPicker = $find('<%= RadColorPicker1.ClientID%>');
                var computedC = 0;
                var computedM = 0;
                var computedY = 0;
                var computedK = 0;

                if (IsOpen == true) {
                    var r = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").value;
                    var g = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").value;
                    var b = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").value;

                    var selectedcolor = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_hexInput").value;

                    if (r != 0 || g != 0 || b != 0) {
                        computedC = 1 - (r / 255);
                        computedM = 1 - (g / 255);
                        computedY = 1 - (b / 255);

                        var minCMY = Math.min(computedC,
                            Math.min(computedM, computedY));
                        computedC = (computedC - minCMY) / (1 - minCMY);
                        computedM = (computedM - minCMY) / (1 - minCMY);
                        computedY = (computedY - minCMY) / (1 - minCMY);
                        computedK = minCMY;

                        document.getElementById("<%= hdn_c.ClientID %>").value = computedC.toPrecision(4);
                        document.getElementById("<%= hdn_m.ClientID %>").value = computedM.toPrecision(4);
                        document.getElementById("<%= hdn_y.ClientID %>").value = computedY.toPrecision(4);
                        document.getElementById("<%= hdn_k.ClientID %>").value = computedK.toPrecision(4);
                        //to grid textbox

                        if (document.getElementById("<%=hdncasetype.ClientID %>").value == 'add' && document.getElementById("<%=hdnrecordtype.ClientID %>").value == 'addnew') {
                            var grdc = document.getElementById(document.getElementById("<%= cgridid.ClientID %>").value).value;
                            var grdm = document.getElementById(document.getElementById("<%= mgridid.ClientID %>").value).value;
                            var grdy = document.getElementById(document.getElementById("<%= ygridid.ClientID %>").value).value;
                            var grdk = document.getElementById(document.getElementById("<%= kgridid.ClientID %>").value).value;

                            if (!IsApply) {
                                document.getElementById(document.getElementById("<%= cgridid.ClientID %>").value).value = Math.round(computedC * 100);
                                document.getElementById(document.getElementById("<%= mgridid.ClientID %>").value).value = Math.round(computedM * 100);
                                document.getElementById(document.getElementById("<%= ygridid.ClientID %>").value).value = Math.round(computedY * 100);
                                document.getElementById(document.getElementById("<%= kgridid.ClientID %>").value).value = Math.round(computedK * 100);
                                document.getElementById(document.getElementById("<%= hdncolor.ClientID %>").value).style.background = selectedcolor;
                            }
                            else {

                                document.getElementById(document.getElementById("<%= cgridid.ClientID %>").value).value = grdc;
                                document.getElementById(document.getElementById("<%= mgridid.ClientID %>").value).value = grdm;
                                document.getElementById(document.getElementById("<%= ygridid.ClientID %>").value).value = grdy;
                                document.getElementById(document.getElementById("<%= kgridid.ClientID %>").value).value = grdk;
                                document.getElementById(document.getElementById("<%= hdncolor.ClientID %>").value).style.background = selectedcolor;
                            }

                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").disabled = true;
                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").disabled = true;
                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").disabled = true;
                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_emptycolor").style.display = "none";
                            IsApply = false;
                        }
                        else {
                            var grdc = document.getElementById(document.getElementById("<%= cgrideditid.ClientID %>").value).value;
                            var grdm = document.getElementById(document.getElementById("<%= mgrideditid.ClientID %>").value).value;
                            var grdy = document.getElementById(document.getElementById("<%= ygrideditid.ClientID %>").value).value;
                            var grdk = document.getElementById(document.getElementById("<%= kgrideditid.ClientID %>").value).value;
                            if (!IsApply) {
                                document.getElementById(document.getElementById("<%= cgrideditid.ClientID %>").value).value = Math.round(computedC * 100);
                                document.getElementById(document.getElementById("<%= mgrideditid.ClientID %>").value).value = Math.round(computedM * 100);
                                document.getElementById(document.getElementById("<%= ygrideditid.ClientID %>").value).value = Math.round(computedY * 100);
                                document.getElementById(document.getElementById("<%= kgrideditid.ClientID %>").value).value = Math.round(computedK * 100);
                                document.getElementById(document.getElementById("<%= hdncoloredit.ClientID %>").value).style.background = selectedcolor;

                            }
                            else {
                                document.getElementById(document.getElementById("<%= cgrideditid.ClientID %>").value).value = grdc;
                                document.getElementById(document.getElementById("<%= mgrideditid.ClientID %>").value).value = grdm;
                                document.getElementById(document.getElementById("<%= ygrideditid.ClientID %>").value).value = grdy;
                                document.getElementById(document.getElementById("<%= kgrideditid.ClientID %>").value).value = grdk;
                                document.getElementById(document.getElementById("<%= hdncoloredit.ClientID %>").value).style.background = selectedcolor;

                            }

                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").disabled = true;
                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").disabled = true;
                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").disabled = true;
                            document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_emptycolor").style.display = "none";
                            IsApply = false;
                        }
                    }
                }
                return false;
                document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_rInput").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_gInput").disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_bInput").disabled = true;
            }

            function imgbtnDelete_ClientClick(type) {
                if (type == 'font') {

                    return window.confirm("Are you sure you want to delete this Font Styles?");
                }
                else if (type == 'color') {
                    return window.confirm("Are you sure you want to delete this Color Styles?");
                }
            }

            function imgbtnDelete_ClientClickGeneral() {
                var frm = document.forms[0];
                var selectall = document.getElementById("ctl00_ContentPlaceHolder1_grdeditablefonts_ctl00_ctl02_ctl02_checkAll");
                var Check = document.forms[0].getElementsByTagName("input");
                var boolChecked = false;
                for (i = 0; i < frm.length; i++) {
                    var e = frm.elements[i];
                    if (e.type == 'checkbox' && e.id.indexOf('Id') != -1) {
                        if (e.checked == true) {
                            boolChecked = true;
                        }
                    }
                }
                if (boolChecked) {
                    return window.confirm("Are you sure you want to delete these selected items?");
                }
                else {
                    window.alert("Please select at least one checkbox to delete.");
                    return false;
                }
            }

        </script>
    </telerik:RadScriptBlock>
    <script type="text/javascript">
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var img_actionsShow = document.getElementById("img_actionsShow");

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
</asp:Content>


