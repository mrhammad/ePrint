<%@ page title="Checkout" language="C#" masterpagefile="~/Templates/MasterPageDefault.master" autoeventwireup="true"  CodeBehind="checkout.aspx.cs" Inherits="ePrint.WebStore.checkout" enableEventValidation="false" viewStateEncryptionMode="Never" %>


<%@ Register Src="~/usercontrol/orderinformation.ascx" TagName="OrderInfo" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/invoice_del_Info.ascx" TagName="AddressInfo" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=strSitepath %>js/tab.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/checkout.js?VN='<%=VersionNumber%>'"></script>
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/Slide/jsPopup.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/Js_Wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript">
        var StoreUserID = '<%=StoreUserID %>';
        var strSitepath = '<%=strSitepath %>';
        var currentdate = '<%=newdate%>';
        var DateFormat = '<%=DateFormat%>';
        var IsEnable = '<%=IsEnable %>';
        var PaymentStep = '<%=PaymentStep %>';
        var ApprovalType = '<%=ApprovalType%>';
        var approverEmailcontains = '<%=approverEmailcontains%>';
        var approverEmailcontains_Validation = '<%=objLanguage.GetLanguageConversion("Approver_Email_Should_End_With")%>' + approverEmailcontains;

        var isCheckDeliveryInfo = '<%=isCheckDeliveryInfo %>';
        var isCheckInvoiceInfo = '<%=isCheckInvoiceInfo %>';
        var is_DeliveryAddress_Mandatory = '<%=is_DeliveryAddress_Mandatory %>';
        var is_InvoiceAddress_Mandatory = '<%=is_InvoiceAddress_Mandatory %>';
    </script>
    <div id="overlay" class="web_dialog_overlay_Address">
    </div>
    <div align="center" id="checkOutMain_div">
        <div align="center" id="checkOut_contentArea">
            <div align="center" id="div_EmptyCart" runat="server">
                <div id="emptyCart_background">
                    <div id="emptyCart">
                        <div id="emptyCart_heading" class="Header_Background">
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Shopping_cart_is_empty")%></strong>
                        </div>
                        <div id="emptyCart_content">
                            <p>
                                <%=objLanguage.GetLanguageConversion("You_have_no_items_in_your_shopping_cart")%></p>
                            <p>
                                <%=objLanguage.GetLanguageConversion("Click")%>
                                <a href="javascript:void(0);" onclick="redirectTo();" class="anchorColor">
                                    <%=objLanguage.GetLanguageConversion("Here")%></a>
                                <%=objLanguage.GetLanguageConversion("to_continue_shopping")%></p>
                        </div>
                    </div>
                </div>
            </div>
            <div id="div_CartContentArea" runat="server">
                <div id="heading" class="center_div_header Header_Background">
                    <strong class="floatLeft">
                        <%=objLanguage.GetLanguageConversion("Checkout")%>
                    </strong>
                </div>
                <div id="div_CartMainContentArea">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="width100p">
                        <tr>
                            <td class="width100p">
                                <div id="wizard" class="swMain">
                                    <ul>
                                        <li id="li3" runat="server"><a href="#step-3" class="CheckOut_HeadingRoundedCorner">
                                            <label runat="server" id="lblStep3" class="stepNumber">
                                                1</label>
                                            <span class="stepDesc"><small>
                                                <%=objLanguage.GetLanguageConversion("Order_Information")%></small> </span></a>
                                        </li>
                                        <li><a href="#step-4" class="CheckOut_HeadingRoundedCorner">
                                            <label runat="server" id="lblStep4" class="stepNumber">
                                                2</label>
                                            <span class="stepDesc"><small>
                                                <%=objLanguage.GetLanguageConversion("Address_Information")%></small> </span>
                                        </a></li>
                                        <li><a href="#step-5" class="CheckOut_HeadingRoundedCorner">
                                            <label runat="server" id="lblStep5" class="stepNumber">
                                                3</label>
                                            <span class="stepDesc"><small>
                                                <%=objLanguage.GetLanguageConversion("Order_Confirmation")%></small> </span>
                                        </a></li>
                                        <li id="li_payment" runat="server"><a href="#step-6" class="CheckOut_HeadingRoundedCorner">
                                            <label runat="server" id="lblStep6" class="stepNumber">
                                                4</label>
                                            <span class="stepDesc"><small>
                                                <%=objLanguage.GetLanguageConversion("Payment_Information")%></small> </span>
                                        </a></li>
                                        <li id="li1" runat="server"><a href="#step-6"></a></li>
                                    </ul>
                                    <div id="step-3" class="ucBackGround">
                                        <UC:OrderInfo ID="ucOrderInfo" runat="server" />
                                    </div>
                                    <div id="step-4" class="ucBackGround">
                                        <UC:AddressInfo ID="ucAddressInfo" runat="server" />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <table class="DisplayNone">
                    <tr>
                        <td valign="top">
                            <div id="checkOutMethod">
                                <div id="Order_content" class="DisplayBlock width100p">
                                    <div id="OrderHeader">
                                        &nbsp; <b>
                                            <%=objLanguage.GetLanguageConversion("Order_Information")%></b>
                                    </div>
                                    <div id="OrderArea" class="DisplayBlock width100p">
                                    </div>
                                </div>
                                <div id="Billing_content" class="DisplayBlock width100p">
                                    <div id="BillingHeader">
                                        &nbsp; <b>
                                            <%=objLanguage.GetLanguageConversion("Invocie_Information")%></b>
                                    </div>
                                    <div id="BillingArea" class="DisplayNone width100p">
                                        <div>
                                        </div>
                                        <br />
                                        <hr />
                                        <div id="BillingArea_bottom" class="width100p">
                                            <div id="BillingArea_back" class="left DisplayBlock floatLeft">
                                                <div id="div_backBilling" class="left">
                                                    <a href="javascript:void(0);" onclick="javascript:return back_BillingValidate();"
                                                        class="anchorColor">
                                                        <%=objLanguage.GetLanguageConversion("Back")%></a>
                                                </div>
                                            </div>
                                            <div class="right floatLeft">
                                                <br />
                                                <div>
                                                    <asp:UpdatePanel ID="updatebillingAddress" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_billingAddress" runat="server" Text="Continue" ValidationGroup="billingInfo"
                                                                class="x-btnpro Grey main" OnClick="OnClick_lnkBtnBillingAddress" OnClientClick="javascript:return executeWithDialog();"></asp:Button><%--OnClientClick="javascript:return BillingValidate();"--%>
                                                            <asp:Button ID="btn_BackShop" runat="server" Text="" CssClass="DisplayNone" CausesValidation="false"
                                                                OnClick="OnClick_btn_BackShop"></asp:Button>
                                                            <div id="div_loadingBilling" class="DisplayNone">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageHandler.ashx?Imagename=loadingGraphic.gif&amp;type=r&amp;aid='<%=AccountID %>'&amp;cid='<%=CompanyID %>'"
                                                                    AlternateText="Loading" />
                                                            </div>
                                                            <asp:LinkButton ID="lnkBtnBillingAddress" runat="server" OnClick="OnClick_lnkBtnBillingAddress"></asp:LinkButton>
                                                            <asp:HiddenField ID="hdn_OrderID" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdn_BillingAddressID" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdn_ClientID" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdn_NewBillingAddressID" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hdnservername" runat="server" />
                                                            <asp:HiddenField ID="hdnaccountid" runat="server" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <div class="floatLeft">
                                                    <asp:Label ID="lbl_billingRF" runat="server" Text="* Required Fields" CssClass="ColorRed"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearBoth">
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hid_address" runat="server" Value="" />
    <asp:HiddenField ID="hid_billingaddress" runat="server" Value="no" />
    <asp:HiddenField ID="hid_Shippingaddress" runat="server" Value="no" />
    <asp:HiddenField ID="hdnCountryID" runat="server" Value='0' />
    <asp:HiddenField ID="hdnBillAdd1" runat="server" Value="" />
    <asp:HiddenField ID="hdnBillAdd2" runat="server" Value="" />
    <asp:HiddenField ID="hdnBillAdd3" runat="server" Value="" />
    <asp:HiddenField ID="hdnBillAdd4" runat="server" Value="" />
    <asp:HiddenField ID="hdnBillAdd5" runat="server" Value="" />
    <asp:HiddenField ID="hdnBilltelephone" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd1" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd2" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd3" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd4" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd5" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldCountryID" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldTel" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldPhone" runat="server" Value="" />
    <asp:HiddenField ID="hdn_isOrderInformationAccessible" runat="server" Value="" />
    <script type="text/javascript">
        $(document).ready(function () {
            if (location.search != null && location.search != "") {
                if (location.search.toLowerCase().indexOf('campid') == -1) {
                    $('#wizard').smartWizard({
                        selected: 1,  // Selected Step, 0 = first step
                        keyNavigation: true, // Enable/Disable key navigation(left and right keys are used if enabled)
                        enableAllSteps: false,
                        transitionEffect: 'fade', // Effect on navigation, none/fade/slide/slideleft
                        contentURL: null, // content url, Enables Ajax content loading
                        contentCache: true, // cache step contents, if false content is fetched always from ajax url
                        cycleSteps: false, // cycle step navigation
                        enableFinishButton: false, // make finish button enabled always
                        hideButtonsOnDisabled: true, // when the previous/next/finish buttons are disabled, hide them instead?
                        errorSteps: [],    // Array Steps with errors
                        labelNext: 'Continue', //Next
                        labelPrevious: 'Back', //Previous
                        labelFinish: 'Continue', //Finish
                        noForwardJumping: false,
                        onLeaveStep: null, // triggers when leaving a step
                        onShowStep: null,  // triggers when showing a step
                        onFinish: null  // triggers when Finish button is clicked
                    });


                    $('#wizard').smartWizard('enableStep', '1');
                    $('#wizard').smartWizard('enableStep', '3');

                    //$('#wizard').smartWizard('disableStep', '1');

                    if (PaymentStep == "true") {
                        $('#wizard').smartWizard('enableStep', '4');
                    }
                    else {
                        $('#wizard').smartWizard('disableStep', '4');
                    }

                }
                else {

                    $('#wizard').smartWizard({
                        selected: 0,  // Selected Step, 0 = first step
                        keyNavigation: true, // Enable/Disable key navigation(left and right keys are used if enabled)
                        enableAllSteps: false,
                        transitionEffect: 'fade', // Effect on navigation, none/fade/slide/slideleft
                        contentURL: null, // content url, Enables Ajax content loading
                        contentCache: true, // cache step contents, if false content is fetched always from ajax url
                        cycleSteps: false, // cycle step navigation
                        enableFinishButton: false, // make finish button enabled always
                        hideButtonsOnDisabled: true, // when the previous/next/finish buttons are disabled, hide them instead?
                        errorSteps: [],    // Array Steps with errors
                        labelNext: 'Continue', //Next
                        labelPrevious: 'Back', //Previous
                        labelFinish: 'Continue', //Finish
                        noForwardJumping: false,
                        onLeaveStep: null, // triggers when leaving a step
                        onShowStep: null,  // triggers when showing a step
                        onFinish: null  // triggers when Finish button is clicked
                    });


                    function onFinishCallback() {
                        $('#wizard').smartWizard('showMessage', 'Finish Clicked');
                    }
                }
            }
            else {
                var selectedval = 0
                var val = parseInt(document.getElementById('ctl00_ContentPlaceHolder1_hdn_isOrderInformationAccessible').value);
                if (val == 0)
                    selectedval = 1;
                else
                    selectedval = 0;
                $('#wizard').smartWizard({
                    //selected: 0,  // Selected Step, 0 = first step
                    selected: selectedval,
                    keyNavigation: true, // Enable/Disable key navigation(left and right keys are used if enabled)
                    enableAllSteps: false,
                    transitionEffect: 'fade', // Effect on navigation, none/fade/slide/slideleft
                    contentURL: null, // content url, Enables Ajax content loading
                    contentCache: true, // cache step contents, if false content is fetched always from ajax url
                    cycleSteps: false, // cycle step navigation
                    enableFinishButton: false, // make finish button enabled always
                    hideButtonsOnDisabled: true, // when the previous/next/finish buttons are disabled, hide them instead?
                    errorSteps: [],    // Array Steps with errors
                    labelNext: 'Continue', //Next
                    labelPrevious: 'Back', //Previous
                    labelFinish: 'Continue', //Finish
                    noForwardJumping: false,
                    onLeaveStep: null, // triggers when leaving a step
                    onShowStep: null,  // triggers when showing a step
                    onFinish: null  // triggers when Finish button is clicked
                });
                
                //$('#wizard').smartWizard('disableStep', '1');
                function onFinishCallback() {
                    $('#wizard').smartWizard('showMessage', 'Finish Clicked');
                }
            }

            document.getElementById("wizard").style.visibility = "visible";
        });
                            
    </script>
    <script type="text/javascript" language="javascript">

        var ModeOfPayments = '<%=ModeOfPayments %>';
        var CompanyID = '<%=CompanyID %>';
        var AccountID = '<%=AccountID %>';
        var cartCount = '<%=cartCount %>';
        var Rewritemodule = '<%=Rewritemodule %>';
        var paymentFlag = '<%=paymentFlag %>';
        var IsSessionCheckOut = '<%=IsSessionCheckOut %>';
        var isGuest = '<%=isGuest %>';
        var isLoginInfo = '<%=isLoginInfo %>';
        var isOrderInfo = '<%=isOrderInfo %>';
        var isInvoiceInfo = '<%=isInvoiceInfo %>';
        var isDeliveryInfo = '<%=isDeliveryInfo %>';
        var isPaymentInfo = '<%=isPaymentInfo %>';

        var hdnBillAdd1 = document.getElementById("<%=hdnBillAdd1.ClientID %>");
        var hdnBillAdd2 = document.getElementById("<%=hdnBillAdd2.ClientID %>");
        var hdnBillAdd3 = document.getElementById("<%=hdnBillAdd3.ClientID %>");
        var hdnBillAdd4 = document.getElementById("<%=hdnBillAdd4.ClientID %>");
        var hdnBillAdd5 = document.getElementById("<%=hdnBillAdd5.ClientID %>");
        var hdnBilltelephone = document.getElementById("<%=hdnBilltelephone.ClientID %>");

        var txt_orderTitle = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txt_orderTitle");
        var txtRequiredBy = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txtRequiredBy");
        var txt_orderNumber = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txt_orderNumber");
        var txtComments = document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txtComments");
        var OrderArea = document.getElementById("OrderArea");
        var BillingArea = document.getElementById("BillingArea");

        var txt_address_billing1 = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing1");
        var txt_address_billing2 = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing2");
        var txt_city_billing = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing3");
        var txt_state_billing = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing4");
        var ddl_country_billing = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_ddlCountry");
        var txt_zipCode_billing = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_txt_address_billing5");
        var spn_address_billing1 = document.getElementById("spn_address_billing1");
        var spn_address_billing2 = document.getElementById("spn_address_billing2");
        var spn_city_billing = document.getElementById("spn_address_billing3");
        var spn_state_billing = document.getElementById("spn_address_billing4");
        var spn_zipCode_billing = document.getElementById("spn_address_billing5");
        var spn_country_billing = document.getElementById("spn_country_billing");

        function Setting_focus_Checkout() {
            document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txt_orderTitle").focus();
        }
        function showEdit(id) {
            id.style.display = "block";
            id.style.paddingTop = "0px";
        }
    </script>
</asp:Content>
