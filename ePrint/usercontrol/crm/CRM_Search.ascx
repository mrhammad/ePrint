<%@ control language="C#" autoeventwireup="true" CodeBehind="CRM_Search.ascx.cs" Inherits="ePrint.usercontrol.crm.CRM_Search" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<telerik:RadAjaxManagerProxy ID="RADMgrCRM" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grvCRMSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvCRMSearch" LoadingPanelID="RadAjaxLoadingPanelCRM" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvCRMSearch" LoadingPanelID="RadAjaxLoadingPanelCRM" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvCRMSearch" LoadingPanelID="RadAjaxLoadingPanelCRM" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelCRM" SkinID="Windows7" runat="server" />
<div id="ds00" style="display: none;">
</div>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<script type="text/javascript">


    document.getElementById("ds00").style.width = window.screen.availWidth + "px";
    document.getElementById("ds00").style.height = window.screen.availHeight + "px";
    //document.getElementById("ds00").style.display = "block"; 

    function OnRowClick(EditPage) {
        window.location = EditPage;
    }
</script>
<div>
    <div>
        <div>
            <div>
                <div style="float: left; padding-left: 5px">
                    <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer; display: none"
                        runat="server" Text="Clear all Filters" />
                </div>
            </div>
            <asp:HiddenField ID="hdnaddress1" runat="server" Value="" />
            <asp:HiddenField ID="hdnaddress2" runat="server" Value="" />
            <asp:HiddenField ID="hdnaddress3" runat="server" Value="" />
            <asp:HiddenField ID="hdnaddress4" runat="server" Value="" />
            <asp:HiddenField ID="hdnaddress5" runat="server" Value="" />
            <div align="left" style="width: 100%;">
                <div style="width: 100%;">
                    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                    <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />
                    <div align="left" style="padding-top: 5px; width: 100%; margin-left: -10px;">
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <telerik:RadGrid ID="grvCRMSearch" AllowSorting="true" OnItemDataBound="OnRowDataBound_grvCRMSearch"
                                    AllowFilteringByColumn="false" runat="server" ShowStatusBar="true" ShowGroupPanel="true"
                                    AutoGenerateColumns="false" AllowPaging="true" OnColumnCreated="grvCRMSearch_ColumnCreated"
                                    OnNeedDataSource="grvCRMSearch_NeedDataSource" GroupingEnabled="false" OnSortCommand="grvCRMSearch_SortCommand"
                                    OnItemCommand="grvCRMSearch_ItemCommand" Skin="RadGrid_Eprint_Skin" EnableEmbeddedSkins="false"
                                    CssClass="RadGrid_Eprint_Skin" AllowCustomPaging="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                    OnItemCreated="grvCRMSearch_ItemCreated">
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                    <MasterTableView OverrideDataSourceControlSorting="true" AutoGenerateColumns="false">
                                        <Columns>
                                            <telerik:GridTemplateColumn DataField="" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="5px"
                                                ItemStyle-Width="5px" AllowFiltering="false">
                                                <ItemTemplate>
                                                    <div style="float: left; width: 5px;">
                                                    </div>
                                                    <div>
                                                        <asp:PlaceHolder ID="plh_customerstatus" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings AllowColumnsReorder="true" ReorderColumnsOnClient="true" AllowDragToGroup="false">
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
        </div>
    </div>
</div>
