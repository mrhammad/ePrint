<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="changepassword.aspx.cs" Inherits="ePrint.changepassword" title="Change Password" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript" src="../CastleBusyBox.js?VN='<%=VersionNumber%>'"></script>

    <script language="javascript" type="text/javascript" src="CastleBusyBox.js?VN='<%=VersionNumber%>'"></script>

    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr>
            <td style="width: 100%" align="center">
                <table id="Table3" cellspacing="0" cellpadding="0" width="100%" border="0" height="23">
                    <tr valign="middle">
                        <td width="1%" valign="top" align="left" class="bgcustomize">
                            <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" /></td><%--r1.jpg--%>
                        <td width="90%" class="bgcustomize" nowrap="nowrap"><%--background="<%=strImagepath%>r2.jpg"--%>
                            <span class="navigatorpanel">Change Password</span>
                        </td>
                        <td width="8%" class="bgcustomize" nowrap="nowrap" align="right"><%--background="<%=strImagepath%>r2.jpg"--%>
                            <asp:LinkButton ID="lnkBack" OnClick="btncancel_Click" CssClass="subnavigator" runat="server"
                                Text="Back" CausesValidation="false"></asp:LinkButton>
                        </td>
                        <td width="1%" valign="top" align="right" class="bgcustomize">
                            <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" /></td><%--r3.jpg--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="borderWithoutTop">
                    <asp:Panel ID="pnlMessage" runat="server" Visible="false">
                        <tr>
                            <td>
                                <div>
                                    <table cellpadding="4" cellspacing="4" align="center" width="80%" border="0">
                                        <tr valign="top">
                                            <td valign="top" align="right" style="width: 30%">
                                            </td>
                                            <td valign="top" align="left" style="width: 70%">
                                                <asp:Label ID="lblmessage" CssClass="error" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlmessagecomfirm" runat="server" Visible="false">
                        <tr>
                            <td>
                                <div>
                                    <table cellpadding="2" cellspacing="2" align="center" width="50%" border="0">
                                        <tr>
                                            <td height="10px">
                                            </td>
                                        </tr>
                                        <tr valign="top" class="successfull_message2">
                                            <td valign="top" align="center" style="width: 50%">
                                                <asp:Label ID="lblmessageconfirm" CssClass="successfull_message" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="pnlBody" runat="server">
                        <tr>
                            <td valign="top">
                                <table cellspacing="10" cellpadding="4" width="40%" border="0">
                                    <tr>
                                        <td align="center">
                                            <table id="Table2" cellspacing="2" cellpadding="4" width="100%" align="center" border="0">
                                                <tr valign="middle">
                                                    <td class="label" align="left" width="25%" nowrap="nowrap" valign="top"><%--class="newLabelText"--%>
                                                        <asp:Label ID="lbloldpwd" runat="server" Width="120px" CssClass="normaltext"><%=objLanguage.convert("Old Password")%>&nbsp;<span  class="normalText"  style="color:Red">*</span></asp:Label>
                                                    </td>
                                                    <td class="tablerowcolor2" width="75%" align="left" valign="top">
                                                        <asp:TextBox ID="txtoldpwd" runat="server" Width="200px" autocomplete=off TextMode="Password" CssClass="txtbox"></asp:TextBox>
                                                        <div style="margin-top: 5px">
                                                            <asp:RequiredFieldValidator Width="200" ID="RequiredFieldValidator1" runat="server"
                                                                ForeColor="#333333" ErrorMessage="Please enter old password." ControlToValidate="txtoldpwd"
                                                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr valign="middle">
                                                    <td class="label" align="left" nowrap="nowrap" valign="top"><%--class="newLabelText"--%>
                                                        <asp:Label ID="lblnewpwd" runat="server" Width="120px" CssClass="normaltext"><%=objLanguage.convert("New Password")%>&nbsp;<span  class="normalText"  style="color:Red">*</span></asp:Label>
                                                    </td>
                                                    <td class="tablerowcolor2" valign="top" align="left">
                                                        <asp:TextBox ID="txtnewpwd" runat="server" Width="200px" TextMode="Password" CssClass="txtbox"></asp:TextBox>
                                                        <div style="margin-top: 5px">
                                                            <asp:RequiredFieldValidator Width="200" ID="RequiredFieldValidator2" runat="server"
                                                                ForeColor="#333333" ErrorMessage="Please enter new password." ControlToValidate="txtnewpwd"
                                                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr valign="middle">
                                                    <td class="label" align="left" nowrap="nowrap" valign="top" width="25%"><%--class="newLabelText"--%>
                                                        <asp:Label ID="lblconfirmpwd" runat="server" Width="120px" CssClass="normaltext"><%=objLanguage.convert("Confirm Password")%>&nbsp;<span  class="normalText"  style="color:Red">*</span></asp:Label>
                                                    </td>
                                                    <td class="tablerowcolor2" valign="top" align="left" nowrap="nowrap">
                                                        <asp:TextBox ID="txtconfirmpwd" runat="server" Width="200px" TextMode="Password"
                                                            CssClass="txtbox"></asp:TextBox>
                                                        <div style="margin-top: 5px">
                                                            <asp:RequiredFieldValidator Width="200" ID="RequiredFieldValidator3" runat="server"
                                                                ForeColor="#333333" ErrorMessage="Please confirm new password." ControlToValidate="txtconfirmpwd"
                                                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Width="200" ForeColor="#333333"
                                                                ControlToValidate="txtconfirmpwd" ControlToCompare="txtnewpwd" ErrorMessage="New and Confirm password is not matching. Please try again."
                                                                CssClass="error" Display="Dynamic"></asp:CompareValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td>
                            <table cellpadding="3" cellspacing="3" width="98%" align="center" border="0">
                                <tr>
                                    <td align="left">
                                        <asp:Button ID="btnsubmit" CssClass="button" runat="server" Text="Submit" Width="50px"
                                            OnClick="btnsubmit_Click"></asp:Button>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btncancel" CssClass="button" runat="server" Width="50px" Text="Cancel"
                                            CausesValidation="false" OnClick="btncancel_Click"></asp:Button>
                                    </td>
                                    <td width="100%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <%--<table cellpadding=2 cellspacing=2 width=100% border=0>
    <tr>
        <td align=right>
            <asp:button id="btnsubmit" runat="server" Text="Submit" Width ="65px" CssClass="button" OnClick="btnsubmit_Click"></asp:button>&nbsp;&nbsp;
            <asp:button id="btncancel" runat="server" CssClass="button" Width ="65px" Text="Cancel" CausesValidation="false" OnClick="btncancel_Click"></asp:button>
        </td>
    </tr>
</table>--%>
</asp:Content>

