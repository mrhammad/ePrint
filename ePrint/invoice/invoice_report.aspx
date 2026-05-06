<%@ Page Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="invoice_report.aspx.cs" Inherits="ePrint.invoice.invoice_report" Title="Untitled Page" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

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
        <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
        <div id="ds00" style="display: block;">
        </div>
        <div id="div_Load" class="loading_new">
            <UC:Loading ID="ucLoading" runat="server" />
        </div>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7" />
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
        </style>
        <style type="text/css">
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
                width: 185px;
                height: 18px;
            }

            .ddlComboBox .rcbInputCellLeft {
                background-image: none;
            }

            .chkBoxListInvoice td {
                width: 10%;
            }

            #ctl00_ContentPlaceHolder1_GridEstReport .commonheaderstylereport11 th {
                white-space: nowrap;
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
        <script>
            var Pgtype = '<%=pg %>';
        </script>
        <div id="divBackGroundNew" style="display: none;">
        </div>
        <div id="div_option" runat="server">
            <div id="waitmessage" style="visibility: hidden; width: 200px; position: absolute; top: 46%; left: 47%">
                <table cellpadding="20" cellspacing="10">
                    <tr>
                        <td align="right" bordercolor="#ffffff"></td>
                    </tr>
                </table>
            </div>
            <div id="divtab" runat="server">
                <div style="display: none" id="padding">
                    <ul>
                        <span id="spn_Call_Report" runat="server">
                            <li id="li_Save" style="cursor: pointer; float: left; clear: right; display: block;">
                                <div id="div_SR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px; float: left; line-height: 20px; margin-right: 2px">
                                    <b><span id="spn_1" onclick="Call_Report(this.id);">Saved Reports </span></b>
                                </div>
                            </li>
                        </span>
                        <li id="li_Customize" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_CR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px; float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="spn_2" onclick="Call_Report(this.id);">Customize Reports</span></b>
                            </div>
                        </li>
                    </ul>
                </div>
                <div style="clear: both;">
                </div>
                <div id="tabs" class="ui-tabs" style="width: 98%; border: solid 0px red; visibility: hidden; padding-top: 3px; padding-left: 5px">
                    <ul id="test-1" style="list-style: none; height: auto; width: 97.4%; background-color: #FFFFFF; margin-left: 5px; border-left: 1px solid transparent; border-right: 1px solid transparent; border-top: 1px solid transparent; border-radius: 0px; border-bottom: 1px solid transparent">
                        <li style="margin-left: -5px"><a id="A1" href="#tabs-1" onclick="Call_Report(this.id);">
                            <b>
                                <%=objLanguage.GetLanguageConversion("Saved_Reports")%></b></a></li>
                        <li><a id="A2" href="#tabs-2" onclick="Call_Report(this.id);"><b>
                            <%=objLanguage.GetLanguageConversion("Customize_Reports")%></b></a></li>
                    </ul>
                    <div id="tabs-1" class="ui-tabs-hide">
                        <div id="divusrReportsave" style="display: <%=divVisibility%>; margin-left: -11.2px; width: 102%; margin-top: -11px; margin: -12px 0px 0px -12px; border: solid 1px #AAAAAA; -moz-border-radius-topright: 4px; -webkit-border-top-right-radius: 4px; -khtml-border-top-right-radius: 4px; border-top-right-radius: 4px; -moz-border-radius-topleft: 0px; -webkit-border-top-left-radius: 0px; -khtml-border-top-left-radius: 0px; border-top-left-radius: 0px; -moz-border-radius-bottomright: 4px; -webkit-border-bottom-right-radius: 4px; -khtml-border-bottom-right-radius: 4px; border-bottom-right-radius: 4px; border: 1px solid rgb(170, 170, 170);">
                            <UC:Savereport ID="usrReportsave" runat="server" />
                        </div>
                    </div>
                    <div id="tabs-2" class="ui-tabs-hide">
                        <div id="div_showfilters" style="display: <%=imgVisibility%>; margin-left: -11px; float: left; margin-top: -11px; width: 100%;">
                            <div id="Div1" class="report_customizetab">
                                <div id="div_Error" align="center" style="width: 100%; display: none">
                                    <span id="spnError" runat="server" class="spanerrorMsg" style="width: 300px; text-align: center">Please check at least one column to generate report</span>
                                </div>
                                <div class="only5px">
                                </div>
                                <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="950px" Height="100%"
                                    Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                                    <Items>
                                        <telerik:RadPanelItem Text="Select columns to run report" Expanded="true" Font-Bold="true"
                                            CssClass="rounded-ReportTopcorners" Selected="true">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="New">
                                                    <telerik:RadPageView runat="server" ID="RadPageView1">
                                                        <div>
                                                            <table class="ColoumnTable">
                                                                <tr>
                                                                    <td valign="bottom">
                                                                        <div align="left" style="width: 100%; padding: 5px;">
                                                                            <a href="javascript:SelectAll();" id="lnkSelectAll" style="font-size: 0.8em">
                                                                                <%=objLanguage.GetLanguageConversion("Select_All_Columns")%></a>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="left" style="margin-top: -4px">
                                                                            <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                Width="790px" CssClass="chkBoxListInvoice">
                                                                                <asp:ListItem Text="" Value="InvoiceNumber" Selected="true"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="JobNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Company"></asp:ListItem>
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
                                                                                <asp:ListItem Text="" Value="InvoiceTitle"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ConvertedBy"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CreatedDate" Selected="True"></asp:ListItem>

                                                                                <asp:ListItem Text="Total Ex. Tax"  Value="TotalExTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Total Inc. Tax" Value="TotalIncTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Ex. Tax"   Value="ItemExTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Inc. Tax"  Value="ItemIncTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Cart Cost"  Value="CartCost"></asp:ListItem>

                                                                                <asp:ListItem Text="" Value="ConvertedDate"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="InvoiceValue" Selected="True"></asp:ListItem>
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
                                                                                <asp:ListItem Text="" Value="InvoicePaid"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="name"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="SubTotal"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CostExMarkup"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="GrossProfitPrice"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="GrossProfitPercentage"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AccountingCode"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AccountingCodeDescription"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CostCentre"></asp:ListItem>
                                                                                <asp:ListItem Text="Activity Notes" Value="ActivityNotes"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Date" Value="InvoiceDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Due Date" Value="InvoiceDueDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Quantity" Value="ItemQuantity"></asp:ListItem>
                                                                                <asp:ListItem Text="Customer Code" Value="CustomerCode"></asp:ListItem>
                                                                                <asp:ListItem Text="Pack Unit" Value="PackUnit"></asp:ListItem>
                                                                                <asp:ListItem Text="Cost Price(Inc. MarkUp)" Value="CostPrice"></asp:ListItem>
                                                                                <asp:ListItem Text="Supplier Name" Value="SupplierName"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Title" Value="ProductTitle"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Code" Value="ProductCode"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Amount Paid" Value="InvoiceAmountPaid"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Amount Outstanding" Value="InvoiceAmountOutstanding"></asp:ListItem>
                                                                                <asp:ListItem Text="Store Name" Value="StoreName"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Width" Value="ProductWidth"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Height" Value="ProductHeight"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Length" Value="ProductLength"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Weight" Value="ProductWeight"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Dimension" Value="ProductDimension"></asp:ListItem>
                                                                                <asp:ListItem Text="Event Name" Value="EventName"></asp:ListItem>
                                                                                <asp:ListItem Text="Event Code Number" Value="EventCodeNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Sign No." Value="CampaignSignNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Event Venue" Value="EventVenue"></asp:ListItem>
                                                                                <asp:ListItem Text="Quantity" Value="QTYDescription1"></asp:ListItem>
                                                                                <asp:ListItem Text="Contact Job Title 1" Value="ContactJobTitle1"></asp:ListItem>
                                                                                <asp:ListItem Text="Contact Job Title 2" Value="ContactJobTitle2"></asp:ListItem>
                                                                                <asp:ListItem Text="Customer Salesperson" Value="CustomerSalesperson"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="JobContactName"></asp:ListItem>
                                                                                <asp:ListItem Text="Job Name" Value="JobName"></asp:ListItem>
                                                                                <asp:ListItem Text="Ordered For" Value="OrderedFor"></asp:ListItem>
                                                                                <asp:ListItem Text="Type" Value="CustomerType"></asp:ListItem>
                                                                                <asp:ListItem Text="Customer Address" Value="CustomerAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="commissionamount"></asp:ListItem>
                                                                                <asp:ListItem Text="Commission (%)" Value="commissionpercentage"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Taxvalue"></asp:ListItem>
                                                                                <asp:ListItem Text="Payment Mode" Value="PaymentMode"></asp:ListItem>
                                                                                <asp:ListItem Text="Ordered By" Value="OrderedBy"></asp:ListItem>
                                                                                <asp:ListItem Text="Order Number" Value="SystemOrderNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimate Number" Value="EstimateNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="Stock Product" Value="StockProduct"></asp:ListItem>
                                                                                <asp:ListItem Text="Back Order" Value="BackOrder"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Total" Value="InvoiceTotal"></asp:ListItem>
                                                                                <asp:ListItem Text="Total Tax" Value="TotalTax"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Markup" Value="InvoiceMarkup"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Profit Margin (%)" Value="ProfitMarginPercentage"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ProfitMarginValue"></asp:ListItem>
                                                                                <asp:ListItem Text="PO No" Value="PONo"></asp:ListItem>
                                                                                <asp:ListItem Text="Supplier Invoice No" Value="SupplierInvoiceNo"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Type" Value="EstItemType"></asp:ListItem>


                                                                                <asp:ListItem Text="Supplier Invoice Date" Value="SupplierInvoiceDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Supplier Quote No" Value="SupplierQuoteNo"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Status" Value="InvoiceStatus"></asp:ListItem>
                                                                                <asp:ListItem Text="Payment Date" Value="PaymentDate"></asp:ListItem>




                                                                                <asp:ListItem Text="Custom Description 1" Value="CustomDescriptionValue1"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 2" Value="CustomDescriptionValue2"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 3" Value="CustomDescriptionValue3"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 4" Value="CustomDescriptionValue4"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 5" Value="CustomDescriptionValue5"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 6" Value="CustomDescriptionValue6"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 7" Value="CustomDescriptionValue7"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 8" Value="CustomDescriptionValue8"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 9" Value="CustomDescriptionValue9"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Description 10" Value="CustomDescriptionValue10"></asp:ListItem>

                                                                                <asp:ListItem Text="Cost per 1000" Value="Costper1000"></asp:ListItem>
                                                                                <asp:ListItem Text="Sub Total per 1000" Value="SubTotalper1000"></asp:ListItem>
                                                                                    <asp:ListItem Text="Custom Date 1" Value="CustomDate1"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 2" Value="CustomDate2"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 3" Value="CustomDate3"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 4" Value="CustomDate4"></asp:ListItem>
                                                                                <asp:ListItem Text="Custom Date 5" Value="CustomDate5"></asp:ListItem> 

                                                                                <%-- <asp:ListItem Text="Supplier Invoice Date" Value="SupplierInvoiceDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Supplier Quote No" Value="SupplierQuoteNo"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Status" Value="InvoiceStatus"></asp:ListItem>
                                                                                <asp:ListItem Text="Payment Date" Value="PaymentDate"></asp:ListItem>--%>
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div align="left" style="padding-top: 4px; padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 190px; padding: 4px">
                                                                                <%-- <span style="vertical-align:middle">--%>
                                                                                <%=objLanguage.GetLanguageConversion("Show_Contact_Addresses_In")%>
                                                                                <%-- </span>--%>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlContactAddress" runat="server" CssClass="normalText" Width="200px">
                                                                                    <asp:ListItem Text="One Column" Value="0" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="1"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 190px; padding: 4px">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("Show_Delivery_Addresses_In")%>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlDeliveryAddress" runat="server" CssClass="normalText" Width="200px">
                                                                                    <asp:ListItem Text="One Column" Value="0" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="1"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 190px; padding: 4px">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("Show_Invoice_Addresses_In")%>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlInvoiceAddress" runat="server" CssClass="normalText" Width="200px">
                                                                                    <asp:ListItem Text="One Column" Value="0" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="1"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="padding-left: 2px">
                                                                            <div class="bgReportlabel" style="width: 190px; padding: 4px">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("Show_Customer_Addresses_In")%>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlCustomerAddress" runat="server" CssClass="normalText" Width="200px">
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
                                        <telerik:RadPanelItem Text="Sort the records" Font-Bold="true" Expanded="false" CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView2">
                                                        <div>
                                                            <div id="Div2" style="padding: 5px">
                                                                <div id="div3" style="width: 49%;">
                                                                    <div align="left" style="padding-left: 5px; padding-top: 5px">
                                                                        <div class="bgReportlabel" style="width: 190px">
                                                                            <asp:Label ID="Label4" class="normalText" runat="server"><%=objLanguage.GetLanguageConversion("Sort_By")%></asp:Label>
                                                                        </div>
                                                                        <div style="float: left; padding-left: 5px">
                                                                            <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="normalText" Width="200px"
                                                                                Height="20px">
                                                                                <asp:ListItem Value="none">None</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div id="div4" style="width: 49%">
                                                                    <asp:UpdatePanel ID="UpdatePanel4" RenderMode="Inline" runat="server">
                                                                        <ContentTemplate>
                                                                            <div style="padding-left: 5px; padding-top: 2px" align="left">
                                                                                <div class="bgReportlabel" style="width: 190px">
                                                                                    <asp:Label ID="Label5" class="normalText" runat="server"><%=objLanguage.GetLanguageConversion("Direction")%></asp:Label>
                                                                                </div>
                                                                                <div style="float: left; padding-left: 5px">
                                                                                    <asp:DropDownList ID="ddldirection" runat="server" CssClass="normalText" Width="200px"
                                                                                        Height="20px">
                                                                                        <asp:ListItem Value="ASC" Selected="True">Ascending</asp:ListItem>
                                                                                        <asp:ListItem Value="DESC">Descending</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="div5" style="width: 49%">
                                                                    <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                                                                        <ContentTemplate>
                                                                            <div style="padding-left: 5px; padding-top: 2px" align="left">
                                                                                <div class="bgReportlabel" style="width: 190px">
                                                                                    <asp:Label ID="Label6" class="normalText" runat="server"><%=objLanguage.GetLanguageConversion("Report_Type")%></asp:Label>
                                                                                </div>
                                                                                <div style="float: left;">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:RadioButton ID="rdosummary" onclick="javascript:GetSummaryDetails()" runat="server"
                                                                                                    Text='Summary' GroupName="sumordet" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:RadioButton ID="rdodetail" onclick="javascript:GetDetails()" runat="server"
                                                                                                    Text='Detailed' GroupName="sumordet" />
                                                                                            </td>
                                                                                            <td valign="bottom">
                                                                                                <div id="DivSelect" runat="server" style="display: none">
                                                                                                    <a href="javascript:\\" style="font-size: 0.8em" onclick="javascript:SummaryorDetialsSelectnone();">Select <span id="spn_SummaryDetail"></span></a>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div id="divDetails" style="width: 49%">
                                                                    <asp:UpdatePanel ID="UpdatePanel2" RenderMode="Inline" runat="server">
                                                                        <ContentTemplate>
                                                                            <div style="padding-left: 5px; padding-top: 2px" align="left">
                                                                                <div class="bgReportlabel" style="width: 190px">
                                                                                    <asp:Label ID="Label7" class="normalText" runat="server"><%=objLanguage.GetLanguageConversion("Group_The_Records_By")%></asp:Label>
                                                                                </div>
                                                                                <div style="float: left; padding-left: 5px">
                                                                                    <asp:DropDownList ID="ddlsummarydetails" SkinID="onlyDDL" CssClass="normaltext" runat="server"
                                                                                        Width="200px">
                                                                                        <asp:ListItem Value="0" Text="Date"></asp:ListItem>
                                                                                        <asp:ListItem Value="1" Selected="True" Text="&nbsp;&nbsp;&nbsp;Daily"></asp:ListItem>
                                                                                        <asp:ListItem Value="2" Text="&nbsp;&nbsp;&nbsp;Monthly"></asp:ListItem>
                                                                                        <asp:ListItem Value="3" Text="&nbsp;&nbsp;&nbsp;Yearly"></asp:ListItem>
                                                                                        <asp:ListItem Value="4" Text="Customer"></asp:ListItem>
                                                                                        <asp:ListItem Value="5" Text="Accounting Code"></asp:ListItem>
                                                                                        <asp:ListItem Value="6" Text="SalesPerson"></asp:ListItem>
                                                                                        <asp:ListItem Value="7" Text="CustomerSalesperson"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="only5px">
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Report filters" Font-Bold="true" Expanded="false" CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage5" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView5">
                                                        <div>
                                                            <div align="left" style="padding-left: 5px; padding-top: 5px">
                                                                <div align="left" style="padding: 5px">
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Invoice_Range")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left">
                                                                        <asp:DropDownList ID="ddlEstimateRange" runat="server" CssClass="normalText" Width="200px">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div id="divchkEstimate" style="float: left; padding-left: 5px">
                                                                        <asp:CheckBox ID="chkEstimate" runat="server" Text='Show Invoices With No Assigned Value'
                                                                            Checked="true" />
                                                                    </div>
                                                                </div>
                                                                <div align="left" style="padding: 5px">
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Invoice_Status")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left">
                                                                        <telerik:RadListBox ID="lstStatus" runat="server" CheckBoxes="true" Width="200px"
                                                                            Height="100px">
                                                                            <Items>
                                                                            </Items>
                                                                        </telerik:RadListBox>

                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                </div>
                                                                <div class="only5px">
                                                                </div>
                                                                <div align="left" style="padding: 5px">
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Select_Company")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left">
                                                                        <div style="float: left;">
                                                                            <asp:TextBox ID="txtName" SkinID="textPad" runat="server" AutoCompleteType="disabled"
                                                                                Width="200px"></asp:TextBox><%--onkeyup="BindClientName(this.value,event,this);"--%>
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
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Payment_Status")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:DropDownList ID="ddlpaymentStatus" runat="server" Width="200px">
                                                                            <asp:ListItem Text="-- Any --" Value="Any"></asp:ListItem>
                                                                            <asp:ListItem Text="Paid" Value="Yes"></asp:ListItem>
                                                                            <asp:ListItem Text="Not Paid" Value="No"></asp:ListItem>
                                                                            <asp:ListItem Text="Partially Paid" Value="Partiallypaid"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Estimate_Type")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <telerik:RadComboBox ID="ddlEstimateType" runat="server" Width="200px" Style="vertical-align: middle; margin-top: -6px"
                                                                            OnClientDropDownOpened="OnClientDropDownOpenedHandler" EmptyMessage="-- Select --"
                                                                            AllowCustomText="true" CssClass="ddlComboBox">
                                                                            <ItemTemplate>
                                                                                <div style="margin-left: -10px">
                                                                                    <asp:CheckBoxList ID="chkEstType" runat="server">
                                                                                    </asp:CheckBoxList>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <Items>
                                                                                <telerik:RadComboBoxItem Text="" />
                                                                            </Items>
                                                                        </telerik:RadComboBox>
                                                                        <%--  <asp:DropDownList ID="ddlEstimateType" runat="server" Width="100px">
                                                                        <asp:ListItem Text="-- Select --" Selected="True" Value="0"></asp:ListItem>
                                                                    </asp:DropDownList>--%>
                                                                        <%--                                                                        <span class="smallgraytext" style="padding-left: 5px; vertical-align: top">&nbsp;(<%=objLanguage.GetLanguageConversion("Filter_Applicable_for_main_items_only")%>)</span>--%>
                                                                    </div>
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Main_Sub_items")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left; margin-top: 3px">
                                                                        <asp:DropDownList ID="ddlShowSubItems" runat="server" CssClass="reportwidth175" Width="200px">
                                                                            <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="" Value="2"></asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Notes_Type")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:DropDownList ID="ddlNotesType" runat="server" Width="200px" Style="margin-top: 2px">
                                                                            <asp:ListItem Text="-- Select --" Selected="True" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="System" Value="System"></asp:ListItem>
                                                                            <asp:ListItem Text="General" Value="General"></asp:ListItem>
                                                                            <asp:ListItem Text="Error" Value="Error"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <%--Estimator--%>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>Estimator
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:DropDownList ID="ddlEstimator" runat="server" Width="200px" Style="margin-top: 2px">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <%--Sales Person--%>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>Sales Person
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:DropDownList ID="ddlSalesPerson" runat="server" Width="200px" Style="margin-top: 2px">
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                   
                                                                    <%--Customer Sales Person--%>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span>Customer Sales Person
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <div style="float: left;">
                                                                        <asp:DropDownList ID="ddlCustomerSalesPerson" runat="server" Width="200px" Style="margin-top: 2px">
                                                                        </asp:DropDownList>
                                                                    </div>

                                                                    <div runat="server" id="divLocation" visible="false">
                                                                        <div class="bgReportlabel" style="width: 190px">
                                                                            <span>
                                                                                <%--<%=objLanguage.GetLanguageConversion("Estimate_Type")%></span>--%>
                                                                           Select Locations
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="normalText" Width="200px" Style="margin-top: 2px">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 190px">
                                                                            <span>
                                                                                <%=objLanguage.GetLanguageConversion("Free_text")%></span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            <div>
                                                                                <asp:TextBox ID="txtFreetext" runat="server" SkinID="textPad" MaxLength="255" Width="200px"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel" style="width: 190px">
                                                                            <span>
                                                                                <%=objLanguage.GetLanguageConversion("Select_Filelds_to_be_searched")%></span>
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            <div>
                                                                                <asp:CheckBoxList ID="chkfreetext" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                    Width="550px">
                                                                                    <asp:ListItem Text="Invoice Number" Selected="True" Value="InvoiceNumber"></asp:ListItem>
                                                                                    <asp:ListItem Text="Customer Name" Selected="True" Value="CustomerName"></asp:ListItem>
                                                                                    <asp:ListItem Text="Store Name" Selected="True" Value="StoreName"></asp:ListItem>
                                                                                    <asp:ListItem Text="Contact Name" Value="ContactName"></asp:ListItem>
                                                                                    <asp:ListItem Text="Department" Value="Department"></asp:ListItem>
                                                                                    <asp:ListItem Text="Cost Centre" Value="CostCentre"></asp:ListItem>
                                                                                    <asp:ListItem Text="Invoice Title" Selected="True" Value="InvoiceTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="Sales Person" Selected="True" Value="SalesPerson"></asp:ListItem>
                                                                                    <asp:ListItem Text="Referred By" Selected="True" Value="Referredby"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ItemTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ProductTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ProductCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CustomerSalesperson"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="AccountingCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="Payment Type" Value="PaymentType"></asp:ListItem>
                                                                                    <asp:ListItem Text="Description" Value="Description"></asp:ListItem>
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />

                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <style>
                                                                        #divCheck {
                                                                            float: left;
                                                                            position: absolute;
                                                                            display: none;
                                                                            border: solid 1px silver;
                                                                            overflow-x: hidden;
                                                                            overflow-y: scroll;
                                                                            width: 195px;
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
                                                                    </style>
                                                                </div>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                                <div align="left" style="margin-left: -2px; padding: 2px">
                                                                    <div align="left">
                                                                        <%-- <span id="Span56" runat="server" class="smallgraytext">(<%=objLangClass.GetLanguageConversion("Date_Filter_applied_on_Purchase_Order_Craeted_Date")%>
                                                                        )</span>--%>
                                                                    </div>
                                                                    <table style="width: 700px;">
                                                                        <tr>
                                                                            <td style="width: 190px;">
                                                                                <asp:CheckBox ID="chkDateOption" runat="server" Text="Date Options" Font-Bold="true"
                                                                                    onclick="javascript:EnableDateOption();OnCheckShow()" />
                                                                            </td>
                                                                            <td style="width: 160px;">
                                                                                <asp:DropDownList ID="rdlDate" Enabled="false" runat="server" onChange="javascript:GetDropdownBind();"
                                                                                    Width="200px">
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
                                                                                    <asp:ListItem Text="Paid Today" Value="paidtoday"></asp:ListItem>
                                                                                    <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                    <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                    <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="width: 260px;">
                                                                                <span id="spn_daily" style="display: none" runat="server" class="smallgraytext">(26/10/2009)</span>
                                                                                <span id="spn_yest" style="display: none" runat="server" class="smallgraytext">(25/10/2009)</span>
                                                                                <span id="spn_month" runat="server" style="display: none"
                                                                                    class="smallgraytext">(1/10/2009 to 31/10/2009)</span> <span id="spn_quarter"
                                                                                        runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span>
                                                                                <span id="spn_lastque" runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span>
                                                                                <span id="spn_year" runat="server" style="display: none" class="smallgraytext">(2009)</span>
                                                                                <span id="span_halfyear" runat="server" style="display: none" class="smallgraytext">(Oct 2013 - March 2014) </span>
                                                                                <span id="span_paidtoday" style="display: none" runat="server" class="smallgraytext"></span>
                                                                                <span id="spn_lastweek" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>
                                                                                <span id="spn_lastmonth" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                <span id="spn_lastyear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                <span id="spn_rdlDate_annualYear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>

                                                                                <div align="left" id="divjobdate" runat="server" style="display: none">
                                                                                    <asp:TextBox ID="txtFrom" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox><span
                                                                                        class="normalText">&nbsp;<%=objLanguage.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                            ID="txtTo" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox>
                                                                                    <span id="spn_txtFromDate" class="spanerrorMsg" style="display: none; width: 150px">
                                                                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                    </span><span id="spn_txtToDate" class="spanerrorMsg" style="display: none; width: 250px;">
                                                                                        <%=objLanguage.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                    </span><span id="spndateRange" class="spanerrorMsg" style="display: none">
                                                                                        <%=objLanguage.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Aggregate functions" Font-Bold="true" Expanded="false"
                                            CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage3" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView3">
                                                        <div>
                                                            <div align="left" style="padding: 2px;">
                                                                <table cellspacing="0" cellpadding="0" class="chkBottom">
                                                                    <tr>
                                                                        <td valign="bottom">
                                                                            <div align="left" class="invoice_report_linkselect">
                                                                                <span id="spn_lnkSelectAll1" runat="server"><a href="javascript:SelectAllGroupByoption();"
                                                                                    id="lnkSelectAll1" style="font-size: 0.8em;">
                                                                                    <%=objLanguage.GetLanguageConversion("Select_All_Columns")%></a></span>
                                                                            </div>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span id="spn_CostPriceExMarkup" runat="server">&nbsp;<%=objLanguage.GetLanguageConversion("Item_Cost_Price_Exc_Markup_View")%>(<%=objJava.GetCurrencyinRequiredFormate("", true)%>)</span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="ChkClmnsCostPriceExMarkup" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4">
                                                                                <asp:ListItem Value="CostExMarkupTotal" Text=""></asp:ListItem>
                                                                                <asp:ListItem Value="CostExMarkupAvg" Text="Average"></asp:ListItem>
                                                                                <asp:ListItem Value="CostExMarkupMax" Text="Maximum"></asp:ListItem>
                                                                                <asp:ListItem Value="CostExMarkupMin" Text="Minimum"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <span>&nbsp;<%=objLanguage.GetLanguageConversion("Invoice_Value_Exc_Tax")%></span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="chkExcTax" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"
                                                                                Style="margin-left: -4px">
                                                                                <asp:ListItem Value="chkTaxCount" Text="Count"></asp:ListItem>
                                                                                <asp:ListItem Value="chkTaxTotal" Text="" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Value="chkTaxAvg" Text="Average"></asp:ListItem>
                                                                                <asp:ListItem Value="chkTaxMax" Text="Maximum"></asp:ListItem>
                                                                                <asp:ListItem Value="chkTaxMin" Text="Minimum"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="bgReportlabel12">
                                                                                <%--<span>&nbsp;<%=objLanguage.GetLanguageConversion("Invoice_Value")%></span>--%>
                                                                                <span>&nbsp;Invoice Value (Inc. Tax)</span>
                                                                            </div>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="chkColumns1" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"
                                                                                Style="margin-left: -4px">
                                                                                <asp:ListItem Value="EstimateCount" Text="Count"></asp:ListItem>
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
                                                                                <span id="spn_GrossProfit" runat="server">&nbsp;<%=objLanguage.GetLanguageConversion("Gross_Profit")%>(<%=objJava.GetCurrencyinRequiredFormate("",true) %>)</span>
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
                                                                                <span id="Span2" runat="server">&nbsp;<%=objLanguage.GetLanguageConversion("Gross_Profit")%>(%)</span>
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
                                        <telerik:RadPanelItem Text="Save and Run Report" Font-Bold="true" Expanded="true"
                                            CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage6" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView6">
                                                        <div class="FilterJob">
                                                            <div align="left" style="padding: 5px; padding-top: 7px">
                                                                <div align="left" style="width: 100%">
                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                        <span class="HeaderText">
                                                                            <%=objLanguage.GetLanguageConversion("Report_Name")%></span>&nbsp;<span style="vertical-align: middle; color: Red">*</span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
                                                                        &nbsp;
                                                                    </div>
                                                                    <asp:TextBox ID="txtSaveReports" runat="server" SkinID="textPad" MaxLength="200"
                                                                        Width="200px" />
                                                                    <asp:HiddenField ID="hdn_reportID" runat="server" />
                                                                </div>
                                                                <div align="left">
                                                                    <div class="bgReportlabel estbg_heightwidth">
                                                                        <span>
                                                                            <%=objLanguage.GetLanguageConversion("Description")%></span>
                                                                    </div>
                                                                    <div style="float: left; width: 5px">
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
                                <div align="left" style="width: 100%; height: 40px; padding: 5px; margin-left: -5px">
                                    <div style="float: left">
                                        <div id="div_cancel" style="display: block">
                                            <asp:Button ID="btnCancel" runat="server" Text='Cancel' CssClass="button" OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess')"
                                                OnClick="btnCancel_OnClick" />
                                            <%--Width="80px"--%>
                                        </div>
                                        <div id="div_cancelprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <div id="div_btnsaverun" style="display: block">
                                            <asp:Button ID="btnSaveRun" runat="server" Text='Save and Run' CssClass="button"
                                                OnClick="btnSaveRun_OnClick" OnClientClick="javascript:var a=ValidateCaller();if(a) loadingimage(this.id,'div_saverunprocess');return a;" />
                                            <%--width=100px--%>
                                        </div>
                                        <div id="div_saverunprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
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
                                        <div id="div_runreport" style="display: block">
                                            <asp:Button ID="btnRunReport" runat="server" Text='Run Report' CssClass="button"
                                                OnClick="btnRunReport_OnClick" OnClientClick="javascript:var a=Runvalidate();if(a!=false)loadingimage(this.id,'div_runreportprocess');return a;" />
                                        </div>
                                        <%--width=80px--%>
                                        <%--return funcCaller();--%>
                                        <div id="div_runreportprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                                <div class="only10px">
                                </div>
                            </div>
                        </div>
                        <div class="only5px">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            <script type="text/javascript">
                var panelBar;
                var panelBarProductsTab;
                var multiPage;

                function onLoad(sender) {
                    panelBar = sender;
                    panelBarProductsTab = panelBar.get_items().getItem(0);
                    multiPage = panelBar.get_items().getItem(0).findControl("RadMultiPage1");
                }

                function onItemClicked(sender, eventArgs) {
                    if (!panelBarProductsTab.get_selected()) {
                        panelBarProductsTab.expand();
                        panelBarProductsTab.select();
                    }

                    var pageView = multiPage.get_pageViews().getPageView(
                        eventArgs.get_item().get_index());

                    pageView.set_selected(true);
                }



                function stopPropagation(e) {
                    e.cancelBubble = true;

                    if (e.stopPropagation)
                        e.stopPropagation();
                }
            </script>
        </telerik:RadScriptBlock>
        <div align="left" style="width: 100%">
            <div id="div_searchres" style="float: left; padding-left: 5px; width: 99.5%" class="successfulMsg"
                runat="server" visible="false">
                <div style="width: 700px" align="right">
                    <asp:Label ID="lbl_searchres" runat="server" ForeColor="gray"></asp:Label>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div id="divexport">
                <div align="left" id="divtoolbar" runat="server" visible="false" class="DivButtonsHeader report_resultpanel">
                    <table border="0" class="act_width100">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td class="act_floatleft">&nbsp;
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip='Back To Search Option' ImageUrl="~/images/image_EM_b.png"
                                                ID="btnfilter" runat="server" Text="Back to Search Option" OnClick="btnfilter_OnClick"
                                                Visible="false" BackColor="Transparent" OnClientClick="javascript:return showWaitMessage();" />
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip='Export Presentation Format' ImageUrl="~/images/xls-presentation.jpg"
                                                ID="btnExport1" runat="server" Text="Export" OnClick="btnExport_vivid_OnClick"
                                                OnClientClick="javascript:getInnerHtml();" Visible="true" BackColor="Transparent" />
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip='Export Excel Format' ImageUrl="~/images/export-icon1.jpg"
                                                ID="btnNewExport" runat="server" Text="Export" OnClick="btnExport_New_OnClick"
                                                OnClientClick="javascript:getInnerHtml();" Visible="true" BackColor="Transparent" />
                                        </td>
                                        <td nowrap="nowrap">
                                            <UC:Paging ID="usrPaging" runat="server" />
                                        </td>
                                        <td align="left"></td>
                                        <td class="act_floatleft" nowrap="nowrap">
                                            <asp:TextBox ID="txt1" runat="server" Width="40px" Visible="false" onblur="javascript:AllowNumber(this,this.value)"></asp:TextBox>&nbsp;
                                        </td>
                                        <td>
                                            <asp:ImageButton ToolTip="Go To" ImageUrl="~/images/gotopage.gif" ID="btngo" runat="server"
                                                OnClick="btngo_OnClick" Visible="false" BackColor="Transparent" OnClientClick="javascript:return showWaitMessage();" />
                                        </td>
                                        <td align="left"></td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right">
                                <div id="div_Total" runat="server" style="float: right; padding-right: 10px">
                                    <span class="normalText">
                                        <%=objLanguage.GetLanguageConversion("Total_Records")%>:</span><b>
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
                                OnPageSizeChanged="GridEstimate_PageSizeChanged" PageSize="50" EnableAjaxSkinRendering="true" Visible="false" EnableViewState="true">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                            </telerik:RadGrid>
                            <asp:Label ID="lblActivityNotes" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblJobNumber" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblItemTitle" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:PlaceHolder ID="plhdetails" runat="server"></asp:PlaceHolder>
                    </div>
                    <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                        <div id="Div6" class="emptyrecords" align="center">
                            <span class="HeaderText" style="text-align: center">
                                <%=objLanguage.GetLanguageConversion("No_Record_Found")%></span>
                        </div>
                    </asp:Panel>
                    <div class="only10px">
                    </div>
                    <div style="border-bottom: 2px solid #E2E2E2" runat="server" id="div7" visible="false">
                    </div>
                    <div id="divaggregate" visible="false" runat="server" style="width: 400px">
                        <table width="350px" cellpadding="3" cellspacing="0">
                            <tr id="CountHeader" visible="false" runat="server">
                                <td style="width: 200px; border: 1px solid black">
                                    <span style="font-weight: bold;">Total Invoice </span>
                                </td>
                                <td style="border-right: 1px solid black; border-top: 1px solid black; border-bottom: 1px solid black; text-align: right;">
                                    <asp:Label ID="lblinvCount" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div style="height: 25px">
                        </div>
                        <div id="divaggregate1" runat="server">
                            <table width="350px" cellpadding="3" cellspacing="0" border="1px solid black" style="border-left: 0; border-top: 0;">
                                <tr id="AggergateHeader" runat="server" visible="false">
                                    <td style="border-top: 1px solid transparent; border-left: 1px solid transparent">
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">
                                            <%=objLanguage.GetLanguageConversion("Count")%>
                                        </span>
                                    </td>
                                    <td>
                                        <span style="font-weight: bold;">
                                            <%=objLanguage.GetLanguageConversion("Total")%>
                                        </span>
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

                                <tr id="tableCostExMarkup" runat="server" visible="false">
                                    <td style="width: 200px; border-bottom: 0; border-right: 0;">
                                        <span style="font-weight: bold;">Cost Price (Ex. Markup) </span>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblCostExMarkupCount" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: right; border-bottom: 0;">
                                        <asp:Label ID="lblCostExMarkupTotal" runat="server"></asp:Label>
                                    </td>
                                    <td style="text-align: right; border-bottom: 0;" visible="false">
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
                                        <span style="font-weight: bold;">
                                            <%=objLanguage.GetLanguageConversion("Invoice_Value_Exc_Tax")%>
                                        </span>
                                    </td>
                                    <td visible="false">
                                        <asp:Label ID="lblTaxCount" runat="server"></asp:Label>
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
                                        <%--<span style="font-weight: bold;"> <%=objLanguage.GetLanguageConversion("Invoice_Value")%></span>--%>
                                        <span style="font-weight: bold;"> Invoice Value (Inc. Tax)</span>
                                    </td>
                                    <td visible="false">
                                        <%--<asp:Label ID="lblinvCount" runat="server"></asp:Label>--%>
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
                                    <td visible="false">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
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
                                    <td visible="false">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
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
                        <div style="height: 25px">
                        </div>
                    </div>
                </div>
            </div>
            <%--<asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                <div id="padding" class="emptyrecords" align="center">
                    <span class="HeaderText" style="text-align: center">
                        <%=objLanguage.GetLanguageConversion("No_Record_Found")%></span>
                </div>
            </asp:Panel>--%>
            <div class="only10px">
            </div>
            <div style="border-bottom: 2px solid #E2E2E2" runat="server" id="divAggl" visible="false">
            </div>
            <div class="only10px">
            </div>
        </div>
        <div class="onlyEmpty">
        </div>
        <asp:Button ID="btnsavemultiple" runat="server" OnClick="btnsavemultiple_onclick"
            Style="visibility: hidden"></asp:Button>
        <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
        <asp:HiddenField ID="hdn_ReportIDs" runat="server" Value="" />

        <asp:HiddenField ID="hdnInnerHtml" runat="server" />
        <asp:HiddenField ID="HdnSortBy" runat="server" Value="InvoiceNumber" />
        <asp:HiddenField ID="HdnStaus" runat="server" />
        <script>
            var RB1 = document.getElementById("<%=rdlDate.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var chkDateOption = document.getElementById("<%=chkDateOption.ClientID%>");
            var txtFromDate = document.getElementById("<%=txtFrom.ClientID %>");
            var txtToDate = document.getElementById("<%=txtTo.ClientID %>");
            var CHK1 = document.getElementById("<%=chkColumns.ClientID%>");
            var chk = CHK1.getElementsByTagName("input");
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

            //new added by ayesha for saving reports
            var txtSaveReports = document.getElementById("<%=txtSaveReports.ClientID %>");
            var div_showfilters = document.getElementById("div_showfilters");
            var divusrReportsave = document.getElementById("divusrReportsave");


            function GetSummaryDetails() {
                document.getElementById("divDetails").style.display = "block";
                document.getElementById("spn_SummaryDetail").innerHTML = 'None';
                var rdosummary = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary");
                if (rdosummary.checked == true) {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "block";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "none";
                }
                GetDropdownBind();
            }
            function GetDetails() {
                document.getElementById("divDetails").style.display = "block";
                document.getElementById("spn_SummaryDetail").innerHTML = 'None';
                var rdodetail = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdodetail");
                if (rdodetail.checked == true) {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "block";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "none";
                }
                //GetSummaryDetails();
                GetDropdownBindonBack();
                GetDropdownBind();
                EnableDateOption();
            }
            function SummaryorDetialsSelectnone() {
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdodetail").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary").checked = false;
                GetDetails();
                GetSummaryDetails();
            }


            function Call_Report(liID) {
                if (document.getElementById(liID) != null) { // IE, on 23.09.2011
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
            function GetSelect() {
                var x = 0, y = 0;
                for (var i = 0; i < chk.length; i++) {
                    if (chk[i].checked == true) {
                        x++;
                    }
                }

                if (x == chk.length) {
                    lnkSelectAll.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None")%>';
                }
                else {
                    lnkSelectAll.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns")%>';
                }

                for (var i = 0; i < chk1.length; i++) {
                    if (chk1[i].checked == true) {
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

                if (y == (chk1.length + chknet.length + chknetPercentage.length)) {
                    document.getElementById("lnkSelectAll1").innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None")%>';
                }
                else {
                    document.getElementById("lnkSelectAll1").innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns")%>';
                }
                GetDetails();
                GetSummaryDetails();
                GetDropdownBindonBack();
                GetDropdownBind();
                EnableDateOption();

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

                var invno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (invno.checked == false) {
                    alert('Please check Invoice number to generate report');
                    return false;
                }
            //                var invval = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_17');
            //                if (invval.checked == false) {
                //                    alert('<%=objLanguage.GetLanguageConversion("Please_Check_InvoiceValue_To_Generate_Report")%>');
                //                    return false;
                //                }

                if (txtSaveReports.value == '') {
                    alert('<%=objLanguage.GetLanguageConversion("Please_Enter_Report_Name")%>');
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
            function SelectAll() {
                var Count = 0;

                var dropDownListRef = document.getElementById('<%= ddlSortBy.ClientID %>');
                var HdnStaus = document.getElementById('<%= HdnStaus.ClientID %>');
                var StausValue = HdnStaus.value.split('~');
                for (j = dropDownListRef.length - 1; j >= 1; j--) {
                    dropDownListRef.remove(j);
                }
                //if (trim12(lnkSelectAll.innerHTML) == "Select All") {
                if (trim12(lnkSelectAll.innerHTML) == trim12('<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>')) {
                    for (var i = 0; i < chk.length; i++) {

                        var option1 = document.createElement("option");
                        chk[i].checked = true;
                        //lnkSelectAll.innerHTML = "Select None";
                        lnkSelectAll.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None") %>';

                        if (i == 0) {
                            option1.text = "Invoice Number";
                            option1.value = "InvoiceNumber";
                        }
                        else if (i == 1) {
                            option1.text = "Company";
                            option1.value = "Company";
                        }
                        else if (i == 12) {
                            option1.text = "Invoice Title";
                            option1.value = "InvoiceTitle";
                        }
                        else if (i == 11) {
                            option1.text = "Invoice Salesperson";
                            option1.value = "SalesPerson";
                        }
                        else if (i == 13) {
                            //option1.text = "Progresses By";
                            option1.text = "Progress By";
                            option1.value = "ConvertedBy";
                        }
                        else if (i == 14) {
                            //option1.text = "Created Date";
                            option1.text = "Created On";
                            option1.value = "CreatedDate";
                        }
                        else if (i == 19) {
                            option1.text = StausValue[0];
                            option1.value = StausValue[1];
                        }
                        else if (i == 16) {
                            option1.text = "Progressed On";
                            option1.value = "ConvertedDate";
                        }
                        else if (i == 17) {
                            option1.text = "Invoice Value";
                            option1.value = "InvoiceValue";
                        }
                        else if (i == 30) {
                            option1.text = "Customer Order Number";
                            option1.value = "OrderNumber";
                        }
                        else if (i == 31) {
                            option1.text = "Invoice Paid";
                            option1.value = "InvoicePaid";
                        }
                        else if (i == 32) {
                            option1.text = "Referred By";
                            option1.value = "name";
                        }
                        else if (i == 41) {
                            option1.text = "Invoice Due Date";
                            option1.value = "InvoiceDueDate";
                        }
                        else if (i == 65) {
                            option1.text = "Customer Salesperson";
                            option1.value = "CustomerSalesperson";
                        }
                        if (i == 0 || i == 1 || i == 12 || i == 11 || i == 13 || i == 14 || i == 19 || i == 16 || i == 17 || i == 30 || i == 31 || i == 32 || i == 41 || i == 65) {
                            if (columnsList[i].checked) {
                                dropDownListRef.options.add(option1);
                            }
                        }
                    }
                    dropDownListRef.value = "InvoiceNumber";
                    HdnSortBy.value = "InvoiceNumber";

                }
                else {
                    for (var i = 0; i < chk.length; i++) {
                        chk[i].checked = false;
                        lnkSelectAll.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>';
                    }
                }
            }
            function EnableDateOption() {
                var rdlDateArray = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                if (chkDateOption.checked) {
                    for (var i = 0; i < rdlDateArray.length; i++) {
                        rdlDateArray.disabled = false;
                    }
                }
                else {
                    for (var i = 0; i < rdlDateArray.length; i++) {
                        rdlDateArray.disabled = true;
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
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
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_span_paidtoday");

                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth");
                var spn_12 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear");
                var spn_rdlDate_annualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_rdlDate_annualYear");

                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;
                ddlJobCreated.disabled = false;
                var ddlSortBy = document.getElementById("<%=ddlSortBy.ClientID%>");
                ddlSortBy.value = HdnSortBy.value;
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
                    spn_rdlDate_annualYear.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
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
                        spn_12.style.display = "none";
                        spn_rdlDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                    else if (ddlvalue == "paidtoday") {
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
                        spn_9.style.display = "none";
                        spn_10.style.display = "block";
                        spn_11.style.display = "none";
                        spn_12.style.display = "none";
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
                        spn_10.style.display = "none";
                        spn_11.style.display = "block";
                        spn_12.style.display = "none";
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
                        spn_11.style.display = "none";
                        spn_12.style.display = "block";
                        spn_rdlDate_annualYear.style.display = "none";
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
            }

            function EnableDateOptionOnBack() {
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
                var invno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (invno.checked == false) {
                    alert('Please check Invoice number to generate report');
                    return false;
                }
                var invval = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_17');
                if (invval.checked == false) {
                    alert('Please check Invoice value to generate report');
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
                    //CheckGrid();
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
                var rdlDateArray = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                if (chkDateOption.checked) {
                    for (var i = 0; i < rdlDateArray.length; i++) {
                        rdlDateArray[i].disabled = false;
                    }
                }
                else {
                    for (var i = 0; i < rdlDateArray.length; i++) {
                        rdlDateArray[i].disabled = false;
                        //rdlDateArray[i].disabled = true;
                        //rdlDateArray[i].style.color = "red";
                    }
                }
                // To disable Date rdl by default Ends //
            </script>
        </asp:Panel>
        <asp:Panel ID="pnlGridview" runat="server" Visible="false">
            <script type="text/javascript">
                var GridItemTitle = document.getElementById("<%=GridEstReport.ClientID %>");
                function CallOverflow() {
                    if (document.getElementById(GridItemTitle) != null) {
                        SetGridOverflow(GridItemTitle);
                    }
                }
                CallOverflow();

            </script>
        </asp:Panel>
        <script>


            var CHK11 = document.getElementById("<%=chkColumns1.ClientID%>");
            var chk1 = CHK11.getElementsByTagName("input");
            var CHKCost = document.getElementById("<%=ChkClmnsCostPriceExMarkup.ClientID%>");
            var chkCostItem = CHKCost.getElementsByTagName("input");
            var chkColumns1 = getName("<%=chkColumns1.ClientID %>");
            var Check_SpecialPrivilege1 = '<%=Check_SpecialPrivilege %>';
            var lnkSelectAll1 = document.getElementById("lnkSelectAll1");
            var chkExcTax = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i3_chkExcTax");
            var chkTax = chkExcTax.getElementsByTagName("input");
            var chkCost = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i3_ChkClmnsCostPriceExMarkup");
            var chkCostExMarkup = chkCost.getElementsByTagName("input");
            function SelectAllGroupByoption() {
                var Count = 0;
                if (trim12(lnkSelectAll1.innerHTML) == trim12('<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>')) {

                    for (var i = 0; i < chkCostExMarkup.length; i++) {
                        chkCostExMarkup[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None") %>';
                    }

                    for (var i = 0; i < chkTax.length; i++) {
                        chkTax[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None") %>';
                    }

                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None") %>';
                    }

                    for (var i = 0; i < chkCostItem.length; i++) {
                        chkCostItem[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None") %>';
                    }

                    if (Check_SpecialPrivilege1 == "False") {
                        for (var i = 0; i < chknet.length; i++) {
                            chknet[i].checked = true;
                            lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None") %>';
                        }
                        for (var i = 0; i < chknetPercentage.length; i++) {
                            chknetPercentage[i].checked = true;
                            lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_None") %>';
                        }
                    }
                }
                else {
                    for (var i = 0; i < chkCostExMarkup.length; i++) {
                        chkCostExMarkup[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>';
                    }

                    for (var i = 0; i < chkTax.length; i++) {
                        chkTax[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>';
                    }
                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>';
                    }
                    for (var i = 0; i < chkCostItem.length; i++) {
                        chkCostItem[i].checked = false;
                        lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>';
                    }
                    if (Check_SpecialPrivilege1 == "False") {
                        for (var i = 0; i < chknet.length; i++) {
                            chknet[i].checked = false;
                            lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>';
                        }
                        for (var i = 0; i < chknetPercentage.length; i++) {
                            chknetPercentage[i].checked = false;
                            lnkSelectAll1.innerHTML = '<%=objLanguage.GetLanguageConversion("Select_All_Columns") %>';
                        }
                    }
                }
            }

            function getInnerHtml() {
                var element = document.getElementById("divexport1");
                document.getElementById('<%=hdnInnerHtml.ClientID%>').value = element.innerHTML;
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
        <asp:Panel ID="pnlSavedReports" runat="server" Visible="false">
            <script type="text/javascript">
                Call_Report('spn_1');
            </script>
        </asp:Panel>
        <asp:Panel ID="pnlReports" runat="server" Visible="false">
            <script type="text/javascript">

                Call_Report('spn_2');

            </script>
        </asp:Panel>
        <script language="javascript">
            function openExportPDF(CustomerName) {

                var URL = "../pdf_generate1.aspx?page=invoice&EstID=-1&key=" + CustomerName + "";
                window.open(URL);

            }
        </script>
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
                    //if (columnsList[0].checked) {
                    //    HdnSortBy.value = "InvoiceNumber";
                    //}
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
                    option1.text = "Invoice Number";
                    option1.value = "InvoiceNumber";
                }
                else if (i == 2) {
                    option1.text = "Company";
                    option1.value = "Company";
                }
                else if (i == 13) {
                    option1.text = "Invoice Title";
                    option1.value = "InvoiceTitle";
                }
                else if (i == 12) {
                    option1.text = "Invoice Salesperson";
                    option1.value = "SalesPerson";
                }
                else if (i == 14) {
                    //option1.text = "Progresses By";
                    option1.text = "Progress By";
                    option1.value = "ConvertedBy";
                }
                else if (i == 15) {
                    //option1.text = "Created Date";
                    option1.text = "CreatedOn";
                    option1.value = "CreatedDate";
                }
                else if (i == 19) {
                    option1.text = StausValue[0];
                    option1.value = StausValue[1];
                }
                else if (i == 16) {
                    option1.text = "Progressed On";
                    option1.value = "ConvertedDate";
                }
                else if (i == 17) {
                    option1.text = "Invoice Value";
                    option1.value = "InvoiceValue";
                }
                else if (i == 31) {
                    option1.text = "Customer Order Number";
                    option1.value = "OrderNumber";
                }
                else if (i == 32) {
                    option1.text = "Invoice Paid";
                    option1.value = "InvoicePaid";
                }
                else if (i == 33) {
                    option1.text = "Referred By";
                    option1.value = "name";
                }
                else if (i == 42) {
                    option1.text = "Invoice Due Date";
                    option1.value = "InvoiceDueDate";
                }
                else if (i == 65) {
                    option1.text = "Customer Salesperson";
                    option1.value = "CustomerSalesperson";
                }
                if (i == 0 || i == 2 || i == 13 || i == 12 || i == 14 || i == 15 || i == 16 || i == 17 || i == 19 || i == 31 || i == 32 || i == 33 || i == 42 || i == 65) {
                    if (columnsList[i].checked) {
                        dropDownListRef.options.add(option1);
                    }
                }
                dropDownListRef.value = "InvoiceNumber";
                //HdnSortBy.value = "InvoiceNumber";
            }

            function ddlsortByOnchange() {
                var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');
                var ddlSortBy = document.getElementById('<%= ddlSortBy.ClientID %>');
                HdnSortBy.value = ddlSortBy.options[ddlSortBy.selectedIndex].value;
            }

            function GetDropdownBindonBack() {
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
                        EnableDateOption();
                    }
                }
            }


            //======================================
            //====Created On 06-09-2012== By Pradeep
            function OnEditReport(SelectedValue) {
                var dropDownListRef = document.getElementById('<%= ddlSortBy.ClientID %>');
                var rdosummary = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary");
                var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');

                document.getElementById("divDetails").style.display = "block";
                document.getElementById("spn_SummaryDetail").innerHTML = 'None';
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
                GetDropdownBind();
                EnableDateOption();
            }

            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        </script>
        <script>


            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        </script>
        <script>
            function Runvalidate() {
                var invno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (invno.checked == false) {
                    alert('<%=objLanguage.GetLanguageConversion("Please_Check_InvoiceNumber_To_Generate_Report")%>');
                    return false;
                }
            }
        </script>
    </div>
</asp:Content>

