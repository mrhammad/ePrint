<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="ePrint.header" %>


<%@ Register TagPrefix="crm" TagName="Resumesession" Src="~/Templates/ResumeSession.ascx" %>
<%@ Register TagPrefix="UC" TagName="Printcenter" Src="~/usercontrol/printcenter_leftpanel.ascx" %>
<%@ Register TagName="company_panel" TagPrefix="uc" Src="~/usercontrol/company_leftpanel.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<script src="<%=strSitepath %>js/jquery-1.7.2.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/approvalsystem.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/track.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/item/AutoFill.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/CRM_json.js?VN='<%=VersionNumber %>'" type="text/javascript"></script>
<script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber %>'" type="text/javascript"></script>
<script src="<%=strSitepath %>js/freshwidget.js?VN='<%=VersionNumber %>'" type="text/javascript"></script>



<script type="text/javascript">
    var EnableAdvancedCRM = "<%=EnableAdvancedCRM%>";
    var tabcolor = "<%=tabcolor%>";
    var headerforecolor = "<%=ActiveForecolor%>";
    var IsWebstore = "<%=IsWebstore%>";
    var GetRolesRight_SettingIcon = "<%=GetRolesRight_SettingIcon%>";
    var MISsettingHeight = "<%=MISsettingHeight%>";
    var eStoreSettingHeight = "<%=eStoreSettingHeight%>";
    var IsSettingTabDisplay = "<%=IsSettingTabDisplay%>";
    var IsReportsDisplay = "<%=IsReportsDisplay%>";
    var GetRolesRight_ReportIcon = "<%=GetRolesRight_ReportIcon %>";
    var Ink = '<%=objLanguage.GetLanguageConversion("Ink")%>';
    var ServerName = '<%=nmsConnectionClass.ConnectionClass.ServerName%>';
</script>



<asp:ScriptManagerProxy ID="smproxy" runat="server">
    <Services>
        <asp:ServiceReference Path="~/AutoFill.asmx" />
    </Services>
</asp:ScriptManagerProxy>

<asp:HiddenField ID="hdnSessionCntr" runat="server" Value="0" />
<asp:HiddenField ID="hdnClientID_FromHeader" runat="server" Value="0" />
<asp:HiddenField runat="server" Value="" ID="AttID" />
<asp:HiddenField ID="hdntodaydate_FromHeader" runat="server" />
<asp:HiddenField ID="hdnCommanID_FromHeader" runat="server" />
<asp:HiddenField ID="hdnSectionName_FromHeader" runat="server" />
<asp:HiddenField ID="hdnSectionID_FromHeader" runat="server" Value="0" />
<asp:HiddenField ID="hdnbuttonid_FromHeader" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentID_FromHeader" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentType_FromHeader" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentID_FromHeader" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentType_FromHeader" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentIDDet_FromHeader" runat="server" />
<asp:HiddenField ID="hdnTaskFollowParentTypeDet_FromHeader" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentIDDet_FromHeader" runat="server" />
<asp:HiddenField ID="hdnCallFollowParentTypeDet_FromHeader" runat="server" />
<asp:HiddenField ID="hdn_Type" runat="server" Value="" />
<asp:HiddenField ID="hdn_SelectedClientID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ContactID" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ModuleID_FromHeader" runat="server" Value="0" />
<asp:HiddenField ID="hdn_ModuleName_FromHeader" runat="server" Value="" />
<asp:HiddenField ID="hdn_SystemDateTime" runat="server" Value="" />
<asp:HiddenField ID="hdn_DefaultTaskSubjectID_FromHeader" runat="server" Value="0" />
<asp:HiddenField ID="hdn_DefaultCallSubjectID_FromHeader" runat="server" Value="0" />
 <asp:HiddenField ID="HiddenField1" runat="server" />


<link rel="stylesheet" type="text/css" href="<%=strSitepath%>App_Themes/Theme1/eprint-sidebar.css?VN=<%=VersionNumber%>" />

<div id="divDrpdwn" class="modern-nav-wrapper eprint-sidebar-host">
    <div id="eprintSidebar" class="eprint-sidebar" data-active-section="<%=Server.HtmlEncode(ActiveNavSection)%>">

        <div class="eprint-sidebar-brand">
            <div class="brand-row">
                <div class="brand-logo" title="<%=Server.HtmlEncode(SidebarCompanyDisplayName)%>"><%=Server.HtmlEncode(SidebarLogoText)%></div>
                <div>
                    <div class="brand-title"><%=Server.HtmlEncode(SidebarCompanyDisplayName)%></div>
                    <div class="brand-sub"><%=Server.HtmlEncode(SidebarProductBrandTagline)%></div>
                </div>
            </div>
        </div>

        <div class="eprint-sidebar-scroll">
            <div class="eprint-nav-label">Modules</div>
            <ul class="eprint-nav-list" id="ulDrpdwn">

                <asp:PlaceHolder ID="phNavDashboard" runat="server">
                <li class="eprint-nav-item" data-section="HOME">
                    <a class="eprint-nav-link eprint-nav-single" href="<%=nmsCommon.global.sitePath()%>dashboard.aspx">Dashboard</a>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavCrm" runat="server">
                <li class="eprint-nav-item" data-section="CLIENTS">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("CRM")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>client/client_view.aspx"><%=objLanguage.GetLanguageConversion("View_Customers")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>client/client_add.aspx?type=Customer"><%=objLanguage.GetLanguageConversion("Add_New_Customer")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>client/client_view.aspx?type=Supplier"><%=objLanguage.GetLanguageConversion("View_Suppliers")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>client/client_add.aspx?type=Supplier"><%=objLanguage.GetLanguageConversion("Add_New_Supplier")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>client/client_view.aspx?type=Prospect"><%=objLanguage.GetLanguageConversion("Prospect")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>client/client_add.aspx?type=Prospect"><%=objLanguage.GetLanguageConversion("Add_New_Prospect")%></a></li>
                        <asp:PlaceHolder ID="phNavCrmReports" runat="server">
                        <li class="eprint-nav-sub-nested"><a href="<%=nmsCommon.global.sitePath()%>client/client_report.aspx"><%=objLanguage.GetLanguageConversion("Customer")%> <%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        <li class="eprint-nav-sub-nested"><a href="<%=nmsCommon.global.sitePath()%>client/activity_callreport.aspx"><%=objLanguage.GetLanguageConversion("Call")%> <%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavEstimates" runat="server">
                <li class="eprint-nav-item" data-section="ESTIMATES">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Estimates")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>estimates/estimates_add.aspx?type=add"><%=objLanguage.GetLanguageConversion("Add_New")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>estimates/estimate_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                        <asp:PlaceHolder ID="phNavEstimateReports" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>Estimates/estimate_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavOrders" runat="server">
                <li class="eprint-nav-item" data-section="WebStoreorder">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Order")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>orders/order_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                        <asp:PlaceHolder ID="phNavOrderReports" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>orders/order_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavJobs" runat="server">
                <li class="eprint-nav-item" data-section="JOBS">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Jobs")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>jobs/job_add.aspx?type=add"><%=objLanguage.GetLanguageConversion("Add_New")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>Jobs/jobs_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                        <asp:PlaceHolder ID="phNavJobReports" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>Jobs/job_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavWarehouse" runat="server">
                <li class="eprint-nav-item" data-section="INVENTORY">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Warehouse")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>warehouse/inventory_add.aspx"><%=objLanguage.GetLanguageConversion("Add_New")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>warehouse/warehouse.aspx?type=inventory"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>Settings/inventory_settings.aspx"><%=objLanguage.GetLanguageConversion("View/Add Categories")%></a></li>
                        <li class="eprint-nav-sub-nested"><a href="<%=strSitepath%>warehouse/inventoryexport.aspx">Export</a></li>
                        <li class="eprint-nav-sub-nested"><a href="<%=strSitepath%>Settings/inventory_import.aspx">Import</a></li>
                        <li class="eprint-nav-sub-nested"><a href="<%=strSitepath%>Settings/inventory_adjustment.aspx">Mass Adjustment</a></li>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavInvoice" runat="server">
                <li class="eprint-nav-item" data-section="Invoices">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Invoice")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>invoice/invoices_add.aspx?type=add"><%=objLanguage.GetLanguageConversion("Add_new")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>Invoice/invoice_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                        <asp:PlaceHolder ID="phNavInvoiceReports" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>Invoice/invoice_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavPurchases" runat="server">
                <li class="eprint-nav-item" data-section="PURCHASES">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Purchases")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>Purchase/purchase_view.aspx"><%=objLanguage.GetLanguageConversion("View")%></a></li>
                        <asp:PlaceHolder ID="phNavPurchaseReports" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>Purchase/purchase_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavDelivery" runat="server">
                <li class="eprint-nav-item" data-section="DELIVERYNOTE">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Delivery")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>Delivery/delivery_view.aspx"><%=objLanguage.GetLanguageConversion("View")%></a></li>
                        <asp:PlaceHolder ID="phNavDeliveryReports" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>Delivery/delivery_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavProducts" runat="server">
                <li class="eprint-nav-item" data-section="PRODUCTCATALOGUE">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Products")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/PriceCatalogue.aspx"><%=objLanguage.GetLanguageConversion("View")%></a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/ProductCatalogueCategory.aspx?&mode=add">Categories</a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/OtherCost_webStore_View.aspx">Additional Options</a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/ProductCatalogueGroup.aspx?&mode=add">Additional Options Group</a></li>
                        <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/Pricecatalog_import.aspx">Import/Export</a></li>
                        <asp:PlaceHolder ID="phNavProductReports" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>common/productcatalogue_report.aspx">Reports</a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phNavSettings" runat="server">
                <li class="eprint-nav-item" data-section="Settings">
                    <button type="button" class="eprint-nav-link eprint-nav-toggle">
                        <span><%=objLanguage.GetLanguageConversion("Settings")%></span><span class="chevron">&#9654;</span>
                    </button>
                    <ul class="eprint-nav-sub">
                        <li><a href="<%=nmsCommon.global.sitePath()%>settings/settings.aspx">MIS Settings</a></li>
                        <asp:PlaceHolder ID="phNavStoreSettings" runat="server">
                        <li><a href="<%=nmsCommon.global.sitePath()%>StoreSettings/StoreSettings.aspx">eStore Settings</a></li>
                        </asp:PlaceHolder>
                    </ul>
                </li>
                </asp:PlaceHolder>

            </ul>
        </div>

        <div class="eprint-sidebar-footer">
            <div class="user-name"><%=Server.HtmlEncode(SidebarUserDisplayName)%></div>
            <div class="user-role"><%=Server.HtmlEncode(SidebarUserRoleDisplay)%></div>
            <a class="eprint-btn-logout" href="<%=nmsCommon.global.sitePath()%>logout.aspx"><%=objLanguage.GetLanguageConversion("Logout")%></a>
        </div>

    </div>
</div>

<script src="<%=strSitepath%>js/eprint-sidebar.js?VN=<%=VersionNumber%>" type="text/javascript"></script>
