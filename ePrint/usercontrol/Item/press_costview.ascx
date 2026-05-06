<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="press_costview.ascx.cs" Inherits="ePrint.usercontrol.Item.press_costview" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript" src="<%=strSitepath %>js/Item/general.js?VN='<%=VersionNumber%>'"></script>
<script type="text/javascript" src="<%=strSitepath %>js/Item/item_cost_view_new_reeng.js?VN='<%=VersionNumber%>'"></script>
<div align="left" id="div_Complete" runat="server">
    <div align="left" style="width: 100%;">
        <div>
            <div align="left" style="width: 100%;">
                <table id="tblPaperHeading" cellpadding="1" cellspacing="1" border="0" runat="server">
                    <tr id="trHeading1">
                        <td class="bglabel" style="width: 200px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Press_Name")%></strong>
                        </td>
                        <td style="width: 250px;">
                            <asp:Label ID="lblPressName" class='normaltext' runat="server" Text="Press Name"></asp:Label>
                        </td>
                       <%-- <td style="width: 100px;">
                            &nbsp;
                        </td>--%>
                        <td id="righttd1" class="bglabel" style="width: 200px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Double_Sided")%></strong>
                        </td>
                        <td style="width: 250px;">
                            <asp:Label ID="lblDoubleSided" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHeading2">
                        <td class="bglabel" style="width: 200px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Minimum_Charge")%></strong>
                        </td>
                        <td class='normaltext' style="width: 250px;">
                            <asp:Label ID="lblMinimumCharge" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                        <%--<td style="width: 100px;">
                            &nbsp;
                        </td>--%>
                        <td id="Td1" class="bglabel" style="width: 200px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Print_Speed")%></strong>
                        </td>
                        <td style="width: 250px;">
                            <asp:Label ID="lblPrintQuality" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                        <td id="Td2" runat="server" class="bglabel" style="width: 200px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Print_Quality_DPI")%></strong>
                        </td>
                        <td id="Td3" style="width: 250px;">
                            <asp:Label ID="LblPrintQualityDPI" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHeading3" visible="false">
                        <td class="bglabel" style="width: 200px;">
                            <strong>Zone buildup Calculation method</strong>
                        </td>
                        <td class='normaltext' style="width: 250px;">
                            <asp:Label ID="lbl_ZonebuildupCalculationmethod" class='normaltext' runat="server"
                                Text=""></asp:Label>
                        </td>
                        <td colspan="3">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <div class='only10px'>
            </div>
            <table width="100%">
                <tr>
                    <td>
                        <telerik:RadGrid ID="GridPressCostView" AutoGenerateColumns="false" runat="server"
                            HeaderStyle-Font-Bold="true" Width="99%" OnItemDataBound="GridPressCostView_OnItemDataBound">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Quantity" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_qty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                            <asp:HiddenField ID="hdn_qty" runat="server" Value='<%#Eval("Quantity")%>' />
                                            <%--0--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Print Sheets" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PrintSheets" runat="server" Text='<%#Eval("PrintSheets")%>'></asp:Label>
                                            <%--1--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Total Clicks" HeaderStyle-HorizontalAlign="Right" Visible="false"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TotalCLicks" runat="server" Text='<%#Eval("PrintSheets")%>'></asp:Label>
                                            <%--2--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Passes" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Passes" runat="server" Text='<%#Eval("DoubleSided")%>'></asp:Label>
                                            <%--3--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Paper Length (Metre)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PaperLength" runat="server" Text='<%#Eval("PaperLength")%>'></asp:Label>
                                           <%--3--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText=" Click Cost" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ChargableRate" runat="server" Text='<%#Eval("ChargableRate")%>'></asp:Label>
                                            <%--4--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Chargable Sheets" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ChargableSheets" runat="server" Text='<%#Eval("ChargableSheets")%>'></asp:Label>
                                            <%--5--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Chargable Rate(Side 1)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ChargableRateSide1" runat="server" Text='<%#Eval("ChargableRateSide1")%>'></asp:Label>
                                            <%--6--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Chargable Rate(Side 2)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ChargableRateSide2" runat="server" Text='<%#Eval("ChargableRateSide2")%>'></asp:Label>
                                            <%--7--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Job Time(min)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_JobTime" runat="server" Text='<%#Eval("JobTime")%>'></asp:Label>
                                            <%--8--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Hourly Rate($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false" UniqueName="HourlyRate">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_HourlyRate" runat="server" Text='<%#Eval("HourlyRate")%>'></asp:Label>
                                            <%--9--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Job Time(min) Side1" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false" UniqueName="JobTimeSide1">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_JobTimeSide1" runat="server" Text='<%#Eval("JobTimeSide1")%>'></asp:Label>
                                            <%--10--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Job Time(min) Side2" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_JobTimeSide2" runat="server" Text='<%#Eval("JobTimeSide2")%>'></asp:Label>
                                            <%--11--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Side colour" HeaderStyle-HorizontalAlign="Left"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Sidecolour" runat="server" Text='<%#Eval("Sidecolour")%>'></asp:Label>
                                            <%--12--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Click Cost" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_ClickChargeCost" runat="server" Text='<%#Eval("ClickChargeCost")%>'></asp:Label>
                                            <%--13--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Mark Up(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Markup" Style="text-align: right;" runat="server" Text='<%#Eval("MarkUp")%>'
                                                Width="75px"></asp:TextBox>
                                            <%--14--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                      <telerik:GridTemplateColumn HeaderText="Click Sell" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            
                                                <asp:Label ID="lbl_ZoneSide1Cost" runat="server" Text='<%#Eval("ZoneSide1Cost")%>'></asp:Label><%--15--%>
                                            <%--15--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Markup" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false" UniqueName="MarkupPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MarkupPrice" runat="server" Text='<%#Eval("MarkupPrice")%>'></asp:Label>
                                            <%--16--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="SetupCharge" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false" UniqueName="SetupCharge">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SetupCharge" runat="server" Text='<%#Eval("SetupCharge")%>'></asp:Label>
                                            <%--17--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="SellingPrice" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false" UniqueName="SellingPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SellingPrice" runat="server" Text='<%#Eval("SellingPrice")%>'></asp:Label>
                                            <%--18--%>
                                            <asp:HiddenField ID="hdn_SellingPrice" runat="server" Value='<%#Eval("SellingPrice")%>' />
                                            <asp:HiddenField ID="hdn_MarkupPrice" runat="server" Value='<%#Eval("MarkupPrice")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup" runat="server" Value='<%#Eval("CostExMarkup")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup_Actual" runat="server" Value='<%#Eval("CostExMarkupActual")%>' />
                                            <asp:HiddenField ID="hdn_EstimateCalculationID" runat="server" Value='<%#Eval("EstimateCalculationID")%>' />
                                            <asp:HiddenField ID="hdn_MinimumCharge" runat="server" Value='<%#Eval("MinimumCharge")%>' />
                                            <asp:HiddenField ID="hdn_SetUpCost" runat="server" Value='<%#Eval("SetUpCost")%>' />
                                            <asp:HiddenField ID="hdnPressType" runat="server" />
                                            <asp:HiddenField ID="hdnQtyNoOnlyForZone" runat="server" Value='<%#Eval("QtyNo")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="" HeaderStyle-HorizontalAlign="Right" ItemStyle-Wrap="false"
                                        ItemStyle-HorizontalAlign="Right" UniqueName="PricePerUnitofMeasure" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PricePerUnitofMeasure" runat="server" Text='<%#Eval("PricePerUnitofMeasure")%>'></asp:Label>
                                            <%--19--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <asp:HiddenField ID="hdn_ZoneSaveItem" runat="server" Value="kumar" />
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
                        <asp:Button ID="btnSave" Style="margin-right: 9px;" CssClass="button" runat="server"
                            Text="Save" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            <%--     </div>--%>
        </div>
    </div>
</div>
<div align="left" id="divfooter" runat="server">
    <br />
    <span style="vertical-align: middle; color: red">*</span>&nbsp;<asp:Label ID="lblnote"
        runat="server" CssClass="smallgraytext"><%=objLanguage.GetLanguageConversion("Press_PPUM_Note")%></asp:Label>
</div>
<script type="text/javascript">
    var CompanyID = '<%=CompanyID%>';
    var UserID = '<%=UserID%>';
    var PressType = '<%=PressType %>'
    var EstType = '<%=EstType %>'
    var hdn_ZoneSaveItem = document.getElementById("<%=hdn_ZoneSaveItem.ClientID %>");
    var isZdoubleside = '<%=isZdoubleside%>'.toLowerCase();

    $(document).ready(function () {
        $TxtMarkUp = $('#<%=GridPressCostView.ClientID %>').find('input:text[id$="txt_Markup"]');
        $lblSellingPrice = $('#<%=GridPressCostView.ClientID %>').find('span[id$="lbl_SellingPrice"]');
        $hdnSellingPrice = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdn_SellingPrice"]');
        $hdnMarkupPrice = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdn_MarkupPrice"]');
        $hdnCostExMarkup = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdn_CostExMarkup"]');
        $hdnCostExMarkupActual = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdn_CostExMarkup_Actual"]');
        $hdnMinimumCharge = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdn_MinimumCharge"]');
        $hdnSetUpCost = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdn_SetUpCost"]');
        $hdnEstimateCalculationID = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdn_EstimateCalculationID"]');
        $lblMarkupPrice = $('#<%=GridPressCostView.ClientID %>').find('span[id$="lbl_MarkupPrice"]');
        $hdnPressType = $('#<%=GridPressCostView.ClientID %>').find('input:hidden[id$="hdnPressType"]');
        $td_PressCostView_Totalsellingprice = $('span[id$="td_PressCostView_Totalsellingprice"]');
    });

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

