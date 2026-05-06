<%@ page language="C#" trace="false" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" CodeBehind="welcome.aspx.cs" Inherits="ePrint.welcome" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Loading" Src="~/usercontrol/settings/Loading.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .RadGrid_Default .rgCommandRow
        {
            background: none;
        }
        
        .RadGrid_Default .rgCommandRow a
        {
            color: #10357F;
            text-decoration: none;
            margin-left: -10px;
        }
        
        .RadGrid_Default .rgCommandCell
        {
            border: none;
        }
        
        .RadGrid_Default .rgHeader
        {
            border: 0;
            border-top: 1px solid #828282;
            border-bottom: 1px solid #828282;
        }
        
        .RadGrid_Default
        {
            outline: none;
        }
        
        #ctl00_ContentPlaceHolder1_GridViewTask tr:hover
        {
            background-color: #D8D8D8;
        }
        
        #ctl00_ContentPlaceHolder1_GridViewTask tr
        {
            height: 28px !important;
        }
        
        #ctl00_ContentPlaceHolder1_GridViewTask td
        {
            border-bottom: 1px solid #C9C9C9;
        }
    </style>
    <link href="css/RadComboBox_eprintSkin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/CommonOpenPopup.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" language="javascript" src="common/GridViewClickable.js?VN='<%=VersionNumber%>'"></script>
    <%--<script src="../js/Item/javascript.js?VN='<%=VersionNumber%>'" type="text/javascript" language="javascript"></script>--%>
    <script type="text/javascript" src="CastleBusyBox.js?VN='<%=VersionNumber%>'"></script>
    <asp:UpdateProgress ID="Uppro" runat="server">
        <ProgressTemplate>
            <div id="div_Loading" align="left" style="position: absolute; height: 50px; width: 200px;
                top: 45%; left: 45%;">
                <UC:Loading ID="ucLoading" runat="server" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- <asp:PlaceHolder ID="plhHeader" runat="server"></asp:PlaceHolder>--%>
    <div style="min-height: 420px;">
        <table width="100%" border="0" cellpadding="0" align="Center" cellspacing="0" style="margin-top: -10px;">
            <tr>
                <td>
                    <%-- <img alt="" src="<%=strImagepath%>nil.gif" height="2" />--%>
                </td>
            </tr>
            <tr>
                <td>
                    <div align="center" style="position: absolute; left: 35%;">
                        <div style="width: 90%">
                            <asp:UpdatePanel ID="UPMessage" RenderMode="Inline" runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder ID="plhMessage" runat="server"></asp:PlaceHolder>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <div class="successfull_message2">
                        <asp:Label ID="lblsuccessfull" Visible="false" runat="server" CssClass="successfull_message"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table cellpadding="0" cellspacing="4" border="0" width="100%" style="display: none;">
                        <tr>
                            <td width="36%">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="100%" class="bgcustomize" height="23px">
                                            <span class="navigatorpanel">&nbsp;&nbsp;
                                                <%=objLanguage.GetLanguageConversion("Todays_Events")%></span>
                                        </td>
                                    </tr>
                                    <tr style="height: 167px;">
                                        <td align="left" valign="top" width="33%" colspan="3" nowrap="nowrap">
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="inline">
                                                <ContentTemplate>
                                                    <div style='height: 170px; overflow-y: scroll; border: 1px solid #BDBDBD; width: 100%'>
                                                        <div>
                                                            <asp:GridView ID="GridView1" EnableViewState="true" runat="server" OnRowDataBound="GridView1_RowDataBound"
                                                                CellSpacing="1" Width="100%" GridLines="None" SkinID="GridStyle" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" SortExpression="Eventdate" ItemStyle-Width="15%"
                                                                        HeaderStyle-Height="10px" HeaderStyle-BackColor="#636D89">
                                                                        <HeaderStyle HorizontalAlign="Left" Width="15%" Wrap="false" />
                                                                        <HeaderTemplate>
                                                                            <div style="padding-left: 2px; color: White;" class="HeaderText">
                                                                                <asp:Label ID="Label1" runat="server" Text="Time"></asp:Label>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 99%; overflow: hidden">
                                                                                <asp:Label ID="lblTime" runat="server" Text='<%#Eval("EventTime") %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Wrap="false" ItemStyle-VerticalAlign="Top" SortExpression="subject"
                                                                        ItemStyle-Width="65%" HeaderStyle-Height="10px" HeaderStyle-BackColor="#636D89"
                                                                        HeaderStyle-ForeColor="Black">
                                                                        <HeaderStyle HorizontalAlign="Left" Width="65%" Wrap="false" />
                                                                        <HeaderTemplate>
                                                                            <div style="padding-left: 2px; color: Black;" class="HeaderText">
                                                                                <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Subject"></asp:Label>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="overflow: hidden; width: 99%;">
                                                                                <asp:Label ID="lnksubject" runat="server" Text='<%#Eval("subject") %>'></asp:Label>
                                                                                <asp:Label ID="lblEventID" Visible="false" runat="server" Text='<%#Eval("EventID") %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderStyle-HorizontalAlign="Left" SortExpression="duration" ItemStyle-Width="20%"
                                                                        HeaderStyle-Height="10px" HeaderStyle-BackColor="#636D89" HeaderStyle-ForeColor="white">
                                                                        <%-- --%>
                                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" Wrap="false" />
                                                                        <HeaderTemplate>
                                                                            <div style="padding-left: 2px; color: White;" class="HeaderText">
                                                                                <asp:Label ID="Label1" runat="server" Text="Duration"></asp:Label>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="width: 99%; overflow: hidden;">
                                                                                <asp:Label ID="lblDuration" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table class="empty_data_gridview" width="100%" border="0" cellpadding="3" cellspacing="0"
                                                                        style="height: 153px">
                                                                        <tr>
                                                                            <td valign="top" nowrap="nowrap">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("No_Records_Available")%>
                                                                                    <%=Check%>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" DataSourceMode="DataSet" SelectCommand="crm_home_events_today_select"
                                                        SelectCommandType="StoredProcedure" ConflictDetection="CompareAllValues">
                                                        <%--crm_home_Select_todaysEvents--%>
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="intCompID" SessionField="companyID" Type="Int32" />
                                                            <asp:SessionParameter Name="intAssignedID" SessionField="userID" Type="Int32" />
                                                            <asp:ControlParameter Name="reqdate" Type="DateTime" Direction="Input" PropertyName="Value"
                                                                ControlID="hdnreqDate" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    <asp:HiddenField ID="hdnreqDate" runat="server" />
                                                    <%--<asp:PlaceHolder ID="eventplace" runat="server"></asp:PlaceHolder>--%>
                                                    <%--  </td>
                                                                </tr>
                                                            </table>--%>
                                                    <%--    </td>
                                                    </tr>
                                                </table>--%>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="1%">
                                <%-- <img alt="" src="<%=strImagepath%>nil.gif" height="2" />--%>
                            </td>
                            <td valign="top" width="26%" align="center">
                                <asp:UpdatePanel ID="upCalendar" runat="server" RenderMode="inline">
                                    <ContentTemplate>
                                        <table width="280px" cellpadding="0" cellspacing="4">
                                            <tr>
                                                <td align="center" valign="top" width="100%">
                                                    <asp:Calendar ID="Calendar1" OnDayRender="Calendar1_DayRender" runat="server" CssClass="bordercalender"
                                                        Height="187px" Width="280px" BorderWidth="0px" CellPadding="0" CellSpacing="0"
                                                        ToolTip="Click here to view details" OnVisibleMonthChanged="Calendar1_VisibleMonthChanged"
                                                        OnSelectionChanged="Calendar1_SelectionChanged" BackColor="Transparent" ShowTitle="true">
                                                        <DayHeaderStyle BackColor="#636D89" ForeColor="white" CssClass="caldayheader" />
                                                        <TitleStyle CssClass="navigatorpanel" Font-Bold="true" ForeColor="white" />
                                                        <NextPrevStyle Font-Bold="true" ForeColor="white" CssClass="calendarItemleft" />
                                                        <DayStyle CssClass="borderleft" />
                                                        <TodayDayStyle BackColor="Orange" Font-Bold="True" ForeColor="Black" />
                                                        <OtherMonthDayStyle BackColor="#DDDDDD" />
                                                    </asp:Calendar>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td width="1%">
                                <%--  <img alt="" src="<%=strImagepath%>nil.gif" height="2" />--%>
                            </td>
                            <td width="36%" valign="top">
                                <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td width="100%" class="bgcustomize" height=" 23px">
                                            <span class="navigatorpanel">&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Tomorrows_Events")%></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" width="33%" colspan="3">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="inline">
                                                <ContentTemplate>
                                                    <div style='height: 170px; overflow-y: scroll; border: 1px solid #BDBDBD; width: 100%'>
                                                        <div>
                                                            <asp:GridView ID="GridView2" EnableViewState="true" runat="server" SkinID="GridStyle"
                                                                OnRowDataBound="GridView2_RowDataBound" Width="100%" GridLines="None" CellSpacing="1"
                                                                AutoGenerateColumns="false">
                                                                <%-- <HeaderStyle CssClass="bgcustomize" Font-Bold="true" /> <asp:Label ID="lblIsAllDay" Visible="false" runat="server" Text='<%#Eval("IsAllDay") %>'></asp:Label>--%>
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" SortExpression="Eventdate" ItemStyle-Width="15%"
                                                                        HeaderStyle-Height="10px" HeaderStyle-BackColor="#636D89" HeaderStyle-ForeColor="white">
                                                                        <HeaderStyle HorizontalAlign="Left" Width="15%" Wrap="false" />
                                                                        <HeaderTemplate>
                                                                            <div style="padding-left: 2px; color: White;" class="HeaderText">
                                                                                <asp:Label ID="Label1" runat="server" Text="Time"></asp:Label>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 99%; overflow: hidden">
                                                                                <asp:Label ID="lblTime" runat="server" Text='<%#Eval("EventTime") %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-Wrap="false" ItemStyle-VerticalAlign="Top" SortExpression="subject"
                                                                        ItemStyle-Width="65%" HeaderStyle-Height="10px" HeaderStyle-BackColor="#636D89"
                                                                        HeaderStyle-ForeColor="white">
                                                                        <HeaderStyle HorizontalAlign="Left" Width="65%" Wrap="false" />
                                                                        <HeaderTemplate>
                                                                            <div style="padding-left: 2px; color: White;" class="HeaderText">
                                                                                <asp:Label ID="Label1" runat="server" Text="Subject"></asp:Label>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 99%; overflow: hidden">
                                                                                <asp:Label ID="lnksubject" runat="server" Text='<%#Eval("subject") %>'></asp:Label>
                                                                                <asp:Label ID="lblEventID" Visible="false" runat="server" Text='<%#Eval("EventID") %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top"
                                                                        HeaderStyle-HorizontalAlign="Left" SortExpression="duration" ItemStyle-Width="20%"
                                                                        HeaderStyle-Height="10px" HeaderStyle-BackColor="#636D89" HeaderStyle-ForeColor="white">
                                                                        <HeaderStyle HorizontalAlign="Left" Width="20%" Wrap="false" />
                                                                        <HeaderTemplate>
                                                                            <div style="padding-left: 2px; color: White;" class="HeaderText">
                                                                                <asp:Label ID="Label13" runat="server" Text="Duration"></asp:Label>
                                                                            </div>
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div style="float: left; width: 99%; overflow: hidden">
                                                                                <asp:Label ID="lblDuration" runat="server" Text='<%#Eval("Duration") %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>
                                                                    <table class="empty_data_gridview" width="100%" border="0" cellpadding="3" cellspacing="0"
                                                                        style="height: 153px">
                                                                        <tr>
                                                                            <td valign="top" nowrap="nowrap">
                                                                                <span>
                                                                                    <%=objLanguage.GetLanguageConversion("No_Records_Available")%>
                                                                                    <%=Check1%>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" SelectCommand="crm_home_events_today_select"
                                                        SelectCommandType="StoredProcedure" ConflictDetection="CompareAllValues">
                                                        <SelectParameters>
                                                            <asp:SessionParameter Name="intCompID" SessionField="companyID" Type="Int32" />
                                                            <asp:SessionParameter Name="intAssignedID" SessionField="userID" Type="Int32" />
                                                            <asp:ControlParameter Name="reqdate" Type="DateTime" Direction="Input" PropertyName="Value"
                                                                ControlID="hdnreqDate1" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>
                                                    <asp:HiddenField ID="hdnreqDate1" runat="server" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Calendar1" EventName="SelectionChanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr valign="Top">
                    </tr>--%>
                        <tr>
                            <td align="center" colspan="5">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server" RenderMode="inline">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="ImageButton1" ToolTip='' runat="server" />
                                        &nbsp;<asp:ImageButton ID="ImageButton2" ToolTip='' runat="server" />
                                        &nbsp;<asp:ImageButton ID="ImageButton3" ToolTip='' runat="server" />
                                        &nbsp;<asp:ImageButton ID="ImageButton4" ToolTip='' runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" align="center" style="height: 0px">
                </td>
            </tr>
            <tr>
                <td align="left" width="100%">
                    <table align="left" border="0" style="display: <%=pnlTask%>;" cellpadding="0" cellspacing="0"
                        width="100%">
                        <tr>
                            <td style="width: 260px;">
                                <div style="float: left; padding-left: 2.1%;">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" RenderMode="inline">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList1" CssClass="normaltext" AutoPostBack="True" runat="server"
                                                Width="130pt" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                <asp:ListItem Value="td">Today</asp:ListItem>
                                                <asp:ListItem Value="to">Today + Overdue</asp:ListItem>
                                                <asp:ListItem Value="tm">Tomorrow</asp:ListItem>
                                                <asp:ListItem Value="n7">Next 7 Days</asp:ListItem>
                                                <asp:ListItem Value="o7">Next 7 Days + Overdue</asp:ListItem>
                                                <asp:ListItem Value="mo">This Month</asp:ListItem>
                                                <asp:ListItem Value="ao">All Open</asp:ListItem>
                                                <asp:ListItem Value="al">All</asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:LinkButton ID="lnkAddTask" runat="server" Style="text-decoration: underline;
                                        padding-left: 10px;" OnClick="btnAddtask_Click"><%=objLanguage.GetLanguageConversion("Add_Task") %></asp:LinkButton>
                                </div>
                            </td>
                            <td>
                                <div style="float: left; padding-left: 1%">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" width="100%" colspan="2" style="padding: 0 5px 0 5px">
                                <table cellpadding="0" cellspacing="0" border="0" width="100%" align="left">
                                    <tr>
                                        <td>
                                            <div class="only5px">
                                            </div>
                                            <div align="left" style="width: 100%">
                                                <div id="div_TotalRec" style="float: right; padding-right: 28px; display: none">
                                                    <span class="normalText">
                                                        <%=objLanguage.GetLanguageConversion("Total_Records") %>:</span><b>
                                                            <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b>
                                                </div>
                                                <div class="onlyEmpty">
                                                </div>
                                                <div id="div_Main" runat="server" align="left" style="width: 100%">
                                                    <div id="a">
                                                    </div>
                                                    <div id="div_Grid" style="display: none;">
                                                        <%--style="display: none"--%>
                                                        <div id="div_popupAction_View" style="display: none; margin: -6px 0px 0px 18px; z-index: 999999;
                                                            position: absolute; visibility: visible;" onmouseover="show();" onmouseout="hide();">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <div id="divDelete" runat="server" onclick="javascript:return CheckchkOne('delete');"
                                                                            class="divDropdownlist" style="border: 1px solid #CBCBCB; width: 100px;">
                                                                            <asp:Label ID="lblDelete" runat="server"></asp:Label>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <asp:GridView AutoGenerateColumns="false" ID="GridViewTask" runat="server" DataKeyNames="taskId"
                                                            OnRowDataBound="GridViewTask_RowDataBound" Width="1700px" SkinID="GridStyleReportNew"
                                                            GridLines="Horizontal" CellPadding="0" CellSpacing="0" RowStyle-Height="22px">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" Wrap="false" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    <HeaderTemplate>
                                                                        <%-- <%-- <table>
                                                                            <tr>
                                                                                <td>--%>
                                                                        <%--<div id="div_chk" style="width: inherit; height: inherit;">--%>
                                                                        <%--  <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;
                                                                            margin-left: 8px;">
                                                                            <tr>
                                                                                <td>
                                                                                    <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Panel ID="pnl_chkImage" runat="server">
                                                                                        <div style="float: left; padding: 0px 0px 0px 1px; display: block;">
                                                                                            <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block;
                                                                                                border: solid 0px Transparent; cursor: pointer;" onclick="show();" alt='' />
                                                                                            <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none;
                                                                                                border: solid 0px Transparent; cursor: pointer;" onclick="hide();" alt='' />
                                                                                        </div>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>--%>
                                                                        <%-- <div id="div_checkBox" style="float: left;">
                                                                            <div style="float: left; display: none;">
                                                                            </div>
                                                                            <div id="div_chk" style="float: left; border: outset 1px; -moz-border-radius: 5px; -webkit-border-radius: 5px; -ms-border-radius: 5px; height: inherit; width: inherit">
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" style="white-space: nowrap;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div style="float: left;">
                                                                                                <input id="checkAll" runat="server" name="checkAll" onclick="checkAll_new(this);"
                                                                                                    type="checkbox" />
                                                                                                <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td>
                                                                                            <div style="float: left; padding: 0px 0px 0px 1px">
                                                                                                <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block; border: solid 0px Transparent; cursor: pointer;"
                                                                                                    onclick="show();" alt='' />
                                                                                                <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none; border: solid 0px Transparent; cursor: pointer;"
                                                                                                    onclick="hide();" alt='' />
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </div>
                                                                        </div>
                                                                           


                                                                        --%>
                                                                        <div id="div_checkBox" style="float: left;">
                                                                            <div id="div_chk" style="float: left; border-bottom: 1px solid #888888; border-right: 1px solid #888888;
                                                                                border-left: 1px solid #F0F0F0; border-top: 1px solid #F0F0F0; width: 34px; -moz-border-radius: 5px;
                                                                                -webkit-border-radius: 5px; -ms-border-radius: 5px; position: relative; left: 30%;">
                                                                                <div style="float: left;">
                                                                                    <input type="checkbox" id="checkAll" onclick="CheckAll(this);" runat="server" name="checkAll" />
                                                                                    <input id="hdnUPDOWN" runat="server" type="hidden" /></ItemTemplate>
                                                                                </div>
                                                                                <div style="float: left; padding: 3px 0px 0px 3px">
                                                                                    <img src="<%=strImagepath %>ArrowDown.gif" id="img_actionsShow" style="display: block;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="show();" alt='' />
                                                                                    <img src="<%=strImagepath %>ArrowUP.GIF" id="img_actionsHide" style="display: none;
                                                                                        border: solid 0px Transparent; cursor: pointer;" onclick="hide();" alt='' />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <%--</div>--%>
                                                                        <%--</td>
                                                                            </tr>
                                                                        </table>--%>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <input class="viewcheckboxpos" style="margin: 0;" type="checkbox" runat="server"
                                                                            id="Id" onclick="CheckChanged(event, this, 'ctl00_ContentPlaceHolder1_GridViewTask');"
                                                                            name="Id" />&nbsp;
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="8%" ItemStyle-HorizontalAlign="left" ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="left" Width="8%" Wrap="false" />
                                                                    <HeaderTemplate>
                                                                        <div style="font-size: 13px;width: 68px;">
                                                                            <asp:Label ID="Label2" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Due_Date")%></asp:Label>
                                                                        </div>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; width: 85%; overflow: hidden; margin-left: 0px;">
                                                                            <asp:Label runat="server" ID="lblDueDAte"></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="12%" HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="left"
                                                                    ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="left" Width="12%" Wrap="false" />
                                                                    <HeaderTemplate>
                                                                        <div style="font-size: 13px;width: 125px;">
                                                                            <asp:Label ID="Label1" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Subject")%></asp:Label>
                                                                        </div>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; width: 130px; overflow: hidden; margin-left: 3px;">
                                                                            <asp:LinkButton runat="server" ID="lnkdetails" Text='<%# DataBinder.Eval(Container.DataItem, "subject") %>'
                                                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "type") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "typeId") %>'
                                                                                OnCommand='lnkdetails_OnCommand' OnClientClick='<%# Eval("taskID","return testjs({0})") %>'></asp:LinkButton>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="15%" HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="left"
                                                                    ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="left" Width="15%" Wrap="false" />
                                                                    <HeaderTemplate>
                                                                        <div style="font-size: 13px;width: 122px;">
                                                                            <asp:Label ID="lblcom" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Company_Name")%></asp:Label>
                                                                        </div>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; width: 160px; overflow: hidden; margin-left: 3px;">
                                                                            <asp:Label ID="lblCompanyname" CssClass="GV_Row" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ClientName")%>'></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="10%" HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="left"
                                                                    ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="left" Width="10%" Wrap="false" />
                                                                    <HeaderTemplate>
                                                                        <div style="font-size: 13px;width: 110px;">
                                                                            <asp:Label ID="Label3" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Contact_Name")%></asp:Label>
                                                                        </div>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; width: 110px; overflow: hidden; margin-left: 3px;">
                                                                            <asp:Label ID="lblContactname" CssClass="GV_Row" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "contactname")%>'></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="18%" HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="left"
                                                                    ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="left" Width="18%" Wrap="false" />
                                                                    <HeaderTemplate>
                                                                        <div style="font-size: 13px;width: 143px;">
                                                                            <asp:Label ID="Label4" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                                                        </div>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; width: 210px; overflow: hidden; margin-left: 3px;">
                                                                            <asp:Label ID="lblDescription" CssClass="GV_Row" ToolTip='<%# DataBinder.Eval(Container.DataItem, "description")%>'
                                                                                runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description")%>'></asp:Label>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="10%" HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="left"
                                                                    ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="left" Width="10%" Wrap="false" />
                                                                    <HeaderTemplate>
                                                                        <div style="font-size: 13px;width: 86px;">
                                                                            <asp:Label ID="Label23" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Task_Status")%></asp:Label>
                                                                        </div>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; width: 99%; overflow: hidden; margin-left: 4px;">
                                                                            <%# DataBinder.Eval(Container.DataItem, "taskStatus")%>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField ItemStyle-Width="15%" HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="left"
                                                                    ItemStyle-Wrap="false">
                                                                    <HeaderStyle HorizontalAlign="left" Width="15%" Wrap="false" />
                                                                    <HeaderTemplate>
                                                                        <div style="font-size: 13px;width: 115px;">
                                                                            <asp:Label ID="Label32" runat="server" Text=''><%=objLanguage.GetLanguageConversion("Assigned_To")%></asp:Label>
                                                                        </div>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <div style="float: left; width: 99%; overflow: hidden; margin-left: 3px;">
                                                                            <asp:Label ID="lbl_assignToUserName" CssClass="GV_Row" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "assignToUserName")%>'></asp:Label>
                                                                            <asp:HiddenField ID="hdn_assignToUserId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "assignToUserId")%>' />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <table class="empty_data_gridview" width="100%" border="0" cellpadding="3" cellspacing="0"
                                                                    style="height: 25px">
                                                                    <tr>
                                                                        <td nowrap="nowrap">
                                                                            <%=objLanguage.GetLanguageConversion("No_Tasks_On_The_Selected_Criteria")%>
                                                                            &nbsp; <a class="empty_data_gridview" href="<%=strSitepath%>common/taskviewall.aspx">
                                                                                <%=objLanguage.GetLanguageConversion("Click_Here")%>
                                                                                &nbsp; </a>
                                                                            <%=objLanguage.GetLanguageConversion("To_View_All_Tasks")%>
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                        <asp:LinkButton ID="lnkTaskDelete" runat="server" Text=" " OnClick="lnkTaskDelete_OnClick"
                                                            CausesValidation="false" Visible="false"></asp:LinkButton>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="crm_home_select_getTaskView_new1"
                                                            SelectCommandType="StoredProcedure" ConflictDetection="CompareAllValues">
                                                            <SelectParameters>
                                                                <asp:SessionParameter Name="intCompID" SessionField="companyID" Type="Int32" Direction="Input" />
                                                                <asp:SessionParameter Name="intAssignedID" SessionField="userID" Type="Int32" Direction="Input" />
                                                                <asp:Parameter Name="strTime" DefaultValue="0" Type="Int32" Direction="Input" />
                                                                <asp:ControlParameter ControlID="DropDownList1" Name="disptype" DefaultValue="td"
                                                                    Direction="Input" Type="String" />
                                                            </SelectParameters>
                                                        </asp:SqlDataSource>
                                                    </div>
                                                </div>
                                                <div id="div_test_1" style="width: 100%; overflow-y: scroll; display: none">
                                                    <div id="div_test_2" style="width: 100%;">
                                                        Loading...
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%" align="center" style="height: 12px">
                </td>
            </tr>
        </table>
    </div>
    <div style="display: none;">
        <asp:Button ID="btnRedirectToClient" runat="server" OnClick="btnRedirectToClient_Click" />
        <asp:HiddenField ID="hdnRedirectPath" runat="server" />
    </div>
    <asp:HiddenField Value="0" ID="hdnTaskID" runat="server" />
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <asp:HiddenField ID="hdnIDs" runat="server" Value="0" />
    <asp:HiddenField ID="hdnTaskIDs" runat="server" Value="0" />
    <asp:Panel ID="pnlCallScroll" runat="server" Visible="false">
        <script type="text/javascript">
            CallScroll();
        </script>
    </asp:Panel>
    <script type="text/javascript">
        function CallScroll() {
            var GridID = document.getElementById("<%=GridViewTask.ClientID%>");
            var div_HeaderID = document.getElementById("a");
            var div_BodyID = document.getElementById("div_Grid");
            var OuterDivID = document.getElementById("div_test_1");
            var InnerDivID = document.getElementById("div_test_2");
            var DivTotalRecID = document.getElementById("div_TotalRec");
            start(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);
            div_BodyID.style.width = "1700px";
        }
        window.onload = CallScroll
        var ClrTimeID = '';
        var countTime = 0;
        var hidGridCount = document.getElementById("<%=hidGridCount.ClientID %>");
    </script>
    <script>

        function testjs(val) {
            document.getElementById("<%=hdnTaskID.ClientID %>").value = val
        }
    </script>
    <script type="text/javascript">
        var GridItemTitle = document.getElementById("<%=GridViewTask.ClientID %>");
        var GridView1 = document.getElementById("<%=GridView1.ClientID %>");
        function CallOverflow() {

            SetGridOverflow(GridItemTitle);
            SetGridOverflow(GridView1);
        }
        CallOverflow();

        function OnRowClick(EditPage) {
            var hdnpath = document.getElementById("ctl00_ContentPlaceHolder1_hdnRedirectPath");
            hdnpath.value = EditPage;
            var btnRedirectToClient = document.getElementById("ctl00_ContentPlaceHolder1_btnRedirectToClient");
            btnRedirectToClient.click();
        }

        var img_actionsShow = document.getElementById("img_actionsShow");
        var img_actionsHide = document.getElementById("img_actionsHide");
        var div_chk = document.getElementById("div_chk");
        var div_popupAction_View = document.getElementById("div_popupAction_View");

        function show() {
            //img_actionsHide.style.display = "none";
            //img_actionsShow.style.display = "block";
            ////div_chk.style.border = "outset 1px";
            ////div_chk.style.background = "";
            ////note: do not use the display:none for below div. below code for strange jump in scroll in safari browser
            //div_popupAction_View.style.display = "none";
            //div_popupAction_View.style.visibility = "hidden";




            document.getElementById("img_actionsHide").style.display = "block";

            document.getElementById("img_actionsShow").style.display = "none";
            //document.getElementById("div_chk").style.border = "inset 1px";
            //document.getElementById("div_chk").style.background = "Gray";



            //img_actionsHide.style.display = "block";
            //img_actionsShow.style.display = "none";
            //div_chk.style.border = "inset 1px";
            //div_chk.style.background = "#C5C5C5";
            //below code for strange jump in scroll in safari browser
            div_popupAction_View.style.display = "block";
            div_popupAction_View.style.visibility = "visible";




        }

        function hide() {

            //  img_actionsHide.style.display = "block";
            //  img_actionsShow.style.display = "none";
            ////div_chk.style.border = "inset 1px";
            ////div_chk.style.background = "#C5C5C5";
            ////below code for strange jump in scroll in safari browser
            //div_popupAction_View.style.display = "block";
            //div_popupAction_View.style.visibility = "visible";




            document.getElementById("img_actionsHide").style.display = "none";
            document.getElementById("img_actionsShow").style.display = "block";

            //document.getElementById("div_chk").style.border = "outset 1px";
            //document.getElementById("div_chk").style.background = "";




            //img_actionsHide.style.display = "none";
            //img_actionsShow.style.display = "block";
            //div_chk.style.border = "outset 1px";
            //div_chk.style.background = "";
            //note: do not use the display:none for below div. below code for strange jump in scroll in safari browser
            div_popupAction_View.style.display = "none";
            div_popupAction_View.style.visibility = "hidden";


        }

        function CheckchkOne(type) {
            var Counter = 0;
            var frm = document.forms[0];
            var Ides = "";

            hdnIDs = document.getElementById("<%=hdnIDs.ClientID %>");
            for (i = 0; i < frm.length; i++) {
                e = frm.elements[i];
                if (e.type == 'checkbox' && e.name.indexOf('Id') != -1) {
                    if (e.checked) {
                        Counter = Number(Counter) + 1;
                        Ides = Ides + e.value + ",";
                    }
                }
            }

            hdnIDs.value = Ides;
            if (Number(Counter) == 0) {
                if (type == "delete") {

                    alert("<%=Delete_Row_Selection_Alert %>");
                }
                return false;
            }
            else {
                var check = "";
                if (type == "delete") {
                    check = window.confirm('Are you sure you want to delete these task(s)?');
                }

                if (check) {
                    if (type == "delete") {
                        DeleteTask();
                    }
                }
            }
        }
        function DeleteTask() {
            document.getElementById("<%=hdnTaskIDs.ClientID %>").value = document.getElementById("<%=hdnIDs.ClientID %>").value;
            __doPostBack('ctl00$ContentPlaceHolder1$lnkTaskDelete', '');
        }
    </script>
</asp:Content>
