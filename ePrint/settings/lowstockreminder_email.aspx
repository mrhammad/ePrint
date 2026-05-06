<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true"  CodeBehind="lowstockreminder_email.aspx.cs" Inherits="ePrint.settings.lowstockreminder_email" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/animation.js?VN='<%=VersionNumber%>" type="text/javascript"></script>
    <script src="../js/item/general.js?VN='<%=VersionNumber%>" type="text/javascript"></script>
    <style type="text/css">
        .reContentArea {
            font-family: Arial !important;
            font-size: 14px !important;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdEmailBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtSubject" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtemailtempname" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkDefaultEmailBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style>
        .RadGrid_Default .rgCommandRow {
            background: none;
        }

            .RadGrid_Default .rgCommandRow a {
                color: #10357F;
                text-decoration: underline;
                margin-left: -10px;
            }

        .RadGrid_Default .rgCommandCell {
            border: none;
            margin-top: -8px;
        }

        .RadGrid_Default .rgHeader {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }

        .RadGrid_Default {
            outline: none;
            margin-top: -10px;
            margin-left: -5px;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
    <div align="left" id="pnldetails">
        <div align="left">
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblheader"><%=objLanguage.GetLanguageConversion("Settings") %>: <%=objLanguage.GetLanguageConversion("Phrase_Book") %> - <%=objLanguage.GetLanguageConversion("Low_Stock_reminder_Email") %></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
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
                    <table cellpadding="1" cellspacing="1" border="0" style="width: 100%">
                        <tr>
                            <td valign="top" style="width: 233px;">
                                <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                            </td>
                            <td style="margin-left: 5px; float: left;" valign="top" align="left">
                                <div align="left" style="width: 60%;">
                                    <div style="width: 40%; padding-bottom: 3px; float: left;">
                                        <div style="float: left;">
                                        </div>
                                        <div style="float: left">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div id="a">
                                </div>
                                <div style="float: left; width: 100%;">
                                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false"
                                        runat="server">
                                        <ContentTemplate>
                                            <telerik:RadGrid ID="grdEmailBody" AutoGenerateColumns="false" runat="server" OnItemDataBound="grdPraseBookEmailSignature_OnItemDataBound"
                                                BorderWidth="0" ItemStyle-Heigh="2%" GridLines="None" AllowPaging="true" PageSize="50"
                                                OnPageIndexChanged="grdEmailBody_PageIndexChanged" OnPageSizeChanged="grdEmailBody_PageSizeChanged"
                                                Width="800px" PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true">
                                                <MasterTableView CommandItemDisplay="Top">
                                                    <CommandItemTemplate>
                                                        <table class="rgCommandTable" border="0" style="width: 100%;">
                                                            <tr>
                                                                <td align="left">
                                                                    <a href="#" onclick="javascript:add_new('add');">
                                                                        <%=objLanguage.GetLanguageConversion("Add_New_Record") %></a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </CommandItemTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                            AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                            <HeaderTemplate>
                                                                <input type="checkbox" id="checkAll1" runat="server" name="checkAll" onclick="CheckAll(this);" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <input type="checkbox" runat="server" id="chkEmailBodyId1" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.EmailID", "{0}") %>'
                                                                    onclick="CheckChanged();" />
                                                                <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Template Name" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-Wrap="false" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkTemplateName" runat="server" Width="99%" OnClick="lnkBody_onClick"
                                                                    OnClientClick="javascript:add_new('edit');" CommandArgument='<%#Eval("EmailID")%>'
                                                                    Text='<%#Eval("TemplateName")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-Wrap="false" ItemStyle-Width="70%" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkSubject" runat="server" Width="99%" OnClick="lnkBody_onClick"
                                                                    OnClientClick="javascript:add_new('edit');" CommandArgument='<%#Eval("EmailID")%>'
                                                                    Text='<%#Eval("Subject")%>'></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn HeaderText="Default" HeaderStyle-HorizontalAlign="Left"
                                                            ItemStyle-Wrap="false" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left">
                                                            <HeaderStyle HorizontalAlign="Left" Width="5%" Wrap="false" />
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:Image ID="imgdefault" runat="server"></asp:Image>
                                                                    <asp:HiddenField ID="hdnDefaulVal" Value='<%#Eval("Isdefault")%>' runat="server" />
                                                                </center>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn>
                                                            <HeaderTemplate>
                                                                <input type="checkbox" id="checkAll" onclick="CheckAll(this); changebgColor(this);"
                                                                    runat="server" name="checkAll" style="display: none" />
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <input type="checkbox" runat="server" id="chkEmailBodyId" onclick="CheckChanged();"
                                                                    name="Id" value='<%#Eval("EmailID")%>' style="display: none" />
                                                                <asp:Label ID="hdnEmailID" Text='<%#Eval("EmailID")%>' Visible="false" runat="server" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                        CommandArgument='<%#Eval("EmailID")%>' Text="Delete" UniqueName="DeleteColumn"
                                                                        runat="server" OnCommand="lnkDelete_onclick" ToolTip="Delete" OnClientClick="javascript:return ImgButtonErase_ClientClick('ctl00_ContentPlaceHolder1_grdEmailBody',this.id)"></asp:ImageButton></center>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                </MasterTableView><ClientSettings>
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="only10px">
                                </div>
                                <div id="div_Load" class="loading_new" style="display: none;">
                                    <UC:Loading ID="ucLoading" runat="server" />
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div align="left" style="width: 100%;" id="EmaiBody">
                                            <div align="left">
                                            </div>
                                            <div class="only10px">
                                            </div>
                                            <div id="tdaddnew" align="left" style="width: 100%; display: none;">
                                                <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div id="tdemailaddnew" align="left" style="width: 100%;">
                                                            <div align="left">
                                                                <div class="bglabel_new" style="width: 20%; color: Black">
                                                                    <span id="spnTempName" runat="server"></span><span style="color: Red; padding-left: 3px;">*</span>
                                                                </div>
                                                                <asp:Label ID="lblemail" runat="server" Style="display: none"></asp:Label>
                                                                <div class="box" style="width: 60%">
                                                                    <asp:TextBox runat="server" ID="txtemailtempname" SkinID="textPad" Width="200px"
                                                                        TextMode="singleline" MaxLength="255">
                                                                    </asp:TextBox>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <span id="spn_txtemailtempname" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">Please enter template name</span>
                                                                </div>
                                                            </div>
                                                            <div class="onlyEmpty">
                                                            </div>
                                                        </div>
                                                        <div id="div_Subject" align="left" style="width: 100%;">
                                                            <div align="left">
                                                                <div class="bglabel_new" style="width: 20%; color: Black">
                                                                    <span id="spnSubject" runat="server"></span>
                                                                </div>
                                                                <div class="box" style="width: 50%">
                                                                    <asp:TextBox ID="txtSubject" runat="server" Width="488px" Height="15px" CssClass="textboxnew"></asp:TextBox>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <span id="Span2" class="spanerrorMsg" style="display: none; width: 200px;">Please enter
                                                                        subject</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div id="lblPhraseText" class=" bglabel_new" style="width: 20%; height: 305px; color: Black">
                                                                <span id="SpnPhraseText" runat="server"></span>
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
                                                                    <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">Max. length of textbox is: 3000</span> <span id="spn_txtphrasetext" class="spanerrorMsg"
                                                                        style="display: none; width: 185px;">Please enter E-mail body</span>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <br />
                                                            <div align="left">
                                                                <div class="bglabel_new" style="width: 20%; color: Black">
                                                                    <span id="spn_defaultSignature" runat="server"></span>
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
                                                    <div id="div_cancel" style="float: left;">   
                                                        <asp:Button ID="btnCancel" CssClass="buttoncustomtxt" runat="server" Text="Cancel"
                                                            CausesValidation="false" OnClick="btnCancel_OnClick" OnClientClick="javascript:loadingimg('div_cancel','div_btnCancelProcess');return true;" />
                                                    </div>
                                                    <div id="div_btnCancelProcess" class="button"  style="height: 14px; width: 33px; display: none;float:left;">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                    </div>
                                                    <div style="float: left; width: 10px">
                                                        &nbsp;
                                                    </div>
                                                   <%-- <div style="float: left;">
                                                        <asp:Button ID="btnSave" CssClass="buttoncustomtxt" runat="server" Text="Save" OnClientClick="javascript:return Validate('');"
                                                            OnClick="btnSave_OnClick" />
                                                    </div>--%>
                                                    <div id="div_Save" style="float: left;">
                                                        <asp:Button ID="btnSave" CssClass="buttoncustomtxt" runat="server" Text="Save" OnClientClick="javascript:var a=Validate(''); if(a)loadingimg('div_Save','div_btnSaveProcess');return a;"
                                                            OnClick="btnSave_OnClick" />
                                                    </div>
                                                    <div id="div_btnSaveProcess" class="button"  style="height: 14px; width: 33px; display: none;float: left;">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                                <div class="only10px">
                                                </div>
                                                <div class="only10px">
                                                </div>
                                                <div align="left" style="width: 85%">
                                                    <div id="divLowStocRemainder" style="display: none">
                                                        <span class="HeaderText">
                                                            <%=objLanguage.GetLanguageConversion("Custom_Tags_For_Low_Stock_Reminder")%></span>
                                                        <div class="only5px">
                                                        </div>
                                                        <span class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Replace_Tags_Value")%>
                                                        </span>
                                                        <div class="only5px">
                                                        </div>
                                                        <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tbody>
                                                                <tr valign="top" height="23" id="trheader" runat="server">
                                                                    <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                        <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                    </td>
                                                                    <td class="bgcustomize navigatorpanel" width="30%">&nbsp;<%=objLanguage.GetLanguageConversion("Tag_Name") %>
                                                                    </td>
                                                                    <td class="bgcustomize navigatorpanel" width="60%">&nbsp;<%=objLanguage.GetLanguageConversion("Description") %>
                                                                    </td>
                                                                    <td class="bgcustomize navigatorpanel" align="right" valign="top" width="1%" style="border-top-right-radius: 5px;"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" width="100%;">
                                                                        <table class="borderWithoutTop" border="0" cellpadding="1" cellspacing="0" width="100%">
                                                                            <tbody>
                                                                                <tr class="NewTableRows" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="InventoryName" size="30" value='[$InventoryName$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Inventory Name
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewAlternative" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="InventoryCode" size="30" value='[$InventoryCode$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Inventory Code
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewTableRows" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="Instockqty" size="30" value='[$Instockqty$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Instock qty
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewAlternative" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="AllocateQty" size="30" value='[$Allocatedqty$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Allocated qty
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewTableRows" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="AvailableQty" size="30" value='[$Availabelqty$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Availabel qty
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewAlternative" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="ReOrderAlertLevel" size="30" value='[$Reorderaletlevel$]'
                                                                                            readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Reorder alert level
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewTableRows" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="ReOrderQty" size="30" value='[$Reorderqty$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Reorder qty
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewAlternative" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="Location" size="30" value='[$Location$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Location
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr class="NewTableRows" valign="middle">
                                                                                    <td width="1%">&nbsp;
                                                                                    </td>
                                                                                    <td width="30%" nowrap="nowrap">
                                                                                        <input type='text' name="Location" size="30" value='[$Supplier$]' readonly="readonly" onclick="this.select();" />
                                                                                    </td>
                                                                                    <td style="overflow: hidden;" width="60%">&nbsp;Supplier
                                                                                    </td>
                                                                                    <td width="1%">&nbsp;
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
                                                <div class="only5px">
                                                </div>
                                                <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                                    <ContentTemplate>
                                                        <asp:HiddenField ID="chkBodyID" runat="server" />
                                                        <asp:HiddenField ID="hiddenEmailID" Value="" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue; display: none">
            <div id="div_test_2" style="width: 100%; border: solid 1px red;">
                Loading...
            </div>
        </div>
    </div>
    <script>


        function add_new(val) {
            document.getElementById('div_Load').style.display = 'block';
            pageScroll();
            setTimeout("displayAddNew()", 3000);
            setTimeout("desableAfterLoad()", 4000);
            if (val == 'add') {
                document.getElementById("<%=txtemailtempname.ClientID %>").value = "";
                document.getElementById("<%=chkDefaultEmailBody.ClientID %>").checked = false;
                document.getElementById("<%=txtSubject.ClientID %>").value = "";
                var editor = $find("<%=RadEditor1.ClientID%>");
                editor.set_html("");

            }
            document.getElementById('tdaddnew').style.display = 'block';
            SelectTemplateType();
            document.getElementById("<%=txtemailtempname.ClientID %>").focus();
            return false;
        }


        function changebgColor(chkobj) {
            var gridid = document.getElementById("<%=grdEmailBody.ClientID%>");
            changeGridColor(chkobj, gridid);
        }

    </script>
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>" type="text/javascript"
        language="javascript"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>"></script>
    <script type="text/javascript">
        function Validate(type, obj) {
            var checkwhat = true;
            var txtphrasetext = document.getElementById("<%=RadEditor1.ClientID %>");
            var txtemailtempname = document.getElementById("<%=txtemailtempname.ClientID %>");

            document.getElementById("spn_txtphrasetext").style.display = "none";
            document.getElementById("spn_txtemailtempname").style.display = "none";

            if (CheckStringMandatory(txtemailtempname.value, 'spn_txtemailtempname')) {
                checkwhat = false;
            }

            if (checkwhat) {
                return true;
            }
            else {
                return false;
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

        function ImgButtonErase_ClientClick(GridID, ImageButtonID) {
            if (confirm("Delete this template?")) {

                return true;
            }
            else {
                return false;
            }
        }
        function SelectTemplateType() {
            document.getElementById("divLowStocRemainder").style.display = 'block';
        }


    </script>
    </asp:Panel>
    <script type="text/javascript">
        function hidetypeLowstock() {
            estimate('block');
            job('none');
            invoice('none');
            purchase('none');
            printbroker('none');
            delivery('none');

        }
    </script>
    <script type="text/javascript">

        function desableAfterLoad() {
            window.document.getElementById("div_Load").style.display = "none";
        }
    </script>
    <script type="text/javascript">
        function OnClientLoad(editor, args) {
            var editorIframe = $get(editor.get_id() + "Wrapper").getElementsByTagName("iframe")[0];
            editorIframe.style.height = "100%";
            var divMinHeight = document.getElementById("ctl00_ContentPlaceHolder1_RadEdit_contentIframe");
            divMinHeight.style.minHeight = "154px";
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

