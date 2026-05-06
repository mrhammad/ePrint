<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Proof_Search.ascx.cs" Inherits="ePrint.Proofs.Proof_Search" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
<telerik:RadAjaxManagerProxy ID="RADMgrProof" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="GridViewProof">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewProof" LoadingPanelID="RadAjaxLoadingPanelProof" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewProof" LoadingPanelID="RadAjaxLoadingPanelProof" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="GridViewProof" LoadingPanelID="RadAjaxLoadingPanelProof" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelProof" SkinID="Windows7" runat="server" />
<div id="ds00" style="display: none;">
</div>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<script type="text/javascript">
    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    //    document.getElementById("ds00").style.display = "block";

</script>
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
                    <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer; display: none"
                        runat="server" Text="Clear all Filters" />
                </div>
                <div style="border: 0px solid red; float: right; display: none">
                    <div style="float: left">
                        <span class="HeaderText" style="color: #787878">Current View:</span>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;
                    </div>
                    <div id="div_lblView" style="float: left; display: block">
                        <asp:Label ID="lblView" runat="server"></asp:Label>
                    </div>
                    <%--<div id="div_ddlView" style="float: left; display: none">
                        <asp:DropDownList ID="ddl_View" SkinID="onlyDDL"
                            AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>--%>
                    <div class="Only5pxWidth">
                        &nbsp;
                    </div>
                    <div style="float: left">
                        <a id="spn_change" style="text-decoration: underline; cursor: pointer">Change</a>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;
                    </div>
                   <%-- <div style="float: left">
                        <span class="normalText" style="color: #787878">Or try</span><a href="../invoice/invoice_search.aspx"
                            id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                            <%=objLanguage.convert("Advanced Search")%></a>
                    </div>--%>
                </div>
            </div>
            <div align="left" style="width: 100%; margin-left: -3px; margin-top: 0px;">
                <div style="width: 100%;">
                    <%--<div style="float: left">
                             <UC:AlphabetSearch ID="ucAplhaSearch" runat="server" />
                        </div>--%>
                    <asp:HiddenField ID="hdnAlphabet" runat="server" />
                    <div align="left" style="padding-top: 5px; width: 100%;">
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <telerik:RadGrid ID="GridViewProof" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridViewProof"
                                    ShowGroupPanel="true" AllowFilteringByColumn="false" ShowStatusBar="true" runat="server"
                                    AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="GridViewProof_ColumnCreated"
                                    OnNeedDataSource="GridViewProof_NeedDataSource" GroupingEnabled="false" OnSortCommand="GridViewProof_SortCommand"
                                    OnItemCommand="GridViewProof_ItemCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true"
                                    EnableEmbeddedSkins="false" CssClass="RadGrid_Eprint_Skin" HeaderStyle-Wrap="true"
                                    Width="100%" ItemStyle-Wrap="false" FilterItemStyle-Wrap="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                    OnItemCreated="GridViewProof_ItemCreated">
                                    <%--<HeaderStyle CssClass="gv_ViewsHeader" Width="120px" />--%>
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <MasterTableView OverrideDataSourceControlSorting="true">
                                        <Columns>
                                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:PlaceHolder ID="plh_customerstatus" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                        <%--<Resizing AllowColumnResize="True" AllowRowResize="true" ResizeGridOnColumnResize="true"
                                                ClipCellContentOnResize="false" EnableRealTimeResize="true" />
                                            <Scrolling AllowScroll="true" UseStaticHeaders="true" />--%>
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />
                    <asp:HiddenField runat="server" ID="hdnProofID" Value="0" />
                </div>
            </div>
            <div style="clear: both">
                &nbsp;
            </div>
        </div>
    </div>
</div>
<script>
<%--    var currentdate = '<%=newdate %>';--%>

    var div_lblView = document.getElementById("div_lblView");
    var div_ddlView = document.getElementById("div_ddlView");

    var checktrue = false;
    function setCookValue(val) {
        document.cookie = "TabViewCookies=" + val + "";
    }

    function OnRowClick(EditPage) {
        window.location = EditPage;
    }
</script>
<script>
    document.getElementById("ds00").style.display = "none";
</script>

