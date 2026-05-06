<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="paper_costview.ascx.cs" Inherits="ePrint.usercontrol.Item.paper_costview" %>

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
                                <asp:Label ID="lblCostViewTitle" runat="server"><%=objLanguage.GetLanguageConversion("Paper_Cost_View")%></asp:Label>
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
                <table id="tblPaperHeading" width="100%" cellpadding="1" cellspacing="1" border="0"
                    runat="server">
                    <tr id="trHeading1">
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <asp:Label ID="paperlabel" class='normaltext' runat="server"></asp:Label></strong>
                        </td>
                        <td class="normaltext" style="width: 300px;">
                            <asp:Label ID="lblPaperName" class='normaltext' runat="server" Text="Paper Name"></asp:Label>
                        </td>
                        <%--<td style="width: 150px;">
                            &nbsp;
                        </td>--%>
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Inventory_Code")%></strong>
                        </td>
                        <td class="normaltext" style="width: 300px;">
                            <asp:Label ID="lblInventoryCode" class='normaltext' runat="server" Text="Inventory code"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHeading2" visible="false">
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Paper_Supplied")%></strong>
                        </td>
                        <td class="normaltext" style="width: 300px;">
                            <asp:Label ID="lblPaperSupplied" class='normaltext' runat="server" Text="Yes"></asp:Label>
                        </td>
                        <%--  <td style="width: 150px;">
                            &nbsp;
                        </td>--%>
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Supplier_Name")%></strong>
                        </td>
                        <td style="width: 300px;">
                            <asp:Label ID="lblSupplierName1" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHeading3" visible="false">
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Price_For_Whole_Pack")%></strong>
                        </td>
                        <td class='normaltext' style="width: 300px;">
                            <asp:Label ID="lblPriceforWholePack" class='normaltext' runat="server" Text="Yes"></asp:Label>
                        </td>
                        <%--   <td>
                            &nbsp;
                        </td>--%>
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Supplier_Name")%></strong>
                        </td>
                        <td style="width: 300px;">
                            <asp:Label ID="lblSupplierName2" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHeading5" runat="server">
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Supplier_Name")%></strong>
                        </td>
                        <td class="normaltext" style="width: 300px;">
                            <asp:Label ID="lblSupplierName3" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHeading6" runat="server">
                        <td class="bglabel" style="width: 150px;">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Description")%></strong>
                        </td>
                        <td class="normaltext" style="width: 300px;">
                            <asp:Label ID="lblDescription" class='normaltext' runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class='only10px'>
            </div>
            <%-- <div align="left" style="width: 100%;">--%>
            <table width="100%">
                <tr>
                    <td>
                        <telerik:RadGrid ID="GridPaperCostView" AutoGenerateColumns="false" runat="server"
                            PageSize="50" Width="100%" HeaderStyle-Font-Bold="true" CssClass="RadGrid_Eprint_Skin"
                            OnItemDataBound="GridPaperCostView_OnItemDataBound">
                            <MasterTableView>
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Quantity" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_qty" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label><%--0--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Inventory Sheets" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_InventorySheets" runat="server" Text='<%#Eval("InventorySheets")%>'></asp:Label><%--1--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <%-- start --%>

                                    <telerik:GridTemplateColumn HeaderText="Actual Inventory Sheets" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="PrintSheets"
                                        Visible="false" ItemStyle-Width="20%" HeaderStyle-Width="20%">
                                        <%--2--%>
                                        <ItemTemplate>                                           
                                            <asp:TextBox ID="txtPrintSheets" runat="server" Width="75px" Text='<%#Eval("PrintSheets")%>'
                                                Style="text-align: right;"></asp:TextBox> 
                                            <%--<asp:TextBox ID="txtPrintSheets" runat="server" Width="75px" Text='0.00'
                                                Style="text-align: right;"></asp:TextBox> --%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <%-- end --%>

                                    <telerik:GridTemplateColumn HeaderText="Packed in" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Packedin" runat="server" Text='<%#Eval("Packedin")%>'></asp:Label><%--2--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Pack Price" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PackedPrice" runat="server" Text='<%#Eval("PackedPrice")%>'></asp:Label><%--3--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Paper Length(Meter)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_PaperLength" runat="server" Text='<%#Eval("PaperLength")%>'></asp:Label><%--4--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Unit Price($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="UnitPrice"
                                        Visible="false" ItemStyle-Width="20%" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <%--5--%>
                                            <asp:TextBox ID="txt_UnitPrice" runat="server" Width="75px" Text='<%#Eval("UnitPrice")%>'
                                                Style="text-align: right;"></asp:TextBox>
                                            <img id="img_LockUnlock" class="imgLockUnock" src="" runat="server" />
                                            <asp:Label ID="lbl_UnitPrice" runat="server" Text='<%#Eval("UnitPrice")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Mark up(%)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Markup" Style="text-align: right;" runat="server" Width="75px"
                                                Text='<%#Eval("Markup")%>'></asp:TextBox><%--6--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="MarkupPrice" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" Visible="false" UniqueName="MarkupPrice">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_MarkupPrice" runat="server" Text='<%#Eval("MarkupPrice")%>'></asp:Label><%--7--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Selling Price($)" HeaderStyle-HorizontalAlign="Right"
                                        ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Right" UniqueName="SellingPrice"
                                        Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_SellingPrice" runat="server" Text='<%#Eval("SellingPrice")%>'></asp:Label><%--8--%>
                                            <asp:HiddenField ID="hdn_SellingPrice" runat="server" Value='<%#Eval("SellingPrice")%>' />
                                            <asp:HiddenField ID="hdn_MarkupPrice" runat="server" Value='<%#Eval("MarkupPrice")%>' />
                                            <asp:HiddenField ID="hdn_CostExMarkup" runat="server" Value='<%#Eval("CostExMarkup")%>' />
                                            <asp:HiddenField ID="hdn_paperUnitPrice" runat="server" Value='<%#Eval("UnitPrice")%>' />
                                            <asp:HiddenField ID="hdn_EstimateCalculationID" runat="server" Value='<%#Eval("EstimateCalculationID")%>' />
                                            <asp:HiddenField ID="hdn_QuantityID" runat="server" Value='<%#Eval("QuantityID")%>' />
                                            <asp:HiddenField ID="hdn_IsPaperUnitPriceLocked" runat="server" Value='<%#Eval("IsPaperUnitPriceLocked")%>' />
                                            <asp:HiddenField ID="hdn_paperLength" runat="server" Value='<%#Eval("PaperLength")%>' />
                                            <asp:HiddenField ID="hdn_InventorySheets" runat="server" Value='<%#Eval("InventorySheets")%>' />
                                            <asp:HiddenField ID="hdn_packedIn" runat="server" Value='<%#Eval("Packedin")%>' />
                                            <asp:HiddenField ID="hdn_NoOfPacks" runat="server" Value='0' />
                                            <asp:HiddenField ID="hdnQtyNumber" runat="server" Value='<%#Eval("QtyNumber")%>' />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <%-- <ClientSettings EnableRowHoverStyle="true">
                        <Selecting EnableDragToSelectRows="false" />
                    </ClientSettings>--%>
                        </telerik:RadGrid>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <br />
                        <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" OnClick="btnSave_Click" />
                        <asp:HiddenField ID="hdn_isLock" runat="server" Value="" />
                        <asp:HiddenField ID="hdn_CalcType" runat="server" Value="" />
                        <asp:HiddenField ID="hdn_invshet" runat="server" Value="" />
                    </td>
                </tr>
            </table>
            <%--   </div>--%>
        </div>
    </div>
</div>
<script type="text/javascript">
    var CompanyID = '<%=CompanyID%>';
    var UserID = '<%=UserID%>';
    var hdn_isLock = document.getElementById("<%=hdn_isLock.ClientID %>");
    var hdn_CalcType = document.getElementById("<%=hdn_CalcType.ClientID %>");
    var hdn_invshet = document.getElementById("<%=hdn_invshet.ClientID %>");


    //    function calculateSellingprice_onBlur(Obj, paperType) {
    //        var hdn_paperUnitPrice = document.getElementById(Obj.id.replace('txt_UnitPrice', 'hdn_paperUnitPrice'))
    //        var PaperUnitPrice = document.getElementById(Obj.id).value;
    //        hdn_paperUnitPrice.value = PaperUnitPrice;
    //        var lbl_SellingPrice = document.getElementById(Obj.id.replace('txt_UnitPrice', 'lbl_SellingPrice'));
    //        var txt_Markup = document.getElementById(Obj.id.replace('txt_UnitPrice', 'txt_Markup'));
    //        var hdn_CostExMarkup = document.getElementById(Obj.id.replace('txt_UnitPrice', 'hdn_CostExMarkup'));
    //        var hdn_MarkupPrice = document.getElementById(Obj.id.replace('txt_UnitPrice', 'hdn_MarkupPrice'));
    //        var InvSheets = "";
    //        if (paperType == "roll" || paperType == "web printing") {
    //            var hdn_paperLength = document.getElementById(Obj.id.replace('txt_UnitPrice', 'hdn_paperLength'));
    //            InvSheets = hdn_paperLength.value;
    //        }
    //        else {
    //            var lbl_InventorySheets = document.getElementById(Obj.id.replace('txt_UnitPrice', 'lbl_InventorySheets'));
    //            InvSheets = lbl_InventorySheets.innerHTML;
    //        }
    //        hdn_CostExMarkup.value = Number(InvSheets) * Number(PaperUnitPrice);
    //        hdn_MarkupPrice.value = (Number(hdn_CostExMarkup.value) * Number(txt_Markup.value)) / 100;
    //        var finalValue = Number(hdn_CostExMarkup.value) + Number(hdn_MarkupPrice.value);
    //        lbl_SellingPrice.innerHTML = Eprint_ReturnFinal_Formated_Amount(CompanyID, UserID, finalValue, 0, '', false, false, true);
    //    }


    //    function onLockTimeout(request, context) {

    //    }
    //    function onLockError(objError) {

    //    }
    //for web service

    //    function onLockResponse(response) {
    //        
    //    }
    

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

