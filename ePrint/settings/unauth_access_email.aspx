<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="unauth_access_email.aspx.cs" Inherits="ePrint.settings.unauth_access_email" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/item/general.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <style type="text/css">
        .reContentArea
        {
            font-family: Arial !important;
            font-size: 14px !important;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdUnthorisedaccess">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdUnthorisedaccess" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdUnthorisedaccess">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
                    <telerik:AjaxUpdatedControl ControlID="txtName" />
                    <telerik:AjaxUpdatedControl ControlID="ddlFooterSignature" />
                    <telerik:AjaxUpdatedControl ControlID="chkDefaultEmailBody" />
                    <telerik:AjaxUpdatedControl ControlID="txtSubject" />
                    <telerik:AjaxUpdatedControl ControlID="lblemail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdUnthorisedaccess" />
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
            margin-top: -10px;
            margin-left: -10px;
        }
    </style>
    <div align="left" id="pnlproductlowstockemaildetails">
        <div align="left">
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblheader"><%=objLanguage.GetLanguageConversion("Settings") %>: <%=objLanguage.GetLanguageConversion("Content_Messages")%> - <%=objLanguage.GetLanguageConversion("Unauthorised_Access")%></asp:Label>
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
                                <td style="vertical-align: top;">
                                    <div align="left" style="margin-top: 12px">
                                        <div style="width: 40%; padding-bottom: 3px; float: left;">
                                            <div style="float: left;">
                                            </div>
                                            <div style="float: left">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div id="div_popupAction" style="margin: 35px 0px 0px 8px;" onmouseover="show();"
                                                            onmouseout="hide(); ">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div style="width: 100%;">
                                                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                                                <asp:LinkButton ID="lnkDeleteStatus" runat="server" CommandName="Delete" CausesValidation="false"
                                                                                    OnClick="lnkMultidelete_Onclick" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CheckOne_new_emailbody();"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
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
                                    <div style="width: 1000px; float: left; margin-top: -13px; margin-left: 10px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false"
                                            runat="server">
                                            <ContentTemplate>
                                                <telerik:RadGrid ID="grdUnthorisedaccess" AutoGenerateColumns="false" runat="server"
                                                    BorderWidth="0" ItemStyle-Height="2%" GridLines="None" AllowPaging="true" Width="60%"
                                                    PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true" OnItemDataBound="grdUnthorisedaccess_OnItemDataBound">
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <CommandItemTemplate>
                                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:LinkButton ID="lnkAddNew" runat="server" OnClientClick="javascript:addnew('add');"> <%=objLanguage.GetLanguageConversion("Add_New_Record") %></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </CommandItemTemplate>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn HeaderStyle-Width="20px">
                                                                <HeaderTemplate>
                                                                    <div id="div_chk" style="width: inherit; height: inherit;">
                                                                        <table width="10%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <input type="checkbox" id="checkAll" onclick="checkAll_new_emailrecords(this);" runat="server"
                                                                                        name="checkAll" />
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
                                                                        <input type="checkbox" runat="server" id="chkSelectGrid" name="Id" value='<%#Eval("EmailID") %>' />
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Template Name" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="150px" ItemStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkTemplateName" runat="server" Text='<%#Eval("TemplateName")%>'
                                                                        OnClick="lnktemplate_OnClick" CommandArgument='<%#Eval("EmailID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="200px" ItemStyle-Width="200px">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkTemplateSubject" runat="server" Text='<%#Eval("Subject")%>'
                                                                        OnClick="lnktemplate_OnClick" CommandArgument='<%#Eval("EmailID")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Default" ItemStyle-Wrap="false" HeaderStyle-Width="50px"
                                                                ItemStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:Image ID="imgdefault" runat="server" CssClass="gridpadding"></asp:Image>
                                                                    <asp:HiddenField ID="hdnDefaultValue" Value='<%#Eval("IsDefault")%>' runat="server" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-Width="50px">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                        Text="Delete" UniqueName="DeleteColumn" runat="server" OnCommand="lnkDelete_onclick"
                                                                        CommandArgument='<%#Eval("EmailID")%>' OnClientClick="javascript:return window.confirm('Are you sure you want to delete this?');"
                                                                        CssClass="gridpadding" ToolTip="Delete"></asp:ImageButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                </telerik:RadGrid>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div align="left" style="width: 100%;" id="EmaiBody">
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
                                                            <asp:TextBox ID="lblemail" runat="server" Style="display: none"></asp:TextBox>
                                                            <div class="box" style="width: 60%">
                                                                <asp:TextBox runat="server" ID="txtName" SkinID="textPad" Width="200px" TextMode="singleline"
                                                                    MaxLength="255">
                                                                </asp:TextBox>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                                <span id="spn_txtemailtempname" class="spanerrorMsg" style="display: none; width: auto;
                                                                    padding-left: 4px; padding-right: 4px;">Please enter Template Name</span>
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
                                                                    ImageManager-ViewMode="Grid" ContentAreaMode="Iframe" OnClientLoad="OnClientLoad"
                                                                    ToolsFile="~/RadEditorDialogs/Tools/tools.xml" ExternalDialogsPath="~/RadEditorDialogs"
                                                                    ContentFilters="MakeUrlsAbsolute">
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
                                                                <asp:Label ID="lbl_emailSignature" runat="server"><%=objLanguage.GetLanguageConversion("Email_Signature")%></asp:Label>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:DropDownList ID="ddlFooterSignature" CssClass="normalText" runat="server" Width="208px">
                                                                </asp:DropDownList>
                                                                <span id="spn_defaultddl" class="spanerrorMsg" style="display: none; width: 185px;">
                                                                    Please Select Footer Signature</span>
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="spn_defaultSignature">
                                                                    <asp:Label ID="lblDefault" runat="server"><%= objLanguage.GetLanguageConversion("Set_this_text_as_Default_Body")%></asp:Label></span>
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
                                                        <asp:Button ID="btnCancel" CssClass="buttoncustomtxt" runat="server" Text="Cancel"
                                                            CausesValidation="false" OnClick="btnCancel_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');" />
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
                                                            OnClientClick="javascript:var a=Validate();if(a)loadingimage(this.id,'div_saveprocess');return a;" />
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
                                                        <%=objLanguage.GetLanguageConversion("Custom_Tags_for_Product_Stock_Low_Reminder_Email") %></span><span
                                                            class="normalText">
                                                            <%=objLanguage.GetLanguageConversion("Replace_Tags_Value")%>. </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheader" runat="server">
                                                                <td class="bgcustomize navigatorpanel tableleftradius" width="30%">
                                                                    &nbsp;
                                                                    <%=objLanguage.GetLanguageConversion("Tag_Name")%>
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel tablerightradius" width="60%">
                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Description")%>
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
                                                                                    <input type='text' name="ProductName" size="30" value='[$IPAddress$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("IP_Address")%>
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
                                                                                    <input type='text' name="SupplierName" size="30" value='[$UserName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("Username")%>
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
                                                                                    <input type='text' name="ProductName" size="30" value='[$SystemURL$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;<%=objLanguage.GetLanguageConversion("System_URL")%>
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
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnEmailIdMultiple" runat="server" Value="" />
                        <asp:HiddenField ID="hiddenEmailID" Value="" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function Validate() {
            var checkwhat = true;
            var FooterSignature = document.getElementById("<%=RadEditor1.ClientID %>");
            var txtemailSignatureTitle = document.getElementById("<%=txtName.ClientID %>");
            document.getElementById("spn_txtemailtempname").innerHTML = '<%=objLanguage.GetLanguageConversion("Please_enter_template_name")%>';

            document.getElementById("spn_txtemailtempname").style.display = "none";
            document.getElementById("spn_txtphrasetext").style.display = "none";


            if (CheckStringMandatory(txtemailSignatureTitle.value, 'spn_txtemailtempname')) {
                checkwhat = false;
            }


            if (checkwhat) {
                return true;
            }
            else {
                return false;
            }
        }

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

            var txtemailtempname = document.getElementById("<%=txtName.ClientID %>");
            var Radeditor = document.getElementById("<%=RadEditor1.ClientID %>");
            var chkDefaultEmailBody = document.getElementById("<%=chkDefaultEmailBody.ClientID %>");
            var lblemail = document.getElementById("<%=lblemail.ClientID%>");
            txtemailtempname.focus();

            if (type == 'add') {
                txtemailtempname.value = "";
                lblemail.value = "";
                chkDefaultEmailBody.checked = false;
                document.getElementById("<%=txtSubject.ClientID %>").value = "";
                var editor = $find("<%=RadEditor1.ClientID%>");
                editor.set_html("");

            }
            else {
                return true;
            }
        }

        function checkAll_new_emailrecords(checkAllBox_emailbody) {
            var frm = document.forms[0];
            var ChkState = checkAllBox_emailbody.checked;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('chkSelectGrid') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }

        function CheckOne_new_emailbody() {
            var frm = document.forms[0];
            var IDs = '';

            var Counter = 0;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox') {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                alert("Please check at least one row to Delete");
                return false;
            }

            if (window.confirm("Are you sure you want to delete this items?") == false) {
                return false;
            }
            else {
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('chkSelectGrid') != -1) {
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

