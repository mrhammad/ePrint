<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="alert_notifications.aspx.cs" Inherits="ePrint.settings.alert_notifications" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGridAlert">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtAlertName" />
                    <telerik:AjaxUpdatedControl ControlID="txtSubject" />
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
                    <telerik:AjaxUpdatedControl ControlID="lblAlertID" />
                    <telerik:AjaxUpdatedControl ControlID="RadGridAlert" LoadingPanelID="RadAjaxLoadingPanel" />
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
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" Skin="Default" />
    <div align="left" id="pnlproductlowstockemaildetails">
        <div align="left">
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblheader"><%=objLanguage.GetLanguageConversion("Settings") %>: <%=objLanguage.GetLanguageConversion("Content_Messages")%> - <%=objLanguage.GetLanguageConversion("Alert_Notifications")%></asp:Label>
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
                        <div id="divMessage">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <table cellpadding="1" cellspacing="1" border="0" width="100%">
                            <tr>
                                <td valign="top" style="width: 13.3%;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                </td>
                                <td valign="top">
                                    <div id="div_Grid" style="width: 1000px; display: none; margin-left: -10px">
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false"
                                            runat="server">
                                            <ContentTemplate>
                                                <telerik:RadGrid ID="RadGridAlert" AutoGenerateColumns="false" runat="server" ItemStyle-Height="2%"
                                                    BorderWidth="0" GridLines="None" AllowPaging="true" Width="60%" PagerStyle-AlwaysVisible="true"
                                                    HeaderStyle-Font-Bold="true" OnNeedDataSource="RadGridAlert_OnNeedDataSource"
                                                    OnItemDataBound="RadGridAlert_OnItemDataBound">
                                                    <MasterTableView>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderText="Template Name" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkTemplateName" runat="server" Text='<%#Eval("TemplateName")%>'
                                                                        OnClick="lnkTemplateName_Click" CommandArgument='<%#Eval("AlertID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkTemplateSubject" runat="server" Text='<%#Eval("Subject")%>'
                                                                        CommandArgument='<%#Eval("AlertID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Default" ItemStyle-Wrap="false" HeaderStyle-Width="50px"
                                                                ItemStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:Image ID="imgdefault" runat="server" CssClass="gridpadding"></asp:Image>
                                                                    <asp:HiddenField ID="hdnDefaultValue" Value='<%#Eval("IsDefault")%>' runat="server" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="EventDiv" style="margin-top: -5px; margin-left: 10px; display: block;">
                                        <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div id="tdemailaddnew" align="left" style="width: 100%;">
                                                    <div align="left">
                                                        <div class="bglabel" style="width: 20%; float: left;">
                                                            <span id="spnTempName">
                                                                <asp:Label ID="Label1" runat="server"><%=objLanguage.GetLanguageConversion("Alert_Template_Name")%></asp:Label></span>
                                                        </div>
                                                        <div class="box" style="width: 300px; float: left;">
                                                            <asp:TextBox runat="server" ID="txtAlertName" SkinID="textPad" Width="300px" TextMode="singleline"
                                                                MaxLength="255">
                                                            </asp:TextBox>
                                                            <asp:Label ID="lblAlertID" runat="server" Style="display: none;"></asp:Label>
                                                        </div>
                                                        <div style="float: left; margin-left: 10px;">
                                                            <span id="spn_txttempname" class="spanerrorMsg" style="display: none; width: auto;
                                                                padding-left: 4px; padding-right: 4px; border-radius: 2px;">Please enter template
                                                                name</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="div_SubJect" align="left" style="width: 100%;">
                                                    <div align="left">
                                                        <div class="bglabel" style="width: 20%; float: left;">
                                                            <span id="Span1">
                                                                <asp:Label ID="Label2" runat="server"><%=objLanguage.GetLanguageConversion("Subject")%></asp:Label></span>
                                                        </div>
                                                        <div class="box" style="width: 650px; float: left;">
                                                            <asp:TextBox ID="txtSubject" runat="server" Width="650px" Height="15px" CssClass="textboxnew"></asp:TextBox>
                                                        </div>
                                                        <div style="float: left; margin-left: 10px;">
                                                            <span id="Span_subject" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px;
                                                                padding-right: 4px; border-radius: 2px;">Please enter subject</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div id="lblPhraseText" class=" bglabel_new" style="width: 20.3%; height: 300px;">
                                                        <span id="SpnPhraseText" style="color: Black">
                                                            <asp:Label ID="Label3" runat="server"><%=objLanguage.GetLanguageConversion("Email_Body")%></asp:Label></span>
                                                    </div>
                                                    <div class="box" style="width: 70%; border: 0px solid red; margin-left: 1px;">
                                                        <div id="divFckEditor" style="border: 0px solid; float: left">
                                                            <telerik:RadEditor ID="RadEditor1" runat="server" Width="90%" Height="300px" EditModes="Design,Html"
                                                                ImageManager-ViewMode="Grid" ContentAreaMode="Iframe" OnClientLoad="OnClientLoad"
                                                                ToolsFile="~/RadEditorDialogs/Tools/tools.xml" ExternalDialogsPath="~/RadEditorDialogs"
                                                                ContentFilters="MakeUrlsAbsolute">
                                                                <Content>
                                                                </Content>
                                                                <CssFiles>
                                                                    <telerik:EditorCssFile Value="~/App_Themes/Theme1/EditorContentArea.css" />
                                                                </CssFiles>
                                                            </telerik:RadEditor>
                                                            <div class="only5px">
                                                            </div>
                                                            <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">
                                                                Max. length of textbox is: 3000</span><span id="spn_txtphrasetext" class="spanerrorMsg"
                                                                    style="display: none; width: 185px;">Please enter E-mail body</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div align="left" style="width: 100%; margin-top: 5px;">
                                            <div style="float: left; width: 21%;">
                                                &nbsp;
                                            </div>
                                            <div style="float: left;">
                                                <div id="div_btncancel" style="display: block">
                                                    <asp:Button ID="btnCancel" CssClass="buttoncustomtxt" runat="server" Text="Cancel"
                                                        CausesValidation="false" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');"
                                                        OnClick="btnCancel_OnClick" />
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
                                                    <asp:Button ID="btnSave" CssClass="buttoncustomtxt" runat="server" Text="Save" OnClick="btnSave_Onclick"
                                                        OnClientClick="javascript:var a=validate();if(a)loadingimage(this.id,'div_saveprocess');return a;" />
                                                </div>
                                                <div id="div_saveprocess" style="display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="only10px">
                                        </div>
                                        <div align="left" style="width: 85%">
                                            <div id="divestimate" style="display: block">
                                                <span class="HeaderText">
                                                    <%=objLanguage.GetLanguageConversion("Custom_Tags_for_Alert")%></span>
                                                <br />
                                                <span class="normalText">
                                                    <%=objLanguage.GetLanguageConversion("Replace_Tags_Value")%>
                                                </span>
                                                <div class="only10px">
                                                </div>
                                                <div style="width: 100%">
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="790px">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheader" runat="server">
                                                                <td class="bgcustomize navigatorpanel" align="left" valign="top" width="1%" style="border-top-left-radius: 5px;">
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
                                                                                    <input type='text' name="ProductName" size="30" value='[$Subject$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Subject")%>
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
                                                                                    <input type='text' name="SupplierName" size="30" value='[$DueDate$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Due_Date")%>
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
                                                                                    <input type='text' name="ProductName" size="30" value='[$AssignedTo$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Assigned_To")%>
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
                                                                                    <input type='text' name="ProductName" size="30" value='[$Description$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Description")%>
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
                                                                                    <input type='text' name="alertType" size="30" value='[$AlertType$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Alert_Type")%>
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
                                                                                    <input type='text' name="CustomerName" size="30" value='[$CustomerName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Customer_Name")%>
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
                                        </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function OnClientLoad(editor, args) {
            var style = editor.get_contentArea().style;
            style.fontFamily = 'Arial';
            style.fontSize = 14 + 'px';

            var tool = editor.getToolByName("FontName");

            if (tool) {
                tool.set_value("Arial");
            }

            var tool2 = editor.getToolByName("RealFontSize");

            if (tool2) {
                tool2.set_value("14px");
            }
        }
        function Editsettings() {
            document.getElementById("EventDiv").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_txtAlertName").focus();
        }
        function validate() {
            var TempName = document.getElementById("ctl00_ContentPlaceHolder1_txtAlertName");
            var Subject = document.getElementById("ctl00_ContentPlaceHolder1_txtSubject");

            if (TempName.value != "" && Subject.value != "") {
                return true;
            }
            else {
                if (TempName.value == "") {
                    document.getElementById("spn_txttempname").style.display = "block";
                    return false;
                }
                if (Subject.value == "") {
                    document.getElementById("spn_txttempname").style.display = "none";
                    document.getElementById("Span_subject").style.display = "block";
                    return false;
                }
            }
        }
    </script>
    <script type="text/javascript">
        window.setTimeout(function () {
            var label = document.getElementById('divMessage');

            if (label != null) {
                label.style.display = 'none';
            }
        }, 6000);
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

