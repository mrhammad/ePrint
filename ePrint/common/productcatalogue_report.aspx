<%@ page title="" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true"  CodeBehind="productcatalogue_report.aspx.cs" Inherits="ePrint.common.productcatalogue_report" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/pagingreport.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Savereport" Src="~/usercontrol/Reports.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
        rel="stylesheet" />
    <div id="Div1" style="display: block;">
    </div>
    <div id="div_Load" class="loading_new">
        <UC:Loading ID="ucLoading" runat="server" />
    </div>
    <script type="text/javascript">

        var div_Load = document.getElementById("div_Load");
        document.getElementById("div_Load").style.display = "block";
    </script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.tabs.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
    <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
    <div id="di`v_mask">
    </div>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" SkinID="windows7" />
    <div id="ds00" style="display: block;">
    </div>
    <script type="text/javascript">
        document.getElementById("ds00").style.width = (window.screen.availWidth * 2) + "px";
        document.getElementById("ds00").style.height = (window.screen.availHeight * 5) + "px";
        document.getElementById("ds00").style.display = "block";
    </script>
    <script>
        var CompanyID = "<%=CompanyID %>";
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.customHeaderItem input[type=checkbox], .customHeaderItem label').click(function (event) {
                event.stopPropagation();
            });
        });
    </script>
    <style type="text/css">
        #ctl00_ContentPlaceHolder1_GridProduct_ctl00 thead tr
        {
            white-space: nowrap;
        }
    </style>
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
    <script type="text/javascript">
        function OnClientDropDownOpenedHandler(sender, eventArgs) {

            var comboBox = $find("<%=ddlCategory.ClientID %>");
            for (var i = 0; i < comboBox.get_items().get_count(); i++) {
                var item = comboBox.get_items().getItem(i);
                var checkbox = $telerik.findElement(item.get_element(), "chkEstType");

            }
        }


        function getSelectedItem(listvalue, i, id, listItem) {

            var dropdownlist = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i4_ddlEstimateType_Input");
            var comboBox = $find("<%=ddlCategory.ClientID %>");
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
    <style type="text/css">
        #test-1
        {
            background-image: none;
            font-weight: bolder;
        }
        .rpItem
        {
            border: 1px solid transparent !important;
        }
        .radpanelbar_default .rpout
        {
            border-bottom-width: 1px;
            border-bottom: 1px solid transparent;
        }
        .RadPanelBar_Default div.rpHeaderTemplate, .RadPanelBar_Default a.rpLink
        {
            background-image: none;
            border: 1px solid #6C6C6C;
            background-color: #F2F2F2;
        }
        .RadPanelBar .rpFocused .rpOut, .RadPanelBar a.rpLink:hover .rpOut, .RadPanelBar .rpSelected .rpOut, .RadPanelBar a.rpSelected:hover .rpOut
        {
            border-top-width: 0px;
            background-color: #C1C1C1;
            border-left-width: 0px;
            border-right-width: 0px;
            border-radius: 4px;
            -webkit-border-radius: 4px;
            -khtml-border-radius: 4px;
        }
        
        .ddlComboBox .rcbInputCell .rcbEmptyMessage
        {
            color: Black !important;
            font-style: normal !important;
            font-family: Verdana,Arial,sans-serif !important;
            font-size: 1em !important;
        }
        
        
        .ddlComboBox .rcbArrowCell a
        {
            background-image: url('../images/dropdown_arrow.png') !important;
            height: 18px !important;
            width: 16px !important;
        }
        
        .ddlComboBox .rcbArrowCellRight
        {
            background-image: none;
        }
        
        .ddlComboBox .rcbInputCell .rcbInput
        {
            border: 1px solid #BFBFBF;
            margin-left: -1px;
            width: 243px;
            height: 18px;
        }
        
        .ddlComboBox .rcbInputCellLeft
        {
            background-image: none;
        }
        
        .chkBoxListPurchase td
        {
            width: 10%;
        }
    </style>
    <style>
        #divCheck
        {
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
        #div_list
        {
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
        .divpad
        {
            padding: 2px;
        }
    </style>
     <div id="divBackGroundNew" style="display: none;">
    </div>
    <div id="div_option" runat="server" style="width: 100%">
        <div id="div_header" class="navigatorpanel" runat="server">
        </div>
        <div id="divtab" runat="server" style="width: 100%;">
            <div style="display: none" id="padding">
                <ul>
                    <li id="li_Save" style="cursor: pointer; float: left; clear: right; display: block;">
                        <div id="div_SR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px;
                            float: left; line-height: 20px; margin-right: 2px">
                            <b><span id="spn_1" onclick="Call_Report(this.id);">Saved Reports </span></b>
                        </div>
                    </li>
                    <li id="li_Customize" style="cursor: pointer; float: left; clear: right; display: block;">
                        <div id="div_CR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px;
                            float: left; line-height: 20px; margin-right: 2px">
                            <b><span id="spn_2" onclick="Call_Report(this.id);">Customize Reports</span></b>
                        </div>
                    </li>
                </ul>
                <div style="clear: both;">
                </div>
            </div>
            <div id="tabs" class="ui-tabs" style="width: 98%; border: solid 0px red; visibility: hidden;
                padding-top: 2px">
                <ul id="test-1" style="list-style: none; height: auto; width: 97.4%; background-color: #FFFFFF;
                    margin-left: 5px; border-left: 1px solid transparent; border-right: 1px solid transparent;
                    border-top: 1px solid transparent; border-radius: 0px; border-bottom: 1px solid transparent">
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
                    <div class="TelerikPaneDiv" id="div_showfilters" runat="server" style="width: 100%">
                        <div id="Div2" class="report_customizetab">
                            <div id="div_Error" align="center" style="width: 100%; display: none">
                                <span id="spnError" runat="server" class="spanerrorMsg" style="width: 300px; text-align: center">
                                    <%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Column_To_Generate_Report")%></span></div>
                            <div class="only5px">
                            </div>
                            <div align="left" style="width: 100%">
                                <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="950px" Height="100%"
                                    Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                                    <Items>
                                        <telerik:RadPanelItem Text="Select columns to run report" Expanded="true" Font-Bold="true"
                                            CssClass="rounded-ReportTopcorners" Selected="true">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView2">
                                                        <div class="ColoumnDiv">
                                                            <table>
                                                                <td valign="bottom">
                                                                    <div align="left" style="width: 100%; padding: 5px;">
                                                                        <a href="javascript:SelectAll();" id="lnkSelectAll" style="font-size: 0.8em;">
                                                                            <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                                                    </div>
                                                                </td>
                                                                <tr>
                                                                    <td>
                                                                        <div align="left" style="margin-top: -4px">
                                                                            <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"
                                                                                Width="950px" CssClass="chkBoxListPurchase">
                                                                                <asp:ListItem Value="ItemTitle" Selected="true" Enabled="false"></asp:ListItem>
                                                                                <asp:ListItem Text="Category Name" Value="CategoryName" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="Item Code" Value="ItemCode" Selected="true"></asp:ListItem>
                                                                                <asp:ListItem Text="Customer Code" Value="CustomerCode" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="Product Type" Value="IsEditableProduct"></asp:ListItem>
                                                                                <asp:ListItem Text="Ownership" Value="OwnerShip"></asp:ListItem>
                                                                                <asp:ListItem Text="Allocation" Value="Allocation"></asp:ListItem>
                                                                                <asp:ListItem Text="Public Accounts" Value="PublicAccount"></asp:ListItem>
                                                                                <asp:ListItem Value="ItemDescription" Selected="true"></asp:ListItem>
                                                                                <asp:ListItem Value="ItemArtwork"></asp:ListItem>
                                                                                <asp:ListItem Value="ItemColour" Selected="true"></asp:ListItem>
                                                                                <asp:ListItem Value="ItemSize"></asp:ListItem>
                                                                                <asp:ListItem Value="Material"></asp:ListItem>
                                                                                <asp:ListItem Selected="true" Value="Delivery"></asp:ListItem>
                                                                                <asp:ListItem Value="Finishing"></asp:ListItem>
                                                                                <asp:ListItem Value="Proofs"></asp:ListItem>
                                                                                <asp:ListItem Value="ItemPacking"></asp:ListItem>
                                                                                <asp:ListItem Value="ItemNotes"></asp:ListItem>

                                                                                <asp:ListItem Value="[Terms/Instructions] "></asp:ListItem>
                                                                                <asp:ListItem Text="Pricing type" Value="MatrixType"></asp:ListItem>
                                                                                <asp:ListItem Text="Start Qty" Value="fromquantity"></asp:ListItem>
                                                                                <asp:ListItem Text="End Qty" Value="toquantity"></asp:ListItem>
                                                                                <asp:ListItem Text="Cost" Value="price"></asp:ListItem>
                                                                                <asp:ListItem Text="Mark(%)" Value="MarkUpPercentage"></asp:ListItem>
                                                                                <asp:ListItem Text="Mark Value" Value="MarkUpValue"></asp:ListItem>
                                                                                <asp:ListItem Text="Selling Price" Value="SellingPrice"></asp:ListItem>
                                                                                <asp:ListItem Text="Weight" Value="Weight"></asp:ListItem>
                                                                                <asp:ListItem Text="Width" Value="Width"></asp:ListItem>
                                                                                <asp:ListItem Text="Height" Value="Height"></asp:ListItem>
                                                                                <asp:ListItem Text="Length" Value="Length"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty On Hand" Value="QtyInHand"></asp:ListItem>
                                                                                <asp:ListItem Text="Allocated Qty" Value="AllocatedQty"></asp:ListItem>
                                                                                <asp:ListItem Text="Available Qty" Value="AvailableQty"></asp:ListItem>
                                                                                <asp:ListItem Text="Re-Order Qty" Value="ReOrderQuantity"></asp:ListItem>
                                                                                <asp:ListItem Text="Re-order Alert Level" Value="ReorderAlertLevel"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Sold Week to Date" Value="QtySoldWeekToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Sold Month to Date" Value="QtySoldMonthToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Sold Last Quarter to Date" Value="QtySoldQuarterToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="QTY Calendar Year Sold to Date" Value="QtySoldYearToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="QTY Financial Year Sold to Date" Value="QtySoldFinancialYearToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Sold Till Date" Value="QtySoldTillDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Draw Stock From" Value="DrawStockFrom"></asp:ListItem>
                                                                                <asp:ListItem Value="SalesTaxRate" Text="Sales Tax Rate"></asp:ListItem>
                                                                                <asp:ListItem Value="DateLastReplenished" Text="Date Last Replenished"></asp:ListItem>
                                                                               <%-- <asp:ListItem Value="CustomDescription1" Text="Custom Description 1"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription2" Text="Custom Description 2"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription3" Text="Custom Description 3"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription4" Text="Custom Description 4"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription5" Text="Custom Description 5"></asp:ListItem>--%>
                                                                                <asp:ListItem Text="Outwork Production Qty" Value="OutworkProductionQty"></asp:ListItem>
                                                                                <asp:ListItem Text="Stock Cost" Value="StockCost"></asp:ListItem> 
                                                                                <asp:ListItem Text="Supplier Name" Value="SupplierName"></asp:ListItem> 
                                                                              <%--  <asp:ListItem Value="CustomField2"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField3"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField4"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField5"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField6"></asp:ListItem> --%>   
                                                                                <asp:ListItem Text="Qty Added Week to Date" Value="QtyAddedWeekToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Added Month to Date" Value="QtyAddedMonthToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Added Last Quarter to Date" Value="QtyAddedQuarterToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="QTY Added Calendar Year to Date" Value="QtyAddedYearToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="QTY Added Financial Year to Date" Value="QtyAddedFinancialYearToDate"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Added Till Date" Value="QtyAddedTillDate"></asp:ListItem>

                                                                                <asp:ListItem Value="CustomDescription1" Text="Custom Description 1"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription2" Text="Custom Description 2"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription3" Text="Custom Description 3"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription4" Text="Custom Description 4"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription5" Text="Custom Description 5"></asp:ListItem>

                                                                                <asp:ListItem Value="CustomDescription6" Text="Custom Description 6"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription7" Text="Custom Description 7"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription8" Text="Custom Description 8"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription9" Text="Custom Description 9"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomDescription10" Text="Custom Description 10"></asp:ListItem>
                                                                                <asp:ListItem Value="LocationQty" Text="Location Qty"></asp:ListItem>


                                                                                <asp:ListItem Value="CustomField2"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField3"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField4"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField5"></asp:ListItem>
                                                                                <asp:ListItem Value="CustomField6"></asp:ListItem> 
                                                                                <asp:ListItem Value="CreateDate" Text="Date Created"></asp:ListItem>
                                                                                <asp:ListItem Value="ModifiedDate" Text="Date Modified"></asp:ListItem>
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
                                        <telerik:RadPanelItem Text="Sort the records" Font-Bold="true" CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="view2">
                                                        <div id="Div3" class="JobReport">
                                                            <div id="div4" style="width: 49%; padding-top: 5px; padding-left: 5px;">
                                                                <div align="left">
                                                                    <div class="bgReportlabel" style="width: 180px">
                                                                        <asp:Label ID="Label4" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Sort_By")%></asp:Label>
                                                                    </div>
                                                                    <div class="box" style="float: left; padding-left: 5px;">
                                                                        <asp:DropDownList ID="ddlEstimateRange" runat="server" CssClass="normalText" Width="260px"
                                                                            Height="20px">
                                                                            <asp:ListItem Value="ItemTitle">Item Title</asp:ListItem>
                                                                            <asp:ListItem Value="CategoryName">Category Name</asp:ListItem>
                                                                            <asp:ListItem Value="CustomerName">Customer Name</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                                <div class="onlyEmpty">
                                                                </div>
                                                            </div>
                                                            <div id="div6" style="width: 49%; padding-left: 5px;">
                                                                <asp:UpdatePanel ID="UpdatePanel4" RenderMode="Inline" runat="server">
                                                                    <ContentTemplate>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 180px">
                                                                                <asp:Label ID="Label5" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Direction")%></asp:Label>
                                                                            </div>
                                                                            <div class="box" style="float: left; padding-left: 5px">
                                                                                <asp:DropDownList ID="ddldirection" runat="server" CssClass="normalText" Width="260px"
                                                                                    Height="20px">
                                                                                    <asp:ListItem Value="ASC">Ascending</asp:ListItem>
                                                                                    <asp:ListItem Value="DESC">Descending</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <div class="only5px">
                                                            </div>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Report filters" Font-Bold="true" Expanded="false" CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="rad2" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView1">
                                                        <div class="ColoumnDiv1">
                                                            <div align="left" style="padding-top: 4px">
                                                                <div align="left" style="padding: 5px">
                                                                    <div align="left" style="width: 100%">
                                                                        <div class="bgReportlabelProdrpt">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Free_Text")%></span></div>
                                                                        <div style="float: left; padding-left: 5px;">
                                                                            <asp:TextBox ID="txtFreetext" Width="260px" runat="server" SkinID="textPad" MaxLength="255"></asp:TextBox>
                                                                            <div>
                                                                                <span class="grayhelptext">(<%=objLangClass.GetLanguageConversion("Text_will_be_searched_on")%>)
                                                                                </span>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div id="div_category" align="left">
                                                                        <div align="left" style="width: 100%;">
                                                                            <div class="bgReportlabel" style="width: 180px">
                                                                                <asp:Label ID="Label1" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Category")%> </asp:Label>
                                                                            </div>
                                                                            <div class="box" style="float: left; padding-left: 5px;">
                                                                                <telerik:RadComboBox ID="ddlCategory" runat="server" Width="260px" Style="vertical-align: middle;"
                                                                                    OnClientDropDownOpened="OnClientDropDownOpenedHandler" EmptyMessage="-- Select --"
                                                                                    AllowCustomText="true" CssClass="ddlComboBox">
                                                                                    <ItemTemplate>
                                                                                        <div style="margin-left: -10px; height: 100px;">
                                                                                            <asp:CheckBoxList ID="chkEstType" runat="server">
                                                                                            </asp:CheckBoxList>
                                                                                        </div>
                                                                                    </ItemTemplate>
                                                                                    <Items>
                                                                                        <telerik:RadComboBoxItem Text="" />
                                                                                    </Items>
                                                                                </telerik:RadComboBox>
                                                                                <%-- <asp:DropDownList ID="ddlCategory" runat="server" CssClass="normalText" Width="195px"
                                                                                Height="20px">
                                                                            </asp:DropDownList> --%>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left" style="width: 100%;">
                                                                        <div class="bgReportlabel" style="width: 180px;">
                                                                            <asp:Label ID="Label6" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Ownership")%> </asp:Label>
                                                                        </div>
                                                                        <div style="float: left">
                                                                            <div class="box" style="float: left; padding-left: 5px;">
                                                                                <asp:TextBox ID="txtName" Width="260px" SkinID="textPad" runat="server" AutoCompleteType="disabled"></asp:TextBox><%--onkeyup="BindClientName(this.value,event,this);"--%>
                                                                                <div class="onlyEmpty">
                                                                                </div>
                                                                                <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                                                                                </div>
                                                                            </div>
                                                                            <div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none">
                                                                                <img id="img1" src="<%=strImagepath %>down01.gif" onclick="BindClientName(this.value,event,this);"
                                                                                    style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                                                                            </div>
                                                                        </div>
                                                                        <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                                                                    </div>
                                                                    <div id="div7" align="left">
                                                                        <div align="left" style="width: 100%;">
                                                                            <div class="bgReportlabel" style="width: 180px">
                                                                                <asp:Label ID="Label7" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Product_TypeCatalague")%> </asp:Label>
                                                                            </div>
                                                                            <div class="box" style="float: left;">
                                                                                <asp:CheckBoxList ID="chkProductType" runat="server" RepeatDirection="Horizontal"
                                                                                    RepeatColumns="3">
                                                                                    <asp:ListItem Value="noneditable" Text="Non Editable" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Value="stock" Text="Stock" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Value="editable" Text="Editable" Selected="True"></asp:ListItem>
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div id="rdlSpecificlabel" runat="server" align="left" style="width: 100%">
                                                                        <div class="bgReportlabel" style="width: 180px;">
                                                                            <asp:Label ID="Label3" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Itmes_Allocated")%></asp:Label>
                                                                        </div>
                                                                        <div style="float: left; width: 4px">
                                                                            &nbsp;</div>
                                                                        <div style="float: left;">
                                                                            <asp:RadioButtonList ID="rdlSpecific" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Text="Specific" Value="s"></asp:ListItem>
                                                                                <asp:ListItem Text="Not Specific" Value="n"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </div>
                                                                    </div>
                                                                    <div align="left" style="width: 100%;">
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <div id="publicAccount_label" align="left" runat="server">
                                                                        <div class="bgReportlabel" style="width: 180px; height: 75px">
                                                                            <%=objLangClass.GetLanguageConversion("Public_Accounts")%>
                                                                        </div>
                                                                        <div class="box" style="padding-left: 5px;">
                                                                            <div id="div_listbox" style="display: block; width: 36%">
                                                                                <asp:ListBox ID="lstAccountPublic" runat="server" CssClass="textboxnew1" SelectionMode="Multiple"
                                                                                    onclick="CheckForNone('accounts');" Enabled="true" checked="True" Width="260px">
                                                                                </asp:ListBox>
                                                                            </div>
                                                                            <div style="clear: both; color: Gray; font-size: 10px">
                                                                                (<%=objLangClass.GetLanguageConversion("Use_Ctrl_For_Multiple_Seletion")%>)
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                    <div class="onlyEmpty">
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </telerik:RadPageView>
                                                </telerik:RadMultiPage>
                                            </ContentTemplate>
                                        </telerik:RadPanelItem>
                                        <telerik:RadPanelItem Text="Aggregate Coloumns" Font-Bold="true" Expanded="false"
                                            CssClass="rounded-ReportTopcorners">
                                            <ContentTemplate>
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage3" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView3">
                                                        <div class="AggregateDiv">
                                                            <div align="left" style="padding: 2px;">
                                                                <table>
                                                                    <tr>
                                                                        <td valign="bottom">
                                                                            <div class="prod_report_linkselect">
                                                                                <span id="spn_lnkSelectAll1" runat="server"><a href="javascript:SelectAllGroupByoption();"
                                                                                    id="lnkSelectAll1" style="font-size: 0.8em;">
                                                                                    <%=objLanguage.GetLanguageConversion("Select_All_Columns")%></a></span>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="chkaggregate" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                Width="500px">
                                                                                <asp:ListItem Text="Opening Stock" Value="OpeningStock"></asp:ListItem>
                                                                                <asp:ListItem Text="Location" Value="Location"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Added" Value="QtyAdded"></asp:ListItem>
                                                                                <asp:ListItem Text="Qty Sold" Value="QtySold"></asp:ListItem>
                                                                                <asp:ListItem Text="Quantity(+)" Value="[QtyAdjusted(+)]"></asp:ListItem>
                                                                                <asp:ListItem Text="Quantity(-)" Value="[QtyAdjusted(-)]"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="PCAggregate">
                                                                            <asp:CheckBox ID="chkDrawStock" runat="server" Text="Show detailed additional options stock" />
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
                                                <telerik:RadMultiPage runat="server" ID="RadMultiPage4" SelectedIndex="0" CssClass="multiPage">
                                                    <telerik:RadPageView runat="server" ID="RadPageView4">
                                                        <div>
                                                            <div id="Div5">
                                                                <div align="left" style="width: 100%; padding: 3px;">
                                                                    <div align="left" style="width: 100%">
                                                                        <div class="bgReportlabel" style="width: 180px">
                                                                            <span class="normalText">
                                                                                <%=objLangClass.GetLanguageConversion("Report_Name")%></span>&nbsp;<span style="vertical-align: middle;
                                                                                    color: Red">*</span>
                                                                        </div>
                                                                        <div style="float: left; padding-left: 5px;">
                                                                            <asp:TextBox ID="txtSaveReports" runat="server" SkinID="textPad" MaxLength="200"
                                                                                Width="260px" />
                                                                            <asp:HiddenField ID="hdn_reportID" runat="server" Value="0" />
                                                                            <asp:HiddenField ID="hdn_reportID2" runat="server" />
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div align="left" style="width: 100%">
                                                                        <div class="bgReportlabel prodsbg_heightwidth">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Description")%></span></div>
                                                                        <div style="float: left; padding-left: 5px;">
                                                                            <asp:TextBox ID="txtDescription" runat="server" SkinID="textPad" TextMode="MultiLine"
                                                                                Width="290px" Height="90px" />
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
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
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick"
                                                OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess')" />
                                        </div>
                                        <div id="div_cancelprocess" style="display: none;">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left">
                                        <div id="div_save" style="display: block">
                                            <asp:Button ID="btnSaveRun" runat="server" Text="Save and Run" CssClass="button"
                                                OnClick="btnSaveRun_OnClick" OnClientClick="javascript: var a = ValidateCaller(); if(a)loadingimg('div_save','div_saverunprocess'); return a;" />
                                        </div>
                                        <div id="div_saverunprocess" class="button" style="display: none; width: 80px;">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>
                                    <div style="float: left; width: 117px">
                                        <div id="div_update">
                                             <asp:Button ID="btnUpdateExisting" runat="server" Text="Update Report" CssClass="button"
                                                OnClick="btnUpdateExisting_OnClick" Visible="false" OnClientClick="javascript: var a=ValidateCaller(); if(a)loadingimg(this.id,'div_btnUpdateProcess');return a;" />
                                        </div>
                                        <div id="div_btnUpdateProcess" class="button" style="display: none; width: 85px;">
                                            <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                        </div>
                                    </div>
                                    <div style="width: 2px">
                                    </div>
                                    <div style="float: left">
                                        <div id="div_runreport" style="display: block">
                                            <asp:Button ID="btnRunReport" runat="server" Text="Run Report" CssClass="button"
                                                OnClick="btnRunReport_OnClick" OnClientClick="javascript:loadingimage(this.id,'div_runreportprocess');" />
                                        </div>
                                        <div id="div_runreportprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </div>
                                </div>
                                <div class="only10px">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divexport" runat="server" style="display: none;">
        <div id="div_Total" runat="server" visible="true" style="float: right; padding-right: 50px">
            <span class="Headertext">
                <%=objLangClass.GetLanguageConversion("Total_Records")%>:
                <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></span></div>
        <div class="onlyEmpty">
        </div>
        <div id="divexport1" style="margin-left: 10px;">
            <telerik:RadGrid ID="GridProduct" Width="99%" runat="server" AllowAutomaticDeletes="false"
                ShowStatusBar="true" AllowAutomaticInserts="false" CssClass="RadGrid_Eprint_Skin"
                OnItemDataBound="GridProduct_ItemDataBound" AllowAutomaticUpdates="false" Skin="RadGrid_Eprint_Skin"
                AutoGenerateColumns="true" AllowFilteringByColumn="false" HeaderStyle-Font-Bold="true"
                AllowPaging="true" EnableEmbeddedSkins="false" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                OnPageIndexChanged="GridProduct_PageIndexChanged" OnNeedDataSource="GridProduct_OnNeedDataSource"
                OnPageSizeChanged="GridProduct_PageSizeChanged" PageSize="50" >
                <%--AllowCustomPaging="true"  OnPageIndexChanged="GridProduct_PageIndexChanged"--%>
                <%-- DataSourceID="odsTemplate"--%><%-- OnNeedDataSource="GridProduct_OnNeedDataSource"  AllowCustomPaging="true" OnPageIndexChanged="GridProduct_PageIndexChanged" OnPageSizeChanged="GridProduct_PageSizeChanged"--%>
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                <MasterTableView CommandItemDisplay="Top" OverrideDataSourceControlSorting="true">
                    <CommandItemTemplate>
                        <table class="DivButtonsHeader">
                            <tr>
                               
                                <td>
                                    <asp:ImageButton ID="btnfilter" ToolTip="Back to Search Option" Style="padding: 5px;"
                                        ImageAlign="Left" ImageUrl="~/images/image_EM_b.png" runat="server" Text="Back to Search Option"
                                        Visible="true" OnCommand="btnfilter_OnClick" BackColor="Transparent" OnClientClick="javascript:return setLoadingPosition()" /><%--OnClick="btnfilter_OnClick"--%>
                                    <div>
                                        <asp:ImageButton ToolTip="Export (Presentation Format)" ID="btnNewExport" ImageAlign="Left"
                                            Style="padding: 5px;" ImageUrl="~/images/xls-presentation.jpg" runat="server"
                                            Text="Export" BackColor="Transparent" OnClientClick="javascript:getInnerHtml();"
                                            OnClick="btnExport_New_OnClick" /></div>
                                    <div>
                                        <asp:ImageButton ToolTip="Export (Excel Format)" ID="btnExport" ImageAlign="Left"
                                            Style="padding: 5px;" ImageUrl="~/images/export-icon1.jpg" runat="server" Text="Export"
                                            BackColor="Transparent" OnClientClick="javascript:getInnerHtml();" OnClick="btnExport_OnClick" /></div>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </CommandItemTemplate>
                </MasterTableView>
                <ClientSettings>
                    <Scrolling ScrollHeight="500"></Scrolling>
                </ClientSettings>
            </telerik:RadGrid>
        </div>
        <div style="height: 20px;">
        </div>
        <div id="divaggregate" visible="false" runat="server" style="width: 400px; float: left;
            margin-left: 10px">
            <table width="100%" cellpadding="3" cellspacing="0" border="1px solid #E2E2E2">
                <tr id="divStock" runat="server" visible="false">
                    <td>
                        <span style="font-weight: bold;">Opening Stock </span>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblOpeningStock" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="divLocation" runat="server" visible="false">
                    <td>
                        <strong style="font-weight: bold">Location </strong>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="divAdded" runat="server" visible="false">
                    <td>
                        <strong style="font-weight: bold">Qty Added</strong>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblQtyAdded" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="divSold" runat="server" visible="false">
                    <td>
                        <strong style="font-weight: bold">Qty Sold</strong>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblQtySold" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="divPlus" runat="server" visible="false">
                    <td>
                        <strong style="font-weight: bold">Quantity (+) </strong>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblQtyIncreement" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="divMinus" runat="server" visible="false">
                    <td>
                        <strong style="font-weight: bold">Quantity (-) </strong>
                    </td>
                    <td style="text-align: right">
                        <asp:Label ID="lblQtyDecreement" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="DivStockHelpText" runat="server" style="display: none">
            <table cellpadding="0" cellspacing="2" class="paddingleft7px">
                <tr>
                    <td class="PCLightRed">
                        <%=objlang.GetLanguageConversion("Light_Red") %>
                    </td>
                    <td>
                        =
                    </td>
                    <td>
                        <%=objlang.GetLanguageConversion("When_Product_has_available_stock") %>
                    </td>
                </tr>
                <tr>
                    <td class="PCpink">
                        <%=objlang.GetLanguageConversion("Pink") %>
                    </td>
                    <td>
                        =
                    </td>
                    <td>
                        <%=objlang.GetLanguageConversion("When_Product_has_less_than_available_stock_stock") %>
                    </td>
                </tr>
                <tr>
                    <td class="PCLightBlue">
                        <%=objlang.GetLanguageConversion("Light_Blue") %>
                    </td>
                    <td>
                        =
                    </td>
                    <td>
                        <%=objlang.GetLanguageConversion("When_Product_has_no_single_activity_history_in_Activity_record_no_stock_transaction_done") %>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Button ID="btnsavemultiple" runat="server" OnClick="btnsavemultiple_onclick"
        Style="visibility: hidden"></asp:Button>
    <asp:HiddenField ID="hdn_Customers" runat="server" Value="" />
    <asp:HiddenField ID="hdn_ReportIDs" runat="server" Value="" />
    <asp:LinkButton ID="lnkFileDownload" runat="server" OnClick="btnExport_OnClick"></asp:LinkButton>
    <asp:LinkButton ID="lnkbtnBack" runat="server" OnClick="btnfilter_OnClick"></asp:LinkButton>
    <asp:HiddenField ID="hdnInnerHtml" runat="server" />
    <script type="text/javascript">
        var Pgtype = '<%=pg %>';
        // var chkColumns = getName("<%=chkColumns.ClientID %>");
        var txtName = document.getElementById("<%=txtName.ClientID %>");
        var lnkSelectAll = document.getElementById("lnkSelectAll");
        var chk1 = document.getElementById("<%=chkColumns.ClientID%>");
        var chk = chk1.getElementsByTagName("input");
        var chk23 = chk1.getElementsByTagName("td");
        var ChkColumns = document.getElementById("<%=chkColumns.ClientID%>");
        var chkprd = ChkColumns.getElementsByTagName("input");
        for (var i = 0; i < chk.length; i++) {
            if (chk[i].checked == true) {
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_None") %>';
            }
            else {
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_All_Columns") %>';
            }
        }


        var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
        var divusrReportsave = document.getElementById("<%=divusrReportsave.ClientID %>");
        var div_showfilters = document.getElementById("<%=div_showfilters.ClientID %>");

        function GetSelect() {
            var x = 0, y = 0;
            for (var i = 0; i < chk.length; i++) {
                if (chk[i].checked == true) {
                    x++;
                }
            }

            if (x == chk.length) {
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_None") %>';
            }
            else {
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_All_Columns") %>';
            }


        }
        function Call_Report(liID) {
            if (document.getElementById(liID) != null) { // on 23.09.2011
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
        }

    </script>
    <asp:Panel ID="pnlReports" runat="server">
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

        var rdlSpecific = document.getElementById('<%= rdlSpecific.ClientID%>');
        var rdlDateArray = rdlSpecific.getElementsByTagName("rdlDateArray");

        for (var i = 0; i < rdlDateArray.length; i++) {
            rdlDateArray[i].disabled = false;
            rdlSpecific.selected = "";
        }

        function CheckForNone(value) {

            var lstAccountPublic = document.getElementById('<%= lstAccountPublic.ClientID%>');

            var rdlDateArray = rdlSpecific.getElementsByTagName("input");
            if (lstAccountPublic.value == "" || lstAccountPublic.value == "0") {
                //alert(txtName.value);
                for (var i = 0; i < rdlDateArray.length; i++) {

                    if (txtName.value == "") {
                        rdlDateArray[i].disabled = false;
                    }
                    else {
                        rdlDateArray[0].disabled = false;
                        rdlDateArray[1].disabled = true;
                    }
                }
            }
            else {
                for (var i = 0; i < rdlDateArray.length; i++) {
                    rdlDateArray[i].disabled = true;
                }
            }
        }

        function showddl(divid) {
            document.getElementById(divid).style.display = "block";
        }

        function ShowOff(divid) {
            document.getElementById(divid).style.display = "none";
        }

        function GetClientName11(ClientID, ClientName, Contacts, AccountNo, Address) {
            txtName.value = SpecialDecode(ClientName);
            var rdlDateArray = rdlSpecific.getElementsByTagName("input");
            //rdlDateArray[0].checked = true;
            //rdlDateArray[1].disabled = true;
            hid_ClientID.value = ClientID;
        }
        //********** End Of web service to autocomplete clientname *********//

    </script>
    <script type="text/javascript">



        document.getElementById("ds00").style.display = "none";
        document.getElementById("div_Load").style.display = "none";
        function SelectAll() {
            debugger
            var Count = 0;
            if (lnkSelectAll.innerHTML.trim() == '<%=objlang.GetLanguageConversion("Select_All_Columns") %>') {
                for (var i = 0; i < chk.length; i++) {

                    chk[i].checked = true;


                }
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_None") %>';
            }
            else {
                for (var i = 0; i < chk.length; i++) {
                    if (i == 0) {
                        chk[i].checked = true;
                    }
                    else {
                        chk[i].checked = false;
                    }

                }
                lnkSelectAll.innerHTML = '<%=objlang.GetLanguageConversion("Select_All_Columns") %>';
            }
        }






        function getInnerHtml() {
            var element = document.getElementById("divexport1");
            document.getElementById('<%=hdnInnerHtml.ClientID%>').value = element.innerHTML;
            //            __doPostBack('ctl00$ContentPlaceHolder1$lnkFileDownload', '');

        }
        function setLoadingPosition() {


            document.getElementById("ds00").style.display = "block";
            document.getElementById("div_Load").style.display = "block";
            __doPostBack('ctl00$ContentPlaceHolder1$lnkbtnBack', '');

        }
        function DownloadFile() {
            __doPostBack('ctl00$ContentPlaceHolder1$lnkFileDownload', '');
        }

        function ValidateSave() {
            var Check = false;
            var txtSaveReports = document.getElementById("<%=txtSaveReports.ClientID%>");

            if (txtSaveReports.value == '') {
                alert('<%=objLangClass.GetLanguageConversion("Please_Enter_Report_Name")%>');
                txtSaveReports.focus();
                Check = false;
            }
            else {
                Check = true;
            }

            if (Check) {
                return true;
            }
            else {
                return false;
            }
        }
        function ValidateCaller() {
            if (!ValidateSave()) {
                return false;
                showWaitMessage();
            }
            else
                return true;
        }

        function SelectAllGroupByoption() {
            var lnkSelectAll1 = document.getElementById("lnkSelectAll1");
            var CHK11 = document.getElementById("<%=chkaggregate.ClientID%>");
            var chk1 = CHK11.getElementsByTagName("input");
            var ChkDrawStock = document.getElementById("<%=chkDrawStock.ClientID%>");

            if (lnkSelectAll1.innerHTML == '<%=objlang.GetLanguageConversion("Select_All_Columns") %>') {

                for (var i = 0; i < chk1.length; i++) {
                    chk1[i].checked = true;
                    ChkDrawStock.checked = true;
                    lnkSelectAll1.innerHTML = '<%=objlang.GetLanguageConversion("Select_None") %>';
                }


                if (Check_SpecialPrivilege1 == "False") {
                    for (var i = 0; i < chknet.length; i++) {
                        chknet[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objlang.GetLanguageConversion("Select_None") %>';
                    }
                    for (var i = 0; i < chknetPercentage.length; i++) {
                        chknetPercentage[i].checked = true;
                        lnkSelectAll1.innerHTML = '<%=objlang.GetLanguageConversion("Select_None") %>';
                    }
                }
            }
            else {


                for (var i = 0; i < chk1.length; i++) {
                    chk1[i].checked = false;
                    ChkDrawStock.checked = false;
                    lnkSelectAll1.innerHTML = '<%=objlang.GetLanguageConversion("Select_All_Columns") %>';
                }

            }
        }


    </script>
</asp:Content>

