<%@ control language="C#" autoeventwireup="true" CodeBehind="inventory_store_customer_view.ascx.cs" Inherits="ePrint.usercontrol.warehouse.inventory_store_customer_view"%>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script type="text/javascript" src="<%=strSitepath %>js/Item/warehouse_view.js?VN='<%=VersionNumber%>'"></script>
<%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <ajaxsettings>
        <telerik:AjaxSetting AjaxControlID="GridViewInv">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewInv" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewInv" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewInv" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="GridStoreSupply">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridStoreSupply" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridStoreSupply" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnStoreclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridStoreSupply" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="GridCustomerItem">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridCustomerItem" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridCustomerItem" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnItemclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridCustomerItem" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </ajaxsettings>
</telerik:RadAjaxManager>
<asp:UpdateProgress ID="upProgress" runat="server">
    <ProgressTemplate>
        <div id="divBackGround1">
            <div id="divLoading" style="position: absolute; z-index: 800; display: block;">
                <div class="Graphic">
                    <div style="padding-left: 25px">
                        <img src="<%=strImagepath %>loading_new.gif" border="0" />
                    </div>
                    <div style="clear: both">
                    </div>
                </div>
            </div>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<div align="left" style="width: 100%">
    <div id="ynnav">
        <ul>
            <li id="li_Inventory" style="cursor: pointer; float: left; clear: right; display: none;">
                <div id="div_33" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                    float: left; line-height: 20px; margin-right: 2px">
                    <b><span id="ware_1" class="lnkTabSelected" style="color: Orange;" onclick="changeCssWare(this.id);">
                        Inventory </span></b>
                </div>
            </li>
            <li id="li_StoreSupply" style="cursor: pointer; float: left; clear: right; display: none;">
                <div id="div_22" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px;
                    float: left; line-height: 20px; margin-right: 2px">
                    <b><span id="ware_2" class="lnkTabSelected" onclick="changeCssWare(this.id);">Store
                        Supply </span></b>
                </div>
            </li>
            <li id="li_CustomerItem" style="cursor: pointer; float: left; clear: right; display: none;">
                <div id="div1" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left;
                    line-height: 20px; margin-right: 2px">
                    <b><span id="ware_3" class="lnkTabSelected" onclick="changeCssWare(this.id);">Customer
                        Item </span></b>
                </div>
            </li>
        </ul>
    </div>
    <div class="onlyEmpty">
    </div>
    <div id="div_warehouse_border" style="margin-left: -5px;">
        <div align="left" style="width: 100%">
            <div id="divpadding" style="padding: 2px; width: 100%">
                <div align="center">
                    <div style="width: 90%">
                        <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div>
                    <div style="width: 50%;left: 48%;position: absolute;margin-top: -20px;">
                        <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhErrorMessage" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <%--Inventory--%>
                <div align="left" id="divinventory" style="width: 100%; display: none; vertical-align: top;
                    margin-top: -12px;" class="onlyEmpty">
                    <div style="height: 18px; margin-top:-20px; margin-bottom:10px;">
                         <div id="div_ddlView" style="float: left; /*display: none*/">
                                <asp:DropDownList ID="ddl_View" SkinID="onlyDDL" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged" Width="110%"
                               style="height:23px;border-radius:4px;background-color:white;  outline:none; cursor:pointer;" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div style="float: left; margin-left:35px; padding-top:3px;">
                                <asp:LinkButton ID="lnkInventoryedit" runat="server" Style="text-decoration: underline;"
                                    Text="Edit View" OnClientClick="javascript:return editviewID_inventory();" OnClick="btnEditViewInventory_Click"><%=objLanguage.GetLanguageConversion("Edit_Add")%></asp:LinkButton>
                                <%--&nbsp;/
                                <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                    cursor: pointer; color: #10357F;">
                                    <%=objLangClass.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                        onclick="javascript:addviews();" style="text-decoration: underline;display:none; cursor: pointer;
                                        color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                            </div>
                        <div style="float: right; padding-left: 5px; padding-top:5px;">
                            <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                cursor: pointer" runat="server" Text="clear all filters" />
                        </div>
                        <div style="border: 0px solid red; float: right; padding-right: 30px; margin-top: -5px;">
                            <div style="float: left; display: none;">
                                <span class="HeaderText" style="color: #787878">
                                    <%=objLangClass.GetLanguageConversion("Current_View")%></span>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div id="div_lblView" style="float: left; display: none;">
                                <asp:Label ID="lblView" runat="server"></asp:Label>
                            </div>
                           
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div style="float: left; display: none;">
                                <span class="normalText" style="color: #787878">
                                    <%=objLangClass.GetLanguageConversion("Or_Try")%></span> <a href="../warehouse/warehouse_inventory_search.aspx"
                                        id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                                        <%=objLanguage.GetLanguageConversion("Advanced_Search")%></a>
                            </div>
                        </div>
                    </div>
                    <div id="div_MainInv" runat="server" align="left" style="width: 100%;">
                        <div id="a">
                        </div>
                        <div id="div_Grid">
                            <div id="div_popupAction" style="" onmouseover="show();" onmouseout="hide(); ">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <div id="divarchive" runat="server" class="divDropdownlist" onclick="javascript:return CheckchkOne('archive');"
                                                style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; border-top: 0px solid #CBCBCB;">
                                                <asp:Label ID="lblArchive" runat="server"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="divunarchive" runat="server" class="divDropdownlist" onclick="javascript:return CheckchkOne('unarchive');"
                                                style="border-left: 1px solid #CBCBCB; border-right: 1px solid #CBCBCB; border-top: 1px solid #CBCBCB;">
                                                <asp:Label ID="lblUnArchive" runat="server"></asp:Label></div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div id="DivSelected" runat="server">
                                                <div onclick="javascript:return CheckchkOne('delete');" class="divDropdownlist" style="border: 1px solid #CBCBCB;">
                                                    <asp:Label ID="lblDelete" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <asp:HiddenField ID="hidGridRecord" runat="server" Value="" />
                            <telerik:RadGrid ID="GridViewInv" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridViewInv"
                                ShowGroupPanel="true" AllowFilteringByColumn="true" ShowStatusBar="true" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" 
                                OnNeedDataSource="GridViewInv_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewInv_SortCommand"
                                OnItemCommand="GridViewInv_ItemCommand" Skin="Sunset" AllowCustomPaging="true"
                                EnableEmbeddedSkins="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                <pagerstyle mode="NextPrevAndNumeric" alwaysvisible="false"></pagerstyle>
                                <filtermenu cssclass="RadMenu_Eprint_Skin" />
                                <%-- <ClientSettings AllowExpandCollapse="false">
                                    <Selecting />
                                    <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                </ClientSettings>--%>
                                <mastertableview overridedatasourcecontrolsorting="true" allowfilteringbycolumn="true"
                                    allowcustomsorting="true">
                                    <Columns>
                                        <%--     <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />--%>
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" AllowFiltering="false"
                                            Reorderable="false" ItemStyle-Wrap="false">
                                            <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                            <HeaderTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div id="div_chk" style="width: inherit; height: inherit;">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                    <tr>
                                                                        <td>
                                                                            <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input class="viewcheckboxpos" type="checkbox" runat="server" id="Id" onclick="CheckChanged(event,this,'ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_GridViewInv');"
                                                    name="Id" value='<%# DataBinder.Eval(Container, "DataItem.InventoryID", "{0}") %>' />
                                                <asp:HiddenField ID="hid_InventoryID" runat="server" Value='<%#Eval("InventoryID") %>' />
                                                <%--<asp:HiddenField ID="hid_UnitPrice" runat="server" Value='<%#Eval("UnitPrice") %>' />--%>
                                                <asp:HiddenField ID="hid_WeightSize" runat="server" Value='<%#Eval("BasisWeight")%>' />
                                                <asp:HiddenField ID="hid_Gsm" runat="server" Value='gsm' />
                                                <asp:HiddenField ID="hid_PaperName" runat="server" Value='<%#Eval("PaperName")%>' />
                                                <asp:HiddenField ID="hid_Height" runat="server" Value='<%#Eval("height") %>' />
                                                <asp:HiddenField ID="hid_Width" runat="server" Value='<%#Eval("Width") %>' />
                                                <asp:HiddenField ID="hid_Length" runat="server" Value='<%#Eval("Length") %>' />
                                                <asp:HiddenField ID="hid_WidthType" runat="server" Value='<%#Eval("WidthType") %>' />
                                                <asp:HiddenField ID="hid_LengthType" runat="server" Value='<%#Eval("LengthType") %>' />
                                                <asp:HiddenField ID="hid_PaperType" runat="server" Value='<%#Eval("PaperType") %>' />
                                                <asp:HiddenField ID="hid_PackedIn" runat="server" Value='<%#Eval("PackedIn") %>' />
                                                <asp:HiddenField ID="hid_StockType" runat="server" Value='<%#Eval("StockType")%>' />
                                                <asp:HiddenField ID="hid_PackedInType" runat="server" Value='<%#Eval("PackedInType")%>' />
                                                <%--<asp:HiddenField ID="hid_inkunitprice" runat="server" Value='<%#Eval("InkUnitPrice") %>' />
                                                <asp:HiddenField ID="hid_ChargableCost" runat="server" Value='<%#Eval("ChargableCost ") %>' />--%>
                                                <asp:HiddenField ID="hid_ChargableSheets" runat="server" Value='<%#Eval("ChargableSheets") %>' />
                                                <asp:HiddenField ID="hid_InkType" runat="server" Value='<%#Eval("InkType") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </mastertableview>
                                <clientsettings allowcolumnsreorder="false" reordercolumnsonclient="false" allowdragtogroup="false">
                                    <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                </clientsettings>
                                <filtermenu onclientshown="MenuShowing" />
                                <headerstyle width="200px" />
                                <itemstyle width="200px" />
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkInvDelete" runat="server" Text="" OnClick="lnkInvDelete_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkInvArchive" runat="server" Text="" OnClick="lnkInvArchive_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkInvUnArchive" runat="server" Text="" OnClick="lnkInvunArchive_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <%--Store Supply--%>
                <div align="left" id="divstore" style="width: 100%; display: none; vertical-align: top"
                    class="onlyEmpty">
                    <div style="height: 15px">
                        <div style="float: left; padding-left: 5px">
                            <asp:LinkButton ID="btnStoreclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                cursor: pointer" runat="server" Text="Clear all Filters" />
                        </div>
                        <div style="border: 0px solid red; float: right;">
                            <div style="float: left">
                                <span class="HeaderText" style="color: #787878">Current View:</span>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div id="div_lblViewStore" style="float: left; display: block">
                                <asp:Label ID="lblViewstore" runat="server"></asp:Label>
                            </div>
                            <div id="div_ddlviewstore" style="float: left; display: none">
                                <asp:DropDownList ID="ddl_View1" SkinID="onlyDDL" OnSelectedIndexChanged="ddlView1_OnSelectedIndexChanged"
                                    AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div style="float: left">
                                <a id="spnStore_Change" onclick="javascript:ChangeViewStore();" style="text-decoration: underline;
                                    cursor: pointer">Change</a>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div style="float: left">
                                <span class="normalText" style="color: #787878">Or try</span> <a href="../warehouse/warehouse_search.aspx?type=store"
                                    id="A3" style="text-decoration: underline" class="normaltext">
                                    <%=objLanguage.convert("Advanced Search")%></a>
                            </div>
                        </div>
                    </div>
                    <div id="div_MainSto" runat="server" align="left" style="width: 100%; padding-top: 5px">
                        <div id="a1">
                        </div>
                        <div id="div_Grid1">
                            <asp:HiddenField ID="hidStoreCount" runat="server" Value="" />
                            <telerik:RadGrid ID="GridStoreSupply" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridStoreSupply"
                                ShowGroupPanel="true" AllowFilteringByColumn="true" ShowStatusBar="true" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" 
                                OnNeedDataSource="GridViewStore_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewStore_SortCommand"
                                OnItemCommand="GridViewStore_ItemCommand" PageSize="50" Skin="Sunset"
                                EnableEmbeddedSkins="true"  PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                <pagerstyle mode="NextPrevAndNumeric" alwaysvisible="true"></pagerstyle>
                                <filtermenu cssclass="RadMenu_Eprint_Skin" />
                                <mastertableview overridedatasourcecontrolsorting="true" allowfilteringbycolumn="true">
                                    <Columns>
                                        <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" AllowFiltering="false"
                                            ItemStyle-Wrap="true" ItemStyle-Width="1%" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Wrap="false" HeaderStyle-Width="1%">
                                            <HeaderTemplate>
                                                <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                    value='<%# DataBinder.Eval(Container, "DataItem.FinishedGoodsID", "{0}") %>' />
                                                <asp:HiddenField ID="hid_UnitPrice" runat="server" Value='<%#Eval("UnitPrice") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </mastertableview>
                                <clientsettings allowcolumnsreorder="true" reordercolumnsonclient="true" allowdragtogroup="false">
                                </clientsettings>
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkStoDelete" runat="server" Text="" OnClick="lnkStoDelete_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkStoArchive" runat="server" Text="" OnClick="lnkStoArchive_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkStoUnArchive" runat="server" Text="" OnClick="lnkStoUnArchive_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <%--Customer Item--%>
                <div align="left" id="divcustomer" style="width: 100%; display: none; vertical-align: top"
                    class="onlyEmpty">
                    <div style="height: 15px">
                        <div style="float: left; padding-left: 5px">
                            <asp:LinkButton ID="btnItemclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline;
                                cursor: pointer" runat="server" Text="Clear all Filters" />
                        </div>
                        <div style="border: 0px solid red; float: right;">
                            <div style="float: left">
                                <span class="HeaderText" style="color: #787878">Current View:</span>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div id="div_lblviewCust" style="float: left; display: block">
                                <asp:Label ID="lblviewCust" runat="server"></asp:Label>
                            </div>
                            <div id="div_ddlviewCust" style="float: left; display: none">
                                <asp:DropDownList ID="ddl_View2" SkinID="onlyDDL" OnSelectedIndexChanged="ddlView2_OnSelectedIndexChanged"
                                    AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div style="float: left">
                                <a id="spn_custChange" onclick="javascript:ChangeViewCust();" style="text-decoration: underline;
                                    cursor: pointer">Change</a>
                            </div>
                            <div class="Only5pxWidth">
                                &nbsp;</div>
                            <div style="float: left">
                                <span class="normalText" style="color: #787878">Or try</span> <a href="../warehouse/warehouse_search.aspx?type=item"
                                    id="A4" style="text-decoration: underline" class="normaltext">
                                    <%=objLanguage.convert("Advanced Search")%></a>
                            </div>
                        </div>
                    </div>
                    <div id="div_MainCus" runat="server" align="left" style="width: 100%; padding-top: 5px">
                        <div id="a2">
                        </div>
                        <div id="div_Grid2">
                            <asp:HiddenField ID="hidCustomCount" runat="server" Value="" />
                            <telerik:RadGrid ID="GridCustomerItem" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridCust"
                                ShowGroupPanel="true" AllowFilteringByColumn="true" ShowStatusBar="true" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" 
                                OnNeedDataSource="GridCust_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridCustItem_SortCommand"
                                OnItemCommand="GridCust_ItemCommand" PageSize="50" Skin="Sunset"
                                EnableEmbeddedSkins="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                <pagerstyle mode="NextPrevAndNumeric" alwaysvisible="true"></pagerstyle>
                                <filtermenu cssclass="RadMenu_Eprint_Skin" />
                                <mastertableview overridedatasourcecontrolsorting="true" allowfilteringbycolumn="true">
                                    <Columns>
                                        <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" AllowFiltering="false"
                                            ItemStyle-Wrap="false">
                                            <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                            <ItemStyle HorizontalAlign="Center" Width="1%" />
                                            <HeaderTemplate>
                                                <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                    value='<%# DataBinder.Eval(Container, "DataItem.FinishedGoodsID", "{0}") %>' />
                                                <asp:HiddenField ID="hid_UnitPrice" runat="server" Value='<%#Eval("UnitPrice") %>' />
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </mastertableview>
                                <clientsettings allowcolumnsreorder="true" reordercolumnsonclient="true" allowdragtogroup="false">
                                </clientsettings>
                                <headerstyle width="120px" />
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkCusDelete" runat="server" Text="" OnClick="lnkCusDelete_OnClick"
                            OnClientClick="javascript:return CheckOne();start();" CausesValidation="false"
                            Visible="false"></asp:LinkButton></div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkCusArchive" runat="server" Text="" OnClick="lnkCusArchive_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div style="float: left">
                        <asp:LinkButton ID="lnkCusUnArchive" runat="server" Text="" OnClick="lnkCusUnArchive_OnClick"
                            OnClientClick="javascript:return CheckOne();" CausesValidation="false" Visible="false"></asp:LinkButton></div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_OnClick"></asp:LinkButton>
                <asp:Button ID="lnkCopy" runat="server" OnClick="lnkCopy_OnClick" class="show_hide">
                </asp:Button>
                <asp:HiddenField ID="hdnProcessedId" runat="server" Value="0" />
                <asp:HiddenField ID="hdnTabType" runat="server" Value="inventory" />
                <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                <asp:HiddenField ID="hdnInvDelIds" runat="server" Value="0" />
                <asp:HiddenField ID="hdnInvStoreDelIds" runat="server" Value="0" />
                <asp:HiddenField ID="hdnInvCustDelIds" runat="server" Value="0" />
                <asp:HiddenField ID="hid_custID" runat="server" Value="0" />
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender;
        var items = menu.get_items();
        if (column.get_dataType() == "System.String") {
            var i = 0;
            while (i < items.get_count() - 1) {
                if (items.getItem(i).get_value() in { 'GreaterThan': '', 'GreaterThanOrEqualTo': '', 'LessThan': '', 'LessThanOrEqualTo': '', 'NotEqualTo': '' }) {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(false);
                }
                else {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(true);
                } i++;
            }
        }
        column = null;
    }

    function filterMenuShowing(sender, eventArgs) {
        column = eventArgs.get_column();
    }

</script>
<script type="text/javascript" language="javascript">
    var GridViewInv = document.getElementById("<%=GridViewInv.ClientID%>");
    var GridStoreSupply = document.getElementById("<%=GridStoreSupply.ClientID%>");
    var GridCustomerItem = document.getElementById("<%=GridCustomerItem.ClientID%>");

    var module = '<%=InvenotoryInk %>';
    var Ware_itemtype = '<%=type %>';

    var Delete_Row_Selection_Alert = "<%=Delete_Row_Selection_Alert %>";
    var Archive_Row_Selection_Alert = "<%=Archive_Row_Selection_Alert %>";
    var UnArchive_Row_Selection_Alert = "<%=UnArchive_Row_Selection_Alert %>";
    var Archive_Confirmation_Alert = '<%=objLanguage.GetLanguageConversion("Archive_Confirmation_Alert") %>';
    var UnArchive_Confirmation_Alert = '<%=objLanguage.GetLanguageConversion("UnArchive_Confirmation_Alert") %>';
    var Delete_Confirmation_Alert = '<%=objLanguage.GetLanguageConversion("Delete_Confirmation_Alert") %>';
    var Inventory_Mandatory_Delete_Note = '<%=objLanguage.GetLanguageConversion("Inventory_Mandatory_Delete_Note") %>';
    var Inventory_Plant_Presses_Delete_Confirmation = '<%=objLanguage.GetLanguageConversion("Inventory_Plant_Presses_Delete_Confirmation") %>';

    //** Func to make grid scroll when In the Update Panel **//
    var clsTimeID = '';
    var TakeTimaeCount = 0;
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");

    var hdnInvDelIds = document.getElementById("<%=hdnInvDelIds.ClientID %>");
    var ctl00_tint_hdnIDs = document.getElementById("ctl00_tint_hdnIDs");
    var hdnInvStoreDelIds = document.getElementById("<%=hdnInvStoreDelIds.ClientID %>");
    var ctl00_tint_hdnIDs = document.getElementById("ctl00_tint_hdnIDs");
    var hdnInvCustDelIds = document.getElementById("<%=hdnInvCustDelIds.ClientID %>");
    var ctl00_tint_hdnIDs = document.getElementById("ctl00_tint_hdnIDs");

    //This Function is used in the ItemAdd.ascx page
    var InventoryFlag = false;
    var StoreFlag = false;
    var CustomerFlag = false;
    ////function changeCssWare(iss)

    function openwindow(type) {
        window.open("item_finishedgoods_add.aspx?page=" + type + "", "", "width=900,height=400,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }
    function openwindow1() {
        window.open("inventory_add.aspx?type=add", "", "width=850,height=600,status=no,align=center,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=270,top=100");
    }

    //Default Call
    var InvenotoryInk = "<%=InvenotoryInk %>";
    checkInk();

    var WareID, WareName, WareType, UnitPrice, PackedInQty;
    var IamFrom = "<%=IamFrom %>";

    function GetCustID(custid) {
        var hid_custID = document.getElementById("<%=hid_custID.ClientID %>");
        if (InvenotoryInk == "estimate") {
            hid_custID.value = custid;
        }
    }

    var div_lblView = document.getElementById("div_lblView");
    var div_ddlView = document.getElementById("div_ddlView");
    var div_lblViewStore = document.getElementById("div_lblViewStore");
    var div_ddlviewstore = document.getElementById("div_ddlviewstore");
    var div_lblviewCust = document.getElementById("div_lblviewCust");
    var div_ddlviewCust = document.getElementById("div_ddlviewCust");

    function ChangeView() {
        if (div_lblView.style.display == 'block') {
            div_lblView.style.display = 'none';
            div_ddlView.style.display = 'block';
            document.getElementById("spn_change").innerHTML = "Cancel";
        }
        else {
            div_lblView.style.display = 'block';
            div_ddlView.style.display = 'none';
            document.getElementById("spn_change").innerHTML = "Change";
        }
    }

    function ChangeViewStore() {
        if (div_lblViewStore.style.display == 'block') {
            div_lblViewStore.style.display = 'none';
            div_ddlviewstore.style.display = 'block';
            document.getElementById("spnStore_Change").innerHTML = "Cancel";
        }
        else {
            div_lblViewStore.style.display = 'block';
            div_ddlviewstore.style.display = 'none';
            document.getElementById("spnStore_Change").innerHTML = "Change";
        }
    }

    function ChangeViewCust() {
        if (div_lblviewCust.style.display == 'block') {
            div_lblviewCust.style.display = 'none';
            div_ddlviewCust.style.display = 'block';
            document.getElementById("spn_custChange").innerHTML = "Cancel";
        }
        else {
            div_lblviewCust.style.display = 'block';
            div_ddlviewCust.style.display = 'none';
            document.getElementById("spn_custChange").innerHTML = "Change";
        }
    }

    var checktrue = false;
    function checkall(tblid) {
        var tbl = document.getElementById(tblid);
        var tagcount = tbl.getElementsByTagName("input");
        for (var i = 0; i < tagcount.length; i++) {
            if (tagcount[i].type == 'checkbox') {
                if (tagcount[0].checked) {
                    tagcount[i].checked = true;
                    checktrue = true;
                    document.getElementById("lnkpo").className = "normalText";
                }
                else {
                    tagcount[i].checked = false;
                    checktrue = false;
                    document.getElementById("lnkpo").className = "disable";
                    document.getElementById("divmessage").style.display = "none";
                }
            }
        }
    }

    document.getElementById("ds00").style.display = "none";
    
</script>
<asp:HiddenField ID="editInvViewID" runat="server" Value="0" />
<script type="text/javascript">
    function editviewID_inventory() {
        var ddl = document.getElementById('ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_ddl_View');
        var editInvViewID = document.getElementById("<%=editInvViewID.ClientID %>");
        editInvViewID.value = ddl.options[ddl.selectedIndex].value;

    }

</script>
<asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
<script>

    document.getElementById("ds00").style.display = "none";

    var img_actionsShow = document.getElementById("img_actionsShow");
    var img_actionsHide = document.getElementById("img_actionsHide");
    var div_chk = document.getElementById("div_chk");
    var div_popupAction = document.getElementById("div_popupAction");
    var hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");

    var check = "";
    var Companyid = "<%=CompanyID %>";

    function show() {
        img_actionsHide.style.display = "block";
        img_actionsShow.style.display = "none";
        div_chk.style.border = "inset 1px";
        div_chk.style.background = "#C5C5C5";
        div_popupAction.style.display = "block";
    }

    function hide() {
        img_actionsHide.style.display = "none";
        img_actionsShow.style.display = "block";
        div_chk.style.border = "outset 1px";
        div_chk.style.background = "";
        div_popupAction.style.display = "none";
    }  

    function OnRowClick(EditPage) {
        window.location = EditPage;
    }

   
</script>
<script type="text/javascript" language="javascript">
    function addviews() {
        window.location.href = "<%=strSitepath%>" + "warehouse/customviewinv.aspx";
    }
</script>
<script type="text/javascript" language="javascript">
    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender; var items = menu.get_items();
        if (column.get_dataType() == "System.DateTime") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '', 'GreaterThan': '', 'LessThan': '' })) {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(false);
                }
                else {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(true);
                } i++;
            }
        }

        if (column.get_dataType() == "System.String") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'Contains': '', 'DoesNotContain': '', 'StartsWith': '', 'EndsWith': '', 'EqualTo': '' })) {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(false);
                }
                else {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(true);
                } i++;
            }
        }

        if (column.get_dataType() == "System.Decimal" || column.get_dataType() == "System.Int32") {
            var i = 0;
            while (i < items.get_count()) {
                if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '' })) {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(false);
                }
                else {
                    var item = items.getItem(i);
                    if (item != null)
                        item.set_visible(true);
                } i++;
            }
        }
        column = null;
        menu.repaint();
    }
    function filterMenuShowing(sender, eventArgs) {
        column = eventArgs.get_column();
    }

    function EraseCheck(val) {
            debugger
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
                    __doPostBack('ctl00$ContentPlaceHolder1$InventoryStoreCustomerView2$lnkDelete', '');

                }
                else {
                    return false;
                }
                //  return true;
            }
        }

    function Copy(val) {
            debugger
            var hdnProcessedId = document.getElementById("<%=hdnProcessedId.ClientID %>");
            hdnProcessedId.value = val;
            document.getElementById("ctl00_ContentPlaceHolder1_InventoryStoreCustomerView2_lnkCopy").click();
        }

</script>
