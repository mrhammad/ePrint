<%@ Page Language="C#" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="purchase_report.aspx.cs" Inherits="ePrint.Purchase.purchase_report" Title="Untitled Page" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/pagingreport.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Savereport" Src="~/usercontrol/Reports.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="reports">
        <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
            rel="stylesheet" />
        <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
        <script src="../js/jquery.ui.tabs.js" type="text/javascript"></script>
        <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
        <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
        <div id="di`v_mask">
        </div>
        <div id="ds00" style="display: block;">
        </div>
        <div id="div_Load" class="loading_new">
            <UC:Loading ID="ucLoading" runat="server" />
        </div>
        <script type="text/javascript">

            var div_Load = document.getElementById("div_Load");
            document.getElementById("div_Load").style.display = "block";
        </script>
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

            .chkBoxListPurchase td {
                width: 10%;
            }
        </style>
        <script>
            var Pgtype = '<%=pg %>';
        </script>
        <div id="div_option" runat="server">
            <div id="div_header" class="navigatorpanel" runat="server">
                <div style="clear: both;">
                </div>
            </div>
            <div id="divtab" runat="server">
                <div style="display: none" id="padding">
                    <ul>
                        <li id="li_Save" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_SR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px; float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="spn_1" onclick="Call_Report(this.id);">
                                    <%=objLangClass.GetLanguageConversion("Saved_Reports")%></span></b>
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
                        <li style="margin-left: -5px"><a href="#tabs-1" id="A1" onclick="Call_Report(this.id);">
                            <b>
                                <%=objLangClass.GetLanguageConversion("Saved_Reports")%></b></a></li>
                        <li><a href="#tabs-2" id="A2" onclick="Call_Report(this.id);"><b>
                            <%=objLangClass.GetLanguageConversion("Customize_Reports")%></b></a></li>
                    </ul>
                    <div id="tabs-1" class="ui-tabs-hide">
                        <div id="divusrReportsave" runat="server" class="report_savedtab" style="border: 1px solid rgb(170, 170, 170);">
                            <UC:Savereport ID="usrReportsave" runat="server" />
                        </div>
                    </div>
                    <div id="tabs-2" class="ui-tabs-hide">
                        <div class="TelerikPaneDiv" id="div_showfilters" runat="server" style="width: 100%">
                            <div id="Div1" class="report_customizetab">
                                <div id="div_Error" align="center" style="width: 100%; display: none">
                                    <span id="spnError" runat="server" class="spanerrorMsg" style="width: 300px; text-align: center">
                                        <%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Column_To_Generate_Report")%></span>
                                </div>
                                <div class="only5px">
                                </div>
                                <div align="left" style="width: 100%;">
                                    <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="950px" Height="100%"
                                        Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                                        <Items>
                                            <telerik:RadPanelItem Text="Select columns to run report" Font-Bold="true" Expanded="true"
                                                CssClass="rounded-ReportTopcorners" Selected="true">
                                                <ContentTemplate>
                                                    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="multiPage">
                                                        <telerik:RadPageView runat="server" ID="RadPageView1">
                                                            <div class="ColoumnDiv">
                                                                <table>
                                                                    <td valign="bottom">
                                                                        <div align="left" style="width: 100%; padding: 5px;">
                                                                            <a href="javascript:SelectAll();" id="lnkSelectAll" style="font-size: 0.8em">
                                                                                <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                                                        </div>
                                                                    </td>
                                                                    <tr>
                                                                        <td>
                                                                            <div align="left" style="margin-top: -4px">
                                                                                <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                    Width="830px" CssClass="chkBoxListPurchase">
                                                                                    <asp:ListItem Text="" Value="PONO" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CreatedDate" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Company"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ContactName"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ContactAddress"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="DeliveryAddress"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CommentDeliveryInstructions"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Status"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="RaisedBy"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="RequestedDate"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="CarrierInformation"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ReferenceNumber"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="JobNumber"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="SupplierQuoteNO"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="SupplierInvoiceNo"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="SupplierInvoiceDate"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="DeliveryDate"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="InvoiceReceived"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Total(Incl.Tax)" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Total(Ex.Tax)" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="JobTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="Activity Notes" Value="ActivityNotes"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="AccountingCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ItemCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Description"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ItemQuantity"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="PackedIn"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Price"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Tax"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="TaxValue"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Notes"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="GoodsReceived"></asp:ListItem>
                                                                                    <asp:ListItem Text="Contact Job Title 1" Value="ContactJobTitle1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Contact Job Title 2" Value="ContactJobTitle2"></asp:ListItem>
                                                                                    <asp:ListItem Text="Payment Terms" Value="PaymentTerms"></asp:ListItem>
                                                                                    <asp:ListItem Text="Item Title" Value="ItemTitle"></asp:ListItem>
                                                                                    <asp:ListItem Text="Invoice Number" Value="InvoiceNumber"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="InvoiceDate"></asp:ListItem>
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
                                                Expanded="true">
                                                <ContentTemplate>
                                                    <telerik:RadMultiPage runat="server" ID="rad2" SelectedIndex="0" CssClass="multiPage">
                                                        <telerik:RadPageView runat="server" ID="view2">
                                                            <div class="recordDiv">
                                                                <div id="Div2">
                                                                    <div id="div3" style="width: 49%">
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <asp:Label ID="Label4" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Sort_By")%></asp:Label>
                                                                            </div>
                                                                            <div class="box" style="float: left; padding-left: 5px">
                                                                                <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="normalText" Width="200px"
                                                                                    Height="20px">
                                                                                    <asp:ListItem Value="none">None</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div id="div4" style="width: 49%">
                                                                        <asp:UpdatePanel ID="UpdatePanel4" RenderMode="Inline" runat="server">
                                                                            <ContentTemplate>
                                                                                <div align="left">
                                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                                        <asp:Label ID="Label5" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Direction")%></asp:Label>
                                                                                    </div>
                                                                                    <div class="box" style="float: left; padding-left: 5px">
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
                                                                                <div align="left">
                                                                                    <div class="bgReportlabel" style="width: 190px">
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
                                                                                                        <a href="javascript:\\" style="font-size: 0.8em" onclick="javascript:SummaryorDetialsSelectnone();">Select <span id="spn_SummaryDetail"></span></a>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </div>
                                                                                </div>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                    <div id="divDetails" style="width: 49%;">
                                                                        <asp:UpdatePanel ID="UpdatePanel2" RenderMode="Inline" runat="server">
                                                                            <ContentTemplate>
                                                                                <div align="left">
                                                                                    <div class="bgReportlabel" style="width: 190px">
                                                                                        <asp:Label ID="Label2" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Group_The_Records_By")%></asp:Label>
                                                                                    </div>
                                                                                    <div class="box" style="float: left; padding-left: 5px;">
                                                                                        <asp:DropDownList ID="ddlsummarydetails" SkinID="onlyDDL" CssClass="normaltext" runat="server"
                                                                                            Width="200px">
                                                                                            <asp:ListItem Value="0" Text="Date"></asp:ListItem>
                                                                                            <asp:ListItem Value="1" Selected="True" Text="Daily"></asp:ListItem>
                                                                                            <asp:ListItem Value="2" Text="Monthly"></asp:ListItem>
                                                                                            <asp:ListItem Value="3" Text="Yearly"></asp:ListItem>
                                                                                            <asp:ListItem Value="4" Text="Supplier"></asp:ListItem>
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
                                            <telerik:RadPanelItem Text="Report Filters " Font-Bold="true" CssClass="rounded-ReportTopcorners"
                                                Expanded="false">
                                                <ContentTemplate>
                                                    <telerik:RadMultiPage runat="server" ID="RadMultiPage4" SelectedIndex="0" CssClass="multiPage">
                                                        <telerik:RadPageView runat="server" ID="RadPageView4">
                                                            <div class="FilterJob">
                                                                <div align="left">
                                                                    <div align="left" style="padding: 5px">
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 190px; height: 102px">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Purchase_Status")%></span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <telerik:RadListBox ID="PurchaseStatus" runat="server" CheckBoxes="true" Width="200px"
                                                                                    Height="100px">
                                                                                    <Items>
                                                                                    </Items>
                                                                                </telerik:RadListBox>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="display: none">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Invoice_Range")%></span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:DropDownList ID="ddlEstimateRange" runat="server" CssClass="normalText" Width="200px">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div id="divchkEstimate" style="float: left; padding-left: 5px">
                                                                                <asp:CheckBox ID="chkEstimate" runat="server" Text="Show Invoices that has no assigned values"
                                                                                    Checked="true" />
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="display: none">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>(<%=objLangClass.GetLanguageConversion("Invoice_Status")%></span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:ListBox ID="lstStatus" runat="server" CssClass="normalText" SelectionMode="Multiple"
                                                                                    Width="200px"></asp:ListBox>
                                                                                <span class="smallgraytext" style="padding-left: 5px; vertical-align: top">&nbsp;(<%=objLangClass.GetLanguageConversion("Multiple_Selection_Option")%>)</span>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 190px; height: 102px">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Select_Supplier")%></span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left;">
                                                                                <div style="float: left; padding-bottom: 5px">
                                                                                    <%--      <asp:TextBox ID="txtName" SkinID="textPad" runat="server" AutoCompleteType="disabled"></asp:TextBox>
                                                                                <div class="onlyEmpty">
                                                                                </div>
                                                                                <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                                                                                </div>--%>
                                                                                    <telerik:RadListBox ID="lstPurchaseSupplier" runat="server" CheckBoxes="true" Width="200px"
                                                                                        Height="100px">
                                                                                        <Items>
                                                                                        </Items>
                                                                                    </telerik:RadListBox>
                                                                                </div>
                                                                                <%--<div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none">
                                                                            <img id="img_down01" src="<%=strImagepath %>down01.gif" onclick="BindSupplierName('');"
                                                                                style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                                                                        </div>--%>
                                                                            </div>
                                                                            <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
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
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>Notes Type</span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:DropDownList ID="ddlNotesType" runat="server" Width="200px">
                                                                                    <asp:ListItem Text="-- Select --" Selected="True" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="System" Value="System"></asp:ListItem>
                                                                                    <asp:ListItem Text="General" Value="General"></asp:ListItem>
                                                                                    <asp:ListItem Text="Error" Value="Error"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <%--Estimator--%>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>Estimator</span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:DropDownList ID="ddlEstimator" runat="server" Width="200px">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <%--Sales Person--%>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>Sales Person</span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:DropDownList ID="ddlSalesPerson" runat="server" Width="200px">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <%--Customer Sales Person--%>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>Customer Sales Person</span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:DropDownList ID="ddlCustomerSalesPerson" runat="server" Width="200px">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" runat="server" id="divLocation" visible="false">
                                                                            <div class="bgReportlabel" style="width: 192px">
                                                                                <span>Select Locations
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="normalText" Width="200px" Style="margin-top: 2px">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="width: 100%">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Free_text")%></span>
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
                                                                        <%-- <span class="smallgraytext">&nbsp;(<%=objLangClass.GetLanguageConversion("Freetext_PO_Report")%>)</span>--%>
                                                                        <div align="left" style="width: 100%">
                                                                            <div class="bgReportlabel" style="width: 190px">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Select_Filelds_to_be_searched")%></span>
                                                                            </div>
                                                                            <div style="float: left;">
                                                                                <asp:CheckBoxList ID="chkfreetext" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
                                                                                    <asp:ListItem Text="" Value="SupplierName"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="PONO"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="JobNumber"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ContactName"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="ItemCode"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="AccountingCode"></asp:ListItem>
                                                                                </asp:CheckBoxList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>

                                                                        <%-------%>
                                                                        <div align="left" class="bgReportlabel" style="margin-left: -7px; padding: 2px;width: 21%;">
                                                                                <span id="Span56ItemCode" runat="server" >Item Code</span>
                                                                        </div>
                                                                        <div style="float: right; margin-right: 65%;">
                                                                            <asp:CheckBox runat="server" ID="chkItemCodeNotNull" Text="Item Code Not Null" />
                                                                        </div>
                                                                        <div class="onlyEmpty"></div>
                                                                        <%--____--%>
                                                                        <div align="left" style="margin-left: -7px; padding: 2px">
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
                                                                                            <asp:ListItem Text="Current Year" Value="thisyear"></asp:ListItem>
                                                                                            <asp:ListItem Text="Half Fiscal year" Value="halfyear"></asp:ListItem>
                                                                                            <asp:ListItem Text="Till Date" Value="tilldate"></asp:ListItem>

                                                                                            <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>

                                                                                            <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                            <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                            <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>

                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 260px;">
                                                                                        <span id="spn_daily" style="display: none" runat="server" class="smallgraytext">(26/10/2009)</span> <span id="spn_yest" style="display: none" runat="server" class="smallgraytext">(25/10/2009)</span> <span id="spn_month" runat="server" style="display: none"
                                                                                            class="smallgraytext">(1/10/2009 to 31/10/2009)</span> <span id="spn_quarter"
                                                                                                runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span>
                                                                                        <span id="spn_lastque" runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span> <span id="spn_year" runat="server" style="display: none" class="smallgraytext">(2009)</span><span id="span_halfyear" runat="server" style="display: none" class="smallgraytext">
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
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </telerik:RadPageView>
                                                    </telerik:RadMultiPage>
                                                </ContentTemplate>
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem Text="Show aggregate functions by purchase value" Expanded="false"
                                                Font-Bold="true" CssClass="rounded-ReportTopcorners">
                                                <ContentTemplate>
                                                    <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="multiPage">
                                                        <telerik:RadPageView runat="server" ID="RadPageView2">
                                                            <div class="ColoumnDiv">
                                                                <div align="left" style="padding: 2px;">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="prod_report_linkselect">
                                                                                    <a href="javascript:SelectAllGroupByoption();" id="lnkSelectAll1" style="font-size: 0.8em;">
                                                                                        <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBoxList ID="chkColumns1" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                                                                                    <asp:ListItem Value="EstimateCount" Text="Count"></asp:ListItem>
                                                                                    <asp:ListItem Value="EstimateTotal" Text="Total" Selected="True"></asp:ListItem>
                                                                                    <asp:ListItem Value="EstimateAverage" Text="Average"></asp:ListItem>
                                                                                    <asp:ListItem Value="EstimateMaximum" Text="Maximum"></asp:ListItem>
                                                                                    <asp:ListItem Value="EstimateMinimum" Text="Minimum"></asp:ListItem>
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
                                                                        <div class="bgReportlabel" style="width: 190px">
                                                                            <span class="HeaderText">
                                                                                <%=objLangClass.GetLanguageConversion("Report_Name")%></span>&nbsp;<span style="vertical-align: middle; color: Red">*</span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px;">
                                                                            &nbsp;
                                                                        </div>
                                                                        <asp:TextBox ID="txtSaveReports" runat="server" SkinID="textPad" MaxLength="200"
                                                                            Width="200px" />
                                                                        <asp:HiddenField ID="hdn_reportID" runat="server" />
                                                                    </div>
                                                                    <div align="left">
                                                                        <div class="bgReportlabel estbg_heightwidth">
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
                                            <div style="display: block">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick"
                                                    OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess')" />
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
                                                <asp:Button ID="btnSaveRun" runat="server" Text="Save and Run" CssClass="button"
                                                    OnClick="btnSaveRun_OnClick" OnClientClick="javascript:var a=ValidateCaller();if(a)loadingimage(this.id,'div_btnsaverunprocess');return a;" />
                                            </div>
                                            <div id="div_btnsaverunprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left; width: 100px">
                                            <div id="div_update" style="display: block">
                                                <asp:Button ID="btnUpdateExisting" runat="server" Text="Update Report" CssClass="button"
                                                    OnClick="btnUpdateExisting_OnClick" Visible="false" OnClientClick="javascript:var a=ValidateCaller(); if(a)loadingimage('div_update','div_btnUpdateExistingprocess'); return a;" />
                                            </div>
                                            <div id="div_btnUpdateExistingprocess" style="display: none;">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" style="margin-top: 2px;" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <%-- <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>--%>
                                        <div style="float: left; margin-left: 12px;">
                                            <div id="div_btnrunreport" style="display: block">
                                                <asp:Button ID="btnRunReport" runat="server" Text="Run Report" CssClass="button"
                                                    OnClientClick="javascript:var a=Runvalidate();if(a!=false)loadingimage(this.id,'div_btnrunreportprocess');return a;"
                                                    OnClick="btnRunReport_OnClick" />
                                                <%-- javascript:return funcCaller();--%>
                                            </div>
                                            <div id="div_btnrunreportprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                    </div>
                                    <asp:HiddenField ID="HdnSortBy" runat="server" Value="PONO" />
                                    <div class="only5px">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="only5px">
                    </div>
                </div>
            </div>
        </div>
        <div align="left" style="width: 100%">
            <div class="only5px">
            </div>
            <div id="div_searchres" style="float: left; padding-left: 5px; width: 99%" class="successfulMsg"
                runat="server" visible="false">
                <asp:Label ID="lbl_searchres" runat="server" ForeColor="gray"></asp:Label>
            </div>
            <div class="only5px">
            </div>
            <div id="divexport" runat="server">
                <div align="left" id="divtoolbar" runat="server" visible="false" class="DivButtonsHeader report_resultpanel">
                    <table border="0" class="act_width100">
                        <tr>
                            <td>
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
                                            <asp:ImageButton ToolTip="Export" ImageUrl="~/images/export-icon1.jpg" ID="btnExport"
                                                runat="server" Text="Export" OnClick="btnExport_OnClick" OnClientClick="javascript:getInnerHtml();"
                                                Visible="false" BackColor="Transparent" />
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
                                        <%=objLangClass.GetLanguageConversion("Total_Records")%>:</span> <b>
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
                            <%--   <asp:GridView ID="GridEstReport" CssClass="t" runat="server" Width="100%" SkinID="GridStyleReport"
                                HeaderStyle-HorizontalAlign="Left" PageSize="100" RowStyle-HorizontalAlign="Left"
                                CellPadding="4" OnDataBound="GridPurchaseReport_OnDataBound">
                            </asp:GridView>--%>

                            <telerik:RadGrid ID="GridEstReport" Width="100%" runat="server" AllowAutomaticDeletes="false"
                                ShowFooter="True" AllowAutomaticInserts="false" CssClass="RadGrid_Eprint_Skin"
                                OnItemDataBound="GridPurchaseReport_OnDataBound" AllowAutomaticUpdates="false" Skin="RadGrid_Eprint_Skin"
                                AutoGenerateColumns="true" AllowFilteringByColumn="false" HeaderStyle-Font-Bold="true"
                                AllowPaging="true" EnableEmbeddedSkins="false" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                OnPageIndexChanged="GridPurchase_PageIndexChanged" OnNeedDataSource="GridPurchase_OnNeedDataSource"
                                OnPageSizeChanged="GridPurchase_PageSizeChanged" PageSize="50" Visible="false" EnableAjaxSkinRendering="true" EnableViewState="true">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                            </telerik:RadGrid>
                        </div>
                        <asp:Label ID="lblActivityNotes" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblDescription" runat="server" Visible="false"></asp:Label>
                    </div>
                    <div>
                        <asp:PlaceHolder ID="plhdetails" runat="server"></asp:PlaceHolder>
                    </div>
                    <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                        <div id="Div6" class="emptyrecords" align="center">
                            <span class="HeaderText" style="text-align: center">No record(s) found</span>
                        </div>
                    </asp:Panel>
                </div>
                <div class="only10px">
                </div>
                <div style="border-bottom: 2px solid #E2E2E2" runat="server" id="divAggl" visible="false">
                </div>
                <div class="only10px">
                </div>
                <div id="divaggregate" visible="false" runat="server" style="width: 400px">
                    <div id="divaggregate1" runat="server">
                        <table width="350" border="1px solid black" cellpadding="3" cellspacing="0" style="border-left: 0; border-right: 0; border-top: 0;">
                            <tr id="divCount" runat="server" visible="false">
                                <td style="border-right: 0; border-bottom: 0;">
                                    <span style="font-weight: bold">
                                        <%=objLangClass.GetLanguageConversion("Count")%>: </span>
                                </td>
                                <td style="text-align: right; border-bottom: 0;">
                                    <asp:Label ID="lblinvCount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="divTotal" runat="server" visible="false">
                                <td style="border-right: 0; border-bottom: 0;">
                                    <span style="font-weight: bold">
                                        <%=objLangClass.GetLanguageConversion("Total_Incl_Tax")%>
                                        (<%=objJava.GetCurrencyinRequiredFormate("", true)%>) </span>
                                </td>
                                <td style="text-align: right; border-bottom: 0;">
                                    <asp:Label ID="lblinvTotal" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="divAverage" runat="server" visible="false">
                                <td style="border-right: 0; border-bottom: 0;">
                                    <span style="font-weight: bold">
                                        <%=objLangClass.GetLanguageConversion("Average_Incl_Tax")%>
                                        (<%=objJava.GetCurrencyinRequiredFormate("", true)%>) </span>
                                </td>
                                <td style="text-align: right; border-bottom: 0;">
                                    <asp:Label ID="lblinvAverage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="divminimum" runat="server" visible="false">
                                <td style="border-right: 0; border-bottom: 0;">
                                    <span style="font-weight: bold">
                                        <%=objLangClass.GetLanguageConversion("Max_Incl_Tax")%>
                                        (<%=objJava.GetCurrencyinRequiredFormate("", true)%>) </span>
                                </td>
                                <td style="text-align: right; border-bottom: 0;">
                                    <asp:Label ID="lblinvMaximum" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="divMaximum" runat="server" visible="false">
                                <td style="border-right: 0; border-bottom: 0;">
                                    <span style="font-weight: bold">
                                        <%=objLangClass.GetLanguageConversion("Min_Incl_Tax")%>
                                        (<%=objJava.GetCurrencyinRequiredFormate("", true)%>) </span>
                                </td>
                                <td style="text-align: right; border-bottom: 0;">
                                    <asp:Label ID="lblinvminimum" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
        </div>
        <asp:HiddenField ID="hdnInnerHtml" runat="server" />
        <script>
            var RB1 = document.getElementById("<%=rdlDate.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var chkDateOption = document.getElementById("<%=chkDateOption.ClientID%>");
            var txtFromDate = document.getElementById("<%=txtFrom.ClientID %>");
            var txtToDate = document.getElementById("<%=txtTo.ClientID %>");
            var CHK1 = document.getElementById("<%=chkColumns.ClientID%>");
            var chk = CHK1.getElementsByTagName("input");
            var lnkSelectAll = document.getElementById("lnkSelectAll");
            var ddlEstimateRange = document.getElementById("<%=ddlEstimateRange.ClientID %>");
            var lstStatus = document.getElementById("<%=lstStatus.ClientID %>");
            var chkEstimate = document.getElementById("<%=chkEstimate.ClientID %>");
            var divchkEstimate = document.getElementById("divchkEstimate");

            var hid_ClientID = document.getElementById("<%=hid_ClientID.ClientID %>");
            var DateFormat = '<%=DateFormat %>';
            var chkColumns = getName("<%=chkColumns.ClientID %>");

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


            function GetSelect() {
                var x = 0, y = 0;
                for (var i = 0; i < chk.length; i++) {
                    if (chk[i].checked == true) {
                        x++;
                    }
                }

                if (x == chk.length) {
                    lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None") %>';
                }
                else {
                    lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All") %>';
                }

                for (var i = 0; i < chk1.length; i++) {
                    if (chk1[i].checked == true) {
                        y++;
                    }
                }

                if (y == chk1.length) {
                    document.getElementById("lnkSelectAll1").innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None") %>';
                }
                else {
                    document.getElementById("lnkSelectAll1").innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns") %>';
                }

                if (chkDateOption.checked == true) {
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

                //GetSummaryDetails();
                GetDetails();
                GetDropdownBindonBack();
                GetDropdownBind();
                EnableDateOption();

            }

            function OnEditReport() {

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

                var purno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (purno.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Purchase_Number_To_Generate_Report")%>');
                    return false;
                }
                //                var purval = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_17');
                //                if (purval.checked == false) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Total_To_Generate_Report")%>');
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
                var str = lnkSelectAll.innerHTML.trim();
                var dropDownListRef = document.getElementById('<%= ddlSortBy.ClientID %>');

                for (j = dropDownListRef.length - 1; j >= 1; j--) {

                    dropDownListRef.remove(j);
                }
                if (str == '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>') {
                    for (var i = 0; i < chk.length; i++) {
                        var option1 = document.createElement("option");
                        chk[i].checked = true;
                        lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';


                        if (i == 0) {
                            option1.text = "Purchase Number";
                            option1.value = "PONO";
                        }
                        else if (i == 1) {
                            option1.text = "Created Date";
                            option1.value = "CreatedDate";
                        }
                        else if (i == 2) {
                            option1.text = "Company";
                            option1.value = "Company";
                        }
                        else if (i == 3) {
                            option1.text = "Raised By";
                            option1.value = "RaisedBy";
                        }
                        else if (i == 4) {
                            option1.text = "Purchase Date";
                            option1.value = "RequestedDate";
                        }
                        else if (i == 5) {
                            option1.text = "Total(Incl.Tax)";
                            option1.value = "Total(Incl.Tax)";
                        }
                        else if (i == 6) {
                            option1.text = "Job Title";
                            option1.value = "JobTitle";
                        }

                        if (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6) {
                            if (columnsList[i].checked) {
                                dropDownListRef.options.add(option1);
                            }
                        }
                    }
                    dropDownListRef.value = "PONO";
                    HdnSortBy.value = "PONO";
                }
                else {
                    for (var i = 1; i < chk.length; i++) {
                        chk[i].checked = false;
                        lnkSelectAll.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>'
                        //HdnSortBy.value = "none";
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
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear");
                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_rdlDate");
                var spn_rdlDate_annualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_rdlDate_annualYear");
                
                var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;
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
                    spn_rdlDate_annualYear.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                } else if (ddlvalue == "daily") {
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
            function BindSupplierName(txtval) {
                if (txtval.length > 3) {
                    var CompID = '<%=CompanyID %>';
                    var val = CompID + "&" + txtval;
                    PageMethods.GetSupplierName(val, FindSuccCName);
                }
            }
            function FindSuccCName(result) {
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
                        finalval += " <div class='divpad' style='height:20px;z-index:1000;background-color:" + color1 + "'>";
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
                txtName.value = ClientName;
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
                var purno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (purno.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Purchase_Number_To_Generate_Report")%>');
                    return false;
                }
                var purval = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_17');
                if (purval.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Total_To_Generate_Report")%>');
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
        <script>
            function GetSummaryDetails() {
                document.getElementById("divDetails").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i3_chkColumns1_3").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i3_chkColumns1_4").checked = true;
                document.getElementById("spn_SummaryDetail").innerHTML = 'None';
                var rdosummary = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary");
                if (rdosummary.checked == true) {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "block";
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_DivSelect").style.display = "none";
                }
                GetDropdownBindonBack();
                GetDropdownBind();
                EnableDateOption();
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
                GetDropdownBindonBack();
                GetDropdownBind();
                EnableDateOption();
            }
            function SummaryorDetialsSelectnone() {
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdodetail").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdosummary").checked = false;
                GetDetails();
            }


            var CHK11 = document.getElementById("<%=chkColumns1.ClientID%>");
            var chk1 = CHK11.getElementsByTagName("input");
            var chkColumns1 = getName("<%=chkColumns1.ClientID %>");
            var lnkSelectAll1 = document.getElementById("lnkSelectAll1");

            function SelectAllGroupByoption() {
                var Count = 0;
                if (trim12(lnkSelectAll1.innerHTML) == '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>') {

                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = true;
                        //lnkSelectAll1.innerHTML = "Select None";
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_None")%>';
                    }
                }
                else {
                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = false;
                        //lnkSelectAll1.innerHTML = "Select All";
                        lnkSelectAll1.innerHTML = '<%=objLangClass.GetLanguageConversion("Select_All_Columns")%>';
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
        <script>
            //======Created On 25/05/2012 ===By Pradeep======
            var Checkcolumns = document.getElementById('<%= chkColumns.ClientID %>');
            var columnsList = Checkcolumns.getElementsByTagName("input");

            var dropDownListRef = document.getElementById('<%= ddlSortBy.ClientID %>');
            var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');
            function AddDDLValue(text, value, k) {
                var option1 = document.createElement("option");
                if (text != "" && value != "") {
                    option1.text = text;
                    option1.value = value;
                }

                if (columnsList[k].checked) {

                    dropDownListRef.options.add(option1);
                    HdnSortBy.value = "PurchaseNumber";
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
                    option1.text = "Purchase Number";
                    //option1.value = "PurchaseNumber";
                    option1.value = "PONO";
                }
                else if (i == 1) {
                    option1.text = "Created Date";
                    option1.value = "CreatedDate";
                }
                else if (i == 2) {
                    option1.text = "Company";
                    option1.value = "Company";
                }
                else if (i == 8) {
                    option1.text = "Raised By";
                    option1.value = "RaisedBy";
                }
                else if (i == 9) {
                    option1.text = "Purchase Date";
                    option1.value = "RequestedDate";
                }
                else if (i == 18) {
                    option1.text = "Total(Inc.Tax)";
                    //option1.value ="Total(Inc.Tax)";
                    option1.value = "Total(Incl.Tax)";
                }
                else if (i == 20) {
                    option1.text = "Job Title";
                    option1.value = "JobTitle";
                }
                else if (i == 23) {
                    option1.text = "Item Code";
                    option1.value = "ItemCode";
                }
                else if (i == 25) {
                    option1.text = "Item Quantity";
                    option1.value = "ItemQuantity";
                }

                if (i == 0 || i == 1 || i == 2 || i == 8 || i == 9 || i == 18 || i == 20 || i == 23 || i == 25) {
                    if (columnsList[i].checked) {
                        dropDownListRef.options.add(option1);
                    }
                }
                //dropDownListRef.value = "PurchaseNumber";
                dropDownListRef.value = "PONO";
                //HdnSortBy.value = "PurchaseNumber";
            }


            function ddlsortByOnchange() {
                var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');
                var ddlSortBy = document.getElementById('<%= ddlSortBy.ClientID %>');
                HdnSortBy.value = ddlSortBy.options[ddlSortBy.selectedIndex].value;
            }
            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
            //====================================== 

        </script>
        <script>
            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        </script>
        <script>

            function Runvalidate() {

                var purno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (purno.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Purchase_Number_To_Generate_Report")%>');
                    return false;
                }
            }
        </script>
    </div>
</asp:Content>

