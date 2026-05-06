<%@ page title="Payment Information" language="C#" masterpagefile="~/templates/MasterPageDefault.master" autoeventwireup="true" CodeBehind="payment_information.aspx.cs" Inherits="ePrint.WebStore.payment_information"  enableEventValidation="false" viewStateEncryptionMode="Never" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/Slide/jquery-1.2.6.min.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="https://js.stripe.com/v3/"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="false" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript">

        var hdn_CreditCard;
        var type;
        var txt_cardNumber = document.getElementById("ctl00_ContentPlaceHolder1_txt_cardNumber");
        var rbnAmericanID = document.getElementById("ctl00_ContentPlaceHolder1_rbnAmericanID");
        var rbnVisaID = document.getElementById("ctl00_ContentPlaceHolder1_rbnVisaID");
        var rbnMasterCardID = document.getElementById("ctl00_ContentPlaceHolder1_rbnMasterCardID");
        var rbnDiscoverID = document.getElementById("ctl00_ContentPlaceHolder1_rbnDiscoverID");


        function show() {
            debugger;
            var Paypal_ButtonText = '<%=Paypal_ButtonText %>';
            var OtherOptions_ButtonText = '<%=OtherOptions_ButtonText %>';
            var orderbutton = document.getElementById("ctl00_ContentPlaceHolder1_btnOrder");
            var ddl_payments = document.getElementById("ctl00_ContentPlaceHolder1_ddl_payments");
            if (ddl_payments.selectedIndex != -1) {
                type = ddl_payments.options[ddl_payments.selectedIndex].value;
            }
            if (type == "CC" || type == "BT") {
                document.getElementById("creditCard").style.display = "block";
                hdn_CreditCard = "1";
            }
            else {
                document.getElementById("creditCard").style.display = "none";
                //document.getElementById("Stripecard").style.display = "none";
                hdn_CreditCard = "0";
            }
            if (type == "PP") {
                orderbutton.value = Paypal_ButtonText;
                orderbutton.style.width = 'auto';
            }
            else {
                orderbutton.value = OtherOptions_ButtonText;
            }
            //if (type == "ST") {
                //document.getElementById("creditCard").style.display = "block";
               // document.getElementById("Stripecard").style.display = "none";
              //  hdn_CreditCard = "1";
            //}
            //else {
               // document.getElementById("creditCard").style.display = "none";
               // document.getElementById("Stripecard").style.display = "none";
              //  hdn_CreditCard = "0";
            //}
            var hdn_Creditcardtypes = document.getElementById("<%=hdn_Creditcardtypes.ClientID %>");
            var hdn_Creditcardtypes_BT = document.getElementById("<%=hdn_Creditcardtypes_BT.ClientID %>");
            var hdn_Creditcardtypes_ST = document.getElementById("<%=hdn_Creditcardtypes_ST.ClientID %>");
            var Creditcardtypes = hdn_Creditcardtypes.value.split(',');
            var CreditCardtypes_BT = hdn_Creditcardtypes_BT.value.split(',');
            var CreditCardtypes_ST = hdn_Creditcardtypes_ST.value.split(',');
            var hdn_SelectedCardType = document.getElementById('<%=hdn_SelectedCardType.ClientID %>');

            var div_creditCard_American = document.getElementById("<%=div_creditCard_American.ClientID %>");
            var div_creditCard_Visa = document.getElementById("<%=div_creditCard_Visa.ClientID %>");
            var div_creditCard_Master = document.getElementById("<%=div_creditCard_Master.ClientID %>");
            var div_creditCard_Discover = document.getElementById("<%=div_creditCard_Discover.ClientID %>");

            var rbnAmericanID = document.getElementById("ctl00_ContentPlaceHolder1_rbnAmericanID");
            var rbnVisaID = document.getElementById("ctl00_ContentPlaceHolder1_rbnVisaID");
            var rbnMasterCardID = document.getElementById("ctl00_ContentPlaceHolder1_rbnMasterCardID");
            var rbnDiscoverID = document.getElementById("ctl00_ContentPlaceHolder1_rbnDiscoverID");

            var flag = false;
            if (type == "CC") {    // forCredit Card
                div_creditCard_American.style.display = "none";
                div_creditCard_Visa.style.display = "none";
                div_creditCard_Discover.style.display = "none";
                div_creditCard_Master.style.display = "none";

                for (i = 0; i < Creditcardtypes.length; i++) {

                    if (Creditcardtypes[i].toString().toLowerCase() == "visa") {
                        div_creditCard_Visa.style.display = "block";

                        if (flag == false) {
                            rbnVisaID.checked = true;
                            flag = true;
                        }
                    }
                    if (Creditcardtypes[i].toString().toLowerCase() == "mastercard") {
                        div_creditCard_Master.style.display = "block";

                        if (flag == false) {
                            rbnMasterCardID.checked = true;
                            flag = true;
                        }
                    }
                    if (Creditcardtypes[i].toString().toLowerCase() == "discover") {
                        div_creditCard_Discover.style.display = "block";

                        if (flag == false) {
                            rbnDiscoverID.checked = true;
                            flag = true;
                        }
                    }
                    if (Creditcardtypes[i].toString().toLowerCase() == "american") {
                        div_creditCard_American.style.display = "block";

                        if (flag == false) {
                            rbnAmericanID.checked = true;
                            flag = true;
                        }
                    }
                }
            }

            var flag1 = false;
            if (type == "BT") { // for Braintree Credit Card
                div_creditCard_American.style.display = "none";
                div_creditCard_Visa.style.display = "none";
                div_creditCard_Discover.style.display = "none";
                div_creditCard_Master.style.display = "none";

                for (i = 0; i < CreditCardtypes_BT.length; i++) {
                    if (CreditCardtypes_BT[i].toString().toLowerCase() == "visa") {
                        div_creditCard_Visa.style.display = "block";

                        if (flag1 == false || hdn_SelectedCardType.value == "visa") {
                            rbnVisaID.checked = true;
                            flag1 = true;
                        }
                    }
                    if (CreditCardtypes_BT[i].toString().toLowerCase() == "mastercard") {
                        div_creditCard_Master.style.display = "block";

                        if (flag1 == false || hdn_SelectedCardType.value == "mastercard") {
                            rbnMasterCardID.checked = true;
                            flag1 = true;
                        }
                    }
                    if (CreditCardtypes_BT[i].toString().toLowerCase() == "discover") {
                        div_creditCard_Discover.style.display = "block";

                        if (flag1 == false || hdn_SelectedCardType.value == "discover") {
                            rbnDiscoverID.checked = true;
                            flag1 = true;
                        }
                    }
                    if (CreditCardtypes_BT[i].toString().toLowerCase() == "american") {
                        div_creditCard_American.style.display = "block";

                        if (flag1 == false || hdn_SelectedCardType.value == "american") {
                            rbnAmericanID.checked = true;
                            flag1 = true;
                        }
                    }
                }
                hdn_SelectedCardType.value = "";
            }
            //var flag2 = false;
            //if (type == "ST") { // for Stripe Credit Card
            //    div_creditCard_American.style.display = "none";
            //    div_creditCard_Visa.style.display = "none";
            //    div_creditCard_Discover.style.display = "none";
            //    div_creditCard_Master.style.display = "none";

            //    for (i = 0; i < CreditCardtypes_ST.length; i++) {
            //        if (CreditCardtypes_ST[i].toString().toLowerCase() == "visa") {
            //            div_creditCard_Visa.style.display = "block";

            //            if (flag2 == false || hdn_SelectedCardType.value == "visa") {
            //                rbnVisaID.checked = true;
            //                flag2 = true;
            //            }
            //        }
            //        if (CreditCardtypes_ST[i].toString().toLowerCase() == "mastercard") {
            //            div_creditCard_Master.style.display = "block";

            //            if (flag2 == false || hdn_SelectedCardType.value == "mastercard") {
            //                rbnMasterCardID.checked = true;
            //                flag2 = true;
            //            }
            //        }
            //        if (CreditCardtypes_ST[i].toString().toLowerCase() == "discover") {
            //            div_creditCard_Discover.style.display = "block";

            //            if (flag2 == false || hdn_SelectedCardType.value == "discover") {
            //                rbnDiscoverID.checked = true;
            //                flag2 = true;
            //            }
            //        }
            //        if (CreditCardtypes_ST[i].toString().toLowerCase() == "american") {
            //            div_creditCard_American.style.display = "block";

            //            if (flag2 == false || hdn_SelectedCardType.value == "american") {
            //                rbnAmericanID.checked = true;
            //                flag2 = true;
            //            }
            //        }
            //    }
            //    hdn_SelectedCardType.value = "";
            //}
        }

        function CreditCardValidation() {
            var txt_cardNumber = document.getElementById("ctl00_ContentPlaceHolder1_txt_cardNumber");
            var rbnAmericanID = document.getElementById("ctl00_ContentPlaceHolder1_rbnAmericanID");
            var rbnVisaID = document.getElementById("ctl00_ContentPlaceHolder1_rbnVisaID");
            var rbnMasterCardID = document.getElementById("ctl00_ContentPlaceHolder1_rbnMasterCardID");
            var rbnDiscoverID = document.getElementById("ctl00_ContentPlaceHolder1_rbnDiscoverID");
            var txt_verification = document.getElementById("<%=txt_verification.ClientID %>");
            var txt_HolderName = document.getElementById("<%=txt_HolderName.ClientID %>");
            var ddl_month = document.getElementById("<%=ddl_month.ClientID %>");
            var ddl_year = document.getElementById("<%=ddl_year.ClientID %>");

            var CreditCheck = false;
            var re = '';

            if (hdn_CreditCard == "1") {

                if (txt_cardNumber.value == "") {
                    document.getElementById("spn_cardNumber").style.display = "block";
                    CreditCheck = true;
                }
                else if (!Number(txt_cardNumber.value)) {
                    document.getElementById("spn_cardNumber").style.display = "block";
                    document.getElementById("spn_cardNumber").innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Number") %>';
                    CreditCheck = true;
                }

                if (rbnVisaID.checked) {
                    // Visa: length 16, prefix 4, dashes optional.
                    re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
                    //                alert(re);
                }
                else if (rbnMasterCardID.checked) {
                    // Mastercard: length 16, prefix 51-55, dashes optional.
                    re = /^5[1-5]\d{2}-?\d{4}-?\d{4}-?\d{4}$/;
                }
                else if (rbnDiscoverID.checked) {
                    // Discover: length 16, prefix 6011, dashes optional.
                    re = /^6011-?\d{4}-?\d{4}-?\d{4}$/;
                }
                else if (rbnAmericanID.checked) {
                    // American Express: length 15, prefix 34 or 37.
                    re = /^3[4,7]\d{13}$/;
                }

                if (re.length == 0) {
                    rbnVisaID.checked = true;
                    re = /^4\d{3}-?\d{4}-?\d{4}-?\d{4}$/;
                }

                if (!re.test(txt_cardNumber.value)) {
                    //                alert('invalid');
                    document.getElementById("spn_cardNumber").style.display = "block";
                    document.getElementById("spn_cardNumber").innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Number") %>';
                    CreditCheck = true;
                }
                else {
                    //                alert('valid');
                    document.getElementById("spn_cardNumber").style.display = "none";
                }

                // Remove all dashes for the checksum checks to eliminate negative numbers
                var ccnum = txt_cardNumber.value.split("-").join("");
                // Checksum ("Mod 10")
                // Add even digits in even length strings or odd digits in odd length strings.
                var checksum = 0;
                for (var i = (2 - (ccnum.length % 2)); i <= ccnum.length; i += 2) {
                    checksum += parseInt(ccnum.charAt(i - 1));
                }

                // Analyze odd digits in even length strings or even digits in odd length strings.
                for (var i = (ccnum.length % 2) + 1; i < ccnum.length; i += 2) {
                    var digit = parseInt(ccnum.charAt(i - 1)) * 2;
                    if (digit < 10) { checksum += digit; } else { checksum += (digit - 9); }
                }
                if ((checksum % 10) != 0) {
                    document.getElementById("spn_cardNumber").style.display = "block";
                    document.getElementById("spn_cardNumber").innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Number") %>';
                    CreditCheck = true;
                }
                else if (!CreditCheck) {
                    document.getElementById("spn_cardNumber").style.display = "none";
                }



                if (txt_verification.value == "") {
                    document.getElementById("spn_verification").style.display = "block";
                    CreditCheck = true;
                }
                else if (!Number(txt_verification.value)) {
                    //                alert('CreditCheck1  _' + CreditCheck);
                    document.getElementById("spn_verification").style.display = "block";
                    document.getElementById("spn_verification").innerHTML = '<%=objLanguage.GetLanguageConversion("Please_Enter_Valid_Number") %>';
                    CreditCheck = true;
                }
                else {
                    document.getElementById("spn_verification").style.display = "none";
                }


                if (txt_HolderName.value == "") {
                    document.getElementById("spn_HolderName").style.display = "block";
                    CreditCheck = true;
                }
                else {
                    document.getElementById("spn_HolderName").style.display = "none";
                }

                if (ddl_month.selectedIndex == 0 || ddl_year.selectedIndex == 0) {
                    document.getElementById("spn_ddlyear").style.display = "block";
                    document.getElementById("spn_ddlyear").innerHTML = '<%=objLanguage.GetLanguageConversion("Please_select_valid_month_year") %>';
                    CreditCheck = true;
                }
                else {
                    document.getElementById("spn_ddlyear").style.display = "none";
                }
            }

            if (CreditCheck) {
                return false;
            }
            loadingimg('div_btnsave', 'div_btnsaveprocess');
            return true;
        }
    </script>
    <div id="PaymentInfoPage">
        <div align="center" id="OrderConfirmMain_div">
            <div align="center" id="OrderConfirmContent_div">
                <div id="heading" class="Header_Background">
                    <strong class="floatLeft paddingTop5">
                        <%=objLanguage.GetLanguageConversion("Checkout") %></strong>
                </div>
                <div class="clearBoth">
                </div>
                <div id="wizard" class="swMain">
                    <ul class="anchor">
                        <li  id="li3" runat="server"><a href="#" class="done CheckOut_HeadingRoundedCorner">
                            <label class="stepNumber">
                                1</label>
                            <span class="stepDesc"><small>
                                <%=objLanguage.GetLanguageConversion("Order_Information") %></small> </span>
                        </a></li>
                        <li id="li4" runat="server"><a href="#" class="done CheckOut_HeadingRoundedCorner">
                            <label id="lblStep4" runat="server" class="stepNumber">
                                2</label>
                            <span class="stepDesc"><small>
                                <%=objLanguage.GetLanguageConversion("Address_Information") %></small> </span>
                        </a></li>
                        <li id="li5" runat="server"><a href="#" class="done CheckOut_HeadingRoundedCorner">
                            <label id="lblStep5" runat="server" class="stepNumber">
                                3</label>
                            <span class="stepDesc"><small>
                                <%=objLanguage.GetLanguageConversion("Order_Confirmation") %></small> </span>
                        </a></li>
                        <li id="li_payment" runat="server"><a href="#" class="selected CheckOut_HeadingRoundedCorner">
                            <label id="lblStep6" runat="server" class="stepNumber">
                                4</label>
                            <span class="stepDesc"><small>
                                <%=objLanguage.GetLanguageConversion("Payment_Information") %></small> </span>
                        </a></li>
                    </ul>
                </div>
                <div class="clearBoth">
                </div>
                <div class="paddingTop2">
                    <div id="PaymentMode">
                        <div style="float: left; padding-left: 5px;">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPaypalAlertMSG" runat="server" Style="color: Red;"><span></span> <br /></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div>
                            <asp:Label ID="lblPIHeader" class="CheckOutPIHeader" runat="server">
                            </asp:Label>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="div_PaymentMode" class="PaymentMode_details" runat="server">
                            <div class="PaymentMode_details_left12">
                                <asp:Label ID="lbl_payment" runat="server"></asp:Label>&nbsp;
                            </div>
                            <div class="PaymentMode_details_right">
                                <asp:DropDownList ID="ddl_payments" runat="server" onchange="javascript:show();"
                                    CssClass="ddl_Width floatLeft">
                                    <%-- <asp:ListItem Value="CD">Cash on Delivery</asp:ListItem>
                                    <asp:ListItem Value="CH">Cheque / Money Order</asp:ListItem>
                                    <asp:ListItem Value="CC">Credit Card</asp:ListItem>
                                    <asp:ListItem Value="PP">PayPal</asp:ListItem>
                                    <asp:ListItem Value="PI">Payment on Invoice</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div>
                            <div>
                                <asp:RadioButton ID="rdn_Check_Money" runat="server" GroupName="PaymentMode" Checked="true"
                                    Visible="false" Text=" Check/Money order" onclick="hide();" />
                            </div>
                            <div>
                                <asp:RadioButton ID="rdn_Card" runat="server" GroupName="PaymentMode" Text=" Credit Card(saved)"
                                    Visible="false" onclick="show();" />
                            </div>
                        </div>
                        <div id="creditCard" class="creditCard_div DisplayNone">
                            <div>
                                <div class="creditCard_left">
                                    <asp:Label ID="lbl_HolderName" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Card_Holders_Name") %></asp:Label>
                                    <label id="Label21" class="mandatoryField">
                                        *</label>
                                </div>
                                <div class="creditCard_right">
                                    <div class="floatLeft">
                                        <asp:TextBox ID="txt_HolderName" runat="server" class="width150px1"></asp:TextBox>
                                        <span id="spn_HolderName" class="mandatoryField DisplayNone floatLeft">&nbsp;&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                    </div>
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                            <div>
                                <div class="creditCard_left">
                                    <asp:Label ID="lbl_cardType" class="lbl_cardType" runat="server" Text="Card Type "><%=objLanguage.GetLanguageConversion("Card_Type") %></asp:Label>
                                    <label id="Label24" class="mandatoryField">
                                        *</label>
                                </div>
                                <div class="creditCard_right">
                                    <div class="Visa_div DisplayNone" id="div_creditCard_Visa" runat="server">
                                        <div id="Visa_rdn">
                                            <asp:RadioButton ID="rbnVisaID" runat="server" CssClass="rdn_creditCard" GroupName="credit" /></div>
                                        <div>
                                            <img id="imgVisaCard" runat="server" alt="Visa" title="Visa" /></div>
                                    </div>
                                    <div class="MasterCard_div DisplayNone" id="div_creditCard_Master" runat="server">
                                        <div id="MasterCard_rdn">
                                            <asp:RadioButton ID="rbnMasterCardID" runat="server" CssClass="rdn_creditCard" GroupName="credit" /></div>
                                        <div>
                                            <img id="imgMasterCard" runat="server" alt="Master Card" title="Master Card" /></div>
                                    </div>
                                  
                                    <div class="American_div DisplayNone" id="div_creditCard_American" runat="server">
                                        <div id="American_rdn">
                                            <asp:RadioButton ID="rbnAmericanID" runat="server" CssClass="rdn_creditCard" GroupName="credit" /></div>
                                        <div>
                                            <img id="imgAmericanCard" runat="server" alt="American Card" title="American Card" />
                                        </div>
                                    </div>
                                      <div class="Discover_div DisplayNone" id="div_creditCard_Discover" runat="server">
                                        <div id="Discover_rdn">
                                            <asp:RadioButton ID="rbnDiscoverID" runat="server" CssClass="rdn_creditCard" GroupName="credit" /></div>
                                        <div>
                                            <img id="imgDiscoverCard" runat="server" alt="Discover" title="Discover" /></div>
                                    </div>
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                            <div>
                                <div class="creditCard_left">
                                    <asp:Label ID="lbl_cardNumber" runat="server" Text="Card Number "><%=objLanguage.GetLanguageConversion("Card_Number") %></asp:Label>
                                    <label id="Label25" class="mandatoryField">
                                        *</label>
                                </div>
                                <div class="creditCard_right">
                                    <div class="floatLeft">
                                        <asp:TextBox ID="txt_cardNumber" runat="server" class="width150px1"></asp:TextBox>
                                        <span id="spn_cardNumber">&nbsp;&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                    </div>
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                            <div>
                                <div class="creditCard_left">
                                    <asp:Label ID="lbl_expDate" runat="server" Text="Expiration Date "><%=objLanguage.GetLanguageConversion("Expiration_Date")%></asp:Label>
                                    <label id="Label26" class="mandatoryField">
                                        *</label>
                                </div>
                                <div class="creditCard_right" id="div_ddl_month">
                                    <asp:DropDownList ID="ddl_month" runat="server" class="width75px1">
                                        <asp:ListItem Text="Month" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="01" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="02" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="03" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="04" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="05" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="06" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="07" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="08" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="09" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="floatLeft paddingTop5">
                                    <asp:DropDownList ID="ddl_year" runat="server" class="width75px1">
                                        <asp:ListItem Text="Year" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                        <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                        <asp:ListItem Text="2023" Value="2023"></asp:ListItem>
                                        <asp:ListItem Text="2024" Value="2024"></asp:ListItem>
                                        <asp:ListItem Text="2025" Value="2025"></asp:ListItem>
                                        <asp:ListItem Text="2026" Value="2026"></asp:ListItem>
                                        <asp:ListItem Text="2027" Value="2027"></asp:ListItem>
                                        <asp:ListItem Text="2028" Value="2028"></asp:ListItem>
                                        <asp:ListItem Text="2029" Value="2029"></asp:ListItem>
                                        <asp:ListItem Text="2030" Value="2030"></asp:ListItem>
                                        <asp:ListItem Text="2031" Value="2031"></asp:ListItem>
                                    </asp:DropDownList>
                                    <span id="spn_ddlmonth" class="mandatoryField DisplayNone">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                    <div class="floatLeft">
                                        <span id="spn_ddlyear" class="mandatoryField">
                                            <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                    </div>
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                            <div>
                                <div class="creditCard_left">
                                    <asp:Label ID="lbl_verification" runat="server" Text="Verification Number "><%=objLanguage.GetLanguageConversion("Verification_Number")%></asp:Label>
                                    <label id="Label27" class="mandatoryField">
                                        *</label>
                                </div>
                                <div class="creditCard_right">
                                    <div class="floatLeft">
                                        <asp:TextBox ID="txt_verification" TextMode="Password" runat="server" class="width30px1" MaxLength="4"></asp:TextBox>
                                        <span id="spn_verification" class="mandatoryField DisplayNone floatLeft">&nbsp;&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                    </div>
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                            <div>
                                <div class="creditCard_left">
                                </div>
                                <div class="creditCard_right">
                                    <asp:Label ID="lbl_paymentRF" runat="server" Text="" class="mandatoryField floatLeft"> * <%=objLanguage.GetLanguageConversion("Required_Fields")%></asp:Label>
                                </div>
                            </div>
                            <div class="clearBoth">
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                    </div>
                </div>
                <br />
                <div class="PaymentInfoPage_BtnsDiv">
                    <table class="PaymentInfoPage_BtnsTbl">
                        <tr>
                            <td class="floatLeft">
                                <div id="divBackLink" class="right">
                                    <div id="div_btnsave2" class="DisplayBlock floatLeft">
                                        <asp:Button ID="BackLink" runat="server" Text="Back" CssClass="x-btnpro Grey main"
                                            Width="100px" OnClick="BackLink_onclick" OnClientClick="javascript:loadingimg('div_btnsave2', 'div_btnsaveprocess2');" />
                                    </div>
                                    <div id="div_btnsaveprocess2" class="x-btnpro Grey main" align="center">
                                        <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                            </td>
                            <td class="floatRight clearLeft">
                                <div id="divSaveMain" class="right">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div id="div_btnsave" class="DisplayBlock floatRight">
                                                <asp:Button ID="btnOrder" Width="120px" runat="server" Text="Confirm Order" class="x-btnpro Grey main"
                                                    OnClientClick="javascript:return CreditCardValidation(); return false;" OnClick="OnClick_lnkbtnOrder"
                                                    CausesValidation="true" ValidationGroup="ApproverEmail" />&nbsp;&nbsp;&nbsp;
                                            </div>
                                            <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                                <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                            </div>
                                            <div id="div_loading" class="DisplayNone">
                                                <asp:Image ID="imgLoading" runat="server" ImageUrl="~/ImageHandler.ashx?Imagename=loadingGraphic.gif&amp;type=r&amp;aid='<%=AccountID %>'&amp;cid='<%=CompanyID %>'"
                                                    AlternateText="Loading" />
                                            </div>
                                            <asp:LinkButton ID="lnkbtnOrder" runat="server" OnClick="OnClick_lnkbtnOrder"></asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdn_EstimateID" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_Creditcardtypes" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_Creditcardtypes_BT" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_Creditcardtypes_ST" runat="server" Value="0" />
    <asp:HiddenField ID="hdn_SelectedCardType" runat="server" Value="" />
    <script type="text/javascript" language="javascript">

        function redirectTo() {
            if (Rewritemodule.toLowerCase() == 'on') {
                window.location = strSitepath + "products" + KeySeparator + 0 + FileExtension;
            }
            else {
                window.location = strSitepath + "products/product.aspx?ID=0";
            }
        }

        function ShowAlert() {
            alert("Email address missing valid Domain name");
            return false;
        }

    </script>
    <script type="text/javascript">
        $(document).keypress(function (e) {
            var keyCode = (window.event) ? e.which : e.keyCode;
            if (keyCode && keyCode == 13) {
                e.preventDefault();
                return false;
            }
        });
    </script>
</asp:Content>
