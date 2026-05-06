<%@ page language="C#" autoeventwireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="ePrint.WebStore.forgotpassword"  enableEventValidation="false" viewStateEncryptionMode="Never" %>



<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="<%#StyleSheetPathMaster +"/Themes/StyleSheet_B2B.css"%>" id="Link1" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/StyleSheet_B2B.css"%>" id="MainStyle2" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/CustomStyleSheet.css"%>" id="Link2" rel="Stylesheet"
        type="text/css" />
</head>
<script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
<body class="loginpage-body">
    <form id="form1" runat="server" defaultbutton="Button1">
    <div id="ForgotPassword">
        <table id="tblheaderimage" runat="server">
            <tr>
                <td id="tdheaderimage" runat="server" valign="top">
                    <asp:PlaceHolder ID="ph_headerLeft" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
        </table>
        <div id="forgetpwd_div">
            <div align="center">
                <div class="Login-div2padding" align="center">
                    <br />
                    <%--<div class="ForgotPassword-Heading" align="center">
                        </div>--%><div>
                            <asp:Label ID="lblForGotPassword" runat="server" CssClass="LoginFontStyle"><%=objLanguage.GetLanguageConversion("Forgotten_your_password")%></asp:Label></div>
                    <br />
                </div>
                <div class="Login-div2padding" align="center">
                    <span class="LoginWelcomeHeading">
                        <%=objLanguage.GetLanguageConversion("To_reset_your_password_enter_the_email_address")%>
                        <br />
                        <%=objLanguage.GetLanguageConversion("you_use_to_login_to_Eprint_Your_password_will_be_emailed_to_this_address")%></span>
                </div>
                <br />
                <div>
                    <div id="RegtxtEmail" class="DisplayNone">
                        <div class="div-EmailRegularExpression">
                            <span class="RegularExpressionLine1">
                                <%=objLanguage.GetLanguageConversion("Please_enter_a_valid_email_address")%>
                                <br />
                            </span><span class="RegularExpressionLine2">
                                <%=objLanguage.GetLanguageConversion("Example_MailID")%></span>
                        </div>
                    </div>
                </div>
                <div id="div_Not_in_DB" runat="server" class="div-EmailRegularExpression paddingTop3">
                    <span class="RegularExpression-Line1">
                        <%=objLanguage.GetLanguageConversion("The_email_which_you_have_entered_does_not_exist_in_our_system")%>
                        <br />
                    </span><span class="RegularExpression-Line2">
                        <%=objLanguage.GetLanguageConversion("Please_enter_a_valid_email_address")%></span>
                </div>
                <div id="div_PasswordSent" runat="server">
                    <span class="RegularExpressionMsg">
                        <%=objLanguage.GetLanguageConversion("The_password_has_been_send_to_your_Email")%>
                        <br />
                    </span>
                </div>
                <div id="div_InvalidMsg" runat="server" class="DisplayNone">
                    <div id="invaliedMsg_div_Login">
                        <div id="invaliedMsg_image_Login">
                            <img id="imgError" runat="server" alt="Error" />
                        </div>
                        <div id="invaliedMsg_details_Login">
                            <asp:Label ID="lblSucess" runat="server" Text="Your account is still not activated"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="ForgotPasswordroundcorners">
                    <table class="Login-Table">
                        <tr>
                            <td class="EmptyCell">
                            </td>
                        </tr>
                        <tr>
                            <td class="EmptyCell">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:Label ID="lbl" runat="server" CssClass="LoginFontStyle" Text="Email"><%=objLanguage.GetLanguageConversion("Email") %></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="paddingTop3">
                                <div align="left">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="Login-TextBox" onblur="javascript:ShowOrHide(this.id,this.value);"></asp:TextBox>
                                    <div class="height20px">
                                        <div id="ReqtxtEmail" class="ValidationColor Validationfont DisplayNone">
                                            <span>This is a required field.</span>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="EmptyCell">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:LinkButton ID="LnkForGotPass" runat="server" Text="Cancel" OnClick="LnkCancel_Click"
                                        CssClass="lnkForgotPassword"></asp:LinkButton>
                                </div>
                                <div id="div_btnsave">
                                    <asp:Button ID="Button1" runat="server" class="x-btn Grey main" OnClick="btn_submit_Click"
                                        Text="Submit" ValidationGroup="ForgotPsWrd" OnClientClick="return ValidateForgotControls();" />
                                </div>
                                <div id="div_btnsaveprocess" class="x-btnpro Grey main" align="center">
                                    <img src="<%=strImagepath %>images/radimg1.gif" class="trans" alt="loading" border="0" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div align="left" id="footer_content">
            <%----------- Footer Area div -------------%>
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
    </div>
    </form>
</body>
</html>
