<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderinformation.ascx.cs" Inherits="ePrint.WebStore.usercontrol.orderinformation" %>


<script src="/js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<div id="order_information_checkout">
    <div runat="server" id="divApproverEmail" class="DisplayNone">
        <table>
            <tr>
                <td colspan="2">
                    <div id="div_lblDesigApprover">
                        <asp:Label ID="lblDesigApprover" runat="server" Text="Your order requires approval.Please enter approver's email address as designated by your company"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="Order_details_left">
                        <asp:Label ID="lblApprover" runat="server" Text="Approver Email"></asp:Label>&nbsp;
                        <label id="Label5" class="mandatoryField">
                            *</label>
                    </div>
                </td>
                <td>
                    <div class="Order_details_right">
                        <div class="floatLeft ApprovalTable_Td5">
                            <asp:TextBox ID="txtDesigApprover" runat="server" class="TextBoxWidth_OrderInfo"></asp:TextBox>
                        </div>
                        <div class="floatLeft paddingLeft5">
                            <span id="reqemail" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Approver_Email")%></span>
                            <span id="RegularExpressionValidator1" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Email_Address_Example")%></span> <span id="reqapproveremailcontains"
                                    class="mandatoryField DisplayNone paddingTop5"></span>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr id="tr_OrderInfoHeader" runat="server">
                <td colspan="2" class="CheckOutHeader">
                    <asp:Label ID="lblOrderInfoHeader" runat="server">
                    </asp:Label>
                </td>
            </tr>
            <tr id="tr_orderTitle" runat="server">
                <td class="Td25">
                    <div class="Order_details_left">
                        <asp:Label ID="lbl_orderTitle" runat="server"></asp:Label>&nbsp;
                        <label id="OrderTitle_Mandatory" runat="server" class="mandatoryField">
                            *</label>
                    </div>
                </td>
                <td class="Td75">
                    <div class="Order_details_right">
                        <div class="floatLeft ApprovalTable_Td5">
                            <asp:Panel DefaultButton="btn_orderInfo" ID="Panel2" runat="server">
                                <asp:TextBox ID="txt_orderTitle" runat="server" class="TextBoxWidth_OrderInfo"></asp:TextBox>
                                <asp:Label ID="lblOrdTitle_Helptext" runat="server" CssClass="lblExampleNoteValue"></asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="floatLeft paddingLeft5">
                            <span id="spn_orderTitle" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Order_Title")%></span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr id="tr_OrderNumber" runat="server">
                <td class="Td25">
                    <div class="Order_details_left">
                        <asp:Label ID="Label31" runat="server"></asp:Label>&nbsp;
                        <label id="OrderNumber_Mandatory" runat="server" class="mandatoryField">
                            *</label>
                    </div>
                </td>
                <td class="Td75">
                    <div class="Order_details_right">
                        <div class="floatLeft ApprovalTable_Td5">
                            <asp:Panel DefaultButton="btn_orderInfo" ID="Panel1" runat="server">
                                <asp:TextBox ID="txt_orderNumber" runat="server" class="TextBoxWidth_OrderInfo"></asp:TextBox>
                                <asp:Label ID="lblOrdNo_Helptext" runat="server" CssClass="lblExampleNoteValue"></asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="floatLeft paddingLeft5">
                            <span id="spn_orderNumber" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Order_Number")%></span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr id="tr_DeliveryRequiredBy" runat="server">
                <td class="Td25">
                    <div class="PaymentMode_details_left">
                        <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;
                        <label id="DeliveryRequiredBy_Mandatory" runat="server" class="mandatoryField">
                            *</label>
                    </div>
                </td>
                <td class="Td75">
                    <div class="PaymentMode_details_right">
                        <div class="floatLeft ApprovalTable_Td5">
                            <asp:Panel DefaultButton="btn_orderInfo" ID="Panel3" runat="server">
                                <asp:TextBox ID="txtRequiredBy" runat="server" class="TextBoxWidth_OrderInfo"></asp:TextBox>
                                <asp:Label ID="lblReqBy_Helptext" runat="server" CssClass="lblExampleNoteValue"></asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="floatLeft paddingLeft5">
                            <span id="spn_txtRequiredBy" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Please_enter_the_valid_date")%></span>
                        </div>
                        <div class="floatLeft paddingLeft5">
                            <span id="spn_DeliveryRequiredBy" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Delivery_Required_By")%></span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr runat="server" id="tdCostCentre">
                <td class="Td25">
                    <div class="PaymentMode_details_left">
                        <%--<asp:Label ID="Label2" runat="server" Text="Cost Centre"><%=objLanguage.GetLanguageConversion("CostCentre")%></asp:Label>&nbsp;--%>
                        <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp;
                        <label id="CostCenter_Mandatory" runat="server" class="mandatoryField">
                            *</label>
                    </div>
                </td>
                <td class="Td75">
                    <div class="PaymentMode_details_right">
                        <div class="floatLeft">
                            <asp:DropDownList ID="ddlCostCenter" CssClass="ddlCostCentertext" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="floatLeft paddingLeft5">
                            <span id="Span_Costcenter" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Please_select_a_cost_centre")%></span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr id="tr_Comments" runat="server">
                <td class="Td25">
                    <div class="PaymentMode_details_left">
                        <asp:Label ID="Label23" runat="server"></asp:Label>&nbsp;
                        <label id="Comments_Mandatory" runat="server" class="mandatoryField">
                            *</label>
                    </div>
                </td>
                <td class="Td75">
                    <div class="PaymentMode_details_right">
                        <asp:TextBox ID="txtComments" runat="server" CssClass="MulilineText_Comment" TextMode="MultiLine"></asp:TextBox>
                        <div class="floatLeft paddingLeft5">
                            <span id="spn_Comments" class="mandatoryField DisplayNone paddingTop5">
                                <%=objLanguage.GetLanguageConversion("Please_Enter_Comments")%></span>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td class="Td25">
                </td>
                <td class="Td75">
                    <div class="clearTop clearBottom">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div id="div_btnsave" class="DisplayNone">
                                    <asp:Button ID="btn_orderInfo" runat="server" Text="Continue" class="x-btnpro Grey main">
                                    </asp:Button>
                                </div>
                                <div class="floatLeft" style="display: none;">
                                    <asp:Label ID="Label33" runat="server" Text="" CssClass="mandatoryField">* <%=objLanguage.GetLanguageConversion("Required_Fields")%></asp:Label>
                                </div>
                                <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <div class="clearBoth">
    </div>
    <div class="clearBoth">
    </div>
    <div class="clearBoth">
    </div>
    <div class="clearBoth">
    </div>
</div>
