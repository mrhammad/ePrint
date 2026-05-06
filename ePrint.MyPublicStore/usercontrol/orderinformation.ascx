<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="orderinformation.ascx.cs" Inherits="ePrint.MyPublicStore.usercontrol.orderinformation" %>
<script src="/js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<div id="chkout_orderinfo_MainDiv">
    <table>
        <tr id="tr_OrderInfoHeader" runat="server">
            <td colspan="2" class="CheckOutHeader">
                <asp:Label ID="lblOrderInfoHeader" runat="server">
                </asp:Label>
            </td>
        </tr>
        <tr id="tr_orderTitle" runat="server">
            <td class="orderinfo_LeftDiv">
                <div class="Order_details_left">
                    <asp:Label ID="lbl_orderTitle" runat="server"></asp:Label>&nbsp;
                    <label id="OrderTitle_Mandatory" runat="server" class="mandatoryField">
                        *</label>
                </div>
            </td>
            <td class="orderinfo_RightDiv">
                <div class="Order_details_right">
                    <div class="Orderdetails_right_fieldDiv">
                        <asp:TextBox ID="txt_orderTitle" runat="server" class="TextBoxWidth_OrderInfo"></asp:TextBox><%--Style="font-family: Calibri, Helvetica, sans-serif;"--%>
                        &nbsp;
                        <asp:Label ID="Label29" runat="server" Text=" eg: My Stationery Item, My Company Order"
                            CssClass="ExampleMsg"><%=objLanguage.GetLanguageConversion("Order_Title_Example_Note")%></asp:Label>
                    </div>
                    <div class="Orderdetails_right_ValidationDiv">
                        <span id="spn_orderTitle" class="mandatoryField displayNone">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Order_Title") %></span>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr id="tr_OrderNumber" runat="server">
            <td class="orderinfo_LeftDiv">
                <div class="Order_details_left">
                    <asp:Label ID="Label31" runat="server"></asp:Label>&nbsp;
                    <label id="OrderNumber_Mandatory" runat="server" class="mandatoryField">
                        *</label>
                </div>
            </td>
            <td class="orderinfo_RightDiv">
                <div class="Order_details_right">
                    <div class="Orderdetails_right_fieldDiv">
                        <asp:TextBox ID="txt_orderNumber" runat="server" class="TextBoxWidth_OrderInfo"></asp:TextBox>
                    </div>
                    <div class="Orderdetails_right_ValidationDiv">
                        <span id="spn_orderNumber" class="mandatoryField displayNone">
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
            <td class="orderinfo_LeftDiv">
                <div class="PaymentMode_details_left">
                    <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;
                    <label id="DeliveryRequiredBy_Mandatory" runat="server" class="mandatoryField">
                        *</label>
                </div>
            </td>
            <td class="orderinfo_RightDiv">
                <div class="PaymentMode_details_right">
                    <div class="Orderdetails_right_fieldDiv">
                        <asp:TextBox ID="txtRequiredBy" runat="server" class="TextBoxWidth_OrderInfo"></asp:TextBox>
                    </div>
                    <div class="Orderdetails_right_ValidationDiv">
                        <span id="spn_txtRequiredBy" class="mandatoryField displayNone">
                            <%=objLanguage.GetLanguageConversion("Please_enter_the_valid_date")%></span>
                    </div>
                    <div class="Orderdetails_right_ValidationDiv">
                        <span id="spn_DeliveryRequiredBy" class="mandatoryField displayNone">
                            <%=objLanguage.GetLanguageConversion("Please_Enter_Delivery_Required_By")%></span>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr id="tr_Comments" runat="server">
            <td class="orderinfo_LeftDiv">
                <div class="PaymentMode_details_left">
                    <asp:Label ID="Label23" runat="server"></asp:Label>&nbsp;
                    <label id="Comments_Mandatory" runat="server" class="mandatoryField">
                        *</label>
                </div>
            </td>
            <td class="orderinfo_RightDiv">
                <div class="PaymentMode_details_right">
                    <asp:TextBox ID="txtComments" runat="server" CssClass="Chkout_OrderInfo_Comments_TxtBx"
                        TextMode="MultiLine"></asp:TextBox>
                    <div class="Orderdetails_right_ValidationDiv">
                        <span id="spn_Comments" class="mandatoryField displayNone">
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
            <td class="orderinfo_LeftDiv">
            </td>
            <td class="orderinfo_RightDiv">
                <div class="right Chkout_OrderInfo_Btns_OuterDiv">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div id="div_btnsave" class="displayNone">
                                <asp:Button ID="btn_orderInfo" runat="server" Text="Continue" class="x-btnpro Grey main">
                                </asp:Button>
                            </div>
                            <div id="div_btnsaveprocess" class="displayNone">
                                <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                            </div>
                            <div class="floatLeft">
                                <asp:Label ID="Label33" runat="server" Text="* Required Fields" class="mandatoryField">* <%=objLanguage.GetLanguageConversion("Required_Fields")%></asp:Label>
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


