<%@ control language="C#" autoeventwireup="true" CodeBehind="jobcard_edit.ascx.cs" Inherits="ePrint.usercontrol.Item.jobcard_edit"  %>
<div id="div_jobcard_edit" runat="server" style="width: 100%; display: none; position: absolute"
    align="left">
    <div id="div_Main_Item" style="width: 100%; margin-bottom: 5px;">
        <div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">Job Card
                                    <asp:Label ID="lblFinishType" runat="server"></asp:Label>
                                </span>
                            </div>
                            <div style="width: 50px; float: right;">
                                <a href="javascript:closewindow('div_jobcard_edit');" class="subnavigator">
                                    <asp:Label ID="lblClose" runat="server" Text="Close X"></asp:Label>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="borderWithoutTop">
            <div style="width: 100%; padding: 5px">
                <div style="float: left; width: 90%; padding-bottom: 10px">
                    <span class="headertext">Select the cost centres you want to print on Job Card,edit
                        the work instructions.</span>
                </div>
                <div style="float: left">
                    <asp:RadioButtonList ID="rdblst" runat="server" RepeatDirection="Horizontal" CellPadding="2">
                        <asp:ListItem Text="View Group by Cost Centres&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"></asp:ListItem>
                        <asp:ListItem Text="View Group by Sections"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div align="left" style="float: left; width: 99%;">
                    <table align="right" class="ex" cellspacing="0" border="1" width="100%" cellpadding="4">
                        <col width="10%" />
                        <col width="30%" />
                        <col width="40%" />
                        <col width="6%" />
                        <col width="14%" />
                        <tr class="label">
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Section" CssClass="normaltext"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label29" runat="server" Text="Cost Centres" CssClass="normaltext"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label30" runat="server" Text="&nbsp;Work Instructions " CssClass="normaltext"></asp:Label>
                            </td>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label31" runat="server" Text="Print On Report" CssClass="normaltext"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="Schedule Date" CssClass="normaltext"></asp:Label>
                            </td>
                        </tr>
                        <tr class="NewTableRows">
                            <td>
                                1
                            </td>
                            <td>
                                Ink
                            </td>
                            <td>
                                16pp
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="chk1" runat="server" CssClass="normalText" />
                            </td>
                            <td>
                                23/12/2008
                            </td>
                        </tr>
                        <tr class="NewAlternative">
                            <td>
                                1
                            </td>
                            <td>
                                Paper
                            </td>
                            <td>
                                Info
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="CheckBox1" CssClass="normalText" runat="server" Style="padding: 0px" />
                            </td>
                            <td>
                                23/12/2008
                            </td>
                        </tr>
                        <tr class="NewTableRows">
                            <td>
                                1
                            </td>
                            <td>
                                Film
                            </td>
                            <td>
                                Pages per section:8,Print sheet Qty:2500
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="CheckBox2" CssClass="normalText" runat="server" Style="padding: 0px" />
                            </td>
                            <td>
                                23/12/2008
                            </td>
                        </tr>
                        <tr class="NewAlternative">
                            <td>
                                1
                            </td>
                            <td>
                                Plate
                            </td>
                            <td>
                                Info
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="CheckBox3" CssClass="normalText" runat="server" Style="padding: 0px" />
                            </td>
                            <td>
                                23/12/2008
                            </td>
                        </tr>
                        <tr class="NewTableRows">
                            <td>
                                1
                            </td>
                            <td>
                                MakeReady
                            </td>
                            <td>
                                order size=450mm*22mm
                            </td>
                            <td align="center">
                                <asp:CheckBox ID="CheckBox4" CssClass="normalText" runat="server" Style="padding: 0px" />
                            </td>
                            <td>
                                23/12/2008
                            </td>
                        </tr>
                        <%-- <tr>
                                    <td colspan="3" align="right">
                                        <asp:Label ID="Label35" runat="server" Text="Total ( incl. Tax )" CssClass="headertext"></asp:Label>
                                    </td>
                                    <td colspan="3">
                                        <span>$&nbsp;</span><asp:Label ID="Label36" runat="server" Text="2,903.59" CssClass="headertext"></asp:Label></td>
                                </tr>--%>
                    </table>
                </div>
                <div style="float: left; padding: 5px 0px 0px 0px">
                    <asp:Button ID="Button3" runat="server" Text="OK" Width="50px" CssClass="button" />
                </div>
                <div style="clear: both">
                    &nbsp;
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both; width: 775px">
        &nbsp;
    </div>
</div>

