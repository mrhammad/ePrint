<%@ control language="C#" autoeventwireup="true" CodeBehind="Job_Search.ascx.cs" Inherits="ePrint.usercontrol.jobs.Job_Search" %>
<%@ Register Src="~/usercontrol/AlphabetSearch.ascx" TagName="AlphabetSearch" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/Paging.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<script src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/progressbar.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>--%>
<%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />--%>
<telerik:RadAjaxManagerProxy ID="RADMgrJob" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="grvJobSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvJobSearch" LoadingPanelID="RadAjaxLoadingPanelJob" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvJobSearch" LoadingPanelID="RadAjaxLoadingPanelJob" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnclrFilters">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvJobSearch" LoadingPanelID="RadAjaxLoadingPanelJob" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanelJob" SkinID="Windows7" runat="server" />
<%--<script type="text/javascript">
     $(document).ready(function () {
         $(".panelHeaderJob").click(function () {
             $(".panelContentJob").slideToggle("slow");
         });
     });
</script>--%>
<%--<style type="text/css">
    .panelHeaderJob
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
    .panelHeaderJob:hover
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
    .panelContentJob
    {
    }
</style>--%>
<div id="ds00" style="display: none;">
</div>
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
                        <span class="navigatorpanel" style="padding-left: 10px">Jobs</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both;">
    </div>
</div>--%>
<%--<div class="panelHeaderJob">
    <div>
        <span class="HeaderText" style="padding-left: 10px">
            Jobs</span>
    </div>
</div>--%>
<div id="divContentJob" class="panelContentJob" runat="server">
    <div>
        <div id="padding">
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
                    <asp:LinkButton ID="btnclrFilters" Style="text-decoration: underline; cursor: pointer;
                        display: none" runat="server" Text="Clear all Filters" />
                </div>
                <div style="border: 0px solid red; float: right; padding-right: 5px; display: none">
                    <div style="float: left">
                        <span class="HeaderText" style="color: #787878">Current View:</span>
                    </div>
                    <div class="Only5pxWidth">
                        &nbsp;</div>
                    <div id="div_lblView" style="float: left; display: block">
                        <asp:Label ID="lblView" runat="server"></asp:Label>
                    </div>
                    <%-- <div id="div_ddlView" style="float: left; display: none">
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
                    <%--<div style="float: left">
                        <span class="normalText" style="color: #787878">Or try</span><a href="../Jobs/job_Search.aspx"
                            id="lnkAdvanceSearch" style="text-decoration: underline" class="normaltext">
                            <%=objLanguage.convert("Advanced Search")%></a>
                    </div>--%>
                </div>
            </div>
            <div align="left" style="width: 100%;">
                <div style="width: 100%;">
                    <%--<div style="float: left">
                             <UC:AlphabetSearch ID="ucAplhaSearch" runat="server" />
                        </div>--%>
                    <asp:HiddenField ID="hdnAlphabet" runat="server" />
                    <div align="left" style="padding-top: 5px; width: 100%; margin-left: -11px; margin-top: -8px;">
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <telerik:RadGrid ID="grvJobSearch" runat="server" AllowSorting="true" OnItemDataBound="OnRowDataBound_grvJobSearch"
                                    ShowGroupPanel="true" AllowFilteringByColumn="false" ShowStatusBar="true" AutoGenerateColumns="false"
                                    AllowPaging="true" GroupingEnabled="false" OnSortCommand="grvJobSearch_SortCommand"
                                    OnItemCommand="grvJobSearch_ItemCommand" Skin="RadGrid_Eprint_Skin" AllowCustomPaging="true"
                                    EnableEmbeddedSkins="false" Width="100.3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="false"
                                    FilterItemStyle-Wrap="true" CssClass="RadGrid_Eprint_Skin" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                    OnNeedDataSource="grvJobSearch_NeedDataSource" OnItemCreated="grvJobSearch_ItemCreated">
                                    <HeaderStyle CssClass="gv_ViewsHeader" />
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <MasterTableView OverrideDataSourceControlSorting="true">
                                        <Columns>
                                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="false" />
                                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="left" AllowFiltering="false"
                                                ItemStyle-Wrap="false">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="margin-left: -10px; padding-left: 5px">
                                                        <asp:PlaceHolder ID="plhInv" runat="server"></asp:PlaceHolder>
                                                    </div>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <div style="margin-left: -10px;">
                                                        <asp:PlaceHolder ID="plh_attach" runat="server"></asp:PlaceHolder>
                                                    </div>                                                   
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                             <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-HorizontalAlign="left">
                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" Width="1%" Wrap="false" />
                                                <ItemStyle HorizontalAlign="Center" Width="1%" />
                                                <HeaderTemplate>
                                                    <div class="absmiddle">
                                                        &nbsp;</div>
                                                </HeaderTemplate>
                                                <ItemTemplate>                                                    
                                                    <div style="margin-left: -10px;">
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
                                    <HeaderStyle Width="120px" />
                                </telerik:RadGrid>
                            </div>
                            <%-- <asp:LinkButton ID="lnkJobDelete" runat="server" Text=" " OnClick="lnkJobDelete_OnClick"
                                CausesValidation="false" Visible="false"></asp:LinkButton>
                            <asp:LinkButton ID="lnkJobArchive" runat="server" Text=" " OnClick="lnkJobArchive_OnClick"
                                CausesValidation="false" Visible="false"></asp:LinkButton>
                            <asp:LinkButton ID="lnkCopyJob" runat="server" Text=" " OnClick="lnkCopyJob_OnClick"
                                CausesValidation="false" Visible="false"></asp:LinkButton>--%>
                        </div>
                        <asp:HiddenField runat="server" ID="hdnJobID" Value="0" />
                        <asp:HiddenField runat="server" ID="hdnEstimateID" Value="0" />
                    </div>
                    <div style="clear: both">
                        &nbsp;</div>
                    <div align="right">
                        <%--<asp:LinkButton ID="lnkBtnViewMore" runat="server" Text="View more" OnClick="lnkBtnViewMore_Click"
                            Style="display: none"></asp:LinkButton>--%>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
        <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />
    </div>
</div>
<script type="text/javascript">
    var clsTimeID = '';
    var TakeTimaeCount = 0;
    var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
    var div_lblView = document.getElementById("div_lblView");
    var div_ddlView = document.getElementById("div_ddlView");

    function OnRowClick(EditPage) {
        window.location = EditPage;
    }
</script>
<script>
    function setCookValue(val) {
        document.cookie = "TabViewCookies=" + val + "";
    } </script>
<script>
    document.getElementById("ds00").style.display = "none";
</script>
