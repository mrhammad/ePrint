<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.Master" AutoEventWireup="true" CodeBehind="ProofReturnEmailBody.aspx.cs" Inherits="ePrint.settings.ProofReturnEmailBody" %>
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
    <script>
        function desableAfterLoad() {
            window.document.getElementById("div_Load").style.display = "none";
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
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
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
                    <telerik:AjaxUpdatedControl ControlID="ddlFooterSignature" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkDefaultEmailBody" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="ddlSpecificType" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdEmailBody" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdEmailBody">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txttemplatesubject" />
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
                                    <asp:Label runat="server" ID="lblheader"><%=objLanguage.GetLanguageConversion("Settings_Email_Body_Heading")%></asp:Label>
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
                                    <div class="only5px">
                                    </div>
                                    <div align="left" style="width: 60%;">
                                        <div style="width: 40%; float: left;">
                                            <div style="float: left;">
                                            </div>
                                            <div style="float: left">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div id="div_popupAction" style="margin: 42px 0px 0px 8px;" onmouseover="show();"
                                                            onmouseout="hide(); ">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div style="width: 100%;">
                                                                            <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 110px;
                                                                                border: 1px solid #C5C5C5;">
                                                                                <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" OnClick="btnDelete_OnClick"
                                                                                    CommandName="Delete" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px"
                                                                                    OnClientClick="javascript:return CallDelete();" CausesValidation="false" Visible="false"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton></div>
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
                                    <div id="div_Grid" style="width: 1000px; margin-top: -12px;">
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" ChildrenAsTriggers="false"
                                            runat="server">
                                            <ContentTemplate>
                                                <telerik:RadGrid ID="grdEmailBody" AutoGenerateColumns="false" runat="server" OnItemDataBound="grdPraseBookEmailSignature_OnItemDataBound"
                                                    BorderWidth="0" ItemStyle-Heigh="2%" GridLines="None" AllowPaging="true" PageSize="50"
                                                    OnPageIndexChanged="grdEmailBody_PageIndexChanged" OnPageSizeChanged="grdEmailBody_PageSizeChanged"
                                                    Width="70%" PagerStyle-AlwaysVisible="true" HeaderStyle-Font-Bold="true">
                                                    <MasterTableView CommandItemDisplay="Top">
                                                        <CommandItemTemplate>
                                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:LinkButton ID="lnkAddNew" OnClick="lnkAddNew_OnClik" runat="server" OnClientClick="javascript:addnew1('add');"
                                                                            Text="">
                                                                        
                                                                      
                                                                      <%=objLanguage.GetLanguageConversion("Add_New_Record") %></asp:LinkButton>
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
                                                                        <input type="checkbox" runat="server" id="chkEmailBodyId1" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.EmailID", "{0}") %>'
                                                                            onclick="CheckChanged();" />
                                                                    </div>
                                                                    <input type="hidden" id="hdnUPDOWN" runat="server" /></ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                ItemStyle-Width="45%" ItemStyle-HorizontalAlign="Left">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkTemplateName" Width="99%"  runat="server" OnClick="lnkBody_onClick"
                                                                        CommandArgument='<%#Eval("EmailID")%>' Text='<%#Eval("TemplateName")%>' OnClientClick="javascript:addnew1('edit');"></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="40%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnTemplateType" runat="server" Value='<%#Eval("TemplateType")%>' />
                                                                    <%#Eval("TemplateType")%>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                ItemStyle-Width="40%" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="45%" />
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="hdnSpecificTo" runat="server" Value='<%#Eval("SpecificTo")%>' />
                                                                    <asp:Label ID="lblSpecificTo" runat="server" Text='<%#Eval("SpecificToName")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Left" ItemStyle-Wrap="false"
                                                                ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                                                                <HeaderStyle HorizontalAlign="Left" Width="10%" Wrap="false" />
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
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Right" HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                        CommandArgument='<%#Eval("EmailID")%>' Text="Delete" UniqueName="DeleteColumn"
                                                                        runat="server" OnCommand="lnkDelete_onclick" ToolTip="Delete" OnClientClick="javascript:return ImgButtonErase_ClientClick('ctl00_ContentPlaceHolder1_grdEmailBody',this.id)">
                                                                    </asp:ImageButton>
                                                                    <asp:ImageButton runat="server" ID="imgbtnCopy" ImageUrl="~/images/copy.gif" ToolTip="Copy"
                                                                        Height="18px" OnCommand="imgbtnCopy_OnCommand" OnClientClick="javascript:return CheckOne_copy();"
                                                                        CommandArgument='<%#Eval("EmailID")%>' />
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
                                        <div id="div_Load" class="loading_new" style="display: none; z-index: 10000;">
                                            <UC:Loading ID="ucLoading" runat="server" />
                                        </div>
                                        <div id="tdaddnew" align="left" style="width: 100%; display: none;">
                                            <asp:UpdatePanel ID="UpdatePanelEdit" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div id="tdemailaddnew" align="left" style="width: 100%;">
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="spnTempName" runat="server"></span><span style="color: red">*</span>
                                                            </div>
                                                            <asp:Label ID="lblemail" runat="server" Style="display: none"></asp:Label>
                                                            <div class="box" style="width: 60%">
                                                                <asp:TextBox runat="server" ID="txtemailtempname" SkinID="textPad" Width="200px"
                                                                    TextMode="singleline" MaxLength="255">
                                                                </asp:TextBox>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                                <span id="spn_txtemailtempname" class="spanerrorMsg" style="display: none; width: auto;
                                                                    padding-left: 4px; padding-right: 4px; margin-left: 4px;">Please enter template
                                                                    name</span>
                                                            </div>
                                                        </div>
                                                       <%-- <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <asp:Label ID="lbl_SpecificTo" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:DropDownList ID="ddlSpecificType" runat="server" Width="208px" CssClass="normalText">
                                                                </asp:DropDownList>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                                <span id="spn_specificto" class="spanerrorMsg" style="display: none; width: auto;
                                                                    padding-left: 4px; padding-right: 4px; margin-left: 4px;">Please select specific
                                                                    type</span>
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>--%>
                                                       <%-- <div id="divTempType" align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <asp:Label ID="lbl_TemplateType" runat="server"></asp:Label><span style="color: red">
                                                                    *</span>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:DropDownList ID="ddlEmailTemplateType" runat="server" CssClass="normalText"
                                                                    Width="208px" onchange="Javascript:SelectTemplateType();">
                                                                    <asp:ListItem Value="0">--- Select ---</asp:ListItem>
                                                                    <asp:ListItem Value="estimate">Estimate</asp:ListItem>
                                                                    <asp:ListItem Value="supplier rfq">Supplier RFQ</asp:ListItem>
                                                                    <asp:ListItem Value="job">Job</asp:ListItem>
                                                                    <asp:ListItem Value="invoice">Invoice</asp:ListItem>
                                                                    <asp:ListItem Value="purchase order">Purchase Order</asp:ListItem>
                                                                    <asp:ListItem Value="delivery note">Delivery Note</asp:ListItem>
                                                                    <asp:ListItem Value="webstoreorder">eStore Order</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                                <span id="spn_ddlEmailTemplateType" class="spanerrorMsg" style="display: none; width: auto;
                                                                    padding-left: 4px; padding-right: 4px; margin-left: 4px;">Please select template
                                                                    type</span>
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>--%>
                                                    </div>
                                                    <div id="divsubject" align="left">
                                                        <div class="bglabel" style="width: 20%;">
                                                            <asp:Label ID="Label1" Text="Subject" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="box">
                                                            <asp:TextBox ID="txttemplatesubject" CssClass="textboxnew" Width="200px" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div align="left">
                                                        <div id="lblPhraseText" class=" bglabel_new" style="width: 20.3%; height: 305px;">
                                                            <span id="SpnPhraseText" style="color: Black" runat="server">
                                                                <%=objLanguage.GetLanguageConversion("Email_Body") %></span>
                                                        </div>
                                                        <div class="box" style="width: 70%; border: 0px solid red">
                                                            <div id="divFckEditor" style="border: 0px solid; float: left">
                                                                <%--   Replaced instead of fckeditor with radeditor by ramakrishna on 30-08-2012--%>
                                                                <telerik:RadEditor ID="RadEditor1" runat="server" Width="700px" Height="300px" EditModes="Design,Html"
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
                                                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: auto;
                                                                    padding-left: 4px; padding-right: 4px; margin-left: 4px;">Max. length of textbox
                                                                    is: 3000</span><span id="spn_txtphrasetext" class="spanerrorMsg" style="display: none;
                                                                        width: auto; padding-left: 4px; padding-right: 4px; margin-left: 4px;">Please enter
                                                                        E-mail body</span>
                                                            </div>
                                                        </div>
                                                        <br />
                                                        <br />
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <asp:Label ID="lbl_emailSignature" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:DropDownList ID="ddlFooterSignature" CssClass="normalText" runat="server" Width="208px">
                                                                </asp:DropDownList>
                                                                <span id="spn_defaultddl" class="spanerrorMsg" style="display: none; width: auto;
                                                                    padding-left: 4px; padding-right: 4px; margin-left: 4px;">Please Select Footer Signature</span>
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="spn_defaultSignature" runat="server"></span>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:CheckBox ID="chkDefaultEmailBody" runat="server"></asp:CheckBox>
                                                            </div>
                                                        </div>

                                                         <div align="left">
                                                            <div class="bglabel" style="width: 20%; height:29px;">
                                                                <span id="spnCC" runat="server"></span>
                                                            </div>
                                                            <div class="box">
                                                                <%--<textarea class="txtbox" rows="2" cols="55" name="txtfirstname" id="txtfirstname"
                                        runat="server" onblur="javascript:return validateMultipleEmailsCommaSeparated(this,this.value,'spn_To',true)"></textarea><br />--%>
                                                             <textarea class="txtbox" id="TextAreaCC" name="TextAreaCC" rows="2" cols="55" runat="server" ></textarea>
<%--                                                            <asp:textarea ID="TextBox1" CssClass="textboxnew" Width="200px" runat="server"></asp:textarea>--%>
                                                             <br />
                                                    <span
                                                        id="spn_cc" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                        display: none"></span>
                                                            </div>
                                                        </div>

                                                         <div align="left">
                                                            <div class="bglabel" style="width: 20%;height:29px;">
                                                                <span id="spnBCC" runat="server"></span>
                                                            </div>
                                                             <div class="box">
                                                                
<%--                                                                 <textarea ID="TextAreaBCC" runat="server" style="Width:200px;" TextMode="MultiLine" SkinID="textPad"></textarea>--%>
                                                                 <textarea class="txtbox" id="TextAreaBCC" name="TextAreaBCC" rows="2" cols="55" runat="server" ></textarea>

                                                                 <br />
                                                    <span
                                                        id="spn_bcc" class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                        display: none"></span>

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
                                                        <asp:Button ID="btnSave" CssClass="buttoncustomtxt" runat="server" Text="Save" OnClick="btnSave_OnClick"
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
                                                <div id="divestimate" style="display: none">
                                                    <span class="HeaderText">Custom Tags for Estimate</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.
                                                    </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheader" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
                                                                    &nbsp;Description
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
                                                                                    <input type='text' name="EstimateTitle" size="30" value='[$EstimateTitle$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Title
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
                                                                                    <input type='text' name="EstimateNumber" size="30" value='[$EstimateNumber$]' readonly="readonly" onclick="this.select();" />
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
                                                                                    <input type='text' name="CustomerContactFirstName" size="30" value='[$CustomerContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;First Name of Customer's Contact
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
                                                                                    <input type='text' name="CustomerContactLastName" size="30" value='[$CustomerContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Last Name of Customer's Contact
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
                                                                                    <input type='text' name="CustomerContactFullName" size="30" value='[$CustomerContactFullName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Full Name of Customer's Contact
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
                                                                                    <input type='text' name="CustomerContactEmail" size="30" value='[$CustomerContactEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Customer's Contact
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
                                                                                    <input type='text' name="CustomerName" size="30" value='[$CustomerName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Name
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
                                                                                    <input type='text' name="EstimateDate" size="30" value='[$EstimateDate$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Date
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
                                                                                    <input type='text' name="EstimatedArtwork" size="30" value='[$EstimatedArtwork$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Artwork
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
                                                                                    <input type='text' name="EstimatedDelivery" size="30" value='[$EstimatedDelivery$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Delivery
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
                                                                                    <input type='text' name="ValidFor" size="30" value='[$ValidFor$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Days Estimate is valid for
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
                                                                                    <input type='text' name="SalesPerson" size="30" value='[$SalesPerson$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Sales Person
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
                                                                                    <input type='text' name="SalesPersonEmail" size="30" value='[$SalesPersonEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Sales Person
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
                                                                                    <input type='text' name="EstimateHeader" size="30" value='[$EstimateHeader$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Header
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
                                                                                    <input type='text' name="EstimateFooter" size="30" value='[$EstimateFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Footer
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
                                                                                    <input type='text' name="EstimateValue" size="30" value='[$EstimateValue$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Value
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
                                                                                    <input type='text' name="PDFPath" size="30" value='[$PDFPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of the PDF File
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
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$EmailFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The name of the person who is logged in
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--Added by chethan TNo.13428-->
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="AttachmentsPath" size="30" value='[$AttachmentsPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of Attachments
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--End-->
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="divSupplierRFQ" >
                                                    <span class="HeaderText">Proof Return </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheaderSup" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
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
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerComments" size="30" value='[$CustomerComments$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Comments
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
                                                                                    <input type='text' name="FileStatus" size="30" value='[$FileStatus$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;File Status
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

                                                                               <tr class="NewTableRows" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactFirstName" size="30" value='[$CustomerContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Contact First Name
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
                                                                                    <input type='text' name="CustomerContactLastName" size="30" value='[$CustomerContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Contact Last Name
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
                                                                                    <input type='text' name="SalesPerson" size="30" value='[$SalesPerson$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Sales Person
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
                                                                                    <input type='text' name="EstimatorPerson" size="30" value='[$EstimatorPerson$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimator Person
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>


                                                                            <tr class="NewTableRows" valign="middle">
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="custometd" nowrap="nowrap">
                                                                                    <input type='text' name="Estimator" size="30" value='[$EstimatorEmail$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="custometdflow">
                                                                                    &nbsp;Estimator Email Address
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
                                                                                    <input type='text' name="SalesPerson" size="30" value='[$SalesPersonEmail$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="custometdflow">
                                                                                    &nbsp;Sales Person Email Address
                                                                                </td>
                                                                                <td class="custometd1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--End-->
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="divJOb" style="display: none">
                                                    <%--<span class="smallgraytext">
                                                You can use the below tags to dynamically replace the values. More tags coming soon <br />
                                                1.[$EstimateNumber$] - Estimate Number  <br />
                                                2.[$JobNumber$] - Job Number <br />
                                                3.[$JobTitle$] - Job Title <br />
                                                4.[$CustomerContactFirstName$] - First Name of Customer's Contact <br />
                                                5.[$CustomerContactLastName$] - Last Name of Customer's Contact <br />
                                                6.[$CustomerContactFullName$] - Full Name of Customer's Contact <br />
                                                7.[$CustomerContactEmail$] - Email of Customer's Contact <br />
                                                8.[$CustomerName$] - Customer Name <br />
                                                9.[$JobDate$] - Job Date <br />
                                                10.[$JobDelivery$] - Job Delivery <br />
                                                11.[$JobCompletionDate$] - Job Completion Date <br />
                                                12.[$JobOrderNumber$] - Job Order Number<br />
                                                13.[$SalesPerson$] <br />
                                                14.[$SalesPersonEmail$] - Email of Sales Person<br />
                                                15.[$JobHeader$] - Job Header<br />
                                                16.[$JobFooter$] - Job Footer<br />
                                                17.[$JobValue$] - Job Value<br />
                                            </span>--%>
                                                    <span class="HeaderText">Custom Tags for Job</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.
                                                    </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheaderJob" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
                                                                    &nbsp;Description
                                                                </td>
                                                                <td class="bgcustomize" align="right" valign="top" width="1%">
                                                                    <img src="../images/rt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" width="100%">
                                                                    <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="EstimateNumber" size="30" value='[$EstimateNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobNumber" size="30" value='[$JobNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobTitle" size="30" value='[$JobTitle$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Title
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactFirstName" size="30" value='[$CustomerContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;First Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactLastName" size="30" value='[$CustomerContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Last Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactFullName" size="30" value='[$CustomerContactFullName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Full Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactEmail" size="30" value='[$CustomerContactEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerName" size="30" value='[$CustomerName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Name
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierName" size="30" value='[$SupplierName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Supplier Name
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierFirstName" size="30" value='[$SupplierContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;First Name of Supplier's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierMiddleName" size="30" value='[$SupplierContactMiddleName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Middle Name of Supplier's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierLastName" size="30" value='[$SupplierContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Last Name of Supplier's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierFullName" size="30" value='[$SupplierContactFullName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Full Name Supplier's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobDelivery" size="30" value='[$JobDelivery$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Delivery Date
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobCompletionDate" size="30" value='[$JobCompletionDate$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Completion Date
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobOrderNumber" size="30" value='[$JobOrderNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Order Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SalesPerson" size="30" value='[$SalesPerson$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Sales Person
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SalesPersonEmail" size="30" value='[$SalesPersonEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Sales Person
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobHeader" size="30" value='[$JobHeader$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Header
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobFooter" size="30" value='[$JobFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Footer
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="JobValue" size="30" value='[$JobValue$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Value
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PDFPath" size="30" value='[$PDFPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of the PDF File
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$EmailFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The name of the person who is logged in
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$ConsigneeURL$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Note Consignee URL
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$Consignment Note Number$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Note Consignment Note Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--Added by chethan for TNo.13428-->
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="AttachmentsPath" size="30" value='[$AttachmentsPath$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of Attachments
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--End-->
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="divInvoice" style="display: none">
                                                    <span class="HeaderText">Custom Tags for Invoice</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.
                                                    </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheaderInv" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
                                                                    &nbsp;Description
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" align="right" valign="top" width="1%" style="border-top-right-radius: 5px;">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" width="100%">
                                                                    <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="InvoiceTitle" size="30" value='[$InvoiceTitle$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Title
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
                                                                                    <input type='text' name="EstimateNumber" size="30" value='[$EstimateNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Estimate Number
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
                                                                                    <input type='text' name="JobNumber" size="30" value='[$JobNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Job Number
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
                                                                                    <input type='text' name="InvoiceNumber" size="30" value='[$InvoiceNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Number
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
                                                                                    <input type='text' name="CustomerContactFirstName" size="30" value='[$CustomerContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;First Name of Customer's Contact
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
                                                                                    <input type='text' name="CustomerContactLastName" size="30" value='[$CustomerContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Last Name of Customer's Contact
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
                                                                                    <input type='text' name="CustomerContactFullName" size="30" value='[$CustomerContactFullName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Full Name of Customer's Contact
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
                                                                                    <input type='text' name="CustomerContactEmail" size="30" value='[$CustomerContactEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Customer's Contact
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
                                                                                    <input type='text' name="InvoiceDate" size="30" value='[$InvoiceDate$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Date
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
                                                                                    <input type='text' name="InvoiceOrderNumber" size="30" value='[$InvoiceOrderNumber$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Order Number
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
                                                                                    <input type='text' name="SalesPerson" size="30" value='[$SalesPerson$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp; Sales Person
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
                                                                                    <input type='text' name="SalesPersonEmail" size="30" value='[$SalesPersonEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Sales Person
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
                                                                                    <input type='text' name="InvoiceHeader" size="30" value='[$InvoiceHeader$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Header
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
                                                                                    <input type='text' name="InvoiceFooter" size="30" value='[$InvoiceFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Footer
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
                                                                                    <input type='text' name="InvoiceValue" size="30" value='[$InvoiceValue$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Value
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
                                                                                    <input type='text' name="PDFPath" size="30" value='[$PDFPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of the PDF File
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
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$EmailFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The name of the person who is logged in
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
                                                                                    <input type='text' name="InvoiceAmountPaid" size="30" value='[$InvoiceAmountPaid$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Amount Paid
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
                                                                                    <input type='text' name="InvoiceAmountOutstanding" size="30" value='[$InvoiceAmountOutstanding$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Amount Outstanding
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
                                                                                    <input type='text' name="InvoiceDueDate" size="30" value='[$InvoiceDueDate$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Invoice Due Date
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--Added by chethan for TNo.13428-->
                                                                            <tr class="NewAlternative" valign="middle">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="AttachmentsPath" size="30" value='[$AttachmentsPath$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of Attachments
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--End-->
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="divPurchase" style="display: none">
                                                    <span class="HeaderText">Custom Tags for Purchase</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.
                                                    </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheaderPur" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
                                                                    &nbsp;Description
                                                                </td>
                                                                <td class="bgcustomize" align="right" valign="top" width="1%">
                                                                    <img src="../images/rt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" width="100%">
                                                                    <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PONumber" size="30" value='[$PurchaseTitle$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Purchase Title
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PONumber" size="30" value='[$PONumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Purchase Order Number
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="RefNo" size="30" value='[$RefNo$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierName" size="30" value='[$SupplierName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Supplier Name
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierContactFirstName" size="30" value='[$SupplierContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;First Name of Supplier's Contact
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierContactLastName" size="30" value='[$SupplierContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Last Name of Supplier's Contact
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierContactFullName" size="30" value='[$SupplierContactFullName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Full Name of Supplier's Contact
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierContactEmail" size="30" value='[$SupplierContactEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Supplier's Contact
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PurchaseHeader" size="30" value='[$PurchaseHeader$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Purchase Header
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PurchaseFooter" size="30" value='[$PurchaseFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Purchase Footer
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="RequiredDate" size="30" value='[$RequiredDate$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="RaisedBy" size="30" value='[$RaisedBy$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PriceIncTax" size="30" value='[$PriceIncTax$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Price Including Tax
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PriceExTax" size="30" value='[$PriceExTax$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Price Excluding Tax
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="Quantity" size="30" value='[$Quantity$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Quantity
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="POComments" size="30" value='[$POComments$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PDFPath" size="30" value='[$PDFPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of the PDF File
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$EmailFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The name of the person who is logged in
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td nowrap="nowrap" class="setting_emailbodywidth30">
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$JobTitle$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="setting_emailbodytd">
                                                                                    &nbsp;Job Title
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SupplierQuoteNumber" size="30" value='[$SupplierQuoteNumber$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Supplier QuoteNumber
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                              <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td nowrap="nowrap" class="setting_emailbodywidth30">
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$JobOrderTitle$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="setting_emailbodytd">
                                                                                    &nbsp;Job Order Title
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--Added by chethan for TNo.13428-->
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td nowrap="nowrap" class="setting_emailbodywidth30">
                                                                                    <input type='text' name="AttachmentsPath" size="30" value='[$AttachmentsPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td class="setting_emailbodytd">
                                                                                    &nbsp;The Path of Attachments
                                                                                </td>
                                                                                <td class="setting_emailbodywidht1">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--End-->
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="divDeliveryNote" style="display: none">
                                                    <span class="HeaderText">Custom Tags for Delivery Note</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.
                                                    </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="trheaderDeli" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
                                                                    &nbsp;Description
                                                                </td>
                                                                <td class="bgcustomize" align="right" valign="top" width="1%">
                                                                    <img src="../images/rt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" width="100%">
                                                                    <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactFirstName" size="30" value='[$CustomerContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;First Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactLastName" size="30" value='[$CustomerContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Last Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactFullName" size="30" value='[$CustomerContactFullName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Full Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactEmail" size="30" value='[$CustomerContactEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerName" size="30" value='[$CustomerName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Name
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="DeliveryHeader" size="30" value='[$DeliveryHeader$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Header
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="DeliveryFooter" size="30" value='[$DeliveryFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Footer
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="DeliveryNumber" size="30" value='[$DeliveryNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="RefNo" size="30" value='[$RefNo$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="OrderNumber" size="30" value='[$OrderNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp; Order Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CarrierName" size="30" value='[$CarrierName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Carrier Name
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="DeliveryDate" size="30" value='[$DeliveryDate$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Date
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ShippedTo" size="30" value='[$ShippedTo$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Shipped To
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PDFPath" size="30" value='[$PDFPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of the PDF File
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="EmailFooter" size="30" value='[$EmailFooter$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The name of the person who is logged in
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--Added by chethan for TNo.13428-->
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="AttachmentsPath" size="30" value='[$AttachmentsPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of Attachments
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ConsigneeURL" size="30" value='[$ConsigneeURL$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Note Consignee URL
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="ConsignmentNoteNumber" size="30" value='[$Consignment Note Number$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp; Delivery Note Consignment Note Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--End-->
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                                <div id="divWebOrder" style="display: none">
                                                    <span class="HeaderText">Custom Tags for Web Order</span>
                                                    <div class="only5px">
                                                    </div>
                                                    <span class="normalText">You can use the below tags to dynamically replace the values.
                                                    </span>
                                                    <div class="only5px">
                                                    </div>
                                                    <table class="tablerowcolor2" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr valign="top" height="23" id="tr2" runat="server">
                                                                <td class="bgcustomize" align="left" valign="top" width="1%">
                                                                    <img src="../images/lt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="30%">
                                                                    &nbsp;Tag Name
                                                                </td>
                                                                <td class="bgcustomize navigatorpanel" width="60%">
                                                                    &nbsp;Description
                                                                </td>
                                                                <td class="bgcustomize" align="right" valign="top" width="1%">
                                                                    <img src="../images/rt_tabnotch.gif" width="5" height="5/">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" width="100%">
                                                                    <table class="borderWithoutTop" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="OrderNumber" size="30" value='[$OrderNumber$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Order Number
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactFirstName" size="30" value='[$CustomerContactFirstName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;First Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactLastName" size="30" value='[$CustomerContactLastName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Last Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactFullName" size="30" value='[$CustomerContactFullName$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Full Name of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerContactEmail" size="30" value='[$CustomerContactEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Customer's Contact
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="CustomerName" size="30" value='[$CustomerName$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Customer Name
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="OrderDate" size="30" value='[$OrderDate$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Order Date
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="DeliveryDate" size="30" value='[$DeliveryDate$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Delivery Date
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SalesPerson" size="30" value='[$SalesPerson$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Sales Person
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="SalesPersonEmail" size="30" value='[$SalesPersonEmail$]'
                                                                                        readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Email of Sales Person
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewAlternative" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="OrderValue" size="30" value='[$OrderValue$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;Order Value
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="PDFPath" size="30" value='[$PDFPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of the PDF file
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--Added by chethan for TNo.13428-->
                                                                            <tr class="NewTableRows" valign="top">
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="30%" nowrap="nowrap">
                                                                                    <input type='text' name="AttachmentsPath" size="30" value='[$AttachmentsPath$]' readonly="readonly" onclick="this.select();" />
                                                                                </td>
                                                                                <td style="overflow: hidden;" width="60%">
                                                                                    &nbsp;The Path of Attachments
                                                                                </td>
                                                                                <td width="1%">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <!--End-->
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
                                                <%--End Web Order--%>
                                            </div>
                                            <div class="only5px">
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
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
    </div>
    <asp:HiddenField ID="hdnaction" runat="server" Value="" />
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            Loading...</div>
    </div>
    <script type="text/javascript">
        var EmailSettingType = '<%=EmailSettingType %>';
        var serverName = '<%=serverName%>';


        function displayAddNew() {
            document.getElementById('tdaddnew').style.display = 'block';
            document.getElementById("<%=txtemailtempname.ClientID %>").focus();
        }
        function pageScroll() {
            window.scrollBy(0, 600); // horizontal and vertical scroll increments
        }

        function addnew1(type) {
            debugger;
            document.getElementById('div_Load').style.display = 'block';
            pageScroll();
            setTimeout("displayAddNew()", 3000);
            setTimeout("desableAfterLoad()", 4000);
            document.getElementById("<%=hdnaction.ClientID %>").value = "";
            var txtemailtempname = document.getElementById("<%=txtemailtempname.ClientID %>");
          <%--  var ddlSpecificType = document.getElementById("<%=ddlSpecificType.ClientID %>");
            var ddlEmailTemplateType = document.getElementById("<%=ddlEmailTemplateType.ClientID %>");--%>
            var ddlFooterSignature = document.getElementById("<%=ddlFooterSignature.ClientID %>");

            var Radeditor = document.getElementById("<%=RadEditor1.ClientID %>");
            var chkDefaultEmailBody = document.getElementById("<%=chkDefaultEmailBody.ClientID %>");
            txtemailtempname.focus();
            //SelectTemplateType();

            if (type == 'add') {
                txtemailtempname.value = "";
                ddlSpecificType.selectedIndex = "0";
                //ddlEmailTemplateType.selectedIndex = "0";
                ddlFooterSignature.selectedIndex = "0";
                chkDefaultEmailBody.checked = false;
                document.getElementById("<%=txttemplatesubject.ClientID %>").value = "";
                document.getElementById("<%=hdnaction.ClientID %>").value = "add";
                changefck("");

            }
            else {
                document.getElementById("<%=hdnaction.ClientID %>").value = "edit";
                return false;
            }

        }
        function changefck(value) {
            var chkDefaultEmailBody = document.getElementById("<%=chkDefaultEmailBody.ClientID %>");

            var Radeditor = FCKeditorAPI.GetInstance('<%=RadEditor1.ClientID%>');
            chkDefaultEmailBody.Checked = false;
            Radeditor.SetHTML(value);
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
        function hidetype() {
            estimate('block');
            job('none');
            invoice('none');
            purchase('none');
            printbroker('none');
            delivery('none');
        }


        function Validate() {
            var checkwhat = true;
            var txtphrasetext = document.getElementById("<%=RadEditor1.ClientID %>");
            var txtemailtempname = document.getElementById("<%=txtemailtempname.ClientID %>");
           <%-- var ddlEmailTemplateType = document.getElementById("<%=ddlEmailTemplateType.ClientID %>");--%>
           <%-- var ddlEmailFooterSignature = document.getElementById("<%=ddlFooterSignature.ClientID %>");--%>
            document.getElementById("spn_txtphrasetext").style.display = "none";
            document.getElementById("spn_ddlEmailTemplateType").style.display = "none";
            document.getElementById("spn_txtemailtempname").style.display = "none";
            document.getElementById("spn_defaultddl").style.display = "none";

            if (CheckStringMandatory(txtemailtempname.value, 'spn_txtemailtempname')) {
                checkwhat = false;
            }
            //if (CallonChange(ddlEmailTemplateType.value, 'spn_ddlEmailTemplateType')) {
            //    checkwhat = false;
            //}

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
            debugger
           <%-- var ddlEmailTemplateType = document.getElementById("<%=ddlEmailTemplateType.ClientID %>");--%>
            var hdnemailid = document.getElementById("<%=hdnaction.ClientID %>");
            if (ddlEmailTemplateType.selectedIndex != 0) {
                if (ddlEmailTemplateType.selectedIndex == 1) {
                    document.getElementById("divestimate").style.display = 'block';
                    document.getElementById("divSupplierRFQ").style.display = 'none';
                    document.getElementById("divJOb").style.display = 'none';
                    document.getElementById("divInvoice").style.display = 'none';
                    document.getElementById("divPurchase").style.display = 'none';
                    document.getElementById("divDeliveryNote").style.display = 'none';
                    document.getElementById("divWebOrder").style.display = 'none';

                    if (hdnemailid.value == "add") {
                        document.getElementById("<%=txttemplatesubject.ClientID %>").value = '[$EstimateTitle$]';
                    }
                }
                else if (ddlEmailTemplateType.selectedIndex == 2) {
                    document.getElementById("divestimate").style.display = 'none';
                    document.getElementById("divSupplierRFQ").style.display = 'block';
                    document.getElementById("divJOb").style.display = 'none';
                    document.getElementById("divInvoice").style.display = 'none';
                    document.getElementById("divPurchase").style.display = 'none';
                    document.getElementById("divDeliveryNote").style.display = 'none';
                    document.getElementById("divWebOrder").style.display = 'none';
                    if (hdnemailid.value == "add") {
                        document.getElementById("<%=txttemplatesubject.ClientID %>").value = '[$EstimateTitle$]';
                    }
                }
                else if (ddlEmailTemplateType.selectedIndex == 3) {
                    document.getElementById("divestimate").style.display = 'none';
                    document.getElementById("divSupplierRFQ").style.display = 'none';
                    document.getElementById("divJOb").style.display = 'block';
                    document.getElementById("divInvoice").style.display = 'none';
                    document.getElementById("divPurchase").style.display = 'none';
                    document.getElementById("divDeliveryNote").style.display = 'none';
                    document.getElementById("divWebOrder").style.display = 'none';
                    if (hdnemailid.value == "add") {
                        document.getElementById("<%=txttemplatesubject.ClientID %>").value = '[$JobTitle$]';
                    }
                }
                else if (ddlEmailTemplateType.selectedIndex == 4) {
                    document.getElementById("divestimate").style.display = 'none';
                    document.getElementById("divSupplierRFQ").style.display = 'none';
                    document.getElementById("divJOb").style.display = 'none';
                    document.getElementById("divInvoice").style.display = 'block';
                    document.getElementById("divPurchase").style.display = 'none';
                    document.getElementById("divDeliveryNote").style.display = 'none';
                    document.getElementById("divWebOrder").style.display = 'none';
                    if (hdnemailid.value == "add") {
                        document.getElementById("<%=txttemplatesubject.ClientID %>").value = '[$InvoiceTitle$]';
                    }
                }
                else if (ddlEmailTemplateType.selectedIndex == 5) {
                    document.getElementById("divestimate").style.display = 'none';
                    document.getElementById("divSupplierRFQ").style.display = 'none';
                    document.getElementById("divJOb").style.display = 'none';
                    document.getElementById("divInvoice").style.display = 'none';
                    document.getElementById("divPurchase").style.display = 'block';
                    document.getElementById("divDeliveryNote").style.display = 'none';
                    document.getElementById("divWebOrder").style.display = 'none';
                    if (hdnemailid.value == "add") {
                        document.getElementById("<%=txttemplatesubject.ClientID %>").value = '[$PurchaseTitle$]';
                    }
                }
                else if (ddlEmailTemplateType.selectedIndex == 6) {
                    document.getElementById("divestimate").style.display = 'none';
                    document.getElementById("divSupplierRFQ").style.display = 'none';
                    document.getElementById("divJOb").style.display = 'none';
                    document.getElementById("divInvoice").style.display = 'none';
                    document.getElementById("divPurchase").style.display = 'none';
                    document.getElementById("divDeliveryNote").style.display = 'block';
                    document.getElementById("divWebOrder").style.display = 'none';
                    if (hdnemailid.value == "add") {
                        document.getElementById("<%=txttemplatesubject.ClientID %>").value = '[$DeliveryNumber$]';
                    }
                }

                else if (ddlEmailTemplateType.selectedIndex == 7) {
                    document.getElementById("divestimate").style.display = 'none';
                    document.getElementById("divSupplierRFQ").style.display = 'none';
                    document.getElementById("divJOb").style.display = 'none';
                    document.getElementById("divInvoice").style.display = 'none';
                    document.getElementById("divPurchase").style.display = 'none';
                    document.getElementById("divDeliveryNote").style.display = 'none';
                    document.getElementById("divWebOrder").style.display = 'block';
                    if (hdnemailid.value == "add") {
                        document.getElementById("<%=txttemplatesubject.ClientID %>").value = '[$OrderNumber$]';
                    }

                }
}
else {
    document.getElementById("divestimate").style.display = 'none';
    document.getElementById("divSupplierRFQ").style.display = 'none';
    document.getElementById("divJOb").style.display = 'none';
    document.getElementById("divInvoice").style.display = 'none';
    document.getElementById("divPurchase").style.display = 'none';
    document.getElementById("divDeliveryNote").style.display = 'none';
}
}

        function SetBCCAndCCValues(cc, bcc) {
            debugger;
            var textAreaBCC = document.getElementById("<%=TextAreaBCC.ClientID %>");
            var textAreaCC = document.getElementById("<%=TextAreaCC.ClientID %>");
            textAreaBCC.innerText = bcc;
            textAreaCC.innerText = cc;
        }
        function validateEmail(field) {
            // var regex = /\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b/i;                                                   
            //var regex = /^(([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?), ?)*^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            //var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            var regex = /^([a-zA-Z0-9_\.\-\'])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            return (regex.test(field)) ? true : false;
        }
        function validateMultipleEmailsCommaSeparated(value, spnid) {
            document.getElementById(spnid).style.display = "none";
            if (value == '') {
                if (spnid == 'spn_To') {
                    document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Email_Address") %>';
                                                            document.getElementById(spnid).style.display = "block";
                                                            return false;
                                                        }
                                                        else {
                                                            return true;
                                                        }
                                                    }
                                                    else {
                                                        var result = value.split(",");
                                                        var chkvalidate = 'false';
                                                        for (var i = 0; i < result.length; i++) {
                                                            var email = result[i].trim().replace(',', '');
                                                            if (!validateEmail(email)) {
                        document.getElementById(spnid).innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Email_Address") %>';
                        document.getElementById(spnid).style.display = "block";
                        chkvalidate = 'false';
                    }
                    else {
                        chkvalidate = 'true';
                    }
                }
                if (chkvalidate == 'false') {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    </script>
    <script>


        function CheckOne_copy() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            //***Bug ID :653, on 08.11.2011, by Natraj
            if (Number(Counter) > 1) {
                alert("Please check only one row to copy");
                return false;
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
    <script type="text/javascript">
        function OnClientLoad(editor) {
            setTimeout(function () {
                var tool = editor.getToolByName("RealFontSize");
                tool.set_value("14px");
                var tool = editor.getToolByName("FontName");
                tool.set_value("Arial");
            }, 0);
        }

    </script>
<%--    <script type="text/javascript">
        function OnClientLoad(editor, args) {
            var editorIframe = $get(editor.get_id() + "Wrapper").getElementsByTagName("iframe")[0];
            editorIframe.style.height = "100%";
            var divMinHeight = document.getElementById("ctl00_ContentPlaceHolder1_RadEdit_contentIframe");
            divMinHeight.style.minHeight = "154px";
        }
     </script>--%>
</asp:Content>


