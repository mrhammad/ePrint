<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="ProductCatalogueCategory.aspx.cs" Inherits="ePrint.ProductCatalogue.ProductCatalogueCategory" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%@ Register Src="~/usercontrol/StoreSettings/account_list.ascx" TagName="accountList"
    TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../js/item/ProductCatalogue.js"></script>
    <%--  <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkbtnDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lnk_loadCatagory" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMenu1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grdallocatedcustomer">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Image_Attachment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--   <telerik:AjaxSetting AjaxControlID="Image_Attachment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--   <telerik:AjaxSetting AjaxControlID="customerwindow">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grdallocatedcustomer" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server" />
    <!--POPUP START-->
    <div>
        <%--<UC:accountList ID="AccountList" runat="server" />--%>
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
    </div>
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <!--POPUP END-->
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
        width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
        <telerik:RadWindowManager ID="RadWindowManager2" runat="server">
            <Windows>
                <telerik:RadWindow ID="RadWindow1" runat="server" Opacity="100" OnClientClose="bindUploadimgname"
                    Title="Category Image" OnClientPageLoad="OnClientPageLoad" KeepInScreenBounds="true"
                    VisibleTitlebar="true" VisibleStatusbar="true" Modal="true" ShowContentDuringLoad="false"
                    Behaviors="Close,Move,Reload,Resize,Maximize">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript" src="<%=strSitepath %>js/Item/javascript.js?VN='<%=VersionNumber%>'"
        language="javascript"></script>
    <%-- <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>--%>
    <script type="text/javascript" src="../js/Item/price_catalogue.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/drag.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript">
        var CompanyID = "<%=CompanyID %>";
        var UserID = "<%=UserID %>";
        var path = "<%=strSitepath %>";
        var DecimalValue = 0;
        DecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 0, '', false, false, false);


    </script>
    <%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div id="lblPriceCatalogueView" align="left" style="float: left;" nowrap="nowrap">
                            <asp:Label ID="lblheader" runat="server" CssClass="navigatorpanel">
                           <%=objlang.GetLanguageConversion("Products")%>&nbsp;:&nbsp;<%=objlang.GetLanguageConversion("Product_Catalogue_Category")%></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
    <div>
        <div style="width: 100%;">
            <div style="width: 100%; display: none" id="divtabs">
                <div id="ynnav" style="padding: 0 0 0 7px">
                    <ul>
                        <li id="li_iteminfo" style="cursor: pointer; float: left; clear: right;">
                            <div id="div2" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                                line-height: 20px; margin-right: 2px; display: none">
                                <b><span id="item_1" class="TabSelected" onclick="javascript:gettabs('i');">
                                    <%=objlang.GetLanguageConversion("Item_Info")%></span> </b>
                            </div>
                        </li>
                        <li id="li_addlweboptions" style="cursor: pointer; float: left; clear: right; display: none">
                            <div id="div3" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                                line-height: 20px; margin-right: 2px">
                                <b><span id="item_2" onclick="javascript:gettabs('w');">
                                    <%=objlang.GetValueOnLang("Addl.Web Options")%></span> </b>
                            </div>
                        </li>
                        <li id="li_image" style="cursor: pointer; float: left; clear: right; display: none">
                            <div id="div5" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                                line-height: 20px; margin-right: 2px">
                                <b><span id="item_3" onclick="javascript:gettabs('m');">
                                    <%=objlang.GetLanguageConversion("Image")%></span></b>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <div id="divgrd" runat="server" style="width: 100%;">
                <div id="padding" style="clear: both;">
                    <div id="div_price_view" style="display: none;">
                        <div align="left" style="width: 80%; border: 0px solid red;" nowrap="nowrap">
                            <div>
                                <table cellpadding="0" cellspacing="0" border="0" width="40%" align="left" style="margin-top: 5px;">
                                    <tr>
                                        <td style="padding-bottom: 5px">
                                            <script type="text/javascript">
                                                function WhenAdd() {
                                                    for (var i = 0; i < 10; i++)
                                                        AddMoreItem('', '');
                                                }
                                            </script>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Panel ID="Panel1" runat="server" class="div_prod_margin">
                <fieldset>
                    <legend class="HeaderText">
                        <%=objlang.GetLanguageConversion("Add_Category")%></legend>
                    <div align="left" style="width: 100%; padding: 0px; border: 0px solid red">
                        <div style="width: 65%;">
                            <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div style="width: 65%; padding: 10px;">
                        <div class="onlyEmpty" id="divitemcode" runat="server">
                            <div class="bglabel">
                                <%=objlang.GetLanguageConversion("Category_Name")%>
                                <span style="color: red">*</span>
                            </div>
                            <div class="box" style="width: 55%;">
                                <div>
                                    <asp:TextBox runat="server" ID="txtCategoryName" SkinID="textPad" Style="display: block;"
                                        MaxLength="150" Width="95%"></asp:TextBox>
                                    <%--onblur="CallonBlur(this.value,'spn_txtitemcode');" --%>
                                    <span id="spn_accountName" style="display: none; width: auto; padding-left: 4px;
                                        padding-right: 4px" class="spanerrorMsg">
                                        <%=objlang.GetLanguageConversion("Please_enter_category_name")%>
                                    </span>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="spn_txtitemcode" style="display: none; width: auto; float: left">
                                    <div class="RFV_Message">
                                        <span style="float: left; width: auto; padding-left: 4px; padding-right: 4px">
                                            <%=objlang.GetLanguageConversion("Please_enter_Item_Code")%></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                            <div class="bglabel">
                                <%=objlang.GetLanguageConversion("Parent_Category_Name")%>
                                <%--  <span style="color: red">*</span>--%>
                            </div>
                            <div class="box" style="width: 55%;">
                                <div>
                                    <asp:DropDownList ID="ddlCategoryList" runat="server" SkinID="textPad" Width="96%"
                                        onchange="javascript:ParentCategoryAlloction()">
                                    </asp:DropDownList>
                                </div>
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                            <div class="bglabel" style="height: 80px">
                                <%=objlang.GetLanguageConversion("Description")%>
                            </div>
                            <div class="box" style="width: 55%;">
                                <div>
                                    <asp:TextBox ID="txtDescription" Width="95%" Height="80px" SkinID="textPad" runat="server"
                                        TextMode="MultiLine" MaxLength="100" onkeyup="javascript:sizelimit(this,'spn_txtDescription_length');"
                                        CssClass="textboxnew1"> </asp:TextBox>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="spn_txtDescription_length" style="display: none; width: 180px; float: left">
                                    <div class="RFV_Message">
                                        <span style="float: left; padding-left: 4px">
                                            <%=objlang.GetLanguageConversion("Max_length_of_textbox_is")%>: 3000</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="divParentCategoryAlloc" runat="server" class="onlyEmpty">
                            <div class="bglabel">
                                <div class="span_width">
                                    <%=objlang.GetLanguageConversion("Apply_Parent_Category_Allocation")%>
                                </div>
                            </div>
                            <div class="box">
                                <div>
                                    <asp:CheckBox ID="chkParentCategoryAlloc" runat="server" onclick="javascript:CheckboxParentCategory()" />
                                </div>
                            </div>
                        </div>
                        <div id="div_categoryvisiblefield" runat="server">
                            <div class="bglabel" style="padding-top: 5px;">
                                <%=objlang.GetLanguageConversion("Category_Visible_to_Customer_Public_Accounts")%>
                            </div>
                            <div class="box" style="width: 55%;">
                                <asp:CheckBox ID="chkvisibletocustomer" runat="server" Checked="true" />
                            </div>
                        </div>
                        <div id="div_categoryapproval" runat="server">
                            <div class="bglabel" style="padding-top: 5px;">
                                <%=objlang.GetLanguageConversion("Category_does_not_require_approval")%>
                            </div>
                            <div>
                                <div class="categoryapprova_box">
                                    <asp:CheckBox ID="chkcatagorynotapproval" runat="server" />
                                </div>
                                <div class="div_categoryapprovalnote">
                                    <span class="smallgraytext">
                                        <%=objlang.GetLanguageConversion("This_option_applies_only_when_approval_system_is_on_for_b2b")%></span>
                                </div>
                            </div>
                        </div>
                        <%--<div class="onlyEmpty" id="div_catagoryType" runat="server">--%>
                        <div class="onlyEmpty" id="div_catagoryType" runat="server">
                            <div class="bglabel">
                                <div style="float: left; width: 5%; height: 50px;">
                                    <span>
                                        <%=objlang.GetLanguageConversion("Customers")%></span>
                                </div>
                            </div>
                            <div align="left" style="float: left; width: 50%;">
                                <div align="left" style="height: 20px;" class="onlyEmpty">
                                    <div style="float: left; cursor: pointer;">
                                        <asp:RadioButton ID="rdCustomerNone" GroupName="Customer" Checked="true" runat="server"
                                            Onclick="ShowHideDiv('N')" />
                                    </div>
                                    <%--<div style="float: left; white-space: normal; padding-top: 3px; width: 140px">
                                        <span>&nbsp;<%=objlang.GetLanguageConversion("None")%></span>
                                    </div>--%>
                                </div>
                                <div align="left" class="onlyEmpty" style="height: 20px;">
                                    <div style="float: left; cursor: pointer;">
                                        <asp:RadioButton ID="rdSelectedCustomer" GroupName="Customer" Text="" runat="server"
                                            Onclick="ShowHideDiv('S')" />
                                    </div>
                                    <%--<div style="float: left; width: 140px; white-space: normal; padding-top: 3px;">
                                        <span>&nbsp;<%=objlang.GetLanguageConversion("Specific_To_Customers")%></span>
                                    </div>--%>
                                    <div id="div_selectLnk" style="float: left; padding-left: 5px; padding-top: 3px;
                                        display: none;">
                                        <a id="Select" runat="server" href="javascript:void(0);">
                                            <%=objlang.GetLanguageConversion("Select") %></a>
                                        <%--onclick="javascript:openPopUp('I','<%=PriceCatalogueCategoryID %>','<%=hdn_categoryName.Value %>','<%=action %>');"--%>
                                        <%----%>
                                    </div>
                                </div>
                                <div align="left" class="onlyEmpty" style="height: 20px;">
                                    <div style="float: left; cursor: pointer;">
                                        <asp:RadioButton ID="rdSelectedAll" GroupName="Customer" Text="" runat="server" Onclick="ShowHideDiv('A')" />
                                    </div>
                                    <%--<div style="float: left; width: 140px; white-space: normal; padding-top: 3px;">
                                        <span>&nbsp;<%=objlang.GetLanguageConversion("All")%></span>
                                    </div>--%>
                                    <div id="div_ExcludeLnk" style="float: left; padding-left: 5px; padding-top: 3px;
                                        display: none;">
                                        <a id="Exclude" runat="server" href="javascript:void(0);">
                                            <%=objlang.GetLanguageConversion("Exclude")%></a>
                                        <%--onclick="javascript:openPopUp('E','<%=PriceCatalogueCategoryID %>','<%=hdn_categoryName.Value %>','<%=action %>');"--%>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_categoryName" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_fromflag" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_validateflag" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_finalvalues" runat="server" Value="" />
                            <asp:HiddenField ID="hdn_iscopychecked" runat="server" Value="false" />
                        </div>
                        <%--<div class="box" style="width: 56%;">
                                                <div id="div3" style="display: block;">
                                                    <asp:ListBox ID="lstCustomer" runat="server" CssClass="textboxnew1" Enabled="true"
                                                        SelectionMode="Multiple" Width="95%" Height="83px"></asp:ListBox>
                                                </div>
                                                <div style="clear: both;">
                                                </div>
                                                <div style="float: left; margin: 0px 10px 0px 0px">
                                                    <a href="javascript:void(0);" id="href_selectAll_Private" runat="server" style="display: block;">
                                                        Select </a>
                                                </div>
                                                <div style="float: left; color: Gray; font-size: 10px">
                                                    <%=objlang.GetValueOnLang("(Use ctrl for multiple seletion)")%>
                                                </div>
                                            </div>--%>
                        <%--<div class="bglabel" style="height: 75px">
                                <div align="left">
                                    <div style="float: left; width: 6%;">
                                        <asp:RadioButton ID="rdAllCustomer" onclick="showListbox('a');" GroupName="Customer"
                                            Checked="true" runat="server" />
                                    </div>
                                    <div style="float: right; width: 90%; white-space: normal; padding-top: 3px;">
                                        <span>
                                            <%=objlang.GetValueOnLang("Don't allocate to any specific customers")%></span>
                                    </div>
                                </div>
                                <div align="left" class="onlyEmpty">
                                    <div style="float: left; width: 6%;">
                                        <asp:RadioButton ID="rdSelectedCustomer" onclick="showListbox('s');" GroupName="Customer"
                                            Text="" runat="server" />
                                    </div>
                                    <div style="float: right; width: 90%; white-space: normal; padding-top: 3px;">
                                        <span>
                                            <%=objlang.GetValueOnLang("Allocate to specific customers")%></span>
                                    </div>
                                </div>
                            </div>
                            <div class="box" style="width: 56%;">
                                <div id="div_listbox" style="display: block;">
                                    <asp:ListBox ID="lstCustomer" runat="server" CssClass="textboxnew1" SelectionMode="Multiple"
                                        Width="95%" Height="83px"></asp:ListBox>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div style="float: left; margin: 0px 10px 0px 0px">
                                    <a href="javascript:void(0);" id="href_selectAll_Private" onclick="selectAll_onclick('private','yes')"
                                        runat="server" style="display: block;">Select All </a><a href="javascript:void(0);"
                                            id="href_selectNone_Private" onclick="selectAll_onclick('private','no')" runat="server"
                                            style="display: none;">None </a>
                                </div>
                                <div style="float: left; color: Gray; font-size: 10px">
                                    <%=objlang.GetValueOnLang("(Use ctrl for multiple seletion)")%>
                                </div>
                            </div>--%>
                        <%-- </div>--%>
                        <div id="publicAccount_label" runat="server" class="onlyEmpty">
                            <div class="bglabel" style="height: 90px">
                                <%=objlang.GetLanguageConversion("Public_Accounts")%>
                            </div>
                            <div class="box" style="width: 55%;">
                                <div id="div_listbox" style="display: block;">
                                    <telerik:RadListBox ID="lstStatus" runat="server" SelectionMode="Multiple" CheckBoxes="true"
                                        Width="98%" Height="98px">
                                        <Items>
                                        </Items>
                                    </telerik:RadListBox>
                                    <%--<asp:ListBox ID="lstAccountPublic" runat="server" CssClass="textboxnew1" SelectionMode="Multiple"
                                        Width="97%" Height="83px" onclick="CheckForNone('accounts');"></asp:ListBox>--%>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <%-- <div style="float: left; margin: 0px 10px 0px 0px">
                                    <a href="javascript:void(0);" id="href_selectAll_Public" onclick="selectAll_onclick('public','yes')"
                                        runat="server" style="display: block;">
                                        <%=objlang.GetLanguageConversion("Select_All")%>
                                    </a><a href="javascript:void(0);" id="href_selectNone_Public" onclick="selectAll_onclick('public','no')"
                                        runat="server" style="display: none;">
                                        <%=objlang.GetLanguageConversion("None")%>
                                    </a>
                                </div>
                                <div style="float: left; color: Gray; font-size: 10px">
                                    <%=objlang.GetValueOnLang("(Use ctrl for multiple seletion)")%>
                                </div>--%>
                            </div>
                        </div>
                        <div class="onlyEmpty">
                            <div class="bglabel" style="padding-bottom: 8px;">
                                <%=objlang.GetLanguageConversion("Category_Image")%>
                                <span style="color: red"></span>
                            </div>
                            <div id="Div1" class="box" style="width: 55%; padding-top: 0px;" runat="server">
                                <div id="div_fuCategory" runat="server" style="float: left; padding-top: 5px">
                                    <%-- <asp:FileUpload ID="fuCategory" size="52" CssClass="textboxnew" runat="server" />--%>
                                    <a href="javascript:void(0);" onclick="javascript:openPopupCrop();">
                                        <%=objLanguage.GetLanguageConversion("Upload_Image") %></a> &nbsp;
                                    <asp:HiddenField ID="hidmode" runat="server" />
                                </div>
                                <div id="div_uploadedimagename" style="display: none">
                                    <a href="javascript:void(0);" id="lnkUpimagepath" runat="server"></a>
                                </div>
                                <div id="div_changeImage" runat="server" style="float: left; padding-top: 5px; height: 30px;">
                                    <a href="javascript:void(0);" id="lnkFileName" runat="server"></a>&nbsp;&nbsp;&nbsp;
                                    <a href="javascript:void(0);" style="text-decoration: underline;" onclick="javascript:ChangeImage();">
                                        <%=objlang.GetValueOnLang("Change Image")%></a>
                                </div>
                                <div style="clear: both;">
                                </div>
                                <div id="div_lblError">
                                    <asp:Label CssClass="error" ID="lblError" runat="server" Visible="false" Text='<%#objlang.GetValueOnLang("Please upload only image file")%>'></asp:Label>
                                </div>
                                <asp:HiddenField ID="hdn_catagoryImageName" runat="server" />
                                <asp:Label ID="lbl_msg" runat="server" Text="(Uploaded image size will be resized to 300px/300px)"
                                    Style="clear: both;" CssClass="smallerfontgrey"><%=objLanguage.GetLanguageConversion("Product_Category_Upload_Image_Note")%></asp:Label>
                                <div style="margin-left: 2%;">
                                </div>
                            </div>
                        </div>
                        <div class="onlyEmpty" style="padding-top: 10px;">
                            <div class="bglabel" style="visibility: hidden">
                                &nbsp;
                            </div>
                            <div class="box">
                                <div style="display: inline; float: left; margin-right: 6px">
                                    <div id="div_cancel" style="display: block">
                                        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="" Style="padding-top: 3px;"
                                            OnClick="btnCancel_Click" CommandName="Cancel" CausesValidation="false" OnClientClick="javascript:return loadingimage(this.id,'div_cancelprocess');"></asp:Button>
                                        <%-- <telerik:RadButton ID="btnCancel" Skin="EprintbtnSkin" EnableEmbeddedSkins="false"
                                        runat="server" Text="" CommandName="Cancel" CausesValidation="false" OnClick="btnCancel_Click">
                                    </telerik:RadButton>--%>
                                    </div>
                                    <div id="div_cancelprocess" class="button" align="center" style="width: 38px; height: 14px;
                                        display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                                <div id="Divdiv_btnsave" runat="server" style="display: inline; float: left">
                                    <div id="div_btnsave" style="display: block">
                                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="" OnClientClick="javascript:var a=txtValidation();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;"
                                            Style="padding-top: 3px;" OnClick="btnSave_Click"></asp:Button>
                                    </div>
                                    <div id="div_btnsaveprocess" style="display: none">
                                        <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </fieldset>
                <fieldset id="Hidefieldset" runat="server">
                    <legend class="HeaderText">
                        <%=objlang.GetLanguageConversion("Product_Categories")%></legend>
                    <div id="div_Resize" align="left" style="width: 80%; display: block">
                        <div align="left" style="padding: 0px 0px 0px 10px;">
                            <div style="width: 65%">
                                <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:PlaceHolder ID="plhMessage_Delete" runat="server"></asp:PlaceHolder>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div style="width: 100%;">
                            <%--<div style="float: left; padding-left: 10px; padding-top: 10px">
                                <asp:LinkButton ID="lnk_loadCatagory" runat="server" OnClick="lnkloadCatagory_click"></asp:LinkButton>
                                <telerik:RadButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                    Skin="EprintbtnSkin" EnableEmbeddedSkins="false" OnClick="lnkDelete_OnClick"
                                    OnClientClick="javascript:return OnDeleteClicked_CheckboxChecked1();" Text="Delete">
                                </telerik:RadButton>
                            </div>--%>
                            <div id="div_popupAction" style="display: none; z-index: 999999; width: 160px; position: absolute;
                                margin: 66px 0px 0px 20px" onmouseover="show();" onmouseout="hide();">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div id="df" runat="server" style="width: 100%;">
                                                <telerik:RadMenu ID="RadMenu1" runat="server" Width="160px" EnableEmbeddedSkins="false"
                                                    OnItemClick="RadMenu1_ItemClick" OnClientItemClicking="onClientItemClicking" Skin="Eprint_Skin" Flow="Vertical">
                                                    <Items>
                                                        <telerik:RadMenuItem Text="Allocate To">
                                                            <Items>
                                                                <telerik:RadMenuItem Width="165px" Value="customer" Text="Customer" onclick="javascript:return CheckOne_custallocation('copy','called');"
                                                                    Style="cursor: pointer;">
                                                                </telerik:RadMenuItem>
                                                                <telerik:RadMenuItem Width="165px" Value="allocate" Text="Public Accounts" onclick="javascript:return CheckOne_new('copy','called')"
                                                                    Style="cursor: pointer;" />
                                                            </Items>
                                                        </telerik:RadMenuItem>
                                                        <telerik:RadMenuItem Text="Delete Selected" Value="Delete" Style="cursor: pointer;"
                                                            onclick="javascript:return OnDeleteClicked_CheckboxChecked1('called');">
                                                        </telerik:RadMenuItem>
                                                    </Items>
                                                </telerik:RadMenu>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <%--   <table border="0" cellpadding="0" cellspacing="0" style="display:none">
<tr>
                                                                            <td>
                                            <div style="width: 100%;" >
                                                <div id="DivAllocate" runat="server" class="divDropdownlist" style="padding-bottom: 7px;
                                                    padding-top: 7px; width: 170px;">
                                                    <asp:LinkButton ID="lnk_loadCatagory" runat="server" Text="Allocate To Public Accounts"
                                                        Style="text-decoration: none;" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return CheckOne_new('copy')"
                                                        CausesValidation="false"></asp:LinkButton></div>
                                                <div id="DivAllocatePublic" runat="server" class="divDropdownlist" style="padding-bottom: 7px;
                                                    padding-top: 7px; width: 170px; border-top: 1px solid #CBCBCB">
                                                    <asp:LinkButton ID="lnkallocatetocustomer" runat="server" Text="Allocate To Customers"
                                                        OnClientClick="javascript:CheckOne_custallocation('copy');return false;" Style="text-decoration: none;"
                                                        ForeColor="#333333" Font-Size="11px" CausesValidation="false"></asp:LinkButton></div>
                                                <div id="div_lnkDelete" runat="server" class="divDropdownlist" style="padding-bottom: 7px;
                                                    padding-top: 7px; width: 170px; border-top: 1px solid #CBCBCB">
                                                    <asp:LinkButton ID="lnkDelete" runat="server" Text="Delete Selected" OnClick="lnkDelete_OnClick"
                                                        Style="text-decoration: none" ForeColor="#333333" Font-Size="11px" OnClientClick="javascript:return OnDeleteClicked_CheckboxChecked1();"
                                                        CausesValidation="false"></asp:LinkButton></div>
                                            
                                            </div>
                                        </td>
                                    </tr>
                                </table>--%>
                                <%--<telerik:RadMenu ID="RadMenu1" runat="server" Width="160px" EnableEmbeddedSkins="false"
                                                                OnItemClick="RadMenu1_ItemClick" Skin="Eprint_Skin" Flow="Vertical">
                                                                <Items>
                                                                    <telerik:RadMenuItem Text="Copy To" onclick="CheckOne_new('copy')">                                                                       
                                                                    </telerik:RadMenuItem>
                                                                    <telerik:RadMenuItem Text="Delete Selected" Value="Delete" Style="cursor: pointer;"
                                                                        onclick="javascript:return OnDeleteClicked_CheckboxChecked1();">
                                                                    </telerik:RadMenuItem>
                                                                </Items>
                                                            </telerik:RadMenu>--%>
                                <%--<telerik:RadListBox runat="server" ID="RadListBox1" SelectionMode="Single" Width="100px"
                                    AutoPostBack="false">
                                    <Items>
                                        <telerik:RadListBoxItem Text="Copy To" onclick="CheckOne_new('copy')" />                                        
                                    </Items>
                                    <ItemTemplate>
                                        <div style="width: 100%;" class="divDropdownlist">
                                            <asp:LinkButton ID="lnkbtnDelete" runat="server" Text="Delete Selected" Style="color: Black;"
                                                OnClientClick="javascript:return OnDeleteClicked_CheckboxChecked1();" OnClick="lnkDelete_OnClick"></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </telerik:RadListBox>--%>
                            </div>
                            <div style="clear: both">
                            </div>
                            <div align="left" style="padding-top: 10px; padding-left: 10px; width: 100%;">
                                <div id="div_Main" runat="server">
                                    <div id="div_Grid">
                                        <telerik:RadGrid ID="GridView1" runat="server" AllowFilteringByColumn="true" AllowPaging="true"
                                            AllowSorting="true" AutoGenerateColumns="false" GridLines="None" GroupingEnabled="false"
                                            OnDeleteCommand="lnkDelete_OnClick" OnItemDataBound="OnRowDataBound_GridView1"
                                            HeaderStyle-Font-Bold="true" OnSortCommand="GridView1_SortCommand" AllowCustomPaging="false"
                                            PagerStyle-CssClass="RadComboBox_Eprint_Skin" PageSize="50" ShowGroupPanel="false"
                                            Width="100%" ShowStatusBar="true">
                                            <GroupingSettings CaseSensitive="false" />
                                            <%--<HeaderStyle Width="100px" />--%>
                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                            <PagerStyle Mode="NextPrevAndNumeric" />
                                            <MasterTableView AutoGenerateColumns="False" CommandItemDisplay="Top" HorizontalAlign="NotSet"
                                                OverrideDataSourceControlSorting="true" Width="100%" PagerStyle-AlwaysVisible="true">
                                                <CommandItemTemplate>
                                                    <table border="0" class="rgCommandTable" style="width: 100%;">
                                                        <tr>
                                                            <td align="left">
                                                                <div id="div_AddNewRecord" runat="server">
                                                                    <asp:Button ID="btnAddNewRecord" runat="server" class="rgAdd" PostBackUrl="ProductCatalogueCategory.aspx?&amp;mode=add" /><a
                                                                        href="ProductCatalogueCategory.aspx?&amp;mode=add"><%=objlang.GetLanguageConversion("Add_new_record")%></a>
                                                                </div>
                                                            </td>
                                                            <td align="right">
                                                                <asp:LinkButton ID="btnclrFilters" runat="server" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                                    cursor: pointer" Text=""><%=objlang.GetLanguageConversion("Clear_All_Filters") %></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </CommandItemTemplate>
                                                <Columns>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                        HeaderStyle-Width="5%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                        ItemStyle-Width="5%" Visible="true">
                                                        <HeaderTemplate>
                                                            <div style="float: left">
                                                                <div style="float: left; display: none;">
                                                                    <input id="checkAll_Copy1" runat="server" name="checkAll" type="checkbox" />
                                                                </div>
                                                                <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px;
                                                                    -webkit-border-radius: 5px; -ms-border-radius: 5px; width: inherit; height: inherit">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                        <tr>
                                                                            <td>
                                                                                <div style="float: left">
                                                                                    <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                        type="checkbox" />
                                                                                </div>
                                                                            </td>
                                                                            <td>
                                                                                <div style="float: left; padding: 0px 0px 0px 1px">
                                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="show();" alt='' />
                                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="hide();" alt='' />
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
                                                                <input id="checkBox_Copy1" runat="server" name="Id" onclick="CheckChanged();" type="checkbox"
                                                                    value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueCategoryID", "{0}") %>' />
                                                            </div>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="left"
                                                        ItemStyle-Width="3%" Visible="false">
                                                        <HeaderTemplate>
                                                            <input id="checkAll_Copy" runat="server" name="checkAll" onclick="CheckAll(this);"
                                                                type="checkbox" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <input id="checkBox_Copy" runat="server" name="Id" onclick="CheckChanged();" type="checkbox"
                                                                value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueCategoryID", "{0}") %>' />
                                                            <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="PriceCatalogueCategoryName"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Category Name"
                                                        ItemStyle-Width="20%" SortExpression="PriceCatalogueCategoryName" UniqueName="PriceCatalogueCategoryName"
                                                        Visible="true" AutoPostBackOnFilter="true">
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        <ItemTemplate>
                                                            <a href='ProductCatalogueCategory.aspx?&amp;mode=edit&amp;catagoryID=<%#Eval("PriceCatalogueCategoryID")%>'>
                                                                <div style="float: left; width: 99%; height: auto">
                                                                    <%--&catagoryImage=<%#Eval("categoryImage")%>--%>
                                                                    <%#Eval("PriceCatalogueCategoryName")%>
                                                                </div>
                                                            </a>
                                                            <%--<asp:Label ID="lblPriceCatalogueCategoryName" Visible="false" runat="server" Text="<%#Eval("PriceCatalogueCategoryID")%>"></asp:Label>--%>
                                                            <input id="hdnPriceCatalogueCategoryName" runat="server" type="hidden" value='<%#Eval("PriceCatalogueCategoryName")%>' />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="Description"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Description"
                                                        ItemStyle-Width="20%" SortExpression="Description" UniqueName="Description" Visible="true"
                                                        AutoPostBackOnFilter="true">
                                                        <ItemTemplate>
                                                            <a href='ProductCatalogueCategory.aspx?&amp;mode=edit&amp;catagoryID=<%#Eval("PriceCatalogueCategoryID")%>'>
                                                                <div style="float: left; width: 99%; height: auto">
                                                                    <%#Eval("Description")%>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="MultiLevelCategory"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="20%" HeaderText="Parent Category"
                                                        ItemStyle-Width="20%" SortExpression="MultiLevelCategory" UniqueName="MultiLevelCategory"
                                                        Visible="true" AutoPostBackOnFilter="true">
                                                        <ItemTemplate>
                                                            <a href='ProductCatalogueCategory.aspx?&amp;mode=edit&amp;catagoryID=<%#Eval("PriceCatalogueCategoryID")%>'
                                                                title="<%#Eval("MultiLevelCategory")%>">
                                                                <div style="float: left; width: 99%; height: auto">
                                                                    <%#Eval("MultiLevelCategory")%>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="AllocatedCustomer"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" HeaderText="Allocated Customer"
                                                        ItemStyle-Width="10%" SortExpression="MultiLevelCategory" UniqueName="AllocatedCustomer"
                                                        Visible="true" AutoPostBackOnFilter="true">
                                                        <ItemTemplate>
                                                            <a href='ProductCatalogueCategory.aspx?&amp;mode=edit&amp;catagoryID=<%#Eval("PriceCatalogueCategoryID")%>'
                                                                title="<%#Eval("customer")%>">
                                                                <div style="float: left; width: 99%; height: 15px">
                                                                    <div style="display: inline; float: left">
                                                                        <asp:Label ID="lblallocatedcust" Text='<%#Eval("customer")%>' runat="server"></asp:Label>
                                                                    </div>
                                                                    <div style="display: inline; float: left; margin-left: 3px">
                                                                        <a id="a1" href="javascript:;" onclick="opencategoryallocationwindow(<%#Eval("PriceCatalogueCategoryID")%>);">
                                                                            <asp:ImageButton ID="Image_Attachment" OnClientClick="javascript:void(0);return false;"
                                                                                runat="server" ImageUrl="~/images/invoiced-paid.png" />
                                                                        </a>
                                                                    </div>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn CurrentFilterFunction="Contains" DataField="Account"
                                                        HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%" HeaderText="Public Accounts"
                                                        ItemStyle-Width="30%" SortExpression="MultiLevelCategory" UniqueName="PublicAccounts"
                                                        Visible="true" AutoPostBackOnFilter="true">
                                                        <ItemTemplate>
                                                            <a href='ProductCatalogueCategory.aspx?&amp;mode=edit&amp;catagoryID=<%#Eval("PriceCatalogueCategoryID")%>'
                                                                title="<%#Eval("Account")%>">
                                                                <div style="float: left; width: 99%; height: auto">
                                                                    <asp:Label ID="lblaccname" Text="" runat="server"></asp:Label>
                                                                    <%--<%#Eval("Account")%>--%>
                                                                </div>
                                                            </a>
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                    <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                        HeaderStyle-HorizontalAlign="Center" ItemStyle-Wrap="true" HeaderStyle-Width="5%"
                                                        HeaderText="Action" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" UniqueName="restoreDefault">
                                                        <ItemTemplate>
                                                            <%--<a href='ProductCatalogueCategory.aspx?&amp;mode=edit&amp;catagoryID=<%#Eval("PriceCatalogueCategoryID")%>'>
                                                                <asp:Image ID="imgbtnEdit" runat="server" ImageUrl="~/images/edit.gif" ToolTip="Edit" /></a>&nbsp;--%>
                                                            <asp:ImageButton ID="imgDelete" runat="server" Height="15px" ImageUrl="~/Images/erase.png"
                                                                OnClick="imgDelete_click" OnCommand="imgDelete_OnCommand" CommandArgument='<%#Eval("PriceCatalogueCategoryID")%>'
                                                                OnClientClick="javascript:return OnDeleteClicked_CheckboxChecked('ctl00_ContentPlaceHolder1_GridView1',this.id);"
                                                                ToolTip="Delete" />
                                                        </ItemTemplate>
                                                    </telerik:GridTemplateColumn>
                                                </Columns>
                                            </MasterTableView><ClientSettings AllowColumnsReorder="false" AllowDragToGroup="false"
                                                ReorderColumnsOnClient="true" EnableRowHoverStyle="true">
                                            </ClientSettings>
                                        </telerik:RadGrid>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both">
                                &nbsp;
                            </div>
                        </div>
                    </div>
                </fieldset>
                <asp:LinkButton ID="lnkallocatepublic" runat="server" OnClick="lnkallocatepublic_onclick"></asp:LinkButton>
                &nbsp;&nbsp;
            </asp:Panel>
            <div class="onlyEmpty">
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        var categoryID = '<%=categoryid_new %>'; //Added For Bug ID : 14283
        var weStoreKey = '<%=WebStore %>';
        var checkBoxID = '';

        var lnkFileName = document.getElementById("<%=lnkFileName.ClientID %>");
        var div_changeImage = document.getElementById("<%=div_changeImage.ClientID %>");

        var hdn_catagoryImageName = document.getElementById("<%=hdn_catagoryImageName.ClientID %>");

        var lstAccountPublic = this.document.getElementById("<%=lstStatus.ClientID %>");



        var rdSelectedCustomer = document.getElementById("<%=rdSelectedCustomer.ClientID %>");

        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");

        // Check for Browser Name (If IE Browser then change style) BY 018
        function checkBrowserName() {
            if (navigator.appName.toLowerCase() == 'microsoft internet explorer') {
                document.getElementById("div_popupAction").style.margin = "100px 0px 0px 17px"
            }
        }
        checkBrowserName();
        // Check for Browser Name (If IE Browser then change style) BY 018


        //        function showListbox(para) {
        //            if (para == "s") {
        //                lstCustomer.disabled = false;
        //            }
        //            else if (para == "a") {
        //                lstCustomer.disabled = true;
        //                for (i = 0; i < lstCustomer.length; i++) {
        //                    lstCustomer.options[i].selected = false;
        //                }
        //                href_selectAll_Private.style.display = "block";
        //                href_selectNone_Private.style.display = "none";
        //            }
        //        }

        function ChangeImage() {
            document.getElementById("<%=div_changeImage.ClientID%>").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_div_fuCategory").style.display = "block";
            hdn_catagoryImageName.value = "";
        }

        function OnDeleteClicked_CheckboxChecked1(check) {
            if (check != 'called') {
                //optimization
                var Counter = 0;
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf('checkBox_Copy') != -1) {
                        if (!e.disabled) {
                            if (e.checked)
                                Counter = Number(Counter) + 1;
                        }
                    }
                }
                if (Number(Counter) == 0) {
                    alert('Please check at least one row to Delete');
                    return false;
                }
                else {
                    
                    if (confirm("If you delete this category any items that are allocated to this category will also be deleted.")) {
                        //var chkidnew = ImageButtonID.replace("imgDelete", "Id");
                        //var chkid = document.getElementById(chkidnew);
                        //chkid.checked = true;
                       // __doPostBack('ctl00$ContentPlaceHolder1$lnkDelete', '');                        
                        return true;
                    }

                    else {                       
                        var frm = document.getElementById("<%=GridView1.ClientID %>").getElementsByTagName("input");
                        var i = 1;
                        for (l = 0; l < frm.length; l++) {
                            if (frm[l].id.indexOf('checkBox_Copy1') != -1) {
                                frm[l].checked = false;
                            }
                        }

                        return false;
                    }
                }
            }
        }

        function OnDeleteClicked_CheckboxChecked(GridID, ImageButtonID) {
            
            if (confirm("If you delete this category any items that are allocated to this category will also be deleted.")) {
                var chkidnew = ImageButtonID.replace("imgDelete", "Id");
                var chkid = document.getElementById(chkidnew);
                chkid.checked = true;
                return true;
            }
            else return false;


        }

        var CheckFinal = false;
        function txtValidation() {
            var Actiontype = document.getElementById("ctl00_ContentPlaceHolder1_hdn_validateflag").value;
            var txtCategoryName = document.getElementById("<%=txtCategoryName.ClientID %>");
            CheckFinal = false;
            if (txtCategoryName.value == "" || trim12(txtCategoryName.value) == "") {
                document.getElementById("spn_accountName").style.display = "block";
                txtCategoryName.focus();
                CheckFinal = true;
            }
            if (Actiontype == '' || Actiontype == 'add' || Actiontype == 'edit') {
                if (CheckFinal) {
                    return false;
                }
                else {
                    return true;
                }
            }

        }

        var queryString = '<%=Request.Params["mode"] %>';
        //        function EnableCustomeListBox() {
        //            if (queryString != "edit") {
        //                lstCustomer.disabled = false;
        //            }

        //            var lstValue = '<%=lstValue %>';
        //            if (lstValue == "no") {
        //                lstCustomer.disabled = true;
        //            }
        //        }
        //EnableCustomeListBox();

        function CheckForNone(value) {
            if (value == 'accounts') {
                if (lstAccountPublic.selectedIndex == '0') {
                    for (i = 0; i < lstAccountPublic.options.length; i++) {
                        lstAccountPublic.options[i].checked = false;
                    }
                    lstAccountPublic.options[0].checked = true;
                }
            }
            //            if (value == 'customers') {
            //                if (lstCustomer.selectedIndex == '0') {
            //                    for (i = 0; i < lstCustomer.options.length; i++) {
            //                        lstCustomer.options[i].selected = false;
            //                    }
            //                    lstCustomer.options[0].selected = true;
            //                }
            //            }
        }

        function selectAll_onclick(type, selectAll) {
            if (type == 'private') {
                if (rdSelectedCustomer.checked) {
                    if (selectAll == 'yes') {
                        for (i = 0; i < lstCustomer.options.length; i++) {
                            lstCustomer.options[i].selected = true;
                        }
                        href_selectAll_Private.style.display = "none";
                        href_selectNone_Private.style.display = "block";
                    }
                }
                else {
                    alert("Please check 'Allocate to specific customers' ");
                }
                if (selectAll == 'no') {
                    for (i = 0; i < lstCustomer.options.length; i++) {
                        lstCustomer.options[i].selected = false;
                    }
                    href_selectAll_Private.style.display = "block";
                    href_selectNone_Private.style.display = "none";
                }
            }
            else {
                if (selectAll == 'yes') {
                    for (i = 1; i < lstAccountPublic.options.length; i++) {
                        lstAccountPublic.options[i].selected = true;
                    }
                    href_selectAll_Public.style.display = "none";
                    href_selectNone_Public.style.display = "block";
                }
                if (selectAll == 'no') {
                    for (i = 0; i < lstAccountPublic.options.length; i++) {
                        lstAccountPublic.options[i].selected = false;
                    }
                    href_selectAll_Public.style.display = "block";
                    href_selectNone_Public.style.display = "none";
                }
            }
        }

        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
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

        function Show_CopyAccountsDiv() {
            hide();
            showDivPopupCenter('div_CopyAccounts', '220');
        }

        function CheckOne_new(val,check) {
            //alert('inside function');
            if (check != 'called') {
                if (weStoreKey.toLowerCase() == 'no') {
                    checkBoxID = 'checkBox_Copy';
                }
                else {
                    checkBoxID = 'checkBox_Copy1';
                }

                var Counter = 0;
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf(checkBoxID) != -1) {
                        if (!e.disabled) {
                            if (e.checked)
                                Counter = Number(Counter) + 1;
                        }
                    }
                }

                hide();

                if (Number(Counter) == 0) {
                    if (val == "copy")
                        alert("Please check at least one row to Copy");

                    return false;
                }
                else {
                    if (val == "copy") {
                        if (true) {
                            //Show_CopyAccountsDiv();
                            openPopUpPublic('category', 0, '', '');
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
            }
        }

        function checkAll_new(checkAllBox) {
            if (weStoreKey.toLowerCase() == 'no') {
                checkBoxID = 'checkBox_Copy';
            }
            else {
                checkBoxID = 'checkBox_Copy1';
            }

            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(checkBoxID) != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
                if (e.type == 'checkbox' && e.name.indexOf('All') != -1) {
                    if (!e.disabled) {
                        e.checked = ChkState;
                    }
                }
            }
        }
        function ShowHideDiv(type) {
            //var RdbID = document.getElementById(rdbId).checked;
            if (type == 'S') {
                document.getElementById("div_selectLnk").style.display = "block";
                document.getElementById("div_ExcludeLnk").style.display = "none";
            }
            else if (type == 'A') {
                document.getElementById("div_selectLnk").style.display = "none";
                document.getElementById("div_ExcludeLnk").style.display = "block";
            }
            else if (type == 'N') {
                document.getElementById("div_selectLnk").style.display = "none";
                document.getElementById("div_ExcludeLnk").style.display = "none";
            }
        }

        function openPopUp(type, PriceCatalogueCategoryID, itemTitle, action) {

            window.radopen(path + "settings/productCatelogue_Allocation.aspx?from=category&type=" + type + "&id=" + PriceCatalogueCategoryID + "&Name=" + itemTitle + "&action=" + action);
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }


        function openPopUpPublic(type, PriceCatalogueCategoryID, itemTitle, action) {
            window.radopen(path + "Settings/ProductCataloguePublic_Allocation.aspx?from=category&type=" + 'i' + "&id=" + PriceCatalogueCategoryID + "&Name=" + 'Allocate to Public' + "&action=" + action);
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }

        var catagoryType = '<%=catagoryType %>'.toString();
        ShowHideDiv(catagoryType);


        function openPopupCrop() {
            var mode = document.getElementById("<%=hidmode.ClientID %>").value;
            var oWnd = $find("<%= RadWindow1.ClientID %>");
            if (mode == "add") {

                oWnd.setUrl(path + "UploadAndCrop.aspx?from=product_category&catagoryID=" + "add");
                //oWnd.setSize(700, 490);
                oWnd.setSize(1100, 490);
                oWnd.center();
                oWnd.show();
                // window.radopen(path + "UploadAndCrop.aspx?from=category&catagoryID=" + "add", '500', '200');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
            else {
                oWnd.setUrl(path + "UploadAndCrop.aspx?from=product_category&catagoryID=" + categoryID);
                //oWnd.setSize(700, 490);
                oWnd.setSize(1100, 490);
                oWnd.center();
                oWnd.show();
                //window.radopen(path + "UploadAndCrop.aspx?from=category&catagoryID=" + categoryID, '500', '200');
                SetRadWindow('divrad', 'divBackGroundNew', '200');
            }
        }

        //added by rk
        function bindUploadimgname() {
            RadWinClose();
            var imagenameCookie = readCookie("UploadedImageName");
            // Get all the cookies pairs in an array
            cookiearray = imagenameCookie.split('&');
            // Now take key value pair out of this array
            //                for (var i = 0; i < cookiearray.length; i++) {
            //                    name = cookiearray[i].split('=')[0];
            //                    value = cookiearray[i].split('=')[1];
            //                    alert("Key is : " + name + " and Value is : " + value);
            //                }
            ckiename = cookiearray[0].split('=')[0];
            upimagename = cookiearray[0].split('=')[1];
            // alert("Key is : " + ckiename + " and Value is : " + upimagename);
            displyUpimageName(upimagename);
            //to delete the cookie
            clearCookie(imagenameCookie);
        }

        function clearCookie(name) {
            var date = new Date();
            date.setDate(date.getDate() - 1);
            document.cookie = name + "=''; expires=" + date + "; path=/";
            // alert('Successfully erased Cookie ' + name);
        }

        function readCookie(name) {
            return (name = new RegExp('(?:^|;\\s*)' + ('' + name).replace(/[-[\]{}()*+?.,\\^$|#\s]/g, '\\$&') + '=([^;]*)').exec(document.cookie)) && name[1];
        }
        function displyUpimageName(upimagename) {
            document.getElementById("ctl00_ContentPlaceHolder1_div_fuCategory").style.display = "none";
            document.getElementById("div_uploadedimagename").style.display = "block";
            document.getElementById('<%= lbl_msg.ClientID %>').style.display = "none";
            document.getElementById('<%= lnkUpimagepath.ClientID %>').innerHTML = upimagename;
            document.getElementById('<%= lnkUpimagepath.ClientID %>').target = "_blank";
            // document.getElementById('<%= lnkUpimagepath.ClientID %>').href = '<%=SecDocumentSitePath %>' + '<%=ServerName %>' + "/" + '<%=CompanyID %>' + "/ProductCatalogueCategory/" + upimagename;
            document.getElementById('<%= lnkUpimagepath.ClientID %>').href = '<%=strSitePath %>' + "DocManager.ashx?doctype=catnew&filename=" + upimagename;
        }

        function OnClientPageLoad(sender, args) {
            if (contentCell && loadingSign) {
                contentCell.removeChild(loadingSign);
                contentCell.style.verticalAlign = "";
                loadingSign.style.display = "none";
            }
        }
        function CheckOne_custallocation(val, check) {
            if (check != 'called') {
                if (weStoreKey.toLowerCase() == 'no') {
                    checkBoxID = 'checkBox_Copy';
                }
                else {
                    checkBoxID = 'checkBox_Copy1';
                }
                var CategoryName = '';
                var Counter = 0;
                var IDsofChk = 0;
                var flag = true;
                var frm = document.forms[0];
                for (i = 0; i < frm.length; i++) {
                    e = frm.elements[i];
                    if (e.type == 'checkbox' && e.name.indexOf(checkBoxID) != -1) {
                        if (!e.disabled) {
                            if (e.checked) {
                                Counter = Number(Counter) + 1;
                                if (Counter == 1) {
                                    var catID = e.id;
                                    catID = catID.replace("checkBox_Copy1", "hdnPriceCatalogueCategoryName");
                                    if (document.getElementById(catID) != null && document.getElementById(catID) != undefined) {
                                        CategoryName = document.getElementById(catID).value;
                                        //CategoryName = ReplaceAll((document.getElementById(catID).value).toString(), "&", "%26");
                                        while (CategoryName.indexOf('&') != -1) {
                                            CategoryName = CategoryName.replace('&', '%26');
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (Number(Counter) == 0) {
                    if (val == "copy") {
                        alert("Please check at least one row to Copy");
                    }
                    return false;
                }
                if (Number(Counter) == 1) {
                    openPopUp('I', '0', CategoryName, 'Allocatesingle');
                    return true;
                }
                else {
                    openPopUp('I', IDsofChk, '', 'AllocateMultiple');
                    return true;
                }
            }
        }
        //optimization 07-10-16
        function onClientItemClicking(sender, eventArgs) {
            var item = eventArgs.get_item();

            if (item.get_text().toLowerCase() == "allocate to") {
                eventArgs.set_cancel(true); 
            }
            if (item.get_text().toLowerCase() == "delete selected") {
                if (!OnDeleteClicked_CheckboxChecked1('')) { eventArgs.set_cancel(true); }
            }
            if (item.get_text().toLowerCase() == "customer") {
                if (!CheckOne_custallocation('copy', '')) { eventArgs.set_cancel(true); }
            }
            if (item.get_text().toLowerCase() == "public accounts") {
                if (!CheckOne_new('copy', '')) { eventArgs.set_cancel(true); }
            }
        }

    </script>
    <script>
        function opencategoryallocationwindow(id) {
            var Rad1Customer = window.radopen('<%=strSitepath %>' + "common/common_popup.aspx?type=categoryallocatedview&categoryid=" + id + "", '1000', '500');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            Rad1Customer.setSize(800, 400);
            Rad1Customer.center();
        }
    </script>
</asp:Content>

