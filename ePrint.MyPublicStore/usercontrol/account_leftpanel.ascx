<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="account_leftpanel.ascx.cs" Inherits="ePrint.MyPublicStore.usercontrol.account_leftpanel" %>




<asp:Panel runat="server" ID="pnlaccount" Visible="true">
    <div id="accountInfoContent_left">
        <div id="heading_accountInfo" class="Header_Background">
            <strong>
                <%=objLanguage.GetLanguageConversion("My_Account") %>
            </strong>
        </div>
        <div id="accountInfoContent_left_content">
            <div class="marginBottom10">
                <div id="href_account" runat="server">
                    <a href="<%=strSitepath %>account/account<%=FileExtension %>" title="My Account DashBoard">
                        <%=objLanguage.GetLanguageConversion("My_Account_DashBoard") %></a><br />
                </div>
                <div id="href_accountedit" runat="server">
                    <a href="<%=strSitepath %>account/accountedit<%=FileExtension %>" title="My Account Information">
                        <%=objLanguage.GetLanguageConversion("Edit_Account_Information") %></a><br />
                </div>
                <div id="href_addressbook" runat="server">
                    <a href="<%=strSitepath %>account/addressbook<%=FileExtension %>" title="My Address Book">
                        <%=objLanguage.GetLanguageConversion("My_Address_book") %></a><br />
                </div>
                <div id="href_myorder" runat="server">
                    <a href="<%=strSitepath %>account/myorder<%=FileExtension %>" title="My Order">
                        <%=objLanguage.GetLanguageConversion("My_orders") %></a><br />
                </div>
            </div>
        </div>
    </div>
    <div class="clearBoth">
    </div>
    <div id="account_myCart_div">
        <div id="account_myCart_Header" class="Header_Background">
            <strong>
                <%=objLanguage.GetLanguageConversion("My_Cart") %>
            </strong>
        </div>
        <div id="account_myCart_content">
            <label id="lbl_myCart_content" runat="server">
            </label>
            <br />
            <label id="lbl_cartPrice" runat="server">
                $ 0.00</label>
            <br />
            <span id="spn_ContinueShopping" runat="server"><a href="#" onclick="Checkout_Onclick('shopping');"
                class="anchorColor" title="Continue Shopping">
                <%=objLanguage.GetLanguageConversion("Shopping") %></a></span><span id="spn_separator"
                    runat="server"> / </span><span id="spn_ContinueCheckout" runat="server"><a href="#"
                        onclick="Checkout_Onclick('checkout');" class="anchorColor" title="Proceed to Checkout">
                        <%=objLanguage.GetLanguageConversion("Checkout") %></a></span>
        </div>
    </div>
    <div class="clearBoth">
    </div>
    <div class="account_leftBanner" id="account_leftBanner" runat="server">
        <asp:PlaceHolder ID="plhLeftBanner" runat="server"></asp:PlaceHolder>
    </div>
    <script type="text/javascript" language="javascript">
        function Checkout_Onclick(page) {
            if (Rewritemodule.toLowerCase() == 'on') {
                if (page.toLowerCase() == "checkout") {
                    window.location = strSitepath + 'checkoutnew' + FileExtension;
                }
                else if (page.toLowerCase() == "shopping") {
                    window.location = strSitepath + "";
                }
            }
            else {
                if (page.toLowerCase() == "checkout") {
                    window.location = strSitepath + "checkoutnew" + FileExtension;
                }
                else if (page.toLowerCase() == "shopping") {
                    window.location = strSitepath + "";
                }
            }
        }
    </script>
</asp:Panel>
