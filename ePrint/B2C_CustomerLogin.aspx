<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/innerMasterPage_withoutLeftTD.Master" CodeBehind="~/B2C_CustomerLogin.aspx.cs" Inherits="ePrint.B2C_CustomerLogin" Title="Untitled Page" EnableViewStateMac="false" EnableEventValidation="false" Theme="Theme1" %>






<%@ Register TagPrefix="UC" TagName="Header_MIS" Src="~/usercontrol/settings/settings_mis_headerpanel.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="<%=strSitepath %>js/approvalsystem.js?VN='<%=VersionNumber%>'" type="text/javascript"></script>
    <UC:Header_MIS ID="header_mis1" runat="server" />
    <div align="left" style="width: 100%; border: 0px solid red">
        <div style="width: 60%">
            <asp:UpdatePanel ID="UpdatePanel1" RenderMode="Inline" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


    <div id="overlay">

        <div id="popup">
            <div id="divLogInNew">
                <div id="loginoverlay" class="web_dialog_overlay_login">
                </div>
                <h2>SignUp</h2>
                <table>
                    <tr>
                        <td>
                            <div class="one" id="signUp-error" style="visibility: hidden; color: red">
                                Please enter your first name
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Company Name</label>
                        </td>
                        <td>
                            <input type="text" autocomplete="off" autocorrect="off" placeholder="Company Name" name="company_name" class="txtbx txtbx-wid" id="txtcompanyname">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="txtuname">Name</label>
                        </td>
                        <td>
                            <input type="text" autocorrect="off" autocomplete="off" placeholder="First Name"
                                name="first_name" class="txtbx txtbx-wid1" id="txtuname">
                            <input type="text" autocorrect="off" autocomplete="off" placeholder="Last Name" name="last_name"
                                class="txtbx txtbx-wid1 lname" id="txtlname">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="txtsignupEmail">
                                Email
                            </label>
                        </td>
                        <td>
                            <input type="email" autocorrect="off" autocomplete="off" autocapitalize="off" name="signup_email"
                                class="txtbx txtbx-wid txt-error" id="txtsignupEmail" placeholder="example@example.com">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="txtupass">
                                Password
                            </label>
                        </td>
                        <td>
                            <input type="password" placeholder="Enter Password" name="password" class="txtbx txtbx-wid1"
                                id="txtupass">
                            <input type="password" placeholder="Confirm Password" name="confirm_password" class="txtbx txtbx-wid1 lname"
                                id="txtcpass">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Button runat="server" class="clr-fff btn-common2 sign-btn" ID="Button1233"
                                OnClientClick="validateaccount(); return false;" Text="Sign Up" value="Sign Up" />
                            <div id="div_loading_btnsaveSignup" style="display: none; width: 46px; padding-bottom: 2px; padding-top: 2px; border: solid 1px #a3a3a3; border-radius: .5em; text-align: center; background: -webkit-gradient(linear, left top, left bottom, from(#E8E8E8), to(#F9F8F8));">
                                <image src="../images/radimg1.gif" alt="loading" class="loadingimg"></image>
                            </div>
                        </td>
                    </tr>
                </table>



                <div class="clear">
                </div>
            </div>




        </div>


    </div>


</asp:Content>

















