<%@ Page Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="job_report.aspx.cs" Inherits="ePrint.Jobs.job_report" Title="Untitled Page" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/pagingreport.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Savereport" Src="~/usercontrol/Reports.ascx" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="reports">
        <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
            rel="stylesheet" />
        <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
        <script src="../js/jquery.ui.tabs.js" type="text/javascript"></script>
        <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
        <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%#VersionNumber%>'"></script>
        <script type="text/javascript">
            document.getElementById("ds00").style.width = (window.screen.availWidth * 2) + "px";
            document.getElementById("ds00").style.height = (window.screen.availHeight * 5) + "px";
            document.getElementById("ds00").style.display = "block";
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.customHeaderItem input[type=checkbox], .customHeaderItem label').click(function (event) {
                    event.stopPropagation();
                });
            });
        </script>
        <script type="text/javascript">

            $(document).ready(function () {

                $(function () {
                    var tabhdn = '<%=Session["DeleteMsg"] %>';
                    $('#tabs').tabs();
                    if (tabhdn != 'selectoptions') {
                        $('#tabs').tabs('select', '#tabs-1');
                    }
                    else {
                        $('#tabs').tabs('select', '#tabs-2');
                    }
                    document.getElementById("tabs").style.visibility = 'visible';
                });
            });
        </script>
        <style type="text/css">
            #ctl00_ContentPlaceHolder1_GridEstReport_ctl00 thead tr {
                white-space: nowrap;
            }

            #ctl00_ContentPlaceHolder1_GridEstReport_ctl00 tbody tr {
                white-space: nowrap;
            }

            .rgStatus {
                display: none;
            }
        </style>
        <style>
            /*--if this css is placed in item.css leftpanel of summary pages wil be affected----*/

            .RadComboBox_Default {
                border-color: silver -moz-use-text-color rgb(115, 115, 115) silver;
            }

                .RadComboBox_Default .rcbFocused .rcbArrowCellRight {
                    background-color: 1px solid #D4D4D4;
                }

            #divCheck {
                float: left;
                position: absolute;
                display: none;
                border: solid 1px silver;
                overflow-x: hidden;
                overflow-y: scroll;
                width: 175px;
                height: 100px;
                background-color: white;
            }

            #div_list {
                float: left;
                position: absolute;
                display: none;
                border: solid 1px silver;
                overflow-x: hidden;
                overflow-y: scroll;
                width: 175px;
                height: 75px;
                background-color: white;
            }

            .divpad {
                padding: 2px;
            }

            .active {
                background-color: #DADADA;
            }

            .active1 {
                background-color: white;
            }



            #test-1 {
                background-image: none;
                font-weight: bolder;
            }


            .rpItem {
                border: 1px solid transparent !important;
            }

            .radpanelbar_default .rpout {
                border-bottom-width: 1px;
                border-bottom: 1px solid transparent;
            }

            .RadPanelBar_Default div.rpHeaderTemplate, .RadPanelBar_Default a.rpLink {
                background-image: none;
                border: 1px solid #6C6C6C;
                background-color: #F2F2F2;
            }

            .RadPanelBar .rpFocused .rpOut, .RadPanelBar a.rpLink:hover .rpOut, .RadPanelBar .rpSelected .rpOut, .RadPanelBar a.rpSelected:hover .rpOut {
                border-top-width: 0px;
                background-color: #C1C1C1;
                border-left-width: 0px;
                border-right-width: 0px;
                border-radius: 4px;
                -webkit-border-radius: 4px;
                -khtml-border-radius: 4px;
            }

            .ddlComboBox .rcbInputCell .rcbEmptyMessage {
                color: Black !important;
                font-style: normal !important;
                font-family: Verdana,Arial,sans-serif !important;
                font-size: 1em !important;
            }


            .ddlComboBox .rcbArrowCell a {
                background-image: url('../images/dropdown_arrow.png') !important;
                height: 18px !important;
                width: 16px !important;
            }

            .ddlComboBox .rcbArrowCellRight {
                background-image: none;
            }

            .ddlComboBox .rcbInputCell .rcbInput {
                border: 1px solid #BFBFBF;
                margin-left: -2px;
                width: 204px;
                height: 18px;
            }

            .ddlComboBox .rcbInputCellLeft {
                background-image: none;
            }

            .chkBoxListEst td {
                width: 27%;
            }
        </style>
        <script type="text/javascript">

            function OnClientDropDownOpenedHandler(sender, eventArgs) {

                var comboBox = $find("<%=ddlEstimateType.ClientID %>");
                for (var i = 0; i < comboBox.get_items().get_count(); i++) {
                    var item = comboBox.get_items().getItem(i);
                    var checkbox = $telerik.findElement(item.get_element(), "chkEstType");

                }
            }


            function getSelectedItem(listvalue, i, id, listItem) {

                var dropdownlist = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlEstimateType_Input");
                var comboBox = $find("<%=ddlEstimateType.ClientID %>");
                var t = false;
                for (var i = 0; i < comboBox.get_items().get_count(); i++) {
                    var item = comboBox.get_items().getItem(i);
                    var checkbox = $telerik.findElement(item.get_element(), "chkEstType").getElementsByTagName("input");
                    for (var i = 0; i < checkbox.length; i++) {

                        if (checkbox[i].checked) {

                            dropdownlist.value = 'Selected';
                            t = true;
                        }
                    }


                }
                //            if (t) {
                //            if (listvalue != "") {
                //                if (dropdownlist.value.trim() != "") {
                //                    //dropdownlist.value += ', ' + listvalue;
                //                    dropdownlist.value = 'Selected';
                //                }
                //                else {
                //                    // dropdownlist.value += listvalue;
                //                    dropdownlist.value = 'Select';
                //                }
                //            }
                //            }
                //            else {
                //                dropdownlist.value = '';
                //            }
                if (t == false) {
                    dropdownlist.value = 'Select';
                }

            }
        </script>
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div id="ds00" style="display: block;">
        </div>
        <div id="div_Load" class="loading_new">
            <UC:Loading ID="ucLoading" runat="server" />
        </div>
        <script>
            var Pgtype = '<%=pg %>';
        </script>
        <div id="div_option" runat="server">
            <div id="div_header" class="navigatorpanel" runat="server">
                <div style="clear: both;">
                </div>
            </div>
            <div id="waitmessage" style="visibility: hidden; width: 150px; position: absolute; height: 90px; top: 45%; left: 47%">
                <table cellpadding="10" cellspacing="20">
                    <tr>
                        <td align="right">
                            <asp:Image ID="imgHourglass" runat="server" ImageUrl="~/images/loading_new.gif" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divtab" runat="server">
                <div style="display: none" id="padding">
                    <ul>
                        <li id="li_Save" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_SR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px; float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="spn_1" onclick="Call_Report(this.id);">
                                    <%=objLangClass.GetLanguageConversion("Saved_Reports")%>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_Customize" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_CR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px; float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="spn_2" onclick="Call_Report(this.id);">
                                    <%=objLangClass.GetLanguageConversion("Customize_Reports")%></span></b>
                            </div>
                        </li>
                    </ul>
                    <div style="clear: both;">
                    </div>
                </div>
                <div id="tabs" class="ui-tabs" style="width: 98%; border: solid 0px red; visibility: hidden; padding-top: 3px; padding-left: 5px">
                    <ul id="test-1" style="list-style: none; height: auto; width: 97.4%; background-color: #FFFFFF; margin-left: 5px; border-left: 1px solid transparent; border-right: 1px solid transparent; border-top: 1px solid transparent; border-radius: 0px; border-bottom: 1px solid transparent">
                        <li style="margin-left: -5px"><a id="A1" href="#tabs-1" onclick="Call_Report(this.id);">
                            <b>
                                <%=objLangClass.GetLanguageConversion("Saved_Reports")%></b></a></li>
                        <li><a id="A2" href="#tabs-2" onclick="Call_Report(this.id);"><b>
                            <%=objLangClass.GetLanguageConversion("Customize_Reports")%></b></a></li>
                    </ul>
                    <div id="tabs-1" class="ui-tabs-hide">
                        <div id="divusrReportsave" class="report_savedtab" runat="server" style="border: 1px solid rgb(170, 170, 170);">
                            <UC:Savereport ID="usrReportsave" runat="server" />
                            <asp:HiddenField ID="hid_runreport" runat="server" />
                        </div>
                    </div>
                    <div id="tabs-2" class="ui-tabs-hide">
                        <div id="div_showfilters" class="TelerikPaneDiv" runat="server" style="width: 100%">
                            <div id="Div1" class="report_customizetab">
                                <div id="div_Error" align="center" style="width: 100%; display: none">
                                    <span id="spnError" runat="server" class="spanerrorMsg" style="width: 300px; text-align: center">
                                        <%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Column_To_Generate_Report")%></span>
                                </div>
                                <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="950px" Height="100%"
                                    Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                                    <Items>
                                        <telerik:RadPanelItem Text="Select columns to run report" Font-Bold="true" Expanded="true"
                                            CssClass="rounded-ReportTopcorners" Selected="true">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView1">
                                                        <div class="AggregateDiv">
                                                            <table>
                                                                <tr>
                                                                    <td valign="bottom">
                                                                        <div align="left" style="width: 100%; padding: 5px">
                                                                            <a href="javascript://" style="font-size: 0.8em;" id="lnkSelectAll" onclick="javascript:SelectAll();">
                                                                                <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="left" style="margin-top: -4px">
                                                                            <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                Width="850px" CssClass="chkBoxListEst">
                                                                                <asp:ListItem Text="" Value="JobNumber" Selected="true"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="JobTitle"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CustomerID" Selected="true"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Department"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CustomerEmail"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactEmail"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactPhone"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DeliveryAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="InvoiceAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Estimator"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="SalesPerson"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CompletionDate"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ProductionDate"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DeliveryDate"></asp:ListItem>

                                                                                <asp:ListItem Text="Total Ex. Tax"  Value="TotalExTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Total Inc. Tax" Value="TotalIncTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Ex. Tax"   Value="ItemExTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Inc. Tax"  Value="ItemIncTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Cart Cost"  Value="CartCost"></asp:ListItem>

                                                                                <asp:ListItem Text="" Value="JobValue" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ItemTitle"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="StatusID"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Description"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Artwork"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Colour"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Size"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Material"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Delivery"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Finishing"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Notes"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Instructions"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Proofs"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Packing"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="OrderNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="name"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="SubTotal"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CostExMarkup"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="GrossProfitPrice"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="GrossProfitPercentage"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AccountingCode"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CostCentre"></asp:ListItem>
                                                                                <asp:ListItem Text="Activity Notes" Value="ActivityNotes"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Quantity" Value="ItemQuantity"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimated Job Time" Value="EstimatedJobTime"></asp:ListItem>
                                                                                <asp:ListItem Text="Actaul Job Time" Value="ActaulJobTime"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimated Delivery Date" Value="EstimatedDeliveryDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Actual Delivery Date" Value="ActualDeliveryDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Customer Code" Value="CustomerCode"></asp:ListItem>
                                                                                <asp:ListItem Text="Pack Unit" Value="PackUnit"></asp:ListItem>
                                                                                <asp:ListItem Text="Cost Price(Inc. MarkUp)" Value="CostPrice"></asp:ListItem>
                                                                                <asp:ListItem Text="Supplier Name" Value="SupplierName"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Title" Value="ProductTitle"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Code" Value="ProductCode"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Category" Value="ProductCatagory"></asp:ListItem>
                                                                                <asp:ListItem Text="Store Name" Value="StoreName"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Width" Value="ProductWidth"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Height" Value="ProductHeight"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Length" Value="ProductLength"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Weight" Value="ProductWeight"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Dimension" Value="ProductDimension"></asp:ListItem>
                                                                                <asp:ListItem Text="Event Name" Value="EventName"></asp:ListItem>
                                                                                <asp:ListItem Text="Event Code Number" Value="EventCodeNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Campaign Sign Number" Value="CampaignSignNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Event Venue" Value="EventVenue"></asp:ListItem>
                                                                                <asp:ListItem Text="Quantity Description" Value="QTYDescription1"></asp:ListItem>
                                                                                <asp:ListItem Text="Event Date" Value="EventDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Job Name" Value="JobName"></asp:ListItem>
                                                                                <asp:ListItem Text="Contact Job Title 1" Value="ContactJobTitle1"></asp:ListItem>
                                                                                <asp:ListItem Text="Contact Job Title 2" Value="ContactJobTitle2"></asp:ListItem>
                                                                                <asp:ListItem Text="Customer Salesperson" Value="CustomerSalesperson"></asp:ListItem>
                                                                                <asp:ListItem Text="Ordered For" Value="OrderedFor"></asp:ListItem>
                                                                                <asp:ListItem Text="Type" Value="CustomerType"></asp:ListItem>
                                                                                <asp:ListItem Text="Customer Address" Value="CustomerAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="commissionamount"></asp:ListItem>
                                                                                <asp:ListItem Text="Commission (%)" Value="commissionpercentage"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Taxvalue"></asp:ListItem>
                                                                                <asp:ListItem Text="Ordered By" Value="OrderedBy"></asp:ListItem>
                                                                                <asp:ListItem Text="Order Number" Value="SystemOrderNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimate Number" Value="EstimateNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimate Created On" Value="EstimateCreatedOn"></asp:ListItem>
                                                                                <asp:ListItem Text="Stock Product" Value="StockProduct"></asp:ListItem>
                                                                                <asp:ListItem Text="Back Order" Value="BackOrder"></asp:ListItem>
                                                                                <asp:ListItem Text="Press Name" Value="PressName"></asp:ListItem>
                                                                                <asp:ListItem Text="Job Total" Value="JobTotal"></asp:ListItem>
                                                                                <asp:ListItem Text="Total Tax" Value="TotalTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Payment Terms" Value="PaymentTerms"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Code" Value="ItemCode"></asp:ListItem>
                                                                                <asp:ListItem Text="Stock Location" Value="Location"></asp:ListItem>
                                                                                <asp:ListItem Text="Delivery Number" Value="DeliveryNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Delivery Consignment Number" Value="ConsignmentNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Delivery Consignee Url" Value="ConsigneeUrl"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Type" Value="EstItemType"></asp:ListItem>
                                                                                <asp:ListItem Text="Contact CustomField1" Value="CustomField1"></asp:ListItem>
                                                                                <asp:ListItem Text="Contact CustomField2" Value="CustomField2"></asp:ListItem>


                                                                                <asp:ListItem Text="Replenish Job" Value="ReplenishJob"></asp:ListItem>
                                                                                <asp:ListItem Text="Supplier Quote No" Value="SupplierQuoteNo"></asp:ListItem>
                                                                                <asp:ListItem Text="Delivery Address Label" Value="DeliveryAddressLabel"></asp:ListItem>
                                                                                <asp:ListItem Text="Job Status" Value="JobStatus"></asp:ListItem>
                                                                                <asp:ListItem Text="Unit Selling Price (ex tax)" Value="UnitSellingPrice"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field1" Value="CustomDescriptionField1"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field2" Value="CustomDescriptionField2"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field3" Value="CustomDescriptionField3"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field4" Value="CustomDescriptionField4"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field5" Value="CustomDescriptionField5"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field6" Value="CustomDescriptionField6"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field7" Value="CustomDescriptionField7"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field8" Value="CustomDescriptionField8"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field9" Value="CustomDescriptionField9"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description Field10" Value="CustomDescriptionField10"></asp:ListItem>
                                                                                <asp:ListItem Text="Replenish Job" Value="ReplenishJob"></asp:ListItem>
                                                                                <asp:ListItem Text="Supplier Quote No" Value="SupplierQuoteNo"></asp:ListItem>
                                                                                <asp:ListItem Text="Delivery Address Label" Value="DeliveryAddressLabel"></asp:ListItem>
                                                                                <asp:ListItem Text="Job Status" Value="JobStatus"></asp:ListItem>
                                                                                <asp:ListItem Text="Unit Selling Price (ex tax)" Value="UnitSellingPrice"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Costper1000"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="SubTotalper1000"></asp:ListItem>
                                                                             <%--   <asp:ListItem Text="" Value="CreatedDate"></asp:ListItem>--%>
                                                                             
                                                                                <asp:ListItem Text="Item Created On" Value="ItemCreatedOn"></asp:ListItem>
                                                                                <asp:ListItem Text="Created Date" Value="CreatedDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 1" Value="CustomDate1"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 2" Value="CustomDate2"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 3" Value="CustomDate3"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 4" Value="CustomDate4"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 5" Value="CustomDate5"></asp:ListItem> 
                                                                               

                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="left" style="padding-top: 4px; padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 195px; padding: 4px">
                                                                                <%-- <span style="vertical-align:middle">--%>
                                                                                <%=objLanguage.GetLanguageConversion("Show_Contact_Addresses_In")%>
                                                                                <%-- </span>--%>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlContactAddress" runat="server" CssClass="normalText" Width="220px">
                                                                                    <asp:ListItem Text="One Column" Value="0" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="1"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 195px; padding: 4px">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("Show_Delivery_Addresses_In")%>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlDeliveryAddress" runat="server" CssClass="normalText" Width="220px">
                                                                                    <asp:ListItem Text="One Column" Value="0" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="1"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 195px; padding: 4px">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("Show_Invoice_Addresses_In")%>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlInvoiceAddress" runat="server" CssClass="normalText" Width="220px">
                                                                                    <asp:ListItem Text="One Column" Value="0" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="1"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 195px; padding: 4px">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("Show_Customer_Addresses_In")%>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlCustomerAddress" runat="server" CssClass="normalText" Width="220px">
                                                                                    <asp:ListItem Text="One Column" Value="0" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="1"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="display: none">
                                                                            <asp:CheckBoxList ID="Chk_addressList" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4">
                                                                                <asp:ListItem Text="" Value="AddressLabel"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address2"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address3"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address4"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address5"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Sort the records" Font-Bold="true" CssClass="rounded-ReportTopcorners"
                                            Expanded="false">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="rad2" SelectedIndex="0">
                                                    <telerik:RadPageView runat="server" ID="view2">
                                                        <div class="JobReport">
                                                            <div id="Div2">
                                                                <div id="div3" style="width: 100%">
                                                                    <div align="left" style="padding-top: 5px; padding-left: 5px">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <asp:Label ID="Label4" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Sort_By")%></asp:Label>
                                                                        </div>
                                                                        <div style="float: left; padding-left: 5px;">
                                                                            <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="normalText" Width="220px"
                                                                                Height="20px">
                                                                                <asp:ListItem Value="none">None</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                </div>
                                                                <div id="div4" style="width: 100%">
                                                                    <asp:UpdatePanel ID="UpdatePanel4" RenderMode="Inline" runat="server">
                                                                        <ContentTemplate>
                                                                            <div align="left" style="padding-left: 5px">
                                                                                <div class="bgReportlabel" style="width: 195px">
                                                                                    <asp:Label ID="Label5" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Direction")%></asp:Label>
                                                                                </div>
                                                                                <div style="float: left; padding-left: 5px;">
                                                                                    <asp:DropDownList ID="ddldirection" runat="server" CssClass="normalText" Width="220px"
                                                                                        Height="20px">
                                                                                        <asp:ListItem Value="ASC" Selected="True">Ascending</asp:ListItem>
                                                                                        <asp:ListItem Value="DESC">Descending</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="div5" style="width: 100%">
                                                                    <div align="left" style="padding-top: 5px; padding-left: 5px">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <asp:Label ID="Label1" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Report_Type")%></asp:Label>
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rdosummary" onclick="javascript:GetSummaryDetails()" runat="server"
                                                                                            Text="Summary" GroupName="sumordet" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButton ID="rdodetail" onclick="javascript:GetDetails()" runat="server"
                                                                                            Text="Detailed" GroupName="sumordet" />
                                                                                    </td>
                                                                                    <td valign="bottom">
                                                                                        <div id="DivSelect" runat="server" style="display: none">
                                                                                            <a href="javascript://" style="font-size: 0.8em" onclick="javascript:SummaryorDetialsSelectnone();">
                                                                                                <%=objLangClass.GetLanguageConversion("Select")%>
                                                                                                <span id="spn_SummaryDetail" runat="server"></span></a>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id="divDetails" style="width: 100%">
                                                                    <div align="left" style="padding-top: 5px; padding-left: 5px">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <asp:Label ID="Label2" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Group_The_Records_By")%></asp:Label>
                                                                        </div>
                                                                        <div style="float: left; padding-left: 5px;">
                                                                            <asp:DropDownList ID="ddlsummarydetails" SkinID="onlyDDL" CssClass="normaltext" runat="server"
                                                                                Width="220px">
                                                                                <asp:ListItem Value="0" Text="Date"></asp:ListItem>
                                                                                <asp:ListItem Value="1" Selected="True" Text="&nbsp;&nbsp;&nbsp;Daily"></asp:ListItem>
                                                                                <asp:ListItem Value="2" Text="&nbsp;&nbsp;&nbsp;Monthly"></asp:ListItem>
                                                                                <asp:ListItem Value="3" Text="&nbsp;&nbsp;&nbsp;Yearly"></asp:ListItem>
                                                                                <asp:ListItem Value="4" Text="Customer"></asp:ListItem>
                                                                                <asp:ListItem Value="5" Text="Accounting Code"></asp:ListItem>
                                                                                <asp:ListItem Value="6" Text="SalesPerson"></asp:ListItem>
                                                                                <asp:ListItem Value="7" Text="Customer Salesperson"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                </div>
                                                                <div class="only5px">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Report filters " Font-Bold="true" CssClass="rounded-ReportTopcorners"
                                            Expanded="false">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage4" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView4">
                                                        <div class="FilterJob">
                                                            <div align="left">
                                                                <div align="left" style="padding: 5px">
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Job_Range")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <asp:DropDownList ID="ddlEstimateRange" runat="server" CssClass="normalText" Width="220px">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div id="divchkEstimate" style="float: left; padding-left: 5px">
                                                                            <asp:CheckBox ID="chkEstimate" runat="server" Text="Show invoices with no assigned value"
                                                                                Checked="true" />
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Job_Status")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <telerik:RadListBox ID="lstStatus" runat="server" CheckBoxes="true" Width="220px"
                                                                                Height="100px">
                                                                                <Items>
                                                                                </Items>
                                                                            </telerik:RadListBox>
                                                                            <%--  <asp:ListBox ID="lstStatus" runat="server" CssClass="normalText" SelectionMode="Multiple"
                                                                            Width="175px"></asp:ListBox>--%>
                                                                            <%--  <span class="smallgraytext" style="padding-left: 5px; vertical-align: top">&nbsp;(
                                                                            <%=objLangClass.GetLanguageConversion("Multiple_Selection_Option")%>)</span>--%>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div class="only5px">
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Select_Company")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <div style="float: left;">
                                                                                <asp:TextBox ID="txtName" SkinID="textPad" runat="server" AutoCompleteType="disabled"
                                                                                    Width="220px"></asp:TextBox>
                                                                                <%--onkeyup="BindClientName(this.value,event,this);"--%>
                                                                                <div class="onlyEmpty">
                                                                                </div>
                                                                                <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                                                                                </div>
                                                                            </div>
                                                                            <div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none">
                                                                                <img id="img_down01" src="<%=strImagepath %>down01.gif" onclick="BindClientName('',event,this);"
                                                                                    style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                                                                            </div>
                                                                        </div>
                                                                        <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Active_Archive")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <asp:DropDownList ID="ddlShowJobs" runat="server" CssClass="reportwidth175" Width="220px">
                                                                                <asp:ListItem Text="" Value="0" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px;">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Estimate_Type") %></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left; margin-top: -5px">
                                                                            <telerik:RadComboBox ID="ddlEstimateType" runat="server" Width="220px" OnClientDropDownOpened="OnClientDropDownOpenedHandler"
                                                                                EmptyMessage="-- Select --" AllowCustomText="true" CssClass="ddlComboBox">
                                                                                <ItemTemplate>
                                                                                    <div>
                                                                                        <asp:CheckBoxList ID="chkEstType" runat="server">
                                                                                        </asp:CheckBoxList>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                                <Items>
                                                                                    <telerik:RadComboBoxItem Text="" />
                                                                                </Items>
                                                                            </telerik:RadComboBox>
                                                                            <%--    <asp:DropDownList ID="ddlEstimateType" runat="server" Width="150px">
                                                                            <asp:ListItem Text="-- Select --" Selected="True" Value="0"></asp:ListItem>
                                                                        </asp:DropDownList>--%>
                                                                            <%--                                                                            <span class="smallgraytext" style="padding-left: 5px; vertical-align: top">&nbsp;(<%=objLangClass.GetLanguageConversion("Filter_Applicable_for_main_items_only")%>)</span>--%>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Main_Sub_items")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <asp:DropDownList ID="ddlShowSubItems" runat="server" CssClass="reportwidth175" Width="220px">
                                                                                <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="2"></asp:ListItem>

                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Notes_Type")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <asp:DropDownList ID="ddlNotesType" runat="server" Width="220px">
                                                                                <asp:ListItem Text="-- Select --" Selected="True" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="System" Value="System"></asp:ListItem>
                                                                                <asp:ListItem Text="General" Value="General"></asp:ListItem>
                                                                                <asp:ListItem Text="Error" Value="Error"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel widht15" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Invoice_Status")%>
                                                                            </span>
                                                                        </div>
                                                                        <div class="Only5pxWidth">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div class="mainheader">
                                                                            <asp:DropDownList ID="ddlInvoiceStatus" runat="server" CssClass="reportwidth175"
                                                                                onChange="javascript:DisbaleConertedToInvoice();" Width="220px">
                                                                                <asp:ListItem Text="-- Select --" Selected="True" Value="0"></asp:ListItem>
                                                                                <asp:ListItem Text="UnInvoiced" Value="UnInvoiced"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoiced" Value="Invoiced"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoiced & Paid" Value="InvoicedPaid"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoiced & unpaid" Value="InvoicedUnpaid"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <%--Estimator--%>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel widht15" style="width: 195px">
                                                                            <span>Estimator
                                                                            </span>
                                                                        </div>
                                                                        <div class="Only5pxWidth">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div class="mainheader">
                                                                            <asp:DropDownList ID="ddlEstimator" runat="server" CssClass="reportwidth175" Width="200px">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>

                                                                    <%--Sales Person--%>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel widht15" style="width: 195px">
                                                                            <span>Sales Person
                                                                            </span>
                                                                        </div>
                                                                        <div class="Only5pxWidth">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div class="mainheader">
                                                                            <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="reportwidth175" Width="200px">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <%--Customer Sales Person--%>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>Customer Sales Person
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <asp:DropDownList ID="ddlCustomerSalesPerson" runat="server" CssClass="normalText" Width="220px" Style="margin-top: 2px">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>

                                                                    <div align="left" runat="server" id="divLocation" visible="false">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>Select Locations
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="normalText" Width="220px" Style="margin-top: 2px">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>

                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 195px">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Free_Text")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            <div>
                                                                                <asp:TextBox ID="txtFreetext" runat="server" SkinID="textPad" MaxLength="255" Width="220px"
                                                                                    TextMode="MultiLine"></asp:TextBox>
                                                                                <span style="padding-left: 5px; vertical-align: middle">
                                                                                    <asp:CheckBox ID="chkExactPhraseText" runat="server" Text="" /></span><span class="smallgraytext filetertext_helptext">
                                                                                        &nbsp;(<%=objLangClass.GetLanguageConversion("Separate_search_phrases_or_words_with_a_comma")%>)</span>
                                                                            </div>
                                                                        </div>

                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 195px">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("Select_Filelds_to_be_searched")%></span>
                                                                            </div>
                                                                            <div style="float: left;">
                                                                                <asp:CheckBoxList ID="chkfreetext" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                    Width="600px">
                                                                                    <asp:ListItem Text="" Selected="True" Value="JobNumber"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Selected="True" Value="JobTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ItemTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CustomerOrderNumber"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Selected="True" Value="CustomerName"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="StoreName"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ContactName"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Department"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CostCentre"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Selected="True" Value="Referredby"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Selected="True" Value="SalesPerson"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="SupplierName"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ProductCatagory"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ProductCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CustomerCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ProductTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CustomerSalesperson"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="AccountingCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="Description" Value="Description"></asp:ListItem>
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                                <div align="left">
                                                                    <div align="left">
                                                                        <table style="width: 680px;">
                                                                            <tr>
                                                                                <td style="width: 150px;">
                                                                                    <asp:CheckBox ID="chkDateOption" runat="server" Text="Job Created" Font-Bold="true"
                                                                                        onclick="javascript:EnableDateOption();checkdates();OnCheckShow()" />
                                                                                </td>
                                                                                <td align="right" style="width: 25px;">
                                                                                    <asp:DropDownList ID="rdlDate" Enabled="false" runat="server" onChange="javascript:GetDropdownBind();"
                                                                                        Width="220px">
                                                                                        <asp:ListItem Text="Today" Value="daily"></asp:ListItem>
                                                                                        <asp:ListItem Text="Yesterday" Value="yesterday"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Month" Value="thismonth" Selected="true"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Quarter" Value="thisquarter"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Year" Value="thisannualyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Quarter" Value="lastquater"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Fiscal Year" Value="thisyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Half Fiscal year" Value="halfyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Till Date" Value="tilldate"></asp:ListItem>
                                                                                        <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 200px; padding-left: 12px">
                                                                                    <span id="spn_daily" style="display: none" runat="server" class="smallgraytext">(26/10/2009)</span>
                                                                                    <span id="spn_yest" style="display: none" runat="server" class="smallgraytext">(25/10/2009)</span>
                                                                                    <span id="spn_month" runat="server" style="display: none" class="smallgraytext">(1/10/2009
                                                                                        to 31/10/2009)</span> <span id="spn_quarter" runat="server" style="display: none"
                                                                                            class="smallgraytext">(Oct - Dec 2009)</span> <span id="spn_lastque" runat="server"
                                                                                                style="display: none" class="smallgraytext">(Oct - Dec 2009)</span>
                                                                                    <span id="spn_year" runat="server" style="display: none" class="smallgraytext">(2009)</span>
                                                                                    <span id="span_halfyear" runat="server" style="display: none" class="smallgraytext">
                                                                                        (Oct 2013 - March 2014) </span>
                                                                                       <span id="spn_lastweek" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>
                                                                                        <span id="spn_lastmonth" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                        <span id="spn_lastyear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    
                                                                                    <span id="spn_rdlDate_annualYear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    <div align="left" id="divjobdate" runat="server" style="display: none">
                                                                                        <asp:TextBox ID="txtFrom" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox><span
                                                                                            class="normalText">&nbsp;<%=objLangClass.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                                ID="txtTo" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox>
                                                                                        <span id="spn_txtFromDate" class="spanerrorMsg" style="display: none; width: 150px">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="spn_txtToDate" class="spanerrorMsg" style="display: none; width: 250px;">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="spndateRange" class="spanerrorMsg" style="display: none">
                                                                                            <%=objLangClass.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div style="height: 5px">
                                                                    </div>
                                                                    <div id="divdates" align="left" style="display: <%=divdatesVisibility %>; margin-left: 460px; padding-bottom: 4px">
                                                                        <asp:DropDownList ID="ddldates" SkinID="onlyDDL" runat="server" Width="150px">
                                                                            <asp:ListItem Text="Apply Both Dates" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Apply Either Dates" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div align="left">
                                                                        <table style="width: 700px;">
                                                                            <tr>
                                                                                <td style="width: 204px;">
                                                                                    <asp:CheckBox ID="chkconvertedoption" runat="server" Text="Job Converted to Invoice"
                                                                                        Font-Bold="true" onclick="javascript:EnableConvertedDateOption();checkdates();checkDeliveryInvoice();OnCheckShowConverted();" />
                                                                                </td>
                                                                                <td align="center" style="width: 85px;">
                                                                                    <asp:DropDownList ID="rdlconverteddate" Enabled="false" runat="server" Width="220px"
                                                                                        onChange="javascript:GetConevrtedDropdownBind();">
                                                                                        <asp:ListItem Text="Today" Value="daily"></asp:ListItem>
                                                                                        <asp:ListItem Text="Yesterday" Value="yesterday"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Month" Value="thismonth" Selected="true"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Quarter" Value="thisquarter"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Year" Value="thisannualyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Quarter" Value="lastquater"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Fiscal Year" Value="thisyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Half Fiscal year" Value="halfyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Till Date" Value="tilldate"></asp:ListItem>
                                                                                        <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 250px; padding-left: 12px">
                                                                                    <span id="spn_daily_c" style="display: none" runat="server" class="smallgraytext">(01/10/2010)</span>
                                                                                    <span id="spn_yest_c" style="display: none" runat="server" class="smallgraytext">(01/10/2010)</span>
                                                                                    <span id="spn_month_c" style="display: none" runat="server" class="smallgraytext">(1/10/2010
                                                                                        to 31/10/2010)</span> <span id="spn_quarter_c" style="display: none" runat="server"
                                                                                            class="smallgraytext">(Oct - Dec 2010)</span> <span id="spn_lastque_c" style="display: none"
                                                                                                runat="server" class="smallgraytext">(Oct - Dec 2010)</span> <span id="spn_year_c"
                                                                                                    runat="server" style="display: none" class="smallgraytext">(2010)</span><span id="span_halfyear_c"
                                                                                                        runat="server" style="display: none" class="smallgraytext"> (Oct 2013 - March 2014)
                                                                                                    </span>
                                                                                       <span id="spn_lastweek_c" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>
                                                                                        <span id="spn_lastmonth_c" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                        <span id="spn_lastyear_c" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    <span id="spn_rdlconverteddate_annualYear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    <div align="left" id="divjobdate_c" runat="server" style="display: none">
                                                                                        <asp:TextBox ID="txtfromdate_converted" runat="server" SkinID="textPad" Width="100px"
                                                                                            Enabled="false"></asp:TextBox><span class="normalText">&nbsp;<%=objLangClass.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                                ID="txttodate_converted" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox>
                                                                                        <span id="Span8" class="spanerrorMsg" style="display: none; width: 150px">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="Span9" class="spanerrorMsg" style="display: none; width: 250px;">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="Span10" class="spanerrorMsg" style="display: none">
                                                                                            <%=objLangClass.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div style="height: 5px">
                                                                    </div>
                                                                    <div id="DivDlivery" align="left" style="display: <%=divDeliverysVisibility %>; margin-left: 460px; padding-bottom: 4px">
                                                                        <asp:DropDownList ID="ddlDeliveryInvoice" SkinID="onlyDDL" runat="server" Width="150px">
                                                                            <asp:ListItem Text="Apply Both Dates" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Apply Either Dates" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div align="left">
                                                                        <table style="width: 675px;">
                                                                            <tr>
                                                                                <td style="width: 154px;">
                                                                                    <asp:CheckBox ID="chkDeilveryOption" runat="server" Text="Job Delivery " Font-Bold="true"
                                                                                        onclick="javascript:EnableDeliveryDateOption();checkDeliveryInvoice();OnCheckShowDelivery();" />
                                                                                </td>
                                                                                <td align="right" style="width: 85px;">
                                                                                    <asp:DropDownList ID="rdlDeliverDate" Enabled="false" runat="server" Width="220px"
                                                                                        onChange="javascript:GetDeliveryDropdownBind();">
                                                                                        <asp:ListItem Text="Today" Value="daily"></asp:ListItem>
                                                                                        <asp:ListItem Text="Yesterday" Value="yesterday"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Month" Selected="True" Value="thismonth"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Quarter" Value="thisquarter"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Year" Value="thisannualyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Quarter" Value="lastquater"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Fiscal Year" Value="thisyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Half Fiscal year" Value="halfyear"></asp:ListItem>
                                                                                        <asp:ListItem Text="Till Date" Value="tilldate"></asp:ListItem>
                                                                                        <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                        <asp:ListItem Text="Next 3 days" Value="next3days"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                        <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td style="width: 200px; padding-left: 10px;">
                                                                                    <span id="spn_daily_d" style="display: none" runat="server" class="smallgraytext">(01/10/2010)</span>
                                                                                    <span id="spn_yest_d" runat="server" style="display: none" class="smallgraytext">(01/10/2010)</span>
                                                                                    <span id="spn_month_d" runat="server" style="display: none" class="smallgraytext">(1/10/2010
                                                                                        to 31/10/2010)</span> <span id="spn_quarter_d" runat="server" style="display: none"
                                                                                            class="smallgraytext">(Oct - Dec 2010)</span> <span id="spn_lastque_d" runat="server"
                                                                                                style="display: none" class="smallgraytext">(Oct - Dec 2010)</span>
                                                                                    <span id="spn_year_d" runat="server" style="display: none" class="smallgraytext">(2010)</span><span
                                                                                        id="span_halfyear_d" runat="server" style="display: none" class="smallgraytext">
                                                                                        (Oct 2013 - March 2014) </span><span id="SpanNext3days" style="display: none" runat="server"
                                                                                            class="smallgraytext">(01/10/2010)</span>

                                                                                       <span id="spn_lastweek_d" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>
                                                                                        <span id="spn_lastmonth_d" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                        <span id="spn_lastyear_d" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    <span id="spn_rdlDeliverDate_annualYear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    <div align="left" id="divDeliveryDate" runat="server" style="display: none">
                                                                                        <asp:TextBox ID="txtDeliveryForm_Date" runat="server" SkinID="textPad" Width="100px"
                                                                                            Enabled="false"></asp:TextBox><span class="normalText">&nbsp;<%=objLangClass.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                                ID="txtDeliveryTo_date" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox>
                                                                                        <span id="Span13" class="spanerrorMsg" style="display: none; width: 150px">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="Span14" class="spanerrorMsg" style="display: none; width: 250px;">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="Span15" class="spanerrorMsg" style="display: none">
                                                                                            <%=objLangClass.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div style="height: 15px">
                                                            </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Aggregate functions" Font-Bold="true" Expanded="false"
                                            CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView2">
                                                        <div class="AggregateDiv">
                                                            <div align="left" style="padding: 2px;">
                                                                <table cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td valign="bottom">
                                                                            <div class="job_report_linkselect">
                                                                                <span id="spn_lnkSelectAll1" runat="server"><a href="javascript:SelectAllGroupByoption();"
                                                                                    id="lnkSelectAll1" style="font-size: 0.8em;">Select All Columns</a></span>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span>&nbsp;<%=objLangClass.GetLanguageConversion("Count")%></span>
                                                                            </div>
                                                                        </td>
                                                                        <td colspan="3">
                                                                            <asp:CheckBoxList ID="chkColumns1" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"
                                                                                Width="300px">
                                                                                <asp:ListItem Value="EstimateCount" Text=""></asp:ListItem>
                                                                                <asp:ListItem Value="InvoiceCount" Text=""></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span>&nbsp;<%=objLangClass.GetLanguageConversion("Item_Cost_Price_Exc_Markup_View")%>(<%=objJava.GetCurrencyinRequiredFormate("", true)%>)</span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="ChkClmnsCostPriceExMarkup" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4">
                                                                                <asp:ListItem Value="CostExMarkupTotal" Text=""></asp:ListItem>
                                                                                <asp:ListItem Value="CostExMarkupAverage" Text="Average"></asp:ListItem>
                                                                                <asp:ListItem Value="CostExMarkupMaximum" Text="Maximum"></asp:ListItem>
                                                                                <asp:ListItem Value="CostExMarkupMinimum" Text="Minimum"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span>&nbsp;<%=objLangClass.GetLanguageConversion("Job_Value_Exc_Tax")%>(<%=objJava.GetCurrencyinRequiredFormate("", true)%>)</span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="chkExcTax" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                                                                <asp:ListItem Value="chkTaxTotal" Text="" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Value="chkTaxAvg" Text=""></asp:ListItem>
                                                                                <asp:ListItem Value="chkTaxMax" Text=""></asp:ListItem>
                                                                                <asp:ListItem Value="chkTaxMin" Text=""></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span>&nbsp;<%=objLangClass.GetLanguageConversion("Job_Value")%>(<%=objJava.GetCurrencyinRequiredFormate("", true)%>)</span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="chkColumns2" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                                                                <asp:ListItem Value="EstimateTotal" Text="" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Value="EstimateAverage" Text="Average"></asp:ListItem>
                                                                                <asp:ListItem Value="EstimateMaximum" Text="Maximum"></asp:ListItem>
                                                                                <asp:ListItem Value="EstimateMinimum" Text="Minimum"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span id="spn_GrossProfit" runat="server">&nbsp;<%=objLangClass.GetLanguageConversion("Gross_Profit")%>(<%=objJava.GetCurrencyinRequiredFormate("", true)%>)</span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="ChkColumnsNetprofit" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4">
                                                                                <asp:ListItem Value="NetTotal" Text=""></asp:ListItem>
                                                                                <asp:ListItem Value="NetAverage" Text="Average"></asp:ListItem>
                                                                                <asp:ListItem Value="NetMaximum" Text="Maximum"></asp:ListItem>
                                                                                <asp:ListItem Value="NetMinimum" Text="Minimum"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span id="Span3" runat="server">&nbsp;<%=objLangClass.GetLanguageConversion("Gross_Profit")%>(%)</span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="ChkClmnsNetPercentage" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4">
                                                                                <asp:ListItem Value="NetTotal" Text=""></asp:ListItem>
                                                                                <asp:ListItem Value="NetAverage" Text="Average"></asp:ListItem>
                                                                                <asp:ListItem Value="NetMaximum" Text="Maximum"></asp:ListItem>
                                                                                <asp:ListItem Value="NetMinimum" Text="Minimum"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Save and Run Report" Font-Bold="true" CssClass="rounded-ReportTopcorners"
                                            Expanded="true">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage5" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView5">
                                                        <div class="FilterJob">
                                                            <div align="left" style="padding: 3px; padding-top: 7px">
                                                                <div align="left">
                                                                    <div class="bgReportlabel" style="width: 195px">
                                                                        <span class="HeaderText">
                                                                            <%=objLangClass.GetLanguageConversion("Report_Name")%></span>&nbsp;<span style="vertical-align: middle; color: Red">*</span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px;">
                                                                        &nbsp;
                                                                    </div>
                                                                    <asp:TextBox ID="txtSaveReports" runat="server" SkinID="textPad" MaxLength="200"
                                                                        Width="220px" />
                                                                    <asp:HiddenField ID="hdn_reportID" runat="server" />
                                                                </div>
                                                                <div align="left" style="width: 100%">
                                                                    <div class="bgReportlabel jobsbg_heightwidth">
                                                                        <span>
                                                                            <%=objLangClass.GetLanguageConversion("Description")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px;">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left">
                                                                        <asp:TextBox ID="txtDescription" runat="server" SkinID="textPad" TextMode="MultiLine"
                                                                            Width="290px" Height="90px" />
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                </div>
                                                                <div class="only5px">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                    </Items>
                                </telerik:RadPanelBar>
                                <div class="only5px">
                                </div>
                                <div align="left" class="ClientBtns">
                                    <div style="float: left">
                                        <div id="div_cancel" style="display: block">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Width="80px"
                                                OnClick="btnCancel_OnClick" OnClientClick="loadingimg(this.id,'div_btnCancelprocess')" />
                                        </div>
                                        <div id="div_btnCancelprocess" class="button" align="center" style="width: 62px; display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <div id="div_btnsaverun" style="display: block">
                                            <asp:Button ID="btnSaveRun" runat="server" Text="Save and Run" CssClass="button"
                                                Width="100px" OnClick="btnSaveRun_OnClick" OnClientClick="javascript:var a=ValidateCaller();if(a)loadingimg('div_btnsaverun','div_saverunprocess');return a;" />
                                        </div>
                                        <div id="div_saverunprocess" class="button" align="center" style="width: 77px; display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 117px">
                                        <asp:Button ID="btnUpdateExisting" runat="server" Text="Update Report" CssClass="button"
                                            OnClick="btnUpdateExisting_OnClick" Visible="false" OnClientClick="javascript:var a= ValidateCaller();if(a!=false)loadingimage(this.id,'div_Updatereportprocess');return a;" />
                                        <div id="div_Updatereportprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left">
                                        <div id="div_btnrunreport" style="display: block">
                                            <asp:Button ID="btnRunReport" runat="server" Text="Run Report" CssClass="button"
                                                Width="80px" OnClick="btnRunReport_OnClick" OnClientClick="javascript:var a=Runvalidate();if(a!=false)loadingimg('div_btnrunreport','div_runreportprocess');return a;" />
                                        </div>
                                        <div id="div_runreportprocess" class="button" align="center" style="width: 62px; display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                                <div class="only5px">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                </div>
            </div>
        </div>
        <div align="left" style="width: 100%;">
            <div class="only5px">
            </div>
            <div id="div_searchres" style="float: left; padding-left: 5px; width: 99.5%" class="successfulMsg"
                runat="server" visible="false">
                <div style="width: 100%" align="center">
                    <asp:Label ID="lbl_searchres" runat="server" ForeColor="gray"></asp:Label>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div id="divexport">
                <div align="left" id="divtoolbar" runat="server" visible="false" class="DivButtonsHeader report_resultpanel">
                    <table border="0" class="act_width100">
                        <tr>
                            <td width="40%">
                                <table>
                                    <tr>
                                        <td class="act_floatleft">&nbsp;
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip="Back to Search Option" ImageUrl="~/images/image_EM_b.png"
                                                ID="btnfilter" runat="server" Text="Back to Search Option" OnClick="btnfilter_OnClick"
                                                Visible="false" BackColor="Transparent" OnClientClick="javascript:return showWaitMessage();" />
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip="Export (Presentation Format)" ImageUrl="~/images/xls-presentation.jpg"
                                                ID="btnExport" runat="server" Text="Export" OnClick="btnExport_vivid_OnClick"
                                                OnClientClick="javascript:getInnerHtml();" Visible="true" BackColor="Transparent" />
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip="Export (Excel Format)" ImageUrl="~/images/export-icon1.jpg"
                                                ID="btnNewExport" runat="server" Text="Export1" OnClientClick="javascript:getInnerHtml();"
                                                BackColor="Transparent" Visible="true" OnClick="btnExport_New_OnClick" />
                                        </td>
                                        <td nowrap="nowrap">
                                            <UC:Paging ID="usrPaging" runat="server" />
                                        </td>
                                        <td class="act_floatleft"></td>
                                        <td class="act_floatleft" nowrap="nowrap">
                                            <asp:TextBox ID="txt1" runat="server" Width="40px" Visible="false" onblur="javascript:AllowNumber(this,this.value)"></asp:TextBox>&nbsp;
                                        </td>
                                        <td class="act_floatleft" nowrap="nowrap">
                                            <asp:ImageButton ToolTip="Go To" ImageUrl="~/images/gotopage.gif" ID="btngo" runat="server"
                                                OnClick="btngo_OnClick" Visible="false" BackColor="Transparent" OnClientClick="javascript:return showWaitMessage();" />
                                        </td>
                                        <td align="left"></td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right">
                                <div id="div_Total" runat="server" visible="false" style="float: right; padding-right: 10px">
                                    <span class="normalText">
                                        <%=objLangClass.GetLanguageConversion("Total_Records")%>:</span><b>
                                            <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="only5px">
                </div>
                <div id="divexport1">
                    <div id="div_Main" runat="server">
                        <div id="a">
                        </div>
                        <div id="div_Grid">
                            <%-- <asp:GridView ID="GridEstReport" CssClass="t" runat="server" Width="100%" SkinID="GridStyleReport"
                                HeaderStyle-HorizontalAlign="Left" PageSize="100" RowStyle-HorizontalAlign="Left"
                                CellPadding="4" OnDataBound="GridEstReport_DataBound">
                            </asp:GridView>--%>

                            <telerik:RadGrid ID="GridEstReport" Width="100%" runat="server" AllowAutomaticDeletes="false"
                                ShowFooter="True" AllowAutomaticInserts="false" CssClass="RadGrid_Eprint_Skin"
                                OnItemDataBound="GridEstReport_DataBound" AllowAutomaticUpdates="false" Skin="RadGrid_Eprint_Skin"
                                AutoGenerateColumns="true" AllowFilteringByColumn="false" HeaderStyle-Font-Bold="true"
                                AllowPaging="true" EnableEmbeddedSkins="false" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                OnPageIndexChanged="GridEstimate_PageIndexChanged" OnNeedDataSource="GridEstimate_OnNeedDataSource"
                                OnPageSizeChanged="GridEstimate_PageSizeChanged" PageSize="50" Visible="false" EnableAjaxSkinRendering="true" EnableViewState="true">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                            </telerik:RadGrid>
                            <asp:Label ID="lblActivity" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblItemTitle" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:PlaceHolder ID="plhdetails" runat="server"></asp:PlaceHolder>
                    </div>
                    <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                        <div id="Div6" class="emptyrecords" align="center">
                            <span class="HeaderText" style="text-align: center;">
                                <%=objLangClass.GetLanguageConversion("No_Record_Found")%></span>
                        </div>
                    </asp:Panel>
                    <div class="only5px">
                    </div>
                    <div style="border-bottom: 2px solid #E2E2E2" runat="server" id="divAggl" visible="false">
                    </div>
                    <div class="only10px">
                    </div>
                    <div id="divaggregate" visible="false" runat="server" style="width: 400px">
                        <table width="350" cellpadding="3" cellspacing="0">
                            <tr id="CountHeader" visible="false" runat="server">
                                <td style="width: 200px; border: 1px solid black">
                                    <span style="font-weight: bold;">Total Job </span>
                                </td>
                                <td style="border-right: 1px solid black; border-top: 1px solid black; border-bottom: 1px solid black; text-align: right;">
                                    <asp:Label ID="lblinvCount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="CountValue" visible="false" runat="server">
                                <td style="width: 200px; border-right: 1px solid black; border-left: 1px solid black; border-bottom: 1px solid black">
                                    <span style="font-weight: bold">Job Converted to Invoice</span>
                                </td>
                                <td style="border-right: 1px solid black; border-bottom: 1px solid black; text-align: right;">
                                    <asp:Label ID="lblnetCount" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div style="height: 25px">
                        </div>
                        <div id="divaggregate1" runat="server">
                            <table width="350" cellpadding="3" cellspacing="0" border="1px solid black" style="border-left: 0; border-right: 0; border-top: 0;">
                                <tr id="AggergateHeader" runat="server" visible="false">
                                    <td style="border-top: 1px solid transparent; border-left: 1px solid transparent">
                                        <asp:Label ID="Label99" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">Total </span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">Avg </span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">Max </span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">Min </span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">YTW</span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">YTM</span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">YTY</span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">YTD</span>
                                    </td>
                                </tr>
                                <tr id="tableTotalCostExMarkup" runat="server" visible="false">
                                    <td style="width: 200px; border-bottom: 0; border-right: 0;">
                                        <span style="font-weight: bold;">Cost Price (Ex. Markup)</span>
                                    </td>
                                    <td style="text-align: right; border-bottom: 0;">
                                        <asp:Label ID="lblCostExMarkupTotal" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupAvg" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupMax" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupMin" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupWTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupMTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupYTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupTD" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tableEstExc" runat="server" visible="false">
                                    <td style="width: 200px; border-bottom: 0; border-right: 0;">
                                        <span style="font-weight: bold;">Job Value (Ex. Tax) </span>
                                    </td>
                                    <td style="text-align: right; border-bottom: 0;">
                                        <asp:Label ID="lblTaxTotal" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxAvg" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxMax" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxMin" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxWTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxMTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxYTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxTD" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tableEstValue" runat="server" visible="false">
                                    <td style="width: 200px; border-bottom: 0; border-right: 0;">
                                        <span style="font-weight: bold;">Job Value (Inc. Tax)</span>
                                    </td>
                                    <td style="text-align: right; border-bottom: 0;">
                                        <asp:Label ID="lblinvTotal" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblinvAverage" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblinvMaximum" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblinvminimum" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblEstWTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblEstMTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblEstYTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblEstTD" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tableGrossPrice" runat="server" visible="false">
                                    <td style="width: 200px; border-bottom: 0; border-right: 0;">
                                        <span style="font-weight: bold;">Gross Profit ($)</span>
                                    </td>
                                    <td style="text-align: right; border-bottom: 0;">
                                        <asp:Label ID="lblnetTotal" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblnetAvg" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblnetMax" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblnetMin" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblnetWTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblnetMTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblnetYTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblnetTD" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tableGrossPercent" runat="server" visible="false">
                                    <td style="width: 200px; border-bottom: 0; border-right: 0;">
                                        <span style="font-weight: bold;">Gross Profit (%) </span>
                                    </td>
                                    <td style="text-align: right; border-bottom: 0;">
                                        <asp:Label ID="lblTotgrossPercentage" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblAvggrossPercentage" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblMaxgrossPercentage" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblMingrossPercentage" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblpercentWTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblpercentMTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblpercentYTD" runat="server"></asp:Label>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblpercentTD" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="height: 50px">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
        <asp:Button ID="btnsavemultiple" runat="server" OnClick="btnsavemultiple_onclick"
            Style="visibility: hidden"></asp:Button>
        <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
        <asp:HiddenField ID="hdn_ReportIDs" runat="server" Value="" />
        <asp:HiddenField ID="hdnInnerHtml" runat="server" />
        <asp:HiddenField ID="HdnSortBy" runat="server" Value="JobNumber" />
        <asp:HiddenField ID="HdnStaus" runat="server" />
        <script type="text/javascript">
            var RB1 = document.getElementById("<%=rdlDate.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var rdlDateArray = getName('<%=rdlDate.ClientID %>');
            var chkDateOption = document.getElementById("<%=chkDateOption.ClientID%>");
            var chkDeilveryOption = document.getElementById("<%=chkDeilveryOption.ClientID%>");

            var chkconvertedoption = document.getElementById("<%=chkconvertedoption.ClientID%>");
            var rdlconverteddateArray = getName('<%=rdlconverteddate.ClientID %>');
            var rdlDeliverydateArray = getName('<%=rdlDeliverDate.ClientID %>');
            var RB1converted = document.getElementById("<%=rdlconverteddate.ClientID%>");
            var radioConverted = RB1converted.getElementsByTagName("input");

            var RB1Delivery = document.getElementById("<%=rdlDeliverDate.ClientID%>");
            var radioDelivery = RB1Delivery.getElementsByTagName("input");

            var txtfromdate_converted = document.getElementById("<%=txtfromdate_converted.ClientID %>");
            var txtDeliveryForm_Date = document.getElementById("<%=txtDeliveryForm_Date.ClientID %>");
            var txttodate_converted = document.getElementById("<%=txttodate_converted.ClientID %>");
            var txtDeliveryTo_date = document.getElementById("<%=txtDeliveryTo_date.ClientID %>");
            var lnkSelectAll1 = document.getElementById("lnkSelectAll1");

            var txtFromDate = document.getElementById("<%=txtFrom.ClientID %>");
            var txtToDate = document.getElementById("<%=txtTo.ClientID %>");
            var CHK1 = document.getElementById("<%=chkColumns.ClientID%>");
            var chk = CHK1.getElementsByTagName("input");
            var ChkColumns2 = document.getElementById("<%=chkColumns2.ClientID%>");
            var chk2 = ChkColumns2.getElementsByTagName("input");
            var ChkColumnsNet = document.getElementById("<%=ChkColumnsNetprofit.ClientID%>");
            var chknet = ChkColumnsNet.getElementsByTagName("input");
            var ChkClmnsNetPercentage = document.getElementById("<%=ChkClmnsNetPercentage.ClientID%>");
            var chknetPercentage = ChkClmnsNetPercentage.getElementsByTagName("input");
            var lnkSelectAll = document.getElementById("lnkSelectAll");
            var ddlEstimateRange = document.getElementById("<%=ddlEstimateRange.ClientID %>");
            var lstStatus = document.getElementById("<%=lstStatus.ClientID %>");
            var chkEstimate = document.getElementById("<%=chkEstimate.ClientID %>");
            var divchkEstimate = document.getElementById("divchkEstimate");
            var txtName = document.getElementById("<%=txtName.ClientID %>");
            var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
            var DateFormat = '<%=DateFormat %>';
            var chkColumns = getName("<%=chkColumns.ClientID %>");
            var hdnInnerHtml = document.getElementById("<%=hdnInnerHtml.ClientID %>");

            //new added by ayesha for saving reports
            var txtSaveReports = document.getElementById("<%=txtSaveReports.ClientID %>");
            var div_showfilters = document.getElementById("<%=div_showfilters.ClientID %>");
            var divusrReportsave = document.getElementById("<%=divusrReportsave.ClientID %>");





            function Call_Report(liID) {
                document.getElementById(liID).style.color = "orange";
                for (var i = 1; i <= 2; i++) {
                    var dd = "spn_" + i;
                    if (dd != liID) {

                        if (document.getElementById("spn_" + i) != null) {
                            document.getElementById("spn_" + i).style.color = "black";
                        }
                    }
                    else {
                    }
                }

                if (liID == 'spn_2' || liID == 'A2') {
                    divusrReportsave.style.display = 'none';
                    div_showfilters.style.display = 'block';
                }
                else if (liID == "spn_1" || liID == 'A1') {
                    divusrReportsave.style.display = 'block';
                    div_showfilters.style.display = 'none';

                }
            }

            //validation when save as new and update existing btn is clicked- ayesha
            var Check = false;
            function ValidateSave() {
                Check = true;
                var count = 0;
                for (var j = 0; j < chkColumns.length; j++) {
                    if (chkColumns[j].checked) {
                        count++;
                    }
                }
                if (count == 0) {
                    Check = false;
                }

                var jobno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (jobno.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Job_Number_To_Generate_Report")%>');
                    return false;
                }
                //                var jobval = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_16');
                //                if (jobval.checked == false) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Job_Value_To_Generate_Report")%>');
                //                    return false;
                //                }

                if (txtSaveReports.value == '') {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Enter_Report_Name")%>');
                    txtSaveReports.focus();
                    Check = false;
                }

                if (chkDateOption.checked) {
                    var spndateRange = document.getElementById("spndateRange");
                    for (var i = 0; i < radio.length; i++) {
                        if (radio[i].checked) {
                            if (radio[i].value == "daterange") {
                                if (txtFromDate.value == "" || txtToDate.value == "") {
                                    document.getElementById("spn_txtFromDate").innerHTML = "Please enter a valid date";
                                    document.getElementById("spn_txtFromDate").style.display = "block";
                                    Check = false;
                                }
                                else {
                                    if (Date(txtFromDate.value) <= Date(txtToDate.value)) {
                                        if (ValidateForm(txtFromDate, 'spn_txtFromDate', DateFormat) == false) {
                                            Check = false;
                                        }
                                        else if (ValidateForm(txtToDate, 'spn_txtFromDate', DateFormat) == false) {
                                            Check = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (Check) {
                    return true;
                }
                else {
                    return false;
                }
            }
            function ValidateCaller() {
                if (!ValidateSave()) { return false; }
                else {
                    document.getElementById("ds00").style.display = "block";
                    document.getElementById("div_Load").style.display = "block";
                    return true;
                }
                showWaitMessage();

            }

            function loading() {
                CheckGrid();
                showWaitMessage();
            }

            function getName(RdID) {
                var Rdl = document.getElementById(RdID);
                var RdlName = Rdl.getElementsByTagName("input");
                return RdlName;
            }

            function GetRadioButtonValue() {
                for (var i = 0; i < radio.length; i++) {
                    if (radio[i].checked) {
                        if (radio[i].value == "daterange") {
                            txtFromDate.disabled = false;
                            txtToDate.disabled = false;
                        }
                        else {
                            txtFromDate.disabled = true;
                            txtToDate.disabled = true;
                        }
                    }
                }
            }



            function GetConveretedRadioButtonValue() {

                for (var i = 0; i < radioConverted.length; i++) {
                    if (radioConverted[i].checked) {
                        if (radioConverted[i].value == "daterange") {
                            txtfromdate_converted.disabled = false;
                            txttodate_converted.disabled = false;
                        }
                        else {
                            txtfromdate_converted.disabled = true;
                            txttodate_converted.disabled = true;
                        }
                    }
                }
            }

            function GetDeliveryRadioButtonValue() {

                for (var i = 0; i < radioDelivery.length; i++) {
                    if (radioDelivery[i].checked) {
                        if (radioDelivery[i].value == "daterange") {
                            txtDeliveryForm_Date.disabled = false;
                            txtDeliveryTo_date.disabled = false;
                        }
                        else {
                            txtDeliveryForm_Date.disabled = true;
                            txtDeliveryTo_date.disabled = true;
                        }
                    }
                }
            }

            function SelectAll() {

                var Count = 0;
                var dropDownListRef = document.getElementById('<%= ddlSortBy.ClientID %>');
                var HdnStaus = document.getElementById('<%= HdnStaus.ClientID %>');
                var StausValue = HdnStaus.value.split('~');
                for (j = dropDownListRef.length - 1; j >= 1; j--) {


                    dropDownListRef.remove(j);

                }
                if (trim12(lnkSelectAll.innerHTML) == trim12('<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>')) {
                    for (var i = 0; i < chk.length; i++) {
                        var option1 = document.createElement("option");
                        chk[i].checked = true;
                        lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                        //To Add DDL Items                    
                        if (i == 0) {
                            option1.text = "Job Number";
                            option1.value = "JobNumber";
                        }

                        else if (i == 1) {
                            option1.text = "Job Title";
                            option1.value = "JobTitle";
                        }

                        else if (i == 2) {
                            option1.text = "Company Name";
                            option1.value = "CompanyName";
                        }
                        else if (i == 12) {
                            option1.text = "Job Salesperson";
                            option1.value = "SalesPerson";
                        }
                        else if (i == 18) {
                            option1.text = StausValue[0];
                            option1.value = StausValue[1];
                        }
                        else if (i == 13) {
                            option1.text = "Completion Date";
                            option1.value = "CompletionDate";
                        }
                        else if (i == 14) {
                            option1.text = "Created On";
                            option1.value = "ConvertedDate";
                        }
                        else if (i == 15) {
                            option1.text = "Delivery Date";
                            option1.value = "DeliveryDate";
                        }
                        else if (i == 16) {
                            option1.text = "Job Value";
                            option1.value = "JobValue";
                        }
                        else if (i == 30) {
                            option1.text = "Customer Order Number";
                            option1.value = "OrderNumber";
                        }
                        else if (i == 31) {
                            option1.text = "Referred By";
                            option1.value = "name";
                        }
                        else if (i == 66) {
                            option1.text = "Customer Salesperson";
                            option1.value = "CustomerSalesperson";
                        }
                        if (i == 0 || i == 1 || i == 2 || i == 12 || i == 18 || i == 13 || i == 14 || i == 15 || i == 16 || i == 30 || i == 31 || i == 66) {
                            dropDownListRef.options.add(option1);
                        }
                    }
                    dropDownListRef.value = "JobNumber";
                    HdnSortBy.value = "JobNumber";
                }


                else {
                    for (var i = 0; i < chk.length; i++) {
                        chk[i].checked = false;
                        //lnkSelectAll.innerHTML = "Select All";
                        lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';
                    }
                }
            }
            function OnCheckShow() {
                var txtFromDate = document.getElementById("<%=txtFrom.ClientID %>");
                var txtToDate = document.getElementById("<%=txtTo.ClientID %>");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month");

                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;
                if (chkDateOption.checked) {
                    if (ddlvalue == "thismonth") {
                        spn_3.style.display = "block";
                    }
                    else if (ddlvalue == "daterange") {
                        txtFromDate.disabled = false;
                        txtToDate.disabled = false;
                    }

                }

                else {
                    spn_3.style.display = "none";
                }

            }

            function OnCheckShowConverted() {
                var txtFromDate = document.getElementById("<%=txtfromdate_converted.ClientID %>");
                var txtToDate = document.getElementById("<%=txttodate_converted.ClientID %>");

                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_c");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlconverteddate");
                var ddlvalue = ddlConvertedJobCreated.options[ddlConvertedJobCreated.selectedIndex].value;
                if (chkconvertedoption.checked) {
                    if (ddlvalue == "thismonth") {
                        spn_3.style.display = "block";
                    }
                    else if (ddlvalue == "daterange") {
                        txtFromDate.disabled = false;
                        txtToDate.disabled = false;
                    }

                }

                else {
                    spn_3.style.display = "none";
                }

            }
            function OnCheckShowDelivery() {
                var txtFromDate = document.getElementById("<%=txtDeliveryForm_Date.ClientID %>");
                var txtToDate = document.getElementById("<%=txtDeliveryTo_date.ClientID %>");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_d");
                var ddlDeliveryJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDeliverDate");
                var ddlvalue = ddlDeliveryJobCreated.options[ddlDeliveryJobCreated.selectedIndex].value;

                if (chkDeilveryOption.checked) {
                    if (ddlvalue == "thismonth") {
                        spn_3.style.display = "block";
                    }
                    else if (ddlvalue == "daterange") {
                        txtFromDate.disabled = false;
                        txtToDate.disabled = false;
                    }

                }

                else {
                    spn_3.style.display = "none";
                }

            }

            function EnableDateOption() {
                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                if (chkDateOption.checked) {
                    for (var i = 0; i < ddlJobCreated.length; i++) {
                        ddlJobCreated.disabled = false;

                    }
                }
                else {
                    for (var i = 0; i < ddlJobCreated.length; i++) {
                        ddlJobCreated.disabled = true;
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }

                }
            }

            function EnableConvertedDateOption() {
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlconverteddate");
                if (chkconvertedoption.checked) {
                    for (var i = 0; i < ddlConvertedJobCreated.length; i++) {
                        ddlConvertedJobCreated.disabled = false;
                    }
                }
                else {
                    for (var i = 0; i < ddlConvertedJobCreated.length; i++) {
                        ddlConvertedJobCreated.disabled = true;
                        txtfromdate_converted.disabled = true;
                        txttodate_converted.disabled = true;
                    }
                }
            }

            function EnableDeliveryDateOption() {

                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
                var rdlDeliverDate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDeliverDate");
                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;
                if (chkDeilveryOption.checked) {
                    for (var i = 0; i < rdlDeliverDate.length; i++) {
                        rdlDeliverDate.disabled = false;
                    }
                }

                else {
                    for (var i = 0; i < rdlDeliverDate.length; i++) {
                        rdlDeliverDate.disabled = true;
                        txtDeliveryForm_Date.disabled = true;
                        txtDeliveryTo_date.disabled = true;
                    }

                }
            }

            function checkdates() {
                var divdates = document.getElementById("divdates");

                if (chkconvertedoption.checked == true && chkDateOption.checked == true) {
                    divdates.style.display = 'block';
                }
                else {
                    divdates.style.display = 'none';
                }
            }

            function checkDeliveryInvoice() {
                var DivDlivery = document.getElementById("DivDlivery");
                var chkDeilveryOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkDeilveryOption");
                var chkConerted = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkconvertedoption");

                if (chkconvertedoption.checked == true && chkDeilveryOption.checked == true) {
                    DivDlivery.style.display = 'block';
                }
                else {
                    DivDlivery.style.display = 'none';
                }
            }

            function DisbaleConertedToInvoice() {
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlconverteddate");
                var ddlInvoiceStatus = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlInvoiceStatus");
                var ddlvalue = ddlInvoiceStatus.options[ddlInvoiceStatus.selectedIndex].value;
                var DivDlivery = document.getElementById("DivDlivery");
                if (ddlvalue == "UnInvoiced") {
                    chkconvertedoption.disabled = true;
                    chkconvertedoption.checked = false;
                    divdates.style.display = 'none';
                    DivDlivery.style.display = 'none';
                    ddlConvertedJobCreated.disabled = true;
                }
                else {
                    chkconvertedoption.disabled = false;
                }
            }

        </script>
        <script>
            //********** web service to autocomplete clientname *********//
            function showddl(divid) {
                document.getElementById(divid).style.display = "block";
            }
            function ShowOff(divid) {
                document.getElementById(divid).style.display = "none";
            }
            this.pointer = 0;
            function BindClientName(txtval, e, objectname) {
                var ac = this;
                this.textbox = document.getElementById(objectname.id);
                this.div = document.getElementById('divCheck');
                this.list = this.div.getElementsByTagName('div');
                var innertextbox = document.getElementById(objectname.id);
                if (e != undefined) {
                    e = e || window.event;
                    switch (e.keyCode) {
                        case 38: //up
                            ac.selectDiv(-1);
                            break;
                        case 40: //down
                            ac.selectDiv(1);
                            break;
                        case 13: //hide div
                            ShowOff("divCheck");
                            break;

                        default:
                            {
                                if (txtval.length > 2) {
                                    this.pointer = 0;
                                    var CompID = '<%=CompanyID %>';
                                    var val = CompID + "±" + txtval;
                                    PageMethods.GetClientName(val, FindSuccCName);
                                }
                            }
                    }
                }

                this.selectDiv = function (inc) {
                    if (this.pointer != null && this.pointer + inc >= 0 && this.pointer + inc < this.list.length) {
                        this.list[this.pointer].className = 'active1';
                        this.pointer += inc;
                        this.list[this.pointer].className = 'active';
                        this.newList = this.list[this.pointer].getElementsByTagName('a')
                        this.newList[0].focus();
                        this.newList[0].onkeydown = function (e)// 
                        {

                            e = e || window.event;
                            switch (e.keyCode) {
                                case 38: //up
                                    {
                                        innertextbox.focus();
                                        break;
                                    }
                                case 40: //down
                                    {
                                        innertextbox.focus();
                                        break;
                                    }
                            }
                        }
                    }
                }
                //gajendra 
            }


            function FindSuccCName(result) {
                //alert(result);
                if (trim12(result) != '') {
                    showddl('divCheck');
                    var divCheck = document.getElementById("divCheck");

                    var str_prop1 = result.split('µ');
                    var store_Name = '';
                    var store_ID = '';
                    var store_contacts = '';
                    var store_accountno = '';
                    var store_address = '';

                    var finalval = '';
                    for (var i = 0; i < str_prop1.length - 1; i++) {
                        var str_prop2 = str_prop1[i].split('$'); //1$Weight^Color^^^^^  
                        store_ID = str_prop2[0];
                        store_Name = str_prop2[1];
                        store_contacts = str_prop2[2];
                        store_accountno = str_prop2[3];
                        store_address = str_prop2[4];
                        var color1 = "#DADADA";
                        if (i % 2 == 0) {
                            color1 = "#EFEFEF";
                        }
                        finalval += " <div class='divpad' style='height:20px;z-index:1000;'>";
                        finalval += " <a href='#' onclick=\"javaScript:GetClientName11('" + store_ID + "','" + store_Name + "','" + store_contacts + "','" + store_accountno + "','" + store_address + "')\">" + store_Name + "</a>";
                        finalval += "</div>";
                    }
                    divCheck.innerHTML = finalval;
                }
                else {
                    ShowOff('divCheck');
                }
            }
            function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address) {
                txtName.value = SpecialDecode(ClientName);
                hid_ClientID.value = ClientID;
            }
            //********** End Of web service to autocomplete clientname *********//


            var CheckFinal = false;
            function CheckDateFormat() {
                CheckFinal = true;
                var count = 0;
                for (var j = 0; j < chkColumns.length; j++) {
                    if (chkColumns[j].checked) {
                        count++;
                    }
                }
                if (count == 0) {
                    CheckFinal = false;
                }
                var jobno = document.getElementById('ctl00_ContentPlaceHolder1_chkColumns_0');
                if (jobno.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Job_Number_To_Generate_Report")%>');
                    return false;
                }
                var jobval = document.getElementById('ctl00_ContentPlaceHolder1_chkColumns_16');
                if (jobval.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Job_Value_To_Generate_Report")%>');
                    return false;
                }

                if (chkDateOption.checked) {
                    var spndateRange = document.getElementById("spndateRange");
                    for (var i = 0; i < radio.length; i++) {
                        if (radio[i].checked) {
                            if (radio[i].value == "daterange") {

                                if (txtFromDate.value == "" || txtToDate.value == "") {
                                    document.getElementById("spn_txtFromDate").innerHTML = "Please enter a valid date";
                                    document.getElementById("spn_txtFromDate").style.display = "block";
                                    CheckFinal = false;
                                }
                                else {
                                    if (Date(txtFromDate.value) <= Date(txtToDate.value)) {
                                        if (ValidateForm(txtFromDate, 'spn_txtFromDate', DateFormat) == false) {
                                            CheckFinal = false;
                                        }
                                        else if (ValidateForm(txtToDate, 'spn_txtFromDate', DateFormat) == false) {
                                            CheckFinal = false;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                if (CheckFinal) {
                    return true;
                }
                else {
                    return false;
                }
            }
        </script>
        <asp:Panel ID="pnlDateOption_Disable" runat="server" Visible="false">
            <script>
                //To disable Date rdl by default //
                if (chkDateOption.checked) {
                    for (var i = 0; i < rdlDateArray.length; i++) {
                        rdlDateArray[i].disabled = false;
                    }
                }
                else {
                    for (var i = 0; i < rdlDateArray.length; i++) {
                        rdlDateArray[i].disabled = true;
                        rdlDateArray[i].style.color = "red";
                    }
                }
                // To disable Date rdl by default Ends //
                if (chkconvertedoption.checked) {
                    for (var i = 0; i < rdlconverteddateArray.length; i++) {
                        rdlconverteddateArray[i].disabled = false;
                    }
                }
                else {
                    for (var i = 0; i < rdlconverteddateArray.length; i++) {
                        rdlconverteddateArray[i].disabled = true;
                        rdlconverteddateArray[i].style.color = "red";
                    }
                }
                // To disable Date rdl by default Ends //
                if (chkDeilveryOption.checked) {
                    for (var i = 0; i < rdlDeliverydateArray.length; i++) {
                        rdlDeliverydateArray[i].disabled = false;
                    }
                }
                else {
                    for (var i = 0; i < rdlDeliverydateArray.length; i++) {
                        rdlDeliverydateArray[i].disabled = true;
                        rdlDeliverydateArray[i].style.color = "red";
                    }
                }

            </script>
        </asp:Panel>
        <asp:Panel ID="pnlGridview" runat="server" Visible="false">
            <script type="text/javascript">



                var GridItemTitle = document.getElementById("<%=GridEstReport.ClientID %>");
                function CallOverflow() {

                    SetGridOverflow(GridItemTitle);
                }
                CallOverflow();

            </script>
        </asp:Panel>
        <script type="text/javascript">
            function GetSummaryDetails() {
                document.getElementById("divDetails").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_SummaryDetail").innerHTML = 'None';
                var rdosummary = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary");
                if (rdosummary.checked == true) {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "block";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "none";
                }
                GetDropdownBindonBack();
                GetDropdownBindback();
                GetDeliveryDropdownBindBack();
                EnableDateOption();
                EnableConvertedDateOption();
                EnableDeliveryDateOption();
                checkDeliveryInvoice();
                checkdates();
            }
            function GetDetails() {
                document.getElementById("divDetails").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_SummaryDetail").innerHTML = 'None';
                var rdodetail = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdodetail");
                if (rdodetail.checked == true) {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "block";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "none";
                }
                GetDropdownBindonBack();
                GetDropdownBindback();
                GetDeliveryDropdownBindBack();
                EnableDateOption();
                EnableConvertedDateOption();
                EnableDeliveryDateOption();
                checkDeliveryInvoice();
                checkdates();
            }
            function SummaryorDetialsSelectnone() {
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdodetail").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_SummaryDetail").innerHTML = '';
                GetDetails();
                GetSummaryDetails();

            }

            function getInnerHtml() {
                var element = document.getElementById("divexport1");
                document.getElementById('<%=hdnInnerHtml.ClientID%>').value = element.innerHTML;
            }


            var CHK11 = document.getElementById("<%=chkColumns1.ClientID%>");
            var chk1 = CHK11.getElementsByTagName("input");
            var chkColumns1 = getName("<%=chkColumns1.ClientID %>");

            function GetSelect() {
                var x = 0, y = 0;
                for (var i = 0; i < chk.length; i++) {
                    if (chk[i].checked == true) {
                        x++;
                    }
                }

                if (x == chk.length) {
                    lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                }
                else {
                    lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All")%>';
                }

                for (var i = 0; i < chk1.length; i++) {
                    if (chk1[i].checked == true) {
                        y++;
                    }
                }
                for (var i = 0; i < chk2.length; i++) {
                    if (chk2[i].checked == true) {
                        y++;
                    }
                }
                for (var i = 0; i < chknet.length; i++) {
                    if (chknet[i].checked == true) {
                        y++;
                    }
                }
                for (var i = 0; i < chknetPercentage.length; i++) {
                    if (chknetPercentage[i].checked == true) {
                        y++;
                    }
                }

                if (y == (chk1.length + chk2.length + chknet.length + chknetPercentage.length)) {
                    lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                }
                else {
                    lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All")%>';
                }

                var divdates = document.getElementById("divdates");

                if (chkconvertedoption.checked == true && chkDateOption.checked == true) {
                    divdates.style.display = 'block';
                }
                else {
                    divdates.style.display = 'none';
                }



                for (var i = 0; i < radio.length; i++) {
                    if (radio[i].checked) {
                        if (radio[i].value == "daterange") {
                            txtFromDate.disabled = false;
                            txtToDate.disabled = false;
                        }
                        else {
                            txtFromDate.disabled = true;
                            txtToDate.disabled = true;
                        }
                    }
                    GetSummaryDetails();
                    GetDetails();
                }
                for (var i = 0; i < radioConverted.length; i++) {
                    if (radioConverted[i].checked) {
                        if (radioConverted[i].value == "daterange") {
                            txtfromdate_converted.disabled = false;
                            txttodate_converted.disabled = false;
                        }
                        else {
                            txtfromdate_converted.disabled = true;
                            txttodate_converted.disabled = true;
                        }
                    }
                }
                for (var i = 0; i < radioDelivery.length; i++) {
                    if (radioDelivery[i].checked) {
                        if (radioDelivery[i].value == "daterange") {
                            txtDeliveryForm_Date.disabled = false;
                            txtDeliveryTo_date.disabled = false;
                        }
                        else {
                            txtDeliveryForm_Date.disabled = true;
                            txtDeliveryTo_date.disabled = true;
                        }
                    }
                }

                GetDropdownBindonBack();
                GetDropdownBindback();
                GetDeliveryDropdownBindBack();
                EnableDateOption();
                EnableConvertedDateOption();
                EnableDeliveryDateOption();
                checkDeliveryInvoice();
                DisbaleConertedToInvoice();
            }
            var Check_SpecialPrivilege1 = '<%=Check_SpecialPrivilege %>';

            var chkExcTax = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i3_chkExcTax");
            var chkTax = chkExcTax.getElementsByTagName("input");
            var chkCost = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i3_ChkClmnsCostPriceExMarkup");
            var chkCostExMarkup = chkCost.getElementsByTagName("input");
            function SelectAllGroupByoption() {
                var Count = 0;
                if (lnkSelectAll1.innerHTML == '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>') {

                    for (var i = 0; i < chkCostExMarkup.length; i++) {
                        chkCostExMarkup[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                    }

                    for (var i = 0; i < chkTax.length; i++) {
                        chkTax[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                    }

                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                    }
                    for (var i = 0; i < chk2.length; i++) {
                        chk2[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                    }
                    if (Check_SpecialPrivilege1 == "False") {
                        for (var i = 0; i < chknet.length; i++) {
                            chknet[i].checked = true;
                            lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                        }
                        for (var i = 0; i < chknetPercentage.length; i++) {
                            chknetPercentage[i].checked = true;
                            lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                        }
                    }

                }
                else {

                    for (var i = 0; i < chkCostExMarkup.length; i++) {
                        chkCostExMarkup[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';
                    }

                    for (var i = 0; i < chkTax.length; i++) {
                        chkTax[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';
                    }
                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';
                    }
                    for (var i = 0; i < chk2.length; i++) {
                        chk2[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';;
                    }
                    if (Check_SpecialPrivilege1 == "False") {
                        for (var i = 0; i < chknet.length; i++) {
                            chknet[i].checked = false;
                            lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';;
                        }
                        for (var i = 0; i < chknetPercentage.length; i++) {
                            chknetPercentage[i].checked = false;
                            lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';;
                        }
                    }
                }
            }
        </script>
        <script language="javascript" type="text/javascript">
            function funcCaller() {
                if (!CheckDateFormat()) { return false; }
                else {
                    document.getElementById("ds00").style.display = "block";
                    document.getElementById("div_Load").style.display = "block";
                    return true;
                }
                showWaitMessage();
            }
            function Disablelnk() { }

        </script>
        <asp:Panel ID="pnlReports" runat="server" Visible="false">
            <script type="text/javascript">

                Call_Report('spn_2');

            </script>
        </asp:Panel>
        <asp:Panel ID="pnlSavedReports" runat="server" Visible="false">
            <script type="text/javascript">

                Call_Report('spn_1');

            </script>
        </asp:Panel>
        <script type="text/javascript">
            //======Created On 25/05/2012 ===By Pradeep======
            var Checkcolumns = document.getElementById('<%= chkColumns.ClientID %>');
            var columnsList = Checkcolumns.getElementsByTagName("input");
            var dropDownListRef = document.getElementById('<%= ddlSortBy.ClientID %>');
            var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');
            var HdnStaus = document.getElementById('<%= HdnStaus.ClientID %>');
            var StausValue = HdnStaus.value.split('~');
            function AddDDLValue(text, value, k) {

                var option1 = document.createElement("option");
                if (text != "" && value != "") {
                    option1.text = text;
                    option1.value = value;
                }

                if (columnsList[k].checked) {

                    dropDownListRef.options.add(option1);
                    //HdnSortBy.value = "JobNumber";
                }
                else {

                    for (j = dropDownListRef.length - 1; j >= 0; j--) {

                        if (dropDownListRef.options[j].value == value) {
                            dropDownListRef.remove(j);
                            HdnSortBy.value = "none";
                        }
                    }
                }
            }




            for (var i = 0; i < columnsList.length; i++) {

                var option1 = document.createElement("option");
                if (i == 0) {
                    option1.text = "Job Number"
                    option1.value = "JobNumber";
                }
                else if (i == 1) {
                    option1.text = "Job Title";
                    option1.value = "JobTitle";
                }
                else if (i == 2) {
                    option1.text = "Company Name";
                    option1.value = "CompanyName";
                    //option1.value = "CustomerID";
                }
                else if (i == 12) {
                    option1.text = "Job Salesperson";
                    option1.value = "SalesPerson";
                }
                else if (i == 18) {
                    option1.text = StausValue[0];
                    option1.value = StausValue[1];
                }
                else if (i == 13) {
                    option1.text = "Completion Date";
                    option1.value = "CompletionDate";
                }
                else if (i == 14) {
                    option1.text = "Created On";
                    option1.value = "ConvertedDate";
                }
                else if (i == 15) {
                    option1.text = "Delivery Date";
                    option1.value = "DeliveryDate";
                }
                else if (i == 16) {
                    option1.text = "Job Value";
                    option1.value = "JobValue";
                }
                else if (i == 30) {
                    option1.text = "Customer Order Number";
                    option1.value = "OrderNumber";
                }
                else if (i == 31) {
                    option1.text = "Referred By";
                    option1.value = "name";
                }
                else if (i == 32) {
                    option1.text = "Sub Total";
                    option1.value = "SubTotal";
                }
                else if (i == 66) {
                    option1.text = "Customer Salesperson";
                    option1.value = "CustomerSalesperson";
                }
                if (i == 0 || i == 1 || i == 2 || i == 12 || i == 18 || i == 13 || i == 14 || i == 15 || i == 16 || i == 30 || i == 31 || i == 66) {
                    if (columnsList[i].checked) {
                        dropDownListRef.options.add(option1);
                    }
                }
                dropDownListRef.value = "JobNumber";
                //HdnSortBy.value = "JobNumber";
            }


            function ddlsortByOnchange() {
                var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');
                var ddlSortBy = document.getElementById('<%= ddlSortBy.ClientID %>');
                HdnSortBy.value = ddlSortBy.options[ddlSortBy.selectedIndex].value;
            }

            //===========Created by Sharanu=========================
            function GetDropdownBindonBack() {
                var txtFromDate = document.getElementById("<%=txtFrom.ClientID %>");
                var txtToDate = document.getElementById("<%=txtTo.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_year");
                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divjobdate");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_span_halfyear");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_SpanNext3days");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth");
                var spn_12 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear");
                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;

                if (chkDateOption.checked) {

                    if (ddlvalue == "daily") {
                        spn_1.style.display = "block";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "yesterday") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "block";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thismonth") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "block";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thisquarter") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "block";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thisyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "block";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "tilldate") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "daterange") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "block";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = false;
                        txtToDate.disabled = false;
                    }
                    else if (ddlvalue == "lastquater") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "block";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "halfyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "block";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastweek") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "block";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastmonth") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "block";
                        spn_12.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "block";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }

                }
            }



            function GetDropdownBindback() {

                var txtFromDate = document.getElementById("<%=txtfromdate_converted.ClientID %>");
                var txtToDate = document.getElementById("<%=txttodate_converted.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily_c");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest_c");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_c");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter_c");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_year_c");
                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divjobdate_c");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque_c");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_span_halfyear_c");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_c");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth_c");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_c");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlconverteddate");
                var ddlvalue = ddlConvertedJobCreated.options[ddlConvertedJobCreated.selectedIndex].value;
                var ddlSortBy = document.getElementById("<%=ddlSortBy.ClientID%>");
                ddlSortBy.value = HdnSortBy.value;
                if (chkconvertedoption.checked) {
                    if (ddlvalue == "daily") {
                        spn_1.style.display = "block";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "yesterday") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "block";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thismonth") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "block";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thisquarter") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "block";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thisyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "block";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "tilldate") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "daterange") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "block";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = false;
                        txtToDate.disabled = false;
                    }
                    else if (ddlvalue == "lastquater") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "block";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "halfyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "block";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastweek") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "block";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastmonth") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "block";
                        spn_11.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "block";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                }
            }

            function GetDeliveryDropdownBindBack() {

                var txtFromDate = document.getElementById("<%=txtDeliveryForm_Date.ClientID %>");
                var txtToDate = document.getElementById("<%=txtDeliveryTo_date.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily_d");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest_d");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_d");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter_d");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_year_d");
                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divDeliveryDate");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque_d");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_span_halfyear_d");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_SpanNext3days");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_d");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth_d");
                var spn_12 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_d");
                var ddlDeliveryJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDeliverDate");
                var spn_rdlDeliverDate_annualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_rdlDeliverDate_annualYear");
                var ddlvalue = ddlDeliveryJobCreated.options[ddlDeliveryJobCreated.selectedIndex].value;

                if (chkDeilveryOption.checked) {
                    if (ddlvalue == "thisannualyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "block";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "daily") {
                        spn_1.style.display = "block";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "yesterday") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "block";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thismonth") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "block";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thisquarter") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "block";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "thisyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "block";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "tilldate") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "daterange") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "block";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = false;
                        txtToDate.disabled = false;
                    }
                    else if (ddlvalue == "lastquater") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "block";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "halfyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "block";
                        spn_9.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "next3days") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "block";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastweek") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "block";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastmonth") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "block";
                        spn_12.style.display = "none";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "lastyear") {
                        spn_1.style.display = "none";
                        spn_2.style.display = "none";
                        spn_3.style.display = "none";
                        spn_4.style.display = "none";
                        spn_5.style.display = "none";
                        spn_6.style.display = "none";
                        spn_7.style.display = "none";
                        spn_8.style.display = "none";
                        spn_9.style.display = "none";
                        spn_10.style.display = "none";
                        spn_11.style.display = "none";
                        spn_12.style.display = "block";
                        spn_rdlDeliverDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                }

            }


            function GetDropdownBind() {

                var txtFromDate = document.getElementById("<%=txtFrom.ClientID %>");
                var txtToDate = document.getElementById("<%=txtTo.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_year");
                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divjobdate");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_span_halfyear");

                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear");
                var spn_rdlDate_annualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_rdlDate_annualYear");


                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;

                if (ddlvalue == "thisannualyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daily") {
                    spn_1.style.display = "block";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "yesterday") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "block";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thismonth") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "block";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thisquarter") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "block";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thisyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "block";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "tilldate") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daterange") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "block";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = false;
                    txtToDate.disabled = false;
                }
                else if (ddlvalue == "lastquater") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "block";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "halfyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "block";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastweek") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "block";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastmonth") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "block";
                    spn_11.style.display = "none";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "block";
                    spn_rdlDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }





            function GetDeliveryDropdownBind() {

                var txtFromDate = document.getElementById("<%=txtDeliveryForm_Date.ClientID %>");
                var txtToDate = document.getElementById("<%=txtDeliveryTo_date.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily_d");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest_d");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_d");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter_d");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_year_d");
                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divDeliveryDate");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque_d");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_span_halfyear_d");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_SpanNext3days");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_d");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth_d");
                var spn_12 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_d");
                var ddlDeliveryJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDeliverDate");
                var spn_rdlDeliverDate_annualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_rdlDeliverDate_annualYear");
                var ddlvalue = ddlDeliveryJobCreated.options[ddlDeliveryJobCreated.selectedIndex].value;

                if (ddlvalue == "thisannualyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daily") {
                    spn_1.style.display = "block";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "yesterday") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "block";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thismonth") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "block";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thisquarter") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "block";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thisyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "block";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "tilldate") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daterange") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "block";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = false;
                    txtToDate.disabled = false;
                }
                else if (ddlvalue == "lastquater") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "block";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "halfyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "block";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastweek") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "block";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastmonth") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "block";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "block";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "next3days") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "block";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_12.style.display = "none";
                    spn_rdlDeliverDate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }

            }


            function GetConevrtedDropdownBind() {

                var txtFromDate = document.getElementById("<%=txtfromdate_converted.ClientID %>");
                var txtToDate = document.getElementById("<%=txttodate_converted.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily_c");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest_c");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_c");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter_c");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_year_c");
                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_tilldate");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divjobdate_c");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque_c");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_span_halfyear_c");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_c");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth_c");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_c");
                var spn_rdlconverteddate_annualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_rdlconverteddate_annualYear");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlconverteddate");
                var ddlvalue = ddlConvertedJobCreated.options[ddlConvertedJobCreated.selectedIndex].value;

                if (ddlvalue == "thisannualyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daily") {
                    spn_1.style.display = "block";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "yesterday") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "block";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thismonth") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "block";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thisquarter") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "block";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "thisyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "block";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "tilldate") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daterange") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "block";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = false;
                    txtToDate.disabled = false;
                }
                else if (ddlvalue == "lastquater") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "block";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "halfyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "block";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastweek") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "block";
                    spn_10.style.display = "none";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastmonth") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "block";
                    spn_11.style.display = "none";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spn_8.style.display = "none";
                    spn_9.style.display = "none";
                    spn_10.style.display = "none";
                    spn_11.style.display = "block";
                    spn_rdlconverteddate_annualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }


            //=====================End==============================
            //====Created On 06-09-2012== By Pradeep

            function OnEditReport(SelectedValue) {
                var dropDownListRef = document.getElementById('<%= ddlSortBy.ClientID %>');
                var rdosummary = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary");
                var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');

                document.getElementById("divDetails").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_SummaryDetail").innerHTML = 'None';
                var rdodetail = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdodetail");
                if (rdodetail.checked == true || rdosummary.checked == true) {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "block";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "none";
                }
                for (var i = 0; i <= dropDownListRef.length - 1; i++) {

                    if (dropDownListRef.options[i].value == SelectedValue) {
                        dropDownListRef.options[i].selected = true;
                    }
                }
                HdnSortBy.value = dropDownListRef.options[dropDownListRef.selectedIndex].value;
                GetDropdownBindonBack();
                GetDropdownBindback();
                GetDeliveryDropdownBindBack();
                EnableDateOption();
                EnableConvertedDateOption();
                EnableDeliveryDateOption();
                checkDeliveryInvoice();
                checkdates();
            }

            function Runvalidate() {

                var jobno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (jobno.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Job_Number_To_Generate_Report")%>');
                    return false;
                }
            }

            //======================================
            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        </script>
        <script>
            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        </script>
    </div>
</asp:Content>

