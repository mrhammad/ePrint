<%@ page title="" language="C#" masterpagefile="~/templates/MasterPageDefault.master" autoeventwireup="true" CodeBehind="order_confirmation.aspx.cs" Inherits="ePrint.WebStore.order_confirmation" enableEventValidation="false" viewStateEncryptionMode="Never" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/default.js"></script>
    <script src="js/defaultjs?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div style="display:none;">
        <asp:Literal ID="ltrLanguageConversionScript" Text="text" runat="server" />
        
    </div>
    <div id="div_OrderConfirmMain">
        <div align="center" id="OrderConfirmMain_div">
            <div align="center" id="OrderConfirmMain_Inner_div">
                <div id="OrderConfirm_background">
                    <div id="OrderConfirmContent_div">
                        <div id="heading" class="Header_Background">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Order_Confirmation") %>
                            </strong>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="messageboxorderconfirmation">
                            <div class="clearTop">
                                <%=objLanguage.GetLanguageConversion("Thank_you_for_your_order_and_your_order_number_is")%>
                                <a href="javascript:void(0);" onclick="Onclick_OrderNo();" class="anchorColor"><b><span
                                    id="spn_OrderNo" runat="server"></span></b></a>
                            </div>
                            <div class="paddingTop5">
                                <asp:Label ID="lblBackOrder" runat="server" Text="Please note this order has gone to back order"
                                    CssClass="DisplayNone"><%=objLanguage.GetLanguageConversion("Please_note_this_order_has_gone_to_Back_Order")%></asp:Label>
                                <asp:Label ID="lblBackOrder1" runat="server" Text="Please note some of your ordered has gone to Back Order"
                                    CssClass="DisplayNone"><%=objLanguage.GetLanguageConversion("Please_note_some_of_your_ordered_has_gone_to_Back_Order")%></asp:Label></div>
                            <div class="clearTopBottom">
                                <a href="javascript:void(0);" onclick="redirectTo();" class="anchorColor">
                                    <%=objLanguage.GetLanguageConversion("Please_Click_Here_To_Continue")%></a><span
                                        id="spnLogout" runat="server"> or <a id="A1" runat="server" onserverclick="onclick_logout"
                                            href="#" class="anchorColor">
                                            logout</a></span>
                            </div>
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
        </div>
    </div>
    <script type="text/javascript" language="javascript">
        var OrderKey = '<%=OrderKey %>';      
    </script>
</asp:Content>
