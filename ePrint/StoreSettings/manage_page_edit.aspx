<%@ page title="" language="C#" masterpagefile="~/Templates/SettingsEstore.master" autoeventwireup="true" CodeBehind="manage_page_edit.aspx.cs" Inherits="ePrint.StoreSettings.manage_page_edit" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/usercontrol/StoreSettings/account_list.ascx" TagName="accountList"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
            <asp:ServiceReference Path="~/ContentManagementWebService.asmx" />
        </Services>
    </asp:ScriptManager>--%>
    <asp:ScriptManagerProxy ID="SMP" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
            <asp:ServiceReference Path="~/ContentManagementWebService.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <script type="text/javascript" language="javascript" src="../js/ProductListCustomize.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="../js/floating-window.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/item/general.js?VN='<%=VersionNumber%>" type="text/javascript?VN='<%=VersionNumber%>"></script>
    <script src="../js/jquery-ui-1.8.17.custom.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid_featuredProducts">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_featuredProducts" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_seletedProducts" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid_seletedProducts">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_featuredProducts" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_seletedProducts" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnMove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_featuredProducts" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_seletedProducts" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReMove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_featuredProducts" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_seletedProducts" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadScriptBlock runat="server" ID="scriptBlock">
        <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
            width: 50%" align="center">
            <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
                Opacity="100" runat="server" Width="1000" Height="620" OnClientClose="RadWinClose"
                Behaviors="Close,Move,Reload,Resize">
            </telerik:RadWindowManager>
        </div>
        <script type="text/javascript">
            function onRowDropping(sender, args) {
                if (sender.get_id() == "<%=RadGrid_featuredProducts.ClientID %>") {

                    var node = args.get_destinationHtmlElement();
                    if (!isChildOf('<%=RadGrid_seletedProducts.ClientID %>', node) && !isChildOf('<%=RadGrid_featuredProducts.ClientID %>', node)) {
                        args.set_cancel(true);
                    }
                }
            }

            function isChildOf(parentId, element) {
                while (element) {
                    if (element.id && element.id.indexOf(parentId) > -1) {
                        return true;
                    }
                    element = element.parentNode;
                }
                return false;
            }
        </script>
    </telerik:RadScriptBlock>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <!--POPUP START-->
    <div>
        <%--<UC:accountList ID="AccountList" runat="server" />--%>
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="plhUploadImages" runat="server"></asp:PlaceHolder>
    </div>
    <!--POPUP END-->
    <div style="float: left; width: 1265px;" class="estore_settingBox">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Settings")%>:&nbsp;
                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp;
                                        <%--<a href="#?"
                                            rel="popup1" class="poplight" style="color: White; text-decoration: underline">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"></asp:Label>
                                        </a></span>--%>
                                        <a id="A1" href="javascript:void(0);" style="color: White; text-decoration: underline"
                                            runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change")%></asp:Label>
                                        </a><a id="A2" href="javascript:void(0);" style="color: White; text-decoration: underline"
                                            runat="server" onclick="Show_uploadImagesDiv();" visible="false">
                                            <asp:Label ID="lbl_UploadImages" runat="server" Text="Upload Images" Visible="false"></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div class="manageedit">
                <div align="left" style="width: 100%; border: 0px solid red">
                    <div style="width: 60%">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div style="display: block">
                    <div style="width: 100%; display: block" id="divtabs">
                        <div id="ynnav">
                            <ul>
                                <li id="li_Content" runat="server" style="cursor: pointer; float: left; clear: right;">
                                    <div id="divContent" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                                        float: left; line-height: 20px; margin-right: 2px; display: block">
                                        <b>
                                            <asp:Label ID="lbl_Content" runat="server" Text="Content" Style="color: Red;" onclick="javascript:gettabs('c');"><%=objLanguage.GetLanguageConversion("Content")%></asp:Label>
                                        </b>
                                    </div>
                                </li>
                                <li id="li_Properties" runat="server" style="cursor: pointer; float: left; clear: right;
                                    display: block">
                                    <div id="divProperties" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                                        float: left; line-height: 20px; margin-right: 2px; filter: opaci">
                                        <b>
                                            <asp:Label ID="lbl_Properties" runat="server" Text="Properties" Style="color: Black;"
                                                onclick="javascript:gettabs('p');"><%=objLanguage.GetLanguageConversion("Properties")%></asp:Label>
                                        </b>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                    <div id="div_ContentMain" style="padding-right: 2px;">
                        <div id="div_Content" style="border: solid 1px gainsboro; padding: 10px 0px 10px 10px;
                            display: block">
                            <div class="bglabel" style="width: 190px">
                                <asp:Label ID="lbl_title" runat="server" Text="Page Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Page_Title")%></asp:Label>
                                <span style="color: red">*</span>
                            </div>
                            <div class="box">
                                <div style="float: left;">
                                    <div>
                                        <div style="float: left; margin: 0px 0px 0px 0px;">
                                            <asp:TextBox ID="txt_title" runat="server" CssClass="textboxnew" MaxLength="300"
                                                onblur="javascript:CheckDuplicate_pages(this.value);"></asp:TextBox>&nbsp;
                                        </div>
                                        <div id="div_imgtitle" runat="server" style="float: left; margin: 3px 0px 0px 0px;
                                            display: none;">
                                            <asp:Image ID="img_title" runat="server" Visible="false" ImageUrl="~/images/StoreImages/icon_tooltip.gif" />
                                        </div>
                                    </div>
                                    <div id="div_pageTitle" style="display: none; width: auto; float: left">
                                        <div class="RFV_Message">
                                            <span id="spn_Pagetitle" style="float: left; width: auto; padding-right: 4px; padding-left: 4px">
                                                <%=objLanguage.GetLanguageConversion("Please_Enter_Page_Title")%></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both">
                            </div>
                            <div id="div_body" runat="server">
                                <div class="bglabel" style="width: 190px">
                                    <asp:Label ID="lbl_body" runat="server" Text="Body" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Body")%></asp:Label>
                                </div>
                                <div>
                                    <div style="float: left; width: 800px;">
                                        <div class="box">
                                            <div id="divFckEditor" style="border: 0px solid; float: left;">
                                                <%--   <FCKeditorV2:FCKeditor ID="FCKeditor1" runat="server" BasePath="~/fckEditor/">
                                                </FCKeditorV2:FCKeditor>--%>
                                                <telerik:RadEditor ID="RadEditor1" runat="server" EditModes="Design,Html" ToolsFile="~/RadEditorDialogs/Tools/tools.xml"
                                                    EnableResize="false" ExternalDialogsPath="~/RadEditorDialogs" ContentFilters="MakeUrlsAbsolute"
                                                    ContentAreaMode="Iframe" imagemanager-viewmode="Grid" OnClientLoad="OnClientLoad">
                                                    <Content>
                                                                          
                                                    </Content>
                                                    <CssFiles>
                                                        <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                                    </CssFiles>
                                                </telerik:RadEditor>
                                                <style>
                                                    .reContentCell
                                                    {
                                                        max-width: 797px;
                                                    }
                                                </style>
                                                <div class="only5px">
                                                </div>
                                                <span id="spn_txtDescription_length" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Max_Length_Of_Textbox_Is_4000")%>
                                                </span><span id="spn_txtphrasetext" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px;">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Email_Body")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                            <div id="div_homeCustomize" runat="server" style="display: none;">
                                <div>
                                    <div class="bglabel" style="width: 190px">
                                        <asp:Label ID="lbl_slidingBanner" runat="server" Text="Sliding Banners" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Sliding_Banners")%></asp:Label>
                                    </div>
                                    <div class="box">
                                        <div style="float: left;">
                                            <asp:CheckBox ID="chk_slidingBanner" runat="server" Checked="true" />
                                            <asp:Image ID="img_slidingBanner" runat="server" Visible="false" ImageUrl="~/images/StoreImages/icon_tooltip.gif" />
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                                <div>
                                    <div class="bglabel" style="width: 190px">
                                        <asp:Label ID="lbl_centerPanelText" runat="server" Text="Center Panel Text" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Center_Panel_Text")%></asp:Label>
                                        <%--<span style="color: red">*</span>--%>
                                    </div>
                                    <div class="box">
                                        <div style="float: left;">
                                            <div style="float: left; margin: 0px 0px 0px 0px;">
                                                <asp:TextBox ID="txt_centerPaneltext" runat="server" CssClass="textboxnew"></asp:TextBox>  <%--onblur="CallonBlur(this.value,'spn_centerPaneltext');"--%>
                                            </div>
                                            <div style="float: left; margin: 3px 0px 0px 5px;">
                                                <asp:Image ID="img_centerPaneltext" runat="server" Visible="false" ImageUrl="~/images/StoreImages/icon_tooltip.gif" />
                                            </div>
                                            <div id="div_centerPaneltext">
                                                <span id="spn_centerPaneltext" class="spanerrorMsg" style="display: none; width: auto; padding-right: 4px; padding-left: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Center_Panel_Text")%>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                                <div>
                                    <div class="bglabel" style="width: 190px;">
                                        <asp:Label ID="lbl_centerPanelOption" runat="server" Text="Center Panel Option" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Center_Panel_Option")%></asp:Label>
                                    </div>
                                    <div class="box" style="width: 82%;">
                                        <div>
                                            <div style="float: left; margin: 3px 0px 0px 0px;">
                                                <div style="float: left; margin: 0px 0px 0px 0px;">
                                                    <asp:RadioButton ID="rdn_new" runat="server" GroupName="Option" Checked="true" onclick="ShowFCK('no','new')" />
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 0px;">
                                                    <asp:Label ID="lbl_NP" runat="server" Text="New Products  (Latest 6-8 products as per design)"><%=objLanguage.GetLanguageConversion("New_Products_Latest_Products_As_Per_Design")%></asp:Label>
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 5px;">
                                                    <asp:Image ID="img_new" runat="server" Visible="false" ImageUrl="~/images/StoreImages/icon_tooltip.gif" />
                                                </div>
                                            </div>
                                            <div style="float: left; margin: 3px 0px 0px 0px;">
                                                <div style="float: left; margin: 0px 0px 0px 0px;">
                                                    <asp:RadioButton ID="rdn_Feature" runat="server" GroupName="Option" Checked="false"
                                                        onclick="ShowFCK('no','featured')" />
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 0px;">
                                                    <asp:Label ID="lbl_FP" runat="server" Text="Featured Products"><%=objLanguage.GetLanguageConversion("Featured_Products")%></asp:Label>
                                                    <asp:Label ID="Label2" runat="server" Text="" Style="color: Gray; font-size: 10px"></asp:Label>
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 5px;">
                                                    <asp:Image ID="img_Feature" runat="server" Visible="false" ImageUrl="~/images/StoreImages/icon_tooltip.gif" />
                                                </div>
                                            </div>
                                            <div style="float: left; margin: 5px 0px 0px 0px;">
                                                <div style="float: left; margin: 0px 0px 0px 0px;">
                                                    <asp:RadioButton ID="rdn_customize" runat="server" GroupName="Option" Checked="false"
                                                        onclick="ShowFCK('yes','html')" />
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 0px;">
                                                    <asp:Label ID="lbl_CU" runat="server" Text="HTML"><%=objLanguage.GetLanguageConversion("HTML")%></asp:Label>
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 5px;">
                                                    <asp:Image ID="img_customize" runat="server" Visible="false" ImageUrl="~/images/StoreImages/icon_tooltip.gif" />
                                                </div>
                                            </div>
                                            <div style="float: left; margin: 5px 0px 0px 0px; display: none;">
                                                <div style="float: left; margin: 0px 0px 0px 0px;">
                                                    <asp:RadioButton ID="rdbCustomizeNew" runat="server" GroupName="Option" Checked="false"
                                                        onclick="ShowFCK('new','custom')" />
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 0px;">
                                                    <asp:Label ID="Label4" runat="server" Text="Custom"><%=objLanguage.GetLanguageConversion("Custom")%></asp:Label>
                                                </div>
                                                <div style="float: left; margin: 3px 0px 0px 5px;">
                                                    <asp:Image ID="Image1" runat="server" Visible="false" ImageUrl="~/images/StoreImages/icon_tooltip.gif" />
                                                </div>
                                            </div>
                                        </div>
                                        <div style="float: left; width: 100%;">
                                            <div id="div_featuredProductsMain" runat="server" style="float: left; margin: 5px 0px 0px 0px;
                                                width: 100%; height: auto; display: none;">
                                                <fieldset>
                                                    <legend id="lgdfeatured" runat="server">Featured Products</legend>
                                                    <div id="div_featuredProducts" style="float: left; margin: 0px 0px 0px 3px; width: 45%;">
                                                        <strong><span style="float: left; padding-left: 0%;">
                                                            <asp:Label runat="server"><%=objLanguage.GetLanguageConversion("Available_Options")%></asp:Label></span></strong>
                                                        <div class="only5px">
                                                        </div>
                                                        <telerik:RadGrid ID="RadGrid_featuredProducts" runat="server" AllowPaging="true"
                                                            Style="border-top-width: 0;" AllowFilteringByColumn="true" AllowSorting="false"
                                                            AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true" GroupingEnabled="false"
                                                            PageSize="50" Width="100%" ShowGroupPanel="true" ShowStatusBar="true" HeaderStyle-Font-Bold="true"
                                                            OnRowDrop="grdAvailableOrders_RowDrop" OnNeedDataSource="RadGrid_featuredProducts_OnNeedDataSource">
                                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                            <PagerStyle Mode="NextPrevAndNumeric" />
                                                            <MasterTableView DataKeyNames="PriceCatalogueID" OverrideDataSourceControlSorting="true"
                                                                AllowFilteringByColumn="false" CommandItemDisplay="Top" Width="100%">
                                                                <CommandItemTemplate>
                                                                    <%--<table class="rgCommandTable" border="0" style="width: 100%;">
                                                                        <tr>
                                                                            <td align="left">
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:LinkButton ID="btnclrFilters_FP" runat="server" Style="text-decoration: underline;
                                                                                    cursor: pointer" Text='<%#"Clear all Filters"%>' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>--%>
                                                                </CommandItemTemplate>
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn AllowFiltering="true" CurrentFilterFunction="Contains"
                                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" HeaderStyle-Wrap="false"
                                                                        ItemStyle-HorizontalAlign="left" ItemStyle-Width="2%">
                                                                        <HeaderTemplate>
                                                                            <input id="checkAll_FP" runat="server" name="checkAll" onclick="checkAll_FP_onclick(this);"
                                                                                type="checkbox" /></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <input id="checkBox_FP" runat="server" name="Id" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>' />
                                                                            <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="PriceCatalogueCategoryName" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="10%" HeaderText="Category Name" ItemStyle-Width="29%" SortExpression="PriceCatalogueCategoryName"
                                                                        AllowFiltering="true" UniqueName="last" Visible="true">
                                                                        <HeaderTemplate>
                                                                            <div>
                                                                                <asp:Label ID="lblcat" runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Category_Name")%></div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 99%; overflow: hidden; height: 15px; text-align: left">
                                                                                <asp:Label ID="lbl_CatagoryName" runat="server" Text='<%#Eval("PriceCatalogueCategoryName")%>'>
                                                                                </asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="CatalogueName" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="10%" HeaderText="Products Name" ItemStyle-Width="29%" SortExpression="CatalogueName"
                                                                        AllowFiltering="true" UniqueName="last" Visible="true">
                                                                        <HeaderTemplate>
                                                                            <div>
                                                                                <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Products_Name")%></div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 99%; overflow: hidden; height: 15px; text-align: left">
                                                                                <asp:Label ID="lbl_CatalogueName" runat="server" Text='<%#Eval("CatalogueName")%>'>
                                                                                </asp:Label>
                                                                                <asp:HiddenField ID="hdn_PriceCatalogueID_Available" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>' />
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                <NoRecordsTemplate>
                                                                    <div style="padding: 0px 0px 0px 10px">
                                                                        <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                                                    </div>
                                                                </NoRecordsTemplate>
                                                            </MasterTableView>
                                                            <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                                                AllowDragToGroup="false" Scrolling-AllowScroll="true">
                                                                <ClientEvents OnRowDropping="onRowDropping" />
                                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                                <Scrolling UseStaticHeaders="true" ScrollHeight="270" />
                                                            </ClientSettings>
                                                        </telerik:RadGrid>
                                                    </div>
                                                    <div id="div_Spliter" style="float: left; width: 9%;">
                                                        <div style="margin: 60px 0px 0px 0px; text-align: center;">
                                                            <asp:Button ID="btnMove" runat="server" ToolTip='Move' Text=">>" CssClass="button"
                                                                OnClick="BtnMove_Onclick" OnClientClick="javascript:CallSelect('move');" />
                                                        </div>
                                                        <div style="margin: 10px 0px 0px 0px; text-align: center;">
                                                            <asp:Button ID="btnReMove" runat="server" ToolTip='Remove' Text="<<" CssClass="button"
                                                                OnClick="BtnReMove_Onclick" OnClientClick="javascript:CallSelect('remove');" />
                                                        </div>
                                                    </div>
                                                    <div id="div_seletedProducts" style="float: left; width: 45%;">
                                                        <strong><span style="float: left; padding-left: 0%;">
                                                            <asp:Label runat="server"><%=objLanguage.GetLanguageConversion("Selected_Options")%></asp:Label></span></strong>
                                                        <div class="only5px">
                                                            <telerik:RadGrid ID="RadGrid_seletedProducts" runat="server" AllowPaging="false"
                                                                Style="border-top-width: 0;" AllowFilteringByColumn="false" AllowSorting="false"
                                                                AutoGenerateColumns="false" PageSize="50" Width="100%" AllowMultiRowSelection="true"
                                                                OnRowDrop="grdSelectedOptions_RowDrop" OnNeedDataSource="RadGrid_seletedProducts_OnNeedDataSource"
                                                                GridLines="None" ClientSettings-AllowRowsDragDrop="false" PagerStyle-AlwaysVisible="true"
                                                                GroupingEnabled="false" ShowGroupPanel="true" ShowStatusBar="true" HeaderStyle-Font-Bold="true">
                                                                <%--OnItemDataBound="RadGridContact_OnRowDataBound" --%>
                                                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                                <PagerStyle Mode="NextPrevAndNumeric" />
                                                                <MasterTableView DataKeyNames="PriceCatalogueID" OverrideDataSourceControlSorting="true"
                                                                    AllowFilteringByColumn="false" CommandItemDisplay="Top" Width="100%">
                                                                    <CommandItemTemplate>
                                                                        <%--<table class="rgCommandTable" border="0" style="width: 100%;">
                                                                        <tr>
                                                                            <td align="left">
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:LinkButton ID="btnclrFilters_SP" runat="server" Style="text-decoration: underline;
                                                                                    cursor: pointer" Text='<%#"Clear all Filters"%>' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>--%>
                                                                    </CommandItemTemplate>
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn AllowFiltering="true" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderStyle-Width="10%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                                            ItemStyle-Width="10%">
                                                                            <HeaderTemplate>
                                                                                <input id="checkAll_SP" runat="server" name="checkAll" onclick="checkAll_SP_onclick(this);"
                                                                                    type="checkbox" /></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div style="float: left;">
                                                                                    <input id="checkBox_SP" runat="server" name="Id" type="checkbox" value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>' />
                                                                                    <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                                                </div>
                                                                                <div style="background-image: url('../images/drag_drop.gif'); width: 15px; height: 15px;
                                                                                    cursor: pointer; float: left; background-repeat: no-repeat; padding: 0px 0px 0px 0px;
                                                                                    margin: 3px 0px 0px 3px;" align="left">
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn DataField="PriceCatalogueCategoryName" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderStyle-Width="10%" HeaderText="Category Name" ItemStyle-Width="29%" SortExpression="PriceCatalogueCategoryName"
                                                                            AllowFiltering="true" UniqueName="PriceCatalogueCategoryName" Visible="true">
                                                                            <HeaderTemplate>
                                                                                <div>
                                                                                    <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Category_Name") %></div>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px; text-align: left">
                                                                                    <asp:Label ID="lbl_CategoryName" runat="server" Text='<%#Eval("PriceCatalogueCategoryName")%>'>
                                                                                    </asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn DataField="CatalogueName" HeaderStyle-HorizontalAlign="Left"
                                                                            HeaderStyle-Width="10%" HeaderText="Products Name" ItemStyle-Width="29%" SortExpression="CatalogueName"
                                                                            AllowFiltering="true" UniqueName="CatalogueName" Visible="true">
                                                                            <HeaderTemplate>
                                                                                <div>
                                                                                    <asp:Label runat="server"></asp:Label><%=objLanguage.GetLanguageConversion("Products_Name")%></div>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div style="float: left; width: 99%; overflow: hidden; height: 15px; text-align: left">
                                                                                    <asp:Label ID="lbl_ProductName" runat="server" Text='<%#Eval("CatalogueName")%>'>
                                                                                    </asp:Label>
                                                                                    <asp:HiddenField ID="hdn_PriceCatalogueID_Selected" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>' />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                    </Columns>
                                                                    <NoRecordsTemplate>
                                                                        <div style="padding: 0px 0px 0px 10px">
                                                                            <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                                                        </div>
                                                                    </NoRecordsTemplate>
                                                                </MasterTableView>
                                                                <ClientSettings ReorderColumnsOnClient="true" EnableRowHoverStyle="true" AllowRowsDragDrop="true">
                                                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                                    <ClientEvents OnRowDropping="onRowDropping" />
                                                                    <Scrolling UseStaticHeaders="true" ScrollHeight="270" />
                                                                </ClientSettings>
                                                            </telerik:RadGrid>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                            </div>
                                        </div>
                                        <div id="div_FCK" runat="server" style="margin: 5px 0px 0px 0px; float: left; display: none;">
                                            <asp:UpdatePanel ID="up_FCKCustomize" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <%-- <FCKeditorV2:FCKeditor ID="FCK_customize" runat="server" BasePath="~/fckEditor/">
                                                    </FCKeditorV2:FCKeditor>--%>
                                                    <telerik:RadEditor ID="RadEditor_customize" runat="server" EditModes="Design,Html"
                                                        ToolsFile="~/RadEditorDialogs/Tools/tools.xml" ExternalDialogsPath="~/RadEditorDialogs"
                                                        ContentFilters="MakeUrlsAbsolute" OnClientLoad="OnClientLoad">
                                                        <Content>
                                                                          
                                                        </Content>
                                                        <CssFiles>
                                                            <telerik:EditorCssFile Value="~/RadEditorDialogs/Tools/EditorContentArea.css" />
                                                        </CssFiles>
                                                    </telerik:RadEditor>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="div_CustomizePannel" runat="server" style="min-width: 1010px; max-width: 1200px;
                                            margin: 5px 0px 0px 0px; float: left; display: none;">
                                            <asp:UpdatePanel ID="upContent" runat="server">
                                                <ContentTemplate>
                                                    <div align="left" id="Div1">
                                                        <div align="left">
                                                            <div style="border: solid 0px gainsboro; padding: 0px 0px 10px 0px;">
                                                                <div style="padding-left: 0px; padding-top: 5px; display: block;">
                                                                    <div>
                                                                        <asp:RadioButtonList runat="server" RepeatDirection="Horizontal" ID="rdlWithRightBanner">
                                                                            <asp:ListItem onclick="onCheckRWithoutBanner(this.id)" Selected="True" Value="0">With Right Banner</asp:ListItem>
                                                                            <asp:ListItem onclick="onCheckRWithoutBanner(this.id)" Value="1">Without Right Banner</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                    <%--Add custom text is removed as requested in bugid- 2313--%>
                                                                    <%--        <div style="padding: 0 5px 5px 5px;">
                                                                        <input class="button" type="button" id="btnAddCustomText" onclick="AddCustomText()"
                                                                            value="Add Custom Text" />
                                                                    </div>--%>
                                                                    <div id="divCustom" style="margin-left: -200px;">
                                                                        <table width="100%" cellspacing="5px">
                                                                            <tr style="width: 99%">
                                                                                <td width="185px" style="float: left; padding-right: 10px; padding-left: 5px;">
                                                                                    <div style="margin-right: 0px; width: 100%;">
                                                                                        <span><b>
                                                                                            <%=objLanguage.GetLanguageConversion("Product_Categories")%></b></span>
                                                                                        <div style="border: 1px solid silver; -moz-border-radius: 5px; border-radius: 5px;
                                                                                            height: 520px; overflow: auto; width: 100%; margin-top: 5px;">
                                                                                            <telerik:RadTreeView ID="rtvProduct" DataFieldID="PriceCatalogueID" CheckBoxes="false"
                                                                                                runat="server" OnNodeDataBound="rtvProduct_NodeDataBound">
                                                                                                <DataBindings>
                                                                                                    <telerik:RadTreeNodeBinding Expanded="True" />
                                                                                                </DataBindings>
                                                                                                <NodeTemplate>
                                                                                                    <div style="margin-left: -8px; margin-top: -3px;">
                                                                                                        <div style="float: left;">
                                                                                                            <asp:CheckBox ID="chkProductID" runat="server" onclick="CheckChange(this.id);" />
                                                                                                        </div>
                                                                                                        <div>
                                                                                                            <%#Eval("PriceCatalogueCategoryName")%></div>
                                                                                                        <asp:HiddenField ID="hdnProductID" runat="server" Value='<%#Eval("PriceCatalogueCategoryID") %>' />
                                                                                                    </div>
                                                                                                </NodeTemplate>
                                                                                            </telerik:RadTreeView>
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                                <td style="margin-top: -10px; float: left;">
                                                                                    <%--<div style="padding: 0 5px 5px 5px;">
                                                                                        <input class="button" type="button" id="btnAddCustomText" onclick="AddCustomText()"
                                                                                            value="Add Custom Text" />
                                                                                    </div>--%>
                                                                                    <div id="MainDIV" style="float: left; margin-top: 28px; padding-right: 1px; min-width: 590px;
                                                                                        max-width: 780px; padding-top: 0px; border: 1px solid silver; -moz-border-radius: 3px;
                                                                                        border-radius: 5px;">
                                                                                        <div style='height: 10px;'>
                                                                                        </div>
                                                                                        <div style="height: 500px; width: auto; overflow-x: hidden; padding: 0 0 0 5px;">
                                                                                            <div id="dragableElementsParentBox" style="float: left; width: auto; -moz-user-select: none;
                                                                                                -webkit-user-select: none;">
                                                                                            </div>
                                                                                        </div>
                                                                                        <div style='height: 10px;'>
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                                <td width="185px" style="float: left; padding-left: 10px;">
                                                                                    <div style="width: 99%; padding-right: 10px;">
                                                                                        <span><b>
                                                                                            <%=objLanguage.GetLanguageConversion("Banners")%></b></span>
                                                                                        <div style="border: 1px solid silver; -moz-border-radius: 5px; border-radius: 5px;
                                                                                            overflow: auto; height: 520px; width: 95%; margin-top: 5px; margin-left: 0px;">
                                                                                            <div style="width: 90%; padding: 5px;">
                                                                                                <telerik:RadListView ID="rlvBanner" runat="server" ItemPlaceholderID="BannerItemsHolder"
                                                                                                    OnNeedDataSource="rlvBanner_NeedDataSource" OnItemDataBound="rlvBanner_ItemDataBound">
                                                                                                    <LayoutTemplate>
                                                                                                        <asp:Panel ID="BannerItemsHolder" runat="server" />
                                                                                                    </LayoutTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <span style="float: left; padding-top: 3px;">
                                                                                                            <asp:CheckBox ID="chkBannerID" onclick="onCheckBanner(this.id)" runat="server" />
                                                                                                        </span>
                                                                                                        <div id="divBannerImage" runat="server" style="padding-top: 5px; margin-bottom: -5px;">
                                                                                                            <asp:Image Height="70px" Width="100px" Style="border: 3px solid silver;" ID="imgBanner"
                                                                                                                ImageUrl="" runat="server" />
                                                                                                            <asp:HiddenField ID="hdnBannerID" runat="server" Value='<%#Eval("bannerid") %>' />
                                                                                                            <asp:HiddenField ID="imageName" runat="server" Value='<%#Eval("bannerImage") %>' />
                                                                                                            <asp:HiddenField ID="hdnURL" runat="server" Value='<%#Eval("URL") %>' />
                                                                                                        </div>
                                                                                                        <br />
                                                                                                    </ItemTemplate>
                                                                                                    <EmptyDataTemplate>
                                                                                                        <div style="padding: 0px 0px 0px 10px">
                                                                                                            <%=objLanguage.GetLanguageConversion("No_Record_Found")%>
                                                                                                        </div>
                                                                                                    </EmptyDataTemplate>
                                                                                                </telerik:RadListView>
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
                                                    <div>
                                                        <asp:HiddenField ID="hdnTypeIDs" runat="server" Value="" />
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both">
                            </div>
                            <div>
                                <div id="div_Next" runat="server" style="float: left; margin: 20px 0px 0px 16%;">
                                    <div style="float: left;">
                                        <div id="div_Button1" style="float: left; display: block; margin: 0px 0px 0px 5px;">
                                            <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="button" OnClick="btn_cancel_Click" />
                                        </div>
                                        <div id="div_Button1process" class="button" align="center" style="height: 14px; width: 43px;
                                            display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <asp:Button ID="btn_Next" runat="server" Text="Next" CssClass="button" Style="display: block"
                                            OnClientClick="javascript:return validate('next','');" />
                                        <div>
                                            <div id="div_btnsave" style="display: block">
                                                <asp:Button ID="btn_SaveHP" runat="server" Text="Save" CssClass="button" Style="display: none"
                                                    OnClick="btn_SaveHP_Click" OnClientClick="javascript:var a=validate('saveDefault','homePage');if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                            </div>
                                            <div id="div_btnsaveprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" style="padding-top: 0.5px" class="loadingimg"
                                                    alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                        <div id="div_Properties" style="border: solid 1px gainsboro; padding: 10px 0px 10px 10px;
                            display: none">
                            <div>
                                <div class="bglabel" style="width: 190px">
                                    <asp:Label ID="lbl_title_property" runat="server" Text="Title" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Title")%></asp:Label>
                                    <span style="color: red">*</span>
                                </div>
                                <div class="box">
                                    <div style="float: left;">
                                        <div>
                                            <asp:TextBox ID="txt_title_property" runat="server" CssClass="textboxnew" MaxLength="100"
                                                onblur="CallonBlur(this.value,'spn_titleProperty');"></asp:TextBox></div>
                                        <div id="spn_titleProperty" style="display: none; width: 180px; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Page_Title")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <div>
                                <div class="bglabel" style="width: 190px">
                                    <asp:Label ID="lbl_description" runat="server" Text="Meta Description" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Meta_Description")%></asp:Label>
                                    <span style="color: red">*</span>
                                </div>
                                <div class="box">
                                    <div style="float: left;">
                                        <div>
                                            <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine" CssClass="textboxnew"
                                                onblur="CallonBlur(this.value,'spn_description');"></asp:TextBox></div>
                                        <div id="spn_description" style="display: none; width: 180px; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Description")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <div>
                                <div class="bglabel" style="width: 190px">
                                    <asp:Label ID="lbl_key" runat="server" Text="Meta Keywords" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Meta_Keywords")%></asp:Label>
                                    <span style="color: red">*</span>
                                </div>
                                <div class="box">
                                    <div style="float: left;">
                                        <div>
                                            <asp:TextBox ID="txt_key" runat="server" TextMode="MultiLine" CssClass="textboxnew"
                                                onblur="CallonBlur(this.value,'spn_keywords');"></asp:TextBox><br />
                                            <asp:Label ID="lbl_information" runat="server" Text="(comma separate multiple keywords)"
                                                CssClass="smallgraytext">(<%=objLanguage.GetLanguageConversion("Comma_Separate_Multiple_Keywords")%>)</asp:Label>
                                        </div>
                                        <div id="spn_keywords" style="display: none; width: 180px; float: left">
                                            <div class="RFV_Message">
                                                <span style="float: left; padding-left: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Keywords")%></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <div>
                                <div class="bglabel" style="width: 190px">
                                    <asp:Label ID="lbl_show" runat="server" Text="Show Page in" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Show_Page_In") %></asp:Label>
                                </div>
                                <div class="box">
                                    <div style="float: left;">
                                        <asp:CheckBox ID="chk_topNavi" runat="server" Checked="true" Text='Top Navigation' />
                                        <asp:CheckBox ID="chk_footer" runat="server" Text='Footer' />
                                    </div>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                            <div>
                                <div class="bglabel" style="width: 190px; background: White; margin: 10px 0px 0px 0px;">
                                    <asp:Label ID="Label9" runat="server" Text="" CssClass="normaltext"></asp:Label>
                                </div>
                                <div class="box">
                                    <div style="display: inline; float: left; padding: 3px">
                                        <div id="div_btn_cancel" style="display: block; float: left;">
                                            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" CssClass="button" OnClick="btn_cancel_Click" />
                                        </div>
                                        <div id="div_btn_cancelprocess" class="button" align="center" style="height: 14px;
                                            width: 43px; display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="display: inline; float: left; padding: 3px">
                                        <asp:Button ID="btn_previous" runat="server" Text="Previous" CssClass="button" OnClientClick="javascript:return gettabs('c');" />
                                    </div>
                                    <div style="display: inline; float: left; padding: 3px">
                                        <div id="div_btnsavesatay" style="display: block">
                                            <asp:Button ID="btn_saveStay" runat="server" Text="Save & Stay" CssClass="button"
                                                OnClientClick="javascript:var a=validate('save','');if(a)loadingimage(this.id,'div_savestayprocess');return a;"
                                                OnClick="btn_save_Click" />
                                        </div>
                                        <div id="div_savestayprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="display: inline; float: left; padding: 3px">
                                        <div id="div_btn_save" style="display: block">
                                            <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="button" OnClientClick="javascript:var a=validate('save','');if(a)loadingimage(this.id,'divbtn_saveprocess');return a;"
                                                OnClick="btn_saveStay_Click" />
                                        </div>
                                        <div id="divbtn_saveprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <asp:HiddenField runat="server" ID="hdnIsRightBanner" Value="" />
            <asp:HiddenField runat="server" ID="hdnCustomText" Value="" />
            <asp:HiddenField runat="server" ID="hdnIDs" Value="" />
            <asp:HiddenField runat="server" ID="hdnCustomHeigthWidth" Value="" />
        </div>
    </div>
    <%--    <style>
        #draggable
        {
            width: 150px;
            height: 150px;
            padding: 0.5em;
            border: 2px solid gray;
        }
    </style>
    <script>
        $(function () {
            $("#draggable").draggable();
        });
    </script>
    <div>
        <div id="draggable" class="ui-widget-content">
            <p>
                Drag me around</p>
        </div>
    </div>--%>
    <script type="text/javascript" language="javascript">

        var div_Content = document.getElementById("div_Content");
        var div_Properties = document.getElementById("div_Properties");
        var lbl_Content = document.getElementById("<%=lbl_Content.ClientID %>");
        var lbl_Properties = document.getElementById("<%=lbl_Properties.ClientID %>");

        var txt_title = document.getElementById("<%=txt_title.ClientID %>");
        var div_pageTitle = document.getElementById("div_pageTitle");

        var txt_title_property = document.getElementById("<%=txt_title_property.ClientID %>");
        var spn_titleProperty = document.getElementById("spn_titleProperty");

        var txt_description = document.getElementById("<%=txt_description.ClientID %>");
        var spn_description = document.getElementById("spn_description");

        var txt_key = document.getElementById("<%=txt_key.ClientID %>");
        var spn_keywords = document.getElementById("spn_keywords");
        var spn_Pagetitle = document.getElementById("spn_Pagetitle");

        var div_FCK = document.getElementById("<%=div_FCK.ClientID %>");
        var div_CustomizePannel = document.getElementById("ctl00_ContentPlaceHolder1_div_CustomizePannel");

        var txt_centerPaneltext = document.getElementById("<%=txt_centerPaneltext.ClientID %>");
        var spn_centerPaneltext = document.getElementById("spn_centerPaneltext");
        var div_centerPaneltext = document.getElementById("div_centerPaneltext");

        var div_featuredProductsMain = document.getElementById("<%=div_featuredProductsMain.ClientID %>");
        var rdbCustomizeNew = document.getElementById("ctl00_ContentPlaceHolder1_rdbCustomizeNew");

        var hdnIsRightBanner = document.getElementById("<%=hdnIsRightBanner.ClientID %>");
        var stay = '<%=stay %>';

        var CompanyID = '<%=CompanyID %>';
        var AccountID = '<%=AccountID %>';
        var PageID = '<%=pageID %>';

        var CheckDuplicate = false;
        function CheckDuplicate_pages(value) {
            if (value != "") {
                AutoFill.Check_page_Duplicacy(CompanyID, AccountID, PageID, txt_title.value, GetResult12, onTimeout, onError);
            }
        }

        function GetResult12(result) {
            if (result == -1) {
                div_pageTitle.style.display = "block";
                div_pageTitle.style.width = "275px";
                spn_Pagetitle.innerHTML = "Page Name/System Name already exists";
                CheckDuplicate = true;
            }
            else {
                div_pageTitle.style.display = "none";
                spn_Pagetitle.style.display = "none";
                CheckDuplicate = false;
            }
        }

        function onTimeout(request, context) {
            //            alert(request + " request");
            //            alert(context + " context");
        }
        function onError(objError) {
            //            alert(objError + " objError");

        }

        function gettabs(value) {
            if (value == 'c') {
                div_Content.style.display = "block";
                div_Properties.style.display = "none";

                lbl_Content.style.color = "Red";
                lbl_Properties.style.color = "Black";
                return false;

            }
            else if (value == 'p') {
                CallonBlur(txt_title.value, 'spn_Pagetitle');
                if (txt_title.value == "" || txt_title.value.trim() == "") {
                    div_pageTitle.style.display = "block";
                    return false;
                }
                else {
                    div_Content.style.display = "none";
                    div_Properties.style.display = "block";

                    lbl_Content.style.color = "Black";
                    lbl_Properties.style.color = "Red";
                    return false;
                }
            }
        }

        gettabs(stay);

        function validate(val, home) {

            var flag = true;
            if (validate_Account()) {
                if (val == 'next') {

                    CallonBlur(txt_title.value, 'spn_Pagetitle');

                    if (txt_title.value == "" || txt_title.value.trim() == "") {
                        div_pageTitle.style.display = "block";
                        flag = false;
                    }
                    else if (CheckDuplicate) {
                        gettabs('c');
                    }
                    else {
                        div_pageTitle.style.display = "none";
                        div_Content.style.display = "none";
                        div_Properties.style.display = "block";

                        lbl_Content.style.color = "Black";
                        lbl_Properties.style.color = "Red";
                        flag = false;
                    }
                }

                if (home.toLowerCase() == 'homepage') {

                    if (document.getElementById("ctl00_ContentPlaceHolder1_div_homeCustomize").style.display == 'block') {
                        CallonBlur(txt_centerPaneltext.value, 'spn_centerPaneltext');
                        if (txt_centerPaneltext.value == "" || txt_centerPaneltext.value.trim() == "") {
                            flag = false;
                        }
                        else {
                            div_centerPaneltext.style.display = "none";
                        }
                    }
                }

                if (val == 'saveDefault') {

                    CallonBlur(txt_title.value, 'div_pageTitle');
                    if (div_pageTitle.style.display == "block") {
                        flag = false;
                    }
                    else {
                        div_pageTitle.style.display = "none";
                    }
                    getSelectedOrders();
                    AggignHiddenField(CompanyID, 0);

                    // Save Customer Oreder
                    //                var customNew = rdbCustomizeNew.checked;

                    //                if (customNew = true) {

                    //                    if (hdnIsRightBanner.value == '0') {
                    //                        SaveCustomizeOrder(CompanyID, 0);
                    //                    }
                    //                    else {
                    //                        SaveCustomizeOrder(CompanyID, 1);

                    //                    }

                    //                }
                }

                if (val == 'save') {
                    CallonBlur(txt_title_property.value, 'spn_titleProperty');
                    CallonBlur(txt_description.value, 'spn_description');
                    CallonBlur(txt_key.value, 'spn_keywords');

                    if (spn_titleProperty.style.display == "block") {
                        flag = false;
                    }
                    else {
                        spn_titleProperty.style.display = "none";
                    }

                    if (spn_description.style.display == "block") {
                        flag = false;
                    }
                    else {
                        spn_description.style.display = "none";
                    }

                    if (spn_keywords.style.display == "block") {
                        flag = false;
                    }
                    else {
                        spn_keywords.style.display = "none";
                    }
                }

                if (flag) {
                    if (!CheckDuplicate) {
                        return true;
                    }
                    else {
                        gettabs('c');
                        return false;
                    }
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        function ShowFCK(val, text) {

            if (val == 'yes') {

                div_FCK.style.display = "block";
                div_featuredProductsMain.style.display = "none";
                div_CustomizePannel.style.display = "none";
            }
            else if (val == 'new') {
                div_CustomizePannel.style.display = "block";
                div_FCK.style.display = "none";
                div_featuredProductsMain.style.display = "none";

            }
            else {
                div_FCK.style.display = "none";
                div_featuredProductsMain.style.display = "none";
                div_CustomizePannel.style.display = "none";
            }

            if (text == 'featured') {
                txt_centerPaneltext.value = "Featured Products";
                div_featuredProductsMain.style.display = "block";
            }
            if (text == 'new') {
                txt_centerPaneltext.value = "New Products"
            }
            if (text == 'html') {
                txt_centerPaneltext.value = "Html"
            }
            if (text == 'custom') {
                txt_centerPaneltext.value = "Custom"
            }
        }

    </script>
    <script type="text/javascript" language="javascript">

        function Show_accountListDiv() {
            showDivPopupCenter('div_accountsList', '200');
        }

        function Show_uploadImagesDiv() {
            showDivPopupCenter('div_uploadImages', '200');
        }

        function checkAll_FP_onclick(checkAll_FP) {
            var frm = document.forms[0];
            var ChkState = checkAll_FP.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_FP') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }

        function checkAll_SP_onclick(checkAll_SP) {
            var frm = document.forms[0];
            var ChkState = checkAll_SP.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_SP') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }

        function CheckOne_new(val) {
            if (val == 'move') {
                var Counter = 0;
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('checkBox_FP') != -1) {
                        if (!e.disabled) {
                            if (e.checked)
                                Counter = Number(Counter) + 1;
                        }
                    }
                }

                if (Number(Counter) == 0) {
                    alert('<%=objLanguage.GetLanguageConversion("Please_Check_Atleast_One_Row_To_Move") %>');
                    return false;
                } else return true;
            }
            if (val == 'remove') {
                var Counter = 0;
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('checkBox_SP') != -1) {
                        if (!e.disabled) {
                            if (e.checked)
                                Counter = Number(Counter) + 1;
                        }
                    }
                }

                if (Number(Counter) == 0) {
                    alert("Please check at least one row to remove");
                    return false;
                } else return true;
            }
        }

        function CallSelect(value) {
            var ret = CheckOne_new(value);
            if (ret) {
                var IDs = '';
                var frm = '';
                if (value == 'move') {
                    frm = document.getElementById("<%=RadGrid_featuredProducts.ClientID %>").getElementsByTagName("input");
                    for (l = 0; l < frm.length; l++) {
                        if (frm[l].id.indexOf('checkBox_FP') != -1) {
                            if (frm[l].type == "checkbox") {
                                if (frm[l].checked) {
                                    IDs = IDs + frm[l].value + ",";
                                }
                            }
                        }
                    }
                }
                else if (value == 'remove') {
                    frm = document.getElementById("<%=RadGrid_seletedProducts.ClientID %>").getElementsByTagName("input");
                        for (l = 0; l < frm.length; l++) {
                            if (frm[l].id.indexOf('checkBox_SP') != -1) {
                                if (frm[l].type == "checkbox") {
                                    if (frm[l].checked) {
                                        IDs = IDs + frm[l].value + ",";
                                    }
                                }
                            }
                        }
                    }

                if (value == 'move') {
                    document.cookie = "MoveOrders=" + IDs;
                }
                else {
                    document.cookie = "RemoveOrders=" + IDs;
                }
            }
            else {
                if (value == 'move') {
                    document.cookie = "MoveOrders=" + "";
                }
                else {
                    document.cookie = "RemoveOrders=" + "";
                }
            }
        }

        function getSelectedOrders() {
            var IDs = '';
            var frm = '';
            var i = 1;
            frm = document.getElementById("<%=RadGrid_seletedProducts.ClientID %>").getElementsByTagName("input");
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('checkBox_SP') != -1) {
                    if (frm[l].type == "checkbox") {
                        IDs = IDs + frm[l].value + ",";
                    }
                }
            }
            document.cookie = "SelectedProductsIDs=" + IDs;
        }

    </script>
    <script type="text/javascript" language="javascript">

        var ServicePath = '<%=strSitepath %>';
        var CompanyID = '<%=CompanyID %>';
        var AccountID = '<%=AccountID %>';
        var strTypeIDs = '<%=TypeIDs %>';
        var PageID = '<%=PageID %>';

        var arrTemplateID = strTypeIDs.split('μ');
        var divMainPannel = document.getElementById("dragableElementsParentBox");

        function FetchItems() {
            if (arrTemplateID != null) {
                CustomePage.ContentManagementWebService.GenerateAllItems(CompanyID, AccountID, arrTemplateID.toString(), CallBackGetAllItems);
            }

        }

        function CheckChange(id) {
            //   alert(id);
            var NodeChecked = document.getElementById(id).checked;
            var idPart = id.replace("chkProductID", "");
            var TypeID = document.getElementById(idPart + "hdnProductID").value;

            if (NodeChecked == true) {
                SaveProductAndBannerList(CompanyID, AccountID, TypeID, 'C', '0');
            }
            else {
                var RemoveDiv = document.getElementById('div_' + TypeID);
                element = document.getElementById(RemoveDiv.parentNode.id);
                element.parentNode.removeChild(element);
                CustomePage.ContentManagementWebService.RemoveCategoryAndBanner(TypeID, AccountID, CallBackGetTemplate);
            }
        }

        function onCheckBanner(id) {
            var idPart = id.replace("chkBannerID", "");
            var TypeID = document.getElementById(idPart + "hdnBannerID").value;
            var NodeChecked = document.getElementById(id).checked;
            if (NodeChecked == true) {
                SaveProductAndBannerList(CompanyID, AccountID, TypeID, 'B', '0');
            }
            else {
                var RemoveDiv = document.getElementById('div_' + TypeID);
                element = document.getElementById(RemoveDiv.parentNode.id);
                element.parentNode.removeChild(element);
                CustomePage.ContentManagementWebService.RemoveCategoryAndBanner(TypeID, AccountID, CallBackGetTemplate);
            }
        }

        function onCheckRWithoutBanner(id) {
            var pnldetails = document.getElementById('pnldetails');
            var MainDIV = document.getElementById('MainDIV');
            var rdlSelectedValue = document.getElementById(id).value;

            if (rdlSelectedValue == '0') {
                hdnIsRightBanner.value = 1;
                div_CustomizePannel.style.width = '1010px';
                MainDIV.style.width = '590px';
            }
            else if (rdlSelectedValue == '1') {
                hdnIsRightBanner.value = 0;
                div_CustomizePannel.style.width = '1240px';
                MainDIV.style.width = '790px';
            }

        }

        function getIsRightBanner() {
            CustomePage.ContentManagementWebService.IsRightBanner(CompanyID, AccountID, CallBackGetIsrightBanner);
        }
        function CallBackGetIsrightBanner(isBanner) {
            hdnIsRightBanner.value = isBanner;
            if (hdnIsRightBanner.value == '1') {
                document.getElementById('ctl00_ContentPlaceHolder1_rdlWithRightBanner_0').checked = true;
                div_CustomizePannel.style.width = '1010px';
                MainDIV.style.width = '590px';
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_rdlWithRightBanner_1').checked = true;
                div_CustomizePannel.style.width = '1240px';
                MainDIV.style.width = '790px';
            }
        }

        function AddCustomText() {

            window.radopen(ServicePath + "StoreSettings/CustomTextPopup.aspx?type=CustomText&CompanyID=" + CompanyID + "&mode=add&AccountID=" + AccountID + "&PageID=" + PageID + '');
            SetRadWindow('divrad', 'divBackGroundNew', '200');

        }

        function Delete(TypeID, divID) {
            var RemoveDiv = document.getElementById(divID.id);
            element = document.getElementById(RemoveDiv.parentNode.id);
            element.parentNode.removeChild(element);
            CustomePage.ContentManagementWebService.RemoveCategoryAndBanner(TypeID, AccountID, CallBackGetTemplate);
        }
        function OpenEditor(id) {
            var EditID = id;
            window.radopen(ServicePath + "StoreSettings/CustomTextPopup.aspx?type=CustomText&Mode=Edit&CompanyID=" + CompanyID + "&AccountID=" + AccountID + "&EditID=" + EditID + "&PageID=" + PageID + '');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
        getIsRightBanner();
        FetchItems();
        window.onmousedown = initWindows;

    </script>
    <asp:Panel ID="pnl_alert" runat="server" Visible="false">
        <%-- <script type="text/javascript" language="javascript">
            alert("Please select account to proceed");
        </script>--%>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
