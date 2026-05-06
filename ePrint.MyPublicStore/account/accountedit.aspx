<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountedit.aspx.cs" Inherits="ePrint.MyPublicStore.account.accountedit" masterpagefile="~/Templates/masterPageDefault.master" %>

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
            <a href="<%=strSitepath%>account/account<%=FileExtension %>"><%=objLanguage.GetLanguageConversion("My_Account") %></a> > <%=objLanguage.GetLanguageConversion("Edit_Account_Information") %>
        </div>
        <div id="accountInfo_background">
            <div id="accountInfoContent_div">
                <div id="accountInfoContent_left">
                    <acc:account_panel ID="account_panel1" runat="server" />
                </div>
                <div id="accountInfoContent_right">
                    <div id="heading" class="Header_Background">
                        <strong><%=objLanguage.GetLanguageConversion("Edit_Account_Information") %> </strong>
                    </div>
                    <div id="accountedit">
                        <div id="createAccount_content_left">
                            <div>
                                <br />
                                <strong><%=objLanguage.GetLanguageConversion("Personal_Information") %> </strong>
                            </div>
                            <div>
                                <asp:Label ID="Label2" runat="server" Text="Company Name "><%=objLanguage.GetLanguageConversion("Company_Name") %></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_CompanyName" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_firstName" runat="server" Text="First Name "><%=objLanguage.GetLanguageConversion("First_Name") %></asp:Label>
                                <label id="lbl_starColor" class="mandatoryField">
                                    *</label><br />
                                <asp:TextBox ID="txt_firstName" runat="server" class="ws_txtWidth260" TabIndex="2"></asp:TextBox>
                                <span id="spn_firstName" class="displayNone colorRed"><%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                            </div>
                            <div>
                                <asp:Label ID="lbl_email" runat="server" Text="Email Address "><%=objLanguage.GetLanguageConversion("Email_Address") %></asp:Label>
                                <label id="Label1" class="mandatoryField">
                                    *</label><br />
                                <asp:TextBox ID="txt_email" runat="server" class="ws_txtWidth260" TabIndex="4" onkeyup="javascript:CheckDuplicate_email(this.value);"
                                    onblur="javascript:CheckDuplicate_email(this.value);"></asp:TextBox>
                                <span id="spn_email" class="displayNone colorRed"><%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                            </div>
                            <div>
                                <asp:CheckBox ID="chk_changePwd" runat="server" Text=" Change Password" TabIndex="6"
                                    onclick="javascript:changepassword();" Checked="false" />
                            </div>
                            <div id="changePassword_header" class="displayNone">
                                <br />
                                <strong><%=objLanguage.GetLanguageConversion("Change_Password") %></strong>
                            </div>
                            <div id="changePassword_currentPwd" class="displayNone">
                                <asp:Label ID="lbl_currentPwd" runat="server" Text="Current Password "><%=objLanguage.GetLanguageConversion("Current_Password") %></asp:Label>
                                <label id="Label4" class="mandatoryField">
                                    *</label><br />
                                <asp:TextBox ID="txt_currentPwd" runat="server" class="ws_txtWidth260" TextMode="Password"
                                    TabIndex="7"></asp:TextBox>
                                <span id="spn_changePwd" class="displayNone colorRed"><%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                            </div>
                            <div id="changePassword_newPwd" class="displayNone">
                                <asp:Label ID="lbl_newPwd" runat="server" Text="New Password "><%=objLanguage.GetLanguageConversion("New_Password") %></asp:Label>
                                <label id="Label6" class="mandatoryField">
                                    *</label><br />
                                <asp:TextBox ID="txt_newPwd" runat="server" class="ws_txtWidth260" TextMode="Password"
                                    TabIndex="8"></asp:TextBox>
                                <span id="spn_newPwd" class="displayNone colorRed"><%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
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
                                    *</label><br />
                                <asp:TextBox ID="txt_lastName" runat="server" class="ws_txtWidth260" TabIndex="3"></asp:TextBox>
                                <span id="spn_lastName" class="displayNone colorRed"><%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                            </div>
                            <div>
                            </div>
                            <div>
                            </div>
                            <div>
                            </div>
                            <div id="changePassword_div_top" class="displayNone">
                            </div>
                            <div id="changePassword_div_middle" class="displayNone">
                            </div>
                            <div id="confirmNewPwd" class="displayNone">
                                <asp:Label ID="lbl_confirmPwd" runat="server" Text="Confirm New Password"><%=objLanguage.GetLanguageConversion("confirm_New_Password") %></asp:Label>
                                <label id="Label5" class="mandatoryField">
                                    *</label><br />
                                <asp:TextBox ID="txt_confirmPwd" runat="server" class="ws_txtWidth260" TextMode="Password"
                                    TabIndex="9"></asp:TextBox>
                                <span id="spn_confirmPwd" class="displayNone colorRed"><%=objLanguage.GetLanguageConversion("This_is_a_required_field")%></span>
                            </div>
                        </div>
                    </div>
                    <div class="clearBoth">
                    </div>
                    <div id="createAccount_content_bottom">
                        <div id="createAccount_content_bottom_left">
                            <br />
                            <br />
                            <a href="<%=strSitepath%>account/account<%=FileExtension %>" class="anchorColor"><small>
                                « </small><%=objLanguage.GetLanguageConversion("Back") %></a>
                        </div>
                        <div id="createAccount_content_bottom_right">
                            <label id="Label29" class="mandatoryField">
                                * <%=objLanguage.GetLanguageConversion("Required_Fields")%></label>
                            <br />
                            <br />
                            <span>
                                <asp:Button ID="btnSave" runat="server" class="WS_Buttons_Style" Text="Save" TabIndex="10"
                                    OnClientClick="javascript:return Validate();" OnClick="OnClick_btnSave" /></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" language="javascript">

        var txt_firstName = document.getElementById("<%=txt_firstName.ClientID %>");
        var txt_lastName = document.getElementById("<%=txt_lastName.ClientID %>");
        var txt_email = document.getElementById("<%=txt_email.ClientID %>");
        var txt_currentPwd = document.getElementById("<%=txt_currentPwd.ClientID %>");
        var txt_newPwd = document.getElementById("<%=txt_newPwd.ClientID %>");
        var txt_confirmPwd = document.getElementById("<%=txt_confirmPwd.ClientID %>");

        var spn_firstName = document.getElementById("spn_firstName");
        var spn_lastName = document.getElementById("spn_lastName");
        var spn_email = document.getElementById("spn_email");
        var spn_changePwd = document.getElementById("spn_changePwd");
        var spn_newPwd = document.getElementById("spn_newPwd");
        var spn_confirmPwd = document.getElementById("spn_confirmPwd");


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
        var EmailID_already_exists = '<%=objLanguage.GetLanguageConversion("EmailID_already_exists")%>';
        var Please_make_sure_your_passwords_match = '<%=objLanguage.GetLanguageConversion("Please_make_sure_your_passwords_match")%>';
        var Invalid_email_format = '<%=objLanguage.GetLanguageConversion("Invalid_email_format")%>';
    </script>

    <script type="text/javascript" src="<%=strSitepath %>js/general.js?VN='<%=VersionNumber%>'"></script>

    <script type="text/javascript" src="<%=strSitepath %>js/create_account.js?VN='<%=VersionNumber%>'"></script>

</asp:Content>

