<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.ProductSubSection" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'"></script>
<style type="text/css">
    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td
    {
        border-style: solid;
        border-color: #C9C9C9;
        border-width: 0 0 1px 0px; /*top right bottom left*/
    }
    .RadGrid .rgHeader, .RadGrid th.rgResizeCol
    {
        padding-top: 5px;
        text-align: left;
        font-weight: normal;
    }
    .RadGrid .rgFilterRow td
    {
        padding-top: 4px;
        padding-bottom: 4px;
    }
    .RowMouseOver td
    {
        background-color: #D8D8D8 !important;
        height: auto;
    }
    .RowMouseOut
    {
        background: #ffffff;
        height: auto;
    }
    
    .RadGrid .rgSelectedRow
    {
        background-color: #8F8F8F !important;
        background-image: none !important;
        height: auto;
    }
</style>
<asp:LinkButton ID="lnk_ClearFilter_Product" runat="server" CausesValidation="false" OnClick="btnclrFilters_Products_Click"></asp:LinkButton>
<div id="div_ProductsMain" runat="server" style="border: solid 0px silver; display: block;">
    <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
        <div style="width: 60%; margin: 5px 0px 0px 5px">
            <asp:UpdatePanel ID="UpdatePanel8" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plhProducts" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:UpdateProgress ID="upProgress" runat="server">
        <ProgressTemplate>
            <div id="div_Load" class="loading_new" style="display: none">
                <table cellpadding="0" cellspacing="10">
                    <tr>
                        <td>
                            <div style="float: left">
                                <img src="<%=ImgPath %>loading_new.gif" border="0" /></div>
                        </td>
                    </tr>
                </table>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div id="div_Products" style="padding: 7px 10px 25px 7px; display: block;">
        <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
            <ContentTemplate>
                <telerik:RadGrid ID="RadGrid_Products" runat="server" AllowPaging="true" AllowSorting="true"
                    OnItemCommand="RadGrid_Products_ItemCommand" AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true"
                    GroupingEnabled="false" PageSize="50" Width="100%" ShowGroupPanel="true" ShowStatusBar="true"
                    HeaderStyle-Font-Bold="true" OnNeedDataSource="RadGrid_Products_OnNeedDataSource"
                    AllowFilteringByColumn="true" OnItemDataBound="RadGridProduct_OnRowDataBound"
                    GridLines="none" CssClass="AddBorders" EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333"
                    HeaderStyle-BorderStyle="Double" BorderColor="White" FilterItemStyle-HorizontalAlign="Justify"
                    Skin="Default" GroupingSettings-CaseSensitive="false">
                    <AlternatingItemStyle BackColor="White" />
                    <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" Position="Bottom" />
                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                    <MasterTableView DataKeyNames="PriceCatalogueID" OverrideDataSourceControlSorting="true"
                        CommandItemDisplay="Top" Width="100%">
                        <CommandItemTemplate>
                            <div style="border-bottom: 1px solid #C9C9C9; margin-top: 5px;">
                            </div>
                        </CommandItemTemplate>
                        <Columns>
                            <telerik:GridTemplateColumn DataField="PriceCatalogueCategoryName" HeaderStyle-HorizontalAlign="Left"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                HeaderStyle-Width="25%" HeaderText="" ItemStyle-Width="25%" SortExpression="PriceCatalogueCategoryName"
                                UniqueName="PriceCatalogueCategoryName" Visible="true">
                                <ItemTemplate>
                                    <a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/ProductCatalogue_item.aspx?action=edit&from=crm&clientID=<%=ClientID %>&id=<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>">
                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                            <asp:Label ID="lbl_CategoryName" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.PriceCatalogueCategoryName", "{0}")) %>'
                                                ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.PriceCatalogueCategoryName", "{0}")) %>'></asp:Label>
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="CatalogueName" HeaderStyle-HorizontalAlign="Left"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                HeaderStyle-Width="25%" HeaderText="" ItemStyle-Width="25%" SortExpression="CatalogueName"
                                UniqueName="CatalogueName" Visible="true" ItemStyle-Height="22px">
                                <ItemTemplate>
                                    <a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/ProductCatalogue_item.aspx?action=edit&from=crm&clientID=<%=ClientID %>&id=<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>">
                                        <div style="float: left; width: 100%; overflow: hidden; height: 18px;">
                                            <asp:Label ID="lbl_ItemTitle" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.CatalogueName", "{0}")) %>'
                                                ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.CatalogueName", "{0}")) %>'></asp:Label>
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="Description" HeaderStyle-HorizontalAlign="Left"
                                CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" AllowFiltering="true"
                                HeaderStyle-Width="49%" HeaderText="" ItemStyle-Width="49%" SortExpression="Description"
                                FilterControlWidth="100" Visible="true" ItemStyle-HorizontalAlign="Left" UniqueName="Description">
                                <ItemTemplate>
                                    <a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/ProductCatalogue_item.aspx?action=edit&from=crm&clientID=<%=ClientID %>&id=<%# DataBinder.Eval(Container, "DataItem.PriceCatalogueID", "{0}") %>">
                                        <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                            <asp:Label ID="lbl_Description" runat="server" Text='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.Description", "{0}")) %>'
                                                ToolTip='<%#objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.Description", "{0}")) %>'></asp:Label>
                                        </div>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <NoRecordsTemplate>
                            <div style="padding: 3px 5px 5px 10px">
                                <%=objLangClass.GetLanguageConversion("No_records_Found") %>
                            </div>
                        </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                        AllowDragToGroup="false" Scrolling-AllowScroll="true">
                        <Selecting AllowRowSelect="True" />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                        <Scrolling UseStaticHeaders="true" ScrollHeight="380" SaveScrollPosition="true" />
                        <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                    </ClientSettings>
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div style="clear: both">
    </div>
</div>
<div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100;
    width: 50%" align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="1000" Height="620" OnClientClose="RadWinClose"
        Behaviors="Close,Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<script type="text/javascript" language="javascript">

</script>

