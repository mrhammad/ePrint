<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="plates_costview.ascx.cs" Inherits="ePrint.usercontrol.Item.plates_costview" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/Item/item_cost_view_new_reeng.js?VN='<%=VersionNumber%>'"></script>
<div align="left" id="div_Complete" runat="server">
    <div align="left" style="width: 100%;">
        <%--<div style="width: 100%;" class="navigatorpanel">
            <div class="t">
                <div class="t">
                    <div class="t">
                        <div class="divpadding">
                            <div align="left" style="float: left;" nowrap="nowrap">
                                <asp:Label ID="lblCostViewTitle" runat="server">Plate Cost View</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div>
            <%--class="divBorderItem"--%>
            <%--<div class='only10px'>
            </div>--%>
            <table width="100%">
                <tr>
                    <td>
                        <%--   <div align="left" style="width: 100%">--%>
                        <telerik:RadGrid ID="GridPlatesCostView" AutoGenerateColumns="false" runat="server"
                            HeaderStyle-Font-Bold="true" Width="100%" CssClass="RadGrid_Eprint_Skin" OnItemDataBound="GridPlatesCostView_OnItemDataBound">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Plate Name" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PlateName" runat="server" ><%# objbase.SpecialDecode(DataBinder.Eval(Container, "DataItem.PlateName", "{0}"))%></asp:Label>
                                            <%--0--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Quantity" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_qty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label><%--1--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Unit Price ($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="UnitPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_UnitPrice" runat="server" Text='<%#Eval("UnitPrice")%>'></asp:Label><%--2--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Mark up(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Markup" Style="text-align: right;" runat="server" Width="75px"
                                                Text='<%#Eval("Markup")%>'></asp:TextBox><%--3--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="MarkupPrice" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="MarkupPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MarkupPrice" runat="server" Text='<%#Eval("MarkupPrice")%>'></asp:Label><%--4--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Selling Price($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="SellingPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SellingPrice" runat="server" Text='<%#Eval("SellingPrice")%>'></asp:Label><%--5--%>
                                            <asp:HiddenField ID="hdn_SellingPrice" runat="server" Value='<%#Eval("SellingPrice")%>' />
                                            <asp:HiddenField ID="hdn_MarkupPrice" runat="server" Value='<%#Eval("MarkupPrice")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup" runat="server" Value='<%#Eval("CostExMarkup")%>' />
                                            <asp:HiddenField ID="hdn_EstimateCalculationID" runat="server" Value='<%#Eval("EstimateCalculationID")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <%-- </div>--%>
                        <asp:HiddenField ID="hdn_LithoMarkup" runat="server" Value="" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
<script type="text/javascript">
    var CompanyID = '<%=CompanyID%>';
    var UserID = '<%=UserID%>';
    var hdn_LithoMarkup = document.getElementById("<%=hdn_LithoMarkup.ClientID %>");
</script>
<asp:Panel ID="pnlCallAfterUpdate" runat="server" Visible="false">
    <script type="text/javascript">

        var Pgtype = '<%=Module %>';
        var EstID = '<%=EstimateID %>';
        var EstItemID = '<%=EstimateItemID %>';
        var JobID = '<%=JobID %>';
        var InvID = '<%=InvoiceID %>';
        var IsFromeStore = '<%=IsFromeStore %>';


        function TakeOut() {
            window.close();
        }

        if (Pgtype == 'estimate') {
            window.close();
            parent.location.href = "<%=strSitepath%>estimates/estimate_summary_reeng.aspx?&estid=" + EstID + "&EstItemID=" + EstItemID + "";

        }

        if (Pgtype == 'order') {
            window.close();
            parent.location.href = "<%=strSitepath%>orders/order_summary.aspx?&estid=" + EstID + "&EstItemID=" + EstItemID + "&ordid=" + EstID + "";

        }
        else if (Pgtype == 'job') {
            window.close();
            if (IsFromeStore.toLowerCase() == 'yes') {
                parent.location.href = "<%=strSitepath%>jobs/job_order_summary.aspx?&ordid=" + EstID + "&estid=" + EstID + "&jID=" + JobID + "&EstItemID=" + EstItemID + "";
            }
            else {
                parent.location.href = "<%=strSitepath%>jobs/job_summary_reeng.aspx?&estid=" + EstID + "&jID=" + JobID + "&EstItemID=" + EstItemID + "";
            }
        }
        else if (Pgtype == 'invoice') {
            window.close();
            if (IsFromeStore.toLowerCase() == 'yes') {
                parent.location.href = "<%=strSitepath%>invoice/invoice_order_summary.aspx?&ordid=" + EstID + "&estid=" + EstID + "&jID=" + JobID + "&EstItemID=" + EstItemID + "&InvID=" + InvID + "";
            }
            else {
                parent.location.href = "<%=strSitepath%>invoice/Invoice_Summary_reeng.aspx?&estid=" + EstID + "&EstItemID=" + EstItemID + "&InvID=" + InvID + "";
            }
        }

    </script>
</asp:Panel>

