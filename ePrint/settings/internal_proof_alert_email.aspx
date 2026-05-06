<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="internal_proof_alert_email.aspx.cs" Inherits="ePrint.settings.internal_proof_alert_email" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../js/animation.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <script src="../js/item/general.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
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
        }
        .RadGrid_Default .rgCommandTable
        {
            margin-top: -12px;
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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdAutoJobAlert">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdAutoJobAlert" />
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
                    <telerik:AjaxUpdatedControl ControlID="lnkStatus" />
                    <telerik:AjaxUpdatedControl ControlID="txtSubject" />
                    <telerik:AjaxUpdatedControl ControlID="chkDefaultEmailBody" />
                    <telerik:AjaxUpdatedControl ControlID="ddlStatus" />
                    <telerik:AjaxUpdatedControl ControlID="ddlSignature" />
                    <telerik:AjaxUpdatedControl ControlID="txt_cc" />
                    <telerik:AjaxUpdatedControl ControlID="txt_bcc" />
                    <telerik:AjaxUpdatedControl ControlID="txt_EmailTo" />
                    <telerik:AjaxUpdatedControl ControlID="chkEnabled" />
                    <telerik:AjaxUpdatedControl ControlID="ImgButtonErase" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ImgButtonErase">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdAutoJobAlert" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7">
    </telerik:RadAjaxLoadingPanel>
    <div align="left" id="pnlproductlowstockemaildetails">
        <div align="left">
            <div class="navigatorpanel AccordPanel" style="display: none;">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" nowrap="nowrap">
                                    <asp:Label runat="server" ID="lblheader"><%=objLangauge.GetLanguageConversion("Auto_Job_Alert_Email")%></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
        <div id="content" class="estore_settingBox">
            <UC:Header_MIS ID="header_mis" runat="server" />
            <div class="">
                <div align="left" class="AccordPanel mis_header_panel">
                    <div id="">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table cellpadding="1" cellspacing="1" border="0" class="AccordPanel">
                            <tr>
                                <td class="PraseMenue" style="width: 11%;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                </td>
                                <td class="tdcontent" style="padding-bottom: 0px;">
                                    <div class="autodiv">
                                        <div class="autodivcontent">
                                            <div class="mainheader">
                                            </div>
                                            <div class="mainheader">
                                                <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <ContentTemplate>--%>
                                                <div id="div_popupAction" style="margin: 48px 0px 0px 16px;" onmouseover="show();"
                                                    onmouseout="hide(); ">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div class="AccordPanel">
                                                                    <div class="divDropdownlist autopopupaction">
                                                                        <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" CommandName="Delete"
                                                                            OnClick="btnDelete_OnClick" CssClass="autodeletetxt" ForeColor="#333333" OnClientClick="javascript:return CallDelete();"
                                                                            CausesValidation="false"></asp:LinkButton></div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="a">
                                    </div>
                                    <div id="div_Grid" class="autogriddiv" style="width: 1000px; margin-top: 3px; margin-left: -2px">
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false"
                                            runat="server">
                                            <ContentTemplate>
                                                <div id="div1" class="mis_header_panel" style="margin-top: -8px;">
                                                    <telerik:RadGrid ID="grdAutoJobAlert" AutoGenerateColumns="false" runat="server"
                                                        BorderWidth="0" itemstyle-heigh="2%" GridLines="None" AllowPaging="true" PageSize="50"
                                                        Width="60%" PagerStyle-AlwaysVisible="true" OnItemDataBound="gridautojobalert_OnItemDataBound" HeaderStyle-Font-Bold="true"> <%--OnItemDataBound="grdaurojobalert_OnItemDataBound">--%>
                                                        <MasterTableView CommandItemDisplay="Top">
                                                            <CommandItemTemplate>
                                                                <table class="rgCommandTable AccordPanel" border="0">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:LinkButton ID="lnkAddNew" runat="server" Text="" OnClientClick="javascript:addnew('add');"> <%=objLangauge.GetLanguageConversion("Add_New_Record") %></asp:LinkButton>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </CommandItemTemplate>
                                                            <Columns>
                                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                                    AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                                    <HeaderTemplate>
                                                                        <div id="div_chk" style="width: inherit; height: inherit;">
                                                                            <table border="0" cellpadding="0" cellspacing="0" class="autogridarrow">
                                                                                <tr>
                                                                                    <td>
                                                                                        <input type="checkbox" id="checkAll1" onclick="CheckAll(this);" runat="server" name="checkAll1" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Panel ID="pnl_chkImage" runat="server">
                                                                                            <div class="deletearrow">
                                                                                                <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" class="arrowdown"
                                                                                                    onclick="show();" alt='' />
                                                                                                <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" class="arrowup" onclick="hide();"
                                                                                                    alt='' />
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
                                                                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                    ItemStyle-Width="45%" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkStatus" Width="99%" runat="server" OnClick="lnkStatus_onClick"
                                                                            CommandArgument='<%#Eval("EmailID")%>' Text='<%#Eval("StatusID")%>' OnClientClick="javascript:addnew('edit');"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="Subject" HeaderStyle-HorizontalAlign="Left"
                                                                    ItemStyle-Wrap="false" ItemStyle-Width="15%" HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:HiddenField ID="hdnSubject" runat="server" Value='<%#Eval("Subject")%>' />
                                                                        <asp:LinkButton ID="lnkSubject" Width="99%" runat="server" CommandArgument='<%#Eval("EmailID")%>'
                                                                            Text='<%#Eval("Subject")%>' OnClientClick="javascript:return addnew('edit');"
                                                                            OnClick="lnkSubject_OnClick"></asp:LinkButton>
                                                                        <%--'<%#Eval("Subject")%>'--%>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderText="Enabled" ItemStyle-Wrap="false" ItemStyle-Width="20%"
                                                                    ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20%" Wrap="false" />
                                                                    <ItemTemplate>
                                                                        <center>
                                                                            <asp:Image ID="imgdefault" runat="server"></asp:Image>
                                                                            <asp:HiddenField ID="hdnDefaultVal" Value='<%#Eval("ISEnabled")%>' runat="server" />
                                                                        </center>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn>
                                                                    <HeaderTemplate>
                                                                        <input type="checkbox" id="checkAll" onclick="CheckAll(this); changebgColor(this);"
                                                                            runat="server" name="checkAll" style="display: none" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <center>
                                                                            <input type="checkbox" runat="server" id="chkEmailBodyId" onclick="CheckChanged();"
                                                                                name="Id" value='<%#Eval("EmailID")%>' style="display: none" />
                                                                            <asp:Label ID="hdnEmailID" Text='<%#Eval("EmailID")%>' Visible="false" runat="server" /></center>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                                <telerik:GridTemplateColumn HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"
                                                                    ItemStyle-HorizontalAlign="Center" HeaderText="Action">
                                                                    <ItemTemplate>
                                                                        <center>
                                                                            <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                                CommandArgument='<%#Eval("EmailID")%>' Text="Delete" UniqueName="DeleteColumn"
                                                                                OnCommand="lnkDelete_onclick" ToolTip="Delete" runat="server" OnClientClick="javascript:return ImgButtonErase_ClientClick1('ctl00_ContentPlaceHolder1_grdAutoJobAlert',this.id)">
                                                                            </asp:ImageButton></center>
                                                                    </ItemTemplate>
                                                                </telerik:GridTemplateColumn>
                                                            </Columns>
                                                        </MasterTableView><ClientSettings>
                                                        </ClientSettings>
                                                    </telerik:RadGrid></div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="only5px">
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div class="only10px">
                                    </div>
                                    <div class="autotable" id="EmaiBody">
                                        <div align="left">
                                        </div>
                                        <div id="div_Load" class="loading_new autocancelProcess">
                                            <UC:Loading ID="ucLoading" runat="server" />
                                        </div>
                                        <div id="tdaddnew" class="autotablenone">
                                            <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div id="tdemailaddnew" class="autotable">
                                                        <div align="left">
                                                            <div class="bglabel statustd">
                                                                <span id="spnTempName">
                                                                    <asp:Label ID="lblStatus" runat="server"><%=objLangauge.GetLanguageConversion("Status")%></asp:Label></span>
                                                                <span style="color: red;">*</span>
                                                            </div>
                                                            <div class="box statusddl">
                                                                <asp:DropDownList ID="ddlStatus" runat="server" onchange="javascript:var a=dispnone();if(a) return a;"
                                                                    CssClass="MailchimpDefaultSettingsbox normaltext">
                                                                </asp:DropDownList>
                                                                <span id="spn_ddlStatus" class="RFV_Message autoccerrormsg" style="width: auto; padding-left: 4px;
                                                                    padding-right: 4px; margin-top: -20px; margin-left: 185px;"></span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:Label ID="lblemail" runat="server" CssClass="autocancelProcess"></asp:Label>
                                                    <div id="div_SubJect" class="autotable">
                                                        <div align="left">
                                                            <div class="bglabel statustd">
                                                                <span id="Span1">
                                                                    <asp:Label ID="Label2" runat="server"><%=objLangauge.GetLanguageConversion("Subject")%></asp:Label></span>
                                                            </div>
                                                            <asp:Label ID="lblSubject" runat="server" CssClass="autocancelProcess"></asp:Label>
                                                            <div class="box statusddl">
                                                                <asp:TextBox ID="txtSubject" runat="server" CssClass="AutoJobSubjecttextbox"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div align="left">
                                                        <div id="lblEmailBody" class="bglabel_AutoJob autoemailbody">
                                                            <span id="SpnPhraseText" class="lnkTabSelected">
                                                                <asp:Label ID="Label3" runat="server"><%=objLangauge.GetLanguageConversion("Email_Body")%></asp:Label></span>
                                                        </div>
                                                        <div class="box radeditorwidth">
                                                            <div id="divFckEditor" class="mainheader">
                                                                <telerik:RadEditor ID="RadEditor1" runat="server" Width="90%" Height="300px" EditModes="Design,Html"
                                                                    imagemanager-viewmode="Grid" ContentAreaMode="Iframe" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                                                    ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute" OnClientLoad="OnClientLoad">
                                                                    <Content>
                                                                          
                                                                    </Content>
                                                                    <CssFiles>
                                                                        <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                                                    </CssFiles>
                                                                </telerik:RadEditor>
                                                                <div class="only5px">
                                                                </div>
                                                                <span id="spn_txtDescription_length" class="spanerrorMsg statuserrormsg">Max. length
                                                                    of textbox is: 3000</span><span id="spn_txtphrasetext" class="spanerrorMsg statuserrormsg">Please
                                                                        enter E-mail body</span>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div align="left">
                                                            <div class="bglabel statustd">
                                                                <span id="Span3">
                                                                    <asp:Label ID="lblSignature" runat="server"><%=objLangauge.GetLanguageConversion("Signature")%></asp:Label></span>
                                                            </div>
                                                            <div class="box statusddl">
                                                                <asp:DropDownList ID="ddlSignature" runat="server" CssClass="MailchimpDefaultSettingsbox normaltext">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div class="bglabel statustd">
                                                                <span id="spn_defaultSignature">
                                                                    <asp:Label ID="lblEnable" runat="server"><%= objLangauge.GetLanguageConversion("Activate_Email")%></asp:Label></span>
                                                            </div>
                                                            <div class="box statusddl">
                                                                <asp:CheckBox ID="chkEnabled" runat="server"></asp:CheckBox>
                                                            </div>
                                                        </div>
                                                        <div>
                                                                <div class="bglabel statustd autojobcc">
                                                                    <span id="Span6">
                                                                        <asp:Label ID="lbl_EmailTo" runat="server" Text=""><%=objLangauge.GetLanguageConversion("To")%></asp:Label></span>
                                                                </div>
                                                                <div class="autojobccbcc autocc margintop2px">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txt_EmailTo" TextMode="MultiLine" CssClass="textpad ccbcctxtbox" runat="server"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                                                                    <img alt="" id="img1" runat="server" src="../images/Help-icon.png" class="tooltip autohelpicon" /></a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <span id="Spn_ErrMsgTo" class="RFV_Message autoccerrormsg" style="width: auto;
                                                                                    padding-left: 4px; padding-right: 4px;"></span><span id="SpnChkErr2" class="RFV_Message autoccerrormsg">
                                                                                    </span>
                                                                                <%--  Please enter email address--%>
                                                                                <asp:HiddenField ID="HiddenField3" runat="server" Value="" />
                                                                                <i class="graytext autocchelptext">[Please separate multiple email addresses with a
                                                                                    comma] </i>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div>
                                                                    <asp:HiddenField ID="HiddenField4" runat="server" Value="" />
                                                                    <i class="graytext autocchelptext">[Please separate multiple email addresses with a
                                                                        comma] </i>
                                                                </div>
                                                            </div>
                                                        <div>
                                                            <div class="bglabel statustd autojobcc">
                                                                <span id="Span4">
                                                                    <asp:Label ID="lblCC" runat="server" Text=""><%=objLangauge.GetLanguageConversion("CC")%></asp:Label></span>
                                                            </div>
                                                            <div class="autojobccbcc autocc margintop2px">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_cc" TextMode="MultiLine" CssClass="textpad ccbcctxtbox" runat="server"
                                                                                onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrMsgCC1');"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                                                                <img alt="" id="img2" runat="server" src="../images/Help-icon.png" class="tooltip autohelpicon" /></a>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <span id="Span2" class="RFV_Message autoccerrormsg"></span>
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
                                                                            <span id="Spn_ErrMsgCC1" class="RFV_Message autoccerrormsg" style="width: auto; padding-left: 4px;
                                                                                padding-right: 4px;"></span>
                                                                            <%--  Please enter email address--%><i class="graytext autocchelptext"> [Please separate
                                                                                multiple email addresses with a comma] </i>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <%--  <asp:TextBox ID="txt_cc" TextMode="MultiLine" CssClass="textpad" runat="server" Width="320px"
                                                                    onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrMsgCC1');"></asp:TextBox>
                                                                <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                                                    <img alt="" id="img_help_productthumbnail" runat="server" src="../images/Help-icon.png"
                                                                        style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                                        class="tooltip" /></a> <span id="Spn_ErrMsgCC1" class="RFV_Message" style="display: none;
                                                                            width: 220px;"></span>--%>
                                                            </div>
                                                            <%-- <div>
                                                                <asp:HiddenField ID="hdn_cc" runat="server" Value="" />
                                                                <span id="SpnChkErr" class="RFV_Message autoccerrormsg">Please enter email address</span>
                                                                <i class="graytext autocchelptext">[Please separate multiple email addresses with a
                                                                    comma] </i>
                                                            </div>--%>
                                                            <div>
                                                                <div class="bglabel statustd autojobcc">
                                                                    <span id="Span5">
                                                                        <asp:Label ID="lblBCC" runat="server" Text=""><%=objLangauge.GetLanguageConversion("BCC")%></asp:Label></span>
                                                                </div>
                                                                <div class="autojobccbcc autocc margintop2px">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:TextBox ID="txt_bcc" TextMode="MultiLine" CssClass="textpad ccbcctxtbox" runat="server"
                                                                                    onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrMsgBCC1');"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                                                                    <img alt="" id="img3" runat="server" src="../images/Help-icon.png" class="tooltip autohelpicon" /></a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <span id="Spn_ErrMsgBCC1" class="RFV_Message autoccerrormsg" style="width: auto;
                                                                                    padding-left: 4px; padding-right: 4px;"></span><span id="SpnChkErr1" class="RFV_Message autoccerrormsg">
                                                                                    </span>
                                                                                <%--  Please enter email address--%>
                                                                                <asp:HiddenField ID="HiddenField2" runat="server" Value="" />
                                                                                <i class="graytext autocchelptext">[Please separate multiple email addresses with a
                                                                                    comma] </i>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <%-- <asp:TextBox ID="txt_bcc" TextMode="MultiLine" CssClass="textpad" runat="server"
                                                                        Width="320px" onchange="javascript:ValidateMultiEmail(this.value,'Spn_ErrMsgBCC1');"></asp:TextBox>
                                                                    <a href="#" class="tooltip" title="Please separate multiple email addresses with a comma">
                                                                        <img alt="" id="img1" runat="server" src="../images/Help-icon.png" style="cursor: pointer;
                                                                            width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                                            class="tooltip" /></a> <span id="Spn_ErrMsgBCC1" class="RFV_Message" style="display: none;
                                                                                width: 220px;"></span><span id="SpnChkErr1" class="RFV_Message" style="display: none;
                                                                                    width: 220px;">Please enter email address</span>--%>
                                                                </div>
                                                                <div>
                                                                    <asp:HiddenField ID="hdn_bcc" runat="server" Value="" />
                                                                    <i class="graytext autocchelptext">[Please separate multiple email addresses with a
                                                                        comma] </i>
                                                                </div>
                                                            </div>


                                                            
                                                        </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <div class="only5px">
                                            </div>
                                            <div class="autotable">
                                                <div class="autobutton" style="width: 21%;">
                                                    &nbsp;
                                                </div>
                                                <div class="mainheader">
                                                    <div id="div_btncancel" class="autobtncancel">
                                                        <asp:Button ID="btnCancel" CssClass="buttoncustomtxt" runat="server" Text="Cancel"
                                                            OnClick="btnCancel_OnClick" CausesValidation="false" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');" />
                                                    </div>
                                                    <div id="div_cancelprocess" class="autocancelProcess">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                                <div class="autobtngap">
                                                    &nbsp;
                                                </div>
                                                <div class="mainheader">
                                                    <div id="div_btnSave" class="autobtncancel">
                                                        <asp:Button ID="btnSave" CssClass="buttoncustomtxt" runat="server" Text="Save" OnClientClick="javascript:var a=Validating();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                                                            OnClick="btnSave_OnClick" />
                                                    </div>
                                                    <div id="div_btnsaveprocess" style="display: none">
                                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="only10px">
                                            </div>
                                            <div class="only10px">
                                            </div>
                                            <div class="autocustometable">
                                                <div id="divestimate" class="autobtncancel">
                                                    <span class="HeaderText">Custom Tags for Proof</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.
                                                    </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2 autocustomewidth" border="0" cellpadding="0" cellspacing="0">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheaderJob" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel custometd">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel statusddl">
                                                                    &nbsp;Description
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" align="right" valign="top" width="1%" style="border-top-right-radius: 5px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" width="100%">
                                                                    <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="custometd" nowrap="nowrap">
                                                                                    <input type='text' name="SalesPerson" size="30" value='[$SalesPerson$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="custometdflow">
                                                                                    &nbsp;Sales Person Email Address
                                                                                </td>
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="custometd" nowrap="nowrap">
                                                                                    <input type='text' name="InternalProofURL" size="30" value='[$InternalProofURL$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="custometdflow">
                                                                                    &nbsp;URL to the page of Proof
                                                                                </td>
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="custometd" nowrap="nowrap">
                                                                                    <input type='text' name="Estimator" size="30" value='[$Estimator$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="custometdflow">
                                                                                    &nbsp;Estimator Email Address
                                                                                </td>
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>

                                                                              <tr class="NewTableRows" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="EstimateTitle" size="30" value='[$EstimateOrJobname$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate or job name
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
                                                                                    <input type='text' name="Itemtitle" size="30" value='[$CustomerName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Name
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
                                                                                    <input type='text' name="Quantity" size="30" value='[$CustomerContactName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Contact Name
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
                                                                                    <input type='text' name="Material" size="30" value='[$ProofNumber$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Proof Number
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
                                                                                    <input type='text' name="Size" size="30" value='[$EstimateNumber$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Number
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
                                                                                    <input type='text' name="Colour" size="30" value='[$OrderNumber$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Order Number
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
                                                                                    <input type='text' name="Finishing" size="30" value='[$JobNumber$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                           <%-- <tr>
                                                                <td colspan="4">
                                                                    <div>
                                                                        <span class="smallgraytext">
                                                                            <%=objLanguage.GetLanguageConversion("Please_Note_This_Email_is_not_applicable_for_eStore_jobs_To_configuare_ePrint_job_email")%>
                                                                            <a href="../StoreSettings/Phrase_Book.aspx?type=em" style="text-decoration: underline">
                                                                                <span class="autojobclickhere">
                                                                                    <%=objLanguage.GetLanguageConversion("Click_Here") %></span></a></span>
                                                                    </div>
                                                                </td>
                                                            </tr>--%>
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
                                <asp:HiddenField ID="chkBodyID" runat="server" />
                                <asp:HiddenField ID="hiddenEmailID" Value="" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <%--<input type="hidden" name="ctl00$ContentPlaceHolder1$hdntypesave" id="ctl00_ContentPlaceHolder1_hdntypesave" />--%>
        <asp:HiddenField ID="hdntypesave" Value="" runat="server" />
    </div>
    <script type="text/javascript">
        var ddlStatus = document.getElementById("ctl00_ContentPlaceHolder1_ddlStatus")
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");


        var NoOFCnt_Address = 0;
        var cnt_Address = 0;
        var IDLenght_Address = 0;
        var ActionType_costcenter = '';
        var Counter_costcenter = 0;

    </script>
    <script type="text/javascript">
        function ImgButtonErase_ClientClick1(GridID, ImageButtonID) {
            if (confirm("Delete this Internal Proof Alert?")) {

                return true;
            }
            else {
                return false;
            }
        }
        function Validating() {

            var txt_cc = document.getElementById("<%=txt_cc.ClientID %>");
            var txt_bcc = document.getElementById("<%=txt_bcc.ClientID %>");
            var ddlStatus = document.getElementById("<%=ddlStatus.ClientID %>");
            var spn_ddlStatus = document.getElementById("spn_ddlStatus");
            var ret1, ret2;
            var Spn_ErrMsgCC1 = document.getElementById("Spn_ErrMsgCC1");
            var Spn_ErrMsgBCC1 = document.getElementById("Spn_ErrMsgBCC1");
            if (txt_cc.value == '' && txt_bcc.value == '' && ddlStatus.value == 0) {
                spn_ddlStatus.innerHTML = "Please select status";
                spn_ddlStatus.style.display = "block";
                return false;
            }
            else if (ddlStatus.value == 0) {
                spn_ddlStatus.innerHTML = "Please select status";
                spn_ddlStatus.style.display = "block";
                return false;
            }
            else if (txt_cc.value != '' && txt_bcc.value != '') {

                ret1 = echeck(txt_cc.value, 'Spn_ErrMsgCC1');
                ret2 = echeck(txt_bcc.value, 'Spn_ErrMsgBCC1');
                if ((ret1 == false) && (ret2 == false)) {
                    Spn_ErrMsgCC1.innerHTML = "Please enter valid email address";
                    Spn_ErrMsgCC1.style.display = "block";
                    Spn_ErrMsgBCC1.innerHTML = "Please enter valid email address";
                    Spn_ErrMsgBCC1.style.display = "block";
                    return false;
                }
                else if (ret1 == false) {
                    Spn_ErrMsgCC1.innerHTML = "Please enter valid email address";
                    Spn_ErrMsgCC1.style.display = "block";
                    return false;
                }
                else if (ret2 == false) {
                    Spn_ErrMsgBCC1.innerHTML = "Please enter valid email address";
                    Spn_ErrMsgBCC1.style.display = "block";
                    return false;
                }
            }
            else { return true; }
        }
        function echeck(str) {
            //    var EmailExn = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var EmailExn = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!EmailExn.test(str)) {
                return false
            }
            return true
        }
        function dispnone() {

            var ddlStatus = document.getElementById("<%=ddlStatus.ClientID %>").value;
            if (ddlStatus == 0) {
                spn_ddlStatus.innerHTML = "Please select status";
                spn_ddlStatus.style.display = "block";
                return false;
            } else {
                spn_ddlStatus.innerHTML = "Please select status";
                spn_ddlStatus.style.display = "none"; return true;
            }
        }
        function validateEmail(field) {
            //var regex = /\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b/i;
            //var regex = /^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?), ?)*^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            //var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return (regex.test(field)) ? true : false;
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
        var hdntypesave = document.getElementById("hdntypesave");
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
