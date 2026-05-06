<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ePrint.MyPublicStore.Login" masterpagefile="~/Templates/MasterPageDefault.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="loginMain_div" class="contentArea_Background">
        <div id="div_NavigationID" runat="server" class="navigation_div">
            <a href="<%=strSitepath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <%=objLanguage.GetLanguageConversion("Login") %>
        </div>
        <div id="login_Backgroung">
            <div id="login_content">
                <div id="loginHeader" class="Header_Background">
                    <strong><span id="spnLoginID" runat="server">
                        <%#objLanguage.GetLanguageConversion("Login_or_Create_an_Account")%></span></strong>
                </div>
                <br />
                <div id="div_InvalidMsg" runat="server" class="displayNone">
                    <div id="invaliedMsg_div">
                        <div id="invaliedMsg_image">
                            <img id="imgError" runat="server" alt="Error" />
                        </div>
                        <div id="invaliedMsg_details">
                            <asp:Label ID="lblSucess" runat="server" Text="Invalid login or password."></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="loginArea">
                    <table>
                        <tr>
                            <td id="td_NewUserID" runat="server">
                                <div id="login_left">
                                    <div id="leftHeader">
                                        <strong>
                                            <asp:Label ID="lbl_NewUser" runat="server" Text="NEW CUSTOMERS"></asp:Label>
                                        </strong>
                                    </div>
                                    <br />
                                    <div>
                                        <p>
                                            <%=objLanguage.GetLanguageConversion("Login_Note1")%><br />
                                            <%=objLanguage.GetLanguageConversion("Login_Note2")%><br />
                                            <%=objLanguage.GetLanguageConversion("Login_Note3")%>
                                        </p>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <div>
                                        <span>
                                            <asp:Button ID="btn_createAccount" runat="server" class="WS_Buttons_Style" Text="Create an Account"
                                                OnClick="btn_createAccount_Click" TabIndex="0" OnClientClick="javascript:loadingimage(this.id,'div_btneditsaveprocess');" /></span>
                                    </div>
                                    <div id="div_btneditsaveprocess" class="displayNone textalignCenter WS_Buttons_Style">
                                        <img src="<%=strSitepath%>images/StoreImages/radimg1.gif" alt="loading" border="0" />
                                    </div>
                                </div>
                            </td>
                            <td valign="top">
                                <div id="login_right">
                                    <div id="rightHeader">
                                        <strong>
                                            <asp:Label ID="lbl_RegisteredCustomer" runat="server" Text="REGISTERED CUSTOMERS"></asp:Label>
                                        </strong>
                                    </div>
                                    <div>
                                        <br />
                                        <strong>
                                            <%=objLanguage.GetLanguageConversion("Used_us_before")%>
                                        </strong>
                                        <br />
                                        <%=objLanguage.GetLanguageConversion("Please_login_below")%>
                                        <br />
                                        <br />
                                        <asp:Label ID="lbl_loginemail" runat="server"><%=objLanguage.GetLanguageConversion("Email_Address")%> </asp:Label>
                                        <label id="lbl_starColor" class="mandatoryField">
                                            *</label>
                                        <div>
                                            <asp:TextBox ID="txt_loginemail" runat="server" class="ws_txtWidth260" TabIndex="1"
                                                onkeypress="return capturekeys(event);"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="req_" runat="server" ControlToValidate="txt_loginemail"
                                                Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="CreateAccount"
                                                SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_loginemail"
                                                Display="Dynamic" ErrorMessage="Please enter a valid email address. For example johndoe@domain.com"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="true"
                                                ValidationGroup="CreateAccount"></asp:RegularExpressionValidator>
                                        </div>
                                        <br />
                                        <asp:Label ID="lbl_loginpassword" runat="server"><%=objLanguage.GetLanguageConversion("Password") %> </asp:Label>
                                        <label id="Label1" class="mandatoryField">
                                            *</label>
                                        <div>
                                            <asp:TextBox ID="txt_loginpassword" runat="server" class="ws_txtWidth260" TextMode="Password"
                                                TabIndex="2" onkeypress="return capturekeys(event);"></asp:TextBox><br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_loginpassword"
                                                ErrorMessage="This is a required field." SetFocusOnError="true" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div id="buttons_set" class="floatLeft width100p">
                                        <table>
                                            <tr>
                                                <td>
                                                    <div class="floatLeft">
                                                        <asp:Button ID="BtnLogin" runat="server" class="WS_Buttons_Style" OnClick="Onclick_BtnLogin"
                                                            OnClientClick="if(Page_ClientValidate()) {javascript:loadingimage(this.id,'div_process');} else {return false;}"
                                                            TabIndex="3" Text="Login" ValidationGroup="CreateAccount" />
                                                        <div id="div_process" class="displayNone textalignCenter WS_Buttons_Style">
                                                            <img src="images/StoreImages/radimg1.gif" alt="loading" border="0" />
                                                        </div>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="login_RqdFldMsg_div">
                                                        <label id="Label29" class="mandatoryField">
                                                            *
                                                            <%=objLanguage.GetLanguageConversion("Required_Fields")%></label></div>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="loginPage_forgotpwd_link_div">
                                            <a href="<%=strSitepath%>forgotpassword<%=FileExtension %>" id="lnk_forgotpwd" target="_self"
                                                class="anchorColor">
                                                <%=objLanguage.GetLanguageConversion("Forgot_your_password")%></a>
                                        </div>
                                    </div>
                                    <div id="div_private" runat="server">
                                        <br />
                                        <br />
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        function capturekeys(e) {
            var evts = e ? e : window.event;
            var bt1 = document.getElementById("<%=BtnLogin.ClientID %>");
            if (bt1) {
                if (evts.keyCode == 13) {
                    bt1.click();
                    return false;
                }
            }
        }
    
    </script>
</asp:Content>
