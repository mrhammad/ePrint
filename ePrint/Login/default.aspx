<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ePrint.login" %>


<form id="form1" runat="server">

<table align="center" cellpadding="0" cellspacing="1" class="divMainlogin" width="400">
                            <tr style="height: 5px">
                                <td align="center" style="padding-bottom: 10px;">
                                    <span class="Maintext">
                                        Login</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div>
                                        <div>
                                            <table align="center" cellpadding="2" cellspacing="4" border="0" width="100%">
                                                <tr>
                                                    <td colspan="2" align="left" width="30%">
                                                        <span id="lblEmail" class="Maintext">Email</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <div style="margin-top: -3px; height: 55px;">
                                                            <input name="email" type="text" id="email" size="30" class="LoginText" /><div id="error_email" style="display: none;">
                                                                </div>
                                                            <span id="RequiredFieldValidator1" class="Redver7" style="display:inline-block;width:150px;font-size:11px;display:none;">Please enter Email</span>
                                                            <span id="RegularExpressionValidator1" class="Redver7" style="display:inline-block;width:150px;display:none;">Invalid Email</span>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="left" width="30%">
                                                        <span id="lblPassword" class="Maintext">Password</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" valign="middle">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <div style="margin-top: -3px; height: 50px;">
                                                                        <input type="hidden" name="hdnpassword" id="hdnpassword" />
                                                                        <input name="password" type="password" id="password" class="LoginText" size="40" style="vertical-align: top;" />
                                                                        <div id="error_password" class="errtable1" style="display: none;">
                                                                        </div>
                                                                        <br />
                                                                        <span id="RequiredFieldValidator2" class="Redver7" style="display:inline-block;width:150px;font-size:11px;display:none;">Please enter Password</span>
                                                                    </div>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td style="width: 205px;">
                                                                    <div id="div_btnlogin" style="display: block; float: left;">                                                                        
                                                                        <asp:Button ID="btnlogin" runat="server" OnClick="btnLogIN_Click" Text="Login" class="Loginbuttoscss"/>
                                                                        <input type="hidden" name="hdn_login" id="hdn_login" />
                                                                        <input type="hidden" name="hdn_pass" id="hdn_pass" />
                                                                    </div>
                                                                    <div id="div_process" style="display: none; float: right;">
                                                                        <img src="https://demo.eprintsoftware.com/images/radimg1.gif" alt="loading" border="0" style="margin-left: 75px; margin-top: 3px;" />
                                                                    </div>
                                                                </td>
                                                                <td style="width: 50%; background-color: #F2F2F2; margin-left: -5px; border-radius: 4px;">
                                                                    <div style="float: left; margin-left: 12px; margin-top: -4px;" class="squaredThree">
                                                                        <input name="chkremember" type="checkbox" id="chkremember" value="Remember me" style="display: none;" />
                                                                        <label for="chkremember" style="margin-left: 0px;">
                                                                        </label>
                                                                    </div>
                                                                    <div style="margin-left: 0px; margin-top: 1px;">
                                                                        <span id="lblRememberMe" style="font-family: Helvetica,sans-serif; font-size: 14px; margin-left: 25px; color: #595959;">Stay logged in</span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table align="center" width="278px" cellspacing="0" cellpadding="0" border="0" style="display: none; margin-left: -0px;"
                                                            id="sitedisp">
                                                            <tr>
                                                                <td class="error_yelloADMIN" align="left" colspan="2" style="border-radius: 2px;">
                                                                    <div style="margin-bottom: 3px;">
                                                                        <span id="lblRemembermeNote">By selecting "remember me" you will stay logged into this computer until you click logout. If this is a public computer please do not use this feature.</span>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table style="display: none" width="100%" cellspacing="0" cellpadding="0" align="right">
                                                            <tr>
                                                                <td class="errtable1" align="center" colspan="2">
                                                                    <div class="errorheader" id="test">
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

  </form>