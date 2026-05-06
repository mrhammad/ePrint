<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ePrint.WebStore.Login" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <noscript>
        Your browser does not support JavaScript! ...
    </noscript>
    <link href="<%#StyleSheetPathMaster +"/Themes/StyleSheet_B2B.css"%>" id="Link1" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/StyleSheet_B2B.css"%>" id="MainStyle2" rel="Stylesheet"
        type="text/css" />
    <link href="<%#StyleSheetPath +"/Themes/CustomStyleSheet.css"%>" id="Link2" rel="Stylesheet"
        type="text/css" />
</head>
<script src="js/commonloading.js?VN='<%#VersionNumber%>'" type="text/javascript"></script>
<script src="js/Slide/jquery-1.2.6.min.js?VN#'<%#VersionNumber%>'" type="text/javascript"></script>
<body id="BodyBackColor" runat="server">
    <form id="form1" runat="server" defaultbutton="Button1">
    <asp:HiddenField ID="hdnAccountID" runat="server" Value="0" />
    <asp:ScriptManager ID="sm1" runat="server" EnablePartialRendering="true" EnablePageMethods="true">
        <Services>
            <asp:ServiceReference Path="~/AutoFill.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="LoginPage">
        <div>
            <table id="tblheaderimage" runat="server">
                <tr>
                    <td id="tdheaderimage" runat="server" valign="top">
                        <asp:PlaceHolder ID="ph_headerLeft" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
            </table>
            <div>
                <div align="center">
                    <br />
                    <div align="center">
                        <%-- <h2>--%>
                        <asp:Label ID="lblLogInHead" runat="server" CssClass="LoginHeaderTest" Text=""></asp:Label>
                        <%--</h2>--%>
                    </div>
                    <br />
                    <div id="div_InvalidMsg" runat="server" class="DisplayNone">
                        <div id="invaliedMsg_div_Login">
                            <div id="invaliedMsg_image_Login">
                                <img id="imgError" runat="server" alt="Error" />
                            </div>
                            <div id="invaliedMsg_details_Login">
                                <asp:Label ID="lblSucess" runat="server" Style="font-family: verdana,arial,helvetica;
                                    font-size: 11px;" Text="Invalid email or password."></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div id="RegtxtEmail" class="DisplayNone">
                            <div class="div-EmailRegularExpression">
                                <span class="RegularExpressionLine1">
                                    <%#objLanguage.GetLanguageConversion("Please_enter_a_valid_email_address")%>
                                    <br />
                                </span><span class="RegularExpressionLine2">
                                    <%#objLanguage.GetLanguageConversion("Example_MailID")%></span>
                            </div>
                        </div>
                    </div>
                    <div class="divB2Blogin" align="center" width="400">
                        <table class="Login-Table" cellpadding="0" cellspacing="1">
                            <tr style="height: 5px">
                                <td align="center" style="padding-bottom: 10px;">
                                    <span class="Maintext">
                                        <%#objLanguage.GetLanguageConversion("Login")%></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <div>
                                            <table align="center" cellpadding="2" cellspacing="4" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2" align="left" width="30%" style="padding-bottom: 8px;">
                                                        <asp:Label ID="lblbl" CssClass="Maintext" runat="server" Text=""><%#objLanguage.GetLanguageConversion("Email") %></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="margin-top: -3px; height: 55px;">
                                                            <asp:TextBox ID="txtEmail" runat="server" size="30" class="LoginText"></asp:TextBox>
                                                            <%--<input type="text" id="txtEmail" runat="server" name="useremail" size="30" class="LoginText"
                                                                value="" /><div id="error_email" style="display: none;">
                                                                </div>--%>
                                                            <asp:RequiredFieldValidator CssClass="Redver7" Width="150px" ID="RequiredFieldValidator1"
                                                                runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Email"
                                                                ForeColor="" Style="font-size: 11px;"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="left" width="30%" style="padding-bottom: 8px;">
                                                        <%-- <asp:Label ID="Label2" CssClass="Maintext" runat="server"></asp:Label>--%>
                                                        <asp:Label ID="Label2" runat="server" Text="Password" CssClass="Maintext"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" valign="middle">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div id="div_password" runat="server" style="margin-top: -3px; height: 50px;">
                                                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="LoginText" TextMode="Password"
                                                                            size="40" Style="vertical-align: top;"></asp:TextBox>
                                                                        <div id="error_password" class="errtable1" style="display: none;">
                                                                        </div>
                                                                        <br />
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                                                            Display="Dynamic" ErrorMessage="Please Enter Password" CssClass="Redver7" Width="150px"
                                                                            ForeColor="" Style="font-size: 11px;"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td style="width: 205px;">
                                                                    <div id="div_btnsave" style="display: block; float: left;">
                                                                        <asp:Button ID="Button1" runat="server" CausesValidation="true" class="x-btn Grey main"
                                                                            CssClass="Loginbuttoscss" OnClick="Onclick_BtnLogin" Text="Login" TabIndex="0"
                                                                            OnClientClick="if(Page_ClientValidate()) {javascript:loadingimagelogin('Button1','div_process');} else {return false;}" />
                                                                    </div>
                                                                    <div id="div_process" style="display: none; float: right;">
                                                                        <img src="<%#strImagepath %>images/radimg1.gif" alt="loading" border="0" style="margin-left: 75px;
                                                                            margin-top: 3px;" />
                                                                    </div>
                                                                </td>
                                                                <td style="width: 50%; background-color: #F2F2F2; margin-left: -5px; border-radius: 4px;">
                                                                    <div id="div_rememberme" runat="server" style="float: left; margin-left: 12px; margin-top: 10px;"
                                                                        class="squaredThree">
                                                                        <%--<asp:CheckBox ID="chkrememberme" runat="server" name="save_password" value="1" Style="display: none;" />
                                                                        <label for="chkrememberme" style="margin-left: 0px;">
                                                                        </label>--%>
                                                                        <input type="checkbox" id="chkrememberme" runat="server" name="save_password" value="1"
                                                                            style="display: none;" />
                                                                        <label for="chkrememberme" style="margin-left: 0px;">
                                                                        </label>
                                                                    </div>
                                                                    <div style="margin-left: 0px; margin-top: 15px;">
                                                                        <asp:Label ID="lblRememberMe" runat="server" Style="font-family: Helvetica,sans-serif;
                                                                            font-size: 14px; margin-left: 25px; color: #595959;"></asp:Label>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table cellpadding="0" cellspacing="1" width="400" style="margin-top: 30px;">
                        <tr>
                            <td id="ForgotPassAndRegistration" runat="server">
                                <table class="width100p">
                                    <tr>
                                        <td>
                                            <div class="floatLeft paddingTop5">
                                                <asp:LinkButton ID="LnkForGotPass" runat="server" Style="display: none;" CausesValidation="false"
                                                    Text="" OnClick="LnkForGotPass_Click" CssClass="button"></asp:LinkButton>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="floatRight paddingTop5">
                                                <asp:LinkButton ID="lnkRegister" runat="server" Style="display: none;" Text="" CausesValidation="false"
                                                    OnClick="Onclick_btnRegister" CssClass="button"></asp:LinkButton>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="floatRight paddingTop5" style="padding-left: 8px;">
                                                <a id="lnktoInkiAdminMail" style="display: none;" runat="server" href="mailto:sales@inkifingus.com.au?">
                                                    Contact Sales Support</a>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="clearBoth height15px">
            </div>
            <div align="center">
                <asp:Label ID="lblBelowLogin" runat="server" Text="" CssClass="BelowLoginText"></asp:Label>
            </div>
        </div>
        <div align="left" id='<%#footer_id%>'>
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
