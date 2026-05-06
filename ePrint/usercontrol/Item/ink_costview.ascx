<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ink_costview.ascx.cs" Inherits="ePrint.usercontrol.Item.ink_costview" %>

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
                                <asp:Label ID="lblCostViewTitle" runat="server">Ink Cost View</asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>--%>
        <div align="left" style="width: 100%;">
            <table id="tblPaperHeading" cellpadding="1" style="margin-left: 1%;" cellspacing="1"
                border="0" width="350px" runat="server">
                <tr id="trHeading1">
                    <td class="bglabel" style="width: 150px;">
                        <strong>
                            <%=objLanguage.GetLanguageConversion("Side1")%> <%=ObjPage.GetRegionalSettings(CompanyID, "Colour")%></strong>
                    </td>
                    <td style="width: 200px;">
                        <asp:Label ID="lblSide1color" class='normaltext' runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trHeading2" runat="server">
                    <td class="bglabel" style="width: 150px;">
                        <strong>
                            <%=objLanguage.GetLanguageConversion("Side2")%> <%=ObjPage.GetRegionalSettings(CompanyID, "Colour")%></strong>
                    </td>
                    <td style="width: 200px;">
                        <asp:Label ID="lblSide2color" class='normaltext' runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div id="padding">
            <%--class="divBorderItem"--%>
            <%-- <div class='only10px'>
            </div>--%>
            <table width="100%">
                <tr>
                    <td>
                        <telerik:RadGrid ID="GridInkCostView" AutoGenerateColumns="false" runat="server"
                            PageSize="50" Width="99%" HeaderStyle-Font-Bold="true" CssClass="RadGrid_Eprint_Skin"
                            OnItemDataBound="GridInkCostView_OnItemDataBound">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Quantity" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Bold="true"
                                        UniqueName="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_qty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label><%--0--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Paperlength" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="Paperlength"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_paperlength" runat="server" Text='<%#Eval("Paperlength")%>'></asp:Label><%--0--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Sides" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" ItemStyle-Font-Bold="true"
                                        UniqueName="Sides">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Sides" runat="server" Text='<%#Eval("SideNumber")%>'><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.SideNumber", "{0}"))%></asp:Label><%--1--%>
                                            <asp:HiddenField ID="hdnSides" runat="server" Value='<%#Eval("Side")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ink Name" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_InventorySheets" runat="server"><%# objBase.SpecialDecode(DataBinder.Eval(Container, "DataItem.InkName", "{0}"))%></asp:Label><%--2--%>
                                            <asp:HiddenField ID="hdninkType" runat="server" Value='<%#Eval("inkType")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Cost Price ($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="CostPrice"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_CostPrice" runat="server" Text='<%#Eval("CostPrice")%>'></asp:Label><%--3--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <%--<telerik:GridTemplateColumn HeaderText="Ink Coverage(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Coverage" runat="server" Text='<%#Eval("Coverage")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>--%><%--4--%>
                                    <telerik:GridTemplateColumn HeaderText="Ink Coverage1(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_InkCoverage1" runat="server" Text='<%#Eval("InkCoverage1")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <%--4--%>
                                    <telerik:GridTemplateColumn HeaderText="Ink Coverage2(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_InkCoverage2" runat="server" Text='<%#Eval("InkCoverage2")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <%--5--%>
                                    <telerik:GridTemplateColumn HeaderText="Unit Price($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="UnitPrice"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_UnitPrice" runat="server" Text='<%#Eval("UnitPrice")%>'></asp:Label><%--6--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Mark up(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Markup" Style="text-align: right;" runat="server" Width="75px"
                                                Text='<%#Eval("Markup")%>'></asp:TextBox><%--7--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="MarkupPrice" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="MarkupPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MarkupPrice" runat="server" Text='<%#Eval("MarkupPrice")%>'></asp:Label><%--8--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Minimum Charge" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MinCharge" runat="server" Text='<%#Eval("MinimumCharge")%>'></asp:Label><%--9--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Setup Cost($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="SetupCost"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SetupCost" runat="server" Text='<%#Eval("SetupCost")%>'></asp:Label><%--10--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Selling Price($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="SellingPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SellingPrice" runat="server" Text='<%#Eval("SellingPrice")%>'></asp:Label><%--11--%>
                                            <asp:HiddenField ID="hdn_SellingPrice" runat="server" Value='<%#Eval("SellingPrice")%>' />
                                            <asp:HiddenField ID="hdn_MarkupPrice" runat="server" Value='<%#Eval("MarkupPrice")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup" runat="server" Value='<%#Eval("CostExMarkup")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup_Actual" runat="server" Value='<%#Eval("CostExMarkupActual")%>' />
                                            <asp:HiddenField ID="hdn_EstimateInkCalcId" runat="server" Value='<%#Eval("EstimateInkCalcId")%>' />
                                            <asp:HiddenField ID="hdn_EstimateCalculationID" runat="server" Value='<%#Eval("EstimateCalculationID")%>' />
                                            <asp:HiddenField ID="hdn_MinimumCharge" runat="server" Value='<%#Eval("MinimumCharge")%>' />
                                            <asp:HiddenField ID="hdn_SetUpCost" runat="server" Value='<%#Eval("SetUpCost")%>' />
                                            <asp:HiddenField ID="hdnQty" runat="server" Value='<%#Eval("QtyNo")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-right: 15px;">
                        <asp:PlaceHolder ID="plhTotalSellingPrice" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        <asp:Button ID="btnSave" Style="margin-right: 8px;" CssClass="button" runat="server"
                            Text="Save" OnClick="btnSave_Click" />
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

        function CallNow() {


            //parent.location.reload();
        }
        function TakeOut() {
            window.close();
        }
        CallNow();

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

