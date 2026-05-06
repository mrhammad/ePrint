<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="taskviewall.aspx.cs" Inherits="ePrint.common.taskviewall" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" %>

<%@ Register Src="~/usercontrol/AlphabetSearch.ascx" TagName="AlphabetSearch" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">
        function changeStyle(xobj, xStyle, xbgColor) {
            xobj.className = xStyle;
            xobj.style.backgroundColor = xbgColor;
        }
    </script>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="TABLE2">
        <tr>
            <td class="" style="width: 100%" align="center">
                <table id="Table3" border="0" cellspacing="0" cellpadding="0" width="100%" align="center"
                    height="23">
                    <asp:Panel ID="pnlTop" runat="server">
                        <tr valign="middle">
                            <td width="1%" valign="top" align="left" class="bgcustomize">
                                <img alt="" src="<%=strImagepath%>lt_tabnotch.gif" width="5" height="5" />
                            </td>
                            <%--r1.jpg--%>
                            <td width="90%" class="bgcustomize" nowrap="nowrap">
                                <%--background="<%=strImagepath%>r2.jpg"--%>
                                <span class="navigatorpanel">Task</span>
                            </td>
                            <td width="1%" valign="top" align="right" class="bgcustomize">
                                <img alt="" src="<%=strImagepath%>rt_tabnotch.gif" width="5" height="5" />
                            </td>
                            <%--r3.jpg--%>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" border="0" width="100%" class="borderWithoutTop">
                    <tr>
                        <td>
                            <img height="5" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                        </td>
                    </tr>
                    <asp:Panel ID="pnlnoofrecordsperpage" runat="server">
                        <tr valign="top">
                            <td>
                                <img height="5" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <table border="0" cellspacing="3" cellpadding="0" width="100%" align="left">
                                    <tr>
                                        <td style="width: 100%">
                                            &nbsp;<UC:AlphabetSearch ID="ucAplhaSearch" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td>
                                <img height="5" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                            </td>
                        </tr>
                    </asp:Panel>
                    <%--======================================================--%>
                    <tr valign="top">
                        <td>
                            <img height="2" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <table width="98%" border="0" cellpadding="0" cellspacing="0" align="center">
                                <asp:Panel ID="pnlNorecord" runat="server" Visible="false">
                                    <tr style="height: 5px">
                                        <td>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <table cellspacing="2" cellpadding="2" border="0" width="20%" align="center">
                                                <tr valign="top">
                                                    <td align="center" class="error">
                                                        <img height="1" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0" /><br>
                                                        <asp:Label ID="lblNoTask" runat="server"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <asp:LinkButton ID="Lnk2" runat="server" Text="Back"></asp:LinkButton>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </asp:Panel>
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:UpdatePanel ID="UP1" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblletter" Text="" runat="server" Visible="false"></asp:Label>
                                                <div id="div_TotalRec">
                                                </div>
                                                <div id="a">
                                                </div>
                                                <div id="div_Grid">
                                                    <asp:GridView ID="dgrTask" runat="server" DataKeyNames="taskID" AutoGenerateColumns="False"
                                                        AllowPaging="false" AllowSorting="True" ShowHeader="true" DataSourceID="SqlDataSource1"
                                                        GridLines="None" OnDataBound="dgrTask_DataBound" OnRowDataBound="dgrTask_RowDataBound"
                                                        OnPageIndexChanging="dgrTask_PageIndexChanging" SkinID="GridStyle" Width="100%">
                                                        <HeaderStyle CssClass="bgcustomize" Font-Bold="true" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Due Date" DataField="dueDate" SortExpression="dueDate"
                                                                HeaderStyle-Width="15%" ItemStyle-Width="15%" ItemStyle-Wrap="false" HeaderStyle-HorizontalAlign="Center"
                                                                ItemStyle-HorizontalAlign="Center" />
                                                            <asp:TemplateField SortExpression="subject" ItemStyle-Width="40%" ItemStyle-Wrap="false"
                                                                ItemStyle-HorizontalAlign="left">
                                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="40%" />
                                                                <HeaderTemplate>
                                                                    <div style='width: 320px; min-width: 300px; overflow: hidden; max-height: 15px; height: 15px;'>
                                                                        <asp:Label runat="server" Text="Subject"></asp:Label></div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style='width: 320px; min-width: 300px; overflow: hidden; max-height: 15px; height: 15px;'>
                                                                        <asp:LinkButton runat="server" ID="lnkdetails" Text='<%# DataBinder.Eval(Container.DataItem, "subject") %>'
                                                                            OnClientClick='<%# Eval("taskID","return testjs({0})") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "type") %>'
                                                                            CommandName='<%# DataBinder.Eval(Container.DataItem, "typeId") %>' OnCommand='lnkdetails_OnCommand'></asp:LinkButton>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="contactname" ItemStyle-Width="25%" ItemStyle-Wrap="false"
                                                                ItemStyle-HorizontalAlign="left">
                                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="25%" />
                                                                <HeaderTemplate>
                                                                    <div style='width: 200px; min-width: 160px; overflow: hidden; max-height: 15px; height: 15px;'>
                                                                        <asp:Label runat="server" Text="Contact Name"></asp:Label></div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style='width: 200px; min-width: 160px; overflow: hidden; max-height: 15px; height: 15px;'>
                                                                        <%--<asp:HyperLink ID="hltype" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.contactname")%>'></asp:HyperLink>--%>
                                                                        <%# DataBinder.Eval(Container, "DataItem.contactname")%>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField SortExpression="taskstatus" ItemStyle-Width="20%" ItemStyle-Wrap="false"
                                                                ItemStyle-HorizontalAlign="left">
                                                                <HeaderStyle HorizontalAlign="Left" Wrap="false" Width="20%" />
                                                                <HeaderTemplate>
                                                                    <div style='width: 160px; min-width: 150px; overflow: hidden; max-height: 15px; height: 15px;'>
                                                                        <asp:Label runat="server" Text="Task Status"></asp:Label></div>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <div style='width: 160px; min-width: 150px; overflow: hidden; max-height: 15px; height: 15px;'>
                                                                        <%--<asp:HyperLink ID="hypRelation" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.taskstatus")%>'></asp:HyperLink>--%>
                                                                        <%# DataBinder.Eval(Container, "DataItem.taskstatus")%>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <EmptyDataTemplate>
                                                            <div id="padding" class="emptyrecords" align="center">
                                                                <span class="HeaderText" style="text-align: center;">No record(s) found</span>
                                                            </div>
                                                        </EmptyDataTemplate>
                                                        <PagerTemplate>
                                                        </PagerTemplate>
                                                        <PagerStyle CssClass="normaltext" />
                                                        <PagerSettings Position="Bottom" />
                                                    </asp:GridView>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                                            SelectCommand="crm_home_select_taskviewall_new" SelectCommandType="StoredProcedure"
                                            ConflictDetection="CompareAllValues">
                                            <SelectParameters>
                                                <asp:SessionParameter Name="intCompID" SessionField="companyID" Type="Int32" DefaultValue="0" />
                                                <asp:SessionParameter Name="intAssignedID" SessionField="userid" Type="Int32" DefaultValue="0" />
                                                <asp:ControlParameter ControlID="lblletter" Name="Para" DefaultValue=" " PropertyName="Text"
                                                    Type="String" Direction="Input" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </td>
                                    <td>
                                        <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
                                            display: none">
                                            <div id="div_test_2" style="width: 100%; border: solid 1px red;">
                                                Loading...</div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td>
                            <img height="8" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField Value="0" ID="hdnTaskID" runat="server" />
    <script src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:Panel ID="pnlCallScroll" runat="server" Visible="false">
        <script type="text/javascript">
            CallScroll();           
        </script>
    </asp:Panel>
    <script type="text/javascript">
        function CallScroll() {

            var GridID = document.getElementById("<%=dgrTask.ClientID%>");
            var div_HeaderID = document.getElementById("a");
            var div_BodyID = document.getElementById("div_Grid");
            var OuterDivID = document.getElementById("div_test_1");
            var InnerDivID = document.getElementById("div_test_2");
            var DivTotalRecID = document.getElementById("div_TotalRec");
            start(GridID, div_HeaderID, div_BodyID, OuterDivID, InnerDivID, DivTotalRecID);
        }
        window.onload = CallScroll
        var ClrTimeID = '';
        var countTime = 0;

        //*** Function to make gridview scrollable ***//
        //    
        function testjs(val) {
            document.getElementById("<%=hdnTaskID.ClientID %>").value = val
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
