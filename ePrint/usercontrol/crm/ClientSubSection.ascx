<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClientSubSection.ascx.cs" Inherits="ePrint.usercontrol.crm.ClientSubSection" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<script src="<%=strSitepath %>js/item/crm.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css" rel="stImgButtonLoginContactsylesheet" />
<link rel="stylesheet" type="text/css" href="<%=strSitepath%>App_Themes/Theme1/eprint-crm-customer.css?VN=<%=VersionNumber%>" />
<link rel="stylesheet" type="text/css" href="<%=strSitepath%>App_Themes/Theme1/eprint-crm-sections.css?VN=<%=VersionNumber%>" />
<script type="text/javascript" src="<%=strSitepath%>js/eprint-crm-customer.js?VN=<%=VersionNumber%>"></script>
<script type="text/javascript" src="<%=strSitepath%>js/eprint-crm-sections.js?VN=<%=VersionNumber%>"></script>
<script type="text/javascript">
    window.eprintCrmPanels = {
        clientMain: "<%=div_ClientMain.ClientID %>",
        contactMain: "<%=div_ContactMain.ClientID %>",
        departmentMain: "<%=div_DepartmentMain.ClientID %>",
        addressMain: "<%=div_AddressMain.ClientID %>",
        b2bMain: "<%=div_b2bMain.ClientID %>",
        productsMain: "<%=div_ProductsMain.ClientID %>",
        notesMain: "<%=div_NotesMain.ClientID %>",
        emailMain: "<%=div_EmailMain.ClientID %>",
        activitiesMain: "<%=div_ActivitiesMain.ClientID %>",
        costcentreMain: "<%=div_CostcentreMain.ClientID %>",
        another: "<%=DivAnotherDesign.ClientID %>",
        deptControls: "<%=div_DeptControls.ClientID %>",
        contactControls: "<%=div_ContactControls.ClientID %>",
        addressControls: "<%=div_AddressControls.ClientID %>",
        costcenterControls: "<%=div_CostcenterControls.ClientID %>",
        productsControls: "<%=div_ProductsControls.ClientID %>",
        emailControls: "<%=div_EmailControls.ClientID %>",
        estimateControls: "<%=div_EstimateControls.ClientID %>",
        jobControls: "<%=div_JobControls.ClientID %>",
        invoiceControls: "<%=div_InvoiceControls.ClientID %>",
        eStoreControls: "<%=div_eStoreControls.ClientID %>",
        searchButton: "<%=DivsearchButton.ClientID %>",
        btnEdit: "<%=divbtnedit.ClientID %>",
        btnDelete: "<%=divbtndelete.ClientID %>",
        printOptions: "<%=DivPrintOptions.ClientID %>"
    };
</script>
<script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/jquery.timer.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/CRM_json.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="../js/helptext.js?VN='<%=VersionNumber%>'" language="javascript"></script>
<script type="text/javascript" language="javascript">
    var asyncState = true;
    (function () {
        var xhr = window.XMLHttpRequest;
        if (!xhr || !xhr.prototype || typeof xhr.prototype.open !== "function") {
            return;
        }
        if (!xhr.prototype.original_open) {
            xhr.prototype.original_open = xhr.prototype.open;
            xhr.prototype.open = function (method, url, async, user, password) {
                async = asyncState;
                var eventArgs = Array.prototype.slice.call(arguments);
                eventArgs[2] = async;
                return this.original_open.apply(this, eventArgs);
            };
        }
    })();
    function bindCrmPageRequestManager() {
        if (typeof Sys === "undefined" || !Sys.WebForms || !Sys.WebForms.PageRequestManager) {
            return;
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm._eprintCrmEndRequestBound) {
            return;
        }
        prm._eprintCrmEndRequestBound = true;
        prm.add_endRequest(EndRequestHandler);
    }
    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", bindCrmPageRequestManager);
    } else {
        bindCrmPageRequestManager();
    }
    function hideCrmLoadingOverlay() {
        var ds = document.getElementById("ds00");
        if (ds) { ds.style.display = "none"; }
        var divLoad = document.getElementById("div_Load");
        if (divLoad) { divLoad.style.display = "none"; }
        var cusLoad = document.getElementById("<%=divLoadingImageCus.ClientID %>");
        if (cusLoad) { cusLoad.style.display = "none"; }
    }
    function EndRequestHandler(sender, args) {
        if (args.get_error() != undefined) {
            args.set_errorHandled(true);
        }
        hideCrmLoadingOverlay();
        if (window.eprintCrmTabs) {
            window.eprintCrmTabs.applyPreview(getActiveCrmTab());
        }
        if (window.eprintCrmUi) {
            window.eprintCrmUi.updateActiveNav();
        }
        if (window.eprintCrmSections) {
            window.eprintCrmSections.refreshVisible();
        }
    }
    var eprintCrmTabClientId = "<%=ClientID%>";
    function getTabFromCookie() {
        var key = "CRMTabName" + eprintCrmTabClientId;
        var parts = document.cookie.split("; ");
        for (var i = 0; i < parts.length; i++) {
            if (parts[i].indexOf(key + "=") === 0) {
                return parts[i].substring(key.length + 1);
            }
        }
        return "client";
    }
    function getActiveCrmTab() {
        var hdnTab = document.getElementById("<%=hdnActiveCrmTab.ClientID %>");
        if (hdnTab && hdnTab.value) {
            return hdnTab.value.toLowerCase();
        }
        var root = document.querySelector(".eprint-crm-customer.eprint-crm-layout-v2");
        if (root && root.getAttribute("data-crm-active-tab")) {
            return root.getAttribute("data-crm-active-tab").toLowerCase();
        }
        return getTabFromCookie();
    }
    window.crmPrepareTab = function (tabKey, panelLabel, allowPostBack) {
        var normalizedTab = (tabKey || "client").toLowerCase();
        document.cookie = "CRMTabName" + eprintCrmTabClientId + "=" + normalizedTab;
        var hdnTab = document.getElementById("<%=hdnActiveCrmTab.ClientID %>");
        if (hdnTab) {
            hdnTab.value = normalizedTab;
        }
        var root = document.querySelector(".eprint-crm-customer.eprint-crm-layout-v2");
        if (root) {
            root.setAttribute("data-crm-active-tab", normalizedTab);
        }
        if (window.eprintCrmTabs) {
            window.eprintCrmTabs.applyPreview(normalizedTab);
        }
        if (window.eprintCrmUi) {
            window.eprintCrmUi.updateActiveNav();
        }
        if (panelLabel) {
            var panelNameEl = document.getElementById("<%=PanelName.ClientID %>");
            if (!panelNameEl) {
                panelNameEl = document.querySelector("[id$='_PanelName']");
            }
            if (panelNameEl) {
                panelNameEl.innerHTML = panelLabel;
            }
        }
        if (typeof LoadImgStarts === "function") {
            setTimeout(LoadImgStarts, 0);
        }
        return allowPostBack === true;
    };
    window.crmUpdateAddressBreadcrumb = function () {
        var companyType = (typeof CompanyType !== "undefined") ? CompanyType : "<%=CompanyType %>";
        var oldSitePath = "";
        if (companyType === "Customer" || companyType === "customer") {
            oldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Address Book</b></span>";
        } else if (companyType === "Supplier" || companyType === "supplier") {
            oldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Supplier' class='subnavigatorblack' style='text-decoration:underline'>Supplier View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Supplier Details > Address Book</b></span>";
        } else if (companyType === "Prospect" || companyType === "prospect") {
            oldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Prospect' class='subnavigatorblack' style='text-decoration:underline'>Prospect View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Prospect Details > Address Book</b></span>";
        }
        var sitePath = document.getElementById("ctl00_header2_lblsitepath");
        if (sitePath) {
            sitePath.innerHTML = oldSitePath;
        }
    };
    function crmPrepareTab(tabKey, panelLabel, allowPostBack) {
        return window.crmPrepareTab(tabKey, panelLabel, allowPostBack);
    }
    function crmUpdateAddressBreadcrumb() {
        return window.crmUpdateAddressBreadcrumb();
    }
</script>
<div id="ds00" style="display: none; position: fixed; top: 0; left: 0; width: 100%; height: 100%; z-index: 9999; background: rgba(0,0,0,0.05); pointer-events: auto;">
</div>
<div id="divBackGroundNew" style="display: none;">
</div>
<style type="text/css">
    .AddBtn {
        background-image: url('../Grid1/sprite.gif');
        margin-right: 3px;
        background-position: 0 -1650px;
        width: 200px;
        background-repeat: no-repeat;
        padding-left: 23px;
    }

    #ctl00_ContentPlaceHolder1_Client_RadGrid_Contact thead tr {
        white-space: nowrap;
    }

    #ctl00_ContentPlaceHolder1_Client_RadGridContact_ctl00_ctl03_ctl01_ChangePageSizeLabel, #ctl00_ContentPlaceHolder1_Client_RadGridContact_ctl00_ctl03_ctl01_PageSizeComboBox {
        display: none;
    }

    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td {
        border-style: solid;
        border-color: #C9C9C9;
        border-width: 0 0 1px 0px;
    }

    .RadGrid .rgHeader, .RadGrid th.rgResizeCol {
        padding-top: 0;
        text-align: left;
        font-weight: normal;
    }

    .RadGrid .rgFilterRow td {
        padding-top: 4px;
        padding-bottom: 4px;
    }

    .RowMouseOver td {
        background-color: #D8D8D8 !important;
        height: auto;
    }

    .RowMouseOut {
        background: #ffffff;
        height: auto;
    }

    #ctl00_ContentPlaceHolder1_Client_RadGrid_Contact_ctl00_Header {
        width: 99% !important;
    }

    .RadGrid .rgSelectedRow {
        background-color: #8F8F8F !important;
        background-image: none !important;
        height: auto;
    }

    .RadGrid_Default .rgCommandCell {
        border-right: 0px solid rgb(242, 242, 242);
        border-width: 0px 0px 0px;
        border-style: inherit;
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        border-color: rgb(153, 153, 153) rgb(242, 242, 242);
        padding: 0px;
        border: 0px solid red;
    }

    .RadGrid_Default .rgCommandTable {
        border-right: 0px none;
        border-left: 0px none;
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        border-width: 0px 0px;
        border-style: solid none;
        border-color: rgb(253, 253, 253) -moz-use-text-color rgb(231, 231, 231);
    }

    .RadGrid .rgClipCells .rgHeader, .RadGrid .rgClipCells .rgFilterRow > td, .RadGrid .rgClipCells .rgRow > td, .RadGrid .rgClipCells .rgAltRow > td, .RadGrid .rgClipCells .rgEditRow > td, .RadGrid .rgClipCells .rgFooter > td {
        overflow: visible;
    }

    .RadGrid_Default .rgEditForm {
        border-bottom: 1px solid rgb(130, 130, 130);
        background-color: White;
    }

    .upload-wrap {
        background-image: url('../images/Upload_Image.png');
        width: 224px;
        height: 25px;
        margin-top: -5px;
        margin-left: -4px;
    }

    .MinimumWidth {
        min-width: 73.4px;
    }

    .DialogueBackgroundSurveyView {
        background-color: White;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 5055;
    }

    .AllnotesbckFade {
        background-color: White;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 5055;
    }

    .detalilslayer {
        background-color: #D2D2D2;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 50;
    }

    .DialogueBackgroundRdWindow {
        background-color: #D2D2D2;
        filter: alpha(opacity=50);
        opacity: 0.50;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        display: block;
        z-index: 50;
    }

    .RadGrid_Default .rgCommandRow {
        background: url("");
        color: rgb(0, 0, 0);
    }

    .RadGrid_Default .rgHeaderDiv {
        background: url("");
    }

    .RadGrid_Default .rgHeader, .RadGrid_Default th.rgResizeCol {
        border-style: none none none;
        border-color: -moz-use-text-color -moz-use-text-color rgb(130, 130, 130);
        -moz-border-top-colors: none;
        -moz-border-right-colors: none;
        -moz-border-bottom-colors: none;
        -moz-border-left-colors: none;
        border-image: none;
        background: url("../images/topbar11.png");
    }

    .RadGrid_Default .rgFilterRow {
        background: none;
    }

    div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td {
        border-style: solid;
        border-color: rgb(201, 201, 201);
        border-width: 0px 0px 1px;
    }

    .rgHeaderDiv {
        width: 100% !important;
        padding-right: 0px;
    }

    .moreaction {
        font-size: 12px;
        color: Gray;
    }

    #ctl00_ContentPlaceHolder1_Client_RadTimePicker1_timeView_wrapper, #ctl00_ContentPlaceHolder1_Client_RadTimePicker5_timeView_wrapper {
        min-width: 214px;
    }

    #ctl00_ContentPlaceHolder1_Client_RadGrid_Department_GridHeader, th {
        white-space: nowrap;
    }
</style>
<asp:ScriptManagerProxy ID="smproxy" runat="server">
    <services>
        <asp:ServiceReference Path="~/AutoFill.asmx" />
    </services>
</asp:ScriptManagerProxy>
<asp:UpdatePanel ID="UpdatePanel4" runat="server">
    <contenttemplate>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Contact">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Contact" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btn_ClearFilter_Contact">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Contact" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Department">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Department" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btn_ClearFilters_Dept">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Department" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Address">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Address" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btn_ClearFilter_Address">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Address" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="div3">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckOne_new_Address" />
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Address" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Products">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Products" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lnk_ClearFilter_Product">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Products" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Email">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Email" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lnk_ClearFilter_Email">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Email" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lnk_EmailRadList">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Email" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Estimates">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Estimates" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lnk_ClearFilter_Estimate">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Estimates" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_eStore">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_eStore" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lnk_ClearFilter_eStorerecords">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_eStore" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Jobs">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Jobs" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lnk_ClearFilter_JObrecords">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Jobs" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid_Invoices">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Invoices" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="lnk_ClearFilter_Invoice">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid_Invoices" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="grdcostcentre">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="grdcostcentre" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="btn_ClearFilter_Costcenter">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="grdcostcentre" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGridContact">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGridContact" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server"
            Skin="Default" />
    </contenttemplate>
</asp:UpdatePanel>
<asp:UpdateProgress ID="upProgress" runat="server">
    <progresstemplate>
        <div id="div_Load" class="loading_new" style="display: block; z-index: 99999">
            <table cellpadding="0" cellspacing="10">
                <tr>
                    <td>
                        <div id="DivBigLoadingImg" style="float: left">
                            <img src="<%=ImgPath %>loading_new.gif" border="0" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </progresstemplate>
</asp:UpdateProgress>
<div id="divLoadingImageCus" runat="server" style="display: none;">
    <div id="DivLayer" class="DialogueBackgroundSurveyView">
    </div>
    <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
        <img src="<%=ImgPath %>loading_new.gif" border="0" style="border-radius: 2px;" />
    </div>
</div>
<div id="divallnotesbckfade" class="AllnotesbckFade" style="display: none;">
</div>
<div id="Divshowallnotes" style="min-height: 212px; height: 412px; width: 980px; left: 10%; position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton26" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseAllnotesPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -12px;">
        <tr>
            <td style="width: 400px;">
                <div>
                    <asp:Label ID="lblti" runat="server" Text="Account Notes" CssClass='NotesSumm' Style='font-weight: bold;'>
                    <%=objLangClass.GetLanguageConversion("Account_Notes")%>
                    </asp:Label>
                    <asp:Label ID="lblnotecount" runat="server" Text="" Style='font-weight: bold; font-size: 12px;'>                    
                    </asp:Label>
                </div>
            </td>
            <td>
                <div align="center" id="DivAllNotesMessage" style="margin-bottom: 0px; display: none;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="DivAllNoteImgMsg" class="msg_success123">
                                </div>
                            </td>
                            <td>
                                <div id="Div16" style="margin-bottom: 4px;">
                                    <asp:Label ID="lblAllnotessucmsg" runat="server" Text="Note deleted successfully"
                                        Style="color: #FD8404; font-weight: bold; font-size: 11px;" CssClass="lblSuccMesgCl"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table style='border: 0px solid red; width: 100%; margin-top: 7px;' cellpadding='0'
        cellspacing='0'>
        <tr>
            <td class='bgcustomizeNew' style='width: 17%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold; margin-left: 5px;'>
                        <%=objLangClass.GetLanguageConversion("Note_Title")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 20%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Note_Content")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Created_By")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Specific_to_Contact")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Date")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 6%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; margin-left: 3px; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Action")%></span>
                </div>
            </td>
        </tr>
    </table>
    <div id="divscroll" style="height: 377px; width: 100%; overflow: auto; overflow-x: hidden; margin-top: 0px;">
        <asp:Label ID="lblAllNotes" runat="server"></asp:Label>
    </div>
</div>
<div id="DicShowAllCl" style="min-height: 212px; height: 412px; width: 980px; left: 10%; position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton29" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseAllClPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -12px;">
        <tr>
            <td style="width: 400px;">
                <div>
                    <asp:Label ID="lblclosetask" runat="server" Text="Close Tasks & Calls" CssClass='NotesSumm'
                        Style='font-weight: bold;'>
                        
                    </asp:Label>
                    <asp:Label ID="lblClCounts" runat="server" Text="" Style='font-weight: bold; font-size: 12px;'>
                    </asp:Label>
                </div>
            </td>
            <td>
                <div align="center" id="DivAllClMsg" style="margin-bottom: 0px; display: none;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="Div20" class="msg_success123">
                                </div>
                            </td>
                            <td>
                                <div id="Div21" style="margin-bottom: 4px;">
                                    <asp:Label ID="lblAllClMsg" runat="server" Text="Note deleted successfully" Style="color: #FD8404; font-weight: bold; font-size: 11px;"
                                        CssClass="lblSuccMesgCl"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table id='Table2' style='border: 0px solid red; margin-top: 7px; width: 100%' cellpadding='0'
        cellspacing='0'>
        <tr>
            <td class='bgcustomizeNew' style='width: 17%;'>
                <div style='margin-top: 0px; margin-left: 5px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Subject")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 9%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Status")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 5%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Type")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Assigned_To")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Name")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 10%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Mobile")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 10%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Phone")%></span>
                </div>
            </td>

            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Due_Date")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 6%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Action")%></span>
                </div>
            </td>
        </tr>
    </table>
    <div id="div22" style="height: 382px; width: 100%; overflow: auto; overflow-x: hidden; margin-top: 0px;">
        <asp:Label ID="lblAllCl" runat="server"></asp:Label>
    </div>
</div>
<div id="DicShowAllOpenActivities" style="min-height: 212px; height: 412px; width: 980px; left: 10%; position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton28" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseAllOAPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -12px;">
        <tr>
            <td style="width: 400px;">
                <div>
                    <asp:Label ID="lblopentask" runat="server" Text="Open Tasks & Calls" CssClass='NotesSumm'
                        Style='font-weight: bold;'>                        
                    </asp:Label>
                    <asp:Label ID="lblopenActivityCount" runat="server" Text="" Style='font-weight: bold; font-size: 12px;'>
                    </asp:Label>
                </div>
            </td>
            <td>
                <div align="center" id="DivdeleteAllOA" style="margin-bottom: 0px; display: none;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="Div17" class="msg_success123">
                                </div>
                            </td>
                            <td>
                                <div id="Div18" style="margin-bottom: 4px;">
                                    <asp:Label ID="Label145" runat="server" Text="Note deleted successfully" Style="color: #FD8404; font-weight: bold; font-size: 11px;"
                                        CssClass="lblSuccMesgCl"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table id='tbOpenActivities' style='border: 0px solid red; margin-top: 7px; width: 100%'
        cellpadding='0' cellspacing='0'>
        <tr>
            <td class='bgcustomizeNew' style='width: 17%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold; margin-left: 5px;'>
                        <%=objLangClass.GetLanguageConversion("Subject")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 9%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Status")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 5%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Type")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Assigned_To")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Name")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        Contact Email></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 10%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Mobile")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 10%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Contact_Phone")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        Department Name</span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 12%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Due_Date")%></span>
                </div>
            </td>
            <td class='bgcustomizeNew' style='width: 7%;'>
                <div style='margin-top: 0px;'>
                    <span style='color: black; margin-left: 5px; font-weight: bold;'>
                        <%=objLangClass.GetLanguageConversion("Action")%></span>
                </div>
            </td>
        </tr>
    </table>
    <div id="div19" style="height: 382px; width: 100%; overflow: auto; overflow-x: hidden; margin-top: 0px;">
        <asp:Label ID="lblAllOA" runat="server"></asp:Label>
    </div>
</div>
<div id="DivOpenActiDetails" style="min-height: 200px; height: auto; width: 505px; left: 30%; position: absolute; top: 18%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton22" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseOADetails(); return false;"></asp:LinkButton>
    </div>
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -20px; display: none;">
            <tr>
                <td>
                    <div style="margin-left: 380px;">
                        <div style="float: left; margin-left: 7px; margin-top: 5px;">
                            <asp:Button ID="btnmoreactionpopup" runat="server" Text="More Actions" CssClass="moreoptions white"
                                onmouseover="javascript:OpenMoreActionsPopup('ctl00_ContentPlaceHolder1_Client_btnmoreactionpopup'); return false;"
                                Width="120px" OnClientClick="javascript:return false;" Style="background: url(../images/down_arrow.png) 95% no-repeat;"></asp:Button>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <div style="margin-top: -10px;">

            <div id='div_loadingtaskcall' class="DialogueBackgroundSurveyView" style='display: none;'>
                <div id='divBackGround1' style='position: absolute; z-index: 800; top: 40%; left: 45%;'>
                    <div id='divLoading' style='position: absolute; display: block;'>
                        <div class='Graphic'>
                            <div style='padding-left: 25px'>
                                <img src="<%=strimgpath%>loading_new.gif" border='0' />
                            </div>
                            <div style='clear: both'>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label126" runat="server" Text="Status" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Status")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetStatus" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label128" runat="server" Text="Subject" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Subject")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px; overflow: hidden;">
                    <asp:Label ID="lblDetSubject" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label127" runat="server" Text="Type" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Type")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetType" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label129" runat="server" Text="Due Date" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Due_Date")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetDueDate" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>

               <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label1299" runat="server" Text="Company Name" CssClass="normalText">
                Company Name
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetCompanyName" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label130" runat="server" Text="Contact Name" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Contact_Name")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetContactName" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>

            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label49" runat="server" Text="Contact Email" CssClass="normalText">
                        Contact Email
               <%-- <%=objLangClass.GetLanguageConversion("Contact_Name")%>--%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lblDetContactEmail" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>

            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label153" runat="server" Text="Contact Phone" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Contact_Mobile")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetContactMobile" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label131" runat="server" Text="Contact Phone" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Contact_Phone")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetContactPhone" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>

            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label50" runat="server" Text="Department Name" CssClass="normalText">
                        Department Name
               <%-- <%=objLangClass.GetLanguageConversion("Contact_Name")%>--%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lblDetDepartmentName" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>

            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label41" runat="server" Text="Contact Phone" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Department_Phone")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbl_DeptPhone" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label133" runat="server" Text="Assigned To" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Assigned_To")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetAssignTo" runat="server" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div align="left">
                <div class="bglabel" style="width: 180px;">
                    <asp:Label ID="Label141" runat="server" Text="Notes" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Description")%>
                    </asp:Label>
                </div>
                <div class="box" style="margin-top: 4px; margin-left: 3px;">
                    <asp:Label ID="lbldetDescription" runat="server" Width="322px" Style="word-wrap: break-word; max-height: 100px; overflow: hidden;" CssClass="normalText"></asp:Label>
                </div>
            </div>
            <div style="float: left; margin-top: 20px; width: 100%;">
                <table border="0" cellpadding="0" cellspacing="0" style="float: left;">
                    <tr>
                        <td>
                            <asp:Button ID="btnDelEdit" runat="server" CssClass="button" Text="Edit" OnClientClick="javascript:Edit_TaskCallDetails(this.id); return false;"></asp:Button>
                        </td>
                        <td>
                            <div style="margin-left: 7px;">
                                <asp:Button ID="btnDelDelete" runat="server" CssClass="button" Text="Delete" CausesValidation="False"
                                    Visible="true" OnClientClick="javascript:delete_TaskCallDetails();return false;"></asp:Button>
                            </div>
                        </td>
                        <td id="divbtncomplete">
                            <div style="margin-left: 7px;">
                                <asp:Button ID="btndetComplete" runat="server" CssClass="button" Text="Complete"
                                    CausesValidation="False" Visible="true" OnClientClick="javascript:Complete_TaskCallDetails();return false;"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</div>
<div id="DivMoreActionForPopup" runat="server" class="ddMpopup" style="display: none; height: auto; z-index: 555555555555; margin-top: 25px;"
    onmouseover="javascript:OpenMoreActionsPopup('ctl00_ContentPlaceHolder1_Client_btnmoreactionpopup'); return false;"
    onmouseout="javascript:ClosedMoreActionsPopup(); return false;">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                    <asp:LinkButton ID="LinkButton33" runat="server" Text="Complete" OnClientClick="javascript:Complete_TaskCallDetails();return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
        <tr>
            <td class="moreactionpanel" style="width: 180px;">
                <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                    <asp:LinkButton ID="Lnkedit" runat="server" Text="Edit" OnClientClick="javascript:Edit_TaskCallDetails(this.id); return false;"
                        Style="color: #000000;" CssClass="moreaction"></asp:LinkButton>
                </div>
            </td>
        </tr>
    </table>
</div>
<div id="DivNoteDetails" style="min-height: 160px; height: auto; width: 505px; left: 30%; position: absolute; top: 25%; z-index: 5555555; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton27" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseNoteDetails(); return false;"></asp:LinkButton>
    </div>
    <div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label142" runat="server" Text="Note Title" CssClass="normalText">
                  <%=objLangClass.GetLanguageConversion("Note_Title")%>
                </asp:Label>
            </div>
            <div class="box" style="margin-top: 4px; margin-left: 3px;">
                <asp:Label ID="lbldetNoteTitle" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label146" runat="server" Text="Specific to Contact" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Specific_to_Contact")%>
                </asp:Label>
            </div>
            <div class="box" style="margin-top: 4px; margin-left: 3px;">
                <asp:Label ID="lbldetSpecifictoContact" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label148" runat="server" Text="Added By" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Created_By")%>
                </asp:Label>
            </div>
            <div class="box" style="margin-top: 4px; margin-left: 3px;">
                <asp:Label ID="lbldetAddedBy" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label150" runat="server" Text="Date" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Date")%>
                </asp:Label>
            </div>
            <div class="box" style="margin-top: 4px; margin-left: 3px;">
                <asp:Label ID="lbldetDate" runat="server" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div align="left">
            <div class="bglabel" style="width: 180px;">
                <asp:Label ID="Label144" runat="server" Text="Note Content" CssClass="normalText">
                <%=objLangClass.GetLanguageConversion("Note_Content")%>
                </asp:Label>
            </div>
            <div class="box" style="margin-top: 4px; margin-left: 3px;">
                <asp:Label ID="lbldetNoteContent" runat="server" Width="322px" Style="word-wrap: break-word; max-height: 100px; overflow: hidden;" CssClass="normalText"></asp:Label>
            </div>
        </div>
        <div style="float: left; margin-top: 20px; width: 100%;">
            <table border="0" cellpadding="0" cellspacing="0" style="float: left;">
                <tr>
                    <td>
                        <asp:Button ID="btnDetailsEdit" runat="server" CssClass="button" Text="Edit" OnClientClick="javascript:Edit_DetailsNotes(); return false;"></asp:Button>
                    </td>
                    <td>
                        <div style="margin-left: 7px;">
                            <asp:Button ID="btndeleteDetNotes" runat="server" CssClass="button" Text="Delete"
                                CausesValidation="False" Visible="true" OnClientClick="javascript:delete_Detailsnote();return false;"></asp:Button>
                        </div>
                    </td>
                    <td id="Td1">
                        <div style="margin-left: 7px;">
                            <asp:Button ID="btnviewdetattachedfile" runat="server" CssClass="button" Text="View Attached File"
                                CausesValidation="False" Visible="true" OnClientClick="javascript:ShowNoteAttachedFiles();return false;"></asp:Button>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<div id="DivNotesPopup" style="min-height: 270px; height: auto; width: 450px; position: absolute; z-index: 9999; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LnkCloseTaskPopup" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseTaskPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <div style="margin-top: 19px; float: left; margin-left: -34px;">
        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CssClass="TaskLeftArrow"></asp:LinkButton>
    </div>
    <div id="DivTaskMain">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: -8px; width: 480px;">
            <tr>
                <td colspan="2">
                    <div align="left" style="margin-top: -11px; margin-bottom: 11px;">
                        <asp:Label ID="Label113" runat="server" Text="" CssClass="normalText" Style="font-size: 15px;">
                         <%=objLangClass.GetLanguageConversion("Add_Task")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin-top: -5px; border-bottom: 1px dashed gray; margin-bottom: 13px; width: 460px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 239px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 239px;">
                        <tr>
                            <td>
                                <div style="margin-top: 0px;">
                                    <asp:Label ID="Label56" runat="server" Text="Assigned to" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Assigned_To")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlassigneto" CssClass="simpledropdownPopup"
                                        Width="200px" TabIndex="501">
                                    </asp:DropDownList>
                                </div>
                                <div id="DivSpan_ddlassigneto" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 5px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="LblSubject" runat="server" Text="Subject" CssClass="normalText" Style="color: #383838;">
                                         <%=objLangClass.GetLanguageConversion("Subject")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="ImageButton9" OnClientClick="javascript:OpenSubjectDiv();return false;"
                                        runat="server" ToolTip="Add new subject" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="ImgClearSubject" OnClientClick="javascript:ClearSubjectDrop();return false;"
                                        runat="server" ToolTip="Clear subject" CausesValidation="False" ImageUrl="~/images/Clear_sub.png"
                                        Style="height: 15px; width: 16px; display: none;"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlsubject" CssClass="simpledropdownPopup" Width="200px"
                                        onchange="javascript:Displayclearbutton(); return false;" TabIndex="503">
                                    </asp:DropDownList>
                                </div>
                                <div id="spn_ddlsubject" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 4px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label59" runat="server" Text="Contact" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Contact")%></asp:Label>
                                </div>
                                <div style="float: left; margin-left: 5px; margin-top: 7px; display: none;">
                                    <asp:ImageButton ID="ImageButton2" OnClientClick="javascript:OpenShowContactDiv();return false;"
                                        runat="server" ToolTip="Select Contact" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="imgClearcontacts" OnClientClick="javascript:ClearContacts();return false;"
                                        runat="server" ToolTip="Clear contact" CausesValidation="False" ImageUrl="~/images/Clear_sub.png"
                                        Style="height: 15px; width: 16px; display: none;"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlTaskContacts" CssClass="simpledropdownPopup"
                                        Width="200px" TabIndex="505">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label7" runat="server" Text="Contact" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Contact_Phone")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txt_TaskContactPhone" runat="server" Width="200px" TabIndex="506"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label9" runat="server" Text="Contact" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Department_Phone")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txt_TaskDepartmentPhone" runat="server" Width="200px" TabIndex="506"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" style="width: 239px;">
                    <table>
                        <tr>
                            <td>
                                <div style="margin-top: -2px;">
                                    <asp:Label ID="Label57" runat="server" Text="Status" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Status")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: -1px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlstatus" CssClass="simpledropdownPopup" Width="200px"
                                        TabIndex="502">
                                    </asp:DropDownList>
                                </div>
                                <div id="Span_ddlstatus" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: -1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 3px;">
                                    <asp:Label ID="Label58" runat="server" Text="Priority" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Priority")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 2px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlpriority" CssClass="simpledropdownPopup"
                                        Width="200px" TabIndex="504">
                                    </asp:DropDownList>
                                </div>
                                <div id="Span_ddlpriority" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:Label ID="Label60" runat="server" Text="Due Date" Style="color: #383838;"></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                    <asp:Label ID="Label149" runat="server" Text="Time (hh:mm)" Style="color: #383838; margin-left: 25px;"></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 0px; float: left;">
                                    <asp:TextBox ID="txtduedate" runat="server" SkinID="textPad" CssClass="txtbox" Width="82px"
                                        TabIndex="506"> </asp:TextBox>&nbsp;&nbsp;
                                    <telerik:RadTimePicker ID="RadTimePicker" runat="server" SkinID="textPad" Height="19px"
                                        Width="104px" ZIndex="30001" inputmode="TimePicker" CssClass="normaltext" TabIndex="507">
                                        <DateInput ID="DateInput1" runat="server" DateFormat="hh:mm tt" DisplayDateFormat="hh:mm tt">
                                        </DateInput>
                                        <ClientEvents OnDateSelected="DateSelected" />
                                        <TimeView ID="TimeView1" runat="server" TimeFormat="hh:mm tt" Columns="3" OnClientTimeSelected="ClientTimeSelected"
                                            Interval="0:30:0" TimeOverStyle-CssClass="rcHover">
                                        </TimeView>
                                        <Calendar ID="Calendar1" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                    </telerik:RadTimePicker>
                                </div>
                                <div id="Span_txtduedate" style="display: none; width: 16px; float: left; margin-left: 2px; margin-top: -1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="Span_txtduedate1" style="display: none; width: 196px; float: left; margin-left: 0px; margin-top: 4px; color: Red;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px"></span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 2px;">
                                    <asp:Label ID="Label8" runat="server" Text="Status" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Contact_Mobile")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: -1px; float: left;">
                                    <asp:TextBox ID="txt_TaskContactMobile" runat="server" TabIndex="506" Width="200px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <div style="margin-top: 7px;">
                                    <asp:Label ID="Label61" runat="server" Text="Description" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Description")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px; width: 100%;">
                                    <asp:TextBox ID="txtNotesDesc" runat="server" SkinID="textPad" CssClass="txtbox"
                                        TextMode="MultiLine" Width="442px" Style="max-width: 442px; max-height: 230px;"
                                        TabIndex="509"> </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 5px;">
                                    <div style="float: left; margin-left: 0px; margin-top: 10px;">
                                        <asp:Button ID="btnsavetasks" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                            Visible="true" OnClientClick="javascript:Validatesavenotes();return false;"></asp:Button>
                                        <div id="div_loading_btnsavetasks" style="display: none; width: 46px; padding-bottom: 2px; padding-top: 2px; border: solid 1px #a3a3a3; border-radius: .5em; text-align: center; background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));">
                                            <image src="../images/radimg1.gif" alt="loading" class="loadingimg"></image>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>

    <div id="DivOpenSubject" style="height: 85px; width: 313px; left: 15%; position: absolute; top: 40%; z-index: 9999; opacity: 1; display: none;"
        class="Popupnotes">
        <div style="margin-top: -32px; float: right; margin-right: -30px;">
            <asp:LinkButton ID="lblAddSubject" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
                OnClientClick="javascript:CloseTaskPopupAddSubject(); return false;"></asp:LinkButton>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1" style="margin-top: -10px;">
            <tr>
                <td>
                    <asp:Label ID="Label92" runat="server" SkinID="textPad" Width="302px"><%=objLangClass.GetLanguageConversion("Add_New_Subjects")%></asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 7px;">
            <tr>
                <td>
                    <div class="bglabel" style="margin-top: 12px; width: 100px;">
                        <asp:Label ID="Label64" runat="server" Text="Subject" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Subject")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px; margin-top: -2px;">*</span>
                    </div>
                </td>
                <td>
                    <div style="margin-top: 10px; margin-left: 4px; float: left;">
                        <div style="float: left;">
                            <asp:TextBox ID="txtSubject" runat="server" SkinID="textPad" CssClass="txtbox" Width="178px"
                                Height="21px"> </asp:TextBox>
                        </div>
                        <div id="DivSubjectAddValidations" style="display: none; width: 16px; float: left; margin-left: 5px;">
                            <div class="RFV_Message" style="border-radius: 2px; float: left;">
                                <span style="float: left; padding-left: 4px">*</span>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="float: left; margin-top: 10px; margin-left: 115px;">
                        <asp:Button ID="lnkSaveSubject" runat="server" CssClass="button" Text="Save" Visible="true"
                            CausesValidation="false" OnClientClick="javascript:ValidateAddSubject();return false;"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="AddCallnTask" runat="server" class="header_settingmenu" style="display: none; width: 80px;">
    <div class="header_settinguparrowdiv" style="margin: -11px 0 0 13px;">
        <img src="<%=strimgpath%>upperarrow.png" class="header_uparrowimg" alt="arrow" />
    </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <div style="margin-top: 10px; margin-left: 12px;" align="left">
                    <a id="Add_Task" runat="server" title="New Task" class="QuickButtons" style="cursor: pointer;"
                        onclick="OpenPopUp(this.id);">
                        <%=objLangClass.GetLanguageConversion("Add_Task")%></a>
                </div>
            </td>
        </tr>

        <tr>
            <td>
                <div id="div10" runat="server" style="margin-top: 10px; margin-left: 12px;" align="left">
                    <a id="Add_Call" runat="server" title="New Call" class="QuickButtons" style="cursor: pointer;"
                        onclick="OpenCallPopup(this.id);">
                        <%=objLangClass.GetLanguageConversion("Add_Call")%></a>
                </div>
            </td>
        </tr>
    </table>
</div>
<div id="DivCallPopup" style="min-height: 250px; width: 450px; position: absolute; z-index: 9999; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px; display: block;">
        <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseCallPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <div style="margin-top: 19px; float: left; margin-left: -34px;">
        <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="false" CssClass="TaskLeftArrow"></asp:LinkButton>
    </div>
    <div id="MainDivCallTimer">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 480px; border: 0px solid red; margin-left: -5px;">
            <tr>
                <td colspan="2">
                    <div align="left" style="margin-top: -11px; margin-bottom: 11px;">
                        <asp:Label ID="Label118" runat="server" Text="Add Call" CssClass="normalText" Style="font-size: 15px;">
                        <%=objLangClass.GetLanguageConversion("Add_Call")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin-top: -5px; border-bottom: 1px dashed gray; width: 455px; margin-bottom: 13px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 239px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -15px;">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 5px;">
                                    <asp:Label ID="Label89" runat="server" Text="Assigned to" Style="color: #383838;">
                         <%=objLangClass.GetLanguageConversion("Assigned_To")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlowner" CssClass="simpledropdownPopup" Width="200px">
                                    </asp:DropDownList>
                                </div>
                                <div id="diverrorCallAssignTo" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 5px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label75" runat="server" Text="Subject" Style="color: #383838;" CssClass="normalText">
                        <%=objLangClass.GetLanguageConversion("Subject")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="ImageButton11" OnClientClick="javascript:OpenCallSubjectDiv(this.id);return false;"
                                        runat="server" ToolTip="Add new subject" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 5px;">
                                    <asp:DropDownList runat="server" ID="ddlCallSubject" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                                <div id="DivCallSubject_Validate" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 4px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label76" runat="server" Text="Contact" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Contact")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlCallAssignTo" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label17" runat="server" Text="Contact" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Contact_Phone")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txt_CallContactPhone" runat="server" Width="200px" TabIndex="506"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label33" runat="server" Text="Contact" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Department_Phone")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txt_CallDepartmentPhone" runat="server" Width="200px" TabIndex="506"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlCallPurpose" CssClass="simpledropdownPopup"
                                        AppendDataBoundItems="true" Width="200px">
                                        <asp:ListItem Text="--None--" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 239px; position: absolute; margin-top: -4px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 5px;">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: -11px;">
                                    <asp:Label ID="Label80w" runat="server" Text="Call Details" Style="color: #383838;">
                          <%=objLangClass.GetLanguageConversion("Call_Details")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: block;">
                                <div style="float: left; margin-top: 5px;">
                                    <asp:DropDownList runat="server" ID="ddlCallDetailsType" CssClass="simpledropdownPopup"
                                        Width="200px" onchange="Javascript:ShowCallDetailType(); return false;">
                                        <asp:ListItem Text="Completed Call" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Scheduled Call" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: none;">
                                <div style="float: left; margin-top: 4px;">
                                    <asp:RadioButton ID="RdoCurrentCall" runat="server" Text="Current Call" GroupName="Call"
                                        Checked="true" />
                                </div>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:RadioButton ID="RdoCompletedCall" runat="server" Text="Completed Call" GroupName="Call" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: none;">
                                <div style="float: left; margin-top: 4px;">
                                    <asp:RadioButton ID="RdoScheduledCall" runat="server" Text="Scheduled Call" GroupName="Call" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="DivCallTimer">
                                <div style="background-color: #E1F3FD; float: left; margin-top: 8px; width: 200px; visibility: hidden;">
                                    <div style="float: left; margin-top: 7px;">
                                        <div style="margin-left: 10px; font-size: 13px;">
                                            <span id="Span1">
                                                <%=objLangClass.GetLanguageConversion("Call_Timer")%></span>
                                        </div>
                                        <div style="margin-top: 5px; margin-left: 12px; margin-bottom: 7px; font-weight: bold; font-size: 13px;">
                                            <span id="stopwatch">00:00</span>
                                        </div>
                                    </div>
                                    <div style="float: left; margin-top: 7px; margin-left: 22px;">
                                        <div id="DivFirstStartButton" runat="server">
                                            <div class="Playbutton" onclick='Example1.Timer.toggle();' title="Start/Stop" style="cursor: pointer;">
                                            </div>
                                        </div>
                                        <div id="DivFirstPauseButton" runat="server" style="display: none;">
                                            <div class="Playbutton" onclick='Example1.Timer.toggle();' title="Start/Stop" style="cursor: pointer;">
                                            </div>
                                        </div>
                                    </div>
                                    <div id="DivButtonResart" runat="server" style="float: left; display: none; margin-top: 8px; margin-left: 10px; margin-bottom: 7px;">
                                        <div class="Pausebutton" onclick='Example1.resetStopwatch();' style="float: left; cursor: pointer;"
                                            title="Pause">
                                        </div>
                                        <div class="Stopbutton" onclick='Example1.resetStopwatch123();' style="float: left; cursor: pointer; margin-left: 10px;"
                                            title="Reset">
                                        </div>
                                        <asp:HiddenField ID="hdncallstaTime" runat="server" />
                                        <asp:HiddenField ID="hdncallHours" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="DivCallStartTime" style="display: none;">
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label81" runat="server" Text="Call Start Date" Style="color: #383838;">
                                        <%=objLangClass.GetLanguageConversion("Call_Start_date")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                    <asp:Label ID="Label100" runat="server" Text="Time (hh:mm)" Style="color: #383838; margin-left: 5px;"></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="DivCallStartTime1" style="display: none;">
                                <div style="float: left; margin-top: 5px;">
                                    <asp:TextBox ID="txtcallstartdate" runat="server" SkinID="textPad" CssClass="txtbox"
                                        Width="95px"> </asp:TextBox>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 5px;">
                                    <div style="float: left; padding-left: 2px;">
                                        <telerik:RadTimePicker ID="RadTimePicker4" runat="server" SkinID="textPad" Height="19px"
                                            Width="104px" ZIndex="30001" inputmode="TimePicker" CssClass="normaltext">
                                            <DateInput ID="DateInput5" runat="server" DateFormat="hh:mm tt" DisplayDateFormat="hh:mm tt">
                                            </DateInput>
                                            <ClientEvents OnDateSelected="DateSelected" />
                                            <TimeView ID="TimeView5" runat="server" TimeFormat="hh:mm tt" Columns="3" OnClientTimeSelected="ClientTimeSelected"
                                                Interval="0:30:0" TimeOverStyle-CssClass="rcHover">
                                            </TimeView>
                                            <Calendar ID="Calendar5" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                                UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                        </telerik:RadTimePicker>
                                    </div>
                                    <div style="float: left; padding-left: 5px; display: none;">
                                        <asp:DropDownList ID="ddlcallHours" CssClass="normaltext" runat="server" Width="41px">
                                        </asp:DropDownList>
                                        :
                                        <asp:DropDownList ID="ddlcallMinute" CssClass="normaltext" runat="server" Width="41px">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlcalltime" CssClass="simpledropdownPopup"
                                        Width="95px" Visible="false">
                                        <asp:ListItem Text="12:00 AM" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="span_txtcallstartdate" style="display: none; width: 16px; float: left; margin-left: 0px; margin-top: 0px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td id="DivCallDuration" style="display: none; float: left;">
                                <div style="float: left; margin-top: 8px;">
                                    <asp:Label ID="Label82" runat="server" Text="Call Duration" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Call_Duration")%>
                                    </asp:Label>
                                </div>
                                <div id="DurationStar" style="float: left; margin-top: 9px;">
                                    <span class="redver7" style="margin-left: 1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td id="DivCallDuration1" style="display: none;">
                                <div style="float: left; margin-top: 4px;">
                                    <asp:TextBox ID="txtcallMinute" runat="server" SkinID="textPad" CssClass="txtbox"
                                        Width="47px" MaxLength="2" onkeypress="return validateNumberOnly(event);"> </asp:TextBox>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 4px;">
                                    <asp:Label ID="Label83" runat="server" Text="minutes" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("minutes")%>
                                    </asp:Label>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 5px;">
                                    <asp:TextBox ID="txtcallSecond" runat="server" SkinID="textPad" MaxLength="2" CssClass="txtbox"
                                        Width="46px" onkeypress="return validateNumberOnly(event);"> </asp:TextBox>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 4px;">
                                    <asp:Label ID="Label84" runat="server" Text="seconds" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("seconds")%>
                                    </asp:Label>
                                </div>
                                <div id="Span_MinuteSecond" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 4px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 9px;">
                                    <asp:Label ID="Label99" runat="server" Text="Call type" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Call_Type")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 6px;">
                                    <asp:DropDownList runat="server" ID="ddlCallType" CssClass="simpledropdownPopup"
                                        Width="200px">
                                        <asp:ListItem Text="Inbound" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Outbound" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px;">
                                    <asp:Label ID="Label34" runat="server" Text="Status" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Contact_Mobile")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:TextBox ID="txt_CallContactMobile" runat="server" TabIndex="506" Width="200px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label147" runat="server" Text="" Style="color: #383838;">
                     
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="margin-top: 5px;">
                                    <asp:Label ID="Label90" runat="server" Text="Notes" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Description")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txtCallDesc" runat="server" SkinID="textPad" CssClass="txtbox" TextMode="MultiLine"
                                        Width="440px" Style="max-width: 440px; max-height: 190px;"> </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 10px; display: none;">
                                    <asp:Button ID="btnCloseCallPopup" runat="server" CssClass="button" Text="Close"
                                        OnClientClick="javascript:CloseCallPopup(); return false;"></asp:Button>
                                </div>
                                <div style="float: left; margin-left: 0px; margin-top: 10px;">
                                    <asp:Button ID="btnSaveCall" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                        Visible="true" OnClientClick="javascript:CallChkvalidate(); return false;"></asp:Button>
                                    <div id="div_loading_btnSaveCall" style="display: none; width: 46px; padding-bottom: 2px; padding-top: 2px; border: solid 1px #a3a3a3; border-radius: .5em; text-align: center; background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));">
                                        <image src="../images/radimg1.gif" alt="loading" class="loadingimg"></image>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="MainDivCallTimerSecond" style="display: none;">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div style="margin-top: 0px;">
                        <asp:Label ID="Label86" runat="server" Text="More Fields" Style="font-size: 16px;"> <%=objLangClass.GetLanguageConversion("More_Fields")%></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 10px; border-bottom: 1px dashed gray; width: 230px; margin-bottom: 10px;">
                        <asp:Label ID="Label87" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <div style="float: left; margin-top: 5px;">
                        <asp:Label ID="Label88" runat="server" Text="Call Result" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Call_Result")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <div style="float: left; margin-top: 5px;">
                        <asp:TextBox ID="txtcallresult" runat="server" SkinID="textPad" CssClass="txtbox"
                            Width="200px"> </asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <div style="margin-top: 5px;">
                        <asp:CheckBox ID="ChkBillable" runat="server" Text="Billable" Style="color: #383838;" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 15px;">
                        <asp:Button ID="bynBackCallPopup" runat="server" CssClass="button" Text="Back" CausesValidation="False"
                            Visible="true"></asp:Button>
                    </div>
                    <div style="float: left; margin-left: 7px; margin-top: 15px;">
                        <asp:Button ID="btnSaveCall1" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                            Visible="true"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="DivCallSubjects" style="height: 85px; width: 313px; left: 58%; position: absolute; top: 45%; z-index: 9999999999; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="LinkButton21" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:CloseCallPopupAddSubject(); return false;"></asp:LinkButton>
    </div>
    <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1" style="margin-top: -10px;">
        <tr>
            <td>
                <asp:Label ID="Label124" runat="server" SkinID="textPad" Width="302px"><%=objLangClass.GetLanguageConversion("Add_New_Subjects")%></asp:Label>
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 7px;">
        <tr>
            <td>
                <div class="bglabel" style="margin-top: 12px; width: 100px;">
                    <asp:Label ID="Label125" runat="server" Text="Subject" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Subject")%></asp:Label>
                    <span class="redver7" style="margin-left: -1px; margin-top: -2px;">*</span>
                </div>
            </td>
            <td>
                <div style="margin-top: 10px; margin-left: 4px; float: left;">
                    <div style="float: left;">
                        <asp:TextBox ID="txtCallSubjects" runat="server" SkinID="textPad" CssClass="txtbox"
                            Width="178px" Height="21px"> </asp:TextBox>
                    </div>
                    <div id="span_callsubj" style="display: none; width: 16px; float: left; margin-left: 5px;">
                        <div class="RFV_Message" style="border-radius: 2px; float: left;">
                            <span style="float: left; padding-left: 4px">*</span>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div style="float: left; margin-top: 10px; margin-left: 115px;">
                    <asp:Button ID="btnSaveCallSubject" runat="server" CssClass="button" Text="Save"
                        Visible="true" CausesValidation="false" OnClientClick="javascript:ValidateAddCallSubject();return false;"></asp:Button>
                </div>
            </td>
        </tr>
    </table>
</div>
<div id="DivtaskPopUpEdit" style="min-height: 250px; width: 450px; position: absolute; z-index: 9999; opacity: 1; display: none; left: 300px; top: 200px;"
    class="Popupnotes">
    <div style="margin-top: 19px; float: right; margin-right: -34px;">
        <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="false" CssClass="TaskRightArrow"></asp:LinkButton>
    </div>
    <div style="margin-top: -32px; float: right; margin-right: -30px; display: block;">
        <asp:LinkButton ID="lnkEditCloseOA" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:Close_Edit_OpenActivities(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>

    <div id='div_loadingtask_onedit' class="DialogueBackgroundSurveyView" style='display: none;'>
        <div id='div6' style='position: absolute; z-index: 800; top: 40%; left: 45%;'>
            <div id='div7' style='position: absolute; display: block;'>
                <div class='Graphic'>
                    <div style='padding-left: 25px'>
                        <img src="<%=strimgpath%>loading_new.gif" border='0' />
                    </div>
                    <div style='clear: both'></div>
                </div>
            </div>
        </div>
    </div>

    <div id="DivtaskEdit">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: -8px; width: 480px;">
            <tr>
                <td colspan="2">
                    <div align="left" style="margin-top: -11px; margin-bottom: 11px;">
                        <asp:Label ID="Label119" runat="server" Text="Edit Task" CssClass="normalText" Style="font-size: 15px;">
                        <%=objLangClass.GetLanguageConversion("Edit_Task")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin-top: -5px; border-bottom: 1px dashed gray; width: 460px; margin-bottom: 13px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td valign="top" style="width: 239px;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="margin-top: 0px;">
                                    <asp:Label ID="Label12" runat="server" Text="Assigned to" Style="color: #383838;">  <%=objLangClass.GetLanguageConversion("Assigned_To")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlEditassignto" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                                <div id="Span_ddlEditassignto" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 5px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label11" runat="server" Text="Subject" Style="color: #383838;" CssClass="normalText">
                                         <%=objLangClass.GetLanguageConversion("Subject")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="imgeditaddcontact" OnClientClick="javascript:OpenEditSubjectDiv();return false;"
                                        runat="server" ToolTip="Add new subject" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 5px;">
                                    <asp:DropDownList runat="server" ID="ddlEditsubject" CssClass="simpledropdownPopup"
                                        Width="200px" onchange="javascript:Displayclearbutton(); return false;">
                                    </asp:DropDownList>
                                </div>
                                <div id="Span_ddlEditsubject" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 5px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label16" runat="server" Text="Contact" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Contact")%></asp:Label>
                                </div>
                                <div style="float: left; margin-left: 5px; margin-top: 7px; display: none;">
                                    <asp:ImageButton ID="ImageButton7" OnClientClick="javascript:OpenShowContactDiv();return false;"
                                        runat="server" ToolTip="Select Contact" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                </div>
                                <div style="float: left; margin-left: 6px; margin-top: 7px;">
                                    <asp:ImageButton ID="ImageButton8" OnClientClick="javascript:ClearContacts();return false;"
                                        runat="server" ToolTip="Clear contact" CausesValidation="False" ImageUrl="~/images/Clear_sub.png"
                                        Style="height: 15px; width: 16px; display: none;"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlEditContact" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label43" runat="server" Text="Contact" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Contact_Phone")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txt_EditTaskContactPhone" runat="server" Width="200px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 7px; float: left;">
                                    <asp:Label ID="Label44" runat="server" Text="Contact" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Department_Phone")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txt_EditDepartmentPhone" runat="server" Width="200px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top" style="width: 239px;">
                    <table>
                        <tr>
                            <td>
                                <div style="margin-top: -2px;">
                                    <asp:Label ID="Label13" runat="server" Text="Status" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Status")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: -2px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlEditStataus" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                                <div id="span_ddlEditStataus" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: -1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 3px;">
                                    <asp:Label ID="Label14" runat="server" Text="Priority" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Priority")%></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px; float: left;">
                                    <asp:DropDownList runat="server" ID="ddlEditPriority" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                                <div id="span_ddlEditPriority" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 5px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 3px;">
                                    <asp:Label ID="lblEditDueDate" runat="server" Text="Due Date" Style="color: #383838;"></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                    <asp:Label ID="Label152" runat="server" Text="Time (hh:mm)" Style="color: #383838; margin-left: 25px;"></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: -1px; float: left;">
                                    <asp:TextBox ID="txtEditDueDate" runat="server" SkinID="textPad" CssClass="txtbox"
                                        Width="89px"> </asp:TextBox>
                                    <telerik:RadTimePicker ID="RadTimePicker1" runat="server" SkinID="textPad" Height="19px"
                                        Width="110px" ZIndex="30001" inputmode="TimePicker" CssClass="normaltext">
                                        <DateInput ID="DateInput2" runat="server" DateFormat="hh:mm tt" DisplayDateFormat="hh:mm tt">
                                        </DateInput>
                                        <ClientEvents OnDateSelected="DateSelected" />
                                        <TimeView ID="TimeView2" runat="server" TimeFormat="hh:mm tt" Columns="3" OnClientTimeSelected="ClientTimeSelected"
                                            Interval="0:30:0" TimeOverStyle-CssClass="rcHover">
                                        </TimeView>
                                        <Calendar ID="Calendar2" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                        </Calendar>
                                    </telerik:RadTimePicker>
                                    <div style="display: none;">
                                        <asp:DropDownList ID="ddlEdithour" runat="server" CssClass="normaltext" Width="50px"
                                            ToolTip="Hour(s)">
                                        </asp:DropDownList>
                                        :
                                        <asp:DropDownList ID="ddlEditminute" runat="server" CssClass="normaltext" Width="48px"
                                            ToolTip="Minute(s)">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="span_txtEditDueDate" style="display: none; width: 16px; float: left; margin-left: 2px; margin-top: -1px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="span_txtEditDueDate1" style="display: none; width: 196px; float: left; margin-left: 0px; margin-top: 4px; color: Red;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px"></span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 3px;">
                                    <asp:Label ID="Label45" runat="server" Text="Contact Mobile" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Contact_Mobile")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left;">
                                    <asp:TextBox ID="txt_EdirTaskContactMobile" runat="server" Width="200px"></asp:TextBox>
                                </div>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="margin-top: 8px;">
                                    <asp:Label ID="Label42" runat="server" Text="Description" Style="color: #383838;"> <%=objLangClass.GetLanguageConversion("Description")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txtEditTaskDesc" runat="server" SkinID="textPad" CssClass="txtbox"
                                        TextMode="MultiLine" Width="447px" Style="max-width: 447px; max-height: 180px;"> </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr style="display: none;">
                            <td>
                                <div style="margin-top: 13px;" onclick="javascript:SlideLeftDivEditTask('DivtaskEdit'); return false;">
                                    <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label36" runat="server" SkinID="textPad" Width="205px"><%=objLangClass.GetLanguageConversion("More_Fields")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton13" runat="server" CssClass="MorefieldRighrImg" ToolTip="Slide Right"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 10px; display: none;">
                                    <asp:Button ID="btnEditCloseTask" runat="server" CssClass="button" Text="Close" OnClientClick="javascript:Close_Edit_OpenActivities(); return false;"></asp:Button>
                                    <asp:HiddenField ID="hdnTaskID" runat="server" />
                                </div>
                                <div style="float: left; margin-left: 0px; margin-top: 10px;">
                                    <asp:Button ID="btncompletetask" runat="server" CssClass="button" Text="Complete"
                                        CausesValidation="False" Visible="true" OnClientClick="javascript:CompleteTask();return false;"></asp:Button>
                                </div>
                                <div style="float: left; margin-left: 7px; margin-top: 10px;">
                                    <asp:Button ID="btnEditUpdateTask" runat="server" CssClass="button" Text="Update"
                                        CausesValidation="False" Visible="true" OnClientClick="javascript:ValidateUpdateTask();return false;"></asp:Button>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="DivtaskEditSecond" style="position: absolute; width: 99%; right: 0px; display: none;">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 15px;">
            <tr>
                <td>
                    <div style="margin-top: 0px;">
                        <asp:Label ID="Label35" runat="server" Text="More Fields" Style="font-size: 16px;"><%=objLangClass.GetLanguageConversion("More_Fields")%></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 10px; border-bottom: 1px dashed gray; width: 220px; margin-bottom: 10px;">
                        <asp:Label ID="Label40" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 15px;">
                        <asp:Button ID="Button8" runat="server" CssClass="button" Text="Back" CausesValidation="False"
                            Visible="true" OnClientClick="javascript:SlideEditRightDivTask('DivtaskEditSecond'); return false;"></asp:Button>
                    </div>
                    <div style="float: left; margin-left: 7px; margin-top: 15px;">
                        <asp:Button ID="btnEditUpdateTask1" runat="server" CssClass="button" Text="Update"
                            CausesValidation="False" Visible="true" OnClientClick="javascript:ValidateUpdateTaskNew();return false;"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div id="DivEditTaskSubject" style="height: 85px; width: 313px; left: 0%; position: absolute; top: -1%; z-index: 9999; opacity: 1; display: none;"
        class="Popupnotes">
        <div style="margin-top: -32px; float: right; margin-right: -30px;">
            <asp:LinkButton ID="LinkButton11" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
                OnClientClick="javascript:CloseEditTaskPopupAddSubject(); return false;"></asp:LinkButton>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1" style="margin-top: -10px;">
            <tr>
                <td>
                    <asp:Label ID="Label38" runat="server" SkinID="textPad" Width="302px"><%=objLangClass.GetLanguageConversion("Add_New_Subjects")%></asp:Label>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 7px;">
            <tr>
                <td>
                    <div class="bglabel" style="margin-top: 12px; width: 100px;">
                        <asp:Label ID="Label39" runat="server" Text="Subject" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Subject")%></asp:Label>
                        <span class="redver7" style="margin-left: -1px; margin-top: -2px;">*</span>
                    </div>
                </td>
                <td>
                    <div style="margin-top: 10px; margin-left: 4px; float: left;">
                        <div style="float: left;">
                            <asp:TextBox ID="txtEditSubject" runat="server" SkinID="textPad" CssClass="txtbox"
                                Width="178px" Height="21px"> </asp:TextBox>
                        </div>
                        <div id="DivEditSubjectAddValidations" style="display: none; width: 16px; float: left; margin-left: 5px;">
                            <div class="RFV_Message" style="border-radius: 2px; float: left;">
                                <span style="float: left; padding-left: 4px">*</span>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="float: left; margin-top: 10px; margin-left: 115px;">
                        <asp:Button ID="lnlAddSub" runat="server" CssClass="button" Text="Save" Visible="true"
                            CausesValidation="false" OnClientClick="javascript:ValidateEditAddSubject();return false;"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="DivEditCallPopup" style="min-height: 250px; width: 450px; left: 865px; position: absolute; top: 142px; z-index: 9999; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: 19px; float: right; margin-right: -34px;">
        <asp:LinkButton ID="LinkButton18" runat="server" CausesValidation="false" CssClass="TaskRightArrow"></asp:LinkButton>
    </div>
    <div style="margin-top: -32px; float: right; margin-right: -30px; display: block;">
        <asp:LinkButton ID="LinkButton19" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
            OnClientClick="javascript:Close_Edit_CallPopup(); return false;" ToolTip="Close"></asp:LinkButton>
    </div>
    <%--13936 --%>
    <div id='div_loadingcall_onedit' class="DialogueBackgroundSurveyView" style='display: none;'>
        <div id='div_background' style='position: absolute; z-index: 800; top: 40%; left: 45%;'>
            <div id='div_loading' style='position: absolute; display: block;'>
                <div class='Graphic'>
                    <div style='padding-left: 25px'>
                        <img src="<%=strimgpath%>loading_new.gif" border='0' />
                    </div>
                    <div style='clear: both'></div>
                </div>
            </div>
        </div>
    </div>
    <%-- end--%>
    <div id="DivEditCallTimer">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 480px;">
            <tr>
                <td colspan="2">
                    <div align="left" style="margin-top: -11px; margin-bottom: 11px;">
                        <asp:Label ID="Label120" runat="server" Text="Edit Call" CssClass="normalText" Style="font-size: 15px;">
                        <%=objLangClass.GetLanguageConversion("Edit_Call")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="margin-top: -5px; border-bottom: 1px dashed gray; width: 455px; margin-bottom: 13px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 239px;">
                    <table border="0" cellpadding="0" cellspacing="0" style="margin-top: -15px;">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 5px;">
                                    <asp:Label ID="Labsel89" runat="server" Text="Assigned to" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Assigned_To")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlEditowner" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                                <div id="dicEditAssigntoCall" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 5px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; padding-top: 2px;">
                                    <asp:Label ID="Label80" runat="server" Text="Subject" Style="color: #383838;" CssClass="normalText">
                        <%=objLangClass.GetLanguageConversion("Subject")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                                <div style="float: left; margin-left: 6px; padding-top: 2px;">
                                    <asp:ImageButton ID="imgeditcallsubject" OnClientClick="javascript:OpenEditCallSubjectDiv(this.id);return false;"
                                        runat="server" ToolTip="Add new subject" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 5px;">
                                    <asp:DropDownList runat="server" ID="ddlCallSubjectEdit" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                                <div id="span_EditCallSubject" style="display: none; width: 16px; float: left; margin-left: 2px; margin-top: 4px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label107" runat="server" Text="Contact" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Contact")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlEditCallContact" CssClass="simpledropdownPopup"
                                        Width="200px">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label46" runat="server" Text="Contact Phone" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Contact_Phone")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:TextBox ID="txt_EditCallContactPhone" runat="server" Width="200px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label47" runat="server" Text="Department Phone" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Department_Phone")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:TextBox ID="txt_EditCallDepartmentPhone" runat="server" Width="200px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>

                        <tr style="display: none;">
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label104" runat="server" Text="Call Purpose" Style="color: #383838;">
                          <%=objLangClass.GetLanguageConversion("Call_Purpose")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddleditCallPurpose" CssClass="simpledropdownPopup"
                                        AppendDataBoundItems="true" Width="200px">
                                        <asp:ListItem Text="--None--" Value="-1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label105" runat="server" Text="Contact Name" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Contact_Name")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="DropDownList3" CssClass="simpledropdownPopup"
                                        Width="80px">
                                        <asp:ListItem Text="Contact" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Lead" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 5px;">
                                    <asp:TextBox ID="TextBox3" runat="server" SkinID="textPad" CssClass="txtbox" Width="93px"> </asp:TextBox>
                                </div>
                                <div style="float: left; margin-left: 5px; margin-top: 5px;">
                                    <asp:ImageButton ID="ImageButton10" OnClientClick="javascript:OpenShowContactDiv();return false;"
                                        runat="server" ToolTip="Select Contact" CausesValidation="False" ImageUrl="~/images/plus.gif"></asp:ImageButton>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label106" runat="server" Text="Related To" Style="color: #383838;">
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="DropDownList4" CssClass="simpledropdownPopup"
                                        Width="100px">
                                        <asp:ListItem Text="Accounts" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 5px;">
                                    <asp:TextBox ID="TextBox4" runat="server" SkinID="textPad" CssClass="txtbox" Width="93px"> </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 239px; margin-top: -10px; position: absolute;">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 0px;">
                                    <asp:Label ID="Label108" runat="server" Text="Call Details" Style="color: #383838;">
                            <%=objLangClass.GetLanguageConversion("Call_Details")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="display: block;">
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlEditCallDetails" CssClass="simpledropdownPopup"
                                        Width="200px" onchange="Javascript:ShowEditCallDetailType(); return false;">
                                        <asp:ListItem Text="Completed Call" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Scheduled Call" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="DivEditCallStartTime">
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label109" runat="server" Text="Call Start Date" Style="color: #383838;">
                         <%=objLangClass.GetLanguageConversion("Call_Start_date")%>
                                    </asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                    <asp:Label ID="Label102" runat="server" Text="Time (hh:mm)" Style="color: #383838; margin-left: 5px;"></asp:Label>
                                    <span class="redver7" style="margin-left: -1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="DivEditCallStartTime1">
                                <div style="float: left; margin-top: 4px;">
                                    <asp:TextBox ID="txtEditCallStartdate" runat="server" SkinID="textPad" CssClass="txtbox"
                                        Width="87px"> </asp:TextBox>
                                </div>
                                <div style="float: left; margin-top: 2px; margin-left: 2px;">
                                    <div style="float: left; padding-left: 5px;">
                                        <telerik:RadTimePicker ID="RadTimePicker5" runat="server" SkinID="textPad" Height="19px"
                                            Width="104px" ZIndex="30001" inputmode="TimePicker" CssClass="normaltext">
                                            <DateInput ID="DateInput6" runat="server" DateFormat="hh:mm tt" DisplayDateFormat="hh:mm tt">
                                            </DateInput>
                                            <ClientEvents OnDateSelected="DateSelected" />
                                            <TimeView ID="TimeView6" runat="server" TimeFormat="hh:mm tt" Columns="3" OnClientTimeSelected="ClientTimeSelected"
                                                Interval="0:30:0" TimeOverStyle-CssClass="rcHover">
                                            </TimeView>
                                            <Calendar ID="Calendar6" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                                UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                            </Calendar>
                                        </telerik:RadTimePicker>
                                    </div>
                                    <div style="float: left; padding-left: 5px; display: none;">
                                        <asp:DropDownList ID="ddleditCallHours" CssClass="normaltext" runat="server" Width="41px">
                                        </asp:DropDownList>
                                        :
                                        <asp:DropDownList ID="ddleditCallSecond" CssClass="normaltext" runat="server" Width="41px">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlEditCallTime" CssClass="simpledropdownPopup"
                                        Width="95px" Visible="false">
                                        <asp:ListItem Text="12:00 AM" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="span_EditCallStartdate" style="display: none; width: 16px; float: left; margin-left: 0px; margin-top: 4px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="span_EditCallStartdate1" style="display: none; width: 196px; float: left; margin-left: 0px; margin-top: 4px; color: Red;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px"></span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td id="DivEditCallDuration" style="float: left;">
                                <div style="float: left; margin-top: 8px;">
                                    <asp:Label ID="Label110" runat="server" Text="Call Duration" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Call_Duration")%>
                                    </asp:Label>
                                </div>
                                <div id="EditDurationStar" style="float: left; margin-top: 9px;">
                                    <span class="redver7" style="margin-left: 1px;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td id="DivEditCallDuration1">
                                <div style="float: left; margin-top: 4px;">
                                    <asp:TextBox ID="txtEditCallMin" runat="server" SkinID="textPad" CssClass="txtbox"
                                        Width="48px" MaxLength="2" onkeypress="return validateNumberOnly(event);"> </asp:TextBox>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 4px;">
                                    <asp:Label ID="Label111" runat="server" Text="minutes" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("minutes")%>
                                    </asp:Label>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 5px;">
                                    <asp:TextBox ID="txtEditCallSec" runat="server" SkinID="textPad" MaxLength="2" CssClass="txtbox"
                                        Width="47px" onkeypress="return validateNumberOnly(event);"> </asp:TextBox>
                                </div>
                                <div style="float: left; margin-top: 4px; margin-left: 4px;">
                                    <asp:Label ID="Label112" runat="server" Text="seconds" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("seconds")%>
                                    </asp:Label>
                                </div>
                                <div id="span_EditMinuteSecond" style="display: none; width: 16px; float: left; margin-left: 5px; margin-top: 4px;">
                                    <div class="RFV_Message" style="border-radius: 2px;">
                                        <span style="float: left; padding-left: 4px">*</span>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label103" runat="server" Text="Call type" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Call_Type")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:DropDownList runat="server" ID="ddlEditCallType" CssClass="simpledropdownPopup"
                                        Width="200px">
                                        <asp:ListItem Text="Inbound" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Outbound" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label48" runat="server" Text="Contact Mobile" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Contact_Mobile")%>
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                    <asp:TextBox ID="txt_EditCallContactMobile" runat="server" Width="200"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 7px;">
                                    <asp:Label ID="Label151" runat="server" Text="" Style="color: #383838;">
                      
                                    </asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 4px;">
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td colspan="2">
                                <div style="margin-top: 13px;" onclick="javascript:SlideLeftEditCallDiv('DivEditCallTimer'); return false;">
                                    <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label116" runat="server" SkinID="textPad" Width="210px"><%=objLangClass.GetLanguageConversion("More_Fields")%></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinkButton20" runat="server" CssClass="MorefieldRighrImg" ToolTip="Slide Right"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="margin-top: 5px;">
                                    <asp:Label ID="Labesl90" runat="server" Text="Notes" Style="color: #383838;"><%=objLangClass.GetLanguageConversion("Description")%></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="margin-top: 4px;">
                                    <asp:TextBox ID="txtEditCallDesc" runat="server" SkinID="textPad" CssClass="txtbox"
                                        TextMode="MultiLine" Width="440px" Style="max-width: 440px; max-height: 200px;"> </asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div style="float: left; margin-top: 10px; display: none;">
                                    <asp:Button ID="Button18" runat="server" CssClass="button" Text="Close" OnClientClick="javascript:Close_Edit_CallPopup(); return false;"></asp:Button>
                                </div>
                                <div style="float: left; margin-left: 0px; margin-top: 10px;">
                                    <asp:Button ID="btncompletecall" runat="server" CssClass="button" Text="Complete"
                                        CausesValidation="False" Visible="true" OnClientClick="javascript:CompleteCall();return false;"></asp:Button>
                                </div>
                                <div style="float: left; margin-left: 7px; margin-top: 10px;">
                                    <asp:Button ID="btnUpdateEditcall" runat="server" CssClass="button" Text="Update"
                                        CausesValidation="False" Visible="true" OnClientClick="javascript:UpdateCallValidations(); return false;"></asp:Button>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div id="DivEditCallTimerSecond" style="display: none;">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <div style="margin-top: 0px;">
                        <asp:Label ID="Label114" runat="server" Text="More Fields" Style="font-size: 16px;"> <%=objLangClass.GetLanguageConversion("More_Fields")%></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 10px; border-bottom: 1px dashed gray; width: 230px; margin-bottom: 10px;">
                        <asp:Label ID="Label115" runat="server" Text="" Style="font-size: 16px;"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <div style="float: left; margin-top: 5px;">
                        <asp:Label ID="Label828" runat="server" Text="Call Result" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Call_Result")%>
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <div style="float: left; margin-top: 5px;">
                        <asp:TextBox ID="txtEditcallressult" runat="server" SkinID="textPad" CssClass="txtbox"
                            Width="200px"> </asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <div style="margin-top: 5px;">
                        <asp:CheckBox ID="ChkEditBillable" runat="server" Text="Billable" Style="color: #383838;" />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 15px;">
                        <asp:Button ID="bynBacksCallPopup" runat="server" CssClass="button" Text="Back" CausesValidation="False"
                            Visible="true" OnClientClick="javascript:SlideRightEditCallDiv('DivEditCallTimerSecond'); return false;"></asp:Button>
                    </div>
                    <div style="float: left; margin-left: 7px; margin-top: 15px;">
                        <asp:Button ID="btnUpdateEditcall1" runat="server" CssClass="button" Text="Update"
                            CausesValidation="False" Visible="true" OnClientClick="javascript:UpdateCallValidationsNew(); return false;"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="DivOpenContact" style="height: 407px; width: 703px; left: 250px; position: absolute; top: 100px; z-index: 9999999999; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="lnkCloseContactPopup" runat="server" CausesValidation="false"
            CssClass="TaskClosePopup" OnClientClick="javascript:CloseContactPopup(); return false;"></asp:LinkButton>
    </div>
    <div>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="0" cellspacing="0" class="newNavNext1" style="margin-top: -10px; margin-bottom: 8px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label93" runat="server" SkinID="textPad" Width="687px" Style="font-weight: bold;">Select Contact</asp:Label>
                        </td>
                    </tr>
                </table>
                <telerik:RadGrid ID="RadGridContact" runat="server" ShowStatusBar="true" Width="99%"
                    FilterItemStyle-Wrap="true" PagerStyle-CssClass="RadComboBox_Eprint_Skin" PageSize="25"
                    AllowPaging="True" AutoGenerateColumns="False" AllowFilteringByColumn="true"
                    PagerStyle-Visible="true" HeaderStyle-Font-Bold="true" HeaderStyle-Height="20px"
                    OnItemDataBound="GridView2_OnRowDataBound" GroupingSettings-CaseSensitive="false">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                    <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                    <MasterTableView OverrideDataSourceControlSorting="true" PagerStyle-AlwaysVisible="true">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Contact Name" ItemStyle-HorizontalAlign="Left"
                                AllowFiltering="true" DataField="contactname" SortExpression="contactname" UniqueName="contactname"
                                FilterControlWidth="150" ItemStyle-Wrap="false" AutoPostBackOnFilter="true">
                                <HeaderStyle HorizontalAlign="left" Wrap="false" Width="50%" />
                                <ItemStyle HorizontalAlign="left" Width="25%" Height="15%" />
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ContactName" runat="server"></asp:Label>
                                    <div style="float: left; width: 99%; overflow: hidden">
                                        <asp:HiddenField ID="hdnFirstLastName" Value='<%#Eval("FirstName")%>' runat="server" />
                                        <asp:HiddenField ID="hdnLastName" Value='<%#Eval("LastName")%>' runat="server" />
                                        <asp:HiddenField ID="hdnContactID" Value='<%#Eval("contactid")%>' runat="server" />
                                        <a id="Contacts" runat="server" class="normaltext" style="cursor: pointer;">
                                            <%#Eval("FirstName")%>
                                            <%#Eval("LastName")%>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Left" AllowFiltering="true"
                                CurrentFilterFunction="Contains" DataField="Email" FilterControlWidth="150" ItemStyle-Wrap="false"
                                UniqueName="Email" SortExpression="Email" HeaderText="Email" AutoPostBackOnFilter="true">
                                <HeaderStyle HorizontalAlign="left" Wrap="false" Width="50%" />
                                <ItemStyle HorizontalAlign="left" Width="25%" Height="15%" />
                                <ItemTemplate>
                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                        <asp:Label ID="lbl_Email" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Email", "{0}") %>' ToolTip='<%# DataBinder.Eval(Container, "DataItem.Email", "{0}") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                        AllowDragToGroup="false" Scrolling-AllowScroll="true">
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                        <Scrolling UseStaticHeaders="true" ScrollHeight="340" SaveScrollPosition="true" />
                    </ClientSettings>
                </telerik:RadGrid>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
<div id="DivAddNotePopup" style="min-height: 230px; height: auto; width: 355px; position: absolute; z-index: 9999; opacity: 1; display: none;"
    class="Popupnotes">
    <div style="margin-top: -32px; float: right; margin-right: -30px;">
        <asp:LinkButton ID="lnlcloseAddnotepopup" runat="server" CausesValidation="false"
            CssClass="TaskClosePopup" OnClientClick="javascript:CloseAddNotePopup(); return false;"
            ToolTip="Close"></asp:LinkButton>
    </div>
    <div id="rgarrow" style="margin-top: 19px; float: right; margin-right: -34px;">
        <asp:LinkButton ID="LinkButton24" runat="server" CausesValidation="false" CssClass="TaskRightArrow"></asp:LinkButton>
    </div>
    <div id="lftarrow" style="margin-top: 19px; float: left; margin-left: -34px;">
        <asp:LinkButton ID="LinkButton23" runat="server" CausesValidation="false" CssClass="TaskLeftArrow"></asp:LinkButton>
    </div>
    <div id="Div12">
        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: -8px; width: 305px;">
            <tr style="display: none;">
                <td id="DivFileUpload1" style="display: none;">
                    <div style="margin-left: 7px; margin-bottom: 7px; margin-top: 4px;">
                        <asp:FileUpload ID="NotesFileUpload" size="30" runat="server" />
                    </div>
                    <div style="margin-left: 7px; margin-top: 4px; height: 20px;">
                        <asp:Label ID="lblvalidatetoploadfile" runat="server" Text="(Do not upload exe, asp, aspx, dll, jar, .bmp types of files)"
                            Style="color: Gray; font-size: 10px;"></asp:Label>
                    </div>
                </td>
                <td id="divNoteTitle" style="display: none;">
                    <div style="margin-left: 7px; margin-bottom: 7px; margin-top: 4px;">
                        <asp:TextBox ID="TextBox2" runat="server" Width="486px" onfocus="this.select();"
                            TabIndex="541"></asp:TextBox>
                    </div>
                    <div id="DivCloseNoteTitle" style="float: left; display: none;">
                        <asp:LinkButton ID="LinkButton8" runat="server" ToolTip="Hide" CssClass="HideNotesFields"
                            OnClientClick="javascript:CloseNoteTitle(); return false;" Visible="false"></asp:LinkButton>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="left" style="margin-top: -11px; margin-bottom: 11px;">
                        <asp:Label ID="lblAddNoteTitle" runat="server" Text="" CssClass="normalText" Style="font-size: 15px;">                       
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: -5px; border-bottom: 1px dashed gray; width: 365px; margin-bottom: 13px;">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left;">
                        <asp:Label ID="Label136" runat="server" Text="Note Title" CssClass="normalText" Style="color: #383838;">   
                        <%=objLangClass.GetLanguageConversion("Note_Title")%>                   
                        </asp:Label>
                        <span class="redver7" style="margin-left: -1px;">*</span>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left; margin-top: 5px;">
                        <asp:TextBox ID="txtnoteTitle" runat="server" Width="365px" CssClass="textboxnew"></asp:TextBox>
                    </div>
                </td>
                <td style="vertical-align: top;">
                    <div id="divnotescontentvalidate" style="display: none; float: left; margin-top: 4px; margin-left: -37px;">
                        <div class="RFV_Message" style="border-radius: 2px; float: left; margin-bottom: 2px;">
                            <span id="ErrorlblNote" style="float: left; padding-left: 4px; font-weight: normal;">*</span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 7px;">
                        <asp:Label ID="Label137" runat="server" Text="Note Content" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Note_Content")%>         
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px; float: left;">
                        <asp:TextBox ID="txtNoteDesc" runat="server" CssClass="textboxnew" TextMode="MultiLine"
                            Height="150px" Width="365px" Style="max-width: 365px; max-height: 250px;"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 7px;">
                        <asp:Label ID="Label138" runat="server" Text="Specific to Contact" Style="color: #383838;">
                        <%=objLangClass.GetLanguageConversion("Specific_to_Contact")%>  
                        </asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-top: 4px; float: left;">
                        <asp:DropDownList runat="server" ID="ddlspecificTo" CssClass="simpledropdownPopup"
                            Width="365px" AppendDataBoundItems="true">
                            <asp:ListItem Text="--Select--" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="margin-left: 7px; margin-bottom: 3px; margin-top: 7px; float: left; display: none;">
                        <div style="float: left; width: 467px; float: left;">
                            <div style="float: left;">
                                <asp:LinkButton ID="lnkUoloadFile" runat="server" Text="Upload File" Style="font-size: 12px; color: black;"
                                    CssClass="NotesSummText" OnClientClick="javascript:OpenBrowseFile(); return false;"></asp:LinkButton>
                            </div>
                            <div id="diverrorNotesFileUpload" style="display: none; float: left; margin-left: 5px; margin-top: -2px; max-width: 350px;">
                                <div class="RFV_Message" style="border-radius: 2px; float: left;">
                                    <span id="SapnNotesFileUpload" style="float: left; padding-left: 4px; font-weight: normal;">
                                        <%=objLangClass.GetLanguageConversion("Please_Enter_Note")%></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="DivUploFile" style="margin-left: 0px; margin-top: 7px; float: left;">
                        <a style="font-size: 12px; color: #383838;" class="NotesSummText" tabindex="542"><%--href="javascript:ShowAddFiles()--%>
                            <%=objLangClass.GetLanguageConversion("Upload_File")%></a></p>
                    </div>
                    <div id="DivCloseBrowseFile" style="float: left; display: none; margin-top: 5px; margin-left: 405px;">
                        <asp:LinkButton ID="LinkButton9" runat="server" ToolTip="Hide" CssClass="HideNotesFields"
                            OnClientClick="javascript:CloseBrowseFile(); return false;" Visible="false"></asp:LinkButton>
                    </div>
                    <input type="hidden" id="hdnFileselected" />
                    <div id="addfileDiv" style="float: left; width: 235px; margin-bottom: 15px; height: auto; overflow: hidden; margin-top: -12px;">
                        <input type="text" name="txtfilename" id="txtfilename" style="display: none;" />
                        <div style="padding-left: 0px; float: left; height: auto;">
                            <div>
                                <asp:FileUpload ID="file_upload" runat="server" CssClass="uploadfiles" Width="218px" />
                            </div>
                        </div>
                        <div style="padding-left: 20px; margin-top: 10px; float: left; display: none;">
                            <a href="javascript:OnClickCall();" style="color: Gray; font-size: 11px; font-weight: bold">Start Upload</a>&nbsp; |&nbsp;<a href="javascript:$('#file_upload').fileUploadClearQueue()"
                                style="color: Gray; font-size: 11px; font-weight: bold">Clear</a>
                        </div>
                        <div id="queue">
                        </div>
                    </div>
                    <div id="divUpload" style="display: none; margin-top: 40px; z-index: 999999;">
                        <div style="width: 280pt; text-align: center;">
                            Uploading...
                        </div>
                        <div style="width: 280pt; height: 10px; border: solid 1pt gray">
                            <div id="divProgress" runat="server" style="width: 1pt; height: 10px; background-color: Green; display: none">
                            </div>
                        </div>
                        <div style="width: 300pt; text-align: center;">
                            <asp:Label ID="lblPercentage" runat="server" Text="Label"></asp:Label>
                        </div>
                        <br />
                        <asp:Label ID="Label159" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div id="DivOldFile" style="padding-left: 2px; margin-top: 5px; float: left; display: none; margin-bottom: 8px;">
                        <div style="float: left;">
                            <asp:Label ID="lblOldFile" runat="server" Style="text-decoration: underline; color: #10357F; cursor: pointer;"></asp:Label>
                            <asp:Label ID="lblOldFileSize" runat="server" Style="display: none;"></asp:Label>
                        </div>
                        <div style="float: left; margin-left: 5px;">
                            <asp:LinkButton ID="lnkRemoveOldFile" runat="server" CausesValidation="false" CssClass="HideNotesFields"
                                OnClientClick="javascript:DeleteOldFile(); return false;" ToolTip="Delete old File"></asp:LinkButton>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="float: left;">
                        <div id="DivBtnNotesSave" style="float: left; margin-left: 0px;">
                            <asp:Button ID="BtnNotesSave" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                OnClientClick="javascript:return ValidateNotesFields();"></asp:Button>
                            <div id="div_loading_BtnNotesSave" style="display: none; width: 46px; padding-bottom: 2px; padding-top: 2px; border: solid 1px #a3a3a3; border-radius: .5em; text-align: center; background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));">
                                <image src="../images/radimg1.gif" alt="loading" class="loadingimg"></image>
                            </div>
                        </div>
                    </div>
                    <div id="DivBtnUpdateNotes" style="margin-left: 0px; margin-bottom: 0px; float: left; margin-top: 0px; display: none;">
                        <asp:Button ID="btnUpdateNotes" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                            OnClientClick="javascript:return UpdateValidateNotesFields();"></asp:Button>
                    </div>
                    <div id="DivBtnUpdateAllNotes" style="margin-left: 0px; margin-bottom: 0px; float: left; margin-top: 0px; display: none;">
                        <asp:Button ID="btnUpdateAllNotes" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                            OnClientClick="javascript:return UpdateValidateAllNotesFields();"></asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</div>

<div style="clear: both;">
</div>
<table id="tablemainpanel" runat="server" border="0" cellpadding="0" cellspacing="0"
    class="eprint-crm-customer eprint-crm-layout-v2" style="border: 0;">
    <tr valign="top" class="eprint-crm-layout-row">
        <td id="DivLeftPanel" width="0" runat="server" class="eprint-crm-context-nav-legacy" style="display: none;">
            <asp:HiddenField ID="ddnAttachID" runat="server" />
            <div style="position: fixed; top: 400px; display: none;">
                <asp:Button ID="btnScroll" runat="server" Text="Scroll" />
            </div>
        </td>
        <td id="DivRightPanel" runat="server" class="eprint-crm-main-panel"><%--Now This is Right Panel Ticket Id:11086--%>
            <div class="eprint-crm-content-card" style="width: 100%; min-height: 470px;">
                <div id="DivButtonsHeader" runat="server"
                    class="DivButtonsHeader eprint-crm-sticky-header">
                    <div class="eprint-crm-header-top">
                        <div id="Div14" runat="server" class="eprint-crm-header-title">
                            <asp:Label ID="lbltitlecompanyname" runat="server"></asp:Label>
                            <span class="eprint-crm-title-sep" aria-hidden="true">·</span>
                            <asp:Label ID="PanelName" CssClass="eprint-crm-section-label" runat="server"></asp:Label>
                        </div>
                        <div class="eprint-crm-header-badges">
                            <span class="eprint-crm-type-badge"><%=CompanyType %></span>
                            <div class="eprint-crm-record-nav">
                                <div id="DivlnkPreviousPage" runat="server" style="display: none;">
                                    <asp:ImageButton ID="lnkPreviousPage" runat="server" ImageUrl="~/images/btn_left.png"
                                        ToolTip="Previous Record" OnClick="lnkPreviousClientRecord_Click" />
                                </div>
                                <div id="DivlnkNextClientRecord" runat="server" style="display: none;">
                                    <asp:ImageButton ID="lnkNextClientRecord" runat="server" ImageUrl="~/images/btn_rgt.png"
                                        ToolTip="Next Record" OnClick="lnkNextClientRecord_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <nav class="eprint-crm-nav eprint-crm-nav-top" aria-label="Customer sections">
                        <div class="eprint-crm-nav-item" data-crm-nav="client">
                            <asp:LinkButton ID="LnkSummary" runat="server" Text="Summary Information" CssClass="moreaction eprint-crm-nav-link" OnClick="LnkSummary_Click" OnClientClick="crmUpdateSummaryBreadcrumb(); if(document.getElementById('DivEditCallPopup')){document.getElementById('DivEditCallPopup').style.display='none';} if(document.getElementById('DivAddNotePopup')){document.getElementById('DivAddNotePopup').style.display='none';} if(typeof crmtooltip==='function'){crmtooltip();} return crmPrepareTab('client', 'Summary Information', true);"></asp:LinkButton>
                        </div>
                        <div class="eprint-crm-nav-item" data-crm-nav="dept">
                            <asp:LinkButton ID="lnkDepartment" runat="server" Text="Departments" CssClass="moreaction eprint-crm-nav-link" OnClick="lnk_DeptTab_Click" OnClientClick="return crmPrepareTab('dept', 'Departments', true);"></asp:LinkButton>
                        </div>
                        <div id="DivlnlCostCentre" runat="server" class="eprint-crm-nav-item" data-crm-nav="costcentre" style="display: none;">
                            <asp:LinkButton ID="lnlCostCentre" runat="server" Text="Cost Centres" CssClass="moreaction eprint-crm-nav-link" OnClick="lnk_CostCenterTab_Click" OnClientClick="return crmPrepareTab('costcentre', 'Cost Centres', true);"></asp:LinkButton>
                        </div>
                        <div class="eprint-crm-nav-item" data-crm-nav="contacts">
                            <asp:LinkButton ID="lnkContact" runat="server" Text="Contacts" CssClass="moreaction eprint-crm-nav-link" OnClick="lnk_ContactTab_Click" OnClientClick="return crmPrepareTab('contacts', 'Contacts', true);"></asp:LinkButton>
                        </div>
                        <div class="eprint-crm-nav-item" data-crm-nav="address">
                            <asp:LinkButton ID="lnkAddressBook" runat="server" Text="Address Book" CssClass="moreaction eprint-crm-nav-link" OnClick="lnkAddressBook_Click" OnClientClick="crmUpdateAddressBreadcrumb(); if(document.getElementById('DivEditCallPopup')){document.getElementById('DivEditCallPopup').style.display='none';} if(document.getElementById('DivAddNotePopup')){document.getElementById('DivAddNotePopup').style.display='none';} return crmPrepareTab('address', 'Address Book', true);"></asp:LinkButton>
                        </div>
                        <div id="divlnkEstore" runat="server" class="eprint-crm-nav-item" data-crm-nav="estore">
                            <asp:LinkButton ID="lnkEstore" runat="server" Text="eStore" CssClass="moreaction eprint-crm-nav-link" OnClick="lnk_b2bTab_Click" OnClientClick="return crmPrepareTab('b2b', 'eStore', true);"></asp:LinkButton>
                        </div>
                        <div id="DivlnlProducts" runat="server" class="eprint-crm-nav-item" data-crm-nav="products">
                            <asp:LinkButton ID="lnlProducts" runat="server" Text="Products" CssClass="moreaction eprint-crm-nav-link" OnClick="lnk_ProductsTab_Click" OnClientClick="return crmPrepareTab('products', 'Products', true);"></asp:LinkButton>
                        </div>
                        <div id="DivlnkEmail" runat="server" class="eprint-crm-nav-item" data-crm-nav="emails">
                            <asp:LinkButton ID="lnkEmail" runat="server" Text="Emails" CssClass="moreaction eprint-crm-nav-link" OnClick="lnk_EmailsTab_Click" OnClientClick="return crmPrepareTab('emails', 'Emails', true);"></asp:LinkButton>
                        </div>
                        <div id="DivlnkRecords" runat="server" class="eprint-crm-nav-item" data-crm-nav="records">
                            <asp:LinkButton ID="lnkRecords" runat="server" Text="Records" CssClass="moreaction eprint-crm-nav-link" OnClick="lnk_ActivitiesTab_Click" OnClientClick="return crmPrepareTab('activities', 'Records', true);"></asp:LinkButton>
                        </div>
                    </nav>
                    <div class="eprint-crm-header-toolbar">
                    <div style="margin-left: 10px; float: left; margin-top: 5px; display: none;">
                        <asp:Button ID="btnCancel" runat="server" Text="Back" OnClick="btnCancel_OnClick"
                            CssClass="headerbutton white"></asp:Button>
                    </div>

                    <div id="converttocust" runat="server" style="float: left; margin-left: 7px; margin-top: 5px;">
                        <div id="div_convertcust" style="display: block">
                            <asp:Button ID="btnConvertToCstmr" runat="server" Text="Progress to Customer" OnClick="btnConvertToCstmr_Click"
                                CssClass="headerbutton white"></asp:Button>
                        </div>
                    </div>
                    <div id="Div9" runat="server" class="eprint-crm-print-options-wrap" style="float: right; margin-right: 10px; margin-top: 5px; position: relative;">
                        <asp:Button ID="Button1" runat="server" Text="Print Options" CssClass="moreoptions white"
                            Width="120px" onmouseover="javascript:ShowPrintMoreActions(); return false;"
                            onmouseout="javascript:HidePrintMoreActions(); return false;" OnClientClick="javascript:return false;"
                            Style="background: url(../images/down_arrow.png) 95% no-repeat;"></asp:Button>
                        <div id="DivPrintOptions" runat="server" class="ddM3 eprint-crm-print-options-menu" style="display: none; position: absolute; top: 100%; right: 0; z-index: 120; height: auto; width: 230px; margin-top: 4px;"
                            onmouseover="javascript:ShowPrintMoreActions(); return false;" onmouseout="javascript:HidePrintMoreActions(); return false;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="moreactionpanel" style="width: 250px;">
                                        <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                                            <asp:LinkButton ID="lnlCustomerInfoWithAddress" runat="server" Text="Customer Info and Address"
                                                OnClientClick="javascript:PrintCustomerInfoandAddress(); return false;" Style="color: #000000;"
                                                CssClass="moreaction"></asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="moreactionpanel" style="width: 250px;">
                                        <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                                            <asp:LinkButton ID="lnlCustomerInfowithDepartment" runat="server" Text="Customer Info with Department"
                                                OnClientClick="javascript:PrintCustomerInfowithDepartment(); return false;" Style="color: #000000;"
                                                CssClass="moreaction"></asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="moreactionpanel" style="width: 250px;">
                                        <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                                            <asp:LinkButton ID="lnkMap" runat="server" Text="Customer Name with Location Map"
                                                OnClientClick="javascript:PrintCustomerNamwithLocationMap(); return false;" Style="color: #000000;"
                                                CssClass="moreaction"></asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="moreactionpanel" style="width: 250px;">
                                        <div style="margin-left: 6px; margin-top: 5px; margin-bottom: 6px;">
                                            <asp:LinkButton ID="lnlAllNotes" runat="server" Text="Customer Info with all Notes"
                                                OnClientClick="javascript:CustomerInfowithallNotes(); return false;" Style="color: #000000;"
                                                CssClass="moreaction"></asp:LinkButton>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div id="div_DeptControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:UpdatePanel ID="UpdatePanel2" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btn_AddNewDepartment" runat="server" Text="Add New Department" CssClass="headerbutton white" />
                                <asp:Button ID="btn_ClearFilters_Dept" runat="server" Text="Clear All Filters" ToolTip="Clear All Filters" OnClick="clrFiltersDept_Click"
                                    CssClass="headerbutton white" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="div_ContactControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:UpdatePanel ID="UpdatePanel10" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btn_AddNewContact" runat="server" Text="Add New Contact" CssClass="headerbutton white" />
                                <asp:Button ID="btn_ClearFilter_Contact" runat="server" Text="Clear All Filters" ToolTip="Clear All Filters" OnClick="clrFilters_Click"
                                    CssClass="headerbutton white" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="div_CostcenterControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:UpdatePanel ID="UpdatePanel8" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btn_AddNewCostCenter" runat="server" Text="Add New Cost Centre" CssClass="headerbutton white" />
                                <asp:Button ID="btn_ClearFilter_Costcenter" runat="server" Text="Clear All Filters" ToolTip="Clear All Filters" OnClick="lnlClerCostFilter_Click"
                                    CssClass="headerbutton white" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="div_AddressControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:UpdatePanel ID="UpdatePanel9" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btn_AddNewAddress" runat="server" Text="Add New Address" CssClass="headerbutton white" />
                                <asp:Button ID="btn_ClearFilter_Address" runat="server" Text="Clear All Filters" ToolTip="Clear All Filters" OnClick="clrFiltersAddress_Click"
                                    CssClass="headerbutton white" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="div_ProductsControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:Button ID="btn_AddNewProduct" runat="server" Text="Add New Product" CssClass="headerbutton white" />
                        <asp:Button ID="btn_ClearFilter_Product" runat="server" Text="Clear All Filters" ToolTip="Clear All Filters" OnClientClick="javascript:clearfilter_product();return false;"
                            CssClass="headerbutton white" />
                    </div>
                    <div id="div_EmailControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:Button ID="btn_AddNewEmail" runat="server" Text="Add New Email" CssClass="headerbutton white" />
                        <asp:Button ID="btn_ClearFilterEmail" runat="server" Text="Clear All Filters" ToolTip="Clear All Filters" CssClass="headerbutton white"
                            OnClientClick="javascript:clearfilter_email();return false;" />
                    </div>
                    <div id="div_EstimateControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:Button ID="btn_ClearFilter_Estimaterecords" runat="server" Text="Clear All Filters" ToolTip="Clear All Filters" CssClass="headerbutton white"
                            OnClientClick="javascript: clearfilter_Estimaterecord(); return false;" />
                    </div>
                    <div id="div_JobControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:Button ID="btn_ClearFilter_Jobrecords" runat="server" Text="Clear all filters" CssClass="headerbutton white"
                            OnClientClick="javascript: clearfilter_Jobrecord(); return false;" />
                    </div>
                    <div id="div_InvoiceControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:Button ID="btn_ClearFilter_Invoicerecords" runat="server" Text="Clear all filters" CssClass="headerbutton white"
                            OnClientClick="javascript: clearfilter_Invoicerecord(); return false;" />
                    </div>
                    <div id="div_eStoreControls" runat="server" style="float: right; margin-right: 10px; margin-top: 5px; display: none;">
                        <asp:Button ID="btn_ClearFilter_eStorerecords" runat="server" Text="Clear all filters" CssClass="headerbutton white"
                            OnClientClick="javascript: clearfilter_eStorerecord(); return false;" />
                    </div>
                    <div id="DivsearchButton" runat="server" style="float: right; margin-right: 10px; margin-left: 7px; margin-top: 5px;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="headerbutton white"
                            OnClientClick="javascript:OpenSearchPanel(); return false;" Style="cursor: pointer;"></asp:Button>
                    </div>
                    <div id="divbtndelete" runat="server" style="float: right; margin-left: 7px; margin-top: 5px;">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_OnClick" CssClass="headerbutton white"
                            OnClientClick="javascript:var a=forDeleteforCRM(CompanyType);if(a)loadingimage(this.id,'div_btndeleteprocess');return a;"></asp:Button>
                    </div>
                    <div id="divbtnedit" runat="server" style="float: right; margin-left: 7px; margin-top: 5px;">
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_OnClick" CssClass="headerbutton white" OnClientClick="javascript: return loadingimage(this.id,'div_btnEdit');"></asp:Button>
                        <div id="div_btnEdit" style="display: none">
                            <img src="<%=strimgpath %>radimg1.gif" alt="loading" border="0" />
                        </div>
                    </div>
                    </div>
                </div>
                <div id="div_ClientMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="client" style="width: 100%; display: block; height: 100%; min-height: 445px;">
                    <div class="eprint-crm-section-pilot">
                        <div class="eprint-crm-section-hero">
                            <div class="eprint-crm-section-hero-main">
                                <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Summary_Information")%></h2>
                                <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                            </div>
                            <div class="eprint-crm-section-hero-stats eprint-crm-section-hero-stats--text">
                                <span class="eprint-crm-section-count"><%=objLangClass.GetLanguageConversion("Account")%></span>
                                <span class="eprint-crm-section-count-label"><%=objLangClass.GetLanguageConversion("Details")%></span>
                            </div>
                        </div>
                        <div class="eprint-crm-section-toolbar">
                            <div class="eprint-crm-section-search-wrap">
                                <label class="eprint-crm-sr-only" for="eprintCrmSectionSearch_client">Search summary</label>
                                <input type="search" id="eprintCrmSectionSearch_client" class="eprint-crm-section-search" data-crm-section="client"
                                    placeholder="Search summary fields…" autocomplete="off" />
                            </div>
                        </div>
                        <div class="eprint-crm-section-body-card eprint-crm-section-body-card--form">
                            <div class="eprint-crm-section-form-inner">
                    <asp:UpdatePanel ID="up_CleintInfo" runat="server">
                        <ContentTemplate>
                            <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                                <div style="width: 60%; margin: 5px 0px 0px 5px">
                                    <asp:PlaceHolder ID="plhClient" runat="server"></asp:PlaceHolder>
                                </div>
                            </div>
                            <asp:HiddenField ID="hid_ClientID" runat="server" />
                            <div id="SearchPanel" style="display: none;" align="center">
                                <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px; margin-left: 12px; margin-bottom: 10px;">
                                    <tr>
                                        <td>
                                            <div style="margin-left: 0px; border: 1px solid #B2B2B2; height: 110px; width: 650px; border-radius: 3px; box-shadow: 3px 3px 5px #888;">
                                                <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 10px; margin-top: 5px;">
                                                    <tr>
                                                        <td>
                                                            <div style="margin-top: 5px;">
                                                                <asp:Label ID="Label55" runat="server" Style="color: #383838;">
                                                                         <%=objLangClass.GetLanguageConversion("Free_Text")%>
                                                                </asp:Label>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 5px; margin-left: 10px;">
                                                                <asp:Label ID="Label139" runat="server" Text="Start Date" Style="color: #383838;">
                                                                    <%=objLangClass.GetLanguageConversion("Start_Date")%>
                                                                </asp:Label>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 5px; margin-left: 10px;">
                                                                <asp:Label ID="Label140" runat="server" Text="End Date" Style="color: #383838;">
                                                                    <%=objLangClass.GetLanguageConversion("End_Date")%>
                                                                </asp:Label>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 10px; margin-left: 10px;">
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 10px; margin-left: 10px;">
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div style="margin-top: 4px;">
                                                                <asp:TextBox ID="txtallsearchcontant" runat="server" SkinID="textPad" CssClass="txtbox"
                                                                    Width="240px"> </asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 4px; margin-left: 10px;">
                                                                <asp:TextBox ID="txtsearchstartdate" runat="server" SkinID="textPad" CssClass="txtbox"
                                                                    Width="100px" ReadOnly="true"> </asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 4px; margin-left: 10px;">
                                                                <asp:TextBox ID="txtsearchenddate" runat="server" SkinID="textPad" CssClass="txtbox"
                                                                    Width="100px" ReadOnly="true"> </asp:TextBox>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div id="Divdiv_btnSearch" runat="server" style="float: left; margin-top: -2px; margin-left: 15px;">
                                                                <div id="div_btnsearch" style="display: block">
                                                                    <asp:Button ID="btnFinalSearch" runat="server" CssClass="button" Text="Search" ToolTip="Search" OnClientClick="javascript:var s=CallSearchMethod();if(s)loadingimage(this.id,'div_btnsaveprocess');return false;"></asp:Button>
                                                                </div>
                                                                <div id="div_btnsaveprocess" style="display: none">
                                                                    <img src="<%=strimgpath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div id="Div23" runat="server" style="float: left; margin-top: -2px; margin-left: 15px;">
                                                                <div>
                                                                    <asp:Button ID="btnClear" runat="server" ToolTip="Clear" CssClass="button" Text="Clear" CausesValidation="False"
                                                                        OnClientClick="javascript:var C=Clearsearchfilter();if(C)loadingimage(this.id,'div_btnClearprocess'); return false;"></asp:Button>
                                                                </div>
                                                                <div id="div_btnClearprocess" style="display: none;">
                                                                    <img src="<%=strimgpath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                                </div>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                </table>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <div style="margin-top: 5px; margin-left: 3px;">
                                                                <asp:CheckBox ID="Chk_Task" runat="server" />
                                                                <%=objLangClass.GetLanguageConversion("Task")%>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 5px; margin-left: 5px;">
                                                                <asp:CheckBox ID="Chk_Call" runat="server" />
                                                                <%=objLangClass.GetLanguageConversion("Call")%>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div style="margin-top: 5px; margin-left: 5px;">
                                                                <asp:CheckBox ID="Chk_Note" runat="server" />
                                                                <%=objLangClass.GetLanguageConversion("Note")%>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div style="padding: 5px 0px 5px 10px" class="smallfontgrey">
                                                    <asp:Label ID="Search_Note" runat="server">
                                                      <b>Note: </b><%=objLanguage.GetLanguageConversion("CRM_Search_Note")%>
                                                    </asp:Label>
                                                </div>
                                            </div>
                                            <div style="margin-top: -118px; float: right; margin-right: -10px;">
                                                <asp:LinkButton ID="LinkButton25" runat="server" CausesValidation="false" CssClass="TaskClosePopup"
                                                    OnClientClick="javascript:CloseSearchPanel(); return false;" ToolTip="Close"></asp:LinkButton>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div id="div_Client" style="padding: 10px 10px 10px 10px; display: block; width: 100%;">
                                <div id="div_detail" align="left" style="width: 100%; margin-top: 0px; margin-left: 5px;">
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <div style="margin-top: -10px; margin-bottom: 10px; display: none;">
                                                    <asp:Button ID="btnPrintClInfoAndAddress" runat="server" CssClass="button" Text="Print"
                                                        CausesValidation="False" OnClientClick="javascript:PrintCusDetailsWithAddress(); return false;"></asp:Button>
                                                    <asp:Button ID="btnPrintClInfoAndNotes" runat="server" CssClass="button" Text="Print"
                                                        CausesValidation="False" OnClientClick="javascript:PrintCusDetailsWithAllNotes(); return false;"></asp:Button>
                                                    <asp:Button ID="btnPrintClInfoWithDeptInfo" runat="server" CssClass="button" Text="Print"
                                                        CausesValidation="False" OnClientClick="javascript:PrintCusDetailsWithDeptInfo(); return false;"></asp:Button>
                                                    <asp:Button ID="btnPrintMap" runat="server" CssClass="button" Text="Map" CausesValidation="False"
                                                        OnClientClick="javascript:PrintCusnamewithlocationMap(); return false;"></asp:Button>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="leftcol" style="width: 47%;">
                                        <div align="left" style="display: none;">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="lbl1" runat="server" Text="Company Name" CssClass="normalText"></asp:Label>
                                            </div>
                                            <div class="box">
                                                <asp:Label ID="lblCompanyName" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="lblConName" runat="server" Text="Contact Name" CssClass="normalText"><%=objLangClass.GetLanguageConversion("Default_Contact_Name")%></asp:Label>
                                            </div>
                                            <div class="clientlabel">
                                                <asp:Label ID="lblContactname" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="Label15" runat="server" Text="Email" CssClass="normalText"><%=objLangClass.GetLanguageConversion("Default_Contact_Email")%></asp:Label>
                                            </div>
                                            <div class="clientlabel">
                                                <asp:Label ID="lblBusinessEmail" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="lblph" runat="server" Text="Phone" CssClass="normalText"><%=objLangClass.GetLanguageConversion("Default_Contact_Mobile")%></asp:Label>
                                            </div>
                                            <div class="clientlabel" style="min-height: 12px;">
                                                <asp:Label ID="lblPhoneNumber" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="Label30" runat="server" Text="Sales Person" CssClass="normalText"></asp:Label>
                                            </div>
                                            <div class="clientlabel">
                                                <asp:Label ID="lblSalesPerson" runat="server" Text="" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="lll">
                                            </div>
                                            <div class="box" style="margin-top: 18px; margin-bottom: 6px;">
                                                <asp:LinkButton ID="lnkShowdetail" runat="server" CssClass="DownArrowDetails" ToolTip="Show Details"
                                                    OnClientClick="javascript:ShowDetails(); return false"></asp:LinkButton>
                                                <asp:LinkButton ID="lnkHideDetails" runat="server" CssClass="DownArrowDetails" Style="display: none;"
                                                    ToolTip="Hide Details" OnClientClick="javascript:HideDetails(); return false"></asp:LinkButton>
                                            </div>
                                        </div>
                                        <div id="ShowDivLeft" style="display: none;">
                                            <div align="left" style="display: none">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label3" runat="server" Text="Company Alias" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblCompanyAlias" runat="server" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div id="Div_Carrier" runat="server" align="left" style="display: none">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="lblcrr" runat="server" Text="Balance" CssClass="normalText">Carrier</asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lbliscarrier" runat="server" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>

                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label23" runat="server" Text="Payment Terms" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <div>
                                                        <asp:Label ID="lblPaymentTerms" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="lbl_url" runat="server" Text="URL" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblURL" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label18" runat="server" Text="Credit Limit" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblCreditLimit" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label19" runat="server" Text="Credit Reference" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblCreditRef" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label20" runat="server" Text="Tax1" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblTax1" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div id="div_Tax2" runat="server" align="left" style="display: none;">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label21" runat="server" Text="Tax2" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblTax2" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="lbl_desc" runat="server" Text="Description" CssClass="normalText"></asp:Label>&nbsp;
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblDescription" runat="server" Style="overflow: hidden; height: auto;"
                                                        CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>

                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="lblbusiemail" runat="server" Text="Business Email" CssClass="normalText"></asp:Label>&nbsp;
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblActualBusinessEmail" runat="server" Style="overflow: hidden; height: auto;"
                                                        CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div id="rightcol" style="width: 47%;">
                                        <div align="left">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="Label5" runat="server" Text="Account Status" CssClass="normalText"></asp:Label>
                                            </div>
                                            <div class="clientlabel">
                                                <asp:Label ID="lblAccountStatus" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="Label4" runat="server" Text="Type" CssClass="normalText"></asp:Label>
                                            </div>
                                            <div class="clientlabel">
                                                <asp:Label ID="lblType" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left" style="display: none;">
                                            <div class="bglabel" style="width: 180px;">
                                                <asp:Label ID="Label24" runat="server" Text="Conversion (%)" CssClass="normalText"></asp:Label>
                                            </div>
                                            <div class="clientlabel">
                                                <asp:Label ID="LblEstimateToJob1" runat="server" CssClass="normalText"></asp:Label>
                                            </div>
                                        </div>
                                        <div align="left">
                                            <div class="lll">
                                            </div>
                                            <div style="clear: both; height: 27px; width: 22px; float: left;"></div>
                                        </div>
                                        <div id="ShowDivRight" style="display: none;">
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label6" runat="server" Text="Account Number" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblAccountNumber" runat="server" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label25" runat="server" Text="Profit Margin" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblProfitMargin" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label22" runat="server" Text="Tax Reg No" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblTaxRegNo" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label26" runat="server" Text="A/C Opened" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblAcOpened" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label27" runat="server" Text="Bank Code" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblBankCode" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label28" runat="server" Text="Bank Account Number" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblBankAccountNumber" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="Label29" runat="server" Text="Account Name" CssClass="normalText"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lblAccountName" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div id="Div_Referencedby" align="left">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="LabelReference" runat="server" Text="Referred By"></asp:Label>
                                                </div>
                                                <div class="clientlabel">
                                                    <asp:Label ID="lbl_Referencedby" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div id="DivChkRoyalityFree" runat="server" align="left" style="display: none;">
                                                <div class="bglabel" style="width: 180px;">
                                                    <asp:Label ID="lblRoyalityFee" runat="server" Text=""><%=objLangClass.GetLanguageConversion("Royality_Free")%></asp:Label>
                                                </div>
                                                <div class="clientlabel" style="margin-top: 2px;">
                                                    <asp:Label ID="lblRoyalityFree" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                </div>
                                            </div>
                                            <div id="div_Supplier" runat="server" style="display: none">
                                                <div align="left">
                                                    <div class="bglabel" style="width: 180px;">
                                                        <asp:Label ID="Label31" runat="server" Text="" CssClass="normalText"><%=objLangClass.GetLanguageConversion("Tax_Number") %></asp:Label>
                                                    </div>
                                                    <div class="clientlabel">
                                                        <asp:Label ID="lblTaxNumber" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                    </div>
                                                </div>
                                                <div align="left">
                                                    <div class="bglabel" style="width: 180px;">
                                                        <asp:Label ID="Label32" runat="server" Text="" CssClass="normalText"><%=objLangClass.GetLanguageConversion("Balance") %></asp:Label>
                                                    </div>
                                                    <div class="clientlabel">
                                                        <asp:Label ID="lblBalance" runat="server" Text="" CssClass="normalText"></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                                <div>
                                    <div style="margin-top: 10px; margin-left: 5px; display: none;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblnotessumm" runat="server" Text="Account Notes" CssClass="NotesSumm"><%=objLangClass.GetLanguageConversion("Account_Notes")%></asp:Label>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="DivShowNote" style="margin-left: 5px; display: none;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="background-color: #EEEEEE; width: 500px; margin-top: 7px; border-radius: 2px; display: none;">
                                            <tr>
                                                <td>
                                                    <div style="margin-top: 7px; margin-bottom: 7px; margin-left: 5px;">
                                                        <input id="txtSearch" style="width: 490px; font-size: 12px; color: Black; padding-bottom: 4px; padding-left: 5px;"
                                                            type="text" value="Add a Note..." onclick="OpenAddnotesDetails();" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="AddNote" style="display: none; margin-left: 5px;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="background-color: #EEEEEE; width: 500px; margin-top: 7px; border-radius: 3px;">
                                            <tr>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="DivViewNotes" runat="server" style="margin-left: 5px; display: none;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="margin-top: 13px; display: none;">
                                                        <asp:Label ID="Label91" runat="server" CssClass="NotesSumm" Text="Recent Added Notes"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 496px; margin-top: 5px;">
                                            <tr>
                                                <td>
                                                    <div id="DivlblNotesTitle" style="margin-top: 0px; margin-right: 5px;">
                                                        <asp:Label ID="lblNotesTitle1" runat="server"></asp:Label>
                                                        <iframe id="Ifattachedfiles" runat="server" style="display: none;"></iframe>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div id="DivlblNotesTitleHide" style="margin-top: 7px; margin-right: 5px; display: none;">
                                                        <asp:Label ID="lblNotesTitleHide" runat="server"></asp:Label>
                                                        <asp:Label ID="lblNotesTitleHide1" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div align="center" id="DivMoreNotes" runat="server" style="margin-top: 5px; margin-right: 5px; margin-bottom: 5px; display: none;">
                                                        <asp:LinkButton ID="lnkShowmoreNotes" runat="server" CssClass="DownArrowDetails"
                                                            ToolTip="See more Notes" OnClientClick="javascript:ShowMoreNotes(); return false"></asp:LinkButton>
                                                        <asp:LinkButton ID="lnkHidemoreNotes" runat="server" CssClass="DownArrowDetails"
                                                            Style="display: none;" ToolTip="Hide more Notes" OnClientClick="javascript:HideMoreNotes(); return false"></asp:LinkButton>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="margin-top: 5px; margin-right: 5px; margin-bottom: 5px;">
                                                        <asp:Label ID="lblNotesDescripitions" Style="line-height: 18px;" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="DivopenActivities" runat="server" style="margin-left: 5px; margin-top: 13px; display: none;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="margin-top: 10px;">
                                                        <asp:Label ID="Label10" runat="server" CssClass="NotesSumm" Text="Open Activities"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="DivlblSuccMesg" align="left" style="margin-bottom: -25px; display: none; margin-left: 170px; border: 1px solid transparent;">
                                        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 280px;">
                                            <tr>
                                                <td>
                                                    <div id="imgopActivitymsg" class="msg_success123">
                                                    </div>
                                                </td>
                                                <td>
                                                    <div id="productAdded_sucessMsg">
                                                        <asp:Label ID="lblSuccMesg" runat="server" Style="color: #FD8404; font-weight: bold; font-size: 11px;"
                                                            Text="" CssClass="lblSuccMesgCl"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div align="left" id="DivNotesMessage" style="margin-bottom: -25px; display: none; margin-left: 170px; border: 1px solid transparent">
                                        <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 280px;">
                                            <tr>
                                                <td>
                                                    <div id="DivNoteImgMsg" class="msg_success123">
                                                    </div>
                                                </td>
                                                <td>
                                                    <div id="Div13" style="margin-bottom: 4px;">
                                                        <asp:Label ID="lblNotesMessage" runat="server" Style="color: #FD8404; font-weight: bold; font-size: 11px;"
                                                            CssClass="lblSuccMesgCl"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <div style="margin-left: 5px; margin-top: 3px;">
                                                    <asp:Label ID="lblNotesTitle" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <div style="margin-left: 5px; margin-top: 3px; display: none; float: left;">
                                                    <asp:PlaceHolder ID="plsOpenActivities" runat="server"></asp:PlaceHolder>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div>
                                        <asp:DropDownList ID="OpenCloseTasknCall" Width="140px" Style="margin-top: 5px; position: absolute; height: 20px; margin-left: 12%;" runat="server" CssClass="simpledropdownPopup" onchange="Open_closeTasknCall1(); return false;">
                                            <asp:ListItem Text="Open Tasks & Calls" Value="OpenTasknCalls" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Closed Tasks & Calls" Value="CloseTasknCalls"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <div style="margin-left: 5px; margin-top: 7px;">
                                                    <asp:Label ID="lblOpenActivities" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <div style="margin-left: 5px;">
                                                    <asp:Label ID="lblcloseActivity" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="divnoactivityFound" style="margin-top: 8px; margin-left: 10px; font-weight: bold; display: none;">
                                        <asp:Label ID="lblNoActivi" runat="server" Text="No open activities found"></asp:Label>
                                    </div>
                                    <div id="DivContactLabel" runat="server" style="margin-left: 5px; margin-top: 15px; display: none;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="margin-top: 10px;">
                                                        <asp:Label ID="Label37" runat="server" CssClass="NotesSumm" Text="Contacts" Visible="false"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="DivCOntactMessage" align="center" style="margin-bottom: -25px; display: none; margin-bottom: -17px;">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div id="imgcontactMsg" class="msg_success123">
                                                    </div>
                                                </td>
                                                <td>
                                                    <div id="Div11">
                                                        <asp:Label ID="lblContactMessage" runat="server" Text="" Style="color: #FD8404; font-weight: bold; font-size: 11px;"
                                                            CssClass="lblSuccMesgCl"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="margin-left: 5px; margin-top: 3px; display: none;">
                                        <asp:PlaceHolder ID="plstopfivecontact" runat="server"></asp:PlaceHolder>
                                    </div>
                                    <div style="margin-left: 5px; margin-top: 3px;">
                                        <asp:Label ID="lbltopfivecontact" runat="server"></asp:Label>
                                    </div>
                                    <div style="margin-left: 5px; margin-top: 3px; display: none;">
                                        <asp:Label ID="lblPrintCusDetailsWithAddress" runat="server"></asp:Label>
                                    </div>
                                    <div style="margin-left: 5px; margin-top: 3px; display: none;">
                                        <asp:Label ID="lblPrintCusDetailsWithAllNotes" runat="server"></asp:Label>
                                    </div>
                                    <div style="margin-left: 5px; margin-top: 3px; display: none;">
                                        <asp:Label ID="lblPrintCusDetailsWithDeptInfo" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div id="div_btn" align="left" style="width: 100%; margin-bottom: 10px;">
                                <div class="only5px">
                                </div>
                                <div align="left" style="width: 100%;">
                                    <div style="float: left; width: 51%">
                                        &nbsp;
                                    </div>
                                    <div style="float: left;">
                                        <div style="float: left">
                                        </div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left">
                                        </div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left">
                                        </div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left; width: 0px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left; display: none;" id="Div_b2b">
                                            <div id="div_createb2b" style="display: block">
                                                <asp:Button ID="btnCreateAcc_Or_view" runat="server" CssClass="Button" Visible="false"
                                                    OnClick="btnCreateAcc_Or_view_Click" OnClientClick="javascript:loadingimage(this.id,'div_createb2bprocess');"
                                                    Text="Create B2B estore"></asp:Button>
                                            </div>
                                            <div id="div_createb2bprocess" style="display: none">
                                                <img src="<%=ImgPath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </div>
                                    <div style="clear: both">
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="DivAnotherDesign" runat="server" style="width: 100%; display: none;">
                    <div id="div_ContactMain" runat="server" class="eprint-crm-section-pilot-root eprint-crm-contacts-pilot-root" data-crm-section="contacts" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot eprint-crm-contacts-pilot">
                            <div class="eprint-crm-section-hero eprint-crm-contacts-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Contacts")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company eprint-crm-contacts-company"></span></p>
                                </div>
                                <div class="eprint-crm-section-hero-stats" aria-live="polite">
                                    <span class="eprint-crm-section-count eprint-crm-contacts-count">0</span>
                                    <span class="eprint-crm-section-count-label"><%=objLangClass.GetLanguageConversion("Contacts")%></span>
                                </div>
                            </div>
                            <div class="eprint-crm-section-toolbar eprint-crm-contacts-toolbar">
                                <div class="eprint-crm-section-search-wrap">
                                    <label class="eprint-crm-sr-only" for="eprintCrmSectionSearch_contacts">Quick search contacts</label>
                                    <input type="search" id="eprintCrmSectionSearch_contacts" class="eprint-crm-section-search eprint-crm-contacts-search"
                                        placeholder="Search name, email, department on this page…" autocomplete="off" />
                                </div>
                                <div class="eprint-crm-section-actions">
                                    <button type="button" class="headerbutton white eprint-crm-section-btn-add"
                                        onclick="javascript:addNewcontact('contact','add','<%=ClientID %>','0');return false;">+ <%=objLangClass.GetLanguageConversion("Add_New_Contact")%></button>
                                    <button type="button" class="headerbutton white"
                                        onclick="var b=document.getElementById('<%=btn_ClearFilter_Contact.ClientID %>');if(b){b.click();} return false;">
                                        <%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></button>
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card eprint-crm-contacts-grid-card">
                                    <asp:PlaceHolder ID="plh_ContactDetails" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                    </div>
                    <div id="div_DepartmentMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="dept" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot">
                            <div class="eprint-crm-section-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Departments")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                                </div>
                                <div class="eprint-crm-section-hero-stats" aria-live="polite">
                                    <span class="eprint-crm-section-count">0</span>
                                    <span class="eprint-crm-section-count-label"><%=objLangClass.GetLanguageConversion("Departments")%></span>
                                </div>
                            </div>
                            <div class="eprint-crm-section-toolbar">
                                <div class="eprint-crm-section-search-wrap">
                                    <input type="search" class="eprint-crm-section-search" placeholder="Search departments on this page…" autocomplete="off" />
                                </div>
                                <div class="eprint-crm-section-actions">
                                    <button type="button" class="headerbutton white eprint-crm-section-btn-add"
                                        onclick="javascript:addNewDepartment('dept','add','<%=ClientID %>','0');return false;">+ <%=objLangClass.GetLanguageConversion("Add_New_Department")%></button>
                                    <button type="button" class="headerbutton white"
                                        onclick="var b=document.getElementById('<%=btn_ClearFilters_Dept.ClientID %>');if(b){b.click();} return false;">
                                        <%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></button>
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card">
                        <div>
                            <asp:UpdatePanel ID="up_DeptDetails" runat="server">
                                <ContentTemplate>
                                    <div id="div2" runat="server" style="display: block;">
                                        <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                                            <div style="width: 60%; margin: 5px 0px 0px 10px">
                                                <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                                    <ContentTemplate>
                                                        <asp:PlaceHolder ID="plhDepartment" runat="server"></asp:PlaceHolder>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div id="DIv_ListBox" runat="server">
                                            <div id="div_popupActionDepartment" style="display: none; z-index: 999999; position: absolute; margin: 30px 0px 0px 16px; cursor: pointer;"
                                                onmouseover="show_Dept();" onmouseout="hide_Dept();">
                                                <telerik:RadListBox runat="server" ID="RadListBox_Department" SelectionMode="Single"
                                                    AutoPostBack="false">
                                                    <Items>
                                                        <%--Ticket Id : 13951--%>
                                                        <telerik:RadListBoxItem id="DeptSpendlimit" runat="server" Text="Spend limit" Style="border-bottom: 1px solid #CBCBCB; display: none; cursor: pointer"
                                                            onclick="javascript:return CheckOne_new_Dept('spendlimitdept');" Checked="false" />
                                                        <telerik:RadListBoxItem id="DeptSpendlimitDeactivate" runat="server" Text="Spend limit" Style="border-bottom: 1px solid #CBCBCB; display: none; cursor: pointer"
                                                            onclick="javascript:return CheckOne_new_Dept('spendlimitdeactivate');" Checked="false" />
                                                        <telerik:RadListBoxItem Text="Delete" onclick="javascript:return CheckOne_new_Dept('delete_dept');"
                                                            Checked="false" />
                                                    </Items>
                                                </telerik:RadListBox>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hdn_deptIDs" runat="server" />
                                        <asp:HiddenField ID="hdn_assignedDeptID" runat="server" Value='0' />
                                        <asp:LinkButton ID="lnk_DeptRadList" runat="server" OnClick="RadListBox_Department_SelectedIndexChanged"></asp:LinkButton>
                                        <div id="div_Department" style="padding: 2px 10px 25px 8px; display: block;">
                                            <telerik:RadGrid ID="RadGrid_Department" runat="server" OnNeedDataSource="RadGrid_Department_OnNeedDataSource"
                                                OnItemDataBound="RadGridDepartment_OnRowDataBound" AllowFilteringByColumn="true"  OnItemCommand="RadGrid_Department_ItemCommand"
                                                AutoGenerateColumns="false" Width="100%" AllowPaging="true" AllowSorting="true"
                                                GridLines="none" PageSize="50" CssClass="AddBorders eprint-crm-section-grid" HeaderStyle-Font-Bold="true" ShowGroupPanel="false"
                                                Skin="Default" EnableEmbeddedSkins="true" loadingpanelid="RadAjaxLoadingPanel1"
                                                HeaderStyle-ForeColor="#333333" HeaderStyle-BorderStyle="Double" BorderColor="White"
                                                FilterItemStyle-HorizontalAlign="Justify" GroupingSettings-CaseSensitive="false" OnPageIndexChanged="RadGrid_Department_PageIndexChanged" AllowCustomPaging="True">
                                                <AlternatingItemStyle BackColor="White" />
                                                <PagerStyle AlwaysVisible="true"  Mode="NextPrevAndNumeric"  Position="Bottom" />
                                                <MasterTableView DataKeyNames="DeptID" OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                    CommandItemDisplay="Top" Width="100%">
                                                    <CommandItemTemplate>
                                                        <div style="border-bottom: 1px solid #C9C9C9; margin-top: 5px;">
                                                        </div>
                                                    </CommandItemTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                            HeaderStyle-Width="5%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                            ItemStyle-Width="5%" UniqueName="ChkDelete">
                                                            <HeaderTemplate>
                                                                <div id="div_checkBox_Dept" style="float: left; display: block;">
                                                                    <div id="div_chk_Dept" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit; border-radius: 2px 2px 2px 2px;">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <div style="float: left;">
                                                                                        <input id="checkAll_Dept" runat="server" name="checkAll_Dept" onclick="checkAll_new_Dept(this);"
                                                                                            type="checkbox" />
                                                                                        <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <div style="float: left; padding: 0px 1px 0px 1px">
                                                                                        <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow_Dept" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                            onclick="show_Dept();" alt='' />
                                                                                        <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide_Dept" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                            onclick="hide();" alt='' />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div style="clear: both;">
                                                                    </div>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <div style="padding-left: 2px">
                                                                    <input id="checkBox_Department" runat="server" name="Id" type="checkbox" onclick="CheckChanged_Dept();"
                                                                        value='<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>' />
                                                                    <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="DeptName" HeaderStyle-HorizontalAlign="Left"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                                            HeaderStyle-Width="10%" HeaderText="Department Name" ItemStyle-Width="10%" SortExpression="DeptName"
                                                            UniqueName="DeptName" Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editdept('dept','edit',<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_DeptName" runat="server" ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.DeptName", "{0}")) %>'><%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.DeptName", "{0}")) %></asp:Label>
                                                                        <asp:HiddenField ID="hdn_DeptName" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeptName", "{0}") %>' />
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="DeliveryAddress1" HeaderStyle-HorizontalAlign="Left" UniqueName="DeliveryAddress1"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                                            HeaderStyle-Width="17%" HeaderText="Delivery Address" ItemStyle-Width="17%" SortExpression="DeliveryAddress1"
                                                            Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editdept('dept','edit',<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_AddressDelivery" runat="server"></asp:Label>
                                                                    </div>
                                                                </a>
                                                                <asp:HiddenField ID="hdn_DeliveryAddress" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeliveryAddress", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_DeliveryAddressLine2" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeliveryAddressLine2", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_DeliveryCity" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeliveryCity", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_DeliveryState" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeliveryState", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_DeliveryZipCode" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeliveryZipCode", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_DeliveryCountry" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeliveryCountry", "{0}") %>' />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="InvoiceAddress" HeaderStyle-HorizontalAlign="Left" UniqueName="InvoiceAddress"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                                            HeaderStyle-Width="17%" HeaderText="Invoice Address" ItemStyle-Width="17%" SortExpression="InvoiceAddress"
                                                            Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editdept('dept','edit',<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_AddressInvoice" runat="server"></asp:Label>
                                                                    </div>
                                                                </a>
                                                                <asp:HiddenField ID="hdn_InvoiceAddress" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Address", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_InvoiceAddressLine2" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.AddressLine2", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_InvoiceCity" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.City", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_InvoiceState" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.State", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_InvoiceZipCode" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.ZipCode", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_InvoiceCountry" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.Country", "{0}") %>' />
                                                                <asp:HiddenField ID="hdn_AddressType" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.AddressType", "{0}") %>' />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="DeliveryTelephone" HeaderStyle-HorizontalAlign="Left"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="80"
                                                            HeaderStyle-Width="12%" HeaderText="Phone" ItemStyle-Width="12%" SortExpression="DeliveryTelephone"
                                                            UniqueName="DeliveryTelephone" Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editdept('dept','edit',<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_DeptPhone" runat="server"><%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.DeliveryTelephone", "{0}"))%></asp:Label>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <%--Ticket Id : 13951--%>
                                                        <telerik:GridTemplateColumn DataField="SpendLimit" HeaderStyle-HorizontalAlign="Left"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="80"
                                                            HeaderStyle-Width="12%" HeaderText="SpendLimit" ItemStyle-Width="12%" SortExpression="SpendLimit"
                                                            UniqueName="SpendLimit" Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editdept('dept','edit',<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_SpendLimit" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.SpendLimit", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.SpendLimit", "{0}")) %>'></asp:Label>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="ApproverName" HeaderStyle-HorizontalAlign="Left"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="80"
                                                            HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="10%" SortExpression="ApproverName"
                                                            UniqueName="ApproverName" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_ApproverName" runat="server"><%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.ApproverName", "{0}")) %></asp:Label>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="IsDefault" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false" HeaderStyle-Width="5%" HeaderText="Default" ItemStyle-Width="5%"
                                                            SortExpression="Enabled" UniqueName="system" Visible="true" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>,'dept');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:HiddenField ID="hdn_DefaultDept" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsDefault", "{0}") %>' />
                                                                        <asp:HiddenField ID="hdn_DefaultDeptID" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>' />
                                                                        <asp:ImageButton ID="img_DefaultDept" runat="server" CommandName="Set as default"
                                                                            CssClass="rollover" Text="Set as default" CommandArgument='<%#Eval("DeptID")%>'
                                                                            OnCommand="setDefaultDept_OnClick"></asp:ImageButton>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="Action"
                                                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="5%" UniqueName="restoreDefault">
                                                            <ItemTemplate>
                                                                <div id="DivDelete" runat="server" style="text-align: center;">
                                                                    <a href="javascript:void(0);" onclick="javascript:return imgbtnDeleteDept_ClientClick('dept',<%# DataBinder.Eval(Container, "DataItem.DeptID", "{0}") %>,<%# DataBinder.Eval(Container, "DataItem.NoOfContacts", "{0}") %>)">
                                                                        <asp:ImageButton ID="ImgButtonDeleteDept" runat="server" ImageUrl="~/images/erase.png"
                                                                            CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" CommandArgument='<%#Eval("DeptID")%>'
                                                                            OnCommand="DeleteImgDept_OnClick"></asp:ImageButton>
                                                                    </a>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <NoRecordsTemplate>
                                                        <div style="padding: 5px 5px 5px 10px">
                                                            <%=objLangClass.GetLanguageConversion("No_records_Found") %>
                                                        </div>
                                                    </NoRecordsTemplate>
                                                </MasterTableView>
                                                <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                                    AllowDragToGroup="false" Scrolling-AllowScroll="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                    <Scrolling UseStaticHeaders="true" ScrollHeight="340" SaveScrollPosition="true" />
                                                    <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                        <div id="div_DepartmentDelete" style="display: none; position: absolute; z-index: 100; width: 40%">
                                            <table cellpadding="0" cellspacing="0" width="100%; height:200px">
                                                <tr>
                                                    <td colspan="2" class="popup-top-leftcorner">&nbsp;
                                                    </td>
                                                    <td class="popup-top-middlebg">
                                                        <div class="Label-PopupHeading" style="float: left; padding-top: 6px; padding-left: 1px">
                                                            <b>Department</b>
                                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        </div>
                                                        <div style="float: right; padding-top: 6px; padding-right: 10px">
                                                            <div class="CancelButtonDiv">
                                                                <asp:ImageButton ID="ImageButton1" ToolTip="Cancel" ImageUrl="~/images/closebtn.png"
                                                                    runat="server" CausesValidation="false" OnClientClick="javascript:return hideDiv('div_DepartmentDelete');" />
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td colspan="2" class="popup-top-rightcorner">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="popup-middle-leftcorner">&nbsp;
                                                    </td>
                                                    <td style="width: 15px; background-color: #ffffff">&nbsp;
                                                    </td>
                                                    <td class="popup-middlebg" align="left">
                                                        <div style="padding-left: 5px; padding-top: 5px">
                                                            <div style="float: left; width: 100%;">
                                                                <div class="bglabel" style="width: 30%">
                                                                    <asp:Label ID="lblStatus" runat="server" Text="Department List" CssClass="normaltext"></asp:Label>
                                                                </div>
                                                                <div class="box">
                                                                    <div style="float: left;">
                                                                        <asp:UpdatePanel ID="pnl_accountList" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:DropDownList ID="ddl_deptList" runat="server" CssClass="textboxnew" Width="280px"
                                                                                    onchange="getDeptID();">
                                                                                </asp:DropDownList>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                    <div style="clear: both">
                                                                    </div>
                                                                    <div id="spn_error" style="color: Red; display: none; font-size: 10px; width: 150px">
                                                                        <span>Please select any one department</span>
                                                                    </div>
                                                                    <div style="clear: both">
                                                                    </div>
                                                                    <div id="div_save" runat="server" style="margin: 15px 0px 5px 0px">
                                                                        <asp:UpdatePanel ID="up_saveDept" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="btn_saveDept" runat="server" Text="Save" CssClass="button" OnClick="btn_saveDept_OnClick"
                                                                                    OnClientClick="callDept();" />
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                                <div style="clear: both">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="width: 10px; background-color: #ffffff">&nbsp;
                                                    </td>
                                                    <td align="right" class="popup-middle-rightcorner">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="popup-bottom-leftcorner">&nbsp;
                                                    </td>
                                                    <td class="popup-bottom-middlebg">&nbsp;
                                                    </td>
                                                    <td colspan="2" class="popup-bottom-rightcorner">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="IsConfirmDepts" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                            </div>
                        </div>
                    </div>
                    <div id="div_AddressMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="address" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot">
                            <div class="eprint-crm-section-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Address_Book")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                                </div>
                                <div class="eprint-crm-section-hero-stats" aria-live="polite">
                                    <span class="eprint-crm-section-count">0</span>
                                    <span class="eprint-crm-section-count-label"><%=objLangClass.GetLanguageConversion("Address_Book")%></span>
                                </div>
                            </div>
                            <div class="eprint-crm-section-toolbar">
                                <div class="eprint-crm-section-search-wrap">
                                    <input type="search" class="eprint-crm-section-search" data-crm-section="address" placeholder="Search addresses on this page…" autocomplete="off" />
                                </div>
                                <div class="eprint-crm-section-actions">
                                    <button type="button" class="headerbutton white eprint-crm-section-btn-add"
                                        onclick="javascript:addNewAddress('Address','add','<%=ClientID %>','0');return false;">+ <%=objLangClass.GetLanguageConversion("Add_New_Address")%></button>
                                    <button type="button" class="headerbutton white"
                                        onclick="var b=document.getElementById('<%=btn_ClearFilter_Address.ClientID %>');if(b){b.click();} return false;">
                                        <%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></button>
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card">
                        <div>
                            <asp:UpdatePanel ID="up_AddressDetails" runat="server">
                                <ContentTemplate>
                                    <div id="div3" runat="server" style="display: block;">
                                        <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                                            <div style="width: 60%; margin: 5px 0px 0px 5px">
                                                <asp:PlaceHolder ID="plhAddress" runat="server"></asp:PlaceHolder>
                                            </div>
                                        </div>
                                        <div>
                                            <div id="div_popupActionAddress" style="display: none; z-index: 999999; position: absolute; margin: 30px 0px 0px 14px"
                                                onmouseover="show_Address();" onmouseout="hide_Address();">
                                                <telerik:RadListBox runat="server" ID="RadListBox_Address" SelectionMode="Single"
                                                    Width="100px" AutoPostBack="false">
                                                    <Items>
                                                        <telerik:RadListBoxItem Text="Delete" onclick="javascript:return CheckOne_new_Address('delete_address');"
                                                            Checked="false" />
                                                    </Items>
                                                </telerik:RadListBox>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="hdn_AddressIDs" runat="server" />
                                        <asp:LinkButton ID="lnk_AddressRadList" runat="server" OnClick="RadListBox_Address_SelectedIndexChanged"></asp:LinkButton>
                                        <div id="div_Address" style="padding: 2px 7px 25px 6px; display: block;">
                                            <telerik:RadGrid ID="RadGrid_Address" runat="server" AllowPaging="true" AllowSorting="true" OnItemCommand="RadGrid_Address_ItemCommand"
                                                AutoGenerateColumns="false" PagerStyle-AlwaysVisible="true" GroupingEnabled="false"
                                                PageSize="50" Width="100%" ShowGroupPanel="false" ShowStatusBar="true" HeaderStyle-Font-Bold="true"
                                                OnNeedDataSource="RadGrid_Address_OnNeedDataSource" OnPreRender="RadGrid_Address_PreRender" AllowFilteringByColumn="true"
                                                OnItemDataBound="RadGridAddress_OnRowDataBound" CssClass="AddBorders eprint-crm-section-grid" EnableEmbeddedSkins="true"
                                                HeaderStyle-ForeColor="#333333" HeaderStyle-BorderStyle="Double" BorderColor="White"
                                                FilterItemStyle-HorizontalAlign="Justify" Skin="Default" GroupingSettings-CaseSensitive="false">
                                                <AlternatingItemStyle BackColor="White" />
                                                <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" Position="Bottom" />
                                                <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                <MasterTableView DataKeyNames="AddressID" OverrideDataSourceControlSorting="true"
                                                    AllowFilteringByColumn="true" CommandItemDisplay="Top" Width="100%">
                                                    <CommandItemTemplate>
                                                        <div style="border-bottom: 1px solid #C9C9C9; margin-top: 5px;">
                                                        </div>
                                                    </CommandItemTemplate>
                                                    <Columns>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                            HeaderStyle-Width="3%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                            ItemStyle-Width="3%" UniqueName="checkBox_Address">
                                                            <HeaderTemplate>
                                                                <div id="div_checkBox_Address" style="float: left; display: block;">
                                                                    <div id="div_chk_Address" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit; border-radius: 2px 2px 2px 2px">
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                            <tr>
                                                                                <td>
                                                                                    <div style="float: left;">
                                                                                        <input id="checkAll_Address" runat="server" name="checkAll_Address" onclick="checkAll_new_Address(this);"
                                                                                            type="checkbox" />
                                                                                        <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <div style="float: left; padding: 0px 1px 0px 1px">
                                                                                        <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow_Address" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                            onclick="show_Address();" alt='' />
                                                                                        <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide_Address" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                            onclick="hide_Address();" alt='' />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div style="clear: both;">
                                                                    </div>
                                                                </div>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <input id="checkBox_Address" runat="server" name="Id" type="checkbox" onclick="CheckChanged_Address();"
                                                                    value='<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>' />
                                                                <input id="hdnUPDOWN" runat="server" type="hidden" />
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="AddressLabel" HeaderStyle-HorizontalAlign="Left"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                                            HeaderStyle-Width="15%" HeaderText="Address Label" ItemStyle-Width="15%" SortExpression="AddressLabel"
                                                            UniqueName="AddressLabel" Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editAddress('address','edit',<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_AddressLabel" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.AddressLabel", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.AddressLabel", "{0}")) %>'></asp:Label>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="NewAddress" HeaderStyle-HorizontalAlign="Left"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                                            HeaderStyle-Width="35%" HeaderText="Address" ItemStyle-Width="35%" SortExpression="NewAddress"
                                                            UniqueName="NewAddress" Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editAddress('address','edit',<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_Address" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.NewAddress", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.NewAddress", "{0}")) %>'></asp:Label>
                                                                        <asp:HiddenField ID="hdn_Address" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Address", "{0}")) %>' />
                                                                        <asp:HiddenField ID="hdn_City" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.City", "{0}")) %>' />
                                                                        <asp:HiddenField ID="hdn_Suburb" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.State", "{0}")) %>' />
                                                                        <asp:HiddenField ID="hdn_PostCode" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.ZipCode", "{0}")) %>' />
                                                                        <asp:HiddenField ID="hdn_Country" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Country", "{0}")) %>' />
                                                                        <asp:HiddenField ID="hdn_AddressLabel" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.AddressLabel", "{0}")) %>' />
                                                                        <asp:HiddenField ID="hdn_AddressLine2" runat="server" Value='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.AddressLine2", "{0}")) %>' />
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="Telephone" HeaderStyle-HorizontalAlign="Left"
                                                            CurrentFilterFunction="Contains" AutoPostBackOnFilter="true" FilterControlWidth="100"
                                                            HeaderStyle-Width="10%" HeaderText="Telephone" ItemStyle-Width="20%" SortExpression="Address"
                                                            UniqueName="Telephone" Visible="true">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editAddress('address','edit',<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>,<%=ClientID %>,'<%=isView%>');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Label ID="lbl_Telephone" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Telephone", "{0}")) %>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container, "DataItem.Telephone", "{0}")) %>'></asp:Label>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="IsDefaultDeliveryAddress" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false" HeaderStyle-Width="10%" HeaderText="Delivery" ItemStyle-Width="10%"
                                                            SortExpression="IsDefaultDeliveryAddress" FilterControlWidth="100" Visible="false"
                                                            ItemStyle-HorizontalAlign="Center" UniqueName="IsDefaultDeliveryAddress">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editAddress('address','edit',<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>,<%=ClientID %>);">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Image ID="img_DefaultDelivery" runat="server" />
                                                                        <asp:HiddenField ID="hdn_DefaultDelivery" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsDefaultDeliveryAddress", "{0}") %>' />
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="IsDefaultBillingAddress" HeaderStyle-HorizontalAlign="Center"
                                                            FilterControlWidth="100" AllowFiltering="false" HeaderStyle-Width="10%" HeaderText="Billing"
                                                            ItemStyle-Width="10%" SortExpression="IsDefaultBillingAddress" Visible="false"
                                                            ItemStyle-HorizontalAlign="Center" UniqueName="IsDefaultBillingAddress">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="editAddress('address','edit',<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>,<%=ClientID %>);">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                        <asp:Image ID="img_DefaultBilling" runat="server" />
                                                                        <asp:HiddenField ID="hdn_DefaultBilling" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsDefaultBillingAddress", "{0}") %>' />
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn DataField="IsDefaultPostBoxAddress" HeaderStyle-HorizontalAlign="Center"
                                                            AllowFiltering="false" HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="10%"
                                                            SortExpression="IsDefaultPostBoxAddress" UniqueName="IsDefaultPostBoxAddress"
                                                            Visible="true" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <a href="javascript:void(0);" onclick="javascript:return setAsDefault(<%# DataBinder.Eval(Container, "DataItem.AddressID", "{0}") %>,'adress');">
                                                                    <div style="float: left; width: 100%; overflow: hidden; height: 18px;">
                                                                        <asp:HiddenField ID="hdn_DefaultPostBox" runat="server" Value='<%# DataBinder.Eval(Container, "DataItem.IsDefaultPostBoxAddress", "{0}") %>' />
                                                                        <asp:ImageButton ID="img_DefaultPostBox" runat="server" CommandName="Set as default"
                                                                            CssClass="rollover" Text="Set as default" CommandArgument='<%#Eval("AddressID")%>'
                                                                            OnCommand="setDefaultAddress_OnClick"></asp:ImageButton>
                                                                    </div>
                                                                </a>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                        <telerik:GridTemplateColumn AllowFiltering="false" CurrentFilterFunction="Contains"
                                                            HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="Action"
                                                            ItemStyle-HorizontalAlign="Right" ItemStyle-Width="5%" UniqueName="restoreDefault">
                                                            <ItemTemplate>
                                                                <asp:Panel ID="PanelDeleteAddress" runat="server">
                                                                    <div style="text-align: center;">
                                                                        <a href="javascript:void(0);" onclick="javascript:return imgbtnDelete_ClientClick('address',<%# DataBinder.Eval(Container, "DataItem.NoOfCount", "{0}") %>)">
                                                                            <asp:ImageButton ID="ImgButtonDeleteAddress" runat="server" ImageUrl="~/Images/erase.png"
                                                                                CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" CommandArgument='<%#Eval("AddressID")%>'
                                                                                OnCommand="DeleteImgAddress_OnClick"></asp:ImageButton>
                                                                        </a>
                                                                    </div>
                                                                </asp:Panel>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
                                                    </Columns>
                                                    <NoRecordsTemplate>
                                                        <div style="padding: 5px 0px 0px 10px">
                                                            <%=objLangClass.GetLanguageConversion("No_records_Found") %>
                                                        </div>
                                                    </NoRecordsTemplate>
                                                </MasterTableView>
                                                <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                                    AllowDragToGroup="false" Scrolling-AllowScroll="true">
                                                    <Selecting AllowRowSelect="True" />
                                                    <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                    <Scrolling UseStaticHeaders="true" ScrollHeight="340" SaveScrollPosition="true" />
                                                    <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                                                </ClientSettings>
                                            </telerik:RadGrid>
                                        </div>
                                        <div style="clear: both">
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                            </div>
                        </div>
                    </div>
                    <div id="div_b2bMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="estore" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot">
                            <div class="eprint-crm-section-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("eStore")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card eprint-crm-section-body-card--form">
                        <div>
                            <asp:UpdatePanel ID="up_2b2Details" runat="server">
                                <ContentTemplate>
                                    <%--<asp:PlaceHolder ID="plh_2b2Details" runat="server"></asp:PlaceHolder>--%>
                                    <div style="margin: 10px 0px 0px 10px; display: none;" id="div_B2B_Button" runat="server">
                                        <asp:Button ID="btn_b2bCreate" runat="server" CssClass="Button" OnClientClick="javascript:return showAccount();"
                                            Text="" />
                                    </div>
                                    <div id="div_B2B_Link" runat="server" style="margin: 10px 0px 0px 10px; display: none;">
                                        <b>
                                            <asp:Label ID="lbl_b2b_eStoreLink" runat="server"> <%=objLangClass.GetLanguageConversion("B2B_EStore_URL")%> </asp:Label></b>
                                        <div style="padding-top: 8px;">
                                            <a id="lnk_b2beStoreLink" href='<%=WSPathB2B %>' target="_blank">
                                                <asp:Label ID="lbl_b2beStoreLink" runat="server"></asp:Label></a>
                                        </div>
                                    </div>
                                    <div id="div_B2C_Link" runat="server" style="margin: 10px 0px 0px 10px; display: none;">
                                        <b>
                                            <asp:Label ID="lbl_b2c_eStoreLink" runat="server" Text="B2C eStore URL"></asp:Label></b>
                                        <div style="padding-top: 8px;">
                                            <a id="lnk_b2ceStoreLink" href='<%=WebStorePathB2C %>' target="_blank">
                                                <asp:Label ID="lbl_b2ceStoreLink" runat="server"></asp:Label></a>
                                        </div>
                                    </div>
                                    <div id="div_account" runat="server" style="display: none; margin: 0px 10px 0px 0px; border: solid 0px green">
                                        <iframe id="ifrm_accounts" runat="server" scrolling="no" style="border: solid 0px green; height: auto; width: 100%"></iframe>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div id="div_B2BMsg" runat="server" style="width: 100%; display: none; height: 500px">
                            <div style="margin: 10px 0px 0px 10px; display: block;" runat="server">
<%--                                <asp:Label ID="lvl_B2BMsg" runat="server" Text="Not applicable to your system. Contact support@eprintsoftware.com for more information"></asp:Label>--%>
                                    <asp:Label ID="lvl_B2BMsg" runat="server" Text="Not applicable to your system. Contact support@hexicomsoftware.com for more information"></asp:Label>
                            </div>
                        </div>

                        <script type="text/javascript" language="javascript">

                            var div_account = document.getElementById("<%=div_account.ClientID %>");
                            var div_B2B_Link = document.getElementById("<%=div_B2B_Link.ClientID %>");
                            var lbl_b2beStoreLink = document.getElementById("<%=lbl_b2beStoreLink.ClientID %>");

                            var WebStorePathB2B = '<%=WebStorePathB2B %>';
                            var WebStorePathB2C = '<%=WebStorePathB2C %>';

                        </script>
                            </div>
                        </div>
                    </div>
                    <div id="div_ProductsMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="products" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot">
                            <div class="eprint-crm-section-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Products")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                                </div>
                                <div class="eprint-crm-section-hero-stats" aria-live="polite">
                                    <span class="eprint-crm-section-count">0</span>
                                    <span class="eprint-crm-section-count-label"><%=objLangClass.GetLanguageConversion("Products")%></span>
                                </div>
                            </div>
                            <div class="eprint-crm-section-toolbar">
                                <div class="eprint-crm-section-search-wrap">
                                    <input type="search" class="eprint-crm-section-search" placeholder="Search products on this page…" autocomplete="off" />
                                </div>
                                <div class="eprint-crm-section-actions">
                                    <button type="button" class="headerbutton white eprint-crm-section-btn-add"
                                        onclick="javascript:addNewProduct('Product','add','<%=ClientID %>','0');return false;">+ <%=objLangClass.GetLanguageConversion("Add_New_Product")%></button>
                                    <button type="button" class="headerbutton white"
                                        onclick="javascript:clearfilter_product();return false;">
                                        <%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></button>
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card">
                        <div style="margin-top: 0;">
                            <asp:UpdatePanel ID="up_ProductDetails" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plh_ProductDetails" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                            </div>
                        </div>
                    </div>
                    <div id="div_NotesMain" runat="server" style="width: 100%; display: none; overflow: hidden; height: auto">
                        <div id="div_Load" class="loading_new" style="display: none">
                            <table cellpadding="0" cellspacing="10">
                                <tr>
                                    <td>
                                        <div style="float: left">
                                            <img src="<%=ImgPath %>loading_new.gif" border="0" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div id="div4" runat="server" style="display: block;">
                            <div align="left" style="width: 100%; padding-bottom: 0px; border: 0px solid red">
                                <div style="width: 60%; margin: 5px 0px 0px 5px">
                                    <asp:UpdatePanel ID="UpdatePanel3" RenderMode="Inline" runat="server">
                                        <ContentTemplate>
                                            <asp:PlaceHolder ID="plhNotes" runat="server"></asp:PlaceHolder>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div style="clear: both">
                            </div>
                            <div id="divNotes" style="padding: 0px 10px 10px 10px; display: block; overflow-y: scroll; width: 98%; height: 500px"
                                class="notes_styleMain">
                                <div id="DivAddNewRecords" runat="server">
                                    <div style="float: left; border: solid 0px green; display: block; padding: 5px 10px 10px 0px;">
                                        <a href="javascript:void(0);" onclick="javascript:displayWindowattachmentadd(); return false"
                                            title="Add New Notes">
                                            <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Add a new note" TabIndex="0"></asp:Button>
                                        </a>
                                    </div>
                                </div>
                                <div id="DivPrint" runat="server">
                                    <div style="float: left; border: solid 0px green; display: block; padding: 5px 10px 10px 0px;">
                                        <asp:Button ID="btn_print" runat="server" CssClass="button" Text="Print" TabIndex="1"
                                            Visible="false" />
                                    </div>
                                </div>
                                <div style="float: left; border: solid 0px green; display: block; padding: 5px 10px 10px 0px;">
                                    <asp:ImageButton ID="btn_SortDirection" runat="server" TabIndex="1" ImageUrl="~/images/sorting_icon_ss.png"
                                        Style="padding-top: 3px;" Height="20px" Width="22px" OnClientClick="javascript:changeSortDirection();return false;"
                                        ToolTip="Click here to sort in ascending/descending order" />
                                    <asp:LinkButton ID="lnk_SortDirection" runat="server" OnClick="lnk_SortDirection_OnClick"></asp:LinkButton>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="div_dlist_Notes" style="width: 80%" class="ui-tabs-hide">
                                    <asp:LinkButton ID="lnk_delete" runat="server" OnClick="DeleteImgNotesNew_OnClick"
                                        Style="display: none;"></asp:LinkButton>
                                    <asp:UpdatePanel ID="updnotes" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:PlaceHolder ID="plhNote" runat="server"></asp:PlaceHolder>
                                            <div id="div_NoRecords" runat="server">
                                                <%=objLangClass.GetLanguageConversion("No_Records_Found") %>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="lnk_delete" />
                                            <asp:AsyncPostBackTrigger ControlID="lnk_SortDirection" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <asp:HiddenField ID="hdnAttachmentID" runat="server" Value="0" />
                                <div style="clear: both">
                                </div>
                            </div>
                        </div>
                        <div id="div_notesPrint" style="display: none;">
                            <asp:PlaceHolder ID="ph_notesPrint" runat="server"></asp:PlaceHolder>
                        </div>
                    </div>
                    <div id="div_EmailMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="emails" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot">
                            <div class="eprint-crm-section-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Emails")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                                </div>
                                <div class="eprint-crm-section-hero-stats" aria-live="polite">
                                    <span class="eprint-crm-section-count">0</span>
                                    <span class="eprint-crm-section-count-label"><%=objLangClass.GetLanguageConversion("Emails")%></span>
                                </div>
                            </div>
                            <div class="eprint-crm-section-toolbar">
                                <div class="eprint-crm-section-search-wrap">
                                    <input type="search" class="eprint-crm-section-search" placeholder="Search emails on this page…" autocomplete="off" />
                                </div>
                                <div class="eprint-crm-section-actions">
                                    <button type="button" class="headerbutton white eprint-crm-section-btn-add"
                                        onclick="var b=document.getElementById('<%=btn_AddNewEmail.ClientID %>');if(b){b.click();} return false;">+ <%=objLangClass.GetLanguageConversion("Add_New_Email")%></button>
                                    <button type="button" class="headerbutton white"
                                        onclick="javascript:clearfilter_email();return false;">
                                        <%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></button>
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card">
                        <div>
                            <asp:UpdatePanel ID="up_EmailsDetails" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plh_EmailsDetails" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                            </div>
                        </div>
                    </div>

                    <div id="div_ActivitiesMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="records" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot">
                            <div class="eprint-crm-section-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Records")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                                </div>
                            </div>
                            <div class="eprint-crm-section-toolbar">
                                <div class="eprint-crm-section-search-wrap">
                                    <input type="search" class="eprint-crm-section-search" placeholder="Search records on this page…" autocomplete="off" />
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card">
                        <div>
                            <asp:UpdatePanel ID="up_ActivitiesDetails" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plh_ActivitiesDetails" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                            </div>
                        </div>
                    </div>
                    <div id="div_CostcentreMain" runat="server" class="eprint-crm-section-pilot-root" data-crm-section="costcentre" style="width: 100%; display: none;">
                        <div class="eprint-crm-section-pilot">
                            <div class="eprint-crm-section-hero">
                                <div class="eprint-crm-section-hero-main">
                                    <h2 class="eprint-crm-section-title"><%=objLangClass.GetLanguageConversion("Cost_Centre")%></h2>
                                    <p class="eprint-crm-section-subtitle"><%=CompanyType %> · <span class="eprint-crm-section-company"></span></p>
                                </div>
                                <div class="eprint-crm-section-hero-stats" aria-live="polite">
                                    <span class="eprint-crm-section-count">0</span>
                                    <span class="eprint-crm-section-count-label"><%=objLangClass.GetLanguageConversion("Cost_Centre")%></span>
                                </div>
                            </div>
                            <div class="eprint-crm-section-toolbar">
                                <div class="eprint-crm-section-search-wrap">
                                    <input type="search" class="eprint-crm-section-search" placeholder="Search cost centres on this page…" autocomplete="off" />
                                </div>
                                <div class="eprint-crm-section-actions">
                                    <button type="button" class="headerbutton white eprint-crm-section-btn-add"
                                        onclick="javascript:addNewCostcenter('costcentre','add','<%=ClientID %>');return false;">+ <%=objLangClass.GetLanguageConversion("Add_New_Cost_Centre")%></button>
                                    <button type="button" class="headerbutton white"
                                        onclick="var b=document.getElementById('<%=btn_ClearFilter_Costcenter.ClientID %>');if(b){b.click();} return false;">
                                        <%=objLangClass.GetLanguageConversion("Clear_All_Filters")%></button>
                                </div>
                            </div>
                            <div class="eprint-crm-section-body-card">
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                            <ContentTemplate>
                                <div>
                                    <div style="width: 60%; margin: 5px 0px 0px 10px">
                                        <asp:UpdatePanel ID="UpdatePanel7" RenderMode="Inline" runat="server">
                                            <ContentTemplate>
                                                <asp:PlaceHolder ID="plhCoceCEn" runat="server"></asp:PlaceHolder>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div id="div_popupActioncostcenter" style="display: none; z-index: 999999; position: absolute; margin: 36px 0px 0px 16px"
                                        onmouseover="show_costcenter();" onmouseout="hide_costcenter();">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <div style="width: 100%;">
                                                        <div class="divDropdownlist" style="padding-bottom: 7px; padding-top: 6px; width: 110px; border: 1px solid #8E8E8E;">
                                                            <asp:LinkButton ID="lnkDeletecostcentre" runat="server" Text="Delete Selected" OnClientClick="javascript:return CheckOne_new_costcenter('delete_costcenter');"
                                                                CommandName="Delete" OnClick="lnkdeletecostcentre_Onclick" Style="text-decoration: none;"
                                                                ForeColor="#333333" Font-Size="11px" CausesValidation="false"><%=objLangClass.GetLanguageConversion("Detele_Selected")%></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hdncostcenterids" runat="server" />
                                <div id="padding" style="width: 99%; margin-bottom: 20px; margin-top: -6px;">
                                    <telerik:RadGrid ID="grdcostcentre" runat="server" AllowPaging="true" AutoGenerateColumns="false"
                                        PagerStyle-AlwaysVisible="true" AllowAutomaticUpdates="false" PageSize="30" Width="99.5%" OnItemCommand="grdcostcenter_ItemCommand"
                                        OnItemDataBound="grdcostcenter_ItemDataBound" ShowStatusBar="true" OnNeedDataSource="grdcostcentre_NeedDataSource"
                                        AllowAutomaticDeletes="false" AllowAutomaticInserts="false" HeaderStyle-Font-Bold="true"
                                        AllowFilteringByColumn="true" GridLines="none" CssClass="AddBorders eprint-crm-section-grid" EnableEmbeddedSkins="true"
                                        HeaderStyle-ForeColor="#333333" HeaderStyle-BorderStyle="Double" BorderColor="White"
                                        FilterItemStyle-HorizontalAlign="Justify" Skin="Default" GroupingSettings-CaseSensitive="false">
                                        <AlternatingItemStyle BackColor="White" />
                                        <PagerStyle AlwaysVisible="true" Mode="NextPrevAndNumeric" Position="Bottom" />
                                        <MasterTableView DataKeyNames="CostCentreID" CommandItemDisplay="top">
                                            <CommandItemTemplate>
                                                <div style="border-bottom: 1px solid #C9C9C9; margin-top: 5px;">
                                                </div>
                                            </CommandItemTemplate>
                                            <CommandItemSettings ShowRefreshButton="false" RefreshText="" />
                                            <Columns>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Width="3%" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="left"
                                                    ItemStyle-Width="3%" UniqueName="checkBox_costcenter">
                                                    <HeaderTemplate>
                                                        <div id="div_checkBox_costcenter" style="float: left; display: block;">
                                                            <div id="div_chk_costcenter" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit; border-radius: 2px 2px 2px 2px">
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                    <tr>
                                                                        <td>
                                                                            <div style="float: left;">
                                                                                <input id="checkall_costcenter" runat="server" name="checkall_costcenter" onclick="checkAll_new_costcenter(this);"
                                                                                    type="checkbox" />
                                                                                <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <div style="float: left; padding: 0px 1px 0px 1px">
                                                                                <img src="<%=ImgPath %>ArrowDown.gif" id="img_actionsShow_costcenter" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                    onclick="show_costcenter();"
                                                                                    alt='' />
                                                                                <img src="<%=ImgPath %>ArrowUP.GIF" id="img_actionsHide_costcenter" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                    onclick="hide_costcenter();"
                                                                                    alt='' />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div style="clear: both;">
                                                            </div>
                                                        </div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input id="checkBox_costcenter" runat="server" name="Id" type="checkbox" onclick="CheckChanged_costcentre();"
                                                            value='<%# DataBinder.Eval(Container, "DataItem.CostCentreID", "{0}") %>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Code" HeaderStyle-HorizontalAlign="Left"
                                                    AutoPostBackOnFilter="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="16%"
                                                    HeaderStyle-Width="16%" FilterControlWidth="100px" DataField="CostCentreCode"
                                                    SortExpression="CostCentreCode" UniqueName="CostCentreCode" CurrentFilterFunction="Contains">
                                                    <ItemTemplate>
                                                        <a href="javascript:void(0);" onclick="javascript:EditCostcenter('costcentre','edit','<%=ClientID %>','<%# DataBinder.Eval(Container, "DataItem.CostCentreID", "{0}") %>');">
                                                            <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                <asp:Label ID="lblcode" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container,"DataItem.CostCentreCode","{0}"))%>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container,"DataItem.CostCentreCode","{0}"))%>'></asp:Label>
                                                            </div>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Name" HeaderStyle-HorizontalAlign="Left"
                                                    AutoPostBackOnFilter="true" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="14%"
                                                    HeaderStyle-Width="14%" FilterControlWidth="100px" DataField="CostCentreName"
                                                    UniqueName="CostCentreName" SortExpression="CostCentreName" CurrentFilterFunction="Contains">
                                                    <ItemTemplate>
                                                        <a href="javascript:void(0);" onclick="javascript:EditCostcenter('costcentre','edit','<%=ClientID %>','<%# DataBinder.Eval(Container, "DataItem.CostCentreID", "{0}") %>');">
                                                            <div style="float: left; width: 100%; overflow: hidden; height: 15px;">
                                                                <asp:Label ID="lblname" runat="server" Text='<%#basecls.SpecialDecode(DataBinder.Eval(Container,"DataItem.CostCentreName","{0}"))%>' ToolTip='<%#basecls.SpecialDecode(DataBinder.Eval(Container,"DataItem.CostCentreName","{0}"))%>'></asp:Label>
                                                            </div>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Default" ItemStyle-Width="10%" HeaderStyle-Width="10%"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" AllowFiltering="false">
                                                    <ItemTemplate>
                                                        <asp:Image runat="server" ID="img_Default" />
                                                        <asp:HiddenField ID="hdn_Default" runat="server" Value='<%#Eval("IsDefault")%>' />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" ItemStyle-Width="8%" HeaderStyle-Width="8%"
                                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                    <HeaderTemplate>
                                                        <div>
                                                            <asp:Label ID="lblaction" Text="" runat="server"><%=objLangClass.GetLanguageConversion("Action") %></asp:Label>
                                                        </div>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("CostCentreID")%>'
                                                            ToolTip="delete" OnCommand="Deletecostcenter_OnClick" OnClientClick="javascript:return window.confirm('Are you sure you want to delete this Cost Centre?');"
                                                            ImageUrl="~/Images/erase.png" />
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <NoRecordsTemplate>
                                                <div style="padding: 5px 0px 0px 10px">
                                                    <%=objLangClass.GetLanguageConversion("No_Records_Found") %>
                                                </div>
                                            </NoRecordsTemplate>
                                        </MasterTableView>
                                        <ClientSettings ReorderColumnsOnClient="false" EnableRowHoverStyle="true" AllowRowsDragDrop="false"
                                            AllowDragToGroup="false" Scrolling-AllowScroll="true">
                                            <Selecting AllowRowSelect="false" />
                                            <Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
                                            <Scrolling UseStaticHeaders="true" ScrollHeight="340" SaveScrollPosition="true" />
                                            <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                                        </ClientSettings>
                                    </telerik:RadGrid>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
                            <script type="text/javascript">
                                function RowDblClick(sender, eventArgs) {
                                    sender.get_masterTableView().editItem(eventArgs.get_itemIndexHierarchical());
                                }
                            </script>
                        </telerik:RadCodeBlock>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="float: right; vertical-align: bottom;">
                <div style="margin-top: -20px; margin-right: 15px; vertical-align: bottom;">
                    <asp:LinkButton ID="lblGoToTop" runat="server" Text="Go to top ↑" Style="color: #2358E2; font-size: 11px; vertical-align: bottom;"
                        OnClientClick="javascript:Gototop(); return false;">
                    </asp:LinkButton>
                </div>
            </div>
        </td>
        <td valign="top" style="width: 10px; border: 0px solid red;">
            <div style="border: 0px solid green; display: none; float: left; width: 100%; margin-top: 25px;">
                <asp:LinkButton ID="lnkRightArrow" runat="server" CssClass="imgrightarrow" Style="cursor: pointer;"
                    ToolTip="Hide Quick Actions" OnClientClick="javascript:HideQuickActions(); return false;"></asp:LinkButton>
                <asp:LinkButton ID="lnkLeftArrow" runat="server" CssClass="imgleftarrow" Style="cursor: pointer; display: none;"
                    ToolTip="Show Quick Actions" OnClientClick="javascript:ShowQuickActions(); return false;"></asp:LinkButton>
            </div>
        </td>
    </tr>
</table>
<asp:Label ID="lblNavigations" runat="server" Visible="false"></asp:Label>
<asp:HiddenField ID="hdntodaydate" runat="server" />
<asp:HiddenField ID="hdnCommanID" runat="server" />
<asp:HiddenField ID="hdnSectionName" runat="server" />
<asp:HiddenField ID="hdnActiveCrmTab" runat="server" Value="client" />
<asp:HiddenField ID="hdnbuttonid" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentID" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentType" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentID" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentType" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentIDDet" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentTypeDet" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentIDDet" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentTypeDet" runat="server" />
<asp:HiddenField ID="hdnDefaultTaskSubject" runat="server" Value="0" />
<asp:HiddenField ID="hdnDefaultCallSubject" runat="server" Value="0" />
<div id="divrad" style="display: none; position: absolute; border: 0px solid; z-index: 100; width: 50%"
    align="center">
    <telerik:RadWindowManager EnableShadow="false" ID="RadWindowManager1" DestroyOnClose="true"
        Opacity="100" runat="server" Width="500" Height="610" OnClientClose="RadWinClose"
        Behaviors="Close,Move,Reload,Resize">
    </telerik:RadWindowManager>
</div>
<asp:HiddenField runat="server" Value="" ID="hdnprintNotesValue" />
<asp:HiddenField runat="server" Value="" ID="hdnPrintCusDetailsWithAddress" />
<asp:HiddenField runat="server" Value="" ID="hdnPrintCusDetailsWithAllNotes" />
<asp:HiddenField runat="server" Value="" ID="hdnPrintCusDetailsWithDeptInfo" />
<asp:HiddenField runat="server" Value="" ID="AttID" />




<div id="ynnav" style="display: none;">
    <ul>
        <asp:UpdatePanel ID="up_ClientTabs" runat="server">
            <ContentTemplate>
                <li id="li_Client" style="cursor: pointer; float: left; clear: right;" onclick="javascript:getMainTabs('client','no');">
                    <div id="div_ClientTabs" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px;">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_ClientTab" runat="server" Style="color: Red;"><%=objLangClass.GetLanguageConversion("Summary_Information")%></asp:Label>
                                        <asp:LinkButton ID="lnk_ClientTab" runat="server" OnClick="lnk_ClientTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="up_DeptTabs" runat="server">
            <ContentTemplate>
                <li id="li_Depts" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('dept','no');">
                    <div id="div_DeptsTabs" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_DeptTab" runat="server"><%=objLangClass.GetLanguageConversion("Department")%></asp:Label>
                                        <asp:LinkButton ID="lnk_DeptTab" runat="server" OnClick="lnk_DeptTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="Up_costcentre" runat="server">
            <ContentTemplate>
                <li id="li_costcentre" runat="server" style="cursor: pointer; float: left; clear: right; display: none"
                    onclick="javascript:getMainTabs('costcentre','no');">
                    <div id="div_costcentretabs" runat="server" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lblcostcentretabs" runat="server"><%=objLangClass.GetLanguageConversion("Cost_Centre")%></asp:Label>
                                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="up_ContactsTabs" runat="server">
            <ContentTemplate>
                <li id="li_Contacts" style="cursor: pointer; float: left; clear: right;" onclick="javascript:getMainTabs('contacts','no');">
                    <div id="div_ContactsTabs" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_ContactTab" runat="server" Style="color: Black;"><%=objLangClass.GetLanguageConversion("Contacts")%></asp:Label>
                                        <asp:LinkButton ID="lnk_ContactTab" runat="server" OnClick="lnk_ContactTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="up_Address" runat="server">
            <ContentTemplate>
                <li id="li_Address" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('address','no');">
                    <div id="div_AddressTabs" runat="server" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_AddressTab" runat="server"><%=objLangClass.GetLanguageConversion("Address_Book")%></asp:Label>
                                        <asp:LinkButton ID="lnk_AddressTab" runat="server" OnClick="lnk_AddressTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="up_b2b" runat="server">
            <ContentTemplate>
                <li id="li_b2b" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('b2b','no');">
                    <div id="div_b2bTabs" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_b2bTab" runat="server"> <%=objLangClass.GetLanguageConversion("eStore")%> </asp:Label>
                                        <asp:LinkButton ID="lnk_b2bTab" runat="server" OnClick="lnk_b2bTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="up_Product" runat="server">
            <ContentTemplate>
                <li id="li_Products" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('products','no');">
                    <div id="div_ProductsTabs" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px;">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_ProductsTab" runat="server"> <%=objLangClass.GetLanguageConversion("Products")%> </asp:Label>
                                        <asp:LinkButton ID="lnk_ProductsTab" runat="server" OnClick="lnk_ProductsTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="up_Notes" runat="server">
            <ContentTemplate>
                <asp:HiddenField runat="server" Value="" ID="hdnPrintNotes" />
                <li id="li_Notes" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('notes','no');">
                    <div id="div_NotesTabs" runat="server" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_NotesTab" runat="server"> <%=objLangClass.GetLanguageConversion("Notes")%> </asp:Label>
                                        <asp:LinkButton ID="lnk_NotesTab" runat="server" OnClick="lnk_NotesTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="up_Emails" runat="server">
            <ContentTemplate>
                <li id="li_Emails" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('emails','no');">
                    <div id="div_EmailsTabs" runat="server" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_EmailsTab" runat="server"> <%=objLangClass.GetLanguageConversion("Email")%> </asp:Label>
                                        <asp:LinkButton ID="lnk_EmailsTab" runat="server" OnClick="lnk_EmailsTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdatePanel ID="up_CostCenter" runat="server">
            <ContentTemplate>
                <li id="liCostCenter" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('CostCenter','no');">
                    <div id="divCostCenter" runat="server" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="Label1" runat="server"> CostCenter </asp:Label>
                                        <asp:LinkButton ID="lnk_CostCenterTab" runat="server" OnClick="lnk_CostCenterTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>



        <asp:UpdatePanel ID="up_Activities" runat="server">
            <ContentTemplate>
                <li id="li_Activities" style="cursor: pointer; float: left; clear: right; display: block"
                    onclick="javascript:getMainTabs('activities','no','y');">
                    <div id="div_ActivitiesTabs" runat="server" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                        <table>
                            <tr>
                                <td>
                                    <b>
                                        <asp:Label ID="lbl_ActivitiesTab" runat="server"><%=objLangClass.GetLanguageConversion("Records")%></asp:Label>
                                        <asp:LinkButton ID="lnk_ActivitiesTab" runat="server" OnClick="lnk_ActivitiesTab_Click"></asp:LinkButton>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                </li>
            </ContentTemplate>
        </asp:UpdatePanel>
    </ul>
</div>
<script type="text/javascript" language="javascript">
    function ShowNoteAttachedFiles() {
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        var iframeAttachedFile = document.getElementById("ctl00_ContentPlaceHolder1_Client_Ifattachedfiles");
        iframeAttachedFile.setAttribute("src", "../crm_view_attached_files.aspx?&AID=" + AttID.value + "&CID=" + CompanyID + "");
    }

    function delete_Detailsnote() {
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        Closepopups();
        if (window.confirm('Are you sure you want to delete?')) {
            document.getElementById("DivNoteDetails").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
            document.getElementById("DivAddNotePopup").style.position = "absolute";
            CallDelete_NotesMethod(CompanyID, ClientIDTask, AttID.value, ''); return false;
            return true;
        }
        else {
            return false;
        }
    }

    function Edit_DetailsNotes() {
        Closepopups();
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        var left = (screen.width / 2) - (335 / 2);
        document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
        document.getElementById("DivBtnUpdateNotes").style.marginTop = "0px";
        document.getElementById("DivAddNotePopup").style.zIndex = "5555555555555";
        document.getElementById("DivAddNotePopup").style.position = "fixed";
        document.getElementById("DivAddNotePopup").style.left = left;
        document.getElementById("DivAddNotePopup").style.top = "17%";
        document.getElementById("DivAddNotePopup").style.display = "block";
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("DivTaskMain").style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').value = "";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').value = "";
        document.getElementById('divnotescontentvalidate').style.display = "none";
        document.getElementById("DivShowNote").style.display = "none";
        document.getElementById("AddNote").style.display = "block";
        document.getElementById("divNoteTitle").style.display = "block";
        document.getElementById("DivFileUpload1").style.display = "none";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById("DivBtnUpdateNotes").style.display = "none";
        document.getElementById("DivBtnUpdateAllNotes").style.display = "block";
        document.getElementById("DivCloseNoteTitle").style.display = "block";
        document.getElementById('rgarrow').style.display = "none";
        document.getElementById('lftarrow').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Edit Note";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById("DivNoteDetails").style.display = "none";
        document.getElementById("divUpload").style.display = "none";
        CallEdit_NotesMethod(AttID.value); return false;
    }

    function CloseNoteDetails() {
        document.getElementById("DivNoteDetails").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
    }
    function Notes_details(attachID) {
        Closepopups();
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        AttID.value = attachID;
        var left = (screen.width / 2) - (505 / 2);
        var top = (screen.height / 2) - (218 / 2);
        var result = $("#DivNoteDetails").css('height');
        document.getElementById("divallnotesbckfade").style.display = "block";
        document.getElementById("DivNoteDetails").style.display = "block";
        document.getElementById("DivNoteDetails").style.zIndex = "5555555555555";
        document.getElementById("DivNoteDetails").style.position = "fixed";
        document.getElementById("DivNoteDetails").style.left = left;
        document.getElementById("DivAddNotePopup").style.display = "none";
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("DivTaskMain").style.display = "none";
        document.getElementById("DivShowNote").style.display = "none";
        document.getElementById("AddNote").style.display = "block";
        document.getElementById("divNoteTitle").style.display = "block";
        document.getElementById("DivFileUpload1").style.display = "none";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById("DivBtnUpdateNotes").style.display = "none";
        document.getElementById("DivCloseNoteTitle").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_btnviewdetattachedfile").style.display = "block";
        CallEdit_NotesMethod(attachID); return false;
    }

    function Notes_detailsWithOutFile(attachID) {
        Closepopups();
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        AttID.value = attachID;
        document.getElementById("divallnotesbckfade").style.display = "block";
        document.getElementById("DivNoteDetails").style.display = "block";
        document.getElementById("DivNoteDetails").style.zIndex = "5555555555555";
        document.getElementById("DivNoteDetails").style.position = "fixed";
        document.getElementById("DivNoteDetails").style.left = "30%";
        document.getElementById("DivAddNotePopup").style.display = "none";
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("DivTaskMain").style.display = "none";
        document.getElementById("DivShowNote").style.display = "none";
        document.getElementById("AddNote").style.display = "block";
        document.getElementById("divNoteTitle").style.display = "block";
        document.getElementById("DivFileUpload1").style.display = "none";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById("DivBtnUpdateNotes").style.display = "none";
        document.getElementById("DivCloseNoteTitle").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_btnviewdetattachedfile").style.display = "none";
        CallEdit_NotesMethod(attachID); return false;
    }

    function GetScreenCordinatesAllEditNotes(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 4.3;
            p.y = p.y + obj.offsetParent.offsetTop - 8;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function Edit_Allnotes(attachID, btnid) {
        Closepopups();
        document.getElementById("DivAddNotePopup").style.zIndex = "5555555555555";
        document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
        document.getElementById("DivBtnUpdateNotes").style.marginTop = "0px";
        var txt = document.getElementById(btnid);
        var p = GetScreenCordinatesAllEditNotes(txt);
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("DivTaskMain").style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').value = "";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').value = "";
        document.getElementById('divnotescontentvalidate').style.display = "none";
        document.getElementById("DivShowNote").style.display = "none";
        document.getElementById("AddNote").style.display = "block";
        document.getElementById("divNoteTitle").style.display = "block";
        document.getElementById("DivFileUpload1").style.display = "none";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById("DivBtnUpdateNotes").style.display = "none";
        document.getElementById("DivCloseNoteTitle").style.display = "block";
        document.getElementById("DivBtnUpdateAllNotes").style.display = "block";
        document.getElementById('rgarrow').style.display = "none";
        document.getElementById('lftarrow').style.display = "block";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Edit Note";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById("DivAddNotePopup").style.position = "fixed";
        document.getElementById("DivAddNotePopup").style.left = "40%";
        document.getElementById("DivAddNotePopup").style.display = "block";
        document.getElementById("lftarrow").style.display = "none";
        var AttechMenID = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddnAttachID");
        AttechMenID.value = attachID;
        CallEdit_NotesMethod(attachID); return false;
    }
</script>
<script type="text/javascript" language="javascript">

    function CallSearchMethod() {

        Chk_Note = document.getElementById('<%=Chk_Note.ClientID %>');
        Chk_Call = document.getElementById('<%=Chk_Call.ClientID %>');
        Chk_Task = document.getElementById('<%=Chk_Task.ClientID %>');
        var SearchFreeText = document.getElementById('<%=txtallsearchcontant.ClientID%>').value;
        var SearchStartDate = document.getElementById('<%=txtsearchstartdate.ClientID%>').value;
        var SearchEndDate = document.getElementById('<%=txtsearchenddate.ClientID%>').value;

        if (SearchFreeText == '' && SearchStartDate == '' && SearchEndDate == '') {
            alert('Please enter a search term or select a date range.');
            return false;
        }

        if (Chk_Call.checked == false || Chk_Task.checked == false) {
            LoadClearpenActivityFilter(SectionID, CompanyID);
            LoadClearCloseActivityFilter(SectionID, CompanyID);
        }

        if (Chk_Note.checked || Chk_Call.checked || Chk_Task.checked) {
            if (Chk_Note.checked) {
                Call_NotesSearchMethod(CompanyID, ClientID, '', '', '', '', '');
                document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle").style.display = "block";
                if (Chk_Call.checked == false || Chk_Task.checked == false) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities").style.display = "none";
                    document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity").style.display = "none";
                }

            }
            if (Chk_Call.checked || Chk_Task.checked) {
                Call_OASearchMethod(CompanyID, ClientID, '', '', '', '', '', ''); // To get Opened calls and tasks
                Call_CASearchMethod(CompanyID, ClientID, '', '', '', '', '', '');     // To get Closed calls and tasks
                document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity").style.display = "block";
                if (Chk_Note.checked == false) {
                    document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle").style.display = "none";
                }
            }

            DisplayNoneAllContant();
            Open_closeTasknCall1();

            if (Chk_Note.checked == false) {
                LoadClearNotesFilter(CompanyID, SectionID);
            }

            return s = 1;
        }

        else if (SearchFreeText.value.length > 0 || SearchStartDate.value.length > 0 || SearchEndDate.value.length > 0) {
            Call_NotesSearchMethod(CompanyID, ClientID, '', '', '', '', '');
            Call_OASearchMethod(CompanyID, ClientID, '', '', '', '', '', ''); // To get Opened calls and tasks
            Call_CASearchMethod(CompanyID, ClientID, '', '', '', '', '', '');     // To get Closed calls and tasks
            //return s = 1;
        }
    }

    function GetScreenCordinatesNotePopups(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 4;
            p.y = p.y + obj.offsetParent.offsetTop - 3.7;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function OpenAddNotePopup(btnid) {
        //Notes save add loading image            
        document.getElementById("divallnotesbckfade").style.display = "block";

        document.getElementById('ctl00_ContentPlaceHolder1_Client_BtnNotesSave').style.display = 'block';
        document.getElementById('div_loading_BtnNotesSave').style.display = 'none';

        document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
        document.getElementById("DivEditCallPopup").style.position = "inherit";
        document.getElementById("DivAddNotePopup").style.display = "block";
        document.getElementById("DivAddNotePopup").style.position = "absolute";
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("DivTaskMain").style.display = "none";
        document.getElementById("DivAddNotePopup").style.left = "35%";
        document.getElementById("DivAddNotePopup").style.top = "18%";
        document.getElementById("DivAddNotePopup").style.position = "fixed";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').value = "";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').value = "";
        document.getElementById('divnotescontentvalidate').style.display = "none";
        document.getElementById('DivOldFile').style.display = "none";
        document.getElementById('DivUploFile').style.display = "block";
        document.getElementById('rgarrow').style.display = "none";
        document.getElementById('lftarrow').style.display = "none";
        document.getElementById('DivBtnNotesSave').style.display = "block";
        document.getElementById('DivBtnUpdateNotes').style.display = "none";
        document.getElementById('DivBtnUpdateAllNotes').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Add Note";
        document.getElementById('DivCloseBrowseFile').style.display = "block";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_file_upload').value = "";
        Load_AllDropdownlist(CompanyID, ClientIDTask);
        $('#addfileDiv').show();
        document.getElementById('divUpload').style.display = "none";
    }

    function CloseAddNotePopup() {
        document.getElementById("DivAddNotePopup").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
    }
</script>
<script type="text/javascript" language="javascript">
    function CloseOADetails() {
        document.getElementById("DivOpenActiDetails").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "none";
    }
</script>
<script type="text/javascript" language="javascript">
    function PrintCustomerInfoandAddress() {
        AutoFill.ReturnCustomerInfoWithMainContact(CompanyID, SectionID, CompanyType, onResponseMainCon);
    }
    function PrintCustomerInfowithDepartment() {
        AutoFill.ReturnCustomerInfoWithDeptInfo(CompanyID, SectionID, CompanyType, onResponseadd);
    }
    function PrintCustomerNamwithLocationMap() {
        var PageURL = sitePath + "MapWithDirections.aspx?clientid=" + SectionID + "&clna=" + CompanyCusName + "";
        var left = ((document.body.clientWidth) / 0) + "px";
        var top = ((document.body.clientHeight) / 0) + "px";
        window.open(PageURL, null, 'height=530, width=1100,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no, left=' + left + ' , top = ' + top + ' ');
    }
    function CustomerInfowithallNotes() {
        AutoFill.ReturnCustomerInfoWithAllNotes(CompanyID, SectionID, CompanyType, onResponsenotes);
    }

    function PrintCusnamewithlocationMap() {

        var PageURL = sitePath + "MapWithDirections.aspx?clientid=" + SectionID + "&clna=" + CompanyCusName + "";
        var left = ((document.body.clientWidth) / 0) + "px";
        var top = ((document.body.clientHeight) / 0) + "px";
        window.open(PageURL, null, 'height=530, width=1100,status= no, resizable= no, scrollbars=yes, toolbar=no,location=no,menubar=no, left=' + left + ' , top = ' + top + ' ');
    }

    function PrintCusDetailsWithDeptInfo(my_DIV) {
        AutoFill.ReturnCustomerInfoWithMainContact(CompanyID, SectionID, CompanyType, onResponseMainCon);
    }

    function onResponseMainCon(result) {
        var hdnPrintCusDetailsWithDeptInfo = document.getElementById("<%=hdnPrintCusDetailsWithDeptInfo.ClientID%>");
        hdnPrintCusDetailsWithDeptInfo.value = result;
        var ddnprintNote = document.getElementById("<%=hdnPrintCusDetailsWithDeptInfo.ClientID%>");
        var sStart = "<html><head>";
        var w = window.open('about:blank', 'printWin', 'width=1050,height=440,scrollbars=yes');
        var wdoc;
        try {
            wdoc = w.document;
            wdoc.open();
        } catch (e) {
            wdoc = w;
            wdoc = document.open();
        }
        wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
        wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");
        wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
        wdoc.writeln("<p>");
        wdoc.writeln(ddnprintNote.value);
        wdoc.writeln("</p>");
        wdoc.writeln("</div>");
        wdoc.writeln("</body></html>");
        wdoc.close();
        setTimeout(function () { w.print(); }, 1000);
    }

    function PrintCusDetailsWithAllNotes(my_DIV) {
        AutoFill.ReturnCustomerInfoWithAllNotes(CompanyID, SectionID, CompanyType, onResponsenotes);
    }

    function onResponsenotes(result) {
        var hdnPrintCusDetailsWithAllNotes = document.getElementById("<%=hdnPrintCusDetailsWithAllNotes.ClientID%>");
        hdnPrintCusDetailsWithAllNotes.value = result;
        var ddnprintNote = document.getElementById("<%=hdnPrintCusDetailsWithAllNotes.ClientID%>");
        var sStart = "<html><head>";
        var w = window.open('about:blank', 'printWin', 'width=1050,height=440,scrollbars=yes');
        var wdoc;
        try {
            wdoc = w.document;
            wdoc.open();
        } catch (e) {
            wdoc = w;
            wdoc = document.open();
        }

        wdoc.open();
        wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
        wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");
        wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
        wdoc.writeln("<p>");
        wdoc.writeln(ddnprintNote.value);
        wdoc.writeln("</p>");
        wdoc.writeln("</div>");
        wdoc.writeln("</body></html>");
        wdoc.close();
        setTimeout(function () { w.print(); }, 1000);
    }

    function PrintCusDetailsWithAddress(my_DIV) {
        AutoFill.ReturnCustomerInfoWithDeptInfo(CompanyID, SectionID, CompanyType, onResponseadd);
    }
    function onResponseadd(result) {
        var hdnPrintCusDetailsWithAddress = document.getElementById("<%=hdnPrintCusDetailsWithAddress.ClientID%>");
        hdnPrintCusDetailsWithAddress.value = result;
        var ddnprintNote = document.getElementById("<%=hdnPrintCusDetailsWithAddress.ClientID%>");
            var sStart = "<html><head>";
            var w = window.open('about:blank', 'printWin', 'width=1050,height=440,scrollbars=yes');

            var wdoc;
            try {
                wdoc = w.document;
                wdoc.open();
            } catch (e) {
                wdoc = w;
                wdoc = document.open();
            }
            wdoc.open();
            wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
            wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");
            wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
            wdoc.writeln("<p>");
            wdoc.writeln(ddnprintNote.value);
            wdoc.writeln("</p>");
            wdoc.writeln("</div>");
            wdoc.writeln("</body></html>");
            wdoc.close();
            setTimeout(function () { w.print(); }, 1000);
        }

</script>
<script type="text/javascript" language="javascript">
    function NextPreviousAlert() {
        alert("No more data to load");
    }
</script>
<script type="text/javascript" language="javascript">
    function SetContentWidth() {
        document.getElementById('ctl00_ContentPlaceHolder1_Client_DivRightPanel').style.width = '90%';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_DivRightPanel").style.minWidth = "90%";
        try {
            document.getElementById("DivclosedActivityTable").style.display = "none";
        } catch (e) {

        }
    }
    function DeleteAlert() {

        alert("Can not be delete default contact");
    }

    function SetContentWidthPopup() {
        document.getElementById('ctl00_ContentPlaceHolder1_Client_DivRightPanel').style.width = '90%';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_DivRightPanel").style.minWidth = "90%";
        try {
            document.getElementById("DivclosedActivityTable").style.display = "none";
        } catch (e) {

        }
        var btnID = "btndetails_0";
        Open_Activity_details(UniqueID, Types, btnID)
    }

</script>
<script type="text/javascript" language="javascript">
    var isTimeSelected = false;
    function DateSelected(sender, args) {

    }
    function ClientTimeSelected(sender, args) {
        isTimeSelected = true;
    }
    function showclosedtaskandcall() {
        document.getElementById("DivclosedActivityTable").style.display = "block";
        document.getElementById("hideclosedactivity").style.display = "block";
        document.getElementById("Showclosedactivity").style.display = "none";
    }

    function Hideclosedtaskandcall() {
        document.getElementById("DivclosedActivityTable").style.display = "none";
        document.getElementById("hideclosedactivity").style.display = "none";
        document.getElementById("Showclosedactivity").style.display = "block";
    }
</script>
<script type="text/javascript">
    function printNotes(my_DIV) {
        var ddnprintNote = document.getElementById("<%=hdnprintNotesValue.ClientID%>");

        var sStart = "<html><head>";
        var w = window.open('about:blank', 'printWin', 'width=1000,height=540,scrollbars=yes');
        var wdoc = w.document;
        wdoc.open();
        wdoc.writeln("<html><head><link href=\"../App_Themes/Theme1/item.css\" type=\"text/css\" rel=\"stylesheet\" /><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
        wdoc.writeln("</head><body style=\"background-image:none;background-color:white;\">");
        wdoc.writeln("<div style=\"direction: " + d + "; margin: 10px\">");
        wdoc.writeln("<p>");
        wdoc.writeln(ddnprintNote.value);
        wdoc.writeln("</p>");
        wdoc.writeln("</div>");
        wdoc.writeln("</body></html>");
        wdoc.close();
        w.print();
    }

    var SearchNotespageNummberIndex = 1;
    var SearchOApageNummberIndex = 1;
    var SearchCLpageNummberIndex = 1;
    function LoadMoreSearchNotesByJson() {
        LoadMoreSearchedNotes(CompanyID, SectionID, '', '', '', '', ''); return false;
    }

    function HideMoreSearchNotesByJson() {
        HideMoreSearchNotesByJs(CompanyID, SectionID, '', '', '', '', ''); return false;
    }

    function LoadAllSearchedNotesByJson() {
        document.getElementById("Divshowallnotes").style.position = "fixed";
        document.getElementById("Divshowallnotes").style.left = "12%";
        document.getElementById("Divshowallnotes").style.top = "10%";
        document.getElementById("Divshowallnotes").style.display = "block";
        document.getElementById("divallnotesbckfade").style.display = "block";
        LoadAll_SearchedNotes(CompanyID, SectionID, '', '', '', ''); return false;
    }

    function LoadMoreSearchedOpenActivityByJson() {
        LoadMoreSearched_OpenActivityByJson(SectionID, CompanyID, '', '', '', '', '', ''); return false;
    }

    function HideMoreSearchedOAByJson() {
        HideMoreSearched_OAByJson(SectionID, CompanyID, '', '', '', '', '', ''); return false;
    }

    function LoadAllSearchedOAByJsn() {
        document.getElementById("DicShowAllOpenActivities").style.position = "fixed";
        document.getElementById("DicShowAllOpenActivities").style.left = "12%";
        document.getElementById("DicShowAllOpenActivities").style.top = "10%";
        document.getElementById("DicShowAllOpenActivities").style.display = "block";
        document.getElementById("divallnotesbckfade").style.display = "block";
        LoadAllSearched_OAByJsn(SectionID, CompanyID, '', '', '', '', ''); return false;
    }

    function LoadMoreSearchedCloseActivityByJson() {
        LoadMoreSearched_CloseActivityByJson(SectionID, CompanyID, '', '', '', '', '', ''); return false;
    }

    function LoadHideSearchedCloseActivityByJson() {
        LoadHideSearched_CloseActivityByJson(SectionID, CompanyID, '', '', '', '', '', ''); return false;
    }

    function LoadMoreClSearchedbyJson() {
        document.getElementById("DicShowAllCl").style.position = "fixed";
        document.getElementById("DicShowAllCl").style.left = "12%";
        document.getElementById("DicShowAllCl").style.top = "10%";
        document.getElementById("DicShowAllCl").style.display = "block";
        document.getElementById("divallnotesbckfade").style.display = "block";
        LoadMoreClSearched_byJson(SectionID, CompanyID, '', '', '', '', ''); return false;
    }

    function Clearsearchfilter() {
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchstartdate").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtsearchenddate").value = "";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtallsearchcontant").focus();
        document.getElementById('<%=Chk_Note.ClientID %>').checked = false;
        document.getElementById('<%=Chk_Call.ClientID %>').checked = false;
        document.getElementById('<%=Chk_Task.ClientID %>').checked = false;
        LoadClearNotesFilter(CompanyID, SectionID);
        LoadClearpenActivityFilter(SectionID, CompanyID);
        LoadClearCloseActivityFilter(SectionID, CompanyID);
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle").style.display = "block";
        Open_closeTasknCall1();
        return C = 1;
    }

    var NotespageNummberIndex = 1;
    var NotespageNummberIndexOA = 1;
    var NotespageNummberIndexCL = 1;
    var NotespageNummberIndexCon = 1;
    function LoadMoreNotesByJson() {
        LoadMoreNotes(CompanyID, SectionID); return false;
    }

    function LoadMoreOpenActivityByJson() {
        LoadMoreOpenActivity(SectionID, CompanyID); return false;
    }

    function LoadMoreCloseActivityByJson() {
        LoadMoreCloseActivity(SectionID, CompanyID); return false;
    }

    function LoadMoreContactByJson() {
        LoadMoreContacts(SectionID, ''); return false;
    }

    function HideMoreNotesByJson() {
        HideMoreNotesByJs(CompanyID, SectionID); return false;
    }

    function HideMoreOAByJson() {
        HideMoreOAByJs(SectionID, CompanyID); return false;
    }

    function LoadHideCloseActivityByJson() {
        LoadHideCloseActivity(SectionID, CompanyID); return false;
    }

    function LoadHideContactByJson() {
        LoadHideContacts(SectionID, ''); return false;
    }

    function GetScreenCordinatesAllNotes(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft - 20;
            p.y = p.y + obj.offsetParent.offsetTop - 8;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function LoadAllNotesByJson(btnid, Count) {
        var txt = document.getElementById(btnid);
        var p = GetScreenCordinatesAllNotes(txt);
        document.getElementById("Divshowallnotes").style.position = "fixed";
        document.getElementById("Divshowallnotes").style.left = "12%";
        document.getElementById("Divshowallnotes").style.top = "10%";
        document.getElementById("Divshowallnotes").style.display = "block";
        document.getElementById("divallnotesbckfade").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lblnotecount").innerHTML = "(" + Count + ")";
        LoadAllNotes(CompanyID, ClientID); return false;
    }

    function LoadAllCAByJson(totalcount) {
        var lblClCounts = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblClCounts");
        lblClCounts.innerHTML = "(" + totalcount + ")";
        document.getElementById("DicShowAllCl").style.position = "fixed";
        document.getElementById("DicShowAllCl").style.left = "12%";
        document.getElementById("DicShowAllCl").style.top = "10%";
        document.getElementById("DicShowAllCl").style.display = "block";
        document.getElementById("divallnotesbckfade").style.display = "block";
        LoadAllClosedActivity(SectionID, CompanyID); return false;
    }

    function CloseAllClPopup() {
        document.getElementById("DicShowAllCl").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
    }

    function CloseAllnotesPopup() {
        document.getElementById("Divshowallnotes").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
    }

    function LoadAllOpenActiviesbyJsonss(totalcount) {
        var labelcount = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblopenActivityCount");
        labelcount.innerHTML = "(" + totalcount + ")";
        document.getElementById("DicShowAllOpenActivities").style.position = "fixed";
        document.getElementById("DicShowAllOpenActivities").style.left = "12%";
        document.getElementById("DicShowAllOpenActivities").style.top = "10%";
        document.getElementById("DicShowAllOpenActivities").style.display = "block";
        document.getElementById("divallnotesbckfade").style.display = "block";
        LoadAllOpenActivity(SectionID, CompanyID); return false;
    }

    function CloseAllOAPopup() {
        document.getElementById("DicShowAllOpenActivities").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
    }

    function UpdateCallValidationsNew() {
        var hdnCallID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID").value;
        var txtCallSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallSubject");
        var txtcallstartdate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallStartdate");
        var txtcallMinute = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallMin");
        var txtcallSecond = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallSec");
        var TxtHM = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker5").get_dateInput();
        var ddlEditCallDetails = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallDetails");
        ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].text;
        var ddlEditCallDetailsNew = ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].value;

        if (ddlEditCallDetailsNew == "2") {

        }
        else if (ddlEditCallDetailsNew == "3") {
            if (txtcallstartdate.value == '') {
                document.getElementById("span_txtcallstartdate").style.display = "block";
            }
        }
        if (txtCallSubject.value == '') {
            document.getElementById("span_EditCallSubject").style.display = "block";
        }
        if (TxtHM.get_value() == '') {
            document.getElementById("span_EditCallStartdate").style.display = "block";
            return true;
        }
        if (txtcallstartdate.value == '') {
            document.getElementById("span_EditCallStartdate").style.display = "block";
        }
        else {

            if (ValidateForm(txtcallstartdate, 'span_EditCallStartdate1', DateFormat) == false) {

            }
        }
        if (txtCallSubject.value != '' && txtcallstartdate.value != '') {
            Update_Call(hdnCallID, CompanyID, SectionID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserIDN, '', ''); return false;
        }
        else {
            SlideRightEditCallDiv();
        }
    }

    function UpdateCallValidations() {
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        var hdnCallID1 = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID").value;

        //        if (hdnCallID1 == "") {
        //            hdnCallID = AttID.value;
        //        }
        if (AttID != "") {
            hdnCallID = AttID.value;
        }
        else {
            var hdnCallID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID").value;
        }
        var ddlCallSubjectEdit = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubjectEdit");
        var txtcallstartdate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallStartdate");
        var txtcallMinute = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallMin");
        var txtcallSecond = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditCallSec");
        var TxtHM = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker5").get_dateInput();
        var ddlEditCallDetails = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallDetails");
        ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].text;
        var ddlEditCallDetailsNew = ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].value;
        var ddlEditowners = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditowner");

        if (ddlEditCallDetailsNew == "2") {

        }
        else if (ddlEditCallDetailsNew == "3") {
            if (txtcallstartdate.value == '') {
                document.getElementById("span_txtcallstartdate").style.display = "block";
                return true;
            }
        }
        if (ddlCallSubjectEdit.selectedIndex == -1) {
            document.getElementById("span_EditCallSubject").style.display = "block";
            return true;
        }
        if (TxtHM.get_value() == '') {
            document.getElementById("span_EditCallStartdate").style.display = "block";
            return true;
        }
        if (txtcallstartdate.value == '') {
            document.getElementById("span_EditCallStartdate").style.display = "block";
            return true;
        }
        else {

            if (ValidateForm(txtcallstartdate, 'span_EditCallStartdate1', DateFormat) == false) {
                return true;
            }
        }
        if (ddlEditowners.options.length == 0) {
            document.getElementById("dicEditAssigntoCall").style.display = "block";
            return true;
        }
        document.getElementById("divallnotesbckfade").style.display = "none";
        Update_Call(hdnCallID, CompanyID, SectionID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserIDN, '', ''); return false;
    }

    function ShowEditCallDetailType() {
        var ddlEditCallDetails = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditCallDetails");

        ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].text;
        var finalCallDetailType = ddlEditCallDetails.options[ddlEditCallDetails.selectedIndex].value;

        if (finalCallDetailType == "1") {
            document.getElementById("EditDurationStar").style.display = "none";
        }
        if (finalCallDetailType == "2") {
            document.getElementById("EditDurationStar").style.display = "block";
        }
        if (finalCallDetailType == "3") {
            document.getElementById("EditDurationStar").style.display = "none";
        }
    }

    function ShowCallDetailType() {
        var ddlCallDetailsType = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallDetailsType");
        ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].text;
        var finalCallType = ddlCallDetailsType.options[ddlCallDetailsType.selectedIndex].value;
        if (finalCallType == "1") {
            document.getElementById("DurationStar").style.display = "none";
            document.getElementById("DivCallTimer").style.display = "none";
            document.getElementById("DivCallStartTime").style.display = "block";
            document.getElementById("DivCallStartTime1").style.display = "block";
            document.getElementById("DivCallDuration").style.display = "block";
            document.getElementById("DivCallDuration1").style.display = "block";
            document.getElementById("Span_MinuteSecond").style.display = "none";
        }
        if (finalCallType == "2") {
            document.getElementById("DurationStar").style.display = "none";
            document.getElementById("DivCallTimer").style.display = "none";
            document.getElementById("DivCallStartTime").style.display = "block";
            document.getElementById("DivCallStartTime1").style.display = "block";
            document.getElementById("DivCallDuration").style.display = "block";
            document.getElementById("DivCallDuration1").style.display = "block";
            document.getElementById("Span_MinuteSecond").style.display = "none";
        }
    }
</script>
<script type="text/javascript" language="javascript">
    function GetScreenCordinatesNew1(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;

        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft - 29.8;
            p.y = p.y + obj.offsetParent.offsetTop - 2.5;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function GetScreenCordinates(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 1.5;
            p.y = p.y + obj.offsetParent.offsetTop - 2.7;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function Edit_OpenActivities(id, SectionName, btnid) {
        var txt = document.getElementById(btnid);
        var p = GetScreenCordinatesNew1(txt);
        var hdnTaskID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID");
        hdnTaskID.value = id;
        document.getElementById('DivAddNotePopup').style.display = "none";
        if (SectionName != "") {
            if (SectionName == "Task") {
                document.getElementById("ctl00_ContentPlaceHolder1_Client_Label119").innerHTML = "Edit Task";
                document.getElementById("DivEditCallPopup").style.display = "none";
                document.getElementById("span_EditMinuteSecond").style.display = "none";
                document.getElementById("span_EditMinuteSecond").style.display = "none";
                document.getElementById("Span_ddlEditsubject").style.display = "none";
                document.getElementById("Span_ddlEditassignto").style.display = "none";
                document.getElementById("span_ddlEditStataus").style.display = "none";
                document.getElementById("span_ddlEditPriority").style.display = "none";
                document.getElementById("span_txtEditDueDate").style.display = "none";
                document.getElementById("span_txtEditDueDate1").style.display = "none";
                document.getElementById("DivtaskEditSecond").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "block";
                document.getElementById("DivtaskPopUpEdit").style.position = "absolute";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton12").style.display = "block";
                document.getElementById("DivtaskEdit").style.display = "block";
                document.getElementById("DivCallSubjects").style.display = "none";
                if (p.x != 0 && p.y != 0) {
                    document.getElementById("DivtaskPopUpEdit").style.left = p.x;
                    document.getElementById("DivtaskPopUpEdit").style.top = p.y;
                }
                else {
                    document.getElementById("DivtaskPopUpEdit").style.left = "50%";
                    document.getElementById("DivtaskPopUpEdit").style.top = "50%";
                    document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton12").style.display = "none";
                }
                $('body,html').animate({ scrollTop: (p.y) }, 800);
                CallEdit_TaskMethod(CompanyID, ClientIDTask, id); return false;
            }
            else if (SectionName == "Call") {
                document.getElementById("ctl00_ContentPlaceHolder1_Client_Label120").innerHTML = "Edit Call";
                document.getElementById("DivEditCallTimerSecond").style.display = "none";
                document.getElementById("DivEditTaskSubject").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("span_EditCallSubject").style.display = "none";
                document.getElementById("span_EditCallStartdate").style.display = "none";
                document.getElementById("DivEditCallPopup").style.display = "block";
                document.getElementById("DivEditCallTimer").style.display = "block";
                document.getElementById("DivCallSubjects").style.display = "none";
                if (p.x != 0 && p.y != 0) {
                    document.getElementById("DivEditCallPopup").style.left = p.x;
                    document.getElementById("DivEditCallPopup").style.top = p.y;
                }
                else {
                    document.getElementById("DivEditCallPopup").style.left = "50%";
                    document.getElementById("DivEditCallPopup").style.top = "50%";
                    document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton18").style.display = "none";
                }
                $('body,html').animate({ scrollTop: (p.y) }, 800);
                Edit_CallMethod(CompanyID, ClientIDTask, id); return false;
            }
        }
    }


    function Edit_AllOpenActivities(id, SectionName) {
        var hdnTaskID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID");
        hdnTaskID.value = id;
        document.getElementById('DivAddNotePopup').style.display = "none";

        if (SectionName != "") {
            if (SectionName == "Task") {
                document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton12").style.display = "none";
                document.getElementById("DivEditCallPopup").style.display = "none";
                document.getElementById("span_EditMinuteSecond").style.display = "none";
                document.getElementById("span_EditMinuteSecond").style.display = "none";
                document.getElementById("Span_ddlEditsubject").style.display = "none";
                document.getElementById("Span_ddlEditassignto").style.display = "none";
                document.getElementById("span_ddlEditStataus").style.display = "none";
                document.getElementById("span_ddlEditPriority").style.display = "none";
                document.getElementById("span_txtEditDueDate").style.display = "none";
                document.getElementById("span_txtEditDueDate1").style.display = "none";
                document.getElementById("DivtaskEditSecond").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.position = "fixed";
                document.getElementById("DivtaskPopUpEdit").style.left = "32%";
                document.getElementById("DivtaskPopUpEdit").style.top = "5%";
                document.getElementById("DivtaskPopUpEdit").style.zIndex = "5555555555555";
                document.getElementById("DivtaskPopUpEdit").style.display = "block";
                document.getElementById("DivtaskEdit").style.display = "block";
                document.getElementById("DivCallSubjects").style.display = "none";
                CallEdit_TaskMethod(CompanyID, ClientIDTask, id); return false;
            }
            else if (SectionName == "Call") {
                document.getElementById("DivEditCallTimerSecond").style.display = "none";
                document.getElementById("DivEditTaskSubject").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("span_EditCallSubject").style.display = "none";
                document.getElementById("span_EditCallStartdate").style.display = "none";
                document.getElementById("DivEditCallPopup").style.position = "fixed";
                document.getElementById("DivEditCallPopup").style.left = "32%";
                document.getElementById("DivEditCallPopup").style.top = "5%";
                document.getElementById("DivEditCallPopup").style.zIndex = "5555555555555";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton18").style.display = "none";
                document.getElementById("DivEditCallPopup").style.display = "block";
                document.getElementById("DivEditCallTimer").style.display = "block";
                document.getElementById("DivCallSubjects").style.display = "none";
                Edit_CallMethod(CompanyID, ClientIDTask, id); return false;
            }
        }
    }

    function GetScreenCordinatesForDetails(obj) {
        var p = {};
        if (obj.offsetLeft != null) {
            p.x = obj.offsetLeft;
        }
        if (obj.offsetTop != null) {
            p.y = obj.offsetTop;
        }
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 9;
            p.y = p.y + obj.offsetParent.offsetTop - 18;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function Closed_Activity_details(id, SectionName, btnID) {
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        AttID.value = id;
        var txt = document.getElementById(btnID);
        var p = GetScreenCordinatesForDetails(txt);
        var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
        var hdnSectionName = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnSectionName");
        var hdnbuttonid = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnbuttonid");
        document.getElementById("divallnotesbckfade").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_btnmoreactionpopup").style.display = "none";
        hdnCommanID.value = id;
        hdnSectionName.value = SectionName;
        hdnbuttonid.value = btnID;
        var btnIDs = btnID.split('_');
        if (btnIDs[0] == "btnclosedetails") {

            document.getElementById("divbtncomplete").style.display = "none";
        }
        else {
            document.getElementById("divbtncomplete").style.display = "block";
        }
        var hdnTaskFollowParentIDDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentIDDet");
        var hdnTaskFollowParentTypeDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentTypeDet");
        hdnTaskFollowParentIDDet.value = id;
        hdnTaskFollowParentTypeDet.value = SectionName;
        var hdnCallFollowParentIDDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentIDDet");
        var hdnCallFollowParentTypeDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentTypeDet");
        hdnCallFollowParentIDDet.value = id;
        hdnCallFollowParentTypeDet.value = SectionName;

        if (SectionName != "") {
            if (SectionName == "Task") {
                document.getElementById("DivOpenActiDetails").style.display = "block";
                document.getElementById("DivOpenActiDetails").style.position = "fixed";
                document.getElementById("DivOpenActiDetails").style.left = "30%";
                document.getElementById("DivOpenActiDetails").style.top = "14%";
                document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";
                document.getElementById("DivEditCallPopup").style.display = "none";
                document.getElementById("DivtaskEditSecond").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivtaskEdit").style.display = "none";
                document.getElementById("DivCallSubjects").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelEdit").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "190px";
                CallEdit_TaskMethod(CompanyID, ClientIDTask, id); return false;
            }
            else if (SectionName == "Call") {
                document.getElementById("DivOpenActiDetails").style.position = "fixed";
                document.getElementById("DivOpenActiDetails").style.left = "30%";
                document.getElementById("DivOpenActiDetails").style.top = "14%";
                document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";
                document.getElementById("DivOpenActiDetails").style.display = "block";
                document.getElementById("DivEditCallTimerSecond").style.display = "none";
                document.getElementById("DivEditTaskSubject").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("span_EditCallStartdate").style.display = "none";
                document.getElementById("DivEditCallPopup").style.display = "none";
                document.getElementById("DivEditCallTimer").style.display = "none";
                document.getElementById("DivCallSubjects").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelEdit").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "190px";
                Edit_CallMethod(CompanyID, ClientIDTask, id); return false;
            }
        }
    }
    function Loadingpreocess_taskandcall() {
        document.getElementById("div_loadingtaskcall").style.display = "block";
    }
    function Open_Activity_details(id, SectionName, btnID) {
        asyncState = false;
        Loadingpreocess_taskandcall();
        debugger;
        try {
            document.getElementById("ctl00_ContentPlaceHolder1_Client_btnmoreactionpopup").style.display = "block";
        } catch (e) {

        }
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        AttID.value = id;
        var txt = document.getElementById(btnID);
        var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
        var hdnSectionName = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnSectionName");
        var hdnbuttonid = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnbuttonid");
        document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "none";
        hdnCommanID.value = id;
        hdnSectionName.value = SectionName;
        hdnbuttonid.value = btnID;
        var btnIDs = btnID.split('_');
        if (btnIDs[0] == "btnclosedetails") {

            document.getElementById("divbtncomplete").style.display = "none";
        }
        else {
            document.getElementById("divbtncomplete").style.display = "block";
        }

        var hdnTaskFollowParentIDDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentIDDet");
        var hdnTaskFollowParentTypeDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskFollowParentTypeDet");
        hdnTaskFollowParentIDDet.value = id;
        hdnTaskFollowParentTypeDet.value = SectionName;

        var hdnCallFollowParentIDDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentIDDet");
        var hdnCallFollowParentTypeDet = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCallFollowParentTypeDet");
        hdnCallFollowParentIDDet.value = id;
        hdnCallFollowParentTypeDet.value = SectionName;
        var left = (screen.width / 2) - (505 / 2);
        if (SectionName != "") {
            if (SectionName == "Task" || SectionName == "task") {
                document.getElementById("divallnotesbckfade").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton33").innerHTML = "Complete Task";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_Lnkedit").innerHTML = "Edit This Task";
                document.getElementById("DivOpenActiDetails").style.display = "block";
                document.getElementById("DivOpenActiDetails").style.position = "fixed";
                document.getElementById("DivOpenActiDetails").style.left = left;//  "30%";
                document.getElementById("DivOpenActiDetails").style.top = "22%";
                document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";
                document.getElementById("DivEditCallPopup").style.display = "none";
                document.getElementById("DivtaskEditSecond").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivtaskEdit").style.display = "none";
                document.getElementById("DivCallSubjects").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelEdit").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "0px";
                CallEdit_TaskMethod(CompanyID, ClientIDTask, id); return false;
            }
            else if (SectionName == "Call" || SectionName == "call") {
                document.getElementById("divallnotesbckfade").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton33").innerHTML = "Complete Call";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_Lnkedit").innerHTML = "Edit This Call";
                document.getElementById("DivOpenActiDetails").style.position = "fixed";
                document.getElementById("DivOpenActiDetails").style.left = left; // "30%";
                document.getElementById("DivOpenActiDetails").style.top = "22%";
                document.getElementById("DivOpenActiDetails").style.zIndex = "555555555555";
                document.getElementById("DivOpenActiDetails").style.display = "block";
                document.getElementById("DivEditCallTimerSecond").style.display = "none";
                document.getElementById("DivEditTaskSubject").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("span_EditCallStartdate").style.display = "none";
                document.getElementById("DivEditCallPopup").style.display = "none";
                document.getElementById("DivEditCallTimer").style.display = "none";
                document.getElementById("DivCallSubjects").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelEdit").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_btnDelDelete").style.marginLeft = "0px";
                Edit_CallMethod(CompanyID, ClientIDTask, id); return false;
            }
        }
    }
    function ClosePopupFromDashboard() {
        document.getElementById("DivOpenActiDetails").style.display = "none";
    }

    function ValidateUpdateTaskNew() {
        var hdnTaskID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID").value;
        var ddlEditsubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditsubject");
        var ddlEditassignto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditassignto");
        var ddlEditStataus = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditStataus");
        var ddlEditPriority = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditPriority");
        var txtEditDueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditDueDate");
        var ddlEdithour = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEdithour");
        var ddlEditminute = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditminute");
        var txtEditTaskDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditTaskDesc");
        var TxtHM = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker1").get_dateInput;

        if (ddlEditsubject.selectedIndex == 0) {
            document.getElementById("Span_ddlEditsubject").style.display = "block";
        }

        if (ddlEditStataus.selectedIndex == 0) {
            document.getElementById("span_ddlEditStataus").style.display = "block";
        }
        if (ddlEditPriority.selectedIndex == 0) {
            document.getElementById("span_ddlEditPriority").style.display = "block";
        }
        if (txtEditDueDate.value == '') {
            document.getElementById("span_txtEditDueDate").style.display = "block";
        }
        else {

            if (ValidateForm(txtEditDueDate, 'span_txtEditDueDate1', DateFormat) == false) {
            }
        }
        if (ddlEditsubject.selectedIndex != 0 && ddlEditStataus.selectedIndex != 0 && ddlEditPriority.selectedIndex != 0 && txtEditDueDate.value != '') {
            CallUpdate_TaskMethod(hdnTaskID, CompanyID, '', '', '', '', '', '', '', 'client', ClientIDTask, '', '', UserIDN, CreateddateN, ''); return false;
        }
        else {
            SlideEditRightDivTask();
        }
    }

    function ValidateUpdateTask() {
        var hdnTaskID = "";
        hdnTaskID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID").value;
        if (hdnTaskID == "") {
            var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
            hdnTaskID = hdnCommanID.value;
        }
        var ddlEditsubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditsubject");
        var ddlEditassignto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditassignto");
        var ddlEditStataus = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditStataus");
        var ddlEditPriority = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditPriority");
        var txtEditDueDate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditDueDate");
        var ddlEdithour = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEdithour");
        var ddlEditminute = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlEditminute");
        var txtEditTaskDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditTaskDesc");
        var TxtHM = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker1").get_dateInput();
        if (ddlEditsubject.selectedIndex == 0) {
            document.getElementById("Span_ddlEditsubject").style.display = "block";
        }
        if (ddlEditStataus.selectedIndex == 0) {
            document.getElementById("span_ddlEditStataus").style.display = "block";
        }
        if (ddlEditPriority.selectedIndex == 0) {
            document.getElementById("span_ddlEditPriority").style.display = "block";
        }
        if (TxtHM.get_value() == '') {
            document.getElementById("span_txtEditDueDate").style.display = "block";
            return true;
        }
        if (txtEditDueDate.value == '') {
            document.getElementById("span_txtEditDueDate").style.display = "block";
        }
        else {

            if (ValidateForm(txtEditDueDate, 'span_txtEditDueDate1', DateFormat) == false) {
                return true;
            }
        }
        if (ddlEditsubject.selectedIndex != 0 && ddlEditStataus.selectedIndex != 0 && ddlEditPriority.selectedIndex != 0 && txtEditDueDate.value != '') {
            document.getElementById("divallnotesbckfade").style.display = "none";
            CallUpdate_TaskMethod(hdnTaskID, CompanyID, '', '', '', '', '', '', '', 'client', ClientIDTask, '', '', UserIDN, CreateddateN, ''); return false;
        }
    }
</script>
<script type="text/javascript" language="javascript">
    var CompanyID = "<%=CompanyID %>";
    var SectionName = "<%=SectionName %>";
    var SectionID = "<%=SectionID %>";
    var UserIDN = "<%=UserIDN %>";
    var attachID = "<%=attachID %>";
    var CreateddateN = "<%=CreateddateN %>";
    var ClientIDTask = "<%=ClientIDTask %>";
    var DateFormat = "<%=DateFormat %>";
    var TodDate = "<%=TodDate %>";
    var CompanyType = "<%=CompanyType %>";
    var CompanyCusName = encodeURIComponent("<%=CompanyCusName %>");
    var UniqueID = "<%=UniqueID %>";
    var Types = "<%=Types %>";
</script>
<script type="text/javascript" language="javascript">
    function SelectContact(sub, hid) {
        document.getElementById("DivOpenContact").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_imgClearcontacts").style.display = "none";
        eval("document.forms[0][\'ctl00_ContentPlaceHolder1_Client_RadGridContact_ctl00_ctl04_hdnContactID'].value='" + hid + "'");
    }
</script>
<script type="text/javascript">
    function DeleteOldFile() {
        var Test = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFile").innerHTML = "";
        document.getElementById('DivOldFile').style.display = "none";
        document.getElementById('addfileDiv').style.display = "block";
        document.getElementById("DivUploFile").style.display = "block";
        document.getElementById("DivCloseBrowseFile").style.display = "block";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_file_upload').value = "";
    }

    function ValidateNotesFields() {

        var NotesFileUpload = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload");
        var FileName = NotesFileUpload.value;
        var txtnoteTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
        var divnotescontentvalidate = document.getElementById("divnotescontentvalidate");
        var diverrorNotesFileUpload = document.getElementById("diverrorNotesFileUpload");
        var SapnNotesFileUpload = document.getElementById("SapnNotesFileUpload");
        var Filename1 = document.getElementById('<%=file_upload.ClientID%>');
        var Name = Filename1.value;
        var File_Name = Name.replace(/^.*[\\\/]/, '');
        if (txtnoteTitle.value.trim().length > 0) {
            divnotescontentvalidate.style.display = 'none';
            ProgressBar();
            //Notes save add loading image            
            document.getElementById('ctl00_ContentPlaceHolder1_Client_BtnNotesSave').style.display = 'none';
            document.getElementById('div_loading_BtnNotesSave').style.display = 'block';
            document.getElementById("divallnotesbckfade").style.display = "none";
            CallInsert_NotesMethod(CompanyID, SectionName, ClientIDTask, File_Name, '', UserIDN, '', '', '', 0, 0); return false;
        }
        else {

            divnotescontentvalidate.style.display = 'block';
            return false;
        }
    }

    function UpdateValidateAllNotesFields() {
        var AttID = document.getElementById("ctl00_ContentPlaceHolder1_Client_AttID");
        var AttechMenID = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddnAttachID");
        if (AttID.value == "") {
            attachID = AttechMenID.value;
        }
        else {
            attachID = AttID.value;
        }

        var NotesFileUpload = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFile");
        var FileName = NotesFileUpload.innerHTML;
        var lblOldFileSize = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFileSize");
        var FileSize = lblOldFileSize.innerHTML;
        var txtnoteTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
        var divnotescontentvalidate = document.getElementById("divnotescontentvalidate");
        var diverrorNotesFileUpload = document.getElementById("diverrorNotesFileUpload");
        var SapnNotesFileUpload = document.getElementById("SapnNotesFileUpload");
        document.getElementById("DivOldFile").style.display = "none";
        document.getElementById("AddNote").style.display = "none";
        document.getElementById("DivShowNote").style.display = "block";
        //document.getElementById("DivAddNotePopup").style.display = "none";
        document.getElementById("DivAddNotePopup").style.position = "absolute";
        document.getElementById("divallnotesbckfade").style.display = "none";
        var Filename1 = document.getElementById('<%=file_upload.ClientID%>');
        var Name = Filename1.value;
        var File_Name = Name.replace(/^.*[\\\/]/, '');
        if (txtnoteTitle.value.trim().length > 0) {
            divnotescontentvalidate.style.display = 'none';
            if (File_Name == "") {
                ProgressBar();
                Call_UpdateAllNoteMethod(attachID, CompanyID, SectionName, ClientIDTask, FileName, '', UserIDN, '', '', '', 0); return false;
            }
            else {
                Call_UpdateAllNoteMethod(attachID, CompanyID, SectionName, ClientIDTask, File_Name, FileSize, UserIDN, '', '', '', 0); return false;
            }
        }
        else {
            divnotescontentvalidate.style.display = 'block';
            return false;
        }

    }

    function UpdateValidateNotesFields() {
        var AttechMenID = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddnAttachID");
        attachID = AttechMenID.value;
        var NotesFileUpload = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFile");
        var FileName = NotesFileUpload.innerHTML;
        var lblOldFileSize = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOldFileSize");
        var FileSize = lblOldFileSize.innerHTML;
        var txtnoteTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
        var divnotescontentvalidate = document.getElementById("divnotescontentvalidate");
        var diverrorNotesFileUpload = document.getElementById("diverrorNotesFileUpload");
        var SapnNotesFileUpload = document.getElementById("SapnNotesFileUpload");
        document.getElementById("DivOldFile").style.display = "none";
        document.getElementById("AddNote").style.display = "none";
        document.getElementById("DivShowNote").style.display = "block";
        document.getElementById("DivAddNotePopup").style.display = "none";
        var Filename1 = document.getElementById('<%=file_upload.ClientID%>');
        var Name = Filename1.value;
        var File_Name = Name.replace(/^.*[\\\/]/, '');
        if (txtnoteTitle.value.trim().length > 0) {
            divnotescontentvalidate.style.display = 'none';
            if (FileName == "") {
                Call_UpdateMethod(attachID, CompanyID, SectionName, SectionID, File_Name, '', UserIDN, '', '', '', 0); return false;
            }
            else {
                Call_UpdateMethod(attachID, CompanyID, SectionName, SectionID, File_Name, FileSize, UserIDN, '', '', '', 0); return false;
            }
        }
        else {
            divnotescontentvalidate.style.display = 'block';
            document.getElementById("DivAddNotePopup").style.display = "block";
            return false;
        }
    }

    function ClearContacts() {
        document.getElementById("ctl00_ContentPlaceHolder1_Client_imgClearcontacts").style.display = "none";
    }

    function Displayclearbutton() {
        var deleteimage = document.getElementById("ctl00_ContentPlaceHolder1_Client_ImgClearSubject");
        var ddlsubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlsubject");

        if (ddlsubject.selectedIndex != 0) {
            deleteimage.style.display = "none";
        }
        else {
            deleteimage.style.display = "none";
        }
    }

    function ClearSubjectDrop() {
        document.getElementById("ctl00_ContentPlaceHolder1_Client_ImgClearSubject").style.display = "none";
        var ddlsubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlsubject");
        ddlsubject.selectedIndex = 0;
    }

    function GetScreenCordinatesEditNotes(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft - 21.5;
            p.y = p.y + obj.offsetParent.offsetTop - 2.1;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function Edit_notes(attachID, btnid) {
        var txt = document.getElementById(btnid);
        var p = GetScreenCordinatesEditNotes(txt);
        Closepopups();
        document.getElementById("DivBtnNotesSave").style.marginTop = "0px";
        document.getElementById("DivBtnUpdateNotes").style.marginTop = "0px";
        if (p.x == 0 && p.y == 0) {
            document.getElementById("DivAddNotePopup").style.left = "50%";
            document.getElementById("DivAddNotePopup").style.top = "45%";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton24").style.display = "none";
        }
        else {
            document.getElementById("DivAddNotePopup").style.left = p.x;
            document.getElementById("DivAddNotePopup").style.top = p.y;
        }
        document.getElementById("DivAddNotePopup").style.position = "absolute";
        document.getElementById("DivAddNotePopup").style.display = "block";
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("DivTaskMain").style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').value = "";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').value = "";
        document.getElementById('divnotescontentvalidate').style.display = "none";
        $('body,html').animate({ scrollTop: (p.y - 20) }, 800);
        document.getElementById("DivShowNote").style.display = "none";
        document.getElementById("AddNote").style.display = "block";
        document.getElementById("divNoteTitle").style.display = "block";
        document.getElementById("DivFileUpload1").style.display = "none";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById("DivBtnUpdateNotes").style.display = "block";
        document.getElementById("DivCloseNoteTitle").style.display = "block";
        document.getElementById('rgarrow').style.display = "block";
        document.getElementById('lftarrow').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lblAddNoteTitle').innerHTML = "Edit Note";
        document.getElementById("DivBtnNotesSave").style.display = "none";
        document.getElementById('DivBtnUpdateAllNotes').style.display = "none";
        var AttechMenID = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddnAttachID");
        AttechMenID.value = attachID;
        CallEdit_NotesMethod(attachID); return false;
    }

    function ShowMoreNotes() {
        document.getElementById("DivlblNotesTitleHide").style.display = "block";
        document.getElementById("DivlblNotesTitle").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkHidemoreNotes").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkShowmoreNotes").style.display = "none";
    }

    function HideMoreNotes() {
        document.getElementById("DivlblNotesTitleHide").style.display = "none";
        document.getElementById("DivlblNotesTitle").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkShowmoreNotes").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_lnkHidemoreNotes").style.display = "none";
    }

    function delete_note(attachID) {
        Closepopups();
        if (window.confirm('Are you sure you want to delete?')) {
            document.getElementById("DivBtnNotesSave").style.display = "block";
            document.getElementById("DivBtnUpdateNotes").style.display = "none";
            document.getElementById("DivOldFile").style.display = "none";
            document.getElementById("DivUploFile").style.display = "block";
            CallDelete_NotesMethod(CompanyID, SectionID, attachID, ''); return false;
            return true;
        }
        else {
            return false;
        }
    }

    function deleteAll_Note(attachID) {
        Closepopups();
        if (window.confirm('Are you sure you want to delete?')) {
            document.getElementById("DivBtnNotesSave").style.display = "block";
            document.getElementById("DivBtnUpdateNotes").style.display = "none";
            document.getElementById("DivOldFile").style.display = "none";
            document.getElementById("DivUploFile").style.display = "block";
            CallAllDelete_NotesMethod(CompanyID, SectionID, attachID, ''); return false;
            return true;
        }
        else {
            return false;
        }
    }

    function CompleteCall(id, CompanyId, Clientid, SectionName) {
        if (window.confirm('Are you sure you want to Complete this Call?')) {
            var hdnTaskID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID");
            var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
            document.getElementById("DivEditCallPopup").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
            //            if (hdnTaskID.value == "") {
            //                hdnTaskID.value = hdnCommanID.value;
            //            }

            if (hdnCommanID.value == "") {
                hdnCommanID.value = hdnTaskID.value;
            }
            CallComplete_Method(hdnCommanID.value, CompanyID, ClientID, 'Call', ''); return false;
            return true;
        }
        else {
            return false;
        }
    }

    function CompleteTask() {
        if (window.confirm('Are you sure you want to complete this task?')) {
            var hdnTaskID = "";
            hdnTaskID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnTaskID").value;
            if (hdnTaskID == "") {
                var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
                hdnTaskID = hdnCommanID.value;
            }
            document.getElementById("DivtaskPopUpEdit").style.display = "none";
            document.getElementById("DivtaskEdit").style.display = "none";
            document.getElementById("divallnotesbckfade").style.display = "none";
            CallDelete_OpenActivitiesMethod(hdnTaskID, CompanyID, ClientID, 'Task', ''); return false;
            return true;
        }
        else {
            return false;
        }
    }

    function delete_OpenActivities(id, CompanyId, Clientid, SectionName) {
        if (SectionName == "Task") {
            if (window.confirm('Are you sure you want to complete this task?')) {
                CallDelete_OpenActivitiesMethod(id, CompanyId, Clientid, SectionName, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }
        else {

            if (window.confirm('Are you sure you want to delete?')) {
                CallDelete_OpenActivitiesMethod(id, CompanyId, Clientid, SectionName, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }
    }

    function Complete_Call(id, CompanyId, Clientid, SectionName) {
        if (window.confirm('Are you sure you want to Complete this Call?')) {
            CallComplete_Method(id, CompanyId, Clientid, SectionName, ''); return false;
            return true;
        }
        else {
            return false;
        }
    }

    function delete_CloseActivities(id, CompanyId, Clientid, SectionName) {
        if (window.confirm('Are you sure you want to delete?')) {
            CallDelete_CloseActivitiesMethod(id, CompanyId, Clientid, SectionName, ''); return false;
            return true;
        }
        else {
            return false;
        }
    }
    function GetScreenCordinatesEditDetails(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft - 89.5;
            p.y = p.y + obj.offsetParent.offsetTop + 18.4;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function Edit_TaskCallDetails(btnids) {
        document.getElementById("DivOpenActiDetails").style.display = "none";
        var hdnbuttonid = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnbuttonid");
        var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
        var hdnSectionName = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnSectionName");

        if (hdnSectionName.value != "") {
            if (hdnSectionName.value == "Task") {
                document.getElementById("div_loadingtask_onedit").style.display = "block";
                document.getElementById("DivEditCallPopup").style.display = "none";
                document.getElementById("span_EditMinuteSecond").style.display = "none";
                document.getElementById("span_EditMinuteSecond").style.display = "none";
                document.getElementById("Span_ddlEditsubject").style.display = "none";
                document.getElementById("Span_ddlEditassignto").style.display = "none";
                document.getElementById("span_ddlEditStataus").style.display = "none";
                document.getElementById("span_ddlEditPriority").style.display = "none";
                document.getElementById("span_txtEditDueDate").style.display = "none";
                document.getElementById("span_txtEditDueDate1").style.display = "none";
                document.getElementById("DivtaskEditSecond").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.position = "absolute";
                document.getElementById("DivtaskPopUpEdit").style.left = "35%";
                document.getElementById("DivtaskPopUpEdit").style.top = "30%";
                document.getElementById("DivtaskPopUpEdit").style.zIndex = "55555555";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton12").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "block";
                document.getElementById("DivtaskEdit").style.display = "block";
                document.getElementById("DivCallSubjects").style.display = "none";
                CallEdit_TaskMethod(CompanyID, ClientIDTask, hdnCommanID.value); return false;
            }
            else if (hdnSectionName.value == "Call") {
                document.getElementById("div_loadingcall_onedit").style.display = "block";
                document.getElementById("DivEditCallTimerSecond").style.display = "none";
                document.getElementById("DivEditTaskSubject").style.display = "none";
                document.getElementById("DivtaskPopUpEdit").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivOpenSubject").style.display = "none";
                document.getElementById("DivOpenContact").style.display = "none";
                document.getElementById("DivCallPopup").style.display = "none";
                document.getElementById("DivNotesPopup").style.display = "none";
                document.getElementById("span_EditCallSubject").style.display = "none";
                document.getElementById("span_EditCallStartdate").style.display = "none";
                document.getElementById("DivCallSubjects").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "none";
                document.getElementById("DivEditCallTimer").style.display = "block";
                document.getElementById("DivEditCallPopup").style.position = "absolute";
                document.getElementById("DivEditCallPopup").style.left = "35%";
                document.getElementById("DivEditCallPopup").style.top = "30%";
                document.getElementById("DivEditCallPopup").style.zIndex = "55555555";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton18").style.display = "none";
                document.getElementById("DivEditCallPopup").style.display = "block";
                Edit_CallMethod(CompanyID, ClientIDTask, hdnCommanID.value); return false;
            }
        }
    }

    function Complete_TaskCallDetails() {
        var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
        var hdnSectionName = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnSectionName");
        if (hdnSectionName.value == "Task") {
            if (window.confirm('Are you sure you want to complete this task?')) {
                document.getElementById("DivOpenActiDetails").style.display = "none";
                document.getElementById("divallnotesbckfade").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "none";
                CallDelete_OpenActivitiesMethod(hdnCommanID.value, CompanyID, ClientIDTask, hdnSectionName.value, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }
        else {

            if (window.confirm('Are you sure you want to complete this call?')) {
                document.getElementById("DivOpenActiDetails").style.display = "none";
                document.getElementById("divallnotesbckfade").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "none";
                CallComplete_Method(hdnCommanID.value, CompanyID, ClientIDTask, hdnSectionName.value, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }
    }

    function delete_TaskCallDetails() {
        var hdnCommanID = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnCommanID");
        var hdnSectionName = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnSectionName");
        if (hdnSectionName.value == "Task") {
            if (window.confirm('Are you sure you want to delete?')) {
                document.getElementById("DivOpenActiDetails").style.display = "none";
                document.getElementById("divallnotesbckfade").style.display = "none";
                document.getElementById("tbOpenActivities").style.display = "none";
                document.getElementById("SpntbOpenActivities").style.display = "none";
                delete_TaskMethod(hdnCommanID.value, CompanyID, ClientIDTask, hdnSectionName.value, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }
        else {

            if (window.confirm('Are you sure you want to delete?')) {
                document.getElementById("DivOpenActiDetails").style.display = "none";
                document.getElementById("divallnotesbckfade").style.display = "none";
                CallDelete_OpenActivitiesMethod(hdnCommanID.value, CompanyID, ClientIDTask, hdnSectionName.value, ''); return false;
                return true;
            }
            else {
                return false;
            }
        }
    }

    function delete_Task(id, CompanyId, Clientid, SectionName) {
        if (window.confirm('Are you sure you want to delete?')) {
            delete_TaskMethod(id, CompanyId, Clientid, SectionName, ''); return false;
            return true;
        }
        else {
            return false;
        }
    }

    function ViewAttachedFiles(attachID, CompanyID) {
        var iframeAttachedFile = document.getElementById("ctl00_ContentPlaceHolder1_Client_Ifattachedfiles");
        iframeAttachedFile.setAttribute("src", "../crm_view_attached_files.aspx?&AID=" + attachID + "&CID=" + CompanyID + "");
    }

    function DeleteNotes() {
        jConfirm('Are you sure you want to delete?', 'Confirm', function (r) {
            if (r == true) {

            }
        });
        return false;
    }

    function crmUpdateSitePath(sectionName) {
        var listView = 'client_view.aspx';
        var entityLabel = 'Customer';
        var detailsLabel = 'Customer Details';
        if (CompanyType == 'Supplier' || CompanyType == 'supplier') {
            listView = 'client_view.aspx?type=Supplier';
            entityLabel = 'Supplier';
            detailsLabel = 'Supplier Details';
        } else if (CompanyType == 'Prospect' || CompanyType == 'prospect') {
            listView = 'client_view.aspx?type=Prospect';
            entityLabel = 'Prospect';
            detailsLabel = 'Prospect Details';
        }
        var sitePathEl = document.getElementById("ctl00_header2_lblsitepath");
        if (sitePathEl) {
            sitePathEl.innerHTML = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='" + listView + "' class='subnavigatorblack' style='text-decoration:underline'>" + entityLabel + " View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;" + detailsLabel + " &gt; " + sectionName + "</b></span>";
        }
    }

    function crmCloseCrmPopups() {
        var divEdit = document.getElementById("DivEditCallPopup");
        if (divEdit) { divEdit.style.display = "none"; }
        var divNote = document.getElementById("DivAddNotePopup");
        if (divNote) { divNote.style.display = "none"; }
    }

    function OpeneRecordsDiv() {
        crmUpdateSitePath("Records");
        crmCloseCrmPopups();
        return crmNavigateTab("activities", "<%=lnk_ActivitiesTab.ClientID %>", "Records");
    }

    function OpeneEmailDiv() {
        crmUpdateSitePath("Emails");
        crmCloseCrmPopups();
        return crmNavigateTab("emails", "<%=lnk_EmailsTab.ClientID %>", "Emails");
    }

    var FromCRMProductLoad = false;

    function OpeneProductsDiv() {
        crmUpdateSitePath("Products");
        crmCloseCrmPopups();
        if (!FromCRMProductLoad && window.eprintCrmSections) {
            setTimeout(function () { window.eprintCrmSections.refresh("products"); }, 300);
        }
        var result = crmNavigateTab("products", "<%=lnk_ProductsTab.ClientID %>", "Products", FromCRMProductLoad);
        FromCRMProductLoad = false;
        return result;
    }

    var strSuc = '<%=strSuc %>';
    if (strSuc == 'products') {
        FromCRMProductLoad = true;
        OpeneProductsDiv();
    }

    function OpeneStoreDiv() {
        crmUpdateSitePath("eStore");
        crmCloseCrmPopups();
        return crmNavigateTab("b2b", "<%=lnk_b2bTab.ClientID %>", "eStore");
    }

    function crmUpdateAddressBreadcrumb() {
        var OldSitePath = '';
        var companyType = (typeof CompanyType !== "undefined") ? CompanyType : "";
        if (companyType == 'Customer' || companyType == 'customer') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Address Book</b></span>";
        }
        if (companyType == 'Supplier' || companyType == 'supplier') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Supplier' class='subnavigatorblack' style='text-decoration:underline'>Supplier View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Supplier Details > Address Book</b></span>";
        }
        if (companyType == 'Prospect' || companyType == 'prospect') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Prospect' class='subnavigatorblack' style='text-decoration:underline'>Prospect View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Prospect Details > Address Book</b></span>";
        }
        var sitePath = document.getElementById("ctl00_header2_lblsitepath");
        if (sitePath) {
            sitePath.innerHTML = OldSitePath;
        }
        window.crmUpdateAddressBreadcrumb = crmUpdateAddressBreadcrumb;
    }

    function OpenAddressBookDiv() {
        crmUpdateAddressBreadcrumb();
        var editCallPopup = document.getElementById("DivEditCallPopup");
        if (editCallPopup) { editCallPopup.style.display = "none"; }
        var addNotePopup = document.getElementById("DivAddNotePopup");
        if (addNotePopup) { addNotePopup.style.display = "none"; }
        return crmNavigateTab("address", "<%=lnk_AddressTab.ClientID %>", "Address Book");
    }

    function OpenContactDiv() {
        if (window.eprintCrmSections) {
            setTimeout(function () { window.eprintCrmSections.refresh("contacts"); }, 300);
        }
        return crmNavigateTab("contacts", "<%=lnk_ContactTab.ClientID %>", "Contacts");
    }

    function OpenCostCentreDiv() {
        var OldSitePath = '';
        if (CompanyType == 'Customer' || CompanyType == 'customer') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Cost Centres</b></span>";
        }
        if (CompanyType == 'Supplier' || CompanyType == 'supplier') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Supplier' class='subnavigatorblack' style='text-decoration:underline'>Supplier View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Supplier Details > Cost Centres</b></span>";
        }
        if (CompanyType == 'Prospect' || CompanyType == 'prospect') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Prospect' class='subnavigatorblack' style='text-decoration:underline'>Prospect View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Prospect Details > Cost Centres</b></span>";
        }
        document.getElementById("ctl00_header2_lblsitepath").innerHTML = OldSitePath;
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivAddNotePopup").style.display = "none";
        return crmNavigateTab("costcentre", "<%=lnk_CostCenterTab.ClientID %>", "Cost Centres");
    }

    function OpenClientDetailsDiv() {
        crmUpdateSummaryBreadcrumb();
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivAddNotePopup").style.display = "none";
        if (typeof crmtooltip === "function") {
            crmtooltip();
        }
        return crmNavigateTab("client", "<%=lnk_ClientTab.ClientID %>", "Summary Information");
    }

    function crmUpdateSummaryBreadcrumb() {
        var OldSitePath = '';
        if (CompanyType == 'Customer' || CompanyType == 'customer') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx' class='subnavigatorblack' style='text-decoration:underline'>Customer View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Customer Details > Summary Information</b></span>";
        }
        if (CompanyType == 'Supplier' || CompanyType == 'supplier') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Supplier' class='subnavigatorblack' style='text-decoration:underline'>Supplier View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Supplier Details > Summary Information</b></span>";
        }
        if (CompanyType == 'Prospect' || CompanyType == 'prospect') {
            OldSitePath = "<span class='navigatorpanelblack'><b><a href='../welcome.aspx' class='subnavigatorblack' style='text-decoration:underline'>Home</a>&nbsp;&gt;&nbsp;<a href='client_view.aspx?type=Prospect' class='subnavigatorblack' style='text-decoration:underline'>Prospect View</a></b></span><span class='navigatorpanelblack'><b>&nbsp;&gt;&nbsp;Prospect Details > Summary Information</b></span>";
        }
        var sitePath = document.getElementById("ctl00_header2_lblsitepath");
        if (sitePath) {
            sitePath.innerHTML = OldSitePath;
        }
    }

    function OpenDepartmentDiv() {
        return crmNavigateTab("dept", "<%=lnk_DeptTab.ClientID %>", "Departments");
    }

    function clearfilter_product() {
        var ClearFilter_Product = document.getElementById("ctl00_ContentPlaceHolder1_Client_ProductSubSection_lnk_ClearFilter_Product");
        if (ClearFilter_Product != null && ClearFilter_Product != undefined) {
            ClearFilter_Product.click();
        }
    }

    function clearfilter_email() {
        var clearfilter_email = document.getElementById("ctl00_ContentPlaceHolder1_Client_EmailsSubSection_RadGrid_Email_ctl00_ctl02_ctl00_lnk_ClearFilter_Email");
        if (clearfilter_email != null && clearfilter_email != undefined) {
            clearfilter_email.click();
        }
    }

    function clearfilter_Estimaterecord() {
        var lnk_ClearFilter_Estimate = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_EstimateSubSection_lnk_ClearFilter_Estimate");
        if (lnk_ClearFilter_Estimate != null && lnk_ClearFilter_Estimate != undefined) {
            lnk_ClearFilter_Estimate.click();
        }
    }

    function clearfilter_Jobrecord() {
        var lnk_ClearFilter_Job = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_JobsSubSection_lnk_ClearFilter_JObrecords");
        if (lnk_ClearFilter_Job != null && lnk_ClearFilter_Job != undefined) {
            lnk_ClearFilter_Job.click();
        }
    }

    function clearfilter_Invoicerecord() {
        var lnk_ClearFilter_Invoice = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_InvoicesSubSection_lnk_ClearFilter_Invoice");
        if (lnk_ClearFilter_Invoice != null && lnk_ClearFilter_Invoice != undefined) {
            lnk_ClearFilter_Invoice.click();
        }
    }

    function clearfilter_eStorerecord() {
        var lnk_ClearFilter_eStore = document.getElementById("ctl00_ContentPlaceHolder1_Client_ActivitiesSubSection_eStoreSubSection_lnk_ClearFilter_eStorerecords");
        if (lnk_ClearFilter_eStore != null && lnk_ClearFilter_eStore != undefined) {
            lnk_ClearFilter_eStore.click();
        }
    }

    function GetScreenCordinatesForMoreActions123(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 0;
            p.y = p.y + obj.offsetParent.offsetTop - 2;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }
    function GetScreenCordinatesForMoreActionsPopup(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft - 0;
            p.y = p.y + obj.offsetParent.offsetTop - 0;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }
    function OpenMoreActionsPopup(btnid) {
        var txt = document.getElementById(btnid);
        var p = GetScreenCordinatesForMoreActionsPopup(txt);
        document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.left = p.x;
        document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.top = p.y;
        document.getElementById("ctl00_ContentPlaceHolder1_Client_DivMoreActionForPopup").style.display = "block";
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivAddNotePopup").style.display = "none";
    }

    function CloseCallPopup() {
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
    }
    function OpenCallPopup(btnid) {
        // added loading image for ticket 13607
        var radTimePicker4 = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker4").get_dateInput();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_btnSaveCall').style.display = 'block';
        document.getElementById('div_loading_btnSaveCall').style.display = 'none';

        document.getElementById("divallnotesbckfade").style.display = "block";

        document.getElementById("ctl00_ContentPlaceHolder1_Client_Label118").innerHTML = "Add Call";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallDetailsType").selectedIndex = 1;
        radTimePicker4.set_value("10:00 AM");
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivOpenSubject").style.display = "none";
        document.getElementById("DivOpenContact").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "block";
        document.getElementById("MainDivCallTimer").style.display = "block";
        document.getElementById("DivCallPopup").style.left = "35%";
        document.getElementById("DivCallPopup").style.top = "22%";
        document.getElementById("DivCallPopup").style.position = "absolute";
        document.getElementById("MainDivCallTimerSecond").style.display = "none";
        document.getElementById("DivCallSubject_Validate").style.display = "none";
        document.getElementById("Span_MinuteSecond").style.display = "none";
        document.getElementById("DurationStar").style.display = "none";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubject").focus();
        ddlCallType = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallType").selectedIndex = 1;
        RdoCompletedCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoCompletedCall").checked = false;
        RdoScheduledCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoScheduledCall").checked = false;
        var txtcallstartdate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallstartdate");
        document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton6").style.display = "none";
        txtcallstartdate.value = TodDate;
        document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlcallHours").selectedIndex = 10;
        document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlcallMinute").selectedIndex = 0;
        txtcallMinute = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallMinute").value = '';
        txtcallSecond = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallSecond").value = '';
        txtcallresult = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallresult").value = '';
        txtCallDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallDesc").value = '';
        ChkBillable = document.getElementById("ctl00_ContentPlaceHolder1_Client_ChkBillable").checked = false;
        document.getElementById("DivCallTimer").style.display = "none";
        document.getElementById("DivCallStartTime").style.display = "block";
        document.getElementById("DivCallStartTime1").style.display = "block";
        document.getElementById("DivCallDuration").style.display = "block";
        document.getElementById("DivCallDuration1").style.display = "block";
        document.getElementById('DivAddNotePopup').style.display = "none";
        Load_AllDropdownlist(CompanyID, ClientIDTask, "call");
        var ddlCallSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubject");
        if (ddlCallSubject != null && ddlCallSubject != undefined) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnDefaultCallSubject").value != 0) {
                ddlCallSubject.value = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnDefaultCallSubject").value;
            } else {
                ddlCallSubject.value = 0;
                ddlCallSubject.selectedIndex = 0;
            }
        }
        $('body,html').animate({ scrollTop: (p.y - 20) }, 800);
    }

    function ValidateAddSubject() {
        var txtSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtSubject");
        if (txtSubject.value == '') {
            document.getElementById("DivSubjectAddValidations").style.display = "block";
        }
        if (txtSubject.value != '') {
            document.getElementById("DivSubjectAddValidations").style.display = "none";
            CallInsert_NotesSubjectMethod('', CompanyID, ''); return false;
        }
    }

    function ValidateAddCallSubject() {
        var txtCallSubjects = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects");
        if (txtCallSubjects.value == '') {
            document.getElementById("span_callsubj").style.display = "block";
        }
        else {
            document.getElementById("span_callsubj").style.display = "none";
            CallInsert_CallSubjectMethod(CompanyID, '', 'False', UserIDN); return false;
        }
    }

    function ValidateEditAddSubject() {
        var txtEditSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtEditSubject");

        if (txtEditSubject.value == '') {
            document.getElementById("DivEditSubjectAddValidations").style.display = "block";
        }
        if (txtEditSubject.value != '') {
            document.getElementById("DivEditSubjectAddValidations").style.display = "none";
            CallInsert_taskEditSubjectMethod('', CompanyID, ''); return false;
        }
    }

    function CallChkvalidate() {
        var ddlCallSubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallSubject").value;
        var RdoCompletedCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoCompletedCall");
        var RdoScheduledCall = document.getElementById("ctl00_ContentPlaceHolder1_Client_RdoScheduledCall");
        var txtcallstartdate = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallstartdate");
        var ddlcalltime = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlcalltime");
        var ddlCallDetailsType123 = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlCallDetailsType");
        ddlCallDetailsType123.options[ddlCallDetailsType123.selectedIndex].text;
        var CallDetailsType123 = ddlCallDetailsType123.options[ddlCallDetailsType123.selectedIndex].value;
        var txtcallMinute = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallMinute");
        var txtcallSecond = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtcallSecond");
        var ddlassignto = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlowner");
        var TxtHM = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker4").get_dateInput();

        var Proceed = true;
        var Proceed = ValidateDateTime(txtcallstartdate.value, TxtHM.get_value());  //To validate DATE And TIME

        if (ddlCallSubject.selectedIndex == 0 || ddlCallSubject == "") {
            document.getElementById("DivCallSubject_Validate").style.display = "block";
            return true;
        }
        if (CallDetailsType123 == "2") {
            if (TxtHM.get_value() == '') {
                document.getElementById("span_txtcallstartdate").style.display = "block";
                return true;
            }
            if (txtcallstartdate.value == '') {
                document.getElementById("span_txtcallstartdate").style.display = "block";
                return true;
            }
        }
        else if (CallDetailsType123 == "3") {
            if (TxtHM.get_value() == '') {
                document.getElementById("span_txtcallstartdate").style.display = "block";
                return true;
            }
            if (txtcallstartdate.value == '') {
                document.getElementById("span_txtcallstartdate").style.display = "block";
                return true;
            }
        }
        if (ddlassignto.options.length == 0) {
            document.getElementById("diverrorCallAssignTo").style.display = "block";
            return true;
        }

        DisplayNoneAllContant();
        if (Proceed == true) {
            // added loading image for ticket 13607            
            document.getElementById('ctl00_ContentPlaceHolder1_Client_btnSaveCall').style.display = 'none'
            document.getElementById('div_loading_btnSaveCall').style.display = 'block';
            document.getElementById("divallnotesbckfade").style.display = "none";
            Insert_Call(CompanyID, SectionID, '', '', '', '', '', '', '', '', '', '', '', '', '', UserIDN, '', '', '', 0);
            return false;
        }
    }


    function crmPrepareTab(tabKey, panelLabel, allowPostBack) {
        return window.crmPrepareTab(tabKey, panelLabel, allowPostBack);
    }

    function crmNavigateTab(tabKey, linkButtonClientId, panelLabel, skipLoading) {
        crmPrepareTab(tabKey, panelLabel, false);
        if (!skipLoading) {
            setTimeout("LoadImgStarts()", 0);
        }
        if (linkButtonClientId && crmFireTabClick(linkButtonClientId)) {
            return false;
        }
        if (linkButtonClientId) {
            return getMainTabs(tabKey, "yes");
        }
        return false;
    }

    function crmFireTabClick(tabButtonClientId) {
        var tabButton = document.getElementById(tabButtonClientId);
        if (tabButton) {
            tabButton.click();
            return true;
        }
        return false;
    }

    function getMainTabs(value, isfrompopup, jhu) {
        var lbl_ClientTab = document.getElementById("<%=lbl_ClientTab.ClientID %>");
        var lbl_ContactTab = document.getElementById("<%=lbl_ContactTab.ClientID %>");
        var lbl_DeptTab = document.getElementById("<%=lbl_DeptTab.ClientID %>");
        var lbl_AddressTab = document.getElementById("<%=lbl_AddressTab.ClientID %>");
        var lbl_b2bTab = document.getElementById("<%=lbl_b2bTab.ClientID %>");
        var lbl_ProductsTab = document.getElementById("<%=lbl_ProductsTab.ClientID %>");
        var lbl_NotesTab = document.getElementById("<%=lbl_NotesTab.ClientID %>");
        var lbl_EmailsTab = document.getElementById("<%=lbl_EmailsTab.ClientID %>");
        var lbl_ActivitiesTab = document.getElementById("<%=lbl_ActivitiesTab.ClientID %>");
        var lbl_CostCentreTab = document.getElementById("<%=lblcostcentretabs.ClientID %>");

        var CompanyType = '<%=CompanyType %>';
        var tabCookieKey = "CRMTabName" + (window.eprintCrmTabClientId || ClientID);
        document.cookie = tabCookieKey + "=" + value;
        var hdnTab = document.getElementById("<%=hdnActiveCrmTab.ClientID %>");
        if (hdnTab) {
            hdnTab.value = (value || "client").toLowerCase();
        }
        if (value == 'client') {
            setTimeout("LoadImgStarts()", 0);
            if (isfrompopup == 'yes') {
                ReadWindowClose(value);
            }
            crmFireTabClick("<%=lnk_ClientTab.ClientID %>");
            return false;
        }
        else if (value == 'dept') {
            setTimeout("LoadImgStarts()", 0);
            if (isfrompopup == 'yes') {
                ReadWindowClose(value);
            }
            crmFireTabClick("<%=lnk_DeptTab.ClientID %>");
            return false;
        }
        else if (value == 'contacts') {
            setTimeout("LoadImgStarts()", 0);
            if (isfrompopup == 'yes') {
                ReadWindowClose(value);
            }
            crmFireTabClick("<%=lnk_ContactTab.ClientID %>");
            return false;
        }
        else if (value == 'address') {
            setTimeout("LoadImgStarts()", 0);
            if (isfrompopup == 'yes') {
                ReadWindowClose(value);
            }
            crmFireTabClick("<%=lnk_AddressTab.ClientID %>");
            return false;
        }

        else if (value == 'b2b') {
            setTimeout("LoadImgStarts()", 0);
            crmFireTabClick("<%=lnk_b2bTab.ClientID %>");
            return false;
        }

        else if (value == 'products') {
            setTimeout("LoadImgStarts()", 0);
            crmFireTabClick("<%=lnk_ProductsTab.ClientID %>");
            return false;
        }
        else if (value == 'notes') {
            if (isfrompopup == 'yes') {
                setTimeout("LoadImgStarts()", 0);
                ReadWindowClose(value);
                crmFireTabClick("<%=lnk_NotesTab.ClientID %>");
            }
            crmFireTabClick("<%=lnk_NotesTab.ClientID %>");
            return false;
        }
        else if (value == 'emails') {
            setTimeout("LoadImgStarts()", 0);
            ReadWindowClose(value);
            crmFireTabClick("<%=lnk_EmailsTab.ClientID %>");
            return false;
        }
        else if (value == 'CostCenter') {
            setTimeout("LoadImgStarts()", 0);
            ReadWindowClose(value);
            crmFireTabClick("<%=lnk_CostCenterTab.ClientID %>");
            return false;
        }
        else if (value == 'activities') {
            setTimeout("LoadImgStarts()", 0);
            if (jhu != 'y') {
                crmFireTabClick("<%=lnk_ActivitiesTab.ClientID %>");
            }
            return false;
        }
    }

    function SetTabs(val, isfrompopup) {
        getMainTabs(val, isfrompopup);
    }

    function TakeOut() {
        window.close();
    }

    function ReadWindowClose(windowid) {
        var oWnd = GetRadWindowManager().GetWindowByName(windowid);
        if (oWnd != null && oWnd != undefined) {
            oWnd.Close();
        }
    }

    function Validatesavenotes() {
        var TxtHM = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker").get_dateInput();
        var ddlsubject = document.getElementById("<%=ddlsubject.ClientID%>").value;
        var ddlassigneto = document.getElementById("<%=ddlassigneto.ClientID%>");
        var ddlstatus = document.getElementById("<%=ddlstatus.ClientID%>");
        var ddlpriority = document.getElementById("<%=ddlpriority.ClientID%>");
        var txtduedate = document.getElementById("<%=txtduedate.ClientID%>");

        if (ddlsubject.selectedIndex == 0 || ddlsubject == "") {
            document.getElementById("spn_ddlsubject").style.display = "block";
            return true;
        }
        if (ddlstatus.selectedIndex == 0) {
            document.getElementById("Span_ddlstatus").style.display = "block";
        }
        if (ddlpriority.selectedIndex == 0) {
            document.getElementById("Span_ddlpriority").style.display = "block";
        }

        if (txtduedate.value == '') {
            document.getElementById("Span_txtduedate").style.display = "block";
        }
        else {

            if (ValidateForm(txtduedate, 'Span_txtduedate1', DateFormat) == false) {

            }
        }
        if (TxtHM.get_value() == '') {
            document.getElementById("Span_txtduedate").style.display = "block";
        }
        var Proceed = true;
        var Proceed = ValidateDateTime(txtduedate.value, TxtHM.get_value());

        if (ddlsubject.selectedIndex != 0 && ddlstatus.selectedIndex != 0 && ddlpriority.selectedIndex != 0 && txtduedate.value != '' && Date > txtduedate.value) {
            DisplayNoneAllContant();
            if (Proceed == true) {
                //added loading image for ticket 13607
                document.getElementById('ctl00_ContentPlaceHolder1_Client_btnsavetasks').style.display = 'none';
                document.getElementById('div_loading_btnsavetasks').style.display = 'block';
                document.getElementById("divallnotesbckfade").style.display = "none";
                CallInsert_TaskMethod(CompanyID, '', '', '', '', '', 0, '', 'client', ClientIDTask, '', 0, '', UserIDN, UserIDN, CreateddateN, CreateddateN, '', 0, '', '', 0);
                return false;
            }
        }
    }

    function SetDefaultContact(CompanyID, clientID, ContactID) {
        CallUpdate_Contact(CompanyID, clientID, ContactID, ''); return false;
    }
</script>

<script type="text/javascript">
    function CloseContactPopup() {
        document.getElementById("DivOpenContact").style.display = "none";
    }
    function OpenShowContactDiv() {
        document.getElementById("DivOpenSubject").style.display = "none";
        document.getElementById("DivOpenContact").style.display = "block";
    }
    function OpenSubjectDiv() {
        document.getElementById("DivOpenSubject").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtSubject").value = '';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtSubject").focus();
    }

    function GetScreenCordinatesForAddCallSubject(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 42;
            p.y = p.y + obj.offsetParent.offsetTop - 15;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function OpenCallSubjectDiv(btnid) {
        document.getElementById("DivCallSubjects").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects").value = '';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects").focus();
        document.getElementById("DivOpenSubject").style.display = "none";
        document.getElementById("DivCallSubjects").style.left = "40%";
        document.getElementById("DivCallSubjects").style.top = "42%";
    }

    function GetScreenCordinatesForEditCallSubject(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft - 23.8;
            p.y = p.y + obj.offsetParent.offsetTop - 14.5;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }
    function OpenEditCallSubjectDiv(btnid) {
        var txt = document.getElementById(btnid);
        var p = GetScreenCordinatesForEditCallSubject(txt);
        document.getElementById("DivCallSubjects").style.display = "block";
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects").value = '';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_txtCallSubjects").focus();
        document.getElementById("DivOpenSubject").style.display = "none";
        document.getElementById("DivCallSubjects").style.left = p.x;
        document.getElementById("DivCallSubjects").style.top = p.y;
    }

    function CloseTaskPopupAddSubject() {
        document.getElementById("DivOpenSubject").style.display = "none";
        document.getElementById("span_callsubj").style.display = "none";
    }
    function CloseCallPopupAddSubject() {
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("span_callsubj").style.display = "none";
    }
    function CloseTaskPopup() {
        document.getElementById("DivNotesPopup").style.display = "none";
        document.getElementById("divallnotesbckfade").style.display = "none";
    }
    function GetScreenCordinatesNew(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 3.8;
            p.y = p.y + obj.offsetParent.offsetTop - 2.7;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function GetScreenCordinatesCall(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 5.5;
            p.y = p.y + obj.offsetParent.offsetTop - 10.7;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    function OpenPopUp(btnid) {
        //added for ticket 13607 
        var radTimePicker = $find("ctl00_ContentPlaceHolder1_Client_RadTimePicker").get_dateInput();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_btnsavetasks').style.display = 'block'
        document.getElementById('div_loading_btnsavetasks').style.display = 'none'

        document.getElementById("divallnotesbckfade").style.display = "block";

        document.getElementById("ctl00_ContentPlaceHolder1_Client_Label113").innerHTML = "Add Task";
        document.getElementById("DivEditCallPopup").style.display = "none";
        document.getElementById("DivEditTaskSubject").style.display = "none";
        document.getElementById("DivtaskPopUpEdit").style.display = "none";
        document.getElementById("DivCallPopup").style.display = "none";
        document.getElementById("DivCallSubjects").style.display = "none";
        document.getElementById("DivNotesPopup").style.display = "block";
        document.getElementById("DivTaskMain").style.display = "block";
        document.getElementById("DivNotesPopup").style.left = "35%";
        document.getElementById("DivNotesPopup").style.top = "22%";
        document.getElementById("DivNotesPopup").style.position = "absolute";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_ddlassigneto').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_ddlstatus').selectedIndex = 4;
        document.getElementById('ctl00_ContentPlaceHolder1_Client_ddlpriority').selectedIndex = 3;
        var txtduedate = document.getElementById('ctl00_ContentPlaceHolder1_Client_txtduedate');
        document.getElementById("ctl00_ContentPlaceHolder1_Client_LinkButton2").style.display = "none";
        txtduedate.value = TodDate;
        radTimePicker.set_value("10:00 AM");
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNotesDesc').value = '';
        document.getElementById('spn_ddlsubject').style.display = "none";
        document.getElementById('DivSpan_ddlassigneto').style.display = "none";
        document.getElementById('Span_ddlstatus').style.display = "none";
        document.getElementById('Span_ddlpriority').style.display = "none";
        document.getElementById('Span_txtduedate').style.display = "none";
        document.getElementById('Span_txtduedate1').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_ImgClearSubject').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_imgClearcontacts').style.display = "none";
        document.getElementById('DivAddNotePopup').style.display = "none";
        var ddlsubject = document.getElementById("ctl00_ContentPlaceHolder1_Client_ddlsubject");
        Load_AllDropdownlist(CompanyID, ClientIDTask, "task");
        if (ddlsubject != null && ddlsubject != undefined) {
            if (document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnDefaultTaskSubject").value != 0) {
                ddlsubject.value = document.getElementById("ctl00_ContentPlaceHolder1_Client_hdnDefaultTaskSubject").value;
            } else {
                ddlsubject.value = 0;
                ddlsubject.selectedIndex = 0;
            }
        }
    }
</script>
<script type="text/javascript">
    $(function () {
        $(window).scroll(function () {
            if ($(this).scrollTop() != 0) {
                $('#toTop').fadeIn();
            } else {
                $('#toTop').fadeOut();
            }
        });

        $('#toTop').click(function () {
            $('body,html').animate({ scrollTop: 0 }, 800);
        });
    });
</script>

<script type="text/javascript">
    function EditNotes() {
        document.getElementById("DivShowNote").style.display = 'none';
        document.getElementById("DivCloseNoteTitle").style.display = 'none';
        document.getElementById("DivCloseBrowseFile").style.display = 'none';
        document.getElementById("DivBtnUpdateNotes").style.display = 'block';
        document.getElementById("DivBtnNotesSave").style.display = 'none';
        document.getElementById("AddNote").style.display = 'block';
        document.getElementById("divNoteTitle").style.display = 'block';
        var NitesTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesTitle");
        var NitesDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_lblNotesDescripitions");
        var txtnoteTitle = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtnoteTitle");
        var txtNoteDesc = document.getElementById("ctl00_ContentPlaceHolder1_Client_txtNoteDesc");
        txtnoteTitle.value = NitesTitle.innerHTML;
        txtNoteDesc.value = NitesDesc.innerHTML;
    }

    function HideEditDeleteButton(imgCounter) {
        document.getElementById("DeleteNotes_" + imgCounter).style.display = "none";
        document.getElementById("Seprator_" + imgCounter).style.display = "none";
        document.getElementById("EditNotes_" + imgCounter).style.display = "none";
    }
    function ShowEditDeleteButton(imgCounter) {
        document.getElementById("DeleteNotes_" + imgCounter).style.display = "block";
        document.getElementById("Seprator_" + imgCounter).style.display = "block";
        document.getElementById("EditNotes_" + imgCounter).style.display = "block";
    }

    function OpenBrowseFile() {
        document.getElementById('DivFileUpload1').style.display = "block";
        document.getElementById('DivCloseBrowseFile').style.display = "block";
        document.getElementById("DivOldFile").style.display = "none";
    }

    function CloseBrowseFile() {
        document.getElementById('DivCloseBrowseFile').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').focus();
        document.getElementById("diverrorNotesFileUpload").style.display = 'none';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload").value = '';
    }

    function CloseNoteTitle() {
        document.getElementById('DivCloseNoteTitle').style.display = "none";
        document.getElementById('divNoteTitle').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').focus();
    }

    function OpenAddnotesDetails() {
        document.getElementById('AddNote').style.display = "block";
        document.getElementById('DivShowNote').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').focus();
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtNoteDesc').value = '';
        document.getElementById('ctl00_ContentPlaceHolder1_Client_txtnoteTitle').value = '';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload").value = '';
        document.getElementById('divNoteTitle').style.display = "block";
        document.getElementById('DivFileUpload1').style.display = "none";
        document.getElementById('DivCloseNoteTitle').style.display = "none";
        document.getElementById('DivCloseBrowseFile').style.display = "none";
        document.getElementById("DivBtnUpdateNotes").style.display = 'none';
        document.getElementById("DivBtnNotesSave").style.display = 'block';
        document.getElementById("divnotescontentvalidate").style.display = 'none';
        document.getElementById("diverrorNotesFileUpload").style.display = 'none';
        document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesFileUpload").value = '';
        document.getElementById("DivUploFile").style.display = 'block';
    }

    function ShowDetails() {
        document.getElementById('ShowDivLeft').style.display = "block";
        document.getElementById('ShowDivRight').style.display = "block";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lnkShowdetail').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lnkHideDetails').style.display = "block";
    }

    function HideDetails() {
        document.getElementById('ShowDivLeft').style.display = "none";
        document.getElementById('ShowDivRight').style.display = "none";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lnkShowdetail').style.display = "block";
        document.getElementById('ctl00_ContentPlaceHolder1_Client_lnkHideDetails').style.display = "none";
    }
</script>

<script type="text/javascript" language="javascript">
    var CompanyID = '<%=CompanyID%>';
    var UserID = '<%=UserID%>';
    var CompanyType = '<%=CompanyType %>';
    var sitePath = '<%=nmsCommon.global.sitePath()%>';
    var ClientID = '<%=ClientID%>';
    var redirectFrom = '<%=redirectFrom.Replace("\\", "\\\\").Replace("'", "\\'") %>';
    if (redirectFrom != '') {
        getMainTabs(redirectFrom);
    }
    var AccountID = '<%=AccountID %>';
    var WebStorePathB2B = '<%=WebStorePathB2B %>';
    var WebStorePathB2C = '<%=WebStorePathB2C %>';
    var img_actionsShow = document.getElementById("img_actionsShow");
    var img_actionsHide = document.getElementById("img_actionsHide");
    var div_popupAction = document.getElementById("div_popupAction");
    var RadListBox_Contact = document.getElementById("ctl00_ContentPlaceHolder1_Client_ctl16_RadListBox_Contact");
    var img_actionsShow_Dept = document.getElementById("img_actionsShow_Dept");
    var img_actionsHide_Dept = document.getElementById("img_actionsHide_Dept");
    var div_popupActionDepartment = document.getElementById("div_popupActionDepartment");
    var RadListBox_Department = document.getElementById("<%=RadListBox_Department.ClientID %>");
    var IsConfirmDepts = document.getElementById("<%=IsConfirmDepts.ClientID %>");
    var img_actionsShow_Address = document.getElementById("img_actionsShow_Address");
    var img_actionsHide_Address = document.getElementById("img_actionsHide_Address");
    var div_popupActionAddress = document.getElementById("div_popupActionAddress");
    var RadListBox_Address = document.getElementById("<%=RadListBox_Address.ClientID %>");
    var div_ClientMain = document.getElementById("<%=div_ClientMain.ClientID %>");
    var div_ContactMain = document.getElementById("<%=div_ContactMain.ClientID %>");
    var div_DepartmentMain = document.getElementById("<%=div_DepartmentMain.ClientID %>");
    var div_AddressMain = document.getElementById("<%=div_AddressMain.ClientID %>");
    var div_b2bMain = document.getElementById("<%=div_b2bMain.ClientID %>");
    var div_ProductsMain = document.getElementById("<%=div_ProductsMain.ClientID %>");
    var div_NotesMain = document.getElementById("<%=div_NotesMain.ClientID %>");
    var div_EmailMain = document.getElementById("<%=div_EmailMain.ClientID %>");
    var div_ActivitiesMain = document.getElementById("<%=div_ActivitiesMain.ClientID %>");
    var div_CostcentreMain = document.getElementById("<%=div_CostcentreMain.ClientID %>");
    var div_ClientTabs = document.getElementById("div_ClientTabs");
    var div_ContactsTabs = document.getElementById("div_ContactsTabs");
    var div_DeptsTabs = document.getElementById("div_DeptsTabs");
    var plhCoceCEn = document.getElementById("plhCoceCEn");
    var div_DepartmentDelete = document.getElementById("div_DepartmentDelete");
    var hdnAttachmentID = document.getElementById("<%=hdnAttachmentID.ClientID %>");
    var strSitepath = '<%=strSitepath %>';
    var CompanyType = '<%=CompanyType %>';
    var The_department_has_a_contact_allocated_to_it = '<%=objLanguage.GetLanguageConversion("The_department_has_a_contact_allocated_to_it") %>';


    function addNewCostcenter(val, type, clientid, contactid) {
        if (type == 'add') {
            var RadWindow_Paid = window.radopen(strSitepath + "common/common_popup.aspx?type=moreCost&clientid=" + clientid + "&mode=add&pg=" + pg + "&CustomerName=" + CompanyCusName + "&companytype=" + CompanyType + "&Pgtype=" + pg + "&from=" + pg, '800', '400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            RadWindow_Paid.setSize(600, 300);
            RadWindow_Paid.center();
        }
    }

    function EditCostcenter(val, type, clientid, CostCentreID) {
        if (type == 'edit') {
            var RadWindow_Paid = window.radopen(strSitepath + "common/common_popup.aspx?type=moreCostEdit&clientid=" + clientid + "&CustomerName=" + CompanyCusName + "&&CostCentreID=" + CostCentreID + "&mode=edit&pg=" + pg + "&companytype=" + CompanyType + "&Pgtype=" + pg + "&from=" + pg, '800', '400', 'height=200', ' width=400');
            SetRadWindow('divrad', 'divBackGroundNew', '200');
            RadWindow_Paid.setSize(600, 300);
            RadWindow_Paid.center();
        }
    }

    var img_actionsHide_Notes = document.getElementById("img_actionsHide_Notes");
    var img_actionsShow_Notes = document.getElementById("img_actionsShow_Notes");
    var div_chk_Notes = document.getElementById("div_chk_Notes");
    var div_popupActionNotes = document.getElementById("div_popupActionNotes");
    var lbl_Subject = document.getElementById("ctl00_ContentPlaceHolder1_Client_NotesSubSection_dlist_Notes_ctl00_lbl_Subject");
</script>
<asp:Panel ID="pnl_MoreThan1Selected" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        function Defaultcontact_click() {
            alert("Please check only one row to set as default contact");
            return false;
        }
        Defaultcontact_click();

    </script>
</asp:Panel>
<asp:Panel ID="pnl_MoreThan1Selected_Dept" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">

        function Defaultcontact_click() {
            alert("Please check only one row to set as default contact");
            return false;
        }
        Defaultcontact_click();

    </script>
</asp:Panel>
<asp:Panel ID="pnl_MoreThan1Selected_Address" runat="server" Visible="false">
    <script type="text/javascript" language="javascript">
        function Defaultcontact_click() {
            alert("Please check only one row to set as post box address");
            return false;
        }
        Defaultcontact_click();
    </script>
</asp:Panel>

<script type="text/javascript" language="javascript">
    try {
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
    } catch (e) {

    }
    function changeSortDirection() {
        document.getElementById("div_Load").style.display = "none";
        __doPostBack('ctl00$ContentPlaceHolder1$Client$lnk_SortDirection', '')
        document.getElementById("div_Load").style.display = "block";
    }

    function getDeptID() {
        var ddl_deptList = document.getElementById("<%=ddl_deptList.ClientID %>");
        var hdn_assignedDeptID = document.getElementById("<%=hdn_assignedDeptID.ClientID %>");
        hdn_assignedDeptID.value = ddl_deptList.options[ddl_deptList.selectedIndex].value;
    }

    function callDept() {
        document.getElementById("div_DepartmentDelete").style.display = "none";
        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "block";
        document.getElementById("divBackGroundNew").style.display = "none";
        getDeptID();
    }

</script>

<script language="javascript" type="text/javascript">
    function CheckChanged_Dept() {
        var frm = document.forms[0];
        var boolAllChecked;
        boolAllChecked = true;

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkBox_Department') != -1)
                if (e.checked == false && (!e.disabled)) {
                    boolAllChecked = false;
                    break;
                }
        }

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_Dept') != -1) {
                if (boolAllChecked == false) {
                    e.checked = false;
                }
                else
                    e.checked = true;
                break;
            }
        }
    }

    function CheckChanged_Contact() {
        var frm = document.forms[0];
        var boolAllChecked;
        boolAllChecked = true;

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkBox_Contact') != -1)
                if (e.checked == false && (!e.disabled)) {
                    boolAllChecked = false;
                    break;
                }
        }

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll') != -1) {
                if (boolAllChecked == false) {
                    e.checked = false;
                }
                else
                    e.checked = true;
                break;
            }
        }
    }

    function CheckChanged_Address() {
        var frm = document.forms[0];
        var boolAllChecked;
        boolAllChecked = true;

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkBox_Address') != -1)
                if (e.checked == false && (!e.disabled)) {
                    boolAllChecked = false;
                    break;
                }
        }

        for (i = 0; i < frm.length; i++) {
            e = frm.elements[i];
            if (e.type == 'checkbox' && e.name.indexOf('checkAll_Address') != -1) {
                if (boolAllChecked == false) {
                    e.checked = false;
                }
                else
                    e.checked = true;
                break;
            }
        }
    }

    function hideDiv(val) {
        document.getElementById(val).style.display = "none";
        document.getElementById("divBackGroundNew").style.display = "none";
        return false;
    }

    $(document).click(function (event) {
        var txt = document.getElementById('AddNewCallnTask');
        var p = GetScreenCordinatesAddNotenCallPopups(txt);
        document.getElementById("ctl00_ContentPlaceHolder1_Client_AddCallnTask").style.left = p.x;
        document.getElementById("ctl00_ContentPlaceHolder1_Client_AddCallnTask").style.top = p.y;
        if (document.getElementById('ctl00_ContentPlaceHolder1_Client_AddCallnTask') != null) {
            if (isPlusclick == true) {
                document.getElementById('ctl00_ContentPlaceHolder1_Client_AddCallnTask').style.display = 'block';
            }
            else {
                document.getElementById('ctl00_ContentPlaceHolder1_Client_AddCallnTask').style.display = 'none';
            }
            isPlusclick = false;
        }
    });

    function StayonCallnTaskDiv() {
        isPlusclick = true;
    }

    var isPlusclick = false;
    $("#AddNewCallnTask").click(function (event) {
        var txt = document.getElementById('AddNewCallnTask');
        var p = GetScreenCordinatesAddNotenCallPopups(txt);
        document.getElementById("ctl00_ContentPlaceHolder1_Client_AddCallnTask").style.left = p.x;
        document.getElementById("ctl00_ContentPlaceHolder1_Client_AddCallnTask").style.top = p.y;
        if (document.getElementById('ctl00_ContentPlaceHolder1_Client_AddCallnTask') != null) {
            if (document.getElementById('ctl00_ContentPlaceHolder1_Client_AddCallnTask').style.display == 'block') {
                isPlusclick = false;
                document.getElementById('ctl00_ContentPlaceHolder1_Client_AddCallnTask').style.display = 'none';
            }
            else {
                isPlusclick = true;
                document.getElementById('ctl00_ContentPlaceHolder1_Client_AddCallnTask').style.display = 'block';
            }
            return;
        }
    });

    function GetScreenCordinatesAddNotenCallPopups(obj) {
        var p = {};
        p.x = obj.offsetLeft;
        p.y = obj.offsetTop;
        while (obj.offsetParent) {
            p.x = p.x + obj.offsetParent.offsetLeft + 5.3;
            p.y = p.y + obj.offsetParent.offsetTop - 1.0;
            if (obj == document.getElementsByTagName("body")[0]) {
                break;
            }
            else {
                obj = obj.offsetParent;
            }
        }
        return p;
    }

    var size = 1;
    var id = 0;
    function ProgressBar() {

        if (document.getElementById('ctl00_ContentPlaceHolder1_Client_file_upload').value != "") {

            document.getElementById("ctl00_ContentPlaceHolder1_Client_divProgress").style.display = "block";
            document.getElementById("divUpload").style.display = "block";
            id = setInterval("progress()", 2);

            return true;
        }

    }
    function progress() {

        size = size + 1;
        if (size > 279) {

            clearTimeout(id);

        }
        document.getElementById("ctl00_ContentPlaceHolder1_Client_divProgress").style.width = size + "pt";
        if (parseInt(size / 3) < 100) {
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lblPercentage").firstChild.data = parseInt(size / 3) + "%";
        }
    }
</script>

<script type="text/javascript">
    function Open_closeTasknCall1() {
        var OpenClosedrpval = document.getElementById("ctl00_ContentPlaceHolder1_Client_OpenCloseTasknCall");
        var finalOpenClosedrpval = OpenClosedrpval.options[OpenClosedrpval.selectedIndex].value;
        if (finalOpenClosedrpval == "CloseTasknCalls") {
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity").style.display = "block";
            document.getElementById("DivclosedActivityTable").style.display = "block";
        }
        if (finalOpenClosedrpval == "OpenTasknCalls") {
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lblcloseActivity").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_Client_lblOpenActivities").style.display = "block";
        }
    }


</script>
