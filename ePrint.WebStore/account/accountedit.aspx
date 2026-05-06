<%@ page title="Account Information" language="C#" masterpagefile="~/Templates/masterPageDefault.master" autoeventwireup="true"  CodeBehind="accountedit.aspx.cs" Inherits="ePrint.WebStore.account.accountedit" enableEventValidation="false" viewStateEncryptionMode="Never" %>


<%@ Register TagName="account_panel" TagPrefix="acc" Src="~/usercontrol/account_leftpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <script src="../js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="accountInfoMain_div">
        <div id="accountInfo_background">
            <div id="accountInfoContent_div_Accountpage">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right_withBrderLft">
                    <div id="DivLblErrorMsg" runat="server" align="Center" class="DivLblErrorMsg">
                        <asp:Label ID="LblErrorMsg" runat="server" CssClass="LblErrorMsg" Text=""><%=objLanguage.GetLanguageConversion("Your_Last_Edit_Profile_Approval_Is_Pending") %></asp:Label>
                    </div>
                    <div class="clearleft">
                        <div id="heading" class="Header_Background Heading_AddressEditpage">
                            <%=objLanguage.GetLanguageConversion("Edit_Account_Information") %>
                        </div>
                        <div id="accountedit">
                            <div id="createAccount_content_left">
                                <div class="clearTop">
                                    <strong>
                                        <%=objLanguage.GetLanguageConversion("Personal_Information") %>
                                    </strong>
                                </div>
                                <div>
                                    <asp:Label ID="Label2" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Company_Name") %></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txt_CompanyName" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox>
                                </div>
                                <div>
                                <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
                                <br />
                                <asp:TextBox ID="txtDepartment" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_firstName" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("First_Name") %></asp:Label>
                                    <label id="lbl_starColor" class="mandatoryField">
                                        *</label><br />
                                    <asp:TextBox ID="txt_firstName" runat="server" class="ws_txtWidth260" TabIndex="3"></asp:TextBox>
                                    <span id="spn_firstName" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                </div>
                                <div>
                                    <asp:CheckBox ID="chk_changePwd" runat="server" Text=" " TabIndex="6" onclick="javascript:changepassword();"
                                        Checked="false" />
                                </div>
                                <div id="changePassword_header">
                                    <br />
                                    <strong>
                                        <%=objLanguage.GetLanguageConversion("Change_Password") %>
                                    </strong>
                                </div>
                                <div id="changePassword_currentPwd" class="DisplayNone">
                                    <asp:Label ID="lbl_currentPwd" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("Current_Password") %></asp:Label>
                                    <label id="Label4" class="mandatoryField">
                                        *</label><br />
                                    <asp:TextBox ID="txt_currentPwd" runat="server" class="ws_txtWidth260" TextMode="Password"
                                        TabIndex="7"></asp:TextBox>
                                    <span id="spn_changePwd" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                    <asp:HiddenField ID="hdnPassword" runat="server" />
                                </div>
                                <div id="changePassword_newPwd" class="DisplayNone">
                                    <asp:Label ID="lbl_newPwd" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("New_Password") %></asp:Label>
                                    <label id="Label6" class="mandatoryField">
                                        *</label><br />
                                    <asp:TextBox ID="txt_newPwd" runat="server" class="ws_txtWidth260" TextMode="Password"
                                        TabIndex="8"></asp:TextBox>
                                    <span id="spn_newPwd" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                </div>
                                <div id="createAccount_content_bottom_left">
                                    <a href="<%=strSitepath%>account/account<%=FileExtension %>" class="anchorColor"><small>
                                        « </small>
                                        <%=objLanguage.GetLanguageConversion("Back") %></a>
                                </div>
                            </div>
                            <div id="createAccount_content_right">
                                <div class="clearTop">
                                </div>
                                <div id="empty">&nbsp;</div>
                                <div>
                                    <asp:Label ID="lbl_email" runat="server" Text=" "><%=objLanguage.GetLanguageConversion("Email_Address") %></asp:Label>
                                    <label id="Label1" class="mandatoryField">
                                        *</label><br />
                                    <asp:TextBox ID="txt_email" runat="server" class="ws_txtWidth260" TabIndex="2" onkeyup="javascript:CheckDuplicate_email(this.value);"
                                        onblur="javascript:CheckDuplicate_email(this.value);"></asp:TextBox>
                                    <span id="spn_email" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                </div>
                                <div>
                                    <asp:Label ID="lbl_lastName" runat="server" Text="Last Name "><%=objLanguage.GetLanguageConversion("Last_Name") %></asp:Label>
                                    <label id="Label3" class="mandatoryField">
                                        *</label><br />
                                    <asp:TextBox ID="txt_lastName" runat="server" class="ws_txtWidth260" TabIndex="4"></asp:TextBox>
                                    <span id="spn_lastName" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                </div>
                                <div id="DivApproverEmail" runat="server">
                                    <asp:Label ID="Label7" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Approver_Email")%></asp:Label>
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
                                <div id="changePassword_div_top" class="DisplayNone">
                                </div>
                                <div id="changePassword_div_middle" class="DisplayNone">
                                </div>
                                <div id="confirmNewPwd">
                                    <asp:Label ID="lbl_confirmPwd" runat="server" Text=""><%=objLanguage.GetLanguageConversion("Confirm_New_Password")%></asp:Label>
                                    <label id="Label5" class="mandatoryField">
                                        *</label><br />
                                    <asp:TextBox ID="txt_confirmPwd" runat="server" class="ws_txtWidth260" TextMode="Password"
                                        TabIndex="9"></asp:TextBox>
                                    <span id="spn_confirmPwd" class="DisplayNone ColorRed">
                                        <%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                                </div>
                                <div id="jj">
                                    <label id="Label29" class="mandatoryField">
                                        *
                                        <%=objLanguage.GetLanguageConversion("Required_Fields")%></label>
                                    <br />
                                    <br />
                                    <div id="div_btnsave">
                                        <asp:Button ID="btnSave" runat="server" class="x-btnpro Grey main" Text="" TabIndex="10"
                                            OnClientClick="javascript:return Validate();" OnClick="OnClick_btnSave" />
                                    </div>
                                    <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                        <img src="<%=strImagepath %>../images/radimg1.gif" class="trans" alt="loading" border="0" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearBoth">
                        </div>
                        <div id="createAccount_content_bottom">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField runat="server" ID="hdnValidation" Value="" />
    <script type="text/javascript" language="javascript">
        var txt_firstName = document.getElementById("<%=txt_firstName.ClientID %>");
        var txt_lastName = document.getElementById("<%=txt_lastName.ClientID %>");
        var txt_email = document.getElementById("<%=txt_email.ClientID %>");
        var txt_currentPwd = document.getElementById("<%=txt_currentPwd.ClientID %>");
        var txt_newPwd = document.getElementById("<%=txt_newPwd.ClientID %>");
        var txt_confirmPwd = document.getElementById("<%=txt_confirmPwd.ClientID %>");
        var txtApproverEmail = document.getElementById("<%=txtApproverEmail.ClientID %>");
        var spn_firstName = document.getElementById("spn_firstName");
        var spn_lastName = document.getElementById("spn_lastName");
        var spn_email = document.getElementById("spn_email");
        var spn_changePwd = document.getElementById("spn_changePwd");
        var spn_newPwd = document.getElementById("spn_newPwd");
        var spn_confirmPwd = document.getElementById("spn_confirmPwd");
        var SpnApproverEmailan = document.getElementById("SpnApproverEmailan");
        var chk_changePwd = document.getElementById("<%=chk_changePwd.ClientID %>");
        var changePassword_header = document.getElementById("changePassword_header");
        var changePassword_currentPwd = document.getElementById("changePassword_currentPwd");
        var changePassword_newPwd = document.getElementById("changePassword_newPwd");
        var changePassword_div_top = document.getElementById("changePassword_header");
        var changePassword_div_middle = document.getElementById("changePassword_div_middle");
        var confirmNewPwd = document.getElementById("confirmNewPwd");
        var type = '<%=type %>';
        var StoreUserID = '<%=StoreUserID %>';
        var AccountID = '<%=AccountID %>';

        var Invalid_email_format = '<%=objLanguage.GetLanguageConversion("Invalid_email_format") %>';
        var EmailID_already_exists = '<%=objLanguage.GetLanguageConversion("EmailID_already_exists") %>';
        var Please_make_sure_your_passwords_match = '<%=objLanguage.GetLanguageConversion("Please_make_sure_your_passwords_match") %>';

        function ValidateExistanceOfEmail(Value, AccountID) {
            AutoFill.ExistanceOfEmail(Value, AccountID, GetApproverID, onTimeout, onError);
        }

        function onTimeout(err) { }
        function onError(err) { }

        function GetApproverID(result) {
            if (result != 0) {
                document.getElementById("<%=hdnApproverID.ClientID %>").value = result;
                return true;
            }
            else {
                alert("designated approver email not contains in this Account");
                return false;
            }
        }
    </script>
    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>
    <script type="text/javascript" src="<%=strSitepath %>js/create_account.js?VN='<%=VersionNumber%>'"></script>
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
