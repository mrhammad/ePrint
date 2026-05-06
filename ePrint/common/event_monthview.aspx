

<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="event_monthview.aspx.cs" Inherits="ePrint.common.event_monthview" title="Event Month View" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
    <asp:PlaceHolder ID="plhHeader" runat="server"></asp:PlaceHolder>
    <table cellspacing="0" cellpadding="5" width="100%" align="center" border="0" id="TABLE2"
        class="borderWithoutTop">
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="TABLE1">
                    <tr>
                        <td align="left" style="width: 45%">
                        </td>
                        <td align="center" style="width: 10%">
                            <table cellspacing="0" cellpadding="5" width="100%" align="center" border="0" id="TABLE3">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" ToolTip='Day View' runat="server" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton2" ToolTip='Week View' runat="server" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton3" ToolTip='Month View' runat="server" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton4" ToolTip='All View' runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" style="width: 45%">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Calendar OnDayRender="Calendar1_DayRender" ID="Calendar1" runat="server" BorderColor="#E0E0E0"
                    BorderStyle="Solid" BorderWidth="1px" Height="100%" ShowGridLines="True" Width="100%"
                    NextMonthText=">>" PrevMonthText="<<" CellPadding="5" SelectionMode="DayWeek"
                    SelectWeekText="Week">
                    <SelectedDayStyle BackColor="#FFFFC0" Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller"
                        Font-Strikeout="True" ForeColor="Red" />
                    <TodayDayStyle BackColor="#FFFFC0" BorderColor="Window" BorderStyle="None" />
                    <SelectorStyle BackColor="#E0E0E0" Font-Names="Verdana" Font-Size="Smaller" />
                    <DayStyle BackColor="WhiteSmoke" Font-Names="Verdana" Font-Size="Smaller" HorizontalAlign="Center"
                        Height="100px" Width="100px" />
                    <WeekendDayStyle BackColor="AliceBlue" Font-Names="Verdana" Font-Size="Smaller" />
                    <OtherMonthDayStyle BackColor="AliceBlue" Font-Names="Verdana" Font-Size="Smaller"
                        ForeColor="AliceBlue" Wrap="False" />
                    <NextPrevStyle BorderStyle="None" Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller"
                        ForeColor="White" HorizontalAlign="Justify" />
                    <DayHeaderStyle BackColor="RosyBrown" BorderColor="#E0E0E0" BorderStyle="Solid" BorderWidth="1px"
                        Font-Names="Arial" Font-Size="Smaller" ForeColor="#404040" />
                    <TitleStyle Font-Bold="True" Font-Names="Verdana" Font-Size="Smaller" ForeColor="White" />
                </asp:Calendar>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
