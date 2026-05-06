<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="manage_banner.aspx.cs" Inherits="ePrint.StoreSettings.manage_banner" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid_bannerLeft">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerLeft" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Button3">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerLeft" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtncopy">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerLeft" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid_bannerHome">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerHome" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Button2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerHome" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtncopy">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerHome" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid_bannerRight">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerRight" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Button4">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerRight" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtncopy">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_bannerRight" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            text-decoration: none;
        }
        .RadGrid_Default .rgCommandCell
        {
            border: none;
            margin-top: -9px;
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
        
        .button
        {
            margin-left: -8px;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <script src="../js/item/Banner_Images.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <style type="text/css">
        .CustomCssClass
        {
            background-color: #c9ecff !important;
        }
        .RadDock .rdTop, .RadDock .rdBottom, .RadDock .rdLeft, .RadDock .rdRight
        {
            display: none !important;
        }
        .rdPlaceHolder
        {
            border: 0 !important;
            background: transparent !important;
        }
        pre
        {
            display: block;
            font: 100% "Courier New" , Courier, monospace;
            padding: 10px;
            border: 0px solid #bae2f0;
            background: #e3f4f9;
            margin: .5em 0;
            overflow: auto;
            width: 800px;
        }
        #preview
        {
            position: absolute;
            border: 0px solid #ccc;
            background: #333;
            padding: 1px;
            display: none;
            color: #fff;
        }
    </style>
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <div id="pnldetails" class="estore_settingBox">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Manage_Banners")%>&nbsp;
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
            <div style="padding: 5px 10px 10px 5px;">
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%; margin: 5px 0px 0px 5px">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="padding-left: 5px; padding-top: 0px; display: block">
                    <div style="width: 100%; display: block" id="divtabs">
                        <div id="ynnav">
                            <ul>
                                <li id="li_home" style="cursor: pointer; float: left; clear: right; display: block"
                                    runat="server">
                                    <div id="divhome" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                                        color: Red; float: left; line-height: 20px; margin-right: 2px; filter: opaci">
                                        <b>
                                            <asp:Label ID="lbl_home" runat="server" Text="Sliding Banner" onclick="javascript:gettabs('h');"><%=objLanguage.GetLanguageConversion("Sliding_Banner")%></asp:Label>
                                        </b>
                                    </div>
                                </li>
                                <li id="li_leftPanel" style="cursor: pointer; float: left; clear: right; display: block">
                                    <div id="divleftPanel" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                                        float: left; line-height: 20px; margin-right: 2px;">
                                        <b>
                                            <asp:Label ID="lbl_leftPanel" runat="server" Text="Left Banner" onclick="javascript:gettabs('l');"><%=objLanguage.GetLanguageConversion("Left_Banner")%></asp:Label>
                                        </b>
                                    </div>
                                </li>
                                <li id="li_rightPanel" style="cursor: pointer; float: left; clear: right; display: block">
                                    <div id="divrightPanel" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                                        float: left; line-height: 20px; margin-right: 2px; filter: opaci">
                                        <b>
                                            <asp:Label ID="lbl_rightPanel" runat="server" Text="Right Banner" onclick="javascript:gettabs('r');"><%=objLanguage.GetLanguageConversion("Right_Banner")%></asp:Label>
                                        </b>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div id="div_home" style="border: solid 1px gainsboro; display: block; padding: 10px 10px 10px 10px">
                        <fieldset style="margin: 10px 0px 0px 0px">
                            <legend class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Add_Banner")%></legend>
                                  <div style="padding-left: 5px; padding-top: 10px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="Label9" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Banner_Name")%></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>
                                <div style="float: left; width: auto;" class="box">
                                    <asp:TextBox ID="txtBannerName" CssClass="textboxnew" runat="server" MaxLength="100"></asp:TextBox>
                                    <%--onblur="CallonBlur(this.value,'spn_bannerName_HomeBanner');" --%>
                                </div>
                            </div>
                            <div style="padding-left: 5px; padding-top: 10px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_bannerName_HomeBanner" runat="server" Text="Banner Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Banner_Title")%></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>
                                <div style="float: left; width: auto;" class="box">
                                    <asp:TextBox ID="txt_bannerName_HomeBanner" CssClass="textboxnew" runat="server" MaxLength="100"></asp:TextBox>  <%--onblur="CallonBlur(this.value,'spn_bannerName_HomeBanner');" --%>
                                </div>
                                <div id="spn_bannerName_HomeBanner" style="display: none; width: auto; float: left;
                                    margin-left: 2px">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Banner_Title")%></span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_bannerDescription_HomeBanner" runat="server" Text="Banner Description"
                                        CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Banner_Description")%></asp:Label>
                                </div>
                                <div style="float: left; width: auto;" class="box">
                                    <asp:TextBox ID="txt_bannerDescription_HomeBanner" CssClass="textboxnew" Width="300px"
                                        Height="150px" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div id="spn_bannerDesc_HomeBanner" style="display: none; float: left; margin-left: 2px">
                                    <div class="RFV_Message" style="width: auto;">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Banner_Description")%></span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_image_HomeBanner" runat="server" Text="Image" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Image")%></asp:Label>
                                    <span style="color: red">*</span>
                                </div>
                                <div id="div_fuBanner_HomeBanner" runat="server" style="float: left; width: auto;"
                                    class="box">
                                    <div style="float: left">
                                        <asp:FileUpload ID="fuBanner_HomeBanner" size="19" CssClass="textboxnew_ForBanner"
                                            runat="server" />&nbsp;&nbsp;
                                    </div>
                                    <div style="float: left; padding: 2px 0px 0px 2px">
                                        <a href="javascript:void(0);" class="tooltip" title="Please use image in .JPG,.GIF,.PNG format only. Restrict the width of the Banner to 950px & Height to 250px. In case if you upload a bigger width and hieght  banner, it will hide the excess width and height">
                                            <img alt="" id="img_help_HomeBanner" runat="server" src="../images/Help-icon.png"
                                                style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" />
                                        </a>
                                    </div>
                                </div>
                                <div id="spn_image_HomeBanner" runat="server" style="display: none; width: auto;
                                    float: left; margin-left: 2px">
                                    <div class="RFV_Message" id="spn_image_HomeBanner_selectImg" runat="server" style="display: none;
                                        width: auto;">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Select_Banner_Image")%></span>
                                    </div>
                                    <div class="RFV_Message" id="spn_image_HomeBanner_onlyImg" runat="server" style="display: none;
                                        padding-left: 4px; padding-right: 4px; width: auto;">
                                        <asp:Label ID="Label4" runat="server" Text="(Please upload only image file)"></asp:Label>
                                    </div>
                                </div>
                                <div>
                                    <div id="div_changeImage_Home" runat="server" style="float: left; display: none;
                                        padding-top: 5px; padding-left: 5px;">
                                        <a href="#" id="lnkFileName_Home" runat="server"></a>&nbsp;&nbsp; <a href="#" style="text-decoration: underline"
                                            onclick="javascript:ChangeImage_home();">
                                            <%=objLanguage.GetLanguageConversion("Change_Image")%></a>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                    <asp:HiddenField ID="hdn_catagoryImageName_home" runat="server" />
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_url_HomeBanner" runat="server" Text="URL" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("URL") %></asp:Label>
                                </div>
                                <div style="float: left; width: auto;" class="box">
                                    <asp:TextBox ID="txt_url_HomeBanner" CssClass="textboxnew" runat="server" Width="298px"></asp:TextBox>
                                </div>
                                <div id="spn_url_HomeBanner" style="display: none; float: left; margin-left: 2px">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_URL")%></span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div class="bglabel" style="width: 20%; background-color: White;">
                                <asp:Label ID="Label6" runat="server" CssClass="normaltext"></asp:Label>
                            </div>
                            <div id="div7" runat="server" style="float: left; width: 330px; padding: 0px 0px 0px 8px"
                                class="box">
                                <div style="display: inline; float: left; padding: 0px; padding-left: 10px">
                                    <div id="div_btn_cancel_home" style="display: block;">
                                        <asp:Button ID="btn_cancel_home" runat="server" Text="Cancel" CssClass="button" OnClick="btn_cancel_home_click" />
                                    </div>
                                    <div id="div_btn_cancel_homeprocess" class="button" align="center" style="width: 44px;
                                        display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="display: inline; float: left; margin-left: 15px;">
                                    <div id="div_btnsavehome" style="display: block;">
                                        <asp:Button ID="btn_saveBannerHome" runat="server" Text="Save" CssClass="button"
                                            OnClick="btn_saveBannerHome_Click" OnClientClick="javascript:var a=validate('saveBannerHome');if(a)loadingimage(this.id,'div_savebannerprocess');return a;" />
                                    </div>
                                    <div id="div_savebannerprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                             <div style="width: 655px; padding: 34px 0px 5px 0px;" class="smallfontgrey">
                                <table>
                                    <tr>
                                        <td id="note1" class="smallfontgrey">
                                            <asp:Label ID="lblNote" runat="server">  <%=objLanguage.GetLanguageConversion("Please_note_Text_entered_display")%></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </fieldset>                         
                        <fieldset style="margin: 10px 0px 0px 0px">
                            <legend class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Sliding_Banner")%></legend>
                            <div id="div_button" runat="server" style="margin: 5px 0px 40px 10px;">
                                <div style="display: inline; float: left; margin-right: 6px">
                                    <div id="div_homesave" style="display: block; margin-left: 7px;">
                                        <asp:Button ID="Button1" runat="server" Text="Save" CssClass="button" OnClick="btn_saveHome_Click"
                                            OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_savehomeprocess');return a;" />
                                    </div>
                                    <div id="div_savehomeprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                            <div id="div_popupAction_Home" style="display: none; z-index: 999999; position: absolute;
                                margin: 28px 0px 0px 10px" onmouseover="show('home');" onmouseout="hide('home');">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="lnkbtncopy" runat="server" Text="Copy To" OnClientClick="javascript:CheckOne_newHome('copy'); return false;"
                                                        OnClick="lnkCopyBanners_click" Width="150px" Style="text-decoration: none" ForeColor="#333333"
                                                        Font-Size="11px"><%=objLanguage.GetLanguageConversion("Copy_To")%></asp:LinkButton></div>
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;
                                                    border-top: 1px solid #CBCBCB">
                                                    <asp:LinkButton ID="Button2" runat="server" Text="Delete Selected" OnClientClick="javascript:return CheckOne_Home();"
                                                        OnClick="DeleteHome_OnClick" Width="150px" Style="text-decoration: none" ForeColor="#333333"
                                                        Font-Size="11px"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div_grid">
                                <asp:UpdatePanel ID="up_bannerHome" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                    <ContentTemplate>
                                        <telerik:RadGrid ID="RadGrid_bannerHome" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                            BorderWidth="0  " OnNeedDataSource="grdPendingOrders_NeedDataSource_Home" AllowPaging="false"
                                            AllowSorting="false" AutoGenerateColumns="false" ClientSettings-AllowRowsDragDrop="true"
                                            PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="500" Width="600px"
                                            ShowGroupPanel="true" ShowStatusBar="true" OnRowDrop="grdPendingOrders_RowDrop_Home"
                                            OnItemDataBound="BannerHome_OnItemDataBound">
                                            <HeaderStyle Width="100px" Font-Bold="true" />
                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                            <PagerStyle Mode="NextPrevAndNumeric" />
                                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="bannerID" HorizontalAlign="NotSet"
                                                OverrideDataSourceControlSorting="true">
                                                <Columns>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderStyle-Wrap="false"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-Width="5%">
                                                        <HeaderTemplate>
                                                            <div style="float: left">
                                                                <div style="float: left; display: none;">
                                                                    <input id="checkAll_Copy1" runat="server" name="checkAll" type="checkbox" />
                                                                </div>
                                                                <div id="div_chk_Home" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                    -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit;">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="float: left">
                                                                                    <input id="checkAll_Home" runat="server" name="checkAll" onclick="checkAll_Home(this);"
                                                                                        type="checkbox" />
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <div style="float: left; padding: 0px 0px 0px 1px">
                                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow_Home" style="display: block;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="show('home');" alt='' />
                                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide_Home" style="display: none;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="hide('home');" alt='' />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div style="clear: both;">
                                                                </div>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="padding-left: 2px">
                                                                <input id="checkBox_Home" runat="server" name="Id" type="checkbox" onclick="CheckChanged_Home();"
                                                                    value='<%# DataBinder.Eval(Container, "DataItem.bannerID", "{0}") %>' />
                                                            </div>
                                                            <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                            <asp:LinkButton ID="lnk_CopyBanners" runat="server" OnClick="lnkCopyBanners_click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" HeaderText="Action"
                                                        HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Center" AllowFiltering="false" Visible="true" HeaderStyle-Wrap="false">
                                                        <HeaderTemplate>
                                                            <div style="float: right; padding-right: 3px">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("ReOrder")%></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                                background-repeat: no-repeat; position: static;" align="center">
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="bannerImage"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Images"
                                                        ItemStyle-Width="30%" UniqueName="page">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label2" runat="server"><%=objLanguage.GetLanguageConversion("Images") %></asp:Label></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <ul style="margin: 0; padding: 0;">
                                                                    <li style="list-style: none; float: left; display: inline; margin-right: 10px; margin: 0;
                                                                        padding: 0;"><a href='<%=filePath_img %><%#Eval("bannerImage")%>' class="preview">
                                                                            <asp:Image ID="imgbannerHome" runat="server" ToolTip='<%#Eval("bannerImage")%>' AlternateText='<%#Eval("bannerImage")%>'
                                                                                Style="cursor: pointer; width: 20px; height: 20px; border: none" />
                                                                            <asp:HiddenField ID="hdnImageHome" runat="server" Value='<%#Eval("bannerImage")%>' />
                                                                        </a></li>
                                                                </ul>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="bannerTitle"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Banner Name"
                                                        ItemStyle-Width="30%" SortExpression="Description" UniqueName="system" Visible="true">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label3" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Banner_Name")%></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <a href="manage_banner.aspx?&amp;page=h&amp;mode=edit&amp;bannerID=<%#Eval("bannerID")%>">
                                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                                    <asp:Label ID="Label5" runat="server" ToolTip='<%#Eval("bannerName")%>'><%#Eval("bannerName")%></asp:Label>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="11%" HeaderText="Action"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" UniqueName="restoreDefault">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label7" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Action") %></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:ImageButton ID="ImgButtonDelete" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                    CommandArgument='<%#Eval("bannerID")%>' OnCommand="DeleteImgHome_OnClick" Text="Delete"
                                                                    UniqueName="DeleteColumn" runat="server" ToolTip="Delete" OnClientClick="javascript:return imgbtnDelete_Click()">
                                                                </asp:ImageButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <NoRecordsTemplate>
                                                    <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                                </NoRecordsTemplate>
                                            </MasterTableView>
                                            <ClientSettings ReorderColumnsOnClient="true" EnableRowHoverStyle="true" AllowRowsDragDrop="true"
                                                AllowDragToGroup="true">
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="true" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </fieldset>
                    </div>
                    <div id="div_leftPanel" style="border: solid 1px gainsboro; display: none; margin: 0px 0px 0px 0px;">
                        <fieldset style="margin: 10px 0px 0px 10px">
                            <legend class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Add_Banner")%>
                            </legend>
                            <div style="padding-left: 5px; padding-top: 10px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_bannerName_LeftBanner" runat="server" Text="Banner Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Banner_Title")%></asp:Label>
                                    <%--<span style="color: red">*</span>--%>
                                </div>
                                <div style="float: left; width: 310px;" class="box">
                                    <asp:TextBox ID="txt_bannerName_LeftBanner" CssClass="textboxnew" runat="server"
                                        MaxLength="100" ></asp:TextBox> <%--onblur="CallonBlur(this.value,'spn_bannerName_LeftBanner');"--%>
                                </div>
                                <div id="spn_bannerName_LeftBanner" style="display: none; width: auto; float: left;
                                    margin-left: 2px">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Banner_Title")%></span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px;">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_image_LeftBanner" runat="server" Text="Image" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Image")%></asp:Label>
                                    <span style="color: red">*</span>
                                </div>
                                <div id="div_fuBanner_LeftBanner" runat="server" style="float: left; width: 310px;"
                                    class="box">
                                    <div style="float: left;">
                                        <asp:FileUpload ID="fuBanner_LeftBanner" size="19" CssClass="textboxnew_ForBanner"
                                            runat="server" />&nbsp;&nbsp;
                                    </div>
                                    <div style="float: left; padding: 2px 0px 0px 2px">
                                        <a href="javascript:void(0);" class="tooltip" title="Please use image in .JPG,.GIF,.PNG format only. Restrict the width of the Banner to 165px. Height can be any dimension.In case if you upload a bigger width banner, it will hide the excess width">
                                            <img alt="" id="img_help_LeftBanner" runat="server" src="../images/Help-icon.png"
                                                style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" />
                                        </a>
                                    </div>
                                </div>
                                <div id="spn_image_LeftBanner" runat="server" style="display: none; width: auto;
                                    float: left; margin-left: 2px">
                                    <div class="RFV_Message" id="spn_image_LeftBanner_selectImg" runat="server" style="display: none;
                                        width: auto;">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Select_Banner_Image")%></span>
                                    </div>
                                    <div class="RFV_Message" id="spn_image_LeftBanner_onlyImg" runat="server" style="display: none;">
                                        <asp:Label ID="lbl_error" runat="server" Text="(Please upload only image file)"></asp:Label>
                                    </div>
                                </div>
                                <div id="div_changeImage" runat="server" style="float: left; display: none; padding-top: 5px;
                                    padding-left: 5px;">
                                    <a href="#" id="lnkFileName" runat="server"></a>&nbsp;&nbsp; <a href="#" style="text-decoration: underline"
                                        onclick="javascript:ChangeImage();">
                                        <%=objLanguage.GetLanguageConversion("Change_Image")%>
                                    </a>
                                </div>
                                <asp:HiddenField ID="hdn_catagoryImageName_left" runat="server" />
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_url_LeftBanner" runat="server" Text="URL" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("URL")%></asp:Label>
                                </div>
                                <div style="float: left; width: 310px;" class="box">
                                    <asp:TextBox ID="txt_url_LeftBanner" CssClass="textboxnew" runat="server" Width="300px"></asp:TextBox>
                                </div>
                                <div id="spn_url_LeftBanner" style="display: none; float: left; margin-left: 2px">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_URL")%></span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px;">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_appearance_LeftBanner" runat="server" Text="Location" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Location")%></asp:Label>
                                </div>
                                <div class="box">
                                    <div style="float: left; width: auto; margin: 0px 0px 0px 0px;">
                                        <asp:PlaceHolder ID="ph_location_left" runat="server"></asp:PlaceHolder>
                                        <div style="clear: both;">
                                        </div>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10px; font-weight: 600; padding-right: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Please_Note") %>: </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10px;">
                                                        <%=objLanguage.GetLanguageConversion("Manage_Banner_B2B_Note")%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10px;">
                                                        <%=objLanguage.GetLanguageConversion("Manage_Banner_B2C_Note")%></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="float: left; margin: 5px 0px 0px 0px;">
                                        <a href="#" id="href_selectAll" onclick="selectAll_onclick('l')" runat="server" style="display: block;">
                                            <%=objLanguage.GetLanguageConversion("Select_All")%></a><a href="#" id="href_selectNone"
                                                onclick="selectNone_onclick('l')" runat="server" style="display: none;"><%=objLanguage.GetLanguageConversion("None")%>
                                            </a>
                                    </div>
                                </div>
                            </div>
                            <div class="bglabel" style="width: 20%; background-color: White;">
                                <asp:Label ID="Label2" runat="server" CssClass="normaltext"></asp:Label>
                            </div>
                            <div id="div10" runat="server" style="float: left; width: 330px;" class="box">
                                <div style="display: inline; float: left; padding: 3px; padding-left: 10px">
                                    <div id="div_btn_cancel_left" style="display: block;">
                                        <asp:Button ID="btn_cancel_left" runat="server" Text="Cancel" CssClass="button" OnClick="btn_cancel_left_click" />
                                    </div>
                                    <div style="width: 65px">
                                    </div>
                                    <div id="div_btn_cancel_leftprocess" class="button" align="center" style="width: 38px;
                                        display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="display: inline; float: left; padding: 3px">
                                    <div id="div_btnsaveleft" style="display: block">
                                        <asp:Button ID="btn_saveBannerLeft" runat="server" Text="Save" CssClass="button"
                                            OnClick="btn_saveBannerLeft_Click" OnClientClick="javascript:var a=validate('saveBannerLeft');if(a)loadingimage(this.id,'div_saveleftprocess');return a;" />
                                    </div>
                                    <div id="div_saveleftprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset style="margin: 10px 0px 0px 10px">
                            <legend class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Left_Banner")%></legend>
                            <div id="div_Save" runat="server" style="margin: 5px 0px 40px 10px">
                                <div style="display: inline; float: left; margin-right: 6px">
                                    <div id="div_btnbannerleft" style="display: block">
                                        <asp:Button ID="btn_saveLeft" runat="server" Text="Save" CssClass="button" OnClick="btn_saveLeft_Click"
                                            OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_bannerleftprocess');return a" />
                                    </div>
                                    <div id="div_bannerleftprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                            <div id="div_popupAction_Left" style="display: none; z-index: 999999; position: absolute;
                                margin: 28px 0px 0px 10px" onmouseover="show('left');" onmouseout="hide('left');">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="Linkcopy" runat="server" Text="Copy To" OnClientClick="javascript:CheckOne_newLeft('copy'); return false;"
                                                        Width="150px" Style="text-decoration: none" ForeColor="#333333" Font-Size="11px"><%=objLanguage.GetLanguageConversion("Copy_To")%></asp:LinkButton></div>
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;
                                                    border-top: 1px solid #CBCBCB">
                                                    <asp:LinkButton ID="Button3" runat="server" Text="Delete Selected" OnClientClick="javascript:return CheckOne_Left();"
                                                        OnClick="DeleteLeft_OnClick" Style="text-decoration: none" ForeColor="#333333"
                                                        Font-Size="11px"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div4">
                                <asp:UpdatePanel ID="up_bannerLeft" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                    <ContentTemplate>
                                        <telerik:RadGrid ID="RadGrid_bannerLeft" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                            BorderWidth="0" OnNeedDataSource="grdPendingOrders_NeedDataSource" AllowPaging="false"
                                            AllowSorting="false" AutoGenerateColumns="false" ClientSettings-AllowRowsDragDrop="true"
                                            PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="500" Width="600px"
                                            ShowGroupPanel="true" ShowStatusBar="true" OnRowDrop="grdPendingOrders_RowDrop"
                                            OnItemDataBound="BannerLeft_OnItemDataBound">
                                            <HeaderStyle Width="100px" Font-Bold="true" />
                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                            <PagerStyle Mode="NextPrevAndNumeric" />
                                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="bannerID" HorizontalAlign="NotSet"
                                                OverrideDataSourceControlSorting="true" Width="100%">
                                                <Columns>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderStyle-Wrap="false"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-Width="5%">
                                                        <HeaderTemplate>
                                                            <div style="float: left">
                                                                <div id="div_chk_Left" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                    -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit;">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="float: left">
                                                                                    <input id="checkAll_Left" runat="server" name="checkAll" onclick="checkAll_Left(this);"
                                                                                        type="checkbox" />
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <div style="float: left; padding: 0px 0px 0px 1px">
                                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow_Left" style="display: block;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="show('left');" alt='' />
                                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide_Left" style="display: none;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="hide('left');" alt='' />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div style="clear: both;">
                                                                </div>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="padding-left: 2px">
                                                                <input id="checkBox_Left" runat="server" name="Id" type="checkbox" onclick="CheckChanged_Left();"
                                                                    value='<%# DataBinder.Eval(Container, "DataItem.bannerID", "{0}") %>' />
                                                            </div>
                                                            <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" HeaderText="Reorder"
                                                        HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Center" AllowFiltering="false" Visible="true" HeaderStyle-Wrap="false">
                                                        <HeaderTemplate>
                                                            <div style="float: right; padding-right: 3px">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("ReOrder")%>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                                background-repeat: no-repeat; position: static;" align="center">
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="bannerImage"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Images"
                                                        ItemStyle-Width="30%" UniqueName="page" Visible="true">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label8" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Images") %></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <ul style="margin: 0; padding: 0;">
                                                                    <li style="list-style: none; float: left; display: inline; margin-right: 10px; margin: 0;
                                                                        padding: 0;"><a href='<%=filePath_img %><%#Eval("bannerImage")%>' class="preview">
                                                                            <asp:Image ID="imgbannerLeft" runat="server" ToolTip='<%#Eval("bannerImage")%>' AlternateText='<%#Eval("bannerImage")%>'
                                                                                Style="cursor: pointer; width: 20px; height: 20px; border: none" />
                                                                            <asp:HiddenField ID="hdnImageLeft" runat="server" Value='<%#Eval("bannerImage")%>' />
                                                                        </a></li>
                                                                </ul>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="bannerTitle"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Banner Name"
                                                        ItemStyle-Width="30%" SortExpression="Description" UniqueName="system" Visible="true">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label10" runat="server"><%=objLanguage.GetLanguageConversion("Banner_Name")%></asp:Label></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <a href="manage_banner.aspx?&amp;page=l&amp;mode=edit&amp;bannerID=<%#Eval("bannerID")%>">
                                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                                    <asp:Label ID="Label8" runat="server" ToolTip='<%#Eval("bannerTitle")%>'><%#Eval("bannerTitle")%></asp:Label>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="11%" HeaderText="Action"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" UniqueName="restoreDefault">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label11" runat="server"><%=objLanguage.GetLanguageConversion("Action")%></asp:Label></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:ImageButton ID="ImgButtonDeleteLeft" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                    CommandArgument='<%#Eval("bannerID")%>' OnCommand="DeleteImgLeft_OnClick" Text="Delete"
                                                                    UniqueName="DeleteColumn" runat="server" OnClientClick="javascript:return imgbtnDelete_Click()">
                                                                </asp:ImageButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <NoRecordsTemplate>
                                                    <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                                </NoRecordsTemplate>
                                            </MasterTableView>
                                            <ClientSettings ReorderColumnsOnClient="true" EnableRowHoverStyle="true" AllowRowsDragDrop="true"
                                                AllowDragToGroup="true">
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </fieldset>
                    </div>
                    <div id="div_rightPanel" style="border: solid 1px gainsboro; display: none; padding: 10px 0px 0px 10px">
                        <fieldset style="padding: 8px 0px 0px 10px">
                            <legend class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Add_Banner")%>
                            </legend>
                            <div style="padding-left: 5px; padding-top: 10px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_bannerName_RightBanner" runat="server" Text="Banner Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Banner_Title")%></asp:Label>
                                   <%-- <span style="color: red">*</span>--%>
                                </div>
                                <div style="float: left; width: auto;" class="box">
                                    <asp:TextBox ID="txt_bannerName_RightBanner" CssClass="textboxnew" runat="server"
                                        MaxLength="100"></asp:TextBox>  <%--onblur="CallonBlur(this.value,'spn_bannerName_RightBanner');"--%>
                                </div>
                                <div id="spn_bannerName_RightBanner" style="display: none; width: auto; float: left">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto; margin-left: 2px">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Banner_Title")%></span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_image_RightBanner" runat="server" Text="Image" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Image")%></asp:Label>
                                    <span style="color: red">*</span>
                                </div>
                                <div id="div_fuBanner_RightBanner" runat="server" style="float: left; width: auto;"
                                    class="box">
                                    <div style="float: left;">
                                        <asp:FileUpload ID="fuBanner_RightBanner" size="19" CssClass="textboxnew_ForBanner"
                                            runat="server" />&nbsp;&nbsp;
                                    </div>
                                    <div style="float: left; padding: 2px 0px 0px 2px">
                                        <a href="javascript:void(0);" class="tooltip" title="Please use image in .JPG,.GIF,.PNG format only. Restrict the width of the Banner to 165px. Height can be any dimension.In case if you upload a bigger width banner, it will hide the excess width">
                                            <img alt="" id="img_help_RightBanner" runat="server" src="../images/Help-icon.png"
                                                style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                class="tooltip" />
                                        </a>
                                    </div>
                                </div>
                                <div id="spn_image_RightBanner" runat="server" style="display: none; width: auto;
                                    float: left">
                                    <div class="RFV_Message" id="spn_image_RightBanner_selectImg" runat="server" style="display: none;
                                        width: auto;">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto; margin-left: 2px">
                                            <%=objLanguage.GetLanguageConversion("Please_Select_Banner_Image")%></span>
                                    </div>
                                    <div class="RFV_Message" id="spn_image_RightBanner_onlyImg" runat="server" style="display: none;">
                                        <asp:Label ID="Label3" runat="server" Text="(Please upload only image file)"></asp:Label>
                                    </div>
                                </div>
                                <div id="div_changeImage_Right" runat="server" style="float: left; display: none;
                                    padding-top: 5px; padding-left: 5px;">
                                    <a href="#" id="lnkFileName_Right" runat="server"></a>&nbsp;&nbsp; <a href="#" style="text-decoration: underline"
                                        onclick="javascript:ChangeImage_Right();">
                                        <%=objLanguage.GetLanguageConversion("Change_Image")%></a>
                                </div>
                                <asp:HiddenField ID="hdn_catagoryImageName_Right" runat="server" />
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_url_RightBanner" runat="server" Text="URL" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("URL")%></asp:Label>
                                </div>
                                <div style="float: left; width: 310px;" class="box">
                                    <asp:TextBox ID="txt_url_RightBanner" CssClass="textboxnew" runat="server" Width="300px"></asp:TextBox>
                                </div>
                                <div id="spn_url_RightBanner" style="display: none; float: left">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px; padding-right: 4px; width: auto;">
                                            <%=objLanguage.GetLanguageConversion("Please_Enter_Valid_URL")%>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div style="padding-left: 5px; padding-top: 0px">
                                <div class="bglabel" style="width: 20%;">
                                    <asp:Label ID="lbl_appearance_RightBanner" runat="server" Text="Location" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Location") %></asp:Label>
                                </div>
                                <div class="box">
                                    <div id="div_locationRight" runat="server" style="float: left; width: auto; margin: 0px 0px 0px 0px;">
                                        <asp:PlaceHolder ID="ph_location_right" runat="server"></asp:PlaceHolder>
                                        <div style="clear: both;">
                                        </div>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10px; font-weight: 600; padding-right: 5px;">
                                                        <%=objLanguage.GetLanguageConversion("Please_Note")%>
                                                        : </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10px;">
                                                        <%=objLanguage.GetLanguageConversion("Manage_Banner_B2B_Note")%></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span style="font-size: 10px;">
                                                        <%=objLanguage.GetLanguageConversion("Manage_Banner_B2C_Note")%></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="float: left; margin: 5px 0px 0px 0px;">
                                        <a href="#" id="href_selectAll_right" onclick="selectAll_onclick('h')" runat="server"
                                            style="display: block;">
                                            <%=objLanguage.GetLanguageConversion("Select_All")%></a><a href="#" id="href_selectNone_right"
                                                onclick="selectNone_onclick('h')" runat="server" style="display: none;"><%=objLanguage.GetLanguageConversion("None")%>
                                            </a>
                                    </div>
                                </div>
                            </div>
                            <div class="bglabel" style="width: 20%; background-color: White;">
                                <asp:Label ID="Label10" runat="server" CssClass="normaltext"></asp:Label>
                            </div>
                            <div id="div11" runat="server" style="float: left; width: 330px;" class="box">
                                <div style="display: inline; float: left; padding: 3px; padding-left: 10px">
                                    <div id="div_btn_cancel_right" style="display: block;">
                                        <asp:Button ID="btn_cancel_right" runat="server" Text="Cancel" CssClass="button"
                                            OnClick="btn_cancel_right_click" />
                                    </div>
                                    <div style="width: 65px">
                                    </div>
                                    <div id="div_btn_cancel_rightprocess" class="button" align="center" style="width: 38px;
                                        display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div style="display: inline; float: left; padding: 3px">
                                    <div id="div_btnbannerright" style="display: block">
                                        <asp:Button ID="btn_saveBannerRight" runat="server" Text="Save" CssClass="button"
                                            OnClick="btn_saveBannerRight_Click" OnClientClick="javascript:var a=validate('saveBannerRight');if(a)loadingimage(this.id,'div_bannerrightprocess');return a;" />
                                    </div>
                                    <div id="div_bannerrightprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                        <fieldset style="margin: 10px 0px 0px 0px">
                            <legend class="HeaderText">
                                <%=objLanguage.GetLanguageConversion("Right_Banner")%></legend>
                            <div id="div3" runat="server" style="margin: 5px 0px 40px 10px">
                                <div style="display: inline; float: left; margin-right: 6px">
                                    <div id="div_btnsaveright" style="display: block">
                                        <asp:Button ID="btn_saveRight" runat="server" Text="Save" CssClass="button" OnClick="btn_saveRight_Click"
                                            OnClientClick="javascript:var a=validate_Account();if(a)loadingimage(this.id,'div_saverightprocess');return a;" />
                                        <div id="div_saverightprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="div_popupAction_Right" style="display: none; z-index: 999999; position: absolute;
                                margin: 28px 0px 0px 10px" onmouseover="show('right');" onmouseout="hide('right');">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div style="width: 100%;">
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;">
                                                    <asp:LinkButton ID="lnkcpy" runat="server" Text="Copy To" OnClientClick="javascript:CheckOne_newRight('copy'); return false;"
                                                        Width="150px" Style="text-decoration: none" ForeColor="#333333" Font-Size="11px"><%=objLanguage.GetLanguageConversion("Copy_To")%></asp:LinkButton></div>
                                                <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 7px; width: 130px;
                                                    border-top: 1px solid #CBCBCB">
                                                    <asp:LinkButton ID="Button4" runat="server" Text="Delete Selected" OnClientClick="javascript:return CheckOne_Right();"
                                                        OnClick="DeleteRight_OnClick" Style="text-decoration: none" ForeColor="#333333"
                                                        Font-Size="11px"><%=objLanguage.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div5">
                                <asp:UpdatePanel ID="up_bannerRight" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                    <ContentTemplate>
                                        <telerik:RadGrid ID="RadGrid_bannerRight" runat="server" GridLines="None" AllowFilteringByColumn="false"
                                            OnNeedDataSource="grdPendingOrders_NeedDataSource_Right" AllowPaging="false"
                                            BorderWidth="0" AllowSorting="false" AutoGenerateColumns="false" ClientSettings-AllowRowsDragDrop="true"
                                            PagerStyle-AlwaysVisible="true" GroupingEnabled="false" PageSize="500" Width="600px"
                                            ShowGroupPanel="true" ShowStatusBar="true" OnRowDrop="grdPendingOrders_RowDrop_Right"
                                            OnItemDataBound="BannerRight_OnItemDataBound">
                                            <HeaderStyle Width="100px" Font-Bold="true" />
                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                            <PagerStyle Mode="NextPrevAndNumeric" />
                                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="bannerID" HorizontalAlign="NotSet"
                                                OverrideDataSourceControlSorting="true" Width="100%">
                                                <Columns>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="1%" HeaderStyle-Wrap="false"
                                                        ItemStyle-HorizontalAlign="left" ItemStyle-Width="1%">
                                                        <HeaderTemplate>
                                                            <div style="float: left">
                                                                <div id="div_chk_Right" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                    -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit;">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="float: left">
                                                                                    <input id="checkAll_Right" runat="server" name="checkAll" onclick="checkAll_Right(this);"
                                                                                        type="checkbox" />
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <div style="float: left; padding: 0px 0px 0px 1px">
                                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow_Right" style="display: block;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="show('right');" alt='' />
                                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide_Right" style="display: none;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="hide('right');" alt='' />
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div style="clear: both;">
                                                                </div>
                                                            </div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="padding-left: 2px">
                                                                <input id="checkBox_Right" runat="server" name="Id" type="checkbox" onclick="CheckChanged_Right();"
                                                                    value='<%# DataBinder.Eval(Container, "DataItem.bannerID", "{0}") %>' />
                                                            </div>
                                                            <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" HeaderText="Action"
                                                        HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Right"
                                                        ItemStyle-HorizontalAlign="Center" AllowFiltering="false" Visible="true" HeaderStyle-Wrap="false">
                                                        <HeaderTemplate>
                                                            <div style="float: right; padding-right: 3px">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("ReOrder")%></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                                background-repeat: no-repeat; position: static;" align="center">
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="bannerImage"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Images"
                                                        ItemStyle-Width="30%" UniqueName="page" Visible="true">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label12" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Images")%></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="float: left; width: 99%;">
                                                                <ul style="margin: 0; padding: 0;">
                                                                    <li style="list-style: none; float: left; display: inline; margin-right: 10px; margin: 0;
                                                                        padding: 0;"><a href='<%=filePath_img %><%#Eval("bannerImage")%>' class="preview">
                                                                            <asp:Image ID="imgbannerRight" runat="server" ToolTip='<%#Eval("bannerImage")%>'
                                                                                AlternateText='<%#Eval("bannerImage")%>' Style="cursor: pointer; width: 20px;
                                                                                height: 20px; border: none" />
                                                                            <asp:HiddenField ID="hdnImageRight" runat="server" Value='<%#Eval("bannerImage")%>' />
                                                                        </a></li>
                                                                </ul>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="bannerTitle"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Banner Name"
                                                        ItemStyle-Width="30%" SortExpression="Description" UniqueName="system" Visible="true">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label13" runat="server"><%=objLanguage.GetLanguageConversion("Banner_Name")%></asp:Label></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <a href="manage_banner.aspx?&amp;page=r&amp;mode=edit&amp;bannerID=<%#Eval("bannerID")%>">
                                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px">
                                                                    <asp:Label ID="Label7" runat="server" ToolTip='<%#Eval("bannerTitle")%>'><%#Eval("bannerTitle")%></asp:Label>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="11%" HeaderText="Action"
                                                        ItemStyle-HorizontalAlign="Right" ItemStyle-Width="10%" UniqueName="restoreDefault">
                                                        <HeaderTemplate>
                                                            <div>
                                                                <asp:Label ID="Label14" runat="server"><%=objLanguage.GetLanguageConversion("Action")%></asp:Label></div>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <div style="text-align: center;">
                                                                <asp:ImageButton ID="ImgButtonDeleteRight" ImageUrl="~/Images/erase.png" CommandName="Delete"
                                                                    CommandArgument='<%#Eval("bannerID")%>' OnCommand="DeleteImgRight_OnClick" Text="Delete"
                                                                    UniqueName="DeleteColumn" runat="server" OnClientClick="javascript:return imgbtnDelete_Click()">
                                                                </asp:ImageButton>
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                                <NoRecordsTemplate>
                                                    <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                                </NoRecordsTemplate>
                                            </MasterTableView>
                                            <ClientSettings ReorderColumnsOnClient="true" EnableRowHoverStyle="true" AllowRowsDragDrop="true"
                                                AllowDragToGroup="true">
                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hid_LeftBannerPaperID" runat="server" />
    <asp:HiddenField ID="hid_RightBannerPaperID" runat="server" />
    <script type="text/javascript" language="javascript">
        var dockID;

        var txt_bannerName_LeftBanner = document.getElementById("<%=txt_bannerName_LeftBanner.ClientID %>");
        var spn_bannerName_LeftBanner = document.getElementById("spn_bannerName_LeftBanner");
        var fuBanner_LeftBanner = document.getElementById("<%=fuBanner_LeftBanner.ClientID %>");
        var spn_image_LeftBanner = document.getElementById("<%=spn_image_LeftBanner.ClientID %>");
        var spn_image_LeftBanner_selectImg = document.getElementById("<%=spn_image_LeftBanner_selectImg.ClientID %>");
        var txt_url_LeftBanner = document.getElementById("<%=txt_url_LeftBanner.ClientID %>");
        var spn_url_LeftBanner = document.getElementById("spn_url_LeftBanner");

        var txt_bannerName_RightBanner = document.getElementById("<%=txt_bannerName_RightBanner.ClientID %>");
        var spn_bannerName_RightBanner = document.getElementById("spn_bannerName_RightBanner");
        var fuBanner_RightBanner = document.getElementById("<%=fuBanner_RightBanner.ClientID %>");
        var spn_image_RightBanner = document.getElementById("<%=spn_image_RightBanner.ClientID %>");
        var spn_image_RightBanner_selectImg = document.getElementById("<%=spn_image_RightBanner_selectImg.ClientID %>");
        var txt_url_RightBanner = document.getElementById("<%=txt_url_RightBanner.ClientID %>");
        var spn_url_RightBanner = document.getElementById("spn_url_RightBanner");

        var txt_bannerName_HomeBanner = document.getElementById("<%=txt_bannerName_HomeBanner.ClientID %>");
        var spn_bannerName_HomeBanner = document.getElementById("spn_bannerName_HomeBanner");
        var fuBanner_HomeBanner = document.getElementById("<%=fuBanner_HomeBanner.ClientID %>");
        var spn_image_HomeBanner = document.getElementById("<%=spn_image_HomeBanner.ClientID %>");
        var spn_image_HomeBanner_selectImg = document.getElementById("<%=spn_image_HomeBanner_selectImg.ClientID %>");
        var txt_url_HomeBanner = document.getElementById("<%=txt_url_HomeBanner.ClientID %>");
        var spn_url_HomeBanner = document.getElementById("spn_url_HomeBanner");
        var txt_bannerDescription_HomeBanner = document.getElementById("<%=txt_bannerDescription_HomeBanner.ClientID %>");
        var lbl_bannerDescription_HomeBanner = document.getElementById("<%=lbl_bannerDescription_HomeBanner.ClientID %>");
        var spn_bannerDesc_HomeBanner = document.getElementById("spn_bannerDesc_HomeBanner");

        var hdn_catagoryImageName_left = document.getElementById("<%=hdn_catagoryImageName_left.ClientID %>");
        var hdn_catagoryImageName_home = document.getElementById("<%=hdn_catagoryImageName_home.ClientID %>");
        var hdn_catagoryImageName_Right = document.getElementById("<%=hdn_catagoryImageName_Right.ClientID %>");

        var hid_LeftBannerPaperID = document.getElementById("<%=hid_LeftBannerPaperID.ClientID %>");
        var hid_RightBannerPaperID = document.getElementById("<%=hid_RightBannerPaperID.ClientID %>");

        var div_leftPanel = document.getElementById("div_leftPanel");
        var div_rightPanel = document.getElementById("div_rightPanel");
        var div_home = document.getElementById("div_home");
        var lbl_leftPanel = document.getElementById("<%=lbl_leftPanel.ClientID %>");
        var lbl_rightPanel = document.getElementById("<%=lbl_rightPanel.ClientID %>");
        var lbl_home = document.getElementById("<%=lbl_home.ClientID %>");
        var stay = '<%=stay %>';
        var cnt_checkBox_bannerLeft = '<%=cnt_checkBox_bannerLeft %>';
        var cnt_checkBox_bannerRight = '<%=cnt_checkBox_bannerRight %>';

        var href_selectAll = document.getElementById("<%=href_selectAll.ClientID %>");
        var href_selectNone = document.getElementById("<%=href_selectNone.ClientID %>");

        var href_selectAll_right = document.getElementById("<%=href_selectAll_right.ClientID %>");
        var href_selectNone_right = document.getElementById("<%=href_selectNone_right.ClientID %>");

        var img_actionsShow_Home = document.getElementById("img_actionsShow_Home");
        var img_actionsHide_Home = document.getElementById("img_actionsHide_Home");
        var div_chk_Home = document.getElementById("div_chk_Home");
        var div_popupAction_Home = document.getElementById("div_popupAction_Home");

        var img_actionsShow_Left = document.getElementById("img_actionsShow_Left");
        var img_actionsHide_Left = document.getElementById("img_actionsHide_Left");
        var div_chk_Left = document.getElementById("div_chk_Left");
        var div_popupAction_Left = document.getElementById("div_popupAction_Left");

        var img_actionsShow_Right = document.getElementById("img_actionsShow_Right");
        var img_actionsHide_Right = document.getElementById("img_actionsHide_Right");
        var div_chk_Right = document.getElementById("div_chk_Right");
        var div_popupAction_Right = document.getElementById("div_popupAction_Right");



        function SetHandleDock(dock, args) {
            dockID = dock.get_id() + "A";
            var dockIDNew = dockID.replace("ctl00_ContentPlaceHolder1_", "");
            dock.set_handle(document.getElementById(dockIDNew));
        }

        function imgbtnDelete_Click() {
            return confirm('<%=objLanguage.GetLanguageConversion("Delete_This_Record") %>');
        }

        function validate(val) {
            var flag = true;
            var IsImage = false;
            if (validate_Account()) {
                if (val == 'saveBannerLeft') {
                    //CallonBlur(txt_bannerName_LeftBanner.value, 'spn_bannerName_LeftBanner');

                    //if (spn_bannerName_LeftBanner.style.display == "block") {
                    //    flag = false;
                    //}
                    //else {
                    //    spn_bannerName_LeftBanner.style.display = "none";
                    //}

                    if (hdn_catagoryImageName_left.value == "") {
                        if (fuBanner_LeftBanner.value == "") {
                            spn_image_LeftBanner.style.display = "block";
                            spn_image_LeftBanner_selectImg.style.display = "block";
                            flag = false;
                        }
                        else {
                            IsImage = IsImageFormat(fuBanner_LeftBanner.value);
                            if (IsImage == false) {
                                spn_image_LeftBanner.style.display = "block";
                                spn_image_LeftBanner_selectImg.style.display = "block";
                                spn_image_LeftBanner_selectImg.innerHTML = "Please use images in .JPG, .GIF, .PNG formay only";
                                spn_image_LeftBanner.style.width = "auto";
                                flag = false;
                            }
                            else {
                                spn_image_LeftBanner.style.display = "none";
                            }
                        }
                    }
                    if (flag) {
                        for (var i = 0; i < cnt_checkBox_bannerLeft; i++) {
                            var chk_location_left = document.getElementById("ctl00_ContentPlaceHolder1_chk_location_left_" + i + "");
                            if (chk_location_left.checked == true) {
                                var lblPageID = document.getElementById("ctl00_ContentPlaceHolder1_lblPageID_" + i + "");
                                hid_LeftBannerPaperID.value = hid_LeftBannerPaperID.value + lblPageID.innerHTML + "µ";
                            }
                        }
                    }
                    if (flag == true) {
                        if (txt_url_LeftBanner.value != "") {
                            flag = isValidURL(txt_url_LeftBanner.value, 'left');
                        }
                    }
                    txt_bannerName_LeftBanner.focus();

                }

                if (val == 'saveBannerRight') {

                    //CallonBlur(txt_bannerName_RightBanner.value, 'spn_bannerName_RightBanner');
                    //if (spn_bannerName_RightBanner.style.display == "block") {
                    //    flag = false;
                    //}
                    //else {
                    //    spn_bannerName_RightBanner.style.display = "none";
                    //}


                    if (hdn_catagoryImageName_Right.value == "") {
                        if (fuBanner_RightBanner.value == "") {
                            spn_image_RightBanner.style.display = "block";
                            spn_image_RightBanner_selectImg.style.display = "block";
                            flag = false;
                        }
                        else {
                            IsImage = IsImageFormat(fuBanner_RightBanner.value);
                            if (IsImage == false) {
                                spn_image_RightBanner.style.display = "block";
                                spn_image_RightBanner_selectImg.style.display = "block";
                                spn_image_RightBanner_selectImg.innerHTML = "Please use images in .JPG, .GIF, .PNG formay only";
                                spn_image_RightBanner.style.width = "auto";
                                flag = false;
                            }
                            else {
                                spn_image_RightBanner.style.display = "none";
                            }
                        }
                    }
                    if (flag) {
                        for (var i = 0; i < cnt_checkBox_bannerRight; i++) {
                            var chk_location_Right = document.getElementById("ctl00_ContentPlaceHolder1_chk_location_right_" + i + "");
                            if (chk_location_Right.checked == true) {
                                var lblPageID = document.getElementById("ctl00_ContentPlaceHolder1_lblPageRightID_" + i + "");
                                hid_RightBannerPaperID.value = hid_RightBannerPaperID.value + lblPageID.innerHTML + "µ";
                            }
                        }
                    }
                    if (flag == true) {
                        if (txt_url_RightBanner.value != "") {
                            flag = isValidURL(txt_url_RightBanner.value, 'right');
                        }
                    }
                    txt_bannerName_RightBanner.focus();
                }

                if (val == 'saveBannerHome') {


                    //CallonBlur(txt_bannerName_HomeBanner.value, 'spn_bannerName_HomeBanner');

                    //if (spn_bannerName_HomeBanner.style.display == "block") {
                    //    flag = false;
                    //}
                    //else {
                    //    spn_bannerName_HomeBanner.style.display = "none";
                    //}


                    if (hdn_catagoryImageName_home.value == "") {
                        if (fuBanner_HomeBanner.value == "") {
                            spn_image_HomeBanner.style.display = "block";
                            spn_image_HomeBanner_selectImg.style.display = "block";
                            flag = false;
                        }
                        else {
                            IsImage = IsImageFormat(fuBanner_HomeBanner.value);
                            if (IsImage == false) {
                                spn_image_HomeBanner.style.display = "block";
                                spn_image_HomeBanner_selectImg.style.display = "block";
                                spn_image_HomeBanner_selectImg.innerHTML = "Please use images in .JPG, .GIF, .PNG formay only";
                                spn_image_HomeBanner.style.width = "auto";
                                flag = false;
                            }
                            else {
                                spn_image_HomeBanner.style.display = "none";
                            }
                        }
                    }
                    if (flag == true) {
                        if (txt_url_HomeBanner.value != "") {
                            flag = isValidURL(txt_url_HomeBanner.value, 'home');
                        }
                    }
                }

                if (flag) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }

        }

        function IsImageFormat(val) {
            var ext = val.split('.');
            var cut = ext[1];
            if (cut.toLowerCase() == "jpg" || cut.toLowerCase() == "png" || cut.toLowerCase() == "tif" || cut.toLowerCase() == "jpeg" || cut.toLowerCase() == "bmp" ||
                    cut.toLowerCase() == "jpf" || cut.toLowerCase() == "gif" || cut.toLowerCase() == "msp" || cut.toLowerCase() == "mng" || cut.toLowerCase() == "pct" ||
                    cut.toLowerCase() == "yuv" || cut.toLowerCase() == "tiff" || cut.toLowerCase() == "mng" || cut.toLowerCase() == "jfif" || cut.toLowerCase() == "dib"
                    || cut.toLowerCase() == "jpe") {
                return true;
            }
            else
                return false;
        }

        function isValidURL(url, banner) {
            var RegExp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/;

            if (banner == 'home') {
                if (RegExp.test(url)) {
                    spn_url_HomeBanner.style.display = "none";
                    return true;
                } else {
                    spn_url_HomeBanner.style.display = "block";
                    return false;
                }
            }
            if (banner == 'left') {
                if (RegExp.test(url)) {
                    spn_url_LeftBanner.style.display = "none";
                    return true;
                } else {
                    spn_url_LeftBanner.style.display = "block";
                    return false;
                }
            }
            if (banner == 'right') {
                if (RegExp.test(url)) {
                    spn_url_RightBanner.style.display = "none";
                    return true;
                } else {
                    spn_url_RightBanner.style.display = "block";
                    return false;
                }
            }
        }

        function OnDeleteClicked_CheckboxChecked1() {
            if (confirm("Are you sure tou want to delete?")) {
                var chkidnew = ImageButtonID.replace("imgDelete", "Id");
                var chkid = document.getElementById(chkidnew);
                chkid.checked = true;
                return true;
            }
            else return false;
        }

        function ChangeImage() {
            document.getElementById("<%=div_fuBanner_LeftBanner.ClientID %>").style.display = "block";
            document.getElementById("<%=div_changeImage.ClientID %>").style.display = "none";
            hdn_catagoryImageName_left.value = "";
        }

        function ChangeImage_Right() {
            document.getElementById("<%=div_fuBanner_RightBanner.ClientID %>").style.display = "block";
            document.getElementById("<%=div_changeImage_Right.ClientID %>").style.display = "none";
            hdn_catagoryImageName_Right.value = "";
        }

        function ChangeImage_home() {
            document.getElementById("<%=div_fuBanner_HomeBanner.ClientID %>").style.display = "block";
            document.getElementById("<%=div_changeImage_Home.ClientID %>").style.display = "none";
            hdn_catagoryImageName_home.value = "";
        }

        function selectAll_onclick(type) {
            if (type == 'l') {
                for (var i = 0; i < cnt_checkBox_bannerLeft; i++) {
                    var chk_location_left = document.getElementById("ctl00_ContentPlaceHolder1_chk_location_left_" + i + "");
                    chk_location_left.checked = true;
                    href_selectAll.style.display = "none";
                    href_selectNone.style.display = "block";
                }
            }
            else {
                for (var j = 0; j < cnt_checkBox_bannerRight; j++) {
                    var chk_location_right = document.getElementById("ctl00_ContentPlaceHolder1_chk_location_right_" + j + "");
                    chk_location_right.checked = true;
                    href_selectAll_right.style.display = "none";
                    href_selectNone_right.style.display = "block";
                }
            }
        }

        function selectNone_onclick(type) {
            if (type == 'l') {
                for (var i = 0; i < cnt_checkBox_bannerLeft; i++) {
                    var chk_location_left = document.getElementById("ctl00_ContentPlaceHolder1_chk_location_left_" + i + "");
                    chk_location_left.checked = false;
                    href_selectAll.style.display = "block";
                    href_selectNone.style.display = "none";
                }
            }
            else {
                for (var j = 0; j < cnt_checkBox_bannerRight; j++) {
                    var chk_location_right = document.getElementById("ctl00_ContentPlaceHolder1_chk_location_right_" + j + "");
                    chk_location_right.checked = false;
                    href_selectAll_right.style.display = "block";
                    href_selectNone_right.style.display = "none";
                }
            }
        }

        function gettabs(value) {
            if (value == 'l') {


                div_leftPanel.style.display = "block";
                div_rightPanel.style.display = "none";
                div_home.style.display = "none";

                lbl_leftPanel.style.color = "Red"
                lbl_rightPanel.style.color = "black"
                lbl_home.style.color = "black"

            }
            else if (value == 'r') {
                div_leftPanel.style.display = "none";
                div_rightPanel.style.display = "block";

                div_home.style.display = "none";

                lbl_leftPanel.style.color = "black"
                lbl_rightPanel.style.color = "Red"
                lbl_home.style.color = "black"
            }
            else {
                div_leftPanel.style.display = "none";
                div_rightPanel.style.display = "none";
                div_home.style.display = "block";

                lbl_leftPanel.style.color = "black"
                lbl_rightPanel.style.color = "black"
                lbl_home.style.color = "Red"
            }
        }

        gettabs(stay);

        function CheckOne_Home() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Home') != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            if (Number(Counter) == 0) {
                alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Delete") %>');
                return false;
            }
            else {
                return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');
            }
        }

        function CheckOne_Left() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Left') != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            if (Number(Counter) == 0) {
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');
            }
        }

        function CheckOne_Right() {
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Right') != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            if (Number(Counter) == 0) {
                alert("Please check at least one row to Delete");
                return false;
            }
            else {
                return window.confirm('<%=objLanguage.GetLanguageConversion("Record_Delete_Confirmation")%>');
            }
        }

        function checkAll_Home(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Home') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }

        function checkAll_Left(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Left') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }

        function checkAll_Right(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Right') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }

        function CheckOne_newHome(val) {

            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf("checkBox_Home") != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            hide('home');

            if (Number(Counter) == 0) {
                if (val == "copy")
                    alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Copy") %>');

                return false;
            }
            else {
                if (val == "copy") {
                    if (true) {
                        Show_CopyAccounts('home');
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }

        function CheckOne_newLeft(val) {

            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf("checkBox_Left") != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            hide('left');

            if (Number(Counter) == 0) {
                if (val == "copy")
                    alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Copy") %>');
                return false;
            }
            else {
                if (val == "copy") {
                    if (true) {
                        Show_CopyAccounts('left');
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }


        function CheckOne_newRight(val) {

            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf("checkBox_Right") != -1) {
                    if (!e.disabled) {
                        if (e.checked)
                            Counter = Number(Counter) + 1;
                    }
                }
            }

            hide('right');

            if (Number(Counter) == 0) {
                if (val == "copy")
                    alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Copy") %>');
                return false;
            }
            else {
                if (val == "copy") {
                    if (true) {
                        Show_CopyAccounts('right');
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }

        function Show_CopyAccounts(val) {
            if (val == 'home') {
                document.cookie = "CopyBanners=" + val;
                document.getElementById("ctl00_ContentPlaceHolder1_ctl04_RadWindowShoppingCart_C_div_accountLocation").style.display = "none";
            }
            if (val == 'left') {
                document.cookie = "CopyBanners=" + val;
                document.getElementById("ctl00_ContentPlaceHolder1_ctl04_RadWindowShoppingCart_C_div_accountLocation").style.display = "block";
            }
            if (val == 'right') {
                document.cookie = "CopyBanners=" + val;
                document.getElementById("ctl00_ContentPlaceHolder1_ctl04_RadWindowShoppingCart_C_div_accountLocation").style.display = "block";
            }
            showDivPopupCenter('div_managebanner', '200');
            ShowPopUpManageBanner();
            RadWindowclose();
        }

        function show(val) {
            if (val == 'home') {
                img_actionsHide_Home.style.display = "block";
                img_actionsShow_Home.style.display = "none";

                div_chk_Home.style.border = "inset 1px";
                div_chk_Home.style.background = "#CBCBCB";

                div_popupAction_Home.style.display = "block";
            }
            if (val == 'left') {
                img_actionsHide_Left.style.display = "block";
                img_actionsShow_Left.style.display = "none";

                div_chk_Left.style.border = "inset 1px";
                div_chk_Left.style.background = "#CBCBCB";

                div_popupAction_Left.style.display = "block";
            }
            if (val == 'right') {
                img_actionsHide_Right.style.display = "block";
                img_actionsShow_Right.style.display = "none";

                div_chk_Right.style.border = "inset 1px";
                div_chk_Right.style.background = "#CBCBCB";

                div_popupAction_Right.style.display = "block";
            }
        }

        function hide(val) {
            if (val == 'home') {
                img_actionsHide_Home.style.display = "none";
                img_actionsShow_Home.style.display = "block";

                div_chk_Home.style.border = "outset 1px";
                div_chk_Home.style.background = "";

                div_popupAction_Home.style.display = "none";
            }
            if (val == 'left') {
                img_actionsHide_Left.style.display = "none";
                img_actionsShow_Left.style.display = "block";

                div_chk_Left.style.border = "outset 1px";
                div_chk_Left.style.background = "";

                div_popupAction_Left.style.display = "none";
            }
            if (val == 'right') {
                img_actionsHide_Right.style.display = "none";
                img_actionsShow_Right.style.display = "block";

                div_chk_Right.style.border = "outset 1px";
                div_chk_Right.style.background = "";

                div_popupAction_Right.style.display = "none";
            }
        }

    </script>
    <script language="javascript" type="text/javascript">
        function CheckChanged_Left() {
            var frm = document.forms[0];
            var boolAllChecked;
            boolAllChecked = true;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Left') != -1)
                    if (e.checked == false) {
                        boolAllChecked = false;
                        break;
                    }
            }
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll_Left') != -1) {
                    if (boolAllChecked == false) {
                        e.checked = false;
                        // alert(e.name);
                    }
                    else
                        e.checked = true;
                    break;
                }
            }
        }

        function CheckChanged_Home() {
            var frm = document.forms[0];
            var boolAllChecked;
            boolAllChecked = true;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Home') != -1)
                    if (e.checked == false) {
                        boolAllChecked = false;
                        break;
                    }
            }
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll_Home') != -1) {
                    if (boolAllChecked == false) {
                        e.checked = false;
                        //alert(e.name);
                    }
                    else
                        e.checked = true;
                    break;
                }
            }
        }

        function CheckChanged_Right() {
            var frm = document.forms[0];
            var boolAllChecked;
            boolAllChecked = true;

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Right') != -1)
                    if (e.checked == false) {
                        boolAllChecked = false;
                        break;
                    }
            }

            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkAll_Right') != -1) {
                    if (boolAllChecked == false) {
                        e.checked = false;
                    }
                    else
                        e.checked = true;
                    break;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
