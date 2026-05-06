<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/settingpage.master" AutoEventWireup="true" CodeBehind="dashboard_settings.aspx.cs" Inherits="ePrint.settings.dashboard_settings" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css" rel="stylesheet" />
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/jquery.ui.tabs.js" type="text/javascript"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
    <script language="javascript" type="text/javascript" src="<%=strSitepath %>js/Item/AutoFill.js?VN='<%#VersionNumber%>'"></script>
    <script src="../common/swazz_calendar.js" type="text/javascript"></script>
    <script src="../common/calendar.js" type="text/javascript"></script>

    <script type="text/javascript">
        Telerik.Web.UI.RadListBox.prototype.saveClientState = function () {
            return "{" +
                "\"isEnabled\":" + this._enabled +
                ",\"logEntries\":" + this._logEntriesJson +
                ",\"selectedIndices\":" + this._selectedIndicesJson +
                ",\"checkedIndices\":" + this._checkedIndicesJson +
                ",\"scrollPosition\":" + Math.round(this._scrollPosition) +
                "}";
        }
    </script>      

    <asp:UpdatePanel ID="UpLoad" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div id="divLoadingImageCus" runat="server" style="display: none;">
                <div id="DivLayer" class="DialogueBackgroundSurveyView">
                </div>
                <div align="center" style="position: absolute; z-index: 5555; left: 47%; top: 40%;">
                    <img src="<%=ImgPath %>loading_new.gif" border="0" style="border-radius: 2px;" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <style type="text/css">
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
            width: 27%;
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
            background-image: none !important;
        }

        .ddlComboBox .rcbInputCell .rcbInput {
            border: 1px solid #BFBFBF !important;
            margin-left: -2px !important;
            width: 185px !important;
            height: 18px !important;
        }

        .ddlComboBox .rcbInputCellLeft {
            background-image: none !important;
        }
    </style>


    <style type="text/css">
        .RadDock .rdTitleBar em {
            font-family: "Verdana",Verdana,Arial,Helvetica !important;
            font-size: 11px !important;
            float: left !important;
            padding: 0px !important;
            margin: 0px !important;
            text-overflow: ellipsis !important;
            overflow: hidden !important;
            white-space: nowrap !important;
            font-weight: bold !important;
            margin-left: 4px !important;
            color: White !important;
            min-width: 500px !important;
            margin-right: 4px !important;
        }

        #ctl00_ContentPlaceHolder1_rwReferences_C_ddlCustomers option {
            width: 250px;
        }

        #ctl00_ContentPlaceHolder1_rwReferences_C_ddlcompanyName1 option {
            width: 250px;
        }

        .RadDock_Default .rdTop .rdLeft, .RadDock_Default .rdTop .rdRight, .RadDock_Default .rdTop .rdCenter {
            background-image: url('');
            background-color: #B7B7B7;
            background: -webkit-linear-gradient(#B7B7B7,#313131);
            background: -moz-linear-gradient(#B7B7B7,#313131);
            background: -o-linear-gradient(#B7B7B7,#313131);
            background: -ms-linear-gradient(#B7B7B7,#313131);
            background: linear-gradient(#B7B7B7,#313131) !important;
        }

        .RadDock_Default .rdTop .rdLeft {
            border-top-left-radius: 9px 9px;
            -webkit-border-top-left-radius: 9px 9px;
        }

        .RadDock_Default .rdTop .rdRight {
            border-top-right-radius: 9px 9px;
            -webkit-border-top-right-radius: 9px 9px;
        }
    </style>
    <div id="Div_navigator" style="width: 100%; display: none;" class="navigatorpanel">
        <div class="t">
            <div class="t">
                <div class="t">
                    <div class="divpadding">
                        <div align="left" style="float: left; margin-top: -2px;" nowrap="nowrap">
                            <span class="navigatorpanel">
                                <asp:Label ID="lblheader" runat="server"><%=objlang.GetLanguageConversion("Settings")%>: <%=objlang.GetLanguageConversion("Dashboard_settings")%></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear: both;">
        </div>
    </div>
    <div id="content" class="estore_settingBox" style="width: 99.5%; min-height: 420px;">
        <UC:Header_MIS ID="header_mis" runat="server" />
        <div class="mis_header_panel" style="margin-top: 0px">
            <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="99%" Height="100%"
                Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                <Items>
                    <telerik:RadPanelItem Text="Summary Widgets" Font-Bold="true" Expanded="true"
                        CssClass="rounded-ReportTopcorners" Selected="true">
                        <ContentTemplate>
                            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="multiPage">
                                <telerik:RadPageView runat="server" ID="RadPageView2">
                                    <div align="left" style="width: 99%;">
                                        <div id="Div3" style="width: 100%; margin: 40px 0px 0px 0px;">
                                            <div>
                                                <asp:UpdatePanel ID="upuseMINI" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadDockLayout EnableViewState="true" runat="server" ID="RadDockLayout1MINI"
                                                            StoreLayoutInViewState="true">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td valign="top" width="100%" colspan="2">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 30%;">
                                                                                    <div style="margin-left: 6px; font-weight: bold; margin-top: -37px;">
                                                                                        <asp:Label ID="lblavilablewidgetsMINI" runat="server"></asp:Label>
                                                                                    </div>
                                                                                </td>
                                                                                <td></td>
                                                                                <td>
                                                                                    <div style="font-weight: bold; margin-top: -37px; margin-left: 37px">
                                                                                        <asp:Label ID="lblcustimizewidgetsMINI" runat="server"></asp:Label>
                                                                                    </div>
                                                                                    <div style="display: none; margin-top: -19px; margin-left: 60%;">
                                                                                        <asp:Button ID="btnUpdateDockPogitionsMINI" runat="server" CssClass="headerbutton white"
                                                                                            Text="Save Current Layout" OnClientClick="javascript:getLeftRightDockPanelMini();"
                                                                                            OnClick="btnUpdateDockPogitionsMini_Click" />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2"></td>
                                                                                <td>
                                                                                    <div style="margin-left: 39px; margin-top: -13px;">
                                                                                        <asp:Label ID="lblNoWidgetsMINI" runat="server" Text="" Style="font-weight: bold; float: left; display: none; margin-top: 0px;"></asp:Label>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <div id="divmsgMINI" runat="server" align="left" style="width: 100%; padding-left: 8px; display: none; margin-top: -12px; margin-bottom: 5px;">
                                                                                        <div id="Div4" style="width: 60%">
                                                                                            <asp:PlaceHolder ID="plhMessageMINI" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%; border: 0px solid red; vertical-align: top;">
                                                                                    <div style="margin-top: -20px;">
                                                                                        <telerik:RadDockZone EnableViewState="true" BorderStyle="None" ID="RadDockZone4MINI"
                                                                                            runat="server" FitDocks="true" Style="float: left; margin-left: 2px; border: 0px solid yellow;"
                                                                                            CssClass="RadDockZone4">
                                                                                        </telerik:RadDockZone>
                                                                                    </div>
                                                                                </td>
                                                                                <td style="width: 30%; border: 0px solid red; vertical-align: top;">
                                                                                    <div style="margin-top: -20px;">
                                                                                        <telerik:RadDockZone EnableViewState="true" BorderStyle="None" ID="RadDockZone5MINI"
                                                                                            runat="server" FitDocks="true" Style="float: left; margin-left: 6px; border: 0px solid red;"
                                                                                            CssClass="RadDockZone5">
                                                                                        </telerik:RadDockZone>
                                                                                    </div>
                                                                                </td>
                                                                                <td style="width: 33%; border: 0px solid red; vertical-align: top;">
                                                                                    <div style="margin-top: -20px;">
                                                                                        <telerik:RadDockZone EnableViewState="true" Skin="Default" BorderStyle="None" Style="margin-top: 0px; float: left; border: 0px solid green; margin-left: 35px"
                                                                                            ID="RadDockZone2MINI" runat="server"
                                                                                            CssClass="RadDockZone2">
                                                                                        </telerik:RadDockZone>
                                                                                        <telerik:RadDockZone EnableViewState="true" Skin="Default" BorderStyle="None" Style="margin-top: -20px; float: left; border: 0px solid red; margin-left: 35px"
                                                                                            ID="RadDockZone3MINI" runat="server"
                                                                                            CssClass="RadDockZone3">
                                                                                        </telerik:RadDockZone>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </telerik:RadDockLayout>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                    <telerik:RadPanelItem Text="Grid/Graphical Widgets" Font-Bold="true" CssClass="rounded-ReportTopcorners"
                        Expanded="false" Style="margin-top: 6px;">
                        <ContentTemplate>
                            <telerik:RadMultiPage runat="server" ID="rad2" SelectedIndex="0" CssClass="multiPage">
                                <telerik:RadPageView runat="server" ID="view2">
                                    <div align="left" style="width: 99%;">
                                        <div id="" style="width: 100%; margin: 40px 0px 0px 0px;">
                                            <div>
                                                <asp:UpdatePanel ID="upuse" runat="server">
                                                    <ContentTemplate>
                                                        <telerik:RadDockLayout EnableViewState="true" runat="server" ID="RadDockLayout1"
                                                            StoreLayoutInViewState="true">
                                                            <table width="100%" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td valign="top" width="100%" colspan="2">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td style="width: 30%;">
                                                                                    <div style="margin-left: 6px; font-weight: bold; margin-top: -37px;">
                                                                                        <asp:Label ID="lblavilablewidgets" runat="server"></asp:Label>
                                                                                    </div>
                                                                                </td>
                                                                                <td></td>
                                                                                <td>
                                                                                    <div style="font-weight: bold; margin-top: -37px; margin-left: 37px">
                                                                                        <asp:Label ID="lblcustimizewidgets" runat="server"></asp:Label>
                                                                                    </div>
                                                                                    <div style="display: none; margin-top: -19px; margin-left: 60%;">
                                                                                        <asp:Button ID="btnUpdateDockPogitions" runat="server" CssClass="headerbutton white"
                                                                                            Text="Save Current Layout" OnClientClick="javascript:getLeftRightDockPanel();"
                                                                                            OnClick="btnUpdateDockPogitions_Click" />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2"></td>
                                                                                <td>
                                                                                    <div style="margin-left: 39px; margin-top: -13px;">
                                                                                        <asp:Label ID="lblNoWidgets" runat="server" Text="" Style="font-weight: bold; float: left; display: none;"></asp:Label>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <div id="divmsg" runat="server" align="left" style="width: 100%; padding-left: 8px; display: none; margin-top: -12px; margin-bottom: 5px;">
                                                                                        <div id="DivMessage" style="width: 60%">
                                                                                            <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 30%; border: 0px solid red; vertical-align: top;">
                                                                                    <div style="margin-top: -20px;">
                                                                                        <telerik:RadDockZone EnableViewState="true" BorderStyle="None" ID="RadDockZone4"
                                                                                            runat="server" FitDocks="true" Style="float: left; margin-left: 2px; border: 0px solid yellow;"
                                                                                            CssClass="RadDockZone4">
                                                                                        </telerik:RadDockZone>
                                                                                    </div>
                                                                                </td>
                                                                                <td style="width: 30%; border: 0px solid red; vertical-align: top;">
                                                                                    <div style="margin-top: -20px;">
                                                                                        <telerik:RadDockZone EnableViewState="true" BorderStyle="None" ID="RadDockZone5"
                                                                                            runat="server" FitDocks="true" Style="float: left; margin-left: 6px; border: 0px solid red;"
                                                                                            CssClass="RadDockZone5">
                                                                                        </telerik:RadDockZone>
                                                                                    </div>
                                                                                </td>
                                                                                <td style="width: 33%; border: 0px solid red; vertical-align: top;">
                                                                                    <div style="margin-top: -20px;">
                                                                                        <telerik:RadDockZone EnableViewState="true" Skin="Default" BorderStyle="None" Style="margin-top: 0px; float: left; border: 0px solid green; margin-left: 35px"
                                                                                            ID="RadDockZone2" runat="server"
                                                                                            CssClass="RadDockZone2">
                                                                                        </telerik:RadDockZone>
                                                                                        <telerik:RadDockZone EnableViewState="true" Skin="Default" BorderStyle="None" Style="margin-top: 0px; float: left; border: 0px solid red; margin-left: 35px"
                                                                                            ID="RadDockZone3" runat="server"
                                                                                            CssClass="RadDockZone3">
                                                                                        </telerik:RadDockZone>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </telerik:RadDockLayout>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </telerik:RadPageView>
                            </telerik:RadMultiPage>
                        </ContentTemplate>
                    </telerik:RadPanelItem>
                </Items>
            </telerik:RadPanelBar>
            <div id="ScroolDown">
            </div>
        </div>
        <div id="DivWindow">
            <telerik:RadWindowManager ID="rwmgrForAll" runat="server" Height="445px" Width="530px"
                EnableShadow="true" ReloadOnShow="true" AutoSize="false" Animation="None" Behaviors="Close,Reload"
                KeepInScreenBounds="true" ShowContentDuringLoad="true" Modal="true" VisibleOnPageLoad="false">
                <Windows>
                    <telerik:RadWindow ID="rwReferences" Skin="Default" runat="server" Height="445px"
                        Width="530px" EnableShadow="true" VisibleOnPageLoad="false" Top="0px" Left="0px"
                        ShowContentDuringLoad="false" Behaviors="Close,Reload" VisibleStatusbar="false">
                        <ContentTemplate>
                            <div style="margin-top: 10px; margin-left: 10px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div id="tdRecordType" class="bglabel" style="width: 150px; display: none;">
                                                <asp:Label ID="Label1" runat="server" Text="Record Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="tdRecordTypeddl" style="margin-left: 5px; margin-top: 1px; display: none;">
                                                <asp:DropDownList ID="ddlRecordType" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Task" Value="Task"></asp:ListItem>
                                                    <asp:ListItem Text="Call" Value="Call"></asp:ListItem>
                                                    <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="tdtaskselecttye" class="bglabel" style="width: 150px; display: none;">
                                                <asp:Label ID="Label4" runat="server" Text="Reord Date"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="tdtaskselecttyeddl" style="margin-left: 5px; margin-top: 1px; display: none;">
                                                <asp:DropDownList ID="ddltaskResultselecType" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Value="1">Today</asp:ListItem>
                                                    <asp:ListItem Value="2">Today + Overdue</asp:ListItem>
                                                    <asp:ListItem Value="3">Tomorrow</asp:ListItem>
                                                    <asp:ListItem Value="4">Next 7 Days</asp:ListItem>
                                                    <asp:ListItem Value="5">Next 7 Days + Overdue</asp:ListItem>
                                                    <asp:ListItem Value="6">This Month</asp:ListItem>
                                                    <asp:ListItem Value="7">All Open</asp:ListItem>
                                                    <asp:ListItem Value="8">All</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="DivRecordDate" class="bglabel" style="width: 150px; display: none;">
                                                <asp:Label ID="Label11" runat="server" Text="Record Date"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivRecordDate1" style="margin-left: 5px; margin-top: 1px; display: none;">
                                                <asp:DropDownList ID="ddlRecordDate" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Value="1">Today</asp:ListItem>
                                                    <asp:ListItem Value="2">This Week</asp:ListItem>
                                                    <asp:ListItem Value="3">This Month</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="tdtargetdisplaytype" align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lbltargetdisplaytype" runat="server" Text="Display Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="tdtargetdisplaytype1" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddltargetdispplayType" runat="server" Width="110px" CssClass="normaltext"
                                                    Onchange="javascript:Displaytargetoptions(); return false;">
                                                    <asp:ListItem Text="Tabular" Value="Tabular"></asp:ListItem>
                                                    <asp:ListItem Text="Graph" Value="Graph"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="tdtargetdisplaytype2" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddltargetdispplayType1" runat="server" Width="100px" CssClass="normaltext"
                                                    Onchange="javascript:Displaytargetoptions1(); return false;">
                                                    <asp:ListItem Text="Tabular" Value="Tabular"></asp:ListItem>
                                                    <asp:ListItem Text="Graph" Value="Graph"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="tdpnldisplay" align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblDisplayType" runat="server" Text="Display Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="pnlddlDisplay" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlDisplayType" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Tabular" Value="Tabular"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="pnlGraphtype" align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lbltaskalert" runat="server" Text="Graph Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="pnlGraphtypectrl" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlGraphType" runat="server" Width="110px" CssClass="normaltext">
                                                    <asp:ListItem Text="Bar" Value="Bar" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Pie" Value="Pie"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="pnlGraphtypectrl2" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlGraphType2" runat="server" Width="110px" CssClass="normaltext">
                                                    <asp:ListItem Text="Bar" Value="Bar" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="StackedBar" Value="StackedBar"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="pnlGraphtypectrl3" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlGraphType3" runat="server" Width="110px" CssClass="normaltext">
                                                    <asp:ListItem Text="Bar" Value="Bar" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Line" Value="Line"></asp:ListItem>
                                                    <asp:ListItem Text="Pie" Value="Pie"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="pnlGraphtypectr4" style="margin-left: 5px; margin-top: 4px;">
                                                <asp:Label ID="lblbar" runat="server" Text="Bar"></asp:Label>
                                            </div>
                                            <div id="pnlGraphtypectr5" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlTargetGraphType" runat="server" Width="110px" CssClass="normaltext">
                                                    <asp:ListItem Text="Bar" Value="Bar" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="StackedBar" Value="StackedBar"></asp:ListItem>
                                                    <asp:ListItem Text="Pie" Value="Pie"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="pnlGraphtypectr6" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:Label ID="GraphTypelbl" runat="server" Text="Pie"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" id="lblModuleName" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblModule" runat="server" Text="Module Name"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div style="margin-left: 5px; margin-top: 1px;">
                                                <div id="DivddlModuleName">
                                                    <asp:DropDownList ID="ddlModuleName" runat="server" Width="110px" CssClass="normaltext"
                                                        onchange="javascript:ShowHideStatusDropdown(this.id,this.value); return false;">
                                                        <asp:ListItem Text="Estimates" Value="Estimates"></asp:ListItem>
                                                        <asp:ListItem Text="Invoice" Value="Invoice"></asp:ListItem>
                                                        <asp:ListItem Text="Jobs" Value="Jobs"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="DivddlJobsinvoicebydue">
                                                    <asp:DropDownList ID="ddlJobsinvoicebydue" runat="server" Width="110px" CssClass="normaltext"
                                                        onchange="javascript:ShowHideStatusDropdown(this.id,this.value); return false;">
                                                        <asp:ListItem Text="Invoice" Value="Invoice"></asp:ListItem>
                                                        <asp:ListItem Text="Jobs" Value="Jobs"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="DivlblEstimate">
                                                    <asp:Label ID="lblEstimate" runat="server" Text="Estimate" Style="margin-top: 6px;"></asp:Label>
                                                </div>
                                                 <div id="DivlblInvoice">
                                                    <asp:Label ID="lblInvoice" runat="server" Text="Invoice" Style="margin-top: 6px;"></asp:Label>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" id="DivStatus" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div style="margin-left: 5px; margin-top: 1px;">
                                                <div id="DivStatus1">
                                                    <telerik:RadListBox ID="ddlStatusEstimate" runat="server" CheckBoxes="true" Width="200px"
                                                        OnClientItemChecked="onItemChecked" Height="80px">
                                                        <Items>
                                                        </Items>
                                                    </telerik:RadListBox>
                                                </div>
                                                <div id="DivStatus2">
                                                    <telerik:RadListBox ID="ddlStatusJob" runat="server" CheckBoxes="true" Width="200px"
                                                        OnClientItemChecked="onItemChecked" Height="80px">
                                                        <Items>
                                                        </Items>
                                                    </telerik:RadListBox>
                                                </div>
                                                <div id="DivStatus3">
                                                    <telerik:RadListBox ID="ddlStatusInvoice" runat="server" CheckBoxes="true" Width="200px"
                                                        OnClientItemChecked="onItemChecked" Height="80px">
                                                        <Items>
                                                        </Items>
                                                    </telerik:RadListBox>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" id="DivArchiveRecords" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblShowArchiverecords" runat="server" Text="Show Archived Records"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivArchiveRecords1" style="margin-left: 2px; margin-top: 1px;">
                                                <div id="Div2">
                                                    <asp:CheckBox ID="chkArchiverecords" runat="server" />
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top" id="DivDateRange">
                                        <td align="left" id="DivDate" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label2" runat="server" Text="Date Range"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivDate1" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlDefaultDate" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Today" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="This Week" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="This Month" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="DivDate2" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlTasksDaterange" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Today" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Today + Overdue" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Tomorrow" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Next 7 Days" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="Next 7 Days + Overdue" Value="7"></asp:ListItem>
                                                    <asp:ListItem Text="This Month" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="All Open" Value="8"></asp:ListItem>
                                                    <asp:ListItem Text="All" Value="9"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="DivDate3" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlAccountingCodeDaterange" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Today" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Weekly" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="This Month" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Last Month" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="This Quarter" Value="5"></asp:ListItem>
                                                    <asp:ListItem Text="Last Quarter" Value="6"></asp:ListItem>
                                                    <asp:ListItem Text="Yearly" Value="7"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" id="tdlblTaskstatus" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblTaskstatus" runat="server" Text="Tasks Status"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="pnlTasksstatus" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlTaskStatus" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                    <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                                                    <asp:ListItem Text="Deferred" Value="Deferred"></asp:ListItem>
                                                    <asp:ListItem Text="In-process" Value="Inprocess"></asp:ListItem>
                                                    <asp:ListItem Text="Not Started" Value="NotStarted"></asp:ListItem>
                                                    <asp:ListItem Text="Partially Completed" Value="PartiallyCompleted"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" id="tdlblCompanytype" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblCompanytype" runat="server" Text="Company Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="pnlCompanyType" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlCompanyType" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Customer" Value="Customer"></asp:ListItem>
                                                    <asp:ListItem Text="Prospect" Value="Prospect"></asp:ListItem>
                                                    <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="tdlblColumns" align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblColumns" runat="server" Text="Columns"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="pnlchkLatestnotes">
                                                <div style="margin-left: 1px; margin-top: 1px; display: none;">
                                                    <asp:CheckBox ID="chkAllLatest" runat="server" Text="All" onchange="javascript:chkAllLatestnotcolumns();" />
                                                </div>
                                                <div style="clear: both;">
                                                </div>
                                                <div style="margin-left: -2px; margin-top: -5px;">
                                                    <asp:CheckBoxList ID="chkLatestcolumns" runat="server" RepeatColumns="2" onclick="javascript:chkUncheckAll('latestnotes');">
                                                        <asp:ListItem Text="Customer Name" Value="Customer Name"></asp:ListItem>
                                                        <asp:ListItem Text="Specific to Contact" Value="Specific to Contact"></asp:ListItem>
                                                        <asp:ListItem Text="Note Title" Value="Note Title"></asp:ListItem>
                                                        <asp:ListItem Text="Note Content" Value="Note Content"></asp:ListItem>
                                                        <asp:ListItem Text="Created By" Value="Created By"></asp:ListItem>
                                                        <asp:ListItem Text="Created On" Value="Created On"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </div>
                                            </div>
                                            <div id="pnlchkCustomeractivity">
                                                <div style="margin-left: 1px; margin-top: 1px; display: none;">
                                                    <asp:CheckBox ID="chkAllCustomer" runat="server" Text="All" onchange="javascript:chkAllCustomerbyactcolumns();" />
                                                </div>
                                                <div style="clear: both;">
                                                </div>
                                                <div style="margin-left: -2px; margin-top: -4px;">
                                                    <asp:CheckBoxList ID="chkcolscustomeractivity" runat="server" RepeatColumns="3" onclick="javascript:chkUncheckAll('customeractivity');">
                                                        <asp:ListItem Text="Customer Name" Value="Customer Name"></asp:ListItem>
                                                        <asp:ListItem Text="Main Contact" Value="Main Contact"></asp:ListItem>
                                                        <asp:ListItem Text="Phone" Value="Phone"></asp:ListItem>
                                                        <asp:ListItem Text="Last Activity Type" Value="Last Activity Type"></asp:ListItem>
                                                        <asp:ListItem Text="Time" Value="Time"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top" id="DivNoOfREcords">
                                        <td id="tdlblNoOfrecords" align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblNoOfrecords" runat="server" Text="No of records"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="pnlNoOfRecords" style="margin-left: 5px; margin-top: 1px;">
                                                            <asp:DropDownList ID="ddlNoofRecords" runat="server" Style="width: 100px;">
                                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                <asp:ListItem Text="10" Value="10" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                                <asp:ListItem Text="All" Value="500"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div id="divslsperson" style="margin-left: 5px; display: none;">
                                                            <span id="spnSalesperson">Sales Persons</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="tdlblCustomers" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblCustomers" runat="server" Text="Customers"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="pnlCustomers" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlCustomers" runat="server" Style="width: 100px;" AppendDataBoundItems="true"
                                                    OnDataBound="ddlCustomers_DataBound">
                                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="divcustomerListBox" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label5" runat="server" Text="Customers"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="divcustomerListBox1" style="margin-left: 5px; margin-top: 1px;">
                                                <telerik:RadListBox ID="RadListBoxCustomer" runat="server" CheckBoxes="true" Width="217px"
                                                    Height="80px">
                                                    <Items>
                                                    </Items>
                                                </telerik:RadListBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="divcustomer" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label6" runat="server" Text="Customers"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="divcustomer1" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlcompanyName1" runat="server" Width="100px" CssClass="normaltext"
                                                    AppendDataBoundItems="true">
                                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="divddlsalesPerson" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblsalper" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="divddlsalesPerson1" style="margin-left: 5px; margin-top: 1px;">
                                                <telerik:RadListBox ID="ddlsalesPerson" runat="server" CheckBoxes="true" Width="200px"
                                                    OnClientItemChecked="onItemChecked" Height="80px">
                                                    <Items>
                                                    </Items>
                                                </telerik:RadListBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="divsalseperson" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label7" runat="server" Text="Customers"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="divsalseperson1" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" CssClass="normaltext"
                                                    AppendDataBoundItems="true">
                                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="DivRecordsType" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblRetype" runat="server" Text="Record Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivRecordsType1" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlRecordsTypes" runat="server" Width="110px" CssClass="normaltext"
                                                    Onchange="javascript:DisplaySalesPersonList(); return false;">
                                                    <asp:ListItem Text="Sales Person" Value="SalesPerson"></asp:ListItem>
                                                    <asp:ListItem Text="Company" Value="Company"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="DivTargetSalesPerson" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label12" runat="server" Text="Sales Person"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivTargetSalesPerson1" style="margin-left: 5px; margin-top: 1px;">
                                                <asp:DropDownList ID="ddlTargetSalesPerson" runat="server" Width="110px" CssClass="normaltext">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="tdcompanyType" align="left" style="width: 150px; display: none;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblSalesOf" runat="server" Text="Sales Person"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="tdcompanyType1" style="margin-left: 5px; margin-top: 1px; display: none;">
                                                <div style="display: none;">
                                                    <asp:DropDownList ID="ddlcompanyName" runat="server" Width="100px" CssClass="normaltext">
                                                    </asp:DropDownList>
                                                </div>
                                                <telerik:RadListBox ID="lstsaleperson" runat="server" CheckBoxes="true" Width="200px"
                                                    OnClientItemChecked="onItemChecked" Height="80px">
                                                    <Items>
                                                    </Items>
                                                </telerik:RadListBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="tdQuarterType" align="left" style="width: 150px; display: none;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblQuarterType" runat="server" Text="Quarter Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="tdQuarterType1" style="margin-left: 5px; margin-top: 1px; display: none;">
                                                <asp:DropDownList ID="ddlquarterType" runat="server" Width="110px" CssClass="normaltext">
                                                    <asp:ListItem Text="Q1-2012-2013" Value="Q1-2013"></asp:ListItem>
                                                    <asp:ListItem Text="Q2-2012-2013" Value="Q2-2013"></asp:ListItem>
                                                    <asp:ListItem Text="Q3-2012-2013" Value="Q3-2013"></asp:ListItem>
                                                    <asp:ListItem Text="Q4-2012-2013" Value="Q4-2013"></asp:ListItem>
                                                    <asp:ListItem Text="Q1-2013-2014" Value="Q1-2014"></asp:ListItem>
                                                    <asp:ListItem Text="Q2-2013-2014" Value="Q2-2014"></asp:ListItem>
                                                    <asp:ListItem Text="Q3-2013-2014" Value="Q3-2014"></asp:ListItem>
                                                    <asp:ListItem Text="Q4-2013-2014" Value="Q4-2014"></asp:ListItem>
                                                    <asp:ListItem Text="Q1-2014-2015" Value="Q1-2015" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Q2-2014-2015" Value="Q2-2015"></asp:ListItem>
                                                    <asp:ListItem Text="Q3-2014-2015" Value="Q3-2015"></asp:ListItem>
                                                    <asp:ListItem Text="Q4-2014-2015" Value="Q4-2015"></asp:ListItem>
                                                    <asp:ListItem Text="Q1-2015-2016" Value="Q1-2016"></asp:ListItem>
                                                    <asp:ListItem Text="Q2-2015-2016" Value="Q2-2016"></asp:ListItem>
                                                    <asp:ListItem Text="Q3-2015-2016" Value="Q3-2016"></asp:ListItem>
                                                    <asp:ListItem Text="Q4-2015-2016" Value="Q4-2016"></asp:ListItem>
                                                    <asp:ListItem Text="Q1-2016-2017" Value="Q1-2017"></asp:ListItem>
                                                    <asp:ListItem Text="Q2-2016-2017" Value="Q2-2017"></asp:ListItem>
                                                    <asp:ListItem Text="Q3-2016-2017" Value="Q3-2017"></asp:ListItem>
                                                    <asp:ListItem Text="Q4-2016-2017" Value="Q4-2017"></asp:ListItem>
                                                    <asp:ListItem Text="Q1-2017-2018" Value="Q1-2018"></asp:ListItem>
                                                    <asp:ListItem Text="Q2-2017-2018" Value="Q2-2018"></asp:ListItem>
                                                    <asp:ListItem Text="Q3-2017-2018" Value="Q3-2018"></asp:ListItem>
                                                    <asp:ListItem Text="Q4-2017-2018" Value="Q4-2018"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="tdQuarterdaterange" align="left" style="width: 150px; display: none;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblDateRange" runat="server" Text="Date Range"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="tdQuarterdaterange1" style="margin-left: 5px; margin-top: 1px; display: none;">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="width: 35px;">
                                                            <asp:Label Text="From" ID="lblfrom" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width: 100px;">
                                                            <asp:TextBox ID="txtFromdate" runat="server" SkinID="textPad" CssClass="txtbox" Width="87px"> </asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label Text="To" ID="lblto" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtToate" runat="server" SkinID="textPad" CssClass="txtbox" Width="87px"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td id="tdestimateTye" align="left" style="width: 150px; display: none;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblEstimateType" runat="server" Text="Estimate Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="tdestimateTye1" style="margin-left: 5px; margin-top: 1px; display: none;">
                                                <asp:DropDownList ID="ddlEstimateType" runat="server" Width="110px" CssClass="normaltext">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="Div1" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label13" runat="server" Text="Show Widget Options"><%=objlang.GetLanguageConversion("ShowWidgetOptions")%></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <table border="0" id="tblWidgetOption" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <div id="DivPrintS1" style="margin-left: 2px; margin-top: 2px; float: left;">
                                                            <asp:CheckBox ID="chkPrintOption" runat="server"></asp:CheckBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div id="DivPrintS" style="width: 25px; margin-top: 1px;">
                                                            <asp:Label ID="Label9" runat="server" Text="Print"><%=objlang.GetLanguageConversion("Print")%></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div id="Tr21" style="margin-left: 10px; margin-top: 2px; float: left;">
                                                            <asp:CheckBox ID="chkshowalloptions" runat="server"></asp:CheckBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div id="Tr2" style="width: 32px; margin-top: 1px;">
                                                            <asp:Label ID="Label10" runat="server" Text="Filters"><%=objlang.GetLanguageConversion("Report_Filters")%></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div id="showfullscreen1" style="margin-left: 10px; margin-top: 2px; float: left; display: none;">
                                                            <asp:CheckBox ID="chkfullscreen" runat="server"></asp:CheckBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div id="showfullscreen" style="width: 63px; margin-top: 1px; display: none;">
                                                            <asp:Label ID="Label8" runat="server" Text="Full Screen"><%=objlang.GetLanguageConversion("Full_Screen")%></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div style="margin-left: 5px; margin-top: 1px; float: left;">
                                                <asp:TextBox ID="txtTitle" runat="server" SkinID="textPad" Width="210px"></asp:TextBox>
                                            </div>
                                            <div style="float: left; margin-left: -65.5%; margin-top: -2px;">
                                                <br />
                                                <br />
                                                <span id="spn_Title" class="RFV_Message" style="width: auto; padding-left: 4px; padding-right: 4px; visibility: visible;">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Title")%></span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div class="bglabel" id="date_type_div" style="width: 150px; display: none">
                                                <asp:Label ID="date_type" runat="server" Text="Date Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivGraphicDateType2" style="margin-left: 5px; display: none">
                                                <asp:DropDownList ID="ddldate" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                    <asp:ListItem Text="Annual" Value="Annual"></asp:ListItem>
                                                    <asp:ListItem Text="Year-to-date" Value="YearToDate"></asp:ListItem>
                                                    <asp:ListItem Text="Date range" Value="DateRange"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trYearToDate2" style="display: none">
                                        <td align="left" style="width: 150px;">
                                            <div id="divYTD2" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label18" runat="server" Text="Year-to-date"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <input type="radio" id="calendarYear2" name="YTD" value="calendarYear" checked runat="server" />
                                                <label for="male">Calendar year</label><br>
                                                <input type="radio" id="financialYear2" name="YTD" value="financialYear" runat="server" />
                                                <label for="female">Financial year</label><br>
                                            </div>
                                        </td>
                                    </tr>


                                    <tr id="trDateRange2" style="display: none">
                                        <td align="left" style="width: 150px;">
                                            <div id="divDateRange2" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label19" runat="server" Text="Date range"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>

                                                <div style="width: 300px; float: left; vertical-align: middle;">
                                                    <%=objLanguage.GetLanguageConversion("From_Date")%>
                                                    <asp:TextBox ID="txtFromDate2" runat="server" CssClass="textboxnew"></asp:TextBox>

                                                </div>
                                                <div style="width: 300px; float: left; vertical-align: middle; margin-top: 4px;">

                                                    <%=objLanguage.GetLanguageConversion("To_Date")%>
                                                    <asp:TextBox ID="txtToDate2" runat="server" CssClass="textboxnew"></asp:TextBox>
                                                </div>

                                            </div>
                                        </td>

                                    </tr>

                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="DivSpread" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblspread" runat="server" Text="Spread in two columns"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivSpread1" style="margin-left: 1px; margin-top: 1px; float: left;">
                                                <asp:CheckBox ID="chkIsSpaead" runat="server"></asp:CheckBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="DivLastYearData" class="bglabel" style="width: 150px;display:none">
                                                <asp:Label ID="lblLastYear" runat="server" Text="Last Year's Data"></asp:Label>
                                            </div>
                                            <div id="DivLastMonthData" class="bglabel" style="width: 150px;display:none">
                                                <asp:Label ID="lblLastmonth" runat="server" Text="Last Month's Data"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivLastYearData1" style="margin-left: 1px; margin-top: 1px; float: left;display:none">
                                                <asp:CheckBox ID="chkIsLastYearData" runat="server"></asp:CheckBox>
                                            </div>
                                        </td>
                                    </tr>
                                     <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="DivDailyTarget" class="bglabel" style="width: 150px;display:none">
                                                <asp:Label ID="lblDailyTarget" runat="server" Text="Display Daily Targets"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivDailyTarget1" style="margin-left: 1px; margin-top: 1px; float: left;display:none">
                                                <asp:CheckBox ID="chkIsDailyTarget" runat="server"></asp:CheckBox>
                                            </div>
                                        </td>
                                    </tr>
                                      <tr valign="top">
                                        <td align="left" style="width: 150px;">
                                            <div id="DivMonthlyTarget" class="bglabel" style="width: 150px;display:none">
                                                <asp:Label ID="lblMonthlyTarget" runat="server" Text="Display Monthly Targets"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivMonthlyTarget1" style="margin-left: 1px; margin-top: 1px; float: left;display:none">
                                                <asp:CheckBox ID="chkIsMonthlyTarget" runat="server"></asp:CheckBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td></td>
                                        <td>
                                            <div style="margin-left: 5px; margin-top: 10px;">
                                                <asp:Button ID="btnUpdate" runat="server" CssClass="button" Text="Update" CausesValidation="False"
                                                    OnClientClick="javascript:var a=CheckValidation();if(a) loadingimage(this.id,'div_btnSave');return a;" OnClick="btnUpdate_Click"
                                                    Style="display: none;"></asp:Button>
                                                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                                    OnClientClick="javascript:var a=CheckValidation();if(a) loadingimage(this.id,'div_btnSave');return a;" OnClick="btnSave_Click"></asp:Button>&nbsp;&nbsp;
                                                <div id="div_btnSave" style="display: none; float: left">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
                                                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Cancel" Visible="false"
                                                    CausesValidation="False" OnClientClick="javascript:return CLosePopup();"></asp:Button>
                                            </div>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>
                    </telerik:RadWindow>
                    <telerik:RadWindow ID="rwReferencesMini" Skin="Default" runat="server" Height="325px"
                        Width="530px" EnableShadow="true" VisibleOnPageLoad="false" Top="0px" Left="0px"
                        ShowContentDuringLoad="false" Behaviors="Close,Reload" VisibleStatusbar="false">
                        <ContentTemplate>
                            <div style="margin-top: 10px; margin-left: 10px;">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div id="divUser" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblUserMini" runat="server" Text="Users"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="divUser1" style="margin-left: 5px; margin-top: -4px;">
                                                <asp:DropDownList ID="ddlUserMini" runat="server" Width="220px" CssClass="normaltext">
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div id="DivDateType" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="lblDateTypeMini" runat="server" Text="Date Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivDateType1" style="margin-left: 5px; margin-top: -4px;">
                                                <asp:DropDownList ID="ddlDateTypeMini" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                    <asp:ListItem Text="This Quarter" Value="Quarterly"></asp:ListItem>
                                                    <asp:ListItem Text="Annual" Value="Annual"></asp:ListItem>
                                                    <asp:ListItem Text="Year-to-date" Value="YearToDate"></asp:ListItem>
                                                    <asp:ListItem Text="Date range" Value="DateRange"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>



                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div id="DivDateType2" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label15" runat="server" Text="Date Type"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivDateType3" style="margin-left: 5px; margin-top: -4px;">
                                                <asp:DropDownList ID="ddlDateTypeMiniNew" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Today" Value="Today"></asp:ListItem>
                                                    <asp:ListItem Text="Weekly" Value="Weekly"></asp:ListItem>
                                                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                    <asp:ListItem Text="This Quarter" Value="Quarterly"></asp:ListItem>
                                                    <asp:ListItem Text="Annual" Value="Annual"></asp:ListItem>
                                                    <asp:ListItem Text="Year-to-date" Value="YearToDate"></asp:ListItem>
                                                    <asp:ListItem Text="Date range" Value="DateRange"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="DivDateType4" style="margin-left: 5px; margin-top: -4px;">
                                                <asp:DropDownList ID="DropDownList2" runat="server" Width="100px" CssClass="normaltext">
                                                    <asp:ListItem Text="Daily" Value="Daily"></asp:ListItem>
                                                    <asp:ListItem Text="Monthly" Value="Monthly"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trDailyTarget" style="display: none">
                                        <td align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;margin-top: -326px;">
                                                <asp:Label ID="DailyTargetLabel" runat="server">Daily Target</asp:Label>

                                            </div>
                                        </td>
                                        <td style="padding:5px">
                                                    <input type="text" style="width:61px" value="1" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="2" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="3" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="4" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="5" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="6" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="7" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="8" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="9" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="10" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="11" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="12" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="13" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="14" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="15" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="16" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="17" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="18" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="19" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="20" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="21" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="22" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="23" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="24" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="25" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="26" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="27" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="28" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="29" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="30" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="31" disabled="disabled"/><br>

                                        </td>
                                        <td>
                                            <div style="margin-left:-240px">

                                                 <input type="text" style="width:110px" id="DailyTarget1" runat="server" /><br>
                                                 <input type="text" style="width:110px" id="DailyTarget2" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget3" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget4" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget5" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget6" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget7" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget8" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget9" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget10" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget11" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget12" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget13" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget14" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget15" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget16" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget17" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget18" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget19" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget20" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget21" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget22" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget23" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget24" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget25" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget26" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget27" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget28" runat="server" /><br>
                                                 <input type="text" style="width:110px" id="DailyTarget29" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget30" runat="server" /><br>
                                                <input type="text" style="width:110px" id="DailyTarget31" runat="server" /><br>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trMonthlyTarget" style="display: none">
                                        <td align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;margin-top: -126px;">
                                                <asp:Label ID="MonthlyTargetLabel" runat="server">Monthly Target</asp:Label>
                                            </div>
                                        </td>
                                        <td style="padding:5px">
                                          <input type="text" style="width:61px" value="1" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="2" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="3" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="4" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="5" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="6" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="7" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="8" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="9" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="10" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="11" disabled="disabled"/><br>
                                            <input type="text" style="width:61px" value="12" disabled="disabled"/>
                                        </td>
                                        <td>
                                            <div style="margin-left:-240px">
                                                <input type="text" style="width:110px" id="MonthlyTarget1" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget2" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget3" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget4" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget5" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget6" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget7" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget8" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget9" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget10" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget11" runat="server" /><br>
                                                <input type="text" style="width:110px" id="MonthlyTarget12" runat="server" /><br>

                                            </div>
                                        </td>
                                    </tr>
                                    <%-- start new dev --%>

                                    <tr id="trYearToDate" style="display: none">
                                        <td align="left" style="width: 150px;">
                                            <div id="divYTD" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label16" runat="server" Text="Year-to-date"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>
                                                <input type="radio" id="calendarYear" name="YTD" value="calendarYear" checked runat="server" />
                                                <label for="male">Calendar year</label><br>
                                                <input type="radio" id="financialYear" name="YTD" value="financialYear" runat="server" />
                                                <label for="female">Financial year</label><br>
                                            </div>
                                        </td>
                                    </tr>


                                    <tr id="trDateRange" style="display: none">
                                        <td align="left" style="width: 150px;">
                                            <div id="divDateRange" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label17" runat="server" Text="Date range"></asp:Label>
                                            </div>
                                        </td>
                                        <td>
                                            <div>

                                                <div style="width: 300px; float: left; vertical-align: middle;">
                                                    <%=objLanguage.GetLanguageConversion("From_Date")%>
                                                    <asp:TextBox ID="txtFromDateNew" runat="server" CssClass="textboxnew"></asp:TextBox>

                                                </div>
                                                <div style="width: 300px; float: left; vertical-align: middle; margin-top: 4px;">

                                                    <%=objLanguage.GetLanguageConversion("To_Date")%>
                                                    <asp:TextBox ID="txtToDate" runat="server" CssClass="textboxnew"></asp:TextBox>
                                                </div>

                                            </div>
                                        </td>

                                    </tr>


                                    <%-- end new dev --%>

                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div id="DivIncludeArchivedRecordMini" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label14" runat="server" Text="Include Archived Record"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivIncludeArchivedRecord1Mini" style="margin-left: 5px; margin-top: -4px;">
                                                <asp:CheckBox ID="chkIncludeArchivedRecordMini" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div id="DivDisplayWidgetMini" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label2Mini" runat="server" Text="Display Widget"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="DivDisplayWidget1Mini" style="margin-left: 5px; margin-top: -4px;">
                                                <asp:CheckBox ID="ChkDisplayWidgetMini" runat="server" />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div id="Div1Mini" class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label4Mini" runat="server" Text="Widget header color"></asp:Label>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div id="Div2Mini" style="margin-left: 5px; margin-top: -4px;">
                                                <telerik:RadColorPicker ID="TotalBackgroundColorMini" SelectedColor="Red" runat="server"
                                                    OnClientLoad="OnClientLoad" PaletteModes="HSV" OnClientColorChanging="OnClientColorChanging"
                                                    OnClientColorChange="OnClientColorChange" OnClientColorPreview="OnClientColorPreview"
                                                    OnClientPopUpShow="OnClientPopUpShow" CssClass="NoColorButton" ShowIcon="true">
                                                </telerik:RadColorPicker>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" style="width: 150px;">
                                            <div class="bglabel" style="width: 150px;">
                                                <asp:Label ID="Label3Mini" runat="server" Text="Title"></asp:Label>
                                                <span style="color: red">*</span>
                                            </div>
                                        </td>
                                        <td align="left">
                                            <div style="margin-left: 5px; margin-top: 1px; float: left;">
                                                <asp:TextBox ID="txtTitleMini" runat="server" SkinID="textPad" Width="210px"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td>
                                            <div id="divvalidationMini" runat="server" style="margin-left: 6px; display: none">
                                                <span id="spn_TitleMini" class="RFV_Message" style="width: auto; padding-left: 4px; padding-right: 4px;">
                                                    <%=objLanguage.GetLanguageConversion("Please_Enter_Title")%></span>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td></td>
                                        <td>
                                            <div style="margin-left: 5px; margin-top: 10px;">

                                                <asp:Button ID="btnUpdateMini" runat="server" CssClass="button" Text="Update" CausesValidation="False"
                                                    OnClientClick="javascript:var a=CheckValidationMini();if(a)loadingimage(this.id,'div_btnSaveMini');return a;" OnClick="btnUpdateMini_Click"
                                                    Style="display: none;"></asp:Button>
                                                <asp:Button ID="btnSaveMini" runat="server" CssClass="button" Text="Save" CausesValidation="False"
                                                    OnClientClick="javascript:var a=CheckValidationMini();if(a)loadingimage(this.id,'div_btnSaveMini');return a;" OnClick="btnSaveMini_Click"></asp:Button>
                                                <div id="div_btnSaveMini" style="display: none">
                                                    <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                                </div>
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
        <asp:HiddenField ID="hdnMasterID" runat="server" />
        <asp:HiddenField ID="hdnCopyMasterID" runat="server" />
        <asp:HiddenField ID="hdnMastervalues" runat="server" />
        <asp:HiddenField ID="hdnCopyMastervalues" runat="server" />
        <asp:HiddenField ID="hdnmasterIDS" runat="server" />

        <%--Mini--%>
        <asp:HiddenField ID="hdnMasterIDMini" runat="server" />
        <asp:HiddenField ID="hdnCopyMasterIDMini" runat="server" />
        <asp:HiddenField ID="hdnMastervaluesMini" runat="server" />
        <asp:HiddenField ID="hdnCopyMastervaluesMini" runat="server" />
        <asp:HiddenField ID="hdnmasterIDSMini" runat="server" />
        <asp:HiddenField ID="hdnIDMini" runat="server" />
        <div style="display: none;">
            <asp:UpdatePanel ID="UpminiDelete" runat="server">
                <ContentTemplate>
                    <asp:Button ID="btndeleteMini" runat="server" Text="" OnClick="imgCancelMini_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <script type="text/javascript" language="javascript">
            function OnClientLoad(sender, eventArgs) {
            }

            function OnClientColorPreview(sender, eventArgs) {
            }

            function OnClientColorChanging(sender, eventArgs) {
            }

            function OnClientPopUpShow(sender, eventArgs) {
            }

            function OnClientColorChange(sender, eventArgs) {
                var TotalBackgroundColor = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_TotalBackgroundColorMini");
                TotalBackgroundColor.value = sender.get_selectedColor();
            }

            function GetScreenCordinatesNew(obj) {
                var p = {};
                p.x = obj.offsetLeft;
                p.y = obj.offsetTop;
                while (obj.offsetParent) {
                    p.x = p.x + obj.offsetParent.offsetLeft - 30;
                    p.y = p.y + obj.offsetParent.offsetTop + 200;
                    if (obj == document.getElementsByTagName("body")[0]) {
                        break;
                    }
                    else {
                        obj = obj.offsetParent;
                    }
                }
                return p;
            }

            function msghideUSeMini() {

                window.setTimeout(function () {
                    var DivNotesMessage = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_divmsgMINI');

                    if (DivNotesMessage != null) {
                        DivNotesMessage.style.display = 'none';
                    }
                }, 9000);
            }

            function UseClickMini(ID) {
                document.getElementById("ctl00_ContentPlaceHolder1_hdnMasterIDMini").value = ID;
                return true;
            }

            function OnClientInitialize(dock, args) {
                dock._resizeExtender = false;
                dock._autoScrollEnabled = false;
            }

            function getLeftRightDockPanelMini() {
                var leftstr = '';
                var rightstr = '';
                var leftcounter = 0;
                var rightcounter = 0;
                var leftdockzone = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_RadDockZone2MINI');
                var righdockzone = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_RadDockZone3MINI');
                var hdnLeft = document.getElementById('ctl00_ContentPlaceHolder1_hdnLeftZoneIdsMini');
                var hdnRight = document.getElementById('ctl00_ContentPlaceHolder1_hdnRightZoneIdsMini');

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
            }

            function msghideMini() {
                window.setTimeout(function () {
                    var DivNotesMessage = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_divmsgMINI');

                    if (DivNotesMessage != null) {
                        DivNotesMessage.style.display = 'none';
                    }
                }, 9000);
            }
        </script>
        <asp:HiddenField runat="server" ID="hdn_selectedcolorMini" Value="" />
        <script type="text/javascript" language="javascript">
            function CustomizeOptionsPopupMini(MasterID, DateType, IncludeArchiverecords, IsDisplayWidget, Color, Title, User, ID, IsCalendarYear, FromDate, ToDate, Mt1, Mt2, Mt3, Mt4, Mt5, Mt6, Mt7, Mt8, Mt9, Mt10, Mt11, Mt12, Dt1, Dt2, Dt3, Dt4, Dt5, Dt6, Dt7, Dt8, Dt9, Dt10, Dt11, Dt12, Dt13, Dt14, Dt15, Dt16, Dt17, Dt18, Dt19, Dt20, Dt21, Dt22, Dt23, Dt24, Dt25, Dt26, Dt27, Dt28, Dt29, Dt30, Dt31) {
                debugger;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_divvalidationMini").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnMasterIDMini").value = MasterID;
                document.getElementById("ctl00_ContentPlaceHolder1_hdnIDMini").value = ID;
                var wnd = $find('<%=rwReferencesMini.ClientID %>');
                $("#trYearToDate").css('display', 'none');
                $("#trDateRange").css('display', 'none');
                wnd.set_title(Title);
                if (MasterID == 1) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 2) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 3) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 4) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 5) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 6) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 7) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 8) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 9) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 10) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                } else if (MasterID == 11) {

                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 12) {

                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "none";
                    document.getElementById("DivDateType4").style.display = "block";
                    document.getElementById("divUser").style.display = "none";
                    document.getElementById("divUser1").style.display = "none";
                    var element = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_DropDownList2");
                    if (DateType == "Monthly") {
                        $("#trMonthlyTarget").css('display', '');
                        $("#trDailyTarget").css('display', 'none');
                        element.value = "Monthly";
                    }
                    else {
                        $("#trDailyTarget").css('display', '');
                        $("#trMonthlyTarget").css('display', 'none');
                        element.value = "Daily";
                    }
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DropDownList2")
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget1").val(Mt1);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget2").val(Mt2);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget3").val(Mt3);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget4").val(Mt4);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget5").val(Mt5);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget6").val(Mt6);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget7").val(Mt7);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget8").val(Mt8);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget9").val(Mt9);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget10").val(Mt10);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget11").val(Mt11);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget12").val(Mt12);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget1").val(Dt1);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget2").val(Dt2);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget3").val(Dt3);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget4").val(Dt4);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget5").val(Dt5);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget6").val(Dt6);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget7").val(Dt7);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget8").val(Dt8);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget9").val(Dt9);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget10").val(Dt10);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget11").val(Dt11);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget12").val(Dt12);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget13").val(Dt13);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget14").val(Dt14);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget15").val(Dt15);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget16").val(Dt16);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget17").val(Dt17);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget18").val(Dt18);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget19").val(Dt19);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget20").val(Dt20);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget21").val(Dt21);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget22").val(Dt22);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget23").val(Dt23);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget24").val(Dt24);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget25").val(Dt25);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget26").val(Dt26);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget27").val(Dt27);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget28").val(Dt28);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget29").val(Dt29);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget30").val(Dt30);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget31").val(Dt31);




                    //$("#trMonthlyTarget").css('display', '');

                }

                var ddlUser = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlUserMini");
                var ddlDateType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlDateTypeMini");
                var ddlDateTypeNew = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlDateTypeMiniNew");
                var chkIncludeArchivedRecord = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_chkIncludeArchivedRecordMini");
                var ChkDisplayWidget = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ChkDisplayWidgetMini");
                var colorPicker = $find('ctl00_ContentPlaceHolder1_rwReferencesMini_C_TotalBackgroundColorMini');
                var txtTitle = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_txtTitleMini");

                ddlUser.value = User;

                ddlDateTypeNew.value = DateType;
                //if (MasterID == 10) {
                //    ddlDateTypeNew.value = DateType;
                //}
                //else {
                //    ddlDateType.value = DateType;
                //}

                if (IncludeArchiverecords == "False") {
                    chkIncludeArchivedRecord.checked = false;
                }
                else if (IncludeArchiverecords == "True") {
                    chkIncludeArchivedRecord.checked = true;
                }
                if (IsDisplayWidget == "False") {
                    ChkDisplayWidget.checked = false;
                }
                else if (IsDisplayWidget == "True") {
                    ChkDisplayWidget.checked = true;
                }

                colorPicker.set_selectedColor(Color);

                txtTitle.value = Title;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_btnUpdateMini").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_btnSaveMini").style.display = "none";


                //start
                var arr = FromDate.split('/');
                var arr1 = ToDate.split('/');
                FromDate = arr[1] + "/" + arr[0] + "/" + arr[2];
                ToDate = arr1[1] + "/" + arr1[0] + "/" + arr1[2];

                if (DateType == "DateRange") {

                    $("#trYearToDate").css('display', 'none');
                    $("#trDateRange").css('display', '');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_txtFromDateNew").val(FromDate);
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_txtToDate").val(ToDate);

                } else if (DateType == "YearToDate") {

                    $("#trYearToDate").css('display', '');
                    $("#trDateRange").css('display', 'none');

                    if (IsCalendarYear == "1") {
                        $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_calendarYear").prop("checked", true);
                    } else {
                        $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_financialYear").prop("checked", true);
                    }

                }


                //end



                wnd.Show();
            }

            function UseDeleteMini(ID) {
                if (window.confirm('Are you sure you want to delete?')) {
                    document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
                    document.getElementById("ctl00_ContentPlaceHolder1_hdnIDMini").value = ID;
                    __doPostBack('ctl00$ContentPlaceHolder1$btndeleteMini', '')
                    return true;
                }
                else {
                    return false;
                }
            }

            function CheckValidationMini() {
                var hdn_selectedcolor = document.getElementById("<%=hdn_selectedcolorMini.ClientID%>");
                var colorPicker = $find('ctl00_ContentPlaceHolder1_rwReferencesMini_C_TotalBackgroundColorMini');
                hdn_selectedcolor.value = colorPicker.get_selectedColor();
                var Spantitle = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_divvalidationMini");
                var txtTitle = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_txtTitleMini");
                if (txtTitle.value == '') {
                    Spantitle.style.display = "block";
                    return false;
                }
                return true;
            }

            function OpencustomizeWindowMini(MasterID, DateType, IncludeArchiverecords, IsDisplayWidget, Color, Title) {
                debugger;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_divvalidationMini").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnMasterIDMini").value = MasterID;
                var wnd = $find('<%=rwReferencesMini.ClientID %>');
                wnd.set_title(Title);


                $("#trYearToDate").css('display', 'none');
                $("#trDateRange").css('display', 'none');

                var ddlUser = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlUserMini");
                var ddlDateType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlDateTypeMini");

                var ddlDateTypeNew = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlDateTypeMiniNew");
                var chkIncludeArchivedRecord = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_chkIncludeArchivedRecordMini");
                var ChkDisplayWidget = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_ChkDisplayWidgetMini");
                var colorPicker = $find('ctl00_ContentPlaceHolder1_rwReferencesMini_C_TotalBackgroundColorMini');
                var txtTitle = document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_txtTitleMini");

                ddlUser.selectedIndex = 0;
                ddlDateTypeNew.value = DateType;
                chkIncludeArchivedRecord.checked = IncludeArchiverecords;
                ChkDisplayWidget.checked = IsDisplayWidget;
                colorPicker.Color = Color;
                txtTitle.value = "";
                if (MasterID == 1) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 2) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 3) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 4) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 5) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 6) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 7) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 8) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 9) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "none";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "none";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 10) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }
                else if (MasterID == 11) {
                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "block";

                    document.getElementById("DivDateType4").style.display = "none";
                    document.getElementById("divUser").style.display = "block";
                    document.getElementById("divUser1").style.display = "block";
                    $("#trDailyTarget").css('display', 'none');
                    $("#trMonthlyTarget").css('display', 'none');
                }

                else if (MasterID == 12) {

                    document.getElementById("DivIncludeArchivedRecordMini").style.display = "block";
                    document.getElementById("DivIncludeArchivedRecord1Mini").style.display = "block";
                    document.getElementById("DivDateType").style.display = "none";
                    document.getElementById("DivDateType1").style.display = "none";
                    document.getElementById("DivDateType2").style.display = "block";
                    document.getElementById("DivDateType3").style.display = "none";
                    document.getElementById("DivDateType4").style.display = "block";
                    document.getElementById("divUser").style.display = "none";
                    document.getElementById("divUser1").style.display = "none";
                    if (DateType == "Monthly") {
                        $("#trMonthlyTarget").css('display', '');
                        $("#trDailyTarget").css('display', 'none');
                    }
                    else {
                        $("#trDailyTarget").css('display', '');
                        $("#trMonthlyTarget").css('display', 'none');
                    }
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget1").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget2").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget3").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget4").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget5").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget6").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget7").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget8").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget9").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget10").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget11").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_MonthlyTarget12").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget1").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget2").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget3").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget4").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget5").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget6").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget7").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget8").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget9").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget10").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget11").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget12").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget13").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget14").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget15").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget16").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget17").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget18").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget19").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget20").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget21").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget22").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget23").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget24").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget25").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget26").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget27").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget28").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget29").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget30").val('');
                    $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DailyTarget31").val('');
                }

                document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_btnUpdateMini").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferencesMini_C_btnSaveMini").style.display = "block";
                wnd.Show();
            }
        </script>
        <asp:HiddenField ID="hdnLeftZoneIdsMini" runat="server" />
        <asp:HiddenField ID="hdnRightZoneIdsMini" runat="server" />
        <asp:HiddenField ID="hdnStatusSelectedMini" runat="server" />
        <script type="text/javascript" language="javascript">
            function OnClientDragEndMini(sender, args) {
                getLeftRightDockPanelMini();
                __doPostBack('ctl00$ContentPlaceHolder1$RadPanelBar1$i0$btnUpdateDockPogitionsMINI', '')
                return true;
            }

            function OnClientDragEndFirst(sender, args) {
                getLeftRightDockPanel();
                __doPostBack('ctl00$ContentPlaceHolder1$RadPanelBar1$i1$btnUpdateDockPogitions', '')
                return true;
            }
        </script>

        <%--END--%>
    </div>
    <div style="display: none;">
        <asp:UpdatePanel ID="UpdatePaneldelete" runat="server">
            <ContentTemplate>
                <asp:Button ID="btndelete" runat="server" Text="vvv" OnClick="btndelete_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript" language="javascript">

        function ShowHideStatusDropdown(ddlID, ddlvalue) {

            var EstimateStatus = document.getElementById("DivStatus1");
            var JobStatus = document.getElementById("DivStatus2");
            var InvoiceStatus = document.getElementById("DivStatus3");

            if (ddlvalue == "Estimates") {
                EstimateStatus.style.display = "block";
                JobStatus.style.display = "none";
                InvoiceStatus.style.display = "none";
            }
            if (ddlvalue == "Jobs") {
                EstimateStatus.style.display = "none";
                JobStatus.style.display = "block";
                InvoiceStatus.style.display = "none";
            }
            if (ddlvalue == "Invoice") {
                EstimateStatus.style.display = "none";
                JobStatus.style.display = "none";
                InvoiceStatus.style.display = "block";
            }
        }

        function getLeftRightDockPanel() {
            var leftstr = '';
            var rightstr = '';
            var leftcounter = 0;
            var rightcounter = 0;
            var leftdockzone = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i1_RadDockZone2');
            var righdockzone = document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i1_RadDockZone3');
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
        }
    </script>
    <asp:HiddenField ID="hdnLeftZoneIds" runat="server" />
    <asp:HiddenField ID="hdnRightZoneIds" runat="server" />
    <asp:HiddenField ID="hdnStatusSelected" runat="server" />
    <script type="text/javascript" language="javascript">
        function GetCopyMasterID(CopyMasterID) {

        }
        function onItemChecked(sender, e) {

            var item = e.get_item();
            var items = sender.get_items();
            var checked = item.get_checked();
            var firstItem = sender.getItem(0);
            if (item.get_text() == "All") {
                items.forEach(function (itm) { itm.set_checked(checked); });
            }
            else {
                if (sender.get_checkedItems().length == items.get_count() - 1) {
                    firstItem.set_checked(!firstItem.get_checked());
                }
            }
        }

        function UseDelete(ID) {

            if (window.confirm('Are you sure you want to delete?')) {
                document.getElementById("ctl00_ContentPlaceHolder1_divLoadingImageCus").style.display = "block";
                document.getElementById("ctl00_ContentPlaceHolder1_hdnCopyMasterID").value = ID;
                __doPostBack('ctl00$ContentPlaceHolder1$btndelete', '')
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <script type="text/javascript" language="javascript">

        function DisplayQuarterDateRange() {
            var ddlquarterType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlquarterType");
            ddlquarterType.options[ddlquarterType.selectedIndex].value;
            var finalddlquarterType = ddlquarterType.options[ddlquarterType.selectedIndex].value;
            if (finalddlquarterType == "DateRange") {
                document.getElementById("tdQuarterdaterange").style.display = "block";
                document.getElementById("tdQuarterdaterange1").style.display = "block";
            }
            else {
                document.getElementById("tdQuarterdaterange").style.display = "none";
                document.getElementById("tdQuarterdaterange1").style.display = "none";
            }
        }

        function Displaytargetoptions() {

            var targetType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType");
            targetType.options[targetType.selectedIndex].value;

            var finaltargetType = targetType.options[targetType.selectedIndex].value;

            if (finaltargetType == "Tabular") {
                document.getElementById("DivNoOfREcords").style.display = "none";
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";

            }
            if (finaltargetType == "Graph") {
                document.getElementById("DivNoOfREcords").style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl2").style.display = "block";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "block";
            }
        }

        function DisplaySalesPersonList() {

            var ddlRecordsTypes = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlRecordsTypes");
            var FinalddlRecordsTypes = ddlRecordsTypes.options[ddlRecordsTypes.selectedIndex].value;

            if (FinalddlRecordsTypes == "Company") {
                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById('DivTargetSalesPerson1').style.display = 'none';
            }

            if (FinalddlRecordsTypes == "SalesPerson") {
                document.getElementById("DivTargetSalesPerson").style.display = "block";
                document.getElementById('DivTargetSalesPerson1').style.display = 'block';
            }
        }

        function Displaytargetoptions1() {

            var targetType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
            targetType.options[targetType.selectedIndex].value;

            var finaltargetType = targetType.options[targetType.selectedIndex].value;

            if (finaltargetType == "Tabular") {
                document.getElementById("DivNoOfREcords").style.display = "none";
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";

                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';

            }

            if (finaltargetType == "Graph") {
                document.getElementById("DivNoOfREcords").style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "block";

            }
        }

    </script>
    <script type="text/javascript" language="javascript">

        function GetScreenCordinatesNew(obj) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft - 30;
                p.y = p.y + obj.offsetParent.offsetTop + 200;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            return p;
        }

        function msghideUSe() {

            window.setTimeout(function () {
                var DivNotesMessage = document.getElementById('DivMessage');

                if (DivNotesMessage != null) {
                    DivNotesMessage.style.display = 'none';
                }
            }, 5000);
        }

        function msghide() {
            window.setTimeout(function () {
                var DivNotesMessage = document.getElementById('DivMessage');

                if (DivNotesMessage != null) {
                    DivNotesMessage.style.display = 'none';
                }
            }, 5000);
        }
    </script>
    <script type="text/javascript" language="javascript">
        function CustomizeOptionsPopup(CopyMasterID, GraphType, DefaultDate, TitleName, MasterID, ModuleName, DisplayType, copyWidgetValues, DisplayRecordSalesOf, QuarterType, FromDate, Todate, EstimateType, NoOfRecords, CustomerID, ShowPrint, ShowFullScreen, ShowAllOptions, Status, ShowArchivedStatus, IsCalendarYear, DateType, IsLastYearData,IsDisplayDailyTarget,IsDisplayMonthlyTarget) {
            debugger;
            var Master = document.getElementById("ctl00_ContentPlaceHolder1_hdnmasterIDS").value = MasterID;

            var wnd = $find('<%=rwReferences.ClientID %>');
            wnd.set_title(TitleName);

            if (MasterID == 1) {
                document.getElementById("date_type_div").style.display = "block";
                document.getElementById("DivGraphicDateType2").style.display = "block";
                var ddlDate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddldate");
                ddlDate.value = DateType;
                var arr = FromDate.split('/');
                var arr1 = Todate.split('/');
                FromDate = arr[1] + "/" + arr[0] + "/" + arr[2];
                ToDate = arr1[1] + "/" + arr1[0] + "/" + arr1[2];

                if (DateType == "DateRange") {

                    $("#trYearToDate2").css('display', 'none');
                    $("#trDateRange2").css('display', '');
                    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtFromDate2").val(FromDate);
                    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtToDate2").val(ToDate);

                } else if (DateType == "YearToDate") {

                    $("#trYearToDate2").css('display', '');
                    $("#trDateRange2").css('display', 'none');

                    if (IsCalendarYear == "1") {
                        $("#ctl00_ContentPlaceHolder1_rwReferences_C_calendarYear2").prop("checked", true);
                    } else {
                        $("#ctl00_ContentPlaceHolder1_rwReferences_C_financialYear2").prop("checked", true);
                    }

                }
                else {
                    $("#trDateRange2").css('display', 'none');
                    $("#trYearToDate2").css('display', 'none');
                }

                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";
                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";
                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";
                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "block";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";

                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').selectedIndex = 0;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";

                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivddlModuleName').style.display = 'block';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                var ddlModuleName = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName');
                ddlModuleName.disabled = false;
                document.getElementById("DivddlModuleName").style.display = "block";
                for (i = 0; i < ddlModuleName.length; i++) {
                    if (ddlModuleName.options[i].text == ModuleName) {
                        ddlModuleName.selectedIndex = i;
                    }
                }

                document.getElementById('Tr2').style.display = 'none';
                document.getElementById('Tr21').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'block';
                if (ModuleName == "Estimates") {
                    document.getElementById('DivStatus1').style.display = 'block';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                else if (ModuleName == "Invoice") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'block';
                }
                else if (ModuleName == "Jobs") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'block';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                var chkArchiverecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkArchiverecords');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }

                if (chkArchiverecords != null) {
                    if (ShowArchivedStatus.toLowerCase() == 'false') {
                        chkArchiverecords.checked = false;
                    }
                    else {
                        chkArchiverecords.checked = true;
                    }
                }

                var StatusID = Status.split(',');

                if (ModuleName == "Estimates") {

                    var EstimateStatus = $find("<%=ddlStatusEstimate.ClientID %>");
                    for (var l = 0; l < EstimateStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (EstimateStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                EstimateStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
                else if (ModuleName == "Invoice") {
                    var InvoiceStatus = $find("<%=ddlStatusInvoice.ClientID %>");
                    for (var l = 0; l < InvoiceStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (InvoiceStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                InvoiceStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
                else if (ModuleName == "Jobs") {
                    var JobStatus = $find("<%=ddlStatusJob.ClientID %>");
                    for (var l = 0; l < JobStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (JobStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                JobStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
            }

            else if (MasterID == 2) {
                document.getElementById("date_type_div").style.display = "block";
                document.getElementById("DivGraphicDateType2").style.display = "block";
                var ddlDate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddldate");
                ddlDate.value = DateType;
                var arr = FromDate.split('/');
                var arr1 = Todate.split('/');
                FromDate = arr[1] + "/" + arr[0] + "/" + arr[2];
                ToDate = arr1[1] + "/" + arr1[0] + "/" + arr1[2];

                if (DateType == "DateRange") {

                    $("#trYearToDate2").css('display', 'none');
                    $("#trDateRange2").css('display', '');
                    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtFromDate2").val(FromDate);
                    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtToDate2").val(ToDate);

                } else if (DateType == "YearToDate") {

                    $("#trYearToDate2").css('display', '');
                    $("#trDateRange2").css('display', 'none');

                    if (IsCalendarYear == "1") {
                        $("#ctl00_ContentPlaceHolder1_rwReferences_C_calendarYear2").prop("checked", true);
                    } else {
                        $("#ctl00_ContentPlaceHolder1_rwReferences_C_financialYear2").prop("checked", true);
                    }

                }
                else {
                    $("#trDateRange2").css('display', 'none');
                    $("#trYearToDate2").css('display', 'none');
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";

                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";

                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "block";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";


                document.getElementById('DivStatus').style.display = 'block';
                if (ModuleName == "Estimates") {
                    document.getElementById('DivStatus1').style.display = 'block';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                else if (ModuleName == "Invoice") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'block';
                }
                else if (ModuleName == "Jobs") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'block';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';

                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "block";

                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';

                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';

                document.getElementById('DivNoOfREcords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('divslsperson').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = 'block';
                document.getElementById('tdcompanyType1').style.display = 'block';
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "Show Records Top";

                var ddlModuleName = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName');
                ddlModuleName.disabled = false;
                document.getElementById("DivddlModuleName").style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                for (i = 0; i < ddlModuleName.length; i++) {
                    if (ddlModuleName.options[i].text == ModuleName) {
                        ddlModuleName.selectedIndex = i;
                    }
                }

                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var chkArchiverecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkArchiverecords');
                var noofRecords = mastervalues[0];

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }
                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }
                var ddlGraphType2 = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType2");
                for (i = 0; i < ddlGraphType2.length; i++) {
                    if (ddlGraphType2.options[i].text == GraphType) {
                        ddlGraphType2.selectedIndex = i;
                    }
                }

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }

                var salesper = DisplayRecordSalesOf.split(',');
                var lstsaleperson = $find("<%=lstsaleperson.ClientID %>");

                for (var i = 0; i < lstsaleperson.get_items().get_count(); i++) {

                    for (var j = 0; j < salesper.length; j++) {
                        if (lstsaleperson.get_items().getItem(i)._properties._data.value == salesper[j]) {
                            lstsaleperson.get_items().getItem(i).set_checked(true);
                            break;
                        }
                    }
                }
                if (chkArchiverecords != null) {
                    if (ShowArchivedStatus.toLowerCase() == 'false') {
                        chkArchiverecords.checked = false;
                    }
                    else {
                        chkArchiverecords.checked = true;
                    }
                }

                var StatusID = Status.split(',');

                if (ModuleName == "Estimates") {

                    var EstimateStatus = $find("<%=ddlStatusEstimate.ClientID %>");
                    for (var l = 0; l < EstimateStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (EstimateStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                EstimateStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
                else if (ModuleName == "Invoice") {
                    var InvoiceStatus = $find("<%=ddlStatusInvoice.ClientID %>");
                    for (var l = 0; l < InvoiceStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (InvoiceStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                InvoiceStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
                else if (ModuleName == "Jobs") {
                    var JobStatus = $find("<%=ddlStatusJob.ClientID %>");
                    for (var l = 0; l < JobStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (JobStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                JobStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
            }
            else if (MasterID == 3) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                //var ddlDate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddldate");
                //ddlDate.value = DateType;
                //var arr = FromDate.split('/');
                //var arr1 = Todate.split('/');
                //FromDate = arr[1] + "/" + arr[0] + "/" + arr[2];
                //ToDate = arr1[1] + "/" + arr1[0] + "/" + arr1[2];

                //if (DateType == "DateRange") {

                //    $("#trYearToDate2").css('display', 'none');
                //    $("#trDateRange2").css('display', '');
                //    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtFromDate2").val(FromDate);
                //    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtToDate2").val(ToDate);

                //} else if (DateType == "YearToDate") {

                //    $("#trYearToDate2").css('display', '');
                //    $("#trDateRange2").css('display', 'none');

                //    if (IsCalendarYear == "1") {
                //        $("#ctl00_ContentPlaceHolder1_rwReferences_C_calendarYear2").prop("checked", true);
                //    } else {
                //        $("#ctl00_ContentPlaceHolder1_rwReferences_C_financialYear2").prop("checked", true);
                //    }

                //}
                //else {
                //    $("#trDateRange2").css('display', 'none');
                //    $("#trYearToDate2").css('display', 'none');
                //}
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "block";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = true;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivNoOfREcords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivddlModuleName').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'block';
                if (ModuleName == "Estimates") {
                    document.getElementById('DivStatus1').style.display = 'block';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                else if (ModuleName == "Invoice") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'block';
                }
                else if (ModuleName == "Jobs") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'block';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';



                var ddlModuleName = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlJobsinvoicebydue');
                document.getElementById("DivddlModuleName").style.display = "none";
                for (i = 0; i < ddlModuleName.length; i++) {
                    if (ddlModuleName.options[i].text == ModuleName) {
                        ddlModuleName.selectedIndex = i;
                    }
                }
                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                var ddlGraphType3 = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType3");
                for (i = 0; i < ddlGraphType3.length; i++) {
                    if (ddlGraphType3.options[i].text == GraphType) {
                        ddlGraphType3.selectedIndex = i;
                    }
                }

                document.getElementById('Tr2').style.display = 'none';
                document.getElementById('Tr21').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                var chkArchiverecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkArchiverecords');

                if (chkArchiverecords != null) {
                    if (ShowArchivedStatus.toLowerCase() == 'false') {
                        chkArchiverecords.checked = false;
                    }
                    else {
                        chkArchiverecords.checked = true;
                    }
                }

                var StatusID = Status.split(',');
                if (ModuleName == "Estimates") {

                    var EstimateStatus = $find("<%=ddlStatusEstimate.ClientID %>");
                    for (var l = 0; l < EstimateStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (EstimateStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                EstimateStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
                else if (ModuleName == "Invoice") {
                    var InvoiceStatus = $find("<%=ddlStatusInvoice.ClientID %>");
                    for (var l = 0; l < InvoiceStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (InvoiceStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                InvoiceStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }

                else if (ModuleName == "Jobs") {
                    var JobStatus = $find("<%=ddlStatusJob.ClientID %>");
                    for (var l = 0; l < JobStatus.get_items().get_count(); l++) {
                        for (var h = 0; h < StatusID.length; h++) {
                            if (JobStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                                JobStatus.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }
            }
            else if (MasterID == 4) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";
                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("tdRecordType").style.display = "block";
                document.getElementById("tdRecordTypeddl").style.display = "block";
                document.getElementById("tdtaskselecttye").style.display = "block";
                document.getElementById("tdtaskselecttyeddl").style.display = "block";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "block";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'block';
                document.getElementById('pnlddlDisplay').style.display = 'block';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "block";
                document.getElementById("pnlCustomers").style.display = "block";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivDate').style.display = 'none';
                document.getElementById('DivDate1').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = 'block';
                document.getElementById('tdcompanyType1').style.display = 'block';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = 'none';
                document.getElementById('tdcompanyType1').style.display = 'none';
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var ddlDisplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType")
                for (i = 0; i < ddlDisplayType.length; i++) {
                    if (ddlDisplayType.options[i].text == DisplayType) {
                        ddlDisplayType.selectedIndex = i;
                    }
                }

                var ddlRecordType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlRecordType")
                for (i = 0; i < ddlRecordType.length; i++) {
                    if (ddlRecordType.options[i].text == DisplayType) {
                        ddlRecordType.selectedIndex = i;
                    }
                }

                var ddltaskResultselecType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltaskResultselecType")
                for (i = 0; i < ddltaskResultselecType.length; i++) {
                    if (ddltaskResultselecType.options[i].value == DefaultDate) {
                        ddltaskResultselecType.selectedIndex = i;
                    }
                }

                var ddlCustomerid = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlCustomers');
                if (ddlCustomerid != null) {
                    for (i = 0; i < ddlCustomerid.length; i++) {
                        if (ddlCustomerid.options[i].value == CustomerID) {
                            ddlCustomerid.selectedIndex = i;
                        }
                    }
                }

                var salesper = DisplayRecordSalesOf.split(',');
                var lstsaleperson = $find("<%=ddlsalesPerson.ClientID %>");

                for (var i = 0; i < lstsaleperson.get_items().get_count(); i++) {

                    for (var j = 0; j < salesper.length; j++) {
                        if (lstsaleperson.get_items().getItem(i)._properties._data.value == salesper[j]) {
                            lstsaleperson.get_items().getItem(i).set_checked(true);
                            break;
                        }
                    }
                }


                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }
                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }
            }
            else if (MasterID == 5) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'block';
                document.getElementById('pnlchkLatestnotes').style.display = 'block';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'block';
                document.getElementById('pnlCustomers').style.display = 'block';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var mastervalues = copyWidgetValues.split('$');
                var noofRecords = mastervalues[0];
                var customizeColumns = mastervalues[1];
                var customerID = mastervalues[2];
                var isspreadovertwocolumns = mastervalues[3];
                var taskstatus = mastervalues[4];
                var companyType = mastervalues[5];

                var checkAllLatest = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllLatest');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var ddlCustomerid = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlCustomers');
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');

                if (customizeColumns.toLowerCase() == 'all') {
                    var checkAllLatest = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllLatest');
                    checkAllLatest.checked = true;
                    chkAllLatestnotcolumns();
                }
                else {
                    var checkedCount = 0;
                    var tblChkALL = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkLatestcolumns');
                    var lblCount = tblChkALL.getElementsByTagName('label');
                    var splitColumns = customizeColumns.split(',');
                    for (var i = 0; i < lblCount.length; i++) {
                        if (lblCount[i] != null) {
                            for (var j = 0; j < splitColumns.length; j++) {

                                if (lblCount[i].innerHTML == "Title" && splitColumns[j] == "Note Title") {
                                    var chkId = document.getElementById(lblCount[i].getAttribute('for'));
                                    chkId.checked = true;
                                    checkedCount++;
                                }
                                if (lblCount[i].innerHTML == "Content" && splitColumns[j] == "Note Content") {
                                    var chkId = document.getElementById(lblCount[i].getAttribute('for'));
                                    chkId.checked = true;
                                    checkedCount++;
                                }
                                if (lblCount[i].innerHTML == splitColumns[j]) {
                                    var chkId = document.getElementById(lblCount[i].getAttribute('for'));
                                    chkId.checked = true;
                                    checkedCount++;
                                }
                            }
                        }
                    }

                    var chkAll = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllLatest');
                    if (checkedCount == lblCount.length) {
                        chkAll.checked = true;
                    }
                    else {
                        chkAll.checked = false;
                    }
                }

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                if (ddlCustomerid != null) {
                    for (i = 0; i < ddlCustomerid.length; i++) {
                        if (ddlCustomerid.options[i].value == customerID) {
                            ddlCustomerid.selectedIndex = i;
                        }
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }
                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }

            }
            else if (MasterID == 6) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";

                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "block";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'block';
                document.getElementById('pnlTasksstatus').style.display = 'block';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var mastervalues = copyWidgetValues.split('$');
                var noofRecords = mastervalues[0];
                var customizeColumns = mastervalues[1];
                var customerID = mastervalues[2];
                var isspreadovertwocolumns = mastervalues[3];
                var taskstatus = mastervalues[4];
                var companyType = mastervalues[5];

                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var ddlTaskStatus = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlTaskStatus');
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                if (ddlTaskStatus != null) {
                    for (i = 0; i < ddlTaskStatus.length; i++) {
                        if (ddlTaskStatus.options[i].value == taskstatus) {
                            ddlTaskStatus.selectedIndex = i;
                        }
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }
            }
            else if (MasterID == 7) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'block';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'block';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'block';
                document.getElementById('pnlCompanyType').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var mastervalues = copyWidgetValues.split('$');
                var noofRecords = mastervalues[0];
                var customizeColumns = mastervalues[1];
                var customerID = mastervalues[2];
                var isspreadovertwocolumns = mastervalues[3];
                var taskstatus = mastervalues[4];
                var companyType = mastervalues[5];

                if (customizeColumns.toLowerCase() == 'all') {
                    var checkAllCompanyType = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllCustomer');
                    checkAllCompanyType.checked = true;
                    chkAllCustomerbyactcolumns();
                }
                else {
                    var checkedCount = 0;
                    var tblChkALL = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkcolscustomeractivity');
                    var lblCount = tblChkALL.getElementsByTagName('label');
                    var splitColumns = customizeColumns.split(',');
                    for (var i = 0; i < lblCount.length; i++) {
                        if (lblCount[i] != null) {
                            for (var j = 0; j < splitColumns.length; j++) {
                                if (lblCount[i].innerHTML == splitColumns[j]) {
                                    var chkId = document.getElementById(lblCount[i].getAttribute('for'));
                                    chkId.checked = true;
                                    checkedCount++;
                                }
                            }
                        }
                    }

                    var chkAll = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllCustomer');
                    if (checkedCount == lblCount.length) {
                        chkAll.checked = true;
                    }
                    else {
                        chkAll.checked = false;
                    }
                }

                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var ddlCompanyType = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlCompanyType');
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                if (ddlCompanyType != null) {
                    for (i = 0; i < ddlCompanyType.length; i++) {
                        if (ddlCompanyType.options[i].value == companyType) {
                            ddlCompanyType.selectedIndex = i;
                        }
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }
                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }
            }

            else if (MasterID == 8) {
                document.getElementById("date_type_div").style.display = "block";
                document.getElementById("DivGraphicDateType2").style.display = "block";
                var ddlDate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddldate");
                ddlDate.value = DateType;
                var arr = FromDate.split('/');
                var arr1 = Todate.split('/');
                FromDate = arr[1] + "/" + arr[0] + "/" + arr[2];
                ToDate = arr1[1] + "/" + arr1[0] + "/" + arr1[2];

                if (DateType == "DateRange") {

                    $("#trYearToDate2").css('display', 'none');
                    $("#trDateRange2").css('display', '');
                    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtFromDate2").val(FromDate);
                    $("#ctl00_ContentPlaceHolder1_rwReferences_C_txtToDate2").val(ToDate);

                } else if (DateType == "YearToDate") {

                    $("#trYearToDate2").css('display', '');
                    $("#trDateRange2").css('display', 'none');

                    if (IsCalendarYear == "1") {
                        $("#ctl00_ContentPlaceHolder1_rwReferences_C_calendarYear2").prop("checked", true);
                    } else {
                        $("#ctl00_ContentPlaceHolder1_rwReferences_C_financialYear2").prop("checked", true);
                    }

                }
                else {
                    $("#trDateRange2").css('display', 'none');
                    $("#trYearToDate2").css('display', 'none');
                }

                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "block";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "block";
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "Show Records Top";

                var ddlModuleName = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName');
                ddlModuleName.disabled = false;
                document.getElementById("DivddlModuleName").style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                for (i = 0; i < ddlModuleName.length; i++) {
                    if (ddlModuleName.options[i].text == ModuleName) {
                        ddlModuleName.selectedIndex = i;
                    }
                }

                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                var ddlGraphType2 = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType2");
                for (i = 0; i < ddlGraphType2.length; i++) {
                    if (ddlGraphType2.options[i].text == GraphType) {
                        ddlGraphType2.selectedIndex = i;
                    }
                }

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                document.getElementById('DivStatus').style.display = 'block';
                if (ModuleName == "Estimates") {
                    document.getElementById('DivStatus1').style.display = 'block';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                else if (ModuleName == "Invoice") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'none';
                    document.getElementById('DivStatus3').style.display = 'block';
                }
                else if (ModuleName == "Jobs") {
                    document.getElementById('DivStatus1').style.display = 'none';
                    document.getElementById('DivStatus2').style.display = 'block';
                    document.getElementById('DivStatus3').style.display = 'none';
                }
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';


                var chkArchiverecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkArchiverecords');

                if (chkArchiverecords != null) {
                    if (ShowArchivedStatus.toLowerCase() == 'false') {
                        chkArchiverecords.checked = false;
                    }
                    else {
                        chkArchiverecords.checked = true;
                    }
                }

                var salesper = Status.split(',');

                if (ModuleName == "Estimates") {

                    var lstsaleperson = $find("<%=ddlStatusEstimate.ClientID %>");
                    for (var l = 0; l < lstsaleperson.get_items().get_count(); l++) {
                        for (var h = 0; h < salesper.length; h++) {
                            if (lstsaleperson.get_items().getItem(l)._properties._data.value == salesper[h]) {
                                lstsaleperson.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
                else if (ModuleName == "Invoice") {
                    var lstsaleperson = $find("<%=ddlStatusInvoice.ClientID %>");
                    for (var l = 0; l < lstsaleperson.get_items().get_count(); l++) {
                        for (var h = 0; h < salesper.length; h++) {
                            if (lstsaleperson.get_items().getItem(l)._properties._data.value == salesper[h]) {
                                lstsaleperson.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }
                else if (ModuleName == "Jobs") {
                    var lstsaleperson = $find("<%=ddlStatusJob.ClientID %>");
                    for (var l = 0; l < lstsaleperson.get_items().get_count(); l++) {
                        for (var h = 0; h < salesper.length; h++) {
                            if (lstsaleperson.get_items().getItem(l)._properties._data.value == salesper[h]) {
                                lstsaleperson.get_items().getItem(l).set_checked(true);
                                break;
                            }
                        }
                    }
                }

                document.getElementById('DivNoOfREcords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('divslsperson').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = 'block';
                document.getElementById('tdcompanyType1').style.display = 'block';

                var salesper = DisplayRecordSalesOf.split(',');
                var lstsaleperson = $find("<%=lstsaleperson.ClientID %>");
                for (var i = 0; i < lstsaleperson.get_items().get_count(); i++) {

                    for (var j = 0; j < salesper.length; j++) {
                        if (lstsaleperson.get_items().getItem(i)._properties._data.value == salesper[j]) {
                            lstsaleperson.get_items().getItem(i).set_checked(true);
                            break;
                        }
                    }
                }

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }
            }

            else if (MasterID == 9) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "block";
                document.getElementById("DivRecordsType1").style.display = "block";

                document.getElementById("DivTargetSalesPerson").style.display = "block";
                document.getElementById("DivTargetSalesPerson1").style.display = "block";

                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlquarterType").selectedIndex = 0;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlEstimateType").selectedIndex = 0;
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName").selectedIndex = 2;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById("tdtargetdisplaytype").style.display = "block";
                document.getElementById("tdtargetdisplaytype1").style.display = "block";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "block";
                document.getElementById('tdQuarterType1').style.display = "block";
                document.getElementById('tdestimateTye').style.display = "block";
                document.getElementById('tdestimateTye1').style.display = "block";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                if (DisplayType == "Graph") {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("tdlblNoOfrecords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "block";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectr5").style.display = "block";
                    document.getElementById("pnlGraphtypectrl").style.display = "none";

                }
                else {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("tdlblNoOfrecords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "none";
                    document.getElementById("pnlGraphtypectrl").style.display = "none";
                    document.getElementById("pnlGraphtypectr5").style.display = "none";
                }

                if (QuarterType == "Date Range") {
                    document.getElementById("tdQuarterdaterange").style.display = "block";
                    document.getElementById("tdQuarterdaterange1").style.display = "block";

                }
                else {
                    document.getElementById("tdQuarterdaterange").style.display = "none";
                    document.getElementById("tdQuarterdaterange1").style.display = "none";
                }

                document.getElementById("lblModuleName").style.display = "none";
                document.getElementById("DivddlModuleName").style.display = "none";


                var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType");
                for (i = 0; i < ddltargetdispplayType.length; i++) {
                    if (ddltargetdispplayType.options[i].text == DisplayType) {
                        ddltargetdispplayType.selectedIndex = i;
                    }
                }

                var ddlNoofRecords = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords");
                for (i = 0; i < ddlNoofRecords.length; i++) {
                    if (ddlNoofRecords.options[i].text == NoOfRecords) {
                        ddlNoofRecords.selectedIndex = i;
                    }
                }

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'block';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';

                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var chkArchiverecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkArchiverecords');

                if (chkArchiverecords != null) {
                    if (ShowArchivedStatus.toLowerCase() == 'false') {
                        chkArchiverecords.checked = false;
                    }
                    else {
                        chkArchiverecords.checked = true;
                    }
                }

                var StatusID = Status.split(',');
                var EstimateStatus = $find("<%=ddlStatusEstimate.ClientID %>");
                for (var l = 0; l < EstimateStatus.get_items().get_count(); l++) {
                    for (var h = 0; h < StatusID.length; h++) {
                        if (EstimateStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                            EstimateStatus.get_items().getItem(l).set_checked(true);
                            break;
                        }
                    }
                }
                var salesper = DisplayRecordSalesOf.split(',');
                var lstsaleperson = $find("<%=lstsaleperson.ClientID %>");

                for (var i = 0; i < lstsaleperson.get_items().get_count(); i++) {

                    for (var j = 0; j < salesper.length; j++) {
                        if (lstsaleperson.get_items().getItem(i)._properties._data.value == salesper[j]) {
                            lstsaleperson.get_items().getItem(i).set_checked(true);
                            break;
                        }
                    }
                }

                var ddlRecordsTypes = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlRecordsTypes");
                for (i = 0; i < ddlRecordsTypes.length; i++) {
                    if (ddlRecordsTypes.options[i].text == ModuleName) {
                        ddlRecordsTypes.selectedIndex = i;
                    }
                }

                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                if (ModuleName == "Company") {
                    document.getElementById("DivTargetSalesPerson").style.display = "none";
                    document.getElementById("DivTargetSalesPerson1").style.display = "none";
                }
                else {
                    document.getElementById("DivTargetSalesPerson").style.display = "block";
                    document.getElementById("DivTargetSalesPerson1").style.display = "block";
                }

                var ddlTargetSalesPerson = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlTargetSalesPerson");
                for (i = 0; i < ddlTargetSalesPerson.length; i++) {
                    if (ddlTargetSalesPerson.options[i].value == DisplayRecordSalesOf) {
                        ddlTargetSalesPerson.selectedIndex = i;
                    }
                }

                var ddlquarterType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlquarterType");
                for (i = 0; i < ddlquarterType.length; i++) {
                    if (ddlquarterType.options[i].value == QuarterType) {
                        ddlquarterType.selectedIndex = i;
                    }
                }

                var ddlEstimateType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlEstimateType");
                for (i = 0; i < ddlEstimateType.length; i++) {
                    if (ddlEstimateType.options[i].value == EstimateType) {
                        ddlEstimateType.selectedIndex = i;
                    }
                }

                var ddlGraphType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlTargetGraphType");
                for (i = 0; i < ddlGraphType.length; i++) {
                    if (ddlGraphType.options[i].text == GraphType) {
                        ddlGraphType.selectedIndex = i;
                    }
                }

                var txtFromdate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_txtFromdate");
                var txtToate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_txtToate");
                txtFromdate.value = FromDate;
                txtToate.value = Todate;

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }
            }
            if (MasterID == 10) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";

                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "block";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = true;
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').selectedIndex = 0;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('tdcompanyType').style.display = "block";
                document.getElementById('tdcompanyType1').style.display = "block";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'block';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';

                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }
                var salesper = DisplayRecordSalesOf.split(',');
                var lstsaleperson = $find("<%=lstsaleperson.ClientID %>");

                for (var i = 0; i < lstsaleperson.get_items().get_count(); i++) {

                    for (var j = 0; j < salesper.length; j++) {
                        if (lstsaleperson.get_items().getItem(i)._properties._data.value == salesper[j]) {
                            lstsaleperson.get_items().getItem(i).set_checked(true);
                            break;
                        }
                    }
                }

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }

                var chkArchiverecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkArchiverecords');

                if (chkArchiverecords != null) {
                    if (ShowArchivedStatus.toLowerCase() == 'false') {
                        chkArchiverecords.checked = false;
                    }
                    else {
                        chkArchiverecords.checked = true;
                    }
                }

                var StatusID = Status.split(',');
                var EstimateStatus = $find("<%=ddlStatusEstimate.ClientID %>");
                for (var l = 0; l < EstimateStatus.get_items().get_count(); l++) {
                    for (var h = 0; h < StatusID.length; h++) {
                        if (EstimateStatus.get_items().getItem(l)._properties._data.value == StatusID[h]) {
                            EstimateStatus.get_items().getItem(l).set_checked(true);
                            break;
                        }
                    }
                }

            }

            else if (MasterID == 12) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";

                document.getElementById("pnlGraphtypectr5").style.display = "none";

                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "block";
                document.getElementById("tdtargetdisplaytype2").style.display = "block";
                document.getElementById("DivRecordDate").style.display = "block";
                document.getElementById("DivRecordDate1").style.display = "block";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "block";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';

                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
                for (i = 0; i < ddltargetdispplayType.length; i++) {
                    if (ddltargetdispplayType.options[i].text == DisplayType) {
                        ddltargetdispplayType.selectedIndex = i;
                    }
                }

                var ddlRecordDate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlRecordDate")
                for (i = 0; i < ddlRecordDate.length; i++) {
                    if (ddlRecordDate.options[i].value == DefaultDate) {
                        ddlRecordDate.selectedIndex = i;
                    }
                }

                if (DisplayType == "Graph") {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("tdlblNoOfrecords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "block";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectr4").style.display = "block";
                }
                else {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("tdlblNoOfrecords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "none";
                    document.getElementById("pnlGraphtypectrl").style.display = "none";
                    document.getElementById("pnlGraphtypectr4").style.display = "none";
                }

                var salesper = DisplayRecordSalesOf.split(',');
                var lstsaleperson = $find("<%=ddlsalesPerson.ClientID %>");

                for (var i = 0; i < lstsaleperson.get_items().get_count(); i++) {

                    for (var j = 0; j < salesper.length; j++) {
                        if (lstsaleperson.get_items().getItem(i)._properties._data.value == salesper[j]) {
                            lstsaleperson.get_items().getItem(i).set_checked(true);
                            break;
                        }
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }

            }
            else if (MasterID == 13) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                if (IsLastYearData == "True") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = true;
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = false;
                }
                if (IsDisplayDailyTarget == "True") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsDailyTarget").checked = true;
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsDailyTarget").checked = false;
                }
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "block";
                document.getElementById("DivRecordDate1").style.display = "block";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';

                document.getElementById('divddlsalesPerson').style.display = 'none';
                document.getElementById('divddlsalesPerson1').style.display = 'none';
                document.getElementById('DivRecordDate').style.display = 'none';
                document.getElementById('DivRecordDate1').style.display = 'none';
                document.getElementById('Div1').style.display = 'none';
                document.getElementById('tblWidgetOption').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'none';
                document.getElementById('DivSpread1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'block';
                document.getElementById('DivLastYearData1').style.display = 'block';
                document.getElementById('DivDailyTarget').style.display = 'block';
                document.getElementById('DivDailyTarget1').style.display = 'block';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1").selectedIndex = 1;
                var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
                var ddltargetdispplayType1 = ddltargetdispplayType.options[ddltargetdispplayType.selectedIndex].text;

                if (ddltargetdispplayType1 == "Tabular") {
                    document.getElementById('showfullscreen').style.display = 'none';
                    document.getElementById('showfullscreen1').style.display = 'none';
                }
                if (ddltargetdispplayType1 == "Graph") {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "block";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl").style.display = "none";
                    document.getElementById("pnlGraphtypectr4").style.display = "block";

                }
            }
            else if (MasterID == 14) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                if (IsLastYearData == "True") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = true;
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = false;
                }
                if (IsDisplayMonthlyTarget == "True") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsMonthlyTarget").checked = true;
                }
                else {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsMonthlyTarget").checked = false;
                }
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "block";
                document.getElementById("DivRecordDate1").style.display = "block";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';

                document.getElementById('divddlsalesPerson').style.display = 'none';
                document.getElementById('divddlsalesPerson1').style.display = 'none';
                document.getElementById('DivRecordDate').style.display = 'none';
                document.getElementById('DivRecordDate1').style.display = 'none';
                document.getElementById('Div1').style.display = 'none';
                document.getElementById('tblWidgetOption').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'none';
                document.getElementById('DivSpread1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'block';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'block';
                document.getElementById('DivMonthlyTarget').style.display = 'block';
                document.getElementById('DivMonthlyTarget1').style.display = 'block';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';

                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1").selectedIndex = 1;
                var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
                var ddltargetdispplayType1 = ddltargetdispplayType.options[ddltargetdispplayType.selectedIndex].text;

                if (ddltargetdispplayType1 == "Tabular") {
                    document.getElementById('showfullscreen').style.display = 'none';
                    document.getElementById('showfullscreen1').style.display = 'none';
                }
                if (ddltargetdispplayType1 == "Graph") {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "block";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl").style.display = "none";
                    document.getElementById("pnlGraphtypectr4").style.display = "block";

                }
            }
            else if (MasterID == 15) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = false;
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = ''; 
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';

                document.getElementById('divddlsalesPerson').style.display = 'none';
                document.getElementById('divddlsalesPerson1').style.display = 'none';
                document.getElementById('DivRecordDate').style.display = 'none';
                document.getElementById('DivRecordDate1').style.display = 'none';
                document.getElementById('Div1').style.display = 'none';
                document.getElementById('tblWidgetOption').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'none';
                document.getElementById('DivSpread1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                document.getElementById('date_type_div').style.display = 'none';
                document.getElementById('DivGraphicDateType2').style.display = 'none';
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("pnlGraphtypectr6").style.display = "block";
                document.getElementById("DivlblInvoice").style.display = "block";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById('DivDate3').style.display = 'block';

                var ddltaskResultselecType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlAccountingCodeDaterange")
                for (i = 0; i < ddltaskResultselecType.length; i++) {
                    if (ddltaskResultselecType.options[i].value == DefaultDate) {
                        ddltaskResultselecType.selectedIndex = i;
                    }
                }

                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
            }

            if (MasterID == 11) {
                document.getElementById("date_type_div").style.display = "none";
                document.getElementById("DivGraphicDateType2").style.display = "none";
                $("#trDateRange2").css('display', 'none');
                $("#trYearToDate2").css('display', 'none');

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "block";
                document.getElementById("tdRecordTypeddl").style.display = "block";
                document.getElementById("tdtaskselecttye").style.display = "block";
                document.getElementById("tdtaskselecttyeddl").style.display = "block";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "block";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'block';
                document.getElementById('pnlddlDisplay').style.display = 'block';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "block";
                document.getElementById("pnlCustomers").style.display = "block";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'block';
                document.getElementById('divcustomer1').style.display = 'block';
                document.getElementById('divsalseperson').style.display = 'block';
                document.getElementById('divsalseperson1').style.display = 'block';
                document.getElementById('divcustomer1').style.display = 'block';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var mastervalues = copyWidgetValues.split('$');
                var isspreadovertwocolumns = mastervalues[3];
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');
                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var noofRecords = mastervalues[0];

                var ddlRecordType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlRecordType")
                for (i = 0; i < ddlRecordType.length; i++) {
                    if (ddlRecordType.options[i].text == DisplayType) {
                        ddlRecordType.selectedIndex = i;
                    }
                }

                var ddltaskResultselecType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltaskResultselecType")
                for (i = 0; i < ddltaskResultselecType.length; i++) {
                    if (ddltaskResultselecType.options[i].value == DefaultDate) {
                        ddltaskResultselecType.selectedIndex = i;
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                var ddlcompanyName1 = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlcompanyName1")
                if (ddlcompanyName1 != null) {
                    for (i = 0; i < ddlcompanyName1.length; i++) {
                        if (ddlcompanyName1.options[i].value == CustomerID) {
                            ddlcompanyName1.selectedIndex = i;
                        }
                    }
                }

                var DropDownList1 = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_DropDownList1")
                if (DropDownList1 != null) {
                    for (i = 0; i < DropDownList1.length; i++) {
                        if (DropDownList1.options[i].value == DisplayRecordSalesOf) {
                            DropDownList1.selectedIndex = i;
                        }
                    }
                }

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');

                if (ShowPrint == "True") {
                    ShowPrintOptions.checked = true;
                }
                else {
                    ShowPrintOptions.checked = false;
                }
                if (ShowFullScreen == "True") {
                    ShowinFullScreen.checked = true;
                }
                else {
                    ShowinFullScreen.checked = false;
                }

                if (ShowAllOptions == "True") {
                    ShowAllOption.checked = true;
                }
                else {
                    ShowAllOption.checked = false;
                }

            }

            document.getElementById("spn_Title").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_btnSave").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_btnUpdate").style.display = "block";

            wnd.Show();
            document.getElementById("ctl00_ContentPlaceHolder1_hdnCopyMasterID").value = CopyMasterID;
            var ddlGraphType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType");
            var ddlDefaultDate = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate");
            var ddlDaterange = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlTasksDaterange');
            var txtTitle = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_txtTitle");
            var ddlNoofRecords = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords");
            for (i = 0; i < ddlGraphType.length; i++) {
                if (ddlGraphType.options[i].text == GraphType) {
                    ddlGraphType.selectedIndex = i;
                }
            }

            if (MasterID == 6) {
                if (ddlDaterange != null) {
                    for (i = 0; i < ddlDaterange.length; i++) {
                        if (ddlDaterange.options[i].value == DefaultDate) {
                            ddlDaterange.selectedIndex = i;
                        }
                    }
                }
            }
            else {
                for (i = 0; i < ddlDefaultDate.length; i++) {
                    if (ddlDefaultDate.options[i].value == DefaultDate) {
                        ddlDefaultDate.selectedIndex = i;
                    }
                }
            }

            txtTitle.value = ReplaceAllSpecialChar(TitleName);
        }

        function UseClick(ID) {
            document.getElementById("ctl00_ContentPlaceHolder1_hdnMasterID").value = ID;
            return true;
        }

        function OnClientInitialize(dock, args) {
            dock._resizeExtender = false;
            dock._autoScrollEnabled = false;
        }

        function CheckValidation() {
            var Master = document.getElementById("ctl00_ContentPlaceHolder1_hdnmasterIDS");
            if (Master.value != null) {
                if (Master.value == "5") {
                    var chkedCount = 0;
                    var tblChkALL = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkLatestcolumns');
                    var chkCount = tblChkALL.getElementsByTagName('input');
                    for (var i = 0; i < chkCount.length; i++) {
                        if (chkCount[i] != null) {
                            if (chkCount[i].checked == true) {
                                chkedCount++;
                            }
                        }
                    }
                    if (chkedCount <= 0) {
                        alert("Please select at least one column to process");
                        return false;
                    }

                }

                if (Master.value == "7") {
                    var chkedCount1 = 0;
                    var tblChkALL = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkcolscustomeractivity');
                    var chkCount = tblChkALL.getElementsByTagName('input');
                    for (var i = 0; i < chkCount.length; i++) {
                        if (chkCount[i] != null) {
                            if (chkCount[i].checked == true) {
                                chkedCount1++;
                            }
                        }
                    }
                    if (chkedCount1 <= 0) {
                        alert("Please select at least one column to process");
                        return false;
                    }
                }
            }

            var Spantitle = document.getElementById("spn_Title");
            var txtTitle = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_txtTitle");

            if (txtTitle.value == '') {
                Spantitle.style.display = "block";
                return false;
            }
            return true;
        }

        function CLosePopup() {
            document.getElementById("RadWindowWrapper_ctl00_ContentPlaceHolder1_rwReferences").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_rwmgrForAll").style.display = "none";
        }

        function OpencustomizeWindow(masterid, GraphType, DefaultDate, masterWidgetValues, widgetname) {
            debugger;
            var Master = document.getElementById("ctl00_ContentPlaceHolder1_hdnmasterIDS").value = masterid;
            document.getElementById("ctl00_ContentPlaceHolder1_hdnMasterID").value = masterid;

            var wnd = $find('<%=rwReferences.ClientID %>');
            wnd.set_title(widgetname);

            if (masterid == 1) {
                if (GraphType == "Area") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bar") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bubble") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 2;
                }
                else if (GraphType == "Donut") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Funnel") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Line") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Pie") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 1;
                }
                else if (GraphType == "Point") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 5;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";
                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";
                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";
                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "block";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName").selectedIndex = 0;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivddlModuleName').style.display = 'block';

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'block';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                var chkArchiverecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkArchiverecords');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
                chkArchiverecords.checked = false;

                document.getElementById('Tr2').style.display = 'none';
                document.getElementById('Tr21').style.display = 'none';
            }
            else if (masterid == 2) {
                if (GraphType == "Area") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bar") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 1;
                }
                else if (GraphType == "Bubble") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 2;
                }
                else if (GraphType == "Donut") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Funnel") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Line") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Pie") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Point") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 5;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";
                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";
                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";
                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "block";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divslsperson').style.display = "block";
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "Show Records Top";
                document.getElementById('DivNoOfREcords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('divslsperson').style.display = 'none';

                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName").selectedIndex = 0;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById('tdcompanyType').style.display = 'block';
                document.getElementById('tdcompanyType1').style.display = 'block';

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'block';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';
            }

            else if (masterid == 3) {
                if (GraphType == "Area") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bar") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 1;
                }
                else if (GraphType == "Bubble") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 2;
                }
                else if (GraphType == "Donut") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Funnel") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Line") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Pie") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Point") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 5;
                }
                //Date
                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";

                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "block";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "block";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlJobsinvoicebydue").selectedIndex = 0;
                document.getElementById('DivddlJobsinvoicebydue').style.display = "block";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";

                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'block';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById('Tr2').style.display = 'none';
                document.getElementById('Tr21').style.display = 'none';

            }
            else if (masterid == 4) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "block";
                document.getElementById("tdRecordTypeddl").style.display = "block";
                document.getElementById("tdtaskselecttye").style.display = "block";
                document.getElementById("tdtaskselecttyeddl").style.display = "block";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "block";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'block';
                document.getElementById('pnlddlDisplay').style.display = 'block';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "block";
                document.getElementById("pnlCustomers").style.display = "block";
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = 'none';
                document.getElementById('tdcompanyType1').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                //ved
                document.getElementById('DivlblEstimate').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";


                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';

            }
            else if (masterid == 5) {
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'block';
                document.getElementById('pnlchkLatestnotes').style.display = 'block';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'block';
                document.getElementById('pnlCustomers').style.display = 'block';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                //ved
                document.getElementById('showfullscreen').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";
                var checkAllLatest = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllLatest');
                checkAllLatest.checked = true;
                chkAllLatestnotcolumns();

                var mastervalues = masterWidgetValues.split('$');
                var noofRecords = mastervalues[0];
                var customizeColumns = mastervalues[1];
                var customerID = mastervalues[2];
                var isspreadovertwocolumns = mastervalues[3];
                var taskstatus = mastervalues[4];
                var companyType = mastervalues[5];

                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var ddlCustomerid = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlCustomers');
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                if (ddlCustomerid != null) {
                    for (i = 0; i < ddlCustomerid.length; i++) {
                        if (ddlCustomerid.options[i].value == customerID) {
                            ddlCustomerid.selectedIndex = i;
                        }
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';

            }
            else if (masterid == 6) {
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";

                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "block";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'block';
                document.getElementById('pnlTasksstatus').style.display = 'block';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var mastervalues = masterWidgetValues.split('$');
                var noofRecords = mastervalues[0];
                var customizeColumns = mastervalues[1];
                var customerID = mastervalues[2];
                var isspreadovertwocolumns = mastervalues[3];
                var taskstatus = mastervalues[4];
                var companyType = mastervalues[5];

                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var ddlDaterange = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlTasksDaterange');
                var ddlTaskStatus = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlTaskStatus');
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                if (ddlDaterange != null) {
                    for (i = 0; i < ddlDaterange.length; i++) {
                        if (ddlDaterange.options[i].value == DefaultDate) {
                            ddlDaterange.selectedIndex = i;
                        }
                    }
                }

                if (ddlTaskStatus != null) {
                    for (i = 0; i < ddlTaskStatus.length; i++) {
                        if (ddlTaskStatus.options[i].value == taskstatus) {
                            ddlTaskStatus.selectedIndex = i;
                        }
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }
            }
            else if (masterid == 7) {
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";


                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'block';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'block';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'block';
                document.getElementById('pnlCompanyType').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var checkAllCompanyType = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllCustomer');
                checkAllCompanyType.checked = true;
                chkAllCustomerbyactcolumns();

                var mastervalues = masterWidgetValues.split('$');
                var noofRecords = mastervalues[0];
                var customizeColumns = mastervalues[1];
                var customerID = mastervalues[2];
                var isspreadovertwocolumns = mastervalues[3];
                var taskstatus = mastervalues[4];
                var companyType = mastervalues[5];

                var ddlNoOfRecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlNoofRecords');
                var ddlCompanyType = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlCompanyType');
                var chkisSpread = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkIsSpaead');

                if (ddlNoOfRecords != null) {
                    for (i = 0; i < ddlNoOfRecords.length; i++) {
                        if (ddlNoOfRecords.options[i].value == noofRecords) {
                            ddlNoOfRecords.selectedIndex = i;
                        }
                    }
                }

                if (ddlCompanyType != null) {
                    for (i = 0; i < ddlCompanyType.length; i++) {
                        if (ddlCompanyType.options[i].value == companyType) {
                            ddlCompanyType.selectedIndex = i;
                        }
                    }
                }

                if (chkisSpread != null) {
                    if (isspreadovertwocolumns.toLowerCase() == 'false') {
                        chkisSpread.checked = false;
                    }
                    else {
                        chkisSpread.checked = true;
                    }
                }
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';

            }

            else if (masterid == 8) {

                if (GraphType == "Area") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bar") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 1;
                }
                else if (GraphType == "Bubble") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 2;
                }
                else if (GraphType == "Donut") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Funnel") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Line") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Pie") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Point") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 5;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";

                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "block";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName").selectedIndex = 0;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'block';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "Show Records Top";
                document.getElementById('divslsperson').style.display = "block";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById('DivNoOfREcords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('divslsperson').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = 'block';
                document.getElementById('tdcompanyType1').style.display = 'block';

            }
            //Target/Actual
            else if (masterid == 9) {

                if (GraphType == "Area") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bar") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 1;
                }
                else if (GraphType == "Bubble") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 2;
                }
                else if (GraphType == "Donut") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Funnel") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Line") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Pie") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Point") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 5;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlRecordsTypes").selectedIndex = 0;
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "block";
                document.getElementById("DivRecordsType1").style.display = "block";

                document.getElementById("DivTargetSalesPerson").style.display = "block";
                document.getElementById("DivTargetSalesPerson1").style.display = "block";

                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById("pnlGraphtypectr5").style.display = "block";

                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlEstimateType").selectedIndex = 0;
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName").selectedIndex = 2;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType").selectedIndex = 1;
                document.getElementById("tdtargetdisplaytype").style.display = "block";
                document.getElementById("tdtargetdisplaytype1").style.display = "block";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "block";
                document.getElementById('tdQuarterType1').style.display = "block";
                document.getElementById('tdestimateTye').style.display = "block";
                document.getElementById('tdestimateTye1').style.display = "block";
                document.getElementById("DivNoOfREcords").style.display = "none";
                document.getElementById("tdlblNoOfrecords").style.display = "none";
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'block';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
                document.getElementById("lblModuleName").style.display = "none";
                document.getElementById("DivddlModuleName").style.display = "none";
            }

            else if (masterid == 10) {
                if (GraphType == "Area") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bar") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 0;
                }
                else if (GraphType == "Bubble") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 2;
                }
                else if (GraphType == "Donut") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Funnel") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 4;
                }
                else if (GraphType == "Line") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 3;
                }
                else if (GraphType == "Pie") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 1;
                }
                else if (GraphType == "Point") {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlGraphType").selectedIndex = 5;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "block";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = true;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName").selectedIndex = 0;
                document.getElementById('DivddlModuleName').style.display = "block";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('tdcompanyType').style.display = "block";
                document.getElementById('tdcompanyType1').style.display = "block";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'block';
                document.getElementById('DivStatus1').style.display = 'block';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'block';
                document.getElementById('DivArchiveRecords1').style.display = 'block';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
            }

            else if (masterid == 11) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "none";
                document.getElementById("divddlsalesPerson1").style.display = "none";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "block";
                document.getElementById("tdRecordTypeddl").style.display = "block";
                document.getElementById("tdtaskselecttye").style.display = "block";
                document.getElementById("tdtaskselecttyeddl").style.display = "block";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById("DivDate1").style.display = "block";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'block';
                document.getElementById('pnlddlDisplay').style.display = 'block';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'block';
                document.getElementById('pnlNoOfRecords').style.display = 'block';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "block";
                document.getElementById("pnlCustomers").style.display = "block";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'block';
                document.getElementById('divsalseperson').style.display = 'block';
                document.getElementById('divsalseperson1').style.display = 'block';
                document.getElementById('divcustomer1').style.display = 'block';
                document.getElementById('DivlblEstimate').style.display = 'none';

                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;
                document.getElementById('showfullscreen').style.display = 'none';
                document.getElementById('showfullscreen1').style.display = 'none';
            }

            else if (masterid == 12) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById('Div1').style.display = 'block';
                document.getElementById('tblWidgetOption').style.display = 'block';
                document.getElementById('DivSpread').style.display = 'block';
                document.getElementById('DivSpread1').style.display = 'block';

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "block";
                document.getElementById("DivRecordDate").style.display = "block";
                document.getElementById("DivRecordDate1").style.display = "block";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "block";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1").selectedIndex = 0;
                var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
                var ddltargetdispplayType1 = ddltargetdispplayType.options[ddltargetdispplayType.selectedIndex].text;

                if (ddltargetdispplayType1 == "Tabular") {
                    document.getElementById('showfullscreen').style.display = 'none';
                    document.getElementById('showfullscreen1').style.display = 'none';
                }

            }
            else if (masterid == 13) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById('date_type_div').style.display = 'none';
                document.getElementById('DivGraphicDateType2').style.display = 'none';
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsDailyTarget").checked = false;
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "block";
                document.getElementById("DivRecordDate1").style.display = "block";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';

                document.getElementById('divddlsalesPerson').style.display = 'none';
                document.getElementById('divddlsalesPerson1').style.display = 'none';
                document.getElementById('DivRecordDate').style.display = 'none';
                document.getElementById('DivRecordDate1').style.display = 'none';
                document.getElementById('Div1').style.display = 'none';
                document.getElementById('tblWidgetOption').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'none';
                document.getElementById('DivSpread1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'block';
                document.getElementById('DivLastYearData1').style.display = 'block';
                document.getElementById('DivDailyTarget').style.display = 'block';
                document.getElementById('DivDailyTarget1').style.display = 'block';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';

                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1").selectedIndex = 1;
                var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
                var ddltargetdispplayType1 = ddltargetdispplayType.options[ddltargetdispplayType.selectedIndex].text;

                if (ddltargetdispplayType1 == "Tabular") {
                    document.getElementById('showfullscreen').style.display = 'none';
                    document.getElementById('showfullscreen1').style.display = 'none';
                }
                if (ddltargetdispplayType1 == "Graph") {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "block";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl").style.display = "none";
                    document.getElementById("pnlGraphtypectr4").style.display = "block";

                }
                document.querySelectorAll("#ddltargetdispplayType1 option").forEach(opt => {
                    if (opt.value == "Tabular") {
                        opt.disabled = true;
                    }
                });

            }
            else if (masterid == 14) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById('date_type_div').style.display = 'none';
                document.getElementById('DivGraphicDateType2').style.display = 'none';
                document.getElementById("pnlGraphtypectr6").style.display = "none";
                document.getElementById("DivlblInvoice").style.display = "none";
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = false;
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsMonthlyTarget").checked = false;

                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordDate").style.display = "block";
                document.getElementById("DivRecordDate1").style.display = "block";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "none";
                document.getElementById("pnlGraphtype").style.display = "none";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                document.getElementById('DivDateRange').style.display = 'none';
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';

                document.getElementById('divddlsalesPerson').style.display = 'none';
                document.getElementById('divddlsalesPerson1').style.display = 'none';
                document.getElementById('DivRecordDate').style.display = 'none';
                document.getElementById('DivRecordDate1').style.display = 'none';
                document.getElementById('Div1').style.display = 'none';
                document.getElementById('tblWidgetOption').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'none';
                document.getElementById('DivSpread1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'block';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'block';
                document.getElementById('DivMonthlyTarget').style.display = 'block';
                document.getElementById('DivMonthlyTarget1').style.display = 'block';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1").selectedIndex = 1;
                var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
                var ddltargetdispplayType1 = ddltargetdispplayType.options[ddltargetdispplayType.selectedIndex].text;

                if (ddltargetdispplayType1 == "Tabular") {
                    document.getElementById('showfullscreen').style.display = 'none';
                    document.getElementById('showfullscreen1').style.display = 'none';
                }
                if (ddltargetdispplayType1 == "Graph") {
                    document.getElementById("DivNoOfREcords").style.display = "none";
                    document.getElementById("pnlGraphtype").style.display = "block";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                    document.getElementById("pnlGraphtypectrl").style.display = "none";
                    document.getElementById("pnlGraphtypectr4").style.display = "block";

                }
                document.querySelectorAll("#ddltargetdispplayType1 option").forEach(opt => {
                    if (opt.value == "Tabular") {
                        opt.disabled = true;
                    }
                });

            }
            else if (masterid == 15) {

                if (DefaultDate == 1) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 0;
                }
                else if (DefaultDate == 2) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 1;
                }
                else if (DefaultDate == 3) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 2;
                }
                else if (DefaultDate == 4) {
                    document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDefaultDate").selectedIndex = 3;
                }
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_chkIsLastYearData").checked = false;
                document.getElementById("pnlGraphtypectr5").style.display = "none";
                document.getElementById("divddlsalesPerson").style.display = "block";
                document.getElementById("divddlsalesPerson1").style.display = "block";
                document.getElementById("pnlGraphtypectr4").style.display = "none";
                document.getElementById("tdtargetdisplaytype2").style.display = "none";
                document.getElementById("DivRecordsType").style.display = "none";
                document.getElementById("DivRecordsType1").style.display = "none";

                document.getElementById("DivTargetSalesPerson").style.display = "none";
                document.getElementById("DivTargetSalesPerson1").style.display = "none";


                document.getElementById("divcustomerListBox").style.display = "none";
                document.getElementById("divcustomerListBox1").style.display = "none";
                document.getElementById("tdRecordType").style.display = "none";
                document.getElementById("tdRecordTypeddl").style.display = "none";
                document.getElementById("tdtaskselecttye").style.display = "none";
                document.getElementById("tdtaskselecttyeddl").style.display = "none";

                document.getElementById("tdtargetdisplaytype").style.display = "none";
                document.getElementById("tdtargetdisplaytype1").style.display = "none";
                document.getElementById("DivDate1").style.display = "none";
                document.getElementById("DivDate2").style.display = "none";
                document.getElementById('lblModuleName').style.display = "block";
                document.getElementById("pnlGraphtype").style.display = "block";
                document.getElementById("pnlGraphtypectrl").style.display = "none";
                document.getElementById("pnlGraphtypectrl2").style.display = "none";
                document.getElementById("pnlGraphtypectrl3").style.display = "none";
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_ddlModuleName').disabled = false;
                document.getElementById('DivddlModuleName').style.display = "none";
                document.getElementById('DivddlJobsinvoicebydue').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = 'none';
                document.getElementById('pnlddlDisplay').style.display = 'none';
                document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddlDisplayType").selectedIndex = 0;
                document.getElementById('tdlblColumns').style.display = 'none';
                document.getElementById('pnlchkLatestnotes').style.display = 'none';
                document.getElementById('pnlchkCustomeractivity').style.display = 'none';
                document.getElementById('tdlblCustomers').style.display = 'none';
                document.getElementById('pnlCustomers').style.display = 'none';
                document.getElementById('tdlblTaskstatus').style.display = 'none';
                document.getElementById('pnlTasksstatus').style.display = 'none';
                document.getElementById('tdlblCompanytype').style.display = 'none';
                document.getElementById('pnlCompanyType').style.display = 'none';
                document.getElementById('divslsperson').style.display = "none";
                //document.getElementById('DivDateRange').style.display = 'block'; 
                document.getElementById('DivNoOfREcords').style.display = '';
                document.getElementById('tdlblNoOfrecords').style.display = 'none';
                document.getElementById('pnlNoOfRecords').style.display = 'none';
                document.getElementById('tdcompanyType').style.display = "none";
                document.getElementById('tdcompanyType1').style.display = "none";
                document.getElementById('tdQuarterType').style.display = "none";
                document.getElementById('tdQuarterType1').style.display = "none";
                document.getElementById('tdestimateTye').style.display = "none";
                document.getElementById('tdestimateTye1').style.display = "none";
                document.getElementById('tdQuarterdaterange').style.display = "none";
                document.getElementById('tdQuarterdaterange1').style.display = "none";
                document.getElementById('tdpnldisplay').style.display = "none";
                document.getElementById('pnlddlDisplay').style.display = "none";
                document.getElementById("tdlblCustomers").style.display = "none";
                document.getElementById("pnlCustomers").style.display = "none";
                document.getElementById('tdlblCustomers').style.display = "none";
                document.getElementById('pnlCustomers').style.display = "none";
                document.getElementById('Tr2').style.display = 'block';
                document.getElementById('Tr21').style.display = 'block';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divcustomer').style.display = 'none';
                document.getElementById('divsalseperson').style.display = 'none';
                document.getElementById('divsalseperson1').style.display = 'none';
                document.getElementById('divcustomer1').style.display = 'none';
                document.getElementById('DivlblEstimate').style.display = 'none';
                document.getElementById('DivStatus').style.display = 'none';
                document.getElementById('DivStatus1').style.display = 'none';
                document.getElementById('DivStatus2').style.display = 'none';
                document.getElementById('DivStatus3').style.display = 'none';
                document.getElementById('DivArchiveRecords').style.display = 'none';
                document.getElementById('DivArchiveRecords1').style.display = 'none';

                document.getElementById('divddlsalesPerson').style.display = 'none';
                document.getElementById('divddlsalesPerson1').style.display = 'none';
                document.getElementById('DivRecordDate').style.display = 'none';
                document.getElementById('DivRecordDate1').style.display = 'none';
                document.getElementById('Div1').style.display = 'none';
                document.getElementById('tblWidgetOption').style.display = 'none';
                document.getElementById('DivSpread').style.display = 'none';
                document.getElementById('DivSpread1').style.display = 'none';
                document.getElementById('DivLastYearData').style.display = 'none';
                document.getElementById('DivLastMonthData').style.display = 'none';
                document.getElementById('DivLastYearData1').style.display = 'none';
                document.getElementById('DivDailyTarget').style.display = 'none';
                document.getElementById('DivDailyTarget1').style.display = 'none';
                document.getElementById('DivMonthlyTarget').style.display = 'none';
                document.getElementById('DivMonthlyTarget1').style.display = 'none';
                document.getElementById('date_type_div').style.display = 'none';
                document.getElementById('DivGraphicDateType2').style.display = 'none';
                document.getElementById("DivRecordDate").style.display = "none";
                document.getElementById("DivRecordDate1").style.display = "none";
                document.getElementById("pnlGraphtypectr6").style.display = "block";
                document.getElementById("DivlblInvoice").style.display = "block";
                document.getElementById("DivDate").style.display = "block";
                document.getElementById('DivDate3').style.display = 'block';

                
                document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_Label7').innerHTML = "Sales Person";

                var showrecords = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_lblNoOfrecords');
                showrecords.innerHTML = "No of Records";

                var ShowinFullScreen = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkfullscreen');
                var ShowPrintOptions = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkPrintOption');
                var ShowAllOption = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkshowalloptions');
                ShowinFullScreen.checked = false;
                ShowPrintOptions.checked = false;
                ShowAllOption.checked = false;

                //document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1").selectedIndex = 1;
                //var ddltargetdispplayType = document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_ddltargetdispplayType1");
                //var ddltargetdispplayType1 = ddltargetdispplayType.options[ddltargetdispplayType.selectedIndex].text;
                //if (ddltargetdispplayType1 == "Tabular") {
                //    document.getElementById('showfullscreen').style.display = 'none';
                //    document.getElementById('showfullscreen1').style.display = 'none';
                //}
                //if (ddltargetdispplayType1 == "Graph") {
                //    document.getElementById("DivNoOfREcords").style.display = "none";
                //    document.getElementById("pnlGraphtype").style.display = "block";
                //    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                //    document.getElementById("pnlGraphtypectrl2").style.display = "none";
                //    document.getElementById("pnlGraphtypectrl").style.display = "block";
                //    document.getElementById("pnlGraphtypectr4").style.display = "none";

                //}
                //document.querySelectorAll("#ddltargetdispplayType1 option").forEach(opt => {
                //    if (opt.value == "Tabular") {
                //        opt.disabled = true;
                //    }
                //});

            }

            document.getElementById("spn_Title").style.display = "none";
            document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_txtTitle").value = '';
            document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_btnSave").style.display = "block";
            document.getElementById("ctl00_ContentPlaceHolder1_rwReferences_C_btnUpdate").style.display = "none";
            wnd.Show();
        }

        function chkAllLatestnotcolumns() {
            var chkAll = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllLatest');
            var cbl = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkLatestcolumns').getElementsByTagName("input");
            // If Checked
            if (chkAll.checked) {
                for (i = 0; i < cbl.length; i++) {
                    cbl[i].checked = true;
                }
            }
            else {
                for (i = 0; i < cbl.length; i++) {
                    cbl[i].checked = false;
                }
            }
        }

        function chkAllCustomerbyactcolumns() {
            var chkAll = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllCustomer');
            var cbl = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkcolscustomeractivity').getElementsByTagName("input");
            // If Checked
            if (chkAll.checked) {
                for (i = 0; i < cbl.length; i++) {
                    cbl[i].checked = true;
                }
            }
            else {
                for (i = 0; i < cbl.length; i++) {
                    cbl[i].checked = false;
                }
            }
        }

        function ReplaceAllSpecialChar(CompleteString) {
            if (CompleteString != null && CompleteString != undefined) {
                CompleteString = CompleteString.split("%27").join("'");
                CompleteString = CompleteString.split("%22").join("\"");
                CompleteString = CompleteString.split("%5C").join(/\\/g);
                return CompleteString;
            }
            else {
                return CompleteString;
            }
        }

        function chkUncheckAll(ctrl) {
            if (ctrl == 'latestnotes') {
                var chkedCount = 0;
                var chkAll = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllLatest');
                var tblChkALL = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkLatestcolumns');
                var chkCount = tblChkALL.getElementsByTagName('input');
                for (var i = 0; i < chkCount.length; i++) {
                    if (chkCount[i] != null) {
                        if (chkCount[i].checked == true) {
                            chkedCount++;
                        }
                    }
                }

                if (chkedCount == chkCount.length) {
                    chkAll.checked = true;
                }
                else {
                    chkAll.checked = false;
                }
            }
            else if (ctrl == 'customeractivity') {
                var chkedCount = 0;
                var chkAll = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkAllCustomer');
                var tblChkALL = document.getElementById('ctl00_ContentPlaceHolder1_rwReferences_C_chkcolscustomeractivity');
                var chkCount = tblChkALL.getElementsByTagName('input');
                for (var i = 0; i < chkCount.length; i++) {
                    if (chkCount[i] != null) {
                        if (chkCount[i].checked == true) {
                            chkedCount++;
                        }
                    }
                }

                if (chkedCount == chkCount.length) {
                    chkAll.checked = true;
                }
                else {
                    chkAll.checked = false;
                }
            }
        }

        $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlDateTypeMini").change(function () {
            debugger;
            var selected_value = this.value;

            if (selected_value == "YearToDate") {
                $("#trYearToDate").css('display', '');
                $("#trDateRange").css('display', 'none');
            } else if (selected_value == "DateRange") {
                $("#trYearToDate").css('display', 'none');
                $("#trDateRange").css('display', '');
            } else {
                $("#trYearToDate").css('display', 'none');
                $("#trDateRange").css('display', 'none');
            }
        });

        $("#ctl00_ContentPlaceHolder1_rwReferences_C_ddldate").change(function () {
            debugger;
            var selected_value = this.value;

            if (selected_value == "YearToDate") {
                $("#trYearToDate2").css('display', '');
                $("#trDateRange2").css('display', 'none');
            } else if (selected_value == "DateRange") {
                $("#trYearToDate2").css('display', 'none');
                $("#trDateRange2").css('display', '');
            } else {
                $("#trYearToDate2").css('display', 'none');
                $("#trDateRange2").css('display', 'none');
            }
        });

        $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_ddlDateTypeMiniNew").change(function () {
            debugger;
            var selected_value = this.value;

            if (selected_value == "YearToDate") {
                $("#trYearToDate").css('display', '');
                $("#trDateRange").css('display', 'none');
            } else if (selected_value == "DateRange") {
                $("#trYearToDate").css('display', 'none');
                $("#trDateRange").css('display', '');
            } else {
                $("#trYearToDate").css('display', 'none');
                $("#trDateRange").css('display', 'none');
            }
        });

        $("#ctl00_ContentPlaceHolder1_rwReferencesMini_C_DropDownList2").change(function () {
            debugger;
            var selected_value = this.value;

            if (selected_value == "Daily") {
                $("#trDailyTarget").css('display', '');
                $("#trMonthlyTarget").css('display', 'none');
            }
            else {
                $("#trDailyTarget").css('display', 'none');
                $("#trMonthlyTarget").css('display', '');
            }
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
