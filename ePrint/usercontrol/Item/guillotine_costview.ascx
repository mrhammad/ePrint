<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="guillotine_costview.ascx.cs" Inherits="ePrint.usercontrol.Item.guillotine_costview" %>


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
                                <asp:Label ID="lblCostViewTitle" runat="server"><%=objLanguage.GetLanguageConversion("Guillotine_Cost_View")%></asp:Label>
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
            <div align="left" style="width: 100%;">
                <table id="tblPaperHeading" cellpadding="1" cellspacing="1" border="0" runat="server">
                    <tr id="trHeading1">
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <asp:Label ID="Guillotinelabel" class='normaltext' runat="server"></asp:Label>
                            </strong>
                        </td>
                        <td style="width: 300px;">
                            &nbsp;<asp:Label ID="lblGuillotine" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHeading2">
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Minimum_Charge")%></strong>
                        </td>
                        <td class='normaltext' style="width: 300px;">
                            &nbsp;<asp:Label ID="lblMinimumCharge" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class='only10px'>
            </div>
            <table width="100%">
                <tr>
                    <td>
                        <telerik:RadGrid ID="GridGuillotineCostView" AutoGenerateColumns="false" runat="server"
                            HeaderStyle-Font-Bold="true" Width="99%" CssClass="RadGrid_Eprint_Skin" OnItemDataBound="GridGuillotineCostView_OnItemDataBound">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Quantity" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_qty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                            <%--0--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Sheets" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Sheets" runat="server" Text='<%#Eval("Sheets")%>'></asp:Label><%--1--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Print Sheets" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PrintSheets" runat="server" Text='<%#Eval("PrintSheets")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Cuts" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Cuts" runat="server" Text='<%#Eval("Cuts")%>'></asp:Label><%--2--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="No Of Bundles" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_NoOfBundles" runat="server" Text='<%#Eval("NoOfBundles")%>'></asp:Label><%--3--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="First Trim Cuts" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FirstTrimCuts" runat="server" Text='<%#Eval("FirstTrimCuts")%>'></asp:Label><%--4--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="First Trim No Of Bundles" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_FirstTrimNoOfBundles" runat="server" Text='<%#Eval("FirstTrimNoOfBundles")%>'></asp:Label><%--5--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Second Trim Cuts" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SecondTrimCuts" runat="server" Text='<%#Eval("SecondTrimCuts")%>'></asp:Label><%--6--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Second Trim  No Of Bundles" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SecondTrimNoOfBundles" runat="server" Text='<%#Eval("SecondTrimNoOfBundles")%>'></asp:Label><%--7--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Cost Per Cut ($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="CostPerCut">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CostPerCut" runat="server" Text='<%#Eval("CostPerCut")%>'></asp:Label><%--8--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Mark Up(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Markup" Style="text-align: right;" runat="server" Width="75px"
                                                Text='<%#Eval("MarkUp")%>'></asp:TextBox><%--9--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="MarkupPrice" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="MarkupPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MarkupPrice" runat="server" Text='<%#Eval("MarkupPrice")%>'></asp:Label><%--10--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Setup Charge ($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="GuillotineSetupCharge">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SetupCharge" runat="server" Text='<%#Eval("GuillotineSetupCharge")%>'></asp:Label><%--11--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Selling Price($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="SellingPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SellingPrice" runat="server" Text='<%#Eval("SellingPrice")%>'></asp:Label><%--12--%>
                                            <asp:HiddenField ID="hdn_SellingPrice" runat="server" Value='<%#Eval("SellingPrice")%>' />
                                            <asp:HiddenField ID="hdn_MarkupPrice" runat="server" Value='<%#Eval("MarkupPrice")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup" runat="server" Value='<%#Eval("CostExMarkup")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup_Actual" runat="server" Value='<%#Eval("CostExMarkupActual")%>' />
                                            <asp:HiddenField ID="hdn_EstimateCalculationID" runat="server" Value='<%#Eval("EstimateCalculationID")%>' />
                                            <asp:HiddenField ID="hdn_MinimumCharge" runat="server" Value='<%#Eval("MinimumCharge")%>' />
                                            <asp:HiddenField ID="hdn_SetUpCost" runat="server" Value='<%#Eval("SetUpCost")%>' />
                                            <asp:HiddenField ID="hdn_isFirstTrim" runat="server" Value='<%#Eval("isFirstTrim")%>' />
                                            <asp:HiddenField ID="hdn_isSecondTrim" runat="server" Value='<%#Eval("isSecondTrim")%>' />
                                            <asp:HiddenField ID="hdnQtyNumber" runat="server" Value='<%#Eval("QtyNumber")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
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

