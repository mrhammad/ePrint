<%@ page title="Address Book" language="C#" masterpagefile="~/Templates/masterPageDefault.master" autoeventwireup="true" CodeBehind="addressbooknew.aspx.cs" Inherits="ePrint.WebStore.account.addressbooknew" enableEventValidation="false" viewStateEncryptionMode="Never" %>



<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <script src="../js/Account.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="accountInfoMain_div">
        <div id="accountInfo_background">
            <div id="accountInfoContent_div">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right_withBrderLft">
                    <div id="DivLblErrorMsg" runat="server" align="Center" class="DivLblErrorMsg">
                        <asp:Label ID="LblErrorMsg" runat="server" CssClass="LblErrorMsg" Text="Your last edit profile approval is pending"></asp:Label>
                    </div>
                    <div id="addressbook_div">
                        <div id="addressbook_heading" class="Header_Background accountclearleft20">
                            <div id="addressbookheading_left">
                                <strong>
                                    <asp:Label ID="lbl_addressHeader" runat="server" Text="Add New Address"></asp:Label>
                                </strong>
                            </div>
                            <div id="addressbookheading_right">
                            </div>
                        </div>
                        <div id="addressbook_Content_top">
                            <div id="addressbook_Content_left_header_top">
                                <div>
                                    <%=objLanguage.GetLanguageConversion("Contact_Information") %>
                                </div>
                            </div>
                            <div id="addressbook_Content_left_top">
                                <div id="div_lbladdressLabel" runat="server" class="DisplayBlock">
                                    <asp:Label ID="lbl_addressLabel" runat="server" Text="Address Label"></asp:Label><br />
                                    <asp:TextBox ID="txt_addressLabel" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox><br />
                                    <asp:Label ID="lbl_addressLabel_note" runat="server" Text="eg:My Home address"></asp:Label>
                                </div>
                                <div id="div_lblfirstName" runat="server" class="DisplayNone">
                                    <asp:Label ID="AddressLabel" runat="server" Text="First Name "></asp:Label>
                                    <label id="lbl_starColor" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_firstName" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox><br />
                                </div>
                                <div>
                                    <asp:Label ID="lbl_telephone" runat="server" Text="Telephone "></asp:Label>
                                    <label id="Label6" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_telephone" runat="server" class="ws_txtWidth260" TabIndex="3"></asp:TextBox><br />
                                    <div id="divTelephone" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_email" runat="server" Text="Email "></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txt_email" runat="server" class="ws_txtWidth260" TabIndex="4"></asp:TextBox><br />
                                </div>
                            </div>
                            <div id="addressbook_Content_right_top">
                                <div id="div_lbllastName" runat="server" class="DisplayNone">
                                    <asp:Label ID="lbl_lastName" runat="server" Text="Last Name "></asp:Label>
                                    <label id="Label3" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_lastName" runat="server" class="ws_txtWidth260" TabIndex="2"></asp:TextBox>
                                    <br />
                                </div>
                                <div>
                                    <asp:Label ID="lbl_fax" runat="server" Text="Fax "></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txt_fax" runat="server" class="ws_txtWidth260" TabIndex="2"></asp:TextBox>
                                </div>
                                <div id="divCountry">
                                    <asp:Label ID="lbl_country" runat="server" Text="Country "></asp:Label>
                                    <label id="Label5" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:DropDownList ID="ddl_Country" runat="server" class="ddlWidth270" TabIndex="4">
                                    </asp:DropDownList>
                                    <br />
                                    <div id="div5" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="addressbook_Content_bottom">
                            <div id="addressbook_Content_left_header_bottom">
                                <strong>
                                    <%=objLanguage.GetLanguageConversion("Address") %>
                                </strong>
                            </div>
                            <div id="addressbook_Content_left_bottom">
                                <div>
                                    <asp:Label ID="lbl_Address1" runat="server" Text="Address "></asp:Label>
                                    <label id="lblMandAdd1" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_address" runat="server" class="ws_txtWidth260" TabIndex="5"></asp:TextBox><br />
                                    <div id="divAdd1" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_Address2" runat="server" Text="Address "></asp:Label>
                                    <label id="lblMandAdd2" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_address2" runat="server" class="ws_txtWidth260" TabIndex="5"></asp:TextBox><br />
                                    <div id="divAdd2" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_Address3" runat="server" Text="City "></asp:Label>
                                    <label id="lblMandAdd3" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_city" runat="server" class="ws_txtWidth260" TabIndex="6"></asp:TextBox><br />
                                    <div id="divAdd3" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div id="createAccount_content_bottom_left">
                                    <a href="#" onclick="RedirectToPage()" class="anchorColor"><small>« </small>
                                        <%=objLanguage.GetLanguageConversion("Back") %></a>
                                </div>
                            </div>
                            <div id="addressbook_Content_right_bottom">
                                <div>
                                    <asp:Label ID="lbl_Address4" runat="server" Text="State "></asp:Label>
                                    <label id="lblMandAdd4" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_state" runat="server" class="ws_txtWidth260" TabIndex="7"></asp:TextBox><br />
                                    <div id="divAdd4" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_Address5" runat="server" Text="ZipCode"></asp:Label>
                                    <label id="lblMandAdd5" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_zipCode" runat="server" class="ws_txtWidth260" TabIndex="8"></asp:TextBox><br />
                                    <div id="divAdd5" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div id="DivApproverEmail" runat="server">
                                    <asp:Label ID="Label7" runat="server" Text="Approver Email"></asp:Label>
                                    <label id="Label8" class="mandatoryField">
                                        *</label><br />
                                    <asp:TextBox ID="txtApproverEmail" runat="server" class="ws_txtWidth260" TabIndex="4"></asp:TextBox>
                                    <span id="SpnApproverEmailan" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span> <span id="RegularExpressionValidator1"
                                            class="DisplayNone ColorRed">
                                            <%=objLanguage.GetLanguageConversion("Email_Address_Example")%></span>
                                    <asp:HiddenField ID="hdnApproverID" runat="server" />
                                    <span id="Span1" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                </div>
                                <div>
                                    <asp:Label ID="lblReqiEmail" runat="server" Visible="false" CssClass="ColorRed" Text="designated approver email not contains in this Account"></asp:Label>
                                </div>
                                <div id="chk_address_div" style="display: none;">
                                    <asp:CheckBox ID="chk_billing_address" runat="server" TabIndex="10" Text=" &nbsp;Use above address as my default Invoice address " /><br />
                                    <br />
                                    <asp:Label ID="lblDefaultBilling" runat="server" CssClass="DisplayNone"></asp:Label>
                                    <asp:CheckBox ID="chk_shipping_address" runat="server" TabIndex="11" Text="&nbsp; Use above address as my default Delivery Address" />
                                    <strong>
                                        <asp:Label ID="lblDefaultShipping" runat="server" CssClass="DisplayNone"></asp:Label></strong>
                                </div>
                                <div id="createAccount_content_bottom" class="clearTop">
                                    <label id="Label29" class="mandatoryField floatLeft">
                                        *
                                        <%=objLanguage.GetLanguageConversion("Required_Fields")%></label>
                                </div>
                                <br />
                                <div id="div_btnsave">
                                    <asp:Button ID="btnUpdateAddress" runat="server" class="x-btnpro Grey main" TabIndex="12"
                                        Text="Save Address" OnClick="OnClick_btnUpdateAddress" OnClientClick="javascript:return Validate();" />
                                </div>
                                <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                    <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div class="clearBoth">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:HiddenField runat="server" ID="hdnIsMandAdd1" Value="" />
        <asp:HiddenField runat="server" ID="hdnIsMandAdd2" Value="" />
        <asp:HiddenField runat="server" ID="hdnIsMandAdd3" Value="" />
        <asp:HiddenField runat="server" ID="hdnIsMandAdd4" Value="" />
        <asp:HiddenField runat="server" ID="hdnIsMandAdd5" Value="" />
        <asp:HiddenField runat="server" ID="hdnValidation" Value="" />
    </div>
    <script type="text/javascript" language="javascript">
        var strSitepath = '<%=strSitepath %>';
    </script>
    <script type="text/javascript" language="javascript">

        var txt_firstName = document.getElementById("<%=txt_firstName.ClientID %>");
        var txt_lastName = document.getElementById("<%=txt_lastName.ClientID %>");
        var txt_telephone = document.getElementById("<%=txt_telephone.ClientID %>");
        var txt_address = document.getElementById("<%=txt_address.ClientID %>");
        var txt_zipCode = document.getElementById("<%=txt_zipCode.ClientID %>");
        var txt_city = document.getElementById("<%=txt_city.ClientID %>");
        var ddl_Country = document.getElementById("<%=ddl_Country.ClientID %>");
        var txt_state = document.getElementById("<%=txt_state.ClientID %>");
        var txtApproverEmail = document.getElementById("<%=txtApproverEmail.ClientID %>");
        var RedirectTo = '<%=RedirectTo %>';
        var Rewritemodule = '<%=Rewritemodule %>';
        var CompanyID = '<%=companyID %>';
        var IsPrivate_SystemName = '<%=IsPrivate_SystemName %>';
        var div_chk_billing_address = document.getElementById("div_chk_billing_address");

        function RegionalSettingCountry() {
            AutoFill.Get_RegionalSetting_Country(CompanyID, GetRegionalSetting, onTimeout, onError);
        }

        function onTimeout(err) { }
        function onError(err) { }

        function GetRegionalSetting(RegionalSetting_Country) {
            ddl_Country.selectedIndex = RegionalSetting_Country;
        }

        function ValidateExistanceOfEmail(Value, AccountID) {
            AutoFill.ExistanceOfEmail(Value, AccountID, GetApproverID, onTimeout, onError);
        }
        function GetApproverID(result) {
            if (result != 0) {
                document.getElementById("<%=hdnApproverID.ClientID %>").value = result;
                return true;
            }
            else {
                //alert("designated approver email not contains in this Account");
                alert('<%=objLanguage.GetLanguageConversion("designated_approver_email_not_contains_in_this_Account") %>');
                return false;
            }
        }

        if (RedirectTo != 'add')
            RegionalSettingCountry();

        function IfB2B_System() {
            if (IsPrivate_SystemName == "True") {
                div_chk_billing_address.style.display = "block";
            }
        }
        IfB2B_System();
        
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
