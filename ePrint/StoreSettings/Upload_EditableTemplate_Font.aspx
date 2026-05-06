<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true"  CodeBehind="Upload_EditableTemplate_Font.aspx.cs" Inherits="ePrint.StoreSettings.Upload_EditableTemplate_Font" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/StoreSettings/editabletemplate_menu.ascx" TagName="PhraseMenue"
    TagPrefix="UCMenue" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="AjaxUplodFont" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="grdFont">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdFont" LoadingPanelID="AjaxPanelFont" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDeleteStatus">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdFont" LoadingPanelID="AjaxPanelFont" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="AjaxPanelFont" runat="server" SkinID="Windows7">
    </telerik:RadAjaxLoadingPanel>
    <style>
        .RadGrid_Default .rgCommandRow {
            background: none;
        }

            .RadGrid_Default .rgCommandRow a {
                color: #10357F;
                text-decoration: none;
            }

        .RadGrid_Default .rgCommandCell {
            border: none;
        }

        .RadGrid_Default .rgHeader {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }

        .RadGrid_Default {
            outline: none;
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
    <div align="left">
        <div style="width: 100%; display: none;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label runat="server" ID="lblheader" Text="Test"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
    </div>
    <div class="estore_settingBox">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel">
            <div style="margin-top: -8px;">
                <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                    <ContentTemplate>
                        <div id="divmsg" runat="server">
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </div>
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
                                                        <asp:LinkButton ID="lnkDeleteStatus" runat="server" Text="Delete Selected" OnClick="btnDelete_OnClick"
                                                            CommandName="Delete" Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px"
                                                            OnClientClick="javascript:return CallDelete();" CausesValidation="false"></asp:LinkButton>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="div_Grid" style="width: 1000px">
                                    <telerik:RadGrid ID="grdFont" runat="server" GridLines="None" AutoGenerateColumns="false"
                                        BorderWidth="0" AllowPaging="true" PageSize="50" Width="70%" OnItemDataBound="grdFont_ItemDataBound"
                                        PagerStyle-AlwaysVisible="true" AllowFilteringByColumn="true" GroupingSettings-CaseSensitive="false">
                                        <MasterTableView CommandItemDisplay="Top">
                                            <CommandItemTemplate>
                                                <table class="rgCommandTable" border="0" style="width: 100%">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:LinkButton ID="btnAdd" Text="Add New Record" runat="server" OnClientClick="javascript:OpenPopup();"
                                                                Font-Underline="True" Style="margin-left: -10px"><%=objLanguage.GetLanguageConversion("Add_New_Record")%></asp:LinkButton>
                                                        </td>
                                                        <td align="right">
                                                            <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline; margin-right: -10px; cursor: pointer"
                                                                runat="server" Text=""><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </CommandItemTemplate>
                                            <Columns>
                                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                    AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false">
                                                    <HeaderTemplate>
                                                        <div style="float: left; display: none;">
                                                            <input id="Checkbox1" type="checkbox" runat="server" name="checkAll" onclick="CheckAll(this);" />
                                                        </div>
                                                        <div id="div_chk" style="width: inherit; height: inherit;">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <input id="checkAll" runat="server" name="checkAll" onclick="CheckAll(this);" type="checkbox" />
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
                                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                            value='<%# Bind("FontID") %>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="FontName" HeaderText="Font Name" HeaderStyle-Font-Bold="true"
                                                    AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="ActualFontFamilyName" HeaderText="Font Actual Name"
                                                    HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                                    CurrentFilterFunction="Contains">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Status" HeaderText="Status" HeaderStyle-Font-Bold="true"
                                                    HeaderStyle-Width="15%" ItemStyle-Width="15%" AllowFiltering="true" AutoPostBackOnFilter="true"
                                                    CurrentFilterFunction="Contains">
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="Action" HeaderStyle-HorizontalAlign="Center"
                                                    ItemStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" HeaderStyle-Width="5%"
                                                    ItemStyle-Width="5%" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <div style="float: none; padding: 0px 0px 0px 1px; display: block;">
                                                            <center>
                                                                <asp:ImageButton ID="ImageBtnDwnld" ImageUrl="~/Images/dwnld_font.png" Visible="false"
                                                                    CommandArgument='<%#Eval("FontID")%>' Text="Download" runat="server"></asp:ImageButton>
                                                                <asp:ImageButton ID="ImgButtonErase" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                    CommandArgument='<%#Eval("FontID")%>' Text="Delete" UniqueName="DeleteColumn"
                                                                    runat="server" OnCommand="lnkDelete_onclick"></asp:ImageButton></center>
                                                            <asp:HiddenField ID="hdn_IsUsedFont" runat="server" Value='<%#Eval("IsUsed")%>' />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Title="Font Upload"
        Behaviors="Move,Close" VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="systemMarkup" runat="server" DestroyOnClose="true" Width="430"
                Height="230">
                <ContentTemplate>
                    <div class="UploadFont_Main">
                        <div class="UploadFont_Box">
                            <div class="UploadFont_bglabel" style="width: 122px;">
                                <asp:Label ID="lblSelectFile" runat="server"><%=objLanguage.GetLanguageConversion("Select_File") %><span style="color:red"> *</span></asp:Label>
                            </div>
                            <div class="box" style="width: 250px;">
                                <div class="box" style="width: 210px; padding-left: 0px; border: 0px solid green">
                                    <asp:FileUpload ID="fup_Fonts" runat="server" CssClass="textboxnew" Style="width: 200px"
                                        onChange="javascript:get_filename(this);" />
                                </div>
                                <div style="padding: 2px 0px 0px 15px">
                                    <a id="img_Anchor" runat='server' href="javascript:void(0);" class="tooltip" title="Only '.ttf' file can be uploaded,before uploading please check your font name inside the font file which should match with entered font name">
                                        <img alt="" id="font_help" runat="server" src="../images/Help-icon.png" style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                            class="tooltip" />
                                    </a>
                                </div>
                            </div>
                            <div>
                                <div style="padding-bottom: 5px; padding-left: 135px;">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Uplaod Font File"
                                        ControlToValidate="fup_Fonts" Width="175px" ValidationGroup="Test" SetFocusOnError="true"
                                        Display="Dynamic" CssClass="RFV_Message" ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px"><%=objLanguage.GetLanguageConversion("Please_Upload_font_File")%></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidateFileUpload"
                                        ControlToValidate="fup_Fonts" ErrorMessage="Please upload only .ttf file"
                                        ValidationGroup="Test" Display="Dynamic" CssClass="RFV_Message" ForeColor=""
                                        Style="width: auto; padding-left: 4px; padding-right: 4px"><%=objLanguage.GetLanguageConversion("Please_upload_only_ttf_file")%></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="UploadFont_Box">
                            <div class="UploadFont_bglabel" style="width: 122px">
                                <asp:Label ID="lblFontName" runat="server"><%=objLanguage.GetLanguageConversion("Font_Friendly_Name")%><span style="color:red"> *</span></asp:Label>
                            </div>
                            <div class="box" style="width: 200px;">
                                <asp:TextBox runat="server" ID="txtFontName" SkinID="textPad" Width="200px" MaxLength="255"></asp:TextBox>
                            </div>
                            <div style="float: left; padding: 2px 0px 0px 3px;">
                                <asp:RequiredFieldValidator ID="RFVFontName" runat="server" ErrorMessage="Please Enter Font Name"
                                    ControlToValidate="txtFontName" ValidationGroup="Test" SetFocusOnError="true"
                                    Display="Dynamic" CssClass="RFV_Message" ForeColor="" Style="width: auto; padding-left: 4px; padding-right: 4px"><%=objLanguage.GetLanguageConversion("Please_Enter_Font_Name")%></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="UploadFont_Box ">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_FontUpload_Note" runat="server" Style="font-weight: bold"><%=objLanguage.GetLanguageConversion("EditableTemplate_Font_Upload_Note")%> </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_FontUpload_Note1" runat="server"><%=objLanguage.GetLanguageConversion("EditableTemplate_Font_Upload_Note_1")%>  </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_FontUpload_Note2" runat="server"><%=objLanguage.GetLanguageConversion("EditableTemplate_Font_Upload_Note_2")%><a id="Editable_upload_font_file_conversion" runat='server' href="https://everythingfonts.com/otf-to-ttf" title="File Conversion from .OTF to .TTF"> here.</a></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_FontUpload_Note3" runat="server"><%=objLanguage.GetLanguageConversion("Font_Upload_Note3")%>  </asp:Label>
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                        <div class="UploadFont_Box" style="padding-top: 10px;">
                            <div>
                                <div style="padding-left: 3px">
                                    <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" OnClick="btnSave_OnClick"
                                        OnClientClick="javascript:if(Page_ClientValidate()) loadingimg(this.id,'div_btnsaveprocess');"
                                        ValidationGroup="Test" />
                                </div>
                                <div id="div_btnsaveprocess" class="button" align="center" style="height: 14px; width: 33px; display: none; margin-left: 12px;">
                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
    <asp:HiddenField ID="hdnFontName" runat="server" Value="" />
    <telerik:RadCodeBlock ID="test" runat="server">
        <script language="javascript" type="text/javascript">
            var hdnIDs = document.getElementById("<%=hdnIDs.ClientID%>");

            function show() {
                img_actionsHide.style.display = "block";
                img_actionsShow.style.display = "none";

                div_chk.style.border = "inset 1px";
                div_chk.style.background = "gray";

                div_popupAction.style.display = "block";
            }

            function hide() {
                img_actionsHide.style.display = "none";
                img_actionsShow.style.display = "block";

                div_chk.style.border = "outset 1px";
                div_chk.style.background = "";

                div_popupAction.style.display = "none";
            }

            function RowDblClick(sender, eventArgs) {
                sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
            }


            function CheckAll(checkAllBox) {
                var frm = document.forms[0];
                var ChkState = checkAllBox.checked;
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                        if (!e.disabled) {
                            e.checked = ChkState;
                        }
                    }
                    if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
                        if (!e.disabled) {
                            e.checked = ChkState;
                        }
                    }
                }
            }
        </script>
    </telerik:RadCodeBlock>
    <telerik:RadScriptBlock ID="script" runat="server">
        <script language="javascript" type="text/javascript">
            function OpenPopup() {
                var fuData = document.getElementById("<%=fup_Fonts.ClientID%>");
                var txtFontName = document.getElementById("<%=txtFontName.ClientID %>");
                txtFontName.value = "";
                fuData.value = "";

                var oWnd = $find("<%=systemMarkup.ClientID%>");
                oWnd.show();
            }

            function ValidateFileUpload(Source, args) {
                var fuData = document.getElementById("<%=fup_Fonts.ClientID%>");
                var txtFontName = document.getElementById("<%=txtFontName.ClientID %>");

                var FileUploadPath = fuData.value;


                if (FileUploadPath == '') {
                    // There is no file selected
                    args.IsValid = false;
                }
                else {
                    var Extension = FileUploadPath.substring(FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
                    if (Extension == "ttf" || Extension == "Ttf") {// || Extension == "otf" || Extension == "Otf") 
                        args.IsValid = true; // Valid file type
                    }
                    else {
                        args.IsValid = false; // Not valid file type                        
                    }
                }
            }

            function CheckOne_new() {
                var Counter = 0;
                var Ides = "";
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                        if (!e.disabled) {
                            if (e.checked) {
                                Counter = Number(Counter) + 1;
                                Ides = Ides + e.value + ",";
                            }
                        }
                    }
                }
                hdnIDs.value = Ides
                if (Number(Counter) == 0) {
                    //alert(Counter);
                    alert("Please check at least one row to Delete");
                    return false;
                }
                else {
                    //alert("call Btn");
                    return window.confirm('Are you sure you want to delete this record(s)?');
                }
            }

            function CallDelete() {
                var ret = CheckOne_new();
                //alert(hdnIDs.value);
                if (ret) {
                    //CheckGrid();
                    return true;
                }
                else {
                    return false;
                }
            }
            function get_filename(obj) {
                var txtFontName = document.getElementById("<%=txtFontName.ClientID %>");
                var file = obj.value;
                var arr_Path = file.split('\\');
                txtFontName.value = arr_Path[2].split('.')[0];
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
