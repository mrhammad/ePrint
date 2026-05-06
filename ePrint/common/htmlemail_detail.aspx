<%@ page language="C#" masterpagefile="~/Templates/popUpMasterPage_new.master" autoeventwireup="true" CodeBehind="htmlemail_detail.aspx.cs" Inherits="ePrint.common.htmlemail_detail" title="Untitled Page" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/CallClass.ascx" TagName="Estyle" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:estyle id="Estyle1" runat="server" />
    <div id="padding">
        <table cellspacing="0" cellpadding="0" width="98%" align="center" border="0">
            <%--class="borderWithoutTop"--%>
            <tr valign="top">
                <td>
                    <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table id="Table2" cellspacing="0" cellpadding="02" width="100%" align="center" border="0">
                        <tr>
                            <td valign="top" align="left">
                                <table id="Table3" cellspacing="03" cellpadding="03" width="100%" align="center"
                                    border="0">
                                    <tr>
                                        <td width="20%" class="label">
                                            <%--class="newLabelText"--%>
                                            <span class="normaltext">
                                                <%=objLanguage.GetLanguageConversion("Subject")%>
                                            </span>
                                        </td>
                                        <td width="70%" class="tablerowcolor2" align="left">
                                            <asp:Label ID="lblsubject_value" runat="server" CssClass="Normaltext"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            <%--class="newLabelText"--%>
                                            <span class="normaltext">
                                                <%=objLanguage.GetLanguageConversion("Sent_Date")%>
                                            </span>
                                        </td>
                                        <td class="tablerowcolor2" align="left">
                                            <asp:Label ID="lbl_senddate_value" runat="server" CssClass="Normaltext"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="label">
                                            <%--class="newLabelText"--%>
                                            <span class="normaltext">
                                                <%=objLanguage.GetLanguageConversion("ToWho")%>
                                            </span>
                                        </td>
                                        <td class="tablerowcolor2" align="left">
                                            <asp:Label ID="lbltowho_value" runat="server" CssClass="Normaltext"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" class="label">
                                            <%--class="newLabelText"--%>
                                            <span class="normaltext">
                                                <%=objLanguage.GetLanguageConversion("Message")%>
                                            </span>
                                        </td>
                                        <td class="tablerowcolor2" align="left">
                                            <asp:Label ID="lblmessage_value" runat="server" CssClass="Normaltext"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <!-- Lead Detail end -->
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel runat="server" Visible="false" ID="plhscript">
        <script language="javascript" type="text/javascript">
            window.close();
            opener.window.location.reload();
        </script>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
