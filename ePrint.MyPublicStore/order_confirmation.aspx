<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_confirmation.aspx.cs" Inherits="ePrint.MyPublicStore.order_confirmation" masterpagefile="~/templates/MasterPageDefault.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="OrderConfirmMain_div" class="contentArea_Background">
        <div id="OrderConfirm_background">
            <div id="OrderConfirmContent_div">
                <div id="heading" class="Header_Background">
                    <strong>
                        <%=objLanguage.GetLanguageConversion("Order_Confirmation") %>
                    </strong>
                </div>
                <div class="clearBoth">
                </div>
                <div id="messageboxorderconfirmation" class="orderconfirmation" runat="server" style="display: none;">
                    <div>
                        <%=objLanguage.GetLanguageConversion("Thank_you_for_your_order_and_your_order_number_is")%>
                        <a href="javascript:void(0);" onclick="Onclick_OrderNo();" class="anchorColor"><b><span
                            id="spn_OrderNo" runat="server"></span></b></a>
                    </div>
                    <div>
                        <asp:Label ID="lblBackOrder" runat="server" Text="Please note this order has gone to Back Order"
                            CssClass="displayNone"><%=objLanguage.GetLanguageConversion("Please_note_this_order_has_gone_to_Back_Order")%></asp:Label>
                        <asp:Label ID="lblBackOrder1" runat="server" Text="Please note this order has gone to back order"
                            CssClass="displayNone"></asp:Label>
                    </div>
                    <div>
                        <a href="javascript:void(0);" onclick="redirectTo();" class="anchorColor">
                            <%=objLanguage.GetLanguageConversion("Please_Click_Here_To_Continue")%></a><span
                                id="spnLogout" runat="server">
                                <%=objLanguage.GetLanguageConversion("or") %>
                                <a runat="server" onserverclick="onclick_logout" href="#" class="anchorColor">
                                    logout</a></span>
                    </div>
                </div>
                <div id="divOrderConfirmationValue" class="Msgorderconfirmation" runat="server" style="display: none;">
                    <asp:Label ID="lblOrderConfirmationValue" runat="server"></asp:Label>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        var OrderKey = '<%=OrderKey %>';
        function Onclick_OrderNo() {
            if (Rewritemodule.toLowerCase() == "on") {
                window.location = strSitepath + "order" + KeySeparator + OrderKey + FileExtension;
            }
            else {
                window.location = strSitepath + "order.aspx?OrdKey=" + OrderKey + "";
            }
        }
        function redirectTo() {
            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = strSitepath + "products" + KeySeparator + 0 + FileExtension;
            }
            else {
                window.location = strSitepath + "products/product.aspx?ID=0";
            }
        }
    </script>
</asp:Content>
