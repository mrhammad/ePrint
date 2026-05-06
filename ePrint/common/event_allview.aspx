
<%@ page language="C#" masterpagefile="~/Templates/innerMasterPage_withLeftTD.master" autoeventwireup="true" CodeBehind="event_allview.aspx.cs" Inherits="ePrint.common.event_allview" title="All Activity" enableviewstatemac="false" enableEventValidation="false" theme="Theme1" %>

<%@ Register Src="~/usercontrol/AlphabetSearch.ascx" TagName="AlphabetSearch" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript" src="../common/forSectionHeader.js?VN='<%=VersionNumber%>'"></script>
    <asp:PlaceHolder ID="plhHeader" runat="server"></asp:PlaceHolder>
    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" id="TABLE2"
        class="borderWithoutTop">
        <tr valign="top">
            <td align="right" style="width: 50%">
                <table cellspacing="2" cellpadding="2" width="60%" align="left" border="0">
                    <tr valign="top">
                        <td align="left" style="width: 90%">
                        </td>
                        <td style="width: 10%" class="headertext">
                            <table cellspacing="0" cellpadding="5" width="99%" align="right" border="0" id="TABLE3">
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" ToolTip="Day View" runat="server" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton2" ToolTip="Week View" runat="server" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton3" ToolTip="Month View" runat="server" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton4" ToolTip="All View" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-left: 8px">
                <div style="width: 100%; float: left">
                    <uc:alphabetsearch id="ucAplhaSearch" runat="server" />
                </div>
            </td>
        </tr>
        <tr valign="top" colspan="2">
            <td>
                <img height="5" alt="" src="<%=strImagepath%>nil.gif" width="1" border="0">
            </td>
        </tr>
        <tr valign="top">
            <td valign="top" colspan="2">
                <table id="Table1" cellspacing="2" cellpadding="2" width="99%" align="left" border="0">
                    <tr valign="top">
                        <td align="left" colspan="6">
                            <div id="div_TotalRec" style="float: right; padding-right: 28px">
                                <span class="normalText">Total Records:</span><b>
                                    <asp:Label ID="lblTotalRecords" runat="server"></asp:Label></b></div>
                            <div class="onlyEmpty">
                            </div>
                            <asp:Panel ID="pnlEmptyRecords" runat="server" Visible="false">
                                <div id="padding" class="emptyrecords" align="center">
                                    <asp:Label ID="lblNoData" runat="server" Width="90%"></asp:Label>
                                </div>
                            </asp:Panel>
                            <div id="a">
                            </div>
                            <div id="div_Grid">
                                <asp:DataGrid DataKeyField="IDVal" ID="dgr" runat="server" CssClass="GridviewBorder GridOverflowHidden"
                                    Width="100%" AllowPaging="false" GridLines="none" AutoGenerateColumns="False"
                                    CellSpacing="1" CellPadding="0" AllowSorting="True" OnSortCommand="dgr_SortCommand"
                                    OnPageIndexChanged="dgr_PageIndexChanged" OnItemCreated="dgr_ItemCreated" OnItemDataBound="OnItemDataBound1"
                                    ShowFooter="true" PagerStyle-Visible="false" HeaderStyle-ForeColor="black">
                                    <AlternatingItemStyle Height="20px" BorderWidth="0px" BorderStyle="None" CssClass="NewAlternative">
                                    </AlternatingItemStyle>
                                    <ItemStyle Height="20px" BorderWidth="0px" CssClass="NewTableRows" Wrap="false">
                                    </ItemStyle>
                                    <HeaderStyle CssClass="bgcustomize navigatorpanel" Height="23" Wrap="false"></HeaderStyle>
                                    <%--CssClass="bgImageDGHeader"--%>
                                    <Columns>
                                        <asp:TemplateColumn SortExpression="DateVal" HeaderText="Due Date" HeaderStyle-Width="13%"
                                            ItemStyle-Width="13%">
                                            <HeaderStyle CssClass="bgcustomize" Wrap="false" Width="13%" HorizontalAlign="Center">
                                            </HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDueDate"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn SortExpression="subject" HeaderText="Subject" HeaderStyle-Width="30%"
                                            ItemStyle-Width="30%">
                                            <HeaderStyle CssClass="bgcustomize" Wrap="false"></HeaderStyle>
                                            <ItemStyle Wrap="false" />
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "subject") %>'
                                                    NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.IDVal", "event_detail.aspx?eventid={0}&eventtype=home&eventtypeid=0") %>'></asp:HyperLink>
                                                <asp:Label runat="server" ID="lbltype" Text='<%# DataBinder.Eval(Container.DataItem, "type") %>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label runat="server" ID="lbltypeId" Text='<%# DataBinder.Eval(Container.DataItem, "typeId") %>'
                                                    Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn ItemStyle-Width="20%" DataField="contactname" SortExpression="contactname"
                                            HeaderText="Contact Name" HeaderStyle-Width="20%">
                                            <HeaderStyle CssClass="bgcustomize" Wrap="false"></HeaderStyle>
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="20%" DataField="Status" SortExpression="Status"
                                            HeaderText="Status" HeaderStyle-Width="20%">
                                            <HeaderStyle CssClass="bgcustomize" Wrap="false"></HeaderStyle>
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="10%" HeaderStyle-Width="10%" DataField="Priority"
                                            SortExpression="Priority" HeaderText="Priority">
                                            <HeaderStyle CssClass="bgcustomize" Wrap="false"></HeaderStyle>
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="10%" DataField="typeval" SortExpression="typeval"
                                            HeaderText="Type Name">
                                            <HeaderStyle CssClass="bgcustomize" Wrap="false" Width="10%"></HeaderStyle>
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="0" HeaderStyle-Width="0%" DataField="Date1" SortExpression="Date1"
                                            HeaderText="Modified On">
                                            <HeaderStyle CssClass="bgcustomize" Wrap="false" Width="0%"></HeaderStyle>
                                            <ItemStyle Wrap="false" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="0%" DataField="Ctype">
                                            <HeaderStyle CssClass="bgcustomize" Width="0%"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="0%" DataField="ContID">
                                            <HeaderStyle CssClass="bgcustomize" Width="0%"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="0%" DataField="strType">
                                            <HeaderStyle CssClass="bgcustomize" Width="0%"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-Width="0%" DataField="TypeID">
                                            <HeaderStyle CssClass="bgcustomize" Width="0%"></HeaderStyle>
                                        </asp:BoundColumn>
                                    </Columns>
                                    <FooterStyle HorizontalAlign="right" CssClass="normaltext" />
                                </asp:DataGrid>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
    <div id="div_test_1" style="width: 100%; overflow-y: scroll; border: solid 1px blue;
        display: none">
        <div id="div_test_2" style="width: 100%; border: solid 1px red;">
            Loading...</div>
    </div>
    <asp:HiddenField ID="hidGridCount" runat="server" Value="" />
    <script src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script>

    </script>
    <script>
        //*** Function to make gridview scrollable ***//
        function start() {
            document.getElementById("div_test_1").style.display = "none";
            var t = document.getElementById("<%=dgr.ClientID%>");
            var t2 = t.cloneNode(true)
            for (i = t2.rows.length - 1; i > 0; i--)
                t2.deleteRow(i)
            t.deleteRow(0)
            document.getElementById("a").appendChild(t2);

            if (t.rows.length < 19) {
                document.getElementById("div_Grid").style.overflowY = "auto";
                document.getElementById("div_TotalRec").style.paddingRight = "5px";
            }
            else {
                var divObj = document.getElementById("a");
                var aWidth = divObj.offsetWidth;

                div = t.parentNode;
                if (div.tagName == "DIV") {
                    div.className = "WrapperDiv";
                    div.style.overflowY = "scroll";

                    document.getElementById("div_test_1").style.display = "block";
                    var OuterDivWidth = document.getElementById("div_test_1").offsetWidth;
                    var InnerDivWidth = document.getElementById("div_test_2").offsetWidth
                    var MinusThisWidth = Number(OuterDivWidth) - Number(InnerDivWidth);
                    document.getElementById("div_test_1").style.display = "none";

                    if (navigator.appName == "Microsoft Internet Explorer") {
                        document.getElementById("div_TotalRec").style.paddingRight = Number(MinusThisWidth) + "px";
                        document.getElementById("a").style.padding = "0px";
                        document.getElementById("a").style.width = Number(aWidth) - Number(MinusThisWidth - 1) + "px";
                        document.getElementById("div_Grid").style.width = Number(aWidth - 1) + "px";
                    }
                    else {
                        document.getElementById("div_TotalRec").style.paddingRight = "28px";
                        document.getElementById("a").style.width = Number(aWidth) - Number(MinusThisWidth) + "px";
                        document.getElementById("div_Grid").style.width = Number(aWidth) + "px";
                    }
                }
            }
            document.getElementById("div_Grid").style.display = "block";
        }
        if ('<%=totalrec %>' != 0) {
            window.onload = start
        }
        //*** Function to make gridview scrollable ***//
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

