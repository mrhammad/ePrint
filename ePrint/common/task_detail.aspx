

<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="task_detail.aspx.cs" Inherits="ePrint.common.task_detail" title="Task Detail" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript">
        var path = "<%=strSitepath %>";
    </script>
    <script type="text/javascript" language="javascript">
        function changeStyle(xobj, xStyle) {
            xobj.className = xStyle;
        }

        function clickDelete() {
            return window.confirm('Are you sure, you want to delete?');
        }
    </script>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
        <tr style="display: none;">
            <td>
                <table id="jkkjkj" cellspacing="0" cellpadding="0" width="100%" border="0" height="23">
                    <tr>
                        <td width="1%" valign="top" align="left" class="bgcustomize">
                            <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" />
                        </td>
                        <%--r1.jpg--%>
                        <td nowrap="nowrap" width="98%" class="bgcustomize" style="padding-left: 8px">
                            <%--background="<%=strImagepath%>r2.jpg"--%>
                            <asp:Label ID="lbltask" runat="server" CssClass="navigatorpanel">Task:</asp:Label>&nbsp;
                            <asp:Label ID="lbltaskname" runat="server" CssClass="navigatorpanel"></asp:Label>
                        </td>
                        <td width="1%" valign="top" align="right" class="bgcustomize">
                            <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" />
                        </td>
                        <%--r3.jpg--%>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" width="100%"  border="0" style="margin-top:-7px;">
                    <tr>
                        <td valign="top">
                            <table id="Table2" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tr>
                                    <td valign="top" align="left">
                                        <%--<br>--%>
                                        <table id="Table3" cellspacing="2" cellpadding="2" width="99%" align="center" border="0">
                                            <tr>
                                                <td colspan="4" height="5px">
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="left" width="20%" class="label" height="20px">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblAssignedTo" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Assigned_To")%></asp:Label>
                                                </td>
                                                <td align="left" width="30%" class="tablerowcolor2">
                                                    <asp:Label ID="lblAssignedToValue" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="left" width="20%" class="label" height="20px">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblsubject" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Subject")%></asp:Label>
                                                </td>
                                                <td align="left" width="30%" class="tablerowcolor2">
                                                    <asp:Label ID="lblsubject_value" runat="server" Text=""></asp:Label>
                                                </td>
                                                <td align="left" width="20%" class="label" height="20px">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblstatus" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Status")%></asp:Label>
                                                </td>
                                                <td align="left" width="30%" class="tablerowcolor2">
                                                    <asp:Label ID="lblstatus_value" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="left" class="label" height="20px">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblduedate" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Due_Date")%></asp:Label>
                                                </td>
                                                <td align="left" class="tablerowcolor2">
                                                    <asp:Label ID="lblduedate_value" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" class="label" height="20px">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblname" runat="server" Text="contact" CssClass="normaltext"></asp:Label>
                                                </td>
                                                <td align="left" class="tablerowcolor2">
                                                    <asp:Label ID="lblname_value" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr valign="top" style="display: none;">
                                                <td align="left" class="label">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblphone" runat="server" Text="Phone" CssClass="normaltext"></asp:Label>
                                                </td>
                                                <td align="left" class="tablerowcolor2">
                                                    <asp:Label ID="lblphone_value" runat="server"></asp:Label>
                                                </td>
                                                <td align="left" class="label">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblemail" runat="server" Text="Email" CssClass="normaltext"></asp:Label>
                                                </td>
                                                <td align="left" class="tablerowcolor2">
                                                    <asp:Label ID="lblemail_value" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr valign="top">
                                                <td align="left" class="label" height="20px">
                                                    &nbsp;<asp:Label ID="label1" runat="server" Text="" CssClass="normaltext"></asp:Label>
                                                </td>
                                                <td align="left" class="tablerowcolor2">
                                                    <asp:Label ID="label1_value" runat="server"></asp:Label>
                                                </td>
                                                <asp:Panel ID="pnlRelatedTo" runat="server" Visible="false">
                                                    <td align="left" class="label" height="20px">
                                                        <%--class="newLabelText"--%>
                                                        &nbsp;<asp:Label ID="lblLinkedTo" runat="server" Text="Linked To" CssClass="normaltext"></asp:Label>
                                                    </td>
                                                    <td align="left" class="tablerowcolor2">
                                                        <asp:Label ID="lblLinkedTo_value" runat="server"></asp:Label>
                                                    </td>
                                                </asp:Panel>
                                            </tr>
                                            <tr valign="top">
                                                <td align="left" class="label" height="20px">
                                                    <%--class="newLabelText"--%>
                                                    &nbsp;<asp:Label ID="lblcomment" runat="server" Text='' CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Description")%></asp:Label>
                                                </td>
                                                <td colspan="3" align="left" class="tablerowcolor2">
                                                    <asp:Label ID="lblcomment_value" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="border: 0px solid">
                            <table width="70%" border="0" align="left">
                            </table>
                            <table cellspacing="3" cellpadding="5" width="30%" align="right" border="0">
                                <tr>
                                    <td align="left">
                                        <div id="div_btncancel" style="display: block">
                                            <asp:Button ID="btncancel" runat="server" CssClass="button" Text="Cancel" OnClientClick="javascript:var a=cancelClick(path+'welcome.aspx');loadingimage(this.id,'div_cancelprocess');return a;" /><%--OnClick="btncancel_OnClick"--%>
                                        </div>
                                        <div id="div_cancelprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </td>
                                    <td align="left">
                                        <div id="div_btnedit" style="display: block">
                                            <asp:Button ID="btnedit" runat="server" Text="Edit" CssClass="button" OnClick="btnedit_Click"
                                                OnClientClick="javascript:loadingimage(this.id,'div_editprocess');"></asp:Button>
                                        </div>
                                        <div id="div_editprocess" class="button" align="center" style="width: 47px; display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </td>
                                    <td align="left">
                                        <div id="div_btndelete" style="display: block">
                                            <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="button" OnClick="btndelete_Click">
                                            </asp:Button>
                                        </div>
                                        <div id="div_deleteprocess" style="display: none">
                                            <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
                                        </div>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnfollowuptast" runat="server" Width="65px" Text="Follow Up Task"
                                            CssClass="button" OnClick="btnfollowuptast_Click" Visible="false"></asp:Button>
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnfollowupevent" runat="server" Width="65px" CssClass="button" Text="Follow Up Event"
                                            OnClick="btnfollowupevent_Click" Visible="false" />
                                    </td>
                                    <td width="100%">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <img height="10" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

