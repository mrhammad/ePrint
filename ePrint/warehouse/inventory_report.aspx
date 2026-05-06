<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withoutLeftTD.master" autoeventwireup="true" CodeBehind="inventory_report.aspx.cs" Inherits="ePrint.warehouse.inventory_report" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/usercontrol/pagingreport.ascx" TagName="Paging" TagPrefix="UC" %>
<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<%@ Register TagPrefix="UC" TagName="Savereport" Src="~/usercontrol/Reports.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="reports">
        <%--<asp:ScriptManager ID="scr1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>--%>
     <%-- added 16/3/2016--%>
       <link href="../App_Themes/Theme1/item.css" rel="stylesheet" type="text/css" />
        <script src="../js/progressbar.js" type="text/javascript"></script>
        <%-- end--%>
        <link type="text/css" href="<%=strSitepath %>css/smoothness/jquery-ui-1.8.21.custom.css"
            rel="stylesheet" />
        <%--<script src="../js/jquery-1.3.2.js" type="text/javascript"></script>--%>
        <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
        <script src="../js/jquery.ui.tabs.js" type="text/javascript"></script>
        <script type="text/javascript" src="<%=strSitepath %>js/jquery-ui-1.8.21.custom.min.js?VN='<%#VersionNumber%>'"></script>
        <%--<script type="text/javascript" src="<%=strSitepath %>js/item/general.js?VN='<%=VersionNumber%>'"></script>--%>
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
       <%-- added 16/3/2016  ticket 12940 jscript--%>
            function jScript() {
                $("#lnkSelectAll").click(function () {
                    SelectAll();
                });
                for (var m = 1; m < chk.length - 1; m++) {
                    if (document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_' + m).checked || chk[m].checked) {
                        lnkSelectAll.innerHTML = "Select None";
                    }
                    else {
                        lnkSelectAll.innerHTML = "Select All Columns";
                    }
                }
            }
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
                //        var accordionindex = Number($("#UIPViewModel_ActiveAccordion").val());
                //        alert("Setting active index to " + accordionindex);
                //        $("#accordion").accordion('activate', accordionindex);
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
                width: 21%;
            }
        </style>
        <%--  <style>
        /*-------------------------- Arrow List Menu Region Starts ----------------------------*/.arrowlistmenu
        {
        }
        .arrowlistmenu ul
        {
            /*CSS for UL of each sub menu*/
            list-style-type: none;
            margin: 0;
            padding: 0;
            margin-bottom: 0px; /*bottom spacing between each UL and rest of content*/
        }
        .arrowlistmenu ul li
        {
            padding-bottom: 2px; /*bottom spacing between menu items*/
        }
        .arrowlistmenu ul li a
        {
            color: Gray;
            background: url(../images/arrowbullet.png) no-repeat center left; /*custom bullet list image*/
            display: block;
            padding: 3px 0;
            padding-left: 19px; /*link text is indented 19px*/
            text-decoration: none;
            font-weight: bold;
            border-bottom: 1px solid #dadada;
            font-size: 70%;
            font-family: Arial,verdana,Helvetic;
        }
        .arrowlistmenu ul li a:visited
        {
            color: Gray; /*#A70303;*/
        }
        .arrowlistmenu ul li a:hover
        {
            /*hover state CSS*/
            color: #A70303;
            background-color: #F3F3F3;
        }
    </style>--%>
        <%--    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>--%>
        <script>
            var Pgtype = '<%=pg %>';
        </script>
        <%-- <style>
        .active
        {
            background-color: #DADADA;
        }
        .active1
        {
            background-color: white;
        }
    </style>--%>
        <div id="div_option" runat="server">
            <div class="navigatorpanel">
                <%--<div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" nowrap="nowrap">
                                <span class="navigatorpanel">Inventory Report</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
                <div style="clear: both;">
                </div>
            </div>
            <%--<div id="waitmessage" style="z-index: -1; left: 0px; visibility: hidden; width: 300px;
        position: absolute; top: 200px; height: 100px">        
        <table cellpadding="0" cellspacing="10">
            <tr>
                <td align="right" bordercolor="#ffffff">
                    <div style="float: left">
                        <asp:Image ID="imgHourglass" runat="server" ImageUrl="~/images/loading_new.gif" />
                    </div>
                   
                </td>
            </tr>
        </table>
    </div>--%>
    <%--added 16/3/2016 for ticket 12940 updateprogress--%>
            <asp:UpdateProgress ID="upprocessnew" runat="server">
                <ProgressTemplate>
                    <div id="divBackGround1">
                        <div id="divLoading" style="position: absolute; top:50%;left:50%; z-index: 800; display: block;">
                            <div class="Graphic">
                                <div style="padding-left: 25px">
                                    <img src="<%=strImagepath %>loading_new.gif" border="0" alt="" />
                                </div>
                                <div style="clear: both">
                                
                                </div>
                            </div>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div id="divtab" runat="server">
                <div style="display: none" id="padding">
                    <ul>
                        <li id="li_Save" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_SR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px;
                                float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="spn_1" onclick="Call_Report(this.id);">
                                    <%=objLangClass.GetLanguageConversion("Saved_Reports") %>
                                </span></b>
                            </div>
                        </li>
                        <li id="li_Customize" style="cursor: pointer; float: left; clear: right; display: block;">
                            <div id="div_CR" nowrap="nowrap" style="height: 20px; padding: 0px 20px 0px 20px;
                                float: left; line-height: 20px; margin-right: 2px">
                                <b><span id="spn_2" onclick="Call_Report(this.id);">
                                    <%=objLangClass.GetLanguageConversion("Customized_Report") %></span></b>
                            </div>
                        </li>
                    </ul>
                    <div style="clear: both;">
                    </div>
                </div>
                <div id="tabs" class="ui-tabs" style="width: 98%; border: solid 0px red; visibility: hidden;
                    padding-top: 3px; padding-left: 5px">
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
                        <div id="divusrReportsave" style="display: <%=divVisibility%>; margin-left: -11.2px;
                            width: 102%; margin-top: -11px; margin: -12px 0px 0px -12px; border: solid 1px #AAAAAA;
                            -moz-border-radius-topright: 4px; -webkit-border-top-right-radius: 4px; -khtml-border-top-right-radius: 4px;
                            border-top-right-radius: 4px; -moz-border-radius-topleft: 0px; -webkit-border-top-left-radius: 0px;
                            -khtml-border-top-left-radius: 0px; border-top-left-radius: 0px; -moz-border-radius-bottomright: 4px;
                            -webkit-border-bottom-right-radius: 4px; -khtml-border-bottom-right-radius: 4px;
                            border-bottom-right-radius: 4px; border: 1px solid rgb(170, 170, 170);">
                            <UC:Savereport ID="usrReportsave" runat="server" />
                        </div>
                    </div>
                    <div id="tabs-2" class="ui-tabs-hide">
                        <div id="div_showfilters" style="display: <%=imgVisibility%>; margin-left: -11px;
                            float: left; margin-top: -11px; width: 100%;">
                            <div id="Div1" class="report_customizetab">
                                <div id="div_Error" align="center" style="width: 100%; display: none">
                                    <span id="spnError" runat="server" class="spanerrorMsg" style="width: 300px; text-align: center">
                                        Please check at least one column to generate report</span></div>
                                <div class="only5px">
                                </div>
                                <div align="left" style="width: 100%">
                                    <telerik:RadPanelBar runat="server" ID="RadPanelBar1" Width="950px" Height="100%"
                                        Skin="Default" ExpandMode="MultipleExpandedItems" CssClass="New">
                                        <Items>
                                            <telerik:RadPanelItem Text="Select Columns To Run Report" Font-Bold="true" Expanded="true"
                                                CssClass="rounded-ReportTopcorners" Selected="true">
                                                <%-- <HeaderTemplate>
                                                <asp:CheckBox ID="lnkSelectAll" runat="server" Style="vertical-align: middle; position: relative"
                                                    onclick="javascript:SelectAll();" />
                                                <span style="cursor: pointer; font-weight: bold">Select columns to run report</span><span
                                                    class="rpExpandHandle"> </span>
                                            </HeaderTemplate>--%>
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanelddlInvCategory" runat="server">
                                                        <ContentTemplate>
                                                        <%--added 16/3/2016 for ticket 12940 script tag----%>
                                                            <script type="text/javascript" language="javascript">
                                                                Sys.Application.add_load(jScript);
                                                            </script>
                                                            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="multiPage">
                                                                <telerik:RadPageView runat="server" ID="RadPageView1">
                                                                    <div class="reportcolumn">
                                                                        <div align="left" style="width: 50%; padding: 5px">
                                                                            <div class="bgReportlabel" style="width: 170px">
                                                                                <asp:Label ID="Label41" CssClass="normaltext" runat="server"> <%=objLangClass.GetLanguageConversion("Select_Inventory_Category")%></asp:Label>
                                                                                <span style="color: Red;">*</span>
                                                                            </div>
                                                                            <div class="ddlsetting">
                                                                                <asp:DropDownList ID="ddlInvCategory" CssClass="normaltext" runat="server" Width="200px"
                                                                                    AutoPostBack="true" OnDataBound="ddlInvCategory_databound" OnSelectedIndexChanged="ddlInvCategory_OnSelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="onlyempty">
                                                                        </div>
                                                                        <div class="ColoumnDiv">
                                                                            <table>
                                                                                <td valign="bottom">
                                                                                    <div align="left" style="width: 100%; padding: 5px;">
                                                                                        <a href="javascript:\\" id="lnkSelectAll" style="font-size: 0.8em;">
                                                                                            <%=objLangClass.GetLanguageConversion("Select_All_Columns")%></a>
                                                                                    </div>
                                                                                </td>
                                                                                <tr>
                                                                                    <td>
                                                                                        <div align="left" style="margin-top: -4px">
                                                                                            <asp:CheckBoxList ID="chkColumns" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"
                                                                                                Width="700px" CssClass="chkBoxListEst">
                                                                                                <asp:ListItem Text="" Value="InventoryCode" Selected="true"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="InventoryName"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="Supplierid"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="Cost"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="InStock"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="QuantityUsed"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="PackedIn"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="PackedPrice"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="createddate"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="basisweight" Enabled="false"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="Coated" Enabled="false"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="Colour" Enabled="false"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="itempapersize" Enabled="false"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="itemcustomsize" Enabled="false"></asp:ListItem>
                                                                                                <asp:ListItem Text="" Value="Caliper" Enabled="false"></asp:ListItem>
                                                                                            </asp:CheckBoxList>
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </telerik:RadPageView>
                                                            </telerik:RadMultiPage>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ContentTemplate>
                                            </telerik:RadPanelItem>
                                            <telerik:RadPanelItem Text="Report Filters" Font-Bold="true" CssClass="rounded-ReportTopcorners"
                                                Expanded="false">
                                                <ContentTemplate>
                                                    <telerik:RadMultiPage runat="server" ID="rad2" SelectedIndex="0" CssClass="multiPage">
                                                        <telerik:RadPageView runat="server" ID="view2">
                                                            <%--<div class="navigatorpanel">
                        <div class="t">
                            <div class="t">
                                <div class="t">
                                    <div class="divpadding">
                                        <div align="left" nowrap="nowrap">
                                            <span class="navigatorpanel">Report Filters </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>--%>
                                                            <div class="ColoumnDiv2">
                                                                <div align="left" style="width: 100%">
                                                                    <div align="left" style="width: 100%; padding: 5px">
                                                                        <div align="left" style="width: 100%">
                                                                            <div class="bgReportlabel" style="width: 19%">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Pack_Sale_Price_Range")%></span></div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;</div>
                                                                            <div style="float: left">
                                                                                <asp:DropDownList ID="ddlEstimateRange" runat="server" CssClass="normalText" Width="200px">
                                                                                    <%--<asp:ListItem Value="0">--- Any ---</asp:ListItem>
                                            <asp:ListItem Value="500">Below $500</asp:ListItem>
                                            <asp:ListItem Value="2500">$501-$2500</asp:ListItem>
                                            <asp:ListItem Value="5000">$2501-$5000</asp:ListItem>
                                            <asp:ListItem Value=">5000">Above $5000</asp:ListItem>--%>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                            <div id="divchkEstimate" style="float: left; padding-left: 5px">
                                                                                <asp:CheckBox ID="chkEstimate" runat="server" Checked="true" Text="Show Price with no assigned value" />
                                                                            </div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="width: 100%">
                                                                            <div class="bgReportlabel" style="width: 19%">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Select_Supplier")%></span></div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;</div>
                                                                            <div style="float: left;">
                                                                                <div style="float: left;">
                                                                                    <asp:TextBox ID="txtName" SkinID="textPad" runat="server" AutoCompleteType="disabled"
                                                                                        Width="200px"></asp:TextBox><%--onkeyup="BindSupplierName(this.value,event,this);"--%>
                                                                                    <div class="onlyEmpty">
                                                                                    </div>
                                                                                    <div id="divCheck" onmouseover="showddl('divCheck');" onmouseout="ShowOff('divCheck');">
                                                                                    </div>
                                                                                </div>
                                                                                <div style="float: left; padding: 1 0 0 1px; cursor: pointer; display: none;">
                                                                                    <img id="img_down01" src="<%=strImagepath %>down01.gif" onclick="BindClientName('',event,this);"
                                                                                        style="padding: 1 1 1 1px; border: solid 1px silver;" width="12px" />
                                                                                </div>
                                                                            </div>
                                                                            <asp:HiddenField ID="hid_ClientID" runat="server" Value="0" />
                                                                            <div class="onlyEmpty">
                                                                            </div>
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
                                                                                    background-color: white; /*
                                        scrollbar-arrow-color:black;
                                        scrollbar-base-color:#CCC;
                                        scrollbar-darkshadow-color:#CCC;
                                        scrollbar-face-color:#CCC;
                                        scrollbar-highlight-color:black;
                                        scrollbar-shadow-color:black;
                                        */
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
                                                                                    background-color: white; /*
                                        scrollbar-arrow-color:black;
                                        scrollbar-base-color:#CCC;
                                        scrollbar-darkshadow-color:#CCC;
                                        scrollbar-face-color:#CCC;
                                        scrollbar-highlight-color:black;
                                        scrollbar-shadow-color:black;
                                        */
                                                                                }
                                                                                .divpad
                                                                                {
                                                                                    padding: 2px;
                                                                                }
                                                                                .active
                                                                                {
                                                                                    background-color: #DADADA;
                                                                                }
                                                                                .active1
                                                                                {
                                                                                    background-color: white;
                                                                                }
                                                                            </style>
                                                                        </div>
                                                                        <div align="left" style="width: 100%">
                                                                            <div class="bgReportlabel" style="width: 19%">
                                                                                <span>
                                                                                    <%=objLangClass.GetLanguageConversion("Free_Text")%></span></div>
                                                                            <div style="float: left; width: 5px">
                                                                                &nbsp;</div>
                                                                            <div style="float: left;">
                                                                                <asp:TextBox ID="txtFreetext" runat="server" SkinID="textPad" MaxLength="255" Width="200px"></asp:TextBox>
                                                                                <span class="smallgraytext">&nbsp;(<%=objLangClass.GetLanguageConversion("Inventory_Freetext")%>)</span></div>
                                                                            <div class="onlyEmpty">
                                                                            </div>
                                                                        </div>
                                                                        <div align="left" style="margin-left: -7px; padding: 2px">
                                                                            <table style="width: 700px;">
                                                                                <tr>
                                                                                    <td style="width: 162px;">
                                                                                        <asp:CheckBox ID="chkDateOption" runat="server" Font-Bold="true" Text="Date Options"
                                                                                            onclick="javascript:EnableDateOption();OnCheckShow()" />
                                                                                        <%--<span id="Span1" runat="server" class="smallgraytext">(<%=objLangClass.GetLanguageConversion("Date_Format")%>:
                                                                    <%=DateFormat %>
                                                                    )</span>--%>
                                                                                    </td>
                                                                                    <td style="width: 160px;">
                                                                                        <asp:DropDownList ID="rdlDate" Enabled="false" runat="server" onChange="javascript:GetDropdownBind();"
                                                                                            Width="200px">
                                                                                            <asp:ListItem Text="Today" Value="daily"></asp:ListItem>
                                                                                            <asp:ListItem Text="Yesterday" Value="yesterday"></asp:ListItem>
                                                                                            <asp:ListItem Text="Current Month" Value="thismonth" Selected="true"></asp:ListItem>
                                                                                            <asp:ListItem Text="Current Quarter" Value="thisquarter"></asp:ListItem>
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
                                                                                        <span id="spn_daily" style="display: none" runat="server" class="smallgraytext">(26/10/2009)</span> 
                                                                                        <span id="spn_yest" style="display: none" runat="server" class="smallgraytext">(25/10/2009)</span>
                                                                                        <span id="spn_month" runat="server" style="display: none" class="smallgraytext">(1/10/2009 to 31/10/2009)</span> 
                                                                                        <span id="spn_quarter" runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span>
                                                                                        <span id="spn_lastque" runat="server" style="display: none" class="smallgraytext">(Oct - Dec 2009)</span> 
                                                                                        <span id="spn_year" runat="server" style="display: none" class="smallgraytext">(2009)</span>
                                                                                        <span id="span_halfyear" runat="server" style="display: none" class="smallgraytext">(Oct 2013 - March 2014)</span>
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
                                                                        </div>
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
                                                    <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" CssClass="multiPage">
                                                        <telerik:RadPageView runat="server" ID="RadPageView2">
                                                            <div class="FilterJob">
                                                                <div align="left" style="padding: 3px; padding-top: 7px">
                                                                    <div align="left" style="width: 100%">
                                                                        <div class="bgReportlabel" style="width: 19%">
                                                                            <span class="HeaderText">
                                                                                <%=objLangClass.GetLanguageConversion("Report_Name")%></span>&nbsp;<span style="vertical-align: middle;
                                                                                    color: Red">*</span>
                                                                        </div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;</div>
                                                                        <div style="float: left">
                                                                            <asp:TextBox ID="txtSaveReports" runat="server" SkinID="textPad" MaxLength="200"
                                                                                Width="200px" />
                                                                            <asp:HiddenField ID="hdn_reportID" runat="server" />
                                                                        </div>
                                                                        <div class="onlyEmpty">
                                                                        </div>
                                                                    </div>
                                                                    <div align="left" style="width: 100%">
                                                                        <div class="bgReportlabel invbg_heightwidth">
                                                                            <span>
                                                                                <%=objLangClass.GetLanguageConversion("Description")%></span></div>
                                                                        <div style="float: left; width: 5px">
                                                                            &nbsp;</div>
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
                                    <div class="only10px">
                                    </div>
                                    <div align="left" style="width: 100%">
                                        <div style="float: left">
                                            <div style="display: block">
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" OnClick="btnCancel_OnClick"
                                                    OnClientClick="javascript:loadingimage(this.id,'div_cancelprocess');" />
                                            </div>
                                            <div id="div_cancelprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left">
                                            <div id="div_saverun" style="display: block">
                                                <asp:Button ID="btnSaveRun" runat="server" Text="Save and Run" CssClass="button"
                                                    OnClick="btnSaveRun_OnClick" OnClientClick="javascript:var a=ValidateCaller();if(a) loadingimage(this.id,'div_saverunprocess');return a;" /></div>
                                            <div id="div_saverunprocess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <div style="float: left; width: 10px">
                                            &nbsp;
                                        </div>
                                        <div style="float: left; width: 117px">
                                           <div id="div_update" style="display:block">
                                            <asp:Button ID="btnUpdateExisting" runat="server" Text="Update Report" CssClass="button"
                                                OnClick="btnUpdateExisting_OnClick" Visible="false" OnClientClick="javascript:var a=ValidateCaller(); if(a)loadingimage(this.id,'div_btnUpdateProcess'); return a;" />
                                            </div>
                                            <div id="div_btnUpdateProcess" style="display: none">
                                                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                            </div>
                                        </div>
                                        <%-- <div style="float: left; width: 10px">
                                        &nbsp;
                                    </div>--%>
                                        <div style="float: left">
                                            <div id="div_btnrunreport" style="display: block">
                                                <asp:Button ID="btnRunReport" runat="server" Text="Run Report" CssClass="button"
                                                    OnClick="btnRunReport_OnClick" OnClientClick="javascript:var a=Runvalidate();if(a!=false)loadingimage(this.id,'div_runreportprocess');return a;" />
                                                <%--return funcCaller();" />--%>
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
                            <div class="only5px">
                            </div>
                        </div>
                    </div>
                    <div class="only5px">
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
        <div align="left" style="width: 100%">
            <div style="float: left; width: 100%">
                <%-- <div style="float: left">
                    </div>
                    <div style="float: left; width: 10px">
                        &nbsp;
                    </div>
                    <div style="float: left">
                    </div>--%>
                <div id="div_searchres" style="float: left; padding-left: 5px; width: 65%" class="successfulMsg"
                    runat="server" visible="false">
                    <asp:Label ID="lbl_searchres" runat="server" ForeColor="gray"></asp:Label>
                </div>
                <%--<div style="float: left; width: 10px">
                    &nbsp;
                </div>--%>
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
                                            <td class="act_floatleft" nowrap="nowrap">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt1" runat="server" Width="40px" Visible="false" onblur="javascript:AllowNumber(this,this.value)"></asp:TextBox>&nbsp;
                                            </td>
                                            <td class="act_floatleft" nowrap="nowrap">
                                                <asp:ImageButton ToolTip="GoTo" ImageUrl="~/images/gotopage.gif" ID="btngo" runat="server"
                                                    OnClick="btngo_OnClick" Visible="false" OnClientClick="javascript:return showWaitMessage();"
                                                    BackColor="Transparent" />
                                            </td>
                                            <td align="left">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <div id="div_Total" runat="server" visible="false" style="float: right; padding-right: 10px">
                                        <span class="normalText">
                                            <%=objLangClass.GetLanguageConversion("Total_Records")%>:</span> <b>
                                                <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="only5px">
                    </div>
                    <div id="div_Main" runat="server">
                        <div id="a">
                        </div>
                        <div id="div_Grid">
                            <asp:GridView ID="GridEstReport" CssClass="t" runat="server" Width="100%" SkinID="GridStyleReport"
                                HeaderStyle-HorizontalAlign="Left" PageSize="100" RowStyle-HorizontalAlign="Left"
                                CellPadding="1" Style="table-layout: fixed">
                            </asp:GridView>
                        </div>
                    </div>
                    <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                        <div id="Div2" class="emptyrecords" align="center">
                            <span class="HeaderText" style="text-align: center">
                                <%=objLangClass.GetLanguageConversion("No_Record_Found")%></span>
                        </div>
                    </asp:Panel>
                    <div class="only10px">
                    </div>
                </div>
            </div>
            <div class="onlyEmpty">
            </div>
        </div>
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

            function Call_Report(liID) {
                if (document.getElementById(liID) != null) {          // IE, on 23.07.2011...
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
                Check = true;
                var count = 0;
                for (var j = 0; j < chkColumns.length; j++) {
                    if (chkColumns[j].checked) {
                        count++;
                    }
                }
                if (count == 0) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Column_To_Generate_Report")%>');
                    return false;
                }

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

            function GetSelect() {
                var x = 0;
                for (var i = 0; i < chk.length; i++) {
                    if (!chk[i].disabled) {
                        if (chk[i].checked == true) {
                            lnkSelectAll.innerHTML = "Select None";
                        }
                        else {
                            lnkSelectAll.innerHTML = "Select All";
                        }
                    }
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
                // GetDropdownBindonBack();
                GetDropdownBind();
                EnableDateOption();
            }

            function OnEditReport() {

                GetDropdownBind();
                EnableDateOption();

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
             <%-- changed 16/3/2016  ticket 12940 jscript--%>
            function SelectAll() {
                var Count = 0;

                if (lnkSelectAll.innerHTML.trim() == "Select All Columns" || lnkSelectAll.innerHTML == "Select All Columns") {
                    for (var i = 0; i < chk.length; i++) {
                        if (!chk[i].disabled) {
                            chk[i].checked = true;

                            for (var j = 0; j <= chk.length - 1; j++) {
                                if (!document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_' + j).disabled)
                                    document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_' + j).checked = true;
                            }

                            lnkSelectAll.innerHTML = "Select None";
                            document.getElementById('lnkSelectAll').innerHTML = "Select None";

                        }
                    }
                }
                else {
                    for (var i = 1; i < chk.length; i++) {
                        chk[i].checked = false;
                        document.getElementById('ctl00_ContentPlaceHolder1_RadPanelBar1_i0_chkColumns_' + i).checked = false;
                        lnkSelectAll.innerHTML = "Select All Columns";
                        document.getElementById('lnkSelectAll').innerHTML = "Select All Columns";
                    }
                }
            }
            function EnableDateOption() {
                var rdlDateArray = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdlDate");
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
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_month");

                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdlDate");
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
                var spn_1 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_daily");
                var spn_2 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_yest");
                var spn_3 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_month");
                var spn_4 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_quarter");
                var spn_5 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_year");
                var tilldate = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_tilldate");
                var spn_6 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_divjobdate");
                var spn_7 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_lastque");
                var spn_8 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_span_halfyear");
                var spn_9 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_lastweek");
                var spn_10 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_lastmonth");
                var spn_11 = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_spn_lastyear");
                var ddlJobCreated = document.getElementById("ctl00_ContentPlaceHolder1_RadPanelBar1_i1_rdlDate");
                var ddlvalue = ddlJobCreated.options[ddlJobCreated.selectedIndex].value;

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


            function GetDropdownBindonBack() {
                for (var i = 0; i < radio.length; i++) {
                    if (chkDateOption.checked = true) {
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
            }

        </script>
        <script>
            //********** web service to autocomplete clientname *********//
            function showddl(divid) {
                document.getElementById(divid).style.display = "block";
                //ddlEstimateRange.style.display = "none";
                //divchkEstimate.style.display = "none";
                //lstStatus.style.display = "none";        
            }
            function ShowOff(divid) {
                document.getElementById(divid).style.display = "none";
                //ddlEstimateRange.style.display = "block";
                //divchkEstimate.style.display = "block";
                //lstStatus.style.display = "block";
            }
            this.pointer = 0;
            function BindSupplierName(txtval, e, objectname) {
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
                                if (txtval.length > 3) {
                                    this.pointer = 0;
                                    var CompID = '<%=CompanyID %>';
                                    var val = CompID + "±" + txtval;
                                    PageMethods.GetSupplierName(val, FindSuccsss);
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

            function FindSuccsss(result) {
                //alert("result="+result);
                if (trim12(result) != '') {
                    showddl('divCheck');
                    var divCheck = document.getElementById("divCheck");

                    var str_prop1 = result.split('µ');
                    //alert("str_prop1µ="+str_prop1);
                    var store_Name = '';
                    var store_ID = '';
                    var store_contacts = '';
                    var store_accountno = '';
                    var store_address = '';

                    var finalval = '';
                    for (var i = 0; i < str_prop1.length - 1; i++) {
                        var str_prop2 = str_prop1[i].split('$'); //1$Weight^Color^^^^^  
                        //alert("str_prop2$="+str_prop2);                         
                        store_ID = str_prop2[0];
                        store_Name = str_prop2[1];
                        store_contacts = str_prop2[2];
                        store_accountno = str_prop2[3];
                        store_address = str_prop2[4];
                        //alert("acc="+store_accountno);        
                        var color1 = "#DADADA";
                        if (i % 2 == 0) {
                            color1 = "#EFEFEF";
                        }
                        finalval += " <div class='divpad' style='height:20px;z-index:1000;'>";
                        finalval += " <a href='#' onclick=\"javaScript:GetClientName11('" + store_ID + "','" + store_Name + "','" + store_contacts + "','" + store_accountno + "','" + store_address + "')\">" + store_Name + "</a>";
                        finalval += "</div>";
                        //document.getElementById("lstClientName").add(new Option(store_Name,store_ID));//To bind listbox
                    }
                    divCheck.innerHTML = finalval;
                    //Response.Write("<a class='aFooter' href=\"javaScript:SelectItem('" + user+ "," + type + "')\">" + user + "" + type + "</a><br>");          
                }
                else {
                    ShowOff('divCheck');
                }
            }

            function GetClientName11(store_ID, store_Name, store_contacts, store_accountno, store_address) {
                txtName.value = SpecialDecode(store_Name);
                hid_ClientID.value = store_ID;
            }
            //    function GetClientName11(ClientID,ClientName,Contacts,AccountNo,Address)
            //    {
            //        txtName.value = ClientName;
            //        hid_ClientID.value = ClientID;
            //    }
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
                    //document.getElementById("div_Error").style.display = "block";
                    alert("Please check at least one column to generate report");
                    CheckFinal = false;
                }

                if (chkDateOption.checked) {
                    var spndateRange = document.getElementById("spndateRange");
                    for (var i = 0; i < radio.length; i++) {
                        if (radio[i].checked) {
                            if (radio[i].value == "daterange") {
                                /*
                                var startDate = getDateObject(txtFromDate.value,"/");
                                var endDate = getDateObject(txtToDate.value,"/");
                                if(startDate < endDate)
                                {
                                alert("startDate is less than endDate");
                                }
                                if(startDate === endDate)
                                {
                                alert("startDate is greater than or equal to endDate");
                                }
                                */
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
                                //                else
                                //                {
                                //                    spndateRange.style.display='block';
                                //                    CheckFinal = false;    
                                //                }                                  
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
            function Disablelnk()
            { }

            function getInnerHtml() {
                var element = document.getElementById("ctl00_ContentPlaceHolder1_divexport");
                var store = document.getElementById("ctl00_ContentPlaceHolder1_hdnInnerHtml");
                store.value = element.innerHTML;

            }
            document.getElementById("div_Load").style.display = "none";
            document.getElementById("ds00").style.display = "none";

        </script>
        <script>
            function Runvalidate() {
                Check = true;
                var count = 0;
                for (var j = 0; j < chkColumns.length; j++) {
                    if (chkColumns[j].checked) {
                        count++;
                    }
                }
                if (count == 0) {
                    alert('<%=objLangClass.GetLanguageConversion("Please_Check_Atleast_One_Column_To_Generate_Report")%>');
                    return false;
                }
            }
        </script>
    </div>
</asp:Content>

