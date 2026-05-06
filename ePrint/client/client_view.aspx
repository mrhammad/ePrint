<%@ Page Language="C#" AutoEventWireup="true" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master"  CodeBehind="client_view.aspx.cs" Inherits="ePrint.client.client_view" title="Client View" enableviewstatemac="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Task" Src="~/usercontrol/Item/estimate_task_add.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="GridView1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ucAplhaSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnclrFilters">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridView1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <div id="div_Task" style="display: none;">
        <asp:PlaceHolder ID="plhTask" runat="server"></asp:PlaceHolder>
        <UC:Task ID="UCTask" runat="server" />
    </div>
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
    <div id="ds00" style="display: block;">
    </div>
    <script src="<%=strSitepath %>js/progressbar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript">
        document.getElementById("ds00").style.width = window.screen.availWidth + "px";
        document.getElementById("ds00").style.height = window.screen.availHeight + "px";
        document.getElementById("ds00").style.display = "block";

    </script>
    <div id="content">
        <asp:HiddenField ID="hdnaddress1" runat="server" Value="" />
        <asp:HiddenField ID="hdnaddress2" runat="server" Value="" />
        <asp:HiddenField ID="hdnaddress3" runat="server" Value="" />
        <asp:HiddenField ID="hdnaddress4" runat="server" Value="" />
        <asp:HiddenField ID="hdnaddress5" runat="server" Value="" />
        <div>
            <%--borderWithoutTop--%>
            <div id="">
                <div style="height: 18px; margin-top: -10px; margin-bottom: 10px;">
                    <div id="div_ddlView" style="float: left; /*display: none*/">
                        <asp:DropDownList ID="ddl_View_cust" OnSelectedIndexChanged="ddlView_OnSelectedIndexChanged"
                            Width="110%" Style="height: 23px; border-radius: 4px; background-color: white; outline: none; cursor: pointer;"
                            AutoPostBack="true" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div style="float: left; margin-left: 35px; padding-top: 3px;">
                        <a onclick="javascript:editviews();" style="cursor: pointer; text-decoration: underline; color: #10357F;">
                            <%=objLangClass.GetLanguageConversion("Edit_Add")%></a> <a id="spn_add" onclick="javascript:addviews();"
                                style="text-decoration: underline; display: none; cursor: pointer; color: #10357F;">
                                <%=objLangClass.GetLanguageConversion("Add")%></a>
                    </div>
                    <div style="float: right; padding-left: 0px; padding-top: 5px;">
                        <asp:LinkButton ID="btnclrFilters" OnClick="clrFilters_Click" Style="text-decoration: underline; cursor: pointer"
                            runat="server" Text="Clear all filters" />
                    </div>
                    <div style="border: 0px solid red; float: right; padding-right: 30px; margin-top: -5px;">
                        <div style="float: left; display: none">
                            <span class="HeaderText" style="color: #787878">
                                <%=objLangClass.GetLanguageConversion("Current_View")%></span>
                        </div>
                        <div class="Only5pxWidth">
                            &nbsp;
                        </div>
                        <div id="div_lblView" style="float: left; display: none">
                            <asp:Label ID="lblView" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div>
            </div>
            <div">
                <div">
                    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
                    <asp:HiddenField ID="hdnEstimateIds" runat="server" Value="0" />
                    <div>
                        <div id="div_Main" runat="server">
                            <div id="div_Grid">
                                <%--OnColumnCreated="GridView1_ColumnCreated"--%>
                                <telerik:RadGrid ID="GridView1" AllowSorting="true" OnItemDataBound="OnRowDataBound_GridView1"
                                    AllowFilteringByColumn="true" runat="server" ShowStatusBar="true" ShowGroupPanel="true"
                                    AutoGenerateColumns="false" AllowPaging="true" OnNeedDataSource="GridView1_NeedDataSource"
                                    GroupingEnabled="false" OnSortCommand="GridView1_SortCommand" OnItemCommand="GridView1_ItemCommand"
                                    Skin="Sunset" EnableEmbeddedSkins="true"
                                    AllowCustomPaging="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin">
                                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="false" Width="100%"></PagerStyle>
                                    <MasterTableView OverrideDataSourceControlSorting="true" AutoGenerateColumns="false"
                                        AllowFilteringByColumn="true" AllowCustomSorting="true">
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
    <script type="text/javascript">

        var currentdate = '<%=newdate %>';

        var clsTimeID = '';
        var TakeTimaeCount = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
        var div_lblView = document.getElementById("div_lblView");
        var div_ddlView = document.getElementById("div_ddlView");

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
                        //document.getElementById("tblpo").style.display="none"; 
                        document.getElementById("divmessage").style.display = "none";
                    }
                }
            }
        }
        function setCookValue(val) {
            document.cookie = "TabViewCookies=" + val + "";
        }

        document.getElementById("ds00").style.display = "none";
    </script>
    <script type="text/javascript">
        function editviews() {
            var ddl = document.getElementById("ctl00_ContentPlaceHolder1_ddl_View_cust");
            var pgtype = "customer";
            if (window.location.search.substring(1) != '') {
                var qrystr = window.location.search.substring(1).split("=");
                if (qrystr[0] == 'type') {
                    pgtype = qrystr[1];
                }
            }
            window.location.href = "<%=strSitepath%>" + "client/CustomViewCRM.aspx?type=edit&id=" + ddl.options[ddl.selectedIndex].value + "&cid=" + <%=companyid%> + "&pgtype=" + pgtype;
        }

        function OnRowClick(EditPage) {
            window.location = EditPage;
        }


        var arrSplit = document.cookie.split(";");
        for (var i = 0; i < arrSplit.length; i++) {
            var cookie = arrSplit[i].trim();
            var cookieName = cookie.split("=")[0];

            // If the prefix of the cookie's name matches the one specified, remove it
            if (cookieName.indexOf("CRMTabName") === 0) {

                // Remove the cookie
                document.cookie = cookieName + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
            }
        }
    </script>
    <script type="text/javascript" language="javascript">

        function addviews() {
            var pgtype = '<%=companytype%>';
            if (pgtype == "Customer") {
                window.location.href = "<%=strSitepath%>" + "client/CustomViewCRM.aspx?pgtype=customer";
            }
            else if (pgtype == "Supplier") {
                window.location.href = "<%=strSitepath%>" + "client/CustomViewCRM.aspx?pgtype=supplier";

            }
            else if (pgtype == "Prospect") {
                window.location.href = "<%=strSitepath%>" + "client/CustomViewCRM.aspx?pgtype=prospect";
            }
        }

    </script>
</asp:Content>
