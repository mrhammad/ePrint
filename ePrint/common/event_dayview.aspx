<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" Inherits="ePrint.common.event_dayview" CodeBehind="event_dayview.aspx.cs" title="Calendar Day View" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
    <asp:PlaceHolder ID="plhHeader" runat="server"></asp:PlaceHolder>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="TABLE2"
        class="borderWithoutTop">
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="99%" align="center" border="0" id="TABLE1">
                    <tr>
                        <td align="left" style="width: 45%">
                        </td>
                        <td align="center" style="width: 15%" nowrap="nowrap">
                            <div class="only5px">
                            </div>
                            <div align="center" style="text-align: center;">
                                <div align="center" style="text-align: center;">
                                    <div style="float: left;">
                                        <asp:ImageButton ID="ImageButton1" ToolTip="Day View" runat="server" />
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;</div>
                                    <div style="float: left;">
                                        <asp:ImageButton ID="ImageButton2" ToolTip='Week View' runat="server" />
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;</div>
                                    <div style="float: left;">
                                        <asp:ImageButton ID="ImageButton3" ToolTip='Month View' runat="server" />
                                    </div>
                                    <div style="float: left; width: 10px;">
                                        &nbsp;</div>
                                    <div style="float: left;">
                                        <asp:ImageButton ID="ImageButton4" ToolTip='All View' runat="server" />
                                    </div>
                                </div>
                            </div>
                        </td>
                        <td align="right" style="width: 40%">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="TABLE5">
                                <tr>
                                    <td style="width: 32%" valign="top">
                                        <fieldset>
                                            <legend class="HeaderText" style="padding: 3px 5px 3px 3px">
                                                <%=objLanguage.GetLanguageConversion("Event_View")%></legend>
                                            <table cellspacing="0" cellpadding="0" class="Border1px_New" width="95%" align="center"
                                                style="overflow-x: auto; overflow-y: hidden" border="0" id="TABLE6">
                                                <tr height="23">
                                                    <td width="1%" valign="top" align="left" class="bgcustomize">
                                                        <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" />
                                                    </td>
                                                    <%--r1.jpg--%>
                                                    <td width="98%" style="white-space: normal" align="center" class="bgcustomize">
                                                        <%--background="<%=strImagepath%>r2.jpg" --%>
                                                        <a style="width: 50; vertical-align: middle" href="event_dayview.aspx?ReqDate=<%=previousdatetime1%>&dispstatus=<%=disptype%>"
                                                            class='WhiteVer9'>
                                                            <img src='../images/prev.gif' width='16' height='16' border='0' alt='Previous Day' /></a>
                                                        <span class="navigatorpanel" style="width: 150; vertical-align: middle">
                                                            <%=ReqDate1%>
                                                        </span><a style="width: 50; vertical-align: middle" href="event_dayview.aspx?ReqDate=<%=nextdatetime1%>&&dispstatus=<%=disptype%>"
                                                            class='White'>
                                                            <img src='../Images/Next.gif' width='16' height='16' border='0' alt='Next Day' /></a>
                                                    </td>
                                                    <td width="1%" valign="top" align="right" class="bgcustomize">
                                                        <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" />
                                                    </td>
                                                    <%--r3.jpg--%>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <table class="borderWithoutTop" cellspacing="0" cellpadding="5" width="100%" align="center"
                                                            border="0" id="TABLE8">
                                                            <asp:PlaceHolder ID="eventdayview" runat="server"></asp:PlaceHolder>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </td>
                                    <td style="width: 1%" valign="top">
                                    </td>
                                    <td style="width: 67%" valign="top">
                                        <fieldset>
                                            <legend class="HeaderText" style="padding: 3px 5px 3px 3px">
                                                <%=objLanguage.GetLanguageConversion("Task_View")%></legend>
                                            <div>
                                                <div align="left" style="float: left; width: 45%; padding-bottom: 2px; display: none;">
                                                    <asp:DropDownList ID="DropDownList1" Visible="false" CssClass="normaltext" AutoPostBack="True"
                                                        runat="server" Width="130pt" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                        <asp:ListItem Value="td">Today</asp:ListItem>
                                                        <asp:ListItem Value="to">Today + Overdue</asp:ListItem>
                                                        <asp:ListItem Value="tm">Tomorrow</asp:ListItem>
                                                        <asp:ListItem Value="n7">Next 7 Days</asp:ListItem>
                                                        <asp:ListItem Value="o7">Next 7 Days + Overdue</asp:ListItem>
                                                        <asp:ListItem Value="mo">This Month</asp:ListItem>
                                                        <asp:ListItem Value="ao">All Open</asp:ListItem>
                                                    </asp:DropDownList>
                                                    &nbsp
                                                </div>
                                            </div>
                                            <div style="clear: both;">
                                                <table cellspacing="0" cellpadding="0" class="Border1px_New" width="100%" align="center"
                                                    border="0" id="TABLE7">
                                                    <tr height="23">
                                                        <td width="1%" valign="top" align="left" class="bgcustomize">
                                                            <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" />
                                                        </td>
                                                        <%--r1.jpg--%>
                                                        <td width="18%" class="bgcustomize">
                                                            <div>
                                                                <div style='float: left; width: 20px;'>
                                                                    <a style="vertical-align: middle" href="event_dayview.aspx?ReqDate=<%=previousdatetime1%>&dispstatus=<%=disptype%>"
                                                                        class='WhiteVer9'>
                                                                        <img src='../images/prev.gif' width='16' height='16' border='0' alt='Previous Day' /></a>
                                                                </div>
                                                                <div style='float: left; width: 10px;'>
                                                                    &nbsp;</div>
                                                                <div style='float: left;'>
                                                                    <a href="#" class="subnavigator" style="cursor: default">
                                                                        <%=objLanguage.GetLanguageConversion("Due_Date")%></a>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td width="32%" class="bgcustomize">
                                                            <a href="#" class="subnavigator" style="cursor: default">
                                                                <%=objLanguage.GetLanguageConversion("Subject")%></a>
                                                        </td>
                                                        <td width="28%" class="bgcustomize">
                                                            <a href="#" class="subnavigator" style="cursor: default">
                                                                <%=objLanguage.GetLanguageConversion("Contacts")%></a>
                                                        </td>
                                                        <td width="22%" class="bgcustomize">
                                                            <div align="left">
                                                                <div style="float: left;">
                                                                    <a href="#" class="subnavigator" style="cursor: default">
                                                                        <%=objLanguage.GetLanguageConversion("Task_Status")%></a>
                                                                </div>
                                                                <div style="float: left; width: 10px;">
                                                                    &nbsp;</div>
                                                                <div style="float: left;">
                                                                    <a style="width: 50; vertical-align: middle" href="event_dayview.aspx?ReqDate=<%=nextdatetime1%>&&dispstatus=<%=disptype%>"
                                                                        class='White'>
                                                                        <img src='../Images/Next.gif' height='16' border='0' alt='Next Day' /></a>
                                                                </div>
                                                            </div>
                                                            <%--background="<%=strImagepath%>r2.jpg"--%>
                                                        </td>
                                                        <td width="1%" valign="top" align="right" class="bgcustomize">
                                                            <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" />
                                                        </td>
                                                        <%--r3.jpg--%>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="6">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" class="borderWithoutTop">
                                                                <asp:PlaceHolder ID="Taskplace" runat="server"></asp:PlaceHolder>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </fieldset>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" Width="100" Height="8" ImageUrl="~/images/nil.gif" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>


