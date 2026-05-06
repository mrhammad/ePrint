<%@ control language="C#" autoeventwireup="true" CodeBehind="PurchaseSearch_General.ascx.cs" Inherits="ePrint.usercontrol.purchase.PurchaseSearch_General" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
<telerik:RadAjaxManagerProxy ID="RADMgrPurchase" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridViewpurchase">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewpurchase" LoadingPanelID="RadAjaxLoadingPanelPurchase" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewpurchase" LoadingPanelID="RadAjaxLoadingPanelPurchase" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewpurchase" LoadingPanelID="RadAjaxLoadingPanelPurchase" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelPurchase" SkinID="Windows7" runat="server" />
<%--<script type="text/javascript">
        $(document).ready(function () {
            $(".panelHeaderPurchase").click(function () {
                $(".panelContentPurchase").slideToggle("slow");
            });
        });
</script>--%>
<%--<style type="text/css">
    .panelHeaderPurchase
    {
        color: #212121;
        text-decoration: none;
        background: -moz-linear-gradient(top, rgba(224, 224, 224, 1) 0%, rgba(241, 241, 241, 0.6) 50%, rgba(225, 225, 225, 0.59) 51%, rgba(246, 246, 246, 0.2) 100%);
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(224, 224, 224, 1)), color-stop(50%,rgba(241, 241, 241, 0.6)), color-stop(51%,rgba(225, 225, 225, 0.59)), color-stop(100%,rgba(246, 246, 246, 0.2)));
        background: -webkit-linear-gradient(top, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        background: -o-linear-gradient(top, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        background: -ms-linear-gradient(top, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        background: linear-gradient(to bottom, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#e0e0e0', endColorstr='#33f6f6f6',GradientType=0 );
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
        /*padding:  .2em .4em;        */
        height: 20px;
        font-family: "Verdana", Verdana,Verdana;
        /*font-size: 1.1em;*/                
        border:solid 1px #D3D3D3;
        padding-top:5px;
        padding-bottom:2px;        
        font-size:15px;
    }
    .panelHeaderPurchase:hover
    {
        color: #212121;
        text-decoration: none;
        background: -moz-linear-gradient(top, rgba(224, 224, 224, 1) 0%, rgba(241, 241, 241, 0.6) 50%, rgba(225, 225, 225, 0.59) 51%, rgba(246, 246, 246, 0.2) 100%);
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(224, 224, 224, 1)), color-stop(50%,rgba(241, 241, 241, 0.6)), color-stop(51%,rgba(225, 225, 225, 0.59)), color-stop(100%,rgba(246, 246, 246, 0.2)));
        background: -webkit-linear-gradient(top, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        background: -o-linear-gradient(top, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        background: -ms-linear-gradient(top, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        background: linear-gradient(to bottom, rgba(224, 224, 224, 1) 0%,rgba(241, 241, 241, 0.6) 50%,rgba(225, 225, 225, 0.59) 51%,rgba(246, 246, 246, 0.2) 100%);
        filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#e0e0e0', endColorstr='#33f6f6f6',GradientType=0 );
        -webkit-border-radius: 3px;
        -moz-border-radius: 3px;
        border-radius: 3px;
        cursor:pointer ;
    }
    .panelContentPurchase
    {
    }
</style>--%>
<div id="ds00" style="display: none;">
</div>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<script type="text/javascript">
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    //document.getElementById("ds00").style.display = "block";

</script>
<%--<asp:UpdateProgress ID="upProgress" runat="server">
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
</asp:UpdateProgress>--%>
<%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">Purchases</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
<%--<div class="panelHeaderPurchase">
    <div>
        <span class="HeaderText" style="padding-left: 10px">
            Purchases</span>
    </div>
</div>--%>
<div id="divContentPurchase" class="panelContentPurchase" runat="server">
    <div>
        <div id="padding">
            <div align="center" style="width: 100%;">
                <div style="width: 90%; border: 0px solid Red;">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div align="left" style="width: 50%;">
                <div style="width: 290px">
                    <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhErrorMessage" runat="server"></asp:PlaceHolder>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div>
                <div style="float: left; padding-left: 5px">
                    <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer;
                        display: none" runat="server" Text="Clear all Filters" />
                </div>
                <div style="border: 0px solid red; float: right;">
                    <div style="float: left; display: none">
                        <span class="HeaderText" style="color: #787878">Current View:</span>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;</div>
                    <div id="div_lblView" style="float: left; display: block; display: none">
                        <asp:Label ID="lblView" runat="server"></asp:Label>
                    </div>
                    <%--<div id="div_ddlView" style="float: left; display: none">
                        <asp:DropDownList ID="ddl_View" SkinID="onlyDDL" AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>--%>
                    <div class="Only5pxWidth">
                        &nbsp;</div>
                    <div style="float: left; display: none">
                        <a id="spn_change" style="text-decoration: underline; cursor: pointer">Change</a>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;</div>
                    <%-- <div style="float: left">
                            <span class="normalText" style="color: #787878">Or try</span><a href="../purchase/purchase_search.aspx"
                                id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                                <%=objLanguage.convert("Advanced Search")%></a>
                        </div>--%>
                </div>
            </div>
            <div align="left" style="width: 100%; margin-left: -11px; margin-top: -8px;">
                <div style="width: 100%;">
                    <div align="left" style="padding-top: 5px; width: 100.8%;">
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <telerik:RadGrid ID="GridViewpurchase" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridViewpurchase"
                                    ShowGroupPanel="true" AllowFilteringByColumn="false" ShowStatusBar="true" runat="server"
                                    AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="GridViewpurchase_ColumnCreated"
                                    OnNeedDataSource="GridViewpurchase_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewpurchase_OnSorting"
                                    OnItemCommand="GridViewpurchase_ItemCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="false"
                                    EnableEmbeddedSkins="false" CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                    OnItemCreated="GridViewpurchase_ItemCreated">
                                    <HeaderStyle CssClass="gv_ViewsHeader" />
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                    <ClientSettings AllowExpandCollapse="false">
                                        <Selecting />
                                        <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                    </ClientSettings>
                                    <MasterTableView OverrideDataSourceControlSorting="true">
                                        <Columns>
                                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                            <%--<telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" AllowFiltering="false"
                                                    ItemStyle-Wrap="false">
                                                    <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                    <HeaderTemplate>
                                                        <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />&nbsp;
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.PurchaseID", "{0}") %>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>--%>
                                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                        <%--<Resizing AllowColumnResize="True" AllowRowResize="true" ResizeGridOnColumnResize="true"
                                                ClipCellContentOnResize="false" EnableRealTimeResize="true" />
                                            <Scrolling AllowScroll="true" UseStaticHeaders="true" />--%>
                                    </ClientSettings>
                                    <FilterMenu OnClientShown="MenuShowing" />
                                    <HeaderStyle Width="120px" />
                                </telerik:RadGrid>
                            </div>
                            <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                            <asp:HiddenField ID="hidDeletePO" runat="server" Value="0" />
                        </div>
                    </div>
                    <div style="clear: both">
                        &nbsp;</div>
                </div>
            </div>
        </div>
    </div>
</div>
<%--=== This Function is used for Remove Filter Options from Filter Control ===--%>
<script type="text/javascript" language="javascript">
    var column = null;
    function MenuShowing(sender, args) {
        if (column == null) return;
        var menu = sender;
        var items = menu.get_items();
        if (column.get_dataType() == "System.Int32") {
            var i = 0;
            while (i < items.get_count() - 1) {
                if (items.getItem(i).get_value() in { 'GreaterThan': '', 'GreaterThanOrEqualTo': '', 'LessThan': '', 'LessThanOrEqualTo': '', 'Contains': '', 'DoesNotContain': '', 'StartsWith': '', 'EndsWith': '' }) {
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
<script type="text/javascript">
    function setCookValue(val) {
        document.cookie = "TabViewCookies=" + val + "";
    }
    document.getElementById("ds00").style.display = "none";

    function OnRowClick(EditPage) {
        window.location = EditPage;
    }
</script>
