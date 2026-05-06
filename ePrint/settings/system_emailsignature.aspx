<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.master" AutoEventWireup="true" Trace="false" EnableEventValidation="false" WarningLevel="0" CodeBehind="system_emailsignature.aspx.cs" Inherits="ePrint.settings.system_emailsignature" EnableViewStateMac="false" Theme="Theme1" %>

<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register Src="~/usercontrol/settings/PhraseBookMenu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/animation.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <style type="text/css">
        .reContentArea {
            font-family: Arial !important;
            font-size: 14px !important;
        }

            .reContentArea table td {
                font-size: 14px !important;
            }

        .Default.RadEditor .reContentCell {
            border: 1px solid #DADADA;
        }

        .RadGrid_Default .rgCommandRow {
            background: none;
        }

            .RadGrid_Default .rgCommandRow a {
                color: #10357F;
                text-decoration: underline;
                margin-left: -10px;
                margin-top: -10px;
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
            margin-top: -2px;
        }
    </style>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtemailSignatureTitle" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadEditor1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="chkDefaultFooter" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
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
                                    <asp:Label runat="server" ID="lblheader"><%=objLanguage.GetLanguageConversion("Settings_Phrase_Book_Email_Signature")%></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div class="estore_settingBox">
                <UC:Header_MIS ID="header_mis" runat="server" />
                <div align="left" style="width: 100%;" class="mis_header_panel">
                    <div id="">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td valign="top" style="width: 220px;">
                                    <UCMenue:PhraseMenue ID="PraseMenue" runat="server" />
                                </td>
                                <td valign="top">
                                    <div id="div_popupAction" style="margin: 47px 0px 0px 8px;" onmouseover="show();"
                                        onmouseout="hide(); ">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                            <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" OnClick="lnkDelete_onclick"
                                                                CommandName="Delete" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px"
                                                                OnClientClick="javascript:return CallDelete();" CausesValidation="false" Visible="false"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="div_Grid" style="width: 1000px;">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <telerik:RadGrid Width="50%" ID="RadGrid1" GridLines="None" runat="server" AllowAutomaticDeletes="True"
                                                    BorderWidth="0" ShowStatusBar="true" AllowAutomaticInserts="True" PageSize="50"
                                                    AllowAutomaticUpdates="True" HeaderStyle-Font-Bold="true" OnItemDataBound="grdPraseBookEmailSignature_OnRowDataBound"
                                                    AllowPaging="True" PagerStyle-AlwaysVisible="true" AutoGenerateColumns="False"
                                                    OnPageIndexChanged="grdPraseBookEmailSignature_PageIndexChanged" OnPageSizeChanged="grdPraseBookEmailSignature_PageSizeChanged">
                                                    <MasterTableView CommandItemDisplay="Top" Width="100%" DataKeyNames="EmailFooterID"
                                                        HorizontalAlign="NotSet" AutoGenerateColumns="False">
                                                        <CommandItemTemplate>
                                                            <table class="rgCommandTable" border="0" style="width: 100%; margin-top: -6px">
                                                                <td align="left">
                                                                    <a href="#" onclick="javascript:return addnew('add')">
                                                                        <%=objLanguage.GetLanguageConversion("Add_New_Record") %></a>
                                                                </td>
                                                                </tr>
                                                            </table>
                                                        </CommandItemTemplate>
                                                        <Columns>
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                                AllowFiltering="false" HeaderStyle-Width="20px" ItemStyle-Width="20px" HeaderStyle-Wrap="false">
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
                                                                                            <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                                onclick="show();" alt='' />
                                                                                            <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                                onclick="hide();" alt='' />
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style="padding-left: 4px;">
                                                                        <input type="checkbox" runat="server" id="chkEmailFooterId1" onclick="CheckChanged();"
                                                                            name="Id" value='<%#Eval("EmailFooterID")%>' />
                                                                    </div>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn SortExpression="FooterTitle" HeaderText="" UniqueName="EmailFooterID"
                                                                Visible="true" HeaderStyle-HorizontalAlign="Left">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkFooterTitle" CommandArgument='<%#Eval("EmailFooterID")%>'
                                                                        Width="99%" runat="server" OnClick="lnkFooterTitle_onclick" Text='<%#Eval("FooterTitle")%>'></asp:LinkButton>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn SortExpression="Isdefault" HeaderText="" UniqueName="Isdefault"
                                                                DataType="System.Boolean" DefaultInsertValue="False" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:Label ID="lblIsdefault" runat="server"></asp:Label>
                                                                        <asp:HiddenField ID="hdnDefaultSig" Value='<%#Eval("Isdefault")%>' runat="server" />
                                                                    </center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"
                                                                HeaderStyle-Wrap="false">
                                                                <HeaderTemplate>
                                                                    <center>
                                                                        <input type="checkbox" id="checkAll" style="display: none;" onclick="CheckAll(this); changebgColor(this);"
                                                                            runat="server" name="checkAll" /></center>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <input type="checkbox" runat="server" style="display: none" id="chkEmailFooterId"
                                                                            onclick="CheckChanged();" name="Id" value='<%#Eval("EmailFooterID")%>' />
                                                                        <asp:HiddenField ID="hdnEmailFooterID" Value='<%#Eval("EmailFooterID")%>' runat="server" />
                                                                    </center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="" HeaderStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <center>
                                                                        <asp:LinkButton ID="lnkFooterTitle1" CommandArgument='<%#Eval("EmailFooterID")%>'
                                                                            runat="server" OnClick="lnkFooterTitle_onclick"></center>
                                                                    </asp:LinkButton>
                                                                    <center>
                                                                        <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                            CommandArgument='<%#Eval("EmailFooterID")%>' Text="Delete" UniqueName="DeleteColumn"
                                                                            runat="server" OnCommand="lnkDelete_onclick" ToolTip="Delete" OnClientClick="javascript:return ImgButtonErase_ClientClick('ctl00_ContentPlaceHolder1_RadGrid1',this.id)"></asp:ImageButton></center>
                                                                </ItemTemplate>
                                                            </telerik:GridTemplateColumn>
                                                        </Columns>
                                                    </MasterTableView>
                                                    <ClientSettings EnableRowHoverStyle="true">
                                                        <ClientEvents />
                                                    </ClientSettings>
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
                                        <div align="left">
                                        </div>
                                        <div id="tdaddnew" align="left" style="width: 100%; display: none;">
                                            <asp:UpdatePanel ID="UpdatePaneleditrecord" runat="server" UpdateMode="Conditional"
                                                ChildrenAsTriggers="false">
                                                <ContentTemplate>
                                                    <div id="tdemailaddnew" align="left" style="width: 100%;">
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="spnTempName" runat="server"></span><span style="color: Red; padding-left: 4px">*</span>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:TextBox runat="server" ID="txtemailSignatureTitle" SkinID="textPad" Width="200px"
                                                                    TextMode="singleline" MaxLength="255">
                                                                </asp:TextBox><asp:Label ID="lblEmailFooterID" runat="server" Style="display: none"></asp:Label>
                                                                <span id="spn_txtemailSignatureTitle" class="spanerrorMsg" style="display: none; width: auto; padding-left: 4px; padding-right: 4px;">Please enter Title</span>
                                                            </div>
                                                        </div>
                                                        <div class="onlyEmpty">
                                                        </div>
                                                    </div>
                                                    <div align="left">
                                                        <div id="lblPhraseText" class="bglabel_new" style="width: 20.2%; height: 310px">
                                                            <span id="SpnPhraseText" runat="server"></span>
                                                        </div>
                                                        <div class="box" style="width: 70%; border: 0px solid red">
                                                            <div id="divFckEditor" style="float: left; border: 0px solid;">
                                                                <telerik:RadEditor ID="RadEditor1" runat="server" Width="100%" Height="300px" EditModes="Design,Html"
                                                                    ToolsFile="~/RadEditorDialogs/Tools/tools.xml" ExternalDialogsPath="~/RadEditorDialogs" 
                                                                    ImageManager-ViewMode="Grid" ContentAreaMode="Iframe" OnClientLoad="OnClientLoad">
                                                                    <ImageManager ViewPaths="~/images" UploadPaths="~/images" DeletePaths="~/images"></ImageManager>
                                                                    <FlashManager ViewPaths="~/images" UploadPaths="~/images" />
                                                                    
                                                                    <FontNames>
                                                                        <telerik:EditorFont Value="Roboto" />
                                                                          <telerik:EditorFont Value="Roboto Black" />
                                                                        <telerik:EditorFont Value="Roboto Light" />
                                                                        <telerik:EditorFont Value="Roboto Thin" />
                                                                        <telerik:EditorFont Value="Roboto Medium" />
                                                                        <telerik:EditorFont Value="Merriweather"  />
                                                                        <telerik:EditorFont Value="Merriweather Light"  />
                                                                    </FontNames>
                                                                </telerik:RadEditor>
                                                                <div class="only5px">
                                                                </div>
                                                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: 185px;">Max. length of textbox is: 3000</span> <span id="spn_txtphrasetext" class="spanerrorMsg"
                                                                    style="display: none; width: 185px;">Please enter Footer Signature</span>
                                                            </div>
                                                        </div>
                                                        <div align="left">
                                                            <div class="bglabel" style="width: 20%;">
                                                                <span id="spn_defaultSignature" runat="server"></span>
                                                            </div>
                                                            <div class="box" style="width: 60%">
                                                                <asp:CheckBox ID="chkDefaultFooter" runat="server"></asp:CheckBox>
                                                            </div>
                                                            <div align="left" style="width: 100%; float: left; padding-left: 21%;">
                                                                <%--  <div style="float: left;">
                                                                    <telerik:RadButton EnableEmbeddedSkins="false" Skin="rbDecorated1" CssClass="rbDecorated1"
                                                                        BorderColor="#A3A3A3" BorderWidth="1" BorderStyle="Solid" ID="btnCancel" runat="server"
                                                                        Text="Cancel" CommandName="Cancel" CausesValidation="false">
                                                                    </telerik:RadButton>
                                                                </div>--%>
                                                                <div style="float: left;">
                                                                    <div id="div_btncancel" style="display: block">
                                                                        <asp:Button ID="btnCancel" CssClass="buttoncustomtxt" runat="server" Text="Cancel"
                                                                            CausesValidation="false" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');"
                                                                            OnClick="btnCancel_OnClick" />
                                                                    </div>
                                                                    <div id="div_cancelprocess" style="display: none">
                                                                        <img src="../images/radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                    </div>
                                                                </div>
                                                                <div style="float: left; width: 10px">
                                                                    &nbsp;
                                                                </div>
                                                                <%-- <div style="float: left;">
                                                                    <telerik:RadButton EnableEmbeddedSkins="false" Skin="rbDecorated1" CssClass="rbDecorated1"
                                                                        BorderColor="#A3A3A3" BorderWidth="1" BorderStyle="Solid" ID="btnSave" OnClick="btnSave_OnClick"
                                                                        runat="server" Text="Save" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>'>
                                                                    </telerik:RadButton>
                                                                </div>--%>
                                                                <div style="float: left;">
                                                                    <div id="div_btnSave" style="display: block">
                                                                        <asp:Button ID="btnSave" CssClass="buttoncustomtxt" runat="server" Text="Save" OnClick="btnSave_OnClick"
                                                                            OnClientClick="javascript:var a=Validate();if(a)loadingimage(this.id,'div_saveprocess');return a;" />
                                                                    </div>
                                                                    <div id="div_saveprocess" style="display: none">
                                                                        <img src="../images/radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdnFooterID" Value="" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript"
        language="javascript"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <asp:HiddenField ID="hdnmode" runat="server" Value="0" />
    <script type="text/javascript">

        var hidmode = document.getElementById("<%=hdnmode.ClientID %>");
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
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return window.confirm('Are you sure you want to delete this record(s)?');
            }
        }

        function addnew(val) {
            if (val == 'add') {
                hidmode.value = "add";

                document.getElementById("<%=txtemailSignatureTitle.ClientID %>").value = "";
                document.getElementById("<%=lblEmailFooterID.ClientID %>").value = "";
                document.getElementById("<%=chkDefaultFooter.ClientID %>").checked = false;

                var oEditor = $find("<%=RadEditor1.ClientID %>").set_html("");

            }
            if (val == 'edit') {
                hidmode.value = "edit";
            }
            document.getElementById('tdaddnew').style.display = 'block';
            document.getElementById("<%=txtemailSignatureTitle.ClientID %>").focus();
            return false;
        }



        function changebgColor(chkobj) {
            var gridid = document.getElementById("<%=RadGrid1.ClientID%>");
            changeGridColor(chkobj, gridid);
        }


    </script>
    <script type="text/javascript">
        function OnClientLoad(editor, args) {
            var editorIframe = $get(editor.get_id() + "Wrapper").getElementsByTagName("iframe")[0];
            editorIframe.style.height = "100%";
            var divMinHeight = document.getElementById("ctl00_ContentPlaceHolder1_RadEditor1_contentIframe");
            divMinHeight.style.minHeight = "154px";
        }
    </script>
    <script>

        function Validate() {
            var checkwhat = true;
            var FooterSignature = document.getElementById("<%=RadEditor1.ClientID %>");
            var txtemailSignatureTitle = document.getElementById("<%=txtemailSignatureTitle.ClientID %>");

            document.getElementById("spn_txtemailSignatureTitle").style.display = "none";
            document.getElementById("spn_txtphrasetext").style.display = "none";


            if (CheckStringMandatory(txtemailSignatureTitle.value, 'spn_txtemailSignatureTitle')) {
                checkwhat = false;
            }


            if (checkwhat) {
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
    </script>
    <script>        estimate('block');
        job('none');
        invoice('none');
        purchase('none');
        printbroker('none');
        delivery('none');
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

        <script type="text/javascript">
            Telerik.Web.UI.Editor.CommandList._completeEditorSelection = function(editor, extraFontAttribute) {
        if (!extraFontAttribute) extraFontAttribute = "";
                var contentWindow = editor.get_contentWindow();
                var editorDocument = editor.get_document();
                var parentElement = editor.getSelection().getParentElement();
                var parentTag = parentElement ? parentElement.tagName : "";
        if ($telerik.isIE && !editor.getSelectionHtml() && (parentTag == "FONT" || parentTag == "SPAN")) {
                editorDocument.execCommand("RemoveFormat", null, false);
            }
            var editorSelection = editor.getSelection();
        editorSelection.pasteHtml("<font " + extraFontAttribute + " id='radERealFont'>​</font>");
        var oFont = editor.get_document().getElementById("radERealFont");
        oFont.removeAttribute("id");

        if ($telerik.isIE) {
            editor.selectElement(oFont);
            editor.getSelection().collapse();
            oFont.innerHTML = "";
        }
        else if (contentWindow.getSelection) {
            var oSel = contentWindow.getSelection();
            var range = editor.getSelection().getRange();
            oSel.removeAllRanges();
            if (!$telerik.isSafari)
                oFont.innerHTML = "";

            range.selectNodeContents(oFont);

            if (!$telerik.isSafari)
                range.collapse(false);

            oSel.addRange(range);
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

