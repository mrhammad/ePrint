<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/Templates/innerMasterPage_withoutLeftTD.master" AutoEventWireup="true" CodeBehind="client_report.aspx.cs" Inherits="ePrint.client.client_report" Title="CRM Report" EnableViewStateMac="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/pagingreport.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Savereport" Src="~/usercontrol/Reports.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="ddlCompanyType">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lstCustomerType" LoadingPanelID="RadAjaxLoadingPanel2" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel2" runat="server" Skin="Default">
    </telerik:RadAjaxLoadingPanel>
    <div id="reports">
        <script type="text/javascript">

            var div_Load = document.getElementById("div_Load");
            if (document.getElementById("div_Load") != null)
                document.getElementById("div_Load").style.display = "block";
        </script>
        <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
            rel="stylesheet" />
        <script src="<%=strSitepath %>js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
        <script src="<%=strSitepath %>js/jquery.ui.tabs.js" type="text/javascript"></script>
        <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
        <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
        <div id="ds00" style="display: block;">
        </div>
        <div id="div_Load" class="loading_new">
            <UC:Loading ID="ucLoading" runat="server" />
        </div>
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

            .chkBoxListEst td {
                width: 26%;
            }
        </style>
        <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1">
        </telerik:RadAjaxLoadingPanel>
        <div id="div_option" runat="server" style="width: 100%;">
            <div class="navigatorpanel">
            </div>
            <div id="divtab" runat="server">
                <div style="display: none">
                    <div align="left" style="padding: 2px 0px 0px 0px; float: left; border: 1px solid green;">
                        <div id="div_SR" class="SummaryTabs" nowrap="nowrap" style="height: 20px; cursor: pointer; float: left; padding: 0px 10px 0px 10px; line-height: 20px; margin-right: 2px">
                            <b><span id="spn_1" class="active" onclick="Call_Report(this.id);">Saved Reports </span>
                            </b>
                        </div>
                        <div id="div_CR" class="SummaryTabs" nowrap="nowrap" style="height: 20px; padding: 0px 10px 0px 10px; float: left; line-height: 20px; margin-right: 2px">
                            <b><span id="spn_2" onclick="Call_Report(this.id);">Customize Reports</span></b>
                        </div>
                        <div id="waitmessage" class="ClientWaitTab">
                            &nbsp;&nbsp;<table cellpadding="0" cellspacing="10">
                                <tr>
                                    <td align="right" bordercolor="#ffffff">
                                        <div style="float: left">
                                            <asp:Image ID="imgHourglass" runat="server" ImageUrl="~/images/loading_new.gif" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div id="tabs" style="width: 98%; border: solid 0px red; visibility: hidden; padding-top: 3px; padding-left: 7px"
                    class="ui-tabs">
                    <ul id="test-1" style="list-style: none; height: auto; background-color: #FFFFFF; border-left: 1px solid transparent; border-right: 1px solid transparent; border-top: 1px solid transparent; border-radius: 0px; width: 97.4%; border-bottom: 1px solid transparent; margin-left: 5px;">
                        <li style="margin-left: -5px"><a id="A1" href="#tabs-1" onclick="Call_Report(this.id);">
                            <b>
                                <%=objLangClass.GetLanguageConversion("Saved_Reports")%></b></a></li>
                        <li><a id="A2" href="#tabs-2" onclick="Call_Report(this.id);"><b>
                            <%=objLangClass.GetLanguageConversion("Customize_Reports")%></b></a></li>
                    </ul>
                    <div id="tabs-1" class="ui-tabs-hide">
                        <div id="divusrReportsave" runat="server" class="report_savedtab" style="border: 1px solid rgb(170, 170, 170);">
                            <UC:Savereport ID="usrReportsave" runat="server" />
                        </div>
                    </div>
                    <div id="tabs-2" class="ui-tabs-hide">
                        <div id="div_showfilters" class="TelerikPaneDiv" runat="server" style="width: 100%;">
                            <div id="padding" class="report_customizetab">
                                <div>
                                    <div id="div_Error" align="center" style="width: 100%; display: none">
                                        <span id="spnError" runat="server" class="spanerrorMsg" style="width: 300px; text-align: center">
                                            <%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Column_To_Generate_Report")%></span>
                                    </div>
                                    <div align="left" style="width: 100%">
                                        <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="950px" Height="100%"
                                            Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                                            <Items>
                                                <telerik:RadPanelItem Text="Select Columns to Run Report" Font-Bold="true" Expanded="true"
                                                    CssClass="rounded-ReportTopcorners" Selected="true">
                                                    <ContentTemplate>
                                                        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
                                                            <telerik:RadPageView runat="server" ID="RadPageView1">
                                                                <div style="width: 900px; padding-left: 8px; padding-top: 5px; padding-bottom: 5px">
                                                                    <div class="ChkGaps">
                                                                    </div>
                                                                    <div align="left">
                                                                        <asp:CheckBox ID="Chk_CompanyInfo" runat="server" Font-Bold="false" Text="Company Information"
                                                                            onclick="javascript:ChkCompanyInfoAll();" />
                                                                        <div align="left" style="padding-left: 15px;">
                                                                            <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                Width="880px" CssClass="chkBoxListEst">
                                                                                <asp:ListItem Text="" Value="CompanyName" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CompanyType"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Type"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AccountStatus"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AccountNo"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Email"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="URL"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CreditLimit"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CreditRef"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Tax1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Tax2"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Description"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="PaymentTerms"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ProfitMargin"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="TaxRegNo"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="CompanyNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ACOpened"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="BankCode"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="BankAccountNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AccountName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="SalesPerson"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="name"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="eStoreName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="OpenTasksCalls"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="RoyalityFree"></asp:ListItem>

                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="ChkGaps">
                                                                    </div>
                                                                    <div align="left">
                                                                        <asp:CheckBox ID="Chk_contacts" runat="server" Font-Bold="false" Text="Contacts"
                                                                            onclick="javascript:ChkcontactsInfoAll();" />
                                                                        <div align="left" style="padding-left: 15px;">
                                                                            <asp:CheckBoxList ID="chk_contactsList" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4" Width="880px" CssClass="chkBoxListEst">
                                                                                <asp:ListItem Text="" Value="ContactName" Selected="True"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="FirstName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="MiddleName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="LastName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Title"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="JobTitle1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="JobTitle2"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactEmail"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Mobile"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Phone"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AlternateNumber"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="PersonalFax"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Department"></asp:ListItem>
                                                                                <asp:ListItem Text=" " Value="ContactAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DeliveryAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="InvoiceAddress"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="MainApprover"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="SubscribedUser"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ReceiveMailout"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactCustomField1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactCustomField2"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactCustomField3"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactCustomField4"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactCustomField5"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                        <div align="left" style="padding-left: 20px; padding-top: 5px;">
                                                                            <div class="bgReportlabel" style="width: 26%">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Show_Addresses_In")%>
                                                                                </span>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlIndividual" runat="server" CssClass="normalText" Width="200px">
                                                                                    <asp:ListItem Text="One Column" Value="OneColumn" Selected="true"></asp:ListItem>
                                                                                    <asp:ListItem Text="Individual Column" Value="IndividualColumn"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="ChkGaps">
                                                                    </div>
                                                                    <div align="left">
                                                                        <asp:CheckBox ID="Chk_Department" runat="server" Font-Bold="false" Text="Department"
                                                                            onclick="javascript:ChkDeptInfoAll();" />
                                                                        <div align="left" style="padding-left: 15px;">
                                                                            <asp:CheckBoxList ID="Chk_DepartmentList" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4" Width="880px" CssClass="chkBoxListEst">
                                                                                <asp:ListItem Text="" Value="DepartmentName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DeliveryAddress1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="InvoiceAddress1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Costcenter"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DepartmentCustomField1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DepartmentCustomField2"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DepartmentCustomField3"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DepartmentCustomField4"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="DepartmentCustomField5"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="ChkGaps">
                                                                    </div>
                                                                    <div align="left">
                                                                        <asp:CheckBox ID="Chk_address" runat="server" Font-Bold="false" Text="Address" onclick="javascript:ChkAddressInfoAll();" />
                                                                        <div align="left" style="padding-left: 15px;">
                                                                            <asp:CheckBoxList ID="Chk_addressList" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="4" Width="880px" CssClass="chkBoxListEst">
                                                                                <asp:ListItem Text="" Value="AddressLabel"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address1"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address2"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address3"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address4"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Address5"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Country"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Telephone"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Fax"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="IsPostBoxAddress"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="ChkGaps">
                                                                    </div>
                                                                    <div align="left" id="divAggCustomer">
                                                                        <asp:CheckBox ID="chkAggCustomer" runat="server" Font-Bold="false" Text="Show Aggregate Functions Specific to Customer"
                                                                            onclick="javascript:chkAggCustomer();" />
                                                                        <div style="padding-left: 15px;">
                                                                            <asp:CheckBoxList ID="chkAggCustomeritems" runat="server" RepeatDirection="Horizontal"
                                                                                RepeatColumns="2" Width="475px" CssClass="chkBoxListEst">
                                                                                <asp:ListItem Text="Total Estimate" Value="TotalEstimate"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimate Value" Value="EstimateValue"></asp:ListItem>
                                                                                <asp:ListItem Text="Total Job" Value="TotalJob"></asp:ListItem>
                                                                                <asp:ListItem Text="Job Value" Value="JobValue"></asp:ListItem>
                                                                                <asp:ListItem Text="Total Invoice" Value="TotalInvoice"></asp:ListItem>
                                                                                <asp:ListItem Text="Invoice Value" Value="InvoiceValue"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimate - Job conversion count %" Value="EstimateJobconversioncount"></asp:ListItem>
                                                                                <asp:ListItem Text="Estimate - Job conversion value %" Value="EstimateJobconversionvalue"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="ChkGaps">
                                                                    </div>
                                                                </div>
                                                            </telerik:RadPageView>
                                                        </telerik:RadMultiPage>
                                                    </ContentTemplate>
                                                </telerik:RadPanelItem>
                                                <%-- Additional options--%>
                                                <telerik:RadPanelItem Text="Group" Font-Bold="true" Expanded="false" CssClass="rounded-ReportTopcorners">
                                                    <ContentTemplate>
                                                        <telerik:RadMultiPage runat="server" ID="RadMultiPage5" SelectedIndex="0">
                                                            <telerik:RadPageView runat="server" ID="RadPageView5">
                                                                <div align="left">
                                                                    <div align="left" style="padding: 5px">
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 250px">
                                                                                <asp:Label ID="Label2" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Group_The_Records_By")%></asp:Label>
                                                                            </div>
                                                                            <div class="box" style="float: left; padding-left: 5px;">
                                                                                <asp:DropDownList ID="ddlGrouprecords" runat="server" CssClass="normalText" Width="200px"
                                                                                    Height="20px">
                                                                                    <asp:ListItem Value="0" Text="None"></asp:ListItem>
                                                                                    <asp:ListItem Value="1" Text="Daily"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="SalesPerson"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div class="bgReportlabel" style="width: 250px">
                                                                                <asp:Label ID="Label4" class="normalText" runat="server"><%=objLanguage.GetLanguageConversion("Sort_By")%></asp:Label>
                                                                            </div>
                                                                            <div style="float: left; padding-left: 5px">
                                                                                <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="normalText" Width="200px"
                                                                                    Height="20px">
                                                                                    <asp:ListItem Value="none">None</asp:ListItem>
                                                                                    <asp:ListItem Value="CompanyName" Text="Company Name" Selected="True"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 250px">
                                                                                <asp:Label ID="lblDirection" class="normalText" runat="server"><%=objLangClass.GetLanguageConversion("Direction")%></asp:Label>
                                                                            </div>
                                                                            <div style="float: left;">
                                                                                <div style="float: left; padding-left: 5px">
                                                                                    <asp:DropDownList ID="ddlDirection" runat="server" CssClass="normalText" Width="200px"
                                                                                        Height="20px">
                                                                                        <asp:ListItem Value="ASC">Ascending</asp:ListItem>
                                                                                        <asp:ListItem Value="DESC">Descending</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                            </telerik:RadPageView>
                                                        </telerik:RadMultiPage>
                                                    </ContentTemplate>
                                                </telerik:RadPanelItem>
                                                <telerik:RadPanelItem Text="Report Filters" Expanded="false" Font-Bold="true" CssClass="rounded-ReportTopcorners">
                                                    <ContentTemplate>
                                                        <telerik:RadMultiPage runat="server" ID="RadMultiPage3" SelectedIndex="0">
                                                            <telerik:RadPageView runat="server" ID="RadPageView3">
                                                                <div class="FilterJob">
                                                                    <div align="left">
                                                                        <div align="left" style="padding: 5px">
                                                                            <div align="left">
                                                                                <div class="bgReportlabel" style="width: 26%">
                                                                                    <span>
                                                                                        <%=objLangClass.GetLanguageConversion("Company_Type")%></span>
                                                                                </div>
                                                                                <div style="float: left; width: 5px">
                                                                                    &nbsp;
                                                                                </div>
                                                                                <div style="float: left">
                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:DropDownList ID="ddlCompanyType" OnSelectedIndexChanged="rdllist_OnSelectedIndexChanged"
                                                                                                AutoPostBack="True" runat="server" CssClass="normalText" Width="200px">
                                                                                                <asp:ListItem Value="0">--- Any ---</asp:ListItem>
                                                                                                <asp:ListItem Text="Customer" Value="Customer" Selected="true"></asp:ListItem>
                                                                                                <asp:ListItem Text="Supplier" Value="Supplier"></asp:ListItem>
                                                                                                <asp:ListItem Text="Prospect" Value="Prospect"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </div>
                                                                                <div class="onlyEmpty">
                                                                                </div>
                                                                            </div>
                                                                            <div align="left">
                                                                                <div class="bgReportlabel" style="width: 26%">
                                                                                    <span>
                                                                                        <%=objLangClass.GetLanguageConversion("Type")%></span>
                                                                                </div>
                                                                                <div style="float: left; width: 5px">
                                                                                    &nbsp;
                                                                                </div>
                                                                                <div style="float: left">
                                                                                    <telerik:RadScriptBlock runat="server" ID="RadScriptBlock2">
                                                                                        <telerik:RadListBox ID="lstCustomerType" runat="server" CheckBoxes="true" Width="200px"
                                                                                            Height="100px">
                                                                                            <Items>
                                                                                            </Items>
                                                                                        </telerik:RadListBox>
                                                                                    </telerik:RadScriptBlock>
                                                                                </div>
                                                                                <div class="onlyEmpty">
                                                                                </div>
                                                                            </div>
                                                                            <div align="left" style="width: 100%">
                                                                                <div class="bgReportlabel" style="width: 26%">
                                                                                    <span>
                                                                                        <%=objLangClass.GetLanguageConversion("Free_Text")%></span>
                                                                                </div>
                                                                                <div style="float: left; width: 5px">
                                                                                    &nbsp;
                                                                                </div>
                                                                                <div style="float: left;">
                                                                                    <asp:TextBox ID="txtFreetext" runat="server" SkinID="textPad" MaxLength="255" Width="200px"></asp:TextBox>
                                                                                    <span class="smallgraytext">&nbsp;(<%=objLangClass.GetLanguageConversion("ReferredBY_Freetext_Search_Client")%>)</span>
                                                                                </div>
                                                                                <div class="onlyEmpty">
                                                                                </div>
                                                                            </div>
                                                                            <div class="only5px">
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <%--   <div align="left">
                                                                    <span id="Span1" runat="server" class="smallgraytext">(<%=objLangClass.GetLanguageConversion("Date_Format")%>:
                                                                        <%=DateFormat %>
                                                                        )</span>
                                                                </div>--%>
                                                                    <div align="left">
                                                                        <div align="left">
                                                                            <table style="width: 730px; margin-left: -2px">
                                                                                <tr>
                                                                                    <td style="width: 248px;">
                                                                                        <asp:CheckBox ID="chkDateOption" runat="server" Text="Created Date Options" Font-Bold="true"
                                                                                            onclick="javascript:EnableDateOption();OnCheckShow()" />
                                                                                    </td>
                                                                                    <td align="left" style="width: 20px;">
                                                                                        <asp:DropDownList ID="rdlDate" Enabled="false" runat="server" Width="200px" onChange="javascript:GetDropdownBind();">
                                                                                            <asp:ListItem Text="Today" Value="daily"></asp:ListItem>
                                                                                            <asp:ListItem Text="Yesterday" Value="yesterday"></asp:ListItem>
                                                                                            <asp:ListItem Text="Current Month" Value="thismonth" Selected="true"></asp:ListItem>
                                                                                            <asp:ListItem Text="Current Quarter" Value="thisquarter"></asp:ListItem>
                                                                                            <asp:ListItem Text="Current Year" Value="thisannualyear"></asp:ListItem>
                                                                                            <asp:ListItem Text="Last Quarter" Value="lastquater"></asp:ListItem>
                                                                                            <asp:ListItem Text="Current Fiscal Year" Value="thisyear"></asp:ListItem>
                                                                                            <asp:ListItem Text="Half Fiscal year" Value="halfyear"></asp:ListItem>
                                                                                            <asp:ListItem Text="All time" Value="tilldate"></asp:ListItem>
                                                                                            <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                            <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                            <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                            <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="width: 250px">
                                                                                        <span id="spn_daily" runat="server" class="smallgraytext" style="display: none">(26/10/2009)</span>
                                                                                        <span id="spn_yest" runat="server" class="smallgraytext" style="display: none">(25/10/2009)</span>
                                                                                        <span id="spn_month" runat="server" class="smallgraytext" style="display: none">(1/10/2009
                                                                                            to 31/10/2009)</span> <span id="spn_quarter" runat="server" class="smallgraytext"
                                                                                                style="display: none">(Oct - Dec 2009)</span>
                                                                                        <span id="spn_rdlDate_AnnualYear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                        <span id="spn_lastque" runat="server"
                                                                                            class="smallgraytext" style="display: none">(Oct - Dec 2009)</span>
                                                                                        <span id="spn_year" runat="server" class="smallgraytext" style="display: none">(2009)</span>
                                                                                        <span id="spn_halfyear" runat="server" class="smallgraytext" style="display: none">(Oct
                                                                                            - Dec 2009) </span>
                                                                                        <span id="spn_lastweek" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>
                                                                                        <span id="spn_lastmonth" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                        <span id="spn_lastyear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>

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
                                                                            <span id="Span2" runat="server" class="smallgraytext" style="padding-left: 14px">(<%=objLangClass.GetLanguageConversion("Date_Filter_applied_on_Customer_Account_Opened_Date_not_on_Customer_record_created_Date")%>)</span>
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                        <div id="divdates" align="left" style="display: none; margin-left: 460px; padding-bottom: 4px">
                                                                            <asp:DropDownList ID="ddldates" SkinID="onlyDDL" runat="server" Width="150px">
                                                                                <asp:ListItem Text="Apply Both Dates" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="Apply Either Dates" Value="2"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div align="left">
                                                                                <table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 248px;">
                                                                                            <asp:CheckBox ID="chkContactDateOption" runat="server" Text="Contact Date Option"
                                                                                                Font-Bold="true" onclick="javascript:EnableContactDateOption();checkdates();OnCheckShowConverted()" />
                                                                                        </td>
                                                                                        <td align="left" style="width: 20px;">
                                                                                            <asp:DropDownList ID="ddlContactDateOption" Enabled="false" Width="200px" runat="server"
                                                                                                onChange="javascript:GetContactDropdownBind();">
                                                                                                <asp:ListItem Text="Today" Value="daily"></asp:ListItem>
                                                                                                <asp:ListItem Text="Yesterday" Value="yesterday"></asp:ListItem>
                                                                                                <asp:ListItem Text="Current Month" Value="thismonth" Selected="true"></asp:ListItem>
                                                                                                <asp:ListItem Text="Current Quarter" Value="thisquarter"></asp:ListItem>
                                                                                                <asp:ListItem Text="Current Year" Value="thisannualyear"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Quarter" Value="lastquater"></asp:ListItem>
                                                                                                <asp:ListItem Text="Current Fiscal Year" Value="thisyear"></asp:ListItem>
                                                                                                <asp:ListItem Text="Half Fiscal year" Value="halfyear"></asp:ListItem>
                                                                                                <asp:ListItem Text="All time" Value="tilldate"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="width: 250px">
                                                                                            <%--<div style="float: left">--%>
                                                                                            <span id="spn_daily_c" style="display: none" runat="server" class="smallgraytext">(01/10/2010)</span>
                                                                                            <span id="spn_yest_c" style="display: none" runat="server" class="smallgraytext">(01/10/2010)</span>
                                                                                            <span id="spn_month_c" style="display: none" runat="server" class="smallgraytext">(1/10/2010
                                                                                                to 31/10/2010)</span> <span id="spn_quarter_c" style="display: none" runat="server"
                                                                                                    class="smallgraytext">(Oct - Dec 2010)</span> <span id="spn_lastque_c" style="display: none"
                                                                                                        runat="server" class="smallgraytext">(Oct - Dec 2010)</span> <span id="spn_year_c"
                                                                                                            runat="server" style="display: none" class="smallgraytext">(2010)</span>
                                                                                            <span id="spn__halfyear_c" runat="server" style="display: none" class="smallgraytext">(Oct 2013 - March 2014) </span>
                                                                                            <span id="spn_lastweek_c" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>
                                                                                            <span id="spn_lastmonth_c" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                            <span id="spn_lastyear_c" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>

                                                                                            <%-- </div>--%>
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
                                                                                            <span id="spn_ddlContactDateOption_annualYear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <span id="spncnthelptxt" runat="server" class="smallgraytext" style="padding-left: 14px">(<%=objLangClass.GetLanguageConversion("Date_filter_applies_on_Contact_Created_Date")%>)</span>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>

                                                                        <%--if show main contact checked --// added by shehzad--%>
                                                                        <div align="left">
                                                                            <div align="left">
                                                                                <table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 248px;">
                                                                                            <asp:CheckBox ID="chkShowMainContact" runat="server" Text="Show Main Contact" Font-Bold="true" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div align="left">
                                                                                <table id="tbActivity" style="width: 722px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 272px;">
                                                                                            <asp:CheckBox ID="chkNoActivityinPast" runat="server" Text="No Activity in past"
                                                                                                Font-Bold="true" onclick="javascript:EnableNoActivityinPast();OnCheckShowNoActivityinPast()" />
                                                                                        </td>
                                                                                        <td align="left" style="width: 20px;">
                                                                                            <asp:DropDownList ID="ddl_NoActivityinPast" Enabled="false" Width="200px" runat="server"
                                                                                                Style="float: left" onChange="javascript:GetNoActivityinPastDropdownBind();">
                                                                                                <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                                                                <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                                                                <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                                                                                <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                                                                                <asp:ListItem Text="120" Value="120"></asp:ListItem>
                                                                                                <asp:ListItem Text="365" Value="365"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="width: 5px;">
                                                                                            <span id="spndays" style="display: block" runat="server" class="smallgraytext">Days</span>
                                                                                        </td>
                                                                                        <td style="width: 250px">
                                                                                            <span id="Spnpast30days" style="display: none" runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span> <span id="Spanpast45days" style="display: none"
                                                                                                runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span> <span id="Spnpast60days"
                                                                                                    style="display: none" runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span>
                                                                                            <span id="Spnpast90days" style="display: none" runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span> <span id="Spnpast120days" style="display: none"
                                                                                                runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span> <span id="Spnpast365days"
                                                                                                    style="display: none" runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span>
                                                                                            <div align="left" id="divNoActivityinPastFromdaterange" runat="server" style="display: none">
                                                                                                <asp:TextBox ID="txtNoActivityinPastFromdate" runat="server" SkinID="textPad" Width="100px"
                                                                                                    Enabled="false"></asp:TextBox><span class="normalText">&nbsp;<%=objLangClass.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                                        ID="txtNoActivityinPastTodate" runat="server" SkinID="textPad" Width="100px"
                                                                                                        Enabled="false"></asp:TextBox>
                                                                                                <span id="SpanddlNoActivityinPast1" class="spanerrorMsg" style="display: none; width: 150px">
                                                                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                                </span><span id="SpanddlNoActivityinPast2" class="spanerrorMsg" style="display: none; width: 250px;">
                                                                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                                </span><span id="SpanddlNoActivityinPast3" class="spanerrorMsg" style="display: none">
                                                                                                    <%=objLangClass.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 320px;"></td>
                                                                                        <td align="left" style="width: 280px;">
                                                                                            <asp:CheckBox ID="chk_Estimate" runat="server" Text="Estimate" onclick="javascript:NoActPast_Estimate_ChkBx();" />
                                                                                            <asp:CheckBox ID="chk_Job" runat="server" Text="Job" onclick="javascript:NoActPast_Job_ChkBx()" />
                                                                                        </td>
                                                                                        <td style="width: 300px;"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                        <div align="left">
                                                                            <div align="left">
                                                                                <table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 248px;">
                                                                                            <asp:CheckBox ID="chkestimatevaluerange" runat="server" Text="Estimate Value" Font-Bold="true"
                                                                                                onclick="javascript:Enableestimatevaluerange();OnCheckShowestimatevalue()" />
                                                                                        </td>
                                                                                        <td align="left" style="width: 20px;">
                                                                                            <asp:DropDownList ID="ddlestimatevaluerange" Enabled="false" Width="200px" runat="server"
                                                                                                onChange="javascript:ddlestimatevaluerangeDropdownonchange();">
                                                                                                <asp:ListItem Text="Greater than" Value="greater than"></asp:ListItem>
                                                                                                <asp:ListItem Text="Less than" Value="less than"></asp:ListItem>
                                                                                                <asp:ListItem Text="Equals to" Value="equals to"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="width: 250px">
                                                                                            <%=CurrencySymbol%><asp:TextBox ID="txtestimatevaluerange" runat="server" SkinID="textPad"
                                                                                                Width="100px" Enabled="false" onblur="javascript:AllowNumber(this,this.value);todecimal_function(this,this.value)"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <%--<table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 334px;"></td>
                                                                                        <td align="left" style="width: 280px;">$<asp:TextBox ID="txtestimatevaluerange" runat="server" SkinID="textPad" Width="100px" Enabled="false" onblur="javascript:AllowNumber(this,this.value);todecimal_function(this,this.value)"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="width: 300px;"></td>
                                                                                    </tr>
                                                                                </table>--%>
                                                                                <table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 248px;"></td>
                                                                                        <td align="left" style="width: 20px;">
                                                                                            <asp:DropDownList ID="ddlestimatevaluedaterange" Enabled="false" Width="200px" runat="server"
                                                                                                onChange="javascript:GetestimatevaluerangetDropdownBind();">
                                                                                                <asp:ListItem Text="Current Month" Value="current month"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Month" Value="last month"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>

                                                                                                <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="width: 250px">
                                                                                            <span id="spnestvaluecurrentmonth" style="display: none" runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span> <span id="spnestvaluelastmonth" style="display: none"
                                                                                                runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span>
                                                                                            <span id="spn_lastweek_est" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>

                                                                                            <span id="spn_lastyear_est" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>

                                                                                            <div align="left" id="divestimatevaluedaterange" runat="server" style="display: none; padding-left: 7px;">
                                                                                                <asp:TextBox ID="txtestvalueFromdate" runat="server" SkinID="textPad" Width="100px"
                                                                                                    Enabled="false"></asp:TextBox><span class="normalText">&nbsp;<%=objLangClass.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                                        ID="txtestvalueTodate" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox>
                                                                                                <span id="Span" class="spanerrorMsg" style="display: none; width: 150px">
                                                                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                                </span><span id="Spanddlestimatevaluedaterange2" class="spanerrorMsg" style="display: none; width: 250px;">
                                                                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                                </span><span id="Spanddlestimatevaluedaterange3" class="spanerrorMsg" style="display: none">
                                                                                                    <%=objLangClass.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                        <div align="left">
                                                                            <div align="left">
                                                                                <table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 248px;">
                                                                                            <asp:CheckBox ID="chkjobvaluerange" runat="server" Text="Job Value" Font-Bold="true"
                                                                                                onclick="javascript:Enablejobvaluerange();OnCheckShowjobvaluerange()" />
                                                                                        </td>
                                                                                        <td align="left" style="width: 20px;">
                                                                                            <asp:DropDownList ID="ddljobvaluerange" Enabled="false" Width="200px" runat="server"
                                                                                                onChange="javascript:ddljobvaluerangeDropdownonchange();">
                                                                                                <asp:ListItem Text="Greater than" Value="greater than"></asp:ListItem>
                                                                                                <asp:ListItem Text="Less than" Value="less than"></asp:ListItem>
                                                                                                <asp:ListItem Text="Equals to" Value="equals to"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="width: 250px">
                                                                                            <%=CurrencySymbol%><asp:TextBox ID="txtjobvaluerange" runat="server" SkinID="textPad"
                                                                                                Width="100px" Enabled="false" onblur="javascript:AllowNumber(this,this.value);todecimal_function(this,this.value)"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <%--<table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 334px;"></td>
                                                                                        <td align="left" style="width: 280px;">$<asp:TextBox ID="txtjobvaluerange" runat="server" SkinID="textPad" Width="100px" Enabled="false" onblur="javascript:AllowNumber(this,this.value);todecimal_function(this,this.value)"></asp:TextBox>
                                                                                        </td>
                                                                                        <td style="width: 300px;"></td>
                                                                                    </tr>
                                                                                </table>--%>
                                                                                <table style="width: 730px; margin-left: -2px">
                                                                                    <tr>
                                                                                        <td style="width: 248px;"></td>
                                                                                        <td align="left" style="width: 20px;">
                                                                                            <asp:DropDownList ID="ddljobvaluedaterange" Enabled="false" Width="200px" runat="server"
                                                                                                onChange="javascript:GetjobvaluedaterangetDropdownBind();">
                                                                                                <asp:ListItem Text="Current Month" Value="current month"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Month" Value="last month"></asp:ListItem>
                                                                                                <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>
                                                                                                <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>

                                                                                                <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                        <td style="width: 250px">
                                                                                            <span id="spnjobvaluecurrentmonth" style="display: none" runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span> <span id="spnjobvaluelastmonth" style="display: none"
                                                                                                runat="server" class="smallgraytext">(1/10/2010 to 31/10/2010)</span>
                                                                                            <span id="spn_lastweek_job" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>

                                                                                            <span id="spn_lastyear_job" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>

                                                                                            <div align="left" id="divjobvaluedaterange" runat="server" style="display: none; padding-left: 7px;">
                                                                                                <asp:TextBox ID="txtjobvalueFromdate" runat="server" SkinID="textPad" Width="100px"
                                                                                                    Enabled="false"></asp:TextBox><span class="normalText">&nbsp;<%=objLangClass.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                                        ID="txtjobvalueTodate" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox>
                                                                                                <span id="spnerrjobvaluedaterange2" class="spanerrorMsg" style="display: none; width: 150px">
                                                                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                                </span><span id="Spanddljobvaluedaterange2" class="spanerrorMsg" style="display: none; width: 250px;">
                                                                                                    <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                                </span><span id="Spanddljobvaluedaterange3" class="spanerrorMsg" style="display: none">
                                                                                                    <%=objLangClass.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                        <div class="only5px">
                                                                        </div>
                                                                    </div>
                                                            </telerik:RadPageView>
                                                        </telerik:RadMultiPage>
                                                    </ContentTemplate>
                                                </telerik:RadPanelItem>
                                                <telerik:RadPanelItem Text="Show Aggregate functions for Entire search results" Font-Bold="true"
                                                    Expanded="false" CssClass="rounded-ReportTopcorners">
                                                    <ContentTemplate>
                                                        <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0">
                                                            <telerik:RadPageView runat="server" ID="RadPageView2">
                                                                <div class="AggregateDiv">
                                                                    <div style="padding: 5px;">
                                                                    </div>
                                                                    <div align="left" style="margin-top: -2px">
                                                                        <table width="60%">
                                                                            <tr>
                                                                                <td>
                                                                                    <div id="chkColumns1" runat="server" style="margin-top: -10px;">
                                                                                        <table border="0" cellpadding="1" cellspacing="0">
                                                                                            <tr>
                                                                                                <td valign="bottom">
                                                                                                    <div align="left" class="crm_report_linkselect">
                                                                                                        <a href="javascript://" id="lnkSelectAll1" style="font-size: 0.8em;" onclick="javascript:SelectAllGroupByoption();">
                                                                                                            <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div class="bgReportlabelcrm">
                                                                                                        <%=objLangClass.GetLanguageConversion("Estimates")%>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:CheckBox ID="chkest" runat="server" Text="" />
                                                                                                </td>
                                                                                                <td align="left" style="padding-left: 30px">
                                                                                                    <asp:CheckBox ID="chkest1" runat="server" Text="Total Est. Value" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div class="bgReportlabelcrm">
                                                                                                        <%=objLangClass.GetLanguageConversion("Jobs")%>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <asp:CheckBox ID="chkjob" runat="server" Text="" />
                                                                                                </td>
                                                                                                <td align="left" style="padding-left: 30px">
                                                                                                    <asp:CheckBox ID="chkjob1" runat="server" Text="Total Job Value" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div class="bgReportlabelcrm">
                                                                                                        <%=objLangClass.GetLanguageConversion("Invoice")%>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <asp:CheckBox ID="chkinv" runat="server" Text="" />
                                                                                                </td>
                                                                                                <td align="left" style="padding-left: 30px">
                                                                                                    <asp:CheckBox ID="chkinv1" runat="server" Text="Total Inv. Value" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div class="bgReportlabelcrm">
                                                                                                        <%=objLangClass.GetLanguageConversion("Purchase_Order")%>
                                                                                                    </div>
                                                                                                </td>
                                                                                                <td align="left" nowrap="nowrap">
                                                                                                    <asp:CheckBox ID="chkpo" runat="server" /><%=objLangClass.GetLanguageConversion("Total_Purchase")%>
                                                                                                </td>
                                                                                                <td align="left" style="padding-left: 30px">
                                                                                                    <asp:CheckBox ID="chkpo1" runat="server" /><%=objLangClass.GetLanguageConversion("Total_Purchase_Value")%>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
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
                                                        <telerik:RadMultiPage runat="server" ID="RadMultiPage4" SelectedIndex="0">
                                                            <telerik:RadPageView runat="server" ID="RadPageView4">
                                                                <div class="FilterJob">
                                                                    <div align="left" style="padding: 3px; padding-top: 7px">
                                                                        <div align="left">
                                                                            <div class="bgReportlabel" style="width: 26%">
                                                                                <span class="HeaderText">
                                                                                    <%=objLangClass.GetLanguageConversion("Report_Name")%></span>&nbsp;<span style="vertical-align: middle; color: Red">*</span>
                                                                            </div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;
                                                                            </div>
                                                                            <div style="float: left">
                                                                                <asp:TextBox ID="txtSaveReports" runat="server" SkinID="textPad" Width="200px" />
                                                                                <asp:HiddenField ID="hdn_reportID" runat="server" />
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel clientbg_heightwidth">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Description")%></span>
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
                                                        OnClientClick="javascript:loadingimage(this.id,'divcancelprocess');" />
                                                </div>
                                                <div id="divcancelprocess" style="display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div class="btnGaps">
                                                &nbsp;
                                            </div>
                                            <div style="float: left">
                                                <div id="div_btnsave" style="display: block">
                                                    <asp:Button ID="btnSaveRun" runat="server" Text="Save and Run" CssClass="button"
                                                        OnClick="btnSaveRun_OnClick" OnClientClick="javascript:var a=ValidateCaller();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                                </div>
                                                <div id="div_btnsaveprocess" style="display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div class="btnGaps">
                                                &nbsp;
                                            </div>
                                            <div style="float: left; width: 100px">
                                                <div id="div_update" style="display: block">
                                                    <asp:Button ID="btnUpdateExisting" runat="server" Text="Update Report" CssClass="button"
                                                        OnClick="btnUpdateExisting_OnClick" Visible="false" OnClientClick="javascript:var a = ValidateCaller(); if(a) loadingimage('div_update','div_btnUpdateProcess'); return a;" />
                                                </div>
                                                <div id="div_btnUpdateProcess" style="display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" style="margin-top: 2px;" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div style="float: left; margin-left: 10px;">
                                                <div id="div_btnrunreport" style="display: block">
                                                    <asp:Button ID="btnRunReport" runat="server" Text="Run Report" CssClass="button"
                                                        OnClick="btnRunReport_OnClick" OnClientClick="javascript:var a=Runvalidate();if(a!=false)loadingimage(this.id,'div_btnrunprocess');return a;" />
                                                </div>
                                                <div id="div_btnrunprocess" style="display: none">
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
                    <div style="clear: both; padding-top: 10px">
                    </div>
                </div>
            </div>
        </div>
        <telerik:RadWindow ID="RadWindow1" runat="server" Skin="Forest" Behaviors="Close, Move"
            Modal="true" Width="440" Height="385" EnableEmbeddedSkins="false">
            <ContentTemplate>
                <img id="Img1" src="Images/discount.jpg" runat="server" alt="promotions" />
            </ContentTemplate>
        </telerik:RadWindow>
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

                function showSpecialOffers() {
                    var oWnd = $find("<%= RadWindow1.ClientID %>");
                    oWnd.set_visibleStatusbar(false);
                    oWnd.show();
                }

                function stopPropagation(e) {
                    e.cancelBubble = true;

                    if (e.stopPropagation)
                        e.stopPropagation();
                }
            </script>
        </telerik:RadScriptBlock>
        <div class="only5px">
        </div>
        <div align="left" style="width: 100%">
            <div id="div_searchres" style="float: left; padding-left: 5px; width: 99%" class="successfulMsg"
                runat="server" visible="false">
                <div style="width: 700px" align="right">
                    <asp:Label ID="lbl_searchres" runat="server" ForeColor="gray"></asp:Label>
                </div>
            </div>
            <div class="only5px">
            </div>
            <div id="divexport" runat="server">
                <div align="left" id="divtoolbar" runat="server" visible="false" class="DivButtonsHeader report_resultpanel">
                    <table border="0" width="97%">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td align="left">&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:ImageButton ToolTip="Back to Search Option" ImageUrl="~/images/image_EM_b.png"
                                                ID="btnfilter" runat="server" Text="Back to Search Option" OnClick="btnfilter_OnClick"
                                                Visible="false" BackColor="Transparent" OnClientClick="javascript:return setLoadingPosition()" />
                                        </td>
                                        <td align="left">
                                            <asp:ImageButton ToolTip="Export" ImageUrl="~/images/export-icon1.jpg" ID="btnExport"
                                                runat="server" Text="Export" OnClick="btnExport_OnClick" OnClientClick="javascript:getInnerHtml();"
                                                Visible="false" BackColor="Transparent" />
                                        </td>
                                        <td nowrap="nowrap">
                                            <UC:Paging ID="usrPaging" runat="server" />
                                        </td>
                                        <td align="left"></td>
                                        <td align="left" nowrap="nowrap">
                                            <asp:TextBox ID="txt1" runat="server" Width="40px" Height="22px" Visible="false"
                                                onblur="javascript:AllowNumber(this,this.value)"></asp:TextBox>&nbsp;
                                        </td>
                                        <td>
                                            <asp:ImageButton ToolTip="Go To" ImageUrl="~/images/gotopage.gif" ID="btngo" runat="server"
                                                CssClass="button" OnClick="btngo_OnClick" Visible="false" BackColor="Transparent"
                                                OnClientClick="javascript:return setLoadingPosition();" />
                                        </td>
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
                            <%--  <asp:GridView ID="GridEstReport" CssClass="t" runat="server" Width="100%" SkinID="GridStyleReport"
                                HeaderStyle-HorizontalAlign="Left" PageSize="100" RowStyle-HorizontalAlign="Left"
                                RowStyle-VerticalAlign="Top" CellPadding="4">
                            </asp:GridView>--%>


                            <telerik:RadGrid ID="GridEstReport" Width="100%" runat="server" AllowAutomaticDeletes="false"
                                ShowFooter="True" AllowAutomaticInserts="false" CssClass="RadGrid_Eprint_Skin"
                                AllowAutomaticUpdates="false" Skin="RadGrid_Eprint_Skin"
                                AutoGenerateColumns="true" AllowFilteringByColumn="false" HeaderStyle-Font-Bold="true"
                                AllowPaging="true" EnableEmbeddedSkins="false" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                                OnPageIndexChanged="GridClient_PageIndexChanged" OnNeedDataSource="GridClient_OnNeedDataSource"
                                OnPageSizeChanged="GridClient_PageSizeChanged" PageSize="50" Visible="false" EnableAjaxSkinRendering="true" EnableViewState="true">
                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
                            </telerik:RadGrid>
                        </div>
                    </div>
                    <div>
                        <asp:PlaceHolder ID="plhdetails" runat="server"></asp:PlaceHolder>
                    </div>
                    <div style="clear: both">
                        &nbsp;
                    </div>
                </div>
            </div>
            <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                <div id="Div1" class="emptyrecords" align="center">
                    <span class="HeaderText" style="text-align: center">
                        <%=objLangClass.GetLanguageConversion("No_Record_Found")%></span>
                </div>
            </asp:Panel>
            <div class="only5px">
            </div>
            <div style="border-bottom: 2px solid #E2E2E2" runat="server" id="divAggl" visible="false">
            </div>
            <div class="only10px">
            </div>
            <div id="divaggregate" visible="false" runat="server" style="width: 350px;">
                <table width="100%" border="1px solid #E2E2E2" cellpadding="0" cellspacing="0">
                    <tr id="divestCount" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Est_Count")%></span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblestCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="divestTotal" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Est_Value")%>
                                (<%=objJava.GetCurrencyinRequiredFormate("", true)%>)</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblestTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="divjobCount" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Job_Count")%></span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lbljobCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="divjobTotal" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Job_Value")%>
                                (<%=objJava.GetCurrencyinRequiredFormate("", true)%>)</span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lbljobTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="divinvCount" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Inv_Count")%></span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblinvCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="divinvTotal" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Inv_Value")%>
                                (<%=objJava.GetCurrencyinRequiredFormate("", true)%>) </span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblinvTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="divpurCount" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Purchase_Count")%></span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblpurCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="divpurTotal" runat="server" visible="false">
                        <td>
                            <span style="font-weight: bold">
                                <%=objLangClass.GetLanguageConversion("Total_Purchase_Value")%>
                                (<%=objJava.GetCurrencyinRequiredFormate("", true)%>) </span>
                        </td>
                        <td style="text-align: right">
                            <asp:Label ID="lblpurTotal" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:HiddenField ID="hdnInnerHtml" runat="server" />
        <asp:HiddenField ID="HdnSortBy" runat="server" Value="CompanyName" />
        <script type="text/javascript">
            var RB1 = document.getElementById("<%=rdlDate.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var rdlDateArray = getName('<%=rdlDate.ClientID %>');
            var chkDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkDateOption");
            var txtFromDate = document.getElementById("<%=txtFrom.ClientID %>");
            var txtToDate = document.getElementById("<%=txtTo.ClientID %>");

            var CHK1 = document.getElementById("<%=chkColumns.ClientID%>");
            var chk = CHK1.getElementsByTagName("input");

            var lnkSelectAllcontact = document.getElementById("lnkSelectAllcontact");

            var CHK11 = document.getElementById("<%=chkColumns1.ClientID%>");
            var chk1 = CHK11.getElementsByTagName("input");
            //var lnkSelectAll = document.getElementById("lnkSelectAll");
            var lnkSelectAll1 = document.getElementById("lnkSelectAll1");
            var divchkEstimate = document.getElementById("divchkEstimate");
            var chkColumns = getName("<%=chkColumns.ClientID %>");
            var chkColumns1 = getName("<%=chkColumns1.ClientID %>");
            var DateFormat = '<%=DateFormat %>';
            var Chk_contacts = getName("<%=chk_contactsList.ClientID %>");

            //new added by ayesha for saving reports
            var txtSaveReports = document.getElementById("<%=txtSaveReports.ClientID %>");
            var div_showfilters = document.getElementById("<%=div_showfilters.ClientID %>");
            var divusrReportsave = document.getElementById("<%=divusrReportsave.ClientID %>");
            var ddlSortBy = document.getElementById("<%=ddlSortBy.ClientID%>")
            var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');
            function AddDDLValue(ddltext, ddlvalue, index) {

                var option = document.createElement("option");
                if (ddltext != "" && ddlvalue != "") {
                    option.text = ddltext;
                    option.value = ddlvalue;
                }
                if (chkColumns[index].checked) {
                    ddlSortBy.options.add(option);
                    HdnSortBy.value = "CompanyName";
                }
                else {
                    for (var j = ddlSortBy.length - 1; j >= 0; j--) {
                        if (ddlSortBy.options[j].value == ddlvalue) {
                            ddlSortBy.remove(j);
                            HdnSortBy.value = "none";
                        }
                    }
                }
            }
            function AddDDLValue_Aggregate(ddltext, ddlvalue, index) {
                var chkAggCustomer = document.getElementById("<%=chkAggCustomer.ClientID%>");
                var chkAggCustomeritems = getName("<%=chkAggCustomeritems.ClientID%>");
                var chkColumnsBoxList_Agg = document.getElementById("<%=chkAggCustomeritems.ClientID%>")
                var chklistArr_Agg = chkColumnsBoxList_Agg.getElementsByTagName("input");
                var chkColumnsTextArr_Agg = chkColumnsBoxList_Agg.getElementsByTagName("label");
                var option = document.createElement("option");
                if (ddltext != "" && ddlvalue != "") {
                    option.text = ddltext;
                    option.value = ddlvalue;
                }
                if (chkAggCustomeritems[index].checked) {
                    ddlSortBy.options.add(option);
                    //HdnSortBy.value = "CompanyName";
                }
                else {
                    for (var j = ddlSortBy.length - 1; j >= 0; j--) {
                        if (ddlSortBy.options[j].value == ddlvalue) {
                            ddlSortBy.remove(j);
                            //HdnSortBy.value = "none";
                        }
                    }
                }
            }
            function ddlsortByOnchange() {
                var HdnSortBy = document.getElementById('<%= HdnSortBy.ClientID %>');
                var ddlSortBy = document.getElementById('<%= ddlSortBy.ClientID %>');
                HdnSortBy.value = ddlSortBy.options[ddlSortBy.selectedIndex].value;
            }
            function Call_Report(liID) {
                if (document.getElementById(liID) != null) {
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

            //validation when save as new and update existing btn is clicked- ayesha
            var Check = false;
            function ValidateSave() {
                var chkEstimate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Estimate");

                var chk_Job = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Job");

                var chkNoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkNoActivityinPast");

                var chkestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkestimatevaluerange");

                var chkAggCustomeritems = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkAggCustomeritems_1");

                var chkAggCustomeritems_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkAggCustomeritems_3");

                var chkjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkjobvaluerange");
                var chkDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkDateOption");


                Check = true;
                var count = 0;
                var contactscount = 0;
                for (var j = 0; j < chkColumns.length; j++) {
                    if (chkColumns[j].checked) {
                        count++;
                    }
                }
                if (count == 0) {
                    Check = false;
                }
                for (var j = 0; j < Chk_contacts.length; j++) {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chk_contactsList_" + [j]).checked) {
                        contactscount++;
                    }
                }
                var estno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (estno.checked == false) {
                    alert('Please check Company name to generate report');
                    return false;
                }
                if (chkEstimate.checked == false && chk_Job.checked == false && chkNoActivityinPast.checked == true) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_check_atleast_one_checkbox_in_No_Activity_in_Past_to_generate_report")%>');
                    return false;
                }
                //                if (chkestimatevaluerange.checked == true && chkAggCustomeritems.checked == false) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Estimate_Value_Inc_Tax_Checkbox_Column_To_Generate_Report")%>');
                //                    return false;
                //                }
                //                if (chkAggCustomeritems_3.checked == false && chkjobvaluerange.checked == true) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Job_Value_Inc_Tax_Checkbox_Column_To_Generate_Report")%>');
                //                    return false;
                //                }

                // && chkAggCustomeritems.checked
                //                if (chkestimatevaluerange.checked == true == true && contactscount == 0) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Select_Atleast_One_Checkbox_In_Contacts_Column_To_Generate_Report")%>');
                //                    return false;
                //                }
                //chkAggCustomeritems_3.checked == true &&
                //                if (chkjobvaluerange.checked == true && contactscount == 0) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Select_Atleast_One_Checkbox_In_Contacts_Column_To_Generate_Report")%>');
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
                                    document.getElementById("spn_txtFromDate").innerHTML = '<%=objLangClass.GetLanguageConversion("Please_Enter_A_Valid_Date")%>';
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
                if (!ValidateSave()) {
                    return false;
                } else {
                    if (document.getElementById("ds00") != null)
                        document.getElementById("ds00").style.display = "block";
                    if (document.getElementById("div_Load") != null)
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

            function SelectAllGroupByoption() {
                var Count = 0;
                if (trim12(lnkSelectAll1.innerHTML) == "Select All Columns") {

                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = true;
                        lnkSelectAll1.innerHTML = "Select None";
                    }
                }
                else {
                    for (var i = 0; i < chk1.length; i++) {
                        chk1[i].checked = false;
                        lnkSelectAll1.innerHTML = "Select All Columns";
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
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_halfyear");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear");
                var spnContactDateOption_AnnualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_rdlDate_AnnualYear");
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
                    spnContactDateOption_AnnualYear.style.display = "block";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }




        </script>
        <div class="onlyEmpty">
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <script type="text/javascript">



                function getName(RdID) {
                    var Rdl = document.getElementById(RdID);
                    var RdlName = Rdl.getElementsByTagName("input");
                    return RdlName;
                }



                var chkAggCustomer = document.getElementById("<%=chkAggCustomer.ClientID%>");
                var chkAggCustomeritems = getName("<%=chkAggCustomeritems.ClientID%>");

                if (chkAggCustomer.checked) {
                    for (var i = 0; i < chkAggCustomeritems.length; i++) {
                        chkAggCustomeritems[i].disabled = false;
                        chkAggCustomeritems[i].checked = true;
                    }
                }
                else {
                    for (var i = 0; i < chkAggCustomeritems.length; i++) {
                        chkAggCustomeritems[i].checked = false;
                    }
                }


            </script>
        </asp:Panel>
        <script type="text/javascript">



            function chkAggCustomer() {
                var chkAggCustomer = document.getElementById("<%=chkAggCustomer.ClientID%>");
                var chkAggCustomeritems = getName("<%=chkAggCustomeritems.ClientID%>");
                var chkColumnsBoxList_Agg = document.getElementById("<%=chkAggCustomeritems.ClientID%>")
                var chklistArr_Agg = chkColumnsBoxList_Agg.getElementsByTagName("input");
                var chkColumnsTextArr_Agg = chkColumnsBoxList_Agg.getElementsByTagName("label");
                if (chkAggCustomer.checked) {
                    for (var i = 0; i <= chkAggCustomeritems.length - 1; i++) {
                        for (var l = 0; l <= ddlSortBy.length - 1; l++) {
                            if (ddlSortBy.options[l].text == chkColumnsTextArr_Agg[i].innerHTML) {
                                ddlSortBy.remove(l);
                            }
                        }
                    }
                    for (var i = 0; i <= chkAggCustomeritems.length - 1; i++) {
                        chkAggCustomeritems[i].disabled = false;
                        chkAggCustomeritems[i].checked = true;
                        var option_Aggr = document.createElement("option");
                        if (i == 0) {
                            option_Aggr.text = "Total Estimate";
                            option_Aggr.value = "TotalEstimate";
                        }
                        else if (i == 1) {
                            option_Aggr.text = "Estimate Value Ex. Tax";
                            option_Aggr.value = "EstimateValue";
                        }
                        else if (i == 2) {
                            option_Aggr.text = "Total Job";
                            option_Aggr.value = "TotalJob";
                        }
                        else if (i == 3) {
                            option_Aggr.text = "Job Value Ex. Tax";
                            option_Aggr.value = "JobValue";
                        }
                        else if (i == 4) {
                            option_Aggr.text = "Total Invoice";
                            option_Aggr.value = "TotalInvoice";
                        }
                        else if (i == 5) {
                            option_Aggr.text = "Invoice Value Ex. Tax";
                            option_Aggr.value = "InvoiceValue";
                        }
                        else if (i == 6) {
                            option_Aggr.text = "Estimate - Job conversion count (%)";
                            option_Aggr.value = "EstimateJobconversioncount";
                        }
                        else if (i == 7) {
                            option_Aggr.text = "Estimate - Job conversion value (%)";
                            option_Aggr.value = "EstimateJobconversionvalue";
                        }
                        if (chklistArr_Agg[i].checked) {
                            ddlSortBy.options.add(option_Aggr);
                        }
                    }
                    HdnSortBy.value = "none";
                    ddlSortBy.value = HdnSortBy.value;
                }
                else {
                    for (var i = 0; i <= chkAggCustomeritems.length - 1; i++) {
                        for (var l = 0; l <= ddlSortBy.length - 1; l++) {
                            if (ddlSortBy.options[l].text == chkColumnsTextArr_Agg[i].innerHTML) {
                                ddlSortBy.remove(l);
                                chkAggCustomeritems[i].checked = false;
                            }
                        }
                    }
                    HdnSortBy.value = "none";
                }
            }

            function ChkCompanyInfoAll() {
                var Chk_CompanyInfo = document.getElementById("<%=Chk_CompanyInfo.ClientID%>");
                var chkColumns = getName('<%=chkColumns.ClientID %>');
                var chkColumnsBoxList = document.getElementById("<%=chkColumns.ClientID%>")
                var chklistArr = chkColumnsBoxList.getElementsByTagName("input");
                var chkColumnsTextArr = chkColumnsBoxList.getElementsByTagName("label");
                var istax2 = '<%=Tax2%>';
                if (Chk_CompanyInfo.checked) {
                    for (var i = 0; i <= chkColumns.length - 1; i++) {
                        for (var l = 0; l <= ddlSortBy.length - 1; l++) {
                            if (ddlSortBy.options[l].text == chkColumnsTextArr[i].innerHTML) {
                                ddlSortBy.remove(l);
                            }
                        }
                    }
                    for (var i = 0; i <= chkColumns.length - 1; i++) {
                        var option = document.createElement("option");
                        chkColumns[i].checked = true;
                        chkColumns[i].disabled = false;
                        if (i == 0) {
                            option.text = "Company Name";
                            option.value = "CompanyName";
                        }
                        else if (i == 1) {
                            option.text = "Company Type";
                            option.value = "CompanyType";
                        }
                        else if (i == 2) {
                            option.text = "Type";
                            option.value = "Type";
                        }
                        else if (i == 3) {
                            option.text = "Account Status";
                            option.value = "AccountStatus";
                        }
                        else if (i == 4) {
                            option.text = "Account Number";
                            option.value = "AccountNo";
                        }
                        else if (i == 5) {
                            option.text = "Email";
                            option.value = "Email";
                        }
                        else if (i == 6) {
                            option.text = "URL";
                            option.value = "URL";
                        }
                        else if (i == 7) {
                            option.text = "Credit Limit";
                            option.value = "CreditLimit";
                        }
                        else if (i == 8) {
                            option.text = "Credit Ref";
                            option.value = "CreditRef";
                        }
                        if (i == 9) {
                            option.text = "Tax";
                            option.value = "Tax1";
                        }
                        if (i == 11) {
                            option.text = "Description";
                            option.value = "Description";
                        }
                        else if (i == 12) {
                            option.text = "Payment Terms";
                            option.value = "PaymentTerms";
                        }
                        else if (i == 13) {
                            option.text = "Profit Margin";
                            option.value = "ProfitMargin";
                        }
                        else if (i == 14) {
                            option.text = "Tax Reg No";
                            option.value = "TaxRegNo";
                        }
                        else if (i == 15) {
                            option.text = "Company Number";
                            option.value = "CompanyNumber";
                        }
                        else if (i == 16) {
                            option.text = "A/C Opened";
                            option.value = "ACOpened";
                        }
                        else if (i == 17) {
                            option.text = "Bank Code";
                            option.value = "BankCode";
                        }
                        else if (i == 18) {
                            option.text = "Bank Account Number";
                            option.value = "BankAccountNumber";
                        }
                        else if (i == 19) {
                            option.text = "Account Name";
                            option.value = "AccountName";
                        }
                        else if (i == 20) {
                            option.text = "Sales Person";
                            option.value = "SalesPerson";
                        }
                        else if (i == 21) {
                            option.text = "Referred By";
                            option.value = "name";
                        }
                        else if (i == 22) {
                            option.text = "eStoreName";
                            option.value = "eStore Name";
                        }
                        else if (i == 23) {
                            option.text = "Open Tasks & Calls";
                            option.value = "OpenTasksCalls";
                        }
                        else if (i == 24) {
                            option.text = "Royality Free";
                            option.value = "RoyalityFree";
                        }
                        if (chklistArr[i].checked && i != 10) {
                            ddlSortBy.options.add(option);
                        }
                    }
                    HdnSortBy.value = "CompanyName";
                    ddlSortBy.value = HdnSortBy.value;
                }
                else {
                    for (var i = 0; i <= chkColumns.length - 1; i++) {
                        for (var l = 0; l <= ddlSortBy.length - 1; l++) {
                            if (ddlSortBy.options[l].text == chkColumnsTextArr[i].innerHTML) {
                                ddlSortBy.remove(l);
                                chkColumns[i].checked = false;
                            }
                        }
                    }
                    HdnSortBy.value = "none";
                }
            }
            function ChkcontactsInfoAll() {

                var Chk_contacts = document.getElementById("<%=Chk_contacts.ClientID%>");
                var chk_contactsList = getName('<%=chk_contactsList.ClientID %>');

                if (Chk_contacts.checked) {
                    for (var i = 0; i < chk_contactsList.length; i++) {
                        chk_contactsList[i].disabled = false;
                        chk_contactsList[i].checked = true;
                    }
                }
                else {
                    for (var i = 0; i < chk_contactsList.length; i++) {
                        chk_contactsList[i].checked = false;
                    }
                }
            }
            function ChkDeptInfoAll() {

                var Chk_Department = document.getElementById("<%=Chk_Department.ClientID%>");
                var Chk_DepartmentList = getName('<%=Chk_DepartmentList.ClientID %>');

                if (Chk_Department.checked) {
                    for (var i = 0; i < Chk_DepartmentList.length; i++) {
                        Chk_DepartmentList[i].disabled = false;
                        Chk_DepartmentList[i].checked = true;
                    }
                }
                else {
                    for (var i = 0; i < Chk_DepartmentList.length; i++) {
                        Chk_DepartmentList[i].checked = false;
                    }
                }
            }

            function ChkAddressInfoAll() {

                var Chk_address = document.getElementById("<%=Chk_address.ClientID%>");
                var Chk_addressList = getName('<%=Chk_addressList.ClientID %>');

                if (Chk_address.checked) {
                    for (var i = 0; i < Chk_addressList.length; i++) {
                        Chk_addressList[i].disabled = false;
                        Chk_addressList[i].checked = true;
                    }
                }
                else {
                    for (var i = 0; i < Chk_addressList.length; i++) {
                        //Chk_addressList[i].disabled = true;
                        Chk_addressList[i].checked = false;
                    }
                }
            }

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

                                    var val = CompID + "Ѣ" + txtval;
                                    PageMethods.GetClientName(val, FindSuccCName);
                                }
                                break;
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
            }


            function FindSuccCName(result) {
                //alert(result);
                if (trim12(result) != '') {
                    showddl('divCheck');
                    var divCheck = document.getElementById("divCheck");

                    var str_prop1 = result.split('է');
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
                txtName.value = ClientName;
                hid_ClientID.value = ClientID;
            }
            //********** End Of web service to autocomplete clientname *********//



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
        <script type="text/javascript">
            function printView() {
                window.print();
            }
        </script>
        <script>
            function GetSummaryDetails() {
                document.getElementById("divDetails").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_chkColumns1_3").checked = true;
                document.getElementById("ctl00_ContentPlaceHolder1_chkColumns1_4").checked = true;
            }
            function GetDetails() {
                document.getElementById("divDetails").style.display = "block";
            }
            function SummaryorDetialsSelectnone() {
                document.getElementById("ctl00_ContentPlaceHolder1_rdodetail").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rdosummary").checked = false;
            }

            function getInnerHtml() {
                var element = document.getElementById("divexport1");
                document.getElementById('<%=hdnInnerHtml.ClientID%>').value = element.innerHTML;
            }

            function OnCheckShowConverted() {

                var chkContactDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkContactDateOption");
                var txtFromDate = document.getElementById("<%=txtfromdate_converted.ClientID %>");
                var txtToDate = document.getElementById("<%=txttodate_converted.ClientID %>");

                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_c");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlContactDateOption");
                var ddlvalue = ddlConvertedJobCreated.options[ddlConvertedJobCreated.selectedIndex].value;
                if (chkContactDateOption.checked) {
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

            function checkdates() {

                var divdates = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddldates");
                var chkContactDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkContactDateOption");
                if (chkContactDateOption.checked == true && chkContactDateOption.checked == true) {
                    divdates.style.display = 'block';
                }
                else {
                    divdates.style.display = 'none';
                }
            }

            function EnableContactDateOption() {
                var chkContactDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkContactDateOption");
                var ddlContactJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlContactDateOption");
                var txtFromDate = document.getElementById("<%=txtfromdate_converted.ClientID %>");
                var txtToDate = document.getElementById("<%=txttodate_converted.ClientID %>");
                if (chkContactDateOption.checked) {
                    for (var i = 0; i < ddlContactJobCreated.length; i++) {
                        ddlContactJobCreated.disabled = false;

                    }
                }
                else {
                    for (var i = 0; i < ddlContactJobCreated.length; i++) {
                        ddlContactJobCreated.disabled = true;
                        txtFromDate.disabled = true;
                        txtToDate.disabled = true;
                    }
                }
            }
            function EnableNoActivityinPast() {
                var chkNoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkNoActivityinPast");
                var ddl_NoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddl_NoActivityinPast");
                var chk_Estimate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Estimate");
                var chk_Job = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Job");
                var txtFromDate = document.getElementById("<%=txtNoActivityinPastFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtNoActivityinPastTodate.ClientID %>");
                var chkestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkestimatevaluerange");
                var chkjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkjobvaluerange");
                var tbActivity = document.getElementById("tbActivity");
                //tbActivity.style.width = "722px";
                if (chkNoActivityinPast.checked) {
                    chkestimatevaluerange.checked = false;
                    chkjobvaluerange.checked = false;
                }

                if (chkNoActivityinPast.checked) {
                    checkuncheck();
                    ddl_NoActivityinPast.disabled = false;
                    chk_Estimate.disabled = false;
                    chk_Job.disabled = false; //chk_Job.disabled = false;
                    txtFromDate.disabled = false;
                    txtToDate.disabled = false;
                    tbActivity.style.width = "728px";
                    if (chk_Estimate.checked == false && chk_Job.checked == false) {
                        chk_Estimate.checked = true;
                    }
                } else {
                    ddl_NoActivityinPast.disabled = true;
                    chk_Estimate.checked = false;
                    chk_Job.checked = false;
                    chk_Estimate.disabled = true;
                    chk_Job.disabled = true;
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                    if (Checkbox_value == 'true') {
                        tbActivity.style.width = "728px";
                    }
                    else {
                        tbActivity.style.width = "722px";
                    }
                }
            }

            function OnCheckShowNoActivityinPast() {

                var chkContactDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkNoActivityinPast");
                var txtFromDate = document.getElementById("<%=txtNoActivityinPastFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtNoActivityinPastTodate.ClientID %>");

                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_Spnpast30days");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddl_NoActivityinPast");
                var ddlvalue = ddlConvertedJobCreated.options[ddlConvertedJobCreated.selectedIndex].value;
                if (chkContactDateOption.checked) {
                    if (ddlvalue == "30") {
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

            function Enableestimatevaluerange() {

                var chkestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkestimatevaluerange");
                var ddlestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlestimatevaluerange");
                var txtestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtestimatevaluerange");
                var ddlestimatevaluedaterange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlestimatevaluedaterange");
                var txtFromDate = document.getElementById("<%=txtestvalueFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtestvalueTodate.ClientID %>");
                var chkNoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkNoActivityinPast");
                var chkjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkjobvaluerange");


                if (chkestimatevaluerange.checked) {
                    chkNoActivityinPast.checked = false;
                    chkjobvaluerange.checked = false;
                }


                if (chkestimatevaluerange.checked) {
                    checkuncheck();
                    ddlestimatevaluerange.disabled = false;
                    txtestimatevaluerange.disabled = false;
                    ddlestimatevaluedaterange.disabled = false;
                    if (txtestimatevaluerange.value == "") {
                        txtestimatevaluerange.value = "0.00";
                    }

                } else {
                    ddlestimatevaluerange.disabled = true;
                    txtestimatevaluerange.disabled = true;

                    ddlestimatevaluedaterange.disabled = true;
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }

            function Enablejobvaluerange() {

                var chkjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkjobvaluerange");
                var ddljobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddljobvaluerange");
                var txtjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_txtjobvaluerange");
                var ddljobvaluedaterange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddljobvaluedaterange");
                var txtFromDate = document.getElementById("<%=txtjobvalueFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtjobvalueTodate.ClientID %>");
                var chkestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkestimatevaluerange");
                var chkNoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkNoActivityinPast");


                if (chkjobvaluerange.checked) {
                    chkestimatevaluerange.checked = false;
                    chkNoActivityinPast.checked = false;
                }

                if (chkjobvaluerange.checked) {
                    checkuncheck();
                    for (var i = 0; i < ddljobvaluerange.length; i++) {
                        ddljobvaluerange.disabled = false;
                        txtjobvaluerange.disabled = false;
                        if (txtjobvaluerange.value == "") {
                            txtjobvaluerange.value = "0.00";
                        }
                        ddljobvaluedaterange.disabled = false;
                    }
                } else {
                    ddljobvaluerange.disabled = true;
                    txtjobvaluerange.disabled = true;
                    ddljobvaluedaterange.disabled = true;
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }

            function OnCheckShowestimatevalue() {
                var chkContactDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkestimatevaluerange");
                var txtFromDate = document.getElementById("<%=txtestvalueFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtjobvalueTodate.ClientID %>");

                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnestvaluecurrentmonth");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlestimatevaluedaterange");
                var ddlvalue = ddlConvertedJobCreated.options[ddlConvertedJobCreated.selectedIndex].value;
                if (chkContactDateOption.checked) {
                    if (ddlvalue == "current month") {
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

            function OnCheckShowjobvaluerange() {
                var chkjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkjobvaluerange");
                var txtFromDate = document.getElementById("<%=txtjobvalueFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtestvalueTodate.ClientID %>");

                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjobvaluecurrentmonth");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddljobvaluedaterange");
                var ddlvalue = ddlConvertedJobCreated.options[ddlConvertedJobCreated.selectedIndex].value;
                if (chkjobvaluerange.checked) {
                    if (ddlvalue == "current month") {
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

            function GetContactDropdownBind() {

                var txtFromDate = document.getElementById("<%=txtfromdate_converted.ClientID %>");
                var txtToDate = document.getElementById("<%=txttodate_converted.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_daily_c");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_yest_c");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_month_c");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_quarter_c");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_year_c");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divjobdate_c");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastque_c");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn__halfyear_c");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_c");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastmonth_c");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_c");
                var spnContactDateOption_AnnualYear = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_ddlContactDateOption_annualYear");
                var ddlConvertedJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlContactDateOption");
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
                    spnContactDateOption_AnnualYear.style.display = "block";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
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
                    spnContactDateOption_AnnualYear.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }

            function NoActPast_Estimate_ChkBx() {
                var chk_Job = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Job");
                chk_Job.checked = false;
            }
            function NoActPast_Job_ChkBx() {
                var chk_Estimate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Estimate");
                chk_Estimate.checked = false;
            }
            var Checkbox_value = 'false'
            function GetNoActivityinPastDropdownBind() {

                var txtFromDate = document.getElementById("<%=txtNoActivityinPastFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtNoActivityinPastTodate.ClientID %>");
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divNoActivityinPastFromdaterange");
                var ddlNoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddl_NoActivityinPast");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_Spnpast30days");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_Spanpast45days");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_Spnpast60days");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_Spnpast90days");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_Spnpast120days");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_Spnpast365days");
                var spndays = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spndays");
                var ddlvalue = ddlNoActivityinPast.options[ddlNoActivityinPast.selectedIndex].value;
                var tbActivity = document.getElementById("tbActivity");
                if (ddlvalue == "daterange") {
                    spn_1.style.display = "block";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spndays.style.display = "none";
                    txtFromDate.disabled = false;
                    txtToDate.disabled = false;
                    tbActivity.style.width = "716px";
                    Checkbox_value = 'true'
                }
                else if (ddlvalue == "30") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "block";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spndays.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                    tbActivity.style.width = "730px";
                    Checkbox_value = 'true'
                }
                else if (ddlvalue == "45") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "block";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spndays.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                    tbActivity.style.width = "730px";
                    Checkbox_value = 'true'
                }
                else if (ddlvalue == "60") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "block";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spndays.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                    tbActivity.style.width = "730px";
                    Checkbox_value = 'true'
                }
                else if (ddlvalue == "90") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "block";
                    spn_6.style.display = "none";
                    spn_7.style.display = "none";
                    spndays.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                    tbActivity.style.width = "730px";
                    Checkbox_value = 'true'
                }
                else if (ddlvalue == "120") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "block";
                    spn_7.style.display = "none";
                    spndays.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                    tbActivity.style.width = "730px";
                    Checkbox_value = 'true'
                }
                else if (ddlvalue == "365") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    spn_6.style.display = "none";
                    spn_7.style.display = "block";
                    spndays.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                    tbActivity.style.width = "730px";
                    Checkbox_value = 'true'
                }

            }

            function GetestimatevaluerangetDropdownBind() {
                var txtFromDate = document.getElementById("<%=txtestvalueFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtestvalueTodate.ClientID %>");
                var ddlestimatevaluedaterange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddlestimatevaluedaterange");
                var ddlvalue = ddlestimatevaluedaterange.options[ddlestimatevaluedaterange.selectedIndex].value;
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divestimatevaluedaterange");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnestvaluecurrentmonth");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnestvaluelastmonth");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_est");

                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_est");


                if (ddlvalue == "current month") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "block";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";

                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "last month") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "block";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";

                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daterange") {
                    spn_1.style.display = "block";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";

                    txtFromDate.disabled = false;
                    txtToDate.disabled = false;
                }
                else if (ddlvalue == "lastweek") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "block";
                    spn_5.style.display = "none";

                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "block";

                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }

            function GetjobvaluedaterangetDropdownBind() {
                var txtFromDate = document.getElementById("<%=txtjobvalueFromdate.ClientID %>");
                var txtToDate = document.getElementById("<%=txtjobvalueTodate.ClientID %>");
                var ddljobvaluedaterange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_ddljobvaluedaterange");
                var ddlvalue = ddljobvaluedaterange.options[ddljobvaluedaterange.selectedIndex].value;
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_divjobvaluedaterange");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjobvaluecurrentmonth");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spnjobvaluelastmonth");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastweek_job");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_spn_lastyear_job");
                if (ddlvalue == "current month") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "block";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "last month") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "block";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "daterange") {
                    spn_1.style.display = "block";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "none";
                    txtFromDate.disabled = false;
                    txtToDate.disabled = false;
                }
                else if (ddlvalue == "lastweek") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "block";
                    spn_5.style.display = "none";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
                else if (ddlvalue == "lastyear") {
                    spn_1.style.display = "none";
                    spn_2.style.display = "none";
                    spn_3.style.display = "none";
                    spn_4.style.display = "none";
                    spn_5.style.display = "block";
                    txtFromDate.disabled = true;
                    txtToDate.disabled = true;
                }
            }
            function checkuncheck() {
                var chkNoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkNoActivityinPast");
                var chkestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkestimatevaluerange");
                var chkjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkjobvaluerange");
                if (chkNoActivityinPast.checked) {
                    Enablejobvaluerange();
                    Enableestimatevaluerange();
                }
                if (chkestimatevaluerange.checked) {
                    Enablejobvaluerange();
                    EnableNoActivityinPast();
                }
                if (chkjobvaluerange.checked) {
                    EnableNoActivityinPast();
                    Enableestimatevaluerange();
                }
            }

            function pageloadcheck() {
                var chk_Estimate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Estimate");
                var chk_Job = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Job");
                chk_Estimate.disabled = true;
                chk_Job.disabled = true;
            }


        </script>
        <script>
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
                var estno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                if (estno.checked == false) {
                    alert('Please check Company name to generate report');
                    return false;
                }

                if (chkDateOption.checked) {
                    var spndateRange = document.getElementById("spndateRange");
                    for (var i = 0; i < radio.length; i++) {
                        if (radio[i].checked) {
                            if (radio[i].value == "daterange") {


                                if (txtFromDate.value == "" || txtToDate.value == "") {
                                    document.getElementById("spn_txtFromDate").innerHTML = '<%=objLangClass.GetLanguageConversion("Please_Enter_A_Valid_Date")%>';
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

            function funcCaller() {
                if (!CheckDateFormat()) {
                    return false;
                }
                else {
                    if (document.getElementById("ds00") != null)
                        document.getElementById("ds00").style.display = "block";
                    if (document.getElementById("div_Load") != null)
                        document.getElementById("div_Load").style.display = "block";
                    return true;
                }
            }


            function Disablelnk() { }

            function GetSelect() {
                var chkAggCustomer = document.getElementById("<%=chkAggCustomer.ClientID%>");
                var chkAggCustomeritems = getName("<%=chkAggCustomeritems.ClientID%>");
                var x = 0, y = 0, z = 0;
                for (var i = 0; i < chk.length; i++) {
                    if (chk[i].checked == true) {
                        x++;
                    }
                }
                for (var i = 0; i < chk1.length; i++) {
                    if (chk1[i].checked == true) {
                        z++;
                    }
                }

                if (z == chk1.length) {
                    document.getElementById("lnkSelectAll1").innerHTML = "Select None";
                }
                else {
                    document.getElementById("lnkSelectAll1").innerHTML = "Select All";
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
                }
                if (chkAggCustomer.checked) {
                    for (var i = 0; i < chkAggCustomeritems.length; i++) {
                        if (chkAggCustomeritems[i].checked == true)
                            chkAggCustomeritems[i].checked = true;
                        else
                            chkAggCustomeritems[i].checked = false;
                    }
                }
                GetContactDropdownBind();
                GetDropdownBind();
                EnableContactDateOption();
                EnableDateOption();
                EnableNoActivityinPast();
                Enableestimatevaluerange();
                Enablejobvaluerange();
                GetNoActivityinPastDropdownBind();
                GetestimatevaluerangetDropdownBind();
                GetjobvaluedaterangetDropdownBind();
                SortDropDownBind();
            }
            function SortDropDownBind() {

                var chkColumns = getName('<%=chkColumns.ClientID %>');
                var chkColumnsBoxList = document.getElementById("<%=chkColumns.ClientID%>")
                var chklistArr = chkColumnsBoxList.getElementsByTagName("input");
                var chkColumnsTextArr = chkColumnsBoxList.getElementsByTagName("label");
                var chkAggCustomer = document.getElementById("<%=chkAggCustomer.ClientID%>");
                var chkAggCustomeritems = getName("<%=chkAggCustomeritems.ClientID%>");
                var chkColumnsBoxList_Agg = document.getElementById("<%=chkAggCustomeritems.ClientID%>")
                var chklistArr_Agg = chkColumnsBoxList_Agg.getElementsByTagName("input");
                var chkColumnsTextArr_Agg = chkColumnsBoxList_Agg.getElementsByTagName("label");
                ddlSortBy.remove(1);
                for (var i = 0; i < chkColumns.length - 1; i++) {
                    var option = document.createElement("option");
                    if (i == 0) {
                        option.text = "Company Name";
                        option.value = "CompanyName";
                    }
                    else if (i == 1) {
                        option.text = "Company Type";
                        option.value = "CompanyType";
                    }
                    else if (i == 2) {
                        option.text = "Type";
                        option.value = "Type";
                    }
                    else if (i == 3) {
                        option.text = "Account Status";
                        option.value = "AccountStatus";
                    }
                    else if (i == 4) {
                        option.text = "Account Number";
                        option.value = "AccountNo";
                    }
                    else if (i == 5) {
                        option.text = "Email";
                        option.value = "Email";
                    }
                    else if (i == 6) {
                        option.text = "URL";
                        option.value = "URL";
                    }
                    else if (i == 7) {
                        option.text = "Credit Limit";
                        option.value = "CreditLimit";
                    }
                    else if (i == 8) {
                        option.text = "Credit Ref";
                        option.value = "CreditRef";
                    }
                    else if (i == 9) {
                        option.text = "Tax";
                        option.value = "Tax1";
                    }
                    else if (i == 10) {
                        option.text = "Description";
                        option.value = "Description";
                    }
                    else if (i == 11) {
                        option.text = "Payment Terms";
                        option.value = "PaymentTerms";
                    }
                    else if (i == 12) {
                        option.text = "Profit Margin";
                        option.value = "ProfitMargin";
                    }
                    else if (i == 13) {
                        option.text = "Tax Reg No";
                        option.value = "TaxRegNo";
                    }
                    else if (i == 14) {
                        option.text = "Company Number";
                        option.value = "CompanyNumber";
                    }
                    else if (i == 15) {
                        option.text = "A/C Opened";
                        option.value = "ACOpened";
                    }
                    else if (i == 16) {
                        option.text = "Bank Code";
                        option.value = "BankCode";
                    }
                    else if (i == 17) {
                        option.text = "Bank Account Number";
                        option.value = "BankAccountNumber";
                    }
                    else if (i == 18) {
                        option.text = "Account Name";
                        option.value = "AccountName";
                    }
                    else if (i == 19) {
                        option.text = "Sales Person";
                        option.value = "SalesPerson";
                    }
                    else if (i == 20) {
                        option.text = "Referred By";
                        option.value = "name";
                    }
                    else if (i == 21) {
                        option.text = "eStore Name";
                        option.value = "eStoreName";
                    }
                    else if (i == 22) {
                        option.text = "Open Tasks & Calls";
                        option.value = "OpenTasksCalls";
                    }
                    else if (i == 23) {
                        option.text = "Royality Free";
                        option.value = "RoyalityFree";
                    }
                    if (chklistArr[i].checked) {
                        ddlSortBy.options.add(option);
                    }
                }
                for (var i = 0; i <= chkAggCustomeritems.length - 1; i++) {
                    var option_Aggr = document.createElement("option");
                    if (i == 0) {
                        option_Aggr.text = "Total Estimate";
                        option_Aggr.value = "TotalEstimate";
                    }
                    else if (i == 1) {
                        option_Aggr.text = "Estimate Value Ex. Tax";
                        option_Aggr.value = "EstimateValue";
                    }
                    else if (i == 2) {
                        option_Aggr.text = "Total Job";
                        option_Aggr.value = "TotalJob";
                    }
                    else if (i == 3) {
                        option_Aggr.text = "Job Value Ex. Tax";
                        option_Aggr.value = "JobValue";
                    }
                    else if (i == 4) {
                        option_Aggr.text = "Total Invoice";
                        option_Aggr.value = "TotalInvoice";
                    }
                    else if (i == 5) {
                        option_Aggr.text = "Invoice Value Ex. Tax";
                        option_Aggr.value = "InvoiceValue";
                    }
                    else if (i == 6) {
                        option_Aggr.text = "Estimate - Job conversion count (%)";
                        option_Aggr.value = "EstimateJobconversioncount";
                    }
                    else if (i == 7) {
                        option_Aggr.text = "Estimate - Job conversion value (%)";
                        option_Aggr.value = "EstimateJobconversionvalue";
                    }
                    if (chklistArr_Agg[i].checked) {
                        ddlSortBy.options.add(option_Aggr);
                    }
                }
                ddlSortBy.value = HdnSortBy.value;
            }
            function OnEditReport() {
                GetContactDropdownBind();
                GetDropdownBind();
                EnableContactDateOption();
                EnableDateOption();
                checkdates();
                EnableNoActivityinPast()
                Enableestimatevaluerange();
                Enablejobvaluerange();
                GetNoActivityinPastDropdownBind();
                GetestimatevaluerangetDropdownBind();
                GetjobvaluedaterangetDropdownBind();
                SortDropDownBind();
            }

        </script>
        <asp:Panel ID="pnlMask" runat="server" Visible="false">
            <script type="text/javascript">
                if (document.getElementById("ds00") != null)
                    document.getElementById("ds00").style.display = "block";
                if (document.getElementById("div_Load") != null)
                    document.getElementById("div_Load").style.display = "block";

            </script>
        </asp:Panel>
        <script language="javascript" type="text/javascript">
            function setLoadingPosition() {
                if (document.getElementById("ds00") != null)
                    document.getElementById("ds00").style.display = "block";
                if (ocument.getElementById("div_Load") != null)
                    document.getElementById("div_Load").style.display = "block";
            }
            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        </script>
        <script language="javascript" type="text/javascript">

            function Runvalidate() {//chk_Estimate chk_Job

                var estno = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_0');
                var chkEstimate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Estimate");
                var chk_Job = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chk_Job");
                var chkNoActivityinPast = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkNoActivityinPast");
                var chkestimatevaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkestimatevaluerange");
                var chkAggCustomeritems = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkAggCustomeritems_1");
                var chkAggCustomeritems_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkAggCustomeritems_3");
                var chkjobvaluerange = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkjobvaluerange");
                var count = 0;
                var chkDateOption = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i2_chkDateOption");

                for (var j = 0; j < Chk_contacts.length; j++) {
                    if (document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chk_contactsList_" + [j]).checked) {
                        count++;
                    }
                }
                if (estno.checked == false) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_check_Company_name_to_generate_report")%>');
                    return false;
                }
                else if (chkEstimate.checked == false && chk_Job.checked == false && chkNoActivityinPast.checked == true) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_check_atleast_one_checkbox_in_No_Activity_in_Past_to_generate_report")%>');
                    return false;
                }

                //                else if (chkestimatevaluerange.checked == true && chkAggCustomeritems.checked == false) {
                //                    //alert("Please check value checkbox in aggregate column to generate report");
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Estimate_Value_Inc_Tax_Checkbox_Column_To_Generate_Report")%>');
                //                    return false;
                //                }

                // && chkAggCustomeritems.checked == true
                //                else if (chkestimatevaluerange.checked == true && count == 0) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Select_Atleast_One_Checkbox_In_Contacts_Column_To_Generate_Report")%>');
                //                    return false;
                //                }

                //                else if (chkAggCustomeritems_3.checked == false && chkjobvaluerange.checked == true) {
                //                    //alert("Please check Job Value Inc.Tax checkbox in aggregate coloumn to generate report");
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Job_Value_Inc_Tax_Checkbox_Column_To_Generate_Report")%>');
                //                    return false;
                //                }

                // && chkjobvaluerange.checked == true
                //                else if (chkAggCustomeritems_3.checked == true && count == 0) {
                //                    alert('<%=objLangClass.GetLanguageConversion("Please_Select_Atleast_One_Checkbox_In_Contacts_Column_To_Generate_Report")%>');
                //                    return false;
                //                }



            }
        </script>
    </div>
</asp:Content>


