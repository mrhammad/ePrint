<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addressbooknew.aspx.cs" Inherits="ePrint.MyPublicStore.account.addressbooknew" masterpagefile="~/Templates/masterPageDefault.master" %>

<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="accountInfoMain_div" class="contentArea_Background">
        <div class="navigation_div">
            <a href="<%=strSitepath%>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="<%=strSitepath%>account/account<%=FileExtension %>">
                <%=objLanguage.GetLanguageConversion("My_Account") %></a> >
            <asp:Label ID="lbl_PageName" runat="server" Text="Add New Address"></asp:Label>
        </div>
        <div id="accountInfo_background">
            <div id="accountInfoContent_div">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right">
                    <div id="addressbook_div">
                        <div id="addressbook_heading" class="Header_Background">
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
                                <strong>
                                    <%=objLanguage.GetLanguageConversion("Contact_Information") %>
                                </strong>
                            </div>
                            <div id="addressbook_Content_left_top">
                                <div id="div_lbladdressLabel" runat="server" class="displayBlock">
                                    <asp:Label ID="lbl_addressLabel" runat="server" Text="Address Label "><%=objLanguage.GetLanguageConversion("Address_Label") %></asp:Label>
                                    <asp:TextBox ID="txt_addressLabel" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox><br />
                                    <asp:Label ID="lbl_addressLabel_note" runat="server" Text="eg:My Home address" CssClass="colorSilver"><%=objLanguage.GetLanguageConversion("Address_Example_Note")%></asp:Label>
                                </div>
                                <div id="div_lblfirstName" runat="server" class="displayNone">
                                    <asp:Label ID="AddressLabel" runat="server" Text="First Name "><%=objLanguage.GetLanguageConversion("First_Name") %></asp:Label>
                                    <label id="lbl_starColor" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_firstName" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox><br />
                                </div>
                                <div>
                                    <asp:Label ID="lbl_telephone" runat="server" Text="Telephone "><%=objLanguage.GetLanguageConversion("Telephone") %></asp:Label>
                                    <label id="Label6" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_telephone" runat="server" class="ws_txtWidth260" TabIndex="3"></asp:TextBox><br />
                                    <div id="divTelephone" class="displayNone colorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                            </div>
                            <div id="addressbook_Content_right_top">
                                <div id="div_lbllastName" runat="server" class="displayNone">
                                    <asp:Label ID="lbl_lastName" runat="server" Text="Last Name "><%=objLanguage.GetLanguageConversion("Last_Name") %></asp:Label>
                                    <label id="Label3" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_lastName" runat="server" class="ws_txtWidth260" TabIndex="2"></asp:TextBox>
                                    <br />
                                </div>
                                <div>
                                    <asp:Label ID="lbl_fax" runat="server" Text="Fax "><%=objLanguage.GetLanguageConversion("Fax") %></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txt_fax" runat="server" class="ws_txtWidth260" TabIndex="4"></asp:TextBox>
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
                                    <div id="divAdd1" class="displayNone colorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_Address2" runat="server" Text="Address "></asp:Label>
                                    <label id="lblMandAdd2" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_address2" runat="server" class="ws_txtWidth260" TabIndex="5"></asp:TextBox><br />
                                    <div id="divAdd2" class="displayNone colorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_Address3" runat="server" Text="City "></asp:Label>
                                    <label id="lblMandAdd3" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_city" runat="server" class="ws_txtWidth260" TabIndex="6"></asp:TextBox><br />
                                    <div id="divAdd3" class="displayNone colorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_Address4" runat="server" Text="State "></asp:Label>
                                    <label id="lblMandAdd4" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_state" runat="server" class="ws_txtWidth260" TabIndex="7"></asp:TextBox><br />
                                    <div id="divAdd4" class="displayNone colorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                            </div>
                            <div id="addressbook_Content_right_bottom">
                                <div>
                                    <asp:Label ID="lbl_Address5" runat="server" Text="ZipCode"></asp:Label>
                                    <label id="lblMandAdd5" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:TextBox ID="txt_zipCode" runat="server" class="ws_txtWidth260" TabIndex="8"></asp:TextBox><br />
                                    <div id="divAdd5" class="displayNone colorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></div>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_country" runat="server" Text="Country "><%=objLanguage.GetLanguageConversion("Country") %></asp:Label>
                                    <label id="Label5" runat="server" class="mandatoryField">
                                        *</label>
                                    <br />
                                    <asp:DropDownList ID="ddl_Country" runat="server" class="ddlWidth270" TabIndex="9">
                                    </asp:DropDownList>
                                    <br />
                                    <div id="div5" class="displayNone colorRed">
                                        <%=objLanguage.GetLanguageConversion("Please_Select_Country")%></div>
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="chk_address_div">
                            <div id="div_chk_billing_address">
                                <asp:CheckBox ID="chk_billing_address" runat="server" TabIndex="10" Text=" Use above address as my default Invoice address " /><br />
                            </div>
                            <strong>
                                <asp:Label ID="lblDefaultBilling" runat="server" CssClass="displayNone"></asp:Label></strong>
                            <asp:CheckBox ID="chk_shipping_address" runat="server" TabIndex="11" Text=" Use above address as my default Delivery Address" />
                            <strong>
                                <asp:Label ID="lblDefaultShipping" runat="server" CssClass="displayNone"></asp:Label></strong>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="createAccount_content_bottom">
                            <div id="createAccount_content_bottom_left">
                                <br />
                                <br />
                                <a href="#" onclick="RedirectToPage()" class="anchorColor"><small>« </small>
                                    <%=objLanguage.GetLanguageConversion("Back") %></a>
                            </div>
                            <div id="createAccount_content_bottom_right">
                                <label id="Label29" class="mandatoryField">
                                    *
                                    <%=objLanguage.GetLanguageConversion("Required_Fields")%></label>
                                <br />
                                <br />
                                <span>
                                    <asp:Button ID="btnUpdateAddress" runat="server" class="WS_Buttons_Style" TabIndex="12"
                                        Text="Save Address" OnClick="OnClick_btnUpdateAddress" OnClientClick="javascript:return Validate();" /></span>
                            </div>
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
    </div>
    <script type="text/javascript" language="javascript">

        var txt_firstName = document.getElementById("<%=txt_firstName.ClientID %>");
        var txt_lastName = document.getElementById("<%=txt_lastName.ClientID %>");
        var txt_telephone = document.getElementById("<%=txt_telephone.ClientID %>");
        var txt_address = document.getElementById("<%=txt_address.ClientID %>");
        var txt_zipCode = document.getElementById("<%=txt_zipCode.ClientID %>");
        var txt_city = document.getElementById("<%=txt_city.ClientID %>");
        var ddl_Country = document.getElementById("<%=ddl_Country.ClientID %>");
        var txt_state = document.getElementById("<%=txt_state.ClientID %>");

        var RedirectTo = '<%=RedirectTo %>';
        var Rewritemodule = '<%=Rewritemodule %>';
        var CompanyID = '<%=companyID %>';

        var IsPrivate_SystemName = '<%=IsPrivate_SystemName %>';
        var div_chk_billing_address = document.getElementById("div_chk_billing_address");

        function RedirectToPage() {
            if (Rewritemodule.toLowerCase() == 'on') {
                if (RedirectTo.toLowerCase() == 'acc')
                    window.location = "<%=strSitepath %>" + "account/account" + FileExtension;
                else
                    window.location = "<%=strSitepath %>" + "account/addressbook" + FileExtension;
            }
            else {
                if (RedirectTo.toLowerCase() == 'add')
                    window.location = "<%=strSitepath%>" + "account/account.aspx";
                else
                    window.location = "<%=strSitepath%>" + "account/addressbook.aspx";
            }
        }

        function RegionalSettingCountry() {
            AutoFill.Get_RegionalSetting_Country(CompanyID, GetRegionalSetting, onTimeout, onError);
        }

        function onTimeout(err) { }
        function onError(err) { }

        function GetRegionalSetting(RegionalSetting_Country) {
            ddl_Country.selectedIndex = RegionalSetting_Country;
        }

        if (RedirectTo != 'add')
            RegionalSettingCountry();

        function IfB2B_System() {
            if (IsPrivate_SystemName == "True") {
                div_chk_billing_address.style.display = "none";
            }
        }
        IfB2B_System();
        
    </script>
    <script type="text/javascript">
        function Validate() {

            var txtTel = document.getElementById("ctl00_ContentPlaceHolder1_txt_telephone");
            var ddlCountry = document.getElementById("ctl00_ContentPlaceHolder1_ddl_Country");

            var txtAdd1 = document.getElementById("ctl00_ContentPlaceHolder1_txt_address");
            var txtAdd2 = document.getElementById("ctl00_ContentPlaceHolder1_txt_address2");
            var txtAdd3 = document.getElementById("ctl00_ContentPlaceHolder1_txt_city");
            var txtAdd4 = document.getElementById("ctl00_ContentPlaceHolder1_txt_state");
            var txtAdd5 = document.getElementById("ctl00_ContentPlaceHolder1_txt_zipCode");


            var hdnIsMandAdd1 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd1");
            var hdnIsMandAdd2 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd2");
            var hdnIsMandAdd3 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd3");
            var hdnIsMandAdd4 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd4");
            var hdnIsMandAdd5 = document.getElementById("ctl00_ContentPlaceHolder1_hdnIsMandAdd5");


            if (txtTel.value == "" || txtTel.value == null) {
                document.getElementById("divTelephone").style.display = "block";
                txtTel.focus();
                return false;
            }
            if (hdnIsMandAdd1.value == "1" && (txtAdd1.value == "" || txtAdd1.value == null)) {
                document.getElementById("divAdd1").style.display = "block";
                txtAdd1.focus();
                return false;
            }
            if (hdnIsMandAdd2.value == "1" && (txtAdd2.value == "" || txtAdd2.value == null)) {
                document.getElementById("divAdd2").style.display = "block";
                txtAdd2.focus();
                return false;
            }

            if (hdnIsMandAdd3.value == "1" && (txtAdd3.value == "" || txtAdd3.value == null)) {
                document.getElementById("divAdd3").style.display = "block";
                txtAdd3.focus();
                return false;
            }

            if (hdnIsMandAdd4.value == "1" && (txtAdd4.value == "" || txtAdd4.value == null)) {
                document.getElementById("divAdd4").style.display = "block";
                txtAdd4.focus();
                return false;
            }

            if (hdnIsMandAdd5.value == "1" && (txtAdd5.value == "" || txtAdd5.value == null)) {
                document.getElementById("divAdd5").style.display = "block";
                txtAdd5.focus();
                return false;
            }
            if (ddlCountry.options[ddlCountry.selectedIndex].value == "0") {
                document.getElementById("div5").style.display = "block";
                ddlCountry.focus();
                return false;
            }

            return true;
        }

        function HideShowError(divID) {
            document.getElementById(divID).style.display = "none";
        }
        
    </script>
</asp:Content>


