<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/SettingsEstore.master" AutoEventWireup="true" CodeBehind="payment_option.aspx.cs" Inherits="ePrint.StoreSettings.payment_option" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>

<%@ Register TagPrefix="UC" TagName="Header" Src="~/usercontrol/settings/settings_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        var AccountID = '<%=AccountID %>';
    </script>
    <div style="float: left;" class="estore_settingBox" id="pnldetails">
        <div align="left">
            <UC:Header ID="header" runat="server" />
            <div style="width: 100%; display: none;" class="navigatorpanel">
                <div class="t">
                    <div class="t">
                        <div class="t">
                            <div class="divpadding">
                                <div align="left" style="float: left;" nowrap="nowrap">
                                    <span class="navigatorpanel">
                                        <%=objLanguage.GetLanguageConversion("Estore_Settings")%>:&nbsp;<%=objLanguage.GetLanguageConversion("Payment_Option")%>&nbsp;
                                        <asp:Label ID="lbl_selectAccount" runat="server" Text=""></asp:Label>&nbsp; <a id="A1"
                                            href="#" style="color: White; text-decoration: underline" runat="server" onclick="Show_accountListDiv();">
                                            <asp:Label ID="lbl_change" runat="server" Text="Change"><%=objLanguage.GetLanguageConversion("Change")%></asp:Label>
                                        </a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
            </div>
            <div>
                <div align="left" style="width: 100%; padding: 10px 0px 0px 10px; border: 0px solid red">
                    <div style="width: 60%">
                        <asp:UpdatePanel ID="UPMessageNew" RenderMode="Inline" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="plhMessageNew" runat="server"></asp:PlaceHolder>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <asp:Label ID="lbl_PaymentID" runat="server" Visible="false" Text=""></asp:Label>
                <div style="padding-left: 10px; width: 100%">
                    <table style="border-spacing: 0px;">
                        <tr>
                            <td>
                                <div class="bglabel" style="width: 94%; margin: 0px">
                                    <asp:Label ID="Label1" runat="server" Text="Online Payment option" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Online_Payment_Option")%></asp:Label>
                                </div>
                            </td>
                            <td>
                                 <div style="float: left;">
                                   <%-- <asp:RadioButton ID="RadioButton1" runat="server" Text='Enable' Checked="true" GroupName="Payment"
                                        onclick="javascript:PaymentEnable('enable');" />
                                    <asp:RadioButton ID="RadioButton2" runat="server" Text='Disable' GroupName="Payment"
                                        onclick="javascript:PaymentEnable('disable');" />--%>

                                           <asp:RadioButton ID="rdn_enable" runat="server" Text='Enable' Checked="true" GroupName="Payment"
                                        onclick="javascript:PaymentEnable('enable');" />
                                    <asp:RadioButton ID="rdn_disable" runat="server" Text='Disable' Checked="false" GroupName="Payment"
                                        onclick="javascript:PaymentEnable('disable');" />

                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:Label ID="Label2" runat="server" Style="font-weight: 900" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Select_one_or_more_options")%></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div style="float: right; padding: 5px 17px 0px 0px">
                                    <asp:Label ID="lbl_default" runat="server" Style="font-weight: 900" Text="Default"><%=objLanguage.GetLanguageConversion("Defaults") %></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="bglabel" style="width: 94%; margin: 0px">
                                    <asp:Label ID="Label3" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Cheque_Money_Order")%></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <div style="float: left; width: 63px">
                                        <asp:CheckBox ID="chk_cheque" runat="server" Checked="false" onclick="javascript:checkButtonChecked('cheque');" /></div>
                                    <div style="float: left; width: 48px; padding-left: 7%;">
                                        <asp:RadioButton ID="rdn_cheque" runat="server" Checked="false" GroupName="paymentMode"
                                            onclick="javascript:radioButtonChecked('cheque');" /></div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="bglabel" style="width: 94%; margin: 0px">
                                    <asp:Label ID="Label5" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Direct_Credit")%></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div style="margin: 0px 0px 10px 0px">
                                    <div style="float: left; width: 63px">
                                        <asp:CheckBox ID="chk_cash" runat="server" Checked="false" onclick="javascript:checkButtonChecked('cash');" /></div>
                                    <div style="float: left; width: 48px; padding-left: 7%;">
                                        <asp:RadioButton ID="rdn_cash" runat="server" Checked="false" GroupName="paymentMode"
                                            onclick="javascript:radioButtonChecked('cash');" /></div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="bglabel" style="width: 94%; margin: 0px">
                                    <asp:Label ID="Label6" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Payment_on_Invoice")%></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div style="float: left; width: 63px">
                                    <asp:CheckBox ID="chk_Invoice" runat="server" Checked="false" onclick="javascript:checkButtonChecked('invoice');" /></div>
                                <div style="float: left; width: 48px; padding-left: 7%;">
                                    <asp:RadioButton ID="rdn_Invoice" runat="server" Checked="false" GroupName="paymentMode"
                                        onclick="javascript:radioButtonChecked('invoice');" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="bglabel" style="width: 94%; margin: 0px">
                                    <asp:Label ID="Label7" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("PayPal")%></asp:Label>
                                </div>
                            </td>
                            <td>
                                <div style="float: left; width: 63px;">
                                    <asp:CheckBox ID="chk_paypal" runat="server" Checked="false" onclick="javascript:checkButtonChecked('paypal');" /></div>
                                <div style="float: left; width: 48px; padding-left: 7%;">
                                    <asp:RadioButton ID="rdn_paypal" runat="server" Checked="false" GroupName="paymentMode"
                                        onclick="javascript:radioButtonChecked('paypal');" /></div>
                            </td>
                        </tr>
                        <tr>
                            <td id="credit_card" style="padding-top: 21px;">
                                <div id="div_CreaditCards" class="bglabel" style="width: 94%; height: 102px; margin-top: -20px;">
                                    <asp:Label ID="Label8" runat="server" CssClass="normaltext"><%=objLanguage.GetLanguageConversion("Credit_Cards")%></asp:Label>
                                </div>
                            </td>
                            <td id="td_credit_card">
                                <div style="float: left; width: 63px">
                                    <asp:CheckBox ID="chk_credit" runat="server" onclick="javascript:checkButtonChecked('credit');" /></div>
                                <div style="float: left; width: 48px; padding-left: 7%;">
                                    <asp:RadioButton ID="rdn_credit" runat="server" Checked="false" GroupName="paymentMode"
                                        onclick="javascript:radioButtonChecked('credit');" /></div>
                                <br />
                                <div style="width: 102%; padding-left: 4%;">
                                    <asp:DropDownList ID="ddlMode" runat="server">
                                        <asp:ListItem Value="0">Offline Mode</asp:ListItem>
                                        <asp:ListItem Value="1">Brain Tree</asp:ListItem>
                                        <asp:ListItem Value="2">Stripe</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="div_creditcardType" runat="server" style="float: left; width: 100px; border: solid 0px #CCC;
                                    display: block; padding-top: 2%; padding-bottom: 0%;">
                                    <div style="padding-left: 20%">
                                        <asp:CheckBox ID="chk_visa" runat="server" Checked="false" Text='Visa' /><br />
                                        <asp:CheckBox ID="chk_master" runat="server" Checked="false" Text='Master' /><br />
                                        <asp:CheckBox ID="chk_american" runat="server" Checked="false" Text="American" /><br />
                                        <asp:CheckBox ID="chk_discover" runat="server" Checked="false" Text='Discover' />
                                    </div>
                                    <div id="spn_errorMsg" style="display: none; margin: 1px 0px 0px 4px; width: 250px">
                                        <div class="RFV_Message" style="width: auto; white-space: nowrap;">
                                            <span style="float: left; padding-left: 5px; padding-right: 5px;">
                                                <%=objLanguage.GetLanguageConversion("Please_Select_Alleast_One_Master_Card")%></span>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div style="width: 550px; padding: 8px 0px 5px 186px;" class="smallfontgrey">
            <table>
                <tr>
                    <td id="note1" class="smallfontgrey">
                        <%=objLanguage.GetLanguageConversion("PayPal_Support")%>
                    </td>
                    <td id="note2" class="smallfontgrey">
                        <%=objLanguage.GetLanguageConversion("or_Braintree_Payment_Integration")%>
                    </td>
                </tr>
            </table>
        </div>
        <div style="float: left; width: 450px; padding: 5px 0px 10px 190px;" class="box">
            <div id="div_btnsave" style="display: block">
                <asp:Button ID="btn_Save" runat="server" CssClass="button" Text="Save" OnClick="btn_Save_Onclick"
                    OnClientClick="javascript:var a=checkCardTypes();if(a)loadingimage('ctl00_ContentPlaceHolder1_btn_Save','div_btnsaveprocess');return a;" />
            </div>
            <div id="div_btnsaveprocess" style="display: none">
                <img src="<%=strImagepath %>radimg1.gif" class="loadingimg" alt="loading" border="0" />
            </div>
        </div>
        <%--    <div style="clear: both">
                            </div>
                            <div id="div_payment" runat="server" style="display: block;">
                                <div style="clear: both">
                                </div>
                              
                                <div style="clear: both">
                                </div>
                          
                                <div style="clear: both">
                                </div>
                                <div>
                                   
                                    <div style="clear: both">
                                    </div>
                                </div>
                                <div>
                                   </div>
                                <div style="clear: both">
                                </div>
                                <div>
                                    <div style="float: left; width: 200px">
                                        <asp:CheckBox ID="chk_Braintree" runat="server" Checked="false" Text='Braintree'
                                            onclick="javascript:checkButtonChecked('braintree');" /></div>
                                    <div style="float: left; width: 200px">
                                        <asp:RadioButton ID="rdn_Braintree" runat="server" Checked="false" GroupName="paymentMode"
                                            onclick="javascript:radioButtonChecked('braintree');" /></div>
                                </div>
                                <div style="clear: both">
                                </div>
                                <div id="div_creditcardBrainTree" runat="server" style="float: left; width: 150px;
                                    margin: 5px 0px 0px 20px; border: solid 0px #CCC; display: none;">
                                    <asp:CheckBox ID="chk_visa_BT" runat="server" Checked="false" Text='Visa' /><br />
                                    <asp:CheckBox ID="chk_master_BT" runat="server" Checked="false" Text='Master' /><br />
                                    <asp:CheckBox ID="chk_discover_BT" runat="server" Checked="false" Text='Discover' /><br />
                                    <asp:CheckBox ID="chk_american_BT" runat="server" Checked="false" Text="American" /><br />
                                </div>
                                <div style="clear: both">
                                </div>
                             
                            </div>
                        </div>
                   </div> 
        --%>
    </div>
    <div style="clear: both;">
    </div>
    <%--   <div>
                    <div class="bglabel" style="width: 20%; background: white">
                        <asp:Label ID="Label4" runat="server" Text="" CssClass="normaltext"></asp:Label>
                    </div>
                  
                </div>--%>
    <div style="clear: both;">
    </div>
    <script type="text/javascript" language="javascript">
        var chk_cash = document.getElementById("<%=chk_cash.ClientID %>");
        var rdn_cash = document.getElementById("<%=rdn_cash.ClientID %>");

        var chk_cheque = document.getElementById("<%=chk_cheque.ClientID %>");
        var rdn_cheque = document.getElementById("<%=rdn_cheque.ClientID %>");

        var chk_credit = document.getElementById("<%=chk_credit.ClientID %>");
        var rdn_credit = document.getElementById("<%=rdn_credit.ClientID %>");

        var chk_paypal = document.getElementById("<%=chk_paypal.ClientID %>");
        var rdn_paypal = document.getElementById("<%=rdn_paypal.ClientID %>");

        var chk_invoice = document.getElementById("<%=chk_Invoice.ClientID %>");
        var rdn_invoice = document.getElementById("<%=rdn_Invoice.ClientID %>");
        var lbl_change = document.getElementById("<%=lbl_change.ClientID %>");

        var div_creditcardType = document.getElementById("<%=div_creditcardType.ClientID %>");
        var spn_errorMsg = document.getElementById("spn_errorMsg");

        var chk_american = document.getElementById("<%=chk_american.ClientID %>");
        var chk_visa = document.getElementById("<%=chk_visa.ClientID %>");
        var chk_master = document.getElementById("<%=chk_master.ClientID %>");
        var chk_discover = document.getElementById("<%=chk_discover.ClientID %>");
        var td_credit_card = document.getElementById("td_credit_card");
        var ddlMode = document.getElementById("ddlMode");

        function checkCardTypes() {
            if (validate_Account()) {
                if (chk_credit.checked) {
                    if (chk_american.checked == false && chk_visa.checked == false && chk_master.checked == false && chk_discover.checked == false) {
                        document.getElementById("div_CreaditCards").style.height = "125px";
                        //td_credit_card.style.paddingBottom = "4%";

                        spn_errorMsg.style.display = "block";
                        return false;
                    }
                }
            }
            return true;
        }


        function radioButtonChecked(val) {
            if (val = 'cash' && rdn_cash.checked == true) {
                chk_cash.checked = true;
            }
            if (val = 'cheque' && rdn_cheque.checked == true) {
                chk_cheque.checked = true;
            }
            if (val = 'credit' && rdn_credit.checked == true) {
                chk_credit.checked = true;
                div_creditcardType.style.display = "block";
                chk_american.disabled = false;
                chk_visa.disabled = false;
                chk_master.disabled = false;
                chk_discover.disabled = false;
                document.getElementById('<%=ddlMode.ClientID %>').disabled = false;
            }
            if (val = 'paypal' && rdn_paypal.checked == true) {
                chk_paypal.checked = true;
            }
            if (val = 'invoice' && rdn_invoice.checked == true) {
                chk_invoice.checked = true;
            }
            //            if (val = 'braintree' && rdn_Braintree.checked == true) {
            //                chk_Braintree.checked = true;
            //                div_creditcardBrainTree.style.display = "block";
            //            }
        }

        function checkButtonChecked(val) {
            if (val = 'cash' && rdn_cash.checked == true) {
                if (chk_cash.checked == false) {
                    chk_cash.checked = true;
                }
            }
            if (val = 'cheque' && rdn_cheque.checked == true) {
                if (chk_cheque.checked == false) {
                    chk_cheque.checked = true;
                }
            }
            if (val = 'credit' && rdn_credit.checked == true) {
                if (chk_credit.checked == false) {
                    chk_credit.checked = true;
                }
            }
            if (val = 'paypal' && rdn_paypal.checked == true) {
                if (chk_paypal.checked == false) {
                    chk_paypal.checked = true;
                }
            }
            if (val = 'invoice' && rdn_invoice.checked == true) {
                if (chk_invoice.checked == false) {
                    chk_invoice.checked = true;
                }
            }

            if (val = 'credit') {

                if (chk_credit.checked == true || rdn_credit.checked == true) {
                    div_creditcardType.style.display = "block";
                    chk_american.disabled = false;
                    chk_visa.disabled = false;
                    chk_master.disabled = false;
                    chk_discover.disabled = false;
                    document.getElementById('<%=ddlMode.ClientID %>').disabled = false;
                }
                else {
                    chk_american.disabled = true;
                    chk_visa.disabled = true;
                    chk_master.disabled = true;
                    chk_discover.disabled = true;
                    document.getElementById('<%=ddlMode.ClientID %>').disabled = true;
                    chk_american.checked = false;
                    chk_visa.checked = false;
                    chk_master.checked = false;
                    chk_discover.checked = false;

                }
            }

        }

        function PaymentEnable(val) {
            var rdnenable = document.getElementById('<%=rdn_enable.ClientID %>')
            var rdndisable = document.getElementById('<%=rdn_disable.ClientID %>')
            if (val == 'enable' && rdnenable.checked == true) {
                chk_cash.disabled = false;
                chk_cheque.disabled = false;
                chk_credit.disabled = false;
                chk_paypal.disabled = false;
                chk_invoice.disabled = false;
                document.getElementById('<%=ddlMode.ClientID %>').disabled = false;
                rdn_cash.disabled = false;
                rdn_cheque.disabled = false;
                rdn_credit.disabled = false;
                rdn_paypal.disabled = false;
                rdn_invoice.disabled = false;


                chk_american.disabled = false;
                chk_visa.disabled = false;
                chk_master.disabled = false;
                chk_discover.disabled = false;

                checkButtonChecked(val);

            }
            if (val == 'disable' && rdndisable.checked == true) {
                chk_cash.disabled = true;
                chk_cheque.disabled = true;
                chk_credit.disabled = true;
                chk_paypal.disabled = true;
                chk_invoice.disabled = true;
                document.getElementById('<%=ddlMode.ClientID %>').disabled = true;
                rdn_cheque.disabled = true;
                rdn_cash.disabled = true;
                rdn_invoice.disabled = true;
                rdn_paypal.disabled = true;
                rdn_credit.disabled = true;
                chk_american.disabled = true;
                chk_visa.disabled = true;
                chk_master.disabled = true;
                chk_discover.disabled = true;
                // checkButtonChecked(val);
            }
        }

        var IsEnable = '';
        if ('<%=IsEnable %>' == 1) {
            IsEnable = 'enable';
        }
        else {
            IsEnable = 'disable';
        }

        PaymentEnable(IsEnable);

        //        function Show_accountListDiv() {
        //            showDivPopupCenter('div_accountsList', '200');
        //        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

