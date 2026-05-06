<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkoutnew.aspx.cs" Inherits="ePrint.MyPublicStore.checkoutnew" masterpagefile="~/templates/MasterPageDefault.master"  %>

<%@ Register Src="~/usercontrol/orderinformation.ascx" TagName="OrderInfo" TagPrefix="UC" %>
<%@ Register Src="~/usercontrol/invoice_del_Info.ascx" TagName="AddressInfo" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>
   

    

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

        var isCheckOrderInfoPublic = '<%=isCheckOrderInfoPublic %>';
        var isCheckAddressInfo = '<%=isCheckAddressInfo %>';
        var isCheckDeliveryInfo = '<%=isCheckDeliveryInfo %>';
        var isCheckInvoiceInfo = '<%=isCheckInvoiceInfo %>';
        var hid_billingaddress = document.getElementById("<%=hid_billingaddress.ClientID %>");
        var hid_address = document.getElementById("<%=hid_address.ClientID %>");

    </script>
    <script type="text/javascript" language="javascript">
        function Add_AddressValidation() {
            var CheckFinal = false;

            if (hdnBillAdd1.value == "1") {

                if (trim(txt_address_billing1.value) == "") {
                    spn_address_billing1.style.display = "block";
                    CheckFinal = true;
                }
                else {
                    spn_address_billing1.style.display = "none";
                }
            }

            if (hdnBillAdd2.value == "1") {

                if (trim(txt_address_billing2.value) == "") {
                    spn_address_billing2.style.display = "block";
                    CheckFinal = true;
                }
                else {
                    spn_address_billing2.style.display = "none";
                }
            }

            if (hdnBillAdd3.value == "1") {

                if (trim(txt_city_billing.value) == "") {
                    spn_city_billing.style.display = "block";
                    CheckFinal = true;
                }
                else {
                    spn_city_billing.style.display = "none";
                }
            }

            if (hdnBillAdd4.value == "1") {
                if (trim(txt_state_billing.value) == "") {
                    spn_state_billing.style.display = "block";
                    CheckFinal = true;
                }
                else {
                    spn_state_billing.style.display = "none";
                }
            }

            if (hdnBillAdd5.value == "1") {

                if (trim(txt_zipCode_billing.value) == "") {
                    spn_zipCode_billing.style.display = "block";
                    CheckFinal = true;
                }
                else {
                    spn_zipCode_billing.style.display = "none";
                }
            }

            if (ddl_country_billing.selectedIndex == 0) {
                spn_country_billing.style.display = "block";
                CheckFinal = true;
                return false;
            }
            else {
                spn_country_billing.style.display = "none";
            }

            if (CheckFinal) {
                return false;
            }
            else {
                return true;
            }
        }
    </script>

     <script type="text/javascript" src="<%=strSitepath %>js/checkoutnew.js?VN='<%=VersionNumber%>'"></script>
    <div id="overlay" class="web_dialog_overlay_Address">
    </div>
    <div id="checkOutMain_div" class="contentArea_Background">
        <div id="div_NavigationID" runat="server" class="navigation_div">
            <a href="<%=strSitepath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <asp:Label ID="lbl_Checkout" runat="server" Text="Checkout"><%=objLanguage.GetLanguageConversion("CheckOut") %></asp:Label>
        </div>
        <div id="checkOut_background">
            <div id="checkOut_contentArea">
                <div id="div_EmptyCart" runat="server" class="displayNone">
                    <div id="emptyCart_background">
                        <div id="emptyCart">
                            <div id="emptyCart_heading" class="Header_Background">
                                <strong>
                                    <%=objLanguage.GetLanguageConversion("Shopping_Cart_is_Empty")%></strong>
                            </div>
                            <div id="emptyCart_content">
                                <br />
                                <p>
                                    <%=objLanguage.GetLanguageConversion("You_have_no_items_in_your_shopping_cart")%></p>
                                <p>
                                    <%=objLanguage.GetLanguageConversion("Click")%>
                                    <a href="javascript:void(0);" onclick="redirectTo();" class="anchorColor">
                                        <%=objLanguage.GetLanguageConversion("here")%></a>
                                    <%=objLanguage.GetLanguageConversion("to_continue_shopping")%></p>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="div_CartContentArea" runat="server" class="chkOut_CartContentArea_div">
                    <div id="heading" class="center_div_header Header_Background">
                        <strong class="floatLeft">Checkout </strong>
                    </div>
                    <div class="chkOut_CartContentArea_innerdiv">
                        <script src="<%#strSitepath%>js/jquery-1.7.min.js" type="text/javascript"></script>
                        <script src="<%#strSitepath%>js/Slide/jsPopup.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
                        <script src="<%#strSitepath%>js/Js_Wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
                        <script src="<%#strSitepath%>js/wizard.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
                        <script type="text/javascript">
                            $(document).ready(function () {

                                if (isCheckOrderInfoPublic == "false" && isCheckAddressInfo == "true" && (location.search == null || location.search == "")) {// When the Order Info is disabled and address info enabled and when the page is loaded from Proceed to checkout.
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
                                }
                                else {
                                    if (isCheckOrderInfoPublic == "true" && isCheckAddressInfo == "false" && location.search != null && location.search != "") {
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

                                        $('#wizard').smartWizard('enableStep', '1');
                                        $('#wizard').smartWizard('enableStep', '3');
                                        if (PaymentStep == "true") {
                                            $('#wizard').smartWizard('enableStep', '4');
                                        }
                                        else {
                                            $('#wizard').smartWizard('disableStep', '4');
                                        }
                                    }
                                    else {
                                        if (location.search != null && location.search != "") {
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
                                }

                                document.getElementById("wizard").style.visibility = "visible";
                            });
                            
                        </script>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" class="width100p">
                            <tr>
                                <td class="width100p">
                                    <div id="wizard" class="swMain">
                                        <ul>
                                            <li id="li_Order" runat="server"><a href="#step-3">
                                                <%--<label class="stepNumber">
                                                    1</label>--%>
                                                <span class="stepDesc"><small>
                                                    <%=objLanguage.GetLanguageConversion("Order_Information") %></small> </span>
                                            </a></li>
                                            <li id="li_Address" runat="server"><a href="#step-4">
                                                <%--<label class="stepNumber">
                                                    2</label>--%>
                                                <span class="stepDesc"><small>
                                                    <%=objLanguage.GetLanguageConversion("Address_Information") %></small> </span>
                                            </a></li>
                                            <li id="li_Confirmation" runat="server"><a href="#step-5">
                                                <%-- <label class="stepNumber">
                                                    3</label>--%>
                                                <span class="stepDesc"><small>
                                                    <%=objLanguage.GetLanguageConversion("Order_Confirmation") %></small> </span>
                                            </a></li>
                                            <li id="li_payment" class="HideArrow" runat="server"><a href="#step-6">
                                                <%--<label class="stepNumber">
                                                    4</label>--%>
                                                <span class="stepDesc"><small>
                                                    <%=objLanguage.GetLanguageConversion("Payment_Information") %></small> </span>
                                            </a></li>
                                            <li id="li1" runat="server" style="display: none"><a href="#step-6"></a></li>
                                        </ul>
                                        <div id="step-3" class="chkout_UC_OuterDiv">
                                            <UC:OrderInfo ID="ucOrderInfo" runat="server" />
                                        </div>
                                        <div id="step-4" class="chkout_UC_OuterDiv">
                                            <UC:AddressInfo ID="ucAddressInfo" runat="server" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table class="displayNone">
                        <tr>
                            <td>
                                <div id="checkOutMethod">
                                    <%-- Order Information --%>
                                    <div id="Order_content">
                                        <div id="OrderHeader">
                                            &nbsp; <b>
                                                <%=objLanguage.GetLanguageConversion("Order_Information") %></b>
                                        </div>
                                        <div id="OrderArea">
                                            <%--<UC:OrderInfo ID="ucOrderInfo" runat="server" />--%>
                                        </div>
                                    </div>
                                    <%-- Billing Information (Invoice Information) --%>
                                    <div id="Billing_content">
                                        <div id="BillingHeader">
                                            &nbsp; <b>
                                                <%=objLanguage.GetLanguageConversion("Invoice_Information") %></b>
                                        </div>
                                        <div id="BillingArea">
                                            <div>
                                                <%--<UC:AddressInfo ID="ucAddressInfo" runat="server" />--%>
                                            </div>
                                            <br />
                                            <hr />
                                            <div id="BillingArea_bottom">
                                                <div id="BillingArea_back" class="left">
                                                    <div id="div_backBilling" class="left">
                                                        <a href="javascript:void(0);" onclick="javascript:return back_BillingValidate();"
                                                            class="anchorColor">
                                                            <%=objLanguage.GetLanguageConversion("Back") %></a>
                                                    </div>
                                                </div>
                                                <div class="right">
                                                    <br />
                                                    <div>
                                                        <asp:UpdatePanel ID="updatebillingAddress" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Button ID="btn_billingAddress" runat="server" Style="padding-left: 30px;" Text="Continue"
                                                                    ValidationGroup="billingInfo" class="x-btnpro Grey main" OnClientClick="javascript:return BillingValidate();"
                                                                    OnClick="OnClick_lnkBtnBillingAddress"></asp:Button>
                                                                <asp:Button ID="btn_BackShop" runat="server" Text="" CausesValidation="false" OnClientClick="javascript:return redirectToshopcart();" OnClick="OnClick_btn_BackShop">
                                                                </asp:Button>
                                                                <div id="div_loadingBilling">
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/ImageHandler.ashx?Imagename=loadingGraphic.gif&amp;type=r&amp;aid='<%=AccountID %>'&amp;cid='<%=CompanyID %>'"
                                                                        AlternateText="Loading" />
                                                                </div>
                                                                <asp:LinkButton ID="lnkBtnBillingAddress" runat="server" OnClick="OnClick_lnkBtnBillingAddress"></asp:LinkButton>
                                                                <asp:HiddenField ID="hdn_OrderID" runat="server" Value="0" />
                                                                <asp:HiddenField ID="hdn_BillingAddressID" runat="server" Value="0" />
                                                                <asp:HiddenField ID="hdn_ClientID" runat="server" Value="0" />
                                                                <asp:HiddenField ID="hdn_NewBillingAddressID" runat="server" Value="0" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div>
                                                        <asp:Label ID="lbl_billingRF" runat="server" Text="* Required Fields"></asp:Label>
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
    <asp:HiddenField ID="hdnOldAdd1" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd2" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd3" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd4" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldAdd5" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldCountryID" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldTel" runat="server" Value="" />
    <asp:HiddenField ID="hdnOldPhone" runat="server" Value="" />
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

        // for Address validations 

        var hdnBillAdd1 = document.getElementById("<%=hdnBillAdd1.ClientID %>");
        var hdnBillAdd2 = document.getElementById("<%=hdnBillAdd2.ClientID %>");
        var hdnBillAdd3 = document.getElementById("<%=hdnBillAdd3.ClientID %>");
        var hdnBillAdd4 = document.getElementById("<%=hdnBillAdd4.ClientID %>");
        var hdnBillAdd5 = document.getElementById("<%=hdnBillAdd5.ClientID %>");

        
        
        // End Added by Manoj

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

        function redirectToshopcart() {
            debugger;
            if (Rewritemodule.toLowerCase() == 'on') {

                window.location = strSitepath + "shoppingcart" + KeySeparator + "0" + KeySeparator + "0" + FileExtension;
              
            }
            else {
                window.location = strSitepath + "shoppingcart.aspx?ID=0&amp;PID=0";
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

        function Setting_focus_Checkout() {
            document.getElementById("ctl00_ContentPlaceHolder1_ucOrderInfo_txt_orderTitle").focus();
            //document.getElementById('<%= (ucOrderInfo.FindControl("txt_orderTitle")).ClientID %>').focus();
        }
        
    </script>
    <asp:Panel ID="pnl_checkout" runat="server" Visible="false">
        <script type="text/javascript">

            if (paymentFlag != "False") {

                ShippingValidate();
            }
            else {
                BillingValidate();
            }
            
        </script>
    </asp:Panel>
    <asp:Panel ID="pnl_BillingAddress" runat="server" Visible="false">
        <script type="text/javascript">

            Billing_Address();
    
        </script>
    </asp:Panel>
    <asp:Panel ID="pnl_ShippingAddress" runat="server" Visible="false">
        <script type="text/javascript">

            Shipping_Address();
    
        </script>
    </asp:Panel>
    <script type="text/javascript" language="javascript">

        var hdnChkInvAddress = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_hdnChkInvAddress"); // This is Invoice Address ID Hidden field
        var hdnChkDelAddress = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_hdnChkDelAddress"); // This is Delivery Address ID Hidden field
        var hdnTotalAddressCount = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_hdnTotalAddressCount"); // This is Total Address Count

        var Invoice_Edit_Address_Link = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdEditAddress");
        var Invoice_ChooseAdress_Link = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdChooseAddress");

        var Delivery_Edit_Address = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdEditAddress1");
        var Delivery_Choose_Address = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdChooseAddress1");

        var Chk_makedefaultAddres_Invoice = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_Chk_makedefaultAddres_Invoice");
        var Chk_makedefaultAddres_Delivery = document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_Chk_makedefaultAddres_Delivery");

        if (hdnTotalAddressCount.value == "0") {
            Invoice_ChooseAdress_Link.style.display = "none";
            Delivery_Choose_Address.style.display = "none";
            Chk_makedefaultAddres_Invoice.checked = true;
            Chk_makedefaultAddres_Delivery.checked = true;
        }

        // This is for hiding the edit option when there is no addresses selected - Start
        if (hdnChkInvAddress.value == "0") {
            Invoice_Edit_Address_Link.style.display = "none";
        }
        else {
            Invoice_Edit_Address_Link.style.display = "block";

        }
        if (hdnChkDelAddress.value == "0") {
            Delivery_Edit_Address.style.display = "none";
        }
        else {
            Delivery_Edit_Address.style.display = "block";
        }
        // This is for hiding the edit option when there is no addresses selected - End

        function ShowEdit(ShippingAddressID, BillingAddressID, Address) {
            if (BillingAddressID != "0" && BillingAddressID != "") {
                Invoice_Edit_Address_Link.style.display = "";
            }
            if (ShippingAddressID != "0" && ShippingAddressID != "") {
                Delivery_Edit_Address.style.display = "";
            }
        }

        function ShowChooseandEdit(hdnTotalAddressCount, Address) {

            if (Address == "Copy") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdEditAddress").style.display = "";
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdEditAddress1").style.display = "";
            }
            else if (Address == "Invoice") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdEditAddress").style.display = "";
            }
            else {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdEditAddress1").style.display = "";
            }

            if (hdnTotalAddressCount != "0" && hdnTotalAddressCount != "") {
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdChooseAddress").style.display = "";
                document.getElementById("ctl00_ContentPlaceHolder1_ucAddressInfo_tdChooseAddress1").style.display = "";
            }
        }

    </script>
</asp:Content>
