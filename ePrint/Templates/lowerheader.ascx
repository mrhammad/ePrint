<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="lowerheader.ascx.cs" Inherits="ePrint.Templates.lowerheader" %>



<script type="text/javascript">
    function openHelp(section, subsection) {
        var openwin;
        openwin = "<%=strSitepath%>" + "help/userhelp.aspx?section=" + section + "&subsection=" + subsection;
        window.open(openwin, '', 'width=775,height=600,status=no,scrollbars=yes,resizable=yes,top=100,title=yes,location=no,titlebar=no,left=120,top=100');
    }
</script>
<%--<div class="tabheadertext bgcustomize" style="height: 5px;">
    &nbsp;
</div>--%>
<tr valign="middle" style="display: none;" width="50%" class="eprint-hide-top-nav">
    <td class="tabheadertext bgcustomize" height="25px" width="50%">
        <table cellspacing="0" cellpadding="0" width="100%" border="0" id="Table11" style="padding-right: 5px;"
            class="normaltext">
            <tr>
                <td colspan="10" height="3px">
                </td>
            </tr>
            <tr>
                <td class="NavigationArea_td" align="left" nowrap="nowrap">
                    <b>&nbsp;
                        <%--<asp:SiteMapPath ID="SiteMapPath1" runat="server">
                        </asp:SiteMapPath>--%>
                        <asp:Label ID="lblsitepath" runat="server" Style="padding-left:3px;" Visible="false"></asp:Label>
                        <asp:LinkButton ID="lnkHome" CausesValidation="false" runat="server"></asp:LinkButton><asp:Label
                            ID="lblHome" runat="server"></asp:Label><asp:LinkButton ID="lnkSection" CausesValidation="false"
                                runat="server"></asp:LinkButton><asp:Label ID="lblSection" runat="server"></asp:Label><asp:LinkButton
                                    ID="lnkSubsection" CausesValidation="false" runat="server"></asp:LinkButton><asp:Label
                                        ID="lnkTask" runat="server"></asp:Label>
                    </b>
                </td>
                <td style="display: none" width="100%" align="right" class="normaltext" valign="middle">
                    <asp:Label ID="lblsubscription" Visible="false" runat="server" EnableViewState="false"
                        Text="Label"></asp:Label>
                </td>
                <td align="right" style="color: White; padding-top: 3px; display: none;" nowrap="nowrap"
                    valign="middle">
                    <asp:Label ID="lblgoto" EnableViewState="false" runat="server" CssClass="normaltext"
                        Visible="false"></asp:Label>
                </td>
                <td align="right" class="normaltext" nowrap="nowrap" valign="middle" style="display: none;">
                    <strong style="color: White">&nbsp;|&nbsp;</strong>
                </td>
                <td align="right" class="normaltext" nowrap="nowrap" valign="middle">
                    <asp:Label ID="lblUserName" EnableViewState="false" runat="Server" CssClass="normaltext"
                        Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </td>
</tr>
