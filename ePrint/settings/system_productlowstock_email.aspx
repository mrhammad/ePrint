<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="system_productlowstock_email.aspx.cs" Inherits="ePrint.settings.system_productlowstock_email" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/animation.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <script src="../js/item/general.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <script type="text/javascript">
        function hidetype() {

        }

        function desableAfterLoad() {
            window.document.getElementById("div_Load").style.display = "none";
        }
    </script>
    <style>
        .reContentArea
        {
            font-family: Arial !important;
            font-size: 14px !important;
        }
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
            margin-top: -8px;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdLowStockEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdLowStockEmail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdLowStockEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdLowStockEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtemailtempname" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdLowStockEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtSubject" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdLowStockEmail">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkDefaultEmailBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdLowStockEmail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
    <div align="left" id="pnlproductlowstockemaildetails">
        <div align="left">
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblheader"><%=objLanguage.GetLanguageConversion("Product_Stock_Reminder_Email")%></asp:Label>
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
            <div class="">
                <div align="left" style="width: 100%;" class="mis_header_panel">
                    <div id="">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table cellpadding="1" cellspacing="1" border="0" width="100%">
                            <tr>
                                <td valign="top" style="width: 233px;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                </td>
                                <td valign="top">
                                    <div align="left" style="width: 60%;">
                                        <div style="width: 40%; float: left;">
                                            <div style="float: left;">
                                            </div>
                                            <div style="float: left">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div id="div_popupAction" style="margin: 48px 0px 0px 8px;" onmouseover="show();"
                                                            onmouseout="hide(); ">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div style="width: 100%;">
                                                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                                                <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" CommandName="Delete"
                                                                                    Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CheckOne_new_emailbody();"
                                                                                    CausesValidation="false" OnClick="lnkMultidelete_Onclick"></asp:LinkButton></div>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="a">
                                    </div>
                                    <div id="div_Grid" style="width: 1000px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false"
                                            runat="server">
                                            <ContentTemplate>
                                                <telerik:RadGrid ID="grdLowStockEmail" AutoGenerateColumns="false" runat="server"
                                                    BorderWidth="0" ItemStyle-Heigh="2%" GridLines="None" AllowPaging="true" PageSize="50"
                                                    Width="60%" PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true" OnItemDataBound="grdLowStockEmail_OnItemDataBound">
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <CommandItemTemplate>
                                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:LinkButton ID="lnkAddNew" runat="server" Text="" OnClick="lnkAddNew_OnClik"
                                                                            OnClientClick="javascript:addnew('add');"><%=objLanguage.GetLanguageConversion("Add_New_Record") %></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </CommandItemTemplate>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                                AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                                <HeaderTemplate>
                                                                    <div id="div_chk" style="width: inherit; height: inherit;">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <input type="checkbox" id="checkAll1" onclick="checkAll_new_emailrecords(this);"
                                                                                        runat="server" name="checkAll1" />
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
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="padding-left: 4px;">
                                                                        <input type="checkbox" runat="server" id="chkEmailBodyId1" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.EmailID", "{0}") %>'
                                                                            onclick="CheckChanged();" />
                                                                    </div>
                                                                    <input type="hidden" id="hdnUPDOWN" runat="server" /></ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Template Name" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-Wrap="false" ItemStyle-Width="35%" HeaderStyle-Width="35%" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkTemplateName" Width="99%" runat="server" CommandArgument='<%#Eval("EmailID")%>'
                                                                        Text='<%#Eval("TemplateName")%>' OnClick="lnktemplate_OnClick" OnClientClick="javascript:return addnew('edit');"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-Wrap="false" ItemStyle-Width="25%" HeaderStyle-Width="25%" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkSubject" Width="99%" runat="server" CommandArgument='<%#Eval("EmailID")%>'
                                                                        Text='<%#Eval("Subject")%>' OnClick="lnktemplate_OnClick" OnClientClick="javascript:return addnew('edit');"></asp:LinkButton>
                                                                    <%--'<%#Eval("Subject")%>'--%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Default" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:Image ID="imgdefault" runat="server"></asp:Image>
                                                                        <asp:HiddenField ID="hdnDefaultVal" Value='<%#Eval("Isdefault")%>' runat="server" />
                                                                    </center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                            CommandArgument='<%#Eval("EmailID")%>' Text="Delete" UniqueName="DeleteColumn"
                                                                            runat="server" OnCommand="lnkDelete_onclick" ToolTip="Delete" OnClientClick="javascript:return window.confirm('Are you sure you want to delete this?');">
                                                                        </asp:ImageButton></center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView><ClientSettings>
                                                    </ClientSettings>
                                                </telerik:RadGrid></ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div align="left" style="width: 100%;" id="EmaiBody">
                                        <div align="left">
                                        </div>
                                        <div id="div_Load" class="loading_new" style="display: none;">
                                            <UC:Loading ID="ucLoading" runat="server" />
                                        </div>
                                        <div id="tdaddnew" align="left" style="width: 100%; display: none;">
                                            <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div id="tdemailaddnew" align="left" style="width: 100%;">
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="spnTempName">
                                                                    <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Email_Template_Name")%></asp:Label></span><span
                                                                        style="color: Red;">*</span>
                                                            </div>
                                                            <asp:Label ID="lblemail" runat="server" Style="display: none"></asp:Label>
                                                            <div class="box" style="width: 60%">
                                                                <asp:TextBox runat="server" ID="txtemailtempname" SkinID="textPad" Width="200px"
                                                                    TextMode="singleline" MaxLength="255">
                                                                </asp:TextBox>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                                <span id="spn_txtemailtempname" class="spanerrorMsg" style="display: none; width: auto;
                                                                    padding-left: 4px; padding-right: 4px;">Please enter template name</span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div id="div_SubJect" align="left" style="width: 100%;">
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="Span1">
                                                                    <asp:Label ID="Label2" runat="server"><%=objLanguage.GetLanguageConversion("Subject")%></asp:Label></span>
                                                            </div>
                                                            <asp:Label ID="lblSubject" runat="server" Style="display: none"></asp:Label>
                                                            <div class="box" style="width: 60%">
                                                                <asp:TextBox ID="txtSubject" runat="server" Width="480px" Height="15px" CssClass="textboxnew"></asp:TextBox>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                                <span id="Span2" class="spanerrorMsg" style="display: none; width: 185px;">Please enter
                                                                    Subject</span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div align="left">
                                                        <div id="lblPhraseText" class=" bglabel_new" style="width: 20.3%; height: 305px;">
                                                            <span id="SpnPhraseText" style="color: Black">
                                                                <asp:Label ID="Label3" runat="server"><%=objLanguage.GetLanguageConversion("Email_Body")%></asp:Label></span>
                                                        </div>
                                                        <div class="box" style="width: 70%; border: 0px solid red">
                                                            <div id="divFckEditor" style="border: 0px solid; float: left">
                                                                <telerik:RadEditor ID="RadEditor1" runat="server" Width="90%" Height="300px" EditModes="Design,Html"
                                                                    ImageManager-ViewMode="Grid" ContentAreaMode="Iframe" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                                                    ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute" OnClientLoad="OnClientLoad">
                                                                    <Content>
                                                                          
                                                                    </Content>
                                                                    <CssFiles>
                                                                        <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                                                    </CssFiles>
                                                                </telerik:RadEditor>
                                                                <div class="only5px">
                                                                </div>
                                                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                                                    Max. length of textbox is: 3000</span><span id="spn_txtphrasetext" class="spanerrorMsg"
                                                                        style="display: none; width: 185px;">Please enter E-mail body</span>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="spn_defaultSignature">
                                                                    <asp:Label ID="Label4" runat="server"><%= objLanguage.GetLanguageConversion("Set_this_text_as_Default_Body")%></asp:Label></span>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:CheckBox ID="chkDefaultEmailBody" runat="server"></asp:CheckBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="only5px">
                                            </div>
                                            <div align="left" style="width: 100%">
                                                <div style="float: left; width: 21%;">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <div id="div_btncancel" style="display: block">
                                                        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" CausesValidation="false"
                                                            OnClick="btnCancel_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');" />
                                                    </div>
                                                    <div id="div_cancelprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                                <div style="float: left; width: 10px">
                                                    &nbsp;
                                                </div>
                                                <div style="float: left;">
                                                    <div id="div_btnSave" style="display: block">
                                                        <asp:Button ID="btnSave" CssClass="button" runat="server" OnClick="btnSave_Onclick"
                                                            Text="Save" OnClientClick="javascript:var a=validate();if(a)loadingimage(this.id,'div_saveprocess');return a;" />
                                                    </div>
                                                    <div id="div_saveprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="only10px">
                                            </div>
                                            <div class="only10px">
                                            </div>
                                            <div align="left" style="width: 85%">
                                                <div id="divestimate" style="display: block">
                                                    <span class="HeaderText">
                                                        <%=objLanguage.GetLanguageConversion("Custom_Tags_for_Product_Stock_Low_Reminder_Email") %></span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">
                                                        <%=objLanguage.GetLanguageConversion("Replace_Tags_Value")%>. </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheader" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;
                                                                    <%=objLanguage.GetLanguageConversion("Tag_Name")%>
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Description")%>
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" align="right" valign="top" width="1%" style="border-top-right-radius: 5px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" width="100%">
                                                                    <table class="borderWithoutTop" border="0" cellpadding="1" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ProductName" size="30" value='[$ProductName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Product_Title")%>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ProductCode" size="30" value='[$ProductCode$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Item_Code")%>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ProductCurrentStock" size="30" value='[$Instockqty$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Current_Stock") %>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ProductAllocatedQuantity" size="30" value='[$Allocatedqty$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Allocated_Quantity")%>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ProductAvailableQuantity" size="30" value='[$Availableqty$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Available_Quantity")%>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ReorderAlertLevel" size="30" value='[$Reorderalertlevel$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("ReOrder_Alert_Level")%>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ReorderQuantity" size="30" value='[$Reorderqty$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("ReOrder_Quantity")%>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierName" size="30" value='[$Supplier$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Product_Supplier_Name")%>
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PurchaseCreateNew" size="30" value='[$CreatePurchaseOrder$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("To_Create_the_New_Purchase_orders")%>
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
                                                <script>
                                                    setTimeout("desableAfterLoad()", 5000);
                                                </script>
                                            </div>
                                            <div class="only5px">
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnEmailIdMultiple" runat="server" Value="" />
                        <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <asp:HiddenField ID="hiddenEmailID" Value="" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function displayAddNew() {
            document.getElementById('tdaddnew').style.display = 'block';
        }
        function desableAfterLoad() {
            window.document.getElementById("div_Load").style.display = "none";
        }

        function addnew(type) {
            document.getElementById('div_Load').style.display = 'block';
            //pageScroll();
            setTimeout("displayAddNew()", 3000);
            setTimeout("desableAfterLoad()", 4000);

            var txtemailtempname = document.getElementById("<%=txtemailtempname.ClientID %>");
            var Radeditor = document.getElementById("<%=RadEditor1.ClientID %>");
            var chkDefaultEmailBody = document.getElementById("<%=chkDefaultEmailBody.ClientID %>");

            if (type == 'add') {
                txtemailtempname.value = ""
                chkDefaultEmailBody.checked = false;
                document.getElementById("<%=txtSubject.ClientID %>").value = "";
                var editor = $find("<%=RadEditor1.ClientID%>");
                editor.set_html("");
                txtemailtempname.focus();

            }
            else {
                return true;
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

        function checkAll_new_emailrecords(checkAllBox_emailbody) {
            var frm = document.forms[0];
            var ChkState = checkAllBox_emailbody.checked;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('chkEmailBodyId1') != -1) {
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

        var NoOFCnt_Address = 0;
        var cnt_Address = 0;
        var IDLenght_Address = 0;
        var ActionType_costcenter = '';
        var Counter_costcenter = 0;

        function CheckOne_new_emailbody() {
            var frm = document.forms[0];
            var IDs = '';

            var Counter = 0;
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

            if (window.confirm("Are you sur you want to delete this items?") == false) {
                return false;
            }
            else {
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('chkEmailBodyId1') != -1) {
                        if (!e.disabled) {
                            if (e.checked) {
                                IDs = IDs + frm[i].value + ",";
                            }
                        }
                    }
                }
                document.getElementById("ctl00_ContentPlaceHolder1_hdnEmailIdMultiple").value = IDs;

            }
        }

        function validate() {
            var txtemailtempname = document.getElementById("<%=txtemailtempname.ClientID %>");
            if (txtemailtempname.value == "") {
                document.getElementById("spn_txtemailtempname").style.display = "block";
                return false;
            }
            else {
                return true;
            }
        }

    </script>
    <script type="text/javascript">
        function OnClientLoad(editor, args) {
            var editorIframe = $get(editor.get_id() + "Wrapper").getElementsByTagName("iframe")[0];
            editorIframe.style.height = "100%";
            var divMinHeight = document.getElementById("ctl00_ContentPlaceHolder1_RadEdit_contentIframe");
            if (divMinHeight != null) {
                divMinHeight.style.minHeight = "154px";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

