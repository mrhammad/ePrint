<%@ control language="C#" autoeventwireup="true" CodeBehind="Estimate_Search.ascx.cs" Inherits="ePrint.usercontrol.ESTIMATE.Estimate_Search" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script type="text/javascript" src="<%=strSitepath %>js/item/item_summary_reeng.js?VN='<%#VersionNumber%>'"></script>
<%--<script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN='<%#VersionNumber%>'"></script>--%>
<%--<telerik:RadScriptManager ID="Radscrmgr" runat="server" />--%>
<telerik:RadAjaxManagerProxy ID="RadAjaxmgr" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grvEstimateSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvEstimateSearch" LoadingPanelID="RadAjaxLoadingPanelEstimate" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvEstimateSearch" LoadingPanelID="RadAjaxLoadingPanelEstimate" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvEstimateSearch" LoadingPanelID="RadAjaxLoadingPanelEstimate" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelEstimate" SkinID="Windows7" runat="server" />
<%--<script type="text/javascript">
    $(document).ready(function () {
        $(".panelHeaderEstimate").click(function () {
            $(".panelContentEstimate").slideToggle("slow");
        });
    });
</script>--%>
<style type="text/css">
    
</style>
<div id="ds00" style="display: none;">
</div>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<script>
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
<%--<div class="panelHeaderEstimate" runat="server" id="divPanelHeader">
    <div>
        <span class="HeaderText" style="padding-left: 10px">Estimates</span>
    </div>
</div>--%>
<div>
    <div>
        <div>
            <div>
                <div style="float: left; padding-left: 5px">
                    <%--<asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline;
                        cursor: pointer;display:none" runat="server" Text="Clear all Filters" />--%>
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
                    <%-- <div id="div_ddlView" style="float: left; display: none">
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
                </div>
            </div>
            <div align="left" style="width: 100%;">
                <div style="width: 100%;">
                    <asp:HiddenField ID="hdnAlphabet" runat="server" />
                    <div align="left" style="padding-top: 5px; width: 100%; margin-left: -4px;">
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <%--<div id="div_popupAction" style="display: none; z-index: 999999; position: absolute;
                                    margin: 26px 0px 0px 5px" onmouseover="show();" onmouseout="hide();">
                                    <table>
                                        <tr>
                                            <td>
                                                <div style="background: #C5C5C5; color: #000000; width: 153px; border-left: 1px solid #828282;
                                                    border-right: 1px solid #828282; border-top: 1px solid #828282; padding: 5px 0px 5px 5px;
                                                    font-size: 11px; font-weight: 700;">
                                                    Change Status</div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>--%>
                                <telerik:RadGrid ID="grvEstimateSearch" AllowSorting="true" OnItemDataBound="OnRowDataBound_grvEstimateSearch"
                                    OnSelectedIndexChanged="grvEstimateSearch_SelectedIndexChanged" ShowGroupPanel="true"
                                    AllowFilteringByColumn="false" ShowStatusBar="true" runat="server" AutoGenerateColumns="false"
                                    AllowPaging="true" OnColumnCreated="grvEstimateSearch_ColumnCreated" OnNeedDataSource="grvEstimateSearch_NeedDataSource"
                                    GroupingEnabled="false" OnSortCommand="grvEstimateSearch_SortCommand" OnItemCommand="grvEstimateSearch_ItemCommand"
                                    Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true" EnableEmbeddedSkins="false"
                                    Width="100.1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false" FilterItemStyle-Wrap="true"
                                    CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                    OnItemCreated="grvEstimateSearch_ItemCreated">
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <HeaderStyle Width="120px" />
                                    <MasterTableView OverrideDataSourceControlSorting="true" PageSize="50">
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
                                                    <div style="margin-left: -10px">
                                                        <asp:PlaceHolder ID="plh_EmailSent" runat="server"></asp:PlaceHolder>
                                                    </div>
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
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" AllowFiltering="false"
                                                ItemStyle-Wrap="false">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;
                                                    </div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="margin-left: -10px;">
                                                        <asp:PlaceHolder ID="plhConvertJob" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <ClientSettings AllowColumnsReorder="False" ReorderColumnsOnClient="False" AllowDragToGroup="false">
                                    </ClientSettings>
                                </telerik:RadGrid>
                            </div>
                        </div>
                        <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />
                    </div>
                    <div style="clear: both">
                        &nbsp;
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
        <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />
    </div>
</div>
<script>

    document.getElementById("ds00").style.display = "none";

    function OnRowClick(EditPage) {
        window.location = EditPage;
    }
    //    var img_actionsShow = document.getElementById("img_actionsShow");
    //    var img_actionsHide = document.getElementById("img_actionsHide");
    //    var div_chk = document.getElementById("div_chk");
    //    var div_popupAction = document.getElementById("div_popupAction");

    //    function show() {
    //        img_actionsHide.style.display = "block";
    //        img_actionsShow.style.display = "none";

    //        div_chk.style.border = "inset 1px";
    //        div_chk.style.background = "gray";

    //        div_popupAction.style.display = "block";
    //    }

    //    function hide() {
    //        img_actionsHide.style.display = "none";
    //        img_actionsShow.style.display = "block";

    //        div_chk.style.border = "outset 1px";
    //        div_chk.style.background = "";

    //        div_popupAction.style.display = "none";
    //    }



    //    function CheckOne_new(val) {
    //        
    //        var Counter = 0;
    //        var frm = document.forms[0];
    //        for (i = 0; i < frm.length; i++) {
    //            e = frm.elements[i];
    //            if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
    //                if (!e.disabled) {
    //                    if (e.checked)
    //                        Counter = Number(Counter) + 1;

    //                }
    //            }
    //        }
    //        alert(Counter);

    //        hide();

    //        if (Number(Counter) == 0) {
    //            alert(Counter);
    //            if (val == "copy")

    //                alert("Please check at least one 'row' to Copy");


    //            if (val == "addoption")
    //                alert("Please check at least one 'row' to process");

    //            return false;
    //        }
    //        else {
    //            if (val == "copy") {
    //                if (true) {
    //                    Show_CopyAccountsDiv();
    //                    return true;
    //                }
    //                else {
    //                    return false;
    //                }
    //            }
    //            if (val == "addoption") {
    //                if (true) {
    //                    Show_AdditionalOptionDiv();
    //                    return true;
    //                }
    //                else {
    //                    return false;
    //                }
    //            }
    //        }
    //    }
</script>
