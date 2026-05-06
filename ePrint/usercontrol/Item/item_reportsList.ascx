<%@ control language="C#" autoeventwireup="true" CodeBehind="item_reportsList.ascx.cs" Inherits="ePrint.usercontrol.Item.item_reportsList" %>
<div id="div_reportsList" runat="server" style="width: 100%; display: none;
    position: absolute" align="left">
    <div id="div_Main_Item" style="width: 100%; margin-bottom: 5px;">
        <div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <span class="navigatorpanel">Reports List
                                    <asp:Label ID="lblFinishType" runat="server"></asp:Label>
                                </span>
                            </div>
                            <div style="width: 50px; float: right;">
                                <asp:Label ID="lblClose" runat="server" onclick="javascript:Print_Email_Estimate_CloseWindow();return false;"
                                    Style="cursor: pointer" Text="Close X"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--  <div style="clear: both;">
            </div>--%>
        </div>
        <div class="borderWithoutTop">
            <div style="width: 100%">
                <div id="padding">
                    <div align="left" style="width: 100%;">
                        <div class="header" style="float: left; width: 90%">
                            <span class="Headertext">Select the Template to use from the list below for printing/Emailing
                                the Report. </span>
                        </div>
                        <div class="header" style="float: left; width: 90%">
                            <span class="normalText"><b>Note:</b> Modify an existing Report to create a new Template.
                            </span>
                        </div>
                        <div style="float: left; width: 80%;">
                            <table align="right" class="ex" cellspacing="0" border="1" width="100%" cellpadding="4">
                                <col width="50%" />
                                <col width="50%" />
                                <tr class="label">
                                    <td>
                                        <asp:Label ID="Label24" runat="server" Text="Template Description" CssClass="normaltext"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label25" runat="server" Text="File Name" CssClass="normaltext"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        OrderAK Layout
                                    </td>
                                    <td>
                                        OrderAK.rpx
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        InvoiceConfirm
                                    </td>
                                    <td>
                                        Invoice.rpx
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left; width: 100%; padding: 10px 5px 0px 0px">
                            <asp:Button ID="Button3" runat="server" Text="Print" Width="65px" CssClass="button"
                                OnClientClick="javascript:return false;" />
                            <asp:Button ID="Button1" runat="server" Text="Email" Width="65px" CssClass="button"
                                OnClientClick="javascript:return false;" />
                            <asp:Button ID="Button2" runat="server" Text="Print / Email" Width="100px" CssClass="button"
                                OnClientClick="javascript:return false;" />
                            <asp:Button ID="Button4" runat="server" Text="Delete" Width="65px" CssClass="button"
                                OnClientClick="javascript:return false;" />
                        </div>
                    </div>
                    <div style="clear: both">
                        &nbsp;
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="clear: both; width: 775px">
        &nbsp;
    </div>
</div>

<script type="text/javascript" language="javascript">
    var divReportsList = document.getElementById("<%=div_reportsList.ClientID %>");
    function MakeMaskShow_OrderAck() {
        var w = 900; var h = 800;
        displayCommon_first(divReportsList.id, w, h);
    }
    function Print_Email_Estimate_CloseWindow() {
        closewindow(divReportsList.id);
    }

</script>



