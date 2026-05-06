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


<div id="divDrpdwn" class="modern-nav-wrapper">
    
<style type="text/css">
    /* 1. Global Reset */
    .modern-nav-wrapper, .modern-nav-wrapper nav, #ulDrpdwn {
        background: transparent !important;
        border: none !important;
        box-shadow: none !important;
        overflow: visible !important;
        list-style: none !important;
        padding: 0;
        margin: 0;
    }

    .modern-nav-wrapper {
        margin-top: 25px;
        margin-left: 15px;
        font-family: 'Segoe UI', Tahoma, sans-serif;
    }

    #ulDrpdwn {
        display: flex;
        flex-direction: column;
        gap: 8px;
    }

    /* 2. Main Menu Buttons - MATCHING YOUR TABLE HEADER */
    .nav-category {
        position: relative;
        /* Gradient matching the orange/red sunset in your image */
        background: #d35400; /* Fallback */
        background: linear-gradient(to bottom, #e67e22 0%, #c0392b 100%) !important;
        
        border: 1px solid #a03026 !important;
        border-radius: 4px;
        cursor: pointer;
        width: 145px; 
        transition: all 0.2s ease;
        display: flex;
        align-items: center;
        box-shadow: 0 2px 4px rgba(0,0,0,0.2);
        z-index: 10;
    }

    .category-header {
        width: 100%;
        padding: 10px 12px;
        font-weight: 700;
        color: #ffffff !important;
        font-size: 11px;
        text-transform: uppercase;
        letter-spacing: 0.5px;
        text-shadow: 1px 1px 2px rgba(0,0,0,0.3);
    }

    .nav-category:hover {
        /* Brightens slightly on hover */
        background: linear-gradient(to bottom, #f39c12 0%, #d35400 100%) !important;
        transform: translateX(5px);
        box-shadow: 0 4px 8px rgba(0,0,0,0.3);
        z-index: 9999;
    }

    /* 3. The Dropdown "Bridge" (Fixed Gap Logic) */
    .dropdown-content {
        display: none;
        position: absolute;
        left: 100%; 
        top: 0;
        /* The invisible bridge: ensures menu stays open while moving mouse */
        padding-left: 20px !important; 
        min-width: 210px;
        background: transparent !important;
        border: none !important;
        box-shadow: none !important;
    }

    /* 4. The Visible Sub-Menu Box (CLEAN WHITE) */
    .dropdown-content .menu-box {
        background-color: #ffffff !important;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-shadow: 5px 5px 15px rgba(0,0,0,0.2);
        padding: 5px 0;
        margin: 0;
        list-style: none;
    }

    /* 5. Sub-menu Links - REMOVING ALL BLUE BLOCKS */
    .dropdown-content .menu-box li a {
        background: #ffffff !important; /* Force white background */
        color: #333 !important;        /* Dark text for readability */
        padding: 8px 15px;
        text-decoration: none;
        display: block;
        font-size: 13px;
        font-weight: 500;
        transition: background 0.2s;
        border: none !important;
    }

    .dropdown-content .menu-box li a:hover {
        background-color: #f5f5f5 !important;
        color: #c0392b !important; /* Text turns Sunset Red on hover */
    }

    .nav-category:hover .dropdown-content {
        display: block;
    }

    .divider {
        height: 1px;
        background: #eee;
        margin: 5px 0;
    }
</style>

<nav class="modern-nav-wrapper">
    <ul id="ulDrpdwn">

        <li class="nav-category">
            <span class="category-header">Dashboard</span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>dashboard.aspx">Dashboard</a></li>                   
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("CRM")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>client/client_view.aspx"><%=objLanguage.GetLanguageConversion("View_Customers")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>client/client_add.aspx?type=Customer"><%=objLanguage.GetLanguageConversion("Add_New_Customer")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>client/client_view.aspx?type=Supplier"><%=objLanguage.GetLanguageConversion("View_Suppliers")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>client/client_add.aspx?type=Supplier"><%=objLanguage.GetLanguageConversion("Add_New_Supplier")%></a></li>

                    <li><a href="<%=nmsCommon.global.sitePath()%>client/client_view.aspx?type=Prospect"><%=objLanguage.GetLanguageConversion("Prospect")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>client/client_add.aspx?type=Prospect"><%=objLanguage.GetLanguageConversion("Add_New_Prospect")%></a></li>

                    <li class="nested-trigger">
                        <a href="#">Reports &rsaquo;</a>
                        <ul class="nested-menu menu-box">
                            <li><a href="<%=nmsCommon.global.sitePath()%>client/client_report.aspx"><%=objLanguage.GetLanguageConversion("Customer")%></a></li>
                            <li><a href="<%=nmsCommon.global.sitePath()%>client/activity_callreport.aspx"><%=objLanguage.GetLanguageConversion("Call")%></a></li>
                        </ul>
                    </li>
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Estimates")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>estimates/estimates_add.aspx?type=add"><%=objLanguage.GetLanguageConversion("Add_New")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>estimates/estimate_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Estimates/estimate_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Order")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>orders/order_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>orders/order_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Jobs")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>jobs/job_add.aspx?type=add"><%=objLanguage.GetLanguageConversion("Add_New")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Jobs/jobs_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Jobs/job_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Warehouse")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>warehouse/inventory_add.aspx"><%=objLanguage.GetLanguageConversion("Add_New")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>warehouse/warehouse.aspx?type=inventory"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Settings/inventory_settings.aspxy"><%=objLanguage.GetLanguageConversion("View/Add Categories")%></a></li>
                    <li class="nested-trigger">
                        <a href="#">Tools &rsaquo;</a>
                        <ul class="nested-menu menu-box">
                            <li><a href="<%=strSitepath%>warehouse/inventoryexport.aspx">Export</a></li>
                            <li><a href="<%=strSitepath%>Settings/inventory_import.aspx">Import</a></li>
                             <li><a href="<%=strSitepath%>Settings/inventory_adjustment.aspx">Mass Adjustment</a></li>
                        </ul>
                    </li>
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Invoice")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>invoice/invoices_add.aspx?type=add"><%=objLanguage.GetLanguageConversion("Add_new")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Invoice/invoice_view.aspx"><%=objLanguage.GetLanguageConversion("View_All")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Invoice/invoice_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Purchases")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>Purchase/purchase_view.aspx"><%=objLanguage.GetLanguageConversion("View")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Purchase/purchase_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                </div>
            </ul>
        </li>

        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Delivery")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>Delivery/delivery_view.aspx"><%=objLanguage.GetLanguageConversion("View")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>Delivery/delivery_report.aspx"><%=objLanguage.GetLanguageConversion("Reports")%></a></li>
                </div>
            </ul>
        </li>
        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Products")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/PriceCatalogue.aspx"><%=objLanguage.GetLanguageConversion("View")%></a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/ProductCatalogueCategory.aspx?&mode=add">Categories</a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/OtherCost_webStore_View.aspx">Additional Options</a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/ProductCatalogueGroup.aspx?&mode=add">Additional Options Group</a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>ProductCatalogue/Pricecatalog_import.aspx">Import/Export</a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>common/productcatalogue_report.aspx">Reports</a></li>
                </div>
            </ul>
        </li>
        <li class="nav-category">
            <span class="category-header"><%=objLanguage.GetLanguageConversion("Settings")%></span>
            <ul class="dropdown-content">
                <div class="menu-box">
                    <li><a href="<%=nmsCommon.global.sitePath()%>settings/settings.aspx">MIS Settings</a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>StoreSettings/StoreSettings.aspx">Store Settings</a></li>
                    <li><a href="<%=nmsCommon.global.sitePath()%>logout.aspx"><%=objLanguage.GetLanguageConversion("Logout")%></a></li>
                </div>
            </ul>
        </li>

    </ul>
</nav>
</div>
