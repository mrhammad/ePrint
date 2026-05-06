<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="warehouse_listNew.ascx.cs" Inherits="ePrint.usercontrol.Item.warehouse_listNew" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="<%=strSitepath%>js/item/item_warehouse.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/Item/warehouse_view.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>' " language="javascript"></script>
<div id="ds00" style="display: block;">
</div>
<div id="div_Load" class="loading_new">
    <UC:Loading ID="ucLoading" runat="server" />
</div>
<script type="text/javascript">
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    document.getElementById("ds00").style.display = "block";
    document.getElementById("div_Load").style.display = "block";      
</script>
<script type="text/javascript">
    var div_Load = document.getElementById("div_Load");
    setLoadingPositionOfDivMove(div_Load);
    var strImagepath = '<%=strImagepath %>';
</script>
<div id="divBackGroundNew" style="display: none;">
</div>
<div id="div_AlertPopup" style="display: none; position: absolute; width: 1100px;
    left: 470px; z-index: 10;">
</div>
<asp:UpdateProgress ID="UpPro" runat="server">
    <ProgressTemplate>
        <div id="divLoading_Warehouse" class="loading_new">
            <UC:Loading ID="ucLoading1" runat="server" />
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
<div align="left" style="width: 100%;">
    <div align="left">
        <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
            <ContentTemplate>
                <table align="center" width="100%">
                    <tr>
                        <td align="left">
                            <asp:PlaceHolder ID="plhErrorMessage" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
<div align="left" style="width: 100%;">
    <asp:UpdatePanel ID="UpdatePanel2" RenderMode="Inline" runat="server">
        <ContentTemplate>
            <table align="center" width="100%">
                <tr>
                    <td align="center">
                        <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<div style="float: left; margin-left:0px;padding-top:5px;padding-bottom:5px;">
                            <asp:LinkButton ID="lnkPurchaseedit" runat="server" Style="text-decoration: underline;"
                                OnClientClick="javascript:return edit_estimatview();" OnClick="btnEditView_Click"><%=objLanguage.GetLanguageConversion("Edit_Add") %></asp:LinkButton>
                            <%--&nbsp;/
                            <a id="spn_change" onclick="javascript:ChangeView();" style="text-decoration: underline;
                                cursor: pointer; color: #10357F;">
                                <%=objLanguage.GetLanguageConversion("Change")%></a>&nbsp;/&nbsp;/--%><a id="spn_add"
                                    onclick="javascript:addviews();" style="text-decoration: underline; display:none; cursor: pointer;
                                    color: #10357F;"><%=objLanguage.GetLanguageConversion("Add")%></a>
                        </div>
<div id="div_warehouse_border">
    <asp:UpdatePanel ID="upWare" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
            <style type="text/css">
                .label_GV
                {
                    overflow: hidden;
                }
            </style>
            <div align="left">
                <div id="div_MainInv" runat="server" align="left" style="width: 100%; display: block;">
                    <div id="div_Grid" class="div_gridinv" style="margin-top: 0px;">
                        <telerik:RadGrid ID="GridViewInv" AllowSorting="true" ShowGroupPanel="true" AllowFilteringByColumn="true"
                            ShowStatusBar="true" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                            OnItemDataBound="OnItemDataBound_GridViewInv" GroupingEnabled="false" PageSize="50"
                            Skin="RadGrid_Eprint_Skin" EnableEmbeddedSkins="false" CssClass="RadGrid_Eprint_Skin"
                            PagerStyle-CssClass="RadComboBox_Eprint_Skin" OnSortCommand="GridViewInv_SortCommand"
                            OnNeedDataSource="GridViewInv_NeedDataSource" OnItemCommand="GridViewInv_ItemCommand">
                            <PagerStyle Mode="NextPrevAndNumeric"></PagerStyle>
                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                            <HeaderStyle Width="120px" />
                           <GroupingSettings CaseSensitive="false" />
                            <MasterTableView OverrideDataSourceControlSorting="true" CommandItemDisplay="Top">
                                <CommandItemTemplate>
                                    <div id="DivbtnAddNewRecord" runat="server">
                                        <table class="rgCommandTable" border="0" style="width: 100%;">
                                            <tr>
                                                <td align="left">
                                                    <asp:Button runat="server" OnClientClick="javascript:popWindow('inventory');" ID="btnAddNewRecord"
                                                        class="rgAdd" />
                                                    <a href="#" id="ware_1" onclick="javascript:popWindow('inventory');">
                                                        <%=objLanguage.GetLanguageConversion("Add_New_Inventory")%></a>
                                                </td>
                                                <td align="right">
                                                    <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer"
                                                        runat="server" OnClick="clrFilters_Click"><%=objLanguage.GetLanguageConversion("Clear_All_Filters")%></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </CommandItemTemplate>
                                <Columns>
                                    <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                    <telerik:GridTemplateColumn SortExpression="InventoryCode" UniqueName="InventoryCode"
                                        DataField="InventoryCode" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="left" Wrap="false" Width="15%" />
                                        <ItemStyle HorizontalAlign="left" Width="15%" />
                                        <HeaderTemplate>
                                            <div style="float: left; width: 99%; overflow: hidden">
                                                <asp:Label ID="lbl_InventoryCode" runat="server" Text="Inventory Code"><%=objLanguage.GetLanguageConversion("Inventory_Code")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 99%; overflow: hidden">
                                            <asp:LinkButton ID="lbl_InventoryCode" OnClientClick='<%# Eval("InventoryID", "SelectInv({0})") %>' runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.InventoryCode","{0}")) %>'></asp:LinkButton></div>
                                            <asp:HiddenField ID="hid_InventoryID" runat="server" Value='<%#Eval("InventoryID") %>' />
                                            <asp:HiddenField ID="hid_UnitPrice" runat="server" Value='<%#Eval("UnitPrice") %>' />
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
                                            <asp:HiddenField ID="hid_cost" runat="server" Value='<%#Eval("Cost")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn SortExpression="InventoryName" UniqueName="InventoryName"
                                        DataField="InventoryName" AutoPostBackOnFilter="true">
                                        <HeaderStyle HorizontalAlign="left" Wrap="false" Width="20%" />
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderTemplate>
                                            <div style="float: left; width: 99%; overflow: hidden">
                                                <asp:Label ID="lbl_InventoryName" runat="server" Text="Inventory Name"><%=objLanguage.GetLanguageConversion("Inventroy_Name")%></asp:Label>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="float: left; width: 99%; overflow: hidden; max-height: 15px; height: 15px;">
                                                <asp:LinkButton ID="lbl_InventoryName_val" OnClientClick='<%# Eval("InventoryID", "SelectInv({0})") %>' runat="server" CssClass="label_GV" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container,"Dataitem.InventoryName","{0}")) %>'></asp:LinkButton><%--</div>--%>
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="Cost" SortExpression="Cost" HeaderText="" DataField="Cost"
                                        AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="7%" HorizontalAlign="Right"></HeaderStyle>
                                        <ItemStyle Width="7%" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="SupplierName" SortExpression="SupplierName"
                                        DataField="SupplierName" HeaderText="Supplier Name" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="25%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="25%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="UnitPrice" SortExpression="UnitPrice" HeaderText=""
                                        DataField="UnitPrice" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="5%" HorizontalAlign="Right"></HeaderStyle>
                                        <ItemStyle Width="5%" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="Description" HeaderText="Description" DataField="Description"
                                        SortExpression="Description" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="CreatedDate" HeaderText="Created Date" DataField="CreatedDate"
                                        SortExpression="CreatedDate" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="Archived" HeaderText="Archived" DataField="Archived"
                                        SortExpression="Archived" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="AvailableQuantity" HeaderText="Available Quantity" DataField="AvailableQuantity"
                                        SortExpression="AvailableQuantity" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="Location" HeaderText="Location" DataField="Location"
                                        SortExpression="Location" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="FriendlyName" HeaderText="Friendly Name" DataField="FriendlyName"
                                        SortExpression="FriendlyName" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="Color" HeaderText="Color" DataField="Color"
                                        SortExpression="Color" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="StockType" HeaderText="Stock Type" DataField="StockType"
                                        SortExpression="StockType" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="Weight" HeaderText="Weight/Size" DataField="Weight"
                                        SortExpression="Weight" AutoPostBackOnFilter="true">
                                        <HeaderStyle Width="50%" HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle Width="50%" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings AllowColumnsReorder="true" ReorderColumnsOnClient="true" AllowDragToGroup="false">
                            </ClientSettings>
                        </telerik:RadGrid>
                    </div>
                </div>
                <div style="clear: both">
                    <asp:HiddenField ID="hid_plhMessage" runat="server" Value="" />
                    <asp:HiddenField ID="hid_InventoryNo" runat="server" Value="" />
                    <asp:LinkButton ID="btn_inventory" runat="server" Text="" OnClick="btnsubmit_onclick" />
                </div>
            </div>
            <script type="text/javascript">
                function CallOverflow1() {
                    var GridItemTitle = document.getElementById("<%=GridViewInv.ClientID %>");
                    SetGridOverflow(GridItemTitle);
                }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_inventory" EventName="click" />
        </Triggers>
    </asp:UpdatePanel>
</div>
<div align="left" style="width: 49%">
    <div class="box">
        <div id="div_warehouseMainItems" style="position: absolute; display: none; z-index: 500;
            width: 300px; height: 75px;">
            <div align="left" class="bgcustomize" style="padding: 2px; padding-right: 0px;">
                <div style="float: left; width: 175px">
                    <span class="navigatorpanel" style="vertical-align: middle; text-align: left;">
                        <%=objLanguage.GetLanguageConversion("Item") %></span>
                </div>
                <div style="float: left; width: 50px;">
                    <span class="navigatorpanel" style="text-align: left;">
                        <%=objLanguage.GetLanguageConversion("Quantity")%></span>
                </div>
                <div align="right" style="float: right;">
                    <a href="javascript://" onclick="ShowWarehouseMainItems();return false;">
                        <img src="<%=strImagepath%>close1.jpg" title="Close" border="0" width="10px" height="10px" /></a></div>
                <div style="clear: both">
                </div>
            </div>
            <div id="div_ware_MainItemadd" align="left" class="divborderItem" style="overflow-y: scroll;
                clear: both; padding: 2px; height: 100px; background-color: white;">
            </div>
        </div>
        <a id="href_showware_MainItem" href="javascript://" style="display: none;" onclick="ShowWarehouseMainItems();return false;">
            <%=objLanguage.GetLanguageConversion("Show_WareHouse_Items") %></a>
    </div>
</div>
<div id="div_inventory_select" style="display: none; position: absolute; z-index: 1000;
    width: 40%" align="center">
    <asp:Panel ID="pnladd" DefaultButton="Button6" runat="server">
        <table cellpadding="0" cellspacing="0" width="100%" border="0px">
            <tr>
                <td colspan="2" class="popup-top-leftcorner">
                    &nbsp;
                </td>
                <td class="popup-top-middlebg">
                    <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                        padding-left: 1px">
                        <b>
                            <%=objLanguage.GetLanguageConversion("Quantity") %></b>
                        <asp:Label ID="Label1" runat="server"></asp:Label></div>
                    <div style="float: right; padding-top: 6px; padding-right: 10px">
                        <div class="CancelButtonDiv">
                            <asp:ImageButton ID="ImageButton2" ToolTip="Close" ImageUrl="~/images/closebtn.png"
                                runat="server" CausesValidation="false" OnClientClick="CloseAddPanel_Estimate();return false;" />
                        </div>
                    </div>
                </td>
                <td colspan="2" class="popup-top-rightcorner">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="popup-middle-leftcorner">
                    &nbsp;
                </td>
                <td style="width: 15px; background-color: #ffffff">
                    &nbsp;
                </td>
                <td class="popup-middlebg" align="center">
                    <div style="padding: 10px 5px 5px 0px; width: 98%">
                        <div class="" style="width: 100%">
                            <table cellpadding="2" cellspacing="2" border="0" width="100%">
                                <tr>
                                    <td valign="top">
                                        <div style="width: 100%; padding-left: 0px;">
                                            <div class="bglabel" style="float: left; width: 160px;">
                                                <asp:Label ID="Label135" runat="server" Text="Quantity Required" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Quantity_Require")%></asp:Label>
                                                <san stpyle="color: Red; padding-left: 4px">*</san>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtWarehouseQuantity" onblur="AllowNumber(this,this.value);MakePrice2Decimal(this);"
                                                    MaxLength="20" SkinID="textPad" runat="server" Width="150px" onfocus="this.select();"
                                                    onclick="this.select();"></asp:TextBox>
                                                <span id="spn_txtWarehouseQuantity" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity")%></span><span id="spn_txtWarehouseQuantity_number"
                                                        class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                        display: none;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>

                                            </div>

                                             <div class="bglabel" style="float: left; width: 160px;">
                                                <asp:Label ID="Label136" runat="server" Text="Quantity2 Required" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Quantity_Require2")%></asp:Label>
                                                <san stpyle="color: Red; padding-left: 4px">*</san>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtWarehouseQuantity2" onblur="AllowNumber(this,this.value);MakePrice2Decimal(this);"
                                                    MaxLength="20" SkinID="textPad" runat="server" Width="150px" onfocus="this.select();"
                                                    onclick="this.select();"></asp:TextBox>
                                                <span id="spn_txtWarehouseQuantity2" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity")%></span><span id="spn_txtWarehouseQuantity_number2"
                                                        class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                        display: none;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>

                                            </div>

                                             <div class="bglabel" style="float: left; width: 160px;">
                                                <asp:Label ID="Label137" runat="server" Text="Quantity3 Required" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Quantity_Require3")%></asp:Label>
                                                <san stpyle="color: Red; padding-left: 4px">*</san>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtWarehouseQuantity3" onblur="AllowNumber(this,this.value);MakePrice2Decimal(this);"
                                                    MaxLength="20" SkinID="textPad" runat="server" Width="150px" onfocus="this.select();"
                                                    onclick="this.select();"></asp:TextBox>
                                                <span id="spn_txtWarehouseQuantity3" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity")%></span><span id="spn_txtWarehouseQuantity_number3"
                                                        class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                        display: none;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>

                                            </div>

                                             <div class="bglabel" style="float: left; width: 160px;">
                                                <asp:Label ID="Label138" runat="server" Text="Quantity4 Required" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Quantity_Require4")%></asp:Label>
                                                <san stpyle="color: Red; padding-left: 4px">*</san>
                                            </div>
                                            <div class="box">
                                                <asp:TextBox ID="txtWarehouseQuantity4" onblur="AllowNumber(this,this.value);MakePrice2Decimal(this);"
                                                    MaxLength="20" SkinID="textPad" runat="server" Width="150px" onfocus="this.select();"
                                                    onclick="this.select();"></asp:TextBox>
                                                <span id="spn_txtWarehouseQuantity4" class="spanerrorMsg" style="display: none; width: auto;
                                                    padding-left: 4px; padding-right: 4px">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Quantity")%></span><span id="spn_txtWarehouseQuantity_number4"
                                                        class="spanerrorMsg" style="width: auto; padding-left: 4px; padding-right: 4px;
                                                        display: none;"><%=objLanguage.GetLanguageConversion("Please_Enter_Numeric_Value")%></span>

                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" id="Div_ItemDescn" runat="server" visible="false">
                                            <div class="bglabelnewLarge" style="float: left; width: 160px; margin-top: -6px;">
                                                <asp:Label ID="Label7" runat="server" Text="Update Item Descriptions" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Update_Item_Description") %></asp:Label>
                                                <a id="img_UpdateDEscription" runat="server" href="javascript:void(0);" class="tooltip_ppup_tip"
                                                    title="Untick this box if you want the item description fields not to be overwritten during the rerun process.">
                                                    <img alt="" id="Img_ItemDescnHelp" src="../../images/Help-icon.png" runat="server"
                                                        style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                                        class="tooltip" /></a>
                                            </div>
                                            <style type="text/css">
                                                
                                            </style>
                                            <div class="box" style="float: left;">
                                                <div id="div2" align="left">
                                                    <asp:CheckBox ID="Chk_ItemDescn" runat="server" Checked="false" />
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div align="left" id="Div_Productcatalogue" runat="server" visible="false">
                                            <div class="bglabelnewLarge" style="float: left; width: 31%;">
                                                <asp:Label ID="Label2" runat="server" Text="Product Catalogue" CssClass="normaltext"></asp:Label>
                                                <%--<span> <%=objLanguage.GetLanguageConversion("ReRun_Process_Duplicate_Note_For_Estimate")%> </span>--%>
                                                <%--<a href="javascript:void(0);" class="tooltip" title="Untick this box if you want the item description fields not to be overwritten during the rerun process.">
                            <img alt="" id="Img1" src="../../images/Help-icon.png" runat="server"
                                style="cursor: pointer; width: 16px; height: 16px; margin: 0px 0px 0px 0px; border: solid 0px green;"
                                class="tooltip" /></a>--%>
                                            </div>
                                            <div class="box" style="float: left;">
                                                <div id="div3" align="left" style="vertical-align: top;">
                                                    <asp:CheckBox ID="chkPoduct1" runat="server" Checked="true" Text="Update product Info/Price"
                                                        onclick="javascript:OnChkchanged1();" /><br />
                                                    <asp:CheckBox ID="chkPoduct2" runat="server" Text="Delete and Recreate" onclick="javascript:OnChkchanged2();" />
                                                    <br />
                                                    <div class="smallgraytext">
                                                        Note: Quantity may be updated/added
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div style="float: left; margin-left: 38.5%;">
                                            <asp:Button ID="Button6" CssClass="button" Text="Add" runat="server" OnClientClick="javascript: var a = WarehouseAddButton('add'); if(a) { var b = InnventoryPrompt(); return b;}"
                                                OnClick="OnClick_WarehouseInsert" /><%--javascript:WarehouseAddButton('add');return false;--%>
                                        </div>
                                        <div style="float: left;" visible="false">
                                            <asp:Button ID="Button8" CssClass="button" Text="Add and Remain here" OnClientClick="javascript:return WarehouseAddButton('more');"
                                                OnClick="OnClick_WarehouseInsert" runat="server" Visible="false" />
                                            <asp:HiddenField runat="server" ID="hdnProtrait" Value="0" />
                                            <asp:HiddenField runat="server" ID="hdnLandscale" Value="0" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
                <td style="width: 10px; background-color: #ffffff">
                    &nbsp;
                </td>
                <td align="right" class="popup-middle-rightcorner">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" class="popup-bottom-leftcorner">
                    &nbsp;
                </td>
                <td class="popup-bottom-middlebg">
                    &nbsp;
                </td>
                <td colspan="2" class="popup-bottom-rightcorner">
                    &nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
<div align="left">
    <div style="float: left; width: 79%;">
        &nbsp;</div>
    <div style="float: right; width: 20%; margin-top: 5px;">
        <div style="float: left;">
            <div id="div_btnprev" style="display: block">
                <asp:Button ID="btnprevious" CssClass="button" OnClick="btnprevious_onclick" OnClientClick="javascript:loadingimg('div_btnprev','div_prevprocess')"
                    runat="server" Text="Previous" />
            </div>
            <div id="div_prevprocess" class="button" align="center" style="width: 55px; display: none">
                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
            </div>
        </div>
        <div style="float: left; width: 10px">
            &nbsp;</div>
        <div id="div_WarehouseNextButton" style="float: left;">
            <div id="div_finish">
                <asp:Button ID="Button3" CssClass="button" OnClientClick="javascript:var a=SaveDataForWarehouse();if(a)loadingimg('div_finish','div_finishprocess');return a;"
                    runat="server" Text="Finish" OnClick="OnClick_WarehouseInsert" /></div>
            <div id="div_finishprocess" class="button" align="center" style="width: 37px; display: none">
                <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
            </div>
        </div>
    </div>
</div>
<%--<div class="onlyEmpty" style="height: 35px;">
</div>--%>
<asp:HiddenField ID="hid_warehouse_save" runat="server" />
<asp:HiddenField ID="hdn_WarehouseDesc" runat="server" Value="" />
<asp:HiddenField ID="hid_ware_data" Value="" runat="server" />
<div id="div_warehouse_summary" style="display: none">
    <div style="float: left; width: 100%;">
        <div style="width: 60%;">
            <div id="div_WareItemTitle" align="left">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <div style="height: 15px;">
                        &nbsp;
                    </div>
                    <div style="clear: both">
                    </div>
                    <asp:CheckBox ID="chkWareItemtitle" runat="server" Checked="true" />
                </div>
                <div style="float: left; width: 96%;">
                    <div style="float: left; width: 100%;">
                        <div style="float: left;">
                            <div style="height: 15px; width: 30px">
                                &nbsp;
                            </div>
                            <div style="clear: both">
                            </div>
                            <div class="bglabel_new" style="width: 229px; float: left">
                                <div style="float: left">
                                    <asp:TextBox ID="txt_lblWareItemtitle" SkinID="textPad" runat="server" Width="140px"
                                        MaxLength="50"></asp:TextBox>
                                </div>
                                <div style="float: right">
                                    <asp:ImageButton Style="vertical-align: top;" ID="ImageButton45" runat="server" CausesValidation="False"
                                        ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Title');return false;" /></div>
                                <asp:HiddenField ID="hdn_lblWareItemtitle" runat="server" Value="" />
                            </div>
                        </div>
                        <div style="float: left;">
                            <div style="float: left; padding-left: 5px">
                                <div style="height: 17px; width: 50px">
                                    &nbsp;
                                </div>
                                <div style="clear: both">
                                </div>
                                <asp:TextBox ID="txtWareItemTitle" SkinID="textPad" runat="server" Width="250px"
                                    MaxLength="50"></asp:TextBox>
                            </div>
                            <div style="float: left;">
                                <div style="float: left; padding-bottom: 4px">
                                    &nbsp;Save to phrase book
                                </div>
                                <div style="clear: both">
                                </div>
                                <div style="float: left;">
                                    <asp:CheckBox ID="chk_Ware_Phrase_ItemTitle" runat="server" /></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div align="left" style="display: none">
                <div class="bglabel">
                    <asp:Label ID="Label133" runat="server" Text="Warehouse" CssClass="normaltext"></asp:Label></div>
                <div class="box">
                    <asp:Label ID="Label134" runat="server" CssClass="graytext"></asp:Label></div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareDescription" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareDescription" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px; height: 41px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareDescription" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton46" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Description');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareDescription" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareDesign" SkinID="textPad" TextMode="MultiLine" runat="server"
                                Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Design" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareArtwork" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareArtwork" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareArtwork" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton47" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Artwork');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareArtwork" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareArtwork" SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Artwork" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareColour" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareColour" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareColour" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton48" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Colours');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareColour" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareColour" SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Colour" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareSize" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareSize" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareSize" SkinID="textPad" runat="server" Width="140px" MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton49" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Size');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareSize" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareSize" SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Size" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareMaterial" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareMaterial" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareMaterial" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton50" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Material');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareMaterial" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareMaterial" SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Material" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareDelivery" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareDelivery" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareDelivery" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton51" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Delivery');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareDelivery" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareDelivery" SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Delivery" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareFinishing" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareFinishing" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareFinishing" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton52" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Finishing');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareFinishing" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareFinishing" SkinID="textPad" runat="server" Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Finishing" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareNotes" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareNotes" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px; height: 41px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareNotes" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton53" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Notes');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareNotes" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareNotes" TextMode="MultiLine" SkinID="textPad" runat="server"
                                Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Notes" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
            <div style="clear: both; padding-top: 2px">
            </div>
            <div id="div_WareInstructions" align="left" style="display: none">
                <div style="float: left; margin-right: 2px; padding: 3px 0px 3px 0px; width: 3%;">
                    <asp:CheckBox ID="chkWareInstructions" runat="server" Checked="true" /></div>
                <div style="float: left; width: 90%">
                    <div class="bglabel_new" style="width: 229px; height: 41px;">
                        <div style="float: left">
                            <asp:TextBox ID="txt_lblWareInstructions" SkinID="textPad" runat="server" Width="140px"
                                MaxLength="50"></asp:TextBox>
                        </div>
                        <div style="float: right">
                            <asp:ImageButton Style="vertical-align: top;" ID="ImageButton69" runat="server" CausesValidation="False"
                                ImageUrl="~/images/plus.gif" ToolTip="Select Phrase Book" OnClientClick="javascript:popup_phrasebook('Estimate Terms');return false;" /></div>
                        <asp:HiddenField ID="hdn_lblWareInstructions" runat="server" Value="" />
                    </div>
                    <div class="box">
                        <div style="float: left">
                            <asp:TextBox ID="txtWareInstructions" TextMode="MultiLine" SkinID="textPad" runat="server"
                                Width="250px"></asp:TextBox>
                        </div>
                        <div style="float: left;">
                            <asp:CheckBox ID="chk_Ware_Phrase_Instructions" runat="server" />
                        </div>
                    </div>
                    <div class="onlyEmpty">
                    </div>
                </div>
                <div class="onlyEmpty">
                </div>
            </div>
        </div>
    </div>
</div>
<div id="div_StockAlertNew" style="display: none; position: absolute; vertical-align: middle;
    z-index: 1000; width: 35%" align="center">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="2" class="popup-top-leftcorner">
                &nbsp;
            </td>
            <td class="popup-top-middlebg">
                <div align="left" class="Label-PopupHeading" style="float: left; padding-top: 6px;
                    padding-left: 1px">
                    <b>Stock Alert </b>
                    <asp:Label ID="Label10" runat="server"></asp:Label></div>
                <div style="float: right; padding-top: 6px; padding-right: 10px">
                    <div class="CancelButtonDiv">
                        <asp:ImageButton ID="ImageButtonNew2" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                            runat="server" CausesValidation="false" OnClientClick="javascript:return SaveNew1('N');" />
                    </div>
                </div>
            </td>
            <td colspan="2" class="popup-top-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="popup-middle-leftcorner">
                &nbsp;
            </td>
            <td style="width: 15px; background-color: #ffffff">
                &nbsp;
            </td>
            <td class="popup-middlebg" align="center">
                <div style="padding: 10px 5px 10px 0px; width: 98%">
                    <div class="" style="width: 100%">
                        <table cellpadding="2" cellspacing="2" border="0" width="100%">
                            <tr>
                                <td valign="top">
                                    Do you want the quantity to be added back to the inventory?
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnYes1" Text="Yes" CssClass="button" runat="server" UseSubmitBehavior="false"
                                        OnClientClick="javascript:return SaveNew1('Y');" />
                                    <asp:Button ID="btnNo1" Text="No" CssClass="button" runat="server" UseSubmitBehavior="false"
                                        OnClientClick="javascript:return SaveNew1('N');" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
            <td style="width: 10px; background-color: #ffffff">
                &nbsp;
            </td>
            <td align="right" class="popup-middle-rightcorner">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" class="popup-bottom-leftcorner">
                &nbsp;
            </td>
            <td class="popup-bottom-middlebg">
                &nbsp;
            </td>
            <td colspan="2" class="popup-bottom-rightcorner">
                &nbsp;
            </td>
        </tr>
    </table>
</div>
<div id="divrad" style="display: none;">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="500" OnClientClose="RadWinClose"
        Behaviors="Close, Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField ID="hdnStockReduce" runat="server" />
<asp:HiddenField ID="hdnStockReduceNew" runat="server" />
<script type="text/javascript" language="javascript">


    var hdnStockReduce = document.getElementById("<%=hdnStockReduce.ClientID %>");
    var hdnStockReduceNew = document.getElementById("<%=hdnStockReduceNew.ClientID %>");
    var CompanyID = '<%=CompanyID%>';
    var UserID = '<%=UserID%>';
    var reduceStockTypeForCancelled = '<%=ReduceStockTypeForCancelled%>';
    var inventoryManagement = '<%=InventoryManagement%>';
    var moduleTyp = '<%=modulename %>';
    var estimateType = 'warehouse';
    var oldWareItemID = '<%=oldWareItemID %>';
    var oldQuantity = '<%=oldQuantity %>';
    var QueryType = "<%=QueryType %>";

    //*************** WAREHOUSE ************************************
    var WareID1, WareName1, WareType1, UnitPrice1, WareItemID1 = 0, PackedInQty1 = 0;

    //To bind othetcost desc//
    var hdn_WarehouseDesc = document.getElementById("<%=hdn_WarehouseDesc.ClientID %>");
    var txt_lblWareItemtitle = document.getElementById("<%=txt_lblWareItemtitle.ClientID %>");
    var txt_lblWareDescription = document.getElementById("<%=txt_lblWareDescription.ClientID %>");
    var txt_lblWareArtwork = document.getElementById("<%=txt_lblWareArtwork.ClientID %>");
    var txt_lblWareColour = document.getElementById("<%=txt_lblWareColour.ClientID %>");
    var txt_lblWareSize = document.getElementById("<%=txt_lblWareSize.ClientID %>");
    var txt_lblWareMaterial = document.getElementById("<%=txt_lblWareMaterial.ClientID %>");
    var txt_lblWareDelivery = document.getElementById("<%=txt_lblWareDelivery.ClientID %>");
    var txt_lblWareFinishing = document.getElementById("<%=txt_lblWareFinishing.ClientID %>");
    var txt_lblWareNotes = document.getElementById("<%=txt_lblWareNotes.ClientID %>");
    var txt_lblWareInstructions = document.getElementById("<%=txt_lblWareInstructions.ClientID %>");

    var hdn_lblWareItemtitle = document.getElementById("<%=hdn_lblWareItemtitle.ClientID %>");
    var hdn_lblWareDescription = document.getElementById("<%=hdn_lblWareDescription.ClientID %>");
    var hdn_lblWareArtwork = document.getElementById("<%=hdn_lblWareArtwork.ClientID %>");
    var hdn_lblWareColour = document.getElementById("<%=hdn_lblWareColour.ClientID %>");
    var hdn_lblWareSize = document.getElementById("<%=hdn_lblWareSize.ClientID %>");
    var hdn_lblWareMaterial = document.getElementById("<%=hdn_lblWareMaterial.ClientID %>");
    var hdn_lblWareDelivery = document.getElementById("<%=hdn_lblWareDelivery.ClientID %>");
    var hdn_lblWareFinishing = document.getElementById("<%=hdn_lblWareFinishing.ClientID %>");
    var hdn_lblWareNotes = document.getElementById("<%=hdn_lblWareNotes.ClientID %>");
    var hdn_lblWareInstructions = document.getElementById("<%=hdn_lblWareInstructions.ClientID %>");

    var txtWareItemTitleID = document.getElementById("<%=txtWareItemTitle.ClientID %>");
    var txtWareDesign = document.getElementById("<%=txtWareDesign.ClientID %>");
    var txtWareArtwork = document.getElementById("<%=txtWareArtwork.ClientID %>");
    var txtWareColour = document.getElementById("<%=txtWareColour.ClientID %>");
    var txtWareSize = document.getElementById("<%=txtWareSize.ClientID %>");
    var txtWareMaterial = document.getElementById("<%=txtWareMaterial.ClientID %>");
    var txtWareDelivery = document.getElementById("<%=txtWareDelivery.ClientID %>");
    var txtWareFinishing = document.getElementById("<%=txtWareFinishing.ClientID %>");
    var txtWareNotes = document.getElementById("<%=txtWareNotes.ClientID %>");
    var txtWareInstructions = document.getElementById("<%=txtWareInstructions.ClientID %>");

    //BindWarehouseDesc()

    var hid_warehouse_save = document.getElementById("<%=hid_warehouse_save.ClientID %>");
    var hid_ware_data = document.getElementById("<%=hid_ware_data.ClientID %>");

            
</script>
<script type="text/javascript">
    var len = 0;
    function StoreOnlyWarehouseItem() {
        SaveDataForWarehouse();
    }

    function showDivAlert(leng) {
        document.getElementById("div_warehouseMainItems").style.zIndex = "0";
        showDivPopupCenter('div_StockAlertNew', '200');
        len = leng;

    }
    function SaveNew1(val) {
        if (val == 'Y') {
            hdnStockReduce.value = hdnStockReduce.value + hdnStockReduceNew.value;
        }
        document.getElementById("divBackGroundNew").style.display = "none";
        document.getElementById("div_StockAlertNew").style.display = "none";
        document.getElementById("div_warehouseMainItems").style.zIndex = "500";
        if (len) {
            document.getElementById("href_showware_MainItem").style.display = "none";
        }
        return false;
    }
    function RadWinClose() {
        document.getElementById("divrad").style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
    }
</script>
<asp:HiddenField ID="hidEditMainWarehouse" Value="" runat="server" />
<asp:HiddenField ID="hdn_invStockReduce" runat="server" Value="" />
<asp:Panel ID="pnlWarehouseOnly" Visible="false" runat="server">
    <script>
        LoadMainWarehouseItems();
    </script>
</asp:Panel>
<script type="text/javascript">

    var Gridinv = document.getElementById("<%=GridViewInv.ClientID %>");

    var WareID, WareName, WareType, UnitPrice, PackedInQty;
    var IamFrom = "AddEstimate";


    function ShowWarehouseMainItems() {
        if (document.getElementById('div_warehouseMainItems').style.display == "none") {
            document.getElementById('div_warehouseMainItems').style.display = "block";
        }
        else {
            document.getElementById('div_warehouseMainItems').style.display = "none";
        }
    }
    debugger;
    var txtWarehouseQuantity = document.getElementById("<%=txtWarehouseQuantity.ClientID %>");
    var txtWarehouseQuantity2 = document.getElementById("<%=txtWarehouseQuantity2.ClientID %>");
    var txtWarehouseQuantity3 = document.getElementById("<%=txtWarehouseQuantity3.ClientID %>");
    var txtWarehouseQuantity4 = document.getElementById("<%=txtWarehouseQuantity4.ClientID %>");

      
</script>
<script type="text/javascript" language="javascript">
    var hid_plhMessage = document.getElementById("<%=hid_plhMessage.ClientID %>");

    var IsInv_Loaded = false;
    var IsStore_Loaded = false;
    var IsCust_Loaded = false;
    function Call_Warehouse_Ind_fun(liID) {
        if (liID == "ware_1") {
            if (IsInv_Loaded == false) {
                IsInv_Loaded = false;
                __doPostBack('ctl00$ContentPlaceHolder1$UCWare$btn_inventory', '');
            }
        }
        hid_plhMessage.value = "abc";
    }


    function popWindow(type) {

        var strSitepath = "<%=strSitepath%>";
        var modulename = "<%=modulename %>";
        var QueryType = "<%=QueryType %>";
        var EstimateID = "<%= EstimateID%>";
        if (modulename == "jobs") {
            modulename = "job";
        }

        if (type == 'inventory') {
            window.radopen(strSitepath + "common/Inventory_FinishedGoods_Add.aspx?type=inventory&page=FrmWareList&post=" + modulename + "&mode=" + QueryType + "&estid=" + EstimateID + "",null, '1200', '600');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
        }
    }

    function Reloadgrid(ProductType) {
        hid_plhMessage.value = "succ";
        if (ProductType == "inventory") {
            Call_Warehouse_Ind_fun("ware_1");
        }
    }
    function OnChkchanged1() {

        var chkPoduct1 = document.getElementById("<%=chkPoduct1.ClientID %>");
        var chkPoduct2 = document.getElementById("<%=chkPoduct2.ClientID %>");
        if (chkPoduct1.checked) {
            chkPoduct2.checked = false;
        }
        else {
            chkPoduct1.checked = false;
        }
    }

    function OnChkchanged2() {
        var chkPoduct1 = document.getElementById("<%=chkPoduct1.ClientID %>");
        var chkPoduct2 = document.getElementById("<%=chkPoduct2.ClientID %>");
        if (chkPoduct2.checked) {
            chkPoduct1.checked = false;
        }
        else {
            chkPoduct2.checked = false;
        }
    }
    function InnventoryPrompt() {
        var InventoryManagement = '<%=InventoryManagement %>';
        var ReduceStockTypeForCancelledVal = '<%=ReduceStockTypeForCancelled %>';
        var ReduceStockType = '<%=ReduceStockType %>';
        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        if (InventoryManagement.toString().toLowerCase() == "im") {                     // Still to work on this case.
            if (moduleTyp.toLowerCase() == "invoice") {
                if (ReduceStockType.toString().toLowerCase() != "e" && ReduceStockType.toString().toLowerCase() != "i") {
//                    if (window.confirm('Do you want to reduce the inventory stock?')) {
//                        hdn_invStockReduce.value = "yes";
//                    }
                    //                    else { hdn_invStockReduce.value = "no"; }
                    ShowConfirmationMessage();
                    SetRadWindow('divrad', 'divBackGroundNew', '200');
                    document.getElementById('divBackGroundNew').style.display = 'block';
                    document.getElementById('divBackGroundNew').style.zIndex = 1001;
                    document.getElementById('div_AlertPopup').style.zIndex = 1002;
                    return false;
                }
            }
        }
        if (InventoryManagement.toString().toLowerCase() != "im") {
            document.getElementById('div_inventory_select').style.display = "none";
            document.getElementById('divBackGroundNew').style.display = "block";
            document.getElementById('divBackGroundNew').style.backgroundColor = "White";
            document.getElementById('div_Load').style.display = "block";
            return true;
        }
    }
    //<img src='" + strImagepath + "IMAGES/deleteicon3.png' title='Cancel' OnClick='javascript:CloseDiv_Popup_InventoryAlert();return false;'/>
    function ShowConfirmationMessage() {
        var id = document.getElementById('div_AlertPopup');
        var strImagepath = '<%= strImagepath %>';
        var str = "<table id='tbl_Popup'  cellpadding='0' cellspacing='0' width='35%' height='82%'>";
        str += "<tr>";
        str += "<td colspan='2' class='popup-top-leftcorner'></td><td class='popup-top-middlebg'><div  align='left' id='div_invoice_Popup' class=Label-PopupHeading style='float: right; padding-top: 6px; padding-right: 7px;'><div class='CancelButtonDiv2' style='cursor:auto;'></div></div></td><td colspan='2' class='popup-top-rightcorner'></td></tr>";
        str += "<tr>";
        str += "<td class='popup-middle-leftcorner'></td><td style='width: 15px; background-color: #ffffff'></td>";

        str += "<td class='popup-middlebg' align='center' valign='top'><table cellpadding='2' cellspacing='2' border='0' width='100%'><tr><td valign='top'><div id='div_Popup_Invoice'><div id='div_rdb_Popup_Invoice' style='float: left; padding-bottom: 7px;'><span style='font-weight: bold;'><label id='lbltxt_Popup' style='width:310px;margin-left:10px;margin-top:10px' Text=''> Do you want to reduce inventory stock ? </label></span></div><div style='clear: both'></div><div style='padding-top: 5px; float: left; padding-left: 3.2%; margin-left:80px;'><input type='button' id='btn_Yes' onclick=javascript:called_reducestock('yes'); return false; class='button' style='width:50px;' value='Yes'/></div><div style='padding-top: 5px; float: left; padding-left: 3.2%;'><input type='button' id='btn_No' style='width:50px;' onclick=javascript:called_reducestock('no'); return false; class='button' value='No'/></div></div></td></tr></table></td>";
        str += "<td style='width: 10px; background-color: #ffffff'></td><td align='right' class='popup-middle-rightcorner'></td>";
        str += "</tr>";
        str += "<tr><td colspan='2' class='popup-bottom-leftcorner'></td><td class='popup-bottom-middlebg'></td><td colspan='2' class='popup-bottom-rightcorner'></td>";
        str += "</tr>";
        str += "</table>";
        id.innerHTML = str;
        id.style.display = 'block';
    }
    function CloseDiv_Popup_InventoryAlert() {
        document.getElementById('div_AlertPopup').style.display = "none"
        document.getElementById('divBackGroundNew').style.zIndex = 1000;
        //document.getElementById('divBackGroundNew').style.display = "none";
    }
    function called_reducestock(val) {


        var hdn_invStockReduce = document.getElementById("<%=hdn_invStockReduce.ClientID %>");
        hdn_invStockReduce.value = val;
        document.getElementById('div_AlertPopup').style.display = "none";
        document.getElementById('div_inventory_select').style.display = "none";
        document.getElementById('divBackGroundNew').style.display = "block";
        document.getElementById('divBackGroundNew').style.backgroundColor = "White";
        document.getElementById('div_Load').style.display = "block";
        __doPostBack('ctl00$ContentPlaceHolder1$UCWare$Button6', '');
    }
    document.getElementById("ds00").style.display = "none";
    document.getElementById("div_Load").style.display = "none";

    function SelectInv(value) {
        debugger;
        $('#ctl00_ContentPlaceHolder1_UCWare_hid_InventoryNo').val(value);
    }
</script>
