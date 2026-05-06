<%@ Page Language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master"  AutoEventWireup="true" CodeBehind="PriceCatalogue.aspx.cs" Inherits="ePrint.PriceCatalogue" theme="Theme1" title="Price Catalogue" enableviewstatemac="false" enableEventValidation="false"  %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="sds" Namespace="Telerik.Web.SessionDS" %>
<%--<%@ Register Src="~/usercontrol/StoreSettings/account_list.ascx" TagName="accountList"
    TagPrefix="UC" %>--%>
<%@ Register Src="~/usercontrol/StoreSettings/PriceCatalogue_CustomerNames.ascx"
    TagName="CustomerNames" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManagerProxy ID="SMproxy" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManagerProxy>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridPriceCatalogue">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadMenu1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnk_load">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%-- <telerik:AjaxSetting AjaxControlID="ddlCategorySelect">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lnkDelete">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridPriceCatalogue" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_ctl02_pnlMessage
        {
            height: 17px;
        }
        
        .loadingPanel .raDiv
        {
            position: fixed;
            z-index: 2;
            background-color: transparent;
            background-position: top;
            background-repeat: no-repeat;
            top: 50%;
        }
        .hyperlinkStyle {
            cursor: pointer;
            color: blue;
            text-decoration: underline;
        }
    </style>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default"
        CssClass="loadingPanel">
    </telerik:RadAjaxLoadingPanel>
    <script type="text/javascript">
        var CompanyID = "<%=CompanyID %>";
        var UserID = "<%=UserID %>";
        var path = "<%=strSitepath %>";
        var DecimalValue = 0;
        DecimalValue = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, Number(DecimalValue), 0, '', false, false, false);

        function AddMultipleCategories(ProductCatalogueID, CompanyID, JobID, InvoiceID, page) {
            debugger;
            var strSitepath_ = "<%=strSitepath %>";

            var Rad_Attachment = window.radopen(strSitepath_ + "common/common_popup.aspx?pagetype=general&type=multiple_categories&productcatalogueid=" + ProductCatalogueID + "&companyid=" + CompanyID + "&jobid=" + JobID + "&invoiceid=" + InvoiceID + "&page=" + page + "&pg=" + page + "");
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            Rad_Attachment.setSize(800, 300);
            Rad_Attachment.center();
        }

    </script>
    <!--POPUP START-->
    <div>
        <asp:PlaceHolder ID="plhAccountList" runat="server"></asp:PlaceHolder>
    </div>
    <!--POPUP END-->
    <div id="divBackGroundNew" style="display: none;">
    </div>
    <div align="center">
        <div style="width: 65%">
            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div style="width: 100%; display: none" id="divtabs">
        <div id="ynnav" style="padding: 0 0 0 7px">
            <ul>
                <li id="li_iteminfo" style="cursor: pointer; float: left; clear: right;">
                    <div id="div2" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                        line-height: 20px; margin-right: 2px; display: none">
                        <b><span id="item_1" class="TabSelected" onclick="javascript:gettabs('i');">Item Info
                        </span></b>
                    </div>
                </li>
                <li id="li_addlweboptions" style="cursor: pointer; float: left; clear: right; display: none">
                    <div id="div2" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                        line-height: 20px; margin-right: 2px">
                        <b><span id="item_2" onclick="javascript:gettabs('w');">Addl Web Options</span></b>
                    </div>
                </li>
                <li id="li_image" style="cursor: pointer; float: left; clear: right; display: none">
                    <div id="div5" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                        line-height: 20px; margin-right: 2px">
                        <b><span id="item_3" onclick="javascript:gettabs('m');">Image</span></b>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <div>
        <span></span>
    </div>
    <div id="content" align="left" style="margin-bottom: -28px;">
        <div id="divgrd" runat="server" style="width: 100%;">
            <div id="" style="clear: both;">
                <div id="div_price_view" style="display: none;">
                    <div style="float: left; width: 100%; display: none">
                        <asp:LinkButton ID="lnk_load" runat="server" OnClick="lnkload_click"></asp:LinkButton>
                        <table width="100%">
                            <tr>
                                <td style="float: left; margin-left: -5px;">
                                    <table>
                                        <tr>
                                            <td>
                                                <div style="width: 150px" class="bglabel">
                                                    <asp:Label ID="lblFilterByCategory" runat="server">
                                                    </asp:Label>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCategorySelect" CssClass="normaltext" runat="server" Width="190px"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlCategorySelect_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div style="float: right; padding-left: 0px; padding-top: 5px;">
                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                            cursor: pointer" runat="server" Text="Clear all filters" />
                    </div>
                    <div style="height: 18px; margin-top: -5px; margin-bottom: 10px;">
                        <div id="div_ddlView" style="float: left; /*display: none; */">
                            <asp:DropDownList ID="ddl_View" SkinID="onlyDDL" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged"
                                Width="110%" Style="height: 23px; border-radius: 4px; background-color: white;
                                outline: none; cursor: pointer;" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div style="float: left; margin-left: 35px; padding-top: 3px;">
                            <asp:LinkButton ID="lnkOrderedit" runat="server" Style="text-decoration: underline;"
                                OnClientClick="javascript:return editviewID_order();" OnClick="btnEditViewOrder_Click"><%=objLanguage.GetLanguageConversion("Edit_Add")%></asp:LinkButton>
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; display: none; color: #10357F;">
                                <asp:Label ID="lblChange" runat="server"> </asp:Label></a><%--/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; cursor: pointer;
                                    display: none; color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                        </div>
                        <div style="border: 0px solid red; float: right; margin-top: -5px;">
                            <div style="float: left; display: none;">
                                <span class="HeaderText" style="color: #787878">
                                    <asp:Label ID="lbl_CurrentView" runat="server" Text="Current View">
                                    </asp:Label></span>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;
                            </div>
                            <div id="div_lblView" style="float: left; display: none;">
                                <asp:Label ID="lblView" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div align="left" style="width: 100%; border: 0px solid red; margin-top: -13px; padding-top: 15px;">
                        <div id="div_Main" runat="server" align="left" style="width: 100%">
                            <div id="a">
                            </div>
                            <div id="div_Grid">
                                <div id="div_popupAction" style="margin: 58px 0px 0px 9px;" onmouseover="show();"
                                    onmouseout="hide(); ">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div id="df" runat="server" style="width: 100%;">
                                                    <telerik:RadMenu ID="RadMenu1" runat="server" Width="160px" EnableEmbeddedSkins="false"
                                                        OnItemClick="RadMenu1_ItemClick" OnClientItemClicking="onClientItemClicking"
                                                        Skin="Eprint_Skin" Flow="Vertical">
                                                        <Items>
                                                            <telerik:RadMenuItem Text="">
                                                                <Items>
                                                                    <telerik:RadMenuItem Width="165px" Value="customer" Text="Customer" Style="cursor: pointer;"
                                                                        onclick="javascript: return CheckOne_new('customer','called');" />
                                                                    <telerik:RadMenuItem Width="165px" Value="allocate" Text="Public Accounts" Style="cursor: pointer;"
                                                                        onclick="javascript: return CheckOne_new('copy','called');" />
                                                                    <telerik:RadMenuItem Width="165px" Value="additional" Text="Additional Option" Style="cursor: pointer;"
                                                                        onclick="javascript: return CheckOne_new('addoption','called');" />
                                                                    <telerik:RadMenuItem Width="165px" Value="CouponCode" Text="CouponCode Option" Style="cursor: pointer;"
                                                                        onclick="javascript: return CheckOne_new('couponcode','called');" />
                                                                </Items>
                                                            </telerik:RadMenuItem>
                                                            <telerik:RadMenuItem Text="" Value="Delete" Style="cursor: pointer;" onclick="javascript:return CallDelete('called');">
                                                            </telerik:RadMenuItem>
                                                            <telerik:RadMenuItem Text="" Value="Invisible" Style="cursor: pointer;" onclick="javascript:ProductVisibility('invisible');">
                                                            </telerik:RadMenuItem>
                                                            <telerik:RadMenuItem Text="" Value="Visible" Style="cursor: pointer;" onclick="javascript:ProductVisibility('visible');">
                                                            </telerik:RadMenuItem>
                                                        </Items>
                                                    </telerik:RadMenu>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <asp:HiddenField runat="server" ID="hdnGridPriceCatalogueRadGrid" Value="50" />
                                <asp:HiddenField runat="server" ID="hdnDbID" Value="" />
                                <telerik:RadGrid ID="GridPriceCatalogue" Width="100%" AllowSorting="true" GridLines="None"  EnableEmbeddedSkins="true" Skin="Sunset"
                                    runat="server" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" AllowPaging="True"
                                    OnSortCommand="GridPriceCatalogue_SortCommand" AllowCustomPaging="true" AutoGenerateColumns="False"
                                    AllowFilteringByColumn="true" HeaderStyle-Font-Bold="true" ShowGroupPanel="true"
                                    ShowStatusBar="true" GroupingEnabled="false" OnItemDataBound="GridAllocatedCust_OnItemDataBound"
                                    OnItemCommand="GridPriceCatalogue_ItemCommand" OnNeedDataSource="GridView1_NeedDataSource">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="false"></PagerStyle>
                                    <MasterTableView Width="100%" DataKeyNames="PriceCatalogueID" PagerStyle-AlwaysVisible="true"
                                        CommandItemDisplay="Top">
                                        <CommandItemTemplate>
                                            <table class="rgCommandTable" border="0" style="width: 100%;">
                                                <tr>
                                                    <td align="left">
                                                        <div id="div_AddNewRecord" runat="server">
                                                            <asp:Button runat="server" PostBackUrl="ProductCatalogue_item.aspx" ID="btnAddNewRecord"
                                                                class="rgAdd" />
                                                            <a href="ProductCatalogue_item.aspx">
                                                                <%=objlang.GetLanguageConversion("Add_New_Record") %></a>
                                                        </div>
                                                    </td>
                                                    <%-- <td align="right">
                                                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                                            cursor: pointer;" runat="server" Text=""><%=objlang.GetLanguageConversion("Clear_All_Filters") %></asp:LinkButton>
                                                    </td>--%>
                                                </tr>
                                            </table>
                                        </CommandItemTemplate>
                                        <EditItemStyle></EditItemStyle>
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
                                                            -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                <tr>
                                                                    <td>
                                                                        <div style="float: left">
                                                                            <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                type="checkbox" />
                                                                        </div>
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
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnPriceCatalogueID" runat="server" Value='<%#Eval("PriceCatalogueID")%>' />
                                                    <div style="padding-left: 2px">
                                                        <input id="checkBox_Copy1" runat="server" name="Id" onclick="CheckChanged();" type="checkbox"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>' />
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="Left"
                                                AllowFiltering="false" HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="false"
                                                Visible="false">
                                                <HeaderTemplate>
                                                    <input type="checkbox" id="checkAll_Copy" runat="server" name="checkAll" onclick="CheckAll(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <input type="checkbox" runat="server" id="checkBox_Copy" name="Id" value='<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>'
                                                        onclick="CheckChanged();" />
                                                    <input type="hidden" id="hdnUPDOWN" runat="server" />
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="false" ReorderColumnsOnClient="false"
                                        AllowDragToGroup="false">
                                        <ClientEvents />
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </div>
                        <asp:Button ID="btnsavemultiple" runat="server" OnClick="btnsavemultiple_onclick"
                            Style="visibility: hidden"></asp:Button>
                        <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
                        <div id="Div_Customer" style="position: absolute; display: none; vertical-align: middle;
                            z-index: 100;" align="center">
                            <telerik:RadWindowManager EnableShadow="false" ID="RadWinCustomer" DestroyOnClose="true"
                                Opacity="100" runat="server" Style="z-index: 31000" OnClientClose="RadWinClose"
                                Behaviors="Close,Move,Reload,Resize" ReloadOnShow="false">
                            </telerik:RadWindowManager>
                        </div>
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
        <div style="width: 100%;">
            <div id="div_additionalwebinfo" style="display: none">
            </div>
        </div>
    </div>
    <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_OnClick"></asp:LinkButton>
    <asp:Button ID="lnkCopy" runat="server" OnClick="lnkCopy_OnClick" class="show_hide">
    </asp:Button>
    <asp:HiddenField ID="hdnProcessedId" runat="server" Value="0" />
    <asp:HiddenField ID="hid_PO_values" runat="server" Value="" />
    <asp:HiddenField ID="editOrderViewID" runat="server" Value="0" />
    <asp:Panel ID="pnlLoadOnEdit" runat="server" Visible="false">
        <script>
            var str = document.getElementById("<%=hid_PO_values.ClientID %>");
            load();
        </script>
    </asp:Panel>
    <asp:HiddenField ID="hid_ddlMatrixType" runat="server" Value="P" />
    <asp:HiddenField ID="hid_gridid_orderno" runat="server" />
    <asp:HiddenField ID="hidGridCount" runat="server" Value="0" />
    <asp:HiddenField ID="hid_Delete_IDs" runat="server" />
    <asp:HiddenField ID="hid_visible_invisible_IDs" runat="server" />
    <div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
        width: 50%" align="center">
        <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
            Opacity="100" runat="server" Width="1000" Height="610" OnClientClose="RadWinClose"
            Behaviors="Close,Move,Reload,Resize">
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript" src="../js/Item/price_catalogue.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
    <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="../js/drag.js?VN='<%=VersionNumber%>'" language="javascript"></script>
    <script type="text/javascript" language="javascript">



        function OnChange_ddlPriceCatalogueCategory(objValue) {
            if (Number(objValue) != 0) {
                document.getElementById("div_DeleteCategory").style.display = "block";
            }
            else {
                document.getElementById("div_DeleteCategory").style.display = "none";
            }
        }
        function PriceOnBlur(obj, val) {
            SetBlank(obj, val);
            obj.value = roundNumber(val, 2);

        }
        function SetBlank(obj, val) {
            if (trim12(val) != '') {
                if (val.substring(1, 0) != "-")//for NEGATIVE Values
                {
                    if (!isNaN(val)) {
                        obj.value = val;
                        document.getElementById("spn_txtQuantity_Number").style.display = "none";
                        return true;
                    }
                    else {
                        obj.value = '';
                        obj.focus();
                        document.getElementById("spn_txtQuantity_Number").style.display = "block";
                        return true;
                    }
                }
            }
        }
        function EraseCheck(val) {
            //return window.confirm('Are you sure you want to delete this record?');  //Ref Bug ID: 656, Natraj on 10.11.2011
            var id;
            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked) {
                        Counter = Number(Counter) + 1;
                    }
                    id = e.value;
                }
            }
            if (Number(Counter) > 1) {
                alert("Please check only one row to Delete");
                return false;
            }
            else {
                var flag;

                //return window.confirm('Are you sure you want to delete this record?');
                flag = window.confirm('Are you sure you want to delete this record?');
                if (flag) {
                    var hdnProcessedId = document.getElementById("<%=hdnProcessedId.ClientID %>");
                    hdnProcessedId.value = val;
                    __doPostBack('ctl00$ContentPlaceHolder1$lnkDelete', '');

                }
                else {
                    return false;
                }
                //  return true;
            }
        }


        function CheckOne(value) {

            var Counter = 0;
            var frm = document.forms[0];
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf(value) != -1) {
                    if (e.checked)
                        Counter = Number(Counter) + 1;
                }
            }
            if (Number(Counter) == 0) {
                //alert("Please check at least one 'row' to Delete");
                alert('<%=objLanguage.GetLanguageConversion("Delete_Row_Selection_Alert")%>');
                return false;
            }
            else {
                return window.confirm('<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert")%>');
                // alert('<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert")%>');
                // return true;
            }
        }
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
            //***Bug ID : 656, on 08.11.2011, by Natraj
            if (Number(Counter) > 1) {
                alert("Please check only one row to copy");
                return false;
            }
        }

        var weStoreKey = '<%=WebStore %>';


        var checkBoxID = '';
        function CallDelete(check) {
            if (check != 'called') {
                if (weStoreKey.toLowerCase() == 'no') {
                    checkBoxID = 'checkBox_Copy';
                }
                else {
                    checkBoxID = 'checkBox_Copy1';
                }

                var ret = CheckOne(checkBoxID);
                if (ret) {
                    CheckGrid();
                    var IDs = '';
                    var frm = document.getElementById("<%=GridPriceCatalogue.ClientID %>").getElementsByTagName("input");
                    var i = 1;
                    for (l = 0; l < frm.length; l++) {
                        if (frm[l].id.indexOf('checkBox_Copy') != -1) {
                            if (frm[l].checked) {
                                IDs = IDs + frm[l].value + ",";
                            }
                        }
                    }
                    document.getElementById("<%=hid_Delete_IDs.ClientID %>").value = IDs;
                    return true;
                }
                else {
                    return false;
                }
            }
        }
        var hid_ddlMatrixType = document.getElementById("<%=hid_ddlMatrixType.ClientID %>");
        document.getElementById("div_price_view").style.display = "block";


        function setLoadingPositionOfDivMove(divisionloading) {

            var width = divisionloading.style.width;
            var height = divisionloading.style.height;


            width = width.replace('px', '');
            height = height.replace('px', '');


            divisionloading.style.left = ((document.documentElement.clientWidth - width) / 2) + "px";


            var top = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop;
            divisionloading.style.top = (top + (document.documentElement.clientHeight - height) / 2) + "px";



            var standardbody = (document.compatMode == "CSS1Compat") ? document.documentElement : document.body //create reference to common "body" across doctypes
            var docheightcomplete = (standardbody.offsetHeight > standardbody.scrollHeight) ? standardbody.offsetHeight : standardbody.scrollHeight
            var docwidthcomplete = (standardbody.offsetWidth > standardbody.scrollWidth) ? standardbody.offsetWidth : standardbody.scrollWidth

        }

        function gettabs(value) {
            if (value == 'i') {

                document.getElementById("div_additionalwebinfo").style.display = "none";
                document.getElementById("item_1").style.color = "red";
                document.getElementById("item_2").style.color = "black";
                document.getElementById("item_3").style.color = "black";
            }
            else if (value == 'w') {
                document.getElementById("div_additionalwebinfo").style.display = "block";


                document.getElementById("item_2").style.color = "red";
                document.getElementById("item_1").style.color = "black";
                document.getElementById("item_3").style.color = "black";
            }
            else if (value == 'm') {
                document.getElementById("item_1").style.color = "black";
                document.getElementById("item_2").style.color = "black";
                document.getElementById("item_3").style.color = "red";

                document.getElementById("div_additionalwebinfo").style.display = "none";
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
            ShowPopUpShoppingCart();
        }

        function Show_AdditionalOptionDiv() {
            hide();
            showDivPopupCenter('div_AdditionalOption', '220');
        }

        function Show_CouponcodeOptionDiv() {
            hide();
            showDivPopupCenter('div_CouponCodeOption', '220');
        }

        //optimization 07-10-16
        function onClientItemClicking(sender, eventArgs) {

            var item = eventArgs.get_item();
            
            if (item.get_text().toLowerCase() == "allocate to") {
                 eventArgs.set_cancel(true); 
            }
            if (item.get_text().toLowerCase() == "customer") {
                if (!CheckOne_new('customer')) { eventArgs.set_cancel(true); }
            }

            if (item.get_text().toLowerCase() == "public accounts") {
                if (!CheckOne_new('copy')) { eventArgs.set_cancel(true); }
            }

            if (item.get_text().toLowerCase() == "additional option") {
                if (!CheckOne_new('addoption')) { eventArgs.set_cancel(true); }
            }

            if (item.get_text().toLowerCase() == "couponcode option") {
                if (!CheckOne_new('couponcode')) { eventArgs.set_cancel(true); }
            }
            
            if (item.get_text().toLowerCase() == "delete selected") {
                if (!CallDelete('')) { eventArgs.set_cancel(true); }
            }
        }

        function CheckOne_new(val, check) {
            if (check != 'called') {
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

                hide();

                if (Number(Counter) == 0) {
                    if (val == "copy" || val == "customer")
                        alert("Please check at least one row to Copy");


                    if (val == "addoption" || val == "couponcode")
                        alert("Please check at least one row to process");

                    return false;
                }
                else {
                    if (val == "copy") {
                        if (true) {
                            Show_CopyAccountsDiv();
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    if (val == "addoption") {
                        if (true) {
                            Show_AdditionalOptionDiv();
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                    if (val == "customer") {
                        if (true) {
                            openPopUp('I', '0', '', 'AllocateMultiple');
                        }
                        else {
                            return false;
                        }
                    }
                    if (val == "couponcode") {
                        if (true) {
                            Show_CouponcodeOptionDiv();
                            return true;
                        }
                        else {
                            return false;
                        }
                    }
                }
            }
        }

        function openPopUp(type, ProductCatalogueID, itemTitle, action) {
            var Rad1Customer = window.radopen(path + "settings/productCatelogue_Allocation.aspx?from=product&type=" + type + "&id=" + 0 + "&Name=Allocate Multiple&action=" + action);
            SetRadWindow_Ver2('Div_Customer', 'divBackGroundNew');
            Rad1Customer.setSize(960, 610);
            Rad1Customer.center();
        }

        function checkAll_new(checkAllBox) {
            var frm = document.forms[0];
            var ChkState = checkAllBox.checked;
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('checkBox_Copy') != -1) {
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

        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";

    </script>
    <asp:Panel ID="pnlShowMsg" runat="server" Visible="false">
        <script type="text/javascript">
            DisplayRightMsg();
        </script>
    </asp:Panel>
    <script>

        function OnRowClick(EditPage) {
            window.location = EditPage;
        }

        function OpenCustomer_List(ID) {
            var RadCustomer = window.radopen("<%=nmsCommon.global.sitePath()%>Settings/PriceCatalogue_Customer.aspx?PriceCatelougeID=" + ID, '1000', '500');
            SetRadWindow_Ver2('Div_Customer', 'divBackGroundNew');
            RadCustomer.setSize(710, 400);
            RadCustomer.center();
        }

        function SetRadWindow_Ver2(divMaskID, divBackgroundID) {
            var Div_Customer = document.getElementById(divMaskID);
            var divBackGroundNew = document.getElementById(divBackgroundID);

            if (document.getElementById(divMaskID).style.display == "none") {

                if (navigator.appName != "Microsoft Internet Explorer") {
                    setLoadingPositionOfDivCenter_Ver2(Div_Customer);
                }
                showDivPopupCenter_Ver2(divMaskID);
            }
            else {
                showDivPopupCenter_Ver2(divMaskID);
            }
        }
        function RadWinClose() {
            document.getElementById("Div_Customer").style.display = "none";
            document.getElementById("divBackGroundNew").style.display = "none";
        }

        function OpenEditableTemplate(url) {
            var OSName;
            var nameOffset, verOffset, ix;
            if (navigator.appVersion.indexOf("Mac") != -1) OSName = "MacOS";
            if (navigator.appVersion.indexOf("Win") != -1) OSName = "Windows";

            var nVer = navigator.appVersion;
            var nAgt = navigator.userAgent;
            // In Chrome, the true version is after "Chrome" 
            if ((verOffset = nAgt.indexOf("Chrome")) != -1) {
                browserName = "Chrome";
            }
            // In Safari, the true version is after "Safari" or after "Version" 
            else if ((verOffset = nAgt.indexOf("Safari")) != -1) {
                browserName = "Safari";
            }
            // In Firefox, the true version is after "Firefox" 
            else if ((verOffset = nAgt.indexOf("Firefox")) != -1) {
                browserName = "Firefox";
            }
            //alert(browserName);            
            if (OSName == "MacOS" && !url.indexOf('et4')) {

                if (browserName == "Chrome") {
                    alert("Please use Firefox or Safari as Chrome does not support Microsoft Silverlight applications on a Mac.");
                }
                else {
                    window.open(url, '_blank');
                    window.focus();
                }
            }
            else {
                //                var a = document.createElement('a');
                //                a.href = url;
                //                a.target = '_blank';
                //                document.body.appendChild(a);

                //a.click();                   
                //window.location = url;

                window.open(url);
            }
        }

    </script>
    <script>
        function editstock(id) {
            var Rad1Customer = window.radopen(path + "common/common_popup.aspx?type=stockedit&action=edit&id=" + id, '1000', '500');
            SetRadWindow_Ver2('divrad', 'divBackGroundNew');
            Rad1Customer.setSize(1330, 520);
            Rad1Customer.center();
            Rad1Customer.id = "Radwindowstock";
        }

    </script>
    <script type="text/javascript" language="javascript">
        function addviews() {
            window.location.href = "<%=strSitepath%>" + "productcatalogue/customviewproduct.aspx";
        }
    </script>
    <script type="text/javascript">
        function editviewID_order() {
            var ddl = document.getElementById('ctl00_ContentPlaceHolder1_ddl_View');
            var editOrderViewID = document.getElementById("<%=editOrderViewID.ClientID %>");
            editOrderViewID.value = ddl.options[ddl.selectedIndex].value;

        }

        function ChangeView() {
            if (div_lblView.style.display == 'block') {
                document.getElementById("spn_change").innerHTML = "Cancel";
                div_lblView.style.display = 'none';
                div_ddlView.style.display = 'block';
            }
            else {
                document.getElementById("spn_change").innerHTML = "Change";
                div_lblView.style.display = 'block';
                div_ddlView.style.display = 'none';
            }
        }

        function Copy(val) {
            var hdnProcessedId = document.getElementById("<%=hdnProcessedId.ClientID %>");
            hdnProcessedId.value = val;
            document.getElementById("ctl00_ContentPlaceHolder1_lnkCopy").click();
        }

        function refreshGrid() {
            var masterTable = $find("<%=GridPriceCatalogue.ClientID%>").get_masterTableView();
            masterTable.rebind();
        }
    </script>
    <script type="text/javascript">
        function onResponse(response) {

        }
        function ProductVisibility(type) {
            var IDs = '';
            var frm = document.getElementById("<%=GridPriceCatalogue.ClientID %>").getElementsByTagName("input");
            var i = 1;
            for (l = 0; l < frm.length; l++) {
                if (frm[l].id.indexOf('checkBox_Copy') != -1) {
                    if (frm[l].checked) {
                        IDs = IDs + frm[l].value + ",";
                    }
                }
            }
            AutoFill.ProductVisibility(type, IDs, onResponse);
        }


    </script>
</asp:Content>
