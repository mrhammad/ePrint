<%@ page title="" language="C#" masterpagefile="~/Templates/settingpage.master" autoeventwireup="true" CodeBehind="supplier_email.aspx.cs" Inherits="ePrint.settings.supplier_email" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/animation.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <script src="../js/item/general.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <style type="text/css">
        .reContentArea
        {
            font-family: Arial !important;
            font-size: 14px !important;
        }
        .Default.RadEditor .reContentCell
        {
            border: 1px solid #DADADA;
        }
    </style>
    <style type="text/css">
        .Default.RadEditor .reContentCell
        {
            border: 1px solid #DADADA;
        }
    </style>
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
            margin-top: -10px;
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
        }
    </style>
    <script type="text/javascript">
        function hidetype() {
        }

        function desableAfterLoad() {
            window.document.getElementById("div_Load").style.display = "none";
        }
    </script>
    <script language="JavaScript">
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
    </script>
    <script language="JavaScript">
        function CheckChanged() {
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
                    if (boolAllChecked == false) e.checked = false;
                    else e.checked = true;
                    break;
                }
            }
        }
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdEmailBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadEditor2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtemailtempname" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlEmailTemplateType" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkDefaultEmailBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txt_Subject" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblemail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdEmailBody" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdEmailBody" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
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
                                    <asp:Label runat="server" ID="lblheader"><%=objLanguage.GetLanguageConversion("Settings_Supplier_Quote_Email_Body")%></asp:Label>
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
                <div align="left" style="width: 800px;" class="mis_header_panel">
                    <div id="">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table cellpadding="1" cellspacing="1" border="0" width="100%">
                            <tr>
                                <td valign="top" style="width: 18%;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                </td>
                                <td style="width: 10px">
                                    &nbsp;
                                </td>
                                <td style="padding-bottom: 10px;" valign="top" align="left">
                                    <div align="left" style="width: 60%;">
                                        <div style="width: 40%; padding-bottom: 3px; float: left;">
                                            <div style="float: left;">
                                            </div>
                                            <div style="float: left">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div id="div_popupAction" style="margin: 48px 0px 0px 8px;" onmouseover="show();"
                                                            onmouseout="hide(); ">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div style="width: 100%;">
                                                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                                                <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" CommandName="Delete"
                                                                                    OnClick="btnDelete_OnClick" Style="text-decoration: none;" ForeColor="#333333"
                                                                                    Font-Size="11px" OnClientClick="javascript:return CallDelete();" CausesValidation="false"
                                                                                    Visible="true"></asp:LinkButton></div>
                                                                            <%--OnClick="btnDelete_OnClick"--%>
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
                                    <div style="float: left">
                                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" ChildrenAsTriggers="false"
                                            runat="server">
                                            <ContentTemplate>
                                                <telerik:RadGrid ID="grdEmailBody" AutoGenerateColumns="false" runat="server" ItemStyle-Heigh="2%"
                                                    BorderWidth="0" GridLines="None" AllowPaging="true" PageSize="50" Width="800px"
                                                    PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true" OnItemDataBound="grdPraseBookEmailSignature_OnItemDataBound"
                                                    OnPageIndexChanged="grdEmailBody_PageIndexChanged" OnPageSizeChanged="grdEmailBody_PageSizeChanged">
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <CommandItemTemplate>
                                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:LinkButton ID="lnkAddNew" runat="server" OnClientClick="javascript:addnew('add');"
                                                                            Text=""><%=objLanguage.GetLanguageConversion("Add_New_Record") %></asp:LinkButton>
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
                                                                                    <input type="checkbox" id="checkAll1" onclick="CheckAll(this);" runat="server" name="checkAll1" />
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
                                                                        <input type="checkbox" runat="server" id="chkEmailBodyId1" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.EmailtoAdminID", "{0}") %>'
                                                                            onclick="CheckChanged();" />
                                                                    </div>
                                                                    <input type="hidden" id="hdnUPDOWN" runat="server" /></ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Template Name" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-Wrap="false" ItemStyle-Width="45%" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkTemplateName" Width="99%" runat="server" CommandArgument='<%#Eval("EmailtoAdminID")%>'
                                                                        OnClick="lnkBody_onClick" Text='<%#Eval("TemplateName")%>' OnClientClick="javascript:addnew('edit');"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Template Type" HeaderStyle-HorizontalAlign="Left"
                                                                ItemStyle-Wrap="false" ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="40%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnTemplateType" runat="server" Value='<%#Eval("TemplateType")%>' />
                                                                    <%#Eval("TemplateType")%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="Default" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-Wrap="false" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle HorizontalAlign="Center" Width="10%" Wrap="false" />
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
                                                                        name="Id" value='<%#Eval("EmailtoAdminID")%>' style="display: none" />
                                                                    <asp:Label ID="hdnEmailtoAdminID" Text='<%#Eval("EmailtoAdminID")%>' Visible="false"
                                                                        runat="server" />
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                            ToolTip="Delete" CommandArgument='<%#Eval("EmailtoAdminID")%>' Text="Delete"
                                                                            UniqueName="DeleteColumn" OnCommand="lnkDelete_onclick" runat="server" OnClientClick="javascript:return ImgButtonErase_ClientClick('ctl00_ContentPlaceHolder1_grdEmailBody',this.id)">
                                                                        </asp:ImageButton></center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView><ClientSettings>
                                                    </ClientSettings>
                                                </telerik:RadGrid></ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div align="left" style="width: 100%;" id="EmaiBody">
                                        <div id="div_Load" class="loading_new" style="display: none;">
                                            <UC:Loading ID="ucLoading" runat="server" />
                                        </div>
                                        <div id="tdaddnew" align="left" style="width: 100%; display: none;">
                                            <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div style="clear: both;">
                                            </div>
                                            <br />
                                            <div id="Div1" align="left" style="width: 100%; display: block;">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div id="tdemailaddnew" align="left" style="width: 100%;">
                                                            <div align="left">
                                                                <div class="bglabel" style="width: 20%;">
                                                                    <span id="spnTempName" runat="server"></span><span style="color: Red; padding-left: 3px">
                                                                        *</span>
                                                                </div>
                                                                <asp:TextBox ID="lblemail" runat="server" Style="display: none"></asp:TextBox>
                                                                <div class="box" style="width: 60%">
                                                                    <asp:TextBox runat="server" ID="txtemailtempname" SkinID="textPad" Width="200px"
                                                                        TextMode="singleline" MaxLength="255">
                                                                    </asp:TextBox>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <span id="spn_txtemailtempname" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px">Please enter template name</span>
                                                                </div>
                                                            </div>
                                                            <div align="left">
                                                                <div class="bglabel" style="width: 20%;">
                                                                    <asp:Label ID="lbl_Subject" runat="server"></asp:Label>
                                                                </div>
                                                                <div class="box" style="width: 60%">
                                                                    <asp:TextBox ID="txt_Subject" runat="server" Width="480px" Height="15px" CssClass="textboxnew"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="onlyEmpty">
                                                            </div>
                                                            <div id="divTempType" align="left">
                                                                <div class="bglabel" style="width: 20%;">
                                                                    <asp:Label ID="lbl_templateType" runat="server"></asp:Label><span style="color: Red;
                                                                        padding-left: 3px">*</span>
                                                                </div>
                                                                <div class="box" style="width: 60%">
                                                                    <asp:DropDownList ID="ddlEmailTemplateType" runat="server" CssClass="normalText"
                                                                        Width="208px">
                                                                        <asp:ListItem Value="0">--- Select ---</asp:ListItem>
                                                                        <asp:ListItem Value="Recieved">Supplier Quote Recieved</asp:ListItem>
                                                                        <asp:ListItem Value="Rejected">Supplier Quote Rejected</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <span id="spn_ddlEmailTemplateType" class="spanerrorMsg" style="display: none; width: auto;
                                                                        padding-left: 4px; padding-right: 4px">Please select template type</span>
                                                                </div>
                                                            </div>
                                                            <div class="onlyEmpty">
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div id="lblPhraseText" class=" bglabel_new" style="width: 20.2%; height: 305px;">
                                                                <span id="SpnPhraseText" style="color: Black" runat="server">
                                                                    <asp:Label ID="lblEmailBody" runat="server"></asp:Label></span>
                                                            </div>
                                                            <div class="box" style="width: 70%; border: 0px solid red">
                                                                <div id="div2" style="border: 0px solid; float: left">
                                                                    <telerik:RadEditor ID="RadEditor2" runat="server" Width="90%" Height="300px" EditModes="Design,Html"
                                                                        ToolsFile="~/RadEditorDialogs/Tools/tools.xml" ExternalDialogsPath="~/RadEditorDialogs"
                                                                        ContentFilters="MakeUrlsAbsolute" ImageManager-ViewMode="Grid" ContentAreaMode="Iframe"
                                                                        OnClientLoad="OnClientLoad">
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
                                                                            style="display: none; width: auto; padding-left: 4px; padding-right: 4px">Please
                                                                            enter E-mail body</span>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <br />
                                                            <div align="left">
                                                                <div class="bglabel" style="width: 20%;">
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
                                                    <div style="float: left;">
                                                        <div id="div_btncancel" style="display: block">
                                                            <asp:Button ID="btnCancel" CssClass="buttoncustomtxt" runat="server" Text="Cancel"
                                                                CausesValidation="false" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');" />
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
                                                            <asp:Button ID="btnSave" CssClass="buttoncustomtxt" runat="server" Text="Save" OnClientClick="javascript:var a=Validate('');if(a)loadingimage(this.id,'div_saveprocess');return a;"
                                                                OnClick="btnSave_OnClick" />
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
                                                <div class="only5px">
                                                </div>
                                            </div>
                                            <br />
                                            <span class="HeaderText">
                                                <%=objLanguage.GetLanguageConversion("Custom_Tags") %></span>
                                            <div class="only5px">
                                            </div>
                                            <span class="normalText">
                                                <%=objLanguage.GetLanguageConversion("Replace_Tags_Value")%>
                                            </span>
                                            <div class="only5px">
                                            </div>
                                            <div id="events" style="width: 100%; padding: 5px 0px 10px 0px;">
                                                <asp:UpdatePanel ID="UpdatePanel_CustomTags" runat="server" UpdateMode="Conditional"
                                                    ChildrenAsTriggers="false">
                                                    <ContentTemplate>
                                                        <telerik:RadGrid ID="RadGrid_CustomTags" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                                            AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true"
                                                            GroupingEnabled="false" PageSize="50" Width="700px" ShowGroupPanel="false" ShowStatusBar="true"
                                                            HeaderStyle-Font-Bold="true">
                                                            <HeaderStyle Width="100px" />
                                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                            <PagerStyle Mode="NextPrevAndNumeric" />
                                                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="TagID" HorizontalAlign="NotSet"
                                                                OverrideDataSourceControlSorting="true" Width="100%">
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn DataField="TagEvent" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="35%" HeaderText="Tag name" ItemStyle-Width="35%" UniqueName="TagEvent"
                                                                        Visible="true">
                                                                        <HeaderTemplate>
                                                                            <div>
                                                                                <asp:Label ID="Label4" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Tag_Name")%>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; overflow: hidden">
                                                                                <input type='text' name="TagName" size="30" value='<%# DataBinder.Eval(Container, "DataItem.TagEvent", "{0}") %>'
                                                                    readonly="readonly"     onclick="this.select();" id="TagName" />
                                                                                <asp:Label ID="lbl_TagEvent" runat="server"></asp:Label>
                                                                            </div>
                                                                            <asp:HiddenField ID="hdn_TagEvent" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.TagEvent", "{0}") %>'>
                                                                            </asp:HiddenField>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="TagDescription" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="60%" HeaderText="Description" ItemStyle-Width="45%" UniqueName="TagEvent"
                                                                        Visible="true">
                                                                        <HeaderTemplate>
                                                                            <div>
                                                                                <asp:Label ID="Label5" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Description")%></div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                                                <asp:Label ID="lbl_Subject" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TagDescription", "{0}") %>'></asp:Label></div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                <NoRecordsTemplate>
                                                                    <div style="padding: 0px 0px 0px 10px">
                                                                        <%=objLanguage.GetLanguageConversion("No_Record_Found") %>
                                                                    </div>
                                                                </NoRecordsTemplate>
                                                            </MasterTableView>
                                                            <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                                                AllowDragToGroup="false">
                                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                            </ClientSettings>
                                                        </telerik:RadGrid>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div style="clear: both;">
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <asp:HiddenField ID="chkBodyID" runat="server" />
                                <asp:HiddenField ID="hiddenEmailtoAdminID" Value="" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="div_test_1" style="width: 100%; overflow: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            Loading...</div>
    </div>
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>" type="text/javascript"
        language="javascript"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>"></script>
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

        function addnew(type) {
            document.getElementById('div_Load').style.display = 'block';
            setTimeout("displayAddNew()", 3000);
            setTimeout("desableAfterLoad()", 4000);
            document.getElementById('tdaddnew').style.display = 'block';

            var txtemailtempname = document.getElementById("<%=txtemailtempname.ClientID %>");
            var txt_Subject = document.getElementById("<%=txt_Subject.ClientID %>");
            var ddlEmailTemplateType = document.getElementById("<%=ddlEmailTemplateType.ClientID %>");

            var Radeditor = document.getElementById("<%=RadEditor2.ClientID %>");
            var chkDefaultEmailBody = document.getElementById("<%=chkDefaultEmailBody.ClientID %>");
            var lblID = document.getElementById("ctl00_ContentPlaceHolder1_lblemail");

            if (type == 'add') {
                txtemailtempname.value = "";
                txt_Subject.value = "";
                ddlEmailTemplateType.selectedIndex = "0";
                chkDefaultEmailBody.checked = false;
                $find("<%=RadEditor2.ClientID%>").set_html("");
                lblID.value = "";
            }
            else {
                return false;
            }
            txtemailtempname.focus();
        }

        function Validate(type, obj) {
            var checkwhat = true;

            var txtphrasetext = document.getElementById("<%=RadEditor2.ClientID %>");
            var txtemailtempname = document.getElementById("<%=txtemailtempname.ClientID %>");
            var ddlEmailTemplateType = document.getElementById("<%=ddlEmailTemplateType.ClientID %>");
            document.getElementById("spn_txtphrasetext").style.display = "none";
            document.getElementById("spn_ddlEmailTemplateType").style.display = "none";
            document.getElementById("spn_txtphrasetext").style.display = "none";
            document.getElementById("spn_txtemailtempname").style.display = "none";

            if (CheckStringMandatory(txtemailtempname.value, 'spn_txtemailtempname')) {
                checkwhat = false;
            }
            if (CallonChange(ddlEmailTemplateType.value, 'spn_ddlEmailTemplateType')) {
                checkwhat = false;
            }

            if (checkwhat) {
                return true;
            }
            else {
                return false;
            }
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

