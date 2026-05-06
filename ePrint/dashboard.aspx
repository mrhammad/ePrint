<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="dashboard.aspx.cs" Inherits="ePrint.dashboard" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Charting" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/RadComboBox_eprintSkin.css" rel="stylesheet" type="text/css" />
    <script src="<%=strSitepath %>js/changeStyle.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="<%=strSitepath %>common/swazz_calendar.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="<%=strSitepath %>js/item/crm.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <link href="App_Themes/Theme1/item.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        div.AddBorders .rgHeader, div.AddBorders th.rgResizeCol, div.AddBorders .rgFilterRow td, div.AddBorders .rgRow td, div.AddBorders .rgAltRow td, div.AddBorders .rgEditRow td, div.AddBorders .rgFooter td {
            border-style: solid;
            border-color: #C9C9C9;
            border-width: 0 0 1px 0px;
        }

        .RadGrid .rgHeader, .RadGrid th.rgResizeCol {
            padding-top: 2px;
            text-align: left;
            font-weight: normal;
            padding-bottom: -4px;
        }

        .RadGrid .rgFilterRow td {
            padding-top: 5px;
            padding-bottom: 5px;
        }

        .RowMouseOver td {
            background-color: #D8D8D8 !important;
            height: auto;
        }

        .RowMouseOut {
            background: #ffffff;
            height: auto;
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

        .RadGrid_Default .rgFilterRow {
            display: none;
        }

        .rsAptDelete {
           
            visibility: hidden !important;
        }
         .rdclose {
              display:none !important;
           
        }

        .RadScheduler .rsAptEditSizingWrapper {
            position: absolute;
            width: 100%;
            visibility: hidden;
            display: none;
        }

        .RadScheduler_Default .rsAptCreate, .RadScheduler_Default .rsMonthView .rsAptCreate {
            background-color: #D8D8D8;
            background-image: url("");
            background-repeat: repeat-x;
        }

        .rsAdvInnerTitle {
            display: none;
            visibility: hidden;
        }

        .rsAdvancedEdit, .rsAdvancedModal {
            display: none;
            visibility: hidden;
        }

        .TelerikModalOverlay {
            display: none;
            visibility: hidden;
        }

        .RadScheduler_Default .rsFooter a {
            color: Black;
            background-color: transparent;
            background-image: url("WebResource.axd?d=u_oWiNrgcyawbMLiaSSpCBRHFi3r-3zQQrJREi73VmxW1riTmMTYkdY222X_eIJ-LZxInXueRSz5Yk6ZvpWXu4QYAo8ENsNhXt7iGirI9Sp4TKD1CaQhQKHQb4o8YfWE58Ip_cAU2qtOCbaowLU3GcutRss1&t=635183250712113359");
            background-repeat: no-repeat;
            font-family: "Verdana",Verdana,Arial,Helvetica;
        }

        .RadScheduler .rsFooter .rsFullTime {
            text-decoration: none;
            padding: 0px 0px 0px 23px;
            margin-left: 5px;
            font-size: 11px;
            line-height: 30px;
            background-position: 0px -252px;
        }

        .RadScheduler .rsHeader h2 {
            font-size: 13px;
            font-weight: normal;
            text-indent: 43px;
            height: 30px;
            display: block;
            overflow: hidden;
        }

        .TelerikModalOverlay123 {
            filter: alpha(opacity=60) !important;
            opacity: .60 !important;
            -moz-opacity: .60 !important;
            background-color: Black !important;
        }

        .RadDock .rdTitleBar em {
            font-family: "Verdana",Verdana,Arial,Helvetica;
            font-size: 11px;
            float: left;
            padding: 0px;
            margin: 0px;
            text-overflow: ellipsis;
            overflow: hidden;
            white-space: nowrap;
            font-weight: bold;
            margin-left: 4px;
            width:auto !important;
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

        #ctl00_ContentPlaceHolder1_RadDock18_C_ddlcustomer_ option {
            width: 250px;
        }

        #ctl00_ContentPlaceHolder1_RadDock19_C_ddlcustomertask_ option {
            width: 250px;
        }

        #ctl00_ContentPlaceHolder1_RadDock25_C_ddlcustomeradmin option {
            width: 250px;
        }
    </style>
    <div id="divLoadingImageCus" runat="server" style="display: none;">
        <div id="DivLayer" class="DialogueBackgroundSurveyView">
        </div>
        <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
            <img src="<%=ImgPath %>loading_new.gif" border="0" style="border-radius: 2px;" />
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        function OnClientInitialize(dock, args) {
            dock._resizeExtender._autoScrollEnabled = false;
        }
    </script>
    <script type="text/javascript" language="javascript">

        function PrintEstimateCountbyStatus(CopyMasterID, MasterID, GraphType, status, WidgetsTitle, ModuleName, ShowArchivedStatus) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&WidgetsTitle=" + WidgetsTitle + "&ModuleName=" + ModuleName + "&ShowArchivedStatus=" + ShowArchivedStatus, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintEstimateValuebyStatus(CopyMasterID, MasterID, GraphType, status, DisplayRecordSalesOf, ModuleName, WidgetsTitle, status, ShowArchivedStatus) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&salesperson=" + DisplayRecordSalesOf + "&ModuleName=" + ModuleName + "&WidgetsTitle=" + WidgetsTitle + "&status=" + status + "&ShowArchivedStatus=" + ShowArchivedStatus, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintEstimateValuebyStatusNew(CopyMasterID, MasterID, GraphType, status, DisplayRecordSalesOf, ModuleName, WidgetsTitle, ShowArchivedStatus) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&salesperson=" + DisplayRecordSalesOf + "&ModuleName=" + ModuleName + "&WidgetsTitle=" + WidgetsTitle + "&ShowArchivedStatus=" + ShowArchivedStatus, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function JobInvoiceByDueDate(CopyMasterID, MasterID, GraphType, status, DisplayRecordSalesOf, ModuleName, WhereCondition, NoOfRecords, WidgetsTitle, ShowArchivedStatus) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&salesperson=" + DisplayRecordSalesOf + "&ModuleName=" + ModuleName + "&WidgetsTitle=" + WidgetsTitle + "&ShowArchivedStatus=" + ShowArchivedStatus, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }
        function PrintLAtestNotes(CopyMasterID, MasterID, GraphType, status, CustomizeColumns, CustomerID, NoOfRecords, WidgetsTitle) {
            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&CustomizeColumns=" + CustomizeColumns + "&CustomerID=" + CustomerID + "&NoOfRecords=" + NoOfRecords + "&WidgetsTitle=" + WidgetsTitle, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintTaskCall(CopyMasterID, MasterID, GraphType, status, CustomizeColumns, CustomerID, NoOfRecords, Date, DisplayType, WidgetsTitle) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&CustomizeColumns=" + CustomizeColumns + "&SalesPID=" + CustomerID + "&NoOfRecords=" + NoOfRecords + "&Date=" + Date + "&DisplayType=" + DisplayType + "&WidgetsTitle=" + WidgetsTitle, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintCall1(CopyMasterID, MasterID, GraphType, status, CustomizeColumns, CustomerID, NoOfRecords, Date, DisplayType, WidgetsTitle) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&CustomizeColumns=" + CustomizeColumns + "&SalesPID=" + CustomerID + "&NoOfRecords=" + NoOfRecords + "&Date=" + Date + "&DisplayType=" + DisplayType + "&WidgetsTitle=" + WidgetsTitle, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintCallBar(CopyMasterID, MasterID, GraphType, status, CustomizeColumns, CustomerID, NoOfRecords, Date, DisplayType, WidgetsTitle) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&CustomizeColumns=" + CustomizeColumns + "&SalesPID=" + CustomerID + "&NoOfRecords=" + NoOfRecords + "&Date=" + Date + "&DisplayType=" + DisplayType + "&WidgetsTitle=" + WidgetsTitle + "&ChartType=" + "Bar", '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintCustomerActivity(CopyMasterID, MasterID, GraphType, status, CustomizeColumns, CustomerID, NoOfRecords, Date, DisplayType, CompanyType, WidgetsTitle) {
            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&CustomizeColumns=" + CustomizeColumns + "&CustomerID=" + CustomerID + "&NoOfRecords=" + NoOfRecords + "&Date=" + Date + "&DisplayType=" + DisplayType + "&CompanyType=" + CompanyType + "&WidgetsTitle=" + WidgetsTitle, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function ShowingActivities(CopyMasterID, MasterID, GraphType, status, CustomizeColumns, CustomerID, NoOfRecords, Date, DisplayType, DisplayRecordSalesOf, WidgetsTitle) {

            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&CustomizeColumns=" + CustomizeColumns + "&CustomerID=" + CustomerID + "&NoOfRecords=" + NoOfRecords + "&Date=" + Date + "&DisplayType=" + DisplayType + "&salesperson=" + DisplayRecordSalesOf + "&WidgetsTitle=" + WidgetsTitle, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintForecast(CopyMasterID, MasterID, GraphType, status, DisplayRecordSalesOf, ModuleName, EstimateType, QuarterType, WidgetsTitle, status, ShowArchivedStatus) {
            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&salesperson=" + DisplayRecordSalesOf + "&ModuleName=" + ModuleName + "&EstimateType=" + EstimateType + "&QuarterType=" + QuarterType + "&WidgetsTitle=" + WidgetsTitle + "&status=" + status + "&ShowArchivedStatus=" + ShowArchivedStatus, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function PrintForecastGrid(CopyMasterID, MasterID, GraphType, status, DisplayRecordSalesOf, ModuleName, EstimateType, QuarterType, WidgetsTitle, status, ShowArchivedStatus) {
            window.open("print.aspx?CopyMasterID=" + CopyMasterID + "&MasterID=" + MasterID + "&GraphType=" + GraphType + "&status=" + status + "&salesperson=" + DisplayRecordSalesOf + "&ModuleName=" + ModuleName + "&EstimateType=" + EstimateType + "&QuarterType=" + QuarterType + "&WidgetsTitle=" + WidgetsTitle + "&ForecastType=" + "Grid" + "&status=" + status + "&ShowArchivedStatus=" + ShowArchivedStatus, '', "width=1100,height=620,status=no,scrollbars=yes,resizable=yes,top=10,title=no,location=no,titlebar=no,left=10")
        }

        function getstatusvalue(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlStatusValue").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }
        function latestNotes(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnlatestNotes").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function TaskCall(selectedvalue, id) {

            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_taskcallcustomer").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;
        }

        function CallVS(selectedvalue, id) {

            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnCallVS").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function CallVSGrid1(selectedvalue, id) {

            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnCallVSGrid").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }


        function TaskCallDAte(selectedvalue, id) {
            if (selectedvalue == "Today") {
                selectedvalue = "1";
            }
            else if (selectedvalue == "TodayOverDue") {
                selectedvalue = "2";
            }
            else if (selectedvalue == "Tomorrow") {
                selectedvalue = "3";
            }
            else if (selectedvalue == "Next7Days") {
                selectedvalue = "4";
            }
            else if (selectedvalue == "Next7DaysPlusOverDue") {
                selectedvalue = "5";
            }
            else if (selectedvalue == "ThisMonth") {
                selectedvalue = "6";
            }
            else if (selectedvalue == "AllOpen") {
                selectedvalue = "7";
            }
            else if (selectedvalue == "---Select---") {
                selectedvalue = "-1";
            }
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_taskcalldate").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;
        }

        function CallVS1(selectedvalue, id) {

            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnCallVS1").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function CallVSGrid(selectedvalue, id) {

            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnCallVS1Grid").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function CustomerActivity(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnCompanyType").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function CustomerActivityNo(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnCompanyTypeNO").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function latestNotesNo(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnlatestNotesNo").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getstatusvalue1(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlStatusValue1").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getstatusvalue3(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlStatusValue3").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getstatusvalue4(selectedvalue, id) {

            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_ddlStatusValue4").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getSalesID(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnsalesID8").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }
        function getSalesID1(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnsalesID81").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getProSalesID(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnProSales").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }
        function getProSalesID1(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnProSales1").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }


        function SetshowingActivities(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnShowingActivities").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function SetshowingActivities1(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnShowingActivities1").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function SetshowingActivities2(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdnShowingActivities2").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getSalesidforecast(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdsalesForecast").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getSalesidforecast1(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdsalesForecast1").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function getSalesidforecast2(selectedvalue, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_hdsalesForecast2").value = selectedvalue;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnChartID").value = id;

            var btnid = document.getElementById("ctl00_ContentPlaceHolder1_btnInvchange");
            btnid.click();
        }

        function hideloading() {
            document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "none";
        }
        function ClientDockPositionChanged(sender, args) {
            var dockID = sender.get_id();
            var dockdaily = 'ctl00_ContentPlaceHolder1_RadDock' +<%:CopyMasterIDdaily%>;
            var dockmonthly = 'ctl00_ContentPlaceHolder1_RadDock' +<%:CopyMasterIDmonthly%>;
          
            if (dockID == dockdaily) {
               
                var element = document.getElementById('ctl00_ContentPlaceHolder1_RadDock' +<%:CopyMasterIDdaily%>+'_C_radChart_' +<%:CopyMasterIDdaily%>);
                element.style.display = 'none';
            
            }
            else if (dockID == dockmonthly) {
             
                var element = document.getElementById('ctl00_ContentPlaceHolder1_RadDock' +<%:CopyMasterIDmonthly%>+'_C_radChart_' +<%:CopyMasterIDmonthly%>);
                element.style.display = 'none'; 
            }

        }
        
    

    </script>
    <script type="text/javascript" language="javascript">
        $("#ctl00_ContentPlaceHolder1_RadDock10_C_radChart_10").elevateZoom({
            zoomType: "inner",
            cursor: "crosshair"
        });
    </script>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGridTodayAdmin">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridTodayAdmin" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGridToday">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridToday" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlCallTaskEvent">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridToday" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="ddlCallTaskEvent" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGridWeeks">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridWeeks" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="txtdate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGridWeeks" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="txtdate" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="lblSectionName" />
                    <telerik:AjaxUpdatedControl ControlID="lblTime" />
                    <telerik:AjaxUpdatedControl ControlID="lblSubjectDetail" />
                    <telerik:AjaxUpdatedControl ControlID="lblContact" />
                    <telerik:AjaxUpdatedControl ControlID="lblPhone" />
                    <telerik:AjaxUpdatedControl ControlID="lblAssignedTo" />
                    <telerik:AjaxUpdatedControl ControlID="lblStatues" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    </telerik:RadCodeBlock>
    <script type="text/javascript" language="javascript">

       

        function getLeftRightDockPanel() {
            var leftstr = '';
            var rightstr = '';
            var leftcounter = 0;
            var rightcounter = 0;
            var leftdockzone = document.getElementById('ctl00_ContentPlaceHolder1_raddockzonefirst');
            var righdockzone = document.getElementById('ctl00_ContentPlaceHolder1_raddockzonesecond');
            var hdnLeft = document.getElementById('ctl00_ContentPlaceHolder1_hdnLeftZoneIds');
            var hdnRight = document.getElementById('ctl00_ContentPlaceHolder1_hdnRightZoneIds');
            var divInleft = leftdockzone.getElementsByTagName('div');
            for (var i = 0; i < divInleft.length; i++) {
                if (divInleft[i].getAttribute('id') != null) {
                    if (divInleft[i].getAttribute('id').indexOf('RadDock') != -1 && divInleft[i].getAttribute('class') == 'RadDock RadDock_Default') {
                        leftcounter = leftcounter + 1;
                        leftstr = divInleft[i].getAttribute('id') + '^' + leftcounter;
                        hdnLeft.value += leftstr + ',';
                    }
                }
            }

            var divInright = righdockzone.getElementsByTagName('div');
            for (var i = 0; i < divInright.length; i++) {
                if (divInright[i].getAttribute('id') != null) {
                    if (divInright[i].getAttribute('id').indexOf('RadDock') != -1 && divInright[i].getAttribute('class') == 'RadDock RadDock_Default') {
                        rightcounter = rightcounter + 1;
                        rightstr = divInright[i].getAttribute('id') + '^' + rightcounter;
                        hdnRight.value += rightstr + ',';
                    }
                }
            }
            return true;
        }
    </script>
    <asp:HiddenField ID="hdnLeftZoneIds" runat="server" />
    <asp:HiddenField ID="hdnRightZoneIds" runat="server" />
    <asp:HiddenField ID="ddlStatusValue" runat="server" />
    <asp:HiddenField ID="ddlStatusValue1" runat="server" />
    <asp:HiddenField ID="ddlStatusValue3" runat="server" />
    <asp:HiddenField ID="ddlStatusValue4" runat="server" />
    <asp:HiddenField ID="hdnChartID" runat="server" />
    <asp:HiddenField ID="hdnlatestNotes" runat="server" />
    <asp:HiddenField ID="hdnlatestNotesNo" runat="server" />
    <asp:HiddenField ID="hdnPrint" runat="server" />
    <asp:HiddenField ID="taskcalldate" runat="server" />
    <asp:HiddenField ID="taskcallcustomer" runat="server" />
    <asp:HiddenField ID="hdnCompanyType" runat="server" />
    <asp:HiddenField ID="hdnCompanyTypeNO" runat="server" />
    <asp:HiddenField ID="hdnsalesID8" runat="server" />
    <asp:HiddenField ID="hdnsalesID81" runat="server" />
    <asp:HiddenField ID="hdnProSales" runat="server" />
    <asp:HiddenField ID="hdnProSales1" runat="server" />
    <asp:HiddenField ID="hdnShowingActivities" runat="server" />
    <asp:HiddenField ID="hdnShowingActivities1" runat="server" />
    <asp:HiddenField ID="hdnShowingActivities2" runat="server" />
    <asp:HiddenField ID="hdsalesForecast" runat="server" />
    <asp:HiddenField ID="hdsalesForecast1" runat="server" />
    <asp:HiddenField ID="hdsalesForecast2" runat="server" />
    <asp:HiddenField ID="hdnCallVS" runat="server" />
    <asp:HiddenField ID="hdnCallVS1" runat="server" />
    <asp:HiddenField ID="hdnCallVS1Grid" runat="server" />
    <asp:HiddenField ID="hdnCallVSGrid" runat="server" />
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="Windows7" runat="server"
        Skin="Default" />
    <div id="TelerikModalOverlay" class="TelerikModalOverlay123" style="position: absolute; left: 0px; top: 0px; z-index: 5555; background-color: rgb(170, 170, 170); opacity: 0.5; width: 100%; height: 200%; display: none;">
    </div>
    <div style="margin-top: -22px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 99.9%;">
            <tr valign="top">
                <td valign="top">
                    <div align="left" style="padding-left: 8px;">
                        <div id="DivMessage" style="width: 80%; margin-top: 11px;">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </td>
                <td valign="top">
                    <div style="float: right; padding-right: 8px; margin-top: 12px;">
                        <asp:Button ID="btnCustomize" runat="server" Text="Customize" CssClass="headerbutton white"
                            OnClick="btnCustomize_Click" OnClientClick="return loadingimage(this.id,'div_btnCustomize');"></asp:Button>
                        <div id="div_btnCustomize" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" alt="loading" border="0" />
                        </div>
                    </div>
                    <div style="float: right; padding-right: 8px; margin-top: 12px;">
                        <asp:Button ID="lnkSavesettings" runat="server" Text="Save current layout" CssClass="headerbutton white"
                            OnClick="lnkSavesettings_Click" OnClientClick="javascript:var a=getLeftRightDockPanel();if (a)loadingimage(this.id,'div_lnkSavesettings');return a;"></asp:Button>
                        <div id="div_lnkSavesettings" style="display: none">
                            <img src="<%=strImagepath %>radimg1.gif" alt="loading" border="0" />
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div style="width: 99%; float: left; margin: 0px 6px 30px -5px;">
        <asp:UpdatePanel ID="dddd" runat="server">
            <ContentTemplate>
                <asp:PlaceHolder ID="plhminidashboard" runat="server"></asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div style="display: none;">
                <asp:Button ID="btnInvchange" runat="server" Text="Invchange" OnClick="btnInvchange_Click" />
            </div>
            <div id="content" style="width: 99.9%; min-height: 400px;">
                <div style="width: 100%;">
                    <div style="width: 100%;">
                        <table id="Divmaintable" runat="server" border="0" cellpadding="0" cellspacing="0"
                            style="width: 100%;">                
                            <tr valign="top">
                                <td valign="top">
                                    <div>
                                        <telerik:RadDockLayout runat="server" EnableViewState="false" ID="rgWidgetslayout"
                                            EnableEmbeddedSkins="true" StoreLayoutInViewState="false">
                                         <%--    <telerik:RadDockZone FitDocks="true"  runat="server" ID="raddockzone2" Style="width: 99%; border-radius: 10px; overflow:hidden; float: left; vertical-align: top; border: dotted 0px #C8C8C8; margin-bottom: 10px; min-height: 5px;"
                                                        Orientation="Vertical" BorderWidth="0px" EnableEmbeddedSkins="true">
                                                <telerik:RadDock ID="RadDock1" Visible="false"   runat="server">
                                                    <ContentTemplate>
                                                        <canvas id="mixedChart"  width="1322" height="338"></canvas>
                                                    </ContentTemplate>
                                                 </telerik:RadDock>
                                             </telerik:RadDockZone>
                                             <telerik:RadDockZone FitDocks="true"  runat="server" ID="raddockzone3" Style="width: 99%; border-radius: 10px; overflow:hidden;  float: left; vertical-align: top; border: dotted 0px #C8C8C8; margin-bottom: 10px; min-height: 5px;"
                                                        Orientation="Vertical" BorderWidth="0px" EnableEmbeddedSkins="true">
                                               <telerik:RadDock ID="RadDock2" Visible="false"   runat="server">
  
                                                <ContentTemplate>
                                                    <canvas id="mixedChart1"  width="1322" height="338"></canvas>
                                                </ContentTemplate>
                                               </telerik:RadDock>
                                            </telerik:RadDockZone>--%>
                                            <telerik:RadDockZone FitDocks="true" runat="server" ID="raddockzonetop" Style="width: 99%; float: left; vertical-align: top; border: dotted 0px #C8C8C8; margin-bottom: 10px; min-height: 5px;"
                                                Orientation="Vertical" BorderWidth="0px" EnableEmbeddedSkins="true">
                                            </telerik:RadDockZone>
                                            <telerik:RadDockZone FitDocks="true" runat="server" ID="raddockzonefirst" Orientation="vertical"
                                                BorderWidth="0px" EnableEmbeddedSkins="true" Style="min-height: 260px; float: left; margin-bottom: 7px; vertical-align: top; margin-top: -18px;"
                                                Width="49%">
                                            </telerik:RadDockZone>
                                            <telerik:RadDockZone FitDocks="true" runat="server" ID="raddockzonesecond" Orientation="vertical"
                                                BorderWidth="0px" EnableEmbeddedSkins="true" Style="min-height: 260px; float: left; margin-bottom: 7px; vertical-align: top; padding-left: 10px; margin-top: -18px;"
                                                Width="49%">
                                            </telerik:RadDockZone>
                                        </telerik:RadDockLayout>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table id="divddlAssignto" runat="server" border="0" cellpadding="0" cellspacing="0"
                            width="100%" style="display: none;">
                            <tr>
                                <td>
                                    <div style="margin-bottom: 1px; float: left; margin-left: 6px;">
                                        <asp:DropDownList ID="ddlAssignto" runat="server" Width="150px" CssClass="simpledropdownPopup"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlAssignto_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" style="display: none;">
                            <tr>
                                <td valign="top" width="100%" colspan="2">
                                    <telerik:RadDockLayout runat="server" EnableViewState="false" ID="RadDockLayout1"
                                        EnableEmbeddedSkins="true" StoreLayoutInViewState="false">
                                        <telerik:RadDockZone EnableViewState="false" BorderStyle="None" Style="float: left; padding-left: 5px; padding-top: 7px; padding-bottom: 5px;"
                                            ID="RadDockZoneTopLeft"
                                            runat="server" CssClass="RadDockZoneTopLeft" Width="48.5%">
                                            <telerik:RadDock Skin="Default" EnableEmbeddedSkins="true" EnableViewState="true"
                                                Visible="false" ID="dockExchangeInformation" runat="server" EnableRoundedCorners="true"
                                                Title="Showing Activities for Today" Resizable="true" Width="45%" EnableAnimation="true"
                                                DockMode="Docked" EnableDrag="true" DefaultCommands="ExpandCollapse" Height="240px"
                                                OnClientInitialize="OnClientInitialize" Style="margin-bottom: 18px;">
                                                <ContentTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <div style="margin-bottom: 6px; float: right; margin-top: 6px; margin-right: 3px;">
                                                                    <asp:DropDownList ID="ddlCallTaskEvent" runat="server" Width="150px" CssClass="simpledropdownPopup"
                                                                        OnSelectedIndexChanged="ddlCallTaskEvent_OnSelectedIndexChanged" AutoPostBack="true"
                                                                        AppendDataBoundItems="true">
                                                                        <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                                                        <asp:ListItem Text="Call" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Task" Value="2"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <div style="border-bottom: 1px solid #C9C9C9; width: 99.7%">
                                                    </div>
                                                    <div style="margin-bottom: 5px;">
                                                        <telerik:RadGrid ID="RadGridToday" runat="server" AllowPaging="false" AllowSorting="false"
                                                            AutoGenerateColumns="false" PagerStyle-AlwaysVisible="false" GroupingEnabled="false"
                                                            PageSize="50" Width="99.5%" ShowGroupPanel="false" ShowStatusBar="false" HeaderStyle-Font-Bold="true"
                                                            GridLines="none" CssClass="AddBorders" EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333"
                                                            HeaderStyle-BorderStyle="Double" BorderColor="White" FilterItemStyle-HorizontalAlign="Justify"
                                                            Skin="Default" AllowFilteringByColumn="false" OnItemDataBound="RadGridToday_OnItemDataBound"
                                                            OnNeedDataSource="RadGridToday_OnNeedDataSource">
                                                            <AlternatingItemStyle BackColor="White" />
                                                            <PagerStyle AlwaysVisible="false" />
                                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                            <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                CommandItemDisplay="None" Width="100%">
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="3%"
                                                                        HeaderText="Action" ItemStyle-Width="3%" UniqueName="Action" AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <div style="margin-left: 8px;">
                                                                                <asp:ImageButton ID="CallIcon" runat="server" ImageUrl="~/images/Call.png" Enabled="false" />
                                                                                <asp:ImageButton ID="TaskIcon" runat="server" ImageUrl="~/images/Tasks.png" Enabled="false" />
                                                                                <asp:ImageButton ID="EventIcon" runat="server" ImageUrl="~/images/Events.png" Enabled="false" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="eventtime" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="5%" HeaderText="Time" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbleventtime" runat="server" Style="padding-left: 0px;" Text='<%#Eval("eventtime") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="Subject" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="13%" HeaderText="Subject" ItemStyle-Width="13%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubject" runat="server" Style="padding-left: 0px;" Text='<%#Eval("Subject") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="ContactName" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="10%" HeaderText="Contact" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblContactName" runat="server" Style="padding-left: 0px;" Text='<%#Eval("ContactName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="PersonalPhone" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="7%" HeaderText="Phone" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPersonalPhone" runat="server" Style="padding-left: 0px;" Text='<%#Eval("PersonalPhone") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="Status" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="7%" HeaderText="Status" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Style="padding-left: 0px;" Text='<%#Eval("Status") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                <NoRecordsTemplate>
                                                                    <div style="padding: 5px 0px 0px 5px">
                                                                        <%=objLangClass.GetLanguageConversion("No_Records_Found") %>
                                                                    </div>
                                                                </NoRecordsTemplate>
                                                            </MasterTableView>
                                                            <ClientSettings EnableRowHoverStyle="true">
                                                                <Selecting AllowRowSelect="True" />
                                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                                <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                                                            </ClientSettings>
                                                        </telerik:RadGrid>
                                                    </div>
                                                </ContentTemplate>
                                            </telerik:RadDock>
                                            <telerik:RadDock Skin="Default" EnableEmbeddedSkins="true" EnableViewState="true"
                                                Visible="true" ID="RadDockAssignto" runat="server" EnableRoundedCorners="true"
                                                Title="Showing Activities for Today" Resizable="false" Width="45%" EnableAnimation="true"
                                                DockMode="Docked" EnableDrag="false" DefaultCommands="ExpandCollapse" Height="350px"
                                                Style="margin-bottom: 18px; display: block;" OnClientInitialize="OnClientInitialize">
                                                <ContentTemplate>
                                                    <div id="MainAdminGrid" style="margin-top: 6px;">
                                                        <div style="border-bottom: 1px solid #C9C9C9; width: 99.6%">
                                                        </div>
                                                        <telerik:RadGrid ID="RadGridTodayAdmin" runat="server" AllowPaging="false" AllowSorting="false"
                                                            AutoGenerateColumns="false" PagerStyle-AlwaysVisible="false" GroupingEnabled="false"
                                                            PageSize="50" Width="99.5%" ShowGroupPanel="false" ShowStatusBar="false" HeaderStyle-Font-Bold="true"
                                                            GridLines="none" CssClass="AddBorders" EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333"
                                                            HeaderStyle-BorderStyle="Double" BorderColor="White" FilterItemStyle-HorizontalAlign="Justify"
                                                            Skin="Default" AllowFilteringByColumn="false" OnItemDataBound="RadGridTodayAdmin_OnItemDataBound"
                                                            OnNeedDataSource="RadGridTodayAdmin_OnNeedDataSource">
                                                            <AlternatingItemStyle BackColor="White" />
                                                            <PagerStyle AlwaysVisible="false" />
                                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                            <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                CommandItemDisplay="None" Width="100%">
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="3%"
                                                                        HeaderText="" ItemStyle-Width="3%" UniqueName="Action" AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <div style="margin-left: 8px;">
                                                                                <asp:ImageButton ID="CallIconAdmin" runat="server" ImageUrl="~/images/Call.png" Enabled="false" />
                                                                                <asp:ImageButton ID="TaskIconAdmin" runat="server" ImageUrl="~/images/Tasks.png"
                                                                                    Enabled="false" />
                                                                                <asp:ImageButton ID="EventIconAdmin" runat="server" ImageUrl="~/images/Events.png"
                                                                                    Enabled="false" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="eventtime" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="6%" HeaderText="" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbleventtimeAdmin" runat="server" Style="padding-left: 0px;" Text='<%#Eval("Time") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="Subject" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubjectAdmin" runat="server" Style="padding-left: 0px;" Text='<%#Eval("Subject") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="ContactName" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="10%" HeaderText="" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblContactNameAdmin" runat="server" Style="padding-left: 0px;" Text='<%#Eval("ContactName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="PersonalPhone" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="6%" HeaderText="" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPhoneAdmin" runat="server" Style="padding-left: 0px;" Text='<%#Eval("PersonalPhone") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="PersonalPhone" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="8%" HeaderText="" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAssignToAdmin" runat="server" Style="padding-left: 0px;" Text='<%#Eval("AssignTo") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="Status" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="7%" HeaderText="" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus" runat="server" Style="padding-left: 0px;" Text='<%#Eval("Status") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                <NoRecordsTemplate>
                                                                    <div align="left" style="margin-top: 5px; margin-left: 5px;">
                                                                        <%=objLangClass.GetLanguageConversion("No_Records_Found") %>
                                                                    </div>
                                                                </NoRecordsTemplate>
                                                            </MasterTableView>
                                                            <ClientSettings EnableRowHoverStyle="true">
                                                                <Selecting AllowRowSelect="True" />
                                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                                <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                                                            </ClientSettings>
                                                        </telerik:RadGrid>
                                                    </div>
                                                </ContentTemplate>
                                            </telerik:RadDock>
                                        </telerik:RadDockZone>
                                        <telerik:RadDockZone EnableViewState="false" BorderStyle="None" Style="float: left; padding-left: 15px; padding-top: 7px; padding-bottom: 5px;"
                                            ID="RadDockZone1"
                                            runat="server" CssClass="RadDockZoneTopLeft" Width="45%">
                                            <telerik:RadDock Skin="Default" EnableEmbeddedSkins="true" EnableViewState="true"
                                                Visible="false" ID="RadDockActivities" runat="server" EnableRoundedCorners="true"
                                                Title="Showing Activities for this Week" Resizable="true" Width="45%" EnableAnimation="true"
                                                DockMode="Docked" EnableDrag="true" DefaultCommands="ExpandCollapse" Height="240px"
                                                Style="margin-bottom: 18px;" OnClientInitialize="OnClientInitialize">
                                                <ContentTemplate>
                                                    <div style="margin-left: 1px; margin-top: 5px; margin-bottom: 15px;">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td>
                                                                    <div style="margin-bottom: 6px; float: right; margin-right: 3px;">
                                                                        <asp:TextBox ID="txtdate" runat="server" SkinID="textPad" CssClass="txtbox" Width="100px"
                                                                            CausesValidation="false" AutoPostBack="true" onkeypress="return CallMethid(event);"
                                                                            OnTextChanged="txtdate_OnTextChanged"> </asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div style="border-bottom: 1px solid #C9C9C9; width: 99.5%">
                                                        </div>
                                                        <telerik:RadGrid ID="RadGridWeeks" runat="server" AllowPaging="false" AllowSorting="false"
                                                            AutoGenerateColumns="false" PagerStyle-AlwaysVisible="false" GroupingEnabled="false"
                                                            PageSize="50" Width="99.5%" ShowGroupPanel="false" ShowStatusBar="false" HeaderStyle-Font-Bold="true"
                                                            GridLines="none" CssClass="AddBorders" EnableEmbeddedSkins="true" HeaderStyle-ForeColor="#333333"
                                                            HeaderStyle-BorderStyle="Double" BorderColor="White" FilterItemStyle-HorizontalAlign="Justify"
                                                            Skin="Default" AllowFilteringByColumn="false" OnItemDataBound="RadGridWeeks_OnItemDataBound"
                                                            OnNeedDataSource="RadGridWeeks_OnNeedDataSource">
                                                            <AlternatingItemStyle BackColor="White" />
                                                            <PagerStyle AlwaysVisible="false" />
                                                            <FilterMenu CssClass="RadMenu_Eprint_Skin" />
                                                            <MasterTableView OverrideDataSourceControlSorting="true" AllowFilteringByColumn="true"
                                                                CommandItemDisplay="None" Width="100%">
                                                                <Columns>
                                                                    <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="3%"
                                                                        HeaderText="Action" ItemStyle-Width="3%" UniqueName="Action" AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <div style="margin-left: 8px;">
                                                                                <asp:ImageButton ID="CallIconWeek" runat="server" ImageUrl="~/images/Call.png" Enabled="false" />
                                                                                <asp:ImageButton ID="TaskIconWeek" runat="server" ImageUrl="~/images/Tasks.png" Enabled="false" />
                                                                                <asp:ImageButton ID="EventIconWeek" runat="server" ImageUrl="~/images/Events.png"
                                                                                    Enabled="false" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="DueDate" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="6%" HeaderText="Date" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDueDate" runat="server" Style="padding-left: 0px;" Text='<%#Eval("DueDate") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="eventtime" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="6%" HeaderText="Time" ItemStyle-Width="6%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbleventtime1" runat="server" Style="padding-left: 0px;" Text='<%#Eval("eventtime") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="Subject" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="10%" HeaderText="Subject" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSubject1" runat="server" Style="padding-left: 0px;" Text='<%#Eval("Subject") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="ContactName" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="10%" HeaderText="Contact" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblContactName1" runat="server" Style="padding-left: 0px;" Text='<%#Eval("ContactName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="PersonalPhone" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="7%" HeaderText="Phone" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPersonalPhone1" runat="server" Style="padding-left: 0px;" Text='<%#Eval("PersonalPhone") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                    <telerik:GridTemplateColumn DataField="Status" HeaderStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-Width="7%" HeaderText="Status" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Left"
                                                                        AllowFiltering="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblStatus1" runat="server" Style="padding-left: 0px;" Text='<%#Eval("Status") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </telerik:GridTemplateColumn>
                                                                </Columns>
                                                                <NoRecordsTemplate>
                                                                    <div style="padding: 5px 0px 0px 5px">
                                                                        <%=objLangClass.GetLanguageConversion("No_Records_Found") %>
                                                                    </div>
                                                                </NoRecordsTemplate>
                                                            </MasterTableView>
                                                            <ClientSettings EnableRowHoverStyle="true">
                                                                <Selecting AllowRowSelect="True" />
                                                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                                                                <ClientEvents OnRowMouseOver="RowMouseOver" OnRowMouseOut="RowMouseOut" />
                                                            </ClientSettings>
                                                        </telerik:RadGrid>
                                                    </div>
                                                </ContentTemplate>
                                            </telerik:RadDock>
                                        </telerik:RadDockZone>
                                    </telerik:RadDockLayout>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <div id="DivClaenderView" runat="server" style="margin-top: 25px; display: none;">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <div style="margin-bottom: 10px; font-weight: bold;">
                                                        Showing All Activities
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <telerik:RadScheduler runat="server" ID="RadScheduler1" SelectedView="DayView" FirstDayOfWeek="Monday"
                                            LastDayOfWeek="Friday" AppointmentStyleMode="Default" OverflowBehavior="Expand"
                                            DataKeyField="ID" Width="60%" RowHeight="30px" DataSubjectField="Subject" DataDescriptionField="Description"
                                            DataStartField="DueDate" DataEndField="DueDate"
                                            OnAppointmentClick="RadScheduler1_OnAppointmentClick"
                                            Localization-HeaderToday="Today" Localization-AllDay="All Day" OnClientAppointmentMoving="OnClientAppointmentMoveStart">
                                            <AdvancedForm Modal="true" />
                                            <TimelineView UserSelectable="false" />
                                            <TimeSlotContextMenuSettings EnableDefault="false" />
                                            <AppointmentContextMenuSettings EnableDefault="false" />
                                            <AppointmentTemplate>
                                                <div style="font-weight: bold; color: Black">
                                                    <%# Eval("Subject") %>
                                                </div>
                                            </AppointmentTemplate>
                                        </telerik:RadScheduler>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div style="display: none; margin-top: -5px; margin-left: 5px;" id="divlblNowidgets" runat="server">
                            <asp:Label ID="lblNowidgets" runat="server" Text="No Widgets found" CssClass="nowidgets"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnUserID" runat="server" />
    <div>
        <telerik:RadWindowManager ID="rwmgrForAll" runat="server" Height="250px" Width="600px"
            EnableShadow="true" ReloadOnShow="true" AutoSize="false" Animation="None" Behaviors="Close,Reload,Move"
            KeepInScreenBounds="true" ShowContentDuringLoad="true" Modal="true" VisibleOnPageLoad="false">
            <Windows>
                <telerik:RadWindow ID="rwReferences" Skin="Default" runat="server" Height="250px"
                    Width="600px" EnableShadow="true" VisibleOnPageLoad="false" Top="0px" Left="0px"
                    ShowContentDuringLoad="false" Behaviors="Close,Reload,Move" VisibleStatusbar="false"
                    Title="Activities Details" Style="z-index: 555555;" OnClientClose="clientClose">
                    <ContentTemplate>
                        <div style="margin-top: 10px; margin-left: 10px;">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td valign="top" style="width: 150px;">
                                        <div class="bglabel" style="width: 150px;">
                                            <asp:Label ID="lblSection" runat="server" Text="Section Name"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div id="Div1" style="margin-left: 5px;">
                                            <asp:Label ID="lblSectionName" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" id="DivDate" style="width: 150px;">
                                        <div class="bglabel" style="width: 150px;">
                                            <asp:Label ID="Label2" runat="server" Text="Time"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div id="DivDate1" style="margin-left: 5px;">
                                            <asp:Label ID="lblTime" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px;">
                                        <div class="bglabel" style="width: 150px;">
                                            <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div style="margin-left: 5px;">
                                            <asp:Label ID="lblSubjectDetail" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px;">
                                        <div class="bglabel" style="width: 150px;">
                                            <asp:Label ID="Label1" runat="server" Text="Contact"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div style="margin-left: 5px;">
                                            <asp:Label ID="lblContact" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px;">
                                        <div class="bglabel" style="width: 150px;">
                                            <asp:Label ID="Label4" runat="server" Text="Phone"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div style="margin-left: 5px;">
                                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px;">
                                        <div class="bglabel" style="width: 150px;">
                                            <asp:Label ID="Label5" runat="server" Text="Assigned To"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div style="margin-left: 5px;">
                                            <asp:Label ID="lblAssignedTo" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" style="width: 150px;">
                                        <div class="bglabel" style="width: 150px;">
                                            <asp:Label ID="Label6" runat="server" Text="Statues"></asp:Label>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div style="margin-left: 5px;">
                                            <asp:Label ID="lblStatues" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ContentTemplate>
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>
    <script type="text/javascript">
 
 //$(document).ready(function () {

        //});
       
        function DailyData() {
            //widget 13
            var str1;
            debugger;
            $.ajax({
                type: "POST",
                url: "dashboard.aspx/GetDataDaily", // The URL of your WebMethod
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    // 'response.d' contains the JSON data returned from the server
                    str1 = response.d;
                    var name = 'ctl00_ContentPlaceHolder1_RadDock' +<%:CopyMasterIDdaily%>+'_C_mixedChartd';
                    var ctx = document.getElementById(name).getContext('2d');
                    var currencysymbol = str1.currency;
                    var format = str1.format;
                    var data = {};

                    if (str1.lastyeardata != null && str1.targets != null) {
                        // Sample data (replace this with data from your backend)
                        data = {
                            labels: str1.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str1.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                },
                                {
                                    label: "Last Month's Performance",
                                    type: 'line',
                                    //data: [8, 10, 6, 9, 7, 9, 11, 12, 13, 14, 15, 17],
                                    data: str1.lastyeardata,
                                    fill: false,
                                    borderColor: 'orange',
                                    borderWidth: 2
                                },
                                {
                                    label: 'Target',
                                    type: 'line',
                                    data: str1.targets,
                                    /* data: [2, 15, 7, 4, 11, 15, 8, 6, 7, 9, 11, 12],*/
                                    fill: false,
                                    borderColor: 'blue',
                                    borderWidth: 2
                                }
                            ]
                        };
                    }
                    else if (str1.lastyeardata == null && str1.targets != null) {
                        // Sample data (replace this with data from your backend)
                        data = {
                            labels: str1.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str1.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                },
                                {
                                    label: 'Target',
                                    type: 'line',
                                    data: str1.targets,
                                    /* data: [2, 15, 7, 4, 11, 15, 8, 6, 7, 9, 11, 12],*/
                                    fill: false,
                                    borderColor: 'blue',
                                    borderWidth: 2
                                }
                            ]
                        };
                    }
                    else if (str1.lastyeardata != null && str1.targets == null) {
                        // Sample data (replace this with data from your backend)
                        data = {
                            labels: str1.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str1.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                },
                                {
                                    label: "Last Month's Performance",
                                    type: 'line',
                                    //data: [8, 10, 6, 9, 7, 9, 11, 12, 13, 14, 15, 17],
                                    data: str1.lastyeardata,
                                    fill: false,
                                    borderColor: 'orange',
                                    borderWidth: 2
                                }
                            ]
                        };
                    }
                    else {
                        // Sample data (replace this with data from your backend)
                        data = {
                            labels: str1.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str1.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                }
                            ]
                        };
                    }



                    // Chart configuration
                    var config = {
                        type: 'bar', // Default chart type (will be overridden)
                        data: data,
                        options: {
                            scales: {
                                y: {
                                    ticks: {
                                        // Include a currency symbol with each tick
                                        callback: function (value, index, values) {
                                            return currencysymbol[index] + ' ' + value; // You can replace '€' with your desired currency symbol
                                        }
                                    }
                                }
                            },
      
                            plugins: {
                                tooltip: {
                                    callbacks: {
                               
                                     title: (tooltipItem, data) => {
                                        
                                            var lastMonthDateString = '';
                                            if (tooltipItem[0].dataset.label != 'Current' && tooltipItem[0].dataset.label != 'Target' && tooltipItem.length==1) {
                                                var dateObject = parseDate(tooltipItem[0].label, format);

                                                // Adjust to the last month
                                                dateObject.setMonth(dateObject.getMonth() - 1);

                                                // Format the date back into the original format
                                                lastMonthDateString = formatDate(dateObject, format);
                                            }
                                            else {
                                                lastMonthDateString = tooltipItem.label;
                                            }
                                            return lastMonthDateString;
                                      },
                                        label: (tooltipItem, data) => {
                                            // Add a dollar sign to the value
                                            const value = tooltipItem.dataset.label + ' : ' + currencysymbol[0]+ tooltipItem.formattedValue;
;
                                            return value;
                                        },

                                   
                                    },
                                },
                            },
                            
                          
                            // Other chart options...
                        }
                    };

                    // Create the chart
                    var mixedChart = new Chart(ctx, config);

                    // Now you can process the data (e.g., populate a table)
                },
                error: function (xhr, status, error) {
                    console.log("Error:", error);
                }
            });

        }

        function parseDate(dateString, format) {
            // Implement custom parsing logic based on the format
            // This is a simplified example, you might need to enhance it based on your requirements
            var parts;
            switch (format) {
                case 'MM/DD/YYYY':
                    parts = dateString.split('-');
                    return new Date(parts[2], parts[0] - 1, parts[1]);
                case 'DD/MM/YYYY':
                    parts = dateString.split('/');
                    return new Date(parts[2], parts[1] - 1, parts[0]);
                // Add more cases for other formats as needed
                default:
                    throw new Error('Unsupported date format');
            }
        }

        function formatDate(date, format) {
            // Implement formatting logic based on the format
            // This is a simplified example, you might need to enhance it based on your requirements
            switch (format) {
                case 'MM/DD/YYYY':
                    return (date.getMonth() + 1).toString().padStart(2, '0') + '/' + date.getDate().toString().padStart(2, '0') + '/' + date.getFullYear();
                case 'DD/MM/YYYY':
                    return date.getDate().toString().padStart(2, '0') + '/' + (date.getMonth() + 1).toString().padStart(2, '0') + '/' + date.getFullYear();
                // Add more cases for other formats as needed
                default:
                    throw new Error('Unsupported date format');
            }
        }




        function MonthlyData() {
            //widget 14
            var str;
            debugger;
            $.ajax({
                type: "POST",
                url: "dashboard.aspx/GetDataMonthly", // The URL of your WebMethod
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    // 'response.d' contains the JSON data returned from the server
                    str = response.d;
                    var data = {};
                    var name = 'ctl00_ContentPlaceHolder1_RadDock' +<%:CopyMasterIDmonthly%>+'_C_mixedChartm';
                    var ctx = document.getElementById(name).getContext('2d');
                    var currencysymbol = str.currency;
                    if (str.lastyeardata != null && str.targets != null) {
                        data = {
                            labels: str.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                },
                                {
                                    label: "Last Year's Performance",
                                    type: 'line',
                                    //data: [8, 10, 6, 9, 7, 9, 11, 12, 13, 14, 15, 17],
                                    data: str.lastyeardata,
                                    fill: false,
                                    borderColor: 'orange',
                                    borderWidth: 2
                                },

                                {
                                    label: 'Target',
                                    type: 'line',
                                    data: str.targets,
                                    /* data: [2, 15, 7, 4, 11, 15, 8, 6, 7, 9, 11, 12],*/
                                    fill: false,
                                    borderColor: 'blue',
                                    borderWidth: 2
                                }
                            ]
                        };
                    }
                    else if (str.lastyeardata == null && str.targets != null) {
                        data = {
                            labels: str.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                },

                                {
                                    label: 'Target',
                                    type: 'line',
                                    data: str.targets,
                                    /* data: [2, 15, 7, 4, 11, 15, 8, 6, 7, 9, 11, 12],*/
                                    fill: false,
                                    borderColor: 'blue',
                                    borderWidth: 2
                                }
                            ]
                        };
                    }
                    else if (str.lastyeardata != null && str.targets == null) {
                        data = {
                            labels: str.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                },
                                {
                                    label: "Last Year's Performance",
                                    type: 'line',
                                    //data: [8, 10, 6, 9, 7, 9, 11, 12, 13, 14, 15, 17],
                                    data: str.lastyeardata,
                                    fill: false,
                                    borderColor: 'orange',
                                    borderWidth: 2
                                }
                            ]
                        };
                    }
                    else {
                        data = {
                            labels: str.data,

                            //labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                            datasets: [
                                {
                                    label: 'Current',
                                    type: 'bar',
                                    data: str.subtotal,
                                    /*  data: [10, 15, 7, 12, 8, 9, 10, 11, 12, 14, 15, 16],*/
                                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                    borderColor: 'rgba(75, 192, 192, 1)',
                                    borderWidth: 1
                                }
                            ]
                        };
                    }




                    // Chart configuration
                    var config = {
                        type: 'bar', // Default chart type (will be overridden)
                        data: data,
                        options: {
                            scales: {
                                y: {
                                    ticks: {
                                        // Include a currency symbol with each tick
                                        callback: function (value, index, values) {
                                            return currencysymbol[0]  + ' ' + value; // You can replace '€' with your desired currency symbol
                                        }
                                    }
                                }
                            },
                            plugins: {
                                tooltip: {
                                    callbacks: {

                                        title: (tooltipItem, data) => {

                                            var year = '';
                                            if (tooltipItem[0].dataset.label != 'Current' && tooltipItem[0].dataset.label != 'Target' && tooltipItem.length == 1) {
                                                year = new Date().getFullYear() - 1;

                                            }
                                            else {
                                                year = new Date().getFullYear();
                                            }
                                            return tooltipItem[0].label + ' ' + year;
                                        },
                                        label: (tooltipItem, data) => {
                                            // Add a dollar sign to the value
                                            const value = tooltipItem.dataset.label + ' : ' + currencysymbol[0] + tooltipItem.formattedValue;

                                            return value;
                                        },


                                    },
                                },
                            },
                           

                    
                        }
                    };

                    // Create the chart
                    var mixedChart = new Chart(ctx, config);

                    // Now you can process the data (e.g., populate a table)
                },
                error: function (xhr, status, error) {
                    console.log("Error:", error);
                }
            });

        }

       
   
 
       
       
     



        function OnClientInitialize(dock, args) {
            dock._resizeExtender = false;
            dock._autoScrollEnabled = false;
        }
        function ddlAssigntoonChange(val, id) {
            document.getElementById("ctl00_ContentPlaceHolder1_hdnUserID").value = val;
            __doPostBack('ddlAssignto', '')
        }
    </script>
    <script type="text/javascript">
        function clientClose(sender, args) {
            document.getElementById("TelerikModalOverlay").style.display = "none";
        }
        function OnClientAppointmentMoveStart(sender, eventArgs) {
            eventArgs.set_cancel(true);
        }
    </script>
    <script type="text/javascript">
        function CallMethid(e) {
            var txt = document.getElementById('ctl00_ContentPlaceHolder1_RadDock1_C_txtdate');
            var evt = e ? e : window.event;

            if (evt.keyCode == 13) {
                if (txt.value != "") {

                    __doPostBack('txtdate', '')
                    return false;
                }
                else {
                    alert('Please select date');
                }
            }
        }
        function OpeneRadWindow() {
            document.getElementById("TelerikModalOverlay").style.display = "block";
            radopen(null, "rwReferences");
        }
        function OnRowClick(EditPage) {
            window.location = EditPage;
        }
    </script>
    <script type="text/javascript" language="javascript">
        window.setTimeout(function () {
            var label = document.getElementById('DivMessage');

            if (label != null) {
                label.style.display = 'none';
            }
        }, 7000);
    </script>


</asp:Content>
