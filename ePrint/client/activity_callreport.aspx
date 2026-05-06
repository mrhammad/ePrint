<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activity_callreport.aspx.cs" Inherits="ePrint.client.activity_callreport" %>--%>

<%@ page title="Call Report" language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="activity_callreport.aspx.cs" Inherits="ePrint.client.activity_callreport" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/pagingreport.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Savereport" Src="~/usercontrol/Reports.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="reports">
        <script type="text/javascript">

            var div_Load = document.getElementById("div_Load");
            document.getElementById("div_Load").style.display = "block";
        </script>
        <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
            rel="stylesheet" />
        <script src="<%=strSitepath %>js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
        <script src="<%=strSitepath %>js/jquery.ui.tabs.js" type="text/javascript"></script>
        <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
        <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%=VersionNumber%>'"></script>
        <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%#VersionNumber%>'"></script>
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
            .chkBoxListEst td
            {
                width: 27%;
            }
        </style>
        <div id="div_option" runat="server" class="act_width100">
            <div class="navigatorpanel">
            </div>
            <div id="div_header" class="navigatorpanel" runat="server">
            </div>
            <div id="divtab" runat="server">
                <div class="show_hide">
                    <div class="actmaintab">
                        <div id="div_SR" class="SummaryTabs actsavedtab">
                            <b><span id="spn_1" onclick="Activity_Call_Report(this.id);">Saved Reports </span>
                            </b>
                        </div>
                        <div id="div_CR" class="SummaryTabs actsavedtab">
                            <b><span id="spn_2" onclick="Activity_Call_Report(this.id);">Customize Reports</span></b>
                        </div>
                        <div id="waitmessage" class="ClientWaitTab">
                            &nbsp;&nbsp;<table cellpadding="0" cellspacing="10">
                                <tr>
                                    <td class="actimghour">
                                        <div class="mainheader">
                                            <asp:Image ID="imgHourglass" runat="server" ImageUrl="~/images/loading_new.gif" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div id="tabs" style="width: 98%; border: solid 0px red; visibility: hidden; padding-top: 3px;
                    padding-left: 7px" class="ui-tabs">
                    <ul id="test-1" style="list-style: none; height: auto; background-color: #FFFFFF;
                        border-left: 1px solid transparent; border-right: 1px solid transparent; border-top: 1px solid transparent;
                        border-radius: 0px; width: 97.4%; border-bottom: 1px solid transparent; margin-left: 5px;">
                        <li style="margin-left: -5px"><a id="A1" href="#tabs-1" onclick="Activity_Call_Report(this.id);">
                            <b>
                                <%=objLangClass.GetLanguageConversion("Saved_Reports")%></b></a></li>
                        <li><a id="A2" href="#tabs-2" onclick="Activity_Call_Report(this.id);"><b>
                            <%=objLangClass.GetLanguageConversion("Customize_Reports")%></b></a></li>
                    </ul>
                    <div id="tabs-1" class="ui-tabs-hide">
                        <div id="divusrReportsave" runat="server" class="report_savedtab" style="border: 1px solid rgb(170, 170, 170);">
                            <UC:Savereport ID="usrReportsave" runat="server" />
                        </div>
                    </div>
                    <div id="tabs-2" class="ui-tabs-hide">
                        <div id="div_showfilters" class="TelerikPaneDiv act_width100" runat="server">
                            <div id="padding" class="report_customizetab">
                                <div>
                                    <div id="div_Error" align="center" class="act_msg">
                                        <span id="spnError" runat="server" class="spanerrorMsg act_selectallcol">
                                            <%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Column_To_Generate_Report")%></span></div>
                                    <div class="act_selecttab">
                                        <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="950px" Height="100%"
                                            Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                                            <Items>
                                                <telerik:RadPanelItem Text="Select Columns to Run Report" Font-Bold="true" Expanded="true"
                                                    CssClass="rounded-ReportTopcorners" Selected="true">
                                                    <ContentTemplate>
                                                        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
                                                            <telerik:RadPageView runat="server" ID="RadPageView1">
                                                                <div class="act_selectall">
                                                                    <div align="left">
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <div class="act_selectalltxt">
                                                                                        <a href="javascript:SelectAll();" id="lnkSelectAll" style="font-size: 0.8em;">
                                                                                            <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <div class="act_chkcols">
                                                                                        <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                            Width="700px" CssClass="chkBoxListEst">
                                                                                        </asp:CheckBoxList>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
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
                                                                <div align="left" class="act_grpdiv1">
                                                                    <div align="left" class="act_grpdiv2">
                                                                        <div align="left">
                                                                            <div class="bgReportlabel act_width175">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Group_The_Records_By")%></span></div>
                                                                            <div class="act_left5px">
                                                                                &nbsp;</div>
                                                                            <div class="act_floatleft">
                                                                                <asp:DropDownList ID="ddlGrouprecords" runat="server" CssClass="normalText" Width="200px"
                                                                                    Height="20px">
                                                                                    <asp:ListItem Value="0" Text="None"></asp:ListItem>
                                                                                    <asp:ListItem Value="1" Text="Daily"></asp:ListItem>
                                                                                    <asp:ListItem Value="2" Text="Assigned To"></asp:ListItem>
                                                                                </asp:DropDownList>
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
                                                <telerik:RadPanelItem Text="Report Filters" Expanded="false" Font-Bold="true" CssClass="rounded-ReportTopcorners">
                                                    <ContentTemplate>
                                                        <telerik:RadMultiPage runat="server" ID="RadMultiPage3" SelectedIndex="0">
                                                            <telerik:RadPageView runat="server" ID="RadPageView3">
                                                                <div class="FilterJob">
                                                                    <div align="left">
                                                                        <span id="Span2" runat="server" class="smallgraytext act_paddingleft5px">(<%=objLangClass.GetLanguageConversion("Date_Filter_applied_on_Customer_Call_Craeted_Date")%>
                                                                            )</span>
                                                                        <table class="act_filtertable">
                                                                            <tr>
                                                                                <td class="act_filtertabletd1">
                                                                                    <asp:CheckBox ID="chkDateOption" runat="server" Text="Date Options" onclick="javascript:EnableCallDateOption();OnCallCheckShow()" />
                                                                                </td>
                                                                                <td align="right">
                                                                                    <asp:DropDownList ID="rdlDate" Enabled="false" runat="server" CssClass="normalText"
                                                                                        Width="200px" Height="20px" onChange="javascript:GetCallDropdownBind();OnCallCheckShow();">
                                                                                        <asp:ListItem Text="Today" Value="daily"></asp:ListItem>
                                                                                        <asp:ListItem Text="Select Date" Value="daterange"></asp:ListItem>

                                                                                           <asp:ListItem Text="Yesterday" Value="yesterday"></asp:ListItem>
                                                                                         <asp:ListItem Text="Current Month" Value="thismonth" Selected="true"></asp:ListItem>
                                                                                         <asp:ListItem Text="Current Quarter" Value="thisquarter"></asp:ListItem>
                                                                                        <asp:ListItem Text="Current Year" Value="thisannualyear"></asp:ListItem>
                                                                                         <asp:ListItem Text="Last Quarter" Value="lastquater"></asp:ListItem>
                                                                                          <asp:ListItem Text="Last Week" Value="lastweek"></asp:ListItem>
                                                                                             <asp:ListItem Text="Last Month" Value="lastmonth"></asp:ListItem>
                                                                                             <asp:ListItem Text="Last Year" Value="lastyear"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="act_width250px">
                                                                                    <span id="spn_daily" runat="server" class="smallgraytext show_hide">(26/10/2009)</span>

                                                                                     <span id="spn_yest" style="display: none" runat="server" class="smallgraytext">(25/10/2009)</span> 
                                                                                <span id="spn_month" runat="server" style="display: none"
                                                                                    class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                    <span id="spn_quarter"
                                                                                        runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span>
                                                                                <span id="spn_lastque" runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span> 

                                                                                      <span id="spn_lastweek" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 7/10/2009)</span>
                                                                                        <span id="spn_lastmonth" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span>
                                                                                        <span id="spn_lastyear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    <span id="spndlDate_AnnualYear" runat="server" style="display: none" class="smallgraytext">(1/1/2009 to 30/12/2009)</span>
                                                                                    <div align="left" id="divcalldate" runat="server" class="show_hide">
                                                                                        <asp:TextBox ID="txtFrom" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox><span
                                                                                            class="normalText">&nbsp;<%=objLangClass.GetLanguageConversion("To")%>&nbsp;</span><asp:TextBox
                                                                                                ID="txtTo" runat="server" SkinID="textPad" Width="100px" Enabled="false"></asp:TextBox>
                                                                                        <span id="spn_txtFromDate" class="spanerrorMsg act_spandate">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="spn_txtToDate" class="spanerrorMsg act_spndate1">
                                                                                            <%=objLangClass.GetLanguageConversion("Please_Enter_Req_Date")%>
                                                                                        </span><span id="spndateRange" class="spanerrorMsg show_hide">
                                                                                            <%=objLangClass.GetLanguageConversion("Date_Range_Is_Not_In_Correct_Format")%></span>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                    <div align="left" class="act_grpdiv1 actvity_margin4px">
                                                                        <div>
                                                                            <div class="bgReportlabel act_width175">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Calls")%></span></div>
                                                                            <div class="act_left5px">
                                                                                &nbsp;</div>
                                                                            <div class="mainheader">
                                                                                <asp:DropDownList ID="ddlCalls" runat="server" CssClass="normalText" Width="200px"
                                                                                    Height="20px">
                                                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="All"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="Completed"></asp:ListItem>
                                                                                    <asp:ListItem Text="" Value="OverDue"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <%--  <div class="onlyEmpty">
                                                                    </div>--%>
                                                                    </div>
                                                                    <div align="left" class="act_grpdiv1" style="margin-left: 4px">
                                                                        <div align="left">
                                                                            <div class="bgReportlabel act_width175">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Free_Text")%></span></div>
                                                                            <div class="act_left5px">
                                                                                &nbsp;</div>
                                                                            <div style="float: left;">
                                                                                <asp:TextBox ID="txtFreeText" runat="server" SkinID="textPad" MaxLength="255" Width="200px"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="bgReportlabel act_width175">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Select_Filelds_to_be_searched")%></span>
                                                                        </div>
                                                                        <div style="float: left;">
                                                                            <asp:CheckBoxList ID="chkFreeText" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                Width="480px">
                                                                                <asp:ListItem Text="" Value="CompanyName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="ContactName"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="SalesPerson"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="AssignedTo"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Subject"></asp:ListItem>
                                                                                <asp:ListItem Text="" Value="Description"></asp:ListItem>
                                                                            </asp:CheckBoxList>
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
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
                                                                    <div align="left" class="act_reportname">
                                                                        <div align="left">
                                                                            <div class="bgReportlabel act_width175">
                                                                                <span class="HeaderText">
                                                                                    <%=objLangClass.GetLanguageConversion("Report_Name")%></span>&nbsp;<span class="act_reportnamevalidate">*</span>
                                                                            </div>
                                                                            <div class="act_left5px">
                                                                                &nbsp;</div>
                                                                            <div class="act_floatleft">
                                                                                <asp:TextBox ID="txtSaveReports" runat="server" SkinID="textPad" Width="200px" />
                                                                                <asp:HiddenField ID="hdn_reportID" runat="server" />
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left">
                                                                            <div class="bgReportlabel act_width175 lbl_height90">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Description")%></span></div>
                                                                            <div class="act_left5px">
                                                                                &nbsp;</div>
                                                                            <div class="act_floatleft">
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
                                            <div class="act_floatleft">
                                                <div class="autobtncancel">
                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick"
                                                        OnClientClick="javascript:loadingimage(this.id,'divcancelprocess');" />
                                                </div>
                                                <div id="divcancelprocess" class="show_hide">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div class="btnGaps">
                                                &nbsp;
                                            </div>
                                            <div class="act_floatleft">
                                                <div id="div_btnsave" class="autobtncancel">
                                                    <asp:Button ID="btnSaveRun" runat="server" Text="Save and Run" CssClass="button"
                                                        OnClick="btnSaveRun_OnClick" OnClientClick="javascript:var a=ActivityValidateCaller();if(a)loadingimage(this.id,'div_btnsaveprocess');return a;" />
                                                </div>
                                                <div id="div_btnsaveprocess" class="show_hide">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div class="btnGaps">
                                                &nbsp;
                                            </div>
                                            <div class="act_floatleftwidth">
                                                <div id="div_update" >
                                                    <asp:Button ID="btnUpdateExisting" runat="server" Text="Update Report" CssClass="button"
                                                        OnClick="btnUpdateExisting_OnClick" Visible="false" OnClientClick="javascript:var a=ActivityValidateCaller(); if(a)loadingimage(this.id,'div_btnUpdateProcess'); return a;" />
                                                </div>
                                                 <div id="div_btnUpdateProcess" class="show_hide">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
                                                </div>
                                            </div>
                                            <div class="act_floatleft">
                                                <div id="div_btnrunreport" class="autobtncancel">
                                                    <asp:Button ID="btnRunReport" runat="server" Text="Run Report" CssClass="button"
                                                        OnClick="btnRunReport_OnClick" OnClientClick="javascript:var a=Activity_Runvalidate();if(a!=false)loadingimage(this.id,'div_btnrunprocess');return a;" />
                                                </div>
                                                <div id="div_btnrunprocess" class="show_hide">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="trans" alt="loading" border="0" />
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
        <div align="left" class="act_width100">
            <div class="only5px">
            </div>
            <div id="divexport" runat="server">
                <div align="left" id="divtoolbar" runat="server" visible="false" class="DivButtonsHeader report_resultpanel">
                    <table border="0" class="act_width100">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td class="act_floatleft">
                                            &nbsp;
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip="Back to Search Option" ImageUrl="~/images/image_EM_b.png"
                                                ID="btnfilter" runat="server" Text="Back to Search Option" OnClick="btnfilter_OnClick"
                                                Visible="false" BackColor="Transparent" OnClientClick="javascript:return setLoadingPosition()" />
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip="Export (Presentation Format)" ImageUrl="~/images/xls-presentation.jpg"
                                                ID="btnExportPPT" runat="server" Text="Export" OnClick="btnExport_vivid_OnClick"
                                                OnClientClick="javascript:Activity_getInnerHtml();" Visible="true" BackColor="Transparent" />
                                        </td>
                                        <td class="act_floatleft">
                                            <asp:ImageButton ToolTip="Export (Excel Format)" ImageUrl="~/images/export-icon1.jpg"
                                                ID="btnExport" runat="server" Text="Export" OnClick="btnExport_New_OnClick" OnClientClick="javascript:Activity_getInnerHtml();"
                                                Visible="false" BackColor="Transparent" />
                                        </td>
                                        <td nowrap="nowrap">
                                            <UC:Paging ID="usrPaging" runat="server" />
                                        </td>
                                        <td align="left">
                                        </td>
                                        <td class="act_floatleft" nowrap="nowrap">
                                            <asp:TextBox ID="txt1" runat="server" CssClass="act_txtpage" Visible="false" onblur="javascript:AllowNumber(this,this.value)"></asp:TextBox>&nbsp;
                                        </td>
                                        <td>
                                            <asp:ImageButton ToolTip="Go To" ImageUrl="~/images/gotopage.gif" ID="btngo" runat="server"
                                                CssClass="Backgroung_imgbutton" OnClick="btngo_OnClick" Visible="false" BackColor="Transparent"
                                                OnClientClick="javascript:return setLoadingPosition();" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right">
                                <div id="div_Total" runat="server" visible="false" class="act_lbltotal">
                                    <span class="normalText">
                                        <%=objLangClass.GetLanguageConversion("Total_Records")%>:</span> <b>
                                            <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b></div>
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
                                RowStyle-VerticalAlign="Top" CellPadding="4" OnDataBound="GridCallReport_DataBound"
                                HeaderStyle-Height="50px">
                            </asp:GridView>--%>
                            <telerik:RadGrid ID="GridEstReport" Width="100%" runat="server" AllowAutomaticDeletes="false"
                ShowFooter="True" AllowAutomaticInserts="false" CssClass="RadGrid_Eprint_Skin"
                OnItemDataBound="GridCallReport_DataBound" AllowAutomaticUpdates="false" Skin="RadGrid_Eprint_Skin"
                AutoGenerateColumns="true" AllowFilteringByColumn="false" HeaderStyle-Font-Bold="true"
                AllowPaging="true" EnableEmbeddedSkins="false" PagerStyle-CssClass="RadComboBox_Eprint_Skin"
                OnPageIndexChanged="GridCall_PageIndexChanged" OnNeedDataSource="GridCall_OnNeedDataSource"
                OnPageSizeChanged="GridCall_PageSizeChanged" PageSize="50" Visible="false" EnableAjaxSkinRendering="true" EnableViewState="true">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true"></PagerStyle>
            </telerik:RadGrid>
                        </div>
                    </div>
                    <div>
                        <asp:PlaceHolder ID="plhdetails" runat="server"></asp:PlaceHolder>
                    </div>
                    <div class="onlyEmpty">
                        &nbsp;</div>
                </div>
            </div>
            <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                <div id="Div1" class="emptyrecords" align="center">
                    <span class="HeaderText txtcentre">
                        <%=objLangClass.GetLanguageConversion("No_Record_Found")%></span>
                </div>
            </asp:Panel>
            <div class="only5px">
            </div>
        </div>
        <asp:HiddenField ID="hdnInnerHtml" runat="server" />
        <script type="text/javascript">

            var CHK1 = document.getElementById("<%=chkColumns.ClientID%>");
            var chk = CHK1.getElementsByTagName("input");
            var lnkSelectAllcontact = document.getElementById("lnkSelectAllcontact");
            var lnkSelectAll = document.getElementById("lnkSelectAll");
            var lnkSelectAll1 = document.getElementById("lnkSelectAll1");
            var divchkEstimate = document.getElementById("divchkEstimate");
            var chkColumns = getName("<%=chkColumns.ClientID %>");
            var txtSaveReports = document.getElementById("<%=txtSaveReports.ClientID %>");
            var div_showfilters = document.getElementById("<%=div_showfilters.ClientID %>");
            var divusrReportsave = document.getElementById("<%=divusrReportsave.ClientID %>");

            function getName(RdID) {
                var Rdl = document.getElementById(RdID);
                var RdlName = Rdl.getElementsByTagName("input");
                return RdlName;
            }
        </script>
        <div class="onlyEmpty">
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <script>
                function getName(RdID) {
                    var Rdl = document.getElementById(RdID);
                    var RdlName = Rdl.getElementsByTagName("input");
                    return RdlName;
                }
            </script>
        </asp:Panel>
        <asp:Panel ID="pnlSavedReports" runat="server" Visible="false">
            <script type="text/javascript">

                Activity_Call_Report('spn_1');

            </script>
        </asp:Panel>
        <asp:Panel ID="pnlReports" runat="server" Visible="false">
            <script type="text/javascript">

                Activity_Call_Report('spn_2');

            </script>
        </asp:Panel>
        <asp:Panel ID="pnlMask" runat="server" Visible="false">
            <script type="text/javascript">
                document.getElementById("ds00").style.display = "block";
                document.getElementById("div_Load").style.display = "block";

            </script>
        </asp:Panel>
        <script language="javascript" type="text/javascript">
            function setLoadingPosition() {
                document.getElementById("ds00").style.display = "block";
                document.getElementById("div_Load").style.display = "block";
            }
            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";
        </script>
        <script>

            function loading() {
                CheckGrid();
                showWaitMessage();
            }

        </script>
    </div>
</asp:Content>
