<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true"  CodeBehind="edit_style_sheet.aspx.cs" Inherits="ePrint.StoreSettings.edit_style_sheet" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
        rel="stylesheet" />
    <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
    <script src="../js/rgbcolor.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript">
        var strSitepath = "<%=strSitepath %>";
        var AccountID = '<%=AccountID %>';
        $(document).ready(function () {
            $(function () {
                $("#accordion").accordion({
                    header: "h3", collapsible: true, autoHeight: false
                });
                $("#accordion").accordion();

                document.getElementById("tabs").style.visibility = 'visible';
                $('#tabs').tabs();
                $('#tabs').tabs('select', '#tabs-2');

            });
        });
    </script>
    <style type="text/css">
        #test-1
        {
            background-image: none;
            font-weight: bolder;
        }
        
        .RadColorPicker .rcpMillionColorsPageView .rcpInputsWrapper .rcpMillionColorsInputs, .RadColorPicker_Default .rcpButton
        {
            display: none;
        }
    </style>
    <!--POPUP START-->
    <!--POPUP END-->
    <div id="divBackGround_New" style="display: none;">
    </div>
    <asp:HiddenField ID="hdnAccountType" runat="server" />
    <div style="float: left;" class="estore_settingBox">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Edit_Style_Sheet")%>&nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                            href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change") %></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div id="divtab" runat="server">
                <div id="tabs" style="visibility: hidden; padding-top: 7px; padding-left: 7px; -moz-border-radius-topright: 0px;
                    border: none; -webkit-border-top-right-radius: 0px; -khtml-border-top-right-radius: 0px;
                    border-top-right-radius: 0px; -moz-border-radius-topleft: 0px; -webkit-border-top-left-radius: 0px;
                    -khtml-border-top-left-radius: 0px; border-top-left-radius: 0px;" class="ui-tabs">
                    <ul id="test-1" style="list-style: none; height: auto; background-color: #FFFFFF;
                        border: 1px solid transparent; border-radius: 0px; width: 97.4%; margin-left: 5px;">
                        <li style="margin-left: -4px"><a id="spn_1" href="#tabs-1" onclick="Call_Report(this.id);">
                            <b>
                                <%=objLanguage.GetLanguageConversion("Source") %></b></a></li>
                        <li><a id="spn_2" href="#tabs-2" onclick="Call_Report(this.id);"><b>
                            <%=objLanguage.GetLanguageConversion("Design")%></b></a></li>
                    </ul>
                    <div id="tabs-1" class="ui-tabs-hide">
                        <asp:Panel ID="phAccessDenite" runat="server" Visible="false">
                            <script type="text/javascript" language="javascript">
                                alert('<%=objLanguage.GetLanguageConversion("Current_File_Using_By_Some_Other_Processor") %>' + ".");     
                            </script>
                        </asp:Panel>
                        <div class="Editstylesheet_withouttopborder">
                            <div align="left" style="width: 100%; padding-bottom: 0px;">
                                <div style="width: 60%; margin: 5px 0px 0px 5px">
                                    <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                        <ContentTemplate>
                                            <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div id="div1" style="padding-left: 5px; padding-top: 5px; padding-bottom: 5px; display: none;
                                    height: 300px" runat="server">
                                    <asp:Label ID="Label1" runat="server" Text="Page in progress"></asp:Label>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <table class="editstyletable">
                                <tr>
                                    <td class="edittablealign">
                                        <div id="div_EditStyleSheetPage" class="editstyletextdiv" runat="server">
                                            <div style="padding-left: 5px; padding-top: 10px; padding-bottom: 5px">
                                                <asp:TextBox ID="txt_editStyleSheet" runat="server" CssClass="EditStyletextboxnew"
                                                    TextMode="MultiLine" Style="min-height: 535px"></asp:TextBox><%--Font-Size="10px"--%>
                                            </div>
                                            <div style="clear: both;">
                                            </div>
                                        </div>
                                    </td>
                                    <td class="edittablealigncell">
                                        <div class="EditstyleTopHeader">
                                            <div>
                                                <span class="edithelptextline">Customize Style Sheet for B2B or Public store </span>
                                            </div>
                                            <div class="edittextgap">
                                            </div>
                                            <div class="edithelptext">
                                                <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Skin="Default" ExpandMode="MultipleExpandedItems"
                                                    CssClass="NewEditStyle">
                                                    <Items>
                                                        <telerik:RadPanelItem Text="Changing Style Classes" CssClass="rounded-ReportTopcorners"
                                                            Expanded="false">
                                                            <ContentTemplate>
                                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="multiPage">
                                                                    <telerik:RadPageView runat="server" ID="RadPageView1">
                                                                        <div class="editpanel">
                                                                            <div class="edittoptextgap">
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("First_make_sure_you_have_selected_the_correct_B2B_or_Public_Account")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                <span class="editstyleToplink1">
                                                                                    <%=objLanguage.GetLanguageConversion("eStore_Settings_Edit_Style_sheet")%>
                                                                                    <%-- <asp:Label ID="lblPanelAccountName" runat="server" Text=""></asp:Label>--%><
                                                                                    <%=objLanguage.GetLanguageConversion("account_nameEdit")%>
                                                                                    ><span class="editstyleanchortag"><%=objLanguage.GetLanguageConversion("Change_Edit_Style")%></span>
                                                                                </span>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •
                                                                                <%=objLanguage.GetLanguageConversion("Then_Click_on")%><span class="editmastersheet">
                                                                                    <%=objLanguage.GetLanguageConversion("View_Master_Style_Sheet_edit")%>
                                                                                </span>
                                                                                <%=objLanguage.GetLanguageConversion("Button_to_see_existing_master_style_sheet_please_note_master_style_sheet_is_view_only")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                <span class="editstyleToplink">
                                                                                    <%=objLanguage.GetLanguageConversion("Master_stylesheet_view_only")%></span></span>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("Locate_the_class_you_want_to_change_this_can_easly_find_b2b_b2c_site_right_click_want_to_change_select_inspect_element")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                <span class="editstyleToplink">
                                                                                    <%=objLanguage.GetLanguageConversion("B2c_site_right_click_want_to_change_and_select_inspect_element")%></span>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("once_you_locate_style_you_may_come_edit_style_sheet_and_locate_in_master_style_sheet")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                <span class="editstyleToplink">
                                                                                    <%=objLanguage.GetLanguageConversion("Master_Style_Sheet")%></span>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("copy_paste_inculding_curly_brackets_paste_on_custom_style_sheet_panle")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •
                                                                                <%=objLanguage.GetLanguageConversion("Click_Save_go_to_the_B2B_or_B2C_site_to_see_the_changes_For_Windows_you_need_to_press_keys_together_For_Mac_you_may_need_to_press")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                <span class="editstyleToplink">
                                                                                    <%=objLanguage.GetLanguageConversion("Changes_for_window_press_key_together_for_mac")%></span>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                <span class="editstyleToplink">
                                                                                    <%=objLanguage.GetLanguageConversion("press_command_key_together")%></span>
                                                                            </div>
                                                                            <div class="edittoptextgap">
                                                                            </div>
                                                                        </div>
                                                                    </telerik:RadPageView>
                                                                </telerik:RadMultiPage>
                                                            </ContentTemplate>
                                                        </telerik:RadPanelItem>
                                                        <telerik:RadPanelItem Text="Uploading an external image for using in the style" CssClass="rounded-ReportTopcorners">
                                                            <ContentTemplate>
                                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="multiPage">
                                                                    <telerik:RadPageView runat="server" ID="RadPageView2">
                                                                        <div class="editpanel">
                                                                            <div class="edittoptextgap">
                                                                            </div>
                                                                            <div class="edithelptexttable">
                                                                                <%=objLanguage.GetLanguageConversion("You_may_sometime_need_image_as_bodybackground_or_navigationbar_if_your_image_is_hosted_somehwhere_else_can_redirect_it_you_can_upload_use_in_tyle_sheeet")%>
                                                                            </div>
                                                                            <div class="edittextgap">
                                                                            </div>
                                                                            <div class="edithelptexttable">
                                                                                <%=objLanguage.GetLanguageConversion("Suppose_you_wanted_to_upload_background_image_please_follow_below_steps")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("You_need_to_click_on")%>
                                                                                <%-- </div>
                                                                <div class="edithelptextbulletin">--%>
                                                                                <span class="editstylelink">
                                                                                    <%=objLanguage.GetLanguageConversion("Appearance_Upload_External_Image")%></span>
                                                                                <%=objLanguage.GetLanguageConversion("This_will_open_dialog_box")%></div>
                                                                            <div class="edithelptextbulletin">
                                                                                •
                                                                                <%=objLanguage.GetLanguageConversion("You_will_see_ePrint_directory_folder_for_documents_where_all_images_are_stored")%></div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("You_can_press_Upload_icon_to_upload_one_or_may_images")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("Use_the_file_and_size_as_per_the_max_size_and_file_type_specified_therein")%></div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("Once_uploaded_you_will_see_the_image_in_the_preview_area")%></div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("If_multiple_Images_Uploaded_show_preview_image_preview_Area")%>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                <span class="editstyleToplink">
                                                                                    <%=objLanguage.GetLanguageConversion("Image_will_show_on_preview_area")%></span>
                                                                            </div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("Right_Click_on_the_image_and_chooseto_copy_the_path_of_the_image")%></div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("Paste_Image_Path_At_Desired_Stylee_Sheet")%></div>
                                                                            <div class="edithelptextbulletin">
                                                                                •<%=objLanguage.GetLanguageConversion("In_This_Example_Want_use_want_to_use_in_body_tag_use_as_background_url")%></div>
                                                                        </div>
                                                                        <div class="edithelptextbulletin">
                                                                            <span class="imagepath1">
                                                                                <%=objLanguage.GetLanguageConversion("Body_backgroung__url")%>
                                                                                <
                                                                                <%=objLanguage.GetLanguageConversion("path_of_the_image")%>
                                                                                >')} </span>
                                                                        </div>
                                                                        <div class="edithelptextbulletin">
                                                                            •<%=objLanguage.GetLanguageConversion("You_Can_use_other_attribute_like_location_repeat_background_etc")%>
                                                                        </div>
                                                                        <div class="edithelptextbulletin">
                                                                            <span class="editstyleToplink">
                                                                                <%=objLanguage.GetLanguageConversion("Can_Check")%><a id="A2" href="http://www.w3schools.com/css"
                                                                                    target="_blank">
                                                                                    <%=objLanguage.GetLanguageConversion("here")%></a></span></div>
                                                                        <div class="edithelptexttable">
                                                                            <%=objLanguage.GetLanguageConversion("if_you_want_another_cahnges_please_contact_erpint_team")%>
<%--                                                                            <a id="A3" href="mailto:support@eprintsoftware.com">--%>
                                                                                <a id="A3" href="mailto:support@hexicomsoftware.com">
                                                                                <%=objLanguage.GetLanguageConversion("support_eprint_com")%></a>.
                                                                            <%=objLanguage.GetLanguageConversion("This_may_Attract_Small_fee")%></div>
                                                                    </telerik:RadPageView>
                                                                </telerik:RadMultiPage>
                                                            </ContentTemplate>
                                                        </telerik:RadPanelItem>
                                                    </Items>
                                                </telerik:RadPanelBar>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <div class="editstylebutton">
                                <div style="float: left; padding: 3px">
                                    <div id="div_btn_cancel" style="display: block; float: left;">
                                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="button" OnClick="btn_cancel_OnClick" />
                                    </div>
                                    <div id="div_btn_cancelprocess" class="button" align="center" style="height: 14px;
                                        width: 43px; display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="display: inline; float: left; padding: 3px">
                                    <div id="div_btnsave" style="display: block">
                                        <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="button" OnClick="btn_save_Click"
                                            OnClientClick="javascript:var a=RestoreDefault('save');if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                    </div>
                                    <div id="div_btnsaveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="display: inline; float: left; padding: 3px">
                                    <div id="div_default" style="display: block">
                                        <asp:Button ID="btn_default" runat="server" Text="Restore Default" CssClass="button"
                                            OnClick="btn_default_Click" OnClientClick="javascript:var a=RestoreDefault('default');if(a)loadingimage(this.id,'div_defaultprocess');return a;" />
                                    </div>
                                    <div id="div_defaultprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="display: inline; float: left; padding: 3px">
                                    <asp:Button ID="btn_masterStyleSheet" runat="server" Text="Vew Master StyleSheet"
                                        CssClass="button" OnClientClick="javascript:return viewMasterStyleAheet()" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tabs-2" class="ui-tabs-hide">
                        <div class="Editstylesheet_withouttopborder">
                            <div id="accordion" style="width: 100%; padding: 0px; margin: 0px">
                                <%--BODY--%>
                                <div align='center' style='width: 80%; margin: 10px'>
                                    <h3>
                                        <a style='border-bottom-width: 0px' href='#'>
                                            <table cellpadding='0' cellspacing='0' border='0' width='100%'>
                                                <tr>
                                                    <td width='100%'>
                                                        <b style='float: left; text-transform: uppercase'>
                                                            <%=objLanguage.GetLanguageConversion("Body") %></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </a>
                                    </h3>
                                    <div align='left' style='padding: 5px; margin: 0px;'>
                                        <table style="padding: 10px;">
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text") %>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBody_color" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtBody_color_div" runat="server" style="height: 19px; width: 19px; float: left;
                                                        margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtBody_color');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /><%--onclick="javascript:paletteOpen('txtBody_color');return false;"--%>
                                                    </div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Background")%>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBody_bckgrdcolor" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtBody_bckgrdcolor_div" runat="server" style="height: 19px; width: 19px;
                                                        float: left; margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtBody_bckgrdcolor');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Default") %>&nbsp;<%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Size")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBody_fontsize" runat="server" Width="65px" CssClass="textboxnew"
                                                        onkeypress="javascript:return IntergerValidation(event);">
                                                    </asp:TextBox>&nbsp;px
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Default") %>&nbsp;<%=objLanguage.GetLanguageConversion("Font_Family")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlBody_fontfamily" runat="server" Width="175px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <%--HEADER--%>
                                <div align='center' style='width: 80%; margin: 10px'>
                                    <h3>
                                        <a style='border-bottom-width: 0px' href='#'>
                                            <table cellpadding='0' cellspacing='0' border='0' width='100%'>
                                                <tr>
                                                    <td width='100%'>
                                                        <b style='float: left; text-transform: uppercase'>
                                                            <%=objLanguage.GetLanguageConversion("Header")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </a>
                                    </h3>
                                    <div align='left' style='padding: 5px; margin: 0px;'>
                                        <table style="padding: 10px;">
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text") %>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHeader_color" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtHeader_color_div" runat="server" style="height: 19px; width: 19px; float: left;
                                                        margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtHeader_color');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Size")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHeader_fontsize" runat="server" Width="65px" CssClass="textboxnew"
                                                        onkeypress="javascript:return IntergerValidation(event);">
                                                    </asp:TextBox>&nbsp;px
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <%--MENU--%>
                                <div align='center' style='width: 80%; margin: 10px'>
                                    <h3>
                                        <a style='border-bottom-width: 0px' href='#'>
                                            <table cellpadding='0' cellspacing='0' border='0' width='100%'>
                                                <tr>
                                                    <td width='100%'>
                                                        <b style='float: left; text-transform: uppercase;'>
                                                            <%=objLanguage.GetLanguageConversion("Menu")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </a>
                                    </h3>
                                    <div align='left' style='padding: 5px; margin: 0px;'>
                                        <table style="padding: 10px;">
                                            <tr>
                                                <td colspan="2">
                                                    <b style='float: left; text-transform: uppercase;'>
                                                        <%=objLanguage.GetLanguageConversion("Menu")%></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Background")%>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenu_bckgrdcolor" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtMenu_bckgrdcolor_div" runat="server" style="height: 19px; width: 19px;
                                                        float: left; margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtMenu_bckgrdcolor');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Font_Weight")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenu_fontweight" runat="server" Width="175px">
                                                        <asp:ListItem Value="0">------Select------</asp:ListItem>
                                                        <asp:ListItem Value="bold">bold</asp:ListItem>
                                                        <asp:ListItem Value="bolder">bolder</asp:ListItem>
                                                        <asp:ListItem Value="lighter">lighter</asp:ListItem>
                                                        <asp:ListItem Value="normal">normal</asp:ListItem>
                                                        <asp:ListItem Value="100">100</asp:ListItem>
                                                        <asp:ListItem Value="200">200</asp:ListItem>
                                                        <asp:ListItem Value="300">300</asp:ListItem>
                                                        <asp:ListItem Value="400">400</asp:ListItem>
                                                        <asp:ListItem Value="500">500</asp:ListItem>
                                                        <asp:ListItem Value="600">600</asp:ListItem>
                                                        <asp:ListItem Value="700">700</asp:ListItem>
                                                        <asp:ListItem Value="800">800</asp:ListItem>
                                                        <asp:ListItem Value="900">900</asp:ListItem>
                                                        <asp:ListItem Value="inherit">inherit</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <b style='float: left; text-transform: uppercase;'>
                                                        <%=objLanguage.GetLanguageConversion("Menu_Item")%>
                                                    </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text") %>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenuItem_color" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtMenuItem_color_div" runat="server" style="height: 19px; width: 19px;
                                                        float: left; margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtMenuItem_color');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Size")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenuItem_fontsize" runat="server" Width="65px" CssClass="textboxnew"
                                                        onkeypress="javascript:return IntergerValidation(event);">
                                                    </asp:TextBox>&nbsp;px
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Font_Family")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenuItem_fontfamily" runat="server" Width="175px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text_Decoration")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenuItem_txtDcrtn" runat="server" Width="175px">
                                                        <asp:ListItem Value="0">------Select------</asp:ListItem>
                                                        <asp:ListItem Value="blink">blink</asp:ListItem>
                                                        <asp:ListItem Value="inherit">inherit</asp:ListItem>
                                                        <asp:ListItem Value="initial">initial</asp:ListItem>
                                                        <asp:ListItem Value="line-through">line-through</asp:ListItem>
                                                        <asp:ListItem Value="overline">overline</asp:ListItem>
                                                        <asp:ListItem Value="underline">underline</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text_Transform")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenuItem_txtTrnsfm" runat="server" Width="175px">
                                                        <asp:ListItem Value="0">------Select------</asp:ListItem>
                                                        <asp:ListItem Value="capitalize">capitalize</asp:ListItem>
                                                        <asp:ListItem Value="inherit">inherit</asp:ListItem>
                                                        <asp:ListItem Value="initial">initial</asp:ListItem>
                                                        <asp:ListItem Value="lowercase">lowercase</asp:ListItem>
                                                        <asp:ListItem Value="none">none</asp:ListItem>
                                                        <asp:ListItem Value="uppercase">uppercase</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <b style='float: left; text-transform: uppercase;'>
                                                        <%=objLanguage.GetLanguageConversion("Menu_Item_Hover")%></b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text") %>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenuItmHvr_color" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtMenuItmHvr_color_div" runat="server" style="height: 19px; width: 19px;
                                                        float: left; margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtMenuItmHvr_color');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Background")%>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenuItmHvr_bckgrdcolor" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtMenuItmHvr_bckgrdcolor_div" runat="server" style="height: 19px; width: 19px;
                                                        float: left; margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtMenuItmHvr_bckgrdcolor');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Size")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenuItmHvr_fontsize" runat="server" Width="65px" CssClass="textboxnew"
                                                        onkeypress="javascript:return IntergerValidation(event);">
                                                    </asp:TextBox>&nbsp;px
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Font_Family")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenuItmHvr_fontfamily" runat="server" Width="175px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text_Decoration")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenuItmHvr_txtDcrtn" runat="server" Width="175px">
                                                        <asp:ListItem Value="0">------Select------</asp:ListItem>
                                                        <asp:ListItem Value="blink">blink</asp:ListItem>
                                                        <asp:ListItem Value="inherit">inherit</asp:ListItem>
                                                        <asp:ListItem Value="initial">initial</asp:ListItem>
                                                        <asp:ListItem Value="line-through">line-through</asp:ListItem>
                                                        <asp:ListItem Value="overline">overline</asp:ListItem>
                                                        <asp:ListItem Value="underline">underline</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text_Transform")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMenuItmHvr_txtTrnsfm" runat="server" Width="175px">
                                                        <asp:ListItem Value="0">------Select------</asp:ListItem>
                                                        <asp:ListItem Value="capitalize">capitalize</asp:ListItem>
                                                        <asp:ListItem Value="inherit">inherit</asp:ListItem>
                                                        <asp:ListItem Value="initial">initial</asp:ListItem>
                                                        <asp:ListItem Value="lowercase">lowercase</asp:ListItem>
                                                        <asp:ListItem Value="none">none</asp:ListItem>
                                                        <asp:ListItem Value="uppercase">uppercase</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr id="Menu_Item_Selected_hdng_tr" runat="server">
                                                <td colspan="2">
                                                    <b style='float: left; text-transform: uppercase;'>
                                                        <%=objLanguage.GetLanguageConversion("Menu_Item_Selected")%></b>
                                                </td>
                                            </tr>
                                            <tr id="Menu_Item_Selected_options_tr2" runat="server">
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Background")%>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtMenuItmSlctd_bckgrdcolor" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtMenuItmSlctd_bckgrdcolor_div" runat="server" style="height: 19px; width: 19px;
                                                        float: left; margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtMenuItmSlctd_bckgrdcolor');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <%--NAVIGATION--%>
                                <div align='center' style='width: 80%; margin: 10px'>
                                    <h3>
                                        <a style='border-bottom-width: 0px' href='#'>
                                            <table cellpadding='0' cellspacing='0' border='0' width='100%'>
                                                <tr>
                                                    <td width='100%'>
                                                        <b style='float: left; text-transform: uppercase;'>
                                                            <%=objLanguage.GetLanguageConversion("Navigation_Bar")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </a>
                                    </h3>
                                    <div align='left' style='padding: 5px; margin: 0px;'>
                                        <table style="padding: 10px;">
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Background")%>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNavBar_bckgrdcolor" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtNavBar_bckgrdcolor_div" runat="server" style="height: 19px; width: 19px;
                                                        float: left; margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtNavBar_bckgrdcolor');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Size")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtNavBar_fontsize" runat="server" Width="65px" CssClass="textboxnew"
                                                        onkeypress="javascript:return IntergerValidation(event);">
                                                    </asp:TextBox>&nbsp;px
                                                </td>
                                            </tr>
                                            <tr id="tr_Upload_Cart_Image" runat="server">
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Upload_Cart_Image")%>
                                                    </div>
                                                    <div>
                                                        <a title="The standard Cart Image size is 44 x 26 pixels" href="javascript:void(0);"
                                                            id="img_thumbNail" runat="server" class="tooltip">
                                                            <img alt="" id="img_help_productthumbnail" runat="server" src="../images/Help-icon.png"
                                                                style="cursor: pointer; width: 16px; height: 16px; margin: 4px 0px 0px 0px; border: solid 0px green;"
                                                                class="tooltip" /></a>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="upCartImage" runat="server" CssClass="textboxnew" />
                                                    <asp:Label ID="lblCartImageName" runat="server" CssClass="Normaltext"></asp:Label>
                                                    <asp:HiddenField ID="hdnCartImage" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <%--HEADING--%>
                                <div align='center' style='width: 80%; margin: 10px'>
                                    <h3>
                                        <a style='border-bottom-width: 0px' href='#'>
                                            <table cellpadding='0' cellspacing='0' border='0' width='100%'>
                                                <tr>
                                                    <td width='100%'>
                                                        <b style='float: left; text-transform: uppercase;'>
                                                            <%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Heading")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </a>
                                    </h3>
                                    <div align='left' style='padding: 5px; margin: 0px;'>
                                        <table style="padding: 10px;">
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text") %>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHeading_color" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtHeading_color_div" runat="server" style="height: 19px; width: 19px; float: left;
                                                        margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtHeading_color');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" /></div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Size")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtHeading_fontsize" runat="server" Width="65px" CssClass="textboxnew"
                                                        onkeypress="javascript:return IntergerValidation(event);">
                                                    </asp:TextBox>&nbsp;px
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Font_Family")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlHeading_fontfamily" runat="server" Width="175px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <%--FOOTER--%>
                                <div align='center' style='width: 80%; margin: 10px'>
                                    <h3>
                                        <a style='border-bottom-width: 0px' href='#'>
                                            <table cellpadding='0' cellspacing='0' border='0' width='100%'>
                                                <tr>
                                                    <td width='100%'>
                                                        <b style='float: left; text-transform: uppercase;'>
                                                            <%=objLanguage.GetLanguageConversion("Footer")%></b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </a>
                                    </h3>
                                    <div align='left' style='padding: 5px; margin: 0px;'>
                                        <table style="padding: 10px;">
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text") %>&nbsp;<%=RegionalSettings_ColorText%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFooter_color" runat="server" Width="65px" Style="float: left;"
                                                        CssClass="textboxnew"></asp:TextBox>
                                                    <div id="txtFooter_color_div" runat="server" style="height: 19px; width: 19px; float: left;
                                                        margin-left: 2px;">
                                                    </div>
                                                    <div style="float: left;">
                                                        <img src="<%=strImagepath %>colorcube.gif" onclick="javascript:showwindow('txtFooter_color');return false;"
                                                            style="height: 18px; width: 18px; margin-left: 10px; cursor: pointer;" alt="loading"
                                                            border="0" />
                                                    </div>
                                                    <div style="float: left; padding-left: 10px; padding-top: 1px;">
                                                        <%=objLanguage.GetLanguageConversion("Edit_Style_Sheet_Color_Help_Text")%>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Text")%>&nbsp;<%=objLanguage.GetLanguageConversion("Size")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtFooter_fontsize" runat="server" Width="65px" CssClass="textboxnew"
                                                        onkeypress="javascript:return IntergerValidation(event);">
                                                    </asp:TextBox>&nbsp;px
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="label" style="width: 160px; padding-bottom: 5px;">
                                                    <div style="float: left; padding: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Font_Family")%>
                                                    </div>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlFooter_fontfamily" runat="server" Width="175px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div style="padding-left: 10px;">
                                <div id="divSave_Design" style="display: block; float: left;">
                                    <asp:Button ID="btnSave_Design" runat="server" Text="Save" CssClass="button" OnClick="btnSave_Design_Click"
                                        OnClientClick="javascript: var a=validate_Account(); if(a)loadingimage(this.id,'divSave_Design_Loading');return a;" /><%--OnClick="btnSave_Design_Click"--%>
                                </div>
                                <div id="divSave_Design_Loading" style="display: none; float: left;">
                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                </div>
                            </div>
                            <div style="clear: both; padding-top: 10px">
                            </div>
                        </div>
                    </div>
                    <div style="clear: both; padding-top: 10px">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input id="hiddenid" type="hidden" name="hiddenid">
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 95;
        width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1060" Height="640" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <telerik:RadWindowManager runat="server" ID="Radwinmanagercatalogue" Behaviors="Move,Close"
        VisibleStatusbar="false" Modal="true">
        <Windows>
            <telerik:RadWindow ID="colorpicker" DestroyOnClose="true" Width="285" Height="305"
                runat="server">
                <ContentTemplate>
                    <div id="padding" style="width: 80%; margin-top: 3%;">
                        <table>
                            <tr>
                                <td>
                                    <telerik:RadColorPicker ID="RadColorPicker1" AutoPostBack="false" Preset="Default"
                                        PaletteModes="HSV" ShowIcon="false" SelectedColor="Black" runat="server" ShowEmptyColor="false">
                                    </telerik:RadColorPicker>
                                    <%--OnClientColorChange="HandleColorChange"--%>
                                    <div style="float: right; padding-top: 5px;">
                                        <asp:Button ID="btn_ColorApply" runat="server" Text="Apply" OnClientClick="javascript:ColorChange();return false;"
                                            class="button" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ContentTemplate>
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
    <script type="text/javascript" language="javascript">

        function showwindow(fieldName) {
            document.forms[0]['hiddenid'].value = fieldName;
            var colorPicker = $find('<%= RadColorPicker1.ClientID%>');
            if (document.getElementById("ctl00_ContentPlaceHolder1_" + fieldName).value != "" && document.getElementById("ctl00_ContentPlaceHolder1_" + fieldName).value != undefined) {
                colorPicker.set_selectedColor(document.getElementById("ctl00_ContentPlaceHolder1_" + fieldName).value);
            }
            var oWnd = $find("<%=colorpicker.ClientID%>");
            document.getElementById("divBackGround_New").style.display = "block";
            oWnd.show();
        }

        function ColorChange() {
            var hid = document.forms[0]['hiddenid'].value;
            var ColorSelected = document.getElementById("ctl00_ContentPlaceHolder1_colorpicker_C_RadColorPicker1_hexInput").value;
            document.getElementById("ctl00_ContentPlaceHolder1_" + hid + "_div").style.background = ColorSelected;
            $get("ctl00_ContentPlaceHolder1_" + hid).value = ColorSelected;
            var oWnd = $find("<%=colorpicker.ClientID%>");
            document.getElementById("divBackGround_New").style.display = "none";
            oWnd.close();
        }

        function RestoreDefault(val) {
            if (validate_Account()) {
                if (val == "default")
                    return window.confirm('<%=objLanguage.GetLanguageConversion("Replace_Default_Style_Confirmation") %> ');
                if (val == "save")
                    return window.confirm('<%=objLanguage.GetLanguageConversion("Overwrite_Default_Style_Confirmation") %>');
            }
            else {
                return false;
            }
        }

        function RedirectTo() {
            window.location = '<%=strSitepath %>' + "settings/settings.aspx";
            return false;
        }

        function viewMasterStyleAheet() {
            window.radopen("<%=strSitepath %>StoreSettings/MasterStyleSheet.aspx?at=<%=AccountType%>", 'MasterStyleSheet', 1100, 650);
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            return false;
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

