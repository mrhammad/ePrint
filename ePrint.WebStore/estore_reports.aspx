<%@ page title="" language="C#" masterpagefile="~/templates/MasterPageDefault.master" autoeventwireup="true" CodeBehind="estore_reports.aspx.cs" Inherits="ePrint.WebStore.estore_reports" enableEventValidation="false" viewStateEncryptionMode="Never" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <%--<asp:ScriptManager ID="scriptmanager" runat="server"></asp:ScriptManager>--%>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdateInitiatorPanelsOnly="true">
        <ClientEvents OnRequestStart="mngRequestStarted" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid_Order_Report">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_Order_Report" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="export">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_Order_Report" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnOrderReportGo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_Order_Report" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid_CustomerJobReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_CustomerJobReport" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btJobGo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_CustomerJobReport" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="export_productsales">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_CustomerJobReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGridReports_salesorderreport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridReports_salesorderreport" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="export_salesorder">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridReports_salesorderreport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadStockUsage_Packs_stockusagereport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs_stockusagereport" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="export_stockusage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs_stockusagereport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid_StockUsageReport_bymonthandyear">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_StockUsageReport_bymonthandyear" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="export_bymonthandyear">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_StockUsageReport_bymonthandyear" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGridProductReport_Customer_stockadjustment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_Customer_stockadjustment"
                        LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="export_stock_adjustment">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_Customer_stockadjustment" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnProductGo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridProductReport_Customer_stockadjustment"
                        LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="GridProductReport_quarterlysales">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridProductReport_quarterlysales" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="RadStockUsage_Packs">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>

             <telerik:AjaxSetting AjaxControlID="RadGrid_StockUsageHistoryReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_StockUsageHistoryReport" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="export_quarterlysales">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GridProductReport_quarterlysales" />
                </UpdatedControls>
            </telerik:AjaxSetting> 

             <telerik:AjaxSetting AjaxControlID="export_StockUsage_Packs">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadStockUsage_Packs" />
                </UpdatedControls>
            </telerik:AjaxSetting> 

             <telerik:AjaxSetting AjaxControlID="export_stockusagehistory">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_StockUsageHistoryReport" />
                </UpdatedControls>
            </telerik:AjaxSetting> 

            <telerik:AjaxSetting AjaxControlID="export_stock_allocatedreport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_stockallocatedcsutomer_new"  />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnProductGo">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_stockallocatedcsutomer_new"
                        LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid_stockallocatedcsutomer_new">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid_stockallocatedcsutomer_new" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="grid_reports_byreportid_order">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_order" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_order_datefilter_go">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_order" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Imgbtn_exporttoexcel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_order" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grid_reports_byreportid_jobs">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_jobs" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_job_datefilter_go">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_jobs" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Imgbtn_exporttoexcel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_jobs" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grid_reports_byreportid_invoice">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_invoice" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btn_invoice_datefilter_go">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_invoice" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Imgbtn_exporttoexcel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_invoice" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="grid_reports_byreportid_product">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_product" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="Imgbtn_exporttoexcel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="grid_reports_byreportid_product" LoadingPanelID="RadAjaxLoadingPanel" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <%--//--%>
    <%--<script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script> 
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>   
    <script type="text/javascript" src="<%=strSitepath %>js/product_item.js?VN='<%=VersionNumber%>'"></script>
    <script src="../js/jquery-1.7.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/jquery-ui.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>--%>
    <script type="text/javascript" language="javascript">

        function mngRequestStarted(sender, eventArgs) {

            if (eventArgs.EventTarget.indexOf("export") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_productsales") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_salesorder") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_stockusage") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_bymonthandyear") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_stock_adjustment") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_quarterlysales") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_StockUsage_Packs") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("export_stockusagehistory") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("btnOrderReportGo") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("btJobGo") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("btnUsageReportGo") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("btnProductGo") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("btn_job_datefilter_go") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("btn_order_datefilter_go") != -1) {
                eventArgs.set_enableAjax(false);
            }
            if (eventArgs.EventTarget.indexOf("btn_invoice_datefilter_go") != -1) {
                eventArgs.set_enableAjax(false);
            }
        }

        var column = null;
        function MenuShowing(sender, args) {

            if (column == null) return;
            var menu = sender; var items = menu.get_items();
            if (column.get_dataType() == "System.Decimal" || column.get_dataType() == "System.Int32") {
                var i = 0;
                while (i < items.get_count()) {
                    if (!(items.getItem(i).get_value() in { 'NoFilter': '', 'EqualTo': '', 'GreaterThan': '', 'LessThan': '' })) {
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
            menu.repaint();
        }
        function filterMenuShowing(sender, eventArgs) {

            column = eventArgs.get_column();
        }

        function GetParticularSelectedDepatmentID(ID) {
            var ddlDepartmentID = document.getElementById(ID);
            var ddlvalue = ddlDepartmentID.options[ddlDepartmentID.selectedIndex].value;
            var hdnDepartmentID = document.getElementById("<%=hdnDepartmentID.ClientID %>");
            if (ddlvalue != "") {
                hdnDepartmentID.value = ddlvalue;
            }
            else {
                hdnDepartmentID.value = "";
            }
        }
        function GetStockItemValue(ID) {
            var hdnisstockItem = document.getElementById("ctl00_ContentPlaceHolder1_hdnisstockItem");
            var ddlStockItem = document.getElementById(ID);
            var ddlvalue = ddlStockItem.options[ddlStockItem.selectedIndex].value;
            if (ddlvalue != "") {
                hdnisstockItem.value = ddlvalue;
            }

            else {
                hdnisstockItem.value = "";
            }
        }
        function GetReplinshesValue(ID) {

            var hdnisreplinsh = document.getElementById("ctl00_ContentPlaceHolder1_hdnisreplinsh");
            var chkreplishment = document.getElementById(ID);
            if (chkreplishment.checked) {
                hdnisreplinsh.value = "1";

            }
            else {
                hdnisreplinsh.value = "";

            }

        }
        function removeValue(list, value) {
            var sourceArr = list.split(",");
            var toReturn = "";
            for (var i = 0; i < sourceArr.length; i++) {
                if (sourceArr[i] != value)
                    toReturn += sourceArr[i] + ",";
            }
            return toReturn.substr(0, toReturn.length - 1);
        }
        function RemoveComma(Chk_values) {
            Chk_values = Chk_values.substring(0, Chk_values.length - 1)
            return Chk_values;
        }
        var t = false;
        var count = 0;
        var dropdownlist;
        var Chk_values = '';

        function getSelectedItem(id, position, clientid) {
            var hdnOrderClientID = document.getElementById("ctl00_ContentPlaceHolder1_usrReportsave_hdnOrderClientID");
            var change = "i0_chkclientname_" + position;
            var exactid = id.replace(change, "Input");
            dropdownlist = document.getElementById(exactid);
            var checkbox = document.getElementById(id);
            if (checkbox.checked) {
                t = true;
                count++;
                Chk_values += clientid + ",";

                dropdownlist.value = count.toString() + " Customer selected ";

            }
            else {
                count--;
                if (count > 0) {
                    dropdownlist.value = count.toString() + " Customer selected ";
                    Chk_values = removeValue(Chk_values, clientid)
                }
            }

            if (count <= 0) {
                Chk_values = "";
                dropdownlist.value = '-- Customer Name -- ';
            }

            hdnOrderClientID.value = Chk_values;


        }
        function GetselectedmonthCategory(id) {
            var hdnMonthCategory = document.getElementById("ctl00_ContentPlaceHolder1_hdnMonthCategory");
            var ddlMonthCategory = document.getElementById(id);
            var ddlvalue = ddlMonthCategory.options[ddlMonthCategory.selectedIndex].value;
            if (ddlvalue != "") {
                hdnMonthCategory.value = ddlvalue;
            }

            else {
                hdnMonthCategory.value = "";
            }
        }
        var div_chk = document.getElementById("div_chk");
        var div_popupAction = document.getElementById("div_popupAction");







    </script>
   
    <style>
        .RadGrid_Default {
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }

        .btngo {
            width: 60px;
            height: 23px;
            margin-left: 25px;
            text-decoration: none;
            text-shadow: 0 1px 1px rgba(0,0,0,.3);
            height: 20px;
            cursor: pointer;
            border-radius: .5em;
            margin-right: 785px;
            box-shadow: 0 1px 2px rgba(0,0,0,.2);
            border: solid 1px #a3a3a3;
            background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));
        }

        .reportjobtabletd {
            border-bottom: 1px solid black;
        }

        .reportunitsale {
            border-right: 1px solid black;
            width: 50px;
            text-align: right;
            padding-right: 4px;
        }

        .reportunittilldate {
            width: 50px;
            text-align: right;
            padding-right: 4px;
        }

        .reporttablefont {
            font-weight: bold;
            color: #525252;
            float: right;
            width: 100%;
        }

        .ver_align_middle {
            vertical-align: middle;
        }

        .reporttablevalue {
            text-align: right;
            width: 50px;
        }

        .RadGrid_Default {
            border: 1px solid #828282;
            background: #fff;
            border-collapse: collapse;
            font-size: 13px;
            font-family: Helvetica,sans-serif;
        }

        #Grid_Estore_reports {
            border-collapse: collapse;
        }

        .collapse {
            border-collapse: collapse !important;
            outline: none;
            border-bottom: 1px solid gray !important;
            text-transform: none !important;
            font-size: 13px;
            font-family: Helvetica,sans-serif;
        }

        #ctl00_ContentPlaceHolder1_Grid_Estore_reports {
            border: 0 !important;
        }

        #ctl00_ContentPlaceHolder1_grid_reports_byreportid_order {
            border: 0 !important;
        }

        .bordertop {
            border-top: 1px solid gray !important;
            color: Gray;
            border-bottom: 1px solid gray !important;
            text-transform: none !important;
            font-size: 13px;
            font-family: Helvetica,sans-serif;
        }

        .footer {
            border-collapse: collapse !important;
            border-bottom: 1px solid gray !important;
        }

        #ctl00_ContentPlaceHolder1_div_Reports_Names {
            border-radius: 5px !important;
            background-color: White;
            padding: 10px;
            border: 1px solid gray;
        }

        .backgroundwhite {
            background-color: White !important;
            background: white !important;
            font-size: 13px;
            font-family: Helvetica,sans-serif;
        }

        .RadGrid_Default .rgMasterTable td.rgGroupCol, .RadGrid_Default .rgMasterTable td.rgExpandCol {
            background-color: White !important;
            background: white !important;
        }

        .RadGrid_Default .rgCommandCell {
            border-left: 0;
            border-right: 0;
        }

        .rgGroupItem input, .RadGrid .rgCommandRow img, .RadGrid .rgHeader input, .RadGrid .rgFilterRow img, .RadGrid .rgFilterRow input, .RadGrid .rgPager img {
            vertical-align: top;
        }

        .RadGrid_Default {
            border: 1px solid #828282;
            background: #fff;
            font-family: Helvetica,sans-serif;
            font-size: 13px;
        }

            .RadGrid_Default, .RadGrid_Default .rgMasterTable, .RadGrid_Default .rgDetailTable, .RadGrid_Default .rgGroupPanel table, .RadGrid_Default .rgCommandRow table, .RadGrid_Default .rgEditForm table, .RadGrid_Default .rgPager table, .GridToolTip_Default {
                font-family: Helvetica,sans-serif;
                font-size: 13px;
                color: #525252;
            }


        #div_CustomizedInvoiceReport {
            clear: both;
            background-color: #ffffff;
            /* padding-left: 8px; */
            /* padding-top: 6px; */
            /* height: 24px; */
            border: 0px;
        }

        .RadGrid_Default .rgGroupPanel {
            background: white;
        }

        .RadGrid_Default .rgGroupHeader td {
            background: white;
            color: #525252;
            font-size: 13px;
            font-family: Helvetica,sans-serif;
        }

        div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td {
            vertical-align: middle;
        }

        .nowrap {
            white-space: nowrap;
        }
    </style>
    <div id="DIV11" runat="server">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel" runat="server" Skin="Default"
            CssClass="loadingPanel" />
    </div>
    <div id="div_Reports_Namesandreportgrid_main"'>
        <div align="center" style="padding-top:9px;" id="header">
                        <div id="header-content">
            <%--<div id="div_no_reportsfound" runat="server" style="display: none;">
            <label>
                <b>No Reports Found</b></label>
        </div>--%>
            <asp:Button ID="lnkdownload" runat="server" Visible="false" CssClass="show_hide"
                OnClick="lnkDownload_OnClick"></asp:Button>
            <asp:Button ID="btnbacksearch" runat="server" Visible="false" CssClass="show_hide"
                OnClick="Back_Onclick"></asp:Button>
            <div id="div_Reports_Names" runat="server">
                <telerik:RadGrid ID="Grid_Estore_reports" runat="server" AllowSorting="true" PageSize="50"
                    AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" ItemStyle-BorderWidth="0"
                    EnableEmbeddedSkins="true" HeaderStyle-BackColor="White" CellPadding="0" CellSpacing="0"
                    HeaderStyle-BorderStyle="Double" AlternatingItemStyle-BackColor="White" GridLines="none"
                    HeaderStyle-BorderColor="#000000" ItemStyle-BorderColor="#C9C9C9" HeaderStyle-Font-Size="13px"
                    HeaderStyle-BorderWidth="0" Skin="Default" EnableTheming="false" HeaderStyle-ForeColor="#525252"
                    AllowPaging="true" OnNeedDataSource="Grid_estorereports_datasource" OnItemDataBound="Grid_estorereports_OnItemDataBound"
                    CssClass="AddBorders ">
                    <ActiveItemStyle BackColor="White" />
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                    <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="false"
                        CssClass="collapse rgMasterTable MasterTableView" FooterStyle-CssClass="collapse">
                        <HeaderStyle CssClass="bordertop UpperCaseText" Font-Size="13px" ForeColor="#525252" />
                        <ItemStyle CssClass="backgroundwhite" Font-Size="13px" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="ReportName" DataField="reportname" HeaderText="Report Name"
                                SortExpression="ReportName" DataType="System.String" HeaderStyle-Font-Bold="true"
                                AllowFiltering="false" AutoPostBackOnFilter="false" ItemStyle-Height="22px" ItemStyle-HorizontalAlign="Left"
                                HeaderStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <div>
                                        <asp:LinkButton runat="server" Text='<%#Eval("reportname")%>' CssClass="anchorTagColor"
                                            Style='color: #007ED5 !important; font-size: 13px;' OnClick="lnkReportName_Click"
                                            CommandArgument='<%#Eval("pagename")%>' CausesValidation="false"></asp:LinkButton>
                                        <asp:HiddenField ID="hdn_reportid" Value='<%#Eval("ReportID")%>' runat="server" />                                        
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle Width="30%" Font-Size="13px" />
                                <ItemStyle Font-Size="13px" />
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="Description" HeaderText="Description" AllowFiltering="false"
                                AutoPostBackOnFilter="false">
                                <HeaderStyle Font-Bold="true" Font-Size="13px" />
                                <ItemTemplate>
                                    <div>
                                        <label id='lbldesc' style="font-size: 13px;">
                                            <%#Eval("Description")%></label></div>
                                </ItemTemplate>
                                <ItemStyle Font-Size="13px" />
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            <div id="div_reportgrid" runat="server" class="divborder" style="display: block;">
                <%-- <telerik:RadAjaxPanel ID="RadAjaxPanel4" runat="server" EnableAJAX="true">--%>
                <telerik:RadGrid ID="grid_reports_byreportid_order" Width="100%" runat="server" AllowSorting="false"
                    PageSize="50" AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" AllowPaging="true"
                    Visible="false" OnItemDataBound="grid_reports_order_itemdatabound" ItemStyle-BorderColor="#C9C9C9"
                    OnNeedDataSource="grid_reports_order_needdatasource" Skin="Default" EnableTheming="false"
                    HeaderStyle-ForeColor="#525252" HeaderStyle-BorderWidth="0" GridLines="none"
                    HeaderStyle-BorderStyle="Double" OnPageSizeChanged="grid_reports_byreportid_order_PageSizeChanged" HeaderStyle-BackColor="White" CssClass="AddBorders border0Imp"
                    HeaderStyle-Wrap="false" ItemStyle-BorderWidth="0">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" BackColor="White" />
                    <AlternatingItemStyle BackColor="White" />
                    <HeaderStyle BackColor="White" CssClass="backgroundwhite bordertop" />
                    <MasterTableView CommandItemDisplay="Top" AllowPaging="true" CssClass="collapse rgMasterTable MasterTableView">
                        <CommandItemTemplate>
                            <div style="background-color: White; color: #525252">
                                <table>
                                    <tr>
                                        <td>
                                            <div style="margin-left: 15px; margin: 5px; margin-bottom: 14px;">
                                                <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_exportpresentation"
                                                    OnClick="btnback_reports_order" CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin-left: 10px; margin: 5px; margin-top: 10px;">
                                                <asp:LinkButton runat="server" ToolTip="Export (Excel Format)" CssClass="anchortagcolor_enduserreport"
                                                    ID="Imgbtn_exporttoexcel" OnClick="btnreport_exptoexcel_order" Text="Export to Excel"
                                                    CausesValidation="false" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-left: 200px; margin-top: 4px;">
                                                <label id="lbl_orderbyiddate" style="font-weight: bold; margin-right: 10px;">
                                                    Order Date Range:
                                                </label>
                                                <label id="lbl_orderbyidfrom">
                                                    From</label>
                                                <asp:TextBox runat="server" ID="txtfrmdate_order" Style="margin-bottom: 4px;" CssClass="textboxnew txtdates_forenduserreport"
                                                    Width="150px" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-top: 4px;">
                                                <label id="lbl_orderbyidto">
                                                    To</label>
                                                <asp:TextBox runat="server" ID="txttodate_order" Style="margin-bottom: 4px;" CssClass="textboxnew txtdates_forenduserreport"
                                                    Width="150px" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-top: 4px;">
                                                <asp:Button ID="btn_order_datefilter_go" Text="Go" OnClick="btngo_order_customizereport_datefilter"
                                                    CssClass="x-btnpro Grey main" Style="padding: 0; height: 25px; font-size: 13px;
                                                    font-family: Sans-Serif;" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </CommandItemTemplate>
                        <Columns>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadGrid ID="grid_reports_byreportid_jobs" runat="server" AllowSorting="false"
                    PageSize="50" AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" AllowPaging="true"
                    Visible="false" CssClass="AddBorders border0Imp" HeaderStyle-ForeColor="#525252"
                    OnItemDataBound="grid_reports_jobs_itemdatabound" HeaderStyle-BorderWidth="0"
                    HeaderStyle-Wrap="false" ItemStyle-BorderWidth="0" Skin="Default" EnableTheming="false"
                    OnNeedDataSource="grid_reports_jobs_needdatasource">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                    <HeaderStyle BackColor="White" CssClass="bordertop backgroundwhite" />
                    <ActiveItemStyle BackColor="White" CssClass="backgroundwhite" />
                    <MasterTableView CommandItemDisplay="Top" BackColor="White" CssClass="collapse">
                        <CommandItemTemplate>
                            <div style="width: 100%; background: white !important; color: #525252;">
                                <table>
                                    <tr>
                                        <td>
                                            <div style="margin-left: 15px; margin: 5px; margin-top: 4px; margin-bottom: 16px;">
                                                <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_exportpresentation"
                                                    OnClick="btnback_reports_jobs" CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin-left: 10px; margin: 5px; margin-top: 10px;">
                                                <asp:LinkButton runat="server" ToolTip="Export (Excel Format)" Text="Export to Excel"
                                                    ID="Imgbtn_exporttoexcel" OnClick="btn_exportexcel_jobs" CssClass="anchortagcolor_enduserreport"
                                                    CausesValidation="false" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-left: 200px; margin-top: 6px;">
                                                <label id="lbl_jobdate_custreport" style="font-weight: bold; margin-right: 10px;">
                                                    Job Date Range:
                                                </label>
                                                <label id="lbl_jobdate_custreport_from">
                                                    From</label>
                                                <asp:TextBox runat="server" ID="txtfrmdate_job" Style="margin-bottom: 2px;" CssClass="textboxnew txtdates_forenduserreport"
                                                    Width="150px" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-top: 6px;">
                                                <label id="lbl_jobdate_custreport_to">
                                                    To</label>
                                                <asp:TextBox runat="server" ID="txttodate_job" Style="margin-bottom: 2px;" CssClass="textboxnew txtdates_forenduserreport"
                                                    Width="150px" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-top: 6px;">
                                                <asp:Button ID="btn_job_datefilter_go" Text="Go" Style="height: 25px; font-size: 13px;
                                                    font-family: Sans-Serif; padding: 0" OnClick="btngo_customizereport_job_datefilter"
                                                    CssClass="x-btnpro Grey main" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </CommandItemTemplate>
                        <Columns>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadGrid ID="grid_reports_byreportid_invoice" runat="server" AllowSorting="false"
                    PageSize="50" AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" AllowPaging="true"
                    Visible="false" OnItemDataBound="grid_reports_invoice_itemdatabound" GridLines="None"
                    HeaderStyle-BorderWidth="0" HeaderStyle-ForeColor="#525252" ItemStyle-BorderWidth="0"
                    CssClass="AddBorders border0Imp" Skin="Default" EnableTheming="false" HeaderStyle-Wrap="false"
                    OnNeedDataSource="grid_reports_invoice_needdatasource">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" />
                    <HeaderStyle BackColor="White" CssClass="bordertop backgroundwhite" />
                    <ActiveItemStyle BackColor="White" CssClass="backgroundwhite" />
                    <MasterTableView CommandItemDisplay="Top" CssClass="collapse">
                        <CommandItemTemplate>
                            <div id="div_CustomizedInvoiceReport" style="width: auto;">
                                <table>
                                    <tr>
                                        <td colspan="46">
                                            <div style="margin-left: 15px; margin: 5px; margin-top: 2px;">
                                                <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_exportpresentation"
                                                    OnClick="btnback_reports_invoice" CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin-left: 10px; margin: 5px; margin-top: 8px;">
                                                <asp:LinkButton runat="server" ToolTip="Export (Excel Format)" ID="Imgbtn_exporttoexcel"
                                                    OnClick="btn_exportexcel_invoice" CausesValidation="false" Text="Export to Excel"
                                                    CssClass="anchortagcolor_enduserreport" />
                                            </div>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-left: 200px; margin-top: 2px;">
                                                <label id="lbl_invoiceddaterange" style="font-weight: bold; margin-right: 10px;">
                                                    Invoice Date Range:
                                                </label>
                                                <label id="lblfrom">
                                                    From</label>
                                                <asp:TextBox runat="server" ID="txtfrmdate_invoice" Style="margin-bottom: 5px;" CssClass="textboxnew txtdates_forenduserreport"
                                                    Width="150px" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-top: 2px;">
                                                <label id="lblto">
                                                    To</label>
                                                <asp:TextBox runat="server" ID="txttodate_invoice" Style="margin-bottom: 5px;" CssClass="textboxnew txtdates_forenduserreport"
                                                    Width="150px" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin: 5px; margin-top: 2px;">
                                                <asp:Button ID="btn_invoice_datefilter_go" Text="Go" OnClick="btngo_customizereport_invoice_datefilter"
                                                    Style="height: 25px; padding: 0; font-size: 13px; font-family: Sans-Serif;" CssClass="x-btnpro Grey main"
                                                    runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </CommandItemTemplate>
                        <Columns>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadGrid ID="grid_reports_byreportid_product" runat="server" AllowSorting="false"
                    PageSize="50" AutoGenerateColumns="False" HeaderStyle-Font-Bold="true" AllowCustomPaging="true"
                    AllowPaging="true" Visible="false" HeaderStyle-ForeColor="#525252" OnPageIndexChanged="grid_reports_byreportid_product_PageIndexChanged"
                    OnPageSizeChanged="grid_reports_byreportid_product_PageSizeChanged" OnNeedDataSource="grid_reports_product_needdatasource"
                    OnItemDataBound="grid_reports_Product_itemdatabound" HeaderStyle-Wrap="false"
                    Skin="Default" EnableTheming="false" ItemStyle-BorderWidth="0" CssClass="AddBorders border0Imp"
                    HeaderStyle-BorderWidth="0" GridLines="None">
                    <PagerStyle Mode="NextPrevAndNumeric" CssClass="AddBorders border0Imp" AlwaysVisible="true"
                        Position="Bottom" BackColor="White" />
                    <HeaderStyle CssClass="bordertop backgroundwhite" />
                    <AlternatingItemStyle CssClass="backgroundwhite" />
                    <MasterTableView CommandItemDisplay="Top" CssClass="collapse">
                        <CommandItemTemplate>
                            <div style="width: 100%; background: white; color: #525252">
                                <table>
                                    <tr>
                                        <td colspan="46">
                                            <div style="margin-left: 15px; margin: 5px; margin-top: 0px; margin-bottom: 10px;">
                                                <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_backtoreports"
                                                    OnClick="btnback_reports_product" CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                            </div>
                                        </td>
                                        <td>
                                            <div style="margin-left: 10px; margin: 5px; margin-top: 5px;">
                                                <asp:LinkButton runat="server" ToolTip="Export (Excel Format)" ID="Imgbtn_exporttoexcel"
                                                    OnClick="btnexport_excel_product" CausesValidation="false" CssClass="anchortagcolor_enduserreport"
                                                    Text="Export to Excel" />
                                            </div>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </CommandItemTemplate>
                        <Columns>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <%--  </telerik:RadAjaxPanel>--%>
            </div>
            <%--system reports grid--%>
            <div id="div_system_reports">
                <%-- Order--%>
                <div id="div_Order_systemgen_reports" runat="server" class="divborder" style="display: none;">
                    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" EnableAJAX="true">
                        <telerik:RadGrid ID="RadGrid_Order_Report" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="50" CellPadding="0" GridLines="None" CellSpacing="0"
                            AllowFilteringByColumn="true" Visible="false" HeaderStyle-BorderColor="#000000"
                            EnableEmbeddedSkins="true" EnableViewState="true" AllowSorting="true" HeaderStyle-ForeColor="#525252"
                            OnNeedDataSource="RadGrid_Order_Report_OnNeedDataSource" OnItemCommand="RadGrid_Order_Report_ItemCommand"
                            Skin="Default" EnableTheming="false" ItemStyle-BorderWidth="0" HeaderStyle-BorderWidth="0"
                            CssClass="AddBorders border0Imp" OnItemDataBound="RadGrid_Order_Report_ItemDataBound">
                            <PagerStyle AlwaysVisible ="true" />
                             <GroupingSettings CaseSensitive="false" />
                            <MasterTableView CommandItemDisplay="Top" CssClass="collapse rgMasterTable MasterTableView backgroundwhite">
                                <AlternatingItemStyle CssClass="backgroundwhite" />
                                <HeaderStyle CssClass="bordertop backgroundwhite ver_align_middle nowrap" ForeColor="#525252"/>
                                <ItemStyle CssClass="backgroundwhite" />
                                <CommandItemTemplate>
                                    <div style="width: 100%; background: white; color: #525252">
                                        <table id="mastertbl_order_systemgen" class="DivButtonsHeader" style="margin: 0px;
                                            width: 100%;">
                                            <tr>
                                                <td class="product_reportwidth30 ver_align_middle">
                                                    <div style="margin-left: 15px; margin: 5px; margin-bottom: 18px;">
                                                        <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_exportpresentation"
                                                            OnClick="btnback_reports_order" CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                        <div style="margin-left: 44px; margin-top: -18px;">
                                                            <asp:LinkButton ID="LinkButton1_order" runat="server" CssClass="anchortagcolor_enduserreport"
                                                                ForeColor="#007ED5" Style="text-decoration: underline; margin-right: 5px; font-weight: bold;
                                                                font-size: 13px;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                            <asp:LinkButton ID="export_ordersystemgenerated" runat="server" Style="margin-right: 10px; height: 23px;
                                                                margin-top: 3px;" CssClass="anchortagcolor_enduserreport" Text="Export to Excel"
                                                                OnClick="lnkDownload_OnClick" />
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="product_reportwidth35 ver_align_middle">
                                                    <%--<div id="Div1" style="height: 23px; margin-left: 15px;">
                                       ImageUrl="images/export-icon1.jpg" src="images/export-icon1.jpg"
                                    </div>--%>
                                                    <div style="margin-left: 15px; margin: 5px;">
                                                    </div>
                                                </td>
                                                <td align="left">
                                                    <table>
                                                        <tr>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td style="vertical-align: middle;">
                                                                <asp:Label ID="Label20" runat="server" CssClass="lable_bold" Style="margin-right: 10px;">
                                                       <b>   <%=objLanguage.GetLanguageConversion("Date_Range")%>: </b>
                                                                </asp:Label>
                                                            </td>
                                                            <td class="tdwidth" style="vertical-align: middle;">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label22" runat="server" Style="margin-right: 2px;">
                                                          <%=objLanguage.GetLanguageConversion("From")%> 
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:TextBox ID="txtOrderFromDate" runat="server" CssClass="textboxnew" Width="125px"
                                                                    Height="20px" Style="margin-right: 10px; margin-bottom: 10px; margin-top: 5px;"></asp:TextBox>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label6" runat="server" Style="margin-right: 2px;">
                                                          <%=objLanguage.GetLanguageConversion("To")%> 
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:TextBox ID="txtOrderToDate" runat="server" CssClass="textboxnew" Width="125px"
                                                                    Height="20px" Style="margin-right: 10px; margin-bottom: 10px; margin-top: 5px;"></asp:TextBox>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:DropDownList ID="ddlStockItem" runat="server" CssClass="product_reportcannedddl"
                                                                    Style="width: 140px; margin-top: 5px; margin-bottom: 10px;" Height="26px" onchange="Javascript:GetStockItemValue(this.id);">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:CheckBox ID="chkreplishment" Style="margin: 5px; vertical-align: bottom; margin-top: 0px;"
                                                                    runat="server" onClick="Javascript:GetReplinshesValue(this.id);" Height="15px"
                                                                    Text="  Include Replenishment Order"></asp:CheckBox>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Button ID="btnOrderReportGo" runat="server" Height="22px" Style="margin: 5px;
                                                                    margin-top: 5px; margin-left:30px;  margin-bottom: 10px;
                                                                    padding: 0" CssClass="x-btnpro Grey main" Text="Go" OnClick="btnOrderReportGo_onClick" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <div style="float: right; margin-right: 10px;">
                                                        <%-- <asp:LinkButton ID="LinkButton1_order" runat="server" CssClass="anchortagcolor_enduserreport"
                                                        ForeColor="#007ED5" Style="text-decoration: underline; font-weight: bold; font-size: 13px;"
                                                        OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </CommandItemTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" DataField="Customer"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                        HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                        AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" FilterControlWidth="70px"
                                        UniqueName="Customer" SortExpression="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("Customer")%>' ToolTip='<%#Eval("Customer")%>'></asp:Label>
                                        </ItemTemplate>                                        
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" DataField="Department"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true"
                                        AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"
                                        FilterControlWidth="70px" UniqueName="Department" SortExpression="Department">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbranchname" runat="server" Text='<%#Eval("Department")%>' ToolTip='<%#Eval("Department")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" DataField="Contact"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50%" ItemStyle-Width="50%"
                                        HeaderStyle-Wrap="true" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                        AutoPostBackOnFilter="true" UniqueName="ContactNameofthePersonOrdering"
                                        SortExpression="Contact Name of the Person Ordering" CurrentFilterFunction="Contains"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcontactperson" runat="server" Text='<%#Eval("Contact")%>' ToolTip='<%#Eval("Contact")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" DataField="End user Cost Centre"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                        HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                        AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" FilterControlWidth="70px"
                                        UniqueName="EnduserCostCentre" SortExpression="End user Cost Centre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostCentre" runat="server" Text='<%#Eval("End user Cost Centre")%>'
                                                ToolTip='<%#Eval("End user Cost Centre")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" DataField="Order No"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" ItemStyle-Width="15%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                        AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" FilterControlWidth="70px"
                                        UniqueName="OrderNo" SortExpression="Order No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderno" style="white-space:nowrap;" runat="server" Text='<%#Eval("Order No")%>' ToolTip='<%#Eval("Order No")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" DataField="Customer Order No"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                        HeaderStyle-Wrap="true" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                        FilterControlWidth="70px" UniqueName="CustomerOrderNo" SortExpression="Customer Order No"
                                        AutoPostBackOnFilter="true" CurrentFilterFunction="Contains">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerOrderNo" runat="server" Text='<%#Eval("Customer Order No")%>'
                                                ToolTip='<%#Eval("Customer Order No")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" DataField="OrderedDate"
                                        ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="13%" ItemStyle-Width="13%"
                                        HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="false"
                                        AutoPostBackOnFilter="false" DataType="System.DateTime" UniqueName="OrderedDate"
                                        SortExpression="OrderedDate">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrderedDate" Text='<%# DataBinder.Eval(Container, "DataItem.OrderedDate", "{0}") %>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="5%" ItemStyle-Width="5%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                        HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="Item Code" UniqueName="ItemCode"
                                        SortExpression="Item Code" CurrentFilterFunction="Contains" AutoPostBackOnFilter="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstockcode" runat="server" Text='<%#Eval("Item Code")%>' ToolTip='<%#Eval("Item Code")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        CurrentFilterFunction="Contains" DataField="Item Title" UniqueName="ItemTitle"
                                        SortExpression="Item Title">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrductname" runat="server" Text='<%#Eval("Item Title")%>' ToolTip='<%#Eval("Item Title")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        CurrentFilterFunction="Contains" DataField="Product Type" UniqueName="ProductType"
                                        SortExpression="Product Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOnDemand" runat="server" Text='<%#Eval("Product Type")%>' ToolTip='<%#Eval("Product Type")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="left" HeaderText="Customer Code" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="True" ItemStyle-Wrap="false"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        CurrentFilterFunction="Contains" DataField="Customer Code" UniqueName="CustomerCode"
                                        SortExpression="Customer Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustomerCode" Text='<%#Eval("Customer Code")%>' ToolTip='<%#Eval("Customer Code")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                        HeaderStyle-Width="13%" ItemStyle-Width="13%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        CurrentFilterFunction="EqualTo" DataField="Qty Ordered" UniqueName="QtyOrdered"
                                        SortExpression="Qty Ordered">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQtyOrdered" Text='<%#Eval("Qty Ordered")%>' ToolTip='<%#Eval("Qty Ordered")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                        HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        CurrentFilterFunction="EqualTo" DataField="Unit of Issue" UniqueName="UnitofIssue"
                                        SortExpression="Unit of Issue">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitOfIssues" Text='<%#Eval("Unit of Issue")%>' ToolTip='<%#Eval("Unit of Issue")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                        HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        CurrentFilterFunction="EqualTo" DataField="Unit Cost" UniqueName="UnitCost"
                                        SortExpression="Unit Cost">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUnitCost" Text='<%#Eval("Unit Cost")%>' ToolTip='<%#Eval("Unit Cost")%>'
                                                runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                        HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        CurrentFilterFunction="EqualTo" DataField="Total" UniqueName="Total" SortExpression="Total">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltotal" Text='<%#Eval("Total")%>' ToolTip='<%#Eval("Total")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                            </ClientSettings>
                            <FilterMenu OnClientShown="MenuShowing" />
                        </telerik:RadGrid>
                    </telerik:RadAjaxPanel>
                </div>
                <%--job system reports--%>
                <div id="div_job_systemgeneratedreports" runat="server" class="divborder" style="display: none;
                    width: 102%;">
                    <%-- product sales report--%>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server" EnableAJAX="true">
                        <telerik:RadGrid ID="RadGrid_CustomerJobReport" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="50" OnItemDataBound="RadGridCustomerJobReport_ItemDataBound"
                            AllowFilteringByColumn="true" HeaderStyle-ForeColor="#525252" OnNeedDataSource="RadGridCustomerJobReport_OnNeedDataSource"
                            Visible="false" AllowSorting="true" ShowGroupPanel="true" ShowFooter="True"
                            FooterStyle-Font-Bold="true" Skin="Default" EnableTheming="false" EnableLinqExpressions="false" ItemStyle-BorderWidth="0"
                            HeaderStyle-BorderWidth="0" CssClass="AddBorders border0Imp">
                            <PagerStyle AlwaysVisible="true" />
                             <GroupingSettings CaseSensitive="false" />                            
                            <MasterTableView CommandItemDisplay="Top" AllowSorting="true" ShowGroupFooter="false"
                                CssClass="collapse backgroundwhite">
                                <AlternatingItemStyle CssClass="backgroundwhite" />
                                <HeaderStyle CssClass="bordertop backgroundwhite" ForeColor="#525252" />
                                <ItemStyle CssClass="backgroundwhite" />
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="19px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <CommandItemTemplate>
                                    <table class="DivButtonsHeader" style="width: 100%; background: White; color: #525252;">
                                        <tr>
                                            <td class="product_reportwidth30">
                                                <div style="margin-left: 15px; margin: 5px; margin-bottom: 10px; margin-top:10px;">
                                                    <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_exportpresentation"
                                                        OnClick="btnback_reports_order" CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                    <div style="margin-left: 43px; margin-top: -16px;">
                                                        <asp:LinkButton ID="LinkButton1_jobproductsales" runat="server" ForeColor="#007ED5"
                                                            Style="margin-right: 5px;" CssClass="anchortagcolor_enduserreport" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                        <asp:LinkButton ID="export_productsales" Style="margin-top: 3px;" runat="server"
                                                            src="images/export-icon1.jpg" CssClass="anchortagcolor_enduserreport" Text="Export to Excel"
                                                            OnClick="lnkDownload_OnClick" /></div>
                                                </div>
                                            </td>
                                            <td class="product_reportwidth35">
                                                <%--<div id="Div1" style="height: 23px; margin-left: 15px;">
                                        
                                    </div>--%>
                                            </td>
                                            <td align="left">
                                                <table class="ver_align_middle" style="margin-top: 10px; margin-bottom: 10px;">
                                                    <tr>
                                                        <td>
                                                            <%--<asp:Label ID="lblJobCustomerName" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                        </asp:Label>--%>
                                                        </td>
                                                        <td>
                                                            &nbsp;<%--<asp:DropDownList ID="ddlJobParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularJobSelectedClientID(this.id);">
                                                    </asp:DropDownList>--%>
                                                        </td>
                                                        <td class="tdwidth">
                                                        </td>
                                                        <td class="ver_align_middle">
                                                            <asp:Label ID="Label20" runat="server" Style="margin-right: 10px;">
                                                   <b>       <%=objLanguage.GetLanguageConversion("Date_Range")%>:</b>
                                                            </asp:Label>
                                                        </td>
                                                        <td class="ver_align_middle">
                                                            <asp:Label ID="Label22" runat="server" Style="margin-right: 2px;">
                                                          <%=objLanguage.GetLanguageConversion("From")%>
                                                            </asp:Label>
                                                        </td>
                                                        <td class="ver_align_middle">
                                                            <asp:TextBox ID="txtJobFromDate" runat="server" CssClass="textboxnew" Width="125px"
                                                                Height="20px" Style="margin-right: 10px;"></asp:TextBox>
                                                        </td>
                                                        <%-- <td class="tdwidth">
                                                    </td>--%>
                                                        <td class="ver_align_middle">
                                                            <asp:Label ID="Label6" runat="server" Style="margin-right: 2px;">
                                                          <%=objLanguage.GetLanguageConversion("To")%>
                                                            </asp:Label>
                                                        </td>
                                                        <td class="ver_align_middle">
                                                            <asp:TextBox ID="txtJobToDate" runat="server" CssClass="textboxnew" Width="125px"
                                                                Height="20px" Style="margin-right: 10px;"></asp:TextBox>
                                                        </td>
                                                        <td class="tdwidth">
                                                        </td>
                                                        <td class="ver_align_middle">
                                                            <asp:Button ID="btJobGo" runat="server" Style="height: 22px; font-size: 13px; font-family: Sans-Serif;"
                                                                CssClass="x-btnpro Grey main" Text="Go" OnClick="btnJobGo_OnClick" />
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align: middle;">
                                                <%--<asp:LinkButton ID="LinkButton1_jobproductsales" runat="server" ForeColor="#007ED5"
                                                Style="text-decoration: underline; margin-right: 10px; font-weight: bold; float: right;"
                                                CssClass="anchortagcolor_enduserreport" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%>
                                            </td>
                                        </tr>
                                    </table>
                                </CommandItemTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Job Number" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                        AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="JobNumber"
                                        SortExpression="JobNumber" FilterControlWidth="70px" Groupable="true" GroupByExpression="JobNumber Group By JobNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblcustJobNumber" runat="server" Text='<%#Eval("JobNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Job Title" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="16%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="JobTitle"
                                        FilterControlWidth="70px" SortExpression="JobTitle" Groupable="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJobTitle" runat="server" Text='<%#Eval("JobTitle")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Department Name" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="12%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="DepartmentName"
                                        FilterControlWidth="70px" SortExpression="DepartmentName" GroupByExpression="DepartmentName Group By DepartmentName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptName" runat="server" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Department State" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" ItemStyle-Width="11%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="DepartmentState"
                                        FilterControlWidth="70px" SortExpression="DepartmentState" GroupByExpression="DepartmentState Group By DepartmentState">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeptState" runat="server" Text='<%#Eval("DepartmentState")%>'> </asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Category" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" ItemStyle-Width="12%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ParentCategorySubCategory"
                                        FilterControlWidth="70px" SortExpression="ParentCategorySubCategory" GroupByExpression="ParentCategorySubCategory Group By ParentCategorySubCategory">
                                        <ItemTemplate>
                                            <asp:Label ID="lblParentcat" runat="server" Text='<%#Eval("ParentCategorySubCategory")%>'> </asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Item Code" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="3%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemCode"
                                        FilterControlWidth="70px" SortExpression="ItemCode" Groupable="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="3%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="CustomerCode"
                                        FilterControlWidth="70px" SortExpression="CustomerCode" GroupByExpression="CustomerCode Group By CustomerCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="22%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemTitle"
                                        FilterControlWidth="70px" SortExpression="ItemTitle" Groupable="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="12%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemDescription"
                                        FilterControlWidth="70px" UniqueName="SubTotal" FooterStyle-HorizontalAlign="Left"
                                        SortExpression="ItemDescription" Groupable="false" Aggregate="Custom" FooterText="Sub Total:"
                                        FooterStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemDesc" runat="server" Text='<%#Eval("ItemDescription")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <div>
                                                <asp:Label ID="lbltext" runat="server"></asp:Label>
                                            </div>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Item Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="10%"
                                        ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="true"
                                        DataField="ItemQty" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                        UniqueName="ItemQTy" SortExpression="ItemQty" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                        DataType="System.Int32" Groupable="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true"
                                        FooterStyle-HorizontalAlign="Right" FooterStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemQTy" runat="server" Text='<%#Eval("ItemQty")%>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <div>
                                                <asp:Label ID="lblSumTotalQty" runat="server" Text="0"></asp:Label>
                                            </div>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Sales Value" HeaderStyle-Font-Bold="true"
                                        HeaderStyle-Width="1%" ItemStyle-Width="1%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                        AllowFiltering="true" DataField="SalesValue" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-HorizontalAlign="Right" UniqueName="SalesValue" SortExpression="SalesValue"
                                        CurrentFilterFunction="EqualTo" DataType="System.Decimal" AutoPostBackOnFilter="true"
                                        Groupable="false" Aggregate="Sum" FooterText=" " FooterStyle-Font-Bold="true"
                                        FooterStyle-HorizontalAlign="Right" FooterStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSalesValue" runat="server" Text='<%#Eval("SalesValue")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnSubItemSalesValue" runat="server" Value='<%#Eval("SubItemSalesValue")%>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <div>
                                                <asp:Label ID="lblSumTotalSubTotal" runat="server" Text="0"></asp:Label>
                                            </div>
                                        </FooterTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <ClientSettings AllowDragToGroup="true">
                                <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                            </ClientSettings>
                            <FilterMenu OnClientShown="MenuShowing" />
                            <GroupingSettings ShowUnGroupButton="true"></GroupingSettings>
                        </telerik:RadGrid>
                        <%-- sales/order report--%>
                        <telerik:RadGrid ID="RadGridReports_salesorderreport" runat="server" AutoGenerateColumns="false"
                            AllowPaging="true" PageSize="50" OnItemDataBound="RadGridReports_ItemDataBound"
                            AllowFilteringByColumn="true" ItemStyle-BorderWidth="0" HeaderStyle-BorderWidth="0"
                            CssClass="AddBorders border0Imp" HeaderStyle-ForeColor="#525252" OnNeedDataSource="RadGridJobReports_OnNeedDataSource"
                            GridLines="None" Skin="Default" FooterStyle-Font-Bold="true" EnableTheming="false" Visible="false">
                            <PagerStyle AlwaysVisible="true" />
                             <GroupingSettings CaseSensitive="false" />
                            <MasterTableView CommandItemDisplay="Top" CssClass="collapse">
                                <AlternatingItemStyle CssClass="backgroundwhite" />
                                <HeaderStyle CssClass="bordertop backgroundwhite ver_align_middle" ForeColor="#525252" />
                                <CommandItemTemplate>
                                    <table class="DivButtonsHeader" style="vertical-align: middle; background-color: White;
                                        width: 100%; color: #525252">
                                        <tr>
                                            <td>
                                                <div style="margin-left: 15px; margin: 5px; margin-bottom: 15px;">
                                                    <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_back" OnClick="btnback_reports_order"
                                                        CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                    <div style="margin-left: 43px; margin-top: -18px;">
                                                        <asp:LinkButton ID="lnkBtnClearFilter_salesorder" runat="server" CssClass="anchortagcolor_enduserreport"
                                                            Style="margin-right: 5px;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                        <asp:LinkButton ID="export_salesorder" runat="server" CssClass="anchortagcolor_enduserreport"
                                                            Text="Export to Excel" OnClick="lnkDownload_OnClick" />
                                                    </div>
                                                </div>
                                            </td>
                                            <td class="product_reportwidth35">
                                                <%-- <div id="Div1" style="height: 23px; margin-left: 15px; margin-top: 5px;">
                                       
                                    </div>--%>
                                            </td>
                                            <td class="report_clrfilter" style="vertical-align: middle;">
                                                <div style="float: right;">
                                                    <%--<asp:LinkButton ID="lnkBtnClearFilter_salesorder" runat="server" CssClass="anchortagcolor_enduserreport"
                                                    Style="text-decoration: underline; margin-right: 10px; font-weight: bold;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%></div>
                                            </td>
                                        </tr>
                                    </table>
                                </CommandItemTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Category" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                        AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Category"
                                        FilterControlWidth="70px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lnkCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                        </ItemTemplate>                                        
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="CustomerCode"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemTitle"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="9%" ItemStyle-Width="9%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ProductDescription"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProdDesc" runat="server" Text='<%#Eval("ProductDescription")%>'> </asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="CustomerName"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustomerName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="State" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="2%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="State"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblState" runat="server" Text='<%#Eval("State")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Department" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="Department"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Department")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Contact Name" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                        HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                        HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ContactName"
                                        FilterControlWidth="70px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContactName" runat="server" Text='<%#Eval("ContactName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-Width="5%"
                                        ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true" AllowFiltering="false"
                                        DataField="UnitSalesThisWeek">
                                        <HeaderTemplate>
                                            <table class="reporttablefont">
                                                <tr>
                                                    <td colspan="6" align="center" class="reportjobtabletd">
                                                        <b>Unit Sales</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="reportunitsale">
                                                        <b>This Week</b>
                                                    </td>
                                                    <td class="reportunitsale">
                                                        <b>Last Week</b>
                                                    </td>
                                                    <td class="reportunitsale">
                                                        <b>This Month</b>
                                                    </td>
                                                    <td class="reportunitsale">
                                                        <b>Last Month</b>
                                                    </td>
                                                    <td class="reportunitsale">
                                                        <b>A/C Year</b>
                                                    </td>
                                                    <td class="reportunittilldate">
                                                        <b>Till Date</b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table class="reportsalevalue">
                                                <tr>
                                                    <td class="reporttablevalue" style="border:0;">
                                                        <asp:Label ID="lblSalesThisWeek" runat="server" Text='<%#Eval("UnitSalesThisWeek")%>'></asp:Label>
                                                    </td>
                                                    <td class="reporttablevalue" style="border:0;">
                                                        <asp:Label ID="lblSalesLastWeek" runat="server" Text='<%#Eval("UnitSalesLastWeek")%>'></asp:Label>
                                                    </td>
                                                    <td class="reporttablevalue" style="border:0;">
                                                        <asp:Label ID="lblSalesThisMonth" runat="server" Text='<%#Eval("UnitSalesThisMonth")%>'></asp:Label>
                                                    </td>
                                                    <td class="reporttablevalue" style="border:0;">
                                                        <asp:Label ID="lblSalesLastMonth" runat="server" Text='<%#Eval("UnitSalesLastMonth")%>'></asp:Label>
                                                    </td>
                                                    <td class="reporttablevalue" style="border:0;">
                                                        <asp:Label ID="lblSalesACYear" runat="server" Text='<%#Eval("UnitSalesACYear")%>'></asp:Label>
                                                    </td>
                                                    <td class="reporttablevalue" style="border:0;">
                                                        <asp:Label ID="lblSalesTillDate" runat="server" Text='<%#Eval("UnitSalesTillDate")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadAjaxPanel>
                </div>
                <%--Product System Generated Reports--%>
                <div id="div_products_system_generatedreports" class="divborder" runat="server" style="display: none;">
                    <telerik:RadAjaxPanel ID="RadAjaxPanel3" runat="server" EnableAJAX="true">
                        <div>
                            <%--stock usage report--%>
                            <telerik:RadGrid ID="RadStockUsage_Packs_stockusagereport" Width="100%" runat="server"
                                AutoGenerateColumns="false" OnNeedDataSource="RadStockUsage_Packs_OnNeedDataSource"
                                AllowPaging="true" PageSize="50" AllowFilteringByColumn="true" Visible="false"
                                AllowSorting="true" OnItemDataBound="RadStockUsage_Packs_OnItemDataBound" ShowFooter="True"
                                FooterStyle-Font-Bold="true" EnableLinqExpressions="false" CssClass="AddBorders border0Imp"
                                ItemStyle-BorderWidth="0" HeaderStyle-ForeColor="#525252" HeaderStyle-BorderWidth="0"
                                Skin="Default" EnableTheming="false">
                                <PagerStyle AlwaysVisible="true" />
                                 <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Top" AllowSorting="true" ShowFooter="true" CssClass="collapse">
                                    <AlternatingItemStyle CssClass="backgroundwhite" />
                                    <HeaderStyle CssClass="bordertop backgroundwhite" ForeColor="#525252" />
                                    <CommandItemTemplate>
                                        <table class="DivButtonsHeader" style="width: 100%; background-color: White;">
                                            <tr>
                                                <td class="product_reportwidth30">
                                                    <div style="margin-left: 15px; margin: 5px; margin-bottom: 14px;">
                                                        <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="Imgbtn_back" OnClick="btnback_reports_order"
                                                            CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                        <div style="margin-top: -18px; margin-left: 45px;">
                                                            <asp:LinkButton ID="LinkButton1_stockusage1" runat="server" CssClass="anchortagcolor_enduserreport"
                                                                Style="text-decoration: underline; margin-right: 5px;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                            <asp:LinkButton ID="export_stockusage" runat="server" CssClass="anchortagcolor_enduserreport"
                                                                Text="Export to Excel" OnClick="lnkDownload_OnClick" />
                                                        </div>
                                                    </div>
                                                    <%-- <div id="Div1" style="height: 20px; margin-top: 5px; margin-left: 10px;">
                                           
                                        </div>--%>
                                                </td>
                                                <td class="product_reportwidth35">
                                                </td>
                                                <%-- <td class="tdwidth">
                                    </td>
                                    <td class="tdwidth">
                                    </td>
                                    <td class="tdwidth">
                                    </td>
                                    <td class="tdwidth">
                                    </td>--%>
                                                <td style="white-space: nowrap; width: 2px;">
                                                    <%--<telerik:RadComboBox ID="Customerlist" runat="server" Width="250px" Style="vertical-align: middle;
                                            margin-right: 10px" EmptyMessage="-- Customer Name --" Height="100px">
                                            <ItemTemplate>
                                                <div style="margin-left: -10px; width: 150%">
                                                    <asp:CheckBoxList ID="chkclientname" runat="server">
                                                    </asp:CheckBoxList>
                                                </div>
                                            </ItemTemplate>
                                            <Items>
                                                <telerik:RadComboBoxItem Text="" />
                                            </Items>
                                        </telerik:RadComboBox>--%>
                                                </td>
                                                <td>
                                                    <%--  <asp:Button ID="btnOrderReportGo" runat="server" CssClass="button btngo" Text="Go" OnClick="btnStockUsage_PacksReportGo_onClick" />--%>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <div style="float: right;">
                                                        <%-- <asp:LinkButton ID="LinkButton1_stockusage1" runat="server" ForeColor="#007ED5" Style="text-decoration: underline;
                                                        font-weight: bold;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Item Code" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" ItemStyle-Width="7%"
                                            HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="ItemCode"
                                            SortExpression="ItemCode" FilterControlWidth="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemCode" runat="server" Text='<%#Eval("ItemCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="9%"
                                            HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            HeaderStyle-Font-Bold="true" CurrentFilterFunction="Contains" DataField="ItemTitle"
                                            FilterControlWidth="150px" SortExpression="ItemTitle" Groupable="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="UOI" HeaderStyle-HorizontalAlign="Right"
                                            UniqueName="SoldInPacksOf" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="10%"
                                            ItemStyle-Width="10%" HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                            DataField="SoldInPacksOf" FilterControlWidth="60px" SortExpression="SoldInPacksOf">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUOI" runat="server" Text='<%#Eval("SoldInPacksOf")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Quantity on Hand" HeaderStyle-HorizontalAlign="Right"
                                            UniqueName="QuantityOnHand" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%"
                                            ItemStyle-Width="3%" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                            DataField="QuantityOnHand" FilterControlWidth="60px" SortExpression="QuantityOnHand">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQauntityOnHand" runat="server" Text='<%#Eval("QuantityOnHand")%>'> </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Allocated Stock" HeaderStyle-HorizontalAlign="Right"
                                            UniqueName="AllocatedStock" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="10%"
                                            ItemStyle-Width="4%" HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                            DataField="AllocatedStock" FilterControlWidth="60px" SortExpression="AllocatedStock">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAllocatedStock" runat="server" Text='<%#Eval("AllocatedStock")%>'> </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Available Stock" HeaderStyle-HorizontalAlign="Right"
                                            UniqueName="AvailableStock" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%"
                                            ItemStyle-Width="2%" HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                            DataField="AvailableStock" FilterControlWidth="60px" SortExpression="AvailableStock"
                                            Groupable="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAvailableStock" runat="server" Text='<%#Eval("AvailableStock")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Stock on Backorder" HeaderStyle-HorizontalAlign="Right"
                                            UniqueName="StockOnBackOrder" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%"
                                            ItemStyle-Width="2%" HeaderStyle-Wrap="false" ItemStyle-Wrap="false" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                            DataField="StockOnBackOrder" FilterControlWidth="60px" SortExpression="StockOnBackOrder">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStockOnBackOrder" runat="server" Text='<%#Eval("StockOnBackOrder")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Cost Per Pack" HeaderStyle-HorizontalAlign="Right"
                                            UniqueName="CostPerPack" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="8%"
                                            ItemStyle-Width="3%" HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                            DataField="CostPerPack" FilterControlWidth="60px" SortExpression="CostPerPack"
                                            Groupable="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCostPerPack" runat="server" Text='<%#Eval("CostPerPack")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Backorder Value" HeaderStyle-HorizontalAlign="Right"
                                            UniqueName="BackOrderValue" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="4%"
                                            ItemStyle-Width="1%" HeaderStyle-Wrap="false" ItemStyle-Wrap="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" HeaderStyle-Font-Bold="true" CurrentFilterFunction="EqualTo"
                                            DataField="BackOrderValue" FilterControlWidth="60px" SortExpression="BackOrderValue"
                                            FooterStyle-HorizontalAlign="Right" FooterStyle-Wrap="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBackOrderValue" runat="server" Text='<%#Eval("BackOrderValue")%>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div>
                                                    <asp:Label ID="lblTotaCostQuantity" runat="server" Text="Total Cost Value:"></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Cost Value" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="1%" ItemStyle-Width="8%" HeaderStyle-Wrap="false" ItemStyle-Wrap="true"
                                            AllowFiltering="true" SortExpression="CostquantityOnBackOrder" DataField="CostquantityOnBackOrder"
                                            HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right" UniqueName="CostquantityOnBackOrder"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" FilterControlWidth="60px"
                                            FooterStyle-HorizontalAlign="Right">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalcost" runat="server" Text='<%#Eval("CostquantityOnBackOrder")%>'></asp:Label>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <div>
                                                    <asp:Label ID="lblTotalCostQuantityvalue" runat="server" Text=""></asp:Label>
                                                </div>
                                            </FooterTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowDragToGroup="true">
                                    <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                </ClientSettings>
                                <FilterMenu OnClientShown="MenuShowing" />
                            </telerik:RadGrid>
                        </div>
                        <div>
                            <%--Stock Usage Report by Month and Year--%>
                            <telerik:RadGrid ID="RadGrid_StockUsageReport_bymonthandyear" runat="server" AutoGenerateColumns="true"
                                GroupingEnabled="true" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true"
                                Visible="false" HeaderStyle-Font-Bold="true" HeaderStyle-Wrap="true" AllowSorting="true"
                                EnableLinqExpressions="false" OnItemDataBound="RadGrid_StockUsageReport_ItemDataBound"
                                OnNeedDataSource="RadGrid_StockUsageReport_OnNeedDataSource" ItemStyle-BorderWidth="0"
                                HeaderStyle-BorderWidth="0" HeaderStyle-ForeColor="#525252" CssClass="AddBorders border0Imp">
                                <PagerStyle AlwaysVisible="true" />
                                 <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Top" HeaderStyle-Font-Bold="true" GroupHeaderItemStyle-BackColor="#F2F2F2"
                                    HeaderStyle-Height="25px" GroupHeaderItemStyle-Font-Bold="false" AllowFilteringByColumn="true"
                                    CssClass="collapse">
                                    <AlternatingItemStyle CssClass="backgroundwhite" />
                                    <HeaderStyle CssClass="bordertop backgroundwhite" Wrap="false" ForeColor="#525252" />
                                    <GroupHeaderItemStyle BackColor="White" />
                                    <GroupByExpressions>
                                        <telerik:GridGroupByExpression>
                                            <SelectFields>
                                                <telerik:GridGroupByField FieldAlias="Department" FieldName="DeptName" />
                                            </SelectFields>
                                            <GroupByFields>
                                                <telerik:GridGroupByField FieldName="DeptName" SortOrder="Ascending" />
                                            </GroupByFields>
                                        </telerik:GridGroupByExpression>
                                    </GroupByExpressions>
                                    <CommandItemTemplate>
                                        <table class="DivButtonsHeader ver_align_middle" style="width: 100%; background: White;
                                            margin: 0px; color: #525252">
                                            <tr>
                                                <td class="product_reportwidth30">
                                                    <div style="margin-left: 15px; margin-top: 4px; width: 20px; margin-bottom: 14px;">
                                                        <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="ImageButton1" OnClick="btnback_reports_order"
                                                            CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                    </div>
                                                </td>
                                                <td class="product_reportwidth35">
                                                    <div id="Div1" style="height: 23px; margin-top: 8px;">
                                                        <asp:LinkButton ID="LinkButton1_bymonthyear" runat="server" Style="text-decoration: underline;
                                                            margin-right: 10px; font-weight: bold;" CssClass="anchortagcolor_enduserreport"
                                                            OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                        <asp:LinkButton ID="export_bymonthandyear" runat="server" CssClass="anchortagcolor_enduserreport"
                                                            Text="Export to Excel" OnClick="lnkDownload_OnClick" />
                                                    </div>
                                                </td>
                                                <td align="left" class="ver_align_middle">
                                                    <table>
                                                        <tr>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td>
                                                                <%--<asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlUsageCustomerName_OnSelectedIndexChanged"
                                                            onchange="Javascript:GetParticularSelectedClientID(this.id);" Height="20px">
                                                        </asp:DropDownList>--%>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td>
                                                                <div style="margin-left: 70px; margin-right: 15px; margin-bottom: 5px;">
                                                                    <asp:DropDownList ID="ddldepartment" runat="server" Style="margin-top: 2px;" CssClass="product_reportcannedddl"
                                                                        onchange="Javascript:GetParticularSelectedDepatmentID(this.id);" Height="23px">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                            <%-- <td class="tdwidth">
                                                    </td>--%>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:DropDownList ID="ddlMonthCategory" Style="margin-top: 2px; margin-bottom: 10px;
                                                                    max-width: 250px;" runat="server" CssClass="product_reportcannedddl" onchange="Javascript:GetselectedmonthCategory(this.id);"
                                                                    Height="23px" Width="250px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Button ID="btnUsageReportGo" Style="margin-top: 2px; margin-bottom: 10px; font-size: 13px;
                                                                    font-family: Sans-Serif; margin-left: 10px; margin-right: 10px; padding: 0;"
                                                                    runat="server" CssClass="x-btnpro Grey main" Height="23px" Text="Go" OnClick="btnUsageReportGo_OnClick" />
                                                            </td>
                                                            <td class="lable_bold ver_align_middle">
                                                                <div style="margin-left: 50px; margin-bottom: 10px;">
                                                                    <b>
                                                                        <asp:Label ID="lblMonthHeading" runat="server">
                                                                        </asp:Label></b>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <%--  <td class="lable_bold">
                                                <div style="margin-right: 500px">
                                                    <b>
                                                        <asp:Label ID="lblMonthHeading" runat="server">
                                                        </asp:Label></b>
                                                </div>
                                            </td>--%>
                                                <td style="vertical-align: middle;">
                                                    <div style="float: right">
                                                        <%--<asp:LinkButton ID="LinkButton1_bymonthyear" runat="server" Style="text-decoration: underline;
                                                        margin-right: 10px; font-weight: bold;" CssClass="anchortagcolor_enduserreport"
                                                        OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                </MasterTableView>
                                <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                    <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                </ClientSettings>
                                <FilterMenu OnClientShown="MenuShowing" />
                            </telerik:RadGrid>
                        </div>
                        <%--Stock Release and Adjustment Report--%>
                        <div>
                            <telerik:RadGrid ID="RadGridProductReport_Customer_stockadjustment" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true"
                                Visible="false" OnNeedDataSource="RadGridProductReportCustomer_OnNeedDataSource"
                                OnItemDataBound="RadGridProductReportCustomer_ItemDataBound" CssClass="AddBorders border0Imp"
                                AllowSorting="true" HeaderStyle-ForeColor="#525252" ItemStyle-BorderWidth="0"
                                HeaderStyle-BorderWidth="0">
                                <PagerStyle AlwaysVisible="true" />
                                <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Top" CssClass="collapse">
                                    <AlternatingItemStyle CssClass="backgroundwhite" />
                                    <HeaderStyle CssClass="bordertop backgroundwhite" ForeColor="#525252" />
                                    <CommandItemTemplate>
                                        <table class="DivButtonsHeader" style="width: 100%; background-color: White; background: white;
                                            color: #525252;">
                                            <tr>
                                                <td class="product_reportwidth30" width="100px">
                                                    <div style="margin-left: 15px; width: 65px; margin: 5px; margin-right: 200px; margin-bottom: 20px;">
                                                        <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="ImageButton2" OnClick="btnback_reports_order"
                                                            CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                        <div style="margin-left: 43px; margin-top: -18px;">
                                                            <asp:LinkButton ID="LinkButton1filter_adjustment" runat="server" CssClass="anchortagcolor_enduserreport"
                                                                Style="text-decoration: underline; margin-right: 10px; white-space: nowrap; font-weight: bold;"
                                                                OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                            <div style="margin-left: 105px; margin-top: -16px;">
                                                                <asp:LinkButton ID="export_stock_adjustment" CssClass="anchortagcolor_enduserreport"
                                                                    Text="Export to Excel" runat="server" OnClick="lnkDownload_OnClick" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="product_reportwidth35">
                                                    <%--<div id="Div1" style="height: 23px; margin-left: 15px;">
                                           
                                        </div>--%>
                                                </td>
                                                <td align="left">
                                                    <table class="ver_align_middle" style="margin: 6px;">
                                                        <tr>
                                                            <%--<td>
                                                    <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                </td>--%>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label20" runat="server" Style="margin-right: 10px; white-space: nowrap;">
                                                      <b><%=objLanguage.GetLanguageConversion("Date_Range")%>:  </b>
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label22" runat="server" Style="margin-right: 4px;">
                                                          <%=objLanguage.GetLanguageConversion("From")%>
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textboxnew" Width="125px"
                                                                    Height="18px" Style="margin-right: 10px;"></asp:TextBox>
                                                            </td>
                                                            <%-- <td class="tdwidth">
                                                    </td>--%>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label6" runat="server" Style="margin-right: 4px;">
                                                          <%=objLanguage.GetLanguageConversion("To")%>
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew" Width="125px" Height="18px"
                                                                    Style="margin-right: 10px;">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Button ID="btnProductGo" runat="server" CssClass="x-btnpro Grey main" Height="22px"
                                                                    Text="Go" OnClick="btnProductGo_OnClick" Style="padding: 0; font-size: 13px;
                                                                    font-family: Sans-Serif;" />
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <div style="float: right;">
                                                        <%-- <asp:LinkButton ID="LinkButton1filter_adjustment" runat="server" CssClass="anchortagcolor_enduserreport"
                                                        Style="text-decoration: underline; margin-right: 10px; white-space: nowrap; font-weight: bold;"
                                                        OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ParentCategory/SubCategory"
                                            SortExpression="ParentCategory/SubCategory">
                                            <ItemTemplate>
                                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("ParentCategory/SubCategory")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Itemcode"
                                            SortExpression="Itemcode">
                                            <ItemTemplate>
                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("Itemcode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="CustomerCode"
                                            SortExpression="CustomerCode">
                                            <ItemTemplate>
                                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ItemTitle"
                                            SortExpression="ItemTitle">
                                            <ItemTemplate>
                                                <asp:Label ID="Label10" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ItemDescription"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" SortExpression="ItemDescription">
                                            <ItemTemplate>
                                                <asp:Label ID="Label11" runat="server" Text='<%#Eval("ItemDescription")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="Openingstock" SortExpression="Openingstock"
                                            CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                            UniqueName="Openingstock">
                                            <ItemTemplate>
                                                <asp:Label ID="Label13" runat="server" Text='<%#Eval("Openingstock")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" DataField="Releases"
                                            ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" SortExpression="Releases" DataType="System.Decimal"
                                            UniqueName="Releases">
                                            <ItemTemplate>
                                                <asp:Label ID="Label14" runat="server" Text='<%#Eval("Releases")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" DataField="Receipts" SortExpression="Receipts"
                                            DataType="System.Decimal" UniqueName="Receipts">
                                            <ItemTemplate>
                                                <asp:Label ID="Label15" runat="server" Text='<%#Eval("Receipts")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" DataField="Adjustments" SortExpression="Adjustments"
                                            DataType="System.Decimal" UniqueName="Adjustments">
                                            <ItemTemplate>
                                                <asp:Label ID="Label16" Text='<%#Eval("Adjustments")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="EqualTo"
                                            AutoPostBackOnFilter="true" DataField="ClosingStock" SortExpression="ClosingStock"
                                            DataType="System.Decimal" UniqueName="ClosingStock">
                                            <HeaderTemplate>
                                                <div class="customercannedreport_header">
                                                </div>
                                                <div class="customercannedreport_header">
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label17" Text='<%#Eval("ClosingStock")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ReleasesOverLast13Weeks"
                                            SortExpression="ReleasesOverLast13Weeks" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                            DataType="System.Decimal" UniqueName="ReleasesOverLast13Weeks">
                                            <HeaderTemplate>
                                                <div class="customercannedreport_header">
                                                </div>
                                                <div class="customercannedreport_header">
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("ReleasesOverLast13Weeks")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Wrap="true" DataField="WeeksRemaining" SortExpression="WeeksRemaining"
                                            DataType="System.Decimal" UniqueName="WeeksRemaining">
                                            <HeaderTemplate>
                                                <div class="customercannedreport_header">
                                                </div>
                                                <div class="customercannedreport_header">
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label19" runat="server" Text='<%#Eval("WeeksRemaining")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                    <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                </ClientSettings>
                                <FilterMenu OnClientShown="MenuShowing" />
                            </telerik:RadGrid>
                        </div>
                        <%--Stock Allocated Report New 19-12-16 --%>
                        <div>
                        <telerik:RadGrid ID="RadGrid_stockallocatedcsutomer_new" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true"
                                Visible="false" OnNeedDataSource="RadGrid_stockallocatedcsutomer_OnNeedDataSource"
                                OnItemDataBound="RadGrid_stockallocatedcsutomer_ItemDataBound" CssClass="AddBorders border0Imp"
                                AllowSorting="true" HeaderStyle-ForeColor="#525252" ItemStyle-BorderWidth="0"
                                HeaderStyle-BorderWidth="0" GroupingSettings-CaseSensitive="false">
                                <PagerStyle AlwaysVisible="true" />                             
                                <MasterTableView CommandItemDisplay="Top" CssClass="collapse">
                                    <AlternatingItemStyle CssClass="backgroundwhite" />
                                    <HeaderStyle CssClass="bordertop backgroundwhite" ForeColor="#525252" />
                                    <CommandItemTemplate>
                                        <table class="DivButtonsHeader" style="width: 100%; background-color: White; background: white;
                                            color: #525252;">
                                            <tr>
                                                <td class="product_reportwidth30" width="100px">
                                                    <div style="margin-left: 15px; width: 65px; margin: 5px; margin-right: 200px; margin-bottom: 20px;">
                                                        <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="ImageButton3" OnClick="btnback_reports_order"
                                                            CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                        <div style="margin-left: 43px; margin-top: -18px;">
                                                            <asp:LinkButton ID="LinkButton1filter_stockallocatedreport" runat="server" CssClass="anchortagcolor_enduserreport"
                                                                Style="text-decoration: underline; margin-right: 10px; white-space: nowrap; font-weight: bold;"
                                                                OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                            <div style="margin-left: 105px; margin-top: -16px;">
                                                                <asp:LinkButton ID="export_stock_allocatedreport" CssClass="anchortagcolor_enduserreport"
                                                                    Text="Export to Excel" runat="server" CausesValidation="false" OnClick="lnkDownload_OnClick" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="product_reportwidth35">
                                                    <%--<div id="Div1" style="height: 23px; margin-left: 15px;">
                                           
                                        </div>--%>
                                                </td>
                                                <td align="left">
                                                    <table class="ver_align_middle" style="margin: 6px;">
                                                        <tr>
                                                            <%--<td>
                                                    <asp:Label ID="Label4" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Customer_Name")%>
                                                    </asp:Label>
                                                </td>
                                                <td>
                                                    &nbsp;<asp:DropDownList ID="ddlParticularCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        onchange="Javascript:GetParticularSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                </td>--%>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label1" runat="server" Style="margin-right: 10px; white-space: nowrap;">
                                                      <b><%=objLanguage.GetLanguageConversion("Date_Range")%>:  </b>
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label2" runat="server" Style="margin-right: 4px;">
                                                          <%=objLanguage.GetLanguageConversion("From")%>
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textboxnew" Width="125px"
                                                                    Height="18px" Style="margin-right: 10px;"></asp:TextBox>
                                                            </td>
                                                            <%-- <td class="tdwidth">
                                                    </td>--%>
                                                            <td class="ver_align_middle">
                                                                <asp:Label ID="Label3" runat="server" Style="margin-right: 4px;">
                                                          <%=objLanguage.GetLanguageConversion("To")%>
                                                                </asp:Label>
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxnew" Width="125px" Height="18px"
                                                                    Style="margin-right: 10px;">
                                                                </asp:TextBox>
                                                            </td>
                                                            <td class="tdwidth">
                                                            </td>
                                                            <td class="ver_align_middle">
                                                                <asp:Button ID="Button1" runat="server" CssClass="x-btnpro Grey main" Height="22px"
                                                                    Text="Go" OnClick="btnProductGoNew_OnClick" Style="padding: 0; font-size: 13px;
                                                                    font-family: Sans-Serif;" />
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <div style="float: right;">
                                                        <%-- <asp:LinkButton ID="LinkButton1filter_adjustment" runat="server" CssClass="anchortagcolor_enduserreport"
                                                        Style="text-decoration: underline; margin-right: 10px; white-space: nowrap; font-weight: bold;"
                                                        OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ParentCategory/SubCategory"
                                            SortExpression="ParentCategory/SubCategory">
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("ParentCategory/SubCategory")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="Itemcode"
                                            SortExpression="Itemcode">
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%#Eval("Itemcode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="CustomerCode"
                                            SortExpression="CustomerCode">
                                            <ItemTemplate>
                                                <asp:Label ID="Label12" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="Contains" FilterControlWidth="70px" DataField="ItemTitle"
                                            SortExpression="ItemTitle">
                                            <ItemTemplate>
                                                <asp:Label ID="Label21" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="10%" ItemStyle-Width="10%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ItemDescription"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" SortExpression="ItemDescription">
                                            <ItemTemplate>
                                                <asp:Label ID="Label23" runat="server" Text='<%#Eval("ItemDescription")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="Openingstock" SortExpression="Openingstock"
                                            CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                            UniqueName="Openingstock">
                                            <ItemTemplate>
                                                <asp:Label ID="Label24" runat="server" Text='<%#Eval("Openingstock")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="2%" ItemStyle-Width="2%" AllowFiltering="true" HeaderStyle-Wrap="true"
                                    HeaderStyle-Font-Bold="true" ItemStyle-Wrap="true" DataField="AllocatedQty" SortExpression="AllocatedQty"
                                    CurrentFilterFunction="EqualTo" AutoPostBackOnFilter="true" DataType="System.Decimal"
                                    UniqueName="AllocatedQty">
                                    <ItemTemplate>
                                    <asp:Label ID="Label25" runat="server" Text='<%#Eval("AllocatedQty")%>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" DataField="Releases"
                                            ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" SortExpression="Releases" DataType="System.Decimal"
                                            UniqueName="Releases">
                                            <ItemTemplate>
                                                <asp:Label ID="Label26" runat="server" Text='<%#Eval("Releases")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" DataField="Receipts" SortExpression="Receipts"
                                            DataType="System.Decimal" UniqueName="Receipts">
                                            <ItemTemplate>
                                                <asp:Label ID="Label27" runat="server" Text='<%#Eval("Receipts")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" DataField="Adjustments" SortExpression="Adjustments"
                                            DataType="System.Decimal" UniqueName="Adjustments">
                                            <ItemTemplate>
                                                <asp:Label ID="Label28" Text='<%#Eval("Adjustments")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" CurrentFilterFunction="EqualTo"
                                            AutoPostBackOnFilter="true" DataField="ClosingStock" SortExpression="ClosingStock"
                                            DataType="System.Decimal" UniqueName="ClosingStock">
                                            <HeaderTemplate>
                                                <div class="customercannedreport_header">
                                                </div>
                                                <div class="customercannedreport_header">
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label29" Text='<%#Eval("ClosingStock")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="7%" ItemStyle-Width="7%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" AllowFiltering="true" DataField="ReleasesOverLast13Weeks"
                                            SortExpression="ReleasesOverLast13Weeks" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"
                                            DataType="System.Decimal" UniqueName="ReleasesOverLast13Weeks">
                                            <HeaderTemplate>
                                                <div class="customercannedreport_header">
                                                </div>
                                                <div class="customercannedreport_header">
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label30" runat="server" Text='<%#Eval("ReleasesOverLast13Weeks")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="true" AutoPostBackOnFilter="true"
                                            CurrentFilterFunction="EqualTo" HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true"
                                            ItemStyle-Wrap="true" DataField="WeeksRemaining" SortExpression="WeeksRemaining"
                                            DataType="System.Decimal" UniqueName="WeeksRemaining">
                                            <HeaderTemplate>
                                                <div class="customercannedreport_header">
                                                </div>
                                                <div class="customercannedreport_header">
                                                </div>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label31" runat="server" Text='<%#Eval("WeeksRemaining")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                                <ClientSettings AllowColumnsReorder="false" ReorderColumnsOnClient="false" AllowDragToGroup="false">
                                    <ClientEvents OnFilterMenuShowing="filterMenuShowing" />
                                </ClientSettings>
                                <FilterMenu OnClientShown="MenuShowing" />
                            </telerik:RadGrid>
                        </div>
                        <%--Stock Report with Quarterly Sales--%>
                        <div>
                            <telerik:RadGrid ID="GridProductReport_quarterlysales" Width="100%" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true"
                                Visible="false" OnNeedDataSource="GridProductReport_OnNeedDataSource" OnItemDataBound="GridProductReport_ItemDataBound"
                                ItemStyle-BorderWidth="0" HeaderStyle-ForeColor="#525252" HeaderStyle-BorderWidth="0"
                                CssClass="AddBorders border0Imp">
                                <PagerStyle AlwaysVisible="true" />
                                 <GroupingSettings CaseSensitive="false" />
                                <MasterTableView CommandItemDisplay="Top" CssClass="collapse">
                                    <AlternatingItemStyle CssClass="backgroundwhite" />
                                    <ItemStyle CssClass="backgroundwhite" />
                                    <HeaderStyle CssClass="bordertop backgroundwhite" ForeColor="#525252" />
                                    <CommandItemTemplate>
                                        <table class="DivButtonsHeader ver_align_middle" style="width: 100%; background: white;
                                            background-color: White;">
                                            <tr>
                                                <td class="product_reportwidth30">
                                                    <div style="margin-left: 15px; margin: 5px; margin-bottom: 16px;">
                                                        <asp:ImageButton runat="server" ToolTip="Back to Reports" ID="ImageButton4" OnClick="btnback_reports_order"
                                                            CausesValidation="false" ImageUrl="~/images/image_EM_b.png" />
                                                        <div style="margin-left: 45px; margin-top: -19px;">
                                                            <asp:LinkButton ID="lnkBtnClearFilter_quarterlysales" runat="server" CssClass="anchortagcolor_enduserreport"
                                                                Style="text-decoration: underline; font-weight: bold;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                            <asp:LinkButton ID="export_quarterlysales" runat="server" Style="margin-left: 5px;"
                                                                CssClass="anchortagcolor_enduserreport" Text="Export to Excel" OnClick="lnkDownload_OnClick" />
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="product_reportwidth35">
                                                    <%-- <div id="Div1" style="height: 23px; margin-left: 15px;">
                                            
                                        </div>--%>
                                                </td>
                                                <td align="left">
                                                    <table>
                                                        <tr>
                                                            <%-- <td>
                                                        <asp:Label ID="lblCustomerName" runat="server" CssClass="lable_bold">
                                                          <%=objLanguage.GetLanguageConversion("Filter_by_Customer")%>:
                                                        </asp:Label>
                                                    </td>
                                                    <td>&nbsp;<asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="product_reportcannedddl"
                                                        OnSelectedIndexChanged="ddlCustomerName_OnSelectedIndexChanged" AutoPostBack="true"
                                                        onchange="Javascript:GetSelectedClientID(this.id);">
                                                    </asp:DropDownList>
                                                    </td>--%>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="vertical-align: middle;">
                                                    <div style="float: right;">
                                                        <%--<asp:LinkButton ID="lnkBtnClearFilter_quarterlysales" runat="server" CssClass="anchortagcolor_enduserreport"
                                                        Style="text-decoration: underline; font-weight: bold;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>--%>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </CommandItemTemplate>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Category" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                            HeaderStyle-Wrap="false" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="Category"
                                            FilterControlWidth="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Customer Code" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="CustomerCode"
                                            FilterControlWidth="70px">
                                            <%-- <HeaderTemplate>
                                        <table style="font-weight: bold; width: 50px">
                                            <tr>
                                                <td style="text-align: center">
                                                    Customer
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    Code
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>--%>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustomerCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Item Title" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                            HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" DataField="ItemTitle" CurrentFilterFunction="Contains"
                                            FilterControlWidth="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="Label32" runat="server" Text='<%#Eval("ItemTitle")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Product Description" HeaderStyle-HorizontalAlign="Left"
                                            ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="10%" ItemStyle-Width="10%"
                                            HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" DataField="ProductDescription"
                                            FilterControlWidth="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblProdDesc" runat="server" Text='<%#Eval("ProductDescription")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="5%" ItemStyle-Width="5%" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                                            DataField="OpeningStock" HeaderStyle-Font-Bold="true"  AllowFiltering="false">
                                            <HeaderTemplate>
                                                <div class="cannedreport_header">
                                                    Stock on Hand
                                                </div>
                                                <div class="cannedreport_header">
                                                    
                                                </div>
                                                <%--<table class="boldwidth">
                                            <tr>
                                                <td class="txtcentre">
                                                    Opening
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    Stock
                                                </td>
                                            </tr>
                                        </table>--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblState" runat="server" Text='<%#Eval("OpeningStock")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Supplier" HeaderStyle-HorizontalAlign="left"
                                            ItemStyle-HorizontalAlign="left" HeaderStyle-Width="5%" ItemStyle-Width="5%"
                                            AutoPostBackOnFilter="true" AllowFiltering="true" CurrentFilterFunction="Contains"
                                            HeaderStyle-Wrap="true" HeaderStyle-Font-Bold="true" DataField="Supplier" ItemStyle-Wrap="true"
                                            FilterControlWidth="70px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalesLastMonth" runat="server" Text='<%#Eval("Supplier")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="6%" ItemStyle-Width="6%" DataField="Sales_Incl_BackOrders"
                                            HeaderStyle-Wrap="false" ItemStyle-Wrap="false" HeaderStyle-Font-Bold="true" AllowFiltering="false">
                                            <HeaderTemplate>
                                                <table class="boldwidth">
                                                    <tr>
                                                        <td class="txtcentre">
                                                            <b>Sales</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txtcentre">
                                                            <b>(incl.Back Orders)</b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("Sales_Incl_BackOrders")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Receipts" HeaderStyle-HorizontalAlign="right"
                                            ItemStyle-HorizontalAlign="right" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                            HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" DataField="Receipts"
                                            AllowFiltering="false">
                                            <HeaderTemplate>
                                                <div class="cannedreport_header">
                                                    Receipts&nbsp;<span class="productcannedreport_receipts">*</span>
                                                </div>
                                                <%-- <table class="reporttablefont">
                                            <tr>
                                                <td>
                                                    Receipts&nbsp;<span style="vertical-align: middle; color: Red">*</span>
                                                </td>
                                            </tr>
                                        </table>--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDepartment" runat="server" Text='<%#Eval("Receipts")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Adjustment" HeaderStyle-HorizontalAlign="right"
                                            ItemStyle-HorizontalAlign="right" HeaderStyle-Width="3%" ItemStyle-Width="3%"
                                            HeaderStyle-Wrap="true" ItemStyle-Wrap="true" HeaderStyle-Font-Bold="true" DataField="Adj"
                                            AllowFiltering="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblContactName" Text='<%#Eval("Adj")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" HeaderStyle-Wrap="true" ItemStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" DataField="AvailableStock" AllowFiltering="false">
                                            <HeaderTemplate>
                                                <div class="cannedreport_header">
                                                    Available
                                                </div>
                                                <div class="cannedreport_header">
                                                    Stock
                                                </div>
                                                <%-- <table class="reporttablefont">
                                            <tr>
                                                <td class="txtcentre">
                                                    Available
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    Stock
                                                </td>
                                            </tr>
                                        </table>--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCentreName" Text='<%#Eval("AvailableStock")%>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="6%" ItemStyle-Width="6%" HeaderStyle-Wrap="false" ItemStyle-Wrap="false"
                                            HeaderStyle-Font-Bold="true" DataField="Last_13_WeeksSales" AllowFiltering="false">
                                            <HeaderTemplate>
                                                <div class="cannedreport_header">
                                                    Last
                                                </div>
                                                <div class="cannedreport_header">
                                                    13 Weeks Sales
                                                </div>
                                                <%-- <table class="reporttablefont">
                                            <tr>
                                                <td class="txtcentre">
                                                    Last
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    13 weeks Sales
                                                </td>
                                            </tr>
                                        </table>--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalesThisWeek" runat="server" Text='<%#Eval("Last_13_WeeksSales")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                                            HeaderStyle-Width="3%" ItemStyle-Width="3%" AllowFiltering="false" HeaderStyle-Wrap="true"
                                            HeaderStyle-Font-Bold="true" DataField="WeeksRemaining" ItemStyle-Wrap="true">
                                            <HeaderTemplate>
                                                <div class="cannedreport_header">
                                                    Weeks
                                                </div>
                                                <div class="cannedreport_header">
                                                    Remaining
                                                </div>
                                                <%-- <table class="reporttablefont">
                                            <tr>
                                                <td class="txtcentre">
                                                    Weeks
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txtcentre">
                                                    remaining
                                                </td>
                                            </tr>
                                        </table>--%>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalesLastWeek" runat="server" Text='<%#Eval("WeeksRemaining")%>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" />
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Back Order Quantity" HeaderStyle-HorizontalAlign="Right"
                                            ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="6%" ItemStyle-Width="6%"
                                            AllowFiltering="false" HeaderStyle-Wrap="false" HeaderStyle-Font-Bold="true" ItemStyle-Wrap="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalesThisMonth" runat="server" Text='<%#Eval("Backorderunits")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>

                         <%--Stock Usage Report - Cost Price --%>
                        <div>
                            <div style="padding:15px;text-align:left;" runat="server" visible="false" id="StockUsage_PacksReportFilters">
                                <asp:LinkButton ID="lnkBtnClearFilter_StockUsage_Packs" runat="server" CssClass="anchortagcolor_enduserreport"
                                        Style="text-decoration: underline; font-weight: bold;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                <asp:LinkButton ID="export_StockUsage_Packs" runat="server" Style="margin-left: 5px;"
                                        CssClass="anchortagcolor_enduserreport" Text="Export to Excel" OnClick="lnkDownload_OnClick"/>
                            </div>
                            <telerik:RadGrid ID="RadStockUsage_Packs"  Width="100%" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true" HeaderStyle-Font-Bold="true"
                                Visible="false" ItemStyle-BorderWidth="0" HeaderStyle-ForeColor="#525252" HeaderStyle-BorderWidth="0"
                                CssClass="AddBorders border0Imp" OnItemCommand="RadGrid_RadStockUsage_Packs_ItemCommand"
                                OnNeedDataSource="GridStockUsage_PacksReport_OnNeedDataSource">
                                <MasterTableView CssClass="collapse">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="ItemCode" HeaderText="Item Code" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="ItemTitle" HeaderText="Item Title" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="SoldInPacksOf" HeaderText="UOI" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="QuantityOnHand" HeaderText="Quantity On Hand" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AllocatedStock" HeaderText="Allocated Stock" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AvailableStock" HeaderText="Available Stock" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StockOnBackOrder" HeaderText="Stock On Backorder" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CostPerPack" HeaderText="Cost Per Pack" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="BackOrderValue" HeaderText="Backorder Value" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CostQuantityOnBackOrder" HeaderText="Cost Value" AllowFiltering="true" AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>

                         <%--Stock Usage History Report --%>
                        <div>
                            <div style="padding:15px;text-align:left;" runat="server" visible="false" id="StockUsageHistoryReportFilters">
                                <asp:LinkButton ID="lnkBtnClearFilter_stockusagehistory" runat="server" CssClass="anchortagcolor_enduserreport"
                                        Style="text-decoration: underline; font-weight: bold;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                <asp:LinkButton ID="export_stockusagehistory" runat="server" Style="margin-left: 5px;"
                                        CssClass="anchortagcolor_enduserreport" Text="Export to Excel" OnClick="lnkDownload_OnClick" />
                                <asp:DropDownList ID="ddldepartment1" runat="server" CssClass="product_reportcannedddl"
                                      onchange="Javascript:GetParticularSelectedDepatmentID(this.id);" Height="20px">
                                </asp:DropDownList>
                               <asp:DropDownList ID="ddlMonthCategory1" runat="server" CssClass="product_reportcannedddl"
                                    onchange="Javascript:GetselectedmonthCategory(this.id);" style="margin-left:15px" Height="20px" Width="210px">
                               </asp:DropDownList>
                                <asp:Button ID="FilterButton" runat="server" Text="GO" style="margin-left:15px;font-weight:bold;" OnClick="FilterButton_Click" />
                            </div>
                            <telerik:RadGrid ID="RadGrid_StockUsageHistoryReport"  Width="100%" runat="server"
                                AutoGenerateColumns="false" AllowPaging="true" PageSize="50" AllowFilteringByColumn="true" HeaderStyle-Font-Bold="true"
                                Visible="false" ItemStyle-BorderWidth="0"  HeaderStyle-ForeColor="#525252"  HeaderStyle-BorderWidth="0"
                                CssClass="AddBorders border0Imp" OnItemCommand="RadGrid_StockUsageHistoryReport_ItemCommand"
                                OnItemCreated="RadGrid_StockUsageHistoryReport_ItemCreated" OnNeedDataSource="GridStockUsageHistoryReport_OnNeedDataSource">
<%--                                OnItemDataBound="RadGrid_StockUsageHistoryReport_ItemDataBound"--%>
                                <MasterTableView CssClass="collapse">
                                   <%-- <CommandItemTemplate>
                                        <asp:LinkButton ID="lnkBtnClearFilter_stockusagehistory" runat="server" CssClass="anchortagcolor_enduserreport"
                                                                Style="text-decoration: underline; font-weight: bold;" OnClick="lnkBtnClearFilter_Click">Clear All Filters</asp:LinkButton>
                                                            <asp:LinkButton ID="export_stockusagehistory" runat="server" Style="margin-left: 5px;"
                                                                CssClass="anchortagcolor_enduserreport" Text="Export to Excel" OnClick="lnkDownload_OnClick" />
                                    </CommandItemTemplate>--%>
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Item Code" AllowFiltering="true" HeaderText="Item Code"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Item Title" HeaderText="Item Title" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Month On List" HeaderText="Month on List" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Quantity on Hand" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo" HeaderText="Quantity On Hand"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Allocated Stock" HeaderText="Allocated Stock" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Available Stock" HeaderText="Available Stock" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StockOnBackOrder" HeaderText="Stock On Backorder" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Stock Sales Value" HeaderText="Stock Sales Value" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="UOI" HeaderText="UOI" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Avg Month Usage" HeaderText="Avg Month Usage" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>

                                         <telerik:GridBoundColumn DataField="Month Over" HeaderText="Month Over" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Total Sales" HeaderText="Total Sales" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="January" HeaderText="January" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="February" HeaderText="February" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="March" HeaderText="March" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="April" HeaderText="April" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="May" HeaderText="May" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="June" HeaderText="June" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="July" HeaderText="July" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="August" HeaderText="August" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="September" HeaderText="September" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="October" HeaderText="October" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="November" HeaderText="November" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="December" HeaderText="December" AllowFiltering="true"
                                            AutoPostBackOnFilter="true" CurrentFilterFunction="EqualTo"></telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </div>

                    </telerik:RadAjaxPanel>
                </div>
            </div>
            <asp:HiddenField ID="hdnFromDate" runat="server" />
            <asp:HiddenField ID="hdnToDate" runat="server" />
            <asp:HiddenField ID="hdnClientID" runat="server" Value="0" />
            <asp:HiddenField ID="hdnParticluarClientID" runat="server" Value="0" />
            <asp:HiddenField ID="hdnParticularCustomer" runat="server" Value="" />
            <asp:HiddenField ID="hdnJobSelectedClientID" runat="server" Value="0" />
            <asp:HiddenField ID="hdnParticularJobCustomer" runat="server" Value="0" />
            <asp:HiddenField ID="hdnTotalQty" runat="server" Value="0" />
            <asp:HiddenField ID="hdnTotalSalesValue" runat="server" Value="0" />
            <asp:HiddenField ID="hdnJobFormdate" runat="server" Value="0" />
            <asp:HiddenField ID="hdnJobToDate" runat="server" Value="0" />
            <asp:HiddenField ID="hdnProductFormDate" runat="server" Value="0" />
            <asp:HiddenField ID="hdnProductToDate" runat="server" Value="0" />
            <asp:HiddenField ID="hdnDepartmentID" runat="server" Value="" />
            <asp:HiddenField ID="hdnOrderClientID" runat="server" Value="" />
            <asp:HiddenField ID="hdnisstockItem" runat="server" Value="" />
            <asp:HiddenField ID="hdnisreplinsh" runat="server" Value="" />
            <asp:HiddenField ID="hdnOrderFromdate" runat="server" Value="0" />
            <asp:HiddenField ID="hdnOrderTodate" runat="server" Value="0" />
            <asp:HiddenField ID="hdnMonthCategory" runat="server" Value="" />
            <asp:HiddenField ID="hdnTotalcost" runat="server" Value="" />
            <asp:HiddenField ID="hdn_reportid_afterload" runat="server" Value="" />
            <asp:HiddenField ID="hdnOrderFromdate_cust" runat="server" Value="" />
            <asp:HiddenField ID="hdnOrderTodate_cust" runat="server" Value="" />
            <asp:HiddenField ID="hdnjobFromdate_cust" runat="server" Value="" />
            <asp:HiddenField ID="hdnjobtodate_cust" runat="server" Value="" />
            <asp:HiddenField ID="hdninvoiceFromdate_cust" runat="server" Value="" />
            <asp:HiddenField ID="hdninvoicetodate_cust" runat="server" Value="" />
            <asp:HiddenField ID="hdn_report_name_aftergen" runat="server" Value="" />
        </div>
    </div>
        </div>
     <script type="text/javascript">

         function GetselectedmonthCategory(id) {

             var hdnMonthCategory = document.getElementById("<%=hdnMonthCategory.ClientID %>");
             var ddlMonthCategory = document.getElementById(id);
             var ddlvalue = ddlMonthCategory.options[ddlMonthCategory.selectedIndex].value;
             if (ddlvalue != "") {
                 hdnMonthCategory.value = ddlvalue;
             }

             else {
                 hdnMonthCategory.value = "";
             }
         }
         $(document).ready(function () {
             //pageLoad();

         });
         function pageLoad() {


         }

         function page______Load() {
             var grid = $find("<%=RadGrid_Order_Report.ClientID%>");
             var grid_job1 = $find("<%=RadGrid_CustomerJobReport.ClientID%>");

             if (grid != null) {
                 if (document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report').style.display != 'none') {
                     document.getElementById('ctl00_HeaderPanel').style.width = '103.2%';
                     document.getElementById('ctl00_ContentPlaceHolder1_div_Order_systemgen_reports').style.width = "102%";

                 }
             }

             if (grid_job1 != null) {
                 if (document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport').style.display != 'none') {
                     document.getElementById('ctl00_HeaderPanel').style.width = '103.1%';
                     document.getElementById('ctl00_ContentPlaceHolder1_div_job_systemgeneratedreports').style.width = '101.5%';

                 }
             }
             var grid_job2 = $find("<%=RadGridReports_salesorderreport.ClientID%>");
             if (grid_job2 != null) {
                 if (document.getElementById('ctl00_ContentPlaceHolder1_RadGridReports_salesorderreport').style.display != 'none') {
                     //  document.getElementById('ctl00_HeaderPanel').style.width = '103.1%';
                     document.getElementById('ctl00_ContentPlaceHolder1_div_job_systemgeneratedreports').style.width = '98.5%';

                 }
             }

             var grid_stockbymonth = $find("<%=RadGrid_StockUsageReport_bymonthandyear.ClientID%>");
             if (grid_stockbymonth != null) {
                 if (document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_StockUsageReport_bymonthandyear').style.display != 'none') {
                     document.getElementById('ctl00_HeaderPanel').style.width = '104%';
                     document.getElementById('ctl00_ContentPlaceHolder1_div_products_system_generatedreports').style.width = '103%';

                 }
             }
             var grid_stockadjustment = $find("<%=RadGridProductReport_Customer_stockadjustment.ClientID%>");
             if (grid_stockadjustment != null) {
                 if (document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment').style.display != 'none') {
                     document.getElementById('ctl00_HeaderPanel').style.width = '103.1%';
                 }
             }

             var font = $("body").css("font").split(' ');
             var grid_reportnames = $find("<%=Grid_Estore_reports.ClientID%>");

             if (grid_reportnames != null) {
                 document.getElementById('ctl00_ContentPlaceHolder1_Grid_Estore_reports_ctl00').style.fontSize = font[4];
                 document.getElementById('ctl00_ContentPlaceHolder1_Grid_Estore_reports_ctl00').style.fontFamily = font[7] + font[8];
                 if (font == '') {
                     document.getElementById('ctl00_ContentPlaceHolder1_Grid_Estore_reports_ctl00').style.fontSize = '13px';
                     document.getElementById('ctl00_ContentPlaceHolder1_Grid_Estore_reports_ctl00').style.fontFamily = 'Helvetica, sans-serif';
                 }
             }
             var grid_order_byid = $find("<%=grid_reports_byreportid_order.ClientID%>");
             //order customized report
             if (grid_order_byid != null) {

                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_order_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_order_ctl00').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lbl_orderbyiddate').style.fontSize = '13px';
                 document.getElementById('lbl_orderbyiddate').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lbl_orderbyidfrom').style.fontSize = '13px';
                 document.getElementById('lbl_orderbyidfrom').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lbl_orderbyidto').style.fontSize = '13px';
                 document.getElementById('lbl_orderbyidto').style.fontFamily = 'Helvetica, sans-serif';


                 // document.getElementById('ctl00_HeaderPanel').style.width = "102.8%";
                 var w4 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_order').style.width = '100%';
                 var w1 = document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_order_ctl00').clientWidth;
                 var w5 = w1 - w4;
                 if (w1 > w4) {
                     w5 = w1 - w4;
                 }
                 else {
                     w5 = w4 - w1;
                 }
                 var w2 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 var w3 = 0;
                 if (w1 > w2) {
                     w3 = w1 - w2;
                 }
                 else {
                     w3 = w2 - w1;
                 }
                 //alert(w5);
                 document.getElementById('ctl00_HeaderPanel').style.width = document.getElementById('ctl00_HeaderPanel').clientWidth + w5 + 'px';
                 // document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = w1 + 'px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_order').style.marginRight = w3 + 'px';


             }

             var grid_job_byid = $find("<%=grid_reports_byreportid_jobs.ClientID%>");
             if (grid_job_byid != null) {

                 // document.getElementById('ctl00_HeaderPanel').style.width = "102.5%";
                 //document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = "101%";
                 // document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_jobs').style.width = "100%";


                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_jobs_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_jobs_ctl00').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lbl_jobdate_custreport').style.fontSize = '13px';
                 document.getElementById('lbl_jobdate_custreport').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lbl_jobdate_custreport_from').style.fontSize = '13px';
                 document.getElementById('lbl_jobdate_custreport_from').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lbl_jobdate_custreport_to').style.fontSize = '13px';
                 document.getElementById('lbl_jobdate_custreport_to').style.fontFamily = 'Helvetica, sans-serif';

                 var w4 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 var w1 = document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_jobs_ctl00').clientWidth;
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_jobs').style.width = '100%';
                 var w5 = 0;
                 if (w1 > w4) {
                     w5 = w1 - w4;
                 }
                 else {
                     w5 = w4 - w1;
                 }
                 var w2 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 var w3 = 0;
                 if (w1 > w2) {
                     w3 = w1 - w2;
                 }
                 else {
                     w3 = w2 - w1;
                 }
                 //alert(w3);
                 document.getElementById('ctl00_HeaderPanel').style.width = document.getElementById('ctl00_HeaderPanel').clientWidth + w5 + 'px';
                 // document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = w1 + 'px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_jobs').style.marginRight = w3 + 'px';

             }
             var grid_invoice_byid = $find("<%=grid_reports_byreportid_invoice.ClientID%>");
             if (grid_invoice_byid != null) {


                 // document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_invoice').style.width = "100%";

                 // document.getElementById('ctl00_HeaderPanel').style.width = "103.5%";
                 // document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = "102%";

                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_invoice_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_invoice_ctl00').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lbl_invoiceddaterange').style.fontSize = '13px';
                 document.getElementById('lbl_invoiceddaterange').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lblfrom').style.fontSize = '13px';
                 document.getElementById('lblfrom').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('lblto').style.fontSize = '13px';
                 document.getElementById('lblto').style.fontFamily = 'Helvetica, sans-serif';

                 var w4 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 var w1 = document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_invoice_ctl00').clientWidth;
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_invoice').style.width = '100%';
                 document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = w1 + 'px';
                 var w5 = 0;
                 if (w1 > w4) {
                     w5 = w1 - w4;
                 }
                 else {
                     w5 = w4 - w1;
                 }
                 var w2 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 var w3 = 0;
                 if (w1 > w2) {
                     w3 = w1 - w2;
                 }
                 else {
                     w3 = w2 - w1;
                 }
                 alert(w5);
                 document.getElementById('ctl00_HeaderPanel').style.width = document.getElementById('ctl00_HeaderPanel').clientWidth + w5 + 'px';
                 // document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = w1 + 'px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_invoice').style.marginRight = w3 + 'px';
             }

             var grid_product_byid = $find("<%=grid_reports_byreportid_product.ClientID%>");
             if (grid_product_byid != null) {

                 //document.getElementById('ctl00_HeaderPanel').style.width = "103.5%";
                 //document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = "102%";


                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_product_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_product_ctl00').style.fontFamily = 'Helvetica, sans-serif';

                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_product').style.width = "100%";

                 var w4 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 var w1 = document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_product_ctl00').clientWidth;
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_product').style.width = '100%';
                 var w5 = 0;
                 if (w1 > w4) {
                     w5 = w1 - w4;
                 }
                 else {
                     w5 = w4 - w1;
                 }
                 var w2 = document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').clientWidth;
                 var w3 = 0;
                 if (w1 > w2) {
                     w3 = w1 - w2;
                 }
                 else {
                     w3 = w2 - w1;
                 }
                 //alert(w3);
                 document.getElementById('ctl00_HeaderPanel').style.width = document.getElementById('ctl00_HeaderPanel').clientWidth + w5 + 'px';
                 // document.getElementById('ctl00_ContentPlaceHolder1_div_reportgrid').style.width = w1 + 'px';
                 document.getElementById('ctl00_ContentPlaceHolder1_grid_reports_byreportid_product').style.marginRight = w3 + 'px';
             }

             var grid_ordersystem_gen = $find("<%=RadGrid_Order_Report.ClientID%>");
             if (grid_ordersystem_gen != null) {


                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00').style.fontFamily = 'Helvetica, sans-serif;';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_Label20').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_Label20').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_chkreplishment').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_chkreplishment').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_Label22').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_Label22').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_Label6').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_Order_Report_ctl00_ctl02_ctl00_Label6').style.fontFamily = 'Helvetica, sans-serif';

             }

             var grid_jobsystem_prodsales = $find("<%=RadGrid_CustomerJobReport.ClientID%>");
             if (grid_jobsystem_prodsales != null) {



                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00').style.fontFamily = 'Helvetica, sans-serif;';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label20').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label20').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label22').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label22').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label6').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label6').style.fontFamily = 'Helvetica, sans-serif';

             }
             var grid_jobsystem_salesorder = $find("<%=RadGridReports_salesorderreport.ClientID%>");
             if (grid_jobsystem_salesorder != null) {



                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridReports_salesorderreport_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridReports_salesorderreport_ctl00').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label20').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label20').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label22').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label22').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label6').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_CustomerJobReport_ctl00_ctl02_ctl00_Label6').style.fontFamily = 'Helvetica, sans-serif';


             }

             var grid_product_stockusage = $find("<%=RadStockUsage_Packs_stockusagereport.ClientID%>");
             if (grid_product_stockusage != null) {


                 document.getElementById('ctl00_ContentPlaceHolder1_RadStockUsage_Packs_stockusagereport_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadStockUsage_Packs_stockusagereport_ctl00').style.fontFamily = 'Helvetica, sans-serif';

             }

             if (grid_product_stockusage != null) {
                 if (document.getElementById('ctl00_ContentPlaceHolder1_RadStockUsage_Packs_stockusagereport').style.display != 'none') {
                     // document.getElementById('ctl00_HeaderPanel').style.width = '103.1%';
                     document.getElementById('ctl00_ContentPlaceHolder1_div_products_system_generatedreports').style.width = '98.5%';

                 }
             }

             var grid_product_month = $find("<%=RadGrid_StockUsageReport_bymonthandyear.ClientID%>");
             if (grid_product_month != null) {
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_StockUsageReport_bymonthandyear_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_StockUsageReport_bymonthandyear_ctl00').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_StockUsageReport_bymonthandyear_ctl00_ctl02_ctl00_lblMonthHeading').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGrid_StockUsageReport_bymonthandyear_ctl00_ctl02_ctl00_lblMonthHeading').style.fontFamily = 'Helvetica, sans-serif';

             }
             var grid_product_stockadjustment = $find("<%=RadGridProductReport_Customer_stockadjustment.ClientID%>");
             if (grid_product_stockadjustment != null) {
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00').style.fontFamily = 'Helvetica, sans-serif';

                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00_ctl02_ctl00_Label20').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00_ctl02_ctl00_Label20').style.fontFamily = 'Helvetica, sans-serif';

                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00_ctl02_ctl00_Label22').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00_ctl02_ctl00_Label22').style.fontFamily = 'Helvetica, sans-serif';

                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00_ctl02_ctl00_Label6').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment_ctl00_ctl02_ctl00_Label6').style.fontFamily = 'Helvetica, sans-serif';
             }
             if (grid_product_stockadjustment != null) {
                 if (document.getElementById('ctl00_ContentPlaceHolder1_RadGridProductReport_Customer_stockadjustment').style.display != 'none') {
                     // document.getElementById('ctl00_HeaderPanel').style.width = '103.1%';
                     document.getElementById('ctl00_ContentPlaceHolder1_div_products_system_generatedreports').style.width = '101.5%';

                 }
             }

             var grid_product_qsales = $find("<%=GridProductReport_quarterlysales.ClientID%>");
             if (grid_product_qsales != null) {
                 document.getElementById('ctl00_ContentPlaceHolder1_GridProductReport_quarterlysales_ctl00').style.fontSize = '13px';
                 document.getElementById('ctl00_ContentPlaceHolder1_GridProductReport_quarterlysales_ctl00').style.fontFamily = 'Helvetica, sans-serif';
                 document.getElementById('ctl00_HeaderPanel').style.width = '101.5%';
             }
         }

         document.getElementById('ctl00_HeaderPanel').style.width = document.getElementById('div_Reports_Namesandreportgrid_main').style.width;

     </script>

</asp:Content>
