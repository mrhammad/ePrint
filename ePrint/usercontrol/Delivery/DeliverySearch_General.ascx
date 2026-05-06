<%@ control language="C#" autoeventwireup="true" CodeBehind="DeliverySearch_General.ascx.cs" Inherits="ePrint.usercontrol.Delivery.DeliverySearch_General" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
<telerik:RadAjaxManagerProxy ID="RADMgrDelivery" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridViewDelivery">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" LoadingPanelID="RadAjaxLoadingPanelDelivery" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" LoadingPanelID="RadAjaxLoadingPanelDelivery" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewDelivery" LoadingPanelID="RadAjaxLoadingPanelDelivery" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelDelivery" SkinID="Windows7" runat="server" />
<%--<script type="text/javascript">
         $(document).ready(function () {
             $(".panelHeaderDelivery").click(function () {
                 $(".panelContentDelivery").slideToggle("slow");
             });
         });
</script>--%>
<%--<style type="text/css">
    .panelHeaderDelivery
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
    .panelHeaderDelivery:hover
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
    .panelContentDelivery
    {
    }
</style>--%>
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
<div id="ds00" style="display: none;">
</div>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<script type="text/javascript">
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    //   document.getElementById("ds00").style.display = "block";

</script>
<%--<div class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" nowrap="nowrap">
                            <span class="navigatorpanel" style="padding-left: 10px">Delivery Note</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>--%>
<%--<div class="panelHeaderDelivery">
    <div>
        <span class="HeaderText" style="padding-left: 10px">
            Delivery Note</span>
    </div>
</div>--%>
<div>
    <div>
        <div>
            <div align="center" style="width: 100%">
                <div style="width: 90%">
                    <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
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
                    <div id="div_lblView" style="float: left; display: none">
                        <asp:Label ID="lblView" runat="server"></asp:Label>
                    </div>
                    <%--<div id="div_ddlView" style="float: left; display: none">
                        <asp:DropDownList ID="ddl_View" SkinID="onlyDDL"
                            AutoPostBack="true" runat="server">
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
                            <span class="normalText" style="color: #787878">Or try</span><a href="../delivery/delivery_search.aspx"
                                id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                                <%=objLanguage.convert("Advanced Search")%></a>
                        </div>--%>
                </div>
            </div>
            <div align="left" style="width: 100%;">
                <div style="width: 100%; margin-left: -4px;">
                    <div align="left" style="padding-top: 5px; width: 100%;">
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <telerik:RadGrid ID="GridViewDelivery" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridViewDelivery"
                                    ShowGroupPanel="true" AllowFilteringByColumn="false" ShowStatusBar="true" runat="server"
                                    AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="GridViewDelivery_ColumnCreated"
                                    OnNeedDataSource="GridViewDelivery_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewDelivery_SortCommand"
                                    OnItemCommand="GridViewDelivery_ItemCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true"
                                    EnableEmbeddedSkins="false" CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                    OnItemCreated="GridViewDelivery_ItemCreated">
                                    <HeaderStyle CssClass="gv_ViewsHeader" />
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                    <MasterTableView OverrideDataSourceControlSorting="true">
                                        <Columns>
                                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                            <%--<telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" AllowFiltering="false"
                                                    ItemStyle-Wrap="false">
                                                    <HeaderStyle HorizontalAlign="Center" Width="2%" Wrap="false" />
                                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                                    <HeaderTemplate>
                                                        <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input type="checkbox" runat="server" id="Id" onclick="CheckChanged();" name="Id"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.DeliveryID", "{0}") %>' />
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
                                    <ClientSettings AllowColumnsReorder="true" ReorderColumnsOnClient="true" AllowDragToGroup="false">
                                        <%--<Resizing AllowColumnResize="True" AllowRowResize="true" ResizeGridOnColumnResize="true"
                                                ClipCellContentOnResize="false" EnableRealTimeResize="true" />
                                            <Scrolling AllowScroll="true" UseStaticHeaders="true" />--%>
                                    </ClientSettings>
                                    <HeaderStyle Width="120px" />
                                </telerik:RadGrid>
                            </div>
                            <asp:HiddenField ID="hidDelveryID" runat="server" Value="" />
                        </div>
                        <div style="clear: both">
                            &nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    var div_lblView = document.getElementById("div_lblView");
    var div_ddlView = document.getElementById("div_ddlView");

    var hidDelveryID = document.getElementById("<%=hidDelveryID.ClientID %>");
    function setCookValue(val) {
        document.cookie = "TabViewCookies=" + val + "";
    }

    document.getElementById("ds00").style.display = "none";

    function OnRowClick(EditPage) {
        window.location = EditPage;
    }
</script>
