<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="ePrint.MyPublicStore.forgotpassword" masterpagefile="~/Templates/masterPageDefault.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="js/commonloading.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <div id="forgetpwd_div" class="contentArea_Background">
        <div class="navigation_div">
            <a href="<%=strSitepath %>">
                <asp:Label ID="lbl_home" runat="server"></asp:Label>
            </a>
            <asp:Label ID="lbl_spliter" runat="server" Text=">"></asp:Label>
            <a href="<%=strSitepath %>login.aspx">
                <%=objLanguage.GetLanguageConversion("Login") %></a> >
            <%=objLanguage.GetLanguageConversion("Forgot_Password") %>
        </div>
        <div id="forgetpwd_background">
            <div id="forgetpwdContent_div">
                <div id="heading" class="Header_Background">
                    <strong>&nbsp;&nbsp;<%=objLanguage.GetLanguageConversion("Forgot_your_password")%>
                    </strong>
                </div>
                <div id="div_emailMsg" class="div_emailMsg displayNone" runat="server">
                    <div class="emailMsg">
                        <div id="emailMsg_image">
                            <img id="imgSucess" runat="server" alt=" " />
                        </div>
                        <div id="emailMsg_sucessMsg">
                            <div class="floatLeft">
                                <asp:Label ID="lblSucess" runat="server" Text=""></asp:Label></div>
                            <div id="div_linkaccount" runat="server" class="linkaccount_div">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearBoth">
                </div>
                <div id="div_emailMsg_Invalid" class="div_emailMsg_Invalid displayNone" runat="server">
                    <div class="emailMsg_Invalid">
                        <div id="emailMsg_image_Invalid">
                            <img id="imgSucess_Invalid" runat="server" src="ImageHandler.ashx?Imagename=i_msg-error.gif&type=r&aid='<%=AccountID %>'&cid='<%=CompanyID %>'"
                                alt=" " />
                        </div>
                        <div id="emailMsg_sucessMsg_Invalid">
                            <div class="floatLeft">
                                <asp:Label ID="lblSucess_Invalid" runat="server" Text=""></asp:Label></div>
                            <div id="div_linkaccount_Invalid" runat="server" class="linkaccount_div">
                                <a href="<%=strSitepath%>create_account<%=FileExtension %>" id="link_account">new account</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearBoth">
                </div>
                <div id="content_div">
                    <div id="div_retirve">
                        <strong>
                            <asp:Label ID="lbl_forgotPassword" runat="server" Text="REGISTERED CUSTOMERS"><%=objLanguage.GetLanguageConversion("REGISTERED_CUSTOMERS")%></asp:Label>
                        </strong>
                    </div>
                    <div class="clearBoth">
                    </div>
                    <div id="div_email">
                        <asp:Label ID="Label1" runat="server" Text="Please enter your email below and we will send your password."><%=objLanguage.GetLanguageConversion("Forgot_Password_Note")%></asp:Label><br />
                        <br />
                        <b>
                            <asp:Label ID="lbl_loginemail" runat="server" Text="Email Address"><%=objLanguage.GetLanguageConversion("Email_Address")%></asp:Label></b>
                        <label id="lbl_starColor" class="mandatoryField">
                            *</label><br />
                        <asp:TextBox ID="txt_loginemail" runat="server" class="ws_txtWidth260" TabIndex="1"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="reqemail" runat="server" ControlToValidate="txt_loginemail"
                            Display="Dynamic" ErrorMessage="This is a required field." ValidationGroup="email"
                            SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_loginemail"
                            Display="Dynamic" ErrorMessage="Please enter a valid email address. For example johndoe@domain.com"
                            ValidationExpression="^((['\w])*[0-9a-zA-Z]([-.'\w]*[0-9a-zA-Z])*(['\w])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                            SetFocusOnError="true" ValidationGroup="email"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="cvEmailID" runat="server" ErrorMessage="" Display="Dynamic"
                            ControlToValidate="txt_loginemail" ValidateEmptyText="false" ValidationGroup="email"
                            OnServerValidate="custEmailID_Duplicacy_ServerValidate"></asp:CustomValidator>
                    </div>
                    <div class="clearBoth">
                    </div>
                </div>
                <div id="forgetPassword_content_bottom">
                    <div id="forgetPassword_content_bottom_left">
                        <br />
                        <br />
                        <a href="login.aspx" class="anchorColor"><small>« </small>
                            <%=objLanguage.GetLanguageConversion("Back") %></a>
                    </div>
                    <div id="forgetPassword_content_bottom_right">
                        <label id="Label29" class="mandatoryField">
                            *
                            <%=objLanguage.GetLanguageConversion("Required_Fields")%></label>
                        <br />
                        <br />
                        <div class="ForgotPSWD_SubmitBtn_Div">
                            <div id="div_CreateAccount123">
                                <asp:Button ID="Button1" runat="server" class="WS_Buttons_Style" TabIndex="2" Text="Submit"
                                    ValidationGroup="email" OnClick="btn_submit_Click" OnClientClick="javascript:if(Page_ClientValidate())loadingimage(this.id,'div_btneditsaveprocess');" />
                            </div>
                            <div id="div_btneditsaveprocess" class="displayNone textalignCenter WS_Buttons_Style">
                                <img src="<%=strSitepath%>images/StoreImages/radimg1.gif" alt="loading" border="0" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="clearBoth">
                </div>
            </div>
        </div>
    </div>
</asp:Content>

