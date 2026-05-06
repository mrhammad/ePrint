<%@ page title="" language="C#" masterpagefile="~/templates/MasterPageDefault.master" autoeventwireup="true"  CodeBehind="B2B_Registration.aspx.cs" Inherits="ePrint.WebStore.B2B_Registration" enableEventValidation="false" viewStateEncryptionMode="Never" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="<%#strSitePath%>js/Account.js?VN='<%#VersionNumber%>'"></script>
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript" language="javascript">
        var asyncState = true;
        XMLHttpRequest.prototype.original_open = XMLHttpRequest.prototype.open;
        XMLHttpRequest.prototype.open = function (method, url, async, user, password) {
            async = asyncState;
            var eventArgs = Array.prototype.slice.call(arguments);
            return this.original_open.apply(this, eventArgs);
        }
    </script>
    <div id="div_Registration">
        <table id="tblheaderimage" runat="server">
            <tr>
                <td id="tdheaderimage" runat="server" valign="top">
                    <asp:PlaceHolder ID="ph_headerLeft" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnlMessage" runat="server" Visible="false">
            <table cellpadding="0" cellspacing="0" align="center" id="tb_pnlMessage">
                <tr>
                    <td align="center">
                        <div class="messageboxSessionLogoutNew">
                            <div>
                                <img src="images/StoreImages/Ok-icon.png" />
                                <asp:Label ID="lblRegisterMessage" runat="server" Text="Your registration is pending approval."><%=objLanguage.GetLanguageConversion("Registration_ApprovalPending_Note")%></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="lblRM" runat="server" Text="If you are approved your login details will be sent to you by email."><%=objLanguage.GetLanguageConversion("If_you_are_approved_your_login_details_will_be_sent")%></asp:Label>
                            </div>
                            <div class="paddingTop5 accountclearleft20">
                                <asp:LinkButton ID="LnkBack" runat="server" Text="Click here to go back to Login Page"
                                    CssClass="MouseOver" OnClick="Onclick_LnkBack"><%=objLanguage.GetLanguageConversion("Click_here_to_return_to_Login_screen")%></asp:LinkButton>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlRegister" runat="server" DefaultButton="btn_createAccount">
            <div id="createAccountMain_div">
                <div id="createAccount_background">
                    <div style="width: 100% !important; height: 100% !important; margin-left: 33px">
                        <div id="createAccount_content">
                            <div class="Header_Background">
                                <strong>
                                    <%=objLanguage.GetLanguageConversion("Create_An_Account")%>
                                </strong>
                            </div>
                            <div id="createAccount_content_left" class="clearTop" style="width: 100%; padding-top: 0px;
                                margin-top: 7px">
                                <table id="tblTop" style="width: 100%; border-collapse: separate; margin-bottom: 5px;"
                                    runat="server">
                                    <tr>
                                        <td class="RegisterTdOdd1" style="width: 25.5% !important">
                                            <asp:Label ID="lbl_firstName" CssClass="RegistrationTest" runat="server" Text=""><%=objLanguage.GetLanguageConversion("First_Name") %></asp:Label>
                                            <label id="lbl_starColor" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdEven1">
                                            <asp:TextBox ID="txt_firstName" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="req_firstName" runat="server" ControlToValidate="txt_firstName"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 8%">
                                        </td>
                                        <td class="RegisterTdOdd2" style="width: 24.25% !important; padding-left: 10px;">
                                            <asp:Label ID="lbl_lastName" CssClass="RegistrationTest" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("Last_Name") %></asp:Label>  
                                            <label id="lbl_starColorlastname" class="mandatoryField">
                                                *</label>                                         
                                        </td>
                                        <td class="RegisterTdEven2">
                                            <asp:TextBox ID="txt_lastName" runat="server" class="ws_txtWidth260 regStyle" ValidationGroup="CreateAccount" ClientIDMode="Static" AutoPostBack="false"></asp:TextBox><br />
                                             <asp:RequiredFieldValidator ID="req_lastName" runat="server" ControlToValidate="txt_lastName" 
                                                 ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="width: 28%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="RegisterTdOdd1" id="divDepartmentNameLeft" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td style="width: 144px;">
                                                        <asp:Label ID="lbl_Department" CssClass="RegistrationTest" runat="server" Text=" "></asp:Label>
                                                        <label runat="server" id="lblDeptMandatry" class="mandatoryField">
                                                            *
                                                        </label>
                                                    </td>
                                                    <td style="width: 35px; text-align: center;">
                                                        <input type="image" id="imgAddDepartment" runat="server" src="images/plus.gif" onclick="javascript:slideToggle();return false;"
                                                            title="" style="margin-right: 5px" />
                                                        <asp:HiddenField ID="hdnNewDeptID" runat="server" Value="" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="RegisterTdEven1" colspan="3" style="height: 60px" id="divDepartmentName"
                                            runat="server">
                                            <asp:DropDownList ID="ddl_Department" OnSelectedIndexChanged="ddl_Department_SelectedIndexChanged"
                                                runat="server" CssClass="ddlWidth268 regStyle registerddlSize" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblDepartment" runat="server" Visible="false">
                                            </asp:Label>
                                            <asp:HiddenField ID="HdnDepartmentID" runat="server" />
                                            <asp:HiddenField ID="hdnIsAddDepartment" runat="server" Value="false" />
                                            <br />
                                            <asp:RequiredFieldValidator ID="req_ddldepartment" Style="float: left;" runat="server"
                                                ControlToValidate="ddl_Department" ErrorMessage="This is a required field." SetFocusOnError="true"
                                                ValidationGroup="CreateAccount" InitialValue="0"></asp:RequiredFieldValidator><br />
                                            <div style="width: auto; height: auto; text-align: left; position: relative; top: -11px;"
                                                id="NoteGeneral" runat="server">
                                                <asp:Label ID="lblAddDepartmentNote" runat="server" Text=""></asp:Label>
                                            </div>
                                        </td>
                                        <td class="RegisterTdOdd1" colspan="2" id="tdAddNewDept" runat="server">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <div id="divpopup" style="position: fixed; top: 0; left: 0; opacity: 0.5; background-color: #FFF;
                                    z-index: 1000; display: none">
                                </div>
                                <div id="registrationAddDepartment" style="width: 600px; height: auto; padding: 15px;
                                    display: none; z-index: 2000; background-color: #FFFFFF; position: fixed; top: 50%;
                                    left: 50%; transform: translate(-50%, -50%); -ms-transform: translate(-50%, -50%);
                                    -webkit-transform: translate(-50%, -50%); -moz-transform: translate(-50%, -50%);
                                    -o-transform: translate(-50%, -50%);">
                                    <div style="width: 100%; margin-left: 10px; margin-top: 10px; height: 100%;">
                                        <asp:HiddenField ID="hdnInsertAddress" runat="server" Value="" />
                                        <table style="width: 100%">
                                            <tr>
                                                <td class="RegisterTdPopupLeft" style="height: 22px">
                                                    <asp:Label ID="lbl_DeptName" runat="server" CssClass="RegistrationTest"></asp:Label><span
                                                        style="color: red; padding: 0px; margin: 0px"> *</span>
                                                </td>
                                                <td class="tdPopupRight">
                                                    <asp:TextBox ID="txtDeptName" runat="server" class="ws_txtWidth260 regStylePopup"
                                                        Style="width: 240px !important"></asp:TextBox>
                                                    <br />
                                                    <span id="spnErrorDulicate" style="color: red; display: none"><asp:Label id="lblErrorDuplicateMessage" runat="server" Text=""></asp:Label></span>
                                                    <asp:RequiredFieldValidator ID="rfvDeptName" runat="server" ControlToValidate="txtDeptName"
                                                        ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Delivery"
                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="RegisterTdPopupLeft" style="height: 30px; vertical-align: middle">
                                                    <asp:Label ID="lblDeliveryAddress" runat="server" CssClass="RegistrationTest RegisterBoldText"
                                                        Style="color: #007ED3 !important"><%=objLanguage.GetLanguageConversion("Delivery_Address")%></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="RegisterTdPopupLeft">
                                                    <asp:Label ID="lblDelAddLabel" runat="server" CssClass="RegistrationTest"></asp:Label>
                                                </td>
                                                <td class="tdPopupRight">
                                                    <asp:TextBox ID="txtDelAddLabel" runat="server" class="ws_txtWidth260 regStylePopup"
                                                        Style="width: 240px !important"></asp:TextBox><br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="RegisterTdPopupLeft">
                                                    <table style="width: 100%; margin-top: -7px">
                                                        <tr>
                                                            <td class="RegisterTdAddLeft1">
                                                                <asp:Label ID="lblDelAdd1" runat="server" CssClass="RegistrationTest"></asp:Label>
                                                                <label runat="server" id="lblDelAddMandatory1" class="mandatoryField">
                                                                    *</label>
                                                            </td>
                                                            <td class="RegisterTdAddRight1">
                                                                <asp:TextBox ID="txtDelAdd1" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator ID="rfvDelAdd1" runat="server" ControlToValidate="txtDelAdd1"
                                                                    ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Delivery"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="RegisterTdAddLeft2">
                                                                <asp:Label ID="lblDelAdd2" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                                <label runat="server" id="lblDelAddMandatory2" class="mandatoryField">
                                                                    *</label>
                                                            </td>
                                                            <td class="RegisterTdAddRight2">
                                                                <asp:TextBox ID="txtDelAdd2" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator ID="rfvDelAdd2" runat="server" ControlToValidate="txtDelAdd2"
                                                                    ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Delivery"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 18%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="RegisterTdAddLeft1">
                                                                <asp:Label ID="lblDelAdd3" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                                <label runat="server" id="lblDelAddMandatory3" class="mandatoryField">
                                                                    *</label>
                                                            </td>
                                                            <td class="RegisterTdAddRight1">
                                                                <asp:TextBox ID="txtDelAdd3" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator ID="rfvDelAdd3" runat="server" ControlToValidate="txtDelAdd3"
                                                                    ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Delivery"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="RegisterTdAddLeft2">
                                                                <asp:Label ID="lblDelAdd4" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                                <label runat="server" id="lblDelAddMandatory4" class="mandatoryField">
                                                                    *</label>
                                                            </td>
                                                            <td class="RegisterTdAddRight2">
                                                                <asp:TextBox ID="txtDelAdd4" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator ID="rfvDelAdd4" runat="server" ControlToValidate="txtDelAdd4"
                                                                    ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Delivery"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="width: 18%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="RegisterTdAddLeft1">
                                                                <asp:Label ID="lblDelAdd5" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                                <label runat="server" id="lblDelAddMandatory5" class="mandatoryField">
                                                                    *</label>
                                                            </td>
                                                            <td class="RegisterTdAddRight1">
                                                                <asp:TextBox ID="txtDelAdd5" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator ID="rfvDelAdd5" runat="server" ControlToValidate="txtDelAdd5"
                                                                    ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Delivery"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="RegisterTdAddLeft2">
                                                                <asp:Label ID="lblDelCountry" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                                <label id="lblDelCountryMandatory" class="mandatoryField">
                                                                    *</label>
                                                            </td>
                                                            <td class="RegisterTdAddRight2">
                                                                <asp:DropDownList ID="ddlDelCountry" runat="server" Style="height: 24px !important"
                                                                    class="ddlWidth268 regStyle registerddlSizeNew">
                                                                </asp:DropDownList>
                                                                <br />
                                                                <span id="Span1" class="mandatoryField DisplayNone">
                                                                    <%=objLanguage.GetLanguageConversion("Please_Select_country") %></span>
                                                                <asp:RequiredFieldValidator ID="rfvDelCountry" runat="server" ControlToValidate="ddlDelCountry"
                                                                    ErrorMessage="Please select country" SetFocusOnError="true" ValidationGroup="Delivery"
                                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                                                <asp:HiddenField ID="hdnCountryIndex" runat="server" Value="0" />
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="RegisterTdAddLeft1">
                                                                <asp:Label ID="lblDelTelephone" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                                <label id="lblDelTelephoneMandatory" class="mandatoryField">
                                                                    *</label>
                                                            </td>
                                                            <td class="RegisterTdAddRight1">
                                                                <asp:TextBox ID="txtDelTelephone" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                                <asp:RequiredFieldValidator ID="rfvDelTelephone" runat="server" ControlToValidate="txtDelTelephone"
                                                                    ErrorMessage="This is a required field." ValidationGroup="Delivery"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="RegisterTdAddLeft2">
                                                                <asp:Label ID="lblDelFax" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                            </td>
                                                            <td class="RegisterTdAddRight2">
                                                                <asp:TextBox ID="txtDelFax" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="RegisterTdAddLeft1">
                                                            </td>
                                                            <td id="tdCopyToInvoice" class="RegisterTdAddRight1" style="font-size: 12px; padding-left: 0px;
                                                                height: 35px;" colspan="3">
                                                                <asp:CheckBox ID="chkCopyToInvoice" Checked runat="server" onClick="insertAddressValue('delivery')" />
                                                                <asp:Label ID="lblCopyToInvoice" runat="server" CssClass="RegistrationTest"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%; display: none; margin-top: -15px;" id="tblInvoiceAddress1">
                                            <tr>
                                                <td colspan="2" class="RegisterTdPopupLeft" style="height: 30px; vertical-align: middle">
                                                    <asp:Label ID="lblInvoiceAddress" runat="server" CssClass="RegistrationTest RegisterBoldText"
                                                        Style="height: 28px !important; color: #007ED3 !important"><%=objLanguage.GetLanguageConversion("Invoice_Address")%></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="RegisterTdPopupLeft">
                                                    <asp:Label ID="lblInvAddLabel" runat="server" CssClass="RegistrationTest"></asp:Label>
                                                </td>
                                                <td class="tdPopupRight">
                                                    <asp:TextBox ID="txtInvAddLabel" runat="server" class="ws_txtWidth260 regStylePopup"
                                                        Style="width: 240px !important"></asp:TextBox><br />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%; margin-top: 0px; display: none; margin-bottom: 10px;"
                                            id="tblInvoiceAddress2">
                                            <tr>
                                                <td class="RegisterTdAddLeft1">
                                                    <asp:Label ID="lblInvAdd1" runat="server" CssClass="RegistrationTest"></asp:Label>
                                                    <label runat="server" id="lblInvAddMandatory1" class="mandatoryField">
                                                        *</label>
                                                </td>
                                                <td class="RegisterTdAddRight1">
                                                    <asp:TextBox ID="txtInvAdd1" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="rfvInvAdd1" runat="server" ControlToValidate="txtInvAdd1"
                                                        ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="RegisterTdAddLeft2">
                                                    <asp:Label ID="lblInvAdd2" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                    <label runat="server" id="lblInvAddMandatory2" class="mandatoryField">
                                                        *</label>
                                                </td>
                                                <td class="RegisterTdAddRight2">
                                                    <asp:TextBox ID="txtInvAdd2" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="rfvInvAdd2" runat="server" ControlToValidate="txtInvAdd2"
                                                        ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 18%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="RegisterTdAddLeft1">
                                                    <asp:Label ID="lblInvAdd3" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                    <label runat="server" id="lblInvAddMandatory3" class="mandatoryField">
                                                        *</label>
                                                </td>
                                                <td class="RegisterTdAddRight1">
                                                    <asp:TextBox ID="txtInvAdd3" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="rfvInvAdd3" runat="server" ControlToValidate="txtInvAdd3"
                                                        ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="RegisterTdAddLeft2">
                                                    <asp:Label ID="lblInvAdd4" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                    <label runat="server" id="lblInvAddMandatory4" class="mandatoryField">
                                                        *</label>
                                                </td>
                                                <td class="RegisterTdAddRight2">
                                                    <asp:TextBox ID="txtInvAdd4" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="rfvInvAdd4" runat="server" ControlToValidate="txtInvAdd4"
                                                        ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 18%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="RegisterTdAddLeft1">
                                                    <asp:Label ID="lblInvAdd5" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                    <label runat="server" id="lblInvAddMandatory5" class="mandatoryField">
                                                        *</label>
                                                </td>
                                                <td class="RegisterTdAddRight1">
                                                    <asp:TextBox ID="txtInvAdd5" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="rfvInvAdd5" runat="server" ControlToValidate="txtInvAdd5"
                                                        ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="RegisterTdAddLeft2">
                                                    <asp:Label ID="lblInvCountry" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                    <label id="lblInvCountryMandatory" class="mandatoryField">
                                                        *</label>
                                                </td>
                                                <td class="RegisterTdAddRight2">
                                                    <asp:DropDownList ID="ddlInvCountry" Style="height: 24px !important" runat="server"
                                                        class="ddlWidth268 regStyle registerddlSizeNew">
                                                    </asp:DropDownList>
                                                    <br />
                                                    <span id="Span2" class="mandatoryField DisplayNone">
                                                        <%=objLanguage.GetLanguageConversion("Please_Select_country") %></span>
                                                    <asp:RequiredFieldValidator ID="rfvInvCountry" runat="server" ControlToValidate="ddlInvCountry"
                                                        ErrorMessage="Please select country" SetFocusOnError="true" ValidationGroup="Invoice"
                                                        InitialValue="0"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="RegisterTdAddLeft1">
                                                    <asp:Label ID="lblInvTelephone" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                    <label id="lblInvTelephoneMandatory" class="mandatoryField">
                                                        *</label>
                                                </td>
                                                <td class="RegisterTdAddRight1">
                                                    <asp:TextBox ID="txtInvTelephone" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox><br />
                                                    <asp:RequiredFieldValidator ID="rfvInvTelephone" runat="server" ControlToValidate="txtInvTelephone"
                                                        ErrorMessage="This is a required field." ValidationGroup="Invoice"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="RegisterTdAddLeft2">
                                                    <asp:Label ID="lblInvFax" CssClass="RegistrationTest" runat="server"></asp:Label>
                                                </td>
                                                <td class="RegisterTdAddRight2">
                                                    <asp:TextBox ID="txtInvFax" runat="server" class="ws_txtWidth260 regStylePopup"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%">
                                            <tr>
                                                <td class="RegisterTdPopupLeft">
                                                </td>
                                                <td class="tdPopupRight">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <input id="btnCancel" type="button" runat="server" class="registerBtnStyle" style="width: 100px !important;
                                                                    margin-left: 3px !important;" value="Cancel" onclick="slideToggle();return false" />
                                                            </td>
                                                            <td>
                                                                <asp:Button ID="btnSaveAndUse" runat="server" CssClass="RegisterBtnStyleNew" ValidationGroup=""
                                                                    Text="Save and Use" OnClick="InsertDepartment" OnClientClick="javascript:if(!validateDepartment()) return false; loading_image(this.id,'divDepartmentProcess');" />
                                                                <div style="float: left; height: 31px; width: 160px !important; padding: 0px; display: none;
                                                                    margin-left: 10px !important; text-align: center !important;" class="registerBtnStyle"
                                                                    id="divDepartmentProcess">
                                                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0"
                                                                        style="margin-top: 5px !important" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="contactAddress_Header" style="height: 15px !important; padding-bottom: 10px;">
                                    <asp:Label ID="lblContact" CssClass="contactAddressTest" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Contact_Address") %></asp:Label>
                                    <asp:HiddenField ID="isPrefill" runat="server" Value="false" />
                                    <br />
                                </div>
                                <table style="width: 100%">
                                    <tr>
                                        <td class="RegisterTdContactLeft1">
                                            <asp:Label ID="lbl_BillAddress1" runat="server" CssClass="RegistrationTest" Text="Address "></asp:Label>
                                            <label runat="server" id="lblAdd1" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdContactRight1">
                                            <asp:TextBox ID="txtBillAddress1" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqAddress1" runat="server" ControlToValidate="txtBillAddress1"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Contact"></asp:RequiredFieldValidator><br />
                                        </td>
                                        <td class="RegisterTdContactLeft2">
                                            <asp:Label ID="lbl_BillAddress2" CssClass="RegistrationTest" runat="server" Text="Address "></asp:Label>
                                            <label runat="server" id="lblAdd2" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdContactRight2">
                                            <asp:TextBox ID="txtBillAddress2" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqAddress2" runat="server" ControlToValidate="txtBillAddress2"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Contact"></asp:RequiredFieldValidator><br />
                                        </td>
                                        <td style="width: 18%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="RegisterTdContactLeft1">
                                            <asp:Label ID="lbl_BillCity" CssClass="RegistrationTest" runat="server" Text="City  "></asp:Label>
                                            <label runat="server" id="lblAdd3" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdContactRight1">
                                            <asp:TextBox ID="txtBillCity" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqAddress3" runat="server" ControlToValidate="txtBillCity"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Contact"></asp:RequiredFieldValidator><br />
                                        </td>
                                        <td class="RegisterTdContactLeft2">
                                            <asp:Label ID="lbl_BillState" CssClass="RegistrationTest" runat="server" Text="State  "></asp:Label>
                                            <label runat="server" id="lblAdd4" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdContactRight2">
                                            <asp:TextBox ID="txtBillState" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqAddress4" runat="server" ControlToValidate="txtBillState"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Contact"></asp:RequiredFieldValidator><br />
                                        </td>
                                        <td style="width: 18%">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="RegisterTdContactLeft1">
                                            <asp:Label ID="lblBillZipCode" CssClass="RegistrationTest" runat="server" Text="Zip/Postal Code "></asp:Label>
                                            <label runat="server" id="lblAdd5" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdContactRight1">
                                            <asp:TextBox ID="txtBillZipCode" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqAddress5" runat="server" ControlToValidate="txtBillZipCode"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Contact"></asp:RequiredFieldValidator>
                                            <br />
                                        </td>
                                        <td class="RegisterTdContactLeft2">
                                            <asp:Label ID="lblBillCountry" CssClass="RegistrationTest" runat="server" Text="Country "></asp:Label>
                                            <label id="Label15" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdContactRight2">
                                            <asp:DropDownList ID="ddlBillCountry" runat="server" class="ddlWidth268 regStyle registerddlSize">
                                            </asp:DropDownList>
                                            <br />
                                            <span id="spn_ddlBillCountry" class="mandatoryField DisplayNone">
                                                <%=objLanguage.GetLanguageConversion("Please_Select_country") %></span>
                                            <asp:RequiredFieldValidator ID="reqCountry" runat="server" ControlToValidate="ddlBillCountry"
                                                ErrorMessage="Please select country" SetFocusOnError="true" ValidationGroup="Contact"
                                                InitialValue="0"></asp:RequiredFieldValidator><br />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="RegisterTdContactLeft1">
                                            <asp:Label ID="lblBillTelephone" CssClass="RegistrationTest" runat="server" Text="Telephone "></asp:Label>
                                            <label id="Label3" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdContactRight1">
                                            <asp:TextBox ID="txtBillTelephone" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqTelephone" runat="server" ControlToValidate="txtBillTelephone"
                                                ErrorMessage="This is a required field." ValidationGroup="Contact"></asp:RequiredFieldValidator><br />
                                        </td>
                                        <td class="RegisterTdContactLeft2">
                                            <asp:Label ID="lblBillFax" CssClass="RegistrationTest" runat="server" Text="Fax "></asp:Label>
                                        </td>
                                        <td class="RegisterTdContactRight2">
                                            <asp:TextBox ID="txtBillFax" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <div id="LoginInformation_Header" class="RegisterDivHeight" style="height: 28px !important;
                                    margin-top: 5px !important">
                                    <asp:Label ID="lblLogin" CssClass="contactAddressTest" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("Login_Information") %></asp:Label>
                                    <br />
                                </div>
                                <table style="width: 100%; margin-bottom: 5px;">
                                    <tr id="trcost" runat="server">
                                        <td class="RegisterTdcostOdd1">
                                            <div id="div_lblemail" runat="server" class="RegisterDivSize">
                                                <asp:Label ID="lbl_email" runat="server" CssClass="RegistrationTest" Text=""><%=objLanguage.GetLanguageConversion("Email") %></asp:Label>
                                                <label id="Label1" class="mandatoryField">
                                                    *</label>
                                            </div>
                                        </td>
                                        <td class="RegisterTdcostEven1">
                                            <div id="div_txtemail" runat="server" class="RegisterDivSize">
                                                <asp:TextBox ID="txt_email" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox>
                                                <div style="width: 210px; height: auto">
                                                    <asp:RequiredFieldValidator ID="reqemail" runat="server" ControlToValidate="txt_email"
                                                        Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="Login"
                                                        SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email"
                                                        Display="Dynamic" ErrorMessage="Please enter a valid email address. For example johndoe@domain.com"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="true"
                                                        ValidationGroup="Login"></asp:RegularExpressionValidator>
                                                    
                                                    <asp:Label id="spn_txt_email" runat="server" Visible="false" Class="spnDisplayNone"/>                                                    

                                                    <span id="spn_txt_email_Rej" runat="server" visible="false" class="ColorRed floatLeft">
                                                        <%=objLanguage.GetLanguageConversion("Waiting_For_Approval")%></span><br />
                                                </div>
                                            </div>
                                        </td>
                                        <td class="RegisterTdcostOdd2" style="padding-left: 10px;">
                                            &nbsp;
                                        </td>
                                        <td class="RegisterTdcostEven2">
                                            &nbsp;
                                        </td>
                                        <td style="width: 30%;">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="RegisterTdcostOdd1" id="costSmartTdLeft" runat="server">
                                            <asp:Label ID="lbl_password" CssClass="RegistrationTest" runat="server" Text=""></asp:Label>
                                            <label id="Label2" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdcostEven1">
                                            <asp:TextBox ID="txtpassword" runat="server" class="ws_txtWidth260 regStyle" TextMode="Password"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqpassword" runat="server" ControlToValidate="txtpassword"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="Regexp_validateEmailForCostsmart" runat="server"
                                                ControlToValidate="txt_email" Display="Dynamic" ErrorMessage="Please enter a valid email address. For example johndoe@domain.com"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="true"
                                                ValidationGroup="Login" Visible="false" Style="display: none"></asp:RegularExpressionValidator>
                                            
                                            <asp:Label id="spn_txtpassemail" runat="server" Visible="false" CssClass="ColorRed"/>

                                            <span id="spn_txtpassemail_Rej" runat="server" style="display: none" visible="false"
                                                class="ColorRed floatLeft">
                                                <%=objLanguage.GetLanguageConversion("Waiting_For_Approval")%></span>
                                            
                                            <asp:Label id="spn_txtPassEmailExists" runat="server" Visible="false" CssClass="spnDisplayNone"/>                                            

                                        </td>
                                        <td class="RegisterTdcostOdd2" style="padding-left: 10px;" id="costSmartTdRight"
                                            runat="server">
                                            <asp:Label ID="lbl_confirmPassword" CssClass="RegistrationTest" runat="server" Text=""></asp:Label>
                                            <label id="Label4" class="mandatoryField">
                                                *</label>
                                        </td>
                                        <td class="RegisterTdcostEven2">
                                            <asp:TextBox ID="txt_confirmPassword" runat="server" class="ws_txtWidth260 regStyle"
                                                TextMode="Password"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="reqconfirmPassword" runat="server" ControlToValidate="txt_confirmPassword"
                                                Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="Login"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword"
                                                ControlToValidate="txt_confirmPassword" Display="Dynamic" ErrorMessage="Please make sure your passwords match."
                                                ValidationGroup="Login"></asp:CompareValidator>
                                            <br />
                                        </td>
                                        <td style="width: 30%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <div class="heightAuto paddingBottom5 DisplayNone RegisterDivHeight" id="div_Approver_Header"
                                    runat="server" style="height: 30px !important">
                                    <asp:Label ID="lbldesignate" CssClass="contactAddressTest" runat="server" Text="Please designate your Approver"></asp:Label>
                                </div>
                                <div id="div_Approver_Content" runat="server" class="DisplayNone RegisterDivSize">
                                    <table>
                                        <tr>
                                            <td class="tdOddlast">
                                                <asp:Label ID="lbl_ApproEmail" runat="server" CssClass="RegistrationTest" Text="Email Address "></asp:Label>
                                                <label id="Label6" class="mandatoryField">
                                                    *</label>
                                            </td>
                                            <td class="tdEvenlast">
                                                <asp:TextBox ID="txt_ApproEmail" runat="server" class="ws_txtWidth260 regStyle"></asp:TextBox><br />
                                                <asp:HiddenField ID="hdnApproverID" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_ApproEmail"
                                                    Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="Approve"
                                                    SetFocusOnError="true" Enabled="false"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txt_ApproEmail"
                                                    Display="Dynamic" ErrorMessage="Please enter a valid email address. For example johndoe@domain.com"
                                                    ValidationExpression="^((['\w])*[0-9a-zA-Z]([-.'\w]*[0-9a-zA-Z])*(['\w])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                    SetFocusOnError="true" ValidationGroup="Approve"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="width: auto; height: auto">
                                    <asp:Label ID="lblReqiEmail" runat="server" Visible="false" CssClass="ColorRed" Text="designated approver email not contains in this Account"></asp:Label>
                                </div>
                                <div id="divsubscribe" style="padding-bottom: 30px; padding-top: 0px">
                                    <asp:CheckBox ID="chkAddEmilDmc" runat="server" Checked="true" Text=" " />
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="createAccount_content_bottom" style="margin: 0px; margin-left: 5px;">
                            <div class="floatLeft accountclearleft20">
                                <span>
                                    <asp:Button ID="btnBackRegister" runat="server" class="registerBtnStyle btnSize"
                                        Text="" OnClientClick="loading_image(this.id,'div_btnsaveprocess');" OnClick="btnBackRegister_Click" /></span>
                                <div id="div_btnsaveprocess" class="registerBtnStyle btnSize" style="height: 21px !important;
                                    text-align: center; width: 91px !important;">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0"
                                        style="margin-top: 2px" />
                                </div>
                            </div>
                            <div class="floatLeft clearLeft">
                                <span>
                                    <asp:Button ID="btn_createAccount" runat="server" class="registerBtnStyle" OnClientClick="if(!ValidateNew()) return false;loading_image(this.id,'div_createAccount');"
                                        Text="" ValidationGroup="CreateAccount" OnClick="btn_createAccount_OnClick" /></span>
                                <div id="div_createAccount" class="registerBtnStyle" style="text-align: center; width: 192px !important;
                                    height: 21px !important;">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans2" alt="loading" border="0"
                                        style="margin-top: 2px !important;" />
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div>
                            &nbsp;</div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlAccessDeniedMsg" runat="server" Visible="false">
            <table cellpadding="0" cellspacing="0" align="center" id="tb_pnlAccessDeniedMsg"
                class="Error_report_Tbl">
                <tr>
                    <td align="center" style="padding-bottom: 200px">
                        <div class="messageboxErrorSupport_ErrorPage" style="width: 20%">
                            <div>
                                You are not allowed to access this page
                            </div>
                            <div>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Click here to go back to Login Page"
                                    CssClass="MouseOver" OnClick="Onclick_LnkBack"><%=objLanguage.GetLanguageConversion("Click_here_to_go_back_to_Login_Page")%></asp:LinkButton>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <script type="text/javascript">
            function loading_image(div1, div2) {
                document.getElementById(div1).style.display = "none";
                document.getElementById(div2).style.display = "block";
            }

            function hideHeader() {
                document.getElementById("header").style.display = "none";
            }
            //hideHeader();

            function ValidateExistanceOfEmail(Value, AccountID) {
                AutoFill.ExistanceOfEmail(Value, AccountID, GetApproverID, onTimeout, onError);

            }
            function onTimeout(err) { }
            function onError(err) { }

            function GetApproverID(result) {
                if (result != 0) {
                    document.getElementById("ctl00_ContentPlaceHolder1_hdnApproverID").value = result;
                    //alert(result);
                    return true;
                }
                else {
                    alert('<%=objLanguage.GetLanguageConversion("designated_approver_email_not_contains_in_this_Account") %>');
                    //alert("designated approver email not contains in this Account");
                    return false;
                }
            }
            var txt_email = document.getElementById('ctl00_ContentPlaceHolder1_txt_email');
            var txtpassword = document.getElementById('<%= txtpassword.ClientID%>');
            function CopyEmailtoEmail(Id, Value) {

                txt_email.value = Value;
                if (Value == '') {
                    document.getElementById('ctl00_ContentPlaceHolder1_reqpassword').style.display = 'block';
                } else {
                    document.getElementById('ctl00_ContentPlaceHolder1_reqpassword').style.display = 'none';
                }
            }
            var spnErrorDulicate = document.getElementById("spnErrorDulicate");
            var registrationAddDepartment = document.getElementById("registrationAddDepartment");
            var divpopup = document.getElementById("divpopup");
            var hdnInsertAddress = document.getElementById('<%= hdnInsertAddress.ClientID%>');
            var chkCopyToInvoice = document.getElementById('<%= chkCopyToInvoice.ClientID%>');
            var hdnIsAddDepartment = document.getElementById('<%= hdnIsAddDepartment.ClientID%>');
            var isPrefill = document.getElementById('<%= isPrefill.ClientID%>');
            var tdCopyToInvoice = document.getElementById("tdCopyToInvoice");
            function slideToggle() {
                if (registrationAddDepartment.style.display == "none") {
                    registrationAddDepartment.style.display = "block";
                    setBgDiv();
                    chkCopyToInvoice.checked = true;
                    divpopup.style.display = "block";
                    clearDeliveryFields();
                    clearInvoiceFields();
                    Page_ClientValidateReset();
                    document.getElementById("tblInvoiceAddress1").style.display = "none";
                    document.getElementById("tblInvoiceAddress2").style.display = "none";
                    hdnInsertAddress.value = "delivery";
                    spnErrorDulicate.style.display = "none";
                }
                else {
                    registrationAddDepartment.style.display = "none";
                    divpopup.style.display = "none";
                    chkCopyToInvoice.checked = false;
                    clearDeliveryFields();
                    clearInvoiceFields();
                    Page_ClientValidateReset();
                }
            }

            function displayInvoiceField() {
                $("#tblInvoiceAddress1").slideDown("slow");
                $("#tblInvoiceAddress2").slideDown("slow");
                document.getElementById("tblInvoiceAddress1").style.display = "block";
                document.getElementById("tblInvoiceAddress2").style.display = "block";
                Page_ClientValidateReset();
                hdnInsertAddress.value = "";
            }
            function hideInvoiceField() {
                $("#tblInvoiceAddress1").slideUp("slow");
                $("#tblInvoiceAddress2").slideUp("slow");
                hdnInsertAddress.value = "delivery";
            }

            var txtInvAdd1 = document.getElementById('<%= txtInvAdd1.ClientID%>');
            var txtInvAdd2 = document.getElementById('<%= txtInvAdd2.ClientID%>');
            var txtInvAdd3 = document.getElementById('<%= txtInvAdd3.ClientID%>');
            var txtInvAdd4 = document.getElementById('<%= txtInvAdd4.ClientID%>');
            var txtInvAdd5 = document.getElementById('<%= txtInvAdd5.ClientID%>');
            var txtInvAddLabel = document.getElementById('<%= txtInvAddLabel.ClientID%>');
            var ddlInvCountry = document.getElementById('<%= ddlInvCountry.ClientID%>');
            var txtInvTelephone = document.getElementById('<%= txtInvTelephone.ClientID%>');
            var txtInvFax = document.getElementById('<%= txtInvFax.ClientID%>');

            var txtDeptName = document.getElementById('<%= txtDeptName.ClientID%>');

            var txtDelAdd1 = document.getElementById('<%= txtDelAdd1.ClientID%>');
            var txtDelAdd2 = document.getElementById('<%= txtDelAdd2.ClientID%>');
            var txtDelAdd3 = document.getElementById('<%= txtDelAdd3.ClientID%>');
            var txtDelAdd4 = document.getElementById('<%= txtDelAdd4.ClientID%>');
            var txtDelAdd5 = document.getElementById('<%= txtDelAdd5.ClientID%>');
            var txtDelAddLabel = document.getElementById('<%= txtDelAddLabel.ClientID%>');
            var ddlDelCountry = document.getElementById('<%= ddlDelCountry.ClientID%>');
            var txtDelTelephone = document.getElementById('<%= txtDelTelephone.ClientID%>');
            var txtDelFax = document.getElementById('<%= txtDelFax.ClientID%>');

            var ddl_Department = document.getElementById('<%= ddl_Department.ClientID%>');
            var HdnDepartmentID = document.getElementById('<%= HdnDepartmentID.ClientID%>');


            var hdnCountryIndex = document.getElementById('<%=hdnCountryIndex.ClientID %>');
            function clearDeliveryFields() {
                txtDelAdd1.value = "";
                txtDelAdd2.value = "";
                txtDelAdd3.value = "";
                txtDelAdd4.value = "";
                txtDelAdd5.value = "";
                txtDelAddLabel.value = "";
                txtDelTelephone.value = "";
                txtDelFax.value = "";
                ddlDelCountry.options.selectedIndex = parseInt(hdnCountryIndex.value);
                txtDeptName.value = "";
            }

            function clearInvoiceFields() {
                txtInvAdd1.value = "";
                txtInvAdd2.value = "";
                txtInvAdd3.value = "";
                txtInvAdd4.value = "";
                txtInvAdd5.value = "";
                txtInvAddLabel.value = "";
                txtInvTelephone.value = "";
                txtInvFax.value = "";
                ddlInvCountry.options.selectedIndex = parseInt(hdnCountryIndex.value);
            }

            function insertAddressValue(val) {
                if (val == "delivery") {
                    if (chkCopyToInvoice.checked) {
                        hideInvoiceField();
                    }
                    else {
                        clearInvoiceFields();
                        displayInvoiceField();
                    }
                }
            }
            var clientid = '<%=clientid %>';
            var CompanyID = '<%=CompanyID %>';
            var spn_txt_email = document.getElementById('<%= spn_txt_email.ClientID%>');
            var spn_txtPassEmailExists = document.getElementById('<%= spn_txtPassEmailExists.ClientID%>');
            function checkDeptDuplicacy(DeptName) {
                if (DeptName != "") {
                    AutoFill.CheckDept_Duplicacy(CompanyID, clientid, DeptName, 0, GetResult_Dept_Duplicacy, onTimeout, onError);
                }
                else {
                    spnErrorDulicate.style.display = "none";
                }
            }

            var isSingleField = document.getElementById("<%=IsSingleField%>");
            function checkEmailDuplicacy() {
                debugger
                if (isSingleField == "true") {
                    if (txtpassword.value.trim() != "")
                        AutoFill.Check_EmailID_Duplicacy_for_Account(txtpassword.value.trim(), clientid, 0, GetResult_Email_Duplicacy, onTimeout, onError);
                    else
                        spn_txtPassEmailExists.className = "spnDisplayNone";
                }
                else {
                    if (txt_email.value.trim() != "")
                        AutoFill.Check_EmailID_Duplicacy_for_Account(txt_email.value.trim(), clientid, 0, GetResult_Email_Duplicacy, onTimeout, onError);
                    else
                        spn_txt_email.className = "spnDisplayNone";
                }
            }

            function GetResult_Email_Duplicacy(result) {
                if (isSingleField == "true") {
                    if (result == -2 || result == -1) {
                        spn_txtPassEmailExists.className = "spnDisplayBlock";
                    }
                    else {
                        spn_txtPassEmailExists.className = "spnDisplayNone";
                    }
                }
                else {
                    if (result == -2 || result == -1) {
                        spn_txt_email.className = "spnDisplayBlock";
                    }
                    else {
                        spn_txt_email.className = "spnDisplayNone";
                    }
                }
            }

            function GetResult_Dept_Duplicacy(result) {
                if (result == -1) {
                    spnErrorDulicate.style.display = "block";
                }
                else {
                    spnErrorDulicate.style.display = "none";
                }
            }

            function onSucceed() {

            }

            function ValidateNew() {
                debugger
                asyncState = false;
                var returnValue = false;
                spn_txt_email.className = "spnDisplayNone";
                spn_txtPassEmailExists.className = "spnDisplayNone";

                if (Page_ClientValidate('CreateAccount')) {
                    returnValue = true;
                }

                if (returnValue) {
                    returnValue = Page_ClientValidate("Contact");
                }

                if (returnValue) {
                    returnValue = Page_ClientValidate("Login");
                }

                if (returnValue) {
                    returnValue = Page_ClientValidate("Approve");
                }

                if (returnValue) {
                    checkEmailDuplicacy();
                    if (isSingleField == "true") {
                        if (spn_txtPassEmailExists.className == "spnDisplayBlock") {
                            returnValue = false;
                        }
                        else {
                            returnValue = true;
                        }
                    }
                    else {
                        if (spn_txt_email.className == "spnDisplayBlock") {
                            returnValue = false;
                        }
                        else {
                            returnValue = true;
                        }
                    }
                }
                return returnValue;
            }

            function validateDepartment() {
                asyncState = false;
                var returnValue = false;
                spnErrorDulicate.style.display = "none";
                returnValue = Page_ClientValidate('Delivery');
                if (returnValue && !(chkCopyToInvoice.checked)) {
                    returnValue = Page_ClientValidate('Invoice');
                }

                if (returnValue) {
                    checkDeptDuplicacy(txtDeptName.value.trim());
                    if (spnErrorDulicate.style.display == "none") {
                        returnValue = true;
                    }
                    else {
                        returnValue = false;
                    }
                }

                return returnValue;
            }


            function setBgDiv() {
                var width = $("body").width();
                var height = $("body").height();
                $("#divpopup").css("width", "100%");
                $("#divpopup").css("height", "100%");
            }

            setBgDiv();



        </script>
        <div align="left" id="footer_content">
            <div class="footer_div DisplayNone">
                <asp:PlaceHolder ID="ph_footer" runat="server"></asp:PlaceHolder>
            </div>
            <div class="clearBoth">
            </div>
            <div id="divfooterMain" runat="server" align="left">
                <div id="divfootersub" runat="server">
                    <asp:Label ID="lbl_copyWriter" runat="server" Visible="false"></asp:Label>
                    <asp:PlaceHolder ID="ph_copyWriter" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $(document).keydown(function (e) {
                var keyCode = (window.event) ? e.which : e.keyCode;
                if (keyCode && keyCode == 13) {
                    e.preventDefault();
                    return false;
                }
            });

            function Page_ClientValidateReset() {
                if (typeof (Page_Validators) != "undefined") {
                    for (var i = 0; i < Page_Validators.length; i++) {
                        var validator = Page_Validators[i];
                        validator.isvalid = true;
                        ValidatorUpdateDisplay(validator);
                    }
                }
            }
            

        </script>
    </div>
</asp:Content>
