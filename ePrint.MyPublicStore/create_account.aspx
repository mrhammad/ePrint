<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_account.aspx.cs" Inherits="ePrint.MyPublicStore.create_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/StoreAutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="createAccountMain_div" class="contentArea_Background">
        <div class="navigation_div">
            <a href="<%=strSitepath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="<%=strSitepath %>login.aspx">
                <%=objLanguage.GetLanguageConversion("Login") %></a> >
            <%=objLanguage.GetLanguageConversion("Create_An_Account")%>
        </div>
        <div id="createAccount_background">
            <div id="createAccount_area">
                <div id="createAccount_header" class="Header_Background">
                    <strong>
                        <%=objLanguage.GetLanguageConversion("Create_An_Account") %>
                    </strong>
                </div>
                <div id="createAccount_content">
                    <div id="createAccount_content_left">
                        <div>
                            <br />
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Personal_Information") %>
                            </strong>
                        </div>
                        <div>
                            <asp:Label ID="Label10" runat="server" Text="Company Name "><%=objLanguage.GetLanguageConversion("Company_Name") %></asp:Label>
                            <br />
                            <asp:TextBox ID="txtCompanyName" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox>
                        </div>
                        <div>
                            <asp:Label ID="lbl_firstName" runat="server" Text="First Name "><%=objLanguage.GetLanguageConversion("First_Name") %></asp:Label>
                            <label id="lbl_starColor" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txt_firstName" runat="server" class="ws_txtWidth260" TabIndex="2"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="req_firstName" runat="server" ControlToValidate="txt_firstName"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                            <br />
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Contact_Information") %></strong>
                        </div>
                        <b>
                            <asp:Label ID="Label5" runat="server" Text="Invoice Information "><%=objLanguage.GetLanguageConversion("Invoice_Information") %></asp:Label></b>
                        <div>
                            <asp:Label ID="lbl_BillAddress1" runat="server" Text="Address "></asp:Label>
                            <label runat="server" id="lblAdd1" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txtBillAddress1" runat="server" class="ws_txtWidth260" TabIndex="4"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqAddress1" runat="server" ControlToValidate="txtBillAddress1"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_BillAddress2" runat="server" Text="Address "></asp:Label>
                            <label runat="server" id="lblAdd2" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txtBillAddress2" runat="server" class="ws_txtWidth260" TabIndex="4"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqAddress2" runat="server" ControlToValidate="txtBillAddress2"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_BillCity" runat="server" Text="City  "></asp:Label>
                            <label runat="server" id="lblAdd3" class="mandatoryField">
                                *</label><br />
                            <asp:TextBox ID="txtBillCity" runat="server" class="ws_txtWidth260" TabIndex="5"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqAddress3" runat="server" ControlToValidate="txtBillCity"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_BillState" runat="server" Text="State  "></asp:Label>
                            <label runat="server" id="lblAdd4" class="mandatoryField">
                                *</label><br />
                            <asp:TextBox ID="txtBillState" runat="server" class="ws_txtWidth260" TabIndex="6"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqAddress4" runat="server" ControlToValidate="txtBillState"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lblBillZipCode" runat="server" Text="Zip/Postal Code "></asp:Label>
                            <label runat="server" id="lblAdd5" class="mandatoryField">
                                *</label><br />
                            <asp:TextBox ID="txtBillZipCode" runat="server" class="ws_txtWidth260" TabIndex="7"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqAddress5" runat="server" ControlToValidate="txtBillZipCode"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lblBillCountry" runat="server" Text="Country "><%=objLanguage.GetLanguageConversion("Country") %></asp:Label>
                            <label id="Label15" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:DropDownList ID="ddlBillCountry" runat="server" class="ddlWidth270" TabIndex="8">
                            </asp:DropDownList>
                            <br />
                            <span id="spn_ddlBillCountry" class="mandatoryField displayNone">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Country") %></span>
                            <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="ddlBillCountry"
                                ErrorMessage="Please select country" SetFocusOnError="true" ValidationGroup="CreateAccount"
                                InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lblBillTelephone" runat="server" Text="Telephone "><%=objLanguage.GetLanguageConversion("Telephone") %></asp:Label>
                            <label id="Label6" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txtBillTelephone" runat="server" class="ws_txtWidth260" TabIndex="9"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqTelephone" runat="server" ControlToValidate="txtBillTelephone"
                                ErrorMessage="This is a required field." ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lblBillFax" runat="server" Text="Fax "><%=objLanguage.GetLanguageConversion("Fax") %></asp:Label>
                            <%--<label id="Label7" class="mandatoryField">*</label>--%><br />
                            <asp:TextBox ID="txtBillFax" runat="server" class="ws_txtWidth260" TabIndex="10"></asp:TextBox><br />
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBillFax"
                                ErrorMessage="This is a required field." ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div>
                            <asp:CheckBox ID="chkCopyAdd" runat="server" Checked="false" onclick="javascript:CopyToShip();"
                                Text=" Copy to Delivery Address" />
                            <div class="paddingTop5">
                                <asp:CheckBox ID="chkAddEmilDmc" runat="server" Checked="true" Text="  Add Email to EDM Database" />
                            </div>
                        </div>
                        <div>
                            <br />
                            <strong>
                                <%=objLanguage.GetLanguageConversion("Login_Information") %>
                            </strong>
                        </div>
                        <div>
                            <asp:Label ID="lbl_email" runat="server" Text="Email Address "><%=objLanguage.GetLanguageConversion("Email_Address") %></asp:Label>
                            <label id="Label1" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txt_email" runat="server" class="ws_txtWidth260" TabIndex="18"></asp:TextBox><br />
                            <%--onkeyup="CheckEmailID(this.value);"
                                onblur="CheckEmailID(this.value);"--%>
                            <asp:RequiredFieldValidator ID="reqemail" runat="server" ControlToValidate="txt_email"
                                Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="CreateAccount"
                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
                                Display="Dynamic" ErrorMessage="Please enter a valid email address. For example johndoe@domain.com"
                                ValidationExpression="^((['\w])*[0-9a-zA-Z]([-.'\w]*[0-9a-zA-Z])*(['\w])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="cvEmailID" runat="server" ErrorMessage="EmailID already exists"
                                Display="Dynamic" ControlToValidate="txt_email" ValidateEmptyText="false" ValidationGroup="CreateAccount"
                                OnServerValidate="custEmailID_Duplicacy_ServerValidate"></asp:CustomValidator>
                            <%--ClientValidationFunction="ClientValidate"--%>
                            <span id="spn_txt_email">
                                <%=objLanguage.GetLanguageConversion("EmailID_already_exists")%></span>
                            <br />
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_password" runat="server" Text="Password "><%=objLanguage.GetLanguageConversion("Password")%></asp:Label>
                            <label id="Label2" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txtpassword" runat="server" class="ws_txtWidth260" TabIndex="19"
                                TextMode="Password"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqpassword" runat="server" ControlToValidate="txtpassword"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div id="createAccount_content_right">
                        <div>
                        </div>
                        <div>
                        </div>
                        <div>
                            <asp:Label ID="lbl_lastName" runat="server" Text="Last Name "><%=objLanguage.GetLanguageConversion("Last_Name") %></asp:Label>
                            <label id="Label3" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txt_lastName" runat="server" class="ws_txtWidth260" TabIndex="3"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqlastName" runat="server" ControlToValidate="txt_lastName"
                                SetFocusOnError="true" Display="Dynamic" ErrorMessage="This is a required field."
                                ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div>
                        </div>
                        <%--Shipping information--%>
                        <b>
                            <asp:Label ID="Label9" runat="server" Text="Delivery Information "><%=objLanguage.GetLanguageConversion("Delivery_Information") %></asp:Label></b>
                        <div>
                            <asp:Label ID="lbl_ShipAddress1" runat="server" Text="Address "></asp:Label>
                            <label id="lbl_ShipAdd1" runat="server" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txtShipAddress1" runat="server" class="ws_txtWidth260" TabIndex="11"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="req_ShipAddress1" runat="server" ControlToValidate="txtShipAddress1"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_ShipAddress2" runat="server" Text="Address "></asp:Label>
                            <label id="lbl_ShipAdd2" runat="server" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txtShipAddress2" runat="server" class="ws_txtWidth260" TabIndex="11"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="req_ShipAddress2" runat="server" ControlToValidate="txtShipAddress2"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_ShipCity" runat="server" Text="City  "></asp:Label>
                            <label id="lbl_ShipAdd3" runat="server" class="mandatoryField">
                                *</label><br />
                            <asp:TextBox ID="txtShipCity" runat="server" class="ws_txtWidth260" TabIndex="12"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="req_ShipAddress3" runat="server" ControlToValidate="txtShipCity"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_ShipState" runat="server" Text="State  "></asp:Label>
                            <label id="lbl_ShipAdd4" runat="server" class="mandatoryField">
                                *</label><br />
                            <asp:TextBox ID="txtShipState" runat="server" class="ws_txtWidth260" TabIndex="13"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="req_ShipAddress4" runat="server" ControlToValidate="txtShipState"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_ShipZipCode" runat="server" Text="Zip/Postal Code "></asp:Label>
                            <label id="lbl_ShipAdd5" runat="server" class="mandatoryField">
                                *</label><br />
                            <asp:TextBox ID="txtShipZipCode" runat="server" class="ws_txtWidth260" TabIndex="14"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="req_ShipAddress5" runat="server" ControlToValidate="txtShipZipCode"
                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lblShipCountry" runat="server" Text="Country "><%=objLanguage.GetLanguageConversion("Country") %></asp:Label>
                            <label id="Label20" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:DropDownList ID="ddlShipCountry" runat="server" class="ddlWidth270" TabIndex="15">
                            </asp:DropDownList>
                            <br />
                            <span id="spn_ddlShipCountry" class="mandatoryField displayNone">
                                <%=objLanguage.GetLanguageConversion("Please_Select_Country") %></span>
                            <asp:RequiredFieldValidator ID="req_ShipCountry" runat="server" ControlToValidate="ddlShipCountry"
                                ErrorMessage="Please select country" SetFocusOnError="true" ValidationGroup="CreateAccount"
                                InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lblShipTelephone" runat="server" Text="Telephone "><%=objLanguage.GetLanguageConversion("Telephone") %></asp:Label>
                            <label id="Label14" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txtShipTelephone" runat="server" class="ws_txtWidth260" TabIndex="16"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="req_ShipTelephone" runat="server" ControlToValidate="txtShipTelephone"
                                ErrorMessage="This is a required field." ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lblShipFax" runat="server" Text="Fax "><%=objLanguage.GetLanguageConversion("Fax") %></asp:Label><br />
                            <asp:TextBox ID="txtShipFax" runat="server" class="ws_txtWidth260" TabIndex="17"></asp:TextBox><br />
                        </div>
                        <%--Shipping information--%>
                        <div>
                        </div>
                        <div>
                        </div>
                        <div>
                        </div>
                        <div style="margin-top: 8px;">
                            <asp:Label ID="lbl_confirmPassword" runat="server" Text="Confirm Password "><%=objLanguage.GetLanguageConversion("Confirm_Password") %></asp:Label>
                            <label id="Label4" class="mandatoryField">
                                *</label>
                            <br />
                            <asp:TextBox ID="txt_confirmPassword" runat="server" class="ws_txtWidth260" TabIndex="20"
                                TextMode="Password"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="reqconfirmPassword" runat="server" ControlToValidate="txt_confirmPassword"
                                Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword"
                                ControlToValidate="txt_confirmPassword" Display="Dynamic" ErrorMessage="Please make sure your passwords match."
                                ValidationGroup="CreateAccount"></asp:CompareValidator>
                        </div>
                    </div>
                </div>
                <div class="clearBoth">
                </div>
                <div id="createAccount_content_bottom">
                    <div id="createAccount_content_bottom_left">
                        <br />
                        <br />
                        <a href="login.aspx"><small>« </small>
                            <%=objLanguage.GetLanguageConversion("Back") %></a>
                    </div>
                    <div id="createAccount_content_bottom_right">
                        <label id="Label29" class="mandatoryField">
                            *
                            <%=objLanguage.GetLanguageConversion("Required_Fields")%></label>
                        <br />
                        <br />
                        <div class="createaccount_btn_Div">
                            <div id="div_CreateAccount">
                                <asp:Button ID="btn_createAccount" runat="server" class="WS_Buttons_Style" TabIndex="21"
                                    Text="Create an Account" ValidationGroup="CreateAccount" OnClick="Onclick_btnCreateAccount"
                                    OnClientClick="javascript:if(Page_ClientValidate())loadingimage(this.id,'div_btneditsaveprocess');" />
                            </div>
                            <div id="div_btneditsaveprocess" class="displayNone textalignCenter WS_Buttons_Style">
                                <img src="<%=strSitepath%>images/StoreImages/radimg1.gif" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
                    <%--OnClientClick="javascript:return CountryValidate();"--%>
                </div>
                <div class="clearBoth">
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

        var CompanyID = '<%=CompanyID %>';

        var txt_email = document.getElementById("<%=txt_email.ClientID %>");
        var txtBillAddress1 = document.getElementById("<%= txtBillAddress1.ClientID%>");
        var txtBillAddress2 = document.getElementById("<%= txtBillAddress2.ClientID%>");
        var txtBillCity = document.getElementById("<%= txtBillCity.ClientID%>");
        var txtBillState = document.getElementById("<%= txtBillState.ClientID%>");
        var txtBillZipCode = document.getElementById("<%= txtBillZipCode.ClientID%>");
        var ddlBillCountry = document.getElementById("<%= ddlBillCountry.ClientID%>");
        var txtBillTelephone = document.getElementById("<%= txtBillTelephone.ClientID%>");
        var txtBillFax = document.getElementById("<%= txtBillFax.ClientID%>");

        var txtShipAddress1 = document.getElementById("<%= txtShipAddress1.ClientID%>");
        var txtShipAddress2 = document.getElementById("<%= txtShipAddress2.ClientID%>");
        var txtShipCity = document.getElementById("<%= txtShipCity.ClientID%>");
        var txtShipState = document.getElementById("<%= txtShipState.ClientID%>");
        var txtShipZipCode = document.getElementById("<%= txtShipZipCode.ClientID%>");
        var ddlShipCountry = document.getElementById("<%= ddlShipCountry.ClientID%>");
        var txtShipTelephone = document.getElementById("<%= txtShipTelephone.ClientID%>");
        var txtShipFax = document.getElementById("<%= txtShipFax.ClientID%>");

        var chkCopyAdd = document.getElementById("<%=chkCopyAdd.ClientID %>");
        var spn_ddlBillCountry = document.getElementById("spn_ddlBillCountry");
        var spn_ddlShipCountry = document.getElementById("spn_ddlShipCountry");

        //******* funcn to check EmailID duplicacy *********////
        var IsDuplicate = false;
        function CheckEmailID(val1) {
            if (val1 != '') {
                var val = val1;
                PageMethods.Check_EmailID_Duplicacy(txt_email.value, ShowMsgDigital, ShowMsg_Failure);
            }
        }
        function ShowMsgDigital(result) {
            $get('spn_txt_email').style.display = "none";
            if (result == -1) {
                $get('spn_txt_email').style.display = "block";
                IsDuplicate = true;
            }
            else {
                IsDuplicate = false;
            }
        }

        // Failure callback method
        function ShowMsg_Failure(error) {

        }
        //*******End of funcn to check EmailID duplicacy*********////

        function CountryValidate() {
            if (ddlBillCountry.options[ddlBillCountry.selectedIndex].value == 0) {
                spn_ddlBillCountry.style.display = "block";
                return false;
            }
            else {
                spn_ddlBillCountry.style.display = "none";
                return true;
            }
        }

        function CopyToShip() {
            var ddlCountryIndex = '<%=ddlCountryIndex %>';

            if (chkCopyAdd.checked) {
                txtShipAddress1.value = txtBillAddress1.value;
                txtShipAddress2.value = txtBillAddress2.value;
                txtShipCity.value = txtBillCity.value;
                txtShipState.value = txtBillState.value;
                txtShipZipCode.value = txtBillZipCode.value;
                ddlShipCountry.selectedIndex = ddlBillCountry.selectedIndex;
                txtShipTelephone.value = txtBillTelephone.value;
                txtShipFax.value = txtBillFax.value;
            }
            else {
                txtShipAddress1.value = "";
                txtShipAddress2.value = "";
                txtShipCity.value = "";
                txtShipState.value = "";
                txtShipZipCode.value = "";
                txtShipTelephone.value = "";
                txtShipFax.value = "";
                ddlShipCountry.selectedIndex = ddlCountryIndex;
            }
        }

        //        function RegionalSettingCountry() {
        //            AutoFill.Get_RegionalSetting_Country(CompanyID, GetRegionalSetting, onTimeout, onError);
        //        }

        //        function onTimeout(err) { }
        //        function onError(err) { }

        //        function GetRegionalSetting(RegionalSetting_Country) {
        //           
        //            ddlBillCountry.selectedIndex = RegionalSetting_Country;
        //            ddlShipCountry.selectedIndex = RegionalSetting_Country;
        //        }

        //        RegionalSettingCountry();
        
    </script>
</asp:Content>


